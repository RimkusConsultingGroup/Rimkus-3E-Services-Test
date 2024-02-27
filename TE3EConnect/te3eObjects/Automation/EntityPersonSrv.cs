using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TE3EConnect.te3eObjects.Automation
{
    public class EntityPersonSrv
    {
        public EntityPerson entityPerson { get; set; }
        public List<PersonSite> personSites { get; set; }
    }

    public class EntityPerson
    {
        public string EntityType { get; set; } = "";
        public string FirstName { get; set; } = "";
        public string MiddleName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Prefix { get; set; } = "";
        public string Suffix { get; set; } = "";
        public int EntityID { get; set; }
    }

    public class PersonSite
    {
        public string SiteID { get; set; }
        public string SiteEmailID { get; set; }
        public string RelateID { get; set; }
        public string Description { get; set; }
        public string SiteType { get; set; }
        public string IsDefault { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string State { get; set; }
        public string County { get; set; }
        public string Country { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public PersonEmail EmailAddress { get; set; }

    }

    public class PersonEmail
    {
        public string EmailAddr { get; set; } = "";
        public string Description { get; set; } = "";
        public string SortString { get; set; } = "";
    }
}
