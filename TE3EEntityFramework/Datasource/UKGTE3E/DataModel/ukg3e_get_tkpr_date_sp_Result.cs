//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TE3EEntityFramework.Datasource.UKGTE3E.DataModel
{
    using System;
    
    public partial class ukg3e_get_tkpr_date_sp_Result
    {
        public int TkprIndex { get; set; }
        public string Number { get; set; }
        public int Entity { get; set; }
        public string DisplayName { get; set; }
        public string TkprStatus { get; set; }
        public System.Guid TkprDateID { get; set; }
        public Nullable<int> TimekeeperLkUp { get; set; }
        public System.DateTime EffStart { get; set; }
        public string Office { get; set; }
        public string Department { get; set; }
        public string Section { get; set; }
        public Nullable<System.DateTime> HireDate { get; set; }
        public Nullable<System.DateTime> TimeStamp { get; set; }
    }
}