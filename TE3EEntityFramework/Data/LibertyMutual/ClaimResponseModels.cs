using System;
using System.Collections.Generic;

namespace TE3EEntityFramework.Data.LibertyMutual
{
    // LM_ClaimSummary myDeserializedClass = JsonConvert.DeserializeObject<LM_ClaimSummary>(myJsonResponse); 

    public class LM_Node
    {
        public string Name { get; set; }
        public string Type { get; set; }
    }

    public class LM_ItemDatabase
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public List<LM_Node> Nodes { get; set; }
    }

    public class LM_GuestCompany
    {
        public string CompanyName { get; set; }
        public string ParticipantGuestCompanyType { get; set; }
    }

    public class LM_Address
    {
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
    }

    public class LM_TaxInfo
    {
        public bool? UseTax1 { get; set; }
        public string Tax1Name { get; set; }
        public bool? ApplyTax1ToMaterials { get; set; }
        public bool? ApplyTax1ToLabor { get; set; }
        public bool? ApplyTax1ToEquipment { get; set; }
        public bool? ApplyTax1ToMarketConditions { get; set; }
        public bool? ApplyTax1ToOverheadAndProfit { get; set; }
        public bool? IsTax1OverriddenForSomeItems { get; set; }
        public bool? UseTax2 { get; set; }
        public string Tax2Name { get; set; }
        public bool? ApplyTax2ToMaterials { get; set; }
        public bool? ApplyTax2ToLabor { get; set; }
        public bool? ApplyTax2ToEquipment { get; set; }
        public bool? ApplyTax2ToMarketConditions { get; set; }
        public bool? ApplyTax2ToOverheadAndProfit { get; set; }
        public bool? IsTax2OverriddenForSomeItems { get; set; }
        public bool? UseTax3 { get; set; }
        public string Tax3Name { get; set; }
        public bool? ApplyTax3ToMaterials { get; set; }
        public bool? ApplyTax3ToLabor { get; set; }
        public bool? ApplyTax3ToEquipment { get; set; }
        public bool? ApplyTax3ToMarketConditions { get; set; }
        public bool? ApplyTax3ToOverheadAndProfit { get; set; }
        public bool? IsTax3OverriddenForSomeItems { get; set; }
        public bool? UseTax4 { get; set; }
        public string Tax4Name { get; set; }
        public bool? ApplyTax4ToMaterials { get; set; }
        public bool? ApplyTax4ToLabor { get; set; }
        public bool? ApplyTax4ToEquipment { get; set; }
        public bool? ApplyTax4ToMarketConditions { get; set; }
        public bool? ApplyTax4ToOverheadAndProfit { get; set; }
        public bool? IsTax4OverriddenForSomeItems { get; set; }
        public bool? CumulativeTaxes { get; set; }
        public double? Tax1Rate { get; set; }
        public double? Tax2Rate { get; set; }
        public double? Tax3Rate { get; set; }
        public double? Tax4Rate { get; set; }
    }

    public class LM_OverheadAndProfitInfo
    {
        public bool? CumulativeOverheadProfit { get; set; }
        public bool? CalculateOverheadProfitOnTotalCost { get; set; }
        public double? OverheadRate { get; set; }
        public double? ProfitRate { get; set; }
    }

    public class LM_ContentsOverheadAndProfitInfo
    {
        public bool? CumulativeOverheadProfit { get; set; }
        public bool? CalculateOverheadProfitOnTotalCost { get; set; }
        public double? OverheadRate { get; set; }
        public double? ProfitRate { get; set; }
    }

    public class LM_MinimumCharge
    {
        public bool? UseMinimumChargeAdjustments { get; set; }
        public string MinimumChargeType { get; set; }
        public bool? ApplyOverheadAndProfitToMinimumCharge { get; set; }
        public bool? ApplyTaxesToMinimumCharge { get; set; }
    }

    public class LM_ClaimSubcoverage
    {
        public string Type { get; set; }
        public double? Sublimit { get; set; }
        public string SublimitType { get; set; }
        public double? SublimitMinimumAmount { get; set; }
    }

    public class LM_Coverage
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public bool? RecoverableDepreciation { get; set; }
        public bool? Default { get; set; }
        public string DeductibleType { get; set; }
        public List<LM_ClaimSubcoverage> ClaimSubcoverages { get; set; }
        public double? Reserve { get; set; }
        public double? Limits { get; set; }
        public double? Deductible { get; set; }
        public double? DeductibleMinimumAmount { get; set; }
        public double? DeductibleMaximumRate { get; set; }
    }

    public class LM_CustomField
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }

    public class LM_User
    {
        public string LoginName { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserGroup { get; set; }
        public string Role { get; set; }
        public string HeadOfficeCompanyID { get; set; }
        public string CompanyID { get; set; }
        public string ExternalSystemCompanyCode { get; set; }
        public string CompanyName { get; set; }
        public string UserRole { get; set; }
        public string Phone { get; set; }
        public string AssigneeStatus { get; set; }
    }

    public class LM_Company
    {
        public string CompanyType { get; set; }
        public string HeadOfficeCompanyID { get; set; }
        public string CompanyID { get; set; }
        public string ExternalSystemCompanyCode { get; set; }
        public string CompanyName { get; set; }
        public string ContactFirstName { get; set; }
        public string ContactLastName { get; set; }
        public string Phone { get; set; }
        public string MobilePhone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public LM_Address Address { get; set; }
        public List<LM_User> Users { get; set; }
    }

    public class LM_InsuredContact
    {
        public LM_Company Company { get; set; }
        public LM_User User { get; set; }
        public string DisplayName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }

    public class LM_UploadStatus
    {
        public bool? PhotosUploaded { get; set; }
    }

    public class LM_Assignment
    {
        public double? AssignmentID { get; set; }
        public double? ParentAssignmentID { get; set; }
        public string Name { get; set; }
        public string FriendlyName { get; set; }
        public string AssignmentTypeCode { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }
        public LM_Company AssignedBy { get; set; }
        public LM_Company Assignee { get; set; }
        public LM_User doubleernalAssignee { get; set; }
        public DateTime? AssignmentSentDate { get; set; }
        public DateTime? AssignmentReceivedDate { get; set; }
        public DateTime? InsuredContactedDate { get; set; }
        public DateTime? InsuredContactedUserDate { get; set; }
        public DateTime? InspectionScheduledDate { get; set; }
        public DateTime? InspectionScheduledUserDate { get; set; }
        public DateTime? InspectionAppodoublementDate { get; set; }
        public DateTime? InspectionPerformedDate { get; set; }
        public DateTime? InspectionPerformedUserDate { get; set; }
        public DateTime? MitigationWorkStartedDate { get; set; }
        public DateTime? MitigationWorkStartedUserDate { get; set; }
        public DateTime? MitigationWorkCompletedDate { get; set; }
        public DateTime? MitigationWorkCompletedUserDate { get; set; }
        public DateTime? EstimateReadyForReviewDate { get; set; }
        public DateTime? EstimateCompletedDate { get; set; }
        public DateTime? EstimateApprovedDate { get; set; }
        public DateTime? JobScheduledDate { get; set; }
        public DateTime? JobScheduledUserDate { get; set; }
        public DateTime? JobNotSoldDate { get; set; }
        public DateTime? JobStartedDate { get; set; }
        public DateTime? JobStartedUserDate { get; set; }
        public DateTime? JobCompletedDate { get; set; }
        public DateTime? JobCompletedUserDate { get; set; }
        public DateTime? JobScheduledJobStartDate { get; set; }
        public DateTime? JobScheduledJobCompleteDate { get; set; }
        public DateTime? AssignmentCompletedDate { get; set; }
        public DateTime? AssignmentCancelledDate { get; set; }
        public DateTime? AssignmentReopenedDate { get; set; }
        public List<LM_CustomField> CustomFields { get; set; }
    }

    public class LM_QuestionAnswer
    {
        public string QuestionCode { get; set; }
        public string AnswerCode { get; set; }
        public string AnswerValue { get; set; }
    }

    public class LM_GermanyAdditionalFields
    {
        public string ParallelClaimNumber { get; set; }
        public string LossContactDescription { get; set; }
        public string TermsAndConditionCode { get; set; }
        public string TermsAndConditionDescription { get; set; }
        public bool? HasPreviousClaims { get; set; }
        public DateTime? LastSavedDate { get; set; }
        public DateTime? PolicyLastChangedDate { get; set; }
    }

    public class LM_Claims
    {
        public string WritingCompany { get; set; }
        public string LetterheadLogoOverrideName { get; set; }
        public List<LM_ItemDatabase> ItemDatabases { get; set; }
        public string FileNumber { get; set; }
        public string LossContactName { get; set; }
        public string LossContactPhone { get; set; }
        public List<LM_User> doubleernalAssignees { get; set; }
        public List<string> Type { get; set; }
        public string ContentsServiceLevel { get; set; }
        public LM_GuestCompany GuestCompany { get; set; }
        public DateTime? ClosedDate { get; set; }
        public string Status { get; set; }
        public string Number { get; set; }
        public string UniqueID { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? LossDate { get; set; }
        public string LossType { get; set; }
        public string CatastropheNumber { get; set; }
        public bool? Reinspection { get; set; }
        public bool? Emergency { get; set; }
        public bool? Secure { get; set; }
        public double? BuiltYear { get; set; }
        public string InsuredCompanyName { get; set; }
        public string InsuredTitle { get; set; }
        public string InsuredFirstName { get; set; }
        public string InsuredLastName { get; set; }
        public string InsuredTitle2 { get; set; }
        public string InsuredFirstName2 { get; set; }
        public string InsuredLastName2 { get; set; }
        public string InsuredHomePhone { get; set; }
        public string InsuredBusinessPhone { get; set; }
        public string InsuredMobilePhone { get; set; }
        public string InsuredOtherPhone { get; set; }
        public string InsuredOtherPhoneLabel { get; set; }
        public string InsuredEmail { get; set; }
        public LM_Address InsuredAddress { get; set; }
        public LM_Address LossAddress { get; set; }
        public string InitialLossReport { get; set; }
        public string Cause { get; set; }
        public string Damages { get; set; }
        public string GeneralComments { get; set; }
        public string OverallRiskCondition { get; set; }
        public LM_TaxInfo TaxInfo { get; set; }
        public LM_OverheadAndProfitInfo OverheadAndProfitInfo { get; set; }
        public LM_ContentsOverheadAndProfitInfo ContentsOverheadAndProfitInfo { get; set; }
        public LM_MinimumCharge MinimumCharge { get; set; }
        public string PolicyNumber { get; set; }
        public string PolicyType { get; set; }
        public double? PolicyTimesRenewed { get; set; }
        public bool? WithoutPrejudice { get; set; }
        public List<LM_Coverage> Coverages { get; set; }
        public string DeductibleType { get; set; }
        public bool? ExcludeCoverageIfLessThanMinimumDeductible { get; set; }
        public DateTime? PolicyStartDate { get; set; }
        public DateTime? PolicyEndDate { get; set; }
        public double? FlatDeductible { get; set; }
        public double? DeductibleMinimumAmount { get; set; }
        public double? DeductibleMaximumRate { get; set; }
        public List<LM_CustomField> CustomFields { get; set; }
        public LM_User CurrentOwner { get; set; }
        public LM_Company Originator { get; set; }
        public LM_InsuredContact InsuredContact { get; set; }
        public List<LM_Company> DelegatedAuthority { get; set; }
        public List<LM_Company> Assignees { get; set; }
        public List<LM_Company> Peers { get; set; }
        public LM_UploadStatus UploadStatus { get; set; }
        public List<LM_Assignment> Assignments { get; set; }
        public List<LM_QuestionAnswer> QuestionAnswers { get; set; }
        public LM_GermanyAdditionalFields GermanyAdditionalFields { get; set; }
        public string ExternalReference { get; set; }
        public LM_User ClaimContact { get; set; }
    }

}
