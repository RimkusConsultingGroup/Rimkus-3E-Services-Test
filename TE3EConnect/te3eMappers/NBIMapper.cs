using System.Text;
using TE3EConnect.extension;
using TE3EConnect.te3eXML;

namespace TE3EConnect.te3eMappers
{
    internal class NBIMapper
    {
        public static string ConvertAddMatterSrvToXml(e3eMatterSrv e3EMatterSrv)
        {
            string mattSrvXml = e3eMatterSrvXML.AddMatterSrvXml
                                          .Replace("@MattStatusDate", e3EMatterSrv.matterSrv.MattStatusDate)
                                          .Replace("@MattStatus", e3EMatterSrv.matterSrv.MattStatus)
                                          .Replace("@DisplayName", e3eExtension.FixXMLString(e3EMatterSrv.matterSrv.DisplayName))
                                          .Replace("@Client", e3EMatterSrv.matterSrv.Client)
                                          .Replace("@OpenTkpr", e3EMatterSrv.matterSrv.OpenTkpr)
                                          .Replace("@OpenDate", e3EMatterSrv.matterSrv.OpenDate)
                                          .Replace("@MattType", e3EMatterSrv.matterSrv.MattType)
                                          .Replace("@MattAttribute", e3EMatterSrv.matterSrv.MattAttribute)
                                          .Replace("@MattCategory", e3EMatterSrv.matterSrv.MattCategory)
                                          .Replace("@IsEvergreen_CCC", e3EMatterSrv.matterSrv.IsEvergreen_CCC)
                                          .Replace("@Month_CCC", e3EMatterSrv.matterSrv.Month_CCC)
                                          .Replace("@Day_CCC", e3EMatterSrv.matterSrv.Day_CCC)
                                          .Replace("@EngType_CCC", e3EMatterSrv.matterSrv.EngType_CCC)
                                          .Replace("@Description", e3EMatterSrv.matterSrv.Description)
                                          .Replace("@EngStatus_CCC", e3EMatterSrv.matterSrv.EngStatus_CCC)
                                          .Replace("@EngSignedDate_CCC", e3EMatterSrv.matterSrv.EngSignedDate_CCC)
                                          .Replace("@OpportunityID_CCC", e3EMatterSrv.matterSrv.OpportunityID_CCC)
                                          .Replace("@BillingFrequency", e3EMatterSrv.matterSrv.BillingFrequency)
                                          .Replace("@CurrencyDateList", e3EMatterSrv.matterSrv.CurrencyDateList)
                                          .Replace("@Currency", e3EMatterSrv.matterSrv.Currency)
                                          .Replace("@TimeIncrement", e3EMatterSrv.matterSrv.TimeIncrement)
                                          .Replace("@PaymentTermsInfo", e3EMatterSrv.matterSrv.PaymentTermsInfo)
                                          .Replace("@Language", e3EMatterSrv.matterSrv.Language)
                                          .Replace("@IsAutoNumbering", e3EMatterSrv.matterSrv.IsAutoNumbering)
                                          .Replace("@IsMaster", e3EMatterSrv.matterSrv.IsMaster);

            return mattSrvXml;
        }

        public static string ConvertEditMatterSrvToXml(e3eMatterSrv e3EMatterSrv)
        {
            string mattSrvXml = e3eMatterSrvXML.EditMatterXML
                                          .Replace("@KeyValue", e3EMatterSrv.matterSrv.MattIndex);

            return mattSrvXml;
        }

        public static string ConvertMattDateToXml(e3eMatterSrv e3EMatterSrv)
        {
            string mattDate = e3eMatterSrvXML.AddMattDate
                                          .Replace("@EffStart", e3EMatterSrv.mattDate.EffStart)
                                          .Replace("@BillTkpr", e3EMatterSrv.mattDate.BillTkpr)
                                          .Replace("@RspTkpr", e3EMatterSrv.mattDate.RspTkpr)
                                          .Replace("@SpvTkpr", e3EMatterSrv.mattDate.SpvTkpr)
                                          .Replace("@Office", e3EMatterSrv.mattDate.Office)
                                          .Replace("@PTAGroup2", e3EMatterSrv.mattDate.PTAGroup2)
                                          .Replace("@PTAGroup", e3EMatterSrv.mattDate.PTAGroup)
                                          .Replace("@Department", e3EMatterSrv.mattDate.Department)
                                          .Replace("@Section", e3EMatterSrv.mattDate.Section)
                                          .Replace("@PracticeGroup", e3EMatterSrv.mattDate.PracticeGroup)
                                          .Replace("@Arrangement", e3EMatterSrv.mattDate.Arrangement);

            string mattOrgTimekpr = e3eMatterSrvXML.AddMattOrgTkpr
                                          .Replace("@Timekeeper", e3EMatterSrv.mattOrgTkpr.Timekeeper)
                                          .Replace("@Percentage", e3EMatterSrv.mattOrgTkpr.Percentage)
                                          .Replace("@IsPrimary", e3EMatterSrv.mattOrgTkpr.IsPrimary);

            string mattPrlTimekpr = e3eMatterSrvXML.AddMattPrlfTkpr
                                          .Replace("@Timekeeper", e3EMatterSrv.mattPrlfTkpr.Timekeeper)
                                          .Replace("@Percentage", e3EMatterSrv.mattPrlfTkpr.Percentage)
                                          .Replace("@IsPrimary", e3EMatterSrv.mattPrlfTkpr.IsPrimary);

            string addMattDateXml = mattDate.Replace("@AddMattOrgTkpr", mattOrgTimekpr)
                                            .Replace("@AddMattPrlfTkpr", string.IsNullOrEmpty(e3EMatterSrv.mattPrlfTkpr.Timekeeper) ? "" : mattPrlTimekpr);

            return addMattDateXml;
        }

