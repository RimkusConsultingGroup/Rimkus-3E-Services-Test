using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TE3EConnect.te3eOjects.Edit.Matter
{
    [Serializable]
    [XmlRoot("Data")]
    public class Data
    {
        [XmlElement]
        public Matter[] Matter { get; set; }
    }

    [Serializable]
    public class Matter
    {
        [XmlElement]
        public string PGDetHdr_CCCID { get; set; }

        [XmlElement]
        public string NxEndDate { get; set; }
    }
}
