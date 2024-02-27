using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TE3EEntityFramework.Data.KenticoCMS.RCGKENTCMS;

namespace TE3EConnect.te3eObjects.Automation
{
    public class MatterSrv
    {
        public string MatterIndex { get; set; }
        public string LoadSource { get; set; }
        public string DisplayName { get; set; }
        public string Client { get; set; }
        public string MStatus { get; set; }
        public string MattStatusDate { get; set; }
        public string OpenDate { get; set; }
        public string OpenTkpr { get; set; }
        public string Narrative { get; set; }
        public string DateOfOccurence_CCC { get; set; }
        public string IsProspective_CCC { get; set; }
        public string TimeTaxCode { get; set; }
        public string RetainerAmount_CCC { get; set; }
        public string ScopeOfWork_CCC { get; set; }
        public string IsFixedPrice_CCC { get; set; }
        public string DNENotes_CCC { get; set; }
        public string IsWeb_CCC { get; set; }
        public string EntryDate { get; set; }
        public string IsEBill { get; set; }
        public string ElecBillingType { get; set; }
        public string ElecNumber { get; set; }
        public string IsConfLetterCAT_CCC { get; set; }
        public string IsConfLetterEngSvcs_CCC { get; set; }
        public string IsConfLetterLegal_CCC { get; set; }
        public string IsConfLetterNatAgmt_CCC { get; set; }
        public string IsConfLetterRtnr_CCC { get; set; }
        public string IsConfLetterSign_CCC { get; set; }
        public string IsConfLetterStd_CCC { get; set; }
        public string ReportOfFindings_CCC { get; set; }
        public string ReportingOffice_CCC { get; set; }
        public MatterRate MatterRate { get; set; }
        public MatterRateExc MatterRateExc { get; set; }
        public MatterBudget MatterBudget { get; set; }
        public MatterFlatFee MatterFlatFee { get; set; }
        public List<MattDate> mattDates { get; set; }
        public List<MattSite> mattSites { get; set; }
        public MattIndustryGroup mattIndustryGroup { get; set; }
        public MattPayor mattPayor { get; set; }
        public List<MattPayorDetail> mattPayorDetails { get; set; }
        public List<RelatedParties_CCC> relatedParties_CCCs { get; set; }
        public TechRevEngRec_CCC techRevEngRec_CCC { get; set; }
        public List<CoConsultants_CCC> coConsultants_CCCs { get; set; }
        public MatterSpecialInstructions_CCC matterSpecialInstructions_CCC { get; set; }
        public List<MatterSpecialInvoiceTo_CCC> matterSpecialInvoiceTo_CCC { get; set; }
    }

    public class MatterBudget
    {
        public string MattBudgetIndex { get; set; }
        public string BudAmount { get; set; }
    }

    public class MatterFlatFee
    {
        public string MattFlatFeeIndex { get; set; }
        public string FlatFeeAmount { get; set; }
        public string TimeType { get; set; }
    }

    public class MatterRate
    {
        public string MattRateIndex { get; set; }
        public string MattRate { get; set; }
        public string IsActive { get; set; }
    }

    public class MatterRateExc
    {
        public string MattRateExcIndex { get; set; }
        public string MattRateExc { get; set; }
    }

    public class MattDate
    {
        public string MattDateIndex { get; set; }
        public string EffStart { get; set; }
        public string NxStartDate { get; set; }
        public string PracticeGroup { get; set; }
        public string Department { get; set; }
        public string Section { get; set; }
        public string Arrangement { get; set; }
        public string PTAGroup { get; set; }
        public string BillTkpr { get; set; }
        public string RspTkpr { get; set; }
        public string SpvTkpr { get; set; }
        public string Office { get; set; }
        public string SubSection_CCC { get; set; }
    }

    public class MattSite
    {
        public string MattSiteIndex { get; set; }
        public string MSite { get; set; }
        public string MattSiteType { get; set; }
        public SvcOps SvcOp { get; set; }
    }

    public class MattIndustryGroup
    {
        public string IndustryGroupIndex { get; set; }
        public string IndustryGroup { get; set; }
    }

    public class MattPayor
    {
        public string MattPayorIndex { get; set; }
        public string StartDate { get; set; }
        public string CauseNum_CCC { get; set; }
        public string Court_CCC { get; set; }
        public string Representing_CCC { get; set; }
        public string Style_CCC { get; set; }

    }

    public class MattPayorDetail
    {
        public string MattPayorDetailIndex { get; set; }
        public string PctFee { get; set; }
        public string CftRole_CCC { get; set; }
        public string CftRelationship_CCC { get; set; }
        public string PayorIndex { get; set; }
        public string Email_CCC { get; set; } = "";
        public string Contact_CCC { get; set; } = "";
        public string PhoneNum_CCC { get; set; } = "";
        public string RefNumber { get; set; } = "";
        public string ClaimNum_CCC { get; set; } = "";
        public string GovernmentType_CCC { get; set; } = "";
        public string CorpType_CCC { get; set; } = "";
        public string Title_CCC { get; set; } = "";
        public string AddtlContactInfo_CCC { get; set; } = "";
        public string PONumber_CCC { get; set; } = "";
        public string Policy_CCC { get; set; } = "";
        public string UMR_CCC { get; set; } = "";
        public string File_CCC { get; set; } = "";
        public string Tracking_CCC { get; set; } = "";
        public string PSite { get; set; }
        public string StmtSite { get; set; }
        public string IsDefault { get; set; }
        public SvcOps SvcOp { get; set; }
    }

    public class RelatedParties_CCC
    {
        public string RelatedPartiesIndex { get; set; }
        public string RelatedPartiesCftRole { get; set; }
        public string RelatedPartiesEntity { get; set; }
        public SvcOps SvcOp { get; set; }
        public string WorkPhone { get; set; }
    }
    public class TechRevEngRec_CCC
    {
        public string TechRevEngRecIndex { get; set; }
        public string EngineerOfRecord { get; set; }
        public string TechincalReviewer { get; set; }
        public string Marketer { get; set; }
    }
    public class CoConsultants_CCC
    {
        public string CoConsultantIndex { get; set; }
        public string CoConsultant { get; set; }
        public SvcOps SvcOp { get; set; }
    }
    public class MatterSpecialInstructions_CCC
    {
        public string MSClientIndex { get; set; }
        public string MSClient { get; set; }
        public string ClientInstr { get; set; }
        public string AdditionalInstr { get; set; }
        public string MSStartDate { get; set; }
        public string MSEffDate { get; set; }
        public string MSEndDate { get; set; }
        public string ReportsTo { get; set; }
    }

    public class MatterSpecialInvoiceTo_CCC
    {
        public string MatterSpecialInvoiceToIndex { get; set; }
        public string InvoiceTo { get; set; }
    }
}