        public static string ConvertAddpGDetHdr_CCCToXml(e3eMatterSrv e3EMatterSrv)
        {
            string pgDetHdr_CCC = e3eMatterSrvXML.AddPGDetHdr_CCC
                                          .Replace("@EffStart", e3EMatterSrv.pGDetHdr_CCC.EffStart)
                                          .Replace("@FeeCapPct", e3EMatterSrv.pGDetHdr_CCC.FeeCapPct)
                                          .Replace("@FeeCapFixed", e3EMatterSrv.pGDetHdr_CCC.FeeCapFixed)
                                          .Replace("@OrigWIP", e3EMatterSrv.pGDetHdr_CCC.OrigWIP)
                                          .Replace("@CreditEstHigh", e3EMatterSrv.pGDetHdr_CCC.CreditEstHigh)
                                          .Replace("@CreditEstLow", e3EMatterSrv.pGDetHdr_CCC.CreditEstLow)
                                          .Replace("@BA_Notes_CCC", e3EMatterSrv.pGDetHdr_CCC.BA_Notes_CCC);

            StringBuilder sb = new StringBuilder();

            foreach (PGDetChild_CCC pgDet in e3EMatterSrv.pGDetChild_CCCs)
            {
                string pgDetChildXml = e3eMatterSrvXML.AddPGDetChild_CCC
                                          .Replace("@Year", pgDet.Year)
                                          .Replace("@IsFederal", pgDet.IsFederal)
                                          .Replace("@State", pgDet.State)
                                          .Replace("@OrigCredit", pgDet.OrigCredit)
                                          .Replace("@Adjustments", pgDet.Adjustments)
                                          //.Replace("@Total", pgDet.Total)
                                          .Replace("@Comments", pgDet.Comments);

                sb.AppendLine(pgDetChildXml);
            }

            string addPGDetChild_CCCXml = e3eMatterSrvXML.PGDetChild_CCC.Replace("@AddPGDetChild_CCC", sb.ToString());
            string addPGDetHdr_CCCXml = pgDetHdr_CCC.Replace("@PGDetChild_CCC", addPGDetChild_CCCXml);

            return addPGDetHdr_CCCXml;
        }

        public static string ConvertEditpGDetHdr_CCCToXml(e3eMatterSrv e3EMatterSrv)
        {
            string pgDetHdr_CCC = e3eMatterSrvXML.EditPGDetHdr_CCC.Replace("@KeyValue", e3EMatterSrv.pGDetHdr_CCC.KeyValue.Trim());

            StringBuilder sb = new StringBuilder();

            foreach (PGDetChild_CCC pgDet in e3EMatterSrv.pGDetChild_CCCs)
            {
                string pgDetChildXml = e3eMatterSrvXML.EditPGDetChild_CCC
                                          .Replace("@KeyValue", pgDet.KeyValue.Trim())
                                          .Replace("@Adjustments", pgDet.Adjustments)
                                          .Replace("@Comments", pgDet.Comments);

                sb.AppendLine(pgDetChildXml);
            }

            string editPGDetChild_CCCXml = e3eMatterSrvXML.edPGDetChild_CCC.Replace("@EditPGDetChild_CCC", sb.ToString());
            string editPGDetHdr_CCCXml = pgDetHdr_CCC.Replace("@edPGDetChild_CCC", editPGDetChild_CCCXml);

            return editPGDetHdr_CCCXml;
        }

