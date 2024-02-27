using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TE3EEntityFramework.Client;
using TE3EEntityFramework.Client.RCGKENTCMS;
using TE3EEntityFramework.Datasource;
using TE3EEntityFramework.Datasource.RCGKENTCMS.DataModel;

namespace TE3EEntityFramework.Setting
{
    public class CMSAzureSBAppSetting
    {
        public bool IsDebug { get; private set; }
        public int SqlCommandTimeout { get; private set; }
        public int AttemptsAllowed { get; private set; }
        public int NumOfDays { get; private set; }
        public string Enotify_From { get; private set; }
        public string Enotify_To { get; private set; }
        public string Enotify_Cc { get; private set; }
        public EnvEnum Te3eServer { get; private set; }
        public string RCG3EDbServer { get; private set; }
        public string RCG3EDbInstance { get; private set; }
        public string RCGDbServer { get; private set; }
        public string RCGDbInstance { get; private set; }
        public string KenticoAPIURL { get; private set; }
        public string KenticoAPIKey { get; private set; }
        public EnvEnum OnPremQueueDBEnv { get; set; }
        public EnvEnum AzureQueueEnv { get; private set; }
        public bool IsProdUpgradedVersion { get; private set; }

        public CMSAzureSBSetting AzSbSetting { get; private set; }

        public CMSAzureSBAppSetting(NameValueCollection appSettings, CMSSQLClientV2 te3EClient)
        {
            IsDebug = Convert.ToBoolean(appSettings["is_debug"] ?? "false");
            SqlCommandTimeout = Convert.ToInt32(appSettings["sqlCommandTimeout"] ?? "60000");
            IsProdUpgradedVersion = Convert.ToBoolean(appSettings["is_prod_upgraded_version"] ?? "true");

            Te3eServer = (EnvEnum)Enum.Parse(typeof(EnvEnum), (appSettings["3e_server"] ?? "DEV"), true);
            AzureQueueEnv = (EnvEnum)Enum.Parse(typeof(EnvEnum), (appSettings["AzureQueueEnv"] ?? "DEV"), true);
            OnPremQueueDBEnv = (EnvEnum)Enum.Parse(typeof(EnvEnum), (appSettings["OnPremQueueDBEnv"] ?? "DEV"), true);
            CMSKenticoConfiguration cMSKenticoConfiguration = te3EClient.GetCMSKenticoConfiguration(SqlCommandTimeout, OnPremQueueDBEnv);

            switch (Te3eServer)
            {
                case EnvEnum.DEV:
                    RCG3EDbServer = "RCG3ESQL31-D.RIMKUS.NET";
                    RCG3EDbInstance = "TE_3E_DEV";
                    break;
                case EnvEnum.UAT:
                    RCG3EDbServer = "RCG3ESQL31-D.RIMKUS.NET";
                    RCG3EDbInstance = "TE_3E_UAT";
                    break;
                case EnvEnum.PROD:
                    RCG3EDbServer = "RCG3ESQL31";
                    RCG3EDbInstance = "TE_3E_PROD";
                    break;
                case EnvEnum.STAGING:
                    RCG3EDbServer = "RCG3ESQL31-D.RIMKUS.NET";
                    RCG3EDbInstance = "TE_3E_STAGING";
                    break;
                default:
                    break;
            }

            switch (AzureQueueEnv)
            {
                case EnvEnum.DEV:
                    KenticoAPIURL = cMSKenticoConfiguration.KenticoAPIURL_DEV;
                    KenticoAPIKey = cMSKenticoConfiguration.KenticoAPIKey_DEV;
                    break;
                case EnvEnum.UAT:
                    KenticoAPIURL = cMSKenticoConfiguration.KenticoAPIURL_UAT;
                    KenticoAPIKey = cMSKenticoConfiguration.KenticoAPIKey_UAT;
                    break;
                case EnvEnum.PROD:
                    KenticoAPIURL = cMSKenticoConfiguration.KenticoAPIURL_PROD;
                    KenticoAPIKey = cMSKenticoConfiguration.KenticoAPIKey_PROD;
                    break;
                default:
                    break;
            }

            switch (OnPremQueueDBEnv)
            {
                case EnvEnum.DEV:
                    RCGDbServer = "RCGSQL06-D";
                    RCGDbInstance = "RCGKENTCMS_DEV01";
                    break;
                case EnvEnum.UAT:
                    RCGDbServer = "RCGSQL06-D";
                    RCGDbInstance = "RCGKENTCMS_UAT01";
                    break;
                case EnvEnum.STAGING:
                    RCGDbServer = "RCGSQL06-D";
                    RCGDbInstance = "RCGKENTCMS_STAGING01";
                    break;
                case EnvEnum.PROD:
                    RCGDbServer = "RCGSQL15";
                    RCGDbInstance = "RCGKENTCMS_PROD01";
                    break;
                default:
                    break;
            }


            AttemptsAllowed = Convert.ToBoolean(appSettings["run_service_as_debug"] ?? "false") ? 20 : cMSKenticoConfiguration.NumOfAttemptsAllowed ?? 20;
            NumOfDays = cMSKenticoConfiguration.NumOfDays ?? 1;
            Enotify_From = cMSKenticoConfiguration.Enotify_From ?? "";
            Enotify_To = cMSKenticoConfiguration.Enotify_To ?? "";
            Enotify_Cc = cMSKenticoConfiguration.Enotify_Cc ?? "";
            AzSbSetting = new CMSAzureSBSetting(appSettings, AzureQueueEnv, cMSKenticoConfiguration);
        }
    }

