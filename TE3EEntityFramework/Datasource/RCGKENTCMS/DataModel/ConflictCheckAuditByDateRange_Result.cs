//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TE3EEntityFramework.Datasource.RCGKENTCMS.DataModel
{
    using System;
    
    public partial class ConflictCheckAuditByDateRange_Result
    {
        public int JobNumber { get; set; }
        public string MatterNumber { get; set; }
        public Nullable<System.DateTime> SearchDate { get; set; }
        public Nullable<System.DateTime> DateRun { get; set; }
        public Nullable<System.DateTime> DateRouted { get; set; }
        public Nullable<System.DateTime> DateDecided { get; set; }
        public Nullable<decimal> ElapsedSearchTime { get; set; }
        public string SearchTerms { get; set; }
        public string EntitySearched { get; set; }
        public string WhereFoundArchCode { get; set; }
        public string WhereFoundAttrCode { get; set; }
        public Nullable<int> Results { get; set; }
    }
}
