using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TE3EConnect.te3eOjects.Edit.Entity
{
    [Serializable]
    [XmlRoot("Data")]
    public class Data
    {
        [XmlElement]
        public Entity[] Entity { get; set; }
    }

    [Serializable]
    public class Entity
    {
        [XmlElement]
        public string EntityID { get; set; }

        [XmlElement]
        public string EntIndex { get; set; }

        [XmlElement]
        public string DisplayName { get; set; }

        [XmlElement]
        public string EntityType { get; set; }

        [XmlElement]
        public string Description { get; set; }

        [XmlElement]
        public string Comment { get; set; }

        [XmlElement]
        public string TaxID { get; set; }

        [XmlElement]
        public string SyncID { get; set; }

        [XmlElement]
        public string Is3EOwned { get; set; }

        [XmlElement]
        public string EntitySanction { get; set; }

        [XmlElement]
        public string AltNum { get; set; }

        [XmlElement]
        public string LoadSource { get; set; }

        [XmlElement]
        public string LoadGroup { get; set; }

        [XmlElement]
        public string LoadNumber { get; set; }

        [XmlElement]
        public string isChangeAll { get; set; }

        [XmlElement]
        public string IsMerged { get; set; }
    }

}
