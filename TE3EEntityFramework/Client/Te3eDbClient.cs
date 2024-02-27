using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TE3EEntityFramework.Data.KenticoCMS;
using TE3EEntityFramework.Data.KenticoCMS._3EProcessItem;
using TE3EEntityFramework.Data.Te3e.CMS.CustomException;
using TE3EEntityFramework.Data.TeamsDMS;
using TE3EEntityFramework.Data.TrackerSafe;
using TE3EEntityFramework.Datasource;
using TE3EEntityFramework.Extension;
using TE3EEntityFramework.imageUtil;
using TE3EEntityFramework.Setting;

namespace TE3EEntityFramework.Client
{
    public class Te3eDbClient
    {
        private TrackerSafeWebClient tSClient;
        private TrackerSafeAppSetting _appSettings;

        public Te3eDbClient()
        {

        }

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

        public Te3eDbClient(TrackerSafeAppSetting appSettings)
        {
            _appSettings = appSettings;
            tSClient = new TrackerSafeWebClient(appSettings);
        }

        public IEnumerable<RetrieveCollectionItemsByPastDueDays_Result> RetrieveCollectionItemsByPastDueDays(int numOfDays, int sqlCommandTimeout, bool isDebug = false)
        {
            IEnumerable<RetrieveCollectionItemsByPastDueDays_Result> results = null;

            if (isDebug)
            {
                TE3ERCGSyncEntities tE3EDBEntities = new TE3ERCGSyncEntities();
                tE3EDBEntities.Database.CommandTimeout = sqlCommandTimeout;
                results = tE3EDBEntities.RetrieveCollectionItemsByPastDueDays(numOfDays).ToList();
            }
            else
            {
                TE3ERCGSYNCPRODEntities tE3EDBProdEntities = new TE3ERCGSYNCPRODEntities();
                tE3EDBProdEntities.Database.CommandTimeout = sqlCommandTimeout;
                results = tE3EDBProdEntities.RetrieveCollectionItemsByPastDueDays(numOfDays).ToList();
            }

            return results;
        }

        public IEnumerable<CustomSubjectLine> RetrieveCustomSubjectLine(int sqlCommandTimeout, bool isDebug = false)
        {
            IEnumerable<CustomSubjectLine> results = null;

            if (isDebug)
            {
                TE3ERCGSyncEntities tE3EDBEntities = new TE3ERCGSyncEntities();
                tE3EDBEntities.Database.CommandTimeout = sqlCommandTimeout;
                results = (from cSubLine in tE3EDBEntities.CustomSubjectLines
                           select cSubLine);
            }
            else
            {
                TE3ERCGSYNCPRODEntities tE3EDBProdEntities = new TE3ERCGSYNCPRODEntities();
                tE3EDBProdEntities.Database.CommandTimeout = sqlCommandTimeout;
                results = (from cSubLine in tE3EDBProdEntities.CustomSubjectLines
                           select cSubLine);
            }

            return results;
        }

        public IEnumerable<RetrieveLetterHeaderAddress_Result> RetrieveLetterHeadAddresses(string matterNo, int sqlCommandTimeout, bool isDebug = false)
        {
            IEnumerable<RetrieveLetterHeaderAddress_Result> results = null;

            if (isDebug)
            {
                TE3ERCGSyncEntities tE3EDBEntities = new TE3ERCGSyncEntities();
                tE3EDBEntities.Database.CommandTimeout = sqlCommandTimeout;
                results = tE3EDBEntities.RetrieveLetterHeaderAddress(matterNo);
            }
            else
            {
                TE3ERCGSYNCPRODEntities tE3EDBProdEntities = new TE3ERCGSYNCPRODEntities();
                tE3EDBProdEntities.Database.CommandTimeout = sqlCommandTimeout;
                results = tE3EDBProdEntities.RetrieveLetterHeaderAddress(matterNo);
            }

            return results;
        }

        public List<RetrieveItemizedInvCollection_Result> RetrieveItemizedInvCollection(string collectionItem, int sqlCommandTimeout, bool isDebug = false)
        {
            IEnumerable<RetrieveItemizedInvCollection_Result> results = null;

            if (isDebug)
            {
                TE3ERCGSyncEntities tE3EDBEntities = new TE3ERCGSyncEntities();
                tE3EDBEntities.Database.CommandTimeout = sqlCommandTimeout;
                results = tE3EDBEntities.RetrieveItemizedInvCollection(collectionItem);
            }
            else
            {
                TE3ERCGSYNCPRODEntities tE3EDBProdEntities = new TE3ERCGSYNCPRODEntities();
                tE3EDBProdEntities.Database.CommandTimeout = sqlCommandTimeout;
                results = tE3EDBProdEntities.RetrieveItemizedInvCollection(collectionItem);
            }

            return results.ToList();
        }

        public IEnumerable<RetrieveMatterByNum_Result> RetrieveMatterByNum(string matterNo, int sqlCommandTimeout, bool isDebug = false)
        {
            IEnumerable<RetrieveMatterByNum_Result> results;

            if (isDebug)
            {
                TE3ERCGSyncEntities tE3EDBEntities = new TE3ERCGSyncEntities();
                tE3EDBEntities.Database.CommandTimeout = sqlCommandTimeout;
                results = tE3EDBEntities.RetrieveMatterByNum(matterNo);
            }
            else
            {
                TE3ERCGSYNCPRODEntities tE3EDBProdEntities = new TE3ERCGSYNCPRODEntities();
                tE3EDBProdEntities.Database.CommandTimeout = sqlCommandTimeout;
                results = tE3EDBProdEntities.RetrieveMatterByNum(matterNo);
            }

            return results;
        }

        public IEnumerable<RetrieveMatteCPC_Result> RetrieveMatteCPC(string matterNo, int sqlCommandTimeout, bool isDebug = false)
        {
            IEnumerable<RetrieveMatteCPC_Result> results;

            if (isDebug)
            {
                TE3ERCGSyncEntities tE3EDBEntities = new TE3ERCGSyncEntities();
                tE3EDBEntities.Database.CommandTimeout = sqlCommandTimeout;
                results = tE3EDBEntities.RetrieveMatteCPC(matterNo);
            }
            else
            {
                TE3ERCGSYNCPRODEntities tE3EDBProdEntities = new TE3ERCGSYNCPRODEntities();
                tE3EDBProdEntities.Database.CommandTimeout = sqlCommandTimeout;
                results = tE3EDBProdEntities.RetrieveMatteCPC(matterNo);
            }

            return results;
        }

        public List<ClientMaster> RetrieveClientMaster(int sqlCommandTimeout, bool isDebug = false)
        {
            IEnumerable<ClientMaster> results;

            if (isDebug)
            {
                TE3ERCGSyncEntities tE3EDBEntities = new TE3ERCGSyncEntities();
                tE3EDBEntities.Database.CommandTimeout = sqlCommandTimeout;
                results = tE3EDBEntities.ClientMasters;
            }
            else
            {
                TE3ERCGSYNCPRODEntities tE3EDBProdEntities = new TE3ERCGSYNCPRODEntities();
                tE3EDBProdEntities.Database.CommandTimeout = sqlCommandTimeout;
                results = tE3EDBProdEntities.ClientMasters;
            }

            return results.ToList();
        }

