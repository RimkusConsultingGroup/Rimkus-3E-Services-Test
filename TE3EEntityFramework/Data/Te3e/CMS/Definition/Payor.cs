using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TE3EEntityFramework.Data.Te3e.CMS.CMS.Definition
{
    public class Payor
    {
        public string PayorIndex { get; set; }
        public string KenticoID { get; set; } = "";
        public string PayName { get; set; } = "";
        public string PayRole { get; set; } = "";
        public string PayRoleDesc { get; set; } = "";
        public string PayRelationship { get; set; } = "";
        [JsonIgnore]
        public string PayRelationshipDesc { get; set; } = "";
        public string InvoicePercentage { get; set; } = "";
        public string ReferenceNumber { get; set; } = "";
        public string PayFirstName { get; set; } = "";
        public string PayLastName { get; set; } = "";
        public string PayPhone { get; set; } = "";
        public string PayEmail { get; set; } = "";
        public string PayAddr1 { get; set; } = "";
        public string PayAddr2 { get; set; } = "";
        public string PayCity { get; set; } = "";
        public string PayState { get; set; } = "";
        public string PayZip { get; set; } = "";
        public string PayCountry { get; set; } = "";
        public string PayLat { get; set; } = "";
        public string PayLon { get; set; } = "";
        public string CareOf { get; set; } = "";
        //   "enum": [
        //"me",
        //"client",
        //"adjuster"
        //]
    }
}
