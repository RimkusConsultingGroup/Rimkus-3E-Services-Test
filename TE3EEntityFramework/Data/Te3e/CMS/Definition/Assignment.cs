using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using TE3EEntityFramework.Data.Te3e.CMS.CMS.Definition;

namespace TE3EEntityFramework.Data.Te3e.CMS.Definition
{
    public class Definitions
    {
        public Assignment Assignment { get; set; } = new Assignment();

        public IncidentLocation IncidentLocation { get; set; } = new IncidentLocation();

        public OpposingParty OpposingParty { get; set; } = new OpposingParty();

        public ReferenceNumber ReferenceNumber { get; set; } = new ReferenceNumber();

        public Party Party { get; set; } = new Party();

        public Payor Payor { get; set; } = new Payor();

        public CoConsultant Coconsultant { get; set; } = new CoConsultant();

        public CustomerProfile CustomerProfile { get; set; } = new CustomerProfile();
    }

    //public class PatchMessage
    //{
    //    public string objectType { get; set; }
    //    //enum:
    //    //- "assignment"
    //    //- "profile"
    //    public int e3EId { get; set; }
    //    public string kenticoId { get; set; }
    //    public object patch { get; set; }
    //}


    public class AssignmentList
    {
        public string CustomerId { get; set; }
        public string Status { get; set; }
        public string Search { get; set; }
        public int Limit { get; set; }
        public int Offset { get; set; }
        public int TotalResultCount { get; set; }
        public int FilteredResultCount { get; set; }
        public List<AssignmentListDetail> Assignments { get; set; } = new List<AssignmentListDetail>();
    }

    public class AssignmentNotes
    {
        public string AssignmentId { get; set; }
        public string CustomerId { get; set; }
        public string Search { get; set; }
        public string EventFilter { get; set; }
        public string EventDateFilter { get; set; }
        public string NoteFilter { get; set; }
        public int Limit { get; set; }
        public int Offset { get; set; }
        public int TotalResultCount { get; set; }
        public int FilteredResultCount { get; set; }
        public List<AssignmentNote> Notes { get; set; } = new List<AssignmentNote>();

    }

    public class AssignmentNote
    {
        public int E3EId { get; set; }

        public string MatterNumber { get; set; }

        public string MatterTitle { get; set; }

        public string NoteDescription { get; set; }

        public string EntryUser { get; set; }

        public string DateEntered { get; set; }

        public string Note { get; set; }
    }

    public class AssignmentListDetail
    {
        public string SubmissionID { get; set; }

        public string RequestDate { get; set; }

        public int E3EId { get; set; }

        public string MatterNumber { get; set; }

        public string MatterType { get; set; }

        public string MatterTitle { get; set; }

        public string OrderingClientNumber { get; set; }
        public string OrderingClientContactEmail { get; set; } = "";

        public string OrderingClientCompany { get; set; }

        public string OrderingClientCity { get; set; }

        public string OrderingClientState { get; set; }

        public string OrderingClientZip { get; set; }

        public string ClaimNumber { get; set; }

        public string DateOfOccurrence { get; set; }

        public string LocationOfOccurrence { get; set; }

        public string OccurrenceCity { get; set; }

        public string OccurrenceState { get; set; }

        public string OccurrenceZip { get; set; }

        public string MatterStatus { get; set; }

        public string LatestNote { get; set; }

        public string StatusDate { get; set; }
        public string OpenTimeKeeper { get; set; }
        public string ResponsibleTimeKeeper { get; set; }
        public string KenticoId { get; set; }
    }

    public class AssignmentDetail
    {
        public int E3EId { get; set; }

        public string MatterNumber { get; set; } = "";

        public string MatterTitle { get; set; } = "";

        public string MatterStatus { get; set; } = "";

        public string OrderingClientNumber { get; set; } = "";

        public string OrderingClientContactEmail { get; set; } = "";

        public string OrderingClientCompany { get; set; } = "";

