//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TE3EEntityFramework.Datasource.RCGCLAIMS
{
    using System;
    using System.Collections.Generic;
    
    public partial class LMAssignmentAudit
    {
        public int Id { get; set; }
        public string ClaimUniqueId { get; set; }
        public Nullable<System.DateTime> AssignmentSentDate { get; set; }
        public string BillingName { get; set; }
        public string BillingTitle { get; set; }
        public string BillingCompany { get; set; }
        public string BillingAddress { get; set; }
        public string BillingCity { get; set; }
        public string BillingState { get; set; }
        public string BillingZip { get; set; }
        public string BillingEmail { get; set; }
        public string BillingPhone { get; set; }
        public string BillingCell { get; set; }
        public string BillingFax { get; set; }
        public string ClientName { get; set; }
        public string ClaimNumber { get; set; }
        public string TPAFileNumber { get; set; }
        public string ClaimDescription { get; set; }
        public string UnlistedService { get; set; }
        public Nullable<System.DateTime> OccurrenceDate { get; set; }
        public string OccurrenceLocation { get; set; }
        public string OccurrenceCity { get; set; }
        public string OccurrenceState { get; set; }
        public string OccurrenceZip { get; set; }
        public string InsuranceCompany { get; set; }
        public string InsuredName { get; set; }
        public string InsuredPhone { get; set; }
        public string InsuredCell { get; set; }
        public string AdjustmentCompany { get; set; }
        public string AdjustmentPhone { get; set; }
        public string AdjustorName { get; set; }
        public string AdjustorEmail { get; set; }
        public string InvoiceTo { get; set; }
        public string InvoiceCompany { get; set; }
        public string InvoicePhone { get; set; }
        public string InvoiceAddress { get; set; }
        public string InvoiceCity { get; set; }
        public string InvoiceState { get; set; }
        public string AdditionalData { get; set; }
        public Nullable<System.DateTime> TimeStamp { get; set; }
        public string Title { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public string Operation { get; set; }
    }
}