using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TE3EEntityFramework.Data.KenticoCMS.RCGKENTCMS;

namespace TE3EConnect.te3eObjects.Automation
{

    public class NxUser
    {
        public string NxUserIndex { get; set; } 
        public string BaseUserName { get; set; } = "";
        public string UserName { get; set; } = "";
        public string IsActive { get; set; } = "1";
        public string TimeZone { get; set; } = "America/Chicago";
        public string Language { get; set; } = "8F4D87BC-3164-45C5-8310-A1AE76ABAEA5";
        public string Dashboard { get; set; } = "E94FB9BF-E329-4AA5-849F-9775834FE35C";
        public string EmailAddr { get; set; } = "";
        public string NetworkAlias { get; set; } = "";
        public string OptionsRole { get; set; } = "22D2B9FB-9087-44AC-A3EA-BB28C331EDF2";
        public string DefaultUnit { get; set; } = "01"; //Rimkus
        public string Office { get; set; } = "000"; //Corporate
        public string CanSwitchOperatingUnit { get; set; } = "0";
        public string DataRole { get; set; } = "F58ACCA5-9D1F-486E-8B22-AF24E20ED33E";
        public string IsAllowTimeEntry { get; set; } = "1";
        public string CanProxy { get; set; } = "0";
        public string CanEditDashboard { get; set; } = "0";
        public string WinTimeZone { get; set; } = "85A4FF52-2BA0-4279-9721-3D4B4D22EFF8"; //Central US
        public string CanEditGlobalModel { get; set; } = "0";
        public string CanEditCompanyHeader { get; set; } = "0";
        public string Department_CCC { get; set; } = "000";
        public string Supervisor_CCC { get; set; } = "05567437-C8A0-4997-B5A7-CE0513606F9F"; //3eadmin
        public string Entity { get; set; }
        public string TimekeeperIndex { get; set; }
        public List<string> NxUserSecRoles { get; set; } = new List<string> { "088EEAA9-5BF2-46CD-A976-7D6E9E6B9F4F", //billing end user role
                                                                              "44A11A4D-0C60-465F-92EF-894C3944D3B9", //expense user role
                                                                              "E10251D0-B53C-4411-9CC8-13F8B096768C" }; //Inquiry & Reports Read Only Security Role - Inquiry, Reports, SimpleSearch, No GL or Profitability

    }
}
