using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TE3EEntityFramework.Data.KenticoCMS.RCGKENTCMS;

namespace TE3EConnect.te3eObjects.Automation
{
    public class EntityOrgSrv
    {
        public EntityOrg entityOrg { get; set; }
        public List<OrgSite> orgSites { get; set; }
    }

    public class EntityOrg
    {
        public string EntityType { get; set; } = "";
        public string OrgName { get; set; } = "";
        public int EntityID { get; set; }
    }

    public class OrgSite
    {
        public string SiteID { get; set; } = "";
        public string SiteEmailID { get; set; }
        public string RelateID { get; set; } = "";
        public string Description { get; set; } = "";
        public string SiteType { get; set; } = "";
        public string IsDefault { get; set; } = "";
        public string Street { get; set; } = "";
        public string City { get; set; } = "";
        public string ZipCode { get; set; } = "";
        public string State { get; set; } = "";
        public string County { get; set; } = "";
        public string Country { get; set; } = "";
        public string Longitude { get; set; } = "";
        public string Latitude { get; set; } = "";
        public OrgEmail EmailAddress { get; set; } = new OrgEmail();
        public SvcOps SvcOp { get; set; }
    }

    public class OrgEmail
    {
        public string EmailAddr { get; set; } = "";
        public string Description { get; set; } = "";
        public string SortString { get; set; } = "";
        public string IsDefault { get; set; } = "0";
    }
}
