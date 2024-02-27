using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TE3EConnect.te3eXML
{
    public static class e3eTimeKeeperXML
    {
        public static string GetTimeKeeperByNumXML = @"
<QUERY><SELECT ID=""SelectStatement"" Class=""NextGen.Framework.OQL.Symbols.SelectStatement"" xmlns=""http://elite.com/schemas/query"">
  <OQL_CONTEXT Class=""NextGen.Framework.Managers.ObjectMgr.ExContextProvider"">
    <NODEMAP ID=""Node#1"" QueryID=""Timekeeper"" Class=""NextGen.Application.Query.Timekeeper"" Assembly=""NextGen.Archetype.Timekeeper"" />
    <NODEMAP ID=""Node#2"" QueryID=""EntityPerson"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#3"" QueryID=""TkprStatus1"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#4"" QueryID=""GLTimekeeper1"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#5"" QueryID=""LanguageRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#6"" QueryID=""TkprTypeRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#7"" QueryID=""TkprAttributeRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#8"" QueryID=""TkprCategoryRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#9"" QueryID=""ProfDCSTemplateRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#10"" QueryID=""BillDCSTemplateRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#11"" QueryID=""StmtDCSTemplateRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#12"" QueryID=""CreditNoteDCSTemplateRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#13"" QueryID=""BillGroupDCSTemplateRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#14"" QueryID=""CreditNoteGroupDCSTemplateRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#15"" QueryID=""WF_UserRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
  </OQL_CONTEXT>
  <SELECT_LIST>
    <SINGLE_SELECT Union=""Distinct"">
      <NODE NodeID=""Node#1"" />
      <VALUES>
        <VALUE>
          <LEAF QueryID=""TimekeeperID"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""TkprIndex"">
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
          <LEAF QueryID=""DisplayName"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""BillName"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""BillInitial"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""TkprStatus"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#3"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""SortName"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""GLTimekeeper"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""GLValue"">
            <NODE NodeID=""Node#4"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Language"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#5"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Narrative"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""PayrollNumber"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""PhysicalLocation"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""HRTitle"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""HRNumber"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""JDDate"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""CompDate"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""TkprType"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#6"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""TkprAttribute"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#7"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""TkprCategory"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#8"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""ProfDCSTemplate"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Name"">
            <NODE NodeID=""Node#9"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""BillDCSTemplate"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Name"">
            <NODE NodeID=""Node#10"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""StmtDCSTemplate"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Name"">
            <NODE NodeID=""Node#11"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""RateYear"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""WestLawUserIDNum"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""WestLawContactIDNum"">
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
            <NODE NodeID=""Node#12"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""BillGroupDCSTemplate"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Name"">
            <NODE NodeID=""Node#13"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""CreditNoteGroupDCSTemplate"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Name"">
            <NODE NodeID=""Node#14"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""WF_User"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""BaseUserName"">
            <NODE NodeID=""Node#15"" />
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

        public static string GetTimeKeeperXML = @"
            <QUERY><SELECT ID=""SelectStatement"" Class=""NextGen.Framework.OQL.Symbols.SelectStatement"" xmlns=""http://elite.com/schemas/query"">
  <OQL_CONTEXT Class=""NextGen.Framework.Managers.ObjectMgr.ExContextProvider"">
    <NODEMAP ID=""Node#1"" QueryID=""Timekeeper"" Class=""NextGen.Application.Query.Timekeeper"" Assembly=""NextGen.Archetype.Timekeeper"" />
    <NODEMAP ID=""Node#2"" QueryID=""EntityPerson"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#3"" QueryID=""TkprStatus1"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#4"" QueryID=""GLTimekeeper1"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#5"" QueryID=""LanguageRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#6"" QueryID=""TkprTypeRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#7"" QueryID=""TkprAttributeRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#8"" QueryID=""TkprCategoryRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#9"" QueryID=""ProfDCSTemplateRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#10"" QueryID=""BillDCSTemplateRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#11"" QueryID=""StmtDCSTemplateRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#12"" QueryID=""CreditNoteDCSTemplateRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#13"" QueryID=""BillGroupDCSTemplateRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#14"" QueryID=""CreditNoteGroupDCSTemplateRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#15"" QueryID=""WF_UserRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
  </OQL_CONTEXT>
  <SELECT_LIST>
    <SINGLE_SELECT Union=""Distinct"">
      <NODE NodeID=""Node#1"" />
      <VALUES>
        <VALUE>
          <LEAF QueryID=""TimekeeperID"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""TkprIndex"">
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
          <LEAF QueryID=""DisplayName"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""BillName"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""BillInitial"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""TkprStatus"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#3"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""SortName"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""GLTimekeeper"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""GLValue"">
            <NODE NodeID=""Node#4"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Language"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#5"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Narrative"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""PayrollNumber"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""PhysicalLocation"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""HRTitle"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""HRNumber"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""JDDate"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""CompDate"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""TkprType"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#6"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""TkprAttribute"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#7"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""TkprCategory"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#8"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""ProfDCSTemplate"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Name"">
            <NODE NodeID=""Node#9"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""BillDCSTemplate"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Name"">
            <NODE NodeID=""Node#10"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""StmtDCSTemplate"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Name"">
            <NODE NodeID=""Node#11"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""RateYear"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""WestLawUserIDNum"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""WestLawContactIDNum"">
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
            <NODE NodeID=""Node#12"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""BillGroupDCSTemplate"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Name"">
            <NODE NodeID=""Node#13"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""CreditNoteGroupDCSTemplate"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Name"">
            <NODE NodeID=""Node#14"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""WF_User"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""BaseUserName"">
            <NODE NodeID=""Node#15"" />
          </LEAF>
        </VALUE>
      </VALUES>
      <WHERE>
        <X_IS_EQUAL_TO_Y>
		  <X>
			<LEAF QueryID=""DisplayName"">
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
    }
}
