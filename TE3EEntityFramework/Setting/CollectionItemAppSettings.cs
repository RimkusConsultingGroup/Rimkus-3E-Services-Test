using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TE3EEntityFramework.Setting
{
    public class CollectionItemAppSettings
    {
        public string Invoice_Statement_Base_Folder { get; private set; }

        public string EmailToTest { get; private set; }

        public string EmailCC { get; private set; }

        public string EmailNotificationFrom { get; private set; }

        public string EmailNotificationTo { get; private set; }

        //public e3eServerEnv E3EServer { get; private set; }

        public string E3EServerDomain { get; private set; }

        public string E3EServerUser { get; private set; }

        public string E3EServerPassword { get; private set; }

        public bool IsSendEmail { get; private set; }

        public bool IsAddCollectionStep { get; private set; }

        public int AR_Aging_Days { get; private set; }

        public bool IsDebug { get; private set; }

        public int SqlCommandTimeout { get; private set; }

        public string Te3eServerDisplayName { get; private set; }

        public bool SkipInvoiceAttachment { get; private set; }
        public bool IsProdUpgradedVersion { get; set; }

        public CollectionItemAppSettings(NameValueCollection appSettings)
        {
            Invoice_Statement_Base_Folder = appSettings["inv_stmt_base_folder"] ?? "Not Found";
            EmailToTest = appSettings["email_to_test"] ?? "";
            EmailCC = appSettings["email_cc"] ?? "";
            EmailNotificationFrom = appSettings["email_notification_from"] ?? "accountsreceivable@rimkus.com";
            EmailNotificationTo = appSettings["email_notification_to"] ?? "";
            IsDebug = Convert.ToBoolean(appSettings["is_debug"] ?? "false");
            IsSendEmail = Convert.ToBoolean(appSettings["send_email"] ?? "true");
            IsAddCollectionStep = Convert.ToBoolean(appSettings["add_collection_step"] ?? "true");
            AR_Aging_Days = Convert.ToInt32(appSettings["ar_aging_days"] ?? "0");
            E3EServerDomain = appSettings["3e_server_domain"] ?? "Not Found";
            E3EServerUser = appSettings["3e_server_user"] ?? "";
            E3EServerPassword = appSettings["3e_server_password"] ?? "";
            SqlCommandTimeout = Convert.ToInt32(appSettings["sqlCommandTimeout"] ?? "180");
            Te3eServerDisplayName = appSettings["3e_server"] ?? "uat";
            SkipInvoiceAttachment = Convert.ToBoolean(appSettings["skip_invoice_attachment"] ?? "false");
            IsProdUpgradedVersion = Convert.ToBoolean(appSettings["is_prod_upgraded_version"] ?? "true");
            //if(!string.IsNullOrEmpty(encodedPassword))
            //    E3EServerPassword = DecodePassword(encodedPassword);

            //if (Te3eServerDisplayName == "uat")
            //    E3EServer = e3eServerEnv.UAT;
            //else if (Te3eServerDisplayName == "dev")
            //    E3EServer = e3eServerEnv.DEV;
            //else if (Te3eServerDisplayName == "prod")
            //    E3EServer = e3eServerEnv.PROD;

            //if (!IsDebug)
            //{
            //    E3EServer = e3eServerEnv.PROD;
            //    E3EServerDomain = "Rimkus";
            //    E3EServerUser = "RCGAPI_service_svc";
            //    E3EServerPassword = DecodePassword(E3EServerPassword);
            //}
        }

        private string DecodePassword(string base64Encoded)
        {
            byte[] data = System.Convert.FromBase64String(base64Encoded);
            string base64Decoded = System.Text.ASCIIEncoding.ASCII.GetString(data);

            return base64Decoded;
        }
    }
}
