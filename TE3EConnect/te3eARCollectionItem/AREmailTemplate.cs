using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using TE3EEntityFramework.Client;
using TE3EEntityFramework.Datasource;

namespace TE3EConnect.te3eARCollectionItem
{
    public class AREmailTemplate
    {
        //private Dictionary<string, Tuple<string, string>> SubjectTemplates = new Dictionary<string, Tuple<string, string>>
        //{
        //    //THIS IS THE SUBJECT LINE FORMAT FOR ALL REGULAR/NON SPECIAL CLIENTS
        //    {"0", new Tuple<string, string>("Claim No.: @claimNo, Insured: @insuredName, Rimkus Matter No.: @mattNo", "") },

        //    //american integrity ins group - Subject line:  CHOxxxxx (CHO followed by Claim Number, no space between CHO and Claim Number)
        //    {"38380", new Tuple<string, string>("CHO@claimNo", "")}, 

        //    //canal insurance - All email correspondence must have the Canal File Number on the subject line and body of text.  
        //    //Format of text should be File No._______. All emails go to claimsinfo@canal-ins.com
        //    {"8596", new Tuple<string, string>("Claim No: @claimNo", "claimsinfo@canal-ins.com")},  

        //    //capital preferred - Send invoices to iareports@capitol-perferred.com.  Reference Claim No. and Insured’s last name in subject line
        //    {"25142", new Tuple<string, string>("Claim No.: @claimNo, Insured: @insuredName", "iareports@capitol-perferred.com")},

        //    //endurance, us operations - Send invoices to eclaims@enhinsurance.com.  Put only insured name & Claim No. in email subject line
        //    {"47697", new Tuple<string, string>("Claim No.: @claimNo, Insured: @insuredName", "eclaims@enhinsurance.com")}, 

        //    //mount beacon - Send invoice to mailroom@NARisk.com.  Include Claim No. and Insured in subject line
        //    {"12508", new Tuple<string, string>("Claim No.: @claimNo, Insured: @insuredName", "mailroom@NARisk.com")}, 

        //    //north american risk -  invoice to mailroom@NARisk.com.  Include Claim No. and Insured in subject line
        //    {"9578", new Tuple<string, string>("Claim No.: @claimNo, Insured: @insuredName", "mailroom@NARisk.com")}, 

        //    //safepoint - Send invoices to claims@safepointins.com. You may copy assigned examiner on email. Include Claim No, and Insured in subject line
        //    {"13285", new Tuple<string, string>("Claim No.: @claimNo, Insured: @insuredName", "claims@safepointins.com")}, 

        //    //southern fidelity - Send invoices to iareports@sfic.com. Reference Claim No. and Insured’s last name in subject line
        //    {"10132", new Tuple<string, string>("Claim No.: @claimNo, Insured: @insuredName", "iareports@sfic.com")}, 

        //    //state farm - Send invoices to statefarmclaims@statefarm.com. Claim No. only in subject line. (590235465136)
        //    {"35004", new Tuple<string, string>("Claim No.: @claimNo", "statefarmclaims@statefarm.com")},
        //};

        public string FromAddress { get; set; }

        public string ToAddress { get; set; }

        public string Body { get; set; }

        //public List<string> Attachments { get; set; }

        public string Subject { get; set; }

        public string Cc { get; set; }

        public string SmtpServer { get; set; }

        public string LocalEmailUsr { get; set; }

        public string LocalEmailPwd { get; set; }

        private int sqlCmdTimeout;

        private bool isDebugMode;

        private Te3eDbClient _te3EClient;

        public AREmailTemplate(Te3eDbClient te3EClient, int sqlCommandTimeout, bool isDebug)
        {
            sqlCmdTimeout = sqlCommandTimeout;
            isDebugMode = isDebug;
            _te3EClient = te3EClient;
        }

        public string ToStringEx2()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"FromAddress: {FromAddress}");
            sb.AppendLine($"ToAddress: {ToAddress}");
            //sb.AppendLine($"Body: {Body}");
            sb.AppendLine($"Subject: {Subject}");
            sb.AppendLine($"Cc: {Cc}");
            sb.AppendLine($"SmtpServer: {SmtpServer}");
            sb.AppendLine("DeliveryMethod: DeliveryMethod");
            sb.AppendLine("EnableSsl: true");
            sb.AppendLine("Port: 25");

