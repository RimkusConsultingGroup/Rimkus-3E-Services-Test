using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using TE3EConnect.logs;
using TE3EConnect.te3eMappers;
using TE3EConnect.te3eMappers.Automation;
using TE3EConnect.te3eMappers.NewBizIntake;
using TE3EConnect.te3eObjects.Automation;
using TE3EConnect.te3eXML;
using TE3EEntityFramework.Client.RCGKENTCMS;
using TE3EEntityFramework.Data.KenticoCMS._3EProcessItem;
using TE3EEntityFramework.Extension;

namespace TE3EConnect
{
    public class TE3ETranSvc
    {
        //private e3ewapiuat2.TransactionService transvcuat;
        //private e3ewapidev2.TransactionService transvcdev;
        private e3ewapiprod.TransactionService transvcprod;
        private elite3edev3.ITransactionService transvcdev;
        private elite3edev_uat.ITransactionService transvcuat;
        private elite3edev_staging.ITransactionService transvcstaging;
        private e3ewapiprodupgrade.ITransactionService transvcprodupgrade;

        public e3eServerEnv _e3EServer;
        public TE3ELoginInfo _tE3ELoginInfo;

        public TE3ETranSvc(TE3ELoginInfo tE3ELoginInfo)
        {
            _e3EServer = tE3ELoginInfo.E3EServerEnv;
            _tE3ELoginInfo = tE3ELoginInfo;

            if (_e3EServer == e3eServerEnv.UAT)
            {
                transvcuat = new elite3edev_uat.ITransactionService();
                transvcuat.Credentials = (string.IsNullOrEmpty(tE3ELoginInfo.sUserName) || string.IsNullOrEmpty(tE3ELoginInfo.sPassword))
                    ? System.Net.CredentialCache.DefaultNetworkCredentials
                    : tE3ELoginInfo.NetCredential;
                //transvcuat.Credentials = tE3ELoginInfo.NetCredential;

                transvcuat.Timeout = 240000;
            }
            else if (_e3EServer == e3eServerEnv.DEV)
            {
                transvcdev = new elite3edev3.ITransactionService();
                transvcdev.Credentials = (string.IsNullOrEmpty(tE3ELoginInfo.sUserName) || string.IsNullOrEmpty(tE3ELoginInfo.sPassword))
                    ? System.Net.CredentialCache.DefaultNetworkCredentials
                    : tE3ELoginInfo.NetCredential;
                //transvcdev.Credentials = tE3ELoginInfo.NetCredential;

                transvcdev.Timeout = 240000;
            }
            else if (_e3EServer == e3eServerEnv.STAGING)
            {
                transvcstaging = new elite3edev_staging.ITransactionService();
                transvcstaging.Credentials = (string.IsNullOrEmpty(tE3ELoginInfo.sUserName) || string.IsNullOrEmpty(tE3ELoginInfo.sPassword))
                    ? System.Net.CredentialCache.DefaultNetworkCredentials
                    : tE3ELoginInfo.NetCredential;
                //transvcdev.Credentials = tE3ELoginInfo.NetCredential;

                transvcstaging.Timeout = 240000;
            }
            else if (_e3EServer == e3eServerEnv.PROD)
            {
                if (tE3ELoginInfo.IsProdUpgradedVersion)
                {
                    transvcprodupgrade = new e3ewapiprodupgrade.ITransactionService();
                    transvcprodupgrade.Credentials = (string.IsNullOrEmpty(tE3ELoginInfo.sUserName) || string.IsNullOrEmpty(tE3ELoginInfo.sPassword))
                        ? System.Net.CredentialCache.DefaultNetworkCredentials
                        : tE3ELoginInfo.NetCredential;
                    //transvcprodupgrade.Credentials = tE3ELoginInfo.NetCredential;

                    transvcprodupgrade.Timeout = 240000;
                }
                else
                {
                    transvcprod = new e3ewapiprod.TransactionService();
                    transvcprod.Credentials = (string.IsNullOrEmpty(tE3ELoginInfo.sUserName) || string.IsNullOrEmpty(tE3ELoginInfo.sPassword))
                        ? System.Net.CredentialCache.DefaultNetworkCredentials
                        : tE3ELoginInfo.NetCredential;
                    //transvcprod.Credentials = tE3ELoginInfo.NetCredential;

                    transvcprod.Timeout = 240000;
                }

            }
        }

        public string ExecuteProcess<T>(e3eProcess e3EProcess, T data, e3eMode e3EMode = e3eMode.Add)
        {
            string result = "";

            if (e3EProcess == e3eProcess.GeneralLedger)
                result = AddGeneralJournal(data as e3eGJ);
            else if (e3EProcess == e3eProcess.RateExceptionGroup)
                result = ProcessRateExc(data as e3eRateExc);
            else if (e3EProcess == e3eProcess.AddCollectionStep)
                result = AddCollectionStep(data as CollectionStep);
            else if (e3EProcess == e3eProcess.CftNewBizIntake)
                result = ProcessCftWFNewBizIntake(data as e3eCftNewBizIntake, e3EMode);

            return result;
        }

        //public List<te3eOjects.Edit.PGDetChild_CCC> GetPGDetChild_CCCs(string pgDetHdr)
        //{
        //    string XOQL = string.Format(e3ePGDetHdrXML.GetPGDetChildXML, pgDetHdr);
        //    string result = "";

        //    if (_e3EServer == e3eServerEnv.UAT)
        //        result = transvcuat.GetArchetypeData(XOQL);
        //    else if (_e3EServer == e3eServerEnv.DEV)
        //        result = transvcdev.GetArchetypeData(XOQL);
        //    //else if (_e3EServer == e3eServerEnv.PROD2)
        //    //    result = transvcprod.GetArchetypeData(XOQL);

        //    if (result == null)
        //        return null;

        //    te3eOjects.Edit.Data pGDetChild_CCCs = DeserializeXml<te3eOjects.Edit.Data>(result);
        //    return pGDetChild_CCCs.PGDetChild_CCC.ToList();
        //}

        //public te3eOjects.Edit.Matter.Matter GetPGDetHdrByMattNum(string mattNum)
        //{
        //    var splitNum = mattNum.Split('.');
        //    int idx = Convert.ToInt32(splitNum[0]);
        //    string num = idx.ToString("D6");
        //    string newMattNum = string.Format("{0}.{1}", num, splitNum[1]);

        //    string XOQL = string.Format(e3ePGDetHdrXML.GetPGDetHdrXML, newMattNum.ToString());
        //    string result = "";

        //    if (_e3EServer == e3eServerEnv.UAT)
        //        result = transvcuat.GetArchetypeData(XOQL);
        //    else if (_e3EServer == e3eServerEnv.DEV)
        //        result = transvcdev.GetArchetypeData(XOQL);
        //    //else if (_e3EServer == e3eServerEnv.PROD2)
        //    //    result = transvcprod.GetArchetypeData(XOQL);

        //    if (result == null)
        //        return null;

        //    te3eOjects.Edit.Matter.Data pgdetHdr = DeserializeXml<te3eOjects.Edit.Matter.Data>(result);

        //    var matter = pgdetHdr.Matter.Where(x => x.NxEndDate == "12/31/9999 12:00:00 AM").Select(x => x).FirstOrDefault();
        //    return matter;
        //}

