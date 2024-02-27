using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TE3EEntityFramework.Data.KenticoCMS;
using TE3EEntityFramework.Data.KenticoCMS._3EProcessItem;
using TE3EEntityFramework.Data.Te3e.CMS.CustomException;
using TE3EEntityFramework.Data.Te3e.CMS.Definition;
using TE3EEntityFramework.Datasource;
using TE3EEntityFramework.Extension;

namespace TE3EEntityFramework.Client
{
    [Obsolete]
    public class Te3eCmsDbClient
    {
        //private TrackerSafeWebClient tSClient;
        //private TrackerSafeAppSetting _appSettings;

        //public Te3eCmsDbClient(TrackerSafeAppSetting appSettings)
        //{
        //    _appSettings = appSettings;
        //    tSClient = new TrackerSafeWebClient(appSettings);
        //}

        public Te3eCmsDbClient()
        {

        }

        #region Kentico CMS Te3e

        #region 3e Lookup Stmt
        public void GetEntity(int entIndex)
        {

        }
        #endregion 3e Lookup Stmt

        public KenticoCMSConfiguration GetKenticoCMSConfiguration(int sqlCommandTimeout, bool isDebug = false)
        {
            KenticoCMSConfiguration kenticoCMSConfiguration = null;

            if (isDebug)
            {
                RCGAMZN_DEV01Entities rcgamznDevEntities = new RCGAMZN_DEV01Entities();
                rcgamznDevEntities.Database.CommandTimeout = sqlCommandTimeout;
                kenticoCMSConfiguration = rcgamznDevEntities.KenticoCMSConfigurations.Select(x => x).FirstOrDefault();
            }
            else
            {
                RCGAMZN_PROD01Entities rcgamznProdEntities = new RCGAMZN_PROD01Entities();
                rcgamznProdEntities.Database.CommandTimeout = sqlCommandTimeout;
                //kenticoCMSConfiguration = rcgamznProdEntities.KenticoCMSConfigurations.Select(x => x).FirstOrDefault();
            }

            return kenticoCMSConfiguration;
        }

