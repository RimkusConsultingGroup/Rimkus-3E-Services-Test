namespace TE3EConnect.te3eXML
{
    public static class e3eMatterXML
    {
        public static string GetMatterInfoXOQLByIndex = @"<QUERY><SELECT ID=""SelectStatement"" Class=""NextGen.Framework.OQL.Symbols.SelectStatement"" xmlns=""http://elite.com/schemas/query"">
  <OQL_CONTEXT Class=""NextGen.Framework.Managers.ObjectMgr.ExContextProvider"">
    <NODEMAP ID=""Node#1"" QueryID=""Matter"" Class=""NextGen.Application.Query.Matter"" Assembly=""NextGen.Archetype.Matter"" />
    <NODEMAP ID=""Node#2"" QueryID=""Client1"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#3"" QueryID=""RelMattIndex1"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#4"" QueryID=""MattStatus1"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#5"" QueryID=""MattType1"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#6"" QueryID=""ConflictStatus1"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#7"" QueryID=""Language1"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#8"" QueryID=""MattCloseType1"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#9"" QueryID=""NonBillType1"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#10"" QueryID=""Entity1"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#11"" QueryID=""ElecBillingType1"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#12"" QueryID=""BillAsMatter1"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#13"" QueryID=""BillSite1"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#14"" QueryID=""StatementSite1"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#15"" QueryID=""OpenTkprRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#16"" QueryID=""CloseTkprRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#17"" QueryID=""BillingFrequencyRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#18"" QueryID=""MarkupRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#19"" QueryID=""TimeTaxCodeRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#20"" QueryID=""CostTaxCodeRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#21"" QueryID=""ChrgTaxCodeRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#22"" QueryID=""CurrencyDateListRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#23"" QueryID=""TimeIncrementRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#24"" QueryID=""BillDCSTemplateRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#25"" QueryID=""ProfDCSTemplateRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#26"" QueryID=""StmtDCSTemplateRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#27"" QueryID=""ApproveTkprRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#28"" QueryID=""MattAttributeRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#29"" QueryID=""MattCategoryRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#30"" QueryID=""MattMinTypeRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#31"" QueryID=""GLProjectRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#32"" QueryID=""WithholdingTaxRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#33"" QueryID=""VolumeDiscountGroupRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#34"" QueryID=""MattInterestRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#35"" QueryID=""ElecDCSTemplateRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#36"" QueryID=""InvoiceOverrideRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#37"" QueryID=""ICBUnitDueToRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#38"" QueryID=""ICBUnitDueFromRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#39"" QueryID=""GLRespTkprRel1"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#40"" QueryID=""BillingOfficeRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#41"" QueryID=""BankAcctApRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#42"" QueryID=""ToTaxAreaRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#43"" QueryID=""WPTypeRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#44"" QueryID=""GLActivityRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#45"" QueryID=""CreditNoteDCSTemplateRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#46"" QueryID=""BillGroupDCSTemplateRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#47"" QueryID=""CreditNoteGroupDCSTemplateRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#48"" QueryID=""Originator_CCCRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#49"" QueryID=""ReportingOfficeRel_CCC"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#50"" QueryID=""ReportOfFindingsRel_CCC"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
  </OQL_CONTEXT>
  <SELECT_LIST>
    <SINGLE_SELECT Union=""Distinct"">
      <NODE NodeID=""Node#1"" />
      <VALUES>
        <VALUE>
          <LEAF QueryID=""MatterID"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""MattIndex"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Number"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""AltNumber"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""DisplayName"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Client"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Number"">
            <NODE NodeID=""Node#2"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""MattInfo"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""RelMattIndex"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Number"">
            <NODE NodeID=""Node#3"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""MattStatus"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#4"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""MattStatusDate"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""MattType"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#5"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""OpenDate"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""ConflictStatus"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#6"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Narrative"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""BillingInstruc"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Language"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#7"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""ContactInfo"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""ReferralInfo"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""MattCloseType"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#8"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""CloseDate"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsMaster"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""NonBillType"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#9"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsProBono"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""ProBonoEntity"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""DisplayName"">
            <NODE NodeID=""Node#10"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""ProBonoInfo"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsAdmin"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""AdminAccount"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""AdminInfo"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""ElecBillingType"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#11"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""ElecNumber"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""ElecInfo"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsNonBillable"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""BillAsMatter"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Number"">
            <NODE NodeID=""Node#12"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""BillSite"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#13"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""StatementSite"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#14"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""OpenTkpr"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Number"">
            <NODE NodeID=""Node#15"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""CloseTkpr"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Number"">
            <NODE NodeID=""Node#16"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Comments"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsDefault"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""BillingFrequency"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#17"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsNoProforma"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsNoBill"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Markup"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#18"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""TimeTaxCode"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#19"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""CostTaxCode"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#20"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""ChrgTaxCode"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#21"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""DueDays"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Currency"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""CurrencyDateList"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#22"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""ElecCostTypeMap"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""TimeIncrement"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#23"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsEngageLetterReq"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""EngageLetterSubDate"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""EngageLetterRecDate"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""EngageLetterComment"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsWaiverLetterReq"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""WaiverLetterSubDate"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""WaiverLetterRecDate"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""WaiverLetterComment"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsConflictsConfidential"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""BillDCSTemplate"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Name"">
            <NODE NodeID=""Node#24"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""ProfDCSTemplate"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Name"">
            <NODE NodeID=""Node#25"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""StmtDCSTemplate"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Name"">
            <NODE NodeID=""Node#26"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""ApproveTkpr"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Number"">
            <NODE NodeID=""Node#27"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""MattAttribute"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#28"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""MattCategory"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#29"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""EntryDate"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""VATRegistration"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""MattMinType"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#30"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""GLProject"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#31"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsForeign"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""WithholdingTax"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#32"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""VolumeDiscountGroup"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#33"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""MattInterest"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#34"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsEBill"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""ElecTitleMap"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""ElecDCSTemplate"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Name"">
            <NODE NodeID=""Node#35"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""PaymentTermsInfo"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsFeeEstimate"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""FeeEstimateAmount"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""EstimatedCompletionDate"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""ApproveDate"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""InvoiceOverride"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#36"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""ProformaEmail"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""BillEmail"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsICBAcctRec"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsICBPayable"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""ICBUnitDueTo"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#37"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""ICBUnitDueFrom"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#38"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""GLRespTkpr"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Number"">
            <NODE NodeID=""Node#39"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsAllowTrustOverdraw"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""BillingOffice"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#40"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""BankAcctAp"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Name"">
            <NODE NodeID=""Node#41"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""TaxReportID1"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""TaxReportID2"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""ToTaxArea"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#42"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsLeadVolumeDiscountMatter"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsBillStatementIncludeDoubtful"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Field1"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Field2"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Field3"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""LoadSource"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""LoadGroup"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""LoadNumber"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""EbillValidationList"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""WPType"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#43"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""GLActivity"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""GLValue"">
            <NODE NodeID=""Node#44"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""CreditNoteDCSTemplate"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Name"">
            <NODE NodeID=""Node#45"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""BillGroupDCSTemplate"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Name"">
            <NODE NodeID=""Node#46"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""CreditNoteGroupDCSTemplate"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Name"">
            <NODE NodeID=""Node#47"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""ElecTaxCodeMap"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""DateOfOccurence_CCC"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""DateOfOccurenceTxt_CCC"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsProspective_CCC"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""isConflictsRoleApproved_CCC"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Originator_CCC"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""BaseUserName"">
            <NODE NodeID=""Node#48"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsWeb_CCC"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""DateReceived_CCC"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""RetainerAmount_CCC"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""ScopeOfWork_CCC"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""ValidationMsg_CCC"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""ReportingOffice_CCC"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#49"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsFixedPrice_CCC"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""DNENotes_CCC"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsConfLetterStd_CCC"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsConfLetterLegal_CCC"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsConfLetterNatAgmt_CCC"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsConfLetterEngSvcs_CCC"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsConfLetterCAT_CCC"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsConfLetterRtnr_CCC"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsConfLetterSign_CCC"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""ReportOfFindings_CCC"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#50"" />
          </LEAF>
        </VALUE>
      </VALUES>
      <WHERE>
<X_IS_EQUAL_TO_Y>
		  <X>
			<LEAF QueryID=""MattIndex"">
			  <NODE NodeID=""Node#1"" />
			</LEAF>
		  </X>
		  <Y>
			<UNICODE_STRING Value=""{0}"" />
		  </Y>
		</X_IS_EQUAL_TO_Y>
             </WHERE>
    </SINGLE_SELECT>
  </SELECT_LIST>
</SELECT>
</QUERY>";

        public static string GetMatterInfoXOQLByNum = @"<QUERY><SELECT ID=""SelectStatement"" Class=""NextGen.Framework.OQL.Symbols.SelectStatement"" xmlns=""http://elite.com/schemas/query"">
  <OQL_CONTEXT Class=""NextGen.Framework.Managers.ObjectMgr.ExContextProvider"">
    <NODEMAP ID=""Node#1"" QueryID=""Matter"" Class=""NextGen.Application.Query.Matter"" Assembly=""NextGen.Archetype.Matter"" />
    <NODEMAP ID=""Node#2"" QueryID=""Client1"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#3"" QueryID=""RelMattIndex1"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#4"" QueryID=""MattStatus1"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#5"" QueryID=""MattType1"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#6"" QueryID=""ConflictStatus1"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#7"" QueryID=""Language1"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#8"" QueryID=""MattCloseType1"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#9"" QueryID=""NonBillType1"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#10"" QueryID=""Entity1"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#11"" QueryID=""ElecBillingType1"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#12"" QueryID=""BillAsMatter1"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#13"" QueryID=""BillSite1"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#14"" QueryID=""StatementSite1"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#15"" QueryID=""OpenTkprRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#16"" QueryID=""CloseTkprRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#17"" QueryID=""BillingFrequencyRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#18"" QueryID=""MarkupRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#19"" QueryID=""TimeTaxCodeRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#20"" QueryID=""CostTaxCodeRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#21"" QueryID=""ChrgTaxCodeRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#22"" QueryID=""CurrencyDateListRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#23"" QueryID=""TimeIncrementRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#24"" QueryID=""BillDCSTemplateRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#25"" QueryID=""ProfDCSTemplateRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#26"" QueryID=""StmtDCSTemplateRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#27"" QueryID=""ApproveTkprRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#28"" QueryID=""MattAttributeRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#29"" QueryID=""MattCategoryRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#30"" QueryID=""MattMinTypeRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#31"" QueryID=""GLProjectRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#32"" QueryID=""WithholdingTaxRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#33"" QueryID=""VolumeDiscountGroupRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#34"" QueryID=""MattInterestRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#35"" QueryID=""ElecDCSTemplateRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#36"" QueryID=""InvoiceOverrideRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#37"" QueryID=""ICBUnitDueToRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#38"" QueryID=""ICBUnitDueFromRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#39"" QueryID=""GLRespTkprRel1"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#40"" QueryID=""BillingOfficeRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#41"" QueryID=""BankAcctApRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#42"" QueryID=""ToTaxAreaRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#43"" QueryID=""WPTypeRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#44"" QueryID=""GLActivityRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#45"" QueryID=""CreditNoteDCSTemplateRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#46"" QueryID=""BillGroupDCSTemplateRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#47"" QueryID=""CreditNoteGroupDCSTemplateRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#48"" QueryID=""Originator_CCCRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#49"" QueryID=""ReportingOfficeRel_CCC"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#50"" QueryID=""ReportOfFindingsRel_CCC"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
  </OQL_CONTEXT>
  <SELECT_LIST>
    <SINGLE_SELECT Union=""Distinct"">
      <NODE NodeID=""Node#1"" />
      <VALUES>
        <VALUE>
          <LEAF QueryID=""MatterID"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""MattIndex"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Number"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""AltNumber"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""DisplayName"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Client"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Number"">
            <NODE NodeID=""Node#2"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""MattInfo"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""RelMattIndex"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Number"">
            <NODE NodeID=""Node#3"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""MattStatus"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#4"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""MattStatusDate"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""MattType"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#5"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""OpenDate"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""ConflictStatus"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#6"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Narrative"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""BillingInstruc"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Language"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#7"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""ContactInfo"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""ReferralInfo"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""MattCloseType"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#8"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""CloseDate"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsMaster"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""NonBillType"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#9"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsProBono"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""ProBonoEntity"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""DisplayName"">
            <NODE NodeID=""Node#10"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""ProBonoInfo"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsAdmin"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""AdminAccount"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""AdminInfo"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""ElecBillingType"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#11"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""ElecNumber"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""ElecInfo"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsNonBillable"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""BillAsMatter"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Number"">
            <NODE NodeID=""Node#12"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""BillSite"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#13"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""StatementSite"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#14"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""OpenTkpr"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Number"">
            <NODE NodeID=""Node#15"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""CloseTkpr"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Number"">
            <NODE NodeID=""Node#16"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Comments"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsDefault"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""BillingFrequency"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#17"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsNoProforma"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsNoBill"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Markup"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#18"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""TimeTaxCode"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#19"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""CostTaxCode"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#20"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""ChrgTaxCode"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#21"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""DueDays"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Currency"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""CurrencyDateList"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#22"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""ElecCostTypeMap"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""TimeIncrement"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#23"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsEngageLetterReq"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""EngageLetterSubDate"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""EngageLetterRecDate"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""EngageLetterComment"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsWaiverLetterReq"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""WaiverLetterSubDate"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""WaiverLetterRecDate"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""WaiverLetterComment"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsConflictsConfidential"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""BillDCSTemplate"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Name"">
            <NODE NodeID=""Node#24"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""ProfDCSTemplate"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Name"">
            <NODE NodeID=""Node#25"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""StmtDCSTemplate"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Name"">
            <NODE NodeID=""Node#26"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""ApproveTkpr"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Number"">
            <NODE NodeID=""Node#27"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""MattAttribute"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#28"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""MattCategory"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#29"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""EntryDate"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""VATRegistration"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""MattMinType"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#30"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""GLProject"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#31"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsForeign"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""WithholdingTax"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#32"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""VolumeDiscountGroup"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#33"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""MattInterest"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#34"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsEBill"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""ElecTitleMap"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""ElecDCSTemplate"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Name"">
            <NODE NodeID=""Node#35"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""PaymentTermsInfo"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsFeeEstimate"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""FeeEstimateAmount"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""EstimatedCompletionDate"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""ApproveDate"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""InvoiceOverride"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#36"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""ProformaEmail"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""BillEmail"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsICBAcctRec"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsICBPayable"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""ICBUnitDueTo"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#37"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""ICBUnitDueFrom"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#38"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""GLRespTkpr"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Number"">
            <NODE NodeID=""Node#39"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsAllowTrustOverdraw"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""BillingOffice"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#40"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""BankAcctAp"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Name"">
            <NODE NodeID=""Node#41"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""TaxReportID1"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""TaxReportID2"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""ToTaxArea"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#42"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsLeadVolumeDiscountMatter"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsBillStatementIncludeDoubtful"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Field1"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Field2"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Field3"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""LoadSource"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""LoadGroup"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""LoadNumber"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""EbillValidationList"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""WPType"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#43"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""GLActivity"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""GLValue"">
            <NODE NodeID=""Node#44"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""CreditNoteDCSTemplate"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Name"">
            <NODE NodeID=""Node#45"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""BillGroupDCSTemplate"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Name"">
            <NODE NodeID=""Node#46"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""CreditNoteGroupDCSTemplate"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Name"">
            <NODE NodeID=""Node#47"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""ElecTaxCodeMap"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""DateOfOccurence_CCC"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""DateOfOccurenceTxt_CCC"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsProspective_CCC"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""isConflictsRoleApproved_CCC"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Originator_CCC"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""BaseUserName"">
            <NODE NodeID=""Node#48"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsWeb_CCC"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""DateReceived_CCC"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""RetainerAmount_CCC"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""ScopeOfWork_CCC"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""ValidationMsg_CCC"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""ReportingOffice_CCC"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#49"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsFixedPrice_CCC"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""DNENotes_CCC"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsConfLetterStd_CCC"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsConfLetterLegal_CCC"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsConfLetterNatAgmt_CCC"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsConfLetterEngSvcs_CCC"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsConfLetterCAT_CCC"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsConfLetterRtnr_CCC"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsConfLetterSign_CCC"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""ReportOfFindings_CCC"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#50"" />
          </LEAF>
        </VALUE>
      </VALUES>
      <WHERE>
<X_IS_EQUAL_TO_Y>
		  <X>
			<LEAF QueryID=""Number"">
			  <NODE NodeID=""Node#1"" />
			</LEAF>
		  </X>
		  <Y>
			<UNICODE_STRING Value=""{0}"" />
		  </Y>
		</X_IS_EQUAL_TO_Y>
             </WHERE>
    </SINGLE_SELECT>
  </SELECT_LIST>
</SELECT>
</QUERY>
";

        public static string GetMatterCPCXOQLByNum = @"

    <SELECT ID=""SelectStatement"" Class=""NextGen.Framework.OQL.Symbols.SelectStatement"" xmlns=""http://elite.com/schemas/query"">
  <OQL_CONTEXT Class=""NextGen.Framework.Managers.ObjectMgr.ExContextProvider"">
    <NODEMAP ID=""Node#1"" QueryID=""Matter"" Class=""NextGen.Application.Query.Matter"" Assembly=""NextGen.Archetype.Matter"" />
    <NODEMAP ID=""Node#2"" QueryID=""Client1"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#3"" QueryID=""MattDate"" Class=""NextGen.Application.Query.MattDate"" Assembly=""NextGen.Archetype.Matter"">
      <NODE NodeID=""Node#1"" />
      <AS_OF_DATE>
        <CURRENT_TIMESTAMP />
      </AS_OF_DATE>
    </NODEMAP>
    <NODEMAP ID=""Node#4"" QueryID=""Office1"">
      <NODE NodeID=""Node#3"" />
    </NODEMAP>
    <NODEMAP ID=""Node#5"" QueryID=""BillTkpr1"">
      <NODE NodeID=""Node#3"" />
    </NODEMAP>
    <NODEMAP ID=""Node#6"" QueryID=""RspTkpr1"">
      <NODE NodeID=""Node#3"" />
    </NODEMAP>
    <NODEMAP ID=""Node#7"" QueryID=""SpvTkpr1"">
      <NODE NodeID=""Node#3"" />
    </NODEMAP>
  </OQL_CONTEXT>
  <SELECT_LIST>
    <SINGLE_SELECT Union=""Distinct"">
      <NODE NodeID=""Node#1"" />
      <VALUES>
        <VALUE>
          <LEAF QueryID=""Number"" Alias=""MattNo"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""DisplayName"" Alias=""MattName"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Number"" Alias=""ClientNo"">
            <NODE NodeID=""Node#2"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""DisplayName"" Alias=""ClientName"">
            <NODE NodeID=""Node#2"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Office"" Alias=""OfficeIndex"">
            <NODE NodeID=""Node#3"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"" Alias=""OfficeName"">
            <NODE NodeID=""Node#4"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""BillTkpr"">
            <NODE NodeID=""Node#3"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""DisplayName"" Alias=""BillTkprName"">
            <NODE NodeID=""Node#5"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""RspTkpr"">
            <NODE NodeID=""Node#3"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""DisplayName"" Alias=""RspTkprName"">
            <NODE NodeID=""Node#6"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""SpvTkpr"">
            <NODE NodeID=""Node#3"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""DisplayName"" Alias=""SpvTkprName"">
            <NODE NodeID=""Node#7"" />
          </LEAF>
        </VALUE>
      </VALUES>
      <WHERE>
        <X_IS_EQUAL_TO_Y>
          <X>
            <LEAF QueryID=""Number"">
              <NODE NodeID=""Node#1"" />
            </LEAF>
          </X>
          <Y>
            <UNICODE_STRING Value=""{0}"" />
          </Y>
        </X_IS_EQUAL_TO_Y>
      </WHERE>
    </SINGLE_SELECT>
  </SELECT_LIST>
</SELECT>



";
    }
}