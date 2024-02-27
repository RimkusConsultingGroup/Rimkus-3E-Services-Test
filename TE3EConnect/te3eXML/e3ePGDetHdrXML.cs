using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TE3EConnect.te3eXML
{
    public static class e3ePGDetHdrXML
    {
        public static string GetPGDetHdrXML = @"
    <SELECT ID=""SelectStatement"" Class=""NextGen.Framework.OQL.Symbols.SelectStatement"" xmlns=""http://elite.com/schemas/query"">
  <OQL_CONTEXT Class = ""NextGen.Framework.Managers.ObjectMgr.ExContextProvider"">
    <NODEMAP ID=""Node#1"" QueryID=""Matter"" Class=""NextGen.Application.Query.Matter"" Assembly=""NextGen.Archetype.Matter"" />
    <NODEMAP ID = ""Node#2"" QueryID=""PGDetHdr_CCC"" Class=""NextGen.Application.Query.PGDetHdr_CCC"" Assembly=""NextGen.Archetype.Matter"" />
  </OQL_CONTEXT>
  <SELECT_LIST>
    <SINGLE_SELECT Union = ""Distinct"">
      <NODE NodeID=""Node#1"" />
      <VALUES>
        <VALUE>
          <LEAF QueryID = ""PGDetHdr_CCCID"">
            <NODE NodeID=""Node#2"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID = ""NxEndDate"">
            <NODE NodeID = ""Node#2"" />
          </LEAF>
        </VALUE>
      </VALUES>
      <JOINS>
        <INNER_JOIN>
          <PRIMARY>
            <NODE NodeID = ""Node#1"" />
          </PRIMARY>
          <SECONDARY>
            <NODE NodeID=""Node#2"" />
          </SECONDARY>
          <ON_CONDITION>
            <X_IS_EQUAL_TO_Y>
              <X>
                <LEAF QueryID = ""MattIndex"">
                  <NODE NodeID=""Node#1"" />
                </LEAF>
              </X>
              <Y>
                <LEAF QueryID = ""MatterLkUp"">
                  <NODE NodeID=""Node#2"" />
                </LEAF>
              </Y>
            </X_IS_EQUAL_TO_Y>
          </ON_CONDITION>
        </INNER_JOIN>
      </JOINS>
        <WHERE>
            <X_IS_EQUAL_TO_Y>
		        <X>
			    <LEAF QueryID = ""Number"">
                    <NODE NodeID=""Node#1"" />
			    </LEAF>
		        </X>
		        <Y>
			        <UNICODE_STRING Value = ""{0}"" />
                </Y>
            </X_IS_EQUAL_TO_Y>
        </WHERE>
    </SINGLE_SELECT>
  </SELECT_LIST>
</SELECT>
";
        public static string GetPGDetChildXML = @"
    <QUERY><SELECT ID=""SelectStatement"" Class=""NextGen.Framework.OQL.Symbols.SelectStatement"" xmlns=""http://elite.com/schemas/query"">
  <OQL_CONTEXT Class = ""NextGen.Framework.Managers.ObjectMgr.ExContextProvider"">
    <NODEMAP ID=""Node#1"" QueryID=""PGDetChild_CCC"" Class=""NextGen.Application.Query.PGDetChild_CCC"" Assembly=""NextGen.Archetype.PGDetChild_CCC"" />
    <NODEMAP ID = ""Node#2"" QueryID=""TriggerTypeRel"">
      <NODE NodeID = ""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#3"" QueryID=""StateRel"">
      <NODE NodeID = ""Node#1"" />
    </NODEMAP>
  </OQL_CONTEXT>
  <SELECT_LIST>
    <SINGLE_SELECT Union=""Distinct"">
      <NODE NodeID = ""Node#1"" />
      <VALUES>
        <VALUE>
          <LEAF QueryID=""PGDetChild_CCCID"">
            <NODE NodeID = ""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""PGDetHdr"">
            <NODE NodeID = ""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""TriggerType"">
            <NODE NodeID = ""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Year"">
            <NODE NodeID = ""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsFederal"">
            <NODE NodeID = ""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsGeneralWork"">
            <NODE NodeID = ""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""State"">
            <NODE NodeID = ""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID = ""Node#3"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Building"">
            <NODE NodeID = ""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Quarter"">
            <NODE NodeID = ""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""OrigCredit"">
            <NODE NodeID = ""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""ValueAssessment"">
            <NODE NodeID = ""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""EngineerReview"">
            <NODE NodeID = ""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""FinalCredit"">
            <NODE NodeID = ""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Interest"">
            <NODE NodeID = ""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Adjustments"">
            <NODE NodeID = ""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Total"">
            <NODE NodeID = ""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Comments"">
            <NODE NodeID = ""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""RevenuePct"">
            <NODE NodeID = ""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""SustentionAmt"">
            <NODE NodeID = ""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""SustentionPct"">
            <NODE NodeID = ""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""MSID"">
            <NODE NodeID = ""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""bldgID"">
            <NODE NodeID = ""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Status"">
            <NODE NodeID = ""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""NewWIPFT"">
            <NODE NodeID = ""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""ControlGroup"">
            <NODE NodeID = ""Node#1"" />
          </LEAF>
        </VALUE>
      </VALUES>
      <WHERE>
       <X_IS_EQUAL_TO_Y>
          <X>
            <LEAF QueryID=""PGDetHdr"">
			  <NODE NodeID = ""Node#1"" />
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