        public Matter GetMatterInfoByIndex(int mattIndex)
        {
            string XOQL = string.Format(e3eMatterXML.GetMatterInfoXOQLByIndex, mattIndex.ToString());

            string result = transvcGetArchetypeData(XOQL);

            if (result == null)
                return null;

            result = result.Replace("<Data>", "").Replace("</Data>", "");

            Matter matter = DeserializeXml<Matter>(result);
            return matter;
        }

        public string GetMatterCPCByNumXml(long matterNo)
        {
            string mattNum = matterNo.ToString("D9");
            string XOQL = string.Format(e3eMatterXML.GetMatterCPCXOQLByNum, mattNum);

            string result = transvcGetArchetypeData(XOQL);

            if (result == null)
                return null;

            result = result.Replace("<Data>", "").Replace("</Data>", "").Replace("Matter", "MatterCPC");
            //MatterCPC matter = DeserializeXml<MatterCPC>(result);
            return result;
        }

        public MatterCPC GetMatterCPCByNum(long matterNo)
        {
            string mattNum = matterNo.ToString("D9");
            string XOQL = string.Format(e3eMatterXML.GetMatterCPCXOQLByNum, mattNum);

            string result = transvcGetArchetypeData(XOQL);

            if (result == null)
                return null;

            result = result.Replace("<Data>", "").Replace("</Data>", "").Replace("Matter", "MatterCPC");
            MatterCPC matter = DeserializeXml<MatterCPC>(result);
            return matter;
        }

        public Matter GetMatterInfoByNum(long matterNo)
        {
            string mattNum = matterNo.ToString("D9");
            string XOQL = string.Format(e3eMatterXML.GetMatterInfoXOQLByNum, mattNum);

            string result = transvcGetArchetypeData(XOQL);

            if (result == null)
                return null;

            result = result.Replace("<Data>", "").Replace("</Data>", "");
            Matter matter = DeserializeXml<Matter>(result);
            return matter;
        }

        //public Voucher GetVoucher(int idx)
        //{
        //    string XOQL = string.Format(e3eVoucherXML.GetVoucherXML, idx.ToString());
        //    string result = "";

        //    if (_e3EServer == e3eServerEnv.UAT)
        //        result = transvcuat.GetArchetypeData(XOQL);
        //    else if (_e3EServer == e3eServerEnv.DEV)
        //        result = transvcdev.GetArchetypeData(XOQL);
        //    //else if (_e3EServer == e3eServerEnv.PROD2)
        //    //    result = transvcprod.GetArchetypeData(XOQL);

        //    if (result == null)
        //        return null;

        //    result = result.Replace("<Data>", "").Replace("</Data>", "");
        //    Voucher voucher = DeserializeXml<Voucher>(result);
        //    return voucher;
        //}

        public Payee GetPayeeByVendor(int vendorNum)
        {
            string XOQL = string.Format(e3ePayeeXML.GetPayeeXOQLByVendor, vendorNum.ToString());

            string result = transvcGetArchetypeData(XOQL);

            if (result == null)
                return null;

            result = result.Replace("<Data>", "").Replace("</Data>", "");
            Payee payee = DeserializeXml<Payee>(result);
            return payee;
        }

        public Payee GetPayeeByName(string name)
        {
            string XOQL = string.Format(e3ePayeeXML.GetPayeeXOQLByName, name.ToUpper());

            string result = transvcGetArchetypeData(XOQL);

            if (result == null)
                return null;

            result = result.Replace("<Data>", "").Replace("</Data>", "");
            Payee payee = DeserializeXml<Payee>(result);
            return payee;
        }

        public Timekeeper GetTimeKeeperByName(string name)
        {
            string XOQL = string.Format(e3eTimeKeeperXML.GetTimeKeeperXML, name);

            string result = transvcGetArchetypeData(XOQL);

            if (result == null)
                return null;

            result = result.Replace("<Data>", "").Replace("</Data>", "");
            Timekeeper timekeeper = DeserializeXml<Timekeeper>(result);
            return timekeeper;
        }

        public Timekeeper GetTimeKeeperByNum(string tkprNum)
        {
            if (string.IsNullOrEmpty(tkprNum))
                return new Timekeeper { TkprIndex = "" };

            int idx = Convert.ToInt32(tkprNum);
            string num = idx.ToString("D5");
            string XOQL = string.Format(e3eTimeKeeperXML.GetTimeKeeperByNumXML, num);

            string result = transvcGetArchetypeData(XOQL);

            if (result == null)
                return new Timekeeper { TkprIndex = "" };

            result = result.Replace("<Data>", "").Replace("</Data>", "");
            Timekeeper timekeeper = DeserializeXml<Timekeeper>(result);
            return timekeeper;
        }

        public Client GetClientByNum(string clientNum)
        {
            if (string.IsNullOrEmpty(clientNum))
                return new Client { ClientIndex = "" };

            int idx = Convert.ToInt32(clientNum);
            string num = idx.ToString("D7");
            string XOQL = string.Format(e3eClientXML.GetClientXOQLByNum, num);

            string result = transvcGetArchetypeData(XOQL);

            if (result == null)
                return null;

            result = result.Replace("<Data>", "").Replace("</Data>", "");
            Client client = DeserializeXml<Client>(result);
            return client;
        }

        public Client GetClientByName(string name)
        {
            if (string.IsNullOrEmpty(name))
                return new Client { ClientIndex = "" };

            string XOQL = string.Format(e3eClientXML.GetClientXOQLByName, name);

            string result = transvcGetArchetypeData(XOQL);

            if (result == null)
                return null;

            result = result.Replace("<Data>", "").Replace("</Data>", "");
            Client client = DeserializeXml<Client>(result);
            return client;
        }

        public GLAcct GetGLAcctByMaskedAlias(string maskedAlias)
        {
            string XOQL = string.Format(e3eGLAcctXML.GetGLAccountXML, maskedAlias);

            string result = transvcGetArchetypeData(XOQL);

            if (result == null)
                return null;

            result = result.Replace("<Data>", "").Replace("</Data>", "");
            GLAcct glAcct = DeserializeXml<GLAcct>(result);
            return glAcct;
        }

        public RateExc GetRateExc(string desc)
        {
            if (string.IsNullOrEmpty(desc))
                return new RateExc { RateExcID = "" };

            string XOQL = string.Format(e3eRateExcXML.GetRateExcXML, desc);

            string result = transvcGetArchetypeData(XOQL);

            if (result == null)
                return new RateExc { RateExcID = "" };

            result = result.Replace("<Data>", "").Replace("</Data>", "");
            RateExc rateExc = DeserializeXml<RateExc>(result);

            return rateExc;
        }

        public string AddVoucher(Voucher voucher)
        {
            int returnInfo = 0;

            string xmlString = string.Format(e3eVoucherXMLSample.AddVoucherXml, e3eVoucherXMLSample.VcrhDirectGL, e3eVoucherXMLSample.Vchr1099);
            string result = TransvcExecuteProcess(xmlString, returnInfo);

            return result;
        }

