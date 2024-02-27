using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TE3EEntityFramework.Client;
using TE3EEntityFramework.Client.RCGKENTCMS;
using TE3EEntityFramework.Client.UKGTE3E;
using TE3EEntityFramework.Datasource;
using TE3EEntityFramework.Datasource.RCGKENTCMS.DataModel;

namespace TE3EEntityFramework.Setting
{
    public class UKGTE3EAppSetting
    {
        public bool IsDebug { get; private set; }
        public int SqlCommandTimeout { get; private set; }
        public int AttemptsAllowed { get; private set; }
        public int NumOfDays { get; private set; }
        public string Enotify_From { get; private set; }
        public string Enotify_To { get; private set; }
        public string Enotify_Cc { get; private set; }
        public string Te3eServer { get; set; }
        public string RCG3EDbServer { get; private set; }
        public string RCG3EDbInstance { get; set; }
        public string RCGDbServer { get; private set; }
        public string RCGDbInstance { get; private set; }
        public TE3EEnv TE3EEnv { get; private set; }
        public bool IsProdUpgradedVersion { get; private set; }
        public bool IsEditRelXml { get; private set; }
        public string DropLocation { get; private set; }
        public TE3ETransaction tE3ETransaction { get; set; }
        //public CMSAzureSBSetting AzSbSetting { get; private set; }
        public bool HasMatterSrvAdd { get; private set; }
        public bool HasPOSrvAdd { get; private set; }
        public bool HasTimekeeperSrvAdd { get; private set; }
        public bool HasNxUserSrvAdd { get; private set; }

        public UKGTE3EAppSetting(NameValueCollection appSettings) //, UKGTE3ESQLClient uKGTE3ESQLClient)
        {
            SqlCommandTimeout = Convert.ToInt32(appSettings["sqlCommandTimeout"] ?? "60000");
            DropLocation = appSettings["drop_location"] ?? "";
            Te3eServer = appSettings["3e_server"].ToLower() ?? "dev";
            RCG3EDbServer = Te3eServer.ToLower() == "uat" || Te3eServer.ToLower() == "dev" || Te3eServer.ToLower() == "staging" ? "RCG3ESQL31-D" : "RCG3ESQL31";
            RCG3EDbInstance = Te3eServer.ToLower() == "uat" ? "TE_3E_UAT" : Te3eServer.ToLower() == "dev" ? "TE_3E_DEV" : Te3eServer.ToLower() == "staging" ? "TE_3E_STAGING" : "TE_3E_PROD";
            RCGDbServer = Te3eServer.ToLower() == "uat" || Te3eServer.ToLower() == "dev" || Te3eServer.ToLower() == "staging" ? "RCGSQL15" : "RCGSQL15";
            RCGDbInstance = Te3eServer.ToLower() == "dev" ? "UKG_TE_3E_SYNC_DEV01" : Te3eServer.ToLower() == "uat" ? "UKG_TE_3E_SYNC_UAT01" : Te3eServer.ToLower() == "staging" ? "UKG_TE_3E_SYNC_STG01" : "UKG_TE_3E_SYNC_PRO01";
            //CMSKenticoConfiguration cMSKenticoConfiguration = te3EClient.GetCMSKenticoConfiguration(SqlCommandTimeout, IsDebug);
            IsEditRelXml = Convert.ToBoolean(appSettings["3e_editRelXml"] ?? "false");
            IsProdUpgradedVersion = Convert.ToBoolean(appSettings["is_prod_upgraded_version"] ?? "true");
            TE3EEnv = Te3eServer == "dev" ? TE3EEnv.DEV : Te3eServer == "uat" ? TE3EEnv.UAT : TE3EEnv.PROD;
            AttemptsAllowed = Convert.ToInt32(appSettings["num_attempt_allowed"] ?? "20");
            NumOfDays = Convert.ToInt32(appSettings["num_days_past"] ?? "0");
            Enotify_From = appSettings["enotify_from"] ?? "";
            Enotify_To = appSettings["enotify_to"] ?? "";
            Enotify_Cc = appSettings["enotify_cc"] ?? "";

            HasMatterSrvAdd = Convert.ToBoolean(appSettings["mattersrv_add"] ?? "false");
            HasPOSrvAdd = Convert.ToBoolean(appSettings["posrv_add"] ?? "false");
            HasTimekeeperSrvAdd = Convert.ToBoolean(appSettings["timekeepersrv_add"] ?? "false");
            HasNxUserSrvAdd = Convert.ToBoolean(appSettings["nxusersrv_add"] ?? "false");

            if (appSettings.AllKeys.Contains("3e_transaction_process"))
            {
                var te3eTrans = appSettings["3e_transaction_process"].ToLower() ?? "POReqWF_CCC".ToLower();
                tE3ETransaction = te3eTrans == "POReqWF_CCC".ToLower() ? TE3ETransaction.POReqWF_CCC : te3eTrans == "POEntry".ToLower() ? TE3ETransaction.POEntry : TE3ETransaction.POUserApproveWF_CCC;

            }
        }
    }

    public enum TE3EEnv
    {
        DEV,
        UAT,
        PROD
    }

    public enum TE3ETransaction
    {
        POEntry,
        POReqWF_CCC,
        POUserApproveWF_CCC
    }
}
