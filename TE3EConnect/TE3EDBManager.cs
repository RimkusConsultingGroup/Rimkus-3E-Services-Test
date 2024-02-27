using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TE3EConnect.extension;
using TE3EConnect.te3eDB;
using TE3EConnect.te3eDB.DbInfo.Entity;

namespace TE3EConnect
{
    public class TE3EDBManager
    {
        public static List<RetrieveCollectionItemsByPastDueDays_Result> RetrieveCollectionItemsByPastDueDays(int numOfDays, int sqlCommandTimeout, bool isDebug = false)
        {
            if (isDebug)
            {
                TE3ERCGSyncEntities tE3EDBEntities = new TE3ERCGSyncEntities();
                tE3EDBEntities.Database.CommandTimeout = sqlCommandTimeout;
                return tE3EDBEntities.RetrieveCollectionItemsByPastDueDays(numOfDays).ToList();
            }

            TE3ERCGSYNCPRODEntities tE3EDBProdEntities = new TE3ERCGSYNCPRODEntities();
            tE3EDBProdEntities.Database.CommandTimeout = sqlCommandTimeout;
            return tE3EDBProdEntities.RetrieveCollectionItemsByPastDueDays(numOfDays).ToList();
        }

        public static List<CustomSubjectLine> RetrieveCustomSubjectLine(int sqlCommandTimeout, bool isDebug = false)
        {
            if (isDebug)
            {
                TE3ERCGSyncEntities tE3EDBEntities = new TE3ERCGSyncEntities();
                tE3EDBEntities.Database.CommandTimeout = sqlCommandTimeout;
                return (from cSubLine in tE3EDBEntities.CustomSubjectLines
                                      select cSubLine).ToList();
            }

            TE3ERCGSYNCPRODEntities tE3EDBProdEntities = new TE3ERCGSYNCPRODEntities();
            tE3EDBProdEntities.Database.CommandTimeout = sqlCommandTimeout;
            return (from cSubLine in tE3EDBProdEntities.CustomSubjectLines
                                  select cSubLine).ToList();
        }

        public static List<RetrieveLetterHeaderAddress_Result> RetrieveLetterHeadAddresses(string matterNo, int sqlCommandTimeout, bool isDebug = false)
        {
            if (isDebug)
            {
                TE3ERCGSyncEntities tE3EDBEntities = new TE3ERCGSyncEntities();
                tE3EDBEntities.Database.CommandTimeout = sqlCommandTimeout;
                return tE3EDBEntities.RetrieveLetterHeaderAddress(matterNo).ToList();
            }

            TE3ERCGSYNCPRODEntities tE3EDBProdEntities = new TE3ERCGSYNCPRODEntities();
            tE3EDBProdEntities.Database.CommandTimeout = sqlCommandTimeout;
            return tE3EDBProdEntities.RetrieveLetterHeaderAddress(matterNo).ToList();
        }

        public static List<RetrieveItemizedInvCollection_Result> RetrieveItemizedInvCollection(string collectionItem, int sqlCommandTimeout, bool isDebug = false)
        {
            if(isDebug)
            {
                TE3ERCGSyncEntities tE3EDBEntities = new TE3ERCGSyncEntities();
                tE3EDBEntities.Database.CommandTimeout = sqlCommandTimeout;
                return tE3EDBEntities.RetrieveItemizedInvCollection(collectionItem).ToList();
            }

            TE3ERCGSYNCPRODEntities tE3EDBProdEntities = new TE3ERCGSYNCPRODEntities();
            tE3EDBProdEntities.Database.CommandTimeout = sqlCommandTimeout;
            return tE3EDBProdEntities.RetrieveItemizedInvCollection(collectionItem).ToList();
        }

        public static List<RetrieveMatterByNum_Result> RetrieveMatterByNum(string matterNo, int sqlCommandTimeout, bool isDebug = false)
        {
            if (isDebug)
            {
                TE3ERCGSyncEntities tE3EDBEntities = new TE3ERCGSyncEntities();
                tE3EDBEntities.Database.CommandTimeout = sqlCommandTimeout;
                return tE3EDBEntities.RetrieveMatterByNum(matterNo).ToList();
            }

            TE3ERCGSYNCPRODEntities tE3EDBProdEntities = new TE3ERCGSYNCPRODEntities();
            tE3EDBProdEntities.Database.CommandTimeout = sqlCommandTimeout;
            return tE3EDBProdEntities.RetrieveMatterByNum(matterNo).ToList();
        }

