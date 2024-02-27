using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TE3EEntityFramework.Data.Te3e.CMS.CMS.Definition
{
    public class Party
    {
        public string KenticoID { get; set; } = "";
        //public string PartyID { get; set; } = "";
        public string EntityIndex { get; set; } = "";
        public string EntityType { get; set; } = "";
        [JsonIgnore]
        public string EntityTypeDesc { get; set; } = "";
        public string PartyType { get; set; } = "";
        [JsonIgnore]
        public string PartyTypeDesc { get; set; } = "";
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string CompanyName { get; set; } = "";
        public string ContactName { get; set; } = "";
        public string Email { get; set; } = "";
        public string Phone { get; set; } = "";
    }
}
