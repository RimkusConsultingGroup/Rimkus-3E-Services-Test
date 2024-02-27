using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TE3EConnect.te3eXML
{
    public static class e3eClientXML
    {
        public static string GetClientXOQLByName = @"
        <QUERY><SELECT ID=""SelectStatement"" Class=""NextGen.Framework.OQL.Symbols.SelectStatement"" xmlns=""http://elite.com/schemas/query"">
  <OQL_CONTEXT Class=""NextGen.Framework.Managers.ObjectMgr.ExContextProvider"">
    <NODEMAP ID=""Node#1"" QueryID=""Client"" Class=""NextGen.Application.Query.Client"" Assembly=""NextGen.Archetype.Client"" />
    <NODEMAP ID=""Node#2"" QueryID=""Entity1"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#3"" QueryID=""RelatedClient1"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#4"" QueryID=""CliType1"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#5"" QueryID=""CliStatusType1"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#6"" QueryID=""InvoiceSite1"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#7"" QueryID=""StatementSite1"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#8"" QueryID=""Industry1"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#9"" QueryID=""Language1"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#10"" QueryID=""OpenTkprRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#11"" QueryID=""CloseTkprRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#12"" QueryID=""ProfDCSTemplateRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#13"" QueryID=""BillDCSTemplateRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#14"" QueryID=""StmtDCSTemplateRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#15"" QueryID=""CountryRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#16"" QueryID=""CliAttributeRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#17"" QueryID=""CliCategoryRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#18"" QueryID=""ApproveTkprRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#19"" QueryID=""ConflictStatusRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#20"" QueryID=""VolumeDiscountRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#21"" QueryID=""ICBUnitRel1"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#22"" QueryID=""CreditNoteDCSTemplateRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#23"" QueryID=""BillGroupDCSTemplateRel1"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#24"" QueryID=""CreditNoteGroupDCSTemplateRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
  </OQL_CONTEXT>
  <SELECT_LIST>
    <SINGLE_SELECT Union=""Distinct"">
      <NODE NodeID=""Node#1"" />
      <VALUES>
        <VALUE>
          <LEAF QueryID=""ClientID"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Entity"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""DisplayName"">
            <NODE NodeID=""Node#2"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""ClientIndex"">
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
          <LEAF QueryID=""SortString"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""RelatedClient"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Number"">
            <NODE NodeID=""Node#3"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""CliType"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#4"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""CliStatusType"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#5"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""CliStatusDate"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""CreditLimit"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Currency"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""CurrencyDate"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""OpenDate"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsPayor"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""InvoiceSite"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#6"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""StatementSite"">
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
          <LEAF QueryID=""Industry"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#8"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Narrative"">
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
            <NODE NodeID=""Node#9"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""BillingInstruc"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""OpenTkpr"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Number"">
            <NODE NodeID=""Node#10"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""CloseTkpr"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Number"">
            <NODE NodeID=""Node#11"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""CloseDate"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""ProfDCSTemplate"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Name"">
            <NODE NodeID=""Node#12"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""BillDCSTemplate"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Name"">
            <NODE NodeID=""Node#13"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""StmtDCSTemplate"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Name"">
            <NODE NodeID=""Node#14"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Country"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#15"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""CliAttribute"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#16"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""CliCategory"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#17"" />
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
          <LEAF QueryID=""ApproveTkpr"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Number"">
            <NODE NodeID=""Node#18"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""ConflictStatus"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#19"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsIdentified"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IdentificationDate"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""VolumeDiscountGroup"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#20"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsEBill"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""DueDays"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""ApproveDate"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsICB"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""ICBUnit"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#21"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsCreateTaxInvOnRcpt"">
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
          <LEAF QueryID=""RSSFeed"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""TickerSymbol"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""URL"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""CreditNoteDCSTemplate"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Name"">
            <NODE NodeID=""Node#22"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""BillGroupDCSTemplate"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Name"">
            <NODE NodeID=""Node#23"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""CreditNoteGroupDCSTemplate"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Name"">
            <NODE NodeID=""Node#24"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsNoTC_CCC"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
      </VALUES>
      <WHERE>
        <X_AND_Y>
            <X>
                <X_IS_EQUAL_TO_Y>
					<X>
						<LEAF QueryID=""DisplayName"">
							<NODE NodeID = ""Node#2"" />
                        </LEAF>
                    </X>
                    <Y>
                        <UNICODE_STRING Value=""{0}"" />
					</Y>
				</X_IS_EQUAL_TO_Y>
		    </X>
			<Y>
				<X_IS_EQUAL_TO_Y>
					<X>
						<LEAF QueryID = ""CliStatusType"">
                            <NODE NodeID=""Node#1"" />
						</LEAF>
					</X>
					<Y>
						<UNICODE_STRING Value = ""100"" />
                    </Y>
                </X_IS_EQUAL_TO_Y>
          </Y>
        </X_AND_Y>
      </WHERE>
    </SINGLE_SELECT>
  </SELECT_LIST>
</SELECT>
</QUERY>
";

        public static string GetClientXOQLByNum = @"

        <QUERY><SELECT ID=""SelectStatement"" Class=""NextGen.Framework.OQL.Symbols.SelectStatement"" xmlns=""http://elite.com/schemas/query"">
  <OQL_CONTEXT Class=""NextGen.Framework.Managers.ObjectMgr.ExContextProvider"">
    <NODEMAP ID=""Node#1"" QueryID=""Client"" Class=""NextGen.Application.Query.Client"" Assembly=""NextGen.Archetype.Client"" />
    <NODEMAP ID=""Node#2"" QueryID=""Entity1"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#3"" QueryID=""RelatedClient1"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#4"" QueryID=""CliType1"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#5"" QueryID=""CliStatusType1"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#6"" QueryID=""InvoiceSite1"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#7"" QueryID=""StatementSite1"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#8"" QueryID=""Industry1"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#9"" QueryID=""Language1"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#10"" QueryID=""OpenTkprRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#11"" QueryID=""CloseTkprRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#12"" QueryID=""ProfDCSTemplateRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#13"" QueryID=""BillDCSTemplateRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#14"" QueryID=""StmtDCSTemplateRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#15"" QueryID=""CountryRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#16"" QueryID=""CliAttributeRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#17"" QueryID=""CliCategoryRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#18"" QueryID=""ApproveTkprRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#19"" QueryID=""ConflictStatusRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#20"" QueryID=""VolumeDiscountRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#21"" QueryID=""ICBUnitRel1"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#22"" QueryID=""CreditNoteDCSTemplateRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#23"" QueryID=""BillGroupDCSTemplateRel1"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#24"" QueryID=""CreditNoteGroupDCSTemplateRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
  </OQL_CONTEXT>
  <SELECT_LIST>
    <SINGLE_SELECT Union=""Distinct"">
      <NODE NodeID=""Node#1"" />
      <VALUES>
        <VALUE>
          <LEAF QueryID=""ClientID"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Entity"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""DisplayName"">
            <NODE NodeID=""Node#2"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""ClientIndex"">
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
          <LEAF QueryID=""SortString"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""RelatedClient"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Number"">
            <NODE NodeID=""Node#3"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""CliType"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#4"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""CliStatusType"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#5"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""CliStatusDate"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""CreditLimit"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Currency"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""CurrencyDate"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""OpenDate"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsPayor"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""InvoiceSite"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#6"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""StatementSite"">
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
          <LEAF QueryID=""Industry"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#8"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Narrative"">
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
            <NODE NodeID=""Node#9"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""BillingInstruc"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""OpenTkpr"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Number"">
            <NODE NodeID=""Node#10"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""CloseTkpr"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Number"">
            <NODE NodeID=""Node#11"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""CloseDate"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""ProfDCSTemplate"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Name"">
            <NODE NodeID=""Node#12"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""BillDCSTemplate"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Name"">
            <NODE NodeID=""Node#13"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""StmtDCSTemplate"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Name"">
            <NODE NodeID=""Node#14"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Country"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#15"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""CliAttribute"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#16"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""CliCategory"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#17"" />
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
          <LEAF QueryID=""ApproveTkpr"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Number"">
            <NODE NodeID=""Node#18"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""ConflictStatus"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#19"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsIdentified"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IdentificationDate"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""VolumeDiscountGroup"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#20"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsEBill"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""DueDays"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""ApproveDate"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsICB"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""ICBUnit"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#21"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsCreateTaxInvOnRcpt"">
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
          <LEAF QueryID=""RSSFeed"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""TickerSymbol"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""URL"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""CreditNoteDCSTemplate"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Name"">
            <NODE NodeID=""Node#22"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""BillGroupDCSTemplate"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Name"">
            <NODE NodeID=""Node#23"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""CreditNoteGroupDCSTemplate"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Name"">
            <NODE NodeID=""Node#24"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsNoTC_CCC"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
      </VALUES>
      <WHERE>
        <X_AND_Y>
            <X>
                <X_IS_EQUAL_TO_Y>
					<X>
						<LEAF QueryID=""Number"">
							<NODE NodeID = ""Node#1"" />
                        </LEAF>
                    </X>
                    <Y>
                        <UNICODE_STRING Value=""{0}"" />
					</Y>
				</X_IS_EQUAL_TO_Y>
		    </X>
			<Y>
				<X_IS_EQUAL_TO_Y>
					<X>
						<LEAF QueryID = ""CliStatusType"">
                            <NODE NodeID=""Node#1"" />
						</LEAF>
					</X>
					<Y>
						<UNICODE_STRING Value = ""100"" />
                    </Y>
                </X_IS_EQUAL_TO_Y>
          </Y>
        </X_AND_Y>
      </WHERE>
    </SINGLE_SELECT>
  </SELECT_LIST>
</SELECT>
</QUERY>
";
    }
}