        public ProcessResults CheckResult(string result)
        {
            XmlDocument xResult = new XmlDocument();
            xResult.LoadXml(result);

            var processResult = xResult.DocumentElement.Attributes["Result"]?.InnerText;
            var processName = xResult.DocumentElement.Attributes["Process"]?.InnerText;

            ProcessResults processResults = new ProcessResults();
            processResults.processExecutionResult = (ProcessExecResult)Enum.Parse(typeof(ProcessExecResult), processResult);
            processResults.message = xResult.OuterXml;

            if (result.Contains("Large_Results_Page") && result.Contains("CftWFSearchEntry_RC"))
            {
                processResults.processExecutionResult = ProcessExecResult.Success;
            }
            if (processName != null && processName.Contains("Matter_Srv_RC") && processResults.message.Contains("assigned Matter Number"))
            {
                processResults.processExecutionResult = ProcessExecResult.Success;
            }

            try
            {
                processResults.processItemId = xResult.DocumentElement.Attributes["ProcessItemId"]?.InnerText ?? "";
            }
            catch { processResults.processItemId = ""; }

            //try
            //{
            //    if (result.Contains("CftWFNewBizIntake_RC") || (result.Contains("Large_Results_Page") && result.Contains("CftWFSearchEntry_RC")))
            //    {
            //        var searchID = result.Substring(result.IndexOf("Assigned Search ID: "), 27).Trim();
            //        var jobNumber = searchID.Replace("Assigned Search ID: ", "").Split(' ');

            //        if (jobNumber.Count() > 0)
            //        {
            //            if (!string.IsNullOrEmpty(jobNumber[0]))
            //            {
            //                processResults.processExecutionResult = ProcessExecResult.Success;
            //                processResults.jobNumber = Convert.ToInt32(jobNumber[0]);
            //            }
            //        }

            //    }
            //}
            //catch { processResults.jobNumber = 0; }

            return processResults;
        }

        public string AddCompleteVoucher(e3eVoucher e3EVoucher)
        {
            int returnInfo = 0;

            string vchrXml = VoucherMapper.ConvertCompleteVchrToXml(e3EVoucher.voucher, e3EVoucher.vchrDirectGLs.Count, e3EVoucher.costCards.Count);
            string vchr1099Xml = VoucherMapper.ConvertVchr1099ToXml(new Vchr1099 { Flag1099 = "N", Amount = e3EVoucher.voucher.Amount });
            string vchrCostXml = e3EVoucher.costCards.Count > 0 ? VoucherMapper.ConvertVchrCostToXml(e3EVoucher.costCards) : "";
            string vchrDirectGLXml = e3EVoucher.vchrDirectGLs.Count > 0 ? VoucherMapper.ConvertVchrDirectGLToXml(e3EVoucher.vchrDirectGLs) : "";
            string xmlString = string.Format(vchrXml, vchrDirectGLXml, vchr1099Xml, vchrCostXml);
            VoucherReport.GenerateXMLVchr(e3EVoucher.voucher.InvNum.First().Value, xmlString);

            string result = TransvcExecuteProcess(xmlString, returnInfo);

            return result;
        }

        public string AddVoucherWithCostCard(Voucher voucher, List<CostCard> costCards)
        {
            int returnInfo = 0;

            string vchrXml = VoucherMapper.ConvertVchrToXml(voucher);
            string vchr1099Xml = VoucherMapper.ConvertVchr1099ToXml(new Vchr1099 { Flag1099 = "N", Amount = voucher.Amount });
            string vchrCostXml = VoucherMapper.ConvertVchrCostToXml(costCards);
            string xmlString = string.Format(vchrXml, vchr1099Xml, vchrCostXml);

            string result = TransvcExecuteProcess(xmlString, returnInfo);

            return result;
        }

        public string AddVoucherWithDirectGL(Voucher voucher, List<VchrDirectGL> vchrDirectGLs)
        {
            int returnInfo = 0;

            string vchrXml = VoucherMapper.ConvertVchrToXml(voucher);
            string vchr1099Xml = VoucherMapper.ConvertVchr1099ToXml(new Vchr1099 { Flag1099 = "N", Amount = voucher.Amount });
            string vchrDirectGLXml = VoucherMapper.ConvertVchrDirectGLToXml(vchrDirectGLs);
            string xmlString = string.Format(vchrXml, vchrDirectGLXml, vchr1099Xml);

            string result = TransvcExecuteProcess(xmlString, returnInfo);

            return result;
        }

        public string AddGeneralJournal(e3eGJ e3EGJ)
        {
            int returnInfo = 0;

            string gjXml = GJMapper.ConvertGJToXml(e3EGJ);
            string gjDetailsXml = GJMapper.ConvertGJDetailToXml(e3EGJ.gJDetails);
            string xmlString = string.Format(gjXml, gjDetailsXml);
            GJReport.GenerateXMLGJ(e3EGJ.gJ.GJTranNum, xmlString);

            string result = TransvcExecuteProcess(xmlString, returnInfo);

            return result;
        }

        public string ProcessRateExc(e3eRateExc e3ERateExc)
        {
            int returnInfo = 0;

            string rateExcXml = RateExcMapper.ConvertRateExcToXml(e3ERateExc);
            string rateExcDetailsXml = RateExcMapper.ConvertRateExcDetailToXml(e3ERateExc.rateExcDets);
            string xmlString = string.Format(e3eRateExcXML.RateExcXML, string.Format(rateExcXml, rateExcDetailsXml));
            RateExcReport.GenerateXMLRateExc(e3ERateExc.rateExc.Description[0].Value, xmlString);

            string result = TransvcExecuteProcess(xmlString, returnInfo);

            return result;
        }

        public string ProcessMatter(e3eMatterSrv e3EMatterSrv, e3eMode e3EMode)
        {
            int returnInfo = 0;
            string xmlString = "";

            if (e3EMode == e3eMode.Add)
            {
                string mattSrvXml = NBIMapper.ConvertAddMatterSrvToXml(e3EMatterSrv);
                string mattDateXml = NBIMapper.ConvertMattDateToXml(e3EMatterSrv);
                string pGDetHdr_CCCXml = NBIMapper.ConvertAddpGDetHdr_CCCToXml(e3EMatterSrv);
                string associatedTkprs_CCCXml = NBIMapper.ConverAssociatedTkprs_CCCToXml(e3EMatterSrv);
                string salesforceInfo_CCCXml = NBIMapper.ConvertSalesforceInfoToXml(e3EMatterSrv);
                string mattRateXml = NBIMapper.ConvertMattRateToXml(e3EMatterSrv);
                string mattRateExcXml = NBIMapper.ConvertMattRateExcToXml(e3EMatterSrv);

                xmlString = mattSrvXml.Replace("@AddMattDate", mattDateXml)
                                      .Replace("@AddMattRate", mattRateXml)
                                      .Replace("@AddMatterRateExc", string.IsNullOrEmpty(e3EMatterSrv.mattRateExc.RateExc) ? "" : mattRateExcXml)
                                      .Replace("@AddPGDetHdr_CCC", pGDetHdr_CCCXml)
                                      .Replace("@AddAssociateTkprs_CCC", associatedTkprs_CCCXml)
                                      .Replace("@AddSalesForceInfo_CCC", salesforceInfo_CCCXml);

                NBIReport.GenerateXMLMatterSrv(e3EMatterSrv.matterSrv.OpportunityID_CCC, xmlString);
            }
            else if (e3EMode == e3eMode.Edit)
            {
                string mattSrvXml = NBIMapper.ConvertEditMatterSrvToXml(e3EMatterSrv);
                string pGDetHdr_CCCXml = NBIMapper.ConvertEditpGDetHdr_CCCToXml(e3EMatterSrv);

                xmlString = mattSrvXml.Replace("@EditPGDetHdr_CCC", pGDetHdr_CCCXml);

                NBIReport.GenerateXMLMatterSrv(e3EMatterSrv.matterSrv.Number.Replace(".", "_"), xmlString);
            }

            string result = TransvcExecuteProcess(xmlString, returnInfo);

            return result;
        }