        public IEnumerable<ClientMaster> AddNewClientKey(string appKey, string clientName, int sqlCommandTimeout, bool isDebug = false)
        {
            IEnumerable<ClientMaster> results;

            string appId = Guid.NewGuid().ToString().ToUpper();
            //var appKey = e3eExtension.GenerateAPPKey();

            if (isDebug)
            {
                TE3ERCGSyncEntities tE3EDBEntities = new TE3ERCGSyncEntities();
                tE3EDBEntities.Database.CommandTimeout = sqlCommandTimeout;
                tE3EDBEntities.Database.ExecuteSqlCommand($@"INSERT INTO [dbo].[ClientMaster]
                                                                               ([AppId]
                                                                               ,[AppKey]
                                                                               ,[ClientName]
                                                                               ,[CreatedOn])
                                                                         VALUES
                                                                               ('{appId}'
                                                                               ,'{appKey}'
                                                                               ,'{clientName}'
                                                                               ,'{DateTime.Now}')");
                results = tE3EDBEntities.ClientMasters;
            }
            else
            {
                TE3ERCGSYNCPRODEntities tE3EDBProdEntities = new TE3ERCGSYNCPRODEntities();
                tE3EDBProdEntities.Database.CommandTimeout = sqlCommandTimeout;
                tE3EDBProdEntities.Database.ExecuteSqlCommand($@"INSERT INTO [dbo].[ClientMaster]
                                                                               ([AppId]
                                                                               ,[AppKey]
                                                                               ,[ClientName]
                                                                               ,[CreatedOn])
                                                                         VALUES
                                                                               ('{appId}'
                                                                               ,'{appKey}'
                                                                               ,'{clientName}'
                                                                               ,'{DateTime.Now}')");

                results = tE3EDBProdEntities.ClientMasters;
            }


            return results;
        }

        #region TeamsDMS Te3e

        public TeamsDMSConfiguration GetTeamsDMSConfiguration(int sqlCommandTimeout, bool isDebug = false)
        {
            TeamsDMSConfiguration teamsDMSConfiguration = null;

            if (isDebug)
            {
                RCGAMZN_DEV01Entities rcgamznDevEntities = new RCGAMZN_DEV01Entities();
                rcgamznDevEntities.Database.CommandTimeout = sqlCommandTimeout;
                teamsDMSConfiguration = rcgamznDevEntities.TeamsDMSConfigurations.Select(x => x).FirstOrDefault();
            }
            else
            {
                RCGAMZN_PROD01Entities rcgamznProdEntities = new RCGAMZN_PROD01Entities();
                rcgamznProdEntities.Database.CommandTimeout = sqlCommandTimeout;
                teamsDMSConfiguration = rcgamznProdEntities.TeamsDMSConfigurations.Select(x => x).FirstOrDefault();
            }

            return teamsDMSConfiguration;
        }

        public void PullMatterChanges(int numOfDays, int sqlCommandTimeout, bool isDebug = false)
        {
            if (isDebug)
            {
                RCGAMZN_DEV01Entities rcgamznDevEntities = new RCGAMZN_DEV01Entities();
                rcgamznDevEntities.Database.CommandTimeout = sqlCommandTimeout;
                rcgamznDevEntities.DMS_RetrieveMattersForTeams(numOfDays);
            }
            else
            {
                RCGAMZN_PROD01Entities rcgamznProdEntities = new RCGAMZN_PROD01Entities();
                rcgamznProdEntities.Database.CommandTimeout = sqlCommandTimeout;
                rcgamznProdEntities.DMS_RetrieveMattersForTeams(numOfDays);
            }
        }

        public void PullSpecificMatterChanges(string matter, int sqlCommandTimeout, bool isDebug = false)
        {
            if (isDebug)
            {
                RCGAMZN_DEV01Entities rcgamznDevEntities = new RCGAMZN_DEV01Entities();
                rcgamznDevEntities.Database.CommandTimeout = sqlCommandTimeout;
                rcgamznDevEntities.DMS_RetrieveMatterForTeamsByNumber(matter);
            }
            else
            {
                RCGAMZN_PROD01Entities rcgamznProdEntities = new RCGAMZN_PROD01Entities();
                rcgamznProdEntities.Database.CommandTimeout = sqlCommandTimeout;
                rcgamznProdEntities.DMS_RetrieveMatterForTeamsByNumber(matter);
            }
        }

        public void AddTeamsDmsQueueLogs(
            TeamsDMSQueue teamsDMSQueue,
            string ownerUsers,
            string memberUsers,
            string errorMessage,
            string webResponse,
            int sqlCommandTimeout,
            bool isDebug = false)
        {
            if (isDebug)
            {
                using (RCGAMZN_DEV01Entities rcgamznDevEntities = new RCGAMZN_DEV01Entities())
                {
                    rcgamznDevEntities.Database.CommandTimeout = sqlCommandTimeout;

                    var sqlInsert = $@"INSERT INTO [dbo].[TeamsDMSQueueLogs]
                                   ([MatterNumber]
                                   ,[MatterName]
                                   ,[MatterStatus]
                                   ,[TeamsOwners]
                                   ,[TeamsMembers]
                                   ,[ExportedDate]
                                   ,[ErrorMessage]
                                   ,[WebResponse])
                             VALUES
                                   ('{teamsDMSQueue.MattNumber}'
                                   ,'{teamsDMSQueue.MattName}'
                                   ,'{teamsDMSQueue.MattStatusDescription}'
                                   ,'{ownerUsers}'
                                   ,'{memberUsers}'
                                   ,'{DateTime.Now}'
                                   ,'{errorMessage}'
                                   ,'{webResponse}')";

                    rcgamznDevEntities.Database.ExecuteSqlCommand(sqlInsert);
                }
            }
            else
            {
                using (RCGAMZN_PROD01Entities rcgamznProdEntities = new RCGAMZN_PROD01Entities())
                {
                    rcgamznProdEntities.Database.CommandTimeout = sqlCommandTimeout;

                    var sqlInsert = $@"INSERT INTO [dbo].[TeamsDMSQueueLogs]
                                   ([MatterNumber]
                                   ,[MatterName]
                                   ,[MatterStatus]
                                   ,[TeamsOwners]
                                   ,[TeamsMembers]
                                   ,[ExportedDate]
                                   ,[ErrorMessage]
                                   ,[WebResponse])
                             VALUES
                                   ('{teamsDMSQueue.MattNumber}'
                                   ,'{teamsDMSQueue.MattName}'
                                   ,'{teamsDMSQueue.MattStatusDescription}'
                                   ,'{ownerUsers}'
                                   ,'{memberUsers}'
                                   ,'{DateTime.Now}'
                                   ,'{errorMessage}'
                                   ,'{webResponse}')";

                    rcgamznProdEntities.Database.ExecuteSqlCommand(sqlInsert);
                }
            }

        }
        public void UpdateExportedDMSMatter(string mattNum, int status, int numOfAttempt, string error = "", bool isDebug = false)
        {
            if (isDebug)
            {
                using (RCGAMZN_DEV01Entities rcgamznDevEntities = new RCGAMZN_DEV01Entities())
                {
                    var sqlUpdt = string.Format(@"UPDATE [RCGAMZN_DEV01].[dbo].[TeamsDMSQueue]
                            SET [IsExported] = '{0}', 
                                [ErrorMsg] = '{1}', 
                                [ExportedDate] = '{2}',
                                [NumOfAttempt] = {4}
                            WHERE [MattNumber] = '{3}'; ", status, error, Convert.ToDateTime(DateTime.Now.ToString()), mattNum, numOfAttempt);

                    rcgamznDevEntities.Database.ExecuteSqlCommand(sqlUpdt);
                }
            }
            else
            {
                using (RCGAMZN_PROD01Entities rcgamznProdEntities = new RCGAMZN_PROD01Entities())
                {
                    var sqlUpdt = string.Format(@"UPDATE [RCGAMZN_PROD01].[dbo].[TeamsDMSQueue]
                            SET [IsExported] = '{0}', 
                                [ErrorMsg] = '{1}', 
                                [ExportedDate] = '{2}',
                                [NumOfAttempt] = {4}
                            WHERE [MattNumber] = '{3}'; ", status, error, Convert.ToDateTime(DateTime.Now.ToString()), mattNum, numOfAttempt);

                    rcgamznProdEntities.Database.ExecuteSqlCommand(sqlUpdt);
                }
            }
        }

        public void RemoveExportedDMSMatter(string mattNum, bool isDebug = false)
        {
            if (isDebug)
            {
                using (RCGAMZN_DEV01Entities rcgamznDevEntities = new RCGAMZN_DEV01Entities())
                {
                    var sqlUpdt = string.Format(@"DELETE FROM [RCGAMZN_DEV01].[dbo].[TeamsDMSQueue]
                            WHERE [MattNumber] = '{0}'; ", mattNum);

                    rcgamznDevEntities.Database.ExecuteSqlCommand(sqlUpdt);
                }
            }
            else
            {
                using (RCGAMZN_PROD01Entities rcgamznProdEntities = new RCGAMZN_PROD01Entities())
                {
                    var sqlUpdt = string.Format(@"DELETE FROM [RCGAMZN_PROD01].[dbo].[TeamsDMSQueue]
                            WHERE [MattNumber] = '{0}'; ", mattNum);

                    rcgamznProdEntities.Database.ExecuteSqlCommand(sqlUpdt);
                }
            }
        }

        public List<TeamsDMSQueue> GetMattersForTeamsDMS(int sqlCommandTimeout, bool isDebug = false)
        {
            IEnumerable<TeamsDMSQueue> results = null;

            if (isDebug)
            {
                RCGAMZN_DEV01Entities rcgamznDevEntities = new RCGAMZN_DEV01Entities();
                rcgamznDevEntities.Database.CommandTimeout = sqlCommandTimeout;
                results = from matter in rcgamznDevEntities.TeamsDMSQueues
                          where (matter.IsExported == 0 || matter.IsExported == -1) && (matter.NumOfAttempt ?? 0) <= 100
                          group matter by matter.MattNumber into g
                          select g.OrderByDescending(t => t.TimeStamp).FirstOrDefault();
            }
            else
            {
                RCGAMZN_PROD01Entities rcgamznProdEntities = new RCGAMZN_PROD01Entities();
                rcgamznProdEntities.Database.CommandTimeout = sqlCommandTimeout;
                results = from matter in rcgamznProdEntities.TeamsDMSQueues
                          where (matter.IsExported == 0 || matter.IsExported == -1) && (matter.NumOfAttempt ?? 0) <= 100
                          group matter by matter.MattNumber into g
                          select g.OrderByDescending(t => t.TimeStamp).FirstOrDefault();
            }

            return results.ToList();
        }

        #endregion TeamsDMS Te3e

        #region TrackerSafe Te3e
        public IEnumerable<TrackerSafeEMSImport> GetMattersToImport()
        {
            IEnumerable<TrackerSafeEMSImport> results = null;

            if (_appSettings.IsDebug)
            {
                TE3ERCGSyncEntities te3eRCGSyncEntities = new TE3ERCGSyncEntities();
                te3eRCGSyncEntities.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                results = from matter in te3eRCGSyncEntities.TrackerSafeEMSImports
                          where matter.Exported == 0 || matter.Exported == -1
                          select matter;
            }
            else
            {
                TE3ERCGSYNCPRODEntities te3eRCGSyncProdEntities = new TE3ERCGSYNCPRODEntities();
                te3eRCGSyncProdEntities.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                results = from matter in te3eRCGSyncProdEntities.TrackerSafeEMSImports
                          where matter.Exported == 0 || matter.Exported == -1
                          select matter;
            }

            return results;
        }

        public string GetBillingTkpr(string mattNo)
        {
            string name = "";

            if (_appSettings.IsDebug)
            {
                TE3ERCGSyncEntities te3eRCGSyncEntities = new TE3ERCGSyncEntities();
                te3eRCGSyncEntities.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                var results = te3eRCGSyncEntities.GetBillingTkpr(mattNo);

                if (results.Count() > 0)
                    name = results.First().BillingTkprName;
            }
            else
            {
                TE3ERCGSYNCPRODEntities te3eRCGSyncProdEntities = new TE3ERCGSYNCPRODEntities();
                te3eRCGSyncProdEntities.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                //var results = te3eRCGSyncProdEntities.GetBillingTkpr(mattNo);

                //if (results.Count() > 0)
                //    name = results.First().BillingTkprName;
            }

            return name;
        }

        public void PullTrackerSafeMatterChanges(int numOfDays)
        {
            string sqlStmt = $@"EXECUTE [dbo].[RetrieveMatters]  @numOfDays = {numOfDays}";
            if (_appSettings.IsDebug)
            {
                TE3ERCGSyncEntities te3eRCGSyncEntities = new TE3ERCGSyncEntities();
                te3eRCGSyncEntities.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                te3eRCGSyncEntities.Database.ExecuteSqlCommand(sqlStmt);
            }
            else
            {
                TE3ERCGSYNCPRODEntities te3eRCGSyncProdEntities = new TE3ERCGSYNCPRODEntities();
                te3eRCGSyncProdEntities.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                te3eRCGSyncProdEntities.Database.ExecuteSqlCommand(sqlStmt);
            }
        }
        public void AddCasesToTrackerSafeEMSImports(List<string> mattNumbers)
        {
            string scriptFileUAT = "InsertMissingCases.uat.sql";
            string scriptFileProd = "InsertMissingCases.prod.sql";

            if (_appSettings.IsDebug)
            {
                using (var objStreamReader = File.OpenText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $"scripts/{scriptFileUAT}")))
                {
                    string sqlStmt = objStreamReader.ReadToEnd();
                    StringBuilder sb = new StringBuilder();

                    for (int i = 0; i < mattNumbers.Count(); i++)
                    {
                        sb.Append($"'{mattNumbers[i].Trim()}'");

                        if ((i + 1) < mattNumbers.Count())
                            sb.Append(",");
                    };

                    sqlStmt = sqlStmt.Replace("@mattNumbers", sb.ToString());
                    TE3ERCGSyncEntities te3eRCGSyncEntities = new TE3ERCGSyncEntities();
                    te3eRCGSyncEntities.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    te3eRCGSyncEntities.Database.ExecuteSqlCommand(sqlStmt);
                }
            }
            else
            {
                using (var objStreamReader = File.OpenText(Path.Combine(Path.GetDirectoryName(Assembly.GetCallingAssembly().Location), $"scripts/{scriptFileProd}")))
                {
                    string sqlStmt = objStreamReader.ReadToEnd();
                    StringBuilder sb = new StringBuilder();

                    for (int i = 0; i < mattNumbers.Count(); i++)
                    {
                        sb.Append($"'{mattNumbers[i].Trim()}'");

                        if ((i + 1) < mattNumbers.Count())
                            sb.Append(",");
                    };

                    sqlStmt = sqlStmt.Replace("@mattNumbers", sb.ToString());
                    TE3ERCGSYNCPRODEntities te3eRCGSyncProdEntities = new TE3ERCGSYNCPRODEntities();
                    te3eRCGSyncProdEntities.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    te3eRCGSyncProdEntities.Database.ExecuteSqlCommand(sqlStmt);
                }
            }
        }

        public IEnumerable<TrackerSafeEMSImport> GetMattersToUpdate(DateTime startDate, DateTime endDate)
        {
            IEnumerable<TrackerSafeEMSImport> results = null;

            if (_appSettings.IsDebug)
            {
                TE3ERCGSyncEntities te3eRCGSyncEntities = new TE3ERCGSyncEntities();
                te3eRCGSyncEntities.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                results = from matter in te3eRCGSyncEntities.TrackerSafeEMSImports
                          where matter.Exported == 1 && (matter.TransDate >= startDate.Date && matter.TransDate <= endDate.Date)
                          select matter;
            }
            else
            {
                TE3ERCGSYNCPRODEntities te3eRCGSyncProdEntities = new TE3ERCGSYNCPRODEntities();
                te3eRCGSyncProdEntities.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                results = from matter in te3eRCGSyncProdEntities.TrackerSafeEMSImports
                          where matter.Exported == 1 && (matter.TransDate >= startDate.Date && matter.TransDate <= endDate.Date)
                          select matter;
            }

            return results;
        }

        public ClientTS3EInfo GetClientTS3EInfo(string matterNo)
        {
            ClientTS3EInfo clientTS3EInfo = new ClientTS3EInfo();
            IEnumerable<TrackerSafeEMSImport> results = null;


            if (_appSettings.IsDebug)
            {
                TE3ERCGSyncEntities te3eRCGSyncEntities = new TE3ERCGSyncEntities();
                te3eRCGSyncEntities.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                results = (from matter in te3eRCGSyncEntities.TrackerSafeEMSImports
                           where matter.MattNumber == matterNo
                           select matter).ToList();

                if (results.Count() == 0)
                {
                    results = (from matter in te3eRCGSyncEntities.RetrieveMatterByNum(matterNo)
                               select new TrackerSafeEMSImport
                               {
                                   MattNumber = matter.MattNumber,
                                   MattName = matter.MattName,
                                   ClientName = matter.ClientName,
                                   ClientFormattedString = matter.ClientFormattedString,
                                   ClientStreet = matter.ClientStreet,
                                   ClientCity = matter.ClientCity,
                                   ClientState = matter.ClientState,
                                   ClientZipCode = matter.ClientZipCode,
                                   Contact_Email = matter.Contact_Email,
                                   ClaimNo = matter.ClaimNo,
                                   ReferenceNumber = matter.ReferenceNumber,
                                   Contact_Name = matter.Contact_Name,
                                   Contact_Phone = matter.Contact_Phone,
                                   Insured_Name = matter.Insured_Name,
                                   Claimant = matter.Claimant,
                                   Style = matter.Style,
                                   Cause_Number = matter.Cause_Number,
                                   Date_of_Loss = matter.Date_of_Loss,
                                   OfficeFormattedString = matter.OfficeFormattedString,
                                   OfficeName = matter.OfficeName,
                                   OfficeStreet = matter.OfficeStreet,
                                   OfficeCity = matter.OfficeCity,
                                   OfficeState = matter.OfficeState,
                                   OfficeZipCode = matter.OfficeZipCode,
                                   OfficePhone = matter.OfficePhone,
                                   OfficeFax = matter.OfficeFax,
                                   CertAuthNo = matter.CertAuthNo
                               }).ToList();
                }
            }
            else
            {
                TE3ERCGSYNCPRODEntities te3eRCGSyncProdEntities = new TE3ERCGSYNCPRODEntities();
                te3eRCGSyncProdEntities.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                results = (from matter in te3eRCGSyncProdEntities.TrackerSafeEMSImports
                           where matter.MattNumber == matterNo
                           select matter).ToList();

                if (results.Count() == 0)
                {
                    results = (from matter in te3eRCGSyncProdEntities.RetrieveMatterByNum(matterNo)
                               select new TrackerSafeEMSImport
                               {
                                   MattNumber = matter.MattNumber,
                                   MattName = matter.MattName,
                                   ClientName = matter.ClientName,
                                   ClientFormattedString = matter.ClientFormattedString,
                                   ClientStreet = matter.ClientStreet,
                                   ClientCity = matter.ClientCity,
                                   ClientState = matter.ClientState,
                                   ClientZipCode = matter.ClientZipCode,
                                   Contact_Email = matter.Contact_Email,
                                   ClaimNo = matter.ClaimNo,
                                   ReferenceNumber = matter.ReferenceNumber,
                                   Contact_Name = matter.Contact_Name,
                                   Contact_Phone = matter.Contact_Phone,
                                   Insured_Name = matter.Insured_Name,
                                   Claimant = matter.Claimant,
                                   Style = matter.Style,
                                   Cause_Number = matter.Cause_Number,
                                   Date_of_Loss = matter.Date_of_Loss,
                                   OfficeFormattedString = matter.OfficeFormattedString,
                                   OfficeName = matter.OfficeName,
                                   OfficeStreet = matter.OfficeStreet,
                                   OfficeCity = matter.OfficeCity,
                                   OfficeState = matter.OfficeState,
                                   OfficeZipCode = matter.OfficeZipCode,
                                   OfficePhone = matter.OfficePhone,
                                   OfficeFax = matter.OfficeFax,
                                   CertAuthNo = matter.CertAuthNo
                               }).ToList();
                }
            }


            if (results.Count() > 0)
            {
                var matter = results.First();
                clientTS3EInfo.MatterNo = matter.MattNumber;
                clientTS3EInfo.MatterName = matter.MattName;
                clientTS3EInfo.ClientName = matter.ClientName;
                clientTS3EInfo.ClientFormattedString = matter.ClientFormattedString;
                clientTS3EInfo.ClientStreet = matter.ClientStreet;
                clientTS3EInfo.ClientCity = matter.ClientCity;
                clientTS3EInfo.ClientState = matter.ClientState;
                clientTS3EInfo.ClientZipCode = matter.ClientZipCode;
                clientTS3EInfo.ContactEmail = matter.Contact_Email;
                clientTS3EInfo.ClaimNo = !string.IsNullOrEmpty(matter.ClaimNo) ? matter.ClaimNo : "";
                clientTS3EInfo.ReferenceNo = !string.IsNullOrEmpty(matter.ReferenceNumber) ? matter.ReferenceNumber : "";
                clientTS3EInfo.ContactName = !string.IsNullOrEmpty(matter.Contact_Name) ? matter.Contact_Name : "";
                clientTS3EInfo.ContactPhone = !string.IsNullOrEmpty(matter.Contact_Phone) ? matter.Contact_Phone : "";
                clientTS3EInfo.InsuredName = !string.IsNullOrEmpty(matter.Insured_Name) ? matter.Insured_Name : "";
                clientTS3EInfo.Claimant = !string.IsNullOrEmpty(matter.Claimant) ? matter.Claimant : "";
                clientTS3EInfo.Style = !string.IsNullOrEmpty(matter.Style) ? matter.Style : "";
                clientTS3EInfo.CauseNo = !string.IsNullOrEmpty(matter.Cause_Number) ? matter.Cause_Number : "";
                clientTS3EInfo.DateOfLoss = !string.IsNullOrEmpty(matter.Date_of_Loss) ? Convert.ToDateTime(matter.Date_of_Loss).ToString("MM/dd/yyyy") : "";
                clientTS3EInfo.OfficeFormattedString = !string.IsNullOrEmpty(matter.OfficeFormattedString) ? matter.OfficeFormattedString : "";
                clientTS3EInfo.OfficeName = !string.IsNullOrEmpty(matter.OfficeName) ? matter.OfficeName : "";
                clientTS3EInfo.OfficeStreet = !string.IsNullOrEmpty(matter.OfficeStreet) ? matter.OfficeStreet : "";
                clientTS3EInfo.OfficeCity = !string.IsNullOrEmpty(matter.OfficeCity) ? matter.OfficeCity : "";
                clientTS3EInfo.OfficeState = !string.IsNullOrEmpty(matter.OfficeState) ? matter.OfficeState : "";
                clientTS3EInfo.OfficeZipCode = !string.IsNullOrEmpty(matter.OfficeZipCode) ? matter.OfficeZipCode : "";
                clientTS3EInfo.OfficePhone = !string.IsNullOrEmpty(matter.OfficePhone) ? matter.OfficePhone : "";
                clientTS3EInfo.OfficeFax = !string.IsNullOrEmpty(matter.OfficeFax) ? matter.OfficeFax : "";
                clientTS3EInfo.CertAuthNo = !string.IsNullOrEmpty(matter.CertAuthNo) ? matter.CertAuthNo : "";
                clientTS3EInfo.ExpirationDate = DateTime.Now.AddDays(30).ToString("MMMM dd, yyyy");

                //default values
                clientTS3EInfo.BillTerm = "quarterly";
                clientTS3EInfo.BillRateDisplayName = "Small";

                //lookup trackersafe api for specific case
                TSCase tSCase = tSClient.GetSpecificCase(clientTS3EInfo.MatterNo);
                clientTS3EInfo.EvidenceDescription = tSCase.offenseDescription;
                clientTS3EInfo.EvidenceID = tSCase.id;

                if (clientTS3EInfo.DateOfLoss != tSCase.offenseDate && Convert.ToDateTime(tSCase.offenseDate) != DateTime.MinValue)
                    clientTS3EInfo.DateOfLoss = Convert.ToDateTime(tSCase.offenseDate).ToString("MM/dd/yyyy");

                var technician = tSClient.GetUserById(tSCase.caseOfficerIds.First());

                if (technician != null)
                {
                    clientTS3EInfo.Technician = $"{technician.FirstName} {technician.LastName}";
                    clientTS3EInfo.TechnicianEmail = technician.Email;
                }

                if (tSCase.formData != null)
                {
                    var billingForm = tSCase.formData.Where(x => x.formId == 10).Select(x => x);

                    if (billingForm.Count() > 0)
                    {
                        var bform = billingForm.First();
                        BFormDataOutput bFormData = JsonConvert.DeserializeObject<BFormDataOutput>(bform.data);
                        clientTS3EInfo.IsBilled = bFormData.field9459 == "2";

                        if (bFormData.field7142 == "2")
                            clientTS3EInfo.BillTerm = "yearly";
                        else if (bFormData.field7142 == "1")
                            clientTS3EInfo.BillTerm = "quarterly";

                        if (bFormData.field7169 == "2")
                            clientTS3EInfo.BillRateDisplayName = "Large";
                        else if (bFormData.field7169 == "1")
                            clientTS3EInfo.BillRateDisplayName = "Small";
                        else if (bFormData.field7169 == "4")
                            clientTS3EInfo.BillRateDisplayName = "Vehicle";
                        else if (bFormData.field7169 == "3")
                        {
                            clientTS3EInfo.BillRateDisplayName = "Special";
                            clientTS3EInfo.SpecialChargedAmount = bFormData.field7227;
                        }
                    }
                }
            }

            return clientTS3EInfo;
        }

        public void UpdateExportedMatter(string mattNum, int status, string error = "")
        {
            if (_appSettings.IsDebug)
            {
                using (TE3ERCGSyncEntities te3eRCGSyncEntities = new TE3ERCGSyncEntities())
                {
                    var sqlUpdt = string.Format(@"UPDATE [TE_3E_RCG_SYNC].[dbo].[TrackerSafeEMSImport]
                            SET [Exported] = '{0}', [ErrorMsg] = '{1}', [TransDate] = '{2}'
                            WHERE [MattNumber] = '{3}'; ", status, error, Convert.ToDateTime(DateTime.Now.ToString()), mattNum);

                    te3eRCGSyncEntities.Database.ExecuteSqlCommand(sqlUpdt);
                }
            }
            else
            {
                using (TE3ERCGSYNCPRODEntities te3eRCGSyncEntities = new TE3ERCGSYNCPRODEntities())
                {
                    var sqlUpdt = string.Format(@"UPDATE [TE_3E_RCG_SYNC].[dbo].[TrackerSafeEMSImport]
                            SET [Exported] = '{0}', [ErrorMsg] = '{1}', [TransDate] = '{2}'
                            WHERE [MattNumber] = '{3}'; ", status, error, Convert.ToDateTime(DateTime.Now.ToString()), mattNum);

                    te3eRCGSyncEntities.Database.ExecuteSqlCommand(sqlUpdt);
                }
            }

        }

        public string getSpecialBillRate(string mattNo)
        {
            string results = null;

            if (_appSettings.IsDebug)
            {
                TE3ERCGSyncEntities te3eRCGSyncEntities = new TE3ERCGSyncEntities();
                te3eRCGSyncEntities.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                var result = te3eRCGSyncEntities.GetBillingRate(mattNo);
                string rate = result.First().ToString();
                results = rate == "" ? null : rate;
            }
            else
            {
                TE3ERCGSYNCPRODEntities te3eRCGSyncProdEntities = new TE3ERCGSYNCPRODEntities();
                te3eRCGSyncProdEntities.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                var result = te3eRCGSyncProdEntities.GetBillingRate(mattNo);
                string rate = result.First().ToString();
                results = rate == "" ? null : rate;
            }

            return results;
        }
        #endregion TrackerSafe Te3e

        #region TrackerSafe DecisionLetter
        //TrackerSafe Phase 3 - DecisionLetter entity framework functions

        private string baseUrl
        {
            get
            {
                var request = HttpContext.Current.Request;
                var appUrl = HttpRuntime.AppDomainAppVirtualPath;

                if (appUrl != "/")
                    appUrl = "/" + appUrl;
                return string.Format("{0}://{1}{2}", request.Url.Scheme, request.Url.Authority, appUrl);
            }
        }
        public string GenerateDecisionLetterLink(string matterNo)
        {
            var expirationDate = DateTime.UtcNow.AddBusinessDays(10);
            try
            {
                if (_appSettings.IsDebug)
                {
                    using (TE3ERCGSyncEntities db = new TE3ERCGSyncEntities())
                    {
                        var decisionLetter = db.TrackerSafeDecisionLetters
                            .Where(x => x.MattNum.Equals(matterNo) && !x.ReceivedAt.HasValue && x.NumOfTries < _appSettings.NumOfRetriesForEmail)
                            .OrderByDescending(x => x.TimeStamp)
                            .FirstOrDefault();
                        if (decisionLetter == null)
                        {
                            var clientTS3EInfo = GetClientTS3EInfo(matterNo);
                            if (string.IsNullOrEmpty(clientTS3EInfo.MatterNo))
                            {
                                return null;
                            }
                            decisionLetter = new TrackerSafeDecisionLetter()
                            {
                                Id = Guid.NewGuid(),
                                ClaimNo = clientTS3EInfo.ClaimNo,
                                ClientAddress = clientTS3EInfo.ClientFormattedString,
                                ClientCity = clientTS3EInfo.ClientCity,
                                ClientName = clientTS3EInfo.ClientName,
                                ClientEmail = clientTS3EInfo.ContactEmail,
                                ClientState = clientTS3EInfo.ClientState,
                                ClientZipCode = clientTS3EInfo.ClientZipCode,
                                EvidenceId = clientTS3EInfo.EvidenceID,
                                Expiration = expirationDate,
                                InsuredName = clientTS3EInfo.InsuredName,
                                MattNum = clientTS3EInfo.MatterNo,
                                SentAt = DateTime.UtcNow,
                                TimeStamp = DateTime.UtcNow,
                                NumOfTries = 1
                            };
                            if (DateTime.TryParse(clientTS3EInfo.DateOfLoss, out DateTime dateOfLoss))
                                decisionLetter.DateOfLoss = dateOfLoss;
                            db.TrackerSafeDecisionLetters.Add(decisionLetter);
                        }
                        else
                        {
                            var clientTS3EInfo = GetClientTS3EInfo(matterNo);

                            decisionLetter.ClaimNo = clientTS3EInfo.ClaimNo;
                            decisionLetter.ClientAddress = clientTS3EInfo.ClientFormattedString;
                            decisionLetter.ClientCity = clientTS3EInfo.ClientCity;
                            decisionLetter.ClientName = clientTS3EInfo.ClientName;
                            decisionLetter.ClientEmail = clientTS3EInfo.ContactEmail;
                            decisionLetter.ClientState = clientTS3EInfo.ClientState;
                            decisionLetter.ClientZipCode = clientTS3EInfo.ClientZipCode;
                            decisionLetter.EvidenceId = clientTS3EInfo.EvidenceID;
                            decisionLetter.InsuredName = clientTS3EInfo.InsuredName;
                            decisionLetter.MattNum = clientTS3EInfo.MatterNo;
                            if (decisionLetter.Expiration.Value.Date < DateTime.UtcNow.Date)
                            {
                                decisionLetter.NumOfTries++;
                            }
                            decisionLetter.Expiration = expirationDate;
                            decisionLetter.SentAt = DateTime.UtcNow;
                        }

                        tSClient.UpdateDecisionLetterResponse(decisionLetter, matterNo);
                        db.SaveChanges();
                        return $"{baseUrl.Replace("//TSDL", "/TSDL")}/DecisionLetter?token={$"{expirationDate:yyyy-MM-dd},{matterNo}".Base64Encode()}";
                    }
                }
                else
                {
                    using (TE3ERCGSYNCPRODEntities db = new TE3ERCGSYNCPRODEntities())
                    {
                        var decisionLetter = db.TrackerSafeDecisionLetters
                            .Where(x => x.MattNum.Equals(matterNo) && !x.ReceivedAt.HasValue && x.NumOfTries < _appSettings.NumOfRetriesForEmail)
                            .OrderByDescending(x => x.TimeStamp)
                            .FirstOrDefault();
                        if (decisionLetter == null)
                        {
                            var clientTS3EInfo = GetClientTS3EInfo(matterNo);
                            if (string.IsNullOrEmpty(clientTS3EInfo.MatterNo))
                            {
                                return null;
                            }
                            decisionLetter = new TrackerSafeDecisionLetter()
                            {
                                Id = Guid.NewGuid(),
                                ClaimNo = clientTS3EInfo.ClaimNo,
                                ClientAddress = clientTS3EInfo.ClientFormattedString,
                                ClientCity = clientTS3EInfo.ClientCity,
                                ClientName = clientTS3EInfo.ClientName,
                                ClientEmail = clientTS3EInfo.ContactEmail,
                                ClientState = clientTS3EInfo.ClientState,
                                ClientZipCode = clientTS3EInfo.ClientZipCode,
                                EvidenceId = clientTS3EInfo.EvidenceID,
                                Expiration = expirationDate,
                                InsuredName = clientTS3EInfo.InsuredName,
                                MattNum = clientTS3EInfo.MatterNo,
                                SentAt = DateTime.UtcNow,
                                TimeStamp = DateTime.UtcNow,
                                NumOfTries = 1
                            };
                            if (DateTime.TryParse(clientTS3EInfo.DateOfLoss, out DateTime dateOfLoss))
                                decisionLetter.DateOfLoss = dateOfLoss;
                            db.TrackerSafeDecisionLetters.Add(decisionLetter);
                        }
                        else
                        {
                            var clientTS3EInfo = GetClientTS3EInfo(matterNo);

                            decisionLetter.ClaimNo = clientTS3EInfo.ClaimNo;
                            decisionLetter.ClientAddress = clientTS3EInfo.ClientFormattedString;
                            decisionLetter.ClientCity = clientTS3EInfo.ClientCity;
                            decisionLetter.ClientName = clientTS3EInfo.ClientName;
                            decisionLetter.ClientEmail = clientTS3EInfo.ContactEmail;
                            decisionLetter.ClientState = clientTS3EInfo.ClientState;
                            decisionLetter.ClientZipCode = clientTS3EInfo.ClientZipCode;
                            decisionLetter.EvidenceId = clientTS3EInfo.EvidenceID;
                            decisionLetter.InsuredName = clientTS3EInfo.InsuredName;
                            decisionLetter.MattNum = clientTS3EInfo.MatterNo;
                            if (decisionLetter.Expiration.Value.Date < DateTime.UtcNow.Date)
                            {
                                decisionLetter.NumOfTries++;
                                if (decisionLetter.NumOfTries > 3)
                                    return null;
                            }
                            decisionLetter.Expiration = expirationDate;
                            decisionLetter.SentAt = DateTime.UtcNow;
                        }

                        tSClient.UpdateDecisionLetterResponse(decisionLetter, matterNo);

                        db.SaveChanges();


                        return $"{baseUrl.Replace("https:/", "https://")}/DecisionLetter?token={$"{expirationDate:yyyy-MM-dd},{matterNo}".Base64Encode()}".Replace("//", "/");
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TrackerSafeDecisionLetter> GetExpiredDecisionLetters()
        {
            var currentDate = DateTime.UtcNow.Date;
            if (_appSettings.IsDebug)
            {
                using (TE3ERCGSyncEntities db = new TE3ERCGSyncEntities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    var decisionLetter = db.TrackerSafeDecisionLetters
                        .Where(x => DbFunctions.TruncateTime(x.Expiration) < currentDate && !x.ReceivedAt.HasValue && x.NumOfTries < _appSettings.NumOfRetriesForEmail).ToList();
                    return decisionLetter;
                }
            }
            else
            {
                using (TE3ERCGSYNCPRODEntities db = new TE3ERCGSYNCPRODEntities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    var decisionLetter = db.TrackerSafeDecisionLetters
                        .Where(x => DbFunctions.TruncateTime(x.Expiration) < currentDate && !x.ReceivedAt.HasValue && x.NumOfTries < _appSettings.NumOfRetriesForEmail).ToList();
                    return decisionLetter;
                }
            }
        }
        public List<TrackerSafeDecisionLetter> GetDecisionLetters(DateTime from, DateTime to)
        {
            if (_appSettings.IsDebug)
            {
                using (TE3ERCGSyncEntities db = new TE3ERCGSyncEntities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    var decisionLetters = db.TrackerSafeDecisionLetters
                        .Where(x => DbFunctions.TruncateTime(x.TimeStamp) >= from && DbFunctions.TruncateTime(x.TimeStamp) < to)
                        .OrderByDescending(x => x.TimeStamp)
                        //.GroupBy(x=>x.MattNum)
                        //.Select(x=>x.FirstOrDefault())
                        .ToList();
                    return decisionLetters;
                }
            }
            else
            {
                using (TE3ERCGSYNCPRODEntities db = new TE3ERCGSYNCPRODEntities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    var decisionLetters = db.TrackerSafeDecisionLetters
                        .Where(x => DbFunctions.TruncateTime(x.TimeStamp) >= from && DbFunctions.TruncateTime(x.TimeStamp) < to)
                        .OrderByDescending(x => x.TimeStamp)
                        //.GroupBy(x=>x.MattNum)
                        //.Select(x=>x.FirstOrDefault())
                        .ToList();
                    return decisionLetters;
                }
            }
        }

        public TrackerSafeDecisionLetter GetDecisionLetterFromMatterNo(string matterNo)
        {
            if (_appSettings.IsDebug)
            {
                using (TE3ERCGSyncEntities db = new TE3ERCGSyncEntities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    var decisionLetter = db.TrackerSafeDecisionLetters.Where(x => x.MattNum.Equals(matterNo)).OrderByDescending(x => x.TimeStamp).FirstOrDefault();
                    return decisionLetter;
                }
            }
            else
            {
                using (TE3ERCGSYNCPRODEntities db = new TE3ERCGSYNCPRODEntities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    var decisionLetter = db.TrackerSafeDecisionLetters.Where(x => x.MattNum.Equals(matterNo)).OrderByDescending(x => x.TimeStamp).FirstOrDefault();
                    return decisionLetter;
                }
            }
        }

        public TrackerSafeDecisionLetter UpdateDecisionLetterFromForm(TrackerSafeDecisionLetter trackerSafeDecisionLetter)
        {
            if (_appSettings.IsDebug)
            {
                using (TE3ERCGSyncEntities db = new TE3ERCGSyncEntities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    var decisionLetter = db.TrackerSafeDecisionLetters.FirstOrDefault(x => x.Id == trackerSafeDecisionLetter.Id);
                    decisionLetter.ReceivedAt = trackerSafeDecisionLetter.ReceivedAt;
                    decisionLetter.IsInsured = trackerSafeDecisionLetter.IsInsured;
                    decisionLetter.InsuranceAmount = trackerSafeDecisionLetter.InsuranceAmount;
                    decisionLetter.RecipientCarrierName = trackerSafeDecisionLetter.RecipientCarrierName;
                    decisionLetter.RecipientAddress = trackerSafeDecisionLetter.RecipientAddress;
                    decisionLetter.RecipientCity = trackerSafeDecisionLetter.RecipientCity;
                    decisionLetter.RecipientCompany = trackerSafeDecisionLetter.RecipientCompany;
                    decisionLetter.RecipientName = trackerSafeDecisionLetter.RecipientName;
                    decisionLetter.RecipientPhone = trackerSafeDecisionLetter.RecipientPhone;
                    decisionLetter.RecipientState = trackerSafeDecisionLetter.RecipientState;
                    decisionLetter.RecipientZipCode = trackerSafeDecisionLetter.RecipientZipCode;
                    decisionLetter.AuthorizedRepresentative = trackerSafeDecisionLetter.AuthorizedRepresentative;
                    decisionLetter.DecisionOption = trackerSafeDecisionLetter.DecisionOption;
                    decisionLetter.PDFFilePath = trackerSafeDecisionLetter.PDFFilePath;
                    db.SaveChanges();
                    return decisionLetter;
                }
            }
            else
            {
                using (TE3ERCGSYNCPRODEntities db = new TE3ERCGSYNCPRODEntities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    var decisionLetter = db.TrackerSafeDecisionLetters.FirstOrDefault(x => x.Id == trackerSafeDecisionLetter.Id);
                    decisionLetter.ReceivedAt = trackerSafeDecisionLetter.ReceivedAt;
                    decisionLetter.IsInsured = trackerSafeDecisionLetter.IsInsured;
                    decisionLetter.InsuranceAmount = trackerSafeDecisionLetter.InsuranceAmount;
                    decisionLetter.RecipientCarrierName = trackerSafeDecisionLetter.RecipientCarrierName;
                    decisionLetter.RecipientAddress = trackerSafeDecisionLetter.RecipientAddress;
                    decisionLetter.RecipientCity = trackerSafeDecisionLetter.RecipientCity;
                    decisionLetter.RecipientCompany = trackerSafeDecisionLetter.RecipientCompany;
                    decisionLetter.RecipientName = trackerSafeDecisionLetter.RecipientName;
                    decisionLetter.RecipientPhone = trackerSafeDecisionLetter.RecipientPhone;
                    decisionLetter.RecipientState = trackerSafeDecisionLetter.RecipientState;
                    decisionLetter.RecipientZipCode = trackerSafeDecisionLetter.RecipientZipCode;
                    decisionLetter.AuthorizedRepresentative = trackerSafeDecisionLetter.AuthorizedRepresentative;
                    decisionLetter.DecisionOption = trackerSafeDecisionLetter.DecisionOption;
                    decisionLetter.PDFFilePath = trackerSafeDecisionLetter.PDFFilePath;
                    db.SaveChanges();
                    return decisionLetter;
                }
            }
        }
        //public string GenerateDecisionLetterPdf(ClientTS3EInfo te3eCase, bool isDebug)
        //{
        //    string strexportfile = $"Evidence_{te3eCase.MatterNo}_Decision.doc";
        //    string contents = "";

        //    string strTemplate = "EvidenceDecisionLetter.xml";
        //    var path = HttpContext.Current.Server.MapPath($"~{(isDebug ? "/bin" : string.Empty)}/data/trackersafe/templates/{strTemplate}");
        //    //var path = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), $"data/trackersafe/templates/{strTemplate}");
        //    //var path = $"../data/trackersafe/templates/{strTemplate}";
        //    using (var objStreamReader = File.OpenText(path))
        //    {
        //        StringBuilder sb = new StringBuilder();
        //        sb.AppendLine(te3eCase.ClientStreet);
        //        sb.Append("<w:br/>");
        //        sb.AppendLine($"{te3eCase.ClientCity}, {te3eCase.ClientState} {te3eCase.ClientZipCode}");
        //        string clientaddress = sb.ToString();

        //        sb = new StringBuilder();
        //        sb.AppendLine($"{te3eCase.OfficeStreet}");
        //        sb.Append("<w:br/>");
        //        sb.AppendLine($"{te3eCase.OfficeCity}, {te3eCase.OfficeState} {te3eCase.OfficeZipCode}");
        //        sb.Append("<w:br/>");
        //        sb.AppendLine($"{te3eCase.OfficePhone} Telephone");
        //        sb.Append("<w:br/>");

        //        if (!string.IsNullOrEmpty(te3eCase.OfficeFax))
        //        {
        //            sb.AppendLine($"{te3eCase.OfficeFax} Facsimile");
        //            sb.Append("<w:br/>");
        //        }

        //        if (!string.IsNullOrEmpty(te3eCase.CertAuthNo))
        //            sb.AppendLine($"Certificate of Authorization No. {te3eCase.CertAuthNo}");

        //        string officeaddress = sb.ToString();

        //        sb = new StringBuilder();

        //        if (!string.IsNullOrEmpty(te3eCase.InsuredName))
        //        {
        //            sb.AppendLine($"Insured: {FixXMLString(te3eCase.InsuredName)}");
        //            sb.Append("<w:br/>");
        //        }

        //        //sb.AppendLine($"Adjustment Firm No: {te3eCase.InsuredName}");
        //        //sb.Append("<w:br/>");

        //        if (!string.IsNullOrEmpty(te3eCase.CauseNo))
        //        {
        //            sb.AppendLine($"Cause No: {te3eCase.CauseNo}");
        //            sb.Append("<w:br/>");
        //        }

        //        if (!string.IsNullOrEmpty(te3eCase.Style))
        //        {
        //            sb.AppendLine($"Style: {FixXMLString(te3eCase.Style)}");
        //            sb.Append("<w:br/>");
        //        }

        //        if (!string.IsNullOrEmpty(te3eCase.ClientName))
        //        {
        //            sb.AppendLine($"Client: {FixXMLString(te3eCase.ClientName)}");
        //            sb.Append("<w:br/>");
        //        }

        //        if (!string.IsNullOrEmpty(te3eCase.ClaimNo))
        //        {
        //            sb.AppendLine($"Claim No: {te3eCase.ClaimNo}");
        //            sb.Append("<w:br/>");
        //        }

        //        if (!string.IsNullOrEmpty(te3eCase.Claimant))
        //        {
        //            sb.AppendLine($"Claimant: {FixXMLString(te3eCase.Claimant)}");
        //            sb.Append("<w:br/>");
        //        }

        //        if (!string.IsNullOrEmpty(te3eCase.DateOfLoss))
        //        {
        //            sb.AppendLine($"Date of Loss: {te3eCase.DateOfLoss}");
        //            sb.Append("<w:br/>");
        //        }

        //        sb.AppendLine("Subject: Evidence Storage");
        //        sb.Append("<w:br/>");
        //        sb.AppendLine($"File No.: {te3eCase.MatterNo}");
        //        string referencenumberlabel = sb.ToString();

        //        contents = objStreamReader.ReadToEnd();
        //        contents = contents.Replace("thedate", DateTime.Now.ToString("MMMM d, yyyy"));

        //        contents = contents.Replace("clientcontact", FixXMLString(te3eCase.ContactName));
        //        contents = contents.Replace("clientname", FixXMLString(te3eCase.ClientName));
        //        contents = contents.Replace("clientaddress", clientaddress);
        //        contents = contents.Replace("clientemail", te3eCase.ContactEmail);

        //        contents = contents.Replace("referencenumberlabel", referencenumberlabel);
        //        contents = contents.Replace("officeaddress", officeaddress);
        //        contents = contents.Replace("evidencedescription", string.IsNullOrEmpty(te3eCase.EvidenceDescription) ? "" : FixXMLString(te3eCase.EvidenceDescription));
        //        contents = contents.Replace("evidencerate", te3eCase.ChargedAmount);
        //        contents = contents.Replace("techname", te3eCase.Technician);
        //        contents = contents.Replace("techemail", te3eCase.TechnicianEmail);
        //        contents = contents.Replace("30days", te3eCase.ExpirationDate);
        //        contents = contents.Replace("quarterly", te3eCase.BillTerm);
        //    }

        //    //var decisionLetterResp = GetDecisionLetterFromMatterNo(te3eCase.MatterNo);
        //    //todo: update content for decision letter response

        //    string decisionLetterDoc = $@"{Path.GetTempPath()}{strexportfile}";

        //    File.WriteAllText(decisionLetterDoc, contents);

        //    //convert to pdf
        //    AsposeUtil asposeUtil = new AsposeUtil();
        //    string decisionLetterPdf = asposeUtil.ConvertWordToPdf(decisionLetterDoc);

        //    return decisionLetterPdf;
        //}

        string EncodeXml(string value)
        {
            return HttpUtility.HtmlDecode(value);
        }

        public string GenerateDecisionLetterPdf(TrackerSafeDecisionLetter model, bool isDebug)
        {
            var te3eCase = GetClientTS3EInfo(model.MattNum);

            string strexportfile = $"Evidence_{model.MattNum}_Decision_{model.ReceivedAt?.ToString("ddMMyyyyHHmmss")}.doc";
            string contents = "";

            string strTemplate = "EvidenceDecisionLetter.xml";
            var path = HttpContext.Current.Server.MapPath($"~{(isDebug ? "/bin" : string.Empty)}/data/trackersafe/templates/{strTemplate}");
            using (var objStreamReader = File.OpenText(path))
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(te3eCase.ClientStreet.XMLEncode());
                sb.AppendLine("<w:br/>");
                //sb.AppendLine($"{te3eCase.ClientCity.XMLEncode()}, {te3eCase.ClientState.XMLEncode()} {te3eCase.ClientZipCode.XMLEncode()}");
                sb.AppendLine(te3eCase.ClientCity.XMLEncode());
                sb.AppendLine(",");
                sb.AppendLine(te3eCase.ClientState.XMLEncode());
                sb.AppendLine(" ");
                sb.AppendLine(te3eCase.ClientZipCode.XMLEncode());
                string clientaddress = sb.ToString();

                sb = new StringBuilder();
                sb.AppendLine($"{te3eCase.OfficeStreet.XMLEncode()}");
                sb.AppendLine("<w:br/>");
                sb.AppendLine($"{te3eCase.OfficeCity.XMLEncode()}, {te3eCase.OfficeState.XMLEncode()} {te3eCase.OfficeZipCode.XMLEncode()}");

                //sb.AppendLine(te3eCase.OfficeCity.XMLEncode());
                //sb.AppendLine(",");
                //sb.AppendLine(te3eCase.OfficeState.XMLEncode());
                //sb.AppendLine(" ");
                //sb.AppendLine(te3eCase.OfficeZipCode.XMLEncode());

                sb.Append("<w:br/>");
                sb.AppendLine($"{te3eCase.OfficePhone} Telephone");
                sb.Append("<w:br/>");

                if (!string.IsNullOrEmpty(te3eCase.OfficeFax))
                {
                    sb.AppendLine($"{te3eCase.OfficeFax.XMLEncode()} Facsimile");
                    sb.Append("<w:br/>");
                }

                if (!string.IsNullOrEmpty(te3eCase.CertAuthNo))
                    sb.AppendLine($"Certificate of Authorization No. {te3eCase.CertAuthNo.XMLEncode()}");

                string officeaddress = sb.ToString();

                sb = new StringBuilder();

                if (!string.IsNullOrEmpty(te3eCase.InsuredName))
                {
                    sb.AppendLine($"Insured: {FixXMLString(te3eCase.InsuredName.XMLEncode())}");
                    sb.Append("<w:br/>");
                }

                //sb.AppendLine($"Adjustment Firm No: {te3eCase.InsuredName}");
                //sb.Append("<w:br/>");

                if (!string.IsNullOrEmpty(te3eCase.CauseNo))
                {
                    sb.AppendLine($"Cause No: {te3eCase.CauseNo.XMLEncode()}");
                    sb.Append("<w:br/>");
                }

                if (!string.IsNullOrEmpty(te3eCase.Style))
                {
                    sb.AppendLine($"Style: {FixXMLString(te3eCase.Style)}");
                    sb.Append("<w:br/>");
                }

                if (!string.IsNullOrEmpty(te3eCase.ClientName))
                {
                    sb.AppendLine($"Client: {FixXMLString(te3eCase.ClientName)}");
                    sb.Append("<w:br/>");
                }

                if (!string.IsNullOrEmpty(te3eCase.ClaimNo))
                {
                    sb.AppendLine($"Claim No: {te3eCase.ClaimNo.XMLEncode()}");
                    sb.Append("<w:br/>");
                }

                if (!string.IsNullOrEmpty(te3eCase.Claimant))
                {
                    sb.AppendLine($"Claimant: {FixXMLString(te3eCase.Claimant)}");
                    sb.Append("<w:br/>");
                }

                if (!string.IsNullOrEmpty(te3eCase.DateOfLoss))
                {
                    sb.AppendLine($"Date of Loss: {te3eCase.DateOfLoss.XMLEncode()}");
                    sb.Append("<w:br/>");
                }

                sb.AppendLine("Subject: Evidence Storage");
                sb.Append("<w:br/>");
                sb.AppendLine($"File No.: {te3eCase.MatterNo.XMLEncode()}");
                string referencenumberlabel = sb.ToString();

                contents = objStreamReader.ReadToEnd();
                contents = contents.Replace("thedate", model.ReceivedAt?.ToString("MMMM d, yyyy"));
                contents = contents.Replace("clientcontact", FixXMLString(te3eCase.ContactName));
                contents = contents.Replace("clientname", FixXMLString(te3eCase.ClientName));
                contents = contents.Replace("clientaddress", clientaddress);
                contents = contents.Replace("clientemail", te3eCase.ContactEmail.XMLEncode());

                contents = contents.Replace("referencenumberlabel", referencenumberlabel);
                contents = contents.Replace("officeaddress", officeaddress);
                contents = contents.Replace("evidencedescription", string.IsNullOrEmpty(te3eCase.EvidenceDescription) ? "" : FixXMLString(te3eCase.EvidenceDescription));
                contents = contents.Replace("evidencerate", te3eCase.ChargedAmount.XMLEncode());
                contents = contents.Replace("techname", te3eCase.Technician.XMLEncode());
                contents = contents.Replace("techemail", te3eCase.TechnicianEmail.XMLEncode());
                //contents = contents.Replace("30days", te3eCase.ExpirationDate.XMLEncode());
                contents = contents.Replace("30days", model.Expiration.Value.ToLongDateString().XMLEncode());
                contents = contents.Replace("quarterly", te3eCase.BillTerm.XMLEncode());
                contents = contents.Replace("RecipientName", model.RecipientName.XMLEncode());
                contents = contents.Replace("RecipientCompany", model.RecipientCompany.XMLEncode());
                contents = contents.Replace("RecipientAddress", model.RecipientAddress.XMLEncode());
                var addressComponents = new List<string>();
                if (!string.IsNullOrEmpty(model.RecipientCity))
                {
                    addressComponents.Add(model.RecipientCity.XMLEncode());
                }
                if (!string.IsNullOrEmpty(model.RecipientState))
                {
                    addressComponents.Add(model.RecipientState.XMLEncode());
                }
                if (!string.IsNullOrEmpty(model.RecipientZipCode))
                {
                    addressComponents.Add(model.RecipientZipCode.XMLEncode());
                }
                contents = contents.Replace("RecipientCity", string.Join(", ", addressComponents));
                //contents = contents.Replace("RecipientState", model.RecipientState);
                //contents = contents.Replace("RecipientZipCode", model.RecipientZipCode);
                contents = contents.Replace("RecipientPhone", model.RecipientPhone.XMLEncode());
                contents = contents.Replace("RecipientCarrierName", model.RecipientCarrierName.XMLEncode());
                contents = contents.Replace("DecisionOption1", (model.DecisionOption ?? 0) == 1 ? "2612" : "0");
                contents = contents.Replace("DecisionOption2", (model.DecisionOption ?? 0) == 2 ? "2612" : "0");
                contents = contents.Replace("DecisionOption3", (model.DecisionOption ?? 0) == 3 ? "2612" : "0");
                contents = contents.Replace("PackageInsuredYes", model.IsInsured ?? false ? "2612" : "0");
                contents = contents.Replace("PackageInsuredNo", !model.IsInsured ?? true ? "2612" : "0");
                if (!(model.IsInsured ?? false) || (model.InsuranceAmount == null || model.InsuranceAmount <= 0))
                {
                    contents = contents.Replace("InsuranceAmount", "\t\t\t");
                }
                else
                {
                    contents = contents.Replace("InsuranceAmount", model.InsuranceAmount.ToString());
                }
                contents = contents.Replace("AuthorizedRepresentative", model.AuthorizedRepresentative.XMLEncode());
                contents = contents.Replace("ReceivedAt", model.ReceivedAt?.ToString("MM/dd/yyyy").XMLEncode());
                //contents = contents.Replace("ReceivedAt", DateTime.Now.ToString("MM/dd/yyyy"));
                contents = contents.Replace("OfficePhone", string.Empty.XMLEncode());
                contents = contents.Replace("YourCompanyName", string.Empty.XMLEncode());
            }

            string decisionLetterDoc = $@"{Path.GetTempPath()}{strexportfile}";
            {
                File.WriteAllText(decisionLetterDoc, contents);
            }
            //convert to pdf
            AsposeUtil asposeUtil = new AsposeUtil();
            string decisionLetterPdf = asposeUtil.ConvertWordToPdf(decisionLetterDoc);

            return decisionLetterPdf;
        }

        public string GenerateDecisionLetterPdf(string matterNo, bool isDebug)
        {
            var te3eCase = GetClientTS3EInfo(matterNo);

            string strexportfile = $"Evidence_{matterNo}_Decision.doc";
            string contents = "";

            string strTemplate = "EvidenceDecisionLetter.xml";
            var path = HttpContext.Current.Server.MapPath($"~{(isDebug ? "/bin" : string.Empty)}/data/trackersafe/templates/{strTemplate}");
            using (var objStreamReader = File.OpenText(path))
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(te3eCase.ClientStreet.XMLEncode());
                sb.Append("<w:br/>");
                sb.AppendLine($"{te3eCase.ClientCity.XMLEncode()}, {te3eCase.ClientState.XMLEncode()} {te3eCase.ClientZipCode.XMLEncode()}");
                string clientaddress = sb.ToString();

                sb = new StringBuilder();
                sb.AppendLine($"{te3eCase.OfficeStreet.XMLEncode()}");
                sb.Append("<w:br/>");
                sb.AppendLine($"{te3eCase.OfficeCity.XMLEncode()}, {te3eCase.OfficeState.XMLEncode()} {te3eCase.OfficeZipCode.XMLEncode()}");
                sb.Append("<w:br/>");
                sb.AppendLine($"{te3eCase.OfficePhone.XMLEncode()} Telephone");
                sb.Append("<w:br/>");

                if (!string.IsNullOrEmpty(te3eCase.OfficeFax))
                {
                    sb.AppendLine($"{te3eCase.OfficeFax.XMLEncode()} Facsimile");
                    sb.Append("<w:br/>");
                }

                if (!string.IsNullOrEmpty(te3eCase.CertAuthNo))
                    sb.AppendLine($"Certificate of Authorization No. {te3eCase.CertAuthNo.XMLEncode()}");

                string officeaddress = sb.ToString();

                sb = new StringBuilder();

                if (!string.IsNullOrEmpty(te3eCase.InsuredName))
                {
                    sb.AppendLine($"Insured: {FixXMLString(te3eCase.InsuredName.XMLEncode())}");
                    sb.Append("<w:br/>");
                }

                //sb.AppendLine($"Adjustment Firm No: {te3eCase.InsuredName}");
                //sb.Append("<w:br/>");

                if (!string.IsNullOrEmpty(te3eCase.CauseNo))
                {
                    sb.AppendLine($"Cause No: {te3eCase.CauseNo.XMLEncode()}");
                    sb.Append("<w:br/>");
                }

                if (!string.IsNullOrEmpty(te3eCase.Style))
                {
                    sb.AppendLine($"Style: {FixXMLString(te3eCase.Style.XMLEncode())}");
                    sb.Append("<w:br/>");
                }

                if (!string.IsNullOrEmpty(te3eCase.ClientName))
                {
                    sb.AppendLine($"Client: {FixXMLString(te3eCase.ClientName.XMLEncode())}");
                    sb.Append("<w:br/>");
                }

                if (!string.IsNullOrEmpty(te3eCase.ClaimNo))
                {
                    sb.AppendLine($"Claim No: {te3eCase.ClaimNo.XMLEncode()}");
                    sb.Append("<w:br/>");
                }

                if (!string.IsNullOrEmpty(te3eCase.Claimant))
                {
                    sb.AppendLine($"Claimant: {FixXMLString(te3eCase.Claimant.XMLEncode())}");
                    sb.Append("<w:br/>");
                }

                if (!string.IsNullOrEmpty(te3eCase.DateOfLoss))
                {
                    sb.AppendLine($"Date of Loss: {te3eCase.DateOfLoss.XMLEncode()}");
                    sb.Append("<w:br/>");
                }

                sb.AppendLine("Subject: Evidence Storage");
                sb.Append("<w:br/>");
                sb.AppendLine($"File No.: {te3eCase.MatterNo.XMLEncode()}");
                string referencenumberlabel = sb.ToString();

                contents = objStreamReader.ReadToEnd();
                contents = contents.Replace("thedate", DateTime.Now.ToString("MMMM d, yyyy"));

                contents = contents.Replace("clientcontact", FixXMLString(te3eCase.ContactName.XMLEncode()));
                contents = contents.Replace("clientname", FixXMLString(te3eCase.ClientName.XMLEncode()));
                contents = contents.Replace("clientaddress", clientaddress);
                contents = contents.Replace("clientemail", te3eCase.ContactEmail.XMLEncode());

                contents = contents.Replace("referencenumberlabel", referencenumberlabel);
                contents = contents.Replace("officeaddress", officeaddress);
                contents = contents.Replace("evidencedescription", string.IsNullOrEmpty(te3eCase.EvidenceDescription.XMLEncode()) ? "" : FixXMLString(te3eCase.EvidenceDescription));
                contents = contents.Replace("evidencerate", te3eCase.ChargedAmount.XMLEncode());
                contents = contents.Replace("techname", te3eCase.Technician.XMLEncode());
                contents = contents.Replace("techemail", te3eCase.TechnicianEmail.XMLEncode());
                contents = contents.Replace("30days", te3eCase.ExpirationDate.XMLEncode());
                contents = contents.Replace("quarterly", te3eCase.BillTerm.XMLEncode());
            }

            var decisionLetterResp = GetDecisionLetterFromMatterNo(matterNo);
            //todo: update content for decision letter response

            string decisionLetterDoc = $@"{Path.GetTempPath()}{strexportfile}";

            File.WriteAllText(decisionLetterDoc, contents);
            //convert to pdf
            AsposeUtil asposeUtil = new AsposeUtil();
            string decisionLetterPdf = asposeUtil.ConvertWordToPdf(decisionLetterDoc);

            return decisionLetterPdf;
        }

        private string FixXMLString(string strValue)
        {
            try
            {

                strValue = strValue.Replace("&", "&amp;")
                                   .Replace("\"\"", "&quot;")
                                   .Replace("'", "&apos;")
                                   .Replace("<", "&lt;")
                                   .Replace(">", "&gt;");
            }
            catch { }

            return strValue;
        }
        #endregion TrackerSafe DecisionLetter
    }
}
