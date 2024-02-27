using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TE3EConnect.te3eARCollectionItem
{
    public class ARCollectionItem
    {
        public string MatterNumber { get; set; }
        public string MatterName { get; set; }
        public string ClientName { get; set; }

        public Nullable<int> ClientIndex { get; set; }
        public Nullable<int> RelatedClient { get; set; }

        public string Office { get; set; }
        public string DateOfLoss { get; set; }
        public string ClaimNumber { get; set; }
        public string ReferenceNumber { get; set; }
        public string Contact { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Insured_Name { get; set; }
        public string Claimant { get; set; }
        public string Style { get; set; }
        public string Cause_Number { get; set; }
        public int InvMaster { get; set; }
        public Nullable<System.DateTime> InvDate { get; set; }
        public System.Guid InvPayor { get; set; }
        public int Payor { get; set; }
        public string PayorName { get; set; }
        public int CollectionItem { get; set; }
        public Nullable<int> CollectionStep { get; set; }
        public System.Guid Collector { get; set; }
        public string CollectorName { get; set; }
        public Nullable<decimal> OpenAmt { get; set; }
        public Nullable<decimal> OrigAmt { get; set; }
        public Nullable<decimal> OrigCollAmt { get; set; }
        public Nullable<int> DaysOverdue { get; set; }
    }
}
