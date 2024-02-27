
using System.Collections.Generic;

namespace TE3EConnect.te3eMappers.NewBizIntake
{
    public class e3eCftNewBizIntake
    {
        #region NewBizRequest
        public TE3EConnect.te3eOjects.NewBizIntake.CftNewBizRequest cftNewBizRequest { get; set; }

        public List<TE3EConnect.te3eOjects.NewBizIntake.CftNewBizSearchName> cftNewBizSearchNames { get; set; }
        
        public TE3EConnect.te3eOjects.NewBizIntake.CftSearch cftSearch { get; set; }
        
        public List<TE3EConnect.te3eOjects.NewBizIntake.CftSearchTerm> cftSearchTerms { get; set; }
        
        public TE3EConnect.te3eOjects.NewBizIntake.CftNewBizDateRange_CCC cftNewBizDateRange_CCC { get; set; }
        
        public TE3EConnect.te3eOjects.NewBizIntake.CftNewBizAddress_CCC cftNewBizAddress_CCC { get; set; }
        #endregion NewBizRequest

        #region ClientSrv
        public TE3EConnect.te3eOjects.ClientSE.Client clientSrv { get; set; }

        public TE3EConnect.te3eOjects.ClientSE.CliBillingContact cliBillingContact { get; set; }

        public TE3EConnect.te3eOjects.ClientSE.CliDate cliDate { get; set; }

        public TE3EConnect.te3eOjects.ClientSE.CliEBillValList cliEBillValList { get; set; }

        public TE3EConnect.te3eOjects.ClientSE.ClientPTAGroup_CCC clientPTAGroup_CCC { get; set; }

        public TE3EConnect.te3eOjects.ClientSE.ClientRateExc clientRateExc { get; set; }

        public TE3EConnect.te3eOjects.ClientSE.ClientSpecialInstructions_CCC clientSpecialInstructions_CCC { get; set; }

        public TE3EConnect.te3eOjects.ClientSE.CliOrgTkpr cliOrgTkpr { get; set; }

        public TE3EConnect.te3eOjects.ClientSE.CliPlfrTkpr cliPlfrTkpr { get; set; }

        public TE3EConnect.te3eOjects.ClientSE.CliProfAdjust cliProfAdjust { get; set; }

        public TE3EConnect.te3eOjects.ClientSE.CliTemplateOption cliTemplateOption { get; set; }

        public TE3EConnect.te3eOjects.ClientSE.MaskOverrideValues cliMaskOverrideValues { get; set; }

        public TE3EConnect.te3eOjects.ClientSE.MattFlatFee cliMattFlatFee { get; set; }

        public TE3EConnect.te3eOjects.ClientSE.RateExc cliRateExc { get; set; }

        public TE3EConnect.te3eOjects.ClientSE.RateExcClientList cliRateExcClientList { get; set; }

        public TE3EConnect.te3eOjects.ClientSE.RateExcDet cliRateExcDet { get; set; }

        public TE3EConnect.te3eOjects.ClientSE.RateExcMatterList cliRateExcMatterList { get; set; }
        #endregion ClientSrv

        #region MatterSrv
        public TE3EConnect.te3eOjects.MatterSE.Matter matterSrv { get; set; }

        public TE3EConnect.te3eOjects.MatterSE.MattOrgTkpr mattOrgTkpr { get; set; }

        public TE3EConnect.te3eOjects.MatterSE.MattPrlfTkpr mattPrlfTkpr { get; set; }

        //public TE3EConnect.te3eOjects.MattShortEntry.PGDetHdr_CCC pGDetHdr_CCC { get; set; }

        //public List<TE3EConnect.te3eOjects.MattShortEntry.PGDetChild_CCC> pGDetChild_CCCs { get; set; }

        //public TE3EConnect.te3eOjects.MattShortEntry.AssociatedTkprs_CCC associatedTkprs_CCC { get; set; }

        //public TE3EConnect.te3eOjects.MattShortEntry.List<CPADetails_CCC> cPADetails_CCCs { get; set; }

        //public TE3EConnect.te3eOjects.MattShortEntry.SalesForceInfo_CCC salesForceInfo_CCC { get; set; }

        public TE3EConnect.te3eOjects.MatterSE.MattRate mattRate { get; set; }

        public TE3EConnect.te3eOjects.MatterSE.MatterRateExc mattRateExc { get; set; }
        #endregion MatterSrv
    }
}
