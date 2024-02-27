using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TE3EEntityFramework.Data.UKGTE3E
{
    public class UKGTE3ETimekprInfo
    {
        public int ID { get; set; }
        public string Number { get; set; }
        public int TkprIndex { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string AltNumber { get; set; }
        public string Entity { get; set; }
        public int EntityIndex { get; set; }
        public string Entity_Type { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Display_Name { get; set; }
        public string Type { get; set; }
        public string Payroll_Number { get; set; }
        public string HR_Number { get; set; }
        public string Bill_Name { get; set; }
        public string Bill_Initial { get; set; }
        public string Status { get; set; }
        public string Sort_Name { get; set; }
        public DateTime CompDate { get; set; }
        public string Timekeeper_Category { get; set; }
        public DateTime EffStart { get; set; }
        public string Office { get; set; }
        public string Department { get; set; }
        public string Section { get; set; }
        public DateTime Hire_Date { get; set; }
        public DateTime Termination_Date { get; set; }
        public string Title { get; set; }
        public string Rate_Class { get; set; }
        public string Work_Calender { get; set; }
        public string Unit { get; set; }
        public string Supervising_timeKeeper { get; set; }
        public string Work_type { get; set; }
        public string Billing_Corodinator { get; set; }
        public string Sitephone { get; set; }
        //public string LicenseType { get; set; }
        //public string LicCountry { get; set; }
        //public string LicState { get; set; }
        //public DateTime LicExpiration { get; set; }
        //public string LicCertificationNo { get; set; }

        public List<TkprLicenseInfo> TkprLicenseInfo { get; set; }
        public DateTime LastChangeTimeStamp { get; set; }
        public DateTime ImportedDate { get; set; }
        public string SvcOperation { get; set; }
        public int NumOfAttempt { get; set; }
        public string LogInfo { get; set; }
        public bool IsProcessed { get; set; }
        public DateTime ProcessedDate { get; set; }
    }

    public class TkprLicenseInfo
    {
        public string LicenseType { get; set; }
        public string LicCountry { get; set; }
        public string LicState { get; set; }
        public DateTime LicExpiration { get; set; }
        public string LicCertificationNo { get; set; }
    }

    public class TkprDateInfo
    {
        public int TkprIndex { get; set; }
        public string Number { get; set; }
        public int Entity { get; set; }
        public string DisplayName { get; set; }
        public string TkprStatus { get; set; }
        public System.Guid TkprDateID { get; set; }
        public Nullable<int> TimekeeperLkUp { get; set; }
        public System.DateTime EffStart { get; set; }
        public string Office { get; set; }
        public string Department { get; set; }
        public string Section { get; set; }
        public string Title { get; set; }
        public string RateClass { get; set; }
        public Nullable<System.DateTime> HireDate { get; set; }
        public Nullable<System.DateTime> TermDate { get; set; }
        public string WorkCalendar { get; set; }
        public string SupTkpr { get; set; }
        public string BillingCoordinator { get; set; }
        public string WorkType { get; set; }
        public Nullable<System.DateTime> NxStartDate { get; set; }
        public Nullable<System.DateTime> NxEndDate { get; set; }
        public Nullable<System.DateTime> TimeStamp { get; set; }
    }

    public class UKGTE3EUserInfo
    {
        public Guid NxFWKUserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BaseUserName { get; set; }
        public string UserName { get; set; }
        public string TimeZone { get; set; }
        public Guid Language { get; set; }
        public Guid Dashboard { get; set; } 
        public string EmailAddr { get; set; }
        public string NetworkAlias { get; set; }
        public string OptionsRole { get; set; } 
        public string DefaultUnit { get; set; } 
        public string Office { get; set; } 
        public byte CanSwitchOperatingUnit { get; set; } 
        public Guid DataRole { get; set; } 
        public string IsAllowTimeEntry { get; set; } 
        public byte CanProxy { get; set; }
        public byte CanEditDashboard { get; set; } 
        public Guid WinTimeZone { get; set; } 
        public string CanEditGlobalModel { get; set; } 
        public string CanEditCompanyHeader { get; set; }
        public string Entity { get; set; }
        public string TimekeeperIndex { get; set; }
        public List<string> NxUserSecRoles { get; set; }
        public string Department_CCC { get; set; }
        public Guid Supervisor_CCC { get; set; }
        public string Title { get; set; }
    }

    public class NxUserInfo
    {
        public UKGTE3ETimekprInfo UKGTE3ETimekpr { get; set; }
        public UKGTE3EUserInfo UKGTE3EUser { get; set; }
    }
}