    public class CMSAzureSBSetting
    {
        public string TE3EAssignmentAzSBConn;
        public string TE3EAssignmentAzSBQueueName;
        public string KenticoAssignmentAzSBConn;
        public string KenticoAssignmentAzSBQueueName;
        public string DynamicsCustomersAzSBConn;
        public string DynamicsCustomersAzSBQueueName;
        public string KenticoCustomersAzSBConn;
        public string KenticoCustomersAzSBQueueName;

        public CMSAzureSBSetting(NameValueCollection appSettings, EnvEnum AzureQueueEnv, CMSKenticoConfiguration cMSKenticoConfiguration)
        {
            switch (AzureQueueEnv)
            {
                case EnvEnum.DEV:
                    {
                        AzureSBDevSetting azureServiceBusDevSetting = new AzureSBDevSetting(appSettings, cMSKenticoConfiguration);
                        TE3EAssignmentAzSBConn = azureServiceBusDevSetting.TE3EAssignmentAzSBConn_Dev;
                        TE3EAssignmentAzSBQueueName = azureServiceBusDevSetting.TE3EAssignmentAzSBQueueName_Dev;
                        KenticoAssignmentAzSBConn = azureServiceBusDevSetting.KenticoAssignmentAzSBConn_Dev;
                        KenticoAssignmentAzSBQueueName = azureServiceBusDevSetting.KenticoAssignmentAzSBQueueName_Dev;
                        DynamicsCustomersAzSBConn = azureServiceBusDevSetting.DynamicsCustomersAzSBConn_Dev;
                        DynamicsCustomersAzSBQueueName = azureServiceBusDevSetting.DynamicsCustomersAzSBQueueName_Dev;
                        KenticoCustomersAzSBConn = azureServiceBusDevSetting.KenticoCustomersAzSBConn_Dev;
                        KenticoCustomersAzSBQueueName = azureServiceBusDevSetting.KenticoCustomersAzSBQueueName_Dev;
                    }
                    break;
                case EnvEnum.UAT:
                    {
                        AzureSBUatSetting azureServiceBusUatSetting = new AzureSBUatSetting(appSettings, cMSKenticoConfiguration);
                        TE3EAssignmentAzSBConn = azureServiceBusUatSetting.TE3EAssignmentAzSBConn_Uat;
                        TE3EAssignmentAzSBQueueName = azureServiceBusUatSetting.TE3EAssignmentAzSBQueueName_Uat;
                        KenticoAssignmentAzSBConn = azureServiceBusUatSetting.KenticoAssignmentAzSBConn_Uat;
                        KenticoAssignmentAzSBQueueName = azureServiceBusUatSetting.KenticoAssignmentAzSBQueueName_Uat;
                        DynamicsCustomersAzSBConn = azureServiceBusUatSetting.DynamicsCustomersAzSBConn_Uat;
                        DynamicsCustomersAzSBQueueName = azureServiceBusUatSetting.DynamicsCustomersAzSBQueueName_Uat;
                        KenticoCustomersAzSBConn = azureServiceBusUatSetting.KenticoCustomersAzSBConn_Uat;
                        KenticoCustomersAzSBQueueName = azureServiceBusUatSetting.KenticoCustomersAzSBQueueName_Uat;
                    }
                    break;
                case EnvEnum.PROD:
                    {
                        AzureSBProdSetting azureServiceBusProdSetting = new AzureSBProdSetting(appSettings, cMSKenticoConfiguration);
                        TE3EAssignmentAzSBConn = azureServiceBusProdSetting.TE3EAssignmentAzSBConn_Prod;
                        TE3EAssignmentAzSBQueueName = azureServiceBusProdSetting.TE3EAssignmentAzSBQueueName_Prod;
                        KenticoAssignmentAzSBConn = azureServiceBusProdSetting.KenticoAssignmentAzSBConn_Prod;
                        KenticoAssignmentAzSBQueueName = azureServiceBusProdSetting.KenticoAssignmentAzSBQueueName_Prod;
                        DynamicsCustomersAzSBConn = azureServiceBusProdSetting.DynamicsCustomersAzSBConn_Prod;
                        DynamicsCustomersAzSBQueueName = azureServiceBusProdSetting.DynamicsCustomersAzSBQueueName_Prod;
                        KenticoCustomersAzSBConn = azureServiceBusProdSetting.KenticoCustomersAzSBConn_Prod;
                        KenticoCustomersAzSBQueueName = azureServiceBusProdSetting.KenticoCustomersAzSBQueueName_Prod;
                    }
                    break;
                default:
                    break;
            }
        }
    }