        public string ClaimNumber { get; set; } = "";

        public string DateOfOccurrence { get; set; } = "";

        public string LocationOfOccurrence { get; set; } = "";

        public string ProjectManager { get; set; } = "";

        public string OfficePhone { get; set; } = "";

        public string CellPhone { get; set; } = "";

        public string Email { get; set; } = "";

        public string Budget { get; set; } = "";
        public string KenticoId { get; set; } = "";
    }

    public class Assignment
    {
        public int? E3EID { get; set; }
        public string KenticoID { get; set; } = "";
        public string MatterStatus { get; set; } = "";
        public string MatterStatusID { get; set; } = "";
        public string SubmissionId { get; set; } = "";

        //# Section: Client Contact
        public string OrderingClientContactSalutation { get; set; } = "";
        public string OrderingClientContactFirstName { get; set; } = "";
        public string OrderingClientContactLastName { get; set; } = "";
        public string OrderingClientContactEmail { get; set; } = "";
        public string OrderingClientContactPhoneNo { get; set; } = "";
        public string OrderingClientNumber { get; set; } = "";
        public string OrderingClientID { get; set; } = "";
        [JsonIgnore]
        public string OrderingClientPayorIndex { get; set; } = "";

        //# Section: Client Company
        public string OrderingClientCompanyName { get; set; } = "";
        public string OrderingClientCompanyAddress1 { get; set; } = "";
        public string OrderingClientCompanyAddress2 { get; set; } = "";
        public string OrderingClientCompanyAddressCity { get; set; } = "";
        public string OrderingClientCompanyAddressState { get; set; } = "";
        public string OrderingClientCompanyAddressZip { get; set; } = "";
        public string OrderingClientCompanyAddressCountry { get; set; } = "";
        [JsonIgnore]
        public string OrderingClientCompanyAddressLat { get; set; } = "";
        [JsonIgnore]
        public string OrderingClientCompanyAddressLon { get; set; } = "";
        public string OrderingClientCompanyType { get; set; } = "";
        //   "enum": [
        //"insurance",
        //"tpa",
        //"ia",
        //"attorney",
        //"corporation",
        //"government",
        //"other"
        //]
        [JsonIgnore]
        public string OrderingClientCompanyTypeDesc { get; set; } = "";

        //# Section: Incident Information
        public bool? IncidentYN { get; set; } = false;
        public string DateOccurence { get; set; } = "";
        public bool? DateUnknown { get; set; }
        public List<IncidentLocation> IncidentLocations { get; set; } = new List<IncidentLocation>();
        //"type": "array",
        //     "items": {
        //"$ref": "#/definitions/IncidentLocation"
        //}

        public string DescOccurence { get; set; } = "";
        public string NeedAnswered { get; set; } = "";
        public string SpecialInstructions { get; set; } = "";

        //# Section: Adjuster Information