        public string ProcessCftWFNewBizIntake(e3eCftNewBizIntake eCftNewBizIntake, e3eMode e3EMode)
        {
            int returnInfo = 0;

            string xmlString = CftNewBizIntakeMapper.ConvertNewBizIntakeToXml(eCftNewBizIntake, e3EMode);
            CftNewBizIntakeReport.GenerateXMLCftNewBizIntake("AddCftWFNewBizIntakeXml", xmlString);

            string result = TransvcExecuteProcess(xmlString, returnInfo);

            CftNewBizIntakeReport.GenerateResultXMLCftNewBizIntake("AddCftWFNewBizIntakeResultXml", result);

            return result;
        }

        public string ProcessMatterShortEntry(e3eMatterSrv e3EMatterSrv, e3eMode e3EMode)
        {
            int returnInfo = 0;
            string xmlString = "";

            if (e3EMode == e3eMode.Add)
            {
                string mattSrvXml = NBIMapper.ConvertAddMatterSrvToXml(e3EMatterSrv);
                string mattDateXml = NBIMapper.ConvertMattDateToXml(e3EMatterSrv);
                string pGDetHdr_CCCXml = NBIMapper.ConvertAddpGDetHdr_CCCToXml(e3EMatterSrv);
                string associatedTkprs_CCCXml = NBIMapper.ConverAssociatedTkprs_CCCToXml(e3EMatterSrv);
                string salesforceInfo_CCCXml = NBIMapper.ConvertSalesforceInfoToXml(e3EMatterSrv);
                string mattRateXml = NBIMapper.ConvertMattRateToXml(e3EMatterSrv);
                string mattRateExcXml = NBIMapper.ConvertMattRateExcToXml(e3EMatterSrv);

                xmlString = mattSrvXml.Replace("@AddMattDate", mattDateXml)
                                      .Replace("@AddMattRate", mattRateXml)
                                      .Replace("@AddMatterRateExc", string.IsNullOrEmpty(e3EMatterSrv.mattRateExc.RateExc) ? "" : mattRateExcXml)
                                      .Replace("@AddPGDetHdr_CCC", pGDetHdr_CCCXml)
                                      .Replace("@AddAssociateTkprs_CCC", associatedTkprs_CCCXml)
                                      .Replace("@AddSalesForceInfo_CCC", salesforceInfo_CCCXml);

                NBIReport.GenerateXMLMatterSrv(e3EMatterSrv.matterSrv.OpportunityID_CCC, xmlString);
            }
            else if (e3EMode == e3eMode.Edit)
            {
                string mattSrvXml = NBIMapper.ConvertEditMatterSrvToXml(e3EMatterSrv);
                string pGDetHdr_CCCXml = NBIMapper.ConvertEditpGDetHdr_CCCToXml(e3EMatterSrv);

                xmlString = mattSrvXml.Replace("@EditPGDetHdr_CCC", pGDetHdr_CCCXml);

                NBIReport.GenerateXMLMatterSrv(e3EMatterSrv.matterSrv.Number.Replace(".", "_"), xmlString);
            }

            string result = TransvcExecuteProcess(xmlString, returnInfo);

            return result;
        }

        public string ProcessClientShortEntry(e3eMatterSrv e3EMatterSrv, e3eMode e3EMode)
        {
            int returnInfo = 0;
            string xmlString = "";

            if (e3EMode == e3eMode.Add)
            {
                string mattSrvXml = NBIMapper.ConvertAddMatterSrvToXml(e3EMatterSrv);
                string mattDateXml = NBIMapper.ConvertMattDateToXml(e3EMatterSrv);
                string pGDetHdr_CCCXml = NBIMapper.ConvertAddpGDetHdr_CCCToXml(e3EMatterSrv);
                string associatedTkprs_CCCXml = NBIMapper.ConverAssociatedTkprs_CCCToXml(e3EMatterSrv);
                string salesforceInfo_CCCXml = NBIMapper.ConvertSalesforceInfoToXml(e3EMatterSrv);
                string mattRateXml = NBIMapper.ConvertMattRateToXml(e3EMatterSrv);
                string mattRateExcXml = NBIMapper.ConvertMattRateExcToXml(e3EMatterSrv);

                xmlString = mattSrvXml.Replace("@AddMattDate", mattDateXml)
                                      .Replace("@AddMattRate", mattRateXml)
                                      .Replace("@AddMatterRateExc", string.IsNullOrEmpty(e3EMatterSrv.mattRateExc.RateExc) ? "" : mattRateExcXml)
                                      .Replace("@AddPGDetHdr_CCC", pGDetHdr_CCCXml)
                                      .Replace("@AddAssociateTkprs_CCC", associatedTkprs_CCCXml)
                                      .Replace("@AddSalesForceInfo_CCC", salesforceInfo_CCCXml);

                NBIReport.GenerateXMLMatterSrv(e3EMatterSrv.matterSrv.OpportunityID_CCC, xmlString);
            }
            else if (e3EMode == e3eMode.Edit)
            {
                string mattSrvXml = NBIMapper.ConvertEditMatterSrvToXml(e3EMatterSrv);
                string pGDetHdr_CCCXml = NBIMapper.ConvertEditpGDetHdr_CCCToXml(e3EMatterSrv);

                xmlString = mattSrvXml.Replace("@EditPGDetHdr_CCC", pGDetHdr_CCCXml);

                NBIReport.GenerateXMLMatterSrv(e3EMatterSrv.matterSrv.Number.Replace(".", "_"), xmlString);
            }

            string result = TransvcExecuteProcess(xmlString, returnInfo);

            return result;
        }

        #region NBI Automation Srv

        #region Add Process

        public ProcessRawResultXml AddEntityPersonSrv(List<EntityPersonSrv> entityPersonSrvs)
        {
            ProcessRawResultXml processRawResultXml = new ProcessRawResultXml();
            processRawResultXml.xmlFiles = new List<string>();

            int returnInfo = 0;

            string xmlString = EntityPersonSrvMapper.ConvertEntityPersonSrvToXml(entityPersonSrvs, e3eMode.Add);

            string result = TransvcExecuteProcess(xmlString, returnInfo);

            string payloadXml = EntityPersonSrvReport.GenerateXMLEntityPersonSrvReport($"{entityPersonSrvs.First().entityPerson.LastName}, {entityPersonSrvs.First().entityPerson.FirstName}", xmlString);
            processRawResultXml.xmlFiles.Add(payloadXml);

            string resultXml = EntityPersonSrvReport.GenerateResultXMLEntityPersonSrvReport($"{entityPersonSrvs.First().entityPerson.LastName}, {entityPersonSrvs.First().entityPerson.FirstName}", result);
            processRawResultXml.xmlFiles.Add(resultXml);
            processRawResultXml.result = result;

            return processRawResultXml;
        }

