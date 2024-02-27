using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TE3EEntityFramework.Data.KenticoCMS._3EProcessItem
{
    public class MatterProcessItem
    {
        public int MattIndex { get; set; }
        public string MattNumber { get; set; }
        public string MattName { get; set; }
    }

    public class MatterDefaultAttr
    {
        public static int ADMIndex = 46; //Administrative Division (46)
        public static string DefaultOffice = "000"; //Houston(001) Corporate(000)
        public static string DefaultPracticeGroup = "000"; // Default
        public static string DefaultDepartment = "000"; //Default
        public static string DefaultSection = "Default"; //Undefined = Old Value Modified on 01-16-2023 
        public static string DefaultArrangement = "100"; //Hourly
        public static string DefaultGovernmentType_CCC = "06"; //Default
        public static string DefaultPTAGroup = "Default"; //Rimkus Default
        public static string DefaultCliType = "600"; //600 - Other
        public static string DefaultMattRate = "DNU"; //Standard - DO NOT USE
        public static string DefaultMattRateExc = "561AD9FC-78B8-432B-9816-EE3F864BFD20"; //NONE
        public static string DefaultROFTemplate = "002"; //Standard Report
        public static string DefaultSpecialClientInstr = "000"; //"000"; //No Special Instructions //E051FC3E-5EF0-4634-8ECC-50D7CC1148FE
        public static string DefaultTimeType = "FFEE"; //Flat Fee
        public static string DefaultIndustryGroup = "15"; //Undefined (Other)
        public static string DefaultCurrency = "USD"; //US Dollar
        public static string DefaultFeesTaxCode = "0"; //No Tax AR

        public static string DefaultRole = "100";
        public static string DefaultRoleDesc = "Corporation";

        public static string DefaultUnknowAddress = "Unknown";
        public static string DefaultInvoiceToEmail = "Unknown@email.com";
        public static string DefaultUnknownEmail = "Unknown@email.com";

        public static string DefaultStdConfirmationLetter = "1"; //Standard confirmation letter

        public static string DefaultSubsection_CCC = "UNDEFINED01"; //Based on Section - Undefined
        public static string DefaultCorpType_CCC = "016"; //Default
        public static string DefaultContact_CCC = "016"; //Default
        public static string DefaultPhone_CCC = "000-000-0000"; //Default


        // Default Values for Default Template Process
        public static string DefaultClient = "2";
        public static string DefaultMattPayorDetail = "2";
        public static string DefaultMattPayorDetailSite = "8";
        public static string DefaultMattPayorDetailStmtSite = "8";
        public static string DefaultRelatedParties_CCCRole = "500";
        public static string DefaultRelatedParties_CCCEntity = "607433";
    }

}