        //Insurance Company
        public string LibertyInsuranceType { get; set; } = "";
        [JsonIgnore]
        public string LibertyInsuranceTypeDesc { get; set; } = "";
        public string LibertyClaimType { get; set; } = "";
        [JsonIgnore]
        public string LibertyClaimTypeDesc { get; set; } = "";
        public string AdjusterType { get; set; } = "";
        //   "enum": [
        //"self",
        //"outside",
        //"none"
        //]
        [JsonIgnore]
        public string AdjusterTypeDesc { get; set; } = "";
        public bool? AuthYN { get; set; } = false;
        public string OutsideCompName { get; set; } = "";
        public string OutsideFirstName { get; set; } = "";
        public string OutsideLastName { get; set; } = "";
        public string OutsideAdjEmail { get; set; } = "";
        public string OutsideAdjPhone { get; set; } = "";
        public string AdjusterInvoicing { get; set; } = "";
        //    "enum": [
        //"self",
        //"adjuster"
        //]
        public string OutsideAddr1 { get; set; } = "";
        public string OutsideAddr2 { get; set; } = "";
        public string OutsideCity { get; set; } = "";
        public string OutsideState { get; set; } = "";
        public string OutsideZip { get; set; } = "";
        public string OutsideCountry { get; set; } = "";
        public string ParaFirstName { get; set; } = "";
        public string ParaLastName { get; set; } = "";
        public string RepType { get; set; } = "";
        //   "enum": [
        //"defendant",
        //"plaintiff",
        //"subrogation",
        //"na"
        //]
        [JsonIgnore]
        public string RepTypeDesc { get; set; } = "";
        public string LegalClientType { get; set; } = "";
        //    "enum": [
        //"individual",
        //"company",
        //"government"
        //]
        [JsonIgnore]
        public string LegalClientTypeDesc { get; set; } = "";
        public string InsFirstName { get; set; } = "";
        public string InsLastName { get; set; } = "";
        public string InsPOCNo { get; set; } = "";
        public string InsPOC { get; set; } = "";
        public string InsNo { get; set; } = "";
        public string InsClientName { get; set; } = "";
        public string InsLegalPOC { get; set; } = "";
        public string InsLegalPOCNo { get; set; } = "";
        public bool? OpposingYN { get; set; } = false;
        public string OppName { get; set; } = "";
        public string OppAttyFirstName { get; set; } = "";
        public string OppAttyLastName { get; set; } = "";
        public string OppStreetAddr1 { get; set; } = "";
        public string OppStreetAddr2 { get; set; } = "";
        public string OppCity { get; set; } = "";
        public string OppState { get; set; } = "";
        public string OppZip { get; set; } = "";
        public string OppCountry { get; set; } = "";
        public List<OpposingParty> OpposingParties { get; set; } = new List<OpposingParty>();
        //    "type": "array",
        //"items": {
        //"$ref": "#/definitions/OpposingParty"
        //}
        public bool? SuitYN { get; set; } = false;
        public string CauseNumber { get; set; } = "";
        public string Court { get; set; } = "";
        public string Style { get; set; } = "";

        //# Section: Reference Numbers
        public List<ReferenceNumber> ReferenceNumbers { get; set; } = new List<ReferenceNumber>();

        public List<Party> Parties { get; set; } = new List<Party>();
        //    "type": "array",
        //"items": {
        //"$ref": "#/definitions/Party"
        //}

        //# Section: Multipayor Information
        public bool? MultipayorYN { get; set; } = false;
        public string MultipayorInvoicing { get; set; } = "";
        //    "enum": [
        //"invoice",
        //"allocate",
        //"schedule"
        //]

        public List<Payor> Payors { get; set; } = new List<Payor>();
        //    "type": "array",
        //"items": {
        //"$ref": "#/definitions/Payor"
        //}

        //# Section: Invoice Instructions
        public string SpecialInvoice { get; set; } = "";

