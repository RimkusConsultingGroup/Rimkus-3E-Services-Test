using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TE3EEntityFramework.Data.KenticoCMS.RCGKENTCMS;

namespace TE3EConnect.te3eObjects.Automation
{
    public class TimekeeperSrv
    {
        public Timekeeper timekeeper { get; set; }
        public TkprDate tkprDate { get; set; }
        public TkprRate tkprRate { get; set; }
        public List<TkprAccreditation> tkprAccreditations { get; set; }
    }

    public class Timekeeper
    {
        public int TkprIndex { get; set; } 
        public string Number { get; set; } = "";
        public string AltNumber { get; set; } = "";
        public string BillInitial { get; set; } = "";
        public string DisplayName { get; set; } = "";
        public string BillName { get; set; } = "";
        public string TkprStatusCode { get; set; } = "";
        public string SortName { get; set; } = "";
        public int EntityID { get; set; }
        public string PayrollNumber { get; set; } = "";
        public string HRNumber { get; set; } = "";
        public string HRTitle { get; set; } = "";
        public string PhysicalLocation { get; set; } = "";
        public string Narrative { get; set; } = "";
        public string TkprType { get; set; } = "";
    }

    public class TkprDate
    {
        public string TkprDateID { get; set; } = "";
        public string EffStart { get; set; }
        public string Office { get; set; }
        public string Department { get; set; }
        public string Section { get; set; }
        public string HireDate { get; set; }
        public string TermDate { get; set; }
        public string Title { get; set; }
        public string RateClass { get; set; }
        public string WorkCalendar { get; set; }
        public string WorkType { get; set; }
        public string NxStartDate { get; set; }
        public string SupTkpr { get; set; }
        public string NxUnit { get; set; }
        public SvcOps SvcOps { get; set; }
    }

    public class TkprRate
    {
        public string RateType { get; set; } = "";
        public string Currency { get; set; } = "";
        public string DefaultRate { get; set; } = "1.00";
        public string EffStart { get; set; }
        public string NxStartDate { get; set; }
    }

    public class TkprAccreditation
    {
        public string TkprAccreditationIdx { get; set; } = "";
        public string Location { get; set; } = "";
        public string AccrType { get; set; } = "";
        public string AccrDate { get; set; }
        public string CertificateNumber { get; set; } = "";
        public string Country { get; set; } = "";
        public string LicenseType_CCC { get; set; } = "";
        public string State { get; set; } = "";
        public string IsActive_CCC { get; set; } = "1";

        public SvcOps SvcOps { get; set; }
    }
}
