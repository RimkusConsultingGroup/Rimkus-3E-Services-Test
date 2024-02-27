using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TE3EConnect.te3eMappers
{
    public class e3eMatterSrv
    {
        public MatterSrv matterSrv { get; set; }

        public MattDate mattDate { get; set; }

        public MattOrgTkpr mattOrgTkpr { get; set; }

        public MattPrlfTkpr mattPrlfTkpr { get; set; }

        public PGDetHdr_CCC pGDetHdr_CCC { get; set; }

        public List<PGDetChild_CCC> pGDetChild_CCCs { get; set; }

        public AssociatedTkprs_CCC associatedTkprs_CCC { get; set; }

        public List<CPADetails_CCC> cPADetails_CCCs { get; set; }

        public SalesForceInfo_CCC salesForceInfo_CCC { get; set; }

        public MattRate mattRate { get; set; }

        public MatterRateExc mattRateExc { get; set; }
    }
}
