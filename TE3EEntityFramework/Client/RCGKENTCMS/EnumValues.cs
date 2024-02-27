using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TE3EEntityFramework.Client.RCGKENTCMS
{

    public class EditKeyValuePair
    {
        public string TableName { get; set; }
        public string LookupColumn { get; set; }
        public string ForeignKey { get; set; }
        public string RetColumn { get; set; }
    }

    public enum EditTableName
    {
        [Description("MattDate")]
        MattDate,

        [Description("MattSite")]
        MattSite,

        [Description("MattBudget")]
        MattBudget,

        [Description("MattFlatFee")]
        MattFlatFee,

        [Description("MattPayor")]
        MattPayor,

        [Description("MattPayorDet")]
        MattPayorDetail,

        [Description("RelatedParties_CCC")]
        RelatedParties_CCC,

        [Description("MatterSpecialInstructions_CCC")]
        MatterSpecialInstructions_CCC,

        [Description("TechRevEngRec_CCC")]
        TechRevEngRec_CCC,

        [Description("CoConsultants_CCC")]
        CoConsultants_CCC,

        [Description("MatterRateExc")]
        MatterRateExc,

        [Description("IndustryGroupMatter_CCC")]
        IndustryGroupMatter_CCC,

        [Description("MatterSpecialInvoiceTo_CCC")]
        MatterSpecialInvoiceTo_CCC,

        [Description("MattRate")]
        MattRate
    }

    public enum QueueType
    {
        [Description("INBOUND")]
        INBOUND,

        [Description("OUTBOUND")]
        OUTBOUND
    }

    public enum KenticoSubEntityRelEnum
    {
        IncidentLocation = 1,
        CoConsultants,
        AdditionalParties,
        Payors,
        ReferenceNumbers
    }
}
