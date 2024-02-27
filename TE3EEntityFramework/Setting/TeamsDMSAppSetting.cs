using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TE3EEntityFramework.Client;
using TE3EEntityFramework.Datasource;

namespace TE3EEntityFramework.Setting
{
    public class TeamsDMSAppSetting
    {
        public bool IsDebug { get; private set; }
        public int SqlCommandTimeout { get; private set; }
        public int NumOfDays { get; private set; }
        public string OrganizationId { get; private set; }
        public string OfficeId { get; private set; }
        public AzureDMSSetting AzureDMSSetting { get; private set; }
        public string Enotify_From { get; private set; }
        public string Enotify_To { get; private set; }
        public string Enotify_Cc { get; private set; }
        public string Test_Owners { get; private set; }
        public string Test_Members { get; private set; }
        public string SpecificMatters { get; private set; }
        public TeamsDMSAppSetting(NameValueCollection appSettings, Te3eDbClient te3EClient)
        {
            IsDebug = Convert.ToBoolean(appSettings["is_debug"] ?? "false");
            SqlCommandTimeout = Convert.ToInt32(appSettings["sqlCommandTimeout"] ?? "180");
            SpecificMatters = appSettings["specific_matters"] ?? "";
            TeamsDMSConfiguration teamsDMSConfiguration = te3EClient.GetTeamsDMSConfiguration(SqlCommandTimeout, IsDebug);

            NumOfDays = teamsDMSConfiguration.NumOfDays ?? 1;
            OrganizationId = teamsDMSConfiguration.TrackerSafe_OrgId?.ToString() ?? "3";
            OfficeId = teamsDMSConfiguration.TrackerSafe_OfficeId?.ToString() ?? "5";
            Enotify_From = teamsDMSConfiguration.Enotify_From ?? "";
            Enotify_To = teamsDMSConfiguration.Enotify_To ?? "";
            Enotify_Cc = teamsDMSConfiguration.Enotify_Cc ?? "";
            Test_Owners = teamsDMSConfiguration.Test_Owners ?? "";
            Test_Members = teamsDMSConfiguration.Test_Members ?? "";
            AzureDMSSetting = new AzureDMSSetting(appSettings, IsDebug, teamsDMSConfiguration);
        }
    }

    public class AzureDMSSetting
    {
        public string AzureFuncBaseUrl;
        public string AzureFuncCaseOpened;
        public string AzureFuncCaseAssignment;
        public string AzureFuncCaseClosed;
        public string AzureFuncTeamAction;

        public AzureDMSSetting(NameValueCollection appSettings, bool isDebug, TeamsDMSConfiguration teamsDMSConfiguration)
        {
            if (isDebug)
            {
                AzureDMSDevSetting azureDMSDevSetting = new AzureDMSDevSetting(appSettings, teamsDMSConfiguration);
                AzureFuncBaseUrl = azureDMSDevSetting.AzureFuncBaseUrl;
                AzureFuncCaseOpened = azureDMSDevSetting.AzureFuncCaseOpened;
                AzureFuncCaseAssignment = azureDMSDevSetting.AzureFuncCaseAssignment;
                AzureFuncCaseClosed = azureDMSDevSetting.AzureFuncCaseClosed;
                AzureFuncTeamAction = azureDMSDevSetting.AzureFuncTeamAction;
            }
            else
            {
                AzureDMSProdSetting azureDMSProdSetting = new AzureDMSProdSetting(appSettings, teamsDMSConfiguration);
                AzureFuncBaseUrl = azureDMSProdSetting.AzureFuncBaseUrl;
                AzureFuncCaseOpened = azureDMSProdSetting.AzureFuncCaseOpened;
                AzureFuncCaseAssignment = azureDMSProdSetting.AzureFuncCaseAssignment;
                AzureFuncCaseClosed = azureDMSProdSetting.AzureFuncCaseClosed;
                AzureFuncTeamAction = azureDMSProdSetting.AzureFuncTeamAction;
            }
        }
    }

    internal class AzureDMSDevSetting
    {
        public string AzureFuncBaseUrl;
        public string AzureFuncCaseOpened;
        public string AzureFuncCaseAssignment;
        public string AzureFuncCaseClosed;
        public string AzureFuncTeamAction;

        internal AzureDMSDevSetting(NameValueCollection appSettings, TeamsDMSConfiguration teamsDMSConfiguration)
        {
            AzureFuncBaseUrl = teamsDMSConfiguration.AzureFunc_BaseUrl_Dev ?? "??";
            AzureFuncCaseOpened = teamsDMSConfiguration.AzureFunc_CaseOpened_Dev ?? "??";
            AzureFuncCaseAssignment = teamsDMSConfiguration.AzureFunc_CaseAssignment_Dev ?? "??";
            AzureFuncCaseClosed = teamsDMSConfiguration.AzureFunc_CaseClosed_Dev ?? "??";
            AzureFuncTeamAction = teamsDMSConfiguration.AzureFunc_TeamAction_Dev ?? "??";
        }
    }

    internal class AzureDMSProdSetting
    {
        public string AzureFuncBaseUrl;
        public string AzureFuncCaseOpened;
        public string AzureFuncCaseAssignment;
        public string AzureFuncCaseClosed;
        public string AzureFuncTeamAction;

        internal AzureDMSProdSetting(NameValueCollection appSettings, TeamsDMSConfiguration teamsDMSConfiguration)
        {
            AzureFuncBaseUrl = teamsDMSConfiguration.AzureFunc_BaseUrl_Prod ?? "??";
            AzureFuncCaseOpened = teamsDMSConfiguration.AzureFunc_CaseOpened_Prod ?? "??";
            AzureFuncCaseAssignment = teamsDMSConfiguration.AzureFunc_CaseAssignment_Prod ?? "??";
            AzureFuncCaseClosed = teamsDMSConfiguration.AzureFunc_CaseClosed_Prod ?? "??";
            AzureFuncTeamAction = teamsDMSConfiguration.AzureFunc_TeamAction_Prod ?? "??";
        }
    }
}