        public ProcessRawResultXml AddUKGEntityPersonSrv(List<EntityPersonSrv> entityPersonSrvs, bool isEditRelXml = false)
        {
            ProcessRawResultXml processRawResultXml = new ProcessRawResultXml();
            processRawResultXml.xmlFiles = new List<string>();

            int returnInfo = 0;

            string xmlString = UKGEntityPersonSrvMapper.ConvertEntityPersonSrvToXml(entityPersonSrvs, e3eMode.Add, isEditRelXml);

            string result = TransvcExecuteProcess(xmlString, returnInfo);

            string payloadXml = EntityPersonSrvReport.GenerateXMLEntityPersonSrvReport($"{entityPersonSrvs.First().entityPerson.LastName}, {entityPersonSrvs.First().entityPerson.FirstName}", xmlString);
            processRawResultXml.xmlFiles.Add(payloadXml);

            string resultXml = EntityPersonSrvReport.GenerateResultXMLEntityPersonSrvReport($"{entityPersonSrvs.First().entityPerson.LastName}, {entityPersonSrvs.First().entityPerson.FirstName}", result);
            processRawResultXml.xmlFiles.Add(resultXml);
            processRawResultXml.result = result;

            return processRawResultXml;
        }

        public ProcessRawResultXml EditUKGEntityPersonSrv(List<EntityPersonSrv> entityPersonSrvs)
        {
            ProcessRawResultXml processRawResultXml = new ProcessRawResultXml();
            processRawResultXml.xmlFiles = new List<string>();

            int returnInfo = 0;

            string xmlString = UKGEntityPersonSrvMapper.ConvertEntityPersonSrvToXml(entityPersonSrvs, e3eMode.Edit);

            string result = TransvcExecuteProcess(xmlString, returnInfo);

            string payloadXml = EntityPersonSrvReport.GenerateXMLEntityPersonSrvReport($"{entityPersonSrvs.First().entityPerson.LastName}, {entityPersonSrvs.First().entityPerson.FirstName}", xmlString);
            processRawResultXml.xmlFiles.Add(payloadXml);

            string resultXml = EntityPersonSrvReport.GenerateResultXMLEntityPersonSrvReport($"{entityPersonSrvs.First().entityPerson.LastName}, {entityPersonSrvs.First().entityPerson.FirstName}", result);
            processRawResultXml.xmlFiles.Add(resultXml);
            processRawResultXml.result = result;

            return processRawResultXml;
        }


        public ProcessRawResultXml EditEntityPersonSrv(List<EntityPersonSrv> entityPersonSrvs)
        {
            ProcessRawResultXml processRawResultXml = new ProcessRawResultXml();
            processRawResultXml.xmlFiles = new List<string>();

            int returnInfo = 0;

            string xmlString = EntityPersonSrvMapper.ConvertEntityPersonSrvToXml(entityPersonSrvs, e3eMode.Edit);
            string result = TransvcExecuteProcess(xmlString, returnInfo);

            string payloadXml = EntityPersonSrvReport.GenerateXMLEntityPersonSrvReport($"{entityPersonSrvs.First().entityPerson.LastName}, {entityPersonSrvs.First().entityPerson.FirstName}", xmlString);
            processRawResultXml.xmlFiles.Add(payloadXml);

            string resultXml = EntityPersonSrvReport.GenerateResultXMLEntityPersonSrvReport($"{entityPersonSrvs.First().entityPerson.LastName}, {entityPersonSrvs.First().entityPerson.FirstName}", result);
            processRawResultXml.xmlFiles.Add(resultXml);
            processRawResultXml.result = result;

            return processRawResultXml;
        }

        public ProcessRawResultXml AddEntityOrgSrv(List<EntityOrgSrv> entityOrgSrvs)
        {
            ProcessRawResultXml processRawResultXml = new ProcessRawResultXml();
            processRawResultXml.xmlFiles = new List<string>();

            int returnInfo = 0;

            string xmlString = EntityOrgSrvMapper.ConvertEntityOrgSrvToXml(entityOrgSrvs, e3eMode.Add);

            string result = TransvcExecuteProcess(xmlString, returnInfo);
            string payloadXml = EntityOrgSrvReport.GenerateXMLEntityOrgSrvReport(string.Join(",", entityOrgSrvs.Select(x => x.entityOrg.OrgName)), xmlString);
            processRawResultXml.xmlFiles.Add(payloadXml);

            string resultXml = EntityOrgSrvReport.GenerateResultXMLEntityOrgSrvReport(string.Join(",", entityOrgSrvs.Select(x => x.entityOrg.OrgName)), result);
            processRawResultXml.xmlFiles.Add(resultXml);
            processRawResultXml.result = result;

            return processRawResultXml;
        }

        public ProcessRawResultXml EditEntityOrgSrv(List<EntityOrgSrv> entityOrgSrvs)
        {
            ProcessRawResultXml processRawResultXml = new ProcessRawResultXml();
            processRawResultXml.xmlFiles = new List<string>();

            int returnInfo = 0;

            string xmlString = EntityOrgSrvMapper.ConvertEntityOrgSrvToXml(entityOrgSrvs, e3eMode.Edit);

            string result = TransvcExecuteProcess(xmlString, returnInfo);
            string payloadXml = EntityOrgSrvReport.GenerateXMLEntityOrgSrvReport(string.Join(",", entityOrgSrvs.Select(x => x.entityOrg.OrgName)), xmlString);
            processRawResultXml.xmlFiles.Add(payloadXml);

            string resultXml = EntityOrgSrvReport.GenerateResultXMLEntityOrgSrvReport(string.Join(",", entityOrgSrvs.Select(x => x.entityOrg.OrgName)), result);
            processRawResultXml.xmlFiles.Add(resultXml);
            processRawResultXml.result = result;

            return processRawResultXml;
        }

        public ProcessRawResultXml AddClientSrv(List<ClientSrv> clientSrvs)
        {
            ProcessRawResultXml processRawResultXml = new ProcessRawResultXml();
            processRawResultXml.xmlFiles = new List<string>();

            int returnInfo = 0;

            string xmlString = ClientSrvMapper.ConvertClientSrvToXml(clientSrvs, e3eMode.Add);

            string result = TransvcExecuteProcess(xmlString, returnInfo);
            string payloadXml = ClientSrvReport.GenerateXMLClientSrvReport(string.Join(",", clientSrvs.Select(x => x.DisplayName)), xmlString);
            processRawResultXml.xmlFiles.Add(payloadXml);

            string resultXml = ClientSrvReport.GenerateResultXMLClientSrvReport(string.Join(",", clientSrvs.Select(x => x.DisplayName)), result);
            processRawResultXml.xmlFiles.Add(resultXml);
            processRawResultXml.result = result;

            return processRawResultXml;
        }

        public ProcessRawResultXml EditClientSrv(List<ClientSrv> clientSrvs)
        {
            ProcessRawResultXml processRawResultXml = new ProcessRawResultXml();
            processRawResultXml.xmlFiles = new List<string>();

            int returnInfo = 0;

            string xmlString = ClientSrvMapper.ConvertClientSrvToXml(clientSrvs, e3eMode.Edit);

            string result = TransvcExecuteProcess(xmlString, returnInfo);
            string payloadXml = ClientSrvReport.GenerateXMLClientSrvReport(string.Join(",", clientSrvs.Select(x => x.DisplayName)), xmlString);
            processRawResultXml.xmlFiles.Add(payloadXml);

            string resultXml = ClientSrvReport.GenerateResultXMLClientSrvReport(string.Join(",", clientSrvs.Select(x => x.DisplayName)), result);
            processRawResultXml.xmlFiles.Add(resultXml);
            processRawResultXml.result = result;

            return processRawResultXml;
        }

