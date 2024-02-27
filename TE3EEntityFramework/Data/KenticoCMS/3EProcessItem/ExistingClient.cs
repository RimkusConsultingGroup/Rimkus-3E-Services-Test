using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TE3EEntityFramework.Data.KenticoCMS._3EProcessItem
{
    public class ExistingClient
    {
        public int EntIndex { get; set; }
        public int ClientIndex { get; set; }
        public string ClientNumber { get; set; }
        public string ClientName { get; set; }
        public string ClientType { get; set; }
        public string ClientTypeDesc { get; set; }
        public string EmailAddress { get; set; }
        public string LastProcItemID { get; set; }
        public string OrigProcItemID { get; set; }
        public string Status { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public DateTime TimeStamp { get; set; }
    }

    public class ExistingPayorClient
    {
        public int PayorIndex { get; set; }
        public string PayorName { get; set; }
        public string ClientName { get; set; }
        public string ClientNumber { get; set; }
        public int ClientIndex { get; set; }
        public string LastProcItemID { get; set; }
        public string OrigProcItemID { get; set; }
    }
}
