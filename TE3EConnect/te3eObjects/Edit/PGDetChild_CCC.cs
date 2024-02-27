using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TE3EConnect.te3eOjects.Edit
{
    [Serializable]
    [XmlRoot("Data")]
    public class Data
    {
        [XmlElement]
        public PGDetChild_CCC[] PGDetChild_CCC { get; set; }
    }

    [Serializable]
    public class PGDetChild_CCC
    {
        [XmlElement]
        public string PGDetChild_CCCID { get; set; }

        [XmlElement]
        public string PGDetHdr { get; set; }

        [XmlElement]
        public string TriggerType { get; set; }

        [XmlElement]
        public string Year { get; set; }

        [XmlElement]
        public string IsFederal { get; set; }

        [XmlElement]
        public string IsGeneralWork { get; set; }

        [XmlElement]
        public string State { get; set; }

        [XmlElement]
        public string Description { get; set; }

        [XmlElement]
        public string Building { get; set; }

        [XmlElement]
        public string Quarter { get; set; }

        [XmlElement]
        public string OrigCredit { get; set; }

        [XmlElement]
        public string ValueAssessment { get; set; }

        [XmlElement]
        public string EngineerReview { get; set; }

        [XmlElement]
        public string FinalCredit { get; set; }

        [XmlElement]
        public string Interest { get; set; }

        [XmlElement]
        public string Adjustment { get; set; }

        [XmlElement]
        public string Total { get; set; }

        [XmlElement]
        public string Comments { get; set; }

        [XmlElement]
        public string RevenuePct { get; set; }

        [XmlElement]
        public string SustentionAmt { get; set; }

        [XmlElement]
        public string SustentionPct { get; set; }

        [XmlElement]
        public string MSID { get; set; }

        [XmlElement]
        public string bldgID { get; set; }

        [XmlElement]
        public string Status { get; set; }

        [XmlElement]
        public string NewWIPFT { get; set; }

        [XmlElement]
        public string ControlGroup { get; set; }
    }
}
