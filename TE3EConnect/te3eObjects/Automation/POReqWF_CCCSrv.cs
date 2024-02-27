using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TE3EEntityFramework.Data.KenticoCMS.RCGKENTCMS;
using TE3EEntityFramework.Setting;

namespace TE3EConnect.te3eObjects.Automation
{
    public class POReqWF_CCCSrv
    {
        public Dictionary<TE3EEnv, List<string>> SystemNxUsers = new Dictionary<TE3EEnv, List<string>>()
        {
            { TE3EEnv.DEV, new List<string> { "RimkusApp_Service", "377B3A90-F614-496D-A801-DBFA1C963D01" } }, //RimkusApp_Service
            { TE3EEnv.UAT, new List<string>{ "Rimkus UKG Service", "77FF1057-858C-4D4B-9092-7503FD5E1CCF" } }, //Rimkus UKG Service
            { TE3EEnv.PROD, new List<string> { "Rimkus UKG Service", "77FF1057-858C-4D4B-9092-7503FD5E1CCF" } }, //Rimkus UKG Service
        };

        public POReq pOReq { get; set; }
        public List<POReqDetail> pOReqDetails { get; set; }
    }

    public class POEntrySrv
    {
        public Dictionary<TE3EEnv, List<string>> SystemNxUsers = new Dictionary<TE3EEnv, List<string>>()
        {
            { TE3EEnv.DEV, new List<string> { "RimkusApp_Service", "377B3A90-F614-496D-A801-DBFA1C963D01" } }, //RimkusApp_Service
            { TE3EEnv.UAT, new List<string>{ "Rimkus UKG Service", "77FF1057-858C-4D4B-9092-7503FD5E1CCF" } }, //Rimkus UKG Service
            { TE3EEnv.PROD, new List<string> { "Rimkus UKG Service", "77FF1057-858C-4D4B-9092-7503FD5E1CCF" } }, //Rimkus UKG Service
        };

        public POEntry pOReq { get; set; }
        public List<POReqDetail> pOReqDetails { get; set; }
    }

    public class POEntry
    {
        public string PONum { get; set; } = "0";
        public string Payee { get; set; } = "1801"; //CDW
        public string PayeeSite { get; set; } = "473776"; //CDW site
        public string RequestNxUser { get; set; } = ""; 
        public string RequestNxUserName { get; set; } = ""; 

        public string DateOrdered { get; set; } = DateTime.Now.ToString("yyyy-MM-ddT00:00:00");
        public string Currency { get; set; } = "USD";
        public string Terms { get; set; } = "200"; //Net 30 Days
        public string BillSite { get; set; } = "600444"; //12140 Wickchester Lane, Suite 300
        public string ShipMethod { get; set; } = "100"; //Not Ordered
        public string ProductBundle_CCC { get; set; } = ""; //IT New Hire Hardware Bundle:  Standard User
        public string ProductBundle_Name { get; set; } = "";
        public string POMatchList { get; set; } = "3"; //3 Way Match
        public string ShipSite { get; set; } = "600444"; //12140 Wickchester Lane, Suite 300
        public string ShipInstructions { get; set; } = "Deliver to Rimkus IT Department";
        //public string Comments { get; set; } = $"Createdby POAutomation {DateTime.Now.ToString("yyyy-MM-dd")}";
        public string Comments { get; set; } = $"";

    }

    public class POReq
    {
        public string NxUser { get; set; } = ""; 
        public string NxUserName { get; set; } = "";
        public string ReqDate { get; set; } = DateTime.Now.ToString("yyyy-MM-ddT00:00:00");
        public string Currency { get; set; } = "USD";
        public string ProductBundle_CCC { get; set; } = ""; //IT New Hire Hardware Bundle:  Standard User
        public string ProductBundle_Name { get; set; } = "";
        public string Payee { get; set; } = "1801"; //CDW
        public string Supplier { get; set; } = "CDW";
        public string ShipSite { get; set; } = "600444";
        public string ShipInstructions { get; set; } = "Deliver to Rimkus IT Department";
        //public string Comments { get; set; } = $"Createdby POAutomation {DateTime.Now.ToString("yyyy-MM-dd")}";
        public string Comments { get; set; } = $"";
    }

    public class POReqDetail
    {
        public string LineNum { get; set; } = "0";
        public string DateRequired { get; set; } = DateTime.Now.ToString("yyyy-MM-ddT00:00:00");
        public string Quantity { get; set; } = "";
        public string ProductCode { get; set; } = "";
        public string Description { get; set; } = "";
        public string UOM { get; set; } = "UNIT";
        public string Matter { get; set; } = "";
        public string Office { get; set; } = "000"; //Corporate
        public string Timekeeper { get; set; } = "";
        public string ExpenseGLAcct { get; set; } = "11918"; // 6200-000-045-01-(COMPUTER SUPPLIES)
        public string Comments { get; set; } = "";
        public string IsRush { get; set; } = "";
        public string DeliverNxUser { get; set; } = "";
        public string IsClosed { get; set; } = "";
        public string GLProject { get; set; } = "";
        public string Category { get; set; } = ""; //IT New Hire Hardware
        public string Currency { get; set; } = "USD";
        public string UnitCost { get; set; } = "";
        public string Amount { get; set; } = "";
        public string FACategory { get; set; } = "";
        public string IsProdCodeDoesNotExist_CCC { get; set; } = "";
        public string ShippingCost_CCC { get; set; } = "";
        public string Tax_CCC { get; set; } = "";
    }
}