            return sb.ToString();
        }

        public string BuildLetterHead(string emailBody, RetrieveLetterHeaderAddress_Result letterHeadAddress)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{letterHeadAddress.BillingCity}, {letterHeadAddress.BillingState} {letterHeadAddress.BillingZipCode}");
            
            var letterHeadAddr = AREmailBody.LetterHead;
            letterHeadAddr = letterHeadAddr.Replace("@currentDate", DateTime.Now.ToString("MMMM dd, yyyy"));
            letterHeadAddr = letterHeadAddr.Replace("@billingOrgName", letterHeadAddress.BillingOrgName);
            letterHeadAddr = letterHeadAddr.Replace("@billingStreet", letterHeadAddress.BillingStreet);
            letterHeadAddr = letterHeadAddr.Replace("@billingCityState", sb.ToString());

            emailBody = emailBody.Replace("@letterHead", letterHeadAddr);
            emailBody = emailBody.Replace("@spaceHeader", AREmailBody.SpaceHeader);
            emailBody = emailBody.Replace("@bankingInfo", AREmailBody.BankingInfo);

            return emailBody;
        }

        public string GetSpecialInstructionEmail(
            RetrieveCollectionItemsByPastDueDays_Result colItem,
            RetrieveLetterHeaderAddress_Result letterHeadAddress,
            string emailToTest)
        {
            string email = !string.IsNullOrEmpty(letterHeadAddress.InvoiceTo)? letterHeadAddress.InvoiceTo : "";

            //var customSubjectLines = TE3EDBManager.RetrieveCustomSubjectLine(sqlCmdTimeout, isDebugMode);

            //var customSubj = customSubjectLines.Where(x => x.ClientIndex == colItem.PayorRelatedClient.ToString());
            //if (customSubj.Count() > 0)
            //    email = !string.IsNullOrEmpty(customSubj.First().SpecificEmail)
            //            ? customSubj.First().SpecificEmail
            //            : letterHeadAddress.ClientEmail;
            //else email = letterHeadAddress.ClientEmail;

            if (!string.IsNullOrEmpty(emailToTest))
            {
                email = emailToTest;
            }
            else
            {
                List<string> emaiTos = email.Split(';').ToList();

                emaiTos.ForEach(x =>
                {
                    if (string.IsNullOrEmpty(x))
                        throw new InvalidDataException($"Invalid email - missing email address");
                    else if (!IsValidEmail(x.Trim()))
                        throw new InvalidDataException($"Invalid email - {x.Trim()}");

                });
            }

            return email;
        }

        public string GetSpecialInstructionEmailForReport(
            RetrieveCollectionItemsByPastDueDays_Result colItem,
            RetrieveLetterHeaderAddress_Result letterHeadAddress)
        {
            string email = !string.IsNullOrEmpty(letterHeadAddress.InvoiceTo) ? letterHeadAddress.InvoiceTo : "missing email address";

            //var customSubjectLines = TE3EDBManager.RetrieveCustomSubjectLine(sqlCmdTimeout, isDebugMode);
            ////if (SubjectTemplates.ContainsKey(colItem.PayorRelatedClient.ToString()))
            ////    email = !string.IsNullOrEmpty(SubjectTemplates[colItem.PayorRelatedClient.ToString()].Item2)
            ////            ? SubjectTemplates[colItem.PayorRelatedClient.ToString()].Item2
            ////            : letterHeadAddress.ClientEmail;
            //var customSubj = customSubjectLines.Where(x => x.ClientIndex == colItem.PayorRelatedClient.ToString());
            //if (customSubj.Count() > 0)
            //    email = !string.IsNullOrEmpty(customSubj.First().SpecificEmail)
            //            ? customSubj.First().SpecificEmail
            //            : letterHeadAddress.ClientEmail;
            //else email = letterHeadAddress.ClientEmail;

            return email;
        }

        public string BuildSubjectLine(
            RetrieveCollectionItemsByPastDueDays_Result colItem,
            RetrieveLetterHeaderAddress_Result letterHeadAddress)
        {
            var customSubjectLines = _te3EClient.RetrieveCustomSubjectLine(sqlCmdTimeout, isDebugMode);
            var customSubj = customSubjectLines.Where(x => x.ClientIndex == colItem.PayorRelatedClient.ToString());

            string subjectLine = "";

            //if (SubjectTemplates.ContainsKey(colItem.PayorRelatedClient.ToString()))
            if (customSubj.Count() > 0)
                subjectLine = customSubj.First().SpecialSubjectLine; // SubjectTemplates[colItem.PayorRelatedClient.ToString()].Item1;
            else subjectLine = "Claim No.: @claimNo, Insured: @insuredName, Rimkus Matter No.: @mattNo";

            subjectLine = string.IsNullOrEmpty(letterHeadAddress.ClaimNumber)
                          ? subjectLine.Replace("Claim No.: @claimNo", "")
                          : subjectLine.Replace("@claimNo", letterHeadAddress.ClaimNumber);

            subjectLine = string.IsNullOrEmpty(colItem.Insured_Name)
                          ? subjectLine.Replace("Insured: @insuredName", "")
                          : subjectLine.Replace("@insuredName", colItem.Insured_Name);

            subjectLine = string.IsNullOrEmpty(colItem.Claimant)
                          ? subjectLine.Replace("Claimant: @claimant", "")
                          : subjectLine.Replace("@claimant", colItem.Claimant);

            subjectLine = subjectLine.Replace("@mattNo", colItem.MatterNumber);

            subjectLine = subjectLine.Replace("@dateOfLoss", Convert.ToDateTime(colItem.DateOfLoss).ToString("MM/dd/yyyy"));

            try
            {
                var subStr4 = subjectLine.Substring(0, 4);
                if (subStr4.Equals(", , "))
                    subjectLine = subjectLine.Replace(", , ", "");

                var subStr2 = subjectLine.Substring(0, 2);
                if (subStr2.Equals(", "))
                    subjectLine = subjectLine.Substring(2, subjectLine.Length - 2);
            }
            catch(Exception ex)
            {

            }

            return subjectLine;
        }

        public string BuildStatementBody(
            RetrieveCollectionItemsByPastDueDays_Result colItem,
            List<RetrieveItemizedInvCollection_Result> itemizedInv,
            RetrieveLetterHeaderAddress_Result letterHeadAddress,
            bool isDebug = false)
        {
            string bodyHtml = AREmailBody.EmailBodyHtml;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{letterHeadAddress.ClientCity}, {letterHeadAddress.ClientState} {letterHeadAddress.ClientZipCode}");

            bodyHtml = bodyHtml.Replace("@clientOrgName", letterHeadAddress.ClientOrgName);
            bodyHtml = bodyHtml.Replace("@clientStreet", letterHeadAddress.ClientStreet);
            bodyHtml = bodyHtml.Replace("@clientCityState", sb.ToString());

            //hide empty attrs
            bodyHtml = string.IsNullOrEmpty(colItem.DateOfLoss) || Convert.ToDateTime(colItem.DateOfLoss) == DateTime.MinValue
               ? bodyHtml.Replace("@dateOfLossParagraph", "")
               : bodyHtml.Replace("@dateOfLossParagraph", AREmailBody.DateOfLossParagraph);

            bodyHtml = string.IsNullOrEmpty(letterHeadAddress.ClaimNumber)
                ? bodyHtml.Replace("@claimParagraph", "")
                : bodyHtml.Replace("@claimParagraph", AREmailBody.ClaimParagraph);

            bodyHtml = string.IsNullOrEmpty(letterHeadAddress.ReferenceNumber)
                ? bodyHtml.Replace("@referenceParagraph", "")
                : bodyHtml.Replace("@referenceParagraph", AREmailBody.ReferenceParagraph);

            bodyHtml = string.IsNullOrEmpty(colItem.Insured_Name)
                ? bodyHtml.Replace("@InsuredParagraph", "")
                : bodyHtml.Replace("@InsuredParagraph", AREmailBody.InsuredParagraph);

            bodyHtml = string.IsNullOrEmpty(colItem.Claimant)
                ? bodyHtml.Replace("@claimantParagraph", "")
                : bodyHtml.Replace("@claimantParagraph", AREmailBody.ClaimantParagraph);

            bodyHtml = string.IsNullOrEmpty(colItem.Style)
                ? bodyHtml.Replace("@styleParagraph", "")
                : bodyHtml.Replace("@styleParagraph", AREmailBody.StyleParagraph);

            bodyHtml = string.IsNullOrEmpty(colItem.Cause_Number)
                ? bodyHtml.Replace("@causeParagraph", "")
                : bodyHtml.Replace("@causeParagraph", AREmailBody.CauseParagraph);

            if (isDebug)
            {
                bodyHtml = bodyHtml.Replace("@emailToParagraph", AREmailBody.EmailToParagraph);
                bodyHtml = bodyHtml.Replace("@clientEmail", letterHeadAddress.InvoiceTo); // GetSpecialInstructionEmail(colItem, letterHeadAddress, ""));
            }
            else
            {
                bodyHtml = bodyHtml.Replace("@emailToParagraph", "");
            }

            bodyHtml = bodyHtml.Replace("@matterNo", colItem.MatterNumber)
                                .Replace("@claimNo", letterHeadAddress.ClaimNumber)
                                .Replace("@referenceNo", letterHeadAddress.ReferenceNumber)
                                .Replace("@dateOfLoss", Convert.ToDateTime(colItem.DateOfLoss).ToString("MM/dd/yyyy"))
                                .Replace("@insuredName", colItem.Insured_Name)
                                .Replace("@claimant", colItem.Claimant)
                                .Replace("@styleName", colItem.Style)
                                .Replace("@causeNo", colItem.Cause_Number)
                                .Replace("@currentDate", DateTime.Now.ToString("MM/dd/yyyy"));

            double totalAmt = 0.0;
            StringBuilder itemizedRow = new StringBuilder();

            foreach (var invGrp in itemizedInv)
            {
                string invDate = Convert.ToDateTime(invGrp.InvMaster_InvDate).ToString("MM/dd/yyyy");
                string invNum = invGrp.InvPayor_InvNumber;
                double billedAmt = Convert.ToDouble(invGrp.InvPayor_OrgAmt);
                double balanceAmt = Convert.ToDouble(invGrp.InvPayor_BalAmt);
                double recvdAmt = balanceAmt - billedAmt;

                string invrow = AREmailBody.ItemizedRow.Replace("@invoiceDate", invDate)
                                                       .Replace("@invoiceNumber", invNum)
                                                       .Replace("@billedAmount", billedAmt.ToString("N2"))
                                                       .Replace("@received", recvdAmt.ToString("N2"))
                                                       .Replace("@balanceDue", balanceAmt.ToString("N2"));
                totalAmt = totalAmt + balanceAmt;
                itemizedRow.AppendLine(invrow);
            }

            string itemizedCollectionTable = AREmailBody.ItemizedCollectionTable.Replace("@itemizedRow", itemizedRow.ToString())
                                                                                .Replace("@totalAmtDue", totalAmt.ToString("N2"));

            bodyHtml = bodyHtml.Replace("@itemizedCollectionTable", itemizedCollectionTable);
            bodyHtml = bodyHtml.Replace("@bankingInfo", AREmailBody.BankingInfo);

            return bodyHtml;
        }

        public string BuildBody(
            RetrieveCollectionItemsByPastDueDays_Result colItem, 
            List<RetrieveItemizedInvCollection_Result> itemizedInv,
            RetrieveLetterHeaderAddress_Result letterHeadAddress,
            bool isDebug = false)
        {
            string bodyHtml = AREmailBody.EmailBodyHtml;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{letterHeadAddress.ClientCity}, {letterHeadAddress.ClientState} {letterHeadAddress.ClientZipCode}");

            bodyHtml = bodyHtml.Replace("@clientOrgName", letterHeadAddress.ClientOrgName);
            bodyHtml = bodyHtml.Replace("@clientStreet", letterHeadAddress.ClientStreet);
            bodyHtml = bodyHtml.Replace("@clientCityState", sb.ToString());

            //hide empty attrs
            bodyHtml = string.IsNullOrEmpty(colItem.DateOfLoss) || Convert.ToDateTime(colItem.DateOfLoss) == DateTime.MinValue
               ? bodyHtml.Replace("@dateOfLossParagraph", "")
               : bodyHtml.Replace("@dateOfLossParagraph", AREmailBody.DateOfLossParagraph);

            bodyHtml = string.IsNullOrEmpty(letterHeadAddress.ClaimNumber) 
                ? bodyHtml.Replace("@claimParagraph", "") 
                : bodyHtml.Replace("@claimParagraph", AREmailBody.ClaimParagraph);

            bodyHtml = string.IsNullOrEmpty(letterHeadAddress.ReferenceNumber)
                ? bodyHtml.Replace("@referenceParagraph", "")
                : bodyHtml.Replace("@referenceParagraph", AREmailBody.ReferenceParagraph);

            bodyHtml = string.IsNullOrEmpty(colItem.Insured_Name)
                ? bodyHtml.Replace("@InsuredParagraph", "")
                : bodyHtml.Replace("@InsuredParagraph", AREmailBody.InsuredParagraph);

            bodyHtml = string.IsNullOrEmpty(colItem.Claimant)
                ? bodyHtml.Replace("@claimantParagraph", "")
                : bodyHtml.Replace("@claimantParagraph", AREmailBody.ClaimantParagraph);

            bodyHtml = string.IsNullOrEmpty(colItem.Style)
                ? bodyHtml.Replace("@styleParagraph", "")
                : bodyHtml.Replace("@styleParagraph", AREmailBody.StyleParagraph);

            bodyHtml = string.IsNullOrEmpty(colItem.Cause_Number)
                ? bodyHtml.Replace("@causeParagraph", "")
                : bodyHtml.Replace("@causeParagraph", AREmailBody.CauseParagraph);

            if (isDebug) 
            {
                bodyHtml = bodyHtml.Replace("@emailToParagraph", AREmailBody.EmailToParagraph);
                bodyHtml = bodyHtml.Replace("@clientEmail", letterHeadAddress.InvoiceTo); // GetSpecialInstructionEmail(colItem, letterHeadAddress, ""));
            }
            else
            {
                bodyHtml = bodyHtml.Replace("@emailToParagraph", "");
            }

            bodyHtml = bodyHtml.Replace("@matterNo", colItem.MatterNumber)
                                .Replace("@claimNo", letterHeadAddress.ClaimNumber)
                                .Replace("@referenceNo", letterHeadAddress.ReferenceNumber)
                                .Replace("@dateOfLoss", Convert.ToDateTime(colItem.DateOfLoss).ToString("MM/dd/yyyy"))
                                .Replace("@insuredName", colItem.Insured_Name)
                                .Replace("@claimant", colItem.Claimant)
                                .Replace("@styleName", colItem.Style)
                                .Replace("@causeNo", colItem.Cause_Number)
                                .Replace("@currentDate", DateTime.Now.ToString("MM/dd/yyyy"));

            double totalAmt = 0.0;
            StringBuilder itemizedRow = new StringBuilder();

            foreach(var invGrp in itemizedInv)
            {
                string invDate = Convert.ToDateTime(invGrp.InvMaster_InvDate).ToString("MM/dd/yyyy");
                string invNum = invGrp.InvPayor_InvNumber;
                double billedAmt = Convert.ToDouble(invGrp.InvPayor_OrgAmt);
                double balanceAmt = Convert.ToDouble(invGrp.InvPayor_BalAmt);
                double recvdAmt = balanceAmt - billedAmt;

                string invrow = AREmailBody.ItemizedRow.Replace("@invoiceDate", invDate)
                                                       .Replace("@invoiceNumber", invNum)
                                                       .Replace("@billedAmount", billedAmt.ToString("N2"))
                                                       .Replace("@received", recvdAmt.ToString("N2"))
                                                       .Replace("@balanceDue", balanceAmt.ToString("N2"));
                totalAmt = totalAmt + balanceAmt;
                itemizedRow.AppendLine(invrow);
            }

            string itemizedCollectionTable = AREmailBody.ItemizedCollectionTable.Replace("@itemizedRow", itemizedRow.ToString())
                                                                                .Replace("@totalAmtDue", totalAmt.ToString("N2"));

            bodyHtml = bodyHtml.Replace("@itemizedCollectionTable", itemizedCollectionTable);
            bodyHtml = bodyHtml.Replace("@bankingInfo", AREmailBody.BankingInfo);

            return bodyHtml;
        }

        public List<string> ScanForInvoices(
            string baseFolder, 
            List<string> lookupFolders, 
            List<RetrieveItemizedInvCollection_Result> itemizedInv)
        {
            List<string> invoices = new List<string>();

            foreach(var item in itemizedInv)
            {
                foreach(var folder in lookupFolders)
                {
                    var dir = new DirectoryInfo($"{baseFolder}\\{folder}");
                    var inv = Directory.GetFiles(dir.FullName, "*.*", SearchOption.AllDirectories).Where(x => Path.GetFileNameWithoutExtension(x).Equals(item.InvMaster_InvNumber)).Select(x => x);

                    if (inv.Count() > 0)
                    {
                        invoices.Add(inv.First());
                        break;
                    }
                }
            }

            return invoices;
        }

        private bool IsValidEmail(string email)
        {
            Regex regex = CreateRegEx();
            bool isValidEmail = regex.Match(email).Length > 0; //new EmailAddressAttribute().IsValid(email);
            return isValidEmail;
        }

        private Regex CreateRegEx()
        {
            const string pattern = @"^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$";
            const RegexOptions options = RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture;

            // Set explicit regex match timeout, sufficient enough for email parsing
            // Unless the global REGEX_DEFAULT_MATCH_TIMEOUT is already set
            TimeSpan matchTimeout = TimeSpan.FromSeconds(2);

            try
            {
                if (AppDomain.CurrentDomain.GetData("REGEX_DEFAULT_MATCH_TIMEOUT") == null)
                {
                    return new Regex(pattern, options, matchTimeout);
                }
            }
            catch
            {
                // Fallback on error
            }

            // Legacy fallback (without explicit match timeout)
            return new Regex(pattern, options);
        }
    }
}

