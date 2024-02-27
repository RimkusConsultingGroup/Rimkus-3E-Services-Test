using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TE3EEntityFramework.Data.Te3e.CMS.CMS.Definition
{
    public class CustomerProfile
    {
        public int? e3EId { get; set; }
        public string kenticoId { get; set; }
        public string email { get; set; }
        public string salutation { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phone { get; set; }
        public string companyName { get; set; }
        public string companyAddress1 { get; set; }
        public string companyAddress2 { get; set; }
        public string companyAddressCity { get; set; }
        public string companyAddressState { get; set; }
        public string companyAddressZip { get; set; }
        public string companyAddressCountry { get; set; }
        public string companyType { get; set; }
        //   "enum": [
        //"insurance",
        //"tpa",
        //"ia",
        //"attorney",
        //"corporation",
        //"government",
        //"other"
        //]
    }
}