    internal class AzureSBDevSetting
    {
        public string TE3EAssignmentAzSBConn_Dev;
        public string TE3EAssignmentAzSBQueueName_Dev;
        public string KenticoAssignmentAzSBConn_Dev;
        public string KenticoAssignmentAzSBQueueName_Dev;
        public string DynamicsCustomersAzSBConn_Dev;
        public string DynamicsCustomersAzSBQueueName_Dev;
        public string KenticoCustomersAzSBConn_Dev;
        public string KenticoCustomersAzSBQueueName_Dev;
        internal AzureSBDevSetting(NameValueCollection appSettings, CMSKenticoConfiguration cMSKenticoConfiguration)
        {
            TE3EAssignmentAzSBConn_Dev = cMSKenticoConfiguration.TE3EAssignmentAzSBConn_Dev ?? "??";
            TE3EAssignmentAzSBQueueName_Dev = cMSKenticoConfiguration.TE3EAssignmentAzSBQueueName_Dev ?? "??";
            KenticoAssignmentAzSBConn_Dev = cMSKenticoConfiguration.KenticoAssignmentAzSBConn_Dev ?? "??";
            KenticoAssignmentAzSBQueueName_Dev = cMSKenticoConfiguration.KenticoAssignmentAzSBQueueName_Dev ?? "??";
            DynamicsCustomersAzSBConn_Dev = cMSKenticoConfiguration.DynamicsCustomersAzSBConn_Dev ?? "??";
            DynamicsCustomersAzSBQueueName_Dev = cMSKenticoConfiguration.DynamicsCustomersAzSBQueueName_Dev ?? "??";
            KenticoCustomersAzSBConn_Dev = cMSKenticoConfiguration.KenticoCustomersAzSBConn_Dev ?? "??";
            KenticoCustomersAzSBQueueName_Dev = cMSKenticoConfiguration.KenticoCustomersAzSBQueueName_Dev ?? "??";
        }
    }

