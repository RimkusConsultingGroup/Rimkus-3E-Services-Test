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
    
    public partial class OutIncidentLocationsCM
    {
        public int Id { get; set; }
        public Nullable<int> E3EID { get; set; }
        public string KenticoID { get; set; }
        public Nullable<int> MatterIndex { get; set; }
        public string MatterNumber { get; set; }
        public string StreetOccurrence { get; set; }
        public string CityOccurrence { get; set; }
        public string CountyOccurrence { get; set; }
        public string StateOccurrence { get; set; }
        public string ZipCodeOccurrence { get; set; }
        public string CountryOccurrence { get; set; }
        public Nullable<decimal> LatOccurrence { get; set; }
        public Nullable<decimal> LonOccurrence { get; set; }
        public Nullable<System.Guid> MattSiteID { get; set; }
        public Nullable<System.Guid> SiteID { get; set; }
        public Nullable<System.Guid> AddressID { get; set; }
        public Nullable<System.DateTime> TimeStamp { get; set; }
        public Nullable<bool> IsExported { get; set; }
        public string ErrorMsg { get; set; }
        public Nullable<System.DateTime> ExportedDate { get; set; }
        public Nullable<int> NumOfAttempts { get; set; }
    }
}
