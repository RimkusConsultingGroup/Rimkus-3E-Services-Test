using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TE3EEntityFramework.Data.TrackerSafe
{
    public class TSCase
    {
        public string id { get; set; }

        public string offenseDate { get; set; }

        public bool active { get; set; }

        public string offenseDescription { get; set; }

        public int offenseTypeId { get; set; }

        public List<TSFormData> formData { get; set; }

        public List<string> tags { get; set; }

        public List<string> items { get; set; }

        public string reviewDateNotes { get; set; }

        public string checkInProgress { get; set; }

        public string caseNumber { get; set; }

        public string reviewDate { get; set; }

        public List<int> caseOfficerIds { get; set; }

        public string caseOfficer { get; set; }

        public string offenseLocation { get; set; }

        public int officeId { get; set; }
    }

    public class TSFormData
    {
        private int form_Id = 11;
        public int formId
        {
            get { return form_Id; }
            set { form_Id = value; }
        }

        private string form_Name = "Additional Matter Information";
        public string formName
        {
            get { return form_Name; }
            set { form_Name = value; }
        }
        private string mydata = "";
        public string data
        {
            get { return mydata; }
            set { mydata = value; }
        }
    }

    public class BFormDataOutput
    {
        /// <summary>
        /// Special Charged Amount
        /// </summary>
        public string field7227 { get; set; }
        /// <summary>
        /// Decision Letter
        /// </summary>
        public string field9981 { get; set; }

        /// <summary>
        /// Billed
        /// </summary>
        public string field9459 { get; set; }

        /// <summary>
        /// BillRateType
        /// </summary>
        public string field7142 { get; set; }

        /// <summary>
        /// BillRate
        /// </summary>
        public string field7169 { get; set; }
    }

    public class DLFormDataDevOutput
    {
        /// <summary>
        /// Package Insure
        /// "1": "Yes"
        /// "2": "No"
        /// </summary>
        public string field5885 { get; set; }
        /// <summary>
        /// Storage Option
        /// "1" : "Continue To Hold Evidence"
        /// "2": "Dispose Of The Evidence"
        /// "3": "Transfer The Evidence"
        /// </summary>
        public string field8213 { get; set; }
        /// <summary>
        /// Recipient Name
        /// </summary>
        public string field5891 { get; set; }
        /// <summary>
        /// Company Name
        /// </summary>
        public string field5893 { get; set; }
        /// <summary>
        /// Recipient Address
        /// </summary>
        public string field5877 { get; set; }
        /// <summary>
        /// Recipient City
        /// </summary>
        public string field5879 { get; set; }
        /// <summary>
        /// Recipient State
        /// </summary>
        public string field5881 { get; set; }
        /// <summary>
        /// Recipient Zip
        /// </summary>
        public string field5883 { get; set; }
        /// <summary>
        /// Recipient Phone
        /// </summary>
        public string field5889 { get; set; }
        /// <summary>
        /// Insurance Cost
        /// </summary>
        public int field5887 { get; set; }
        /// <summary>
        /// Authorized Representive
        /// </summary>
        public string field5895 { get; set; }
        /// <summary>
        /// Carrier Name
        /// </summary>
        public string field8053 { get; set; }
        /// <summary>
        /// Sent At
        /// </summary>
        public DateTime? field5873 { get; set; }
        /// <summary>
        /// Recived At
        /// </summary>
        public DateTime? field5871 { get; set; }
    }
    public class DLFormDataProdOutput
    {
        /// <summary>
        /// Package Insure
        /// "1": "Yes"
        /// "2": "No"
        /// </summary>
        public string field2063 { get; set; }
        /// <summary>
        /// Storage Option
        /// "1" : "Continue To Hold Evidence"
        /// "2": "Dispose Of The Evidence"
        /// "3": "Transfer The Evidence"
        /// </summary>
        public string field2045 { get; set; }
        /// <summary>
        /// Recipient Name
        /// </summary>
        public string field2047 { get; set; }
        /// <summary>
        /// Company Name
        /// </summary>
        public string field2049 { get; set; }
        /// <summary>
        /// Recipient Address
        /// </summary>
        public string field2051 { get; set; }
        /// <summary>
        /// Recipient City
        /// </summary>
        public string field2053 { get; set; }
        /// <summary>
        /// Recipient State
        /// </summary>
        public string field2055 { get; set; }
        /// <summary>
        /// Recipient Zip
        /// </summary>
        public string field2057 { get; set; }
        /// <summary>
        /// Recipient Phone
        /// </summary>
        public string field2059 { get; set; }
        /// <summary>
        /// Insurance Cost
        /// </summary>
        public int field2065 { get; set; }
        /// <summary>
        /// Authorized Representive
        /// </summary>
        public string field2067 { get; set; }
        /// <summary>
        /// Carrier Name
        /// </summary>
        public string field2061 { get; set; }
        /// <summary>
        /// Sent At
        /// </summary>
        public DateTime? field2041 { get; set; }
        /// <summary>
        /// Recived At
        /// </summary>
        public DateTime? field2043 { get; set; }
    }

    public class AIFormDataDevOutput
    {
        //public string field9507 { get; set; }
        //public string field9509 { get; set; }
        //public string field9511 { get; set; }
        //public string field9513 { get; set; }
        //public string field9515 { get; set; }
        //public string field9068 { get; set; }
        //public string field6836 { get; set; }
        //public string field2006 { get; set; }
        /// <summary>
        /// Recepient Email
        /// </summary>
        public string field7525 { get; set; }
    }
    public class AIFormDataProdOutput
    {
        //public string field9507 { get; set; }
        //public string field9509 { get; set; }
        //public string field9513 { get; set; }
        //public string field9515 { get; set; }
        //public string field9068 { get; set; }
        //public string field6836 { get; set; }
        //public string field2006 { get; set; }
        /// <summary>
        /// Recepient Email
        /// </summary>
        public string field198 { get; set; }
    }

}
