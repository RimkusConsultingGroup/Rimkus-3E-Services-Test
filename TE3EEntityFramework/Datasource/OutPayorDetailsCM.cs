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
    
    public partial class OutPayorDetailsCM
    {
        public int Id { get; set; }
        public Nullable<int> E3EID { get; set; }
        public string KenticoID { get; set; }
        public Nullable<int> MatterIndex { get; set; }
        public string MatterNumber { get; set; }
        public string ClientNumber { get; set; }
        public string ClientName { get; set; }
        public Nullable<int> PayorIndex { get; set; }
        public string PayorName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public string RoleDesc { get; set; }
        public string Relationship { get; set; }
        public string relationshipDesc { get; set; }
        public Nullable<decimal> PercentFee { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string ClaimNumber { get; set; }
        public string ReferenceNumber { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public Nullable<decimal> LatAddress { get; set; }
        public Nullable<decimal> LonAddress { get; set; }
        public Nullable<System.Guid> MattPayorID { get; set; }
        public Nullable<System.Guid> MattPayorDetID { get; set; }
        public Nullable<System.Guid> PayorID { get; set; }
        public Nullable<System.Guid> PayorSiteID { get; set; }
        public Nullable<System.Guid> PayorAddressID { get; set; }
        public Nullable<System.DateTime> TimeStamp { get; set; }
        public Nullable<bool> IsExported { get; set; }
        public string ErrorMsg { get; set; }
        public Nullable<System.DateTime> ExportedDate { get; set; }
        public Nullable<int> NumOfAttempts { get; set; }
    }
}