        public ProcessRawResultXml AddMatterSrv(te3eObjects.Automation.MatterSrv matterSrv)
        {
            ProcessRawResultXml processRawResultXml = new ProcessRawResultXml();
            processRawResultXml.xmlFiles = new List<string>();

            int returnInfo = 0;

            string xmlString = MatterSrvMapper.ConvertAddMatterSrvToXml(matterSrv, false);

            string result = TransvcExecuteProcess(xmlString, returnInfo);
            string payloadXml = MatterSrvReport.GenerateXMLMatterSrvReport(matterSrv.DisplayName, xmlString);
            processRawResultXml.xmlFiles.Add(payloadXml);

            string resultXml = MatterSrvReport.GenerateResultXMLMatterSrvReport(matterSrv.DisplayName, result);
            processRawResultXml.xmlFiles.Add(resultXml);
            processRawResultXml.result = result;

            return processRawResultXml;
        }
        public ProcessRawResultXml AddMatterSrvTemplateProcess(te3eObjects.Automation.MatterSrv matterSrv)
        {
            ProcessRawResultXml processRawResultXml = new ProcessRawResultXml();
            processRawResultXml.xmlFiles = new List<string>();

            int returnInfo = 0;

            string xmlString = MatterSrvMapper.ConvertAddMatterSrvToXml(matterSrv, true);

            string result = TransvcExecuteProcess(xmlString, returnInfo);
            string payloadXml = MatterSrvReport.GenerateXMLMatterSrvReport(matterSrv.DisplayName, xmlString);
            processRawResultXml.xmlFiles.Add(payloadXml);

            string resultXml = MatterSrvReport.GenerateResultXMLMatterSrvReport(matterSrv.DisplayName, result);
            processRawResultXml.xmlFiles.Add(resultXml);
            processRawResultXml.result = result;

            return processRawResultXml;
        }

        public ProcessRawResultXml AddNBISrv(NBISrv nbiSrv)
        {
            ProcessRawResultXml processRawResultXml = new ProcessRawResultXml();
            processRawResultXml.xmlFiles = new List<string>();

            int returnInfo = 0;

            string xmlString = NBISrvMapper.ConvertNBISrvToXml(nbiSrv);
            string payloadXml = NBISrvReport.GenerateXMLNBISrvReport($"Client({nbiSrv.Client}) - Matter({nbiSrv.Matter})", xmlString);
            processRawResultXml.xmlFiles.Add(payloadXml);
            try
            {
                string result = TransvcExecuteProcess(xmlString, returnInfo);
                string resultXml = NBISrvReport.GenerateResultXMLNBISrvReport($"Client({nbiSrv.Client}) - Matter({nbiSrv.Matter})", result);
                processRawResultXml.xmlFiles.Add(resultXml);
                processRawResultXml.result = result;
            }
            catch (Exception) // This is a temp bypass for NBI Process Timeout Issue
            {
                var fakeXML = "<ProcessExecutionResults Process=\"CftWFNewBizIntake_RC\" Result=\"Success\"><MESSAGE>NBI Proccess timeout. Assigned Search ID: 000001 </MESSAGE></ProcessExecutionResults>";
                string resultXml = NBISrvReport.GenerateResultXMLNBISrvReport($"Client({nbiSrv.Client}) - Matter({nbiSrv.Matter})", fakeXML);
                processRawResultXml.xmlFiles.Add(resultXml);
                processRawResultXml.result = fakeXML;
            }


            return processRawResultXml;
        }

        public ProcessRawResultXml AddTimekeeper(TimekeeperSrv timekeeperSrv)
        {
            ProcessRawResultXml processRawResultXml = new ProcessRawResultXml();
            processRawResultXml.xmlFiles = new List<string>();

            int returnInfo = 0;

            string xmlString = TimekeeperSrvMapper.ConvertTimekeeperSrvToXml(timekeeperSrv, e3eMode.Add);
            string payloadXml = TimekeeperSrvReport.GenerateXMLTimekeeperSrvReport($"Timekeeper ({timekeeperSrv.timekeeper.DisplayName}) - Number({timekeeperSrv.timekeeper.Number})", xmlString);
            processRawResultXml.xmlFiles.Add(payloadXml);

            string result = TransvcExecuteProcess(xmlString, returnInfo);

            string resultXml = TimekeeperSrvReport.GenerateResultXMLTimekeeperSrvReport($"Timekeeper({timekeeperSrv.timekeeper.DisplayName}) - Number({timekeeperSrv.timekeeper.Number})", result);
            processRawResultXml.xmlFiles.Add(resultXml);
            processRawResultXml.result = result;

            return processRawResultXml;
        }

        public ProcessRawResultXml AddNxUser(NxUser nxUser)
        {
            ProcessRawResultXml processRawResultXml = new ProcessRawResultXml();
            processRawResultXml.xmlFiles = new List<string>();

            int returnInfo = 0;

            string xmlString = NxUserSrvMapper.ConvertNxUserSrvToXml(nxUser, e3eMode.Add);
            string payloadXml = NxUserReport.GenerateXMLNxUserReport($"User ({nxUser.BaseUserName}) - NetworkAlias({nxUser.UserName})", xmlString);
            processRawResultXml.xmlFiles.Add(payloadXml);

            string result = TransvcExecuteProcess(xmlString, returnInfo);

            string resultXml = NxUserReport.GenerateResultXMLNxUserReport($"User ({nxUser.BaseUserName}) - NetworkAlias({nxUser.UserName})", result);
            processRawResultXml.xmlFiles.Add(resultXml);
            processRawResultXml.result = result;

            return processRawResultXml;
        }

        public ProcessRawResultXml EditNxUser(NxUser nxUser)
        {
            ProcessRawResultXml processRawResultXml = new ProcessRawResultXml();
            processRawResultXml.xmlFiles = new List<string>();

            int returnInfo = 0;

            string xmlString = NxUserSrvMapper.ConvertNxUserSrvToXml(nxUser, e3eMode.Edit);
            string payloadXml = NxUserReport.GenerateXMLNxUserReport($"User ({nxUser.BaseUserName}) - NetworkAlias({nxUser.UserName})", xmlString);
            processRawResultXml.xmlFiles.Add(payloadXml);

            string result = TransvcExecuteProcess(xmlString, returnInfo);

            string resultXml = NxUserReport.GenerateResultXMLNxUserReport($"User ({nxUser.BaseUserName}) - NetworkAlias({nxUser.UserName})", result);
            processRawResultXml.xmlFiles.Add(resultXml);
            processRawResultXml.result = result;

            return processRawResultXml;
        }

        public ProcessRawResultXml AddPOReqWFCCC(POReqWF_CCCSrv pOReqWF_CCCSrv)
        {
            ProcessRawResultXml processRawResultXml = new ProcessRawResultXml();
            processRawResultXml.xmlFiles = new List<string>();

            int returnInfo = 0;

            string xmlString = POReqWFSrvMapper.ConvertPOReqWFSrvToXml(pOReqWF_CCCSrv, e3eMode.Add);
            string payloadXml = POReqWFCCCReport.GenerateXMLPOReqWFCCCReport($"Requested By ({pOReqWF_CCCSrv.pOReq.NxUserName}) - Product Bundle ({pOReqWF_CCCSrv.pOReq.ProductBundle_Name})", xmlString);
            processRawResultXml.xmlFiles.Add(payloadXml);

            string result = TransvcExecuteProcess(xmlString, returnInfo);

            string resultXml = POReqWFCCCReport.GenerateResultXMLPOReqWFCCCReport($"Requested By ({pOReqWF_CCCSrv.pOReq.NxUserName}) - Product Bundle ({pOReqWF_CCCSrv.pOReq.ProductBundle_Name})", result);
            processRawResultXml.xmlFiles.Add(resultXml);
            processRawResultXml.result = result;

            return processRawResultXml;
        }

