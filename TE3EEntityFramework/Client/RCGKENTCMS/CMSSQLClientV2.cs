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

    public class CMSSQLClientV2
    {
        public CMSSQLClientV2()
        {
        }

        #region Helper

        private System.Data.Entity.Infrastructure.DbRawSqlQuery<T> SqlScriptExecution<T>(string sqlStmt, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        {
            switch (env)
            {
                case EnvEnum.DEV:
                    {
                        RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities();
                        rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        return rCGKENTCMS_DEV01Entities.Database.SqlQuery<T>(sqlStmt);
                    }
                case EnvEnum.UAT:
                    {
                        RCGKENTCMS_UAT01Entities rCGKENTCMS_UAT01Entities = new RCGKENTCMS_UAT01Entities();
                        rCGKENTCMS_UAT01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        return rCGKENTCMS_UAT01Entities.Database.SqlQuery<T>(sqlStmt);
                    }
                case EnvEnum.STAGING:
                    {
                        RCGKENTCMS_STAGING01Entities rCGKENTCMS_STAGING01Entities = new RCGKENTCMS_STAGING01Entities();
                        rCGKENTCMS_STAGING01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        return rCGKENTCMS_STAGING01Entities.Database.SqlQuery<T>(sqlStmt);
                    }
                case EnvEnum.PROD:
                    {
                        RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities();
                        rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        return rCGKENTCMS_PROD01Entities.Database.SqlQuery<T>(sqlStmt);
                    }
                default:
                    {
                        RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities();
                        rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        return rCGKENTCMS_DEV01Entities.Database.SqlQuery<T>(sqlStmt);
                    }
            }
        }

        private void SqlScriptExecutionNoReturn(string sqlStmt, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        {
            switch (env)
            {
                case EnvEnum.DEV:
                    {
                        RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities();
                        rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        rCGKENTCMS_DEV01Entities.Database.ExecuteSqlCommand(sqlStmt);
                        break;
                    }
                case EnvEnum.UAT:
                    {
                        RCGKENTCMS_UAT01Entities rCGKENTCMS_UAT01Entities = new RCGKENTCMS_UAT01Entities();
                        rCGKENTCMS_UAT01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        rCGKENTCMS_UAT01Entities.Database.ExecuteSqlCommand(sqlStmt);
                        break;
                    }
                case EnvEnum.STAGING:
                    {
                        RCGKENTCMS_STAGING01Entities rCGKENTCMS_STAGING01Entities = new RCGKENTCMS_STAGING01Entities();
                        rCGKENTCMS_STAGING01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        rCGKENTCMS_STAGING01Entities.Database.ExecuteSqlCommand(sqlStmt);
                        break;
                    }
                case EnvEnum.PROD:
                    {
                        RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities();
                        rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        rCGKENTCMS_PROD01Entities.Database.ExecuteSqlCommand(sqlStmt);
                        break;
                    }
                default:
                    {
                        RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities();
                        rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        rCGKENTCMS_DEV01Entities.Database.ExecuteSqlCommand(sqlStmt);
                        break;
                    }
            }
        }

        private IQueryable<T> SqlDBEntity_Get<T>(int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV) where T : class
        {
            switch (env)
            {
                case EnvEnum.DEV:
                    {
                        RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities();
                        rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        return rCGKENTCMS_DEV01Entities.Set<T>().AsQueryable();
                    }
                case EnvEnum.UAT:
                    {
                        RCGKENTCMS_UAT01Entities rCGKENTCMS_UAT01Entities = new RCGKENTCMS_UAT01Entities();
                        rCGKENTCMS_UAT01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        return rCGKENTCMS_UAT01Entities.Set<T>().AsQueryable();
                    }
                case EnvEnum.STAGING:
                    {
                        RCGKENTCMS_STAGING01Entities rCGKENTCMS_STAGING01Entities = new RCGKENTCMS_STAGING01Entities();
                        rCGKENTCMS_STAGING01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        return rCGKENTCMS_STAGING01Entities.Set<T>().AsQueryable();
                    }
                case EnvEnum.PROD:
                    {
                        RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities();
                        rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        return rCGKENTCMS_PROD01Entities.Set<T>().AsQueryable();
                    }
                default:
                    {
                        RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities();
                        rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        return rCGKENTCMS_DEV01Entities.Set<T>().AsQueryable();
                    }
            }
        }
        #endregion

        #region Kentico CMS Te3e

        public CMSKenticoConfiguration GetCMSKenticoConfiguration(int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        {
            CMSKenticoConfiguration cMSKenticoConfiguration = SqlDBEntity_Get<CMSKenticoConfiguration>(sqlCommandTimeout, env).FirstOrDefault();

            return cMSKenticoConfiguration;
        }


        public CMSDynamics365Configuration GetDynamics365Configuration(int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        {
            CMSDynamics365Configuration cMSDynamicsConfiguration = SqlDBEntity_Get<CMSDynamics365Configuration>(sqlCommandTimeout, env).FirstOrDefault();

            return cMSDynamicsConfiguration;
        }
        #endregion


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

        public string GetEditKeyValue(EditTableName editTableName, string foreignKey, string server, string dbInstance, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
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

                var results = SqlScriptExecution<string>(sqlStmt, sqlCommandTimeout, env);
                editKeyVaue = results.Count() > 0 ? results.First() : null;
            }

            return editKeyVaue;
        }

        public int GetRefNumberID(string refType, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        {
            int cMSRefLookup = 0;
            var refLookups = SqlDBEntity_Get<CMSRefLookup>(sqlCommandTimeout, env).Where(x => x.RefType.ToLower() == refType.ToLower()).ToList();
            cMSRefLookup = refLookups.Count() > 0 ? refLookups.First().RefNumId : 0;
            return cMSRefLookup;
        }

        public CMSGetMatterCode_Result GetMatterCode(T3EMatterLookupType lookupType, string lookupValue, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        {
            CMSGetMatterCode_Result cMSGetMatterCode = null;
            var mlookupType = TE3EEntityExt.GetEnumDescription(lookupType);
            switch (env)
            {
                case EnvEnum.DEV:
                    {
                        RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities();
                        rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        var refLookups = rCGKENTCMS_DEV01Entities.CMSGetMatterCode(mlookupType, lookupValue).ToList();
                        cMSGetMatterCode = refLookups.Any() ? refLookups.First() : null;
                    }
                    break;
                case EnvEnum.UAT:
                    {
                        RCGKENTCMS_UAT01Entities rCGKENTCMS_UAT01Entities = new RCGKENTCMS_UAT01Entities();
                        rCGKENTCMS_UAT01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        var refLookups = rCGKENTCMS_UAT01Entities.CMSGetMatterCode(mlookupType, lookupValue).ToList();
                        cMSGetMatterCode = refLookups.Any() ? refLookups.First() : null;
                    }
                    break;
                case EnvEnum.STAGING:
                    {
                        RCGKENTCMS_STAGING01Entities rCGKENTCMS_STAGING01Entities = new RCGKENTCMS_STAGING01Entities();
                        rCGKENTCMS_STAGING01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        var refLookups = rCGKENTCMS_STAGING01Entities.CMSGetMatterCode(mlookupType, lookupValue).ToList();
                        cMSGetMatterCode = refLookups.Any() ? refLookups.First() : null;
                    }
                    break;
                case EnvEnum.PROD:
                    {
                        RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities();
                        rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        var refLookups = rCGKENTCMS_PROD01Entities.CMSGetMatterCode(mlookupType, lookupValue).ToList();
                        cMSGetMatterCode = refLookups.Any() ? refLookups.First() : null;
                    }
                    break;
                default:
                    break;
            }
            return cMSGetMatterCode;
        }


        public string GetRefType(int refNumberId, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        {
            string refType = "";
            var refLookups = SqlDBEntity_Get<CMSRefLookup>(sqlCommandTimeout, env).Where(x => x.RefNumId == refNumberId).ToList();
            refType = refLookups.Count() > 0 ? refLookups.First().RefType : "";
            return refType;
        }

        public string GetClientInstrID(string server, string dbInstance, string mattIndex, string clientInst, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        {
            string clientInstr = "";

            using (var objStreamReader = File.OpenText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $"datasource/rcgkentcms/datascripts/GetClientInstrID.sql")))
            {
                string sqlStmt = objStreamReader.ReadToEnd();

                sqlStmt = sqlStmt.Replace("@server", server);
                sqlStmt = sqlStmt.Replace("@instance", dbInstance);
                sqlStmt = sqlStmt.Replace("@mattIndex", mattIndex);
                sqlStmt = sqlStmt.Replace("@clientInst", clientInst.SQLSafe());

                var results = SqlScriptExecution<string>(sqlStmt, sqlCommandTimeout, env);
                clientInstr = results.Count() > 0 ? results.First() : null;
            }

            return clientInstr;
        }

        public string GetInvoiceToID(string server, string dbInstance, string mattIndex, string email, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        {
            string invoiceTo = "";

            using (var objStreamReader = File.OpenText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $"datasource/rcgkentcms/datascripts/GetInvoiceToID.sql")))
            {
                string sqlStmt = objStreamReader.ReadToEnd();

                sqlStmt = sqlStmt.Replace("@server", server);
                sqlStmt = sqlStmt.Replace("@instance", dbInstance);
                sqlStmt = sqlStmt.Replace("@mattIndex", mattIndex);
                sqlStmt = sqlStmt.Replace("@email", email.SQLSafe());

                var results = SqlScriptExecution<string>(sqlStmt, sqlCommandTimeout, env);
                invoiceTo = results.Count() > 0 ? results.First() : null;
            }

            return invoiceTo;
        }

        public ExistingMatterClient GetExistingMatterClient(string server, string dbInstance, string clientNumber, string mattIndex, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        {
            ExistingMatterClient existingMatterClient = new ExistingMatterClient();

            using (var objStreamReader = File.OpenText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $"datasource/sqlscripts/GetExistingMatterClient.sql")))
            {
                string sqlStmt = objStreamReader.ReadToEnd();

                sqlStmt = sqlStmt.Replace("@server", server);
                sqlStmt = sqlStmt.Replace("@instance", dbInstance);
                sqlStmt = sqlStmt.Replace("@clientNumber", clientNumber);
                sqlStmt = sqlStmt.Replace("@mattIndex", mattIndex);
                var results = SqlScriptExecution<ExistingMatterClient>(sqlStmt, sqlCommandTimeout, env);
                existingMatterClient = results.Count() > 0 ? results.First() : null;
            }
            return existingMatterClient;
        }

        public List<ExistingPayorContact> GetExistingPayorContactNameAndEmail(string server, string dbInstance, string contactName, string emailAddress, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        {
            List<ExistingPayorContact> existingPayorContacts = new List<ExistingPayorContact>();

            using (var objStreamReader = File.OpenText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $"datasource/rcgkentcms/datascripts/GetExistingPayorContactNameAndEmail.sql")))
            {
                string sqlStmt = objStreamReader.ReadToEnd();

                sqlStmt = sqlStmt.Replace("@server", server);
                sqlStmt = sqlStmt.Replace("@instance", dbInstance);
                sqlStmt = sqlStmt.Replace("@contactName", contactName.SQLSafe());
                sqlStmt = sqlStmt.Replace("@email", emailAddress.SQLSafe());
                existingPayorContacts = SqlScriptExecution<ExistingPayorContact>(sqlStmt, sqlCommandTimeout, env).ToList();
            }

            return existingPayorContacts;
        }

        public List<CMSCftWorkflowHistory> GetCftWorkflowHistory(string server, string dbInstance, int jobNumber, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        {
            List<CMSCftWorkflowHistory> cftWorkflowHistories = new List<CMSCftWorkflowHistory>();

            using (var objStreamReader = File.OpenText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $"datasource/rcgkentcms/datascripts/GetCftWorkflowHistory.sql")))
            {
                string sqlStmt = objStreamReader.ReadToEnd();

                sqlStmt = sqlStmt.Replace("@server", server);
                sqlStmt = sqlStmt.Replace("@instance", dbInstance);
                sqlStmt = sqlStmt.Replace("@jobNumber", jobNumber.ToString());

                cftWorkflowHistories = SqlScriptExecution<CMSCftWorkflowHistory>(sqlStmt, sqlCommandTimeout, env).ToList();
            }

            return cftWorkflowHistories;
        }

        public List<CMSCftSearchTransaction> GetCftSearchTransaction(string server, string dbInstance, string description, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        {
            List<CMSCftSearchTransaction> cftSearchTransactions = new List<CMSCftSearchTransaction>();

            using (var objStreamReader = File.OpenText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $"datasource/rcgkentcms/datascripts/GetCftSearchTransaction.sql")))
            {
                string sqlStmt = objStreamReader.ReadToEnd();

                sqlStmt = sqlStmt.Replace("@server", server);
                sqlStmt = sqlStmt.Replace("@instance", dbInstance);
                sqlStmt = sqlStmt.Replace("@description", description.SQLSafe());

                cftSearchTransactions = SqlScriptExecution<CMSCftSearchTransaction>(sqlStmt, sqlCommandTimeout, env).ToList();
            }

            return cftSearchTransactions;
        }

        [Obsolete]
        public List<ExistingEntity> GetExistingEntityByNameAndEmailObsolete(string server, string dbInstance, EntityArchetypeCode archetypeCode, string displayName, string emailAddress, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        {
            List<ExistingEntity> existingEntities = new List<ExistingEntity>();

            using (var objStreamReader = File.OpenText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $"datasource/sqlscripts/GetExistingEntityByNameAndEmail.sql")))
            {
                string sqlStmt = objStreamReader.ReadToEnd();

                string emailCondition = "";

                if (archetypeCode == EntityArchetypeCode.EntityPerson)
                {
                    emailCondition = $"= '{emailAddress.SQLSafe()}'";
                }
                else
                {
                    try
                    {
                        MailAddress address = new MailAddress(emailAddress.SQLSafe());
                        emailCondition = $"like '%{address.Host}%'";
                    }
                    catch { emailCondition = $"= '{emailAddress.SQLSafe()}'"; }
                }

                sqlStmt = sqlStmt.Replace("@server", server);
                sqlStmt = sqlStmt.Replace("@instance", dbInstance);
                //sqlStmt = sqlStmt.Replace("@archetypeCode", TE3EEntityExt.GetEnumDescription(archetypeCode));
                sqlStmt = sqlStmt.Replace("@displayName", displayName.SQLSafe());
                sqlStmt = sqlStmt.Replace("@emailCondition", emailCondition);

                existingEntities = SqlScriptExecution<ExistingEntity>(sqlStmt, sqlCommandTimeout, env).ToList();
            }

            return existingEntities;
        }

        public List<ExistingEntity> GetExistingEntityPersonByNameAndEmail(string server, string dbInstance, string firstName, string lastName, string emailAddress, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        {
            List<ExistingEntity> existingEntities = new List<ExistingEntity>();

            using (var objStreamReader = File.OpenText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $"datasource/sqlscripts/GetExistingEntityPersonByNameAndEmail.sql")))
            {
                string sqlStmt = objStreamReader.ReadToEnd();
                string emailCondition = $"= '{emailAddress}'";

                sqlStmt = sqlStmt.Replace("@server", server);
                sqlStmt = sqlStmt.Replace("@instance", dbInstance);
                sqlStmt = sqlStmt.Replace("@firstName", string.IsNullOrEmpty(@firstName) ? "''" : $"'{@firstName.SQLSafe()}'");
                //sqlStmt = sqlStmt.Replace("@middleName", string.IsNullOrEmpty(@middleName) ? "''" : $"'{@middleName.SQLSafe()}'");
                sqlStmt = sqlStmt.Replace("@lastName", string.IsNullOrEmpty(@lastName) ? "''" : $"'{@lastName.SQLSafe()}'");

                if (string.IsNullOrEmpty(emailAddress))
                {
                    sqlStmt = sqlStmt.Replace("@lookupEmail", "");
                }
                else
                {
                    sqlStmt = sqlStmt.Replace("@lookupEmail", "and se.EmailAddr @emailCondition");
                    sqlStmt = sqlStmt.Replace("@emailCondition", emailCondition);
                }

                existingEntities = SqlScriptExecution<ExistingEntity>(sqlStmt, sqlCommandTimeout, env).ToList();
            }

            return existingEntities;
        }

        public List<ExistingEntity> GetExistingEntityOrgByNameAndEmail(string server, string dbInstance, string displayName, string emailAddress, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        {
            List<ExistingEntity> existingEntities = new List<ExistingEntity>();

            using (var objStreamReader = File.OpenText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $"datasource/sqlscripts/GetExistingEntityOrgByNameAndEmail.sql")))
            {
                string sqlStmt = objStreamReader.ReadToEnd();
                string emailCondition = "";

                try
                {
                    MailAddress address = new MailAddress(emailAddress.SQLSafe());
                    emailCondition = $"like '%{address.Host}%'";
                }
                catch { emailCondition = $"= '{emailAddress.SQLSafe()}'"; }

                if (string.IsNullOrEmpty(emailAddress.SQLSafe()))
                {
                    sqlStmt = sqlStmt.Replace("@lookupEmail", "");
                }
                else
                {
                    sqlStmt = sqlStmt.Replace("@lookupEmail", "and se.EmailAddr @emailCondition");
                    sqlStmt = sqlStmt.Replace("@emailCondition", emailCondition);
                }


                sqlStmt = sqlStmt.Replace("@server", server);
                sqlStmt = sqlStmt.Replace("@instance", dbInstance);
                //sqlStmt = sqlStmt.Replace("@archetypeCode", TE3EEntityExt.GetEnumDescription(archetypeCode));
                sqlStmt = sqlStmt.Replace("@displayName", displayName.SQLSafe());
                sqlStmt = sqlStmt.Replace("@emailCondition", emailCondition);

                existingEntities = SqlScriptExecution<ExistingEntity>(sqlStmt, sqlCommandTimeout, env).ToList();
            }

            return existingEntities;
        }

        public List<ExistingClient> GetExistingClientByNameAndEmail(string server, string dbInstance, string displayName, string emailAddress, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        {
            List<ExistingClient> existingClients = new List<ExistingClient>();

            using (var objStreamReader = File.OpenText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $"datasource/sqlscripts/GetExistingClientByNameAndEmail.sql")))
            {
                string sqlStmt = objStreamReader.ReadToEnd();

                MailAddress address = new MailAddress(emailAddress);
                string emailDomain = address.Host;

                sqlStmt = sqlStmt.Replace("@server", server);
                sqlStmt = sqlStmt.Replace("@instance", dbInstance);
                sqlStmt = sqlStmt.Replace("@displayName", displayName.SQLSafe());
                sqlStmt = sqlStmt.Replace("@email", emailDomain);

                existingClients = SqlScriptExecution<ExistingClient>(sqlStmt, sqlCommandTimeout, env).ToList();
            }

            return existingClients;
        }

        public ExistingEntity GetExistingEntity(string server, string dbInstance, EntityArchetypeCode archetypeCode, string displayName, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        {
            ExistingEntity existingEntity = new ExistingEntity();

            using (var objStreamReader = File.OpenText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $"datasource/sqlscripts/GetExistingEntity.sql")))
            {
                string sqlStmt = objStreamReader.ReadToEnd();

                sqlStmt = sqlStmt.Replace("@server", server);
                sqlStmt = sqlStmt.Replace("@instance", dbInstance);
                sqlStmt = sqlStmt.Replace("@archetypeCode", TE3EEntityExt.GetEnumDescription(archetypeCode));
                sqlStmt = sqlStmt.Replace("@displayName", displayName.SQLSafe());

                var results = SqlScriptExecution<ExistingEntity>(sqlStmt, sqlCommandTimeout, env);
                existingEntity = results.Count() > 0 ? results.First() : null;
            }

            return existingEntity;
        }

        public ExistingClient GetExistingClient(string server, string dbInstance, CMSJob cmsJob, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        {
            return GetExistingClient(server, dbInstance, cmsJob.orderingClient.CompanyName, cmsJob.orderingClient.ClientNumber, sqlCommandTimeout, env);
        }

        public ExistingClient GetExistingClient(string server, string dbInstance, string ClientName, string ClientNumber, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        {
            ExistingClient existingClient = new ExistingClient();

            using (var objStreamReader = File.OpenText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $"datasource/sqlscripts/GetExistingClient.sql")))
            {
                string sqlStmt = objStreamReader.ReadToEnd();

                sqlStmt = sqlStmt.Replace("@server", server);
                sqlStmt = sqlStmt.Replace("@instance", dbInstance);
                sqlStmt = sqlStmt.Replace("@clientName", ClientName.SQLSafe());
                sqlStmt = sqlStmt.Replace("@clientNumber", ClientNumber);

                var results = SqlScriptExecution<ExistingClient>(sqlStmt, sqlCommandTimeout, env);
                existingClient = results.Count() > 0 ? results.First() : null;
            }

            return existingClient;
        }
        public ExistingPayorClient GetExistingPayorClient(string server, string dbInstance, int payorIndex, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        {
            ExistingPayorClient existingClient = new ExistingPayorClient();

            using (var objStreamReader = File.OpenText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $"datasource/sqlscripts/GetExistingPayorClient.sql")))
            {
                string sqlStmt = objStreamReader.ReadToEnd();

                sqlStmt = sqlStmt.Replace("@server", server);
                sqlStmt = sqlStmt.Replace("@instance", dbInstance);
                sqlStmt = sqlStmt.Replace("@payorIndex", payorIndex.ToString());

                var results = SqlScriptExecution<ExistingPayorClient>(sqlStmt, sqlCommandTimeout, env);
                existingClient = results.Count() > 0 ? results.First() : null;
            }

            return existingClient;
        }

        public ExistingMatter GetExistingMatter(string server, string dbInstance, int mattIndex, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        {
            ExistingMatter existingMatter = new ExistingMatter();

            if (mattIndex == 0)
            {
                return null;
            }

            using (var objStreamReader = File.OpenText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $"datasource/sqlscripts/GetExistingMatter.sql")))
            {
                string sqlStmt = objStreamReader.ReadToEnd();

                sqlStmt = sqlStmt.Replace("@server", server);
                sqlStmt = sqlStmt.Replace("@instance", dbInstance);
                sqlStmt = sqlStmt.Replace("@mattIndex", mattIndex.ToString());

                var results = SqlScriptExecution<ExistingMatter>(sqlStmt, sqlCommandTimeout, env);
                existingMatter = results.Count() > 0 ? results.First() : null;
            }

            return existingMatter;
        }

        public List<TE3ERoles> GetCftRoles(string server, string dbInstance, TE3ERoleType tE3ERoleType, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        {
            List<TE3ERoles> tE3ERoles = new List<TE3ERoles>();

            var scriptFile = tE3ERoleType == TE3ERoleType.AdditionalParties ? "GetAdditionalPartiesRoles" : "GetMatterPayorDetailRoles";
            using (var objStreamReader = File.OpenText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $"datasource/sqlscripts/{scriptFile}.sql")))
            {
                string sqlStmt = objStreamReader.ReadToEnd();

                sqlStmt = sqlStmt.Replace("@server", server);
                sqlStmt = sqlStmt.Replace("@instance", dbInstance);

                tE3ERoles = SqlScriptExecution<TE3ERoles>(sqlStmt, sqlCommandTimeout, env).ToList();
            }

            return tE3ERoles;
        }

        public MattRateGrpExc GetMattRateGrpExc(string server, string dbInstance, string mattRateGrpExcDesc, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        {
            MattRateGrpExc mattRateGrpExc = new MattRateGrpExc();

            using (var objStreamReader = File.OpenText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $"datasource/sqlscripts/GetMattRateGroupExc.sql")))
            {
                string sqlStmt = objStreamReader.ReadToEnd();

                sqlStmt = sqlStmt.Replace("@server", server);
                sqlStmt = sqlStmt.Replace("@instance", dbInstance);
                sqlStmt = sqlStmt.Replace("@mattRateGrpExc", mattRateGrpExcDesc);

                var results = SqlScriptExecution<MattRateGrpExc>(sqlStmt, sqlCommandTimeout, env).ToList();
                mattRateGrpExc = results.Count() > 0 ? results.First() : null;
            }

            return mattRateGrpExc;
        }

        public string GetDefaultSubSection(string server, string dbInstance, string section, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        {
            string subSection = string.Empty;

            using (var objStreamReader = File.OpenText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $"datasource/sqlscripts/GetDefaultSubSection.sql")))
            {
                string sqlStmt = objStreamReader.ReadToEnd();

                sqlStmt = sqlStmt.Replace("@server", server);
                sqlStmt = sqlStmt.Replace("@instance", dbInstance);
                sqlStmt = sqlStmt.Replace("@section", section);

                var results = SqlScriptExecution<string>(sqlStmt, sqlCommandTimeout, env).ToList();
                subSection = results.Count() > 0 ? results.First() : null;
            }

            return subSection;
        }
        public List<EntityProcessItem> GetEntityOrgAndPersonProcessItems(string server, string dbInstance, string entityPersonPId, string entityOrgPId, string companyName, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        {

            #region Process Id Operations

            string EntityPersonPId = null, EntityPersonEIndex = null, EntityOrgPId = null, EntityOrgEIndex = null;

            if (entityPersonPId != null)
            {
                var EntityPersonProcessIds = entityPersonPId.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Distinct();
                EntityPersonPId = $"{string.Join("','", EntityPersonProcessIds.Where(x => Guid.TryParse(x, out _)))}";
                EntityPersonEIndex = $"{string.Join(",", EntityPersonProcessIds.Where(x => int.TryParse(x, out _)))}";
            }

            if (entityPersonPId != null)
            {
                var EntityOrgProcessIds = entityOrgPId.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Distinct();
                EntityOrgPId = $"{string.Join("','", EntityOrgProcessIds.Where(x => Guid.TryParse(x, out _)))}";
                EntityOrgEIndex = $"{string.Join(",", EntityOrgProcessIds.Where(x => int.TryParse(x, out _)))}";
            }

            EntityPersonPId = string.IsNullOrEmpty(EntityPersonPId) ? "''" : $"'{EntityPersonPId}'";
            EntityOrgPId = string.IsNullOrEmpty(EntityOrgPId) ? "''" : $"'{EntityOrgPId}'";

            EntityPersonEIndex = string.IsNullOrEmpty(EntityPersonEIndex) ? "0" : $"{EntityPersonEIndex}";
            EntityOrgEIndex = string.IsNullOrEmpty(EntityOrgEIndex) ? "0" : $"{EntityOrgEIndex}";

            #endregion

            List<EntityProcessItem> entityProcessItems = new List<EntityProcessItem>();

            using (var objStreamReader = File.OpenText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $"datasource/sqlscripts/GetProcessItemEntity.sql")))
            {
                string sqlStmt = objStreamReader.ReadToEnd();

                sqlStmt = sqlStmt.Replace("@server", server);
                sqlStmt = sqlStmt.Replace("@instance", dbInstance);
                sqlStmt = sqlStmt.Replace("@personProcessItemId", EntityPersonPId);
                sqlStmt = sqlStmt.Replace("@orgProcessItemId", EntityOrgPId);
                sqlStmt = sqlStmt.Replace("@personEntityIndex", EntityPersonEIndex);
                sqlStmt = sqlStmt.Replace("@orgEntityIndex", EntityOrgEIndex);
                sqlStmt = sqlStmt.Replace("@companyName", $"'{companyName.SQLSafe()}'");

                entityProcessItems = SqlScriptExecution<EntityProcessItem>(sqlStmt, sqlCommandTimeout, env).ToList();
            }

            return entityProcessItems;
        }

        public List<EntityProcessItem> GetEntityByName(string server, string dbInstance, string companyName, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        {
            List<EntityProcessItem> entityProcessItems = new List<EntityProcessItem>();

            using (var objStreamReader = File.OpenText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $"datasource/sqlscripts/GetEntityByName.sql")))
            {
                string sqlStmt = objStreamReader.ReadToEnd();

                sqlStmt = sqlStmt.Replace("@server", server);
                sqlStmt = sqlStmt.Replace("@instance", dbInstance);
                sqlStmt = sqlStmt.Replace("@companyName", $"'{@companyName.SQLSafe()}'");

                entityProcessItems = SqlScriptExecution<EntityProcessItem>(sqlStmt, sqlCommandTimeout, env).ToList();
            }

            return entityProcessItems;
        }

        public List<ClientProcessItem> GetClientAndPayorIndexProcessItems(string server, string dbInstance, string clientNum, string clientPId, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        {
            List<ClientProcessItem> clientProcessItems = new List<ClientProcessItem>();

            using (var objStreamReader = File.OpenText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $"datasource/sqlscripts/GetProcessItemClient.sql")))
            {
                string sqlStmt = objStreamReader.ReadToEnd();

                sqlStmt = sqlStmt.Replace("@server", server);
                sqlStmt = sqlStmt.Replace("@instance", dbInstance);
                sqlStmt = sqlStmt.Replace("@clientProcessItemId", clientPId);
                sqlStmt = sqlStmt.Replace("@clientNum", $"'{clientNum}'");

                clientProcessItems = SqlScriptExecution<ClientProcessItem>(sqlStmt, sqlCommandTimeout, env).ToList();
            }

            return clientProcessItems;
        }

        public MatterProcessItem GetMatterProcessItem(string server, string dbInstance, string matterPId, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        {
            MatterProcessItem matterProcessItem = new MatterProcessItem();

            using (var objStreamReader = File.OpenText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $"datasource/sqlscripts/GetProcessItemMatter.sql")))
            {
                string sqlStmt = objStreamReader.ReadToEnd();

                sqlStmt = sqlStmt.Replace("@server", server);
                sqlStmt = sqlStmt.Replace("@instance", dbInstance);
                sqlStmt = sqlStmt.Replace("@matterProcessItemId", matterPId);

                var results = SqlScriptExecution<MatterProcessItem>(sqlStmt, sqlCommandTimeout, env);
                matterProcessItem = results.Count() > 0 ? results.First() : null;
            }

            return matterProcessItem;
        }

        public ExistingEntity GetExistingEntityByEntIndex(string server, string dbInstance, int entityID, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        {
            ExistingEntity existingEntity = new ExistingEntity();

            using (var objStreamReader = File.OpenText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $"datasource/sqlscripts/GetExistingEntityByEntIndex.sql")))
            {
                string sqlStmt = objStreamReader.ReadToEnd();

                sqlStmt = sqlStmt.Replace("@server", server);
                sqlStmt = sqlStmt.Replace("@instance", dbInstance);
                sqlStmt = sqlStmt.Replace("@entityID", entityID.ToString());

                var results = SqlScriptExecution<ExistingEntity>(sqlStmt, sqlCommandTimeout, env);
                existingEntity = results.Count() > 0 ? results.First() : null;
            }

            return existingEntity;
        }

        public List<EntityAddress> GetEntityAddressesByEntIndex(string server, string dbInstance, int entityID, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        {
            List<EntityAddress> entityAddresses = new List<EntityAddress>();

            using (var objStreamReader = File.OpenText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $"datasource/sqlscripts/GetEntityAddressesByEntIndex.sql")))
            {
                string sqlStmt = objStreamReader.ReadToEnd();

                sqlStmt = sqlStmt.Replace("@server", server);
                sqlStmt = sqlStmt.Replace("@instance", dbInstance);
                sqlStmt = sqlStmt.Replace("@entityID", entityID.ToString());

                var results = SqlScriptExecution<EntityAddress>(sqlStmt, sqlCommandTimeout, env);
                entityAddresses = results.ToList();
            }

            return entityAddresses;
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

        public CMSGetCliTypeFromCftRole_Result GetCliTypeFromCftRole(int cftRole, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        {
            CMSGetCliTypeFromCftRole_Result cftRole_Result = new CMSGetCliTypeFromCftRole_Result();

            switch (env)
            {
                case EnvEnum.DEV:
                    {
                        RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities();
                        rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        var results = rCGKENTCMS_DEV01Entities.CMSGetCliTypeFromCftRole(cftRole).ToList();
                        cftRole_Result = results.Count() > 0 ? results.First() : null;
                    }
                    break;
                case EnvEnum.UAT:
                    {
                        RCGKENTCMS_UAT01Entities rCGKENTCMS_UAT01Entities = new RCGKENTCMS_UAT01Entities();
                        rCGKENTCMS_UAT01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        var results = rCGKENTCMS_UAT01Entities.CMSGetCliTypeFromCftRole(cftRole).ToList();
                        cftRole_Result = results.Count() > 0 ? results.First() : null;
                    }
                    break;
                case EnvEnum.STAGING:
                    {
                        RCGKENTCMS_STAGING01Entities rCGKENTCMS_STAGING01Entities = new RCGKENTCMS_STAGING01Entities();
                        rCGKENTCMS_STAGING01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        var results = rCGKENTCMS_STAGING01Entities.CMSGetCliTypeFromCftRole(cftRole).ToList();
                        cftRole_Result = results.Count() > 0 ? results.First() : null;
                    }
                    break;
                case EnvEnum.PROD:
                    {
                        RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities();
                        rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        var results = rCGKENTCMS_PROD01Entities.CMSGetCliTypeFromCftRole(cftRole).ToList();
                        cftRole_Result = results.Count() > 0 ? results.First() : null;
                    }
                    break;
                default:
                    break;
            }
            return cftRole_Result;
        }

        public List<CMSGetLookupCodes_Result> GetOfficeCodes(int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        {
            List<CMSGetLookupCodes_Result> officeCodes = new List<CMSGetLookupCodes_Result>();

            switch (env)
            {
                case EnvEnum.DEV:
                    {
                        RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities();
                        rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        officeCodes = rCGKENTCMS_DEV01Entities.CMSGetLookupCodes("Office").ToList();
                    }
                    break;
                case EnvEnum.UAT:
                    {
                        RCGKENTCMS_UAT01Entities rCGKENTCMS_UAT01Entities = new RCGKENTCMS_UAT01Entities();
                        rCGKENTCMS_UAT01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        officeCodes = rCGKENTCMS_UAT01Entities.CMSGetLookupCodes("Office").ToList();
                    }
                    break;
                case EnvEnum.STAGING:
                    {
                        RCGKENTCMS_STAGING01Entities rCGKENTCMS_STAGING01Entities = new RCGKENTCMS_STAGING01Entities();
                        rCGKENTCMS_STAGING01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        officeCodes = rCGKENTCMS_STAGING01Entities.CMSGetLookupCodes("Office").ToList();
                    }
                    break;
                case EnvEnum.PROD:
                    {
                        RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities();
                        rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        officeCodes = rCGKENTCMS_PROD01Entities.CMSGetLookupCodes("Office").ToList();
                    }
                    break;
                default:
                    break;
            }

            return officeCodes;
        }

        public List<CMSKeyVault> AddNewClientCMSKey(string clientName, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        {
            List<CMSKeyVault> results = null;

            string appId = Guid.NewGuid().ToString().ToUpper();
            var appKey = GenerateCMSAPPKey();
            var sqlStmt = $@"INSERT INTO [dbo].[CMSKeyVaults]
                                                                               ([AppId]
                                                                               ,[AppKey]
                                                                               ,[ClientName]
                                                                               ,[CreatedOn])
                                                                         VALUES
                                                                               ('{appId}'
                                                                               ,'{appKey}'
                                                                               ,'{clientName}'
                                                                               ,'{DateTime.Now}')";
            SqlScriptExecutionNoReturn(sqlStmt, sqlCommandTimeout, env);
            results = SqlDBEntity_Get<CMSKeyVault>(sqlCommandTimeout, env).ToList();
            return results;
        }

        public List<CMSKeyVault> GetCMSKeyVaults(int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        {
            List<CMSKeyVault> results = null;
            results = SqlDBEntity_Get<CMSKeyVault>(sqlCommandTimeout, env).ToList();

            return results;
        }

        #region assignment data access methods

        public void AddAssignment(CMSJob cMSJob, QueueType queueType, bool dontDuplicate, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
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

            switch (env)
            {
                case EnvEnum.DEV:
                    {
                        using (RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities())
                        {
                            using (DbContextTransaction transaction = rCGKENTCMS_DEV01Entities.Database.BeginTransaction())
                            {
                                try
                                {
                                    rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                                    if (dontDuplicate)
                                    {
                                        var existing = rCGKENTCMS_DEV01Entities.CMSAssignments.FirstOrDefault(x => x.KenticoID.Equals(cMSJob.assignment.KenticoID) && (x.QueueType.ToUpper() == queueTypeDesc.ToUpper()));

                                        if (existing != null)
                                        {
                                            return;
                                        }
                                    }


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

                                    rCGKENTCMS_DEV01Entities.SaveChanges();
                                    transaction.Commit();
                                    return;
                                }
                                catch (Exception ex)
                                {
                                    transaction.Rollback();
                                    throw ex;
                                }
                            }
                        }
                    }
                case EnvEnum.UAT:
                    {
                        using (RCGKENTCMS_UAT01Entities rCGKENTCMS_UAT01Entities = new RCGKENTCMS_UAT01Entities())
                        {
                            using (DbContextTransaction transaction = rCGKENTCMS_UAT01Entities.Database.BeginTransaction())
                            {
                                try
                                {
                                    rCGKENTCMS_UAT01Entities.Database.CommandTimeout = sqlCommandTimeout;

                                    if (dontDuplicate)
                                    {
                                        var existing = rCGKENTCMS_UAT01Entities.CMSAssignments.FirstOrDefault(x => x.KenticoID.Equals(cMSJob.assignment.KenticoID) && (x.QueueType.ToUpper() == queueTypeDesc.ToUpper()));

                                        if (existing != null)
                                        {
                                            return;
                                        }
                                    }
                                    rCGKENTCMS_UAT01Entities.CMSAssignments.Add(cMSJob.assignment);

                                    if (cMSJob.orderingClient != null)
                                        rCGKENTCMS_UAT01Entities.CMSOrderingClients.Add(cMSJob.orderingClient);

                                    if (cMSJob.coConsultants.Count() > 0)
                                        rCGKENTCMS_UAT01Entities.CMSCoConsultants.AddRange(cMSJob.coConsultants);

                                    if (cMSJob.incidentLocations.Count() > 0)
                                        rCGKENTCMS_UAT01Entities.CMSIncidentLocations.AddRange(cMSJob.incidentLocations);

                                    if (cMSJob.payorDetails.Count() > 0)
                                        rCGKENTCMS_UAT01Entities.CMSPayorDetails.AddRange(cMSJob.payorDetails);

                                    if (cMSJob.additionalParties.Count() > 0)
                                        rCGKENTCMS_UAT01Entities.CMSAdditionalParties.AddRange(cMSJob.additionalParties);


                                    rCGKENTCMS_UAT01Entities.SaveChanges();
                                    transaction.Commit();
                                    return;
                                }
                                catch (Exception ex)
                                {
                                    transaction.Rollback();
                                    throw ex;
                                }
                            }
                        }
                    }
                case EnvEnum.STAGING:
                    {
                        using (RCGKENTCMS_STAGING01Entities rCGKENTCMS_STAGING01Entities = new RCGKENTCMS_STAGING01Entities())
                        {
                            using (DbContextTransaction transaction = rCGKENTCMS_STAGING01Entities.Database.BeginTransaction())
                            {
                                try
                                {
                                    rCGKENTCMS_STAGING01Entities.Database.CommandTimeout = sqlCommandTimeout;

                                    if (dontDuplicate)
                                    {
                                        var existing = rCGKENTCMS_STAGING01Entities.CMSAssignments.FirstOrDefault(x => x.KenticoID.Equals(cMSJob.assignment.KenticoID) && (x.QueueType.ToUpper() == queueTypeDesc.ToUpper()));

                                        if (existing != null)
                                        {
                                            return;
                                        }
                                    }
                                    rCGKENTCMS_STAGING01Entities.CMSAssignments.Add(cMSJob.assignment);

                                    if (cMSJob.orderingClient != null)
                                        rCGKENTCMS_STAGING01Entities.CMSOrderingClients.Add(cMSJob.orderingClient);

                                    if (cMSJob.coConsultants.Count() > 0)
                                        rCGKENTCMS_STAGING01Entities.CMSCoConsultants.AddRange(cMSJob.coConsultants);

                                    if (cMSJob.incidentLocations.Count() > 0)
                                        rCGKENTCMS_STAGING01Entities.CMSIncidentLocations.AddRange(cMSJob.incidentLocations);

                                    if (cMSJob.payorDetails.Count() > 0)
                                        rCGKENTCMS_STAGING01Entities.CMSPayorDetails.AddRange(cMSJob.payorDetails);

                                    if (cMSJob.additionalParties.Count() > 0)
                                        rCGKENTCMS_STAGING01Entities.CMSAdditionalParties.AddRange(cMSJob.additionalParties);


                                    rCGKENTCMS_STAGING01Entities.SaveChanges();
                                    transaction.Commit();
                                    return;
                                }
                                catch (Exception ex)
                                {
                                    transaction.Rollback();
                                    throw ex;
                                }
                            }
                        }
                    }
                case EnvEnum.PROD:
                    {
                        using (RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities())
                        {
                            using (DbContextTransaction transaction = rCGKENTCMS_PROD01Entities.Database.BeginTransaction())
                            {
                                try
                                {
                                    rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;

                                    if (dontDuplicate)
                                    {
                                        var existing = rCGKENTCMS_PROD01Entities.CMSAssignments.FirstOrDefault(x => x.KenticoID.Equals(cMSJob.assignment.KenticoID) && (x.QueueType.ToUpper() == queueTypeDesc.ToUpper()));

                                        if (existing != null)
                                        {
                                            return;
                                        }
                                    }
                                    rCGKENTCMS_PROD01Entities.CMSAssignments.Add(cMSJob.assignment);

                                    if (cMSJob.orderingClient != null)
                                        rCGKENTCMS_PROD01Entities.CMSOrderingClients.Add(cMSJob.orderingClient);

                                    if (cMSJob.coConsultants.Count() > 0)
                                        rCGKENTCMS_PROD01Entities.CMSCoConsultants.AddRange(cMSJob.coConsultants);

                                    if (cMSJob.incidentLocations.Count() > 0)
                                        rCGKENTCMS_PROD01Entities.CMSIncidentLocations.AddRange(cMSJob.incidentLocations);

                                    if (cMSJob.payorDetails.Count() > 0)
                                        rCGKENTCMS_PROD01Entities.CMSPayorDetails.AddRange(cMSJob.payorDetails);

                                    if (cMSJob.additionalParties.Count() > 0)
                                        rCGKENTCMS_PROD01Entities.CMSAdditionalParties.AddRange(cMSJob.additionalParties);


                                    rCGKENTCMS_PROD01Entities.SaveChanges();
                                    transaction.Commit();
                                    return;
                                }
                                catch (Exception ex)
                                {
                                    transaction.Rollback();
                                    throw ex;
                                }
                            }
                        }
                    }
                default:
                    return;
            }
        }

        public void RemoveAssignment(CMSJob cMSJob, QueueType queueType, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        {
            string queueTypeDesc = TE3EEntityExt.GetEnumDescription(queueType);

            switch (env)
            {
                case EnvEnum.DEV:
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
                    break;
                case EnvEnum.UAT:
                    {
                        using (RCGKENTCMS_UAT01Entities rCGKENTCMS_UAT01Entities = new RCGKENTCMS_UAT01Entities())
                        {
                            using (DbContextTransaction transaction = rCGKENTCMS_UAT01Entities.Database.BeginTransaction())
                            {
                                rCGKENTCMS_UAT01Entities.Database.CommandTimeout = sqlCommandTimeout;

                                var deletedInAssgnmnts = rCGKENTCMS_UAT01Entities.CMSAssignments.Where(k => (k.E3EID == cMSJob.assignment.E3EID) && (k.QueueType.ToUpper() == queueTypeDesc));

                                if (deletedInAssgnmnts.Count() > 0)
                                    rCGKENTCMS_UAT01Entities.CMSAssignments.RemoveRange(deletedInAssgnmnts);

                                var deletedInOrderingClients = rCGKENTCMS_UAT01Entities.CMSOrderingClients.Where(k => (k.E3EID == cMSJob.assignment.E3EID) && (k.QueueType.ToUpper() == queueTypeDesc));

                                if (deletedInOrderingClients.Count() > 0)
                                    rCGKENTCMS_UAT01Entities.CMSOrderingClients.RemoveRange(deletedInOrderingClients);

                                var deletedInCoConslts = rCGKENTCMS_UAT01Entities.CMSCoConsultants.Where(k => (k.E3EID == cMSJob.assignment.E3EID) && (k.QueueType.ToUpper() == queueTypeDesc));

                                if (deletedInCoConslts.Count() > 0)
                                    rCGKENTCMS_UAT01Entities.CMSCoConsultants.RemoveRange(deletedInCoConslts);

                                var deletedInAddtnlParties = rCGKENTCMS_UAT01Entities.CMSAdditionalParties.Where(k => (k.E3EID == cMSJob.assignment.E3EID) && (k.QueueType.ToUpper() == queueTypeDesc));

                                if (deletedInAddtnlParties.Count() > 0)
                                    rCGKENTCMS_UAT01Entities.CMSAdditionalParties.RemoveRange(deletedInAddtnlParties);

                                var deletedInPayDets = rCGKENTCMS_UAT01Entities.CMSPayorDetails.Where(k => (k.E3EID == cMSJob.assignment.E3EID) && (k.QueueType.ToUpper() == queueTypeDesc));

                                if (deletedInPayDets.Count() > 0)
                                    rCGKENTCMS_UAT01Entities.CMSPayorDetails.RemoveRange(deletedInPayDets);

                                var deletedInIncLocs = rCGKENTCMS_UAT01Entities.CMSIncidentLocations.Where(k => (k.E3EID == cMSJob.assignment.E3EID) && (k.QueueType.ToUpper() == queueTypeDesc));

                                if (deletedInIncLocs.Count() > 0)
                                    rCGKENTCMS_UAT01Entities.CMSIncidentLocations.RemoveRange(deletedInIncLocs);

                                rCGKENTCMS_UAT01Entities.SaveChanges();
                            }
                        }
                    }
                    break;
                case EnvEnum.STAGING:
                    {
                        using (RCGKENTCMS_STAGING01Entities rCGKENTCMS_STAGING01Entities = new RCGKENTCMS_STAGING01Entities())
                        {
                            using (DbContextTransaction transaction = rCGKENTCMS_STAGING01Entities.Database.BeginTransaction())
                            {
                                rCGKENTCMS_STAGING01Entities.Database.CommandTimeout = sqlCommandTimeout;

                                var deletedInAssgnmnts = rCGKENTCMS_STAGING01Entities.CMSAssignments.Where(k => (k.E3EID == cMSJob.assignment.E3EID) && (k.QueueType.ToUpper() == queueTypeDesc));

                                if (deletedInAssgnmnts.Count() > 0)
                                    rCGKENTCMS_STAGING01Entities.CMSAssignments.RemoveRange(deletedInAssgnmnts);

                                var deletedInOrderingClients = rCGKENTCMS_STAGING01Entities.CMSOrderingClients.Where(k => (k.E3EID == cMSJob.assignment.E3EID) && (k.QueueType.ToUpper() == queueTypeDesc));

                                if (deletedInOrderingClients.Count() > 0)
                                    rCGKENTCMS_STAGING01Entities.CMSOrderingClients.RemoveRange(deletedInOrderingClients);

                                var deletedInCoConslts = rCGKENTCMS_STAGING01Entities.CMSCoConsultants.Where(k => (k.E3EID == cMSJob.assignment.E3EID) && (k.QueueType.ToUpper() == queueTypeDesc));

                                if (deletedInCoConslts.Count() > 0)
                                    rCGKENTCMS_STAGING01Entities.CMSCoConsultants.RemoveRange(deletedInCoConslts);

                                var deletedInAddtnlParties = rCGKENTCMS_STAGING01Entities.CMSAdditionalParties.Where(k => (k.E3EID == cMSJob.assignment.E3EID) && (k.QueueType.ToUpper() == queueTypeDesc));

                                if (deletedInAddtnlParties.Count() > 0)
                                    rCGKENTCMS_STAGING01Entities.CMSAdditionalParties.RemoveRange(deletedInAddtnlParties);

                                var deletedInPayDets = rCGKENTCMS_STAGING01Entities.CMSPayorDetails.Where(k => (k.E3EID == cMSJob.assignment.E3EID) && (k.QueueType.ToUpper() == queueTypeDesc));

                                if (deletedInPayDets.Count() > 0)
                                    rCGKENTCMS_STAGING01Entities.CMSPayorDetails.RemoveRange(deletedInPayDets);

                                var deletedInIncLocs = rCGKENTCMS_STAGING01Entities.CMSIncidentLocations.Where(k => (k.E3EID == cMSJob.assignment.E3EID) && (k.QueueType.ToUpper() == queueTypeDesc));

                                if (deletedInIncLocs.Count() > 0)
                                    rCGKENTCMS_STAGING01Entities.CMSIncidentLocations.RemoveRange(deletedInIncLocs);

                                rCGKENTCMS_STAGING01Entities.SaveChanges();
                            }
                        }
                    }
                    break;
                case EnvEnum.PROD:
                    {
                        using (RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities())
                        {
                            using (DbContextTransaction transaction = rCGKENTCMS_PROD01Entities.Database.BeginTransaction())
                            {
                                rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;

                                var deletedInAssgnmnts = rCGKENTCMS_PROD01Entities.CMSAssignments.Where(k => (k.E3EID == cMSJob.assignment.E3EID) && (k.QueueType.ToUpper() == queueTypeDesc));

                                if (deletedInAssgnmnts.Count() > 0)
                                    rCGKENTCMS_PROD01Entities.CMSAssignments.RemoveRange(deletedInAssgnmnts);

                                var deletedInOrderingClients = rCGKENTCMS_PROD01Entities.CMSOrderingClients.Where(k => (k.E3EID == cMSJob.assignment.E3EID) && (k.QueueType.ToUpper() == queueTypeDesc));

                                if (deletedInOrderingClients.Count() > 0)
                                    rCGKENTCMS_PROD01Entities.CMSOrderingClients.RemoveRange(deletedInOrderingClients);

                                var deletedInCoConslts = rCGKENTCMS_PROD01Entities.CMSCoConsultants.Where(k => (k.E3EID == cMSJob.assignment.E3EID) && (k.QueueType.ToUpper() == queueTypeDesc));

                                if (deletedInCoConslts.Count() > 0)
                                    rCGKENTCMS_PROD01Entities.CMSCoConsultants.RemoveRange(deletedInCoConslts);

                                var deletedInAddtnlParties = rCGKENTCMS_PROD01Entities.CMSAdditionalParties.Where(k => (k.E3EID == cMSJob.assignment.E3EID) && (k.QueueType.ToUpper() == queueTypeDesc));

                                if (deletedInAddtnlParties.Count() > 0)
                                    rCGKENTCMS_PROD01Entities.CMSAdditionalParties.RemoveRange(deletedInAddtnlParties);

                                var deletedInPayDets = rCGKENTCMS_PROD01Entities.CMSPayorDetails.Where(k => (k.E3EID == cMSJob.assignment.E3EID) && (k.QueueType.ToUpper() == queueTypeDesc));

                                if (deletedInPayDets.Count() > 0)
                                    rCGKENTCMS_PROD01Entities.CMSPayorDetails.RemoveRange(deletedInPayDets);

                                var deletedInIncLocs = rCGKENTCMS_PROD01Entities.CMSIncidentLocations.Where(k => (k.E3EID == cMSJob.assignment.E3EID) && (k.QueueType.ToUpper() == queueTypeDesc));

                                if (deletedInIncLocs.Count() > 0)
                                    rCGKENTCMS_PROD01Entities.CMSIncidentLocations.RemoveRange(deletedInIncLocs);

                                rCGKENTCMS_PROD01Entities.SaveChanges();
                            }
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        public List<CMSJob> GetAssgnMessages(QueueType queueType, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV, int attemptsAllowed = 20)
        {
            List<CMSJob> cMSJobs = new List<CMSJob>();
            string queueTypeDesc = TE3EEntityExt.GetEnumDescription(queueType);

            switch (env)
            {
                case EnvEnum.DEV:
                    {
                        using (RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities())
                        {
                            rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;

                            #region scan assignments

                            var oAssignmentGroup = rCGKENTCMS_DEV01Entities.CMSAssignments.Where(x => !(x.IsProcessed ?? false) && ((x.NumOfAttempts ?? 0) < attemptsAllowed) && (x.QueueType.ToUpper() == queueTypeDesc))
                                                                                          .GroupBy(x => new { KenticoID = x.KenticoID, TimeStamp = x.TimeStamp })
                                                                                          .OrderByDescending(x => x.Key.TimeStamp).AsNoTracking()
                                                                                          .ToList();

                            oAssignmentGroup.ForEach(g =>
                            {
                                CMSJob cMSJob = new CMSJob();
                                cMSJob.assignment = g.FirstOrDefault();
                                cMSJobs.Add(cMSJob);
                            });

                            #endregion scan assignments

                            #region scan ordering client

                            var outClientGroup = rCGKENTCMS_DEV01Entities.CMSOrderingClients.Where(c => !(c.IsProcessed ?? false) && ((c.NumOfAttempts ?? 0) < attemptsAllowed) && (c.QueueType.ToUpper() == queueTypeDesc))
                                                                                          .GroupBy(x => new { KenticoID = x.KenticoID, TimeStamp = x.TimeStamp })
                                                                                          .OrderByDescending(x => x.Key.TimeStamp).AsNoTracking()
                                                                                          .ToList();
                            outClientGroup.ForEach(x =>
                            {
                                cMSJobs.ForEach(e =>
                                {
                                    if (e.assignment.KenticoID == x.Key.KenticoID && e.assignment.TimeStamp == x.Key.TimeStamp)
                                        e.orderingClient = x.First();
                                });
                            });


                            #endregion scan ordering client

                            #region scan incident locations

                            var outIncidentLocations = rCGKENTCMS_DEV01Entities.CMSIncidentLocations.Where(c => !(c.IsProcessed ?? false) && ((c.NumOfAttempts ?? 0) < attemptsAllowed) && (c.QueueType.ToUpper() == queueTypeDesc))
                                                                                          .GroupBy(x => new { KenticoID = x.KenticoID, TimeStamp = x.TimeStamp })
                                                                                          .OrderByDescending(x => x.Key.TimeStamp).AsNoTracking()
                                                                                          .ToList();
                            outIncidentLocations.ForEach(x =>
                            {
                                cMSJobs.ForEach(e =>
                                {
                                    if (e.assignment.KenticoID == x.Key.KenticoID && e.assignment.TimeStamp == x.Key.TimeStamp)
                                        e.incidentLocations.AddRange(x.ToList());
                                });
                            });

                            #endregion scan incident locations

                            #region scan payor details

                            var oPayorDetails = rCGKENTCMS_DEV01Entities.CMSPayorDetails.Where(c => !(c.IsProcessed ?? false) && ((c.NumOfAttempts ?? 0) < attemptsAllowed) && (c.QueueType.ToUpper() == queueTypeDesc))
                                                                                        .GroupBy(x => new { KenticoID = x.KenticoID, TimeStamp = x.TimeStamp })
                                                                                        .OrderByDescending(x => x.Key.TimeStamp).AsNoTracking()
                                                                                        .ToList();
                            oPayorDetails.ForEach(x =>
                            {
                                cMSJobs.ForEach(e =>
                                {
                                    if (e.assignment.KenticoID == x.Key.KenticoID && e.assignment.TimeStamp == x.Key.TimeStamp)
                                        e.payorDetails.AddRange(x.ToList());
                                });
                            });

                            #endregion scan payor details

                            #region scan coConsultants

                            var oCoConsultants = rCGKENTCMS_DEV01Entities.CMSCoConsultants.Where(c => !(c.IsProcessed ?? false) && ((c.NumOfAttempts ?? 0) < attemptsAllowed) && (c.QueueType.ToUpper() == queueTypeDesc))
                                                                                        .GroupBy(x => new { KenticoID = x.KenticoID, TimeStamp = x.TimeStamp })
                                                                                        .OrderByDescending(x => x.Key.TimeStamp).AsNoTracking()
                                                                                        .ToList();
                            oCoConsultants.ForEach(x =>
                            {
                                cMSJobs.ForEach(e =>
                                {
                                    if (e.assignment.KenticoID == x.Key.KenticoID && e.assignment.TimeStamp == x.Key.TimeStamp)
                                        e.coConsultants.AddRange(x.ToList());
                                });
                            });
                            #endregion scan coConsultants

                            #region scan additional parties

                            var oAdditionalParties = rCGKENTCMS_DEV01Entities.CMSAdditionalParties.Where(c => !(c.IsProcessed ?? false) && ((c.NumOfAttempts ?? 0) < attemptsAllowed) && (c.QueueType.ToUpper() == queueTypeDesc))
                                                                                        .GroupBy(x => new { KenticoID = x.KenticoID, TimeStamp = x.TimeStamp })
                                                                                        .OrderByDescending(x => x.Key.TimeStamp).AsNoTracking()
                                                                                        .ToList();
                            oAdditionalParties.ForEach(x =>
                            {
                                cMSJobs.ForEach(e =>
                                {
                                    if (e.assignment.KenticoID == x.Key.KenticoID && e.assignment.TimeStamp == x.Key.TimeStamp)
                                        e.additionalParties.AddRange(x.ToList());
                                });
                            });

                            #endregion scan additional parties
                        }
                    }
                    break;
                case EnvEnum.UAT:
                    {
                        using (RCGKENTCMS_UAT01Entities rCGKENTCMS_UAT01Entities = new RCGKENTCMS_UAT01Entities())
                        {
                            rCGKENTCMS_UAT01Entities.Database.CommandTimeout = sqlCommandTimeout;

                            #region scan assignments

                            var oAssignmentGroup = rCGKENTCMS_UAT01Entities.CMSAssignments.Where(x => !(x.IsProcessed ?? false) && ((x.NumOfAttempts ?? 0) < attemptsAllowed) && (x.QueueType.ToUpper() == queueTypeDesc))
                                                                                          .GroupBy(x => new { KenticoID = x.KenticoID, TimeStamp = x.TimeStamp })
                                                                                          .OrderByDescending(x => x.Key.TimeStamp).AsNoTracking()
                                                                                          .ToList();

                            oAssignmentGroup.ForEach(g =>
                            {
                                CMSJob cMSJob = new CMSJob();
                                cMSJob.assignment = g.FirstOrDefault();
                                cMSJobs.Add(cMSJob);
                            });

                            #endregion scan assignments

                            #region scan ordering client

                            var outClientGroup = rCGKENTCMS_UAT01Entities.CMSOrderingClients.Where(c => !(c.IsProcessed ?? false) && ((c.NumOfAttempts ?? 0) < attemptsAllowed) && (c.QueueType.ToUpper() == queueTypeDesc))
                                                                                          .GroupBy(x => new { KenticoID = x.KenticoID, TimeStamp = x.TimeStamp })
                                                                                          .OrderByDescending(x => x.Key.TimeStamp).AsNoTracking()
                                                                                          .ToList();
                            outClientGroup.ForEach(x =>
                            {
                                cMSJobs.ForEach(e =>
                                {
                                    if (e.assignment.KenticoID == x.Key.KenticoID && e.assignment.TimeStamp == x.Key.TimeStamp)
                                        e.orderingClient = x.First();
                                });
                            });


                            #endregion scan ordering client

                            #region scan incident locations

                            var outIncidentLocations = rCGKENTCMS_UAT01Entities.CMSIncidentLocations.Where(c => !(c.IsProcessed ?? false) && ((c.NumOfAttempts ?? 0) < attemptsAllowed) && (c.QueueType.ToUpper() == queueTypeDesc))
                                                                                          .GroupBy(x => new { KenticoID = x.KenticoID, TimeStamp = x.TimeStamp })
                                                                                          .OrderByDescending(x => x.Key.TimeStamp).AsNoTracking()
                                                                                          .ToList();
                            outIncidentLocations.ForEach(x =>
                            {
                                cMSJobs.ForEach(e =>
                                {
                                    if (e.assignment.KenticoID == x.Key.KenticoID && e.assignment.TimeStamp == x.Key.TimeStamp)
                                        e.incidentLocations.AddRange(x.ToList());
                                });
                            });

                            #endregion scan incident locations

                            #region scan payor details

                            var oPayorDetails = rCGKENTCMS_UAT01Entities.CMSPayorDetails.Where(c => !(c.IsProcessed ?? false) && ((c.NumOfAttempts ?? 0) < attemptsAllowed) && (c.QueueType.ToUpper() == queueTypeDesc))
                                                                                        .GroupBy(x => new { KenticoID = x.KenticoID, TimeStamp = x.TimeStamp })
                                                                                        .OrderByDescending(x => x.Key.TimeStamp).AsNoTracking()
                                                                                        .ToList();
                            oPayorDetails.ForEach(x =>
                            {
                                cMSJobs.ForEach(e =>
                                {
                                    if (e.assignment.KenticoID == x.Key.KenticoID && e.assignment.TimeStamp == x.Key.TimeStamp)
                                        e.payorDetails.AddRange(x.ToList());
                                });
                            });

                            #endregion scan payor details

                            #region scan coConsultants

                            var oCoConsultants = rCGKENTCMS_UAT01Entities.CMSCoConsultants.Where(c => !(c.IsProcessed ?? false) && ((c.NumOfAttempts ?? 0) < attemptsAllowed) && (c.QueueType.ToUpper() == queueTypeDesc))
                                                                                        .GroupBy(x => new { KenticoID = x.KenticoID, TimeStamp = x.TimeStamp })
                                                                                        .OrderByDescending(x => x.Key.TimeStamp).AsNoTracking()
                                                                                        .ToList();
                            oCoConsultants.ForEach(x =>
                            {
                                cMSJobs.ForEach(e =>
                                {
                                    if (e.assignment.KenticoID == x.Key.KenticoID && e.assignment.TimeStamp == x.Key.TimeStamp)
                                        e.coConsultants.AddRange(x.ToList());
                                });
                            });
                            #endregion scan coConsultants

                            #region scan additional parties

                            var oAdditionalParties = rCGKENTCMS_UAT01Entities.CMSAdditionalParties.Where(c => !(c.IsProcessed ?? false) && ((c.NumOfAttempts ?? 0) < attemptsAllowed) && (c.QueueType.ToUpper() == queueTypeDesc))
                                                                                        .GroupBy(x => new { KenticoID = x.KenticoID, TimeStamp = x.TimeStamp })
                                                                                        .OrderByDescending(x => x.Key.TimeStamp).AsNoTracking()
                                                                                        .ToList();
                            oAdditionalParties.ForEach(x =>
                            {
                                cMSJobs.ForEach(e =>
                                {
                                    if (e.assignment.KenticoID == x.Key.KenticoID && e.assignment.TimeStamp == x.Key.TimeStamp)
                                        e.additionalParties.AddRange(x.ToList());
                                });
                            });

                            #endregion scan additional parties
                        }
                    }
                    break;
                case EnvEnum.STAGING:
                    {
                        using (RCGKENTCMS_STAGING01Entities rCGKENTCMS_STAGING01Entities = new RCGKENTCMS_STAGING01Entities())
                        {
                            rCGKENTCMS_STAGING01Entities.Database.CommandTimeout = sqlCommandTimeout;

                            #region scan assignments

                            var oAssignmentGroup = rCGKENTCMS_STAGING01Entities.CMSAssignments.Where(x => !(x.IsProcessed ?? false) && ((x.NumOfAttempts ?? 0) < attemptsAllowed) && (x.QueueType.ToUpper() == queueTypeDesc))
                                                                                          .GroupBy(x => new { KenticoID = x.KenticoID, TimeStamp = x.TimeStamp })
                                                                                          .OrderByDescending(x => x.Key.TimeStamp).AsNoTracking()
                                                                                          .ToList();

                            oAssignmentGroup.ForEach(g =>
                            {
                                CMSJob cMSJob = new CMSJob();
                                cMSJob.assignment = g.FirstOrDefault();
                                cMSJobs.Add(cMSJob);
                            });

                            #endregion scan assignments

                            #region scan ordering client

                            var outClientGroup = rCGKENTCMS_STAGING01Entities.CMSOrderingClients.Where(c => !(c.IsProcessed ?? false) && ((c.NumOfAttempts ?? 0) < attemptsAllowed) && (c.QueueType.ToUpper() == queueTypeDesc))
                                                                                          .GroupBy(x => new { KenticoID = x.KenticoID, TimeStamp = x.TimeStamp })
                                                                                          .OrderByDescending(x => x.Key.TimeStamp).AsNoTracking()
                                                                                          .ToList();
                            outClientGroup.ForEach(x =>
                            {
                                cMSJobs.ForEach(e =>
                                {
                                    if (e.assignment.KenticoID == x.Key.KenticoID && e.assignment.TimeStamp == x.Key.TimeStamp)
                                        e.orderingClient = x.First();
                                });
                            });


                            #endregion scan ordering client

                            #region scan incident locations

                            var outIncidentLocations = rCGKENTCMS_STAGING01Entities.CMSIncidentLocations.Where(c => !(c.IsProcessed ?? false) && ((c.NumOfAttempts ?? 0) < attemptsAllowed) && (c.QueueType.ToUpper() == queueTypeDesc))
                                                                                          .GroupBy(x => new { KenticoID = x.KenticoID, TimeStamp = x.TimeStamp })
                                                                                          .OrderByDescending(x => x.Key.TimeStamp).AsNoTracking()
                                                                                          .ToList();
                            outIncidentLocations.ForEach(x =>
                            {
                                cMSJobs.ForEach(e =>
                                {
                                    if (e.assignment.KenticoID == x.Key.KenticoID && e.assignment.TimeStamp == x.Key.TimeStamp)
                                        e.incidentLocations.AddRange(x.ToList());
                                });
                            });

                            #endregion scan incident locations

                            #region scan payor details

                            var oPayorDetails = rCGKENTCMS_STAGING01Entities.CMSPayorDetails.Where(c => !(c.IsProcessed ?? false) && ((c.NumOfAttempts ?? 0) < attemptsAllowed) && (c.QueueType.ToUpper() == queueTypeDesc))
                                                                                        .GroupBy(x => new { KenticoID = x.KenticoID, TimeStamp = x.TimeStamp })
                                                                                        .OrderByDescending(x => x.Key.TimeStamp).AsNoTracking()
                                                                                        .ToList();
                            oPayorDetails.ForEach(x =>
                            {
                                cMSJobs.ForEach(e =>
                                {
                                    if (e.assignment.KenticoID == x.Key.KenticoID && e.assignment.TimeStamp == x.Key.TimeStamp)
                                        e.payorDetails.AddRange(x.ToList());
                                });
                            });

                            #endregion scan payor details

                            #region scan coConsultants

                            var oCoConsultants = rCGKENTCMS_STAGING01Entities.CMSCoConsultants.Where(c => !(c.IsProcessed ?? false) && ((c.NumOfAttempts ?? 0) < attemptsAllowed) && (c.QueueType.ToUpper() == queueTypeDesc))
                                                                                        .GroupBy(x => new { KenticoID = x.KenticoID, TimeStamp = x.TimeStamp })
                                                                                        .OrderByDescending(x => x.Key.TimeStamp).AsNoTracking()
                                                                                        .ToList();
                            oCoConsultants.ForEach(x =>
                            {
                                cMSJobs.ForEach(e =>
                                {
                                    if (e.assignment.KenticoID == x.Key.KenticoID && e.assignment.TimeStamp == x.Key.TimeStamp)
                                        e.coConsultants.AddRange(x.ToList());
                                });
                            });
                            #endregion scan coConsultants

                            #region scan additional parties

                            var oAdditionalParties = rCGKENTCMS_STAGING01Entities.CMSAdditionalParties.Where(c => !(c.IsProcessed ?? false) && ((c.NumOfAttempts ?? 0) < attemptsAllowed) && (c.QueueType.ToUpper() == queueTypeDesc))
                                                                                        .GroupBy(x => new { KenticoID = x.KenticoID, TimeStamp = x.TimeStamp })
                                                                                        .OrderByDescending(x => x.Key.TimeStamp).AsNoTracking()
                                                                                        .ToList();
                            oAdditionalParties.ForEach(x =>
                            {
                                cMSJobs.ForEach(e =>
                                {
                                    if (e.assignment.KenticoID == x.Key.KenticoID && e.assignment.TimeStamp == x.Key.TimeStamp)
                                        e.additionalParties.AddRange(x.ToList());
                                });
                            });

                            #endregion scan additional parties
                        }
                    }
                    break;
                case EnvEnum.PROD:
                    {
                        using (RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities())
                        {
                            rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;

                            #region scan assignments

                            var oAssignmentGroup = rCGKENTCMS_PROD01Entities.CMSAssignments.Where(x => !(x.IsProcessed ?? false) && ((x.NumOfAttempts ?? 0) < attemptsAllowed) && (x.QueueType.ToUpper() == queueTypeDesc))
                                                                                          .GroupBy(x => new { KenticoID = x.KenticoID, TimeStamp = x.TimeStamp })
                                                                                          .OrderByDescending(x => x.Key.TimeStamp).AsNoTracking()
                                                                                          .ToList();

                            oAssignmentGroup.ForEach(g =>
                            {
                                CMSJob cMSJob = new CMSJob();
                                cMSJob.assignment = g.FirstOrDefault();
                                cMSJobs.Add(cMSJob);
                            });

                            #endregion scan assignments

                            #region scan ordering client

                            var outClientGroup = rCGKENTCMS_PROD01Entities.CMSOrderingClients.Where(c => !(c.IsProcessed ?? false) && ((c.NumOfAttempts ?? 0) < attemptsAllowed) && (c.QueueType.ToUpper() == queueTypeDesc))
                                                                                          .GroupBy(x => new { KenticoID = x.KenticoID, TimeStamp = x.TimeStamp })
                                                                                          .OrderByDescending(x => x.Key.TimeStamp).AsNoTracking()
                                                                                          .ToList();
                            outClientGroup.ForEach(x =>
                            {
                                cMSJobs.ForEach(e =>
                                {
                                    if (e.assignment.KenticoID == x.Key.KenticoID && e.assignment.TimeStamp == x.Key.TimeStamp)
                                        e.orderingClient = x.First();
                                });
                            });


                            #endregion scan ordering client

                            #region scan incident locations

                            var outIncidentLocations = rCGKENTCMS_PROD01Entities.CMSIncidentLocations.Where(c => !(c.IsProcessed ?? false) && ((c.NumOfAttempts ?? 0) < attemptsAllowed) && (c.QueueType.ToUpper() == queueTypeDesc))
                                                                                          .GroupBy(x => new { KenticoID = x.KenticoID, TimeStamp = x.TimeStamp })
                                                                                          .OrderByDescending(x => x.Key.TimeStamp).AsNoTracking()
                                                                                          .ToList();
                            outIncidentLocations.ForEach(x =>
                            {
                                cMSJobs.ForEach(e =>
                                {
                                    if (e.assignment.KenticoID == x.Key.KenticoID && e.assignment.TimeStamp == x.Key.TimeStamp)
                                        e.incidentLocations.AddRange(x.ToList());
                                });
                            });

                            #endregion scan incident locations

                            #region scan payor details

                            var oPayorDetails = rCGKENTCMS_PROD01Entities.CMSPayorDetails.Where(c => !(c.IsProcessed ?? false) && ((c.NumOfAttempts ?? 0) < attemptsAllowed) && (c.QueueType.ToUpper() == queueTypeDesc))
                                                                                        .GroupBy(x => new { KenticoID = x.KenticoID, TimeStamp = x.TimeStamp })
                                                                                        .OrderByDescending(x => x.Key.TimeStamp).AsNoTracking()
                                                                                        .ToList();
                            oPayorDetails.ForEach(x =>
                            {
                                cMSJobs.ForEach(e =>
                                {
                                    if (e.assignment.KenticoID == x.Key.KenticoID && e.assignment.TimeStamp == x.Key.TimeStamp)
                                        e.payorDetails.AddRange(x.ToList());
                                });
                            });

                            #endregion scan payor details

                            #region scan coConsultants

                            var oCoConsultants = rCGKENTCMS_PROD01Entities.CMSCoConsultants.Where(c => !(c.IsProcessed ?? false) && ((c.NumOfAttempts ?? 0) < attemptsAllowed) && (c.QueueType.ToUpper() == queueTypeDesc))
                                                                                        .GroupBy(x => new { KenticoID = x.KenticoID, TimeStamp = x.TimeStamp })
                                                                                        .OrderByDescending(x => x.Key.TimeStamp).AsNoTracking()
                                                                                        .ToList();
                            oCoConsultants.ForEach(x =>
                            {
                                cMSJobs.ForEach(e =>
                                {
                                    if (e.assignment.KenticoID == x.Key.KenticoID && e.assignment.TimeStamp == x.Key.TimeStamp)
                                        e.coConsultants.AddRange(x.ToList());
                                });
                            });
                            #endregion scan coConsultants

                            #region scan additional parties

                            var oAdditionalParties = rCGKENTCMS_PROD01Entities.CMSAdditionalParties.Where(c => !(c.IsProcessed ?? false) && ((c.NumOfAttempts ?? 0) < attemptsAllowed) && (c.QueueType.ToUpper() == queueTypeDesc))
                                                                                        .GroupBy(x => new { KenticoID = x.KenticoID, TimeStamp = x.TimeStamp })
                                                                                        .OrderByDescending(x => x.Key.TimeStamp).AsNoTracking()
                                                                                        .ToList();
                            oAdditionalParties.ForEach(x =>
                            {
                                cMSJobs.ForEach(e =>
                                {
                                    if (e.assignment.KenticoID == x.Key.KenticoID && e.assignment.TimeStamp == x.Key.TimeStamp)
                                        e.additionalParties.AddRange(x.ToList());
                                });
                            });

                            #endregion scan additional parties
                        }
                    }
                    break;
                default:
                    break;
            }

            return cMSJobs;
        }

        public List<CMSJob> UpdateAssignMessageMattIndex(int CMSAssignmentID, int MatterIndex, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV, int attemptsAllowed = 20)
        {
            List<CMSJob> cMSJobs = new List<CMSJob>();

            switch (env)
            {
                case EnvEnum.DEV:
                    {
                        using (RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities())
                        {
                            rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                            var assignment = rCGKENTCMS_DEV01Entities.CMSAssignments.Find(CMSAssignmentID);
                            assignment.E3EID = MatterIndex;
                            assignment.MatterIndex = MatterIndex;
                            rCGKENTCMS_DEV01Entities.SaveChanges();
                        }
                    }
                    break;
                case EnvEnum.UAT:
                    {
                        using (RCGKENTCMS_UAT01Entities rCGKENTCMS_UAT01Entities = new RCGKENTCMS_UAT01Entities())
                        {
                            rCGKENTCMS_UAT01Entities.Database.CommandTimeout = sqlCommandTimeout;
                            var assignment = rCGKENTCMS_UAT01Entities.CMSAssignments.Find(CMSAssignmentID);
                            assignment.E3EID = MatterIndex;
                            assignment.MatterIndex = MatterIndex;
                            rCGKENTCMS_UAT01Entities.SaveChanges();
                        }
                    }
                    break;
                case EnvEnum.STAGING:
                    {
                        using (RCGKENTCMS_STAGING01Entities rCGKENTCMS_STAGING01Entities = new RCGKENTCMS_STAGING01Entities())
                        {
                            rCGKENTCMS_STAGING01Entities.Database.CommandTimeout = sqlCommandTimeout;
                            var assignment = rCGKENTCMS_STAGING01Entities.CMSAssignments.Find(CMSAssignmentID);
                            assignment.E3EID = MatterIndex;
                            assignment.MatterIndex = MatterIndex;
                            rCGKENTCMS_STAGING01Entities.SaveChanges();
                        }
                    }
                    break;
                case EnvEnum.PROD:
                    {
                        using (RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities())
                        {
                            rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                            var assignment = rCGKENTCMS_PROD01Entities.CMSAssignments.Find(CMSAssignmentID);
                            assignment.E3EID = MatterIndex;
                            assignment.MatterIndex = MatterIndex;
                            rCGKENTCMS_PROD01Entities.SaveChanges();
                        }
                    }
                    break;
                default:
                    break;
            }

            return cMSJobs;
        }


        [Obsolete]
        public List<CMSJob> GetAssgnMessagesOLD(QueueType queueType, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV, int attemptsAllowed = 20)
        {
            List<CMSJob> cMSJobs = new List<CMSJob>();
            string queueTypeDesc = TE3EEntityExt.GetEnumDescription(queueType);

            switch (env)
            {
                case EnvEnum.DEV:
                    {
                        using (RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities())
                        {
                            rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;

                            #region scan assignments

                            var oAssignmentGroup = rCGKENTCMS_DEV01Entities.CMSAssignments.Where(x => !(x.IsProcessed ?? false) && ((x.NumOfAttempts ?? 0) < attemptsAllowed) && (x.QueueType.ToUpper() == queueTypeDesc))
                                                                                          .GroupBy(x => new { x.KenticoID })
                                                                                          .ToList();

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

                            var outClientGroup = rCGKENTCMS_DEV01Entities.CMSOrderingClients.Where(c => !(c.IsProcessed ?? false) && ((c.NumOfAttempts ?? 0) < attemptsAllowed) && (c.QueueType.ToUpper() == queueTypeDesc))
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

                            var outIncidentLocations = rCGKENTCMS_DEV01Entities.CMSIncidentLocations.Where(c => !(c.IsProcessed ?? false) && ((c.NumOfAttempts ?? 0) < attemptsAllowed) && (c.QueueType.ToUpper() == queueTypeDesc))
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

                            var oPayorDetails = rCGKENTCMS_DEV01Entities.CMSPayorDetails.Where(c => !(c.IsProcessed ?? false) && ((c.NumOfAttempts ?? 0) < attemptsAllowed) && (c.QueueType.ToUpper() == queueTypeDesc))
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

                            var oCoConsultants = rCGKENTCMS_DEV01Entities.CMSCoConsultants.Where(c => !(c.IsProcessed ?? false) && ((c.NumOfAttempts ?? 0) < attemptsAllowed) && (c.QueueType.ToUpper() == queueTypeDesc))
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

                            var oAdditionalParties = rCGKENTCMS_DEV01Entities.CMSAdditionalParties.Where(c => !(c.IsProcessed ?? false) && ((c.NumOfAttempts ?? 0) < attemptsAllowed) && (c.QueueType.ToUpper() == queueTypeDesc))
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
                    break;
                case EnvEnum.UAT:
                    {
                        using (RCGKENTCMS_UAT01Entities rCGKENTCMS_UAT01Entities = new RCGKENTCMS_UAT01Entities())
                        {
                            rCGKENTCMS_UAT01Entities.Database.CommandTimeout = sqlCommandTimeout;

                            #region scan assignments

                            var oAssignmentGroup = rCGKENTCMS_UAT01Entities.CMSAssignments.Where(x => !(x.IsProcessed ?? false) && ((x.NumOfAttempts ?? 0) < attemptsAllowed) && (x.QueueType.ToUpper() == queueTypeDesc))
                                                                                          .GroupBy(x => new { x.KenticoID })
                                                                                          .ToList();

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

                            var outClientGroup = rCGKENTCMS_UAT01Entities.CMSOrderingClients.Where(c => !(c.IsProcessed ?? false) && ((c.NumOfAttempts ?? 0) < attemptsAllowed) && (c.QueueType.ToUpper() == queueTypeDesc))
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

                            var outIncidentLocations = rCGKENTCMS_UAT01Entities.CMSIncidentLocations.Where(c => !(c.IsProcessed ?? false) && ((c.NumOfAttempts ?? 0) < attemptsAllowed) && (c.QueueType.ToUpper() == queueTypeDesc))
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

                            var oPayorDetails = rCGKENTCMS_UAT01Entities.CMSPayorDetails.Where(c => !(c.IsProcessed ?? false) && ((c.NumOfAttempts ?? 0) < attemptsAllowed) && (c.QueueType.ToUpper() == queueTypeDesc))
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

                            var oCoConsultants = rCGKENTCMS_UAT01Entities.CMSCoConsultants.Where(c => !(c.IsProcessed ?? false) && ((c.NumOfAttempts ?? 0) < attemptsAllowed) && (c.QueueType.ToUpper() == queueTypeDesc))
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

                            var oAdditionalParties = rCGKENTCMS_UAT01Entities.CMSAdditionalParties.Where(c => !(c.IsProcessed ?? false) && ((c.NumOfAttempts ?? 0) < attemptsAllowed) && (c.QueueType.ToUpper() == queueTypeDesc))
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
                    break;
                case EnvEnum.STAGING:
                    {
                        using (RCGKENTCMS_STAGING01Entities rCGKENTCMS_STAGING01Entities = new RCGKENTCMS_STAGING01Entities())
                        {
                            rCGKENTCMS_STAGING01Entities.Database.CommandTimeout = sqlCommandTimeout;

                            #region scan assignments

                            var oAssignmentGroup = rCGKENTCMS_STAGING01Entities.CMSAssignments.Where(x => !(x.IsProcessed ?? false) && ((x.NumOfAttempts ?? 0) < attemptsAllowed) && (x.QueueType.ToUpper() == queueTypeDesc))
                                                                                          .GroupBy(x => new { x.KenticoID })
                                                                                          .ToList();

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

                            var outClientGroup = rCGKENTCMS_STAGING01Entities.CMSOrderingClients.Where(c => !(c.IsProcessed ?? false) && ((c.NumOfAttempts ?? 0) < attemptsAllowed) && (c.QueueType.ToUpper() == queueTypeDesc))
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

                            var outIncidentLocations = rCGKENTCMS_STAGING01Entities.CMSIncidentLocations.Where(c => !(c.IsProcessed ?? false) && ((c.NumOfAttempts ?? 0) < attemptsAllowed) && (c.QueueType.ToUpper() == queueTypeDesc))
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

                            var oPayorDetails = rCGKENTCMS_STAGING01Entities.CMSPayorDetails.Where(c => !(c.IsProcessed ?? false) && ((c.NumOfAttempts ?? 0) < attemptsAllowed) && (c.QueueType.ToUpper() == queueTypeDesc))
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

                            var oCoConsultants = rCGKENTCMS_STAGING01Entities.CMSCoConsultants.Where(c => !(c.IsProcessed ?? false) && ((c.NumOfAttempts ?? 0) < attemptsAllowed) && (c.QueueType.ToUpper() == queueTypeDesc))
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

                            var oAdditionalParties = rCGKENTCMS_STAGING01Entities.CMSAdditionalParties.Where(c => !(c.IsProcessed ?? false) && ((c.NumOfAttempts ?? 0) < attemptsAllowed) && (c.QueueType.ToUpper() == queueTypeDesc))
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
                    break;
                case EnvEnum.PROD:
                    {
                        using (RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities())
                        {
                            rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;

                            #region scan assignments

                            var oAssignmentGroup = rCGKENTCMS_PROD01Entities.CMSAssignments.Where(x => !(x.IsProcessed ?? false) && ((x.NumOfAttempts ?? 0) < attemptsAllowed) && (x.QueueType.ToUpper() == queueTypeDesc))
                                                                                          .GroupBy(x => new { x.KenticoID })
                                                                                          .ToList();

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

                            var outClientGroup = rCGKENTCMS_PROD01Entities.CMSOrderingClients.Where(c => !(c.IsProcessed ?? false) && ((c.NumOfAttempts ?? 0) < attemptsAllowed) && (c.QueueType.ToUpper() == queueTypeDesc))
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

                            var outIncidentLocations = rCGKENTCMS_PROD01Entities.CMSIncidentLocations.Where(c => !(c.IsProcessed ?? false) && ((c.NumOfAttempts ?? 0) < attemptsAllowed) && (c.QueueType.ToUpper() == queueTypeDesc))
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

                            var oPayorDetails = rCGKENTCMS_PROD01Entities.CMSPayorDetails.Where(c => !(c.IsProcessed ?? false) && ((c.NumOfAttempts ?? 0) < attemptsAllowed) && (c.QueueType.ToUpper() == queueTypeDesc))
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

                            var oCoConsultants = rCGKENTCMS_PROD01Entities.CMSCoConsultants.Where(c => !(c.IsProcessed ?? false) && ((c.NumOfAttempts ?? 0) < attemptsAllowed) && (c.QueueType.ToUpper() == queueTypeDesc))
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

                            var oAdditionalParties = rCGKENTCMS_PROD01Entities.CMSAdditionalParties.Where(c => !(c.IsProcessed ?? false) && ((c.NumOfAttempts ?? 0) < attemptsAllowed) && (c.QueueType.ToUpper() == queueTypeDesc))
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
                    break;
                default:
                    break;
            }

            return cMSJobs;
        }

        public void RemoveAssgnMessage(
            QueueType queueType,
            string server,
            string dbInstance,
            string kenticoID,
            DateTime? timeStamp,
            int sqlCommandTimeout,
             EnvEnum env = EnvEnum.DEV)
        {
            string queueTypeDesc = TE3EEntityExt.GetEnumDescription(queueType);

            using (var objStreamReader = File.OpenText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $"datasource/rcgkentcms/datascripts/RemoveAssgnMessage.sql")))
            {
                string sqlStmt = objStreamReader.ReadToEnd();
                sqlStmt = sqlStmt.Replace("@server", server);
                sqlStmt = sqlStmt.Replace("@instance", dbInstance);
                sqlStmt = sqlStmt.Replace("@kenticoID", kenticoID);
                sqlStmt = sqlStmt.Replace("@queueType", queueTypeDesc);
                sqlStmt = sqlStmt.Replace("@timeStamp", timeStamp.ToSQLFormat());
                SqlScriptExecutionNoReturn(sqlStmt, sqlCommandTimeout, env);
            }
        }

        public void UpdateAssgnMessage(
            QueueType queueType,
            string server,
            string dbInstance,
            string kenticoID,
            DateTime? timeStamp,
            int sqlCommandTimeout,
             EnvEnum env = EnvEnum.DEV)
        {

            string queueTypeDesc = TE3EEntityExt.GetEnumDescription(queueType);

            using (var objStreamReader = File.OpenText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $"datasource/rcgkentcms/datascripts/UpdateAssgnMessage.sql")))
            {
                string sqlStmt = objStreamReader.ReadToEnd();

                sqlStmt = sqlStmt.Replace("@server", server);
                sqlStmt = sqlStmt.Replace("@instance", dbInstance);
                sqlStmt = sqlStmt.Replace("@kenticoID", kenticoID);
                sqlStmt = sqlStmt.Replace("@queueType", queueTypeDesc);
                sqlStmt = sqlStmt.Replace("@processedDate", DateTime.UtcNow.ToSQLFormat());
                sqlStmt = sqlStmt.Replace("@timeStamp", timeStamp.ToSQLFormat());

                SqlScriptExecutionNoReturn(sqlStmt, sqlCommandTimeout, env);
            }
        }

        [Obsolete]
        public void UpdateAssgnMessageOLD(CMSJob cMSJob, QueueType queueType, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        {
            string queueTypeDesc = TE3EEntityExt.GetEnumDescription(queueType);

            switch (env)
            {
                case EnvEnum.DEV:
                    {
                        using (RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities())
                        {
                            rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;

                            #region update assignment

                            var oAssignmentGroup = rCGKENTCMS_DEV01Entities.CMSAssignments.Where(x => !(x.IsProcessed ?? false) && x.KenticoID == cMSJob.assignment.KenticoID && (x.QueueType.ToUpper() == queueTypeDesc))
                                                                                          .ToList();

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
                    break;
                case EnvEnum.UAT:
                    {
                        using (RCGKENTCMS_UAT01Entities rCGKENTCMS_UAT01Entities = new RCGKENTCMS_UAT01Entities())
                        {
                            rCGKENTCMS_UAT01Entities.Database.CommandTimeout = sqlCommandTimeout;

                            #region update assignment

                            var oAssignmentGroup = rCGKENTCMS_UAT01Entities.CMSAssignments.Where(x => !(x.IsProcessed ?? false) && x.KenticoID == cMSJob.assignment.KenticoID && (x.QueueType.ToUpper() == queueTypeDesc))
                                                                                          .ToList();

                            if (oAssignmentGroup.Count() > 0)
                            {

                                oAssignmentGroup.First().IsProcessed = true;
                                oAssignmentGroup.First().ProcessedDate = DateTime.Now;
                                oAssignmentGroup.First().NumOfAttempts = (oAssignmentGroup.First().NumOfAttempts ?? 0) + 1;
                            }

                            #endregion update assignment

                            #region scan ordering client

                            var outClientGroup = rCGKENTCMS_UAT01Entities.CMSOrderingClients.Where(c => !(c.IsProcessed ?? false) && c.KenticoID == cMSJob.assignment.KenticoID && (c.QueueType.ToUpper() == queueTypeDesc))
                                                                                            .Select(c => c).ToList();
                            if (outClientGroup.Count() > 0)
                            {
                                outClientGroup.First().IsProcessed = true;
                                outClientGroup.First().ProcessedDate = DateTime.Now;
                                outClientGroup.First().NumOfAttempts = (outClientGroup.First().NumOfAttempts ?? 0) + 1;
                            }

                            #endregion scan ordering client

                            #region scan incident locations

                            var outIncidentLocations = rCGKENTCMS_UAT01Entities.CMSIncidentLocations.Where(c => !(c.IsProcessed ?? false) && c.KenticoID == cMSJob.assignment.KenticoID && (c.QueueType.ToUpper() == queueTypeDesc))
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

                            var oPayorDetails = rCGKENTCMS_UAT01Entities.CMSPayorDetails.Where(c => !(c.IsProcessed ?? false) && c.KenticoID == cMSJob.assignment.KenticoID && (c.QueueType.ToUpper() == queueTypeDesc))
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

                            var oCoConsultants = rCGKENTCMS_UAT01Entities.CMSCoConsultants.Where(c => !(c.IsProcessed ?? false) && c.KenticoID == cMSJob.assignment.KenticoID && (c.QueueType.ToUpper() == queueTypeDesc))
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

                            var oAdditionalParties = rCGKENTCMS_UAT01Entities.CMSAdditionalParties.Where(c => !(c.IsProcessed ?? false) && c.KenticoID == cMSJob.assignment.KenticoID && (c.QueueType.ToUpper() == queueTypeDesc))
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

                            rCGKENTCMS_UAT01Entities.SaveChanges();
                        }
                    }
                    break;
                case EnvEnum.STAGING:
                    {
                        using (RCGKENTCMS_STAGING01Entities rCGKENTCMS_STAGING01Entities = new RCGKENTCMS_STAGING01Entities())
                        {
                            rCGKENTCMS_STAGING01Entities.Database.CommandTimeout = sqlCommandTimeout;

                            #region update assignment

                            var oAssignmentGroup = rCGKENTCMS_STAGING01Entities.CMSAssignments.Where(x => !(x.IsProcessed ?? false) && x.KenticoID == cMSJob.assignment.KenticoID && (x.QueueType.ToUpper() == queueTypeDesc))
                                                                                          .ToList();

                            if (oAssignmentGroup.Count() > 0)
                            {

                                oAssignmentGroup.First().IsProcessed = true;
                                oAssignmentGroup.First().ProcessedDate = DateTime.Now;
                                oAssignmentGroup.First().NumOfAttempts = (oAssignmentGroup.First().NumOfAttempts ?? 0) + 1;
                            }

                            #endregion update assignment

                            #region scan ordering client

                            var outClientGroup = rCGKENTCMS_STAGING01Entities.CMSOrderingClients.Where(c => !(c.IsProcessed ?? false) && c.KenticoID == cMSJob.assignment.KenticoID && (c.QueueType.ToUpper() == queueTypeDesc))
                                                                                            .Select(c => c).ToList();
                            if (outClientGroup.Count() > 0)
                            {
                                outClientGroup.First().IsProcessed = true;
                                outClientGroup.First().ProcessedDate = DateTime.Now;
                                outClientGroup.First().NumOfAttempts = (outClientGroup.First().NumOfAttempts ?? 0) + 1;
                            }

                            #endregion scan ordering client

                            #region scan incident locations

                            var outIncidentLocations = rCGKENTCMS_STAGING01Entities.CMSIncidentLocations.Where(c => !(c.IsProcessed ?? false) && c.KenticoID == cMSJob.assignment.KenticoID && (c.QueueType.ToUpper() == queueTypeDesc))
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

                            var oPayorDetails = rCGKENTCMS_STAGING01Entities.CMSPayorDetails.Where(c => !(c.IsProcessed ?? false) && c.KenticoID == cMSJob.assignment.KenticoID && (c.QueueType.ToUpper() == queueTypeDesc))
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

                            var oCoConsultants = rCGKENTCMS_STAGING01Entities.CMSCoConsultants.Where(c => !(c.IsProcessed ?? false) && c.KenticoID == cMSJob.assignment.KenticoID && (c.QueueType.ToUpper() == queueTypeDesc))
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

                            var oAdditionalParties = rCGKENTCMS_STAGING01Entities.CMSAdditionalParties.Where(c => !(c.IsProcessed ?? false) && c.KenticoID == cMSJob.assignment.KenticoID && (c.QueueType.ToUpper() == queueTypeDesc))
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

                            rCGKENTCMS_STAGING01Entities.SaveChanges();
                        }
                    }
                    break;
                case EnvEnum.PROD:
                    {
                        using (RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities())
                        {
                            rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;

                            #region update assignment

                            var oAssignmentGroup = rCGKENTCMS_PROD01Entities.CMSAssignments.Where(x => !(x.IsProcessed ?? false) && x.KenticoID == cMSJob.assignment.KenticoID && (x.QueueType.ToUpper() == queueTypeDesc))
                                                                                          .ToList();

                            if (oAssignmentGroup.Count() > 0)
                            {

                                oAssignmentGroup.First().IsProcessed = true;
                                oAssignmentGroup.First().ProcessedDate = DateTime.Now;
                                oAssignmentGroup.First().NumOfAttempts = (oAssignmentGroup.First().NumOfAttempts ?? 0) + 1;
                            }

                            #endregion update assignment

                            #region scan ordering client

                            var outClientGroup = rCGKENTCMS_PROD01Entities.CMSOrderingClients.Where(c => !(c.IsProcessed ?? false) && c.KenticoID == cMSJob.assignment.KenticoID && (c.QueueType.ToUpper() == queueTypeDesc))
                                                                                            .Select(c => c).ToList();
                            if (outClientGroup.Count() > 0)
                            {
                                outClientGroup.First().IsProcessed = true;
                                outClientGroup.First().ProcessedDate = DateTime.Now;
                                outClientGroup.First().NumOfAttempts = (outClientGroup.First().NumOfAttempts ?? 0) + 1;
                            }

                            #endregion scan ordering client

                            #region scan incident locations

                            var outIncidentLocations = rCGKENTCMS_PROD01Entities.CMSIncidentLocations.Where(c => !(c.IsProcessed ?? false) && c.KenticoID == cMSJob.assignment.KenticoID && (c.QueueType.ToUpper() == queueTypeDesc))
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

                            var oPayorDetails = rCGKENTCMS_PROD01Entities.CMSPayorDetails.Where(c => !(c.IsProcessed ?? false) && c.KenticoID == cMSJob.assignment.KenticoID && (c.QueueType.ToUpper() == queueTypeDesc))
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

                            var oCoConsultants = rCGKENTCMS_PROD01Entities.CMSCoConsultants.Where(c => !(c.IsProcessed ?? false) && c.KenticoID == cMSJob.assignment.KenticoID && (c.QueueType.ToUpper() == queueTypeDesc))
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

                            var oAdditionalParties = rCGKENTCMS_PROD01Entities.CMSAdditionalParties.Where(c => !(c.IsProcessed ?? false) && c.KenticoID == cMSJob.assignment.KenticoID && (c.QueueType.ToUpper() == queueTypeDesc))
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

                            rCGKENTCMS_PROD01Entities.SaveChanges();
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        public void UpdateAssgnMessageErr(
            QueueType queueType,
            string server,
            string dbInstance,
            string kenticoID,
            DateTime? timeStamp,
            string errMsg,
            int sqlCommandTimeout,
             EnvEnum env = EnvEnum.DEV)
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
                sqlStmt = sqlStmt.Replace("@timeStamp", timeStamp.ToSQLFormat());

                SqlScriptExecutionNoReturn(sqlStmt, sqlCommandTimeout, env);
            }
        }

        #endregion assignment data access methods

        #region Kentico Assignment Copy data access methods

        public Assignment GetKenticoAssignmentCopy(string kenticoId, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        {
            Assignment assignment = null;
            var kenticoAssignmentCopy = SqlDBEntity_Get<CMSKenticoAssignmentCopy>(sqlCommandTimeout, env).FirstOrDefault(x => x.KenticoId.Equals(kenticoId));
            if (kenticoAssignmentCopy != null)
            {
                assignment = JsonConvert.DeserializeObject<Assignment>(kenticoAssignmentCopy.AssignmentImageJson);
            }
            return assignment;
        }


        public void AddOrUpdateKenticoAssignmentCopy(Assignment assignment, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        {

            switch (env)
            {
                case EnvEnum.DEV:
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
                    break;
                case EnvEnum.UAT:
                    {
                        using (RCGKENTCMS_UAT01Entities rCGKENTCMS_UAT01Entities = new RCGKENTCMS_UAT01Entities())
                        {
                            rCGKENTCMS_UAT01Entities.Database.CommandTimeout = sqlCommandTimeout;

                            var kenticoAssignmentCopy = rCGKENTCMS_UAT01Entities.CMSKenticoAssignmentCopies.FirstOrDefault(x => x.KenticoId.Equals(assignment.KenticoID));
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
                                rCGKENTCMS_UAT01Entities.CMSKenticoAssignmentCopies.Add(kenticoAssignmentCopy);
                            }
                            else
                            {
                                kenticoAssignmentCopy.KenticoId = assignment.KenticoID;
                                kenticoAssignmentCopy.E3EID = assignment.E3EID;
                                kenticoAssignmentCopy.MatterIndex = assignment.E3EID;
                                kenticoAssignmentCopy.AssignmentImageJson = JsonConvert.SerializeObject(assignment);
                                kenticoAssignmentCopy.Timestamp = DateTime.Now;
                            }
                            rCGKENTCMS_UAT01Entities.SaveChanges();
                        }
                    }
                    break;
                case EnvEnum.STAGING:
                    {
                        using (RCGKENTCMS_STAGING01Entities rCGKENTCMS_STAGING01Entities = new RCGKENTCMS_STAGING01Entities())
                        {
                            rCGKENTCMS_STAGING01Entities.Database.CommandTimeout = sqlCommandTimeout;

                            var kenticoAssignmentCopy = rCGKENTCMS_STAGING01Entities.CMSKenticoAssignmentCopies.FirstOrDefault(x => x.KenticoId.Equals(assignment.KenticoID));
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
                                rCGKENTCMS_STAGING01Entities.CMSKenticoAssignmentCopies.Add(kenticoAssignmentCopy);
                            }
                            else
                            {
                                kenticoAssignmentCopy.KenticoId = assignment.KenticoID;
                                kenticoAssignmentCopy.E3EID = assignment.E3EID;
                                kenticoAssignmentCopy.MatterIndex = assignment.E3EID;
                                kenticoAssignmentCopy.AssignmentImageJson = JsonConvert.SerializeObject(assignment);
                                kenticoAssignmentCopy.Timestamp = DateTime.Now;
                            }
                            rCGKENTCMS_STAGING01Entities.SaveChanges();
                        }
                    }
                    break;
                case EnvEnum.PROD:
                    {
                        using (RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities())
                        {
                            rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;

                            var kenticoAssignmentCopy = rCGKENTCMS_PROD01Entities.CMSKenticoAssignmentCopies.FirstOrDefault(x => x.KenticoId.Equals(assignment.KenticoID));
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
                                rCGKENTCMS_PROD01Entities.CMSKenticoAssignmentCopies.Add(kenticoAssignmentCopy);
                            }
                            else
                            {
                                kenticoAssignmentCopy.KenticoId = assignment.KenticoID;
                                kenticoAssignmentCopy.E3EID = assignment.E3EID;
                                kenticoAssignmentCopy.MatterIndex = assignment.E3EID;
                                kenticoAssignmentCopy.AssignmentImageJson = JsonConvert.SerializeObject(assignment);
                                kenticoAssignmentCopy.Timestamp = DateTime.Now;
                            }
                            rCGKENTCMS_PROD01Entities.SaveChanges();
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region customer profile data access methods

        public void AddCustomer(CMSCustomerProfile customer, QueueType queueType, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        {
            #region set queue type
            customer.QueueType = TE3EEntityExt.GetEnumDescription(queueType);

            #endregion set queue type

            switch (env)
            {
                case EnvEnum.DEV:
                    {
                        using (RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities())
                        {
                            rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                            rCGKENTCMS_DEV01Entities.CMSCustomerProfiles.Add(customer);
                            rCGKENTCMS_DEV01Entities.SaveChanges();
                        }
                    }
                    break;
                case EnvEnum.UAT:
                    {
                        using (RCGKENTCMS_UAT01Entities rCGKENTCMS_UAT01Entities = new RCGKENTCMS_UAT01Entities())
                        {
                            rCGKENTCMS_UAT01Entities.Database.CommandTimeout = sqlCommandTimeout;
                            rCGKENTCMS_UAT01Entities.CMSCustomerProfiles.Add(customer);
                            rCGKENTCMS_UAT01Entities.SaveChanges();
                        }
                    }
                    break;
                case EnvEnum.STAGING:
                    {
                        using (RCGKENTCMS_STAGING01Entities rCGKENTCMS_STAGING01Entities = new RCGKENTCMS_STAGING01Entities())
                        {
                            rCGKENTCMS_STAGING01Entities.Database.CommandTimeout = sqlCommandTimeout;
                            rCGKENTCMS_STAGING01Entities.CMSCustomerProfiles.Add(customer);
                            rCGKENTCMS_STAGING01Entities.SaveChanges();
                        }
                    }
                    break;
                case EnvEnum.PROD:
                    {
                        using (RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities())
                        {
                            rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                            rCGKENTCMS_PROD01Entities.CMSCustomerProfiles.Add(customer);
                            rCGKENTCMS_PROD01Entities.SaveChanges();
                        }
                    }
                    break;
                default:
                    break;
            }
        }


        public List<CMSCustomerProfile> GetCustomers(QueueType queueType, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV, int attemptsAllowed = 20)
        {
            List<CMSCustomerProfile> oCustomers = new List<CMSCustomerProfile>();
            string queueTypeDesc = TE3EEntityExt.GetEnumDescription(queueType);

            var custGrouping = SqlDBEntity_Get<CMSCustomerProfile>(sqlCommandTimeout, env).Where(x => !(x.IsProcessed ?? false) && ((x.NumOfAttempts ?? 0) < attemptsAllowed) && (x.QueueType.ToUpper() == queueTypeDesc))
                                                                                           .GroupBy(x => new { x.KenticoID, x.ClientNumber, x.CompanyName, x.FirstName, x.LastName })
                                                                                           .ToList();
            custGrouping.ForEach(g =>
            {
                var mostedUpdatedRec = g.OrderByDescending(o => o.TimeStamp).First();
                oCustomers.Add(mostedUpdatedRec);
            });
            return oCustomers;
        }

        public void RemoveCustomer(CMSCustomerProfile iCustomer, QueueType queueType, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        {
            string queueTypeDesc = TE3EEntityExt.GetEnumDescription(queueType);

            switch (env)
            {
                case EnvEnum.DEV:
                    {
                        using (RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities())
                        {
                            rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                            var deletedInCustomers = rCGKENTCMS_DEV01Entities.CMSCustomerProfiles.Where(k => (k.KenticoID == iCustomer.KenticoID) && (k.QueueType.ToUpper() == queueTypeDesc));
                            rCGKENTCMS_DEV01Entities.CMSCustomerProfiles.RemoveRange(deletedInCustomers);
                            rCGKENTCMS_DEV01Entities.SaveChanges();
                        }
                    }
                    break;
                case EnvEnum.UAT:
                    {
                        using (RCGKENTCMS_UAT01Entities rCGKENTCMS_UAT01Entities = new RCGKENTCMS_UAT01Entities())
                        {
                            rCGKENTCMS_UAT01Entities.Database.CommandTimeout = sqlCommandTimeout;
                            var deletedInCustomers = rCGKENTCMS_UAT01Entities.CMSCustomerProfiles.Where(k => (k.KenticoID == iCustomer.KenticoID) && (k.QueueType.ToUpper() == queueTypeDesc));
                            rCGKENTCMS_UAT01Entities.CMSCustomerProfiles.RemoveRange(deletedInCustomers);
                            rCGKENTCMS_UAT01Entities.SaveChanges();
                        }
                    }
                    break;
                case EnvEnum.STAGING:
                    {
                        using (RCGKENTCMS_STAGING01Entities rCGKENTCMS_STAGING01Entities = new RCGKENTCMS_STAGING01Entities())
                        {
                            rCGKENTCMS_STAGING01Entities.Database.CommandTimeout = sqlCommandTimeout;
                            var deletedInCustomers = rCGKENTCMS_STAGING01Entities.CMSCustomerProfiles.Where(k => (k.KenticoID == iCustomer.KenticoID) && (k.QueueType.ToUpper() == queueTypeDesc));
                            rCGKENTCMS_STAGING01Entities.CMSCustomerProfiles.RemoveRange(deletedInCustomers);
                            rCGKENTCMS_STAGING01Entities.SaveChanges();
                        }
                    }
                    break;
                case EnvEnum.PROD:
                    {
                        using (RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities())
                        {
                            rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                            var deletedInCustomers = rCGKENTCMS_PROD01Entities.CMSCustomerProfiles.Where(k => (k.KenticoID == iCustomer.KenticoID) && (k.QueueType.ToUpper() == queueTypeDesc));
                            rCGKENTCMS_PROD01Entities.CMSCustomerProfiles.RemoveRange(deletedInCustomers);
                            rCGKENTCMS_PROD01Entities.SaveChanges();
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        public void RemoveCustMessage(
            QueueType queueType,
            string server,
            string dbInstance,
            string kenticoID,
            int sqlCommandTimeout,
             EnvEnum env = EnvEnum.DEV)
        {
            string queueTypeDesc = TE3EEntityExt.GetEnumDescription(queueType);

            using (var objStreamReader = File.OpenText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $"datasource/rcgkentcms/datascripts/RemoveCustMessage.sql")))
            {
                string sqlStmt = objStreamReader.ReadToEnd();

                sqlStmt = sqlStmt.Replace("@server", server);
                sqlStmt = sqlStmt.Replace("@instance", dbInstance);
                sqlStmt = sqlStmt.Replace("@kenticoID", kenticoID);
                sqlStmt = sqlStmt.Replace("@queueType", queueTypeDesc);

                SqlScriptExecutionNoReturn(sqlStmt, sqlCommandTimeout, env);
            }
        }

        public void UpdateCustomerMessage(CMSCustomerProfile cMSJob, QueueType queueType, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        {
            string queueTypeDesc = TE3EEntityExt.GetEnumDescription(queueType);

            switch (env)
            {
                case EnvEnum.DEV:
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
                    break;
                case EnvEnum.UAT:
                    {
                        using (RCGKENTCMS_UAT01Entities rCGKENTCMS_UAT01Entities = new RCGKENTCMS_UAT01Entities())
                        {
                            rCGKENTCMS_UAT01Entities.Database.CommandTimeout = sqlCommandTimeout;

                            #region update assignment

                            var ocustomer = rCGKENTCMS_UAT01Entities.CMSCustomerProfiles.Where(x => !(x.IsProcessed ?? false) && x.KenticoID == cMSJob.KenticoID && (x.QueueType.ToUpper() == queueTypeDesc)).FirstOrDefault();

                            if (ocustomer != null)
                            {
                                ocustomer.IsProcessed = true;
                                ocustomer.ProcessedDate = DateTime.Now;
                            }
                            rCGKENTCMS_UAT01Entities.SaveChanges();
                        }
                    }
                    break;
                case EnvEnum.STAGING:
                    {
                        using (RCGKENTCMS_STAGING01Entities rCGKENTCMS_STAGING01Entities = new RCGKENTCMS_STAGING01Entities())
                        {
                            rCGKENTCMS_STAGING01Entities.Database.CommandTimeout = sqlCommandTimeout;


                            var ocustomer = rCGKENTCMS_STAGING01Entities.CMSCustomerProfiles.Where(x => !(x.IsProcessed ?? false) && x.KenticoID == cMSJob.KenticoID && (x.QueueType.ToUpper() == queueTypeDesc)).FirstOrDefault();

                            if (ocustomer != null)
                            {
                                ocustomer.IsProcessed = true;
                                ocustomer.ProcessedDate = DateTime.Now;
                            }
                            rCGKENTCMS_STAGING01Entities.SaveChanges();
                        }
                    }
                    break;
                case EnvEnum.PROD:
                    {
                        using (RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities())
                        {
                            rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;

                            #region update assignment

                            var ocustomer = rCGKENTCMS_PROD01Entities.CMSCustomerProfiles.Where(x => !(x.IsProcessed ?? false) && x.KenticoID == cMSJob.KenticoID && (x.QueueType.ToUpper() == queueTypeDesc)).FirstOrDefault();

                            if (ocustomer != null)
                            {
                                ocustomer.IsProcessed = true;
                                ocustomer.ProcessedDate = DateTime.Now;
                            }
                            rCGKENTCMS_PROD01Entities.SaveChanges();
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        public void UpdateCustMessageErr(
            QueueType queueType,
            string server,
            string dbInstance,
            string kenticoID,
            string errMsg,
            int sqlCommandTimeout,
             EnvEnum env = EnvEnum.DEV)
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

                SqlScriptExecutionNoReturn(sqlStmt, sqlCommandTimeout, env);
            }
        }

        #endregion customer profile data access methods


        #region Kentico customer Copy data access methods

        public CustomerProfile GetKenticoCustomerCopy(string kenticoId, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        {
            CustomerProfile customerProfile = null;
            var kenticoAssignmentCopy = SqlDBEntity_Get<CMSKenticoCustomerCopy>(sqlCommandTimeout, env).FirstOrDefault(x => x.KenticoId.Equals(kenticoId));
            if (kenticoAssignmentCopy != null)
            {
                customerProfile = JsonConvert.DeserializeObject<CustomerProfile>(kenticoAssignmentCopy.CustomerImageJson);
            }
            return customerProfile;
        }


        public void AddOrUpdateKenticoCustomerCopy(CustomerProfile customerProfile, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        {

            switch (env)
            {
                case EnvEnum.DEV:
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
                    break;
                case EnvEnum.UAT:
                    {
                        using (RCGKENTCMS_UAT01Entities rCGKENTCMS_UAT01Entities = new RCGKENTCMS_UAT01Entities())
                        {
                            rCGKENTCMS_UAT01Entities.Database.CommandTimeout = sqlCommandTimeout;

                            var kenticoAssignmentCopy = rCGKENTCMS_UAT01Entities.CMSKenticoCustomerCopies.FirstOrDefault(x => x.KenticoId.Equals(customerProfile.kenticoId));
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
                                rCGKENTCMS_UAT01Entities.CMSKenticoCustomerCopies.Add(kenticoAssignmentCopy);
                            }
                            else
                            {
                                kenticoAssignmentCopy.KenticoId = customerProfile.kenticoId;
                                kenticoAssignmentCopy.E3EID = customerProfile.e3EId;
                                //kenticoAssignmentCopy.MatterIndex = customerProfile.E3EID;
                                kenticoAssignmentCopy.CustomerImageJson = JsonConvert.SerializeObject(customerProfile);
                                kenticoAssignmentCopy.Timestamp = DateTime.Now;
                            }
                            rCGKENTCMS_UAT01Entities.SaveChanges();
                        }
                    }
                    break;
                case EnvEnum.STAGING:
                    {
                        using (RCGKENTCMS_STAGING01Entities rCGKENTCMS_STAGING01Entities = new RCGKENTCMS_STAGING01Entities())
                        {
                            rCGKENTCMS_STAGING01Entities.Database.CommandTimeout = sqlCommandTimeout;

                            var kenticoAssignmentCopy = rCGKENTCMS_STAGING01Entities.CMSKenticoCustomerCopies.FirstOrDefault(x => x.KenticoId.Equals(customerProfile.kenticoId));
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
                                rCGKENTCMS_STAGING01Entities.CMSKenticoCustomerCopies.Add(kenticoAssignmentCopy);
                            }
                            else
                            {
                                kenticoAssignmentCopy.KenticoId = customerProfile.kenticoId;
                                kenticoAssignmentCopy.E3EID = customerProfile.e3EId;
                                //kenticoAssignmentCopy.MatterIndex = customerProfile.E3EID;
                                kenticoAssignmentCopy.CustomerImageJson = JsonConvert.SerializeObject(customerProfile);
                                kenticoAssignmentCopy.Timestamp = DateTime.Now;
                            }
                            rCGKENTCMS_STAGING01Entities.SaveChanges();
                        }
                    }
                    break;
                case EnvEnum.PROD:
                    {
                        using (RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities())
                        {
                            rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;

                            var kenticoAssignmentCopy = rCGKENTCMS_PROD01Entities.CMSKenticoCustomerCopies.FirstOrDefault(x => x.KenticoId.Equals(customerProfile.kenticoId));
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
                                rCGKENTCMS_PROD01Entities.CMSKenticoCustomerCopies.Add(kenticoAssignmentCopy);
                            }
                            else
                            {
                                kenticoAssignmentCopy.KenticoId = customerProfile.kenticoId;
                                kenticoAssignmentCopy.E3EID = customerProfile.e3EId;
                                //kenticoAssignmentCopy.MatterIndex = customerProfile.E3EID;
                                kenticoAssignmentCopy.CustomerImageJson = JsonConvert.SerializeObject(customerProfile);
                                kenticoAssignmentCopy.Timestamp = DateTime.Now;
                            }
                            rCGKENTCMS_PROD01Entities.SaveChanges();
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region kentico assignment and customer relationship data access methods

        public void AddOrUpdateKenticoAssignmentRel(CMSKenticoAssignmentRel kentico3ERel, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        {
            switch (env)
            {
                case EnvEnum.DEV:
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
                    break;
                case EnvEnum.UAT:
                    {
                        using (RCGKENTCMS_UAT01Entities rCGKENTCMS_UAT01Entities = new RCGKENTCMS_UAT01Entities())
                        {
                            rCGKENTCMS_UAT01Entities.Database.CommandTimeout = sqlCommandTimeout;
                            var k3eMattRels = rCGKENTCMS_UAT01Entities.CMSKenticoAssignmentRels.Where(k => k.ClientIndex == kentico3ERel.ClientIndex || k.ClientNumber == kentico3ERel.ClientNumber);

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
                                rCGKENTCMS_UAT01Entities.CMSKenticoAssignmentRels.Add(kentico3ERel);
                            }

                            rCGKENTCMS_UAT01Entities.SaveChanges();
                        }
                    }
                    break;
                case EnvEnum.STAGING:
                    {
                        using (RCGKENTCMS_STAGING01Entities rCGKENTCMS_STAGING01Entities = new RCGKENTCMS_STAGING01Entities())
                        {
                            rCGKENTCMS_STAGING01Entities.Database.CommandTimeout = sqlCommandTimeout;
                            var k3eMattRels = rCGKENTCMS_STAGING01Entities.CMSKenticoAssignmentRels.Where(k => k.ClientIndex == kentico3ERel.ClientIndex || k.ClientNumber == kentico3ERel.ClientNumber);

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
                                rCGKENTCMS_STAGING01Entities.CMSKenticoAssignmentRels.Add(kentico3ERel);
                            }

                            rCGKENTCMS_STAGING01Entities.SaveChanges();
                        }
                    }
                    break;
                case EnvEnum.PROD:
                    {
                        using (RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities())
                        {
                            rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                            var k3eMattRels = rCGKENTCMS_PROD01Entities.CMSKenticoAssignmentRels.Where(k => k.ClientIndex == kentico3ERel.ClientIndex || k.ClientNumber == kentico3ERel.ClientNumber);

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
                                rCGKENTCMS_PROD01Entities.CMSKenticoAssignmentRels.Add(kentico3ERel);
                            }

                            rCGKENTCMS_PROD01Entities.SaveChanges();
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        public CMSKenticoAssignmentRel GetKenticoAssignmentRel(int matterIndex, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        {
            CMSKenticoAssignmentRel kentico3ERels = new CMSKenticoAssignmentRel();
            var results = SqlDBEntity_Get<CMSKenticoAssignmentRel>(sqlCommandTimeout, env).Where(k => k.MatterIndex == matterIndex).OrderByDescending(x => x.TimeStamp).Select(k => k).ToList();
            kentico3ERels = results.Count() > 0 ? results.First() : null;
            return kentico3ERels;
        }


        public CMSOfficeEmailLookup GetOfficeEmailsByOfficeCode(string OfficeCode, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        {
            CMSOfficeEmailLookup cMSOfficeEmailLookup = SqlDBEntity_Get<CMSOfficeEmailLookup>(sqlCommandTimeout, env).Where(x => x.Code == OfficeCode).FirstOrDefault();

            return cMSOfficeEmailLookup;
        }

        public void AddOrUpdateKenAssignSubEntRel(CMSKenticoSubEntityRel kenticoSubEntityRel, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        {
            switch (env)
            {
                case EnvEnum.DEV:
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
                    break;
                case EnvEnum.UAT:
                    {
                        using (RCGKENTCMS_UAT01Entities rCGKENTCMS_UAT01Entities = new RCGKENTCMS_UAT01Entities())
                        {
                            rCGKENTCMS_UAT01Entities.Database.CommandTimeout = sqlCommandTimeout;
                            CMSKenticoSubEntityRel k3eMattRel = null;

                            var query = rCGKENTCMS_UAT01Entities.CMSKenticoSubEntityRels.AsQueryable();


                            if (!string.IsNullOrEmpty(kenticoSubEntityRel.KenticoId) && !string.IsNullOrEmpty(kenticoSubEntityRel.SubKenticoId))
                            {
                                k3eMattRel = rCGKENTCMS_UAT01Entities.CMSKenticoSubEntityRels.Where(k => k.KenticoId == kenticoSubEntityRel.KenticoId && k.SubKenticoId == kenticoSubEntityRel.SubKenticoId && k.EntityType == kenticoSubEntityRel.EntityType).OrderByDescending(x => x.TimeStamp).FirstOrDefault();
                            }
                            if (k3eMattRel == null)
                            {
                                k3eMattRel = rCGKENTCMS_UAT01Entities.CMSKenticoSubEntityRels.Where(k => k.MatterIndex == kenticoSubEntityRel.MatterIndex && k.EntityKey == kenticoSubEntityRel.EntityKey && k.EntityType == kenticoSubEntityRel.EntityType).OrderByDescending(x => x.TimeStamp).FirstOrDefault();
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
                                rCGKENTCMS_UAT01Entities.CMSKenticoSubEntityRels.Add(kenticoSubEntityRel);
                            }

                            rCGKENTCMS_UAT01Entities.SaveChanges();
                        }
                    }
                    break;
                case EnvEnum.STAGING:
                    {
                        using (RCGKENTCMS_STAGING01Entities rCGKENTCMS_STAGING01Entities = new RCGKENTCMS_STAGING01Entities())
                        {
                            rCGKENTCMS_STAGING01Entities.Database.CommandTimeout = sqlCommandTimeout;
                            CMSKenticoSubEntityRel k3eMattRel = null;

                            var query = rCGKENTCMS_STAGING01Entities.CMSKenticoSubEntityRels.AsQueryable();


                            if (!string.IsNullOrEmpty(kenticoSubEntityRel.KenticoId) && !string.IsNullOrEmpty(kenticoSubEntityRel.SubKenticoId))
                            {
                                k3eMattRel = rCGKENTCMS_STAGING01Entities.CMSKenticoSubEntityRels.Where(k => k.KenticoId == kenticoSubEntityRel.KenticoId && k.SubKenticoId == kenticoSubEntityRel.SubKenticoId && k.EntityType == kenticoSubEntityRel.EntityType).OrderByDescending(x => x.TimeStamp).FirstOrDefault();
                            }
                            if (k3eMattRel == null)
                            {
                                k3eMattRel = rCGKENTCMS_STAGING01Entities.CMSKenticoSubEntityRels.Where(k => k.MatterIndex == kenticoSubEntityRel.MatterIndex && k.EntityKey == kenticoSubEntityRel.EntityKey && k.EntityType == kenticoSubEntityRel.EntityType).OrderByDescending(x => x.TimeStamp).FirstOrDefault();
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
                                rCGKENTCMS_STAGING01Entities.CMSKenticoSubEntityRels.Add(kenticoSubEntityRel);
                            }

                            rCGKENTCMS_STAGING01Entities.SaveChanges();
                        }
                    }
                    break;
                case EnvEnum.PROD:
                    {
                        using (RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities())
                        {
                            rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                            CMSKenticoSubEntityRel k3eMattRel = null;

                            var query = rCGKENTCMS_PROD01Entities.CMSKenticoSubEntityRels.AsQueryable();


                            if (!string.IsNullOrEmpty(kenticoSubEntityRel.KenticoId) && !string.IsNullOrEmpty(kenticoSubEntityRel.SubKenticoId))
                            {
                                k3eMattRel = rCGKENTCMS_PROD01Entities.CMSKenticoSubEntityRels.Where(k => k.KenticoId == kenticoSubEntityRel.KenticoId && k.SubKenticoId == kenticoSubEntityRel.SubKenticoId && k.EntityType == kenticoSubEntityRel.EntityType).OrderByDescending(x => x.TimeStamp).FirstOrDefault();
                            }
                            if (k3eMattRel == null)
                            {
                                k3eMattRel = rCGKENTCMS_PROD01Entities.CMSKenticoSubEntityRels.Where(k => k.MatterIndex == kenticoSubEntityRel.MatterIndex && k.EntityKey == kenticoSubEntityRel.EntityKey && k.EntityType == kenticoSubEntityRel.EntityType).OrderByDescending(x => x.TimeStamp).FirstOrDefault();
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
                                rCGKENTCMS_PROD01Entities.CMSKenticoSubEntityRels.Add(kenticoSubEntityRel);
                            }

                            rCGKENTCMS_PROD01Entities.SaveChanges();
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        public CMSKenticoSubEntityRel GetKenAssignSubEntRelByMatterIndex(int matterIndex, string SubEntityKey, KenticoSubEntityRelEnum SubEntityType, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        {
            CMSKenticoSubEntityRel kentico3ERels = new CMSKenticoSubEntityRel();
            kentico3ERels = SqlDBEntity_Get<CMSKenticoSubEntityRel>(sqlCommandTimeout, env).Where(k => k.MatterIndex == matterIndex && k.EntityType == SubEntityType.ToString() && k.EntityKey == SubEntityKey).OrderByDescending(x => x.TimeStamp).FirstOrDefault();
            return kentico3ERels;
        }
        public List<CMSKenticoSubEntityRel> GetKenAssignRefrenceNumberRelByKenticoId(string kenticoId, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        {
            List<CMSKenticoSubEntityRel> kentico3ERels = new List<CMSKenticoSubEntityRel>();

            kentico3ERels = SqlDBEntity_Get<CMSKenticoSubEntityRel>(sqlCommandTimeout, env).Where(k => k.KenticoId == kenticoId && k.EntityType == KenticoSubEntityRelEnum.ReferenceNumbers.ToString()).OrderByDescending(x => x.TimeStamp).ToList();
            return kentico3ERels;
        }

        public CMSKenticoSubEntityRel GetKenAssignSubEntRelByKenticoId(string kenticoId, string SubKenticoId, KenticoSubEntityRelEnum SubEntityType, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        {
            CMSKenticoSubEntityRel kentico3ERels = new CMSKenticoSubEntityRel();

            kentico3ERels = SqlDBEntity_Get<CMSKenticoSubEntityRel>(sqlCommandTimeout, env).Where(k => k.KenticoId == kenticoId && k.SubKenticoId == SubKenticoId && k.EntityType == SubEntityType.ToString()).OrderByDescending(x => x.TimeStamp).FirstOrDefault();
            return kentico3ERels;
        }

        public void AddOrUpdateKenticoCustomerRel(CMSKenticoCustomerRel kenticoCustomerRel, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        {
            switch (env)
            {
                case EnvEnum.DEV:
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
                    break;
                case EnvEnum.UAT:
                    {
                        using (RCGKENTCMS_UAT01Entities rCGKENTCMS_UAT01Entities = new RCGKENTCMS_UAT01Entities())
                        {
                            rCGKENTCMS_UAT01Entities.Database.CommandTimeout = sqlCommandTimeout;
                            var kenticoCustomers = rCGKENTCMS_UAT01Entities.CMSKenticoCustomerRels.Where(k => k.ClientNumber == kenticoCustomerRel.ClientNumber);

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
                                rCGKENTCMS_UAT01Entities.CMSKenticoCustomerRels.Add(kenticoCustomerRel);
                            }

                            rCGKENTCMS_UAT01Entities.SaveChanges();
                        }
                    }
                    break;
                case EnvEnum.STAGING:
                    {
                        using (RCGKENTCMS_STAGING01Entities rCGKENTCMS_STAGING01Entities = new RCGKENTCMS_STAGING01Entities())
                        {
                            rCGKENTCMS_STAGING01Entities.Database.CommandTimeout = sqlCommandTimeout;
                            var kenticoCustomers = rCGKENTCMS_STAGING01Entities.CMSKenticoCustomerRels.Where(k => k.ClientNumber == kenticoCustomerRel.ClientNumber);

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
                                rCGKENTCMS_STAGING01Entities.CMSKenticoCustomerRels.Add(kenticoCustomerRel);
                            }

                            rCGKENTCMS_STAGING01Entities.SaveChanges();
                        }
                    }
                    break;
                case EnvEnum.PROD:
                    {
                        using (RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities())
                        {
                            rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                            var kenticoCustomers = rCGKENTCMS_PROD01Entities.CMSKenticoCustomerRels.Where(k => k.ClientNumber == kenticoCustomerRel.ClientNumber);

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
                                rCGKENTCMS_PROD01Entities.CMSKenticoCustomerRels.Add(kenticoCustomerRel);
                            }

                            rCGKENTCMS_PROD01Entities.SaveChanges();
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        public CMSKenticoCustomerRel GetKenticoCustomerRel(string cliNumber, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        {
            CMSKenticoCustomerRel kenticoCustomerRel = new CMSKenticoCustomerRel();

            var results = SqlDBEntity_Get<CMSKenticoCustomerRel>(sqlCommandTimeout, env).Where(k => k.ClientNumber == cliNumber);
            kenticoCustomerRel = results.Count() > 0 ? results.First() : null;
            return kenticoCustomerRel;
        }

        #endregion kentico assignment and customer relationship data access methods

        #endregion CMS Table SQL Actions

        #region Rimkus Connect REST API

        public IEnumerable<CMSGetLookupTypes_Result> GetLookupTypes(int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        {
            IEnumerable<CMSGetLookupTypes_Result> results = null;

            switch (env)
            {
                case EnvEnum.DEV:
                    {
                        using (RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities())
                        {
                            rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                            results = rCGKENTCMS_DEV01Entities.CMSGetLookupTypes().ToList();
                        }
                    }
                    break;
                case EnvEnum.UAT:
                    {
                        using (RCGKENTCMS_UAT01Entities rCGKENTCMS_UAT01Entities = new RCGKENTCMS_UAT01Entities())
                        {
                            rCGKENTCMS_UAT01Entities.Database.CommandTimeout = sqlCommandTimeout;
                            results = rCGKENTCMS_UAT01Entities.CMSGetLookupTypes().ToList();
                        }
                    }
                    break;
                case EnvEnum.STAGING:
                    {
                        using (RCGKENTCMS_STAGING01Entities rCGKENTCMS_STAGING01Entities = new RCGKENTCMS_STAGING01Entities())
                        {
                            rCGKENTCMS_STAGING01Entities.Database.CommandTimeout = sqlCommandTimeout;
                            results = rCGKENTCMS_STAGING01Entities.CMSGetLookupTypes().ToList();
                        }
                    }
                    break;
                case EnvEnum.PROD:
                    {
                        using (RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities())
                        {
                            rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                            results = rCGKENTCMS_PROD01Entities.CMSGetLookupTypes().ToList();
                        }
                    }
                    break;
                default:
                    break;
            }

            return results;
        }

        public List<CMSGetLookupCodes_Result> GetLookupCodes(int lookupId, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        {
            List<CMSGetLookupCodes_Result> results = null;

            var lookupTypes = GetLookupTypes(sqlCommandTimeout, env).Where(x => x.ID == lookupId);
            var lookupType = (lookupTypes != null) ? lookupTypes.First().Type : "";
            switch (env)
            {
                case EnvEnum.DEV:
                    {
                        RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities();
                        rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        results = rCGKENTCMS_DEV01Entities.CMSGetLookupCodes(lookupType).ToList();
                    }
                    break;
                case EnvEnum.UAT:
                    {
                        RCGKENTCMS_UAT01Entities rCGKENTCMS_UAT01Entities = new RCGKENTCMS_UAT01Entities();
                        rCGKENTCMS_UAT01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        results = rCGKENTCMS_UAT01Entities.CMSGetLookupCodes(lookupType).ToList();
                    }
                    break;
                case EnvEnum.STAGING:
                    {
                        RCGKENTCMS_STAGING01Entities rCGKENTCMS_STAGING01Entities = new RCGKENTCMS_STAGING01Entities();
                        rCGKENTCMS_STAGING01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        results = rCGKENTCMS_STAGING01Entities.CMSGetLookupCodes(lookupType).ToList();
                    }
                    break;
                case EnvEnum.PROD:
                    {
                        RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities();
                        rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        results = rCGKENTCMS_PROD01Entities.CMSGetLookupCodes(lookupType).ToList();
                    }
                    break;
                default:
                    break;
            }

            return results;
        }

        public CMSConvertToCliTypeByCode_Result ConvertCliTypeByCode(string cliTypeCode, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        {
            CMSConvertToCliTypeByCode_Result cliType = null;

            switch (env)
            {
                case EnvEnum.DEV:
                    {
                        RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities();
                        rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        var results = rCGKENTCMS_DEV01Entities.CMSConvertToCliTypeByCode(cliTypeCode).ToList();
                        cliType = results.Count() > 0 ? results.First() : null;
                    }
                    break;
                case EnvEnum.UAT:
                    {
                        RCGKENTCMS_UAT01Entities rCGKENTCMS_UAT01Entities = new RCGKENTCMS_UAT01Entities();
                        rCGKENTCMS_UAT01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        var results = rCGKENTCMS_UAT01Entities.CMSConvertToCliTypeByCode(cliTypeCode).ToList();
                        cliType = results.Count() > 0 ? results.First() : null;
                    }
                    break;
                case EnvEnum.STAGING:
                    {
                        RCGKENTCMS_STAGING01Entities rCGKENTCMS_STAGING01Entities = new RCGKENTCMS_STAGING01Entities();
                        rCGKENTCMS_STAGING01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        var results = rCGKENTCMS_STAGING01Entities.CMSConvertToCliTypeByCode(cliTypeCode).ToList();
                        cliType = results.Count() > 0 ? results.First() : null;
                    }
                    break;
                case EnvEnum.PROD:
                    {
                        RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities();
                        rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        var results = rCGKENTCMS_PROD01Entities.CMSConvertToCliTypeByCode(cliTypeCode).ToList();
                        cliType = results.Count() > 0 ? results.First() : null;
                    }
                    break;
                default:
                    break;
            }

            return cliType;
        }

        public List<CMSSearchTimekeepers_Result> GetTimekeepers(string name, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        {
            List<CMSSearchTimekeepers_Result> results = null;

            switch (env)
            {
                case EnvEnum.DEV:
                    {
                        RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities();
                        rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        results = rCGKENTCMS_DEV01Entities.CMSSearchTimekeepers(name).ToList();
                    }
                    break;
                case EnvEnum.UAT:
                    {
                        RCGKENTCMS_UAT01Entities rCGKENTCMS_UAT01Entities = new RCGKENTCMS_UAT01Entities();
                        rCGKENTCMS_UAT01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        results = rCGKENTCMS_UAT01Entities.CMSSearchTimekeepers(name).ToList();
                    }
                    break;
                case EnvEnum.STAGING:
                    {
                        RCGKENTCMS_STAGING01Entities rCGKENTCMS_STAGING01Entities = new RCGKENTCMS_STAGING01Entities();
                        rCGKENTCMS_STAGING01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        results = rCGKENTCMS_STAGING01Entities.CMSSearchTimekeepers(name).ToList();
                    }
                    break;
                case EnvEnum.PROD:
                    {
                        RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities();
                        rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        results = rCGKENTCMS_PROD01Entities.CMSSearchTimekeepers(name).ToList();
                    }
                    break;
                default:
                    break;
            }

            return results;
        }

        public List<CMSSearchClients_Result> GetClients(string name, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        {
            List<CMSSearchClients_Result> results = null;

            switch (env)
            {
                case EnvEnum.DEV:
                    {
                        RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities();
                        rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        results = rCGKENTCMS_DEV01Entities.CMSSearchClients(name).ToList();
                    }
                    break;
                case EnvEnum.UAT:
                    {
                        RCGKENTCMS_UAT01Entities rCGKENTCMS_UAT01Entities = new RCGKENTCMS_UAT01Entities();
                        rCGKENTCMS_UAT01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        results = rCGKENTCMS_UAT01Entities.CMSSearchClients(name).ToList();
                    }
                    break;
                case EnvEnum.STAGING:
                    {
                        RCGKENTCMS_STAGING01Entities rCGKENTCMS_STAGING01Entities = new RCGKENTCMS_STAGING01Entities();
                        rCGKENTCMS_STAGING01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        results = rCGKENTCMS_STAGING01Entities.CMSSearchClients(name).ToList();
                    }
                    break;
                case EnvEnum.PROD:
                    {
                        RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities();
                        rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        results = rCGKENTCMS_PROD01Entities.CMSSearchClients(name).ToList();
                    }
                    break;
                default:
                    break;
            }
            return results;
        }

        public List<CMSSearchEntity_Result> GetEntities(string name, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        {
            List<CMSSearchEntity_Result> results = null;

            switch (env)
            {
                case EnvEnum.DEV:
                    {
                        RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities();
                        rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        results = rCGKENTCMS_DEV01Entities.CMSSearchEntity(name).ToList();
                    }
                    break;
                case EnvEnum.UAT:
                    {
                        RCGKENTCMS_UAT01Entities rCGKENTCMS_UAT01Entities = new RCGKENTCMS_UAT01Entities();
                        rCGKENTCMS_UAT01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        results = rCGKENTCMS_UAT01Entities.CMSSearchEntity(name).ToList();
                    }
                    break;
                case EnvEnum.STAGING:
                    {
                        RCGKENTCMS_STAGING01Entities rCGKENTCMS_STAGING01Entities = new RCGKENTCMS_STAGING01Entities();
                        rCGKENTCMS_STAGING01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        results = rCGKENTCMS_STAGING01Entities.CMSSearchEntity(name).ToList();
                    }
                    break;
                case EnvEnum.PROD:
                    {
                        RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities();
                        rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        results = rCGKENTCMS_PROD01Entities.CMSSearchEntity(name).ToList();
                    }
                    break;
                default:
                    break;
            }
            return results;
        }

        public List<CMSSearchRelMatters_Result> GetRelMatters(string name, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        {
            List<CMSSearchRelMatters_Result> results = null;

            switch (env)
            {
                case EnvEnum.DEV:
                    {
                        RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities();
                        rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        results = rCGKENTCMS_DEV01Entities.CMSSearchRelMatters(name).ToList();
                    }
                    break;
                case EnvEnum.UAT:
                    {
                        RCGKENTCMS_UAT01Entities rCGKENTCMS_UAT01Entities = new RCGKENTCMS_UAT01Entities();
                        rCGKENTCMS_UAT01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        results = rCGKENTCMS_UAT01Entities.CMSSearchRelMatters(name).ToList();
                    }
                    break;
                case EnvEnum.STAGING:
                    {
                        RCGKENTCMS_STAGING01Entities rCGKENTCMS_STAGING01Entities = new RCGKENTCMS_STAGING01Entities();
                        rCGKENTCMS_STAGING01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        results = rCGKENTCMS_STAGING01Entities.CMSSearchRelMatters(name).ToList();
                    }
                    break;
                case EnvEnum.PROD:
                    {
                        RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities();
                        rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        results = rCGKENTCMS_PROD01Entities.CMSSearchRelMatters(name).ToList();
                    }
                    break;
                default:
                    break;
            }
            return results;
        }

        public List<CMSGetClientsByType_Result> GetClientsByType(int lookupId, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        {
            List<CMSGetClientsByType_Result> results = null;

            switch (env)
            {
                case EnvEnum.DEV:
                    {
                        RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities();
                        rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        results = rCGKENTCMS_DEV01Entities.CMSGetClientsByType(lookupId.ToString()).ToList();
                    }
                    break;
                case EnvEnum.UAT:
                    {
                        RCGKENTCMS_UAT01Entities rCGKENTCMS_UAT01Entities = new RCGKENTCMS_UAT01Entities();
                        rCGKENTCMS_UAT01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        results = rCGKENTCMS_UAT01Entities.CMSGetClientsByType(lookupId.ToString()).ToList();
                    }
                    break;
                case EnvEnum.STAGING:
                    {
                        RCGKENTCMS_STAGING01Entities rCGKENTCMS_STAGING01Entities = new RCGKENTCMS_STAGING01Entities();
                        rCGKENTCMS_STAGING01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        results = rCGKENTCMS_STAGING01Entities.CMSGetClientsByType(lookupId.ToString()).ToList();
                    }
                    break;
                case EnvEnum.PROD:
                    {
                        RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities();
                        rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        results = rCGKENTCMS_PROD01Entities.CMSGetClientsByType(lookupId.ToString()).ToList();
                    }
                    break;
                default:
                    break;
            }
            return results;
        }

        public List<CMSGetClientMatters_Result> GetClientMatters(int clientNo, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        {
            List<CMSGetClientMatters_Result> results = null;

            switch (env)
            {
                case EnvEnum.DEV:
                    {
                        RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities();
                        rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        results = rCGKENTCMS_DEV01Entities.CMSGetClientMatters(clientNo.ToString("D7")).ToList();
                    }
                    break;
                case EnvEnum.UAT:
                    {
                        RCGKENTCMS_UAT01Entities rCGKENTCMS_UAT01Entities = new RCGKENTCMS_UAT01Entities();
                        rCGKENTCMS_UAT01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        results = rCGKENTCMS_UAT01Entities.CMSGetClientMatters(clientNo.ToString("D7")).ToList();
                    }
                    break;
                case EnvEnum.STAGING:
                    {
                        RCGKENTCMS_STAGING01Entities rCGKENTCMS_STAGING01Entities = new RCGKENTCMS_STAGING01Entities();
                        rCGKENTCMS_STAGING01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        results = rCGKENTCMS_STAGING01Entities.CMSGetClientMatters(clientNo.ToString("D7")).ToList();
                    }
                    break;
                case EnvEnum.PROD:
                    {
                        RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities();
                        rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        results = rCGKENTCMS_PROD01Entities.CMSGetClientMatters(clientNo.ToString("D7")).ToList();
                    }
                    break;
                default:
                    break;
            }
            return results;
        }

        public List<CMSGetClientMattersByRelSiteEmail_Result> GetClientMattersByEmail(string email, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        {
            List<CMSGetClientMattersByRelSiteEmail_Result> results = null;

            switch (env)
            {
                case EnvEnum.DEV:
                    {
                        RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities();
                        rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        results = rCGKENTCMS_DEV01Entities.CMSGetClientMattersByRelSiteEmail(email).ToList();
                    }
                    break;
                case EnvEnum.UAT:
                    {
                        RCGKENTCMS_UAT01Entities rCGKENTCMS_UAT01Entities = new RCGKENTCMS_UAT01Entities();
                        rCGKENTCMS_UAT01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        results = rCGKENTCMS_UAT01Entities.CMSGetClientMattersByRelSiteEmail(email).ToList();
                    }
                    break;
                case EnvEnum.STAGING:
                    {
                        RCGKENTCMS_STAGING01Entities rCGKENTCMS_STAGING01Entities = new RCGKENTCMS_STAGING01Entities();
                        rCGKENTCMS_STAGING01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        results = rCGKENTCMS_STAGING01Entities.CMSGetClientMattersByRelSiteEmail(email).ToList();
                    }
                    break;
                case EnvEnum.PROD:
                    {
                        RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities();
                        rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        results = rCGKENTCMS_PROD01Entities.CMSGetClientMattersByRelSiteEmail(email).ToList();
                    }
                    break;
                default:
                    break;
            }

            return results;
        }

        //public List<CMSGetAllClientMatters_Result> GetAllClientMatters(int offset, int limit, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        //{
        //    List<CMSGetAllClientMatters_Result> results = null;

        //    switch (env)
        //    {
        //        case EnvEnum.DEV:
        //            {
        //                RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities();
        //                rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
        //                results = rCGKENTCMS_DEV01Entities.CMSGetAllClientMatters(offset, limit).ToList();
        //            }
        //            break;
        //        case EnvEnum.UAT:
        //            {
        //                RCGKENTCMS_UAT01Entities rCGKENTCMS_UAT01Entities = new RCGKENTCMS_UAT01Entities();
        //                rCGKENTCMS_UAT01Entities.Database.CommandTimeout = sqlCommandTimeout;
        //                results = rCGKENTCMS_UAT01Entities.CMSGetAllClientMatters(offset, limit).ToList();
        //            }
        //            break;
        //        case EnvEnum.STAGING:
        //            {
        //                RCGKENTCMS_STAGING01Entities rCGKENTCMS_STAGING01Entities = new RCGKENTCMS_STAGING01Entities();
        //                rCGKENTCMS_STAGING01Entities.Database.CommandTimeout = sqlCommandTimeout;
        //                results = rCGKENTCMS_STAGING01Entities.CMSGetAllClientMatters(offset, limit).ToList();
        //            }
        //            break;
        //        case EnvEnum.PROD:
        //            {
        //                RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities();
        //                rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
        //                results = rCGKENTCMS_PROD01Entities.CMSGetAllClientMatters(offset, limit).ToList();
        //            }
        //            break;
        //        default:
        //            break;
        //    }
        //    return results;
        //}
        public List<CMSGetAllClientMatters_V3_Result> GetAllClientMatters_V3(string status, string search, string searchcolumn, string from, string to, string email, string clientNumber, int offset, int limit, out int totalCountOut, out int filteredCountOut, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        {
            var fromdate = from.ToDateTime() /*?? DateTime.UtcNow.AddDays(-30).Date*/;
            var todate = to.ToDateTime() /*?? DateTime.UtcNow.Date*/;

            List<CMSGetAllClientMatters_V3_Result> results = null;
            ObjectParameter totalCount = new ObjectParameter(nameof(totalCount), typeof(int));
            ObjectParameter filteredCount = new ObjectParameter(nameof(filteredCount), typeof(int));
            switch (env)
            {
                case EnvEnum.DEV:
                    {
                        RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities();
                        rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        results = rCGKENTCMS_DEV01Entities.CMSGetAllClientMatters_V3(offset, limit, status, search, searchcolumn, fromdate, todate, email, clientNumber, totalCount, filteredCount).ToList();
                    }
                    break;
                case EnvEnum.UAT:
                    {
                        RCGKENTCMS_UAT01Entities rCGKENTCMS_UAT01Entities = new RCGKENTCMS_UAT01Entities();
                        rCGKENTCMS_UAT01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        results = rCGKENTCMS_UAT01Entities.CMSGetAllClientMatters_V3(offset, limit, status, search, searchcolumn, fromdate, todate, email, clientNumber, totalCount, filteredCount).ToList();
                    }
                    break;
                case EnvEnum.STAGING:
                    {
                        RCGKENTCMS_STAGING01Entities rCGKENTCMS_STAGING01Entities = new RCGKENTCMS_STAGING01Entities();
                        rCGKENTCMS_STAGING01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        results = rCGKENTCMS_STAGING01Entities.CMSGetAllClientMatters_V3(offset, limit, status, search, searchcolumn, fromdate, todate, email, clientNumber, totalCount, filteredCount).ToList();
                    }
                    break;
                case EnvEnum.PROD:
                    {
                        RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities();
                        rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        results = rCGKENTCMS_PROD01Entities.CMSGetAllClientMatters_V3(offset, limit, status, search, searchcolumn, fromdate, todate, email, clientNumber, totalCount, filteredCount).ToList();
                    }
                    break;
                default:
                    break;
            }
            totalCountOut = Convert.ToInt32(totalCount.Value ?? 0);
            filteredCountOut = Convert.ToInt32(filteredCount.Value ?? 0);
            return results;
        }
        public CMSGetMatterDetails_Result GetMatterDetails(int mattIndex, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        {
            List<CMSGetMatterDetails_Result> results = null;

            switch (env)
            {
                case EnvEnum.DEV:
                    {
                        RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities();
                        rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        results = rCGKENTCMS_DEV01Entities.CMSGetMatterDetails(mattIndex.ToString()).ToList();
                    }
                    break;
                case EnvEnum.UAT:
                    {
                        RCGKENTCMS_UAT01Entities rCGKENTCMS_UAT01Entities = new RCGKENTCMS_UAT01Entities();
                        rCGKENTCMS_UAT01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        results = rCGKENTCMS_UAT01Entities.CMSGetMatterDetails(mattIndex.ToString()).ToList();
                    }
                    break;
                case EnvEnum.STAGING:
                    {
                        RCGKENTCMS_STAGING01Entities rCGKENTCMS_STAGING01Entities = new RCGKENTCMS_STAGING01Entities();
                        rCGKENTCMS_STAGING01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        results = rCGKENTCMS_STAGING01Entities.CMSGetMatterDetails(mattIndex.ToString()).ToList();
                    }
                    break;
                case EnvEnum.PROD:
                    {
                        RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities();
                        rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        results = rCGKENTCMS_PROD01Entities.CMSGetMatterDetails(mattIndex.ToString()).ToList();
                    }
                    break;
                default:
                    break;
            }
            if (results.Count() == 0)
                throw new AssignmentNotFoundException($"Assignment ID Not Found. No assignment with ID = {mattIndex}");

            return results.First();
        }

        public List<CMSGetMatterNotes_Result> GetMatterNotes(int mattIndex, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        {
            List<CMSGetMatterNotes_Result> results = null;

            switch (env)
            {
                case EnvEnum.DEV:
                    {
                        RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities();
                        rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        results = rCGKENTCMS_DEV01Entities.CMSGetMatterNotes(mattIndex.ToString()).ToList();
                    }
                    break;
                case EnvEnum.UAT:
                    {
                        RCGKENTCMS_UAT01Entities rCGKENTCMS_UAT01Entities = new RCGKENTCMS_UAT01Entities();
                        rCGKENTCMS_UAT01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        results = rCGKENTCMS_UAT01Entities.CMSGetMatterNotes(mattIndex.ToString()).ToList();
                    }
                    break;
                case EnvEnum.STAGING:
                    {
                        RCGKENTCMS_STAGING01Entities rCGKENTCMS_STAGING01Entities = new RCGKENTCMS_STAGING01Entities();
                        rCGKENTCMS_STAGING01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        results = rCGKENTCMS_STAGING01Entities.CMSGetMatterNotes(mattIndex.ToString()).ToList();
                    }
                    break;
                case EnvEnum.PROD:
                    {
                        RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities();
                        rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        results = rCGKENTCMS_PROD01Entities.CMSGetMatterNotes(mattIndex.ToString()).ToList();
                    }
                    break;
                default:
                    break;
            }

            return results;
        }

        public CMSGetFullMatterDetails_Result GetFullMatterDetails(int mattIndex, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        {
            List<CMSGetFullMatterDetails_Result> results = null;

            switch (env)
            {
                case EnvEnum.DEV:
                    {
                        RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities();
                        rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        results = rCGKENTCMS_DEV01Entities.CMSGetFullMatterDetails(mattIndex.ToString()).ToList();
                    }
                    break;
                case EnvEnum.UAT:
                    {
                        RCGKENTCMS_UAT01Entities rCGKENTCMS_UAT01Entities = new RCGKENTCMS_UAT01Entities();
                        rCGKENTCMS_UAT01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        results = rCGKENTCMS_UAT01Entities.CMSGetFullMatterDetails(mattIndex.ToString()).ToList();
                    }
                    break;
                case EnvEnum.STAGING:
                    {
                        RCGKENTCMS_STAGING01Entities rCGKENTCMS_STAGING01Entities = new RCGKENTCMS_STAGING01Entities();
                        rCGKENTCMS_STAGING01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        results = rCGKENTCMS_STAGING01Entities.CMSGetFullMatterDetails(mattIndex.ToString()).ToList();
                    }
                    break;
                case EnvEnum.PROD:
                    {
                        RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities();
                        rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        results = rCGKENTCMS_PROD01Entities.CMSGetFullMatterDetails(mattIndex.ToString()).ToList();
                    }
                    break;
                default:
                    break;
            }

            if (results.Count() == 0)
                throw new AssignmentNotFoundException($"Assignment ID Not Found. No assignment with ID = {mattIndex}");

            return results.First();
        }

        public CMSGetFullMatterOrderingClientDetails_Result GetFullMatterOrderingClientDetails(int mattIndex, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        {
            List<CMSGetFullMatterOrderingClientDetails_Result> results = null;

            switch (env)
            {
                case EnvEnum.DEV:
                    {
                        RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities();
                        rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        results = rCGKENTCMS_DEV01Entities.CMSGetFullMatterOrderingClientDetails(mattIndex.ToString()).ToList();
                    }
                    break;
                case EnvEnum.UAT:
                    {
                        RCGKENTCMS_UAT01Entities rCGKENTCMS_UAT01Entities = new RCGKENTCMS_UAT01Entities();
                        rCGKENTCMS_UAT01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        results = rCGKENTCMS_UAT01Entities.CMSGetFullMatterOrderingClientDetails(mattIndex.ToString()).ToList();
                    }
                    break;
                case EnvEnum.STAGING:
                    {
                        RCGKENTCMS_STAGING01Entities rCGKENTCMS_STAGING01Entities = new RCGKENTCMS_STAGING01Entities();
                        rCGKENTCMS_STAGING01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        results = rCGKENTCMS_STAGING01Entities.CMSGetFullMatterOrderingClientDetails(mattIndex.ToString()).ToList();
                    }
                    break;
                case EnvEnum.PROD:
                    {
                        RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities();
                        rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        results = rCGKENTCMS_PROD01Entities.CMSGetFullMatterOrderingClientDetails(mattIndex.ToString()).ToList();
                    }
                    break;
                default:
                    break;
            }

            return results.First();
        }

        public List<CMSGetFullMatterIncidentLocationsDetails_Result> GetFullMatterIncidentLocationDetails(int mattIndex, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        {
            List<CMSGetFullMatterIncidentLocationsDetails_Result> results = null;

            switch (env)
            {
                case EnvEnum.DEV:
                    {
                        RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities();
                        rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        results = rCGKENTCMS_DEV01Entities.CMSGetFullMatterIncidentLocationsDetails(mattIndex.ToString()).ToList();
                    }
                    break;
                case EnvEnum.UAT:
                    {
                        RCGKENTCMS_UAT01Entities rCGKENTCMS_UAT01Entities = new RCGKENTCMS_UAT01Entities();
                        rCGKENTCMS_UAT01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        results = rCGKENTCMS_UAT01Entities.CMSGetFullMatterIncidentLocationsDetails(mattIndex.ToString()).ToList();
                    }
                    break;
                case EnvEnum.STAGING:
                    {
                        RCGKENTCMS_STAGING01Entities rCGKENTCMS_STAGING01Entities = new RCGKENTCMS_STAGING01Entities();
                        rCGKENTCMS_STAGING01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        results = rCGKENTCMS_STAGING01Entities.CMSGetFullMatterIncidentLocationsDetails(mattIndex.ToString()).ToList();
                    }
                    break;
                case EnvEnum.PROD:
                    {
                        RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities();
                        rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        results = rCGKENTCMS_PROD01Entities.CMSGetFullMatterIncidentLocationsDetails(mattIndex.ToString()).ToList();
                    }
                    break;
                default:
                    break;
            }
            return results;
        }

        public List<CMSGetFullMatterCoConsultantDetails_Result> GetFullMatterCoConsultantDetails(int mattIndex, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        {
            List<CMSGetFullMatterCoConsultantDetails_Result> results = null;

            switch (env)
            {
                case EnvEnum.DEV:
                    {
                        RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities();
                        rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        results = rCGKENTCMS_DEV01Entities.CMSGetFullMatterCoConsultantDetails(mattIndex.ToString()).ToList();
                    }
                    break;
                case EnvEnum.UAT:
                    {
                        RCGKENTCMS_UAT01Entities rCGKENTCMS_UAT01Entities = new RCGKENTCMS_UAT01Entities();
                        rCGKENTCMS_UAT01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        results = rCGKENTCMS_UAT01Entities.CMSGetFullMatterCoConsultantDetails(mattIndex.ToString()).ToList();
                    }
                    break;
                case EnvEnum.STAGING:
                    {
                        RCGKENTCMS_STAGING01Entities rCGKENTCMS_STAGING01Entities = new RCGKENTCMS_STAGING01Entities();
                        rCGKENTCMS_STAGING01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        results = rCGKENTCMS_STAGING01Entities.CMSGetFullMatterCoConsultantDetails(mattIndex.ToString()).ToList();
                    }
                    break;
                case EnvEnum.PROD:
                    {
                        RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities();
                        rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        results = rCGKENTCMS_PROD01Entities.CMSGetFullMatterCoConsultantDetails(mattIndex.ToString()).ToList();
                    }
                    break;
                default:
                    break;
            }
            return results;
        }

        public List<CMSGetFullMatterPayorDetails_Result> GetFullMatterPayorDetails(int mattIndex, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        {
            List<CMSGetFullMatterPayorDetails_Result> results = null;

            switch (env)
            {
                case EnvEnum.DEV:
                    {
                        RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities();
                        rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        results = rCGKENTCMS_DEV01Entities.CMSGetFullMatterPayorDetails(mattIndex.ToString()).ToList();
                    }
                    break;
                case EnvEnum.UAT:
                    {
                        RCGKENTCMS_UAT01Entities rCGKENTCMS_UAT01Entities = new RCGKENTCMS_UAT01Entities();
                        rCGKENTCMS_UAT01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        results = rCGKENTCMS_UAT01Entities.CMSGetFullMatterPayorDetails(mattIndex.ToString()).ToList();
                    }
                    break;
                case EnvEnum.STAGING:
                    {
                        RCGKENTCMS_STAGING01Entities rCGKENTCMS_STAGING01Entities = new RCGKENTCMS_STAGING01Entities();
                        rCGKENTCMS_STAGING01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        results = rCGKENTCMS_STAGING01Entities.CMSGetFullMatterPayorDetails(mattIndex.ToString()).ToList();
                    }
                    break;
                case EnvEnum.PROD:
                    {
                        RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities();
                        rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        results = rCGKENTCMS_PROD01Entities.CMSGetFullMatterPayorDetails(mattIndex.ToString()).ToList();
                    }
                    break;
                default:
                    break;
            }
            return results;
        }

        public List<CMSGetFullMatterAdditionalPartiesDetails_Result> GetFullMatterAdditionalPartiesDetails(int mattIndex, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        {
            List<CMSGetFullMatterAdditionalPartiesDetails_Result> results = null;

            switch (env)
            {
                case EnvEnum.DEV:
                    {
                        RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities();
                        rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        results = rCGKENTCMS_DEV01Entities.CMSGetFullMatterAdditionalPartiesDetails(mattIndex.ToString()).ToList();
                    }
                    break;
                case EnvEnum.UAT:
                    {
                        RCGKENTCMS_UAT01Entities rCGKENTCMS_UAT01Entities = new RCGKENTCMS_UAT01Entities();
                        rCGKENTCMS_UAT01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        results = rCGKENTCMS_UAT01Entities.CMSGetFullMatterAdditionalPartiesDetails(mattIndex.ToString()).ToList();
                    }
                    break;
                case EnvEnum.STAGING:
                    {
                        RCGKENTCMS_STAGING01Entities rCGKENTCMS_STAGING01Entities = new RCGKENTCMS_STAGING01Entities();
                        rCGKENTCMS_STAGING01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        results = rCGKENTCMS_STAGING01Entities.CMSGetFullMatterAdditionalPartiesDetails(mattIndex.ToString()).ToList();
                    }
                    break;
                case EnvEnum.PROD:
                    {
                        RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities();
                        rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        results = rCGKENTCMS_PROD01Entities.CMSGetFullMatterAdditionalPartiesDetails(mattIndex.ToString()).ToList();
                    }
                    break;
                default:
                    break;
            }
            return results;
        }

        public List<CMSGetOfficeAndTpk_Result> GetCMSOfficeAndTpk(string county, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        {
            List<CMSGetOfficeAndTpk_Result> results = null;

            switch (env)
            {
                case EnvEnum.DEV:
                    {
                        RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities();
                        rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        results = rCGKENTCMS_DEV01Entities.CMSGetOfficeAndTpk(county).ToList();
                    }
                    break;
                case EnvEnum.UAT:
                    {
                        RCGKENTCMS_UAT01Entities rCGKENTCMS_UAT01Entities = new RCGKENTCMS_UAT01Entities();
                        rCGKENTCMS_UAT01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        results = rCGKENTCMS_UAT01Entities.CMSGetOfficeAndTpk(county).ToList();
                    }
                    break;
                case EnvEnum.STAGING:
                    {
                        RCGKENTCMS_STAGING01Entities rCGKENTCMS_STAGING01Entities = new RCGKENTCMS_STAGING01Entities();
                        rCGKENTCMS_STAGING01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        results = rCGKENTCMS_STAGING01Entities.CMSGetOfficeAndTpk(county).ToList();
                    }
                    break;
                case EnvEnum.PROD:
                    {
                        RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities();
                        rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        results = rCGKENTCMS_PROD01Entities.CMSGetOfficeAndTpk(county).ToList();
                    }
                    break;
                default:
                    break;
            }

            return results;
        }

        public List<CMSGetOfficeAndTpkByCounty_Result> GetCMSOfficeAndTpkByCounty(string county, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        {
            List<CMSGetOfficeAndTpkByCounty_Result> results = null;

            switch (env)
            {
                case EnvEnum.DEV:
                    {
                        RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities();
                        rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        results = rCGKENTCMS_DEV01Entities.CMSGetOfficeAndTpkByCounty(county).ToList();
                    }
                    break;
                case EnvEnum.UAT:
                    {
                        RCGKENTCMS_UAT01Entities rCGKENTCMS_UAT01Entities = new RCGKENTCMS_UAT01Entities();
                        rCGKENTCMS_UAT01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        results = rCGKENTCMS_UAT01Entities.CMSGetOfficeAndTpkByCounty(county).ToList();
                    }
                    break;
                case EnvEnum.STAGING:
                    {
                        RCGKENTCMS_STAGING01Entities rCGKENTCMS_STAGING01Entities = new RCGKENTCMS_STAGING01Entities();
                        rCGKENTCMS_STAGING01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        results = rCGKENTCMS_STAGING01Entities.CMSGetOfficeAndTpkByCounty(county).ToList();
                    }
                    break;
                case EnvEnum.PROD:
                    {
                        RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities();
                        rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        results = rCGKENTCMS_PROD01Entities.CMSGetOfficeAndTpkByCounty(county).ToList();
                    }
                    break;
                default:
                    break;
            }
            return results;
        }

        public List<CMSGetOfficeAndTpkByZip_Result> GetCMSOfficeAndTpkByZipCode(string zipCode, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        {
            List<CMSGetOfficeAndTpkByZip_Result> results = null;

            switch (env)
            {
                case EnvEnum.DEV:
                    {
                        RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities();
                        rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        results = rCGKENTCMS_DEV01Entities.CMSGetOfficeAndTpkByZip(zipCode).ToList();
                    }
                    break;
                case EnvEnum.UAT:
                    {
                        RCGKENTCMS_UAT01Entities rCGKENTCMS_UAT01Entities = new RCGKENTCMS_UAT01Entities();
                        rCGKENTCMS_UAT01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        results = rCGKENTCMS_UAT01Entities.CMSGetOfficeAndTpkByZip(zipCode).ToList();
                    }
                    break;
                case EnvEnum.STAGING:
                    {
                        RCGKENTCMS_STAGING01Entities rCGKENTCMS_STAGING01Entities = new RCGKENTCMS_STAGING01Entities();
                        rCGKENTCMS_STAGING01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        results = rCGKENTCMS_STAGING01Entities.CMSGetOfficeAndTpkByZip(zipCode).ToList();
                    }
                    break;
                case EnvEnum.PROD:
                    {
                        RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities();
                        rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        results = rCGKENTCMS_PROD01Entities.CMSGetOfficeAndTpkByZip(zipCode).ToList();
                    }
                    break;
                default:
                    break;
            }
            return results;
        }

        public List<CMSGetOfficeAndTpkByKeywords_Result> GetCMSOfficeAndTpkByKeywords(string keyPhrase, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        {
            List<CMSGetOfficeAndTpkByKeywords_Result> results = null;

            switch (env)
            {
                case EnvEnum.DEV:
                    {
                        RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities();
                        rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        results = rCGKENTCMS_DEV01Entities.CMSGetOfficeAndTpkByKeywords(keyPhrase).ToList();
                    }
                    break;
                case EnvEnum.UAT:
                    {
                        RCGKENTCMS_UAT01Entities rCGKENTCMS_UAT01Entities = new RCGKENTCMS_UAT01Entities();
                        rCGKENTCMS_UAT01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        results = rCGKENTCMS_UAT01Entities.CMSGetOfficeAndTpkByKeywords(keyPhrase).ToList();
                    }
                    break;
                case EnvEnum.STAGING:
                    {
                        RCGKENTCMS_STAGING01Entities rCGKENTCMS_STAGING01Entities = new RCGKENTCMS_STAGING01Entities();
                        rCGKENTCMS_STAGING01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        results = rCGKENTCMS_STAGING01Entities.CMSGetOfficeAndTpkByKeywords(keyPhrase).ToList();
                    }
                    break;
                case EnvEnum.PROD:
                    {
                        RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities();
                        rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        results = rCGKENTCMS_PROD01Entities.CMSGetOfficeAndTpkByKeywords(keyPhrase).ToList();
                    }
                    break;
                default:
                    break;
            }

            return results;
        }

        public string GetCMSOfficeCode(string keyPhrase, string zipCode, string city, string state, string county, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        {
            string code = string.Empty;

            switch (env)
            {
                case EnvEnum.DEV:
                    {
                        RCGKENTCMS_DEV01Entities rCGKENTCMS_DEV01Entities = new RCGKENTCMS_DEV01Entities();
                        rCGKENTCMS_DEV01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        code = rCGKENTCMS_DEV01Entities.CMSGetOfficeCode(keyPhrase, zipCode, city, state, county).ToList().FirstOrDefault();
                    }
                    break;
                case EnvEnum.UAT:
                    {
                        RCGKENTCMS_UAT01Entities rCGKENTCMS_UAT01Entities = new RCGKENTCMS_UAT01Entities();
                        rCGKENTCMS_UAT01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        code = rCGKENTCMS_UAT01Entities.CMSGetOfficeCode(keyPhrase, zipCode, city, state, county).ToList().FirstOrDefault();
                    }
                    break;
                case EnvEnum.STAGING:
                    {
                        RCGKENTCMS_STAGING01Entities rCGKENTCMS_STAGING01Entities = new RCGKENTCMS_STAGING01Entities();
                        rCGKENTCMS_STAGING01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        code = rCGKENTCMS_STAGING01Entities.CMSGetOfficeCode(keyPhrase, zipCode, city, state, county).ToList().FirstOrDefault();
                    }
                    break;
                case EnvEnum.PROD:
                    {
                        RCGKENTCMS_PROD01Entities rCGKENTCMS_PROD01Entities = new RCGKENTCMS_PROD01Entities();
                        rCGKENTCMS_PROD01Entities.Database.CommandTimeout = sqlCommandTimeout;
                        code = rCGKENTCMS_PROD01Entities.CMSGetOfficeCode(keyPhrase, zipCode, city, state, county).ToList().FirstOrDefault();
                    }
                    break;
                default:
                    break;
            }

            return code;
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

    public enum EnvEnum
    {
        DEV,
        UAT,
        PROD,
        STAGING
    }
}
