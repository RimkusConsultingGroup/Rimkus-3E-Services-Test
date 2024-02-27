using Microsoft.VisualBasic.FileIO;
using System;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Linq;
using System.Security.Cryptography;
using TE3EConnect.te3eObjects;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using TE3EEntityFramework.Data.KenticoCMS;
using TE3EEntityFramework.Setting;
using TE3EEntityFramework.Datasource;
using TE3EEntityFramework.Datasource.RCGKENTCMS.DataModel;
using TE3EEntityFramework.Data.KenticoCMS.RCGKENTCMS;
using TE3EEntityFramework.Data.KenticoCMS._3EProcessItem;
using TE3EEntityFramework.Datasource.UKGTE3E.DataModel;
using TE3EEntityFramework.Data.UKGTE3E;

namespace TE3EConnect.extension
{
    public class e3eExtension
    {
        public static CodeLookup GetCode(e3eArchetype e3EArchetype, string desc)
        {
            CodeLookup codeLookup = new CodeLookup { Code = "" };

            if (string.IsNullOrEmpty(desc))
                return codeLookup;

            try
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                StreamReader sr = null;

                switch (e3EArchetype)
                {
                    case e3eArchetype.Section:
                        sr = new StreamReader(assembly.GetManifestResourceStream("TE3EConnect.te3eCodeLookup.Common.section.csv"));
                        break;
                    case e3eArchetype.PTAGroup:
                        sr = new StreamReader(assembly.GetManifestResourceStream("TE3EConnect.te3eCodeLookup.Common.ptagroup.csv"));
                        break;
                    case e3eArchetype.PraticeGroup:
                        sr = new StreamReader(assembly.GetManifestResourceStream("TE3EConnect.te3eCodeLookup.Common.practicegroup.csv"));
                        break;
                    case e3eArchetype.Office:
                        sr = new StreamReader(assembly.GetManifestResourceStream("TE3EConnect.te3eCodeLookup.Common.office.csv"));
                        break;
                    case e3eArchetype.Department:
                        sr = new StreamReader(assembly.GetManifestResourceStream("TE3EConnect.te3eCodeLookup.Common.department.csv"));
                        break;
                    case e3eArchetype.Arrangement:
                        sr = new StreamReader(assembly.GetManifestResourceStream("TE3EConnect.te3eCodeLookup.Common.arrangement.csv"));
                        break;
                    case e3eArchetype.BillingFrequency:
                        sr = new StreamReader(assembly.GetManifestResourceStream("TE3EConnect.te3eCodeLookup.Common.billingfrequency.csv"));
                        break;
                    case e3eArchetype.EngStatus:
                        sr = new StreamReader(assembly.GetManifestResourceStream("TE3EConnect.te3eCodeLookup.Common.engstatus_ccc.csv"));
                        break;
                    case e3eArchetype.EngType:
                        sr = new StreamReader(assembly.GetManifestResourceStream("TE3EConnect.te3eCodeLookup.Common.engtype_ccc.csv"));
                        break;
                    case e3eArchetype.Entity:
                        sr = new StreamReader(assembly.GetManifestResourceStream("TE3EConnect.te3eCodeLookup.Common.entity.csv"));
                        break;
                    case e3eArchetype.MattAttribute:
                        sr = new StreamReader(assembly.GetManifestResourceStream("TE3EConnect.te3eCodeLookup.Common.mattattribute.csv"));
                        break;
                    case e3eArchetype.MattCategory:
                        sr = new StreamReader(assembly.GetManifestResourceStream("TE3EConnect.te3eCodeLookup.Common.mattcategory.csv"));
                        break;
                    case e3eArchetype.MattStatus:
                        sr = new StreamReader(assembly.GetManifestResourceStream("TE3EConnect.te3eCodeLookup.Common.mattstatus.csv"));
                        break;
                    case e3eArchetype.MattType:
                        sr = new StreamReader(assembly.GetManifestResourceStream("TE3EConnect.te3eCodeLookup.Common.matttype.csv"));
                        break;
                    case e3eArchetype.Month_CCC:
                        sr = new StreamReader(assembly.GetManifestResourceStream("TE3EConnect.te3eCodeLookup.Common.month_ccc.csv"));
                        break;
                    case e3eArchetype.State:
                        sr = new StreamReader(assembly.GetManifestResourceStream("TE3EConnect.te3eCodeLookup.Common.state.csv"));
                        break;
                    case e3eArchetype.CPAType_CCC:
                        sr = new StreamReader(assembly.GetManifestResourceStream("TE3EConnect.te3eCodeLookup.Common.cpatype_ccc.csv"));
                        break;
                    case e3eArchetype.CostType:
                        sr = new StreamReader(assembly.GetManifestResourceStream("TE3EConnect.te3eCodeLookup.Common.costtype.csv"));
                        break;
                    default:
                        break;
                };

                if (sr != null)
                {
                    string[] contents = sr.ReadToEnd().Replace("\r", "").Split('\n');
                    contents = contents.Skip(1).ToArray();
                    var line = contents.Where(x => LineParser(x)[3].Trim().ToLower().Contains(desc.ToLower())).Select(x => x);

                    if (line != null)
                    {
                        string[] parsedLine = LineParser(line.First());
                        codeLookup = new CodeLookup { Code = parsedLine[0], Default = parsedLine[1], Active = parsedLine[2], Description = parsedLine[3] };
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(string.Format("GetCode error - {0}", ex.Message));
            }

            return codeLookup;
        }

        public static string[] LineParser(string line)
        {
            TextFieldParser parser = new TextFieldParser(new StringReader(line));

            // You can also read from a file
            // TextFieldParser parser = new TextFieldParser("mycsvfile.csv");

            parser.HasFieldsEnclosedInQuotes = true;
            parser.SetDelimiters(",");

            string[] fields = null;

            while (!parser.EndOfData)
                fields = parser.ReadFields();

            parser.Close();

            return fields;
        }

        public static bool IsAddressExisted(List<EntityAddress> entityAddresses, 
            string srcSiteType,
            string srcStreet, 
            string srcCity, 
            string srcState, 
            string srcZipCode, 
            string srcCountry)
        {
            var addrExisted = entityAddresses.Any(x =>
                                                  x.Street?.ToLower() == srcStreet?.ToLower()
                                               && x.City?.ToLower() == srcCity?.ToLower()
                                               && x.State?.ToLower() == srcState?.ToLower()
                                               && x.ZipCode?.ToLower() == srcZipCode?.ToLower()
                                               && x.Country?.ToLower() == srcCountry?.ToLower()
                                               && x.SiteTypeCode == srcSiteType);

            return addrExisted;
        }

        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute),
                false);

