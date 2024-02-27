using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TE3EEntityFramework.Data.KenticoCMS._3EProcessItem
{
    public class EntityProcessItem
    {
        public string EntityType { get; set; }
        public string EntityTypeDesc { get; set; }
        public string EntityName { get; set; }
        public byte? IsDefault { get; set; }
        public int EntIndex { get; set; }
        public int? SiteIndex { get; set; }
        public string OfficeType { get; set; }
        public string OfficeTypeDesc { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public string ArchetypeCode { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
