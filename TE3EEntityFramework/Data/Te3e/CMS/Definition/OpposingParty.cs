using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TE3EEntityFramework.Data.Te3e.CMS.CMS.Definition
{
    public class OpposingParty
    {
        public string EntityIndex { get; set; }
        public string KenticoID { get; set; } = "";
        public string AttorneysClientType { get; set; } = "";
        [JsonIgnore]
        public string AttorneysClientTypeDesc { get; set; } = "";
        public string OpposingAttorneysClientName { get; set; } = "";
    } 
}
