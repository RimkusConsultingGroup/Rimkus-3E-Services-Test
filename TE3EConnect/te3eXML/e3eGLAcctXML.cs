using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TE3EConnect.te3eXML
{
    public static class e3eGLAcctXML
    {
        public static string GetGLAccountXML = @"
<QUERY><SELECT ID=""SelectStatement"" Class=""NextGen.Framework.OQL.Symbols.SelectStatement"" xmlns=""http://elite.com/schemas/query"">
  <OQL_CONTEXT Class=""NextGen.Framework.Managers.ObjectMgr.ExContextProvider"">
    <NODEMAP ID=""Node#1"" QueryID=""GLAcct"" Class=""NextGen.Application.Query.GLAcct"" Assembly=""NextGen.Archetype.GLAcct"" />
    <NODEMAP ID=""Node#2"" QueryID=""TimekeeperRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#3"" QueryID=""GLNaturalRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#4"" QueryID=""NxUnitRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#5"" QueryID=""GLArrangementRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#6"" QueryID=""GLUnitRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#7"" QueryID=""GLOfficeRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#8"" QueryID=""GLDepartmentRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#9"" QueryID=""GLPracticeGroupRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#10"" QueryID=""GLSectionRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#11"" QueryID=""GLTimekeeperRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#12"" QueryID=""GLTitleRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#13"" QueryID=""GLUnitLocalRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#14"" QueryID=""GLWorkTypeRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#15"" QueryID=""GLTypeRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#16"" QueryID=""GLActivityRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
  </OQL_CONTEXT>
  <SELECT_LIST>
    <SINGLE_SELECT Union=""Distinct"">
      <NODE NodeID=""Node#1"" />
      <VALUES>
        <VALUE>
          <LEAF QueryID=""GLAcctID"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""AcctIndex"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Timekeeper"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Number"">
            <NODE NodeID=""Node#2"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""ExportGLNum"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsControl"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsActive"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsRollup"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsParent"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsAggregate"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""GLNatural"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""GLNat"">
            <NODE NodeID=""Node#3"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""GLLocal"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""NxUnit"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#4"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""RestrictCurr"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""GLArrangement"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""GLValue"">
            <NODE NodeID=""Node#5"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""GLUnit"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""GLValue"">
            <NODE NodeID=""Node#6"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""GLOffice"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""GLValue"">
            <NODE NodeID=""Node#7"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""GLDepartment"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""GLValue"">
            <NODE NodeID=""Node#8"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""GLPracticeGroup"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""GLValue"">
            <NODE NodeID=""Node#9"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""GLSection"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""GLValue"">
            <NODE NodeID=""Node#10"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""GLTimekeeper"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""GLValue"">
            <NODE NodeID=""Node#11"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""GLTitle"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""GLValue"">
            <NODE NodeID=""Node#12"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""GLUnitLocal"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""GLLocal"">
            <NODE NodeID=""Node#13"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""GLWorkType"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""GLValue"">
            <NODE NodeID=""Node#14"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsPostable"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""MaskedAlias"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""UnMaskedAlias"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsCreateZeroGJE"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""GLType"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#15"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""GLActivity"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""GLValue"">
            <NODE NodeID=""Node#16"" />
          </LEAF>
        </VALUE>
      </VALUES>
      <WHERE>
       <X_AND_Y>
            <X>
                <X_IS_EQUAL_TO_Y>
					<X>
						<LEAF QueryID=""MaskedAlias"">
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
						<LEAF QueryID = ""IsActive"">
                            <NODE NodeID=""Node#1"" />
						</LEAF>
					</X>
					<Y>
						<UNICODE_STRING Value = ""1"" />
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
