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
    
    public partial class LMClaimNotificationsAudit
    {
        public int Id { get; set; }
        public string ClaimNumber { get; set; }
        public string ClaimUniqueId { get; set; }
        public string ExternalReference { get; set; }
        public string PolicyNumber { get; set; }
        public string FileNumber { get; set; }
        public string Status { get; set; }
        public string OriginatorCompanyID { get; set; }
        public string OriginatorCompanyName { get; set; }
        public string NotificationJson { get; set; }
        public Nullable<System.DateTime> TimeStamp { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public string Operation { get; set; }
        public Nullable<System.DateTime> ImportedAt { get; set; }
        public int NumOfAttempts { get; set; }
    }
}
