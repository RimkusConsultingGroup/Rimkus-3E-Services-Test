using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TE3EEntityFramework.Datasource.RCGCLAIMS;

namespace TE3EEntityFramework.Setting
{
    public class LibertyMutualAppSetting
    {
        public bool IsDebug { get; private set; }
        public int SqlCommandTimeout { get; private set; }
        public int MaxNumOfAttempts { get; private set; }
        public string LibertyMutualAPIUrl { get; private set; }
        public string LibertyMutualAPIToken { get; private set; }
        public string LibertyMutualJournalUserId { get; private set; }
        public string LibertyMutualJournalUserIdType { get; private set; }
        public string EmailSendingAddress { get; private set; }
        public string EmailsTo { get; private set; }


        public LibertyMutualAppSetting(NameValueCollection appSettings)
        {
            IsDebug = Convert.ToBoolean(appSettings["is_debug"] ?? "false");
            SqlCommandTimeout = Convert.ToInt32(appSettings["sqlCommandTimeout"] ?? "180");

            if (IsDebug)
            {
                using (RCGCLAIMS_DEV01Entities db = new RCGCLAIMS_DEV01Entities())
                {
                    var appConfigs = db.AppConfigs.ToList();
                    LibertyMutualAPIUrl = getConfigValue(appConfigs, IsDebug, LibertyMutualAppSettingEnum.lm_api_url);
                    LibertyMutualAPIToken = getConfigValue(appConfigs, IsDebug, LibertyMutualAppSettingEnum.lm_api_token);
                    EmailSendingAddress = getConfigValue(appConfigs, IsDebug, LibertyMutualAppSettingEnum.lm_emailconfig_sendingaddress);
                    EmailsTo = getConfigValue(appConfigs, IsDebug, LibertyMutualAppSettingEnum.lm_emailconfig_reportingaddress);
                    LibertyMutualJournalUserId = getConfigValue(appConfigs, IsDebug, LibertyMutualAppSettingEnum.lm_journal_userid);
                    LibertyMutualJournalUserIdType = getConfigValue(appConfigs, IsDebug, LibertyMutualAppSettingEnum.lm_journal_useridtype);
                    MaxNumOfAttempts = Convert.ToInt32(getConfigValue(appConfigs, IsDebug, LibertyMutualAppSettingEnum.MaxNumOfAttempts));
                }
            }
            else
            {
                using (RCGCLAIMS_PROD01Entities db = new RCGCLAIMS_PROD01Entities())
                {
                    var appConfigs = db.AppConfigs.ToList();
                    LibertyMutualAPIUrl = getConfigValue(appConfigs, IsDebug, LibertyMutualAppSettingEnum.lm_api_url);
                    LibertyMutualAPIToken = getConfigValue(appConfigs, IsDebug, LibertyMutualAppSettingEnum.lm_api_token);
                    EmailSendingAddress = getConfigValue(appConfigs, IsDebug, LibertyMutualAppSettingEnum.lm_emailconfig_sendingaddress);
                    EmailsTo = getConfigValue(appConfigs, IsDebug, LibertyMutualAppSettingEnum.lm_emailconfig_reportingaddress);
                    LibertyMutualJournalUserId = getConfigValue(appConfigs, IsDebug, LibertyMutualAppSettingEnum.lm_journal_userid);
                    LibertyMutualJournalUserIdType = getConfigValue(appConfigs, IsDebug, LibertyMutualAppSettingEnum.lm_journal_useridtype);
                    MaxNumOfAttempts = Convert.ToInt32(getConfigValue(appConfigs, IsDebug, LibertyMutualAppSettingEnum.MaxNumOfAttempts));
                }
            }
        }

        private string getConfigValue(List<AppConfig> appConfigs, bool IsDebug, LibertyMutualAppSettingEnum appSettingEnum)
        {
            try
            {
                return IsDebug ? appConfigs.FirstOrDefault(x => x.KeyName.Equals(appSettingEnum.ToString())).DevValue : appConfigs.FirstOrDefault(x => x.KeyName.Equals(appSettingEnum.ToString())).ProdValue;
            }
            catch (Exception)
            {
                throw new Exception("Configurations miss-matched with database.");
            }
        }

        private enum LibertyMutualAppSettingEnum
        {
            lm_api_url,
            lm_api_token,
            lm_journal_userid,
            lm_journal_useridtype,
            lm_emailconfig_sendingaddress,
            lm_emailconfig_reportingaddress,
            MaxNumOfAttempts
        }
    }
}