        #region CMS Table SQL Actions
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
                    RCGAMZN_DEV01Entities rcgamznDevEntities = new RCGAMZN_DEV01Entities();
                    rcgamznDevEntities.Database.CommandTimeout = sqlCommandTimeout;
                    var results = rcgamznDevEntities.Database.SqlQuery<ExistingMatterClient>(sqlStmt);
                    existingMatterClient = results.Count() > 0 ? results.First() : null;
                }
                else
                {
                    RCGAMZN_PROD01Entities rcgamznProdEntities = new RCGAMZN_PROD01Entities();
                    rcgamznProdEntities.Database.CommandTimeout = sqlCommandTimeout;
                    var results = rcgamznProdEntities.Database.SqlQuery<ExistingMatterClient>(sqlStmt);
                    existingMatterClient = results.Count() > 0 ? results.First() : null;
                }
            }

            return existingMatterClient;
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
                    MailAddress address = new MailAddress(emailAddress);
                    emailCondition = $"like '%{address.Host}%'";
                }

                sqlStmt = sqlStmt.Replace("@server", server);
                sqlStmt = sqlStmt.Replace("@instance", dbInstance);
                sqlStmt = sqlStmt.Replace("@archetypeCode", TE3EEntityExt.GetEnumDescription(archetypeCode));
                sqlStmt = sqlStmt.Replace("@displayName", displayName);
                sqlStmt = sqlStmt.Replace("@emailCondition", emailCondition);

                if (isDebug)
                {
                    RCGAMZN_DEV01Entities rcgamznDevEntities = new RCGAMZN_DEV01Entities();
                    rcgamznDevEntities.Database.CommandTimeout = sqlCommandTimeout;
                    existingEntities = rcgamznDevEntities.Database.SqlQuery<ExistingEntity>(sqlStmt).ToList();
                }
                else
                {
                    RCGAMZN_PROD01Entities rcgamznProdEntities = new RCGAMZN_PROD01Entities();
                    rcgamznProdEntities.Database.CommandTimeout = sqlCommandTimeout;
                    existingEntities = rcgamznProdEntities.Database.SqlQuery<ExistingEntity>(sqlStmt).ToList();
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
                    RCGAMZN_DEV01Entities rcgamznDevEntities = new RCGAMZN_DEV01Entities();
                    rcgamznDevEntities.Database.CommandTimeout = sqlCommandTimeout;
                    existingClients = rcgamznDevEntities.Database.SqlQuery<ExistingClient>(sqlStmt).ToList();
                }
                else
                {
                    RCGAMZN_PROD01Entities rcgamznProdEntities = new RCGAMZN_PROD01Entities();
                    rcgamznProdEntities.Database.CommandTimeout = sqlCommandTimeout;
                    existingClients = rcgamznProdEntities.Database.SqlQuery<ExistingClient>(sqlStmt).ToList();
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
                sqlStmt = sqlStmt.Replace("@displayName", displayName);

                if (isDebug)
                {
                    RCGAMZN_DEV01Entities rcgamznDevEntities = new RCGAMZN_DEV01Entities();
                    rcgamznDevEntities.Database.CommandTimeout = sqlCommandTimeout;
                    var results = rcgamznDevEntities.Database.SqlQuery<ExistingEntity>(sqlStmt);
                    existingEntity = results.Count() > 0 ? results.First() : null;
                }
                else
                {
                    RCGAMZN_PROD01Entities rcgamznProdEntities = new RCGAMZN_PROD01Entities();
                    rcgamznProdEntities.Database.CommandTimeout = sqlCommandTimeout;
                    var results = rcgamznProdEntities.Database.SqlQuery<ExistingEntity>(sqlStmt);
                    existingEntity = results.Count() > 0 ? results.First() : null;
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
                sqlStmt = sqlStmt.Replace("@clientName", clientName);
                sqlStmt = sqlStmt.Replace("@clientNumber", clientNumber);

                if (isDebug)
                {
                    RCGAMZN_DEV01Entities rcgamznDevEntities = new RCGAMZN_DEV01Entities();
                    rcgamznDevEntities.Database.CommandTimeout = sqlCommandTimeout;
                    var results = rcgamznDevEntities.Database.SqlQuery<ExistingClient>(sqlStmt);
                    existingClient = results.Count() > 0 ? results.First() : null;
                }
                else
                {
                    RCGAMZN_PROD01Entities rcgamznProdEntities = new RCGAMZN_PROD01Entities();
                    rcgamznProdEntities.Database.CommandTimeout = sqlCommandTimeout;
                    var results = rcgamznProdEntities.Database.SqlQuery<ExistingClient>(sqlStmt);
                    existingClient = results.Count() > 0 ? results.First() : null;
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
                    RCGAMZN_DEV01Entities rcgamznDevEntities = new RCGAMZN_DEV01Entities();
                    rcgamznDevEntities.Database.CommandTimeout = sqlCommandTimeout;
                    var results = rcgamznDevEntities.Database.SqlQuery<ExistingPayorClient>(sqlStmt);
                    existingClient = results.Count() > 0 ? results.First() : null;
                }
                else
                {
                    RCGAMZN_PROD01Entities rcgamznProdEntities = new RCGAMZN_PROD01Entities();
                    rcgamznProdEntities.Database.CommandTimeout = sqlCommandTimeout;
                    var results = rcgamznProdEntities.Database.SqlQuery<ExistingPayorClient>(sqlStmt);
                    existingClient = results.Count() > 0 ? results.First() : null;
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
                sqlStmt = sqlStmt.Replace("@mattName", mattName);
                sqlStmt = sqlStmt.Replace("@mattIndex", mattIndex.ToString());

                if (isDebug)
                {
                    RCGAMZN_DEV01Entities rcgamznDevEntities = new RCGAMZN_DEV01Entities();
                    rcgamznDevEntities.Database.CommandTimeout = sqlCommandTimeout;
                    var results = rcgamznDevEntities.Database.SqlQuery<ExistingMatter>(sqlStmt);
                    existingMatter = results.Count() > 0 ? results.First() : null;
                }
                else
                {
                    RCGAMZN_PROD01Entities rcgamznProdEntities = new RCGAMZN_PROD01Entities();
                    rcgamznProdEntities.Database.CommandTimeout = sqlCommandTimeout;
                    var results = rcgamznProdEntities.Database.SqlQuery<ExistingMatter>(sqlStmt);
                    existingMatter = results.Count() > 0 ? results.First() : null;
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
                    RCGAMZN_DEV01Entities rcgamznDevEntities = new RCGAMZN_DEV01Entities();
                    rcgamznDevEntities.Database.CommandTimeout = sqlCommandTimeout;
                    tE3ERoles = rcgamznDevEntities.Database.SqlQuery<TE3ERoles>(sqlStmt).ToList();
                }
                else
                {
                    RCGAMZN_PROD01Entities rcgamznProdEntities = new RCGAMZN_PROD01Entities();
                    rcgamznProdEntities.Database.CommandTimeout = sqlCommandTimeout;
                    tE3ERoles = rcgamznProdEntities.Database.SqlQuery<TE3ERoles>(sqlStmt).ToList();
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
                    RCGAMZN_DEV01Entities rcgamznDevEntities = new RCGAMZN_DEV01Entities();
                    rcgamznDevEntities.Database.CommandTimeout = sqlCommandTimeout;
                    var results = rcgamznDevEntities.Database.SqlQuery<MattRateGrpExc>(sqlStmt).ToList();
                    mattRateGrpExc = results.Count() > 0 ? results.First() : null;
                }
                else
                {
                    RCGAMZN_PROD01Entities rcgamznProdEntities = new RCGAMZN_PROD01Entities();
                    rcgamznProdEntities.Database.CommandTimeout = sqlCommandTimeout;
                    var results = rcgamznProdEntities.Database.SqlQuery<MattRateGrpExc>(sqlStmt).ToList();
                    mattRateGrpExc = results.Count() > 0 ? results.First() : null;
                }
            }

            return mattRateGrpExc;
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
                    RCGAMZN_DEV01Entities rcgamznDevEntities = new RCGAMZN_DEV01Entities();
                    rcgamznDevEntities.Database.CommandTimeout = sqlCommandTimeout;
                    entityProcessItems = rcgamznDevEntities.Database.SqlQuery<EntityProcessItem>(sqlStmt).ToList();
                }
                else
                {
                    RCGAMZN_PROD01Entities rcgamznProdEntities = new RCGAMZN_PROD01Entities();
                    rcgamznProdEntities.Database.CommandTimeout = sqlCommandTimeout;
                    entityProcessItems = rcgamznProdEntities.Database.SqlQuery<EntityProcessItem>(sqlStmt).ToList();
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
                    RCGAMZN_DEV01Entities rcgamznDevEntities = new RCGAMZN_DEV01Entities();
                    rcgamznDevEntities.Database.CommandTimeout = sqlCommandTimeout;
                    clientProcessItems = rcgamznDevEntities.Database.SqlQuery<ClientProcessItem>(sqlStmt).ToList();
                }
                else
                {
                    RCGAMZN_PROD01Entities rcgamznProdEntities = new RCGAMZN_PROD01Entities();
                    rcgamznProdEntities.Database.CommandTimeout = sqlCommandTimeout;
                    clientProcessItems = rcgamznProdEntities.Database.SqlQuery<ClientProcessItem>(sqlStmt).ToList();
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
                    RCGAMZN_DEV01Entities rcgamznDevEntities = new RCGAMZN_DEV01Entities();
                    rcgamznDevEntities.Database.CommandTimeout = sqlCommandTimeout;
                    var results = rcgamznDevEntities.Database.SqlQuery<MatterProcessItem>(sqlStmt);
                    matterProcessItem = results.Count() > 0 ? results.First() : null;
                }
                else
                {
                    RCGAMZN_PROD01Entities rcgamznProdEntities = new RCGAMZN_PROD01Entities();
                    rcgamznProdEntities.Database.CommandTimeout = sqlCommandTimeout;
                    var results = rcgamznProdEntities.Database.SqlQuery<MatterProcessItem>(sqlStmt);
                    matterProcessItem = results.Count() > 0 ? results.First() : null;
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
                    RCGAMZN_DEV01Entities rcgamznDevEntities = new RCGAMZN_DEV01Entities();
                    rcgamznDevEntities.Database.CommandTimeout = sqlCommandTimeout;
                    var results = rcgamznDevEntities.Database.SqlQuery<ExistingEntity>(sqlStmt);
                    existingEntity = results.Count() > 0 ? results.First() : null;
                }
                else
                {
                    RCGAMZN_PROD01Entities rcgamznProdEntities = new RCGAMZN_PROD01Entities();
                    rcgamznProdEntities.Database.CommandTimeout = sqlCommandTimeout;
                    var results = rcgamznProdEntities.Database.SqlQuery<ExistingEntity>(sqlStmt);
                    existingEntity = results.Count() > 0 ? results.First() : null;
                }
            }

            return existingEntity;
        }

        public CMS_GetCliTypeFromCftRole_Result GetCliTypeFromDesc(string cliType)
        {
            CMS_GetCliTypeFromCftRole_Result cliTypeResult = new CMS_GetCliTypeFromCftRole_Result();
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

        public CMS_GetCliTypeFromCftRole_Result GetCliTypeFromCftRole(int cftRole, int sqlCommandTimeout, bool isDebug = false)
        {
            CMS_GetCliTypeFromCftRole_Result cftRole_Result = new CMS_GetCliTypeFromCftRole_Result();

            if (isDebug)
            {
                RCGAMZN_DEV01Entities rcgamznDevEntities = new RCGAMZN_DEV01Entities();
                rcgamznDevEntities.Database.CommandTimeout = sqlCommandTimeout;
                var results = rcgamznDevEntities.CMS_GetCliTypeFromCftRole(cftRole).ToList();
                cftRole_Result = results.Count() > 0 ? results.First() : null;
            }
            else
            {
                //RCGAMZN_PROD01Entities rcgamznProdEntities = new RCGAMZN_PROD01Entities();
                //rcgamznProdEntities.Database.CommandTimeout = sqlCommandTimeout;
                //var results = rcgamznProdEntities.CMS_GetCliTypeFromCftRole(cftRole).ToList();
                //cftRole_Result = results.Count() > 0 ? results.First() : null;
            }

            return cftRole_Result;
        }

        public List<CMS_GetLookupCodes_Result> GetOfficeCodes(int sqlCommandTimeout, bool isDebug = false)
        {
            List<CMS_GetLookupCodes_Result> officeCodes = new List<CMS_GetLookupCodes_Result>();

            if (isDebug)
            {
                RCGAMZN_DEV01Entities rcgamznDevEntities = new RCGAMZN_DEV01Entities();
                rcgamznDevEntities.Database.CommandTimeout = sqlCommandTimeout;
                officeCodes = rcgamznDevEntities.CMS_GetLookupCodes("Office").ToList();
            }
            else
            {
                //RCGAMZN_PROD01Entities rcgamznProdEntities = new RCGAMZN_PROD01Entities();
                //rcgamznProdEntities.Database.CommandTimeout = sqlCommandTimeout;
                //officeCodes = rcgamznProdEntities.CMS_GetLookupCodes("Office").ToList();
            }

            return officeCodes;
        }

        public void GetNBIProcessItem()
        {

        }

        public List<ClientMasterCM> AddNewClientCMSKey(string clientName, int sqlCommandTimeout, bool isDebug = false)
        {
            List<ClientMasterCM> results = null;

            string appId = Guid.NewGuid().ToString().ToUpper();
            var appKey = GenerateCMSAPPKey();

            if (isDebug)
            {
                using (RCGAMZN_DEV01Entities rcgamznDevEntities = new RCGAMZN_DEV01Entities())
                {
                    rcgamznDevEntities.Database.CommandTimeout = sqlCommandTimeout;
                    rcgamznDevEntities.Database.ExecuteSqlCommand($@"INSERT INTO [dbo].[ClientMasterCMS]
                                                                               ([AppId]
                                                                               ,[AppKey]
                                                                               ,[ClientName]
                                                                               ,[CreatedOn])
                                                                         VALUES
                                                                               ('{appId}'
                                                                               ,'{appKey}'
                                                                               ,'{clientName}'
                                                                               ,'{DateTime.Now}')");
                    results = rcgamznDevEntities.ClientMasterCMS.ToList();
                }
            }
            else
            {
                using (RCGAMZN_PROD01Entities rcgamznProdEntities = new RCGAMZN_PROD01Entities())
                {
                    rcgamznProdEntities.Database.CommandTimeout = sqlCommandTimeout;
                    rcgamznProdEntities.Database.ExecuteSqlCommand($@"INSERT INTO [dbo].[ClientMasterCMS]
                                                                               ([AppId]
                                                                               ,[AppKey]
                                                                               ,[ClientName]
                                                                               ,[CreatedOn])
                                                                         VALUES
                                                                               ('{appId}'
                                                                               ,'{appKey}'
                                                                               ,'{clientName}'
                                                                               ,'{DateTime.Now}')");

                    //results = rcgamznProdEntities.ClientMasters.ToList();
                }
            }


            return results;
        }

        public List<ClientMasterCM> GetClientMasterCMS(int sqlCommandTimeout, bool isDebug = false)
        {
            List<ClientMasterCM> results = null;

            if (isDebug)
            {
                using (RCGAMZN_DEV01Entities rcgamznDevEntities = new RCGAMZN_DEV01Entities())
                {
                    rcgamznDevEntities.Database.CommandTimeout = sqlCommandTimeout;
                    results = rcgamznDevEntities.ClientMasterCMS.ToList();
                }
            }
            else
            {
                using (RCGAMZN_PROD01Entities rcgamznProdEntities = new RCGAMZN_PROD01Entities())
                {
                    rcgamznProdEntities.Database.CommandTimeout = sqlCommandTimeout;
                    //results = rcgamznProdEntities.ClientMasterCMS.ToList();
                }
            }

            return results;
        }

        public void AddInAssignment(In3eAssignment iAssignment, int sqlCommandTimeout, bool isDebug = false)
        {
            if (isDebug)
            {
                using (RCGAMZN_DEV01Entities rcgamznDevEntities = new RCGAMZN_DEV01Entities())
                {
                    using (DbContextTransaction transaction = rcgamznDevEntities.Database.BeginTransaction())
                    {
                        try
                        {
                            rcgamznDevEntities.Database.CommandTimeout = sqlCommandTimeout;
                            rcgamznDevEntities.InAssignmentsCMS.Add(iAssignment.assignment);

                            if (iAssignment.orderingClient != null)
                                rcgamznDevEntities.InOrderingClientsCMS.Add(iAssignment.orderingClient);

                            if (iAssignment.coConsultants.Count() > 0)
                                rcgamznDevEntities.InCoConsultantsCMS.AddRange(iAssignment.coConsultants);

                            if (iAssignment.incidentLocations.Count() > 0)
                                rcgamznDevEntities.InIncidentLocationsCMS.AddRange(iAssignment.incidentLocations);

                            if (iAssignment.payorDetails.Count() > 0)
                                rcgamznDevEntities.InPayorDetailsCMS.AddRange(iAssignment.payorDetails);

                            if (iAssignment.additionalParties.Count() > 0)
                                rcgamznDevEntities.InAdditionalPartiesCMS.AddRange(iAssignment.additionalParties);

                            rcgamznDevEntities.SaveChanges();
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
            {
                using (RCGAMZN_PROD01Entities rcgamznProdEntities = new RCGAMZN_PROD01Entities())
                {
                    using (DbContextTransaction transaction = rcgamznProdEntities.Database.BeginTransaction())
                    {
                        rcgamznProdEntities.Database.CommandTimeout = sqlCommandTimeout;
                        //rcgamznProdEntities.InAssignmentsCMS.Add(iAssignment.assignment);

                        //if (iAssignment.orderingClient != null)
                        //    rcgamznProdEntities.InOrderingClientsCMS.Add(iAssignment.orderingClient);

                        //if (iAssignment.coConsultants.Count() > 0)
                        //    rcgamznProdEntities.InCoConsultantsCMS.AddRange(iAssignment.coConsultants);

                        //if (iAssignment.incidentLocations.Count() > 0)
                        //    rcgamznProdEntities.InIncidentLocationsCMS.AddRange(iAssignment.incidentLocations);

                        //if (iAssignment.payorDetails.Count() > 0)
                        //    rcgamznProdEntities.InPayorDetailsCMS.AddRange(iAssignment.payorDetails);

                        //if (newAssignment.additionalParties.Count() > 0)
                        //    rcgamznProdEntities.InAdditionalPartiesCMS.AddRange(iAssignment.additionalParties);

                        //rcgamznProdEntities.SaveChanges();
                    }
                }
            }
        }

        public void AddOutAssignment(Out3eAssignment oAssignment, int sqlCommandTimeout, bool isDebug = false)
        {
            if (isDebug)
            {
                using (RCGAMZN_DEV01Entities rcgamznDevEntities = new RCGAMZN_DEV01Entities())
                {
                    rcgamznDevEntities.Database.CommandTimeout = sqlCommandTimeout;
                    rcgamznDevEntities.OutAssignmentsCMS.Add(oAssignment.assignment);

                    if (oAssignment.orderingClient != null)
                        rcgamznDevEntities.OutOrderingClientsCMS.Add(oAssignment.orderingClient);

                    if (oAssignment.coConsultants.Count() > 0)
                        rcgamznDevEntities.OutCoConsultantsCMS.AddRange(oAssignment.coConsultants);

                    if (oAssignment.incidentLocations.Count() > 0)
                        rcgamznDevEntities.OutIncidentLocationsCMS.AddRange(oAssignment.incidentLocations);

                    if (oAssignment.payorDetails.Count() > 0)
                        rcgamznDevEntities.OutPayorDetailsCMS.AddRange(oAssignment.payorDetails);

                    if (oAssignment.additionalParties.Count() > 0)
                        rcgamznDevEntities.OutAdditionalPartiesCMS.AddRange(oAssignment.additionalParties);

                    rcgamznDevEntities.SaveChanges();
                }
            }
            else
            {
                using (RCGAMZN_PROD01Entities rcgamznProdEntities = new RCGAMZN_PROD01Entities())
                {
                    rcgamznProdEntities.Database.CommandTimeout = sqlCommandTimeout;
                    //rcgamznProdEntities.OutAssignmentsCMS.Add(oAssignment.assignment);

                    //if (oAssignment.orderingClient != null)
                    //    rcgamznProdEntities.OutOrderingClientsCMS.Add(oAssignment.orderingClient);

                    //if (oAssignment.coConsultants.Count() > 0)
                    //    rcgamznProdEntities.OutCoConsultantsCMS.AddRange(oAssignment.coConsultants);

                    //if (oAssignment.incidentLocations.Count() > 0)
                    //    rcgamznProdEntities.OutIncidentLocationsCMS.AddRange(oAssignment.incidentLocations);

                    //if (oAssignment.payorDetails.Count() > 0)
                    //    rcgamznProdEntities.OutPayorDetailsCMS.AddRange(oAssignment.payorDetails);

                    //if (oAssignment.additionalParties.Count() > 0)
                    //    rcgamznProdEntities.OutAdditionalPartiesCMS.AddRange(oAssignment.additionalParties);

                    //rcgamznProdEntities.SaveChanges();
                }
            }
        }

        public void AddInCustomer(InCustomerProfileCM iCustomer, int sqlCommandTimeout, bool isDebug = false)
        {
            if (isDebug)
            {
                using (RCGAMZN_DEV01Entities rcgamznDevEntities = new RCGAMZN_DEV01Entities())
                {
                    rcgamznDevEntities.Database.CommandTimeout = sqlCommandTimeout;
                    rcgamznDevEntities.InCustomerProfileCMS.Add(iCustomer);
                    rcgamznDevEntities.SaveChanges();
                }
            }
            else
            {
                using (RCGAMZN_PROD01Entities rcgamznProdEntities = new RCGAMZN_PROD01Entities())
                {
                    rcgamznProdEntities.Database.CommandTimeout = sqlCommandTimeout;
                    //rcgamznProdEntities.InCustomerProfileCMS.Add(iCustomer);
                    //rcgamznProdEntities.SaveChanges();
                }
            }
        }

        public void AddOutCustomer(OutCustomerProfileCM oCustomer, int sqlCommandTimeout, bool isDebug = false)
        {
            if (isDebug)
            {
                using (RCGAMZN_DEV01Entities rcgamznDevEntities = new RCGAMZN_DEV01Entities())
                {
                    rcgamznDevEntities.Database.CommandTimeout = sqlCommandTimeout;
                    rcgamznDevEntities.OutCustomerProfileCMS.Add(oCustomer);
                    rcgamznDevEntities.SaveChanges();
                }
            }
            else
            {
                using (RCGAMZN_PROD01Entities rcgamznProdEntities = new RCGAMZN_PROD01Entities())
                {
                    rcgamznProdEntities.Database.CommandTimeout = sqlCommandTimeout;
                    //rcgamznProdEntities.OutCustomerProfileCMS.Add(oCustomer);
                    //rcgamznProdEntities.SaveChanges();
                }
            }
        }

        public List<Out3eAssignment> GetOutAssignments(int sqlCommandTimeout, bool isDebug = false, int attemptsAllowed = 20)
        {
            List<Out3eAssignment> oAssignments = new List<Out3eAssignment>();

            if (isDebug)
            {
                using (RCGAMZN_DEV01Entities rcgamznDevEntities = new RCGAMZN_DEV01Entities())
                {
                    rcgamznDevEntities.Database.CommandTimeout = sqlCommandTimeout;

                    #region scan OutAssignmentsCMS
                    var oAssignmentGroup = rcgamznDevEntities.OutAssignmentsCMS.Where(x => (x.NumOfAttempts ?? 0) <= attemptsAllowed)
                                                                              .GroupBy(x => new { x.KenticoID, x.MatterName, x.ClientName })
                                                                              .Select(x => x).ToList();

                    if (oAssignmentGroup.Count() > 0)
                    {
                        oAssignmentGroup.ForEach(g =>
                        {
                            var mostUpdatedAssignmentRec = g.OrderByDescending(o => o.TimeStamp).First();
                            Out3eAssignment oAssignment = new Out3eAssignment();
                            oAssignment.assignment = mostUpdatedAssignmentRec;
                            oAssignments.Add(oAssignment);
                        });
                    }
                    else
                    {
                        oAssignments.Add(new Out3eAssignment());
                    }

                    #endregion scan OutAssignmentsCMS

                    #region scan OutOrderingClientsCMS
                    var outClientGroup = rcgamznDevEntities.OutOrderingClientsCMS.Where(c => (c.NumOfAttempts ?? 0) <= attemptsAllowed)
                                                                               .GroupBy(c => new { c.KenticoID, c.OrderClientCompanyName })
                                                                               .Select(c => c).ToList();
                    if (outClientGroup.Count() > 0)
                    {
                        outClientGroup.ForEach(g =>
                        {
                            var mostUpdatedOrderClientRec = g.OrderByDescending(o => o.TimeStamp).First();
                            var existingOutAssignment = oAssignments.Where(oa => oa.assignment.KenticoID == mostUpdatedOrderClientRec.KenticoID).Select(oa => oa).ToList();
                            existingOutAssignment.ForEach(e => e.orderingClient = mostUpdatedOrderClientRec);
                        });

                    }

                    #endregion scan OutOrderingClientsCMS

                    #region scan OutIncidentLocationsCMS
                    var outIncidentLocations = rcgamznDevEntities.OutIncidentLocationsCMS.Where(c => (c.NumOfAttempts ?? 0) <= attemptsAllowed)
                                                                                       .Select(c => c)
                                                                                       .OrderByDescending(c => c.TimeStamp)
                                                                                       .ToList();
                    if (outIncidentLocations.Count() > 0)
                    {
                        outIncidentLocations.ForEach(x =>
                        {
                            var existingOutAssignment = oAssignments.Where(oa => oa.assignment.KenticoID == x.KenticoID).Select(oa => oa).ToList();
                            existingOutAssignment.ForEach(a => a.incidentLocations.Add(x));
                        });
                    }
                    #endregion scan OutIncidentLocationsCMS

                    #region scan OutPayorDetailsCMS
                    var oPayorDetails = rcgamznDevEntities.OutPayorDetailsCMS.Where(c => (c.NumOfAttempts ?? 0) <= attemptsAllowed)
                                                                             .Select(c => c)
                                                                             .OrderByDescending(c => c.TimeStamp)
                                                                             .ToList();
                    if (oPayorDetails.Count() > 0)
                    {
                        oPayorDetails.ForEach(x =>
                        {
                            var existingOutAssignment = oAssignments.Where(oa => oa.assignment.KenticoID == x.KenticoID).Select(oa => oa).ToList();
                            existingOutAssignment.ForEach(a => a.payorDetails.Add(x));
                        });
                    }
                    #endregion scan OutPayorDetailsCMS

                    #region scan OutCoConsultantsCMS
                    var oCoConsultants = rcgamznDevEntities.OutCoConsultantsCMS.Where(c => (c.NumOfAttempts ?? 0) <= attemptsAllowed)
                                                                               .Select(c => c)
                                                                               .OrderByDescending(c => c.TimeStamp)
                                                                               .ToList();
                    if (oCoConsultants.Count() > 0)
                    {
                        oCoConsultants.ForEach(x =>
                        {
                            var existingOutAssignment = oAssignments.Where(oa => oa.assignment.KenticoID == x.KenticoID).Select(oa => oa).ToList();
                            existingOutAssignment.ForEach(a => a.coConsultants.Add(x));
                        });
                    }
                    #endregion scan OutCoConsultantsCMS

                    #region scan OutAdditionalPartiesCMS
                    var oAdditionalParties = rcgamznDevEntities.OutAdditionalPartiesCMS.Where(c => (c.NumOfAttempts ?? 0) <= attemptsAllowed)
                                                                                       .Select(c => c)
                                                                                       .OrderByDescending(c => c.TimeStamp)
                                                                                       .ToList();
                    if (oAdditionalParties.Count() > 0)
                    {
                        oAdditionalParties.ForEach(x =>
                        {
                            var existingOutAssignment = oAssignments.Where(oa => oa.assignment.KenticoID == x.KenticoID).Select(oa => oa).ToList();
                            existingOutAssignment.ForEach(a => a.additionalParties.Add(x));
                        });
                    }
                    #endregion scan OutAdditionalPartiesCMS
                }
            }
            else
            {
                using (RCGAMZN_PROD01Entities rcgamznProdEntities = new RCGAMZN_PROD01Entities())
                {
                    rcgamznProdEntities.Database.CommandTimeout = sqlCommandTimeout;

                    //#region scan OutAssignmentsCMS
                    //var oAssignmentGroup = rcgamznProdEntities.OutAssignmentsCMS.Where(x => (x.NumOfAttempts ?? 0) <= attemptsAllowed)
                    //                                                          .GroupBy(x => new { x.KenticoID, x.MatterName, x.ClientName })
                    //                                                          .Select(x => x).ToList();

                    //if (oAssignmentGroup.Count() > 0)
                    //{
                    //    oAssignmentGroup.ForEach(g =>
                    //    {
                    //        var mostUpdatedAssignmentRec = g.OrderByDescending(o => o.TimeStamp).First();
                    //        Out3eAssignment oAssignment = new Out3eAssignment();
                    //        oAssignment.assignment = mostUpdatedAssignmentRec;
                    //        oAssignments.Add(oAssignment);
                    //    });
                    //}
                    //else
                    //{
                    //    oAssignments.Add(new Out3eAssignment());
                    //}

                    //#endregion scan OutAssignmentsCMS

                    //#region scan OutOrderingClientsCMS
                    //var outClientGroup = rcgamznProdEntities.OutOrderingClientsCMS.Where(c => (c.NumOfAttempts ?? 0) <= attemptsAllowed)
                    //                                                           .GroupBy(c => new { c.KenticoID, c.OrderClientCompanyName })
                    //                                                           .Select(c => c).ToList();
                    //if (outClientGroup.Count() > 0)
                    //{
                    //    outClientGroup.ForEach(g =>
                    //    {
                    //        var mostUpdatedOrderClientRec = g.OrderByDescending(o => o.TimeStamp).First();
                    //        var existingOutAssignment = oAssignments.Where(oa => oa.assignment.KenticoID == mostUpdatedOrderClientRec.KenticoID).Select(oa => oa).ToList();
                    //        existingOutAssignment.ForEach(e => e.orderingClient = mostUpdatedOrderClientRec);
                    //    });

                    //}

                    //#endregion scan OutOrderingClientsCMS

                    //#region scan OutIncidentLocationsCMS
                    //var outIncidentLocations = rcgamznProdEntities.OutIncidentLocationsCMS.Where(c => (c.NumOfAttempts ?? 0) <= attemptsAllowed)
                    //                                                                   .Select(c => c)
                    //                                                                   .OrderByDescending(c => c.TimeStamp)
                    //                                                                   .ToList();
                    //if (outIncidentLocations.Count() > 0)
                    //{
                    //    outIncidentLocations.ForEach(x =>
                    //    {
                    //        var existingOutAssignment = oAssignments.Where(oa => oa.assignment.KenticoID == x.KenticoID).Select(oa => oa).ToList();
                    //        existingOutAssignment.ForEach(a => a.incidentLocations.Add(x));
                    //    });
                    //}
                    //#endregion scan OutIncidentLocationsCMS

                    //#region scan OutPayorDetailsCMS
                    //var oPayorDetails = rcgamznProdEntities.OutPayorDetailsCMS.Where(c => (c.NumOfAttempts ?? 0) <= attemptsAllowed)
                    //                                                         .Select(c => c)
                    //                                                         .OrderByDescending(c => c.TimeStamp)
                    //                                                         .ToList();
                    //if (oPayorDetails.Count() > 0)
                    //{
                    //    oPayorDetails.ForEach(x =>
                    //    {
                    //        var existingOutAssignment = oAssignments.Where(oa => oa.assignment.KenticoID == x.KenticoID).Select(oa => oa).ToList();
                    //        existingOutAssignment.ForEach(a => a.payorDetails.Add(x));
                    //    });
                    //}
                    //#endregion scan OutPayorDetailsCMS

                    //#region scan OutCoConsultantsCMS
                    //var oCoConsultants = rcgamznProdEntities.OutCoConsultantsCMS.Where(c => (c.NumOfAttempts ?? 0) <= attemptsAllowed)
                    //                                                           .Select(c => c)
                    //                                                           .OrderByDescending(c => c.TimeStamp)
                    //                                                           .ToList();
                    //if (oCoConsultants.Count() > 0)
                    //{
                    //    oCoConsultants.ForEach(x =>
                    //    {
                    //        var existingOutAssignment = oAssignments.Where(oa => oa.assignment.KenticoID == x.KenticoID).Select(oa => oa).ToList();
                    //        existingOutAssignment.ForEach(a => a.coConsultants.Add(x));
                    //    });
                    //}
                    //#endregion scan OutCoConsultantsCMS

                    //#region scan OutAdditionalPartiesCMS
                    //var oAdditionalParties = rcgamznProdEntities.OutAdditionalPartiesCMS.Where(c => (c.NumOfAttempts ?? 0) <= attemptsAllowed)
                    //                                                                   .Select(c => c)
                    //                                                                   .OrderByDescending(c => c.TimeStamp)
                    //                                                                   .ToList();
                    //if (oAdditionalParties.Count() > 0)
                    //{
                    //    oAdditionalParties.ForEach(x =>
                    //    {
                    //        var existingOutAssignment = oAssignments.Where(oa => oa.assignment.KenticoID == x.KenticoID).Select(oa => oa).ToList();
                    //        existingOutAssignment.ForEach(a => a.additionalParties.Add(x));
                    //    });
                    //}
                    //#endregion scan OutAdditionalPartiesCMS
                }
            }

            return oAssignments;
        }

        public List<In3eAssignment> GetInAssignments(int sqlCommandTimeout, bool isDebug = false, int attemptsAllowed = 20)
        {
            List<In3eAssignment> iAssignments = new List<In3eAssignment>();

            if (isDebug)
            {
                using (RCGAMZN_DEV01Entities rcgamznDevEntities = new RCGAMZN_DEV01Entities())
                {
                    rcgamznDevEntities.Database.CommandTimeout = sqlCommandTimeout;

                    #region scan InAssignmentsCMS

                    var iAssignmentGroup = rcgamznDevEntities.InAssignmentsCMS.Where(x => !((bool)x.IsImported) && x.NumOfAttempts <= attemptsAllowed)
                                                                              .GroupBy(x => new { x.KenticoID, x.MatterName, x.ClientName })
                                                                              .Select(x => x).ToList();

                    if (iAssignmentGroup.Count() > 0)
                    {
                        iAssignmentGroup.ForEach(g =>
                        {
                            var mostUpdatedAssignmentRec = g.OrderByDescending(o => o.TimeStamp).First();
                            In3eAssignment iAssignment = new In3eAssignment();
                            iAssignment.assignment = mostUpdatedAssignmentRec;
                            iAssignments.Add(iAssignment);
                        });
                    }
                    else
                    {
                        iAssignments.Add(new In3eAssignment());
                    }

                    #endregion scan InAssignmentsCMS

                    #region scan InOrderingClientsCMS
                    var inClientGroup = rcgamznDevEntities.InOrderingClientsCMS.Where(c => (c.NumOfAttempts ?? 0) <= attemptsAllowed)
                                                                               .GroupBy(c => new { c.KenticoID, c.OrderClientCompanyName })
                                                                               .Select(c => c).ToList();
                    if (inClientGroup.Count() > 0)
                    {
                        inClientGroup.ForEach(g =>
                        {
                            var mostUpdatedOrderClientRec = g.OrderByDescending(o => o.TimeStamp).First();
                            var existingInAssignment = iAssignments.Where(ia => ia.assignment.KenticoID == mostUpdatedOrderClientRec.KenticoID).Select(ia => ia).ToList();
                            existingInAssignment.ForEach(e => e.orderingClient = mostUpdatedOrderClientRec);
                        });

                    }
                    #endregion scan InOrderingClientsCMS

                    #region scan InIncidentLocationsCMS
                    var inIncidentLocations = rcgamznDevEntities.InIncidentLocationsCMS.Where(c => (c.NumOfAttempts ?? 0) <= attemptsAllowed)
                                                                                       .Select(c => c)
                                                                                       .OrderByDescending(c => c.TimeStamp)
                                                                                       .ToList();
                    if (inIncidentLocations.Count() > 0)
                    {
                        inIncidentLocations.ForEach(x =>
                        {
                            var existingInAssignment = iAssignments.Where(ia => ia.assignment.KenticoID == x.KenticoID).Select(ia => ia).ToList();
                            existingInAssignment.ForEach(a => a.incidentLocations.Add(x));
                        });
                    }
                    #endregion scan InIncidentLocationsCMS

                    #region scan InPayorDetailsCMS
                    var inPayorDetails = rcgamznDevEntities.InPayorDetailsCMS.Where(c => (c.NumOfAttempts ?? 0) <= attemptsAllowed)
                                                                             .Select(c => c)
                                                                             .OrderByDescending(c => c.TimeStamp)
                                                                             .ToList();
                    if (inPayorDetails.Count() > 0)
                    {
                        inPayorDetails.ForEach(x =>
                        {
                            var existingInAssignment = iAssignments.Where(ia => ia.assignment.KenticoID == x.KenticoID).Select(ia => ia).ToList();
                            existingInAssignment.ForEach(a => a.payorDetails.Add(x));
                        });
                    }
                    #endregion scan InPayorDetailsCMS

                    #region scan InCoConsultantsCMS
                    var inCoConsultants = rcgamznDevEntities.InCoConsultantsCMS.Where(c => (c.NumOfAttempts ?? 0) <= attemptsAllowed)
                                                                               .Select(c => c)
                                                                               .OrderByDescending(c => c.TimeStamp)
                                                                               .ToList();
                    if (inCoConsultants.Count() > 0)
                    {
                        inCoConsultants.ForEach(x =>
                        {
                            var existingInAssignment = iAssignments.Where(ia => ia.assignment.KenticoID == x.KenticoID).Select(ia => ia).ToList();
                            existingInAssignment.ForEach(a => a.coConsultants.Add(x));
                        });
                    }
                    #endregion scan InCoConsultantsCMS

                    #region scan InAdditionalPartiesCMS
                    var inAdditionalParties = rcgamznDevEntities.InAdditionalPartiesCMS.Where(c => (c.NumOfAttempts ?? 0) <= attemptsAllowed)
                                                                                       .Select(c => c)
                                                                                       .OrderByDescending(c => c.TimeStamp)
                                                                                       .ToList();
                    if (inAdditionalParties.Count() > 0)
                    {
                        inAdditionalParties.ForEach(x =>
                        {
                            var existingInAssignment = iAssignments.Where(ia => ia.assignment.KenticoID == x.KenticoID).Select(ia => ia).ToList();
                            existingInAssignment.ForEach(a => a.additionalParties.Add(x));
                        });
                    }
                    #endregion scan InAdditionalPartiesCMS
                }
            }
            else
            {
                using (RCGAMZN_PROD01Entities rcgamznProdEntities = new RCGAMZN_PROD01Entities())
                {
                    rcgamznProdEntities.Database.CommandTimeout = sqlCommandTimeout;

                    //#region scan InAssignmentsCMS

                    //var iAssignmentGroup = rcgamznProdEntities.InAssignmentsCMS.Where(x => (x.NumOfAttempts ?? 0) <= attemptsAllowed)
                    //                                                          .GroupBy(x => new { x.KenticoID, x.MatterName, x.ClientName })
                    //                                                          .Select(x => x).ToList();



                    //if (iAssignmentGroup.Count() > 0)
                    //{
                    //    iAssignmentGroup.ForEach(g =>
                    //    {
                    //        var mostUpdatedAssignmentRec = g.OrderByDescending(o => o.TimeStamp).First();
                    //        In3eAssignment iAssignment = new In3eAssignment();
                    //        iAssignment.assignment = mostUpdatedAssignmentRec;
                    //        iAssignments.Add(iAssignment);
                    //    });
                    //}
                    //else
                    //{
                    //    iAssignments.Add(new In3eAssignment());
                    //}

                    //#endregion scan InAssignmentsCMS

                    //#region scan InOrderingClientsCMS
                    //var inClientGroup = rcgamznProdEntities.InOrderingClientsCMS.Where(c => (c.NumOfAttempts ?? 0) <= attemptsAllowed)
                    //                                                           .GroupBy(c => new { c.KenticoID, c.OrderClientCompanyName })
                    //                                                           .Select(c => c).ToList();
                    //if (inClientGroup.Count() > 0)
                    //{
                    //    inClientGroup.ForEach(g =>
                    //    {
                    //        var mostUpdatedOrderClientRec = g.OrderByDescending(o => o.TimeStamp).First();
                    //        var existingInAssignment = iAssignments.Where(ia => ia.assignment.KenticoID == mostUpdatedOrderClientRec.KenticoID).Select(ia => ia).ToList();
                    //        existingInAssignment.ForEach(e => e.orderingClient = mostUpdatedOrderClientRec);
                    //    });

                    //}
                    //#endregion scan InOrderingClientsCMS

                    //#region scan InIncidentLocationsCMS
                    //var inIncidentLocations = rcgamznProdEntities.InIncidentLocationsCMS.Where(c => (c.NumOfAttempts ?? 0) <= attemptsAllowed)
                    //                                                                   .Select(c => c)
                    //                                                                   .OrderByDescending(c => c.TimeStamp)
                    //                                                                   .ToList();
                    //if (inIncidentLocations.Count() > 0)
                    //{
                    //    inIncidentLocations.ForEach(x =>
                    //    {
                    //        var existingInAssignment = iAssignments.Where(ia => ia.assignment.KenticoID == x.KenticoID).Select(ia => ia).ToList();
                    //        existingInAssignment.ForEach(a => a.incidentLocations.Add(x));
                    //    });
                    //}
                    //#endregion scan InIncidentLocationsCMS

                    //#region scan InPayorDetailsCMS
                    //var inPayorDetails = rcgamznProdEntities.InPayorDetailsCMS.Where(c => (c.NumOfAttempts ?? 0) <= attemptsAllowed)
                    //                                                         .Select(c => c)
                    //                                                         .OrderByDescending(c => c.TimeStamp)
                    //                                                         .ToList();
                    //if (inPayorDetails.Count() > 0)
                    //{
                    //    inPayorDetails.ForEach(x =>
                    //    {
                    //        var existingInAssignment = iAssignments.Where(ia => ia.assignment.KenticoID == x.KenticoID).Select(ia => ia).ToList();
                    //        existingInAssignment.ForEach(a => a.payorDetails.Add(x));
                    //    });
                    //}
                    //#endregion scan InPayorDetailsCMS

                    //#region scan InCoConsultantsCMS
                    //var inCoConsultants = rcgamznProdEntities.InCoConsultantsCMS.Where(c => (c.NumOfAttempts ?? 0) <= attemptsAllowed)
                    //                                                           .Select(c => c)
                    //                                                           .OrderByDescending(c => c.TimeStamp)
                    //                                                           .ToList();
                    //if (inCoConsultants.Count() > 0)
                    //{
                    //    inCoConsultants.ForEach(x =>
                    //    {
                    //        var existingInAssignment = iAssignments.Where(ia => ia.assignment.KenticoID == x.KenticoID).Select(ia => ia).ToList();
                    //        existingInAssignment.ForEach(a => a.coConsultants.Add(x));
                    //    });
                    //}
                    //#endregion scan InCoConsultantsCMS

                    //#region scan InAdditionalPartiesCMS
                    //var inAdditionalParties = rcgamznProdEntities.InAdditionalPartiesCMS.Where(c => (c.NumOfAttempts ?? 0) <= attemptsAllowed)
                    //                                                                   .Select(c => c)
                    //                                                                   .OrderByDescending(c => c.TimeStamp)
                    //                                                                   .ToList();
                    //if (inAdditionalParties.Count() > 0)
                    //{
                    //    inAdditionalParties.ForEach(x =>
                    //    {
                    //        var existingInAssignment = iAssignments.Where(ia => ia.assignment.KenticoID == x.KenticoID).Select(ia => ia).ToList();
                    //        existingInAssignment.ForEach(a => a.additionalParties.Add(x));
                    //    });
                    //}
                    //#endregion scan InAdditionalPartiesCMS
                }
            }

            return iAssignments;
        }

        public List<OutCustomerProfileCM> GetOutCustomers(int sqlCommandTimeout, bool isDebug = false, int attemptsAllowed = 20)
        {
            List<OutCustomerProfileCM> oCustomers = new List<OutCustomerProfileCM>();

            if (isDebug)
            {
                using (RCGAMZN_DEV01Entities rcgamznDevEntities = new RCGAMZN_DEV01Entities())
                {
                    rcgamznDevEntities.Database.CommandTimeout = sqlCommandTimeout;
                    var custGrouping = rcgamznDevEntities.OutCustomerProfileCMS.Where(x => (x.NumOfAttempts ?? 0) <= attemptsAllowed)
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
                using (RCGAMZN_PROD01Entities rcgamznProdEntities = new RCGAMZN_PROD01Entities())
                {
                    rcgamznProdEntities.Database.CommandTimeout = sqlCommandTimeout;
                    //var custGrouping = rcgamznProdEntities.OutCustomerProfileCMS.Where(x => (x.NumOfAttempts ?? 0) <= attemptsAllowed)
                    //                                                           .GroupBy(x => new { x.KenticoID, x.ClientNumber, x.CompanyName, x.FirstName, x.LastName })
                    //                                                           .Select(x => x).ToList();

                    //custGrouping.ForEach(g =>
                    //{
                    //    var mostedUpdatedRec = g.OrderByDescending(o => o.TimeStamp).First();
                    //    oCustomers.Add(mostedUpdatedRec);
                    //});
                }
            }

            return oCustomers;
        }

        public List<InCustomerProfileCM> GetInCustomers(int sqlCommandTimeout, bool isDebug = false, int attemptsAllowed = 20)
        {
            List<InCustomerProfileCM> iCustomers = new List<InCustomerProfileCM>();

            if (isDebug)
            {
                using (RCGAMZN_DEV01Entities rcgamznDevEntities = new RCGAMZN_DEV01Entities())
                {
                    rcgamznDevEntities.Database.CommandTimeout = sqlCommandTimeout;
                    var custGrouping = rcgamznDevEntities.InCustomerProfileCMS.Where(x => (x.NumOfAttempts ?? 0) <= attemptsAllowed)
                                                                              .GroupBy(x => new { x.KenticoID, x.CompanyName, x.FirstName, x.LastName })
                                                                              .Select(x => x).ToList();

                    custGrouping.ForEach(g =>
                    {
                        var mostedUpdatedRec = g.OrderByDescending(o => o.TimeStamp).First();
                        iCustomers.Add(mostedUpdatedRec);
                    });
                }
            }
            else
            {
                using (RCGAMZN_PROD01Entities rcgamznProdEntities = new RCGAMZN_PROD01Entities())
                {
                    rcgamznProdEntities.Database.CommandTimeout = sqlCommandTimeout;
                    //var custGrouping = rcgamznProdEntities.InCustomerProfileCMS.Where(x => (x.NumOfAttempts ?? 0) <= attemptsAllowed)
                    //                                                           .GroupBy(x => new { x.KenticoID, x.CompanyName, x.FirstName, x.LastName })
                    //                                                           .Select(x => x).ToList();

                    //custGrouping.ForEach(g =>
                    //{
                    //    var mostedUpdatedRec = g.OrderByDescending(o => o.TimeStamp).First();
                    //    iCustomers.Add(mostedUpdatedRec);
                    //});
                }
            }

            return iCustomers;
        }

        public void RemoveInCustomer(InCustomerProfileCM iCustomer, int sqlCommandTimeout, bool isDebug = false)
        {

            if (isDebug)
            {
                using (RCGAMZN_DEV01Entities rcgamznDevEntities = new RCGAMZN_DEV01Entities())
                {
                    rcgamznDevEntities.Database.CommandTimeout = sqlCommandTimeout;
                    var deletedInCustomers = rcgamznDevEntities.InCustomerProfileCMS.Where(k => k.KenticoID == iCustomer.KenticoID);
                    rcgamznDevEntities.InCustomerProfileCMS.RemoveRange(deletedInCustomers);
                    rcgamznDevEntities.SaveChanges();
                }
            }
            else
            {
                using (RCGAMZN_PROD01Entities rcgamznProdEntities = new RCGAMZN_PROD01Entities())
                {
                    rcgamznProdEntities.Database.CommandTimeout = sqlCommandTimeout;
                    //var deletedInCustomers = rcgamznDevEntities.InCustomerProfileCMS.Where(k => k.KenticoID == iCustomer.KenticoID);
                    //rcgamznDevEntities.InCustomerProfileCMS.RemoveRange(deletedInCustomers);
                    //rcgamznDevEntities.SaveChanges();
                }
            }
        }

        public void RemoveOutCustomer(OutCustomerProfileCM oCustomer, int sqlCommandTimeout, bool isDebug = false)
        {

            if (isDebug)
            {
                using (RCGAMZN_DEV01Entities rcgamznDevEntities = new RCGAMZN_DEV01Entities())
                {
                    rcgamznDevEntities.Database.CommandTimeout = sqlCommandTimeout;
                    var deletedOutCustomer = rcgamznDevEntities.OutCustomerProfileCMS.Where(k => k.KenticoID == oCustomer.KenticoID);
                    rcgamznDevEntities.OutCustomerProfileCMS.RemoveRange(deletedOutCustomer);
                    rcgamznDevEntities.SaveChanges();
                }
            }
            else
            {
                using (RCGAMZN_PROD01Entities rcgamznProdEntities = new RCGAMZN_PROD01Entities())
                {
                    rcgamznProdEntities.Database.CommandTimeout = sqlCommandTimeout;
                    //var deletedOutCustomer = rcgamznProdEntities.OutCustomerProfileCMS.Where(k => k.KenticoID == oCustomer.KenticoID);
                    //rcgamznProdEntities.OutCustomerProfileCMS.RemoveRange(deletedOutCustomer);
                    //rcgamznProdEntities.SaveChanges();
                }
            }
        }

        public void RemoveInAssignment(In3eAssignment iAssignment, int sqlCommandTimeout, bool isDebug = false)
        {

            if (isDebug)
            {
                using (RCGAMZN_DEV01Entities rcgamznDevEntities = new RCGAMZN_DEV01Entities())
                {
                    using (DbContextTransaction transaction = rcgamznDevEntities.Database.BeginTransaction())
                    {
                        rcgamznDevEntities.Database.CommandTimeout = sqlCommandTimeout;

                        var deletedInAssgnmnts = rcgamznDevEntities.InAssignmentsCMS.Where(k => k.E3EID == iAssignment.assignment.E3EID);

                        if (deletedInAssgnmnts.Count() > 0)
                            rcgamznDevEntities.InAssignmentsCMS.RemoveRange(deletedInAssgnmnts);

                        var deletedInOrderingClients = rcgamznDevEntities.InOrderingClientsCMS.Where(k => k.E3EID == iAssignment.assignment.E3EID);

                        if (deletedInOrderingClients.Count() > 0)
                            rcgamznDevEntities.InOrderingClientsCMS.RemoveRange(deletedInOrderingClients);

                        var deletedInCoConslts = rcgamznDevEntities.InCoConsultantsCMS.Where(k => k.E3EID == iAssignment.assignment.E3EID);

                        if (deletedInCoConslts.Count() > 0)
                            rcgamznDevEntities.InCoConsultantsCMS.RemoveRange(deletedInCoConslts);

                        var deletedInAddtnlParties = rcgamznDevEntities.InAdditionalPartiesCMS.Where(k => k.E3EID == iAssignment.assignment.E3EID);

                        if (deletedInAddtnlParties.Count() > 0)
                            rcgamznDevEntities.InAdditionalPartiesCMS.RemoveRange(deletedInAddtnlParties);

                        var deletedInPayDets = rcgamznDevEntities.InPayorDetailsCMS.Where(k => k.E3EID == iAssignment.assignment.E3EID);

                        if (deletedInPayDets.Count() > 0)
                            rcgamznDevEntities.InPayorDetailsCMS.RemoveRange(deletedInPayDets);

                        var deletedInIncLocs = rcgamznDevEntities.InIncidentLocationsCMS.Where(k => k.E3EID == iAssignment.assignment.E3EID);

                        if (deletedInIncLocs.Count() > 0)
                            rcgamznDevEntities.InIncidentLocationsCMS.RemoveRange(deletedInIncLocs);

                        rcgamznDevEntities.SaveChanges();
                    }
                }
            }
            else
            {
                using (RCGAMZN_PROD01Entities rcgamznProdEntities = new RCGAMZN_PROD01Entities())
                {
                    using (DbContextTransaction transaction = rcgamznProdEntities.Database.BeginTransaction())
                    {
                        rcgamznProdEntities.Database.CommandTimeout = sqlCommandTimeout;

                        //var deletedInAssgnmnts = rcgamznProdEntities.InAssignmentsCMS.Where(k => k.E3EID == iAssignment.assignment.E3EID);

                        //if (deletedInAssgnmnts.Count() > 0)
                        //    rcgamznProdEntities.InAssignmentsCMS.RemoveRange(deletedInAssgnmnts);

                        //var deletedInOrderingClients = rcgamznProdEntities.InOrderingClientsCMS.Where(k => k.E3EID == iAssignment.assignment.E3EID);

                        //if (deletedInOrderingClients.Count() > 0)
                        //    rcgamznProdEntities.InOrderingClientsCMS.RemoveRange(deletedInOrderingClients);

                        //var deletedInCoConslts = rcgamznProdEntities.InCoConsultantsCMS.Where(k => k.E3EID == iAssignment.assignment.E3EID);

                        //if (deletedInCoConslts.Count() > 0)
                        //    rcgamznProdEntities.InCoConsultantsCMS.RemoveRange(deletedInCoConslts);

                        //var deletedInAddtnlParties = rcgamznProdEntities.InAdditionalPartiesCMS.Where(k => k.E3EID == iAssignment.assignment.E3EID);

                        //if (deletedInAddtnlParties.Count() > 0)
                        //    rcgamznProdEntities.InAdditionalPartiesCMS.RemoveRange(deletedInAddtnlParties);

                        //var deletedInPayDets = rcgamznProdEntities.InPayorDetailsCMS.Where(k => k.E3EID == iAssignment.assignment.E3EID);

                        //if (deletedInPayDets.Count() > 0)
                        //    rcgamznProdEntities.InPayorDetailsCMS.RemoveRange(deletedInPayDets);

                        //var deletedInIncLocs = rcgamznProdEntities.InIncidentLocationsCMS.Where(k => k.E3EID == iAssignment.assignment.E3EID);

                        //if (deletedInIncLocs.Count() > 0)
                        //    rcgamznProdEntities.InIncidentLocationsCMS.RemoveRange(deletedInIncLocs);

                        //rcgamznProdEntities.SaveChanges();
                    }
                }
            }
        }

        public void RemoveOutAssignment(Out3eAssignment oAssignment, int sqlCommandTimeout, bool isDebug = false)
        {

            if (isDebug)
            {
                using (RCGAMZN_DEV01Entities rcgamznDevEntities = new RCGAMZN_DEV01Entities())
                {
                    rcgamznDevEntities.Database.CommandTimeout = sqlCommandTimeout;

                    var deletedOutAssgnmnts = rcgamznDevEntities.OutAssignmentsCMS.Where(k => k.E3EID == oAssignment.assignment.E3EID);

                    if (deletedOutAssgnmnts.Count() > 0)
                        rcgamznDevEntities.OutAssignmentsCMS.RemoveRange(deletedOutAssgnmnts);

                    var deletedOutOrderingClients = rcgamznDevEntities.OutOrderingClientsCMS.Where(k => k.E3EID == oAssignment.assignment.E3EID);

                    if (deletedOutOrderingClients.Count() > 0)
                        rcgamznDevEntities.OutOrderingClientsCMS.RemoveRange(deletedOutOrderingClients);

                    var deletedOutCoConslts = rcgamznDevEntities.OutCoConsultantsCMS.Where(k => k.E3EID == oAssignment.assignment.E3EID);

                    if (deletedOutCoConslts.Count() > 0)
                        rcgamznDevEntities.OutCoConsultantsCMS.RemoveRange(deletedOutCoConslts);

                    var deletedOutAddtnlParties = rcgamznDevEntities.OutAdditionalPartiesCMS.Where(k => k.E3EID == oAssignment.assignment.E3EID);

                    if (deletedOutAddtnlParties.Count() > 0)
                        rcgamznDevEntities.OutAdditionalPartiesCMS.RemoveRange(deletedOutAddtnlParties);

                    var deletedOutPayDets = rcgamznDevEntities.OutPayorDetailsCMS.Where(k => k.E3EID == oAssignment.assignment.E3EID);

                    if (deletedOutPayDets.Count() > 0)
                        rcgamznDevEntities.OutPayorDetailsCMS.RemoveRange(deletedOutPayDets);

                    var deletedOutIncLocs = rcgamznDevEntities.OutIncidentLocationsCMS.Where(k => k.E3EID == oAssignment.assignment.E3EID);

                    if (deletedOutIncLocs.Count() > 0)
                        rcgamznDevEntities.OutIncidentLocationsCMS.RemoveRange(deletedOutIncLocs);

                    rcgamznDevEntities.SaveChanges();
                }
            }
            else
            {
                using (RCGAMZN_PROD01Entities rcgamznProdEntities = new RCGAMZN_PROD01Entities())
                {
                    rcgamznProdEntities.Database.CommandTimeout = sqlCommandTimeout;

                    //var deletedOutAssgnmnts = rcgamznProdEntities.OutAssignmentsCMS.Where(k => k.E3EID == oAssignment.assignment.E3EID);

                    //if (deletedOutAssgnmnts.Count() > 0)
                    //    rcgamznProdEntities.OutAssignmentsCMS.RemoveRange(deletedOutAssgnmnts);

                    //var deletedOutOrderingClients = rcgamznProdEntities.OutOrderingClientsCMS.Where(k => k.E3EID == oAssignment.assignment.E3EID);

                    //if (deletedOutOrderingClients.Count() > 0)
                    //    rcgamznProdEntities.OutOrderingClientsCMS.RemoveRange(deletedOutOrderingClients);

                    //var deletedOutCoConslts = rcgamznProdEntities.OutCoConsultantsCMS.Where(k => k.E3EID == oAssignment.assignment.E3EID);

                    //if (deletedOutCoConslts.Count() > 0)
                    //    rcgamznProdEntities.OutCoConsultantsCMS.RemoveRange(deletedOutCoConslts);

                    //var deletedOutAddtnlParties = rcgamznProdEntities.OutAdditionalPartiesCMS.Where(k => k.E3EID == oAssignment.assignment.E3EID);

                    //if (deletedOutAddtnlParties.Count() > 0)
                    //    rcgamznProdEntities.OutAdditionalPartiesCMS.RemoveRange(deletedOutAddtnlParties);

                    //var deletedOutPayDets = rcgamznProdEntities.OutPayorDetailsCMS.Where(k => k.E3EID == oAssignment.assignment.E3EID);

                    //if (deletedOutPayDets.Count() > 0)
                    //    rcgamznProdEntities.OutPayorDetailsCMS.RemoveRange(deletedOutPayDets);

                    //var deletedOutIncLocs = rcgamznProdEntities.OutIncidentLocationsCMS.Where(k => k.E3EID == oAssignment.assignment.E3EID);

                    //if (deletedOutIncLocs.Count() > 0)
                    //    rcgamznProdEntities.OutIncidentLocationsCMS.RemoveRange(deletedOutIncLocs);

                    //rcgamznProdEntities.SaveChanges();
                }
            }
        }

        public void UpdateInCustMessageErr(string server,
                                            string dbInstance,
                                            string kenticoID,
                                            string errMsg,
                                            int sqlCommandTimeout,
                                            bool isDebug = false)
        {
            using (var objStreamReader = File.OpenText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $"datasource/sqlscripts/UpdateInCustMessageErr.sql")))
            {
                string sqlStmt = objStreamReader.ReadToEnd();

                sqlStmt = sqlStmt.Replace("@server", server);
                sqlStmt = sqlStmt.Replace("@instance", dbInstance);
                sqlStmt = sqlStmt.Replace("@kenticoID", kenticoID);
                sqlStmt = sqlStmt.Replace("@errMsg", errMsg.Replace("'", "\""));

                if (isDebug)
                {
                    RCGAMZN_DEV01Entities rcgamznDevEntities = new RCGAMZN_DEV01Entities();
                    rcgamznDevEntities.Database.CommandTimeout = sqlCommandTimeout;
                    rcgamznDevEntities.Database.ExecuteSqlCommand(sqlStmt);
                }
                else
                {
                    RCGAMZN_PROD01Entities rcgamznProdEntities = new RCGAMZN_PROD01Entities();
                    rcgamznProdEntities.Database.CommandTimeout = sqlCommandTimeout;
                    rcgamznProdEntities.Database.ExecuteSqlCommand(sqlStmt);
                }
            }
        }

        public void RemoveInCustMessage(string server,
                                          string dbInstance,
                                          string kenticoID,
                                          int sqlCommandTimeout,
                                          bool isDebug = false)
        {
            using (var objStreamReader = File.OpenText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $"datasource/sqlscripts/RemoveInCustMessage.sql")))
            {
                string sqlStmt = objStreamReader.ReadToEnd();

                sqlStmt = sqlStmt.Replace("@server", server);
                sqlStmt = sqlStmt.Replace("@instance", dbInstance);
                sqlStmt = sqlStmt.Replace("@kenticoID", kenticoID);

                if (isDebug)
                {
                    RCGAMZN_DEV01Entities rcgamznDevEntities = new RCGAMZN_DEV01Entities();
                    rcgamznDevEntities.Database.CommandTimeout = sqlCommandTimeout;
                    rcgamznDevEntities.Database.ExecuteSqlCommand(sqlStmt);
                }
                else
                {
                    RCGAMZN_PROD01Entities rcgamznProdEntities = new RCGAMZN_PROD01Entities();
                    rcgamznProdEntities.Database.CommandTimeout = sqlCommandTimeout;
                    rcgamznProdEntities.Database.ExecuteSqlCommand(sqlStmt);
                }
            }
        }

        public void RemoveInAssgnMessage(string server,
                                          string dbInstance,
                                          string kenticoID,
                                          int sqlCommandTimeout,
                                          bool isDebug = false)
        {
            using (var objStreamReader = File.OpenText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $"datasource/sqlscripts/RemoveInAssgnMessage.sql")))
            {
                string sqlStmt = objStreamReader.ReadToEnd();

                sqlStmt = sqlStmt.Replace("@server", server);
                sqlStmt = sqlStmt.Replace("@instance", dbInstance);
                sqlStmt = sqlStmt.Replace("@kenticoID", kenticoID);

                if (isDebug)
                {
                    RCGAMZN_DEV01Entities rcgamznDevEntities = new RCGAMZN_DEV01Entities();
                    rcgamznDevEntities.Database.CommandTimeout = sqlCommandTimeout;
                    rcgamznDevEntities.Database.ExecuteSqlCommand(sqlStmt);
                }
                else
                {
                    RCGAMZN_PROD01Entities rcgamznProdEntities = new RCGAMZN_PROD01Entities();
                    rcgamznProdEntities.Database.CommandTimeout = sqlCommandTimeout;
                    rcgamznProdEntities.Database.ExecuteSqlCommand(sqlStmt);
                }
            }
        }

        public void UpdateInAssgnMessageErr(string server,
                                             string dbInstance,
                                             string kenticoID,
                                             string errMsg,
                                             int sqlCommandTimeout,
                                             bool isDebug = false)
        {
            using (var objStreamReader = File.OpenText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $"datasource/sqlscripts/UpdateInAssgnMessageErr.sql")))
            {
                string sqlStmt = objStreamReader.ReadToEnd();

                sqlStmt = sqlStmt.Replace("@server", server);
                sqlStmt = sqlStmt.Replace("@instance", dbInstance);
                sqlStmt = sqlStmt.Replace("@kenticoID", kenticoID);
                sqlStmt = sqlStmt.Replace("@errMsg", errMsg.Replace("'", "\""));

                if (isDebug)
                {
                    RCGAMZN_DEV01Entities rcgamznDevEntities = new RCGAMZN_DEV01Entities();
                    rcgamznDevEntities.Database.CommandTimeout = sqlCommandTimeout;
                    rcgamznDevEntities.Database.ExecuteSqlCommand(sqlStmt);
                }
                else
                {
                    RCGAMZN_PROD01Entities rcgamznProdEntities = new RCGAMZN_PROD01Entities();
                    rcgamznProdEntities.Database.CommandTimeout = sqlCommandTimeout;
                    rcgamznProdEntities.Database.ExecuteSqlCommand(sqlStmt);
                }
            }
        }


        public void RemoveOutAssgnMessage(string server,
                                          string dbInstance,
                                          string mattIndex,
                                          int sqlCommandTimeout,
                                          bool isDebug = false)
        {
            using (var objStreamReader = File.OpenText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $"datasource/sqlscripts/RemoveOutAssgnMessage.sql")))
            {
                string sqlStmt = objStreamReader.ReadToEnd();

                sqlStmt = sqlStmt.Replace("@server", server);
                sqlStmt = sqlStmt.Replace("@instance", dbInstance);
                sqlStmt = sqlStmt.Replace("@mattIndex", mattIndex);

                if (isDebug)
                {
                    RCGAMZN_DEV01Entities rcgamznDevEntities = new RCGAMZN_DEV01Entities();
                    rcgamznDevEntities.Database.CommandTimeout = sqlCommandTimeout;
                    rcgamznDevEntities.Database.ExecuteSqlCommand(sqlStmt);
                }
                else
                {
                    RCGAMZN_PROD01Entities rcgamznProdEntities = new RCGAMZN_PROD01Entities();
                    rcgamznProdEntities.Database.CommandTimeout = sqlCommandTimeout;
                    rcgamznProdEntities.Database.ExecuteSqlCommand(sqlStmt);
                }
            }
        }

        public void UpdateOutAssgnMessageErr(string server,
                                             string dbInstance,
                                             string mattIndex,
                                             string errMsg,
                                             int sqlCommandTimeout,
                                             bool isDebug = false)
        {
            using (var objStreamReader = File.OpenText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $"datasource/sqlscripts/UpdateOutAssgnMessageErr.sql")))
            {
                string sqlStmt = objStreamReader.ReadToEnd();

                sqlStmt = sqlStmt.Replace("@server", server);
                sqlStmt = sqlStmt.Replace("@instance", dbInstance);
                sqlStmt = sqlStmt.Replace("@mattIndex", mattIndex);
                sqlStmt = sqlStmt.Replace("@errMsg", errMsg);

                if (isDebug)
                {
                    RCGAMZN_DEV01Entities rcgamznDevEntities = new RCGAMZN_DEV01Entities();
                    rcgamznDevEntities.Database.CommandTimeout = sqlCommandTimeout;
                    rcgamznDevEntities.Database.ExecuteSqlCommand(sqlStmt);
                }
                else
                {
                    RCGAMZN_PROD01Entities rcgamznProdEntities = new RCGAMZN_PROD01Entities();
                    rcgamznProdEntities.Database.CommandTimeout = sqlCommandTimeout;
                    rcgamznProdEntities.Database.ExecuteSqlCommand(sqlStmt);
                }
            }
        }

        public void AddOrUpdateKenticoAssignmentRel(KenticoAssignmentRelCM kentico3ERel, int sqlCommandTimeout, bool isDebug = false)
        {
            if (isDebug)
            {
                using (RCGAMZN_DEV01Entities rcgamznDevEntities = new RCGAMZN_DEV01Entities())
                {
                    rcgamznDevEntities.Database.CommandTimeout = sqlCommandTimeout;
                    var k3eMattRels = rcgamznDevEntities.KenticoAssignmentRelCMS.Where(k => k.ClientIndex == kentico3ERel.ClientIndex || k.ClientNumber == kentico3ERel.ClientNumber);

                    if (k3eMattRels.Count() > 0)
                    {
                        k3eMattRels.First().E3EID = kentico3ERel.E3EID;
                        k3eMattRels.First().KenticoID = kentico3ERel.KenticoID;
                        k3eMattRels.First().MatterIndex = kentico3ERel.MatterIndex;
                        k3eMattRels.First().MatterNumber = kentico3ERel.MatterNumber;
                        k3eMattRels.First().ClientIndex = kentico3ERel.ClientIndex;
                        k3eMattRels.First().ClientNumber = kentico3ERel.ClientNumber;
                        k3eMattRels.First().TimeStamp = DateTime.Now;
                    }
                    else
                    {
                        rcgamznDevEntities.KenticoAssignmentRelCMS.Add(kentico3ERel);
                    }

                    rcgamznDevEntities.SaveChanges();
                }
            }
            else
            {
                using (RCGAMZN_PROD01Entities rcgamznProdEntities = new RCGAMZN_PROD01Entities())
                {
                    rcgamznProdEntities.Database.CommandTimeout = sqlCommandTimeout;
                    //var k3eMattRels = rcgamznProdEntities.KenticoAssignmentRelCMS.Where(k => k.ClientIndex == kentico3ERel.ClientIndex || k.ClientNumber == kentico3ERel.ClientNumber);

                    //if (k3eMattRels.Count() > 0)
                    //{
                    //    k3eMattRels.First().E3EID = kentico3ERel.E3EID;
                    //    k3eMattRels.First().KenticoID = kentico3ERel.KenticoID;
                    //    k3eMattRels.First().MatterIndex = kentico3ERel.MatterIndex;
                    //    k3eMattRels.First().MatterNumber = kentico3ERel.MatterNumber;
                    //    k3eMattRels.First().ClientIndex = kentico3ERel.ClientIndex;
                    //    k3eMattRels.First().ClientNumber = kentico3ERel.ClientNumber;
                    //    k3eMattRels.First().TimeStamp = DateTime.Now;
                    //}
                    //else
                    //{
                    //    rcgamznProdEntities.KenticoAssignmentRelCMS.Add(kentico3ERel);
                    //}

                    //rcgamznProdEntities.SaveChanges();
                }
            }
        }

        public KenticoAssignmentRelCM GetKenticoAssignmentRel(int matterIndex, int sqlCommandTimeout, bool isDebug = false)
        {
            KenticoAssignmentRelCM kentico3ERels = new KenticoAssignmentRelCM();

            if (isDebug)
            {
                using (RCGAMZN_DEV01Entities rcgamznDevEntities = new RCGAMZN_DEV01Entities())
                {
                    rcgamznDevEntities.Database.CommandTimeout = sqlCommandTimeout;
                    var results = rcgamznDevEntities.KenticoAssignmentRelCMS.Where(k => k.MatterIndex == matterIndex).OrderByDescending(x => x.TimeStamp).Select(k => k).ToList();
                    kentico3ERels = results.Count() > 0 ? results.First() : null;
                }
            }
            else
            {
                using (RCGAMZN_PROD01Entities rcgamznProdEntities = new RCGAMZN_PROD01Entities())
                {
                    rcgamznProdEntities.Database.CommandTimeout = sqlCommandTimeout;
                    //var results = rcgamznProdEntities.KenticoAssignmentRelCMS.Where(k => k.MatterIndex == matterIndex).OrderByDescending(x => x.TimeStamp).Select(k => k).ToList();
                    //kentico3ERels = results.Count() > 0 ? results.First() : null;
                }
            }

            return kentico3ERels;
        }

        public void AddOrUpdateKenticoCustomerRel(KenticoCustomerRelCM kenticoCustomerRel, int sqlCommandTimeout, bool isDebug = false)
        {
            if (isDebug)
            {
                using (RCGAMZN_DEV01Entities rcgamznDevEntities = new RCGAMZN_DEV01Entities())
                {
                    rcgamznDevEntities.Database.CommandTimeout = sqlCommandTimeout;
                    var kenticoCustomers = rcgamznDevEntities.KenticoCustomerRelCMS.Where(k => k.ClientNumber == kenticoCustomerRel.ClientNumber);

                    if (kenticoCustomers.Count() > 0)
                    {
                        var kCust = kenticoCustomers.First();
                        kCust.EntityID = kenticoCustomerRel.EntityID;
                        kCust.KenticoID = kenticoCustomerRel.KenticoID;
                        kCust.ClientNumber = kenticoCustomerRel.ClientNumber;
                        kCust.ClientName = kenticoCustomerRel.ClientName;
                        kCust.TimeStamp = DateTime.Now;
                    }
                    else
                    {
                        rcgamznDevEntities.KenticoCustomerRelCMS.Add(kenticoCustomerRel);
                    }

                    rcgamznDevEntities.SaveChanges();
                }
            }
            else
            {
                //using (RCGAMZN_PROD01Entities rcgamznProdEntities = new RCGAMZN_PROD01Entities())
                //{
                //    rcgamznProdEntities.Database.CommandTimeout = sqlCommandTimeout;
                //    var kenticoCustomers = rcgamznProdEntities.KenticoCustomerRelCMS.Where(k => k.ClientNumber == kenticoCustomerRel.ClientNumber);

                //    if (kenticoCustomers.Count() > 0)
                //    {
                //        var kCust = kenticoCustomers.First();
                //        kCust.EntityID = kenticoCustomerRel.EntityID;
                //        kCust.KenticoID = kenticoCustomerRel.KenticoID;
                //        kCust.ClientNumber = kenticoCustomerRel.ClientNumber;
                //        kCust.ClientName = kenticoCustomerRel.ClientName;
                //        kCust.TimeStamp = DateTime.Now;
                //    }
                //    else
                //    {
                //        rcgamznProdEntities.KenticoCustomerRelCMS.Add(kenticoCustomerRel);
                //    }

                //    rcgamznProdEntities.SaveChanges();
                //}
            }
        }

        public KenticoCustomerRelCM GetKenticoCustomerRel(string cliNumber, int sqlCommandTimeout, bool isDebug = false)
        {
            KenticoCustomerRelCM kenticoCustomerRel = new KenticoCustomerRelCM();

            if (isDebug)
            {
                using (RCGAMZN_DEV01Entities rcgamznDevEntities = new RCGAMZN_DEV01Entities())
                {
                    rcgamznDevEntities.Database.CommandTimeout = sqlCommandTimeout;
                    var results = rcgamznDevEntities.KenticoCustomerRelCMS.Where(k => k.ClientNumber == cliNumber);
                    kenticoCustomerRel = results.Count() > 0 ? results.First() : null;
                }
            }
            else
            {
                using (RCGAMZN_PROD01Entities rcgamznProdEntities = new RCGAMZN_PROD01Entities())
                {
                    rcgamznProdEntities.Database.CommandTimeout = sqlCommandTimeout;
                    //var results = rcgamznProdEntities.KenticoCustomerRelCMS.Where(k => k.ClientNumber == cliNumber);
                    //kenticoCustomerRel = results.Count() > 0 ? results.First() : null;
                }
            }

            return kenticoCustomerRel;
        }

        #endregion CMS Table SQL Actions

        #region Rimkus Connect REST API
        public IEnumerable<CMS_GetLookupTypes_Result> GetLookupTypes(int sqlCommandTimeout, bool isDebug = false)
        {
            IEnumerable<CMS_GetLookupTypes_Result> results = null;

            if (isDebug)
            {
                RCGAMZN_DEV01Entities rcgamznDevEntities = new RCGAMZN_DEV01Entities();
                rcgamznDevEntities.Database.CommandTimeout = sqlCommandTimeout;
                results = rcgamznDevEntities.CMS_GetLookupTypes().ToList();
            }
            else
            {
                RCGAMZN_PROD01Entities rcgamznProdEntities = new RCGAMZN_PROD01Entities();
                rcgamznProdEntities.Database.CommandTimeout = sqlCommandTimeout;
                //results = rcgamznProdEntities.CMS_GetLookupTypes().ToList();
            }

            return results;
        }

        public List<CMS_GetLookupCodes_Result> GetLookupCodes(int lookupId, int sqlCommandTimeout, bool isDebug = false)
        {
            List<CMS_GetLookupCodes_Result> results = null;

            if (isDebug)
            {
                var lookupTypes = GetLookupTypes(sqlCommandTimeout, isDebug).Where(x => x.ID == lookupId).Select(x => x);
                var lookupType = (lookupTypes != null) ? lookupTypes.First().Type : "";

                RCGAMZN_DEV01Entities rcgamznDevEntities = new RCGAMZN_DEV01Entities();
                rcgamznDevEntities.Database.CommandTimeout = sqlCommandTimeout;
                results = rcgamznDevEntities.CMS_GetLookupCodes(lookupType).ToList();
            }
            else
            {
                var lookupTypes = GetLookupTypes(sqlCommandTimeout, isDebug).Where(x => x.ID == lookupId).Select(x => x);
                var lookupType = (lookupTypes != null) ? lookupTypes.First().Type : "";

                RCGAMZN_PROD01Entities rcgamznProdEntities = new RCGAMZN_PROD01Entities();
                rcgamznProdEntities.Database.CommandTimeout = sqlCommandTimeout;
                //results = rcgamznProdEntities.CMS_GetLookupCodes(lookupType).ToList();
            }

            return results;
        }

        public List<CMS_SearchTimekeepers_Result> GetTimekeepers(string name, int sqlCommandTimeout, bool isDebug = false)
        {
            List<CMS_SearchTimekeepers_Result> results = null;

            if (isDebug)
            {
                RCGAMZN_DEV01Entities rcgamznDevEntities = new RCGAMZN_DEV01Entities();
                rcgamznDevEntities.Database.CommandTimeout = sqlCommandTimeout;
                results = rcgamznDevEntities.CMS_SearchTimekeepers(name).ToList();
            }
            else
            {
                RCGAMZN_PROD01Entities rcgamznProdEntities = new RCGAMZN_PROD01Entities();
                rcgamznProdEntities.Database.CommandTimeout = sqlCommandTimeout;
                //results = rcgamznProdEntities.CMS_SearchTimekeepers(name).ToList();
            }

            return results;
        }

        public List<CMS_SearchClients_Result> GetClients(string name, int sqlCommandTimeout, bool isDebug = false)
        {
            List<CMS_SearchClients_Result> results = null;

            if (isDebug)
            {
                RCGAMZN_DEV01Entities rcgamznDevEntities = new RCGAMZN_DEV01Entities();
                rcgamznDevEntities.Database.CommandTimeout = sqlCommandTimeout;
                results = rcgamznDevEntities.CMS_SearchClients(name).ToList();
            }
            else
            {
                RCGAMZN_PROD01Entities rcgamznProdEntities = new RCGAMZN_PROD01Entities();
                rcgamznProdEntities.Database.CommandTimeout = sqlCommandTimeout;
                //results = rcgamznProdEntities.CMS_SearchClients(name).ToList();
            }

            return results;
        }

        public List<CMS_SearchEntity_Result> GetEntities(string name, int sqlCommandTimeout, bool isDebug = false)
        {
            List<CMS_SearchEntity_Result> results = null;

            if (isDebug)
            {
                RCGAMZN_DEV01Entities rcgamznDevEntities = new RCGAMZN_DEV01Entities();
                rcgamznDevEntities.Database.CommandTimeout = sqlCommandTimeout;
                results = rcgamznDevEntities.CMS_SearchEntity(name).ToList();
            }
            else
            {
                RCGAMZN_PROD01Entities rcgamznProdEntities = new RCGAMZN_PROD01Entities();
                rcgamznProdEntities.Database.CommandTimeout = sqlCommandTimeout;
                //results = rcgamznProdEntities.CMS_SearchEntity(name).ToList();
            }

            return results;
        }

        public List<CMS_SearchRelMatters_Result> GetRelMatters(string name, int sqlCommandTimeout, bool isDebug = false)
        {
            List<CMS_SearchRelMatters_Result> results = null;

            if (isDebug)
            {
                RCGAMZN_DEV01Entities rcgamznDevEntities = new RCGAMZN_DEV01Entities();
                rcgamznDevEntities.Database.CommandTimeout = sqlCommandTimeout;
                results = rcgamznDevEntities.CMS_SearchRelMatters(name).ToList();
            }
            else
            {
                RCGAMZN_PROD01Entities rcgamznProdEntities = new RCGAMZN_PROD01Entities();
                rcgamznProdEntities.Database.CommandTimeout = sqlCommandTimeout;
                //results = rcgamznProdEntities.CMS_SearchRelMatters(name).ToList();
            }

            return results;
        }

        public List<CMS_GetClientsByType_Result> GetClientsByType(int lookupId, int sqlCommandTimeout, bool isDebug = false)
        {
            List<CMS_GetClientsByType_Result> results = null;

            if (isDebug)
            {
                RCGAMZN_DEV01Entities rcgamznDevEntities = new RCGAMZN_DEV01Entities();
                rcgamznDevEntities.Database.CommandTimeout = sqlCommandTimeout;
                results = rcgamznDevEntities.CMS_GetClientsByType(lookupId.ToString()).ToList();
            }
            else
            {
                RCGAMZN_PROD01Entities rcgamznProdEntities = new RCGAMZN_PROD01Entities();
                rcgamznProdEntities.Database.CommandTimeout = sqlCommandTimeout;
                //results = rcgamznProdEntities.CMS_GetClientsByType(lookupId.ToString()).ToList();
            }

            return results;
        }

        public List<CMS_GetClientMatters_Result> GetClientMatters(int clientNo, int sqlCommandTimeout, bool isDebug = false)
        {
            List<CMS_GetClientMatters_Result> results = null;

            if (isDebug)
            {
                RCGAMZN_DEV01Entities rcgamznDevEntities = new RCGAMZN_DEV01Entities();
                rcgamznDevEntities.Database.CommandTimeout = sqlCommandTimeout;
                results = rcgamznDevEntities.CMS_GetClientMatters(clientNo.ToString("D7")).ToList();
            }
            else
            {
                RCGAMZN_PROD01Entities rcgamznProdEntities = new RCGAMZN_PROD01Entities();
                rcgamznProdEntities.Database.CommandTimeout = sqlCommandTimeout;
                //results = rcgamznProdEntities.CMS_GetClientMatters(clientNo.ToString("D7")).ToList();
            }

            return results;
        }

        public List<CMS_GetClientMattersByRelSiteEmail_Result> GetClientMattersByEmail(string email, int sqlCommandTimeout, bool isDebug = false)
        {
            List<CMS_GetClientMattersByRelSiteEmail_Result> results = null;

            if (isDebug)
            {
                RCGAMZN_DEV01Entities rcgamznDevEntities = new RCGAMZN_DEV01Entities();
                rcgamznDevEntities.Database.CommandTimeout = sqlCommandTimeout;
                results = rcgamznDevEntities.CMS_GetClientMattersByRelSiteEmail(email).ToList();
            }
            else
            {
                RCGAMZN_PROD01Entities rcgamznProdEntities = new RCGAMZN_PROD01Entities();
                rcgamznProdEntities.Database.CommandTimeout = sqlCommandTimeout;
                //results = rcgamznProdEntities.CMS_GetClientMattersByRelSiteEmail(email).ToList();
            }

            return results;
        }


        public CMS_GetMatterDetails_Result GetMatterDetails(int mattIndex, int sqlCommandTimeout, bool isDebug = false)
        {
            List<CMS_GetMatterDetails_Result> results = null;

            if (isDebug)
            {
                RCGAMZN_DEV01Entities rcgamznDevEntities = new RCGAMZN_DEV01Entities();
                rcgamznDevEntities.Database.CommandTimeout = sqlCommandTimeout;
                results = rcgamznDevEntities.CMS_GetMatterDetails(mattIndex.ToString()).ToList();
            }
            else
            {
                RCGAMZN_PROD01Entities rcgamznProdEntities = new RCGAMZN_PROD01Entities();
                rcgamznProdEntities.Database.CommandTimeout = sqlCommandTimeout;
                //results = rcgamznProdEntities.CMS_GetMatterDetails(mattIndex.ToString()).ToList();
            }

            if (results.Count() == 0)
                throw new AssignmentNotFoundException($"Assignment ID Not Found. No assignment with ID = {mattIndex}");

            return results.First();
        }

        public List<CMS_GetMatterNotes_Result> GetMatterNotes(int mattIndex, int sqlCommandTimeout, bool isDebug = false)
        {
            List<CMS_GetMatterNotes_Result> results = null;

            if (isDebug)
            {
                RCGAMZN_DEV01Entities rcgamznDevEntities = new RCGAMZN_DEV01Entities();
                rcgamznDevEntities.Database.CommandTimeout = sqlCommandTimeout;
                results = rcgamznDevEntities.CMS_GetMatterNotes(mattIndex.ToString()).ToList();
            }
            else
            {
                RCGAMZN_PROD01Entities rcgamznProdEntities = new RCGAMZN_PROD01Entities();
                rcgamznProdEntities.Database.CommandTimeout = sqlCommandTimeout;
                //results = rcgamznProdEntities.CMS_GetMatterNotes(mattIndex.ToString()).ToList();
            }

            return results;
        }

        public CMS_GetFullMatterDetails_Result GetFullMatterDetails(int mattIndex, int sqlCommandTimeout, bool isDebug = false)
        {
            List<CMS_GetFullMatterDetails_Result> results = null;

            if (isDebug)
            {
                RCGAMZN_DEV01Entities rcgamznDevEntities = new RCGAMZN_DEV01Entities();
                rcgamznDevEntities.Database.CommandTimeout = sqlCommandTimeout;
                results = rcgamznDevEntities.CMS_GetFullMatterDetails(mattIndex.ToString()).ToList();
            }
            else
            {
                RCGAMZN_PROD01Entities rcgamznProdEntities = new RCGAMZN_PROD01Entities();
                rcgamznProdEntities.Database.CommandTimeout = sqlCommandTimeout;
                //results = rcgamznProdEntities.CMS_GetFullMatterDetails(mattIndex.ToString()).ToList();
            }

            if (results.Count() == 0)
                throw new AssignmentNotFoundException($"Assignment ID Not Found. No assignment with ID = {mattIndex}");

            return results.First();
        }

        public CMS_GetFullMatterOrderingClientDetails_Result GetFullMatterOrderingClientDetails(int mattIndex, int sqlCommandTimeout, bool isDebug = false)
        {
            List<CMS_GetFullMatterOrderingClientDetails_Result> results = null;

            if (isDebug)
            {
                RCGAMZN_DEV01Entities rcgamznDevEntities = new RCGAMZN_DEV01Entities();
                rcgamznDevEntities.Database.CommandTimeout = sqlCommandTimeout;
                results = rcgamznDevEntities.CMS_GetFullMatterOrderingClientDetails(mattIndex.ToString()).ToList();
            }
            else
            {
                RCGAMZN_PROD01Entities rcgamznProdEntities = new RCGAMZN_PROD01Entities();
                rcgamznProdEntities.Database.CommandTimeout = sqlCommandTimeout;
                //results = rcgamznProdEntities.CMS_GetFullMatterOrderingClientDetails(mattIndex.ToString()).ToList();
            }

            return results.First();
        }

        public List<CMS_GetFullMatterIncidentLocationsDetails_Result> GetFullMatterIncidentLocationDetails(int mattIndex, int sqlCommandTimeout, bool isDebug = false)
        {
            List<CMS_GetFullMatterIncidentLocationsDetails_Result> results = null;

            if (isDebug)
            {
                RCGAMZN_DEV01Entities rcgamznDevEntities = new RCGAMZN_DEV01Entities();
                rcgamznDevEntities.Database.CommandTimeout = sqlCommandTimeout;
                results = rcgamznDevEntities.CMS_GetFullMatterIncidentLocationsDetails(mattIndex.ToString()).ToList();
            }
            else
            {
                RCGAMZN_PROD01Entities rcgamznProdEntities = new RCGAMZN_PROD01Entities();
                rcgamznProdEntities.Database.CommandTimeout = sqlCommandTimeout;
                //results = rcgamznProdEntities.CMS_GetFullMatterIncidentLocationsDetails(mattIndex.ToString()).ToList();
            }

            return results;
        }

        public List<CMS_GetFullMatterCoConsultantDetails_Result> GetFullMatterCoConsultantDetails(int mattIndex, int sqlCommandTimeout, bool isDebug = false)
        {
            List<CMS_GetFullMatterCoConsultantDetails_Result> results = null;

            if (isDebug)
            {
                RCGAMZN_DEV01Entities rcgamznDevEntities = new RCGAMZN_DEV01Entities();
                rcgamznDevEntities.Database.CommandTimeout = sqlCommandTimeout;
                results = rcgamznDevEntities.CMS_GetFullMatterCoConsultantDetails(mattIndex.ToString()).ToList();
            }
            else
            {
                RCGAMZN_PROD01Entities rcgamznProdEntities = new RCGAMZN_PROD01Entities();
                rcgamznProdEntities.Database.CommandTimeout = sqlCommandTimeout;
                //results = rcgamznProdEntities.CMS_GetFullMatterCoConsultantDetails(mattIndex.ToString()).ToList();
            }

            return results;
        }

        public List<CMS_GetFullMatterPayorDetails_Result> GetFullMatterPayorDetails(int mattIndex, int sqlCommandTimeout, bool isDebug = false)
        {
            List<CMS_GetFullMatterPayorDetails_Result> results = null;

            if (isDebug)
            {
                RCGAMZN_DEV01Entities rcgamznDevEntities = new RCGAMZN_DEV01Entities();
                rcgamznDevEntities.Database.CommandTimeout = sqlCommandTimeout;
                results = rcgamznDevEntities.CMS_GetFullMatterPayorDetails(mattIndex.ToString()).ToList();
            }
            else
            {
                RCGAMZN_PROD01Entities rcgamznProdEntities = new RCGAMZN_PROD01Entities();
                rcgamznProdEntities.Database.CommandTimeout = sqlCommandTimeout;
                //results = rcgamznProdEntities.CMS_GetFullMatterPayorDetails(mattIndex.ToString()).ToList();
            }

            return results;
        }

        public List<CMS_GetFullMatterAdditionalPartiesDetails_Result> GetFullMatterAdditionalPartiesDetails(int mattIndex, int sqlCommandTimeout, bool isDebug = false)
        {
            List<CMS_GetFullMatterAdditionalPartiesDetails_Result> results = null;

            if (isDebug)
            {
                RCGAMZN_DEV01Entities rcgamznDevEntities = new RCGAMZN_DEV01Entities();
                rcgamznDevEntities.Database.CommandTimeout = sqlCommandTimeout;
                results = rcgamznDevEntities.CMS_GetFullMatterAdditionalPartiesDetails(mattIndex.ToString()).ToList();
            }
            else
            {
                RCGAMZN_PROD01Entities rcgamznProdEntities = new RCGAMZN_PROD01Entities();
                rcgamznProdEntities.Database.CommandTimeout = sqlCommandTimeout;
                //results = rcgamznProdEntities.CMS_GetFullMatterAdditionalPartiesDetails(mattIndex.ToString()).ToList();
            }

            return results;
        }

        #endregion Rimkus Connect REST API

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
        #endregion Kentico CMS Te3e
    }

    public class KenticoCustomerGrouping
    {
        public string KenticoID { get; set; }
        public string ClientNumber { get; set; }
        public string ClientName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