            if (attributes != null &&
                attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }

        public static string GenerateAPPKey()
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

        public static string FixXMLString(string strValue)
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

        //send notification event
        public static void SendEmailNotification(string fromAddr,
                                                 string toAddr,
                                                 string cc,
                                                 string subject,
                                                 string body,
                                                 List<string> attachments = null)
        {
            var smtpClient = new SmtpClient();
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.EnableSsl = false;
            smtpClient.Host = "mail.rimkus.com";
            smtpClient.Port = 25;

            var mailMessage = new MailMessage
            {
                From = new MailAddress(fromAddr),
                Subject = subject,
                Body = body,
                IsBodyHtml = false,
            };

            List<string> emailTos = toAddr.Split(';').ToList();
            emailTos.ForEach(x => mailMessage.To.Add(x.Trim()));

            if (!string.IsNullOrEmpty(cc.Trim()))
            {
                List<string> emaiCC = cc.Split(';').ToList();
                emaiCC.ForEach(x => mailMessage.CC.Add(x.Trim()));
            }

            if (attachments != null)
                attachments.ForEach(x => mailMessage.Attachments.Add(new Attachment(x)));

            smtpClient.Send(mailMessage);
        }

        public static string GetAssignmentNoficationTemplate(
            In3eAssignment in3EAssignment,
            AzureServiceBusAppSetting azSbAppSetting,
            TE3EProcessSrvType tE3EProcessSrv,
            string processResult,
            AzQueueType azQueueType,
            bool isSucceeded,
            bool isExported)
        {
            string processDateType = isExported ? "Exported" : "Imported";
            string succeededType = isSucceeded ? "Successfully" : "Failed to";
            string azQueueName = "";
            string azQueueConn = "";

            if (azQueueType == AzQueueType.TE3EAssignment)
            {
                azQueueName = azSbAppSetting.AzSbSetting.TE3EAssignmentAzSBQueueName;
                azQueueConn = azSbAppSetting.AzSbSetting.TE3EAssignmentAzSBConn;
            }
            else if (azQueueType == AzQueueType.KenticoAssignment)
            {
                azQueueName = azSbAppSetting.AzSbSetting.KenticoAssignmentAzSBQueueName;
                azQueueConn = azSbAppSetting.AzSbSetting.KenticoAssignmentAzSBConn;
            }
            else if (azQueueType == AzQueueType.DynamicsCustomer)
            {
                azQueueName = azSbAppSetting.AzSbSetting.DynamicsCustomersAzSBQueueName;
                azQueueConn = azSbAppSetting.AzSbSetting.DynamicsCustomersAzSBConn;
            }
            else if (azQueueType == AzQueueType.KenticoCustomer)
            {
                azQueueName = azSbAppSetting.AzSbSetting.KenticoCustomersAzSBQueueName;
                azQueueConn = azSbAppSetting.AzSbSetting.KenticoCustomersAzSBConn;
            }

            string mattName = string.IsNullOrEmpty(in3EAssignment.assignment.MatterName)
                              ? $"{in3EAssignment.orderingClient.OrderClientCompanyName} - {in3EAssignment.assignment.KenticoID}"
                              : in3EAssignment.assignment.MatterName;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"============================================================================");
            sb.AppendLine($"{succeededType} process {GetEnumDescription(tE3EProcessSrv)}");
            sb.AppendLine($"KenticoID: {in3EAssignment.assignment.KenticoID}");
            sb.AppendLine($"Matter Name: {mattName}");
            //sb.AppendLine("");
            sb.AppendLine($"Azure Queue Name: {azQueueName}");
            sb.AppendLine($"Azure Queue Connection: {azQueueConn}");
            sb.AppendLine($"{processDateType} Date: {DateTime.Now.ToString()}");
            sb.AppendLine($"----------------------------------------------------------------------------");
            sb.AppendLine($"Response: {processResult}");
            sb.AppendLine($"============================================================================");
            sb.AppendLine("");

