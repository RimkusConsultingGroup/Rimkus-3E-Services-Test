//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TE3EEntityFramework.Datasource
{
    using System;
    using System.Collections.Generic;
    
    public partial class OutOrderingClientsCMSAudit
    {
        public int Id { get; set; }
        public Nullable<int> E3EID { get; set; }
        public string KenticoID { get; set; }
        public int MatterIndex { get; set; }
        public string MatterNumber { get; set; }
        public Nullable<int> OrderClientIndex { get; set; }
        public string OrderClientNumber { get; set; }
        public string OrderClientContactSalutation { get; set; }
        public string OrderClientContactFirstName { get; set; }
        public string OrderClientContactLastName { get; set; }
        public string OrderClientContactEmail { get; set; }
        public string OrderClientContactPhoneNo { get; set; }
        public string OrderClientCompanyName { get; set; }
        public string OrderClientCompanyAddress1 { get; set; }
        public string OrderClientCompanyAddress2 { get; set; }
        public string OrderClientCompanyAddressCity { get; set; }
        public string OrderClientCompanyAddressState { get; set; }
        public string OrderClientCompanyAddressZip { get; set; }
        public string OrderClientCompanyAddressCountry { get; set; }
        public string OrderClientCompanyType { get; set; }
        public string OrderClientCompanyTypeCode { get; set; }
        public string OrderClientAdditionalInstr { get; set; }
        public Nullable<decimal> OrderClientCompanyLatAddress { get; set; }
        public Nullable<decimal> OrderClientCompanyLonAddress { get; set; }
        public string Style { get; set; }
        public string Representing { get; set; }
        public string RepresentingDesc { get; set; }
        public string Court { get; set; }
        public string CauseNumber { get; set; }
        public Nullable<System.DateTime> TimeStamp { get; set; }
        public Nullable<bool> IsExported { get; set; }
        public string ErrorMsg { get; set; }
        public Nullable<System.DateTime> ExportedDate { get; set; }
        public Nullable<int> NumOfAttempts { get; set; }
        public System.DateTime UpdatedAt { get; set; }
        public string Operation { get; set; }
    }
}
