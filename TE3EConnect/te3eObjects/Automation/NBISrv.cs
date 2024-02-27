using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TE3EConnect.te3eObjects.Automation
{
    public class NBISrv
    {
        public string Client { get; set; }
        public string Matter { get; set; }
        public string RequestDateTime { get; set; }
        public string Description { get; set; }
        public List<CftNewBizSearchName> cftNewBizSearchNames { get; set; }
        public List<CftNewBizAddress_CCC> cftNewBizAddress_CCCs { get; set; }
    }

    public class CftNewBizSearchName
    {
        public string CftPartyType { get; set; }
        public string CftRelationshipCode { get; set; }
        public string EntityDisplayName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Entity { get; set; }
        public string CftRole { get; set; }
        public string SearchTerm { get; set; }
        public string CftEntityType { get; set; }
    }

    public class CftNewBizAddress_CCC
    {
        public string City { get; set; }
        public string Country { get; set; }
        public string Location { get; set; }
        public string State { get; set; }
    }
}
