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
    public class AzureServiceBusAppSetting
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
        public EnvEnum AzureQueueEnv { get; private set; }
        public EnvEnum OnPremQueueDBEnv { get; set; }
        public AzureServiceBusSetting AzSbSetting { get; private set; }

        public AzureServiceBusAppSetting(NameValueCollection appSettings, CMSSQLClientV2 cmsSQLClient)
        {
            IsDebug = Convert.ToBoolean(appSettings["is_debug"] ?? "false");
            SqlCommandTimeout = Convert.ToInt32(appSettings["sqlCommandTimeout"] ?? "60000");
            Te3eServer = (EnvEnum)Enum.Parse(typeof(EnvEnum), (appSettings["3e_server"] ?? "DEV"), true);
            AzureQueueEnv = (EnvEnum)Enum.Parse(typeof(EnvEnum), (appSettings["AzureQueueEnv"] ?? "DEV"), true);
            OnPremQueueDBEnv = (EnvEnum)Enum.Parse(typeof(EnvEnum), (appSettings["OnPremQueueDBEnv"] ?? "DEV"), true);

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

            CMSKenticoConfiguration cmsKenticoConfiguration = cmsSQLClient.GetCMSKenticoConfiguration(SqlCommandTimeout, OnPremQueueDBEnv);

            AttemptsAllowed = Convert.ToBoolean(appSettings["run_service_as_debug"] ?? "false") ? 20 : cmsKenticoConfiguration.NumOfAttemptsAllowed ?? 20;
            NumOfDays = cmsKenticoConfiguration.NumOfDays ?? 1;
            Enotify_From = cmsKenticoConfiguration.Enotify_From ?? "";
            Enotify_To = cmsKenticoConfiguration.Enotify_To ?? "";
            Enotify_Cc = cmsKenticoConfiguration.Enotify_Cc ?? "";
            AzSbSetting = new AzureServiceBusSetting(appSettings, AzureQueueEnv, cmsKenticoConfiguration);
        }
    }

    public class AzureServiceBusSetting
    {
        public string TE3EAssignmentAzSBConn;
        public string TE3EAssignmentAzSBQueueName;
        public string KenticoAssignmentAzSBConn;
        public string KenticoAssignmentAzSBQueueName;
        public string DynamicsCustomersAzSBConn;
        public string DynamicsCustomersAzSBQueueName;
        public string KenticoCustomersAzSBConn;
        public string KenticoCustomersAzSBQueueName;

        public AzureServiceBusSetting(NameValueCollection appSettings, EnvEnum AzureQueueEnv, CMSKenticoConfiguration cmsKenticoConfiguration)
        {
            switch (AzureQueueEnv)
            {
                case EnvEnum.PROD:
                    AzureServiceBusProdSetting azureServiceBusProdSetting = new AzureServiceBusProdSetting(appSettings, cmsKenticoConfiguration);
                    TE3EAssignmentAzSBConn = azureServiceBusProdSetting.TE3EAssignmentAzSBConn_Prod;
                    TE3EAssignmentAzSBQueueName = azureServiceBusProdSetting.TE3EAssignmentAzSBQueueName_Prod;
                    KenticoAssignmentAzSBConn = azureServiceBusProdSetting.KenticoAssignmentAzSBConn_Prod;
                    KenticoAssignmentAzSBQueueName = azureServiceBusProdSetting.KenticoAssignmentAzSBQueueName_Prod;
                    DynamicsCustomersAzSBConn = azureServiceBusProdSetting.DynamicsCustomersAzSBConn_Prod;
                    DynamicsCustomersAzSBQueueName = azureServiceBusProdSetting.DynamicsCustomersAzSBQueueName_Prod;
                    KenticoCustomersAzSBConn = azureServiceBusProdSetting.KenticoCustomersAzSBConn_Prod;
                    KenticoCustomersAzSBQueueName = azureServiceBusProdSetting.KenticoCustomersAzSBQueueName_Prod;
                    break;
                case EnvEnum.UAT:
                    AzureServiceBusUatSetting azureServiceBusUatSetting = new AzureServiceBusUatSetting(appSettings, cmsKenticoConfiguration);
                    TE3EAssignmentAzSBConn = azureServiceBusUatSetting.TE3EAssignmentAzSBConn_Uat;
                    TE3EAssignmentAzSBQueueName = azureServiceBusUatSetting.TE3EAssignmentAzSBQueueName_Uat;
                    KenticoAssignmentAzSBConn = azureServiceBusUatSetting.KenticoAssignmentAzSBConn_Uat;
                    KenticoAssignmentAzSBQueueName = azureServiceBusUatSetting.KenticoAssignmentAzSBQueueName_Uat;
                    DynamicsCustomersAzSBConn = azureServiceBusUatSetting.DynamicsCustomersAzSBConn_Uat;
                    DynamicsCustomersAzSBQueueName = azureServiceBusUatSetting.DynamicsCustomersAzSBQueueName_Uat;
                    KenticoCustomersAzSBConn = azureServiceBusUatSetting.KenticoCustomersAzSBConn_Uat;
                    KenticoCustomersAzSBQueueName = azureServiceBusUatSetting.KenticoCustomersAzSBQueueName_Uat;
                    break;
                case EnvEnum.DEV:
                default:
                    AzureServiceBusDevSetting azureServiceBusDevSetting = new AzureServiceBusDevSetting(appSettings, cmsKenticoConfiguration);
                    TE3EAssignmentAzSBConn = azureServiceBusDevSetting.TE3EAssignmentAzSBConn_Dev;
                    TE3EAssignmentAzSBQueueName = azureServiceBusDevSetting.TE3EAssignmentAzSBQueueName_Dev;
                    KenticoAssignmentAzSBConn = azureServiceBusDevSetting.KenticoAssignmentAzSBConn_Dev;
                    KenticoAssignmentAzSBQueueName = azureServiceBusDevSetting.KenticoAssignmentAzSBQueueName_Dev;
                    DynamicsCustomersAzSBConn = azureServiceBusDevSetting.DynamicsCustomersAzSBConn_Dev;
                    DynamicsCustomersAzSBQueueName = azureServiceBusDevSetting.DynamicsCustomersAzSBQueueName_Dev;
                    KenticoCustomersAzSBConn = azureServiceBusDevSetting.KenticoCustomersAzSBConn_Dev;
                    KenticoCustomersAzSBQueueName = azureServiceBusDevSetting.KenticoCustomersAzSBQueueName_Dev;
                    break;
            }
        }
    }

    internal class AzureServiceBusDevSetting
    {
        public string TE3EAssignmentAzSBConn_Dev;
        public string TE3EAssignmentAzSBQueueName_Dev;
        public string KenticoAssignmentAzSBConn_Dev;
        public string KenticoAssignmentAzSBQueueName_Dev;
        public string DynamicsCustomersAzSBConn_Dev;
        public string DynamicsCustomersAzSBQueueName_Dev;
        public string KenticoCustomersAzSBConn_Dev;
        public string KenticoCustomersAzSBQueueName_Dev;
        internal AzureServiceBusDevSetting(NameValueCollection appSettings, CMSKenticoConfiguration cmsKenticoConfiguration)
        {
            TE3EAssignmentAzSBConn_Dev = cmsKenticoConfiguration.TE3EAssignmentAzSBConn_Dev ?? "??";
            TE3EAssignmentAzSBQueueName_Dev = cmsKenticoConfiguration.TE3EAssignmentAzSBQueueName_Dev ?? "??";
            KenticoAssignmentAzSBConn_Dev = cmsKenticoConfiguration.KenticoAssignmentAzSBConn_Dev ?? "??";
            KenticoAssignmentAzSBQueueName_Dev = cmsKenticoConfiguration.KenticoAssignmentAzSBQueueName_Dev ?? "??";
            DynamicsCustomersAzSBConn_Dev = cmsKenticoConfiguration.DynamicsCustomersAzSBConn_Dev ?? "??";
            DynamicsCustomersAzSBQueueName_Dev = cmsKenticoConfiguration.DynamicsCustomersAzSBQueueName_Dev ?? "??";
            KenticoCustomersAzSBConn_Dev = cmsKenticoConfiguration.KenticoCustomersAzSBConn_Dev ?? "??";
            KenticoCustomersAzSBQueueName_Dev = cmsKenticoConfiguration.KenticoCustomersAzSBQueueName_Dev ?? "??";
        }
    }

    internal class AzureServiceBusUatSetting
    {
        public string TE3EAssignmentAzSBConn_Uat;
        public string TE3EAssignmentAzSBQueueName_Uat;
        public string KenticoAssignmentAzSBConn_Uat;
        public string KenticoAssignmentAzSBQueueName_Uat;
        public string DynamicsCustomersAzSBConn_Uat;
        public string DynamicsCustomersAzSBQueueName_Uat;
        public string KenticoCustomersAzSBConn_Uat;
        public string KenticoCustomersAzSBQueueName_Uat;
        internal AzureServiceBusUatSetting(NameValueCollection appSettings, CMSKenticoConfiguration cmsKenticoConfiguration)
        {
            TE3EAssignmentAzSBConn_Uat = cmsKenticoConfiguration.TE3EAssignmentAzSBConn_Uat ?? "??";
            TE3EAssignmentAzSBQueueName_Uat = cmsKenticoConfiguration.TE3EAssignmentAzSBQueueName_Uat ?? "??";
            KenticoAssignmentAzSBConn_Uat = cmsKenticoConfiguration.KenticoAssignmentAzSBConn_Uat ?? "??";
            KenticoAssignmentAzSBQueueName_Uat = cmsKenticoConfiguration.KenticoAssignmentAzSBQueueName_Uat ?? "??";
            DynamicsCustomersAzSBConn_Uat = cmsKenticoConfiguration.DynamicsCustomersAzSBConn_Uat ?? "??";
            DynamicsCustomersAzSBQueueName_Uat = cmsKenticoConfiguration.DynamicsCustomersAzSBQueueName_Uat ?? "??";
            KenticoCustomersAzSBConn_Uat = cmsKenticoConfiguration.KenticoCustomersAzSBConn_Uat ?? "??";
            KenticoCustomersAzSBQueueName_Uat = cmsKenticoConfiguration.KenticoCustomersAzSBQueueName_Uat ?? "??";
        }
    }
    internal class AzureServiceBusProdSetting
    {
        public string TE3EAssignmentAzSBConn_Prod;
        public string TE3EAssignmentAzSBQueueName_Prod;
        public string KenticoAssignmentAzSBConn_Prod;
        public string KenticoAssignmentAzSBQueueName_Prod;
        public string DynamicsCustomersAzSBConn_Prod;
        public string DynamicsCustomersAzSBQueueName_Prod;
        public string KenticoCustomersAzSBConn_Prod;
        public string KenticoCustomersAzSBQueueName_Prod;
        internal AzureServiceBusProdSetting(NameValueCollection appSettings, CMSKenticoConfiguration cmsKenticoConfiguration)
        {
            TE3EAssignmentAzSBConn_Prod = cmsKenticoConfiguration.TE3EAssignmentAzSBConn_Prod ?? "??";
            TE3EAssignmentAzSBQueueName_Prod = cmsKenticoConfiguration.TE3EAssignmentAzSBQueueName_Prod ?? "??";
            KenticoAssignmentAzSBConn_Prod = cmsKenticoConfiguration.KenticoAssignmentAzSBConn_Prod ?? "??";
            KenticoAssignmentAzSBQueueName_Prod = cmsKenticoConfiguration.KenticoAssignmentAzSBQueueName_Prod ?? "??";
            DynamicsCustomersAzSBConn_Prod = cmsKenticoConfiguration.DynamicsCustomersAzSBConn_Prod ?? "??";
            DynamicsCustomersAzSBQueueName_Prod = cmsKenticoConfiguration.DynamicsCustomersAzSBQueueName_Prod ?? "??";
            KenticoCustomersAzSBConn_Prod = cmsKenticoConfiguration.KenticoCustomersAzSBConn_Prod ?? "??";
            KenticoCustomersAzSBQueueName_Prod = cmsKenticoConfiguration.KenticoCustomersAzSBQueueName_Prod ?? "??";
        }
    }
}
