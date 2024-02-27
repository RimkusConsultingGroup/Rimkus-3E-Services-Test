using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TE3EEntityFramework.Client.RCGKENTCMS;
using TE3EEntityFramework.Datasource;
using TE3EEntityFramework.Datasource.RCGKENTCMS.DataModel;
using TE3EEntityFramework.Setting;

namespace TE3EEntityFramework.Client
{
    public class CMSDynamicsClient
    {
        private CrmServiceClient svc;
        private ColumnSet accountColumns = new ColumnSet("accountid", "name", "new_clienttype", "telephone1", "emailaddress1", "address1_line1", "address1_line2", "address1_city", "address1_stateorprovince", "address1_postalcode", "primarycontactid");
        private ColumnSet contactsColumns = new ColumnSet("salutation", "firstname", "lastname", "telephone1", "emailaddress1", "address1_line1", "address1_line2", "address1_city", "address1_stateorprovince", "address1_postalcode");
        private ColumnSet addressColumns = new ColumnSet("telephone1", "line1", "line2", "city", "stateorprovince", "postalcode", "addresstypecode");

        public CMSDynamicsClient(int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        {
            var cmsSQLClient = new CMSSQLClientV2();
            var dynamicsSetting = cmsSQLClient.GetDynamics365Configuration(sqlCommandTimeout, env);


            if (dynamicsSetting != null)
            {
                svc = new CrmServiceClient($"Url = {dynamicsSetting.BaseUrl}; AuthType = Office365; UserName = {dynamicsSetting.Username}; Password = {dynamicsSetting.Password}; RequireNewInstance = True");
            }
            else
            {
                throw new Exception("Dynamics365Configurations are missing in Database.");
            }
        }

        public Guid AddOrUpdateCustomer(CMSCustomerProfile inCustomer)
        {
            Entity account, primaryContact, address;
            bool updateAccount = false, updateContact = false;
            Guid accountId, contactId;

            {
                // Account
                // Exact name OR match email domain 

                var accountConditionsList = new List<ConditionExpression>()
                {
                    CreateSearchCondition("name", inCustomer.CompanyName?.ToUpper())
                };

                if (!string.IsNullOrEmpty(inCustomer.Email) && inCustomer.Email.Split('@').Length > 1)
                {
                    var domain = inCustomer.Email.Split('@')[1].Trim().ToLower();
                    accountConditionsList.Add(CreateSearchCondition("emailaddress1", domain, ConditionOperator.EndsWith));
                }

                account = SearchFirstOrDefault("account", accountConditionsList, LogicalOperator.Or);
                if (account == null)
                {
                    account = new Entity("account");
                    primaryContact = new Entity("contact");
                    address = new Entity("customeraddress");
                }
                else
                {
                    updateAccount = true;
                    address = SearchFirstOrDefault("customeraddress", new List<ConditionExpression>() { CreateSearchCondition("parentid", (Guid)account["accountid"]) });
                    if (!string.IsNullOrEmpty(inCustomer.Email))
                    {
                        // Contact 
                        // Exact email
                        var contactConditionsList = new List<ConditionExpression>()
                        {
                            CreateSearchCondition("parentcustomerid", account["accountid"]),
                            CreateSearchCondition("emailaddress1", inCustomer.Email, ConditionOperator.EndsWith)
                        };

                        primaryContact = SearchFirstOrDefault("contact", contactConditionsList);
                        if (primaryContact == null)
                        {
                            primaryContact = new Entity("contact");
                        }
                        else
                        {
                            updateContact = true;
                        }
                    }
                    else
                    {
                        primaryContact = new Entity("contact");
                    }
                }
            }

            #region Data Mapping

            // Account Fields
            account["name"] = ValidateStringLength(inCustomer.CompanyName, 160).ToUpper();
            account["new_masterrelatednumber"] = ValidateStringLength(inCustomer.ClientNumber, 75);
            account["new_clienttype"] = new OptionSetValue(CompanyTypeToDynamicsOptionSet(inCustomer.CompanyType?.ToLower()?.Trim() ?? "corporation"));
            if (!updateAccount)
                account["emailaddress1"] = ValidateStringLength(inCustomer.Email, 100).ToLower();
            account["telephone1"] = ValidateStringLength(inCustomer.Phone, 50);
            account["address1_line1"] = ValidateStringLength(inCustomer.CompanyAddress1, 250);
            account["address1_line2"] = ValidateStringLength(inCustomer.CompanyAddress2, 250);
            account["address1_city"] = ValidateStringLength(inCustomer.CompanyAddressCity, 80);
            account["address1_stateorprovince"] = ValidateStringLength(inCustomer.CompanyAddressState, 50);
            account["address1_postalcode"] = ValidateStringLength(inCustomer.CompanyAddressZip, 20);

            // Address Fields
            address["telephone1"] = ValidateStringLength(inCustomer.Phone, 50);
            //address["addresstypecode"] = new OptionSetValue(200003);
            address["line1"] = ValidateStringLength(inCustomer.CompanyAddress1, 250);
            address["line2"] = ValidateStringLength(inCustomer.CompanyAddress2, 250);
            address["city"] = ValidateStringLength(inCustomer.CompanyAddressCity, 80);
            address["stateorprovince"] = ValidateStringLength(inCustomer.CompanyAddressState, 50);
            address["postalcode"] = ValidateStringLength(inCustomer.CompanyAddressZip, 20);

            // Contact Fields
            primaryContact["arb_3eentityid"] = ValidateStringLength(inCustomer.ContactID?.ToString(), 100);
            primaryContact["salutation"] = ValidateStringLength(inCustomer.Salutation, 100);
            primaryContact["firstname"] = ValidateStringLength(inCustomer.FirstName, 50);
            primaryContact["lastname"] = ValidateStringLength(inCustomer.LastName, 50);
            primaryContact["telephone1"] = ValidateStringLength(inCustomer.Phone, 50);
            primaryContact["emailaddress1"] = ValidateStringLength(inCustomer.Email, 100).ToLower();
            primaryContact["address1_line1"] = ValidateStringLength(inCustomer.CompanyAddress1, 250);
            primaryContact["address1_line2"] = ValidateStringLength(inCustomer.CompanyAddress2, 250);
            primaryContact["address1_city"] = ValidateStringLength(inCustomer.CompanyAddressCity, 80);
            primaryContact["address1_stateorprovince"] = ValidateStringLength(inCustomer.CompanyAddressState, 50);
            primaryContact["address1_postalcode"] = ValidateStringLength(inCustomer.CompanyAddressZip, 20);

            #endregion

            try
            {

                if (updateAccount)
                {
                    svc.Update(account);
                    accountId = (Guid)account["accountid"];
                }
                else
                {
                    accountId = svc.Create(account);
                    // Associate Address
                    address["parentid"] = new EntityReference("account", accountId);
                    // Create address
                    Guid _addressId = svc.Create(address);
                }

                if (updateContact)
                {
                    svc.Update(primaryContact);
                    svc.Update(address);
                }
                else
                {
                    // Associate Contact
                    primaryContact["parentcustomerid"] = new EntityReference("account", accountId);

                    // Create contact 
                    contactId = svc.Create(primaryContact);

                    var relatedEntities = new EntityReferenceCollection();
                    relatedEntities.Add(new EntityReference("account", accountId));

                    // Create an object that defines the relationship between the contact and account.
                    var contactRelationship = new Relationship("account_primary_contact");

                    //Associate the contact with the account.
                    svc.Associate("contact", contactId, contactRelationship, relatedEntities);

                }

                return accountId;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<OutCustomerProfileCM> RetrieveLastModifiedCustomers(int hours = 24)
        {
            // Create the ConditionExpression.
            ConditionExpression condition = new ConditionExpression();

            // Set the condition for the retrieval to be when the contact's address' city is Sammamish.
            condition.AttributeName = "modifiedon";
            condition.Operator = ConditionOperator.GreaterEqual;
            DateTime maxCrmModified = DateTime.UtcNow.AddDays(hours * -1);
            condition.Values.Add(maxCrmModified);

            // Create the FilterExpression.
            FilterExpression filter = new FilterExpression();

            // Set the properties of the filter.
            filter.FilterOperator = LogicalOperator.And;
            filter.Conditions.Add(condition);

            // Create the QueryExpression object.
            QueryExpression accountQuery = new QueryExpression();

            // Set the properties of the QueryExpression object.
            accountQuery.EntityName = "account";
            accountQuery.ColumnSet = accountColumns;
            //accountQuery.ColumnSet = new ColumnSet(true);
            accountQuery.Criteria = filter;

            accountQuery.LinkEntities.Add(new LinkEntity("account", "contact", "primarycontactid", "contactid", JoinOperator.Inner));
            accountQuery.LinkEntities[0].Columns = contactsColumns;
            accountQuery.LinkEntities[0].EntityAlias = "PrimaryContact";


            accountQuery.LinkEntities.Add(new LinkEntity("account", "customeraddress", "accountid", "parentid", JoinOperator.Inner));
            accountQuery.LinkEntities[1].Columns = addressColumns;
            accountQuery.LinkEntities[1].EntityAlias = "PrimaryAddress";

            // Sorting by Modification
            accountQuery.AddOrder("modifiedon", OrderType.Descending);

            accountQuery.Distinct = false;

            // Retrieve the accounts.
            var accountCollection = svc.RetrieveMultiple(accountQuery);
            var customersList = new List<OutCustomerProfileCM>();
            foreach (var item in accountCollection.Entities)
            {
                var result = new OutCustomerProfileCM();
                result.CompanyName = item["name"].ToString();
                result.CompanyType = CompanyTypeToDatabaseValue(((OptionSetValue)item["new_clienttype"]).Value);
                result.Salutation = ((AliasedValue)item["PrimaryContact.salutation"]).Value.ToString();
                result.FirstName = ((AliasedValue)item["PrimaryContact.firstname"]).Value.ToString();
                result.LastName = ((AliasedValue)item["PrimaryContact.lastname"]).Value.ToString();
                result.Email = item["emailaddress1"].ToString();
                result.Phone = item["telephone1"].ToString();
                result.CompanyAddress1 = item["address1_line1"].ToString();
                //result.CompanyAddress2 = item["address1_line2"].ToString();
                result.CompanyAddressCity = item["address1_city"].ToString();
                result.CompanyAddressState = item["address1_stateorprovince"].ToString();
                result.CompanyAddressZip = item["address1_postalcode"].ToString();
                //result.ClientID = (Guid)item["accountid"]; --todo: need to get client id from 3e
                //result.ClientNumber = ???
                customersList.Add(result);

            }

            return customersList;
        }

        #region Helper

        private int CompanyTypeToDynamicsOptionSet(string value)
        {
            switch (value)
            {
                case "adjustment company":
                    return 7;
                case "attorney":
                    return 1;
                case "corporation":
                    return 2;
                case "expert":
                    return 8;
                case "government entities":
                    return 3;
                case "independent adjuster":
                    return 4;
                case "insurance broker":
                    return 9;
                case "insurance company":
                    return 5;
                case "third party administrator":
                    return 6;
                default:
                    return -1;
            }
        }
        private string CompanyTypeToDatabaseValue(int value)
        {
            switch (value)
            {
                case 7:
                    return "Adjustment Company";
                case 1:
                    return "Attorney";
                case 2:
                    return "Corporation";
                case 8:
                    return "Expert";
                case 3:
                    return "Government Entities";
                case 4:
                    return "Independent Adjuster";
                case 9:
                    return "Insurance Broker";
                case 5:
                    return "Insurance Company";
                case 6:
                    return "Third Party Administrator";
                default:
                    return String.Empty;
            }
        }
        private Entity SearchFirstOrDefault(string entityName, List<ConditionExpression> conditions, LogicalOperator logicalOperator = LogicalOperator.And)
        {

            var collection = Search(entityName, conditions, logicalOperator);

            if (collection != null && collection.Entities != null && collection.Entities.Count > 0)
            {
                return collection.Entities[0];
            }
            else
                return null;
        }
        private EntityCollection Search(string entityName, List<ConditionExpression> conditions, LogicalOperator logicalOperator = LogicalOperator.And)
        {
            // Create the FilterExpression.
            FilterExpression filter = new FilterExpression
            {
                FilterOperator = logicalOperator
            };
            filter.Conditions.AddRange(conditions);

            // Create the QueryExpression object.
            QueryExpression query = new QueryExpression
            {
                EntityName = entityName,
                ColumnSet = new ColumnSet(true),
                Criteria = filter
            };

            // Retrieve the accounts.
            return svc.RetrieveMultiple(query);
        }

        private ConditionExpression CreateSearchCondition(string attributeName, object value, ConditionOperator conditionOperator = ConditionOperator.Equal)
        {
            // Create the ConditionExpression.
            ConditionExpression condition = new ConditionExpression
            {
                AttributeName = attributeName,
                Operator = conditionOperator
            };
            condition.Values.Add(value);
            return condition;
        }

        private void PrintEntity(Entity item)
        {
            Console.WriteLine("===============================================================");
            Console.WriteLine(item.LogicalName);
            Console.WriteLine("===========Attributes Start==================================");
            foreach (var item2 in item.Attributes)
            {
                if (item2.Value == null)
                {
                    Console.WriteLine(item2.Key + " => Null Value");
                }
                else
                if (item2.Key.Equals("primarycontactid") || item2.Key.Equals("address1_addressId"))
                {
                    Console.WriteLine(item2.Key + " => " + ((EntityReference)item2.Value).LogicalName + " => " + ((EntityReference)item2.Value).Name + " => " + ((EntityReference)item2.Value).Id);
                }
                else
                if (item2.Key.Contains("."))
                {
                    Console.WriteLine(item2.Key + " => " + ((AliasedValue)item2.Value).EntityLogicalName + " => " + ((AliasedValue)item2.Value).AttributeLogicalName + " => " + ((AliasedValue)item2.Value).Value);
                }
                else
                {
                    Console.WriteLine(item2.Key + " => " + item2.Value);
                }
            }
            Console.WriteLine("=============Attributes End============================");
            Console.WriteLine("===============================================================");
        }
        private string ValidateStringLength(string value, int length)
        {
            if (string.IsNullOrEmpty(value))
                return string.Empty;
            value = value.Trim();
            return value.Length >= length ? value.Substring(0, length) : value;
        }

        #endregion

    }
}
