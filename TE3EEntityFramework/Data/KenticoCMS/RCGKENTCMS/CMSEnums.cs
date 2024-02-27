using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TE3EEntityFramework.Data.KenticoCMS.RCGKENTCMS
{
    public enum MattStatus
    {
        Closed = 10,
        Complete = 20,
        OpenforEvidenceBilling = 30,
        Open = 40,
        OpenforTime = 50,
        Pending = 60,
        ClientRefused = 70,
        Declined = 80,
        Hold = 90,
        NoBilling = 99,
        AwaitingRetainer = 100
    }

    public enum EntityType
    {
        [Description("100")]
        All,
        [Description("200")]
        GeneralNoSiteRequired,
        [Description("300")]
        AdditionalParty,
        [Description("ExpenseEntity")]
        ExpenseEntity,
        [Description("CFT_PRO")]
        ProspectiveClient,
        [Description("CFT_PRO_RP")]
        ProspectiveRelatedParty,
        [Description("CFT_FINAL_ENTITY")]
        FinalizedClient,
        [Description("CFT_RP")]
        FinalizedRelatedParty
    }

    public enum AdditionalPartiesRoles
    {
        [Description("Corporation")]
        Corporation = 100,
        [Description("Claimant")]
        Claimant = 200,
        [Description("Insured")]
        Insured = 300,
        [Description("Plaintiff")]
        Plaintiff = 400,
        [Description("Defendant")]
        Defendant = 500,
        [Description("Individual")]
        Individual = 600
    }

    public enum CftRoleCodes
    {
        [Description("Corporation")]
        Corporation = 100,
        [Description("Claimant")]
        Claimant = 200,
        [Description("Insured")]
        Insured = 300,
        [Description("Plaintiff")]
        Plaintiff = 400,
        [Description("Defendant")]
        Defendant = 500,
        [Description("Insurance Company")]
        InsuranceCompany = 600,
        [Description("Adjustment Firm")]
        AdjustmentFirm = 700,
        [Description("Law Firm Plaintiff")]
        LawFirmPlaintiff = 800,
        [Description("Law Firm Defendant")]
        LawFirmDefendant = 900,
        //Government = 950,
        [Description("Government/Municipality")]
        GovernmentMunicipality = 1000,
        [Description("Individual")]
        Individual = 1100,
        [Description("Third Party Administrator (TPA)")]
        ThirdPartyAdministratorTPA = 1200,
        [Description("Independent Adjuster (IA)")]
        IndependentAdjusterIA = 1300,
        //Attorney = 1400,
        //GovernmentEntity = 1500,
        [Description("None of the above")]
        Noneoftheabove = 1600
    }

    public enum IndustryGroup_CCC
    {
        Agriculture = 1,
        Construction = 2,
        Education = 3,
        Energy = 4,
        Entertainment = 5,
        GovernmentMunicipality = 6,
        Healthcare = 7,
        Hospitality = 8,
        Individual = 9,
        Manufacturing = 10,
        MarineIndustry = 11,
        RealEstate = 12,
        Retail = 13,
        Transportation = 14,
        Undefined = 15,
        Telecom = 16
    }

    public enum CftRelationship_CCC
    {
        [Description("Both")]
        Both = 1,
        [Description("Ordering")]
        Ordering = 2,
        [Description("Paying")]
        Paying = 3,
        [Description("SameSideInvolved")]
        SameSideInvolved = 4,
        [Description("Against")]
        Against = 5
    }

    public enum SiteType
    {
        Office = 100,
        Collections = 150,
        Home = 200,
        LocationOfOccurence = 300
    }

    public enum CliStatusType
    {
        Active = 100,
        DeclinedClosed = 150,
        Inactive = 250,
        Pending = 300
    }

    public enum CMSAdjType
    {
        [Description("I am the adjuster")]
        IAmAdjuster = 1,
        [Description("Outside adjuster")]
        OutsideAdjuster = 2,
        [Description("I did not hire an adjuster")]
        IDidNotHireAdjuster = 3
    }

    public enum CMSLegalOrAttyType
    {
        [Description("Individual")]
        Individual = 1,
        [Description("Company")]
        Company = 2,
        [Description("Government Entity")]
        GovernmentEntity = 3
    }

    public enum CMSClientType
    {
        [Description("Insurance Company")]
        InsuranceCompany = 400,
        [Description("Third Party Administrator (TPA)")]
        ThirdPartyAdministrator = 100,
        [Description("Independent Adjuster (IA)")]
        IndependentAdjuster = 101,
        [Description("Attorney")]
        Attorney = 500,
        [Description("Corporation")]
        Corporation = 200,
        [Description("Government Entity")]
        GovernmentEntity = 300,
        [Description("None of the above")]
        NoneOfTheAbove = 0
    }

    public enum CMSEntityType
    {
        [Description("Individual")]
        Individual = 1,
        [Description("Insurance Company")]
        InsuranceCompany = 2,
        [Description("Third Party Administrator (TPA)")]
        ThirdPartyAdministrator = 3,
        [Description("Independent Adjuster (IA)")]
        IndependentAdjuster = 4,
        [Description("Attorney")]
        Attorney = 5,
        [Description("Corporation")]
        Corporation = 6,
        [Description("Government Entity")]
        GovernmentEntity = 7
    }

    public enum CMSPartyType
    {
        [Description("Insured")]
        Insured = 1,
        [Description("Claimant")]
        Claimant = 2,
        [Description("Point of Contact")]
        PointOfContact = 3,
        [Description("Corporation")]
        Corporation = 4,
        [Description("Defendant")]
        Defendant = 5,
        [Description("Plantiff")]
        Plantiff = 6
    }

    public enum T3EClientType
    {
        [Description("Insurance")]
        Insurance = 400,
        [Description("Adjustment Firm/Third Party Administrator (TPA)")]
        ThirdPartyAdministrator = 100,
        [Description("Law Firm")]
        LawFirm = 500,
        [Description("Corporation")]
        Corporation = 200,
        [Description("Government")]
        Government = 300,
        [Description("Other")]
        Other = 600
    }

    public enum T3EMatterLookupType
    {
        [Description("Timekeeper")]
        Timekeeper,
        [Description("ReportOfFindings_CCC")]
        ReportOfFindings_CCC,
        [Description("Office")]
        Office,
        [Description("Department")]
        Department,
        [Description("Arrangement")]
        Arrangement,
        [Description("Section")]
        Section,
        [Description("PracticeGroup")]
        PracticeGroup,
        [Description("IndustryGroup_CCC")]
        IndustryGroup_CCC,
        [Description("SpecialClientInstruction")]
        SpecialClientInstruction,
        [Description("InsuranceType")]
        InsuranceType,
        [Description("ClaimType")]
        ClaimType,
        [Description("Rate")]
        Rate,
        [Description("RateExceptionGroup")]
        RateExceptionGroup,
        [Description("MattStatus")]
        MattStatus,
        [Description("TimeType")]
        TimeType,
        [Description("PTAGroup")]
        PTAGroup,
        [Description("ElecBillingType")]
        ElecBillingType,
        [Description("Currency")]
        Currency,
        [Description("TimeTaxCode")]
        TimeTaxCode
    }

    public enum CMSRepType
    {
        [Description("Defendant")]
        Defendant = 100,
        [Description("Plaintiff")]
        Plaintiff = 200,
        [Description("Subrogation")]
        Subrogation = 300,
    }

    public enum ArchetypeCode
    {
        [Description("EntityPerson")]
        EntityPerson,
        [Description("EntityOrg")]
        EntityOrg
    }
}