            return sb.ToString();
        }

        public static string GetCMSAssignmentNoficationTemplate(
            CMSJob in3EAssignment,
            CMSAzureSBAppSetting azSbAppSetting,
            TE3EProcessSrvType tE3EProcessSrv,
            string processResult,
            AzQueueType azQueueType,
            bool isSucceeded,
            bool isExported)
        {
            string processDateType = isExported ? "Exported" : "Imported";
            string succeededType = isSucceeded ? "Successfully" : "Failed to";
            string azQueueName = "";
            string azQueueConn = "";

            if (azQueueType == AzQueueType.TE3EAssignment)
            {
                azQueueName = azSbAppSetting.AzSbSetting.TE3EAssignmentAzSBQueueName;
                azQueueConn = azSbAppSetting.AzSbSetting.TE3EAssignmentAzSBConn;
            }
            else if (azQueueType == AzQueueType.KenticoAssignment)
            {
                azQueueName = azSbAppSetting.AzSbSetting.KenticoAssignmentAzSBQueueName;
                azQueueConn = azSbAppSetting.AzSbSetting.KenticoAssignmentAzSBConn;
            }
            else if (azQueueType == AzQueueType.DynamicsCustomer)
            {
                azQueueName = azSbAppSetting.AzSbSetting.DynamicsCustomersAzSBQueueName;
                azQueueConn = azSbAppSetting.AzSbSetting.DynamicsCustomersAzSBConn;
            }
            else if (azQueueType == AzQueueType.KenticoCustomer)
            {
                azQueueName = azSbAppSetting.AzSbSetting.KenticoCustomersAzSBQueueName;
                azQueueConn = azSbAppSetting.AzSbSetting.KenticoCustomersAzSBConn;
            }

            string mattName = string.IsNullOrEmpty(in3EAssignment.assignment.MatterName)
                              ? $"{in3EAssignment.orderingClient.CompanyName} - {in3EAssignment.assignment.KenticoID}"
                              : in3EAssignment.assignment.MatterName;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"============================================================================");
            sb.AppendLine($"{succeededType} process {GetEnumDescription(tE3EProcessSrv)}");
            sb.AppendLine($"KenticoID: {in3EAssignment.assignment.KenticoID}");
            sb.AppendLine($"Client Name: {in3EAssignment.orderingClient.CompanyName}");

            if (!string.IsNullOrEmpty(in3EAssignment.orderingClient.ClientNumber))
                sb.AppendLine($"Client Number: {in3EAssignment.orderingClient.ClientNumber}");

            sb.AppendLine($"Matter Name: {mattName.Trim()}");

            if (!string.IsNullOrEmpty(in3EAssignment.assignment.MatterNumber))
                sb.AppendLine($"Matter Number: {in3EAssignment.assignment.MatterNumber}");

            sb.AppendLine("-----------------------------------------------------------------------------");
            sb.AppendLine($"Azure Queue Name: {azQueueName}");
            sb.AppendLine($"Azure Queue Connection: {azQueueConn}");
            sb.AppendLine($"On-Prem Queue Env: {azSbAppSetting.OnPremQueueDBEnv}");
            sb.AppendLine($"{processDateType} Date: {DateTime.Now.ToString()}");
            sb.AppendLine($"----------------------------------------------------------------------------");
            sb.AppendLine($"Response: {processResult}");
            sb.AppendLine($"============================================================================");
            sb.AppendLine("");

            return sb.ToString();
        }

        public static string GetCMSCftWorkflowHistoryTemplate(List<CMSCftWorkflowHistory> cftWorkflowHistories)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"============================================================================");
            sb.AppendLine($"Conflicts Workflow History");
            cftWorkflowHistories.ForEach(x =>
            {
                sb.AppendLine($"============================================================================");
                sb.AppendLine($"CurrentOwner: {x.CurrentOwner}");
                sb.AppendLine($"CurrentStepID: {x.CurrentStepID}");
                sb.AppendLine($"StepType: {x.StepType}");
                sb.AppendLine($"CftSearchReason: {x.CftSearchReason}");
                sb.AppendLine($"ClientIndex: {x.ClientIndex}");
                sb.AppendLine($"ClientNumber: {x.ClientNumber}");
                sb.AppendLine($"ClientName: {x.ClientName}");
                sb.AppendLine($"MatterIndex: {x.MatterIndex}");
                sb.AppendLine($"MatterNumber: {x.MatterNumber}");
                sb.AppendLine($"MatterName: {x.MatterName}");
                sb.AppendLine($"RequestDateTime: {x.RequestDateTime}");
                sb.AppendLine($"EndDateTime: {x.EndDateTime}");
                sb.AppendLine($"JobNumber: {x.JobNumber}");
                sb.AppendLine($"Description: {x.Description}");
                sb.AppendLine($"CftNBRStatus: {x.CftNBRStatus}");
                sb.AppendLine($"NumResults: {x.NumResults}");
                sb.AppendLine($"DateRun: {x.DateRun}");
                sb.AppendLine($"Ranby: {x.Ranby}");
                sb.AppendLine($"============================================================================");

            });

            return sb.ToString();
        }

        public static string GetCustomerNoficationTemplate(
            InCustomerProfileCM inCustomer,
            AzureServiceBusAppSetting azSbAppSetting,
            TE3EProcessSrvType tE3EProcessSrv,
            string processResult,
            AzQueueType azQueueType,
            bool isSucceeded,
            bool isExported)
        {
            string processDateType = isExported ? "Exported" : "Imported";
            string succeededType = isSucceeded ? "Successfully" : "Failed to";
            string azQueueName = "";
            string azQueueConn = "";

            if (azQueueType == AzQueueType.TE3EAssignment)
            {
                azQueueName = azSbAppSetting.AzSbSetting.TE3EAssignmentAzSBQueueName;
                azQueueConn = azSbAppSetting.AzSbSetting.TE3EAssignmentAzSBConn;
            }
            else if (azQueueType == AzQueueType.KenticoAssignment)
            {
                azQueueName = azSbAppSetting.AzSbSetting.KenticoAssignmentAzSBQueueName;
                azQueueConn = azSbAppSetting.AzSbSetting.KenticoAssignmentAzSBConn;
            }
            else if (azQueueType == AzQueueType.DynamicsCustomer)
            {
                azQueueName = azSbAppSetting.AzSbSetting.DynamicsCustomersAzSBQueueName;
                azQueueConn = azSbAppSetting.AzSbSetting.DynamicsCustomersAzSBConn;
            }
            else if (azQueueType == AzQueueType.KenticoCustomer)
            {
                azQueueName = azSbAppSetting.AzSbSetting.KenticoCustomersAzSBQueueName;
                azQueueConn = azSbAppSetting.AzSbSetting.KenticoCustomersAzSBConn;
            }

            string customerName = tE3EProcessSrv == TE3EProcessSrvType.EntityPerson
                                  ? $"{inCustomer.FirstName} {inCustomer.LastName}"
                                  : inCustomer.CompanyName; ;

            customerName = string.IsNullOrEmpty(customerName)
                           ? $"Kentico Client {inCustomer.KenticoID}"
                           : customerName;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"============================================================================");
            sb.AppendLine($"{succeededType} process {GetEnumDescription(tE3EProcessSrv)}");
            sb.AppendLine($"KenticoID: {inCustomer.KenticoID}");
            sb.AppendLine($"Customer Name: {customerName}");
            sb.AppendLine($"Azure Queue Name: {azQueueName}");
            sb.AppendLine($"Azure Queue Connection: {azQueueConn}");
            sb.AppendLine($"{processDateType} Date: {DateTime.Now.ToString()}");
            sb.AppendLine($"----------------------------------------------------------------------------");
            sb.AppendLine($"Response: {processResult}");
            sb.AppendLine($"============================================================================");
            sb.AppendLine("");

            return sb.ToString();
        }

        public static string GetCMSCustomerNoficationTemplate(
            CMSCustomerProfile inCustomer,
            CMSAzureSBAppSetting azSbAppSetting,
            TE3EProcessSrvType tE3EProcessSrv,
            string processResult,
            AzQueueType azQueueType,
            bool isSucceeded,
            bool isExported)
        {
            string processDateType = isExported ? "Exported" : "Imported";
            string succeededType = isSucceeded ? "Successfully" : "Failed to";
            string azQueueName = "";
            string azQueueConn = "";

            if (azQueueType == AzQueueType.TE3EAssignment)
            {
                azQueueName = azSbAppSetting.AzSbSetting.TE3EAssignmentAzSBQueueName;
                azQueueConn = azSbAppSetting.AzSbSetting.TE3EAssignmentAzSBConn;
            }
            else if (azQueueType == AzQueueType.KenticoAssignment)
            {
                azQueueName = azSbAppSetting.AzSbSetting.KenticoAssignmentAzSBQueueName;
                azQueueConn = azSbAppSetting.AzSbSetting.KenticoAssignmentAzSBConn;
            }
            else if (azQueueType == AzQueueType.DynamicsCustomer)
            {
                azQueueName = azSbAppSetting.AzSbSetting.DynamicsCustomersAzSBQueueName;
                azQueueConn = azSbAppSetting.AzSbSetting.DynamicsCustomersAzSBConn;
            }
            else if (azQueueType == AzQueueType.KenticoCustomer)
            {
                azQueueName = azSbAppSetting.AzSbSetting.KenticoCustomersAzSBQueueName;
                azQueueConn = azSbAppSetting.AzSbSetting.KenticoCustomersAzSBConn;
            }

            string customerName = tE3EProcessSrv == TE3EProcessSrvType.EntityPerson
                                  ? $"{inCustomer.FirstName} {inCustomer.LastName}"
                                  : inCustomer.CompanyName; ;

            customerName = string.IsNullOrEmpty(customerName)
                           ? $"Kentico Client {inCustomer.KenticoID}"
                           : customerName;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"============================================================================");
            sb.AppendLine($"{succeededType} process {GetEnumDescription(tE3EProcessSrv)}");
            sb.AppendLine($"KenticoID: {inCustomer.KenticoID}");
            sb.AppendLine($"Customer Name: {customerName}");
            sb.AppendLine("-----------------------------------------------------------------------------");
            sb.AppendLine($"Azure Queue Name: {azQueueName}");
            sb.AppendLine($"Azure Queue Connection: {azQueueConn}");
            sb.AppendLine($"{processDateType} Date: {DateTime.Now.ToString()}");
            sb.AppendLine($"----------------------------------------------------------------------------");
            sb.AppendLine($"Response: {processResult}");
            sb.AppendLine($"============================================================================");
            sb.AppendLine("");

            return sb.ToString();
        }

        public static string GetUKGTE3ETimekeeperNoficationTemplate(
            UKGTE3ETimekprInfo timekeeper,
            TE3EProcessSrvType tE3EProcessSrv,
            string processResult,
            bool isSucceeded,
            bool isExported)
        {
            string processDateType = isExported ? "Exported" : "Imported";
            string succeededType = isSucceeded ? "Successfully" : "Failed to";

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"============================================================================");
            sb.AppendLine($"{succeededType} process {GetEnumDescription(tE3EProcessSrv)}");

            if (timekeeper != null)
            {
                sb.AppendLine($"Timekeeper Name: {timekeeper.Display_Name}");
                sb.AppendLine($"Timekeeper Number: {timekeeper.Number}");
            }

            sb.AppendLine($"{processDateType} Date: {DateTime.Now.ToString()}");
            sb.AppendLine($"----------------------------------------------------------------------------");
            sb.AppendLine($"Response: {processResult}");
            sb.AppendLine($"============================================================================");
            sb.AppendLine("");

            return sb.ToString();
        }

        public static string GetNxUserNoficationTemplate(
            UKGTE3ETimekprInfo timekeeper,
            TE3EProcessSrvType tE3EProcessSrv,
            string processResult,
            bool isSucceeded,
            bool isExported)
        {
            string processDateType = isExported ? "Exported" : "Imported";
            string succeededType = isSucceeded ? "Successfully" : "Failed to";

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"============================================================================");
            sb.AppendLine($"{succeededType} process {GetEnumDescription(tE3EProcessSrv)}");

            if (timekeeper != null)
            {
                sb.AppendLine($"User: {timekeeper.Display_Name}");
                sb.AppendLine($"Timekeeper Number: {timekeeper.Number}");
            }

            sb.AppendLine($"{processDateType} Date: {DateTime.Now.ToString()}");
            sb.AppendLine($"----------------------------------------------------------------------------");
            sb.AppendLine($"Response: {processResult}");
            sb.AppendLine($"============================================================================");
            sb.AppendLine("");

            return sb.ToString();
        }

        public static string GetUKGTE3EPONoficationTemplate(
            UKG_TE_3E_PO po,
            TE3EProcessSrvType tE3EProcessSrv,
            string processResult,
            bool isSucceeded,
            bool isExported)
        {
            string processDateType = isExported ? "Exported" : "Imported";
            string succeededType = isSucceeded ? "Successfully" : "Failed to";

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"============================================================================");
            sb.AppendLine($"{succeededType} process {GetEnumDescription(tE3EProcessSrv)}");

            if (po != null)
            {
                sb.AppendLine($"Requested By: {po.NxUser}");
                sb.AppendLine($"Product Bundle: {po.BundleName}");
            }

            sb.AppendLine($"{processDateType} Date: {DateTime.Now.ToString()}");
            sb.AppendLine($"----------------------------------------------------------------------------");
            sb.AppendLine($"Response: {processResult}");
            sb.AppendLine($"============================================================================");
            sb.AppendLine("");

            return sb.ToString();
        }
    }

    public static class VoucherEx
    {
        public static string ToStringEx(this Voucher voucher)
        {
            string str = string.Format("{0} - {1}", voucher.InvNum.First().Value, voucher.Amount);

            return str;
        }

        public static string ToDesc(this Voucher voucher)
        {
            string str = string.Format("{0},{1},{2},{3}", voucher.InvNum.First().Value,
                voucher.TranDate, voucher.InvDate, voucher.Amount);

            return str;
        }
    }
}