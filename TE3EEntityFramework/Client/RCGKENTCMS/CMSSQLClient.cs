using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Security.Cryptography;
using TE3EEntityFramework.Data.KenticoCMS._3EProcessItem;
using TE3EEntityFramework.Data.KenticoCMS.RCGKENTCMS;
using TE3EEntityFramework.Data.Te3e.CMS.CMS.Definition;
using TE3EEntityFramework.Data.Te3e.CMS.CustomException;
using TE3EEntityFramework.Data.Te3e.CMS.Definition;
using TE3EEntityFramework.Datasource.RCGKENTCMS.DataModel;
using TE3EEntityFramework.Extension;

namespace TE3EEntityFramework.Client.RCGKENTCMS
{
    public class CMSSQLClient
    {
        public CMSSQLClient()
        {
        }

        #region Kentico CMS Te3e

        #region 3e Lookup Stmt

        public void GetEntity(int entIndex)
        {
        }

        #endregion 3e Lookup Stmt

        public CMSKenticoConfiguration GetCMSKenticoConfiguration(int sqlCommandTimeout, bool isDebug = false)
        {
            CMSKenticoConfiguration cMSKenticoConfiguration = null;

            if (isDebug)
            {
                RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities();
                rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                cMSKenticoConfiguration = rCGKENTCMS_DEV01Entities.CMSKenticoConfigurations.Select(x => x).FirstOrDefault();

            }
            else
            {
                //RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities();
                //rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                //cMSKenticoConfiguration = rCGKENTCMS_PROD01Entities.CMSKenticoConfigurations.Select(x => x).FirstOrDefault();
            }

            return cMSKenticoConfiguration;
        }



        #region CMS Table SQL Actions

        private EditKeyValuePair GetEditKeyValuePair(EditTableName editTableName, string foreignKey)
        {
            EditKeyValuePair editKeyValuePair = new EditKeyValuePair();

            switch (editTableName)
            {
                case EditTableName.MattDate:
                    editKeyValuePair.TableName = TE3EEntityExt.GetEnumDescription(editTableName);
                    editKeyValuePair.ForeignKey = foreignKey;
                    editKeyValuePair.LookupColumn = "MatterLkUp";
                    editKeyValuePair.RetColumn = "MattDateID";
                    break;

                case EditTableName.MattSite:
                    editKeyValuePair.TableName = TE3EEntityExt.GetEnumDescription(editTableName);
                    editKeyValuePair.ForeignKey = foreignKey;
                    editKeyValuePair.LookupColumn = "Site";
                    editKeyValuePair.RetColumn = "MattSiteID";
                    break;

                case EditTableName.MattPayor:
                    editKeyValuePair.TableName = TE3EEntityExt.GetEnumDescription(editTableName);
                    editKeyValuePair.ForeignKey = foreignKey;
                    editKeyValuePair.LookupColumn = "Matter";
                    editKeyValuePair.RetColumn = "MattPayorID";
                    break;

                case EditTableName.MattPayorDetail:
                    editKeyValuePair.TableName = TE3EEntityExt.GetEnumDescription(editTableName);
                    editKeyValuePair.ForeignKey = foreignKey;
                    editKeyValuePair.LookupColumn = "MattPayor";
                    editKeyValuePair.RetColumn = "MattPayorDetID";
                    break;

                case EditTableName.MattBudget:
                    editKeyValuePair.TableName = TE3EEntityExt.GetEnumDescription(editTableName);
                    editKeyValuePair.ForeignKey = foreignKey;
                    editKeyValuePair.LookupColumn = "Matter";
                    editKeyValuePair.RetColumn = "MattBudgetID";
                    break;

                case EditTableName.MattFlatFee:
                    editKeyValuePair.TableName = TE3EEntityExt.GetEnumDescription(editTableName);
                    editKeyValuePair.ForeignKey = foreignKey;
                    editKeyValuePair.LookupColumn = "Matter";
                    editKeyValuePair.RetColumn = "MattFlatFeeID";
                    break;

                case EditTableName.TechRevEngRec_CCC:
                    editKeyValuePair.TableName = TE3EEntityExt.GetEnumDescription(editTableName);
                    editKeyValuePair.ForeignKey = foreignKey;
                    editKeyValuePair.LookupColumn = "Matter";
                    editKeyValuePair.RetColumn = "TechRevEngRec_CCCID";
                    break;

                case EditTableName.MatterSpecialInvoiceTo_CCC:
                    editKeyValuePair.TableName = TE3EEntityExt.GetEnumDescription(editTableName);
                    editKeyValuePair.ForeignKey = foreignKey;
                    editKeyValuePair.LookupColumn = "MatterSpecial";
                    editKeyValuePair.RetColumn = "MatterSpecialInvoiceTo_CCCID";
                    break;

                case EditTableName.MatterSpecialInstructions_CCC:
                    editKeyValuePair.TableName = TE3EEntityExt.GetEnumDescription(editTableName);
                    editKeyValuePair.ForeignKey = foreignKey;
                    editKeyValuePair.LookupColumn = "Matter";
                    editKeyValuePair.RetColumn = "MatterSpecialInstructions_CCCID";
                    break;

                case EditTableName.MattRate:
                    editKeyValuePair.TableName = TE3EEntityExt.GetEnumDescription(editTableName);
                    editKeyValuePair.ForeignKey = foreignKey;
                    editKeyValuePair.LookupColumn = "Matter";
                    editKeyValuePair.RetColumn = "MattRateID";
                    break;

                case EditTableName.MatterRateExc:
                    editKeyValuePair.TableName = TE3EEntityExt.GetEnumDescription(editTableName);
                    editKeyValuePair.ForeignKey = foreignKey;
                    editKeyValuePair.LookupColumn = "Matter";
                    editKeyValuePair.RetColumn = "MatterRateExcID";
                    break;

                case EditTableName.IndustryGroupMatter_CCC:
                    editKeyValuePair.TableName = TE3EEntityExt.GetEnumDescription(editTableName);
                    editKeyValuePair.ForeignKey = foreignKey;
                    editKeyValuePair.LookupColumn = "Matter";
                    editKeyValuePair.RetColumn = "IndustryGroupMatter_CCCID";
                    break;
            }

            return editKeyValuePair;
        }

        public string GetEditKeyValue(EditTableName editTableName, string foreignKey, string server, string dbInstance, int sqlCommandTimeout, bool isDebug = false)
        {
            string editKeyVaue = "";
            EditKeyValuePair editKeyValuePair = GetEditKeyValuePair(editTableName, foreignKey);

            using (var objStreamReader = File.OpenText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $"datasource/rcgkentcms/datascripts/GetEditKeyValue.sql")))
            {
                string sqlStmt = objStreamReader.ReadToEnd();

                sqlStmt = sqlStmt.Replace("@server", server);
                sqlStmt = sqlStmt.Replace("@instance", dbInstance);
                sqlStmt = sqlStmt.Replace("@tableName", editKeyValuePair.TableName);
                sqlStmt = sqlStmt.Replace("@lookupColumn", editKeyValuePair.LookupColumn);
                sqlStmt = sqlStmt.Replace("@retColumn", editKeyValuePair.RetColumn);
                sqlStmt = sqlStmt.Replace("@foreignKey", editKeyValuePair.ForeignKey);

                if (isDebug)
                {
                    RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities();
                    rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                    var results = rCGKENTCMS_DEV01Entities.Database.SqlQuery<string>(sqlStmt);
                    editKeyVaue = results.Count() > 0 ? results.First() : null;
                }
                else
                {
                    //RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities();
                    //rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                    //var results = rCGKENTCMS_PROD01Entities.Database.SqlQuery<ExistingMatterClient>(sqlStmt);
                    //existingMatterClient = results.Count() > 0 ? results.First() : null;
                }
            }

