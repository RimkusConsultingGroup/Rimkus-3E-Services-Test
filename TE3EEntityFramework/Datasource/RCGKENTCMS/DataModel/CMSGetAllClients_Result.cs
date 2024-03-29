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
    
    public partial class CMSGetAllClients_Result
    {
        public string ClientName { get; set; }
        public System.Guid ClientID { get; set; }
        public int Entity { get; set; }
        public int ClientIndex { get; set; }
        public string Number { get; set; }
        public string AltNumber { get; set; }
        public string DisplayName { get; set; }
        public string SortString { get; set; }
        public Nullable<int> RelatedClient { get; set; }
        public string CliType { get; set; }
        public string CliStatusType { get; set; }
        public System.DateTime CliStatusDate { get; set; }
        public Nullable<decimal> CreditLimit { get; set; }
        public string Currency { get; set; }
        public Nullable<System.DateTime> CurrencyDate { get; set; }
        public System.DateTime OpenDate { get; set; }
        public byte IsPayor { get; set; }
        public Nullable<int> InvoiceSite { get; set; }
        public Nullable<int> StatementSite { get; set; }
        public string ContactInfo { get; set; }
        public string Industry { get; set; }
        public string Narrative { get; set; }
        public string Narrative_UnformattedText { get; set; }
        public Nullable<int> Language { get; set; }
        public string BillingInstruc { get; set; }
        public string Description { get; set; }
        public int OpenTkpr { get; set; }
        public Nullable<int> CloseTkpr { get; set; }
        public Nullable<System.DateTime> CloseDate { get; set; }
        public Nullable<System.Guid> ProfDCSTemplate { get; set; }
        public Nullable<System.Guid> BillDCSTemplate { get; set; }
        public Nullable<System.Guid> StmtDCSTemplate { get; set; }
        public string Country { get; set; }
        public string CliAttribute { get; set; }
        public string CliCategory { get; set; }
        public Nullable<System.DateTime> EntryDate { get; set; }
        public string VATRegistration { get; set; }
        public byte IsEngageLetterReq { get; set; }
        public Nullable<System.DateTime> EngageLetterSubDate { get; set; }
        public Nullable<System.DateTime> EngageLetterRecDate { get; set; }
        public string EngageLetterComment { get; set; }
        public byte IsWaiverLetterReq { get; set; }
        public Nullable<System.DateTime> WaiverLetterSubDate { get; set; }
        public Nullable<System.DateTime> WaiverLetterRecDate { get; set; }
        public string WaiverLetterComment { get; set; }
        public byte IsConflictsConfidential { get; set; }
        public Nullable<int> ApproveTkpr { get; set; }
        public string ConflictStatus { get; set; }
        public byte IsIdentified { get; set; }
        public Nullable<System.DateTime> IdentificationDate { get; set; }
        public string VolumeDiscountGroup { get; set; }
        public byte IsEBill { get; set; }
        public Nullable<int> DueDays { get; set; }
        public Nullable<System.DateTime> ApproveDate { get; set; }
        public byte IsICB { get; set; }
        public string ICBUnit { get; set; }
        public byte IsCreateTaxInvOnRcpt { get; set; }
        public string LoadSource { get; set; }
        public string LoadGroup { get; set; }
        public string LoadNumber { get; set; }
        public string EbillValidationList { get; set; }
        public string RSSFeed { get; set; }
        public string TickerSymbol { get; set; }
        public string URL { get; set; }
        public string ArchetypeCode { get; set; }
        public Nullable<System.Guid> CurrProcItemID { get; set; }
        public Nullable<System.Guid> LastProcItemID { get; set; }
        public Nullable<System.Guid> OrigProcItemID { get; set; }
        public Nullable<byte> HasAttachments { get; set; }
        public Nullable<System.DateTime> TimeStamp { get; set; }
        public Nullable<System.Guid> CreditNoteDCSTemplate { get; set; }
        public Nullable<System.Guid> BillGroupDCSTemplate { get; set; }
        public Nullable<System.Guid> CreditNoteGroupDCSTemplate { get; set; }
        public Nullable<byte> IsNoTC_CCC { get; set; }
        public Nullable<int> EBHClientList { get; set; }
        public string ConvNumber { get; set; }
        public string ConvSource { get; set; }
        public string ConvGroup { get; set; }
        public byte IsExportRestricted { get; set; }
        public string VATRegistrationSeq { get; set; }
        public byte IsEbhAttachments { get; set; }
        public int LxLabel { get; set; }
    }
}
