using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TE3EEntityFramework.Setting;

namespace TE3EEntityFramework.Data.TeamsDMS
{
    class TeamsDMSUrlVerbs
    {
        public static string GetAzureFuncUrl(AzureFuncURL azureFunc, TeamsDMSAppSetting teamsDMSAppSetting)
        {
            string urlPart = "";

            switch(azureFunc)
            {
                case AzureFuncURL.CASEOPENED:
                    urlPart = $@"/api/caseOpened?code={teamsDMSAppSetting.AzureDMSSetting.AzureFuncCaseOpened}";
                    break;
                case AzureFuncURL.CASECLOSED:
                    urlPart = $@"/api/caseClosed?code={teamsDMSAppSetting.AzureDMSSetting.AzureFuncCaseClosed}";
                    break;
                case AzureFuncURL.CASEASSIGNMENT:
                    urlPart = $@"/api/caseAssignment?code={teamsDMSAppSetting.AzureDMSSetting.AzureFuncCaseAssignment}";
                    break;
                case AzureFuncURL.TEAMACTION:
                    urlPart = $@"/api/teamAction?code={teamsDMSAppSetting.AzureDMSSetting.AzureFuncTeamAction}";
                    break;
                default:
                    break;

            }
       
            return urlPart;
        }
    }
    
    public enum AzureFuncURL
    {
        CASEOPENED,
        CASECLOSED,
        CASEASSIGNMENT,
        TEAMACTION
    }
}
