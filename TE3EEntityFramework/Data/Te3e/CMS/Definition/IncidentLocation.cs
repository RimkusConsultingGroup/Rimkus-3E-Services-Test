using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TE3EEntityFramework.Data.Te3e.CMS.CMS.Definition
{
    public class IncidentLocation
    {
        public string SiteIndex{ get; set; } = "";
        //[JsonIgnore]
        public string KenticoID { get; set; } = "";
        [JsonIgnore]
        public string MattSiteID { get; set; } = "";
        [JsonIgnore]
        public string AddressID { get; set; } = "";
        public string StreetOccurence { get; set; } = "";
        public string CityOccurence { get; set; } = "";
        public string CountyOccurence { get; set; } = "";
        public string StateOccurence { get; set; } = "";
        public string ZipOccurrence { get; set; } = "";
        public string CountryOccurence { get; set; } = "";
        public string LatOccurence { get; set; } = "";
        public string LonOccurence { get; set; } = "";
    }
}
