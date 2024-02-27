using System;
using System.Collections.Specialized;

namespace TE3EEntityFramework.Setting
{
    public class TrackerSafeAppSetting
    {
        public bool IsDebug { get; private set; }
        public bool IsSendingEmailsToClients { get; private set; }

        public int SqlCommandTimeout { get; private set; }

        public string OrganizationId { get; set; }

        public string OfficeId { get; set; }


        public string UpdateType { get; private set; }

        public string SpecificCases { get; private set; }

        public string TrackerApiBaseUrl { get; private set; }

        public string TrackerApiToken { get; private set; }

        #region Decision Letter Email Sending Job  Settings

        public string DecisionLetterBaseUrl { get; private set; }
        public string TrackerAppHeaderToken { get; private set; }
        public bool ForceQuarterlyjob { get; set; }
        public int NumOfRetriesForEmail { get; set; }

        #endregion

        public string EmailsToMonitor { get; private set; }
        public string EmailSendingAddress { get; private set; }
        public string MediaLocation { get; private set; }

        public TrackerSafeAppSetting(NameValueCollection appSettings)
        {
            IsDebug = Convert.ToBoolean(appSettings["is_debug"] ?? "false");
            IsSendingEmailsToClients = Convert.ToBoolean(appSettings["IsSendingEmailsToClients"] ?? "false");
            SqlCommandTimeout = Convert.ToInt32(appSettings["sqlCommandTimeout"] ?? "180");
            OrganizationId = appSettings["orgid"] ?? "3";
            OfficeId = appSettings["officeid"] ?? "5";
            UpdateType = appSettings["updatetype"] ?? "";
            SpecificCases = appSettings["specificcases"] ?? "";
            var tsDevApiUrl = appSettings["tsdevapiurl"] ?? "https://trackersafeapi.rimkusdev.com";
            var tProdApiUrl = appSettings["tsprodapiurl"] ?? "https://trackersafeapi.rimkus.com";
            TrackerApiBaseUrl = IsDebug ? tsDevApiUrl : tProdApiUrl;
            EmailsToMonitor = appSettings["dl_EmailsToMonitor"] ?? string.Empty;
            EmailSendingAddress = appSettings["dl_EmailSendingAddress"];
            MediaLocation = IsDebug ? appSettings["medialoc_dev"] : appSettings["medialoc_prod"];
            #region Decision Letter Email Sending Job  Settings
            DecisionLetterBaseUrl = (IsDebug ? appSettings["dl_dev_base_url"] : appSettings["dl_prod_base_url"]) ?? "http://rcgapp01/tsapi";
            TrackerAppHeaderToken = IsDebug ? appSettings["dl_dev_app_token"] : appSettings["dl_prod_app_token"];
            ForceQuarterlyjob = Convert.ToBoolean(appSettings["dl_ForceQuarterlyJob"] ?? "false");
            NumOfRetriesForEmail = Convert.ToInt32(appSettings["dl_NumOfRetriesForEmail"] ?? "3");
            #endregion
        }
    }
}