        //# Section: Internal Use Only
        public string MatterName { get; set; } = "";
        public string MatterNumber { get; set; } = "";
        public string RelatedMatter { get; set; } = "";
        public string RelatedMatterName { get; set; } = "";
        public string Currency { get; set; } = "";
        [JsonIgnore]
        public string CurrencyDesc { get; set; } = "";
        public string OpenTimekeeper { get; set; } = "";
        public string OpenTimekeeperName { get; set; } = "";
        public string RetainerAmount { get; set; } = "";
        public bool? FixedPrice { get; set; }
        public string DneNotes { get; set; } = "";
        public bool? WebOriginated { get; set; }
        public string FeesTaxCode { get; set; } = "";
        [JsonIgnore]
        public string FeesTaxCodeDesc { get; set; } = "";
        public string EntryDate { get; set; } = "";
        public bool? EBilling { get; set; }
        public string EBillingType { get; set; } = "";
        //   "type": "string",
        //"enum": [
        //"Legal-X",
        //"Tymetrix 360"
        //]
        [JsonIgnore]
        public string EBillingTypeDesc { get; set; } = "";
        public string ElectronicNumber { get; set; } = "";
        public string ConfirmationLetterType { get; set; } = "";
        //    "enum": [
        //"Standard",
        //"Legal",
        //"Natonal Agreement",
        //"CAT",
        //"Engineering Services",
        //"Retainer",
        //"Signature"
        //]
        [JsonIgnore]
        public string ConfirmationLetterTypeDesc { get; set; } = "";
        public string RofTemplate { get; set; } = "";
        [JsonIgnore]
        public string RofTemplateDesc { get; set; } = "";
        public string StartDate1 { get; set; } = "";
        public string BillingTimekeeper { get; set; } = "";
        public string BillingTimekeeperName { get; set; } = "";
        public string ResponsibleTimekeeper { get; set; } = "";
        public string ResponsibleTimekeeperName { get; set; } = "";
        public string SupervisingTimekeeper { get; set; } = "";
        public string SupervisingTimekeeperName { get; set; } = "";
        public string Office { get; set; } = "";
        //    "enum": [
        //"All Offices",
        //"CAT and Profit Centers"
        //]
        [JsonIgnore]
        public string OfficeDesc { get; set; } = "";
        public string Section { get; set; } = "";
        [JsonIgnore]
        public string SectionDesc { get; set; } = "";
        public string Arrangement { get; set; } = "";
        //enum:
        //- "Flat Fee"
        //- "Hourly"
        [JsonIgnore]
        public string ArrangementDesc { get; set; } = "";
        public string Department { get; set; } = "";
        [JsonIgnore]
        public string DepartmentDesc { get; set; } = "";
        public string PracticeGroup { get; set; } = "";
        //    "enum": [
        //"Commercial - 1st Party",
        //"Commercial - 3rd Party",
        //"Default",
        //"Personal Lines - 1st Party",
        //"Personal Lines - 3rd Party",
        //"Undefined"
        //]
        [JsonIgnore]
        public string PracticeGroupDesc { get; set; } = "";
        public string Pta1 { get; set; } = "";
        [JsonIgnore]
        public string Pta1Desc { get; set; } = "";
        public string IndustryGroup { get; set; } = "";
        [JsonIgnore]
        public string IndustryGroupDesc { get; set; } = "";
        [JsonIgnore]
        public string TechRevEngRecID { get; set; } = "";
        public string TechnicalReviewerNumber { get; set; } = "";
        public string TechnicalReviewerName { get; set; } = "";
        public string EngineerOfRecordNumber { get; set; } = "";
        public string EngineerOfRecordName { get; set; } = "";
        public string BdManagerNumber { get; set; } = "";
        public string BdManagerName { get; set; } = "";
        public bool? CoConsultantsYN { get; set; } = false;
        public List<CoConsultant> CoConsultants { get; set; } = new List<CoConsultant>();
        //    "type": "array",
        //"items": {
        //"$ref": "#/definitions/CoConsultant"
        //}
        public string StartDate2 { get; set; } = "";
        public string SpecialClientInstruction { get; set; } = "";
        [JsonIgnore]
        public string SpecialClientInstructionDesc { get; set; } = "";
        public string Rate { get; set; } = "";
        //     "enum": [
        //"Investigative",
        //"Investigative-Canada",
        //"Investigative-London",
        //"Legal",
        //"Legal - Canada",
        //"Legal - London"
        //]
        [JsonIgnore]
        public string RateDesc { get; set; } = "";
        public string RateExceptGroup { get; set; } = "";
        [JsonIgnore]
        public string RateExceptGroupDesc { get; set; } = "";
        public string TimeType { get; set; } = "";
        [JsonIgnore]
        public string TimeTypeDesc { get; set; } = "";
        public string FlatFeeAmount { get; set; } = "";
        public string Budget { get; set; } = "";
        public string ReportEmail { get; set; } = "";
    }
}
