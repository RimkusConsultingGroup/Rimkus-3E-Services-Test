using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TE3EConnect.te3eOjects.NewBizIntake;

namespace TE3EConnect.te3eDB.DbInfo
{
    public class NewBizIntake3e
    {
        public CftNewBizRequest cftNewBizRequest { get; set; }

        public List<CftNewBizSearchName> cftNewBizSearchNames { get; set; }

        public CftSearch cftSearch { get; set; }

        public List<CftSearchTerm> cftSearchTerms { get; set; }

        public List<CftSearchResultRPOrg> cftSearchResultRPOrgs { get; set; }

        public List<CftSearchResultRPPerson> cftSearchResultRPPeople { get; set; }

        public List<CftComments> cftComments { get; set; }

        public List<CftWorkflowHistory> cftWorkflowHistories { get; set; }

        public List<CftSearchFields> cftSearchFields { get; set; }

        public List<CftSearchAddress_CCC> cftSearchAddress_CCCs { get; set; }

        public List<CftNBIComments> cftNBIComments { get; set; }

        public List<CftNewBizDateRange_CCC> cftNewBizDateRange_CCCs { get; set; }

        public List<CftNewBizAddress_CCC> cftNewBizAddress_CCCs { get; set; }
    }
}