        public static List<RetrieveMatteCPC_Result> RetrieveMatteCPC(string matterNo, int sqlCommandTimeout, bool isDebug = false)
        {
            if (isDebug)
            {
                TE3ERCGSyncEntities tE3EDBEntities = new TE3ERCGSyncEntities();
                tE3EDBEntities.Database.CommandTimeout = sqlCommandTimeout;
                return tE3EDBEntities.RetrieveMatteCPC(matterNo).ToList();
            }

            TE3ERCGSYNCPRODEntities tE3EDBProdEntities = new TE3ERCGSYNCPRODEntities();
            tE3EDBProdEntities.Database.CommandTimeout = sqlCommandTimeout;
            return tE3EDBProdEntities.RetrieveMatteCPC(matterNo).ToList();
        }

        public static List<ClientMaster> RetrieveClientMaster(int sqlCommandTimeout, bool isDebug = false)
        {
            if (isDebug)
            {
                TE3ERCGSyncEntities tE3EDBEntities = new TE3ERCGSyncEntities();
                tE3EDBEntities.Database.CommandTimeout = sqlCommandTimeout;
                return tE3EDBEntities.ClientMasters.ToList();
            }

            TE3ERCGSYNCPRODEntities tE3EDBProdEntities = new TE3ERCGSYNCPRODEntities();
            tE3EDBProdEntities.Database.CommandTimeout = sqlCommandTimeout;
            return tE3EDBProdEntities.ClientMasters.ToList();
        }

        public static List<ClientMaster> AddNewClientKey(string clientName, int sqlCommandTimeout, bool isDebug = false)
        {
            string appId = Guid.NewGuid().ToString().ToUpper();
            var appKey = e3eExtension.GenerateAPPKey();

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
                return tE3EDBEntities.ClientMasters.ToList();
            }

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
            return tE3EDBProdEntities.ClientMasters.ToList();
        }

        public static List<GetLookupTypes_Result> GetLookupTypes(int sqlCommandTimeout, bool isDebug = false)
        {
            TE3ERCGSyncEntities tE3EDBEntities = new TE3ERCGSyncEntities();
            tE3EDBEntities.Database.CommandTimeout = sqlCommandTimeout;
            return tE3EDBEntities.GetLookupTypes().ToList();

            //if (isDebug)
            //{
            //    TE3ERCGSyncEntities tE3EDBEntities = new TE3ERCGSyncEntities();
            //    tE3EDBEntities.Database.CommandTimeout = sqlCommandTimeout;
            //    return tE3EDBEntities.GetLookupTypes().ToList();
            //}

            //TE3ERCGSYNCPRODEntities tE3EDBProdEntities = new TE3ERCGSYNCPRODEntities();
            //tE3EDBProdEntities.Database.CommandTimeout = sqlCommandTimeout;
            //return tE3EDBProdEntities.GetLookupTypes().ToList();
        }

        public static List<GetLookupCodes_Result> GetLookupCodes(int lookupId, int sqlCommandTimeout, bool isDebug = false)
        {
            var lookupTypes = GetLookupTypes(sqlCommandTimeout, isDebug).Where(x => x.ID == lookupId).Select(x => x);
            var lookupType = (lookupTypes != null) ? lookupTypes.First().Type : "";
            
            TE3ERCGSyncEntities tE3EDBEntities = new TE3ERCGSyncEntities();
            tE3EDBEntities.Database.CommandTimeout = sqlCommandTimeout;
            return tE3EDBEntities.GetLookupCodes(lookupType).ToList();

            //if (isDebug)
            //{
            //    TE3ERCGSyncEntities tE3EDBEntities = new TE3ERCGSyncEntities();
            //    tE3EDBEntities.Database.CommandTimeout = sqlCommandTimeout;
            //    return tE3EDBEntities.GetLookupCodes(lookupType).ToList();
            //}

            //TE3ERCGSYNCPRODEntities tE3EDBProdEntities = new TE3ERCGSYNCPRODEntities();
            //tE3EDBProdEntities.Database.CommandTimeout = sqlCommandTimeout;
            //return tE3EDBProdEntities.GetLookupCodes(lookupType).ToList();
        }
    }
}
