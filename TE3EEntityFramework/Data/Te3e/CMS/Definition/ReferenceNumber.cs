using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TE3EEntityFramework.Data.Te3e.CMS.CMS.Definition
{
    public class ReferenceNumber
    {
        public string KenticoID { get; set; } = "";
        public string ReferenceIndex { get; set; } = "";
        public string Type { get; set; } = "";
        //    "enum": [
        //"claim",
        //"policy",
        //"file",
        //"reference",
        //"umr",
        //"tracking"
        //]
        public string Number { get; set; } = "";
        public bool? IncludeForBilling { get; set; } = false;
    }

    public enum ReferenceNumberType
    {
        [Description("Claim")]
        Claim,
        [Description("Policy")]
        Policy,
        [Description("File")]
        File,
        [Description("Reference")]
        Reference,
        [Description("UMR")]
        UMR,
        [Description("Tracking")]
        Tracking,
        [Description("PONumber")]
        PO,
    }
}
