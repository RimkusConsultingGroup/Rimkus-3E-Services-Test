using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TE3EEntityFramework.Datasource.RCGKENTCMS.DataModel;

namespace TE3EEntityFramework.Data.KenticoCMS._3EProcessItem
{
    public class ExistingEntity
    {
        public int EntIndex { get; set; }
        public string EntName { get; set; } = "";
        public string EntityType { get; set; } = "";
        public string EmailAddress { get; set; } = "";
        public string LastProcItemID { get; set; }
        public string OrigProcItemID { get; set; }
        public string RelateID { get; set; }
        public string SiteID { get; set; }
        public string SiteEmailID { get; set; }
        public string Street { get; set; }
        public DateTime TimeStamp { get; set; }
    }

    public class ExistingPayorContact
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Email { get; set; } = "";
        public int PayorIndex { get; set; }
        public int PayorSiteIndex { get; set; }
        public string LastProcItemID { get; set; }
        public string OrigProcItemID { get; set; }
    }

    public class EntityAddress
    {
        public int EntIndex { get; set; }
        public string EntName { get; set; } = "";
        public string EntityTypeCode { get; set; } = "";
        public string EntityTypeDesc { get; set; } = "";
        public string SiteTypeCode { get; set; } = "";
        public string SiteTypeDesc { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
    }

    public class CMSCftWorkflowHistory
    {
        public string CurrentOwner { get; set; } = "";
        public string CurrentStepID { get; set; } = "";
        public string StepType { get; set; } = "";
        public string CftSearchReason { get; set; } = "";
        public int ClientIndex { get; set; }
        public string ClientNumber { get; set; } = "";
        public string ClientName { get; set; } = "";
        public int MatterIndex { get; set; }
        public string MatterNumber { get; set; } = "";
        public string MatterName { get; set; } = "";
        public DateTime RequestDateTime { get; set; } 
        public Nullable<DateTime> EndDateTime { get; set; }
        public int JobNumber { get; set; }
        public string Description { get; set; } = "";
        public string CftNBRStatus { get; set; } = "";
        public int NumResults { get; set; } 
        public DateTime DateRun { get; set; }
        public string Ranby { get; set; } = "";
    }

    public class CMSCftSearchTransaction
    {
        public string CftNewBizRequestID { get; set; } = "";
        public string CftSearchReason { get; set; } = "";
        public string Client { get; set; } = "";
        public string Matter { get; set; } = "";
        public DateTime RequestDateTime { get; set; }
        public string JobNumber { get; set; } = "";
        public string Description { get; set; } = "";
        public string CftNBRStatus { get; set; }
        public string BaseUserName { get; set; } = "";
        public string OrigProcItemID { get; set; } = "";
        public string LastProcItemID { get; set; } = "";
    }

    public enum EntityArchetypeCode
    {
        [Description ("EntityPerson")]
        EntityPerson,

        [Description("EntityOrg")]
        EntityOrg
    }
}
