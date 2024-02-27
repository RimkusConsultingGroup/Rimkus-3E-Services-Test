using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TE3EConnect.te3eObjects.Automation
{
    public class ClientSrv
    {
        public string Entity { get; set; }
        public string CliType { get; set; }
        public string ClientIndex { get; set; }
        public string ClientNumber { get; set; }
        public string CliStatusType { get; set; }
        public string CliStatusDate { get; set; }
        public string OpenDate { get; set; }
        public string InvoiceSite { get; set; }
        public string DisplayName { get; set; }
        public string OpenTkpr { get; set; }
        public CliDate cliDate { get; set; }
    }

    public class CliDate
    {
        public string EffStart { get; set; }
        public string Office { get; set; }
        public string RspTkpr { get; set; }
        public string BillTkpr { get; set; }
        public string SpvTkpr { get; set; }
        public string NxStartDate { get; set; }
        public string CliDateKey { get; set; }
    }
}