        public ProcessRawResultXml AddPOUserApproveWFCCC(POReqWF_CCCSrv pOReqWF_CCCSrv)
        {
            ProcessRawResultXml processRawResultXml = new ProcessRawResultXml();
            processRawResultXml.xmlFiles = new List<string>();

            int returnInfo = 0;

            string xmlString = POUserApproveWFSrvMapper.ConvertPOUserApproveWFSrvToXml(pOReqWF_CCCSrv, e3eMode.Add);
            string payloadXml = POUserApproveWFCCCReport.GenerateXMLPOUserApproveWFCCCReport($"Requested By ({pOReqWF_CCCSrv.pOReq.NxUserName}) - Product Bundle ({pOReqWF_CCCSrv.pOReq.ProductBundle_Name})", xmlString);
            processRawResultXml.xmlFiles.Add(payloadXml);

            string result = TransvcExecuteProcess(xmlString, returnInfo);

            string resultXml = POUserApproveWFCCCReport.GenerateResultXMLPOUserApproveWFCCCReport($"Requested By ({pOReqWF_CCCSrv.pOReq.NxUserName}) - Product Bundle ({pOReqWF_CCCSrv.pOReq.ProductBundle_Name})", result);
            processRawResultXml.xmlFiles.Add(resultXml);
            processRawResultXml.result = result;

            return processRawResultXml;
        }

        public ProcessRawResultXml AddPOEntry(POEntrySrv pOEntrySrv)
        {
            ProcessRawResultXml processRawResultXml = new ProcessRawResultXml();
            processRawResultXml.xmlFiles = new List<string>();

            int returnInfo = 0;

            string xmlString = POEntrySrvMapper.ConvertPOEntrySrvToXml(pOEntrySrv, e3eMode.Add);
            string payloadXml = POEntryReport.GenerateXMLPOEntryReport($"Requested By ({pOEntrySrv.pOReq.RequestNxUserName}) - Product Bundle ({pOEntrySrv.pOReq.ProductBundle_Name})", xmlString);
            processRawResultXml.xmlFiles.Add(payloadXml);

            string result = TransvcExecuteProcess(xmlString, returnInfo);

            string resultXml = POEntryReport.GenerateResultXMLPOEntryReport($"Requested By ({pOEntrySrv.pOReq.RequestNxUserName}) - Product Bundle ({pOEntrySrv.pOReq.ProductBundle_Name})", result);
            processRawResultXml.xmlFiles.Add(resultXml);
            processRawResultXml.result = result;

            return processRawResultXml;
        }

        #endregion Add Process

        #region Edit Process
        public ProcessRawResultXml EditTimekeeper(TimekeeperSrv timekeeperSrv, bool forceEditDisplayAndBillName = false)
        {
            ProcessRawResultXml processRawResultXml = new ProcessRawResultXml();
            processRawResultXml.xmlFiles = new List<string>();

            int returnInfo = 0;

            string xmlString = TimekeeperSrvMapper.ConvertTimekeeperSrvToXml(timekeeperSrv, e3eMode.Edit, forceEditDisplayAndBillName);
            string payloadXml = TimekeeperSrvReport.GenerateXMLTimekeeperSrvReport($"Timekeeper({timekeeperSrv.timekeeper.DisplayName}) - Number({timekeeperSrv.timekeeper.Number})", xmlString);
            processRawResultXml.xmlFiles.Add(payloadXml);

            string result = TransvcExecuteProcess(xmlString, returnInfo);

            string resultXml = TimekeeperSrvReport.GenerateResultXMLTimekeeperSrvReport($"Timekeeper({timekeeperSrv.timekeeper.DisplayName}) - Number({timekeeperSrv.timekeeper.Number})", result);
            processRawResultXml.xmlFiles.Add(resultXml);
            processRawResultXml.result = result;

            return processRawResultXml;
        }

        public ProcessRawResultXml EditMatterSrv(te3eObjects.Automation.MatterSrv matterSrv)
        {
            ProcessRawResultXml processRawResultXml = new ProcessRawResultXml();
            processRawResultXml.xmlFiles = new List<string>();

            int returnInfo = 0;

            string xmlString = MatterSrvMapper.ConvertEditMatterSrvToXml(matterSrv);
            string payloadXml = MatterSrvReport.GenerateXMLMatterSrvReport(matterSrv.DisplayName, xmlString);
            processRawResultXml.xmlFiles.Add(payloadXml);

            string result = TransvcExecuteProcess(xmlString, returnInfo);

            string resultXml = MatterSrvReport.GenerateResultXMLMatterSrvReport(matterSrv.DisplayName, result);
            processRawResultXml.xmlFiles.Add(resultXml);
            processRawResultXml.result = result;

            return processRawResultXml;
        }

        #endregion Edit Process


        #endregion NBI Automation Srv

        public string AddCollectionStep(CollectionStep collectionStep)
        {
            int returnInfo = 0;

            string xmlString = CollectionItemMapper.ConvertColStepToXml(collectionStep);
            CollectionItemReport.GenerateXMLCollectionItem(collectionStep.CollectionItem, xmlString);

            string result = TransvcExecuteProcess(xmlString, returnInfo);

            CollectionItemReport.GenerateResultXMLCollectionItem(collectionStep.CollectionItem, result);

            return result;
        }

        public te3eOjects.Edit.Entity.Entity GetEntityByDisplayName(string name)
        {
            if (string.IsNullOrEmpty(name))
                return new te3eOjects.Edit.Entity.Entity { EntIndex = "" };

            string XOQL = string.Format(e3eEntityXML.GetEntityByDisplayNameXML, name.Replace("&", "&amp;"));

            string result = transvcGetArchetypeData(XOQL);

            if (result == null)
                return new te3eOjects.Edit.Entity.Entity { EntIndex = "" };

            te3eOjects.Edit.Entity.Data entityData = DeserializeXml<te3eOjects.Edit.Entity.Data>(result);
            te3eOjects.Edit.Entity.Entity entity = entityData.Entity.First(x => Convert.ToInt32(x.EntIndex) == entityData.Entity.Max(y => Convert.ToInt32(y.EntIndex)));

            return entity;
        }

        public te3eOjects.Edit.Entity.Entity GetCPAEntity(string name)
        {
            if (string.IsNullOrEmpty(name))
                return new te3eOjects.Edit.Entity.Entity { EntIndex = "" };

            string XOQL = string.Format(e3eEntityXML.GetEntityCPAXML, name.Replace("&", "&amp;"));

            string result = transvcGetArchetypeData(XOQL);

            if (result == null)
                return new te3eOjects.Edit.Entity.Entity { EntIndex = "" };

            te3eOjects.Edit.Entity.Data entityData = DeserializeXml<te3eOjects.Edit.Entity.Data>(result);
            te3eOjects.Edit.Entity.Entity entity = entityData.Entity.First(x => Convert.ToInt32(x.EntIndex) == entityData.Entity.Max(y => Convert.ToInt32(y.EntIndex)));

            return entity;
        }