    internal class AzureSBUatSetting
    {
        public string TE3EAssignmentAzSBConn_Uat;
        public string TE3EAssignmentAzSBQueueName_Uat;
        public string KenticoAssignmentAzSBConn_Uat;
        public string KenticoAssignmentAzSBQueueName_Uat;
        public string DynamicsCustomersAzSBConn_Uat;
        public string DynamicsCustomersAzSBQueueName_Uat;
        public string KenticoCustomersAzSBConn_Uat;
        public string KenticoCustomersAzSBQueueName_Uat;
        internal AzureSBUatSetting(NameValueCollection appSettings, CMSKenticoConfiguration cMSKenticoConfiguration)
        {
            TE3EAssignmentAzSBConn_Uat = cMSKenticoConfiguration.TE3EAssignmentAzSBConn_Uat ?? "??";
            TE3EAssignmentAzSBQueueName_Uat = cMSKenticoConfiguration.TE3EAssignmentAzSBQueueName_Uat ?? "??";
            KenticoAssignmentAzSBConn_Uat = cMSKenticoConfiguration.KenticoAssignmentAzSBConn_Uat ?? "??";
            KenticoAssignmentAzSBQueueName_Uat = cMSKenticoConfiguration.KenticoAssignmentAzSBQueueName_Uat ?? "??";
            DynamicsCustomersAzSBConn_Uat = cMSKenticoConfiguration.DynamicsCustomersAzSBConn_Uat ?? "??";
            DynamicsCustomersAzSBQueueName_Uat = cMSKenticoConfiguration.DynamicsCustomersAzSBQueueName_Uat ?? "??";
            KenticoCustomersAzSBConn_Uat = cMSKenticoConfiguration.KenticoCustomersAzSBConn_Uat ?? "??";
            KenticoCustomersAzSBQueueName_Uat = cMSKenticoConfiguration.KenticoCustomersAzSBQueueName_Uat ?? "??";
        }
    }
    internal class AzureSBProdSetting
    {
        public string TE3EAssignmentAzSBConn_Prod;
        public string TE3EAssignmentAzSBQueueName_Prod;
        public string KenticoAssignmentAzSBConn_Prod;
        public string KenticoAssignmentAzSBQueueName_Prod;
        public string DynamicsCustomersAzSBConn_Prod;
        public string DynamicsCustomersAzSBQueueName_Prod;
        public string KenticoCustomersAzSBConn_Prod;
        public string KenticoCustomersAzSBQueueName_Prod;
        internal AzureSBProdSetting(NameValueCollection appSettings, CMSKenticoConfiguration cMSKenticoConfiguration)
        {
            TE3EAssignmentAzSBConn_Prod = cMSKenticoConfiguration.TE3EAssignmentAzSBConn_Prod ?? "??";
            TE3EAssignmentAzSBQueueName_Prod = cMSKenticoConfiguration.TE3EAssignmentAzSBQueueName_Prod ?? "??";
            KenticoAssignmentAzSBConn_Prod = cMSKenticoConfiguration.KenticoAssignmentAzSBConn_Prod ?? "??";
            KenticoAssignmentAzSBQueueName_Prod = cMSKenticoConfiguration.KenticoAssignmentAzSBQueueName_Prod ?? "??";
            DynamicsCustomersAzSBConn_Prod = cMSKenticoConfiguration.DynamicsCustomersAzSBConn_Prod ?? "??";
            DynamicsCustomersAzSBQueueName_Prod = cMSKenticoConfiguration.DynamicsCustomersAzSBQueueName_Prod ?? "??";
            KenticoCustomersAzSBConn_Prod = cMSKenticoConfiguration.KenticoCustomersAzSBConn_Prod ?? "??";
            KenticoCustomersAzSBQueueName_Prod = cMSKenticoConfiguration.KenticoCustomersAzSBQueueName_Prod ?? "??";
        }
    }
}