        public static string ConverAssociatedTkprs_CCCToXml(e3eMatterSrv e3EMatterSrv)
        {
            string associateTkprs_CCC = e3eMatterSrvXML.AddAssociateTkprs_CCC
                                          .Replace("@EffStart", e3EMatterSrv.associatedTkprs_CCC.EffStart)
                                          .Replace("@BDTkpr1", e3EMatterSrv.associatedTkprs_CCC.BDTkpr1)
                                          .Replace("@BDTkprPct1", e3EMatterSrv.associatedTkprs_CCC.BDTkprPct1)
                                          .Replace("@BDTkpr2", e3EMatterSrv.associatedTkprs_CCC.BDTkpr2)
                                          .Replace("@BDTkprPct2", e3EMatterSrv.associatedTkprs_CCC.BDTkprPct2)
                                          .Replace("@BDTkpr3", e3EMatterSrv.associatedTkprs_CCC.BDTkpr3)
                                          .Replace("@BDTkprPct3", e3EMatterSrv.associatedTkprs_CCC.BDTkprPct3)
                                          .Replace("@SOETkpr1", e3EMatterSrv.associatedTkprs_CCC.SOETkpr1)
                                          .Replace("@SOETkprPct1", e3EMatterSrv.associatedTkprs_CCC.SOETkprPct1)
                                          .Replace("@SOETkpr2", e3EMatterSrv.associatedTkprs_CCC.SOETkpr2)
                                          .Replace("@SOETkprPct2", e3EMatterSrv.associatedTkprs_CCC.SOETkprPct2)
                                          .Replace("@SOETkpr3", e3EMatterSrv.associatedTkprs_CCC.SOETkpr3)
                                          .Replace("@SOETkprPct3", e3EMatterSrv.associatedTkprs_CCC.SOETkprPct3)
                                          .Replace("@FUSOETkprPct", e3EMatterSrv.associatedTkprs_CCC.FUSOETkprPct)
                                          .Replace("@FUSOETkpr", e3EMatterSrv.associatedTkprs_CCC.FUSOETkpr)
                                          .Replace("@AlliancePct", e3EMatterSrv.associatedTkprs_CCC.AlliancePct)
                                          .Replace("@Alliance", e3EMatterSrv.associatedTkprs_CCC.Alliance)
                                          .Replace("@RefSource1", e3EMatterSrv.associatedTkprs_CCC.RefSource1)
                                          .Replace("@RefSourcePct1", e3EMatterSrv.associatedTkprs_CCC.RefSourcePct1)
                                          .Replace("@RefSource2", e3EMatterSrv.associatedTkprs_CCC.RefSource2)
                                          .Replace("@RefSourcePct2", e3EMatterSrv.associatedTkprs_CCC.RefSourcePct2)
                                          .Replace("@Comments", e3EMatterSrv.associatedTkprs_CCC.Comments);

            StringBuilder sb = new StringBuilder();

            foreach (CPADetails_CCC cPADetails in e3EMatterSrv.cPADetails_CCCs)
            {
                string cPADetailsXml = e3eMatterSrvXML.AddCPADetails_CCC
                                          .Replace("@CPAFirm", cPADetails.CPAFirm)
                                          .Replace("@CPAEntity", cPADetails.CPAEntity)
                                          .Replace("@CPAType", cPADetails.CPAType)
                                          .Replace("@CPAPct", cPADetails.CPAPct);

                sb.AppendLine(cPADetailsXml);
            }

            string addCPADetails_CCCXml = e3eMatterSrvXML.CPADetails_CCC.Replace("@AddCPADetails_CCC", sb.ToString());
            string addAssociateTkprs_CCCXml = associateTkprs_CCC.Replace("@CPADetails_CCC", string.IsNullOrEmpty(sb.ToString()) ? "" : addCPADetails_CCCXml);

            return addAssociateTkprs_CCCXml;
        }

        public static string ConvertSalesforceInfoToXml(e3eMatterSrv e3EMatterSrv)
        {
            string salesforceInfo_CCCXml = e3eMatterSrvXML.AddSalesForceInfo_CCC
                                          .Replace("@EffStart", e3EMatterSrv.salesForceInfo_CCC.EffStart)
                                          .Replace("@AdditionalRefSource", e3EMatterSrv.salesForceInfo_CCC.AdditionalRefSource)
                                          .Replace("@StudyInfoEntityType", e3EMatterSrv.salesForceInfo_CCC.StudyInfoEntityType)
                                          .Replace("@StudyInfoFedStudyYears", e3EMatterSrv.salesForceInfo_CCC.StudyInfoFedStudyYears)
                                          .Replace("@StudyInfoFiscalYearEnd", e3EMatterSrv.salesForceInfo_CCC.StudyInfoFiscalYearEnd)
                                          .Replace("@StudyInfoStateStudyYears", e3EMatterSrv.salesForceInfo_CCC.StudyInfoStateStudyYears)
                                          .Replace("@StudyInfoStates", e3EMatterSrv.salesForceInfo_CCC.StudyInfoStates);

            return salesforceInfo_CCCXml;
        }

        public static string ConvertMattRateToXml(e3eMatterSrv e3EMatterSrv)
        {
            string mattRateXml = e3eMatterSrvXML.AddMattRate
                                          .Replace("@Rate", e3EMatterSrv.mattRate.Rate);

            return mattRateXml;
        }

        public static string ConvertMattRateExcToXml(e3eMatterSrv e3EMatterSrv)
        {
            string mattRateXml = e3eMatterSrvXML.AddMatterRateExc
                                          .Replace("@RateExc", e3EMatterSrv.mattRateExc.RateExc)
                                          .Replace("@StartDate", e3EMatterSrv.mattRateExc.StartDate);

            return mattRateXml;
        }
    }
}