        public te3eOjects.Edit.Entity.Entity GetEntityAdditionalRefSource(string name)
        {
            if (string.IsNullOrEmpty(name))
                return new te3eOjects.Edit.Entity.Entity { EntIndex = "" };

            string XOQL = string.Format(e3eEntityXML.GetEntityAdditionalRefSourceXML, name.Replace("&", "&amp;"));

            string result = transvcGetArchetypeData(XOQL);

            if (result == null)
                return new te3eOjects.Edit.Entity.Entity { EntIndex = "" };

            te3eOjects.Edit.Entity.Data entityData = DeserializeXml<te3eOjects.Edit.Entity.Data>(result);
            te3eOjects.Edit.Entity.Entity entity = entityData.Entity.First(x => Convert.ToInt32(x.EntIndex) == entityData.Entity.Max(y => Convert.ToInt32(y.EntIndex)));

            return entity;
        }

        public ActionsList GetActionList()
        {
            string result = "";

            if (_e3EServer == e3eServerEnv.UAT)
                result = transvcuat.GetActionsList();
            else if (_e3EServer == e3eServerEnv.DEV)
                result = transvcdev.GetActionsList();
            else if (_e3EServer == e3eServerEnv.STAGING)
                result = transvcstaging.GetActionsList();
            else if (_e3EServer == e3eServerEnv.PROD)
                result = transvcprod.GetActionsList();

            if (result == null)
                return null;

            ActionsList actionsList = DeserializeXml<ActionsList>(result);
            return actionsList;
        }

        private T DeserializeXml<T>(string xml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            StringReader stringReader = new StringReader(xml);
            T results = (T)serializer.Deserialize(stringReader);

            return results;
        }

        private string SerializeXml<T>(T e3eObj)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<T>), new XmlRootAttribute(typeof(T).Name));

            MemoryStream memStream;
            memStream = new MemoryStream();
            XmlTextWriter xmlWriter;
            xmlWriter = new XmlTextWriter(memStream, Encoding.UTF8);
            xmlWriter.Namespaces = true;

            serializer.Serialize(xmlWriter, e3eObj);

            xmlWriter.Close();
            memStream.Close();
            string xml;
            xml = Encoding.UTF8.GetString(memStream.GetBuffer());
            xml = xml.Substring(xml.IndexOf(Convert.ToChar(60)));
            xml = xml.Substring(0, (xml.LastIndexOf(Convert.ToChar(62)) + 1));

            return xml;
        }

        //public static string GetDescription(System.Enum value)
        //{
        //    var enumMember = value.GetType().GetMember(value.ToString()).FirstOrDefault();
        //    var descriptionAttribute =
        //        enumMember == null
        //            ? default(DescriptionAttribute)
        //            : enumMember.GetCustomAttribute(typeof(DescriptionAttribute)) as DescriptionAttribute;
        //    return
        //        descriptionAttribute == null
        //            ? value.ToString()
        //            : descriptionAttribute.Description;
        //}

        #region Helper

        public string TransvcExecuteProcess(string xmlString, int returnInfo)
        {
            xmlString = xmlString.XMLFixesEncode();
            if (_e3EServer == e3eServerEnv.UAT)
                return transvcuat.ExecuteProcess(xmlString, returnInfo);
            else if (_e3EServer == e3eServerEnv.DEV)
                return transvcdev.ExecuteProcess(xmlString, returnInfo);
            else if (_e3EServer == e3eServerEnv.STAGING)
                return transvcstaging.ExecuteProcess(xmlString, returnInfo);
            else if (_e3EServer == e3eServerEnv.PROD)
                return _tE3ELoginInfo.IsProdUpgradedVersion
                      ? transvcprodupgrade.ExecuteProcess(xmlString, returnInfo)
                      : transvcprod.ExecuteProcess(xmlString, returnInfo);

            return string.Empty;
        }

        private string transvcGetArchetypeData(string XOQL)
        {
            var result = string.Empty;
            if (_e3EServer == e3eServerEnv.UAT)
                result = transvcuat.GetArchetypeData(XOQL);
            else if (_e3EServer == e3eServerEnv.DEV)
                result = transvcdev.GetArchetypeData(XOQL);
            else if (_e3EServer == e3eServerEnv.STAGING)
                result = transvcstaging.GetArchetypeData(XOQL);
            else if (_e3EServer == e3eServerEnv.PROD)
                result = transvcprod.GetArchetypeData(XOQL);
            return result;
        }

        #endregion Helper
    }

    public class ProcessResults
    {
        public ProcessExecResult processExecutionResult { get; set; }

        public string message { get; set; } = "";
        public string processItemId { get; set; } = "";
        public List<string> xmlFiles { get; set; } = new List<string>();
        public string clientNumber { get; set; } = "";
        public string clientIndex { get; set; } = "";
        public string matterIndex { get; set; } = "";
        public string matterNumber { get; set; } = "";
        public string entityPersonId { get; set; } = "";
        public string entityOrgId { get; set; } = "";
        public int jobNumber { get; set; } = 0;
        public List<EntityIndexes> entityIndexes { get; set; } = new List<EntityIndexes>();
        public ProcessExecResult outputId { get; set; }
    }

    public class ProcessRawResultXml
    {
        public List<string> xmlFiles { get; set; } = new List<string>();
        public string result { get; set; } = "";
    }

    public class EntityIndexes
    {
        public string entityName { get; set; } = "";
        public string entityIndex { get; set; } = "";
        public EntityArchetypeCode entityArchetypeCode { get; set; }
    }

    public class TE3ELoginInfo
    {
        public bool IsDebug { get; set; }

        public bool IsProdUpgradedVersion { get; set; }

        public int SqlCommandTimeout { get; set; }

        public e3eServerEnv E3EServerEnv { get; set; }

        public string sUserName { get; set; }

        public string sPassword { get; set; }

        public string sDomain { get; set; }
        public EnvEnum OnPremQueueDBEnv { get; set; }

        public NetworkCredential NetCredential
        {
            get { return new NetworkCredential { UserName = sUserName, Password = sPassword, Domain = sDomain }; }
        }
    }

    public enum ProcessExecResult
    {
        Success = 0,
        Interface = 1,
        Failure = 2
    }

    public enum e3eServerEnv
    {
        DEV,
        UAT,
        PROD,
        STAGING
    }

    public enum e3eProcess
    {
        GeneralLedger,
        RateExceptionGroup,
        AddCollectionStep,
        CftNewBizIntake
    }

    public enum e3eMode
    {
        Add,
        Edit
    }

    public enum TE3EProcessSrvType
    {
        [Description("Matter")]
        Matter,

        [Description("EntityPerson")]
        EntityPerson,

        [Description("EntityOrg")]
        EntityOrg,

        [Description("Client")]
        Client,

        [Description("NBI")]
        NBI,

        [Description("Timekeeper")]
        Tkpr,

        [Description("NxUser")]
        NxUser,

        [Description("PurchaseOrder")]
        PO,
    }

    public enum AzQueueType
    {
        TE3EAssignment,
        KenticoAssignment,
        DynamicsCustomer,
        KenticoCustomer
    }
}