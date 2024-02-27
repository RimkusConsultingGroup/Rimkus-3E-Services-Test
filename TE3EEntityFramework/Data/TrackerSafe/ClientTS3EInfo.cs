using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TE3EEntityFramework.Data.TrackerSafe
{
    public class ClientTS3EInfo
    {
        private Dictionary<string, string> BillRates = new Dictionary<string, string>
        {
            { "small", "100" },
            { "large", "150" },
            { "vehicle", "300" },
            { "special", "(enter amount)" }
        };

        public string MatterNo { get; set; }

        public string MatterName { get; set; }

        public string ClientName { get; set; }

        public string ClientFormattedString { get; set; }

        public string ClientStreet { get; set; }

        public string ClientCity { get; set; }

        public string ClientState { get; set; }

        public string ClientZipCode { get; set; }

        public string ContactEmail { get; set; }

        public string ClaimNo { get; set; }

        public string ReferenceNo { get; set; }

        public string ContactName { get; set; }

        public string ContactPhone { get; set; }

        public string InsuredName { get; set; }

        public string Claimant { get; set; }

        public string Style { get; set; }

        public string CauseNo { get; set; }

        public string DateOfLoss { get; set; }

        public string OfficeFormattedString { get; set; }

        public string OfficeName { get; set; }

        public string OfficeStreet { get; set; }

        public string OfficeCity { get; set; }

        public string OfficeState { get; set; }

        public string OfficeZipCode { get; set; }

        public string OfficePhone { get; set; }

        public string OfficeFax { get; set; }

        public string CertAuthNo { get; set; }

        public string Technician { get; set; }

        public string TechnicianEmail { get; set; }

        public string EvidenceDescription { get; set; }

        public string EvidenceID { get; set; }

        public string ExpirationDate { get; set; }

        public bool IsBilled { get; set; }

        public string BillTerm { get; set; }

        private string billRateDisplayName = "";
        public string BillRateDisplayName
        {
            get { return billRateDisplayName; }
            set { billRateDisplayName = value; }
        }

        public string EvidenceResonse { get; set; }
        public string SpecialChargedAmount { get; set; }

        public string ChargedAmount
        {
            get
            {
                if (BillRateDisplayName.ToLower().Equals("special"))
                {
                    return SpecialChargedAmount;
                }
                return BillRates.ContainsKey(BillRateDisplayName.ToLower())
                       ? BillRates[BillRateDisplayName.ToLower()]
                       : "0";
            }
        }
    }
}