            return editKeyVaue;
        }

        public int GetRefNumberID(string refType, int sqlCommandTimeout, bool isDebug = false)
        {
            int cMSRefLookup = 0;

            if (isDebug)
            {
                RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities();
                rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                var refLookups = rCGKENTCMS_DEV01Entities.CMSRefLookups.Where(x => x.RefType.ToLower() == refType.ToLower()).Select(x => x).ToList();
                cMSRefLookup = refLookups.Count() > 0 ? refLookups.First().RefNumId : 0;
            }
            else
            {
                //RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities();
                //rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                //var refLookups = rCGKENTCMS_PROD01Entities.CMSRefLookups.Where(x => x.RefType == refType).Select(x => x).ToList();
                //cMSRefLookup = refLookups.Count() > 0 ? refLookups.First().RefNumId : 0;
            }

            return cMSRefLookup;
        }

        public CMSGetMatterCode_Result GetMatterCode(T3EMatterLookupType lookupType, string lookupValue, int sqlCommandTimeout, bool isDebug = false)
        {
            CMSGetMatterCode_Result cMSGetMatterCode = null;
            var mlookupType = TE3EEntityExt.GetEnumDescription(lookupType);

            if (isDebug)
            {
                RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities();
                rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                var refLookups = rCGKENTCMS_DEV01Entities.CMSGetMatterCode(mlookupType, lookupValue).ToList();

                cMSGetMatterCode = refLookups.Any() ? refLookups.First() : null;
            }
            else
            {
                //RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities();
                //rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                //var refLookups = rCGKENTCMS_PROD01Entities.CMSGetMatterCode(mlookupType, lookupValue);
                //cMSGetMatterCode = refLookups.Count() > 0 ? refLookups.First().RefNumId : 0;
            }

            return cMSGetMatterCode;
        }

        public string GetRefType(int refNumberId, int sqlCommandTimeout, bool isDebug = false)
        {
            string refType = "";

            if (isDebug)
            {
                RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities();
                rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                var refLookups = rCGKENTCMS_DEV01Entities.CMSRefLookups.Where(x => x.RefNumId == refNumberId).Select(x => x).ToList();
                refType = refLookups.Count() > 0 ? refLookups.First().RefType : "";
            }
            else
            {
                //RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities();
                //rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                //var refLookups = rCGKENTCMS_PROD01Entities.CMSRefLookups.Where(x => x.RefNumId == refNumberId).Select(x => x).ToList();
                //refType = refLookups.Count() > 0 ? refLookups.First().RefType : "";
            }

            return refType;
        }

        public string GetClientInstrID(string server, string dbInstance, string mattIndex, string clientInst, int sqlCommandTimeout, bool isDebug = false)
        {
            string clientInstr = "";

            using (var objStreamReader = File.OpenText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $"datasource/rcgkentcms/datascripts/GetClientInstrID.sql")))
            {
                string sqlStmt = objStreamReader.ReadToEnd();

                sqlStmt = sqlStmt.Replace("@server", server);
                sqlStmt = sqlStmt.Replace("@instance", dbInstance);
                sqlStmt = sqlStmt.Replace("@mattIndex", mattIndex);
                sqlStmt = sqlStmt.Replace("@clientInst", clientInst);

                if (isDebug)
                {
                    RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities();
                    rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                    var results = rCGKENTCMS_DEV01Entities.Database.SqlQuery<string>(sqlStmt);
                    clientInstr = results.Count() > 0 ? results.First() : null;
                }
                else
                {
                    //RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities();
                    //rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                    //var results = rCGKENTCMS_DEV01Entities.Database.SqlQuery<string>(sqlStmt);
                    //clientInstr = results.Count() > 0 ? results.First() : null;
                }
            }

            return clientInstr;
        }

        public string GetInvoiceToID(string server, string dbInstance, string mattIndex, string email, int sqlCommandTimeout, bool isDebug = false)
        {
            string invoiceTo = "";

            using (var objStreamReader = File.OpenText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $"datasource/rcgkentcms/datascripts/GetInvoiceToID.sql")))
            {
                string sqlStmt = objStreamReader.ReadToEnd();

                sqlStmt = sqlStmt.Replace("@server", server);
                sqlStmt = sqlStmt.Replace("@instance", dbInstance);
                sqlStmt = sqlStmt.Replace("@mattIndex", mattIndex);
                sqlStmt = sqlStmt.Replace("@email", email);

                if (isDebug)
                {
                    RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities();
                    rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                    var results = rCGKENTCMS_DEV01Entities.Database.SqlQuery<string>(sqlStmt);
                    invoiceTo = results.Count() > 0 ? results.First() : null;
                }
                else
                {
                    //RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities();
                    //rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                    //var results = rCGKENTCMS_DEV01Entities.Database.SqlQuery<string>(sqlStmt);
                    //invoiceTo = results.Count() > 0 ? results.First() : null;
                }
            }

            return invoiceTo;
        }

        public ExistingMatterClient GetExistingMatterClient(string server, string dbInstance, string clientNumber, string mattIndex, int sqlCommandTimeout, bool isDebug = false)
        {
            ExistingMatterClient existingMatterClient = new ExistingMatterClient();

            using (var objStreamReader = File.OpenText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $"datasource/sqlscripts/GetExistingMatterClient.sql")))
            {
                string sqlStmt = objStreamReader.ReadToEnd();

                sqlStmt = sqlStmt.Replace("@server", server);
                sqlStmt = sqlStmt.Replace("@instance", dbInstance);
                sqlStmt = sqlStmt.Replace("@clientNumber", clientNumber);
                sqlStmt = sqlStmt.Replace("@mattIndex", mattIndex);

                if (isDebug)
                {
                    RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities();
                    rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                    var results = rCGKENTCMS_DEV01Entities.Database.SqlQuery<ExistingMatterClient>(sqlStmt);
                    existingMatterClient = results.Count() > 0 ? results.First() : null;
                }
                else
                {
                    //RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities();
                    //rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                    //var results = rCGKENTCMS_PROD01Entities.Database.SqlQuery<ExistingMatterClient>(sqlStmt);
                    //existingMatterClient = results.Count() > 0 ? results.First() : null;
                }
            }

            return existingMatterClient;
        }

        public List<ExistingPayorContact> GetExistingPayorContactNameAndEmail(string server, string dbInstance, string contactName, string emailAddress, int sqlCommandTimeout, bool isDebug = false)
        {
            List<ExistingPayorContact> existingPayorContacts = new List<ExistingPayorContact>();

            using (var objStreamReader = File.OpenText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $"datasource/rcgkentcms/datascripts/GetExistingPayorContactNameAndEmail.sql")))
            {
                string sqlStmt = objStreamReader.ReadToEnd();

                sqlStmt = sqlStmt.Replace("@server", server);
                sqlStmt = sqlStmt.Replace("@instance", dbInstance);
                sqlStmt = sqlStmt.Replace("@contactName", contactName);
                sqlStmt = sqlStmt.Replace("@email", emailAddress);

                if (isDebug)
                {
                    RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities();
                    rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                    existingPayorContacts = rCGKENTCMS_DEV01Entities.Database.SqlQuery<ExistingPayorContact>(sqlStmt).ToList();
                }
                else
                {
                    //RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities();
                    //rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                    //existingPayorContacts = rCGKENTCMS_PROD01Entities.Database.SqlQuery<ExistingPayorContact>(sqlStmt).ToList();
                }
            }

            return existingPayorContacts;
        }

        public List<CMSCftWorkflowHistory> GetCftWorkflowHistory(string server, string dbInstance, int jobNumber, int sqlCommandTimeout, bool isDebug = false)
        {
            List<CMSCftWorkflowHistory> cftWorkflowHistories = new List<CMSCftWorkflowHistory>();

            using (var objStreamReader = File.OpenText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $"datasource/rcgkentcms/datascripts/GetCftWorkflowHistory.sql")))
            {
                string sqlStmt = objStreamReader.ReadToEnd();

                sqlStmt = sqlStmt.Replace("@server", server);
                sqlStmt = sqlStmt.Replace("@instance", dbInstance);
                sqlStmt = sqlStmt.Replace("@jobNumber", jobNumber.ToString());

                if (isDebug)
                {
                    RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities();
                    rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                    cftWorkflowHistories = rCGKENTCMS_DEV01Entities.Database.SqlQuery<CMSCftWorkflowHistory>(sqlStmt).ToList();
                }
                else
                {
                    //RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities();
                    //rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                    //cftWorkflowHistories = rCGKENTCMS_PROD01Entities.Database.SqlQuery<CMSCftWorkflowHistory>(sqlStmt).ToList();
                }
            }

            return cftWorkflowHistories;
        }

        public List<ExistingEntity> GetExistingEntityByNameAndEmail(string server, string dbInstance, EntityArchetypeCode archetypeCode, string displayName, string emailAddress, int sqlCommandTimeout, bool isDebug = false)
        {
            List<ExistingEntity> existingEntities = new List<ExistingEntity>();

            using (var objStreamReader = File.OpenText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $"datasource/sqlscripts/GetExistingEntityByNameAndEmail.sql")))
            {
                string sqlStmt = objStreamReader.ReadToEnd();

                string emailCondition = "";

                if (archetypeCode == EntityArchetypeCode.EntityPerson)
                {
                    emailCondition = $"= '{emailAddress}'";
                }
                else
                {
                    try
                    {
                        MailAddress address = new MailAddress(emailAddress);
                        emailCondition = $"like '%{address.Host}%'";
                    }
                    catch { emailCondition = $"= '{emailAddress}'"; }
                }

                sqlStmt = sqlStmt.Replace("@server", server);
                sqlStmt = sqlStmt.Replace("@instance", dbInstance);
                //sqlStmt = sqlStmt.Replace("@archetypeCode", TE3EEntityExt.GetEnumDescription(archetypeCode));
                sqlStmt = sqlStmt.Replace("@displayName", displayName.Replace("'", "''"));
                sqlStmt = sqlStmt.Replace("@emailCondition", emailCondition);

                if (isDebug)
                {
                    RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities();
                    rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                    existingEntities = rCGKENTCMS_DEV01Entities.Database.SqlQuery<ExistingEntity>(sqlStmt).ToList();
                }
                else
                {
                    //RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities();
                    //rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                    //existingEntities = rCGKENTCMS_PROD01Entities.Database.SqlQuery<ExistingEntity>(sqlStmt).ToList();
                }
            }

            return existingEntities;
        }

        public List<ExistingClient> GetExistingClientByNameAndEmail(string server, string dbInstance, string displayName, string emailAddress, int sqlCommandTimeout, bool isDebug = false)
        {
            List<ExistingClient> existingClients = new List<ExistingClient>();

            using (var objStreamReader = File.OpenText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $"datasource/sqlscripts/GetExistingClientByNameAndEmail.sql")))
            {
                string sqlStmt = objStreamReader.ReadToEnd();

                MailAddress address = new MailAddress(emailAddress);
                string emailDomain = address.Host;

                sqlStmt = sqlStmt.Replace("@server", server);
                sqlStmt = sqlStmt.Replace("@instance", dbInstance);
                sqlStmt = sqlStmt.Replace("@displayName", displayName);
                sqlStmt = sqlStmt.Replace("@email", emailDomain);

                if (isDebug)
                {
                    RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities();
                    rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                    existingClients = rCGKENTCMS_DEV01Entities.Database.SqlQuery<ExistingClient>(sqlStmt).ToList();
                }
                else
                {
                    //RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities();
                    //rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                    //existingClients = rCGKENTCMS_PROD01Entities.Database.SqlQuery<ExistingClient>(sqlStmt).ToList();
                }
            }

            return existingClients;
        }

        public ExistingEntity GetExistingEntity(string server, string dbInstance, EntityArchetypeCode archetypeCode, string displayName, int sqlCommandTimeout, bool isDebug = false)
        {
            ExistingEntity existingEntity = new ExistingEntity();

            using (var objStreamReader = File.OpenText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $"datasource/sqlscripts/GetExistingEntity.sql")))
            {
                string sqlStmt = objStreamReader.ReadToEnd();

                sqlStmt = sqlStmt.Replace("@server", server);
                sqlStmt = sqlStmt.Replace("@instance", dbInstance);
                sqlStmt = sqlStmt.Replace("@archetypeCode", TE3EEntityExt.GetEnumDescription(archetypeCode));
                sqlStmt = sqlStmt.Replace("@displayName", displayName.Replace("'", "''"));

                if (isDebug)
                {
                    RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities();
                    rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                    var results = rCGKENTCMS_DEV01Entities.Database.SqlQuery<ExistingEntity>(sqlStmt);
                    existingEntity = results.Count() > 0 ? results.First() : null;
                }
                else
                {
                    //RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities();
                    //rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                    //var results = rCGKENTCMS_PROD01Entities.Database.SqlQuery<ExistingEntity>(sqlStmt);
                    //existingEntity = results.Count() > 0 ? results.First() : null;
                }
            }

            return existingEntity;
        }

        public ExistingClient GetExistingClient(string server, string dbInstance, string clientNumber, string clientName, int sqlCommandTimeout, bool isDebug = false)
        {
            ExistingClient existingClient = new ExistingClient();

            using (var objStreamReader = File.OpenText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $"datasource/sqlscripts/GetExistingClient.sql")))
            {
                string sqlStmt = objStreamReader.ReadToEnd();

                sqlStmt = sqlStmt.Replace("@server", server);
                sqlStmt = sqlStmt.Replace("@instance", dbInstance);
                sqlStmt = sqlStmt.Replace("@clientName", clientName.Replace("'", "''"));
                sqlStmt = sqlStmt.Replace("@clientNumber", clientNumber);

                if (isDebug)
                {
                    RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities();
                    rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                    var results = rCGKENTCMS_DEV01Entities.Database.SqlQuery<ExistingClient>(sqlStmt);
                    existingClient = results.Count() > 0 ? results.First() : null;
                }
                else
                {
                    //RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities();
                    //rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                    //var results = rCGKENTCMS_PROD01Entities.Database.SqlQuery<ExistingClient>(sqlStmt);
                    //existingClient = results.Count() > 0 ? results.First() : null;
                }
            }

            return existingClient;
        }

        public ExistingPayorClient GetExistingPayorClient(string server, string dbInstance, int payorIndex, int sqlCommandTimeout, bool isDebug = false)
        {
            ExistingPayorClient existingClient = new ExistingPayorClient();

            using (var objStreamReader = File.OpenText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $"datasource/sqlscripts/GetExistingPayorClient.sql")))
            {
                string sqlStmt = objStreamReader.ReadToEnd();

                sqlStmt = sqlStmt.Replace("@server", server);
                sqlStmt = sqlStmt.Replace("@instance", dbInstance);
                sqlStmt = sqlStmt.Replace("@payorIndex", payorIndex.ToString());

                if (isDebug)
                {
                    RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities();
                    rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                    var results = rCGKENTCMS_DEV01Entities.Database.SqlQuery<ExistingPayorClient>(sqlStmt);
                    existingClient = results.Count() > 0 ? results.First() : null;
                }
                else
                {
                    //RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities();
                    //rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                    //var results = rCGKENTCMS_PROD01Entities.Database.SqlQuery<ExistingPayorClient>(sqlStmt);
                    //existingClient = results.Count() > 0 ? results.First() : null;
                }
            }

            return existingClient;
        }

        public ExistingMatter GetExistingMatter(string server, string dbInstance, int mattIndex, string mattName, int sqlCommandTimeout, bool isDebug = false)
        {
            ExistingMatter existingMatter = new ExistingMatter();

            using (var objStreamReader = File.OpenText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $"datasource/sqlscripts/GetExistingMatter.sql")))
            {
                string sqlStmt = objStreamReader.ReadToEnd();

                sqlStmt = sqlStmt.Replace("@server", server);
                sqlStmt = sqlStmt.Replace("@instance", dbInstance);
                sqlStmt = sqlStmt.Replace("@mattName", mattName.Replace("'", "''"));
                sqlStmt = sqlStmt.Replace("@mattIndex", mattIndex.ToString());

                if (isDebug)
                {
                    RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities();
                    rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                    var results = rCGKENTCMS_DEV01Entities.Database.SqlQuery<ExistingMatter>(sqlStmt);
                    existingMatter = results.Count() > 0 ? results.First() : null;
                }
                else
                {
                    //RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities();
                    //rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                    //var results = rCGKENTCMS_PROD01Entities.Database.SqlQuery<ExistingMatter>(sqlStmt);
                    //existingMatter = results.Count() > 0 ? results.First() : null;
                }
            }

            return existingMatter;
        }

        public List<TE3ERoles> GetCftRoles(string server, string dbInstance, TE3ERoleType tE3ERoleType, int sqlCommandTimeout, bool isDebug = false)
        {
            List<TE3ERoles> tE3ERoles = new List<TE3ERoles>();

            var scriptFile = tE3ERoleType == TE3ERoleType.AdditionalParties ? "GetAdditionalPartiesRoles" : "GetMatterPayorDetailRoles";
            using (var objStreamReader = File.OpenText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $"datasource/sqlscripts/{scriptFile}.sql")))
            {
                string sqlStmt = objStreamReader.ReadToEnd();

                sqlStmt = sqlStmt.Replace("@server", server);
                sqlStmt = sqlStmt.Replace("@instance", dbInstance);

                if (isDebug)
                {
                    RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities();
                    rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                    tE3ERoles = rCGKENTCMS_DEV01Entities.Database.SqlQuery<TE3ERoles>(sqlStmt).ToList();
                }
                else
                {
                    //RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities();
                    //rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                    //tE3ERoles = rCGKENTCMS_PROD01Entities.Database.SqlQuery<TE3ERoles>(sqlStmt).ToList();
                }
            }

            return tE3ERoles;
        }

        public MattRateGrpExc GetMattRateGrpExc(string server, string dbInstance, string mattRateGrpExcDesc, int sqlCommandTimeout, bool isDebug = false)
        {
            MattRateGrpExc mattRateGrpExc = new MattRateGrpExc();

            using (var objStreamReader = File.OpenText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $"datasource/sqlscripts/GetMattRateGroupExc.sql")))
            {
                string sqlStmt = objStreamReader.ReadToEnd();

                sqlStmt = sqlStmt.Replace("@server", server);
                sqlStmt = sqlStmt.Replace("@instance", dbInstance);
                sqlStmt = sqlStmt.Replace("@mattRateGrpExc", mattRateGrpExcDesc);

                if (isDebug)
                {
                    RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities();
                    rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                    var results = rCGKENTCMS_DEV01Entities.Database.SqlQuery<MattRateGrpExc>(sqlStmt).ToList();
                    mattRateGrpExc = results.Count() > 0 ? results.First() : null;
                }
                else
                {
                    //RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities();
                    //rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                    //var results = rCGKENTCMS_PROD01Entities.Database.SqlQuery<MattRateGrpExc>(sqlStmt).ToList();
                    //mattRateGrpExc = results.Count() > 0 ? results.First() : null;
                }
            }

            return mattRateGrpExc;
        }

        public string GetDefaultSubSection(string server, string dbInstance, string section, int sqlCommandTimeout, bool isDebug = false)
        {
            string subSection = string.Empty;

            using (var objStreamReader = File.OpenText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $"datasource/sqlscripts/GetDefaultSubSection.sql")))
            {
                string sqlStmt = objStreamReader.ReadToEnd();

                sqlStmt = sqlStmt.Replace("@server", server);
                sqlStmt = sqlStmt.Replace("@instance", dbInstance);
                sqlStmt = sqlStmt.Replace("@section", section);

                if (isDebug)
                {
                    RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities();
                    rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                    var results = rCGKENTCMS_DEV01Entities.Database.SqlQuery<string>(sqlStmt).ToList();
                    subSection = results.Count() > 0 ? results.First() : null;
                }
                else
                {
                    //RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities();
                    //rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                    //var results = rCGKENTCMS_PROD01Entities.Database.SqlQuery<MattRateGrpExc>(sqlStmt).ToList();
                    //mattRateGrpExc = results.Count() > 0 ? results.First() : null;
                }
            }

            return subSection;
        }
        public List<EntityProcessItem> GetEntityOrgAndPersonProcessItems(string server, string dbInstance, string entityPersonPId, string entityOrgPId, int sqlCommandTimeout, bool isDebug = false)
        {
            List<EntityProcessItem> entityProcessItems = new List<EntityProcessItem>();

            using (var objStreamReader = File.OpenText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $"datasource/sqlscripts/GetProcessItemEntity.sql")))
            {
                string sqlStmt = objStreamReader.ReadToEnd();

                sqlStmt = sqlStmt.Replace("@server", server);
                sqlStmt = sqlStmt.Replace("@instance", dbInstance);
                sqlStmt = sqlStmt.Replace("@personProcessItemId", entityPersonPId);
                sqlStmt = sqlStmt.Replace("@orgProcessItemId", entityOrgPId);
                if (isDebug)
                {
                    RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities();
                    rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                    entityProcessItems = rCGKENTCMS_DEV01Entities.Database.SqlQuery<EntityProcessItem>(sqlStmt).ToList();
                }
                else
                {
                    //RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities();
                    //rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                    //entityProcessItems = rCGKENTCMS_PROD01Entities.Database.SqlQuery<EntityProcessItem>(sqlStmt).ToList();
                }
            }

            return entityProcessItems;
        }

        public List<ClientProcessItem> GetClientAndPayorIndexProcessItems(string server, string dbInstance, string clientPId, int sqlCommandTimeout, bool isDebug = false)
        {
            List<ClientProcessItem> clientProcessItems = new List<ClientProcessItem>();

            using (var objStreamReader = File.OpenText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $"datasource/sqlscripts/GetProcessItemClient.sql")))
            {
                string sqlStmt = objStreamReader.ReadToEnd();

                sqlStmt = sqlStmt.Replace("@server", server);
                sqlStmt = sqlStmt.Replace("@instance", dbInstance);
                sqlStmt = sqlStmt.Replace("@clientProcessItemId", clientPId);

                if (isDebug)
                {
                    RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities();
                    rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                    clientProcessItems = rCGKENTCMS_DEV01Entities.Database.SqlQuery<ClientProcessItem>(sqlStmt).ToList();
                }
                else
                {
                    //RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities();
                    //rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                    //clientProcessItems = rCGKENTCMS_PROD01Entities.Database.SqlQuery<ClientProcessItem>(sqlStmt).ToList();
                }
            }

            return clientProcessItems;
        }

        public MatterProcessItem GetMatterProcessItem(string server, string dbInstance, string matterPId, int sqlCommandTimeout, bool isDebug = false)
        {
            MatterProcessItem matterProcessItem = new MatterProcessItem();

            using (var objStreamReader = File.OpenText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $"datasource/sqlscripts/GetProcessItemMatter.sql")))
            {
                string sqlStmt = objStreamReader.ReadToEnd();

                sqlStmt = sqlStmt.Replace("@server", server);
                sqlStmt = sqlStmt.Replace("@instance", dbInstance);
                sqlStmt = sqlStmt.Replace("@matterProcessItemId", matterPId);

                if (isDebug)
                {
                    RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities();
                    rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                    var results = rCGKENTCMS_DEV01Entities.Database.SqlQuery<MatterProcessItem>(sqlStmt);
                    matterProcessItem = results.Count() > 0 ? results.First() : null;
                }
                else
                {
                    //RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities();
                    //rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                    //var results = rCGKENTCMS_PROD01Entities.Database.SqlQuery<MatterProcessItem>(sqlStmt);
                    //matterProcessItem = results.Count() > 0 ? results.First() : null;
                }
            }

            return matterProcessItem;
        }

        public ExistingEntity GetExistingEntityByEntIndex(string server, string dbInstance, int entityID, int sqlCommandTimeout, bool isDebug = false)
        {
            ExistingEntity existingEntity = new ExistingEntity();

            using (var objStreamReader = File.OpenText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $"datasource/sqlscripts/GetExistingEntityByEntIndex.sql")))
            {
                string sqlStmt = objStreamReader.ReadToEnd();

                sqlStmt = sqlStmt.Replace("@server", server);
                sqlStmt = sqlStmt.Replace("@instance", dbInstance);
                sqlStmt = sqlStmt.Replace("@entityID", entityID.ToString());

                if (isDebug)
                {
                    RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities();
                    rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                    var results = rCGKENTCMS_DEV01Entities.Database.SqlQuery<ExistingEntity>(sqlStmt);
                    existingEntity = results.Count() > 0 ? results.First() : null;
                }
                else
                {
                    //RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities();
                    //rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                    //var results = rCGKENTCMS_PROD01Entities.Database.SqlQuery<ExistingEntity>(sqlStmt);
                    //existingEntity = results.Count() > 0 ? results.First() : null;
                }
            }

            return existingEntity;
        }

        public CMSGetCliTypeFromCftRole_Result GetCliTypeFromDesc(string cliType)
        {
            CMSGetCliTypeFromCftRole_Result cliTypeResult = new CMSGetCliTypeFromCftRole_Result();
            cliTypeResult.Code = "600";
            cliTypeResult.Description = "Other";

            if ((cliType.ToLower() == "Adjustment Company".ToLower())
                || (cliType.ToLower() == "Independent Adjuster".ToLower()))
            {
                cliTypeResult.Code = "100";
                cliTypeResult.Description = "Adjustment Firm/Third Party";
            }
            else if (cliType.ToLower() == "Corporation".ToLower())
            {
                cliTypeResult.Code = "200";
                cliTypeResult.Description = "Corporation";
            }
            else if (cliType.ToLower() == "Government Entities".ToLower())
            {
                cliTypeResult.Code = "300";
                cliTypeResult.Description = "Government";
            }
            else if ((cliType.ToLower() == "Insurance Company".ToLower())
                || (cliType.ToLower() == "Insurance Broker".ToLower()))
            {
                cliTypeResult.Code = "400";
                cliTypeResult.Description = "Insurance";
            }
            else if (cliType.ToLower() == "Attorney".ToLower())
            {
                cliTypeResult.Code = "500";
                cliTypeResult.Description = "Law Firm";
            }
            else if ((cliType.ToLower() == "Expert".ToLower())
                || (cliType.ToLower() == "Third Party Administrator".ToLower()))
            {
                cliTypeResult.Code = "600";
                cliTypeResult.Description = "Other";
            }

            return cliTypeResult;
        }

        public CMSGetCliTypeFromCftRole_Result GetCliTypeFromCftRole(int cftRole, int sqlCommandTimeout, bool isDebug = false)
        {
            CMSGetCliTypeFromCftRole_Result cftRole_Result = new CMSGetCliTypeFromCftRole_Result();

            if (isDebug)
            {
                RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities();
                rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                var results = rCGKENTCMS_DEV01Entities.CMSGetCliTypeFromCftRole(cftRole).ToList();
                cftRole_Result = results.Count() > 0 ? results.First() : null;
            }
            else
            {
                //RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities();
                //rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                //var results = rCGKENTCMS_PROD01Entities.CMSGetCliTypeFromCftRole(cftRole).ToList();
                //cftRole_Result = results.Count() > 0 ? results.First() : null;
            }

            return cftRole_Result;
        }

        public List<CMSGetLookupCodes_Result> GetOfficeCodes(int sqlCommandTimeout, bool isDebug = false)
        {
            List<CMSGetLookupCodes_Result> officeCodes = new List<CMSGetLookupCodes_Result>();

            if (isDebug)
            {
                RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities();
                rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                officeCodes = rCGKENTCMS_DEV01Entities.CMSGetLookupCodes("Office").ToList();
            }
            else
            {
                //RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities();
                //rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                //officeCodes = rCGKENTCMS_PROD01Entities.CMSGetLookupCodes("Office").ToList();
            }

            return officeCodes;
        }

        public List<CMSKeyVault> AddNewClientCMSKey(string clientName, int sqlCommandTimeout, bool isDebug = false)
        {
            List<CMSKeyVault> results = null;

            string appId = Guid.NewGuid().ToString().ToUpper();
            var appKey = GenerateCMSAPPKey();

            if (isDebug)
            {
                using (RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities())
                {
                    rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                    rCGKENTCMS_DEV01Entities.Database.ExecuteSqlCommand($@"INSERT INTO [dbo].[CMSKeyVaults]
                                                                               ([AppId]
                                                                               ,[AppKey]
                                                                               ,[ClientName]
                                                                               ,[CreatedOn])
                                                                         VALUES
                                                                               ('{appId}'
                                                                               ,'{appKey}'
                                                                               ,'{clientName}'
                                                                               ,'{DateTime.Now}')");
                    results = rCGKENTCMS_DEV01Entities.CMSKeyVaults.ToList();
                }
            }
            else
            {
                //using (RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities())
                //{
                //    rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                //    rCGKENTCMS_PROD01Entities.Database.ExecuteSqlCommand($@"INSERT INTO [dbo].[CMSKeyVaults]
                //                                                               ([AppId]
                //                                                               ,[AppKey]
                //                                                               ,[ClientName]
                //                                                               ,[CreatedOn])
                //                                                         VALUES
                //                                                               ('{appId}'
                //                                                               ,'{appKey}'
                //                                                               ,'{clientName}'
                //                                                               ,'{DateTime.Now}')");

                //    results = rCGKENTCMS_PROD01Entities.CMSKeyVaults.ToList();
                //}
            }

            return results;
        }

        public List<CMSKeyVault> GetCMSKeyVaults(int sqlCommandTimeout, bool isDebug = false)
        {
            List<CMSKeyVault> results = null;

            if (isDebug)
            {
                using (RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities())
                {
                    rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                    results = rCGKENTCMS_DEV01Entities.CMSKeyVaults.ToList();
                }
            }
            else
            {
                //using (RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities())
                //{
                //    rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                //    results = rCGKENTCMS_PROD01Entities.CMSKeyVaults.ToList();
                //}
            }

            return results;
        }

        #region assignment data access methods

        public void AddAssignment(CMSJob cMSJob, QueueType queueType, int sqlCommandTimeout, bool isDebug = false)
        {
            string queueTypeDesc = TE3EEntityExt.GetEnumDescription(queueType);
            #region set queue type

            cMSJob.assignment.QueueType = queueTypeDesc;
            cMSJob.orderingClient.QueueType = queueTypeDesc;
            cMSJob.coConsultants.ForEach(x => x.QueueType = queueTypeDesc);
            cMSJob.incidentLocations.ForEach(x => x.QueueType = queueTypeDesc);
            cMSJob.payorDetails.ForEach(x => x.QueueType = queueTypeDesc);
            cMSJob.additionalParties.ForEach(x => x.QueueType = queueTypeDesc);

            #endregion set queue type

            if (isDebug)
            {
                using (RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities())
                {
                    using (DbContextTransaction transaction = rCGKENTCMS_DEV01Entities.Database.BeginTransaction())
                    {
                        try
                        {
                            rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;

                            var existing = rCGKENTCMS_DEV01Entities.CMSAssignments.FirstOrDefault(x => x.KenticoID.Equals(cMSJob.assignment.KenticoID) && (x.QueueType.ToUpper() == queueTypeDesc.ToUpper()));

                            if (existing == null)
                            {
                                rCGKENTCMS_DEV01Entities.CMSAssignments.Add(cMSJob.assignment);

                                if (cMSJob.orderingClient != null)
                                    rCGKENTCMS_DEV01Entities.CMSOrderingClients.Add(cMSJob.orderingClient);

                                if (cMSJob.coConsultants.Count() > 0)
                                    rCGKENTCMS_DEV01Entities.CMSCoConsultants.AddRange(cMSJob.coConsultants);

                                if (cMSJob.incidentLocations.Count() > 0)
                                    rCGKENTCMS_DEV01Entities.CMSIncidentLocations.AddRange(cMSJob.incidentLocations);

                                if (cMSJob.payorDetails.Count() > 0)
                                    rCGKENTCMS_DEV01Entities.CMSPayorDetails.AddRange(cMSJob.payorDetails);

                                if (cMSJob.additionalParties.Count() > 0)
                                    rCGKENTCMS_DEV01Entities.CMSAdditionalParties.AddRange(cMSJob.additionalParties);
                            }
                            else
                            {
                                throw new Exception($"CMS job has unprocessed job for this kentico ID: {cMSJob.assignment.KenticoID}");
                            }

                            rCGKENTCMS_DEV01Entities.SaveChanges();
                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw ex;
                        }
                    }
                }
            }
            else
            {// Todo Update this one
                //using (RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities())
                //{
                //    using (DbContextTransaction transaction = rCGKENTCMS_PROD01Entities.Database.BeginTransaction())
                //    {
                //        try
                //        {
                //            rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                //            rCGKENTCMS_PROD01Entities.CMSAssignments.Add(cMSJob.assignment);

                //            if (cMSJob.orderingClient != null)
                //                rCGKENTCMS_PROD01Entities.CMSOrderingClients.Add(cMSJob.orderingClient);

                //            if (cMSJob.coConsultants.Count() > 0)
                //                rCGKENTCMS_PROD01Entities.CMSCoConsultants.AddRange(cMSJob.coConsultants);

                //            if (cMSJob.incidentLocations.Count() > 0)
                //                rCGKENTCMS_PROD01Entities.CMSIncidentLocations.AddRange(cMSJob.incidentLocations);

                //            if (cMSJob.payorDetails.Count() > 0)
                //                rCGKENTCMS_PROD01Entities.CMSPayorDetails.AddRange(cMSJob.payorDetails);

                //            if (cMSJob.additionalParties.Count() > 0)
                //                rCGKENTCMS_PROD01Entities.CMSAdditionalParties.AddRange(cMSJob.additionalParties);

                //            rCGKENTCMS_PROD01Entities.SaveChanges();
                //            transaction.Commit();
                //        }
                //        catch (Exception ex)
                //        {
                //            transaction.Rollback();
                //            throw ex;
                //        }
                //    }
                //}
            }
        }

        public void RemoveAssignment(CMSJob cMSJob, QueueType queueType, int sqlCommandTimeout, bool isDebug = false)
        {
            string queueTypeDesc = TE3EEntityExt.GetEnumDescription(queueType);

            if (isDebug)
            {
                using (RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities())
                {
                    using (DbContextTransaction transaction = rCGKENTCMS_DEV01Entities.Database.BeginTransaction())
                    {
                        rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;

                        var deletedInAssgnmnts = rCGKENTCMS_DEV01Entities.CMSAssignments.Where(k => (k.E3EID == cMSJob.assignment.E3EID) && (k.QueueType.ToUpper() == queueTypeDesc));

                        if (deletedInAssgnmnts.Count() > 0)
                            rCGKENTCMS_DEV01Entities.CMSAssignments.RemoveRange(deletedInAssgnmnts);

                        var deletedInOrderingClients = rCGKENTCMS_DEV01Entities.CMSOrderingClients.Where(k => (k.E3EID == cMSJob.assignment.E3EID) && (k.QueueType.ToUpper() == queueTypeDesc));

                        if (deletedInOrderingClients.Count() > 0)
                            rCGKENTCMS_DEV01Entities.CMSOrderingClients.RemoveRange(deletedInOrderingClients);

                        var deletedInCoConslts = rCGKENTCMS_DEV01Entities.CMSCoConsultants.Where(k => (k.E3EID == cMSJob.assignment.E3EID) && (k.QueueType.ToUpper() == queueTypeDesc));

                        if (deletedInCoConslts.Count() > 0)
                            rCGKENTCMS_DEV01Entities.CMSCoConsultants.RemoveRange(deletedInCoConslts);

                        var deletedInAddtnlParties = rCGKENTCMS_DEV01Entities.CMSAdditionalParties.Where(k => (k.E3EID == cMSJob.assignment.E3EID) && (k.QueueType.ToUpper() == queueTypeDesc));

                        if (deletedInAddtnlParties.Count() > 0)
                            rCGKENTCMS_DEV01Entities.CMSAdditionalParties.RemoveRange(deletedInAddtnlParties);

                        var deletedInPayDets = rCGKENTCMS_DEV01Entities.CMSPayorDetails.Where(k => (k.E3EID == cMSJob.assignment.E3EID) && (k.QueueType.ToUpper() == queueTypeDesc));

                        if (deletedInPayDets.Count() > 0)
                            rCGKENTCMS_DEV01Entities.CMSPayorDetails.RemoveRange(deletedInPayDets);

                        var deletedInIncLocs = rCGKENTCMS_DEV01Entities.CMSIncidentLocations.Where(k => (k.E3EID == cMSJob.assignment.E3EID) && (k.QueueType.ToUpper() == queueTypeDesc));

                        if (deletedInIncLocs.Count() > 0)
                            rCGKENTCMS_DEV01Entities.CMSIncidentLocations.RemoveRange(deletedInIncLocs);

                        rCGKENTCMS_DEV01Entities.SaveChanges();
                    }
                }
            }
            else
            {
                //using (RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities())
                //{
                //    using (DbContextTransaction transaction = rCGKENTCMS_PROD01Entities.Database.BeginTransaction())
                //    {
                //        rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;

                //        var deletedInAssgnmnts = rCGKENTCMS_PROD01Entities.CMSAssignments.Where(k => (k.E3EID == cMSJob.assignment.E3EID) && (k.QueueType.ToUpper() == queueTypeDesc));

                //        if (deletedInAssgnmnts.Count() > 0)
                //            rCGKENTCMS_PROD01Entities.CMSAssignments.RemoveRange(deletedInAssgnmnts);

                //        var deletedInOrderingClients = rCGKENTCMS_PROD01Entities.CMSOrderingClients.Where(k => (k.E3EID == cMSJob.assignment.E3EID) && (k.QueueType.ToUpper() == queueTypeDesc));

                //        if (deletedInOrderingClients.Count() > 0)
                //            rCGKENTCMS_PROD01Entities.CMSOrderingClients.RemoveRange(deletedInOrderingClients);

                //        var deletedInCoConslts = rCGKENTCMS_PROD01Entities.CMSCoConsultants.Where(k => (k.E3EID == cMSJob.assignment.E3EID) && (k.QueueType.ToUpper() == queueTypeDesc));

                //        if (deletedInCoConslts.Count() > 0)
                //            rCGKENTCMS_PROD01Entities.CMSCoConsultants.RemoveRange(deletedInCoConslts);

                //        var deletedInAddtnlParties = rCGKENTCMS_PROD01Entities.CMSAdditionalParties.Where(k => (k.E3EID == cMSJob.assignment.E3EID) && (k.QueueType.ToUpper() == queueTypeDesc));

                //        if (deletedInAddtnlParties.Count() > 0)
                //            rCGKENTCMS_PROD01Entities.CMSAdditionalParties.RemoveRange(deletedInAddtnlParties);

                //        var deletedInPayDets = rCGKENTCMS_PROD01Entities.CMSPayorDetails.Where(k => (k.E3EID == cMSJob.assignment.E3EID) && (k.QueueType.ToUpper() == queueTypeDesc));

                //        if (deletedInPayDets.Count() > 0)
                //            rCGKENTCMS_PROD01Entities.CMSPayorDetails.RemoveRange(deletedInPayDets);

                //        var deletedInIncLocs = rCGKENTCMS_PROD01Entities.CMSIncidentLocations.Where(k => (k.E3EID == cMSJob.assignment.E3EID) && (k.QueueType.ToUpper() == queueTypeDesc));

                //        if (deletedInIncLocs.Count() > 0)
                //            rCGKENTCMS_PROD01Entities.CMSIncidentLocations.RemoveRange(deletedInIncLocs);

                //        rCGKENTCMS_PROD01Entities.SaveChanges();
                //    }
                //}
            }
        }

        public List<CMSJob> GetAssgnMessages(QueueType queueType, int sqlCommandTimeout, bool isDebug = false, int attemptsAllowed = 20)
        {
            List<CMSJob> cMSJobs = new List<CMSJob>();
            string queueTypeDesc = TE3EEntityExt.GetEnumDescription(queueType);

            if (isDebug)
            {
                using (RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities())
                {
                    rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;

                    #region scan assignments

                    var oAssignmentGroup = rCGKENTCMS_DEV01Entities.CMSAssignments.Where(x => !(x.IsProcessed ?? false) && ((x.NumOfAttempts ?? 0) <= attemptsAllowed) && (x.QueueType.ToUpper() == queueTypeDesc))
                                                                                  .GroupBy(x => new { x.KenticoID })
                                                                                  .Select(x => x).ToList();

                    if (oAssignmentGroup.Count() > 0)
                    {
                        oAssignmentGroup.ForEach(g =>
                        {
                            var mostUpdatedAssignmentRec = g.OrderByDescending(o => o.TimeStamp).First();
                            CMSJob cMSJob = new CMSJob();
                            cMSJob.assignment = mostUpdatedAssignmentRec;
                            cMSJobs.Add(cMSJob);
                        });
                    }
                    else
                    {
                        return cMSJobs;
                    }

                    #endregion scan assignments

                    #region scan ordering client

                    var outClientGroup = rCGKENTCMS_DEV01Entities.CMSOrderingClients.Where(c => !(c.IsProcessed ?? false) && ((c.NumOfAttempts ?? 0) <= attemptsAllowed) && (c.QueueType.ToUpper() == queueTypeDesc))
                                                                                    .GroupBy(c => new { c.KenticoID })
                                                                                    .Select(c => c).ToList();
                    if (outClientGroup.Count() > 0)
                    {
                        outClientGroup.ForEach(g =>
                        {
                            var mostUpdatedOrderClientRec = g.OrderByDescending(o => o.TimeStamp).First();
                            // var existingOutAssignment = cMSJobs.Where(oa => oa.assignment.KenticoID == mostUpdatedOrderClientRec.KenticoID).Select(oa => oa).ToList();
                            cMSJobs.ForEach(e =>
                            {
                                if (e.assignment.KenticoID == mostUpdatedOrderClientRec.KenticoID)
                                    e.orderingClient = mostUpdatedOrderClientRec;
                            });
                        });
                    }

                    #endregion scan ordering client

                    #region scan incident locations

                    var outIncidentLocations = rCGKENTCMS_DEV01Entities.CMSIncidentLocations.Where(c => !(c.IsProcessed ?? false) && ((c.NumOfAttempts ?? 0) <= attemptsAllowed) && (c.QueueType.ToUpper() == queueTypeDesc))
                                                                                            .Select(c => c)
                                                                                            .OrderByDescending(c => c.TimeStamp)
                                                                                            .ToList();
                    if (outIncidentLocations.Count() > 0)
                    {
                        outIncidentLocations.ForEach(x =>
                        {
                            //var existingOutAssignment = cMSJobs.Where(oa => oa.assignment.KenticoID == x.KenticoID).Select(oa => oa).ToList();
                            //existingOutAssignment.ForEach(a => a.incidentLocations.Add(x));

                            cMSJobs.ForEach(e =>
                            {
                                if (e.assignment.KenticoID == x.KenticoID)
                                    e.incidentLocations.Add(x);
                            });
                        });
                    }

                    #endregion scan incident locations

                    #region scan payor details

                    var oPayorDetails = rCGKENTCMS_DEV01Entities.CMSPayorDetails.Where(c => !(c.IsProcessed ?? false) && ((c.NumOfAttempts ?? 0) <= attemptsAllowed) && (c.QueueType.ToUpper() == queueTypeDesc))
                                                                                .Select(c => c)
                                                                                .OrderByDescending(c => c.TimeStamp)
                                                                                .ToList();
                    if (oPayorDetails.Count() > 0)
                    {
                        oPayorDetails.ForEach(x =>
                        {
                            //var existingOutAssignment = cMSJobs.Where(oa => oa.assignment.KenticoID == x.KenticoID).Select(oa => oa).ToList();
                            //existingOutAssignment.ForEach(a => a.payorDetails.Add(x));

                            cMSJobs.ForEach(e =>
                            {
                                if (e.assignment.KenticoID == x.KenticoID)
                                    e.payorDetails.Add(x);
                            });
                        });
                    }

                    #endregion scan payor details

                    #region scan coConsultants

                    var oCoConsultants = rCGKENTCMS_DEV01Entities.CMSCoConsultants.Where(c => !(c.IsProcessed ?? false) && ((c.NumOfAttempts ?? 0) <= attemptsAllowed) && (c.QueueType.ToUpper() == queueTypeDesc))
                                                                                  .Select(c => c)
                                                                                  .OrderByDescending(c => c.TimeStamp)
                                                                                  .ToList();
                    if (oCoConsultants.Count() > 0)
                    {
                        oCoConsultants.ForEach(x =>
                        {
                            //var existingOutAssignment = cMSJobs.Where(oa => oa.assignment.KenticoID == x.KenticoID).Select(oa => oa).ToList();
                            //existingOutAssignment.ForEach(a => a.coConsultants.Add(x));

                            cMSJobs.ForEach(e =>
                            {
                                if (e.assignment.KenticoID == x.KenticoID)
                                    e.coConsultants.Add(x);
                            });
                        });
                    }

                    #endregion scan coConsultants

                    #region scan additional parties

                    var oAdditionalParties = rCGKENTCMS_DEV01Entities.CMSAdditionalParties.Where(c => !(c.IsProcessed ?? false) && ((c.NumOfAttempts ?? 0) <= attemptsAllowed) && (c.QueueType.ToUpper() == queueTypeDesc))
                                                                                          .Select(c => c)
                                                                                          .OrderByDescending(c => c.TimeStamp)
                                                                                          .ToList();
                    if (oAdditionalParties.Count() > 0)
                    {
                        oAdditionalParties.ForEach(x =>
                        {
                            //var existingOutAssignment = cMSJobs.Where(oa => oa.assignment.KenticoID == x.KenticoID).Select(oa => oa).ToList();
                            //existingOutAssignment.ForEach(a => a.additionalParties.Add(x));

                            cMSJobs.ForEach(e =>
                            {
                                if (e.assignment.KenticoID == x.KenticoID)
                                    e.additionalParties.Add(x);
                            });
                        });
                    }

                    #endregion scan additional parties
                }
            }
            else
            {
                //using (RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities())
                //{
                //    rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;

                //    #region scan assignments
                //    var oAssignmentGroup = rCGKENTCMS_PROD01Entities.CMSAssignments.Where(x => !(x.IsProcessed ?? false) && ((x.NumOfAttempts ?? 0) <= attemptsAllowed) && (x.QueueType.ToUpper() == queueTypeDesc))
                //                                                                  .GroupBy(x => new { x.KenticoID })
                //                                                                  .Select(x => x).ToList();

                //    if (oAssignmentGroup.Count() > 0)
                //    {
                //        oAssignmentGroup.ForEach(g =>
                //        {
                //            var mostUpdatedAssignmentRec = g.OrderByDescending(o => o.TimeStamp).First();
                //            CMSJob cMSJob = new CMSJob();
                //            cMSJob.assignment = mostUpdatedAssignmentRec;
                //            cMSJobs.Add(cMSJob);
                //        });
                //    }
                //    else
                //    {
                //        cMSJobs.Add(new CMSJob());
                //    }

                //    #endregion scan assignments

                //    #region scan ordering client
                //    var outClientGroup = rCGKENTCMS_PROD01Entities.CMSOrderingClients.Where(c => !(c.IsProcessed ?? false) && ((c.NumOfAttempts ?? 0) <= attemptsAllowed) && (c.QueueType.ToUpper() == queueTypeDesc))
                //                                                                    .GroupBy(c => new { c.KenticoID })
                //                                                                    .Select(c => c).ToList();
                //    if (outClientGroup.Count() > 0)
                //    {
                //        outClientGroup.ForEach(g =>
                //        {
                //            var mostUpdatedOrderClientRec = g.OrderByDescending(o => o.TimeStamp).First();
                //            // var existingOutAssignment = cMSJobs.Where(oa => oa.assignment.KenticoID == mostUpdatedOrderClientRec.KenticoID).Select(oa => oa).ToList();
                //            cMSJobs.ForEach(e =>
                //            {
                //                if (e.assignment.KenticoID == mostUpdatedOrderClientRec.KenticoID)
                //                    e.orderingClient = mostUpdatedOrderClientRec;

                //            });
                //        });

                //    }

                //    #endregion scan ordering client

                //    #region scan incident locations
                //    var outIncidentLocations = rCGKENTCMS_PROD01Entities.CMSIncidentLocations.Where(c => !(c.IsProcessed ?? false) && ((c.NumOfAttempts ?? 0) <= attemptsAllowed) && (c.QueueType.ToUpper() == queueTypeDesc))
                //                                                                            .Select(c => c)
                //                                                                            .OrderByDescending(c => c.TimeStamp)
                //                                                                            .ToList();
                //    if (outIncidentLocations.Count() > 0)
                //    {
                //        outIncidentLocations.ForEach(x =>
                //        {
                //            //var existingOutAssignment = cMSJobs.Where(oa => oa.assignment.KenticoID == x.KenticoID).Select(oa => oa).ToList();
                //            //existingOutAssignment.ForEach(a => a.incidentLocations.Add(x));

                //            cMSJobs.ForEach(e =>
                //            {
                //                if (e.assignment.KenticoID == x.KenticoID)
                //                    e.incidentLocations.Add(x);

                //            });
                //        });
                //    }
                //    #endregion scan incident locations

                //    #region scan payor details
                //    var oPayorDetails = rCGKENTCMS_PROD01Entities.CMSPayorDetails.Where(c => !(c.IsProcessed ?? false) && ((c.NumOfAttempts ?? 0) <= attemptsAllowed) && (c.QueueType.ToUpper() == queueTypeDesc))
                //                                                                .Select(c => c)
                //                                                                .OrderByDescending(c => c.TimeStamp)
                //                                                                .ToList();
                //    if (oPayorDetails.Count() > 0)
                //    {
                //        oPayorDetails.ForEach(x =>
                //        {
                //            //var existingOutAssignment = cMSJobs.Where(oa => oa.assignment.KenticoID == x.KenticoID).Select(oa => oa).ToList();
                //            //existingOutAssignment.ForEach(a => a.payorDetails.Add(x));

                //            cMSJobs.ForEach(e =>
                //            {
                //                if (e.assignment.KenticoID == x.KenticoID)
                //                    e.payorDetails.Add(x);

                //            });
                //        });
                //    }
                //    #endregion scan payor details

                //    #region scan coConsultants
                //    var oCoConsultants = rCGKENTCMS_PROD01Entities.CMSCoConsultants.Where(c => !(c.IsProcessed ?? false) && ((c.NumOfAttempts ?? 0) <= attemptsAllowed) && (c.QueueType.ToUpper() == queueTypeDesc))
                //                                                                  .Select(c => c)
                //                                                                  .OrderByDescending(c => c.TimeStamp)
                //                                                                  .ToList();
                //    if (oCoConsultants.Count() > 0)
                //    {
                //        oCoConsultants.ForEach(x =>
                //        {
                //            //var existingOutAssignment = cMSJobs.Where(oa => oa.assignment.KenticoID == x.KenticoID).Select(oa => oa).ToList();
                //            //existingOutAssignment.ForEach(a => a.coConsultants.Add(x));

                //            cMSJobs.ForEach(e =>
                //            {
                //                if (e.assignment.KenticoID == x.KenticoID)
                //                    e.coConsultants.Add(x);

                //            });
                //        });
                //    }
                //    #endregion scan coConsultants

                //    #region scan additional parties
                //    var oAdditionalParties = rCGKENTCMS_PROD01Entities.CMSAdditionalParties.Where(c => !(c.IsProcessed ?? false) && ((c.NumOfAttempts ?? 0) <= attemptsAllowed) && (c.QueueType.ToUpper() == queueTypeDesc))
                //                                                                          .Select(c => c)
                //                                                                          .OrderByDescending(c => c.TimeStamp)
                //                                                                          .ToList();
                //    if (oAdditionalParties.Count() > 0)
                //    {
                //        oAdditionalParties.ForEach(x =>
                //        {
                //            //var existingOutAssignment = cMSJobs.Where(oa => oa.assignment.KenticoID == x.KenticoID).Select(oa => oa).ToList();
                //            //existingOutAssignment.ForEach(a => a.additionalParties.Add(x));

                //            cMSJobs.ForEach(e =>
                //            {
                //                if (e.assignment.KenticoID == x.KenticoID)
                //                    e.additionalParties.Add(x);

                //            });
                //        });
                //    }
                //    #endregion scan additional parties
                //}
            }

            return cMSJobs;
        }

        [Obsolete]
        public CMSJob GetAssgnMessages(string kenticoId, QueueType queueType, bool isProcessed, int sqlCommandTimeout, bool isDebug = false, int attemptsAllowed = 20)

        {
            CMSJob cmsJob = new CMSJob();
            string queueTypeDesc = TE3EEntityExt.GetEnumDescription(queueType);

            if (isDebug)
            {
                using (RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities())
                {
                    rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;

                    #region scan assignments

                    var ocmsAssignment = rCGKENTCMS_DEV01Entities.CMSAssignments.Where(x => (x.IsProcessed ?? false) == isProcessed && ((x.NumOfAttempts ?? 0) <= attemptsAllowed) && (x.QueueType.ToUpper() == queueTypeDesc) && x.KenticoID == kenticoId)
                                                                                  .Select(x => x).ToList();

                    if (ocmsAssignment.Count() > 0)
                    {
                        var mostUpdatedAssignmentRec = ocmsAssignment.OrderByDescending(o => o.TimeStamp).First();
                        cmsJob.assignment = mostUpdatedAssignmentRec;
                    }
                    else
                    {
                        return null;
                    }

                    #endregion scan assignments

                    #region scan ordering client

                    var outClientGroup = rCGKENTCMS_DEV01Entities.CMSOrderingClients.Where(c => (c.IsProcessed ?? false) == isProcessed && ((c.NumOfAttempts ?? 0) <= attemptsAllowed) && (c.QueueType.ToUpper() == queueTypeDesc) && c.KenticoID == cmsJob.assignment.KenticoID)
                                                                                    .GroupBy(c => new { c.KenticoID })
                                                                                    .Select(c => c).ToList();
                    if (outClientGroup.Count() > 0)
                    {
                        outClientGroup.ForEach(g =>
                        {
                            var mostUpdatedOrderClientRec = g.OrderByDescending(o => o.TimeStamp).First();
                            cmsJob.orderingClient = mostUpdatedOrderClientRec;
                        });
                    }

                    #endregion scan ordering client

                    #region scan incident locations

                    var outIncidentLocations = rCGKENTCMS_DEV01Entities.CMSIncidentLocations.Where(c => (c.IsProcessed ?? false) == isProcessed && ((c.NumOfAttempts ?? 0) <= attemptsAllowed) && (c.QueueType.ToUpper() == queueTypeDesc) && c.KenticoID == cmsJob.assignment.KenticoID)
                                                                                            .Select(c => c)
                                                                                            .OrderByDescending(c => c.TimeStamp)
                                                                                            .ToList();
                    if (outIncidentLocations.Count() > 0)
                    {
                        outIncidentLocations.ForEach(x =>
                        {
                            cmsJob.incidentLocations.Add(x);
                        });
                    }

                    #endregion scan incident locations

                    #region scan payor details

                    var oPayorDetails = rCGKENTCMS_DEV01Entities.CMSPayorDetails.Where(c => (c.IsProcessed ?? false) == isProcessed && ((c.NumOfAttempts ?? 0) <= attemptsAllowed) && (c.QueueType.ToUpper() == queueTypeDesc) && c.KenticoID == cmsJob.assignment.KenticoID)
                                                                                .Select(c => c)
                                                                                .OrderByDescending(c => c.TimeStamp)
                                                                                .ToList();
                    if (oPayorDetails.Count() > 0)
                    {
                        oPayorDetails.ForEach(x =>
                        {
                            cmsJob.payorDetails.Add(x);
                        });
                    }

                    #endregion scan payor details

                    #region scan coConsultants

                    var oCoConsultants = rCGKENTCMS_DEV01Entities.CMSCoConsultants.Where(c => (c.IsProcessed ?? false) == isProcessed && ((c.NumOfAttempts ?? 0) <= attemptsAllowed) && (c.QueueType.ToUpper() == queueTypeDesc) && c.KenticoID == cmsJob.assignment.KenticoID)
                                                                                  .Select(c => c)
                                                                                  .OrderByDescending(c => c.TimeStamp)
                                                                                  .ToList();
                    if (oCoConsultants.Count() > 0)
                    {
                        oCoConsultants.ForEach(x =>
                        {
                            cmsJob.coConsultants.Add(x);
                        });
                    }

                    #endregion scan coConsultants

                    #region scan additional parties

                    var oAdditionalParties = rCGKENTCMS_DEV01Entities.CMSAdditionalParties.Where(c => (c.IsProcessed ?? false) == isProcessed && ((c.NumOfAttempts ?? 0) <= attemptsAllowed) && (c.QueueType.ToUpper() == queueTypeDesc) && c.KenticoID == cmsJob.assignment.KenticoID)
                                                                                          .Select(c => c)
                                                                                          .OrderByDescending(c => c.TimeStamp)
                                                                                          .ToList();
                    if (oAdditionalParties.Count() > 0)
                    {
                        oAdditionalParties.ForEach(x =>
                        {
                            cmsJob.additionalParties.Add(x);
                        });
                    }

                    #endregion scan additional parties
                }
            }
            else
            {
                //using (RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities())
                //{
                //    rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;

                //    #region scan assignments
                //    var oAssignmentGroup = rCGKENTCMS_PROD01Entities.CMSAssignments.Where(x => !(x.IsProcessed ?? false) && ((x.NumOfAttempts ?? 0) <= attemptsAllowed) && (x.QueueType.ToUpper() == queueTypeDesc))
                //                                                                  .GroupBy(x => new { x.KenticoID })
                //                                                                  .Select(x => x).ToList();

                //    if (oAssignmentGroup.Count() > 0)
                //    {
                //        oAssignmentGroup.ForEach(g =>
                //        {
                //            var mostUpdatedAssignmentRec = g.OrderByDescending(o => o.TimeStamp).First();
                //            CMSJob cMSJob = new CMSJob();
                //            cMSJob.assignment = mostUpdatedAssignmentRec;
                //            cMSJobs.Add(cMSJob);
                //        });
                //    }
                //    else
                //    {
                //        cMSJobs.Add(new CMSJob());
                //    }

                //    #endregion scan assignments

                //    #region scan ordering client
                //    var outClientGroup = rCGKENTCMS_PROD01Entities.CMSOrderingClients.Where(c => !(c.IsProcessed ?? false) && ((c.NumOfAttempts ?? 0) <= attemptsAllowed) && (c.QueueType.ToUpper() == queueTypeDesc))
                //                                                                    .GroupBy(c => new { c.KenticoID })
                //                                                                    .Select(c => c).ToList();
                //    if (outClientGroup.Count() > 0)
                //    {
                //        outClientGroup.ForEach(g =>
                //        {
                //            var mostUpdatedOrderClientRec = g.OrderByDescending(o => o.TimeStamp).First();
                //            // var existingOutAssignment = cMSJobs.Where(oa => oa.assignment.KenticoID == mostUpdatedOrderClientRec.KenticoID).Select(oa => oa).ToList();
                //            cMSJobs.ForEach(e =>
                //            {
                //                if (e.assignment.KenticoID == mostUpdatedOrderClientRec.KenticoID)
                //                    e.orderingClient = mostUpdatedOrderClientRec;

                //            });
                //        });

                //    }

                //    #endregion scan ordering client

                //    #region scan incident locations
                //    var outIncidentLocations = rCGKENTCMS_PROD01Entities.CMSIncidentLocations.Where(c => !(c.IsProcessed ?? false) && ((c.NumOfAttempts ?? 0) <= attemptsAllowed) && (c.QueueType.ToUpper() == queueTypeDesc))
                //                                                                            .Select(c => c)
                //                                                                            .OrderByDescending(c => c.TimeStamp)
                //                                                                            .ToList();
                //    if (outIncidentLocations.Count() > 0)
                //    {
                //        outIncidentLocations.ForEach(x =>
                //        {
                //            //var existingOutAssignment = cMSJobs.Where(oa => oa.assignment.KenticoID == x.KenticoID).Select(oa => oa).ToList();
                //            //existingOutAssignment.ForEach(a => a.incidentLocations.Add(x));

                //            cMSJobs.ForEach(e =>
                //            {
                //                if (e.assignment.KenticoID == x.KenticoID)
                //                    e.incidentLocations.Add(x);

                //            });
                //        });
                //    }
                //    #endregion scan incident locations

                //    #region scan payor details
                //    var oPayorDetails = rCGKENTCMS_PROD01Entities.CMSPayorDetails.Where(c => !(c.IsProcessed ?? false) && ((c.NumOfAttempts ?? 0) <= attemptsAllowed) && (c.QueueType.ToUpper() == queueTypeDesc))
                //                                                                .Select(c => c)
                //                                                                .OrderByDescending(c => c.TimeStamp)
                //                                                                .ToList();
                //    if (oPayorDetails.Count() > 0)
                //    {
                //        oPayorDetails.ForEach(x =>
                //        {
                //            //var existingOutAssignment = cMSJobs.Where(oa => oa.assignment.KenticoID == x.KenticoID).Select(oa => oa).ToList();
                //            //existingOutAssignment.ForEach(a => a.payorDetails.Add(x));

                //            cMSJobs.ForEach(e =>
                //            {
                //                if (e.assignment.KenticoID == x.KenticoID)
                //                    e.payorDetails.Add(x);

                //            });
                //        });
                //    }
                //    #endregion scan payor details

                //    #region scan coConsultants
                //    var oCoConsultants = rCGKENTCMS_PROD01Entities.CMSCoConsultants.Where(c => !(c.IsProcessed ?? false) && ((c.NumOfAttempts ?? 0) <= attemptsAllowed) && (c.QueueType.ToUpper() == queueTypeDesc))
                //                                                                  .Select(c => c)
                //                                                                  .OrderByDescending(c => c.TimeStamp)
                //                                                                  .ToList();
                //    if (oCoConsultants.Count() > 0)
                //    {
                //        oCoConsultants.ForEach(x =>
                //        {
                //            //var existingOutAssignment = cMSJobs.Where(oa => oa.assignment.KenticoID == x.KenticoID).Select(oa => oa).ToList();
                //            //existingOutAssignment.ForEach(a => a.coConsultants.Add(x));

                //            cMSJobs.ForEach(e =>
                //            {
                //                if (e.assignment.KenticoID == x.KenticoID)
                //                    e.coConsultants.Add(x);

                //            });
                //        });
                //    }
                //    #endregion scan coConsultants

                //    #region scan additional parties
                //    var oAdditionalParties = rCGKENTCMS_PROD01Entities.CMSAdditionalParties.Where(c => !(c.IsProcessed ?? false) && ((c.NumOfAttempts ?? 0) <= attemptsAllowed) && (c.QueueType.ToUpper() == queueTypeDesc))
                //                                                                          .Select(c => c)
                //                                                                          .OrderByDescending(c => c.TimeStamp)
                //                                                                          .ToList();
                //    if (oAdditionalParties.Count() > 0)
                //    {
                //        oAdditionalParties.ForEach(x =>
                //        {
                //            //var existingOutAssignment = cMSJobs.Where(oa => oa.assignment.KenticoID == x.KenticoID).Select(oa => oa).ToList();
                //            //existingOutAssignment.ForEach(a => a.additionalParties.Add(x));

                //            cMSJobs.ForEach(e =>
                //            {
                //                if (e.assignment.KenticoID == x.KenticoID)
                //                    e.additionalParties.Add(x);

                //            });
                //        });
                //    }
                //    #endregion scan additional parties
                //}
            }

            return cmsJob;
        }


        public void RemoveAssgnMessage(
            QueueType queueType,
            string server,
            string dbInstance,
            string kenticoID,
            int sqlCommandTimeout,
            bool isDebug = false)
        {
            string queueTypeDesc = TE3EEntityExt.GetEnumDescription(queueType);

            using (var objStreamReader = File.OpenText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $"datasource/rcgkentcms/datascripts/RemoveAssgnMessage.sql")))
            {
                string sqlStmt = objStreamReader.ReadToEnd();

                sqlStmt = sqlStmt.Replace("@server", server);
                sqlStmt = sqlStmt.Replace("@instance", dbInstance);
                sqlStmt = sqlStmt.Replace("@kenticoID", kenticoID);
                sqlStmt = sqlStmt.Replace("@queueType", queueTypeDesc);

                if (isDebug)
                {
                    RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities();
                    rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                    rCGKENTCMS_DEV01Entities.Database.ExecuteSqlCommand(sqlStmt);
                }
                else
                {
                    //RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities();
                    //rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                    //rCGKENTCMS_PROD01Entities.Database.ExecuteSqlCommand(sqlStmt);
                }
            }
        }

        public void UpdateAssgnMessage(CMSJob cMSJob, QueueType queueType, int sqlCommandTimeout, bool isDebug = false)
        {
            string queueTypeDesc = TE3EEntityExt.GetEnumDescription(queueType);

            if (isDebug)
            {
                using (RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities())
                {
                    rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;

                    #region update assignment

                    var oAssignmentGroup = rCGKENTCMS_DEV01Entities.CMSAssignments.Where(x => !(x.IsProcessed ?? false) && x.KenticoID == cMSJob.assignment.KenticoID && (x.QueueType.ToUpper() == queueTypeDesc))
                                                                                  .Select(x => x).ToList();

                    if (oAssignmentGroup.Count() > 0)
                    {

                        oAssignmentGroup.First().IsProcessed = true;
                        oAssignmentGroup.First().ProcessedDate = DateTime.Now;
                        oAssignmentGroup.First().NumOfAttempts = (oAssignmentGroup.First().NumOfAttempts ?? 0) + 1;
                    }

                    #endregion update assignment

                    #region scan ordering client

                    var outClientGroup = rCGKENTCMS_DEV01Entities.CMSOrderingClients.Where(c => !(c.IsProcessed ?? false) && c.KenticoID == cMSJob.assignment.KenticoID && (c.QueueType.ToUpper() == queueTypeDesc))
                                                                                    .Select(c => c).ToList();
                    if (outClientGroup.Count() > 0)
                    {
                        outClientGroup.First().IsProcessed = true;
                        outClientGroup.First().ProcessedDate = DateTime.Now;
                        outClientGroup.First().NumOfAttempts = (outClientGroup.First().NumOfAttempts ?? 0) + 1;
                    }

                    #endregion scan ordering client

                    #region scan incident locations

                    var outIncidentLocations = rCGKENTCMS_DEV01Entities.CMSIncidentLocations.Where(c => !(c.IsProcessed ?? false) && c.KenticoID == cMSJob.assignment.KenticoID && (c.QueueType.ToUpper() == queueTypeDesc))
                                                                                            .Select(c => c)
                                                                                            .OrderByDescending(c => c.TimeStamp)
                                                                                            .ToList();
                    if (outIncidentLocations.Count() > 0)
                    {
                        outIncidentLocations.ForEach(x =>
                        {
                            x.IsProcessed = true;
                            x.ProcessedDate = DateTime.Now;
                            x.NumOfAttempts = (x.NumOfAttempts ?? 0) + 1;
                        });
                    }

                    #endregion scan incident locations

                    #region scan payor details

                    var oPayorDetails = rCGKENTCMS_DEV01Entities.CMSPayorDetails.Where(c => !(c.IsProcessed ?? false) && c.KenticoID == cMSJob.assignment.KenticoID && (c.QueueType.ToUpper() == queueTypeDesc))
                                                                                .Select(c => c)
                                                                                .OrderByDescending(c => c.TimeStamp)
                                                                                .ToList();
                    if (oPayorDetails.Count() > 0)
                    {
                        oPayorDetails.ForEach(x =>
                        {
                            x.IsProcessed = true;
                            x.ProcessedDate = DateTime.Now;
                            x.NumOfAttempts = (x.NumOfAttempts ?? 0) + 1;
                        });
                    }

                    #endregion scan payor details

                    #region scan coConsultants

                    var oCoConsultants = rCGKENTCMS_DEV01Entities.CMSCoConsultants.Where(c => !(c.IsProcessed ?? false) && c.KenticoID == cMSJob.assignment.KenticoID && (c.QueueType.ToUpper() == queueTypeDesc))
                                                                                  .Select(c => c)
                                                                                  .OrderByDescending(c => c.TimeStamp)
                                                                                  .ToList();
                    if (oCoConsultants.Count() > 0)
                    {
                        oCoConsultants.ForEach(x =>
                        {
                            x.IsProcessed = true;
                            x.ProcessedDate = DateTime.Now;
                            x.NumOfAttempts = (x.NumOfAttempts ?? 0) + 1;
                        });
                    }

                    #endregion scan coConsultants

                    #region scan additional parties

                    var oAdditionalParties = rCGKENTCMS_DEV01Entities.CMSAdditionalParties.Where(c => !(c.IsProcessed ?? false) && c.KenticoID == cMSJob.assignment.KenticoID && (c.QueueType.ToUpper() == queueTypeDesc))
                                                                                          .Select(c => c)
                                                                                          .OrderByDescending(c => c.TimeStamp)
                                                                                          .ToList();
                    if (oAdditionalParties.Count() > 0)
                    {
                        oAdditionalParties.ForEach(x =>
                        {
                            x.IsProcessed = true;
                            x.ProcessedDate = DateTime.Now;
                            x.NumOfAttempts = (x.NumOfAttempts ?? 0) + 1;
                        });
                    }

                    #endregion scan additional parties

                    rCGKENTCMS_DEV01Entities.SaveChanges();
                }
            }
            //else
            //{
            //    //using (RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities())
            //    //{
            //    //    rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;

            //    //    #region scan assignments
            //    //    var oAssignmentGroup = rCGKENTCMS_PROD01Entities.CMSAssignments.Where(x => !((bool)x.IsProcessed) && ((x.NumOfAttempts ?? 0) <= attemptsAllowed) && (x.QueueType.ToUpper() == queueTypeDesc))
            //    //                                                                  .GroupBy(x => new { x.KenticoID, x.MatterName, x.ClientName })
            //    //                                                                  .Select(x => x).ToList();

            //    //    if (oAssignmentGroup.Count() > 0)
            //    //    {
            //    //        oAssignmentGroup.ForEach(g =>
            //    //        {
            //    //            var mostUpdatedAssignmentRec = g.OrderByDescending(o => o.TimeStamp).First();
            //    //            CMSJob cMSJob = new CMSJob();
            //    //            cMSJob.assignment = mostUpdatedAssignmentRec;
            //    //            cMSJobs.Add(cMSJob);
            //    //        });
            //    //    }
            //    //    else
            //    //    {
            //    //        cMSJobs.Add(new CMSJob());
            //    //    }

            //    //    #endregion scan assignments

            //    //    #region scan ordering client
            //    //    var outClientGroup = rCGKENTCMS_PROD01Entities.CMSOrderingClients.Where(c => !((bool)c.IsProcessed) && ((c.NumOfAttempts ?? 0) <= attemptsAllowed) && (c.QueueType.ToUpper() == queueTypeDesc))
            //    //                                                                     .GroupBy(c => new { c.KenticoID, c.CompanyName })
            //    //                                                                     .Select(c => c).ToList();
            //    //    if (outClientGroup.Count() > 0)
            //    //    {
            //    //        outClientGroup.ForEach(g =>
            //    //        {
            //    //            var mostUpdatedOrderClientRec = g.OrderByDescending(o => o.TimeStamp).First();
            //    //            var existingOutAssignment = cMSJobs.Where(oa => oa.assignment.KenticoID == mostUpdatedOrderClientRec.KenticoID).Select(oa => oa).ToList();
            //    //            existingOutAssignment.ForEach(e => e.orderingClient = mostUpdatedOrderClientRec);
            //    //        });

            //    //    }

            //    //    #endregion scan ordering client

            //    //    #region scan incident locations
            //    //    var outIncidentLocations = rCGKENTCMS_PROD01Entities.CMSIncidentLocations.Where(c => !((bool)c.IsProcessed) && ((c.NumOfAttempts ?? 0) <= attemptsAllowed) && (c.QueueType.ToUpper() == queueTypeDesc))
            //    //                                                                             .Select(c => c)
            //    //                                                                             .OrderByDescending(c => c.TimeStamp)
            //    //                                                                             .ToList();
            //    //    if (outIncidentLocations.Count() > 0)
            //    //    {
            //    //        outIncidentLocations.ForEach(x =>
            //    //        {
            //    //            var existingOutAssignment = cMSJobs.Where(oa => oa.assignment.KenticoID == x.KenticoID).Select(oa => oa).ToList();
            //    //            existingOutAssignment.ForEach(a => a.incidentLocations.Add(x));
            //    //        });
            //    //    }
            //    //    #endregion scan incident locations

            //    //    #region scan payor details
            //    //    var oPayorDetails = rCGKENTCMS_PROD01Entities.CMSPayorDetails.Where(c => !((bool)c.IsProcessed) && ((c.NumOfAttempts ?? 0) <= attemptsAllowed) && (c.QueueType.ToUpper() == queueTypeDesc))
            //    //                                                                 .Select(c => c)
            //    //                                                                 .OrderByDescending(c => c.TimeStamp)
            //    //                                                                 .ToList();
            //    //    if (oPayorDetails.Count() > 0)
            //    //    {
            //    //        oPayorDetails.ForEach(x =>
            //    //        {
            //    //            var existingOutAssignment = cMSJobs.Where(oa => oa.assignment.KenticoID == x.KenticoID).Select(oa => oa).ToList();
            //    //            existingOutAssignment.ForEach(a => a.payorDetails.Add(x));
            //    //        });
            //    //    }
            //    //    #endregion scan payor details

            //    //    #region scan coConsultants
            //    //    var oCoConsultants = rCGKENTCMS_PROD01Entities.CMSCoConsultants.Where(c => !((bool)c.IsProcessed) && ((c.NumOfAttempts ?? 0) <= attemptsAllowed) && (c.QueueType.ToUpper() == queueTypeDesc))
            //    //                                                                   .Select(c => c)
            //    //                                                                   .OrderByDescending(c => c.TimeStamp)
            //    //                                                                   .ToList();
            //    //    if (oCoConsultants.Count() > 0)
            //    //    {
            //    //        oCoConsultants.ForEach(x =>
            //    //        {
            //    //            var existingOutAssignment = cMSJobs.Where(oa => oa.assignment.KenticoID == x.KenticoID).Select(oa => oa).ToList();
            //    //            existingOutAssignment.ForEach(a => a.coConsultants.Add(x));
            //    //        });
            //    //    }
            //    //    #endregion scan coConsultants

            //    //    #region scan additional parties
            //    //    var oAdditionalParties = rCGKENTCMS_PROD01Entities.CMSAdditionalParties.Where(c => !((bool)c.IsProcessed) && ((c.NumOfAttempts ?? 0) <= attemptsAllowed) && (c.QueueType.ToUpper() == queueTypeDesc))
            //    //                                                                           .Select(c => c)
            //    //                                                                           .OrderByDescending(c => c.TimeStamp)
            //    //                                                                           .ToList();
            //    //    if (oAdditionalParties.Count() > 0)
            //    //    {
            //    //        oAdditionalParties.ForEach(x =>
            //    //        {
            //    //            var existingOutAssignment = cMSJobs.Where(oa => oa.assignment.KenticoID == x.KenticoID).Select(oa => oa).ToList();
            //    //            existingOutAssignment.ForEach(a => a.additionalParties.Add(x));
            //    //        });
            //    //    }
            //    //    #endregion scan additional parties
            //    //}
            //}
        }

        public void UpdateAssgnMessageErr(
            QueueType queueType,
            string server,
            string dbInstance,
            string kenticoID,
            string errMsg,
            int sqlCommandTimeout,
            bool isDebug = false)
        {
            string queueTypeDesc = TE3EEntityExt.GetEnumDescription(queueType);

            using (var objStreamReader = File.OpenText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $"datasource/rcgkentcms/datascripts/UpdateAssgnMessageErr.sql")))
            {
                string sqlStmt = objStreamReader.ReadToEnd();

                sqlStmt = sqlStmt.Replace("@server", server);
                sqlStmt = sqlStmt.Replace("@instance", dbInstance);
                sqlStmt = sqlStmt.Replace("@kenticoID", kenticoID);
                sqlStmt = sqlStmt.Replace("@errMsg", errMsg.Replace("'", "\""));
                sqlStmt = sqlStmt.Replace("@queueType", queueTypeDesc);

                if (isDebug)
                {
                    RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities();
                    rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                    rCGKENTCMS_DEV01Entities.Database.ExecuteSqlCommand(sqlStmt);
                }
                else
                {
                    //RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities();
                    //rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                    //rCGKENTCMS_PROD01Entities.Database.ExecuteSqlCommand(sqlStmt);
                }
            }
        }

        #endregion assignment data access methods

        #region Kentico Assignment Copy data access methods

        public Assignment GetKenticoAssignmentCopy(string kenticoId, int sqlCommandTimeout, bool isDebug = false)
        {
            Assignment assignment = null;

            if (isDebug)
            {
                using (RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities())
                {
                    rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                    var kenticoAssignmentCopy = rCGKENTCMS_DEV01Entities.CMSKenticoAssignmentCopies.FirstOrDefault(x => x.KenticoId.Equals(kenticoId));
                    if (kenticoAssignmentCopy != null)
                    {
                        assignment = JsonConvert.DeserializeObject<Assignment>(kenticoAssignmentCopy.AssignmentImageJson);
                    }
                }
            }
            else
            {
                //using (RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities())
                //{
                //    rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                //    results = rCGKENTCMS_PROD01Entities.CMSKeyVaults.ToList();
                //}
            }
            return assignment;
        }


        public void AddOrUpdateKenticoAssignmentCopy(Assignment assignment, int sqlCommandTimeout, bool isDebug = false)
        {

            if (isDebug)
            {
                using (RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities())
                {
                    rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;

                    var kenticoAssignmentCopy = rCGKENTCMS_DEV01Entities.CMSKenticoAssignmentCopies.FirstOrDefault(x => x.KenticoId.Equals(assignment.KenticoID));
                    if (kenticoAssignmentCopy == null)
                    {
                        kenticoAssignmentCopy = new CMSKenticoAssignmentCopy()
                        {
                            KenticoId = assignment.KenticoID,
                            E3EID = assignment.E3EID,
                            MatterIndex = assignment.E3EID,
                            AssignmentImageJson = JsonConvert.SerializeObject(assignment),
                            Timestamp = DateTime.Now
                        };
                        rCGKENTCMS_DEV01Entities.CMSKenticoAssignmentCopies.Add(kenticoAssignmentCopy);
                    }
                    else
                    {
                        kenticoAssignmentCopy.KenticoId = assignment.KenticoID;
                        kenticoAssignmentCopy.E3EID = assignment.E3EID;
                        kenticoAssignmentCopy.MatterIndex = assignment.E3EID;
                        kenticoAssignmentCopy.AssignmentImageJson = JsonConvert.SerializeObject(assignment);
                        kenticoAssignmentCopy.Timestamp = DateTime.Now;
                    }
                    rCGKENTCMS_DEV01Entities.SaveChanges();
                }
            }
            else
            {
                //using (RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities())
                //{
                //    rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                //    results = rCGKENTCMS_PROD01Entities.CMSKeyVaults.ToList();
                //}
            }
        }

        #endregion

        #region customer profile data access methods

        public void AddCustomer(CMSCustomerProfile customer, QueueType queueType, int sqlCommandTimeout, bool isDebug = false)
        {
            #region set queue type
            customer.QueueType = TE3EEntityExt.GetEnumDescription(queueType);

            #endregion set queue type

            if (isDebug)
            {
                using (RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities())
                {
                    rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                    rCGKENTCMS_DEV01Entities.CMSCustomerProfiles.Add(customer);
                    rCGKENTCMS_DEV01Entities.SaveChanges();
                }
            }
            else
            {
                //using (RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities())
                //{
                //    rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                //    rCGKENTCMS_PROD01Entities.CMSCustomerProfiles.Add(iCustomer);
                //    rCGKENTCMS_PROD01Entities.SaveChanges();
                //}
            }
        }


        public List<CMSCustomerProfile> GetCustomers(QueueType queueType, int sqlCommandTimeout, bool isDebug = false, int attemptsAllowed = 20)
        {
            List<CMSCustomerProfile> oCustomers = new List<CMSCustomerProfile>();
            string queueTypeDesc = TE3EEntityExt.GetEnumDescription(queueType);

            if (isDebug)
            {
                using (RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities())
                {
                    rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                    var custGrouping = rCGKENTCMS_DEV01Entities.CMSCustomerProfiles.Where(x => !(x.IsProcessed ?? false) && ((x.NumOfAttempts ?? 0) <= attemptsAllowed) && (x.QueueType.ToUpper() == queueTypeDesc))
                                                                                   .GroupBy(x => new { x.KenticoID, x.ClientNumber, x.CompanyName, x.FirstName, x.LastName })
                                                                                   .Select(x => x).ToList();

                    custGrouping.ForEach(g =>
                    {
                        var mostedUpdatedRec = g.OrderByDescending(o => o.TimeStamp).First();
                        oCustomers.Add(mostedUpdatedRec);
                    });
                }
            }
            else
            {
                //using (RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities())
                //{
                //    rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                //    var custGrouping = rCGKENTCMS_PROD01Entities.CMSCustomerProfiles.Where(x => !((bool)x.IsProcessed) && ((x.NumOfAttempts ?? 0) <= attemptsAllowed) && (x.QueueType.ToUpper() == queueTypeDesc))
                //                                                                    .GroupBy(x => new { x.KenticoID, x.ClientNumber, x.CompanyName, x.FirstName, x.LastName })
                //                                                                    .Select(x => x).ToList();

                //    custGrouping.ForEach(g =>
                //    {
                //        var mostedUpdatedRec = g.OrderByDescending(o => o.TimeStamp).First();
                //        oCustomers.Add(mostedUpdatedRec);
                //    });
                //}
            }

            return oCustomers;
        }

        public void RemoveCustomer(CMSCustomerProfile iCustomer, QueueType queueType, int sqlCommandTimeout, bool isDebug = false)
        {
            string queueTypeDesc = TE3EEntityExt.GetEnumDescription(queueType);

            if (isDebug)
            {
                using (RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities())
                {
                    rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                    var deletedInCustomers = rCGKENTCMS_DEV01Entities.CMSCustomerProfiles.Where(k => (k.KenticoID == iCustomer.KenticoID) && (k.QueueType.ToUpper() == queueTypeDesc));
                    rCGKENTCMS_DEV01Entities.CMSCustomerProfiles.RemoveRange(deletedInCustomers);
                    rCGKENTCMS_DEV01Entities.SaveChanges();
                }
            }
            else
            {
                //using (RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities())
                //{
                //    rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                //    var deletedInCustomers = rCGKENTCMS_PROD01Entities.CMSCustomerProfiles.Where(k => (k.KenticoID == iCustomer.KenticoID) && (k.QueueType.ToUpper() == queueTypeDesc));
                //    rCGKENTCMS_PROD01Entities.CMSCustomerProfiles.RemoveRange(deletedInCustomers);
                //    rCGKENTCMS_PROD01Entities.SaveChanges();
                //}
            }
        }

        public void RemoveCustMessage(
            QueueType queueType,
            string server,
            string dbInstance,
            string kenticoID,
            int sqlCommandTimeout,
            bool isDebug = false)
        {
            string queueTypeDesc = TE3EEntityExt.GetEnumDescription(queueType);

            using (var objStreamReader = File.OpenText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $"datasource/rcgkentcms/datascripts/RemoveCustMessage.sql")))
            {
                string sqlStmt = objStreamReader.ReadToEnd();

                sqlStmt = sqlStmt.Replace("@server", server);
                sqlStmt = sqlStmt.Replace("@instance", dbInstance);
                sqlStmt = sqlStmt.Replace("@kenticoID", kenticoID);
                sqlStmt = sqlStmt.Replace("@queueType", queueTypeDesc);

                if (isDebug)
                {
                    RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities();
                    rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                    rCGKENTCMS_DEV01Entities.Database.ExecuteSqlCommand(sqlStmt);
                }
                else
                {
                    //RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities();
                    //rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                    //rCGKENTCMS_PROD01Entities.Database.ExecuteSqlCommand(sqlStmt);
                }
            }
        }

        public void UpdateCustomerMessage(CMSCustomerProfile cMSJob, QueueType queueType, int sqlCommandTimeout, bool isDebug = false)
        {
            string queueTypeDesc = TE3EEntityExt.GetEnumDescription(queueType);

            if (isDebug)
            {
                using (RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities())
                {
                    rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;

                    #region update assignment

                    var ocustomer = rCGKENTCMS_DEV01Entities.CMSCustomerProfiles.Where(x => !(x.IsProcessed ?? false) && x.KenticoID == cMSJob.KenticoID && (x.QueueType.ToUpper() == queueTypeDesc)).FirstOrDefault();

                    if (ocustomer != null)
                    {
                        ocustomer.IsProcessed = true;
                        ocustomer.ProcessedDate = DateTime.Now;
                    }
                    rCGKENTCMS_DEV01Entities.SaveChanges();
                }
            }
            //else
            //{
            // TODO
            //}
        }

        public void UpdateCustMessageErr(
            QueueType queueType,
            string server,
            string dbInstance,
            string kenticoID,
            string errMsg,
            int sqlCommandTimeout,
            bool isDebug = false)
        {
            string queueTypeDesc = TE3EEntityExt.GetEnumDescription(queueType);

            using (var objStreamReader = File.OpenText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $"datasource/rcgkentcms/datascripts/UpdateCustMessageErr.sql")))
            {
                string sqlStmt = objStreamReader.ReadToEnd();

                sqlStmt = sqlStmt.Replace("@server", server);
                sqlStmt = sqlStmt.Replace("@instance", dbInstance);
                sqlStmt = sqlStmt.Replace("@kenticoID", kenticoID);
                sqlStmt = sqlStmt.Replace("@errMsg", errMsg.Replace("'", "\""));
                sqlStmt = sqlStmt.Replace("@queueType", queueTypeDesc);

                if (isDebug)
                {
                    RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities();
                    rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                    rCGKENTCMS_DEV01Entities.Database.ExecuteSqlCommand(sqlStmt);
                }
                else
                {
                    //RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities();
                    //rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                    //rCGKENTCMS_PROD01Entities.Database.ExecuteSqlCommand(sqlStmt);
                }
            }
        }

        #endregion customer profile data access methods


        #region Kentico customer Copy data access methods

        public CustomerProfile GetKenticoCustomerCopy(string kenticoId, int sqlCommandTimeout, bool isDebug = false)
        {
            CustomerProfile customerProfile = null;

            if (isDebug)
            {
                using (RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities())
                {
                    rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                    var kenticoAssignmentCopy = rCGKENTCMS_DEV01Entities.CMSKenticoCustomerCopies.FirstOrDefault(x => x.KenticoId.Equals(kenticoId));
                    if (kenticoAssignmentCopy != null)
                    {
                        customerProfile = JsonConvert.DeserializeObject<CustomerProfile>(kenticoAssignmentCopy.CustomerImageJson);
                    }
                }
            }
            else
            {
                //using (RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities())
                //{
                //    rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                //    results = rCGKENTCMS_PROD01Entities.CMSKeyVaults.ToList();
                //}
            }
            return customerProfile;
        }


        public void AddOrUpdateKenticoCustomerCopy(CustomerProfile customerProfile, int sqlCommandTimeout, bool isDebug = false)
        {

            if (isDebug)
            {
                using (RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities())
                {
                    rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;

                    var kenticoAssignmentCopy = rCGKENTCMS_DEV01Entities.CMSKenticoCustomerCopies.FirstOrDefault(x => x.KenticoId.Equals(customerProfile.kenticoId));
                    if (kenticoAssignmentCopy == null)
                    {
                        kenticoAssignmentCopy = new CMSKenticoCustomerCopy()
                        {
                            KenticoId = customerProfile.kenticoId,
                            E3EID = customerProfile.e3EId,
                            //ClientNumber = customerProfile.,
                            CustomerImageJson = JsonConvert.SerializeObject(customerProfile),
                            Timestamp = DateTime.Now
                        };
                        rCGKENTCMS_DEV01Entities.CMSKenticoCustomerCopies.Add(kenticoAssignmentCopy);
                    }
                    else
                    {
                        kenticoAssignmentCopy.KenticoId = customerProfile.kenticoId;
                        kenticoAssignmentCopy.E3EID = customerProfile.e3EId;
                        //kenticoAssignmentCopy.MatterIndex = customerProfile.E3EID;
                        kenticoAssignmentCopy.CustomerImageJson = JsonConvert.SerializeObject(customerProfile);
                        kenticoAssignmentCopy.Timestamp = DateTime.Now;
                    }
                    rCGKENTCMS_DEV01Entities.SaveChanges();
                }
            }
            else
            {
                //using (RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities())
                //{
                //    rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                //    results = rCGKENTCMS_PROD01Entities.CMSKeyVaults.ToList();
                //}
            }
        }

        #endregion

        #region kentico assignment and customer relationship data access methods

        public void AddOrUpdateKenticoAssignmentRel(CMSKenticoAssignmentRel kentico3ERel, int sqlCommandTimeout, bool isDebug = false)
        {
            if (isDebug)
            {
                using (RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities())
                {
                    rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                    var k3eMattRels = rCGKENTCMS_DEV01Entities.CMSKenticoAssignmentRels.Where(k => k.ClientIndex == kentico3ERel.ClientIndex || k.ClientNumber == kentico3ERel.ClientNumber);

                    if (k3eMattRels.Count() > 0)
                    {
                        var k3eMattRel = k3eMattRels.FirstOrDefault();

                        k3eMattRel.E3EID = kentico3ERel.E3EID;
                        k3eMattRel.KenticoID = kentico3ERel.KenticoID;
                        k3eMattRel.MatterIndex = kentico3ERel.MatterIndex;
                        k3eMattRel.MatterNumber = kentico3ERel.MatterNumber;
                        k3eMattRel.ClientIndex = kentico3ERel.ClientIndex;
                        k3eMattRel.ClientNumber = kentico3ERel.ClientNumber;
                        k3eMattRel.TimeStamp = DateTime.Now;
                    }
                    else
                    {
                        rCGKENTCMS_DEV01Entities.CMSKenticoAssignmentRels.Add(kentico3ERel);
                    }

                    rCGKENTCMS_DEV01Entities.SaveChanges();
                }
            }
            else
            {
                //using (RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities())
                //{
                //    rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                //    var k3eMattRels = rCGKENTCMS_PROD01Entities.CMSKenticoAssignmentRels.Where(k => k.ClientIndex == kentico3ERel.ClientIndex || k.ClientNumber == kentico3ERel.ClientNumber);

                //    if (k3eMattRels.Count() > 0)
                //    {
                //        k3eMattRels.First().E3EID = kentico3ERel.E3EID;
                //        k3eMattRels.First().KenticoID = kentico3ERel.KenticoID;
                //        k3eMattRels.First().MatterIndex = kentico3ERel.MatterIndex;
                //        k3eMattRels.First().MatterNumber = kentico3ERel.MatterNumber;
                //        k3eMattRels.First().ClientIndex = kentico3ERel.ClientIndex;
                //        k3eMattRels.First().ClientNumber = kentico3ERel.ClientNumber;
                //        k3eMattRels.First().TimeStamp = DateTime.Now;
                //    }
                //    else
                //    {
                //        rCGKENTCMS_PROD01Entities.CMSKenticoAssignmentRels.Add(kentico3ERel);
                //    }

                //    rCGKENTCMS_PROD01Entities.SaveChanges();
                //}
            }
        }

        public CMSKenticoAssignmentRel GetKenticoAssignmentRel(int matterIndex, int sqlCommandTimeout, bool isDebug = false)
        {
            CMSKenticoAssignmentRel kentico3ERels = new CMSKenticoAssignmentRel();

            if (isDebug)
            {
                using (RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities())
                {
                    rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                    var results = rCGKENTCMS_DEV01Entities.CMSKenticoAssignmentRels.Where(k => k.MatterIndex == matterIndex).OrderByDescending(x => x.TimeStamp).Select(k => k).ToList();
                    kentico3ERels = results.Count() > 0 ? results.First() : null;
                }
            }
            else
            {
                //using (RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities())
                //{
                //    rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                //    var results = rCGKENTCMS_PROD01Entities.CMSKenticoAssignmentRels.Where(k => k.MatterIndex == matterIndex).OrderByDescending(x => x.TimeStamp).Select(k => k).ToList();
                //    kentico3ERels = results.Count() > 0 ? results.First() : null;
                //}
            }

            return kentico3ERels;
        }


        public void AddOrUpdateKenAssignSubEntRel(CMSKenticoSubEntityRel kenticoSubEntityRel, int sqlCommandTimeout, bool isDebug = false)
        {
            if (isDebug)
            {
                using (RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities())
                {
                    rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                    CMSKenticoSubEntityRel k3eMattRel = null;

                    var query = rCGKENTCMS_DEV01Entities.CMSKenticoSubEntityRels.AsQueryable();


                    if (!string.IsNullOrEmpty(kenticoSubEntityRel.KenticoId) && !string.IsNullOrEmpty(kenticoSubEntityRel.SubKenticoId))
                    {
                        k3eMattRel = rCGKENTCMS_DEV01Entities.CMSKenticoSubEntityRels.Where(k => k.KenticoId == kenticoSubEntityRel.KenticoId && k.SubKenticoId == kenticoSubEntityRel.SubKenticoId && k.EntityType == kenticoSubEntityRel.EntityType).OrderByDescending(x => x.TimeStamp).FirstOrDefault();
                    }
                    if (k3eMattRel == null)
                    {
                        k3eMattRel = rCGKENTCMS_DEV01Entities.CMSKenticoSubEntityRels.Where(k => k.MatterIndex == kenticoSubEntityRel.MatterIndex && k.EntityKey == kenticoSubEntityRel.EntityKey && k.EntityType == kenticoSubEntityRel.EntityType).OrderByDescending(x => x.TimeStamp).FirstOrDefault();
                    }

                    if (k3eMattRel != null)
                    {
                        k3eMattRel.KenticoId = kenticoSubEntityRel.KenticoId;
                        k3eMattRel.SubKenticoId = kenticoSubEntityRel.SubKenticoId;
                        k3eMattRel.EntityType = kenticoSubEntityRel.EntityType;
                        k3eMattRel.EntityKey = kenticoSubEntityRel.EntityKey;
                        k3eMattRel.MatterIndex = kenticoSubEntityRel.MatterIndex;
                        k3eMattRel.E3EID = kenticoSubEntityRel.E3EID;
                        k3eMattRel.TimeStamp = DateTime.Now;
                    }
                    else
                    {
                        rCGKENTCMS_DEV01Entities.CMSKenticoSubEntityRels.Add(kenticoSubEntityRel);
                    }

                    rCGKENTCMS_DEV01Entities.SaveChanges();
                }
            }
            else
            {
                //using (RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities())
                //{
                //    rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                //    var k3eMattRels = rCGKENTCMS_PROD01Entities.CMSKenticoAssignmentRels.Where(k => k.ClientIndex == kentico3ERel.ClientIndex || k.ClientNumber == kentico3ERel.ClientNumber);

                //    if (k3eMattRels.Count() > 0)
                //    {
                //        k3eMattRels.First().E3EID = kentico3ERel.E3EID;
                //        k3eMattRels.First().KenticoID = kentico3ERel.KenticoID;
                //        k3eMattRels.First().MatterIndex = kentico3ERel.MatterIndex;
                //        k3eMattRels.First().MatterNumber = kentico3ERel.MatterNumber;
                //        k3eMattRels.First().ClientIndex = kentico3ERel.ClientIndex;
                //        k3eMattRels.First().ClientNumber = kentico3ERel.ClientNumber;
                //        k3eMattRels.First().TimeStamp = DateTime.Now;
                //    }
                //    else
                //    {
                //        rCGKENTCMS_PROD01Entities.CMSKenticoAssignmentRels.Add(kentico3ERel);
                //    }

                //    rCGKENTCMS_PROD01Entities.SaveChanges();
                //}
            }
        }

        public CMSKenticoSubEntityRel GetKenAssignSubEntRelByMatterIndex(int matterIndex, string SubEntityKey, KenticoSubEntityRelEnum SubEntityType, int sqlCommandTimeout, bool isDebug = false)
        {
            CMSKenticoSubEntityRel kentico3ERels = new CMSKenticoSubEntityRel();

            if (isDebug)
            {
                using (RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities())
                {
                    rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                    kentico3ERels = rCGKENTCMS_DEV01Entities.CMSKenticoSubEntityRels.Where(k => k.MatterIndex == matterIndex && k.EntityType == SubEntityType.ToString() && k.EntityKey == SubEntityKey).OrderByDescending(x => x.TimeStamp).FirstOrDefault();
                }
            }
            else
            {
                //Todo
                //using (RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities())
                //{
                //    rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                //    var results = rCGKENTCMS_PROD01Entities.CMSKenticoAssignmentRels.Where(k => k.MatterIndex == matterIndex).OrderByDescending(x => x.TimeStamp).Select(k => k).ToList();
                //    kentico3ERels = results.Count() > 0 ? results.First() : null;
                //}
            }

            return kentico3ERels;
        }
        public List<CMSKenticoSubEntityRel> GetKenAssignRefrenceNumberRelByKenticoId(string kenticoId, int sqlCommandTimeout, bool isDebug = false)
        {
            List<CMSKenticoSubEntityRel> kentico3ERels = new List<CMSKenticoSubEntityRel>();

            if (isDebug)
            {
                using (RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities())
                {
                    rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                    kentico3ERels = rCGKENTCMS_DEV01Entities.CMSKenticoSubEntityRels.Where(k => k.KenticoId == kenticoId && k.EntityType == KenticoSubEntityRelEnum.ReferenceNumbers.ToString()).OrderByDescending(x => x.TimeStamp).ToList();
                }
            }
            else
            {
                //Todo
                //using (RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities())
                //{
                //    rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                //    var results = rCGKENTCMS_PROD01Entities.CMSKenticoAssignmentRels.Where(k => k.MatterIndex == matterIndex).OrderByDescending(x => x.TimeStamp).Select(k => k).ToList();
                //    kentico3ERels = results.Count() > 0 ? results.First() : null;
                //}
            }

            return kentico3ERels;
        }

        public CMSKenticoSubEntityRel GetKenAssignSubEntRelByKenticoId(string kenticoId, string SubKenticoId, KenticoSubEntityRelEnum SubEntityType, int sqlCommandTimeout, bool isDebug = false)
        {
            CMSKenticoSubEntityRel kentico3ERels = new CMSKenticoSubEntityRel();

            if (isDebug)
            {
                using (RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities())
                {
                    rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                    kentico3ERels = rCGKENTCMS_DEV01Entities.CMSKenticoSubEntityRels.Where(k => k.KenticoId == kenticoId && k.SubKenticoId == SubKenticoId && k.EntityType == SubEntityType.ToString()).OrderByDescending(x => x.TimeStamp).FirstOrDefault();
                }
            }
            else
            {
                //Todo
                //using (RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities())
                //{
                //    rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                //    var results = rCGKENTCMS_PROD01Entities.CMSKenticoAssignmentRels.Where(k => k.MatterIndex == matterIndex).OrderByDescending(x => x.TimeStamp).Select(k => k).ToList();
                //    kentico3ERels = results.Count() > 0 ? results.First() : null;
                //}
            }

            return kentico3ERels;
        }

        public void AddOrUpdateKenticoCustomerRel(CMSKenticoCustomerRel kenticoCustomerRel, int sqlCommandTimeout, bool isDebug = false)
        {
            if (isDebug)
            {
                using (RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities())
                {
                    rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                    var kenticoCustomers = rCGKENTCMS_DEV01Entities.CMSKenticoCustomerRels.Where(k => k.ClientNumber == kenticoCustomerRel.ClientNumber);

                    if (kenticoCustomers.Count() > 0)
                    {
                        var kCust = kenticoCustomers.First();
                        kCust.ContactID = kenticoCustomerRel.ContactID;
                        kCust.KenticoID = kenticoCustomerRel.KenticoID;
                        kCust.ClientNumber = kenticoCustomerRel.ClientNumber;
                        kCust.ClientName = kenticoCustomerRel.ClientName;
                        kCust.TimeStamp = DateTime.Now;
                    }
                    else
                    {
                        rCGKENTCMS_DEV01Entities.CMSKenticoCustomerRels.Add(kenticoCustomerRel);
                    }

                    rCGKENTCMS_DEV01Entities.SaveChanges();
                }
            }
            else
            {
                //using (RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities())
                //{
                //    rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                //    var kenticoCustomers = rCGKENTCMS_PROD01Entities.CMSKenticoCustomerRels.Where(k => k.ClientNumber == kenticoCustomerRel.ClientNumber);

                //    if (kenticoCustomers.Count() > 0)
                //    {
                //        var kCust = kenticoCustomers.First();
                //        kCust.ContactID = kenticoCustomerRel.ContactID;
                //        kCust.KenticoID = kenticoCustomerRel.KenticoID;
                //        kCust.ClientNumber = kenticoCustomerRel.ClientNumber;
                //        kCust.ClientName = kenticoCustomerRel.ClientName;
                //        kCust.TimeStamp = DateTime.Now;
                //    }
                //    else
                //    {
                //        rCGKENTCMS_PROD01Entities.CMSKenticoCustomerRels.Add(kenticoCustomerRel);
                //    }

                //    rCGKENTCMS_PROD01Entities.SaveChanges();
                //}
            }
        }

        public CMSKenticoCustomerRel GetKenticoCustomerRel(string cliNumber, int sqlCommandTimeout, bool isDebug = false)
        {
            CMSKenticoCustomerRel kenticoCustomerRel = new CMSKenticoCustomerRel();

            if (isDebug)
            {
                using (RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities())
                {
                    rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                    var results = rCGKENTCMS_DEV01Entities.CMSKenticoCustomerRels.Where(k => k.ClientNumber == cliNumber);
                    kenticoCustomerRel = results.Count() > 0 ? results.First() : null;
                }
            }
            else
            {
                //using (RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities())
                //{
                //    rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                //    var results = rCGKENTCMS_PROD01Entities.CMSKenticoCustomerRels.Where(k => k.ClientNumber == cliNumber);
                //    kenticoCustomerRel = results.Count() > 0 ? results.First() : null;
                //}
            }

            return kenticoCustomerRel;
        }

        #endregion kentico assignment and customer relationship data access methods

        #endregion CMS Table SQL Actions

        #region Rimkus Connect REST API

        public IEnumerable<CMSGetLookupTypes_Result> GetLookupTypes(int sqlCommandTimeout, bool isDebug = false)
        {
            IEnumerable<CMSGetLookupTypes_Result> results = null;

            if (isDebug)
            {
                RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities();
                rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                results = rCGKENTCMS_DEV01Entities.CMSGetLookupTypes().ToList();
            }
            else
            {
                //RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities();
                //rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                //results = rCGKENTCMS_PROD01Entities.CMSGetLookupTypes().ToList();
            }

            return results;
        }

        public List<CMSGetLookupCodes_Result> GetLookupCodes(int lookupId, int sqlCommandTimeout, bool isDebug = false)
        {
            List<CMSGetLookupCodes_Result> results = null;

            if (isDebug)
            {
                var lookupTypes = GetLookupTypes(sqlCommandTimeout, isDebug).Where(x => x.ID == lookupId).Select(x => x);
                var lookupType = (lookupTypes != null) ? lookupTypes.First().Type : "";

                RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities();
                rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                results = rCGKENTCMS_DEV01Entities.CMSGetLookupCodes(lookupType).ToList();
            }
            else
            {
                //var lookupTypes = GetLookupTypes(sqlCommandTimeout, isDebug).Where(x => x.ID == lookupId).Select(x => x);
                //var lookupType = (lookupTypes != null) ? lookupTypes.First().Type : "";

                //RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities();
                //rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                //results = rCGKENTCMS_PROD01Entities.CMSGetLookupCodes(lookupType).ToList();
            }

            return results;
        }

        public CMSConvertToCliTypeByCode_Result ConvertCliTypeByCode(string cliTypeCode, int sqlCommandTimeout, bool isDebug = false)
        {
            CMSConvertToCliTypeByCode_Result cliType = null;

            if (isDebug)
            {
                RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities();
                rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                var results = rCGKENTCMS_DEV01Entities.CMSConvertToCliTypeByCode(cliTypeCode).ToList();
                cliType = results.Count() > 0 ? results.First() : null;
            }
            else
            {
                //RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities();
                //rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                //var results = rCGKENTCMS_PROD01Entities.CMSConvertToCliTypeByCode(cliTypeCode);
                //cliType = results.Count() > 0 ? results.First() : null;
            }

            return cliType;
        }

        public List<CMSSearchTimekeepers_Result> GetTimekeepers(string name, int sqlCommandTimeout, bool isDebug = false)
        {
            List<CMSSearchTimekeepers_Result> results = null;

            if (isDebug)
            {
                RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities();
                rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                results = rCGKENTCMS_DEV01Entities.CMSSearchTimekeepers(name).ToList();
            }
            else
            {
                //RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities();
                //rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                //results = rCGKENTCMS_PROD01Entities.CMSSearchTimekeepers(name).ToList();
            }

            return results;
        }

        public List<CMSSearchClients_Result> GetClients(string name, int sqlCommandTimeout, bool isDebug = false)
        {
            List<CMSSearchClients_Result> results = null;

            if (isDebug)
            {
                RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities();
                rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                results = rCGKENTCMS_DEV01Entities.CMSSearchClients(name).ToList();
            }
            else
            {
                //RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities();
                //rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                //results = rCGKENTCMS_PROD01Entities.CMSSearchClients(name).ToList();
            }

            return results;
        }

        public List<CMSSearchEntity_Result> GetEntities(string name, int sqlCommandTimeout, bool isDebug = false)
        {
            List<CMSSearchEntity_Result> results = null;

            if (isDebug)
            {
                RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities();
                rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                results = rCGKENTCMS_DEV01Entities.CMSSearchEntity(name).ToList();
            }
            else
            {
                //RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities();
                //rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                //results = rCGKENTCMS_PROD01Entities.CMSSearchEntity(name).ToList();
            }

            return results;
        }

        public List<CMSSearchRelMatters_Result> GetRelMatters(string name, int sqlCommandTimeout, bool isDebug = false)
        {
            List<CMSSearchRelMatters_Result> results = null;

            if (isDebug)
            {
                RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities();
                rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                results = rCGKENTCMS_DEV01Entities.CMSSearchRelMatters(name).ToList();
            }
            else
            {
                //RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities();
                //rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                //results = rCGKENTCMS_PROD01Entities.CMSSearchRelMatters(name).ToList();
            }

            return results;
        }

        public List<CMSGetClientsByType_Result> GetClientsByType(int lookupId, int sqlCommandTimeout, bool isDebug = false)
        {
            List<CMSGetClientsByType_Result> results = null;

            if (isDebug)
            {
                RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities();
                rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                results = rCGKENTCMS_DEV01Entities.CMSGetClientsByType(lookupId.ToString()).ToList();
            }
            else
            {
                //RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities();
                //rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                //results = rCGKENTCMS_PROD01Entities.CMSGetClientsByType(lookupId.ToString()).ToList();
            }

            return results;
        }

        public List<CMSGetClientMatters_Result> GetClientMatters(int clientNo, int sqlCommandTimeout, bool isDebug = false)
        {
            List<CMSGetClientMatters_Result> results = null;

            if (isDebug)
            {
                RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities();
                rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                results = rCGKENTCMS_DEV01Entities.CMSGetClientMatters(clientNo.ToString("D7")).ToList();
            }
            else
            {
                //RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities();
                //rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                //results = rCGKENTCMS_PROD01Entities.CMSGetClientMatters(clientNo.ToString("D7")).ToList();
            }

            return results;
        }

        public List<CMSGetClientMattersByRelSiteEmail_Result> GetClientMattersByEmail(string email, int sqlCommandTimeout, bool isDebug = false)
        {
            List<CMSGetClientMattersByRelSiteEmail_Result> results = null;

            if (isDebug)
            {
                RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities();
                rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                results = rCGKENTCMS_DEV01Entities.CMSGetClientMattersByRelSiteEmail(email).ToList();
            }
            else
            {
                //RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities();
                //rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                //results = rCGKENTCMS_PROD01Entities.CMSGetClientMattersByRelSiteEmail(email).ToList();
            }

            return results;
        }

        public List<CMSGetAllClientMatters_Result> GetAllClientMatters(int offset, int limit, int sqlCommandTimeout, bool isDebug = false)
        {
            List<CMSGetAllClientMatters_Result> results = null;

            if (isDebug)
            {
                RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities();
                rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                results = rCGKENTCMS_DEV01Entities.CMSGetAllClientMatters(offset, limit).ToList();
            }
            else
            {
                //RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities();
                //rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                //results = rCGKENTCMS_PROD01Entities.CMSGetAllClientMatters(offset, limit).ToList();
            }

            return results;
        }

        public List<CMSGetAllClientMatters_V2_Result> GetAllClientMatters_V2(string status, string search, string email, string clientNumber, int offset, int limit, out int totalCountOut, out int filteredCountOut, int sqlCommandTimeout, bool isDebug = false)
        {
            List<CMSGetAllClientMatters_V2_Result> results = null;
            ObjectParameter totalCount = new ObjectParameter(nameof(totalCount), typeof(int));
            ObjectParameter filteredCount = new ObjectParameter(nameof(filteredCount), typeof(int));
            if (isDebug)
            {
                RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities();
                rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;

                results = rCGKENTCMS_DEV01Entities.CMSGetAllClientMatters_V2(offset, limit, status, search, email, clientNumber, totalCount, filteredCount).ToList();
            }
            else
            {
                //RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities();
                //rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                //results = rCGKENTCMS_PROD01Entities.CMSGetAllClientMatters_V2(offset, limit,status,search).ToList();
            }
            totalCountOut = Convert.ToInt32(totalCount.Value ?? 0);
            filteredCountOut = Convert.ToInt32(filteredCount.Value ?? 0);
            return results;
        }

        public CMSGetMatterDetails_Result GetMatterDetails(int mattIndex, int sqlCommandTimeout, bool isDebug = false)
        {
            List<CMSGetMatterDetails_Result> results = null;

            if (isDebug)
            {
                RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities();
                rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                results = rCGKENTCMS_DEV01Entities.CMSGetMatterDetails(mattIndex.ToString()).ToList();
            }
            else
            {
                //RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities();
                //rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                //results = rCGKENTCMS_PROD01Entities.CMSGetMatterDetails(mattIndex.ToString()).ToList();
            }

            if (results.Count() == 0)
                throw new AssignmentNotFoundException($"Assignment ID Not Found. No assignment with ID = {mattIndex}");

            return results.First();
        }

        public List<CMSGetMatterNotes_Result> GetMatterNotes(int mattIndex, int sqlCommandTimeout, bool isDebug = false)
        {
            List<CMSGetMatterNotes_Result> results = null;

            if (isDebug)
            {
                RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities();
                rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                results = rCGKENTCMS_DEV01Entities.CMSGetMatterNotes(mattIndex.ToString()).ToList();
            }
            else
            {
                //RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities();
                //rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                //results = rCGKENTCMS_PROD01Entities.CMSGetMatterNotes(mattIndex.ToString()).ToList();
            }

            return results;
        }

        public CMSGetFullMatterDetails_Result GetFullMatterDetails(int mattIndex, int sqlCommandTimeout, bool isDebug = false)
        {
            List<CMSGetFullMatterDetails_Result> results = null;

            if (isDebug)
            {
                RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities();
                rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                results = rCGKENTCMS_DEV01Entities.CMSGetFullMatterDetails(mattIndex.ToString()).ToList();
            }
            else
            {
                //RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities();
                //rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                //results = rCGKENTCMS_PROD01Entities.CMSGetFullMatterDetails(mattIndex.ToString()).ToList();
            }

            if (results.Count() == 0)
                throw new AssignmentNotFoundException($"Assignment ID Not Found. No assignment with ID = {mattIndex}");

            return results.First();
        }

        public CMSGetFullMatterOrderingClientDetails_Result GetFullMatterOrderingClientDetails(int mattIndex, int sqlCommandTimeout, bool isDebug = false)
        {
            List<CMSGetFullMatterOrderingClientDetails_Result> results = null;

            if (isDebug)
            {
                RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities();
                rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                results = rCGKENTCMS_DEV01Entities.CMSGetFullMatterOrderingClientDetails(mattIndex.ToString()).ToList();
            }
            else
            {
                //RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities();
                //rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                //results = rCGKENTCMS_PROD01Entities.CMSGetFullMatterOrderingClientDetails(mattIndex.ToString()).ToList();
            }

            return results.First();
        }

        public List<CMSGetFullMatterIncidentLocationsDetails_Result> GetFullMatterIncidentLocationDetails(int mattIndex, int sqlCommandTimeout, bool isDebug = false)
        {
            List<CMSGetFullMatterIncidentLocationsDetails_Result> results = null;

            if (isDebug)
            {
                RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities();
                rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                results = rCGKENTCMS_DEV01Entities.CMSGetFullMatterIncidentLocationsDetails(mattIndex.ToString()).ToList();
            }
            else
            {
                //RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities();
                //rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                //results = rCGKENTCMS_PROD01Entities.CMSGetFullMatterIncidentLocationsDetails(mattIndex.ToString()).ToList();
            }

            return results;
        }

        public List<CMSGetFullMatterCoConsultantDetails_Result> GetFullMatterCoConsultantDetails(int mattIndex, int sqlCommandTimeout, bool isDebug = false)
        {
            List<CMSGetFullMatterCoConsultantDetails_Result> results = null;

            if (isDebug)
            {
                RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities();
                rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                results = rCGKENTCMS_DEV01Entities.CMSGetFullMatterCoConsultantDetails(mattIndex.ToString()).ToList();
            }
            else
            {
                //RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities();
                //rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                //results = rCGKENTCMS_PROD01Entities.CMSGetFullMatterCoConsultantDetails(mattIndex.ToString()).ToList();
            }

            return results;
        }

        public List<CMSGetFullMatterPayorDetails_Result> GetFullMatterPayorDetails(int mattIndex, int sqlCommandTimeout, bool isDebug = false)
        {
            List<CMSGetFullMatterPayorDetails_Result> results = null;

            if (isDebug)
            {
                RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities();
                rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                results = rCGKENTCMS_DEV01Entities.CMSGetFullMatterPayorDetails(mattIndex.ToString()).ToList();
            }
            else
            {
                //RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities();
                //rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                //results = rCGKENTCMS_PROD01Entities.CMSGetFullMatterPayorDetails(mattIndex.ToString()).ToList();
            }

            return results;
        }

        public List<CMSGetFullMatterAdditionalPartiesDetails_Result> GetFullMatterAdditionalPartiesDetails(int mattIndex, int sqlCommandTimeout, bool isDebug = false)
        {
            List<CMSGetFullMatterAdditionalPartiesDetails_Result> results = null;

            if (isDebug)
            {
                RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities();
                rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                results = rCGKENTCMS_DEV01Entities.CMSGetFullMatterAdditionalPartiesDetails(mattIndex.ToString()).ToList();
            }
            else
            {
                //RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities();
                //rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                //results = rCGKENTCMS_PROD01Entities.CMSGetFullMatterAdditionalPartiesDetails(mattIndex.ToString()).ToList();
            }

            return results;
        }

        public List<CMSGetOfficeAndTpk_Result> GetCMSOfficeAndTpk(string county, int sqlCommandTimeout, bool isDebug = false)
        {
            List<CMSGetOfficeAndTpk_Result> results = null;

            if (isDebug)
            {
                RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities();
                rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                results = rCGKENTCMS_DEV01Entities.CMSGetOfficeAndTpk(county).ToList();
            }
            else
            {
                //RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities();
                //rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                //results = rCGKENTCMS_PROD01Entities.CMSGetOfficeAndTpk(county).ToList();
            }

            return results;
        }

        public List<CMSGetOfficeAndTpkByCounty_Result> GetCMSOfficeAndTpkByCounty(string county, int sqlCommandTimeout, bool isDebug = false)
        {
            List<CMSGetOfficeAndTpkByCounty_Result> results = null;

            if (isDebug)
            {
                RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities();
                rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                results = rCGKENTCMS_DEV01Entities.CMSGetOfficeAndTpkByCounty(county).ToList();
            }
            else
            {
                //RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities();
                //rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                //results = rCGKENTCMS_PROD01Entities.CMSGetOfficeAndTpkByCounty(county).ToList();
            }

            return results;
        }

        public List<CMSGetOfficeAndTpkByKeywords_Result> GetCMSOfficeAndTpkByKeywords(string keyPhrase, int sqlCommandTimeout, bool isDebug = false)
        {
            List<CMSGetOfficeAndTpkByKeywords_Result> results = null;

            if (isDebug)
            {
                RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities();
                rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                results = rCGKENTCMS_DEV01Entities.CMSGetOfficeAndTpkByKeywords(keyPhrase).ToList();
            }
            else
            {
                //RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities();
                //rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                //results = rCGKENTCMS_PROD01Entities.CMSGetOfficeAndTpkByKeywords(keyPhrase).ToList();
            }

            return results;
        }
        #endregion Rimkus Connect REST API

        #region helper functions

        private string GenerateCMSAPPKey()
        {
            string APIKey = "";

            using (var cryptoProvider = new RNGCryptoServiceProvider())
            {
                byte[] secretKeyByteArray = new byte[32]; //256 bit
                cryptoProvider.GetBytes(secretKeyByteArray);
                APIKey = Convert.ToBase64String(secretKeyByteArray);
            }

            return APIKey;
        }

        #endregion helper functions

        #endregion Kentico CMS Te3e

        #endregion
    }

    public class EditKeyValuePair
    {
        public string TableName { get; set; }
        public string LookupColumn { get; set; }
        public string ForeignKey { get; set; }
        public string RetColumn { get; set; }
    }

    public enum EditTableName
    {
        [Description("MattDate")]
        MattDate,

        [Description("MattSite")]
        MattSite,

        [Description("MattBudget")]
        MattBudget,

        [Description("MattFlatFee")]
        MattFlatFee,

        [Description("MattPayor")]
        MattPayor,

        [Description("MattPayorDet")]
        MattPayorDetail,

        [Description("RelatedParties_CCC")]
        RelatedParties_CCC,

        [Description("MatterSpecialInstructions_CCC")]
        MatterSpecialInstructions_CCC,

        [Description("TechRevEngRec_CCC")]
        TechRevEngRec_CCC,

        [Description("CoConsultants_CCC")]
        CoConsultants_CCC,

        [Description("MatterRateExc")]
        MatterRateExc,

        [Description("IndustryGroupMatter_CCC")]
        IndustryGroupMatter_CCC,

        [Description("MatterSpecialInvoiceTo_CCC")]
        MatterSpecialInvoiceTo_CCC,

        [Description("MattRate")]
        MattRate
    }

    public enum QueueType
    {
        [Description("INBOUND")]
        INBOUND,

        [Description("OUTBOUND")]
        OUTBOUND
    }

    public enum KenticoSubEntityRelEnum
    {
        IncidentLocation = 1,
        CoConsultants,
        AdditionalParties,
        Payors,
        ReferenceNumbers
    }

}