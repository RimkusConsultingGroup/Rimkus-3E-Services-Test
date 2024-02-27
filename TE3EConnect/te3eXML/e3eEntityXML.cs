using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TE3EConnect.te3eXML
{
    public static class e3eEntityXML
    {
        public static string GetEntityByDisplayNameXML = @"
        <QUERY><SELECT ID=""SelectStatement"" Class=""NextGen.Framework.OQL.Symbols.SelectStatement"" xmlns=""http://elite.com/schemas/query"">
  <OQL_CONTEXT Class = ""NextGen.Framework.Managers.ObjectMgr.ExContextProvider"">
    <NODEMAP ID=""Node#1"" QueryID=""Entity"" Class=""NextGen.Application.Query.Entity"" Assembly=""NextGen.Archetype.Entity"" />
    <NODEMAP ID = ""Node#2"" QueryID=""EntityType1"">
      <NODE NodeID = ""Node#1"" />
    </NODEMAP>
  </OQL_CONTEXT>
  <SELECT_LIST>
    <SINGLE_SELECT Union=""Distinct"">
      <NODE NodeID = ""Node#1"" />
      <VALUES>
        <VALUE>
          <LEAF QueryID=""EntityID"">
            <NODE NodeID = ""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""EntIndex"">
            <NODE NodeID = ""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""DisplayName"">
            <NODE NodeID = ""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""EntityType"">
            <NODE NodeID = ""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID = ""Node#2"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Comment"">
            <NODE NodeID = ""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""TaxID"">
            <NODE NodeID = ""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""SyncID"">
            <NODE NodeID = ""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Is3EOwned"">
            <NODE NodeID = ""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""EntitySanction"">
            <NODE NodeID = ""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""AltNum"">
            <NODE NodeID = ""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""LoadSource"">
            <NODE NodeID = ""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""LoadGroup"">
            <NODE NodeID = ""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""LoadNumber"">
            <NODE NodeID = ""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsChangeAll"">
            <NODE NodeID = ""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsMerged"">
            <NODE NodeID = ""Node#1"" />
          </LEAF>
        </VALUE>
      </VALUES>
      <WHERE>
        <X_IS_EQUAL_TO_Y>
          <X>
            <LEAF QueryID=""DisplayName"">
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

        
        public static string GetEntityAdditionalRefSourceXML = @"
        <QUERY><SELECT ID=""SelectStatement"" Class=""NextGen.Framework.OQL.Symbols.SelectStatement"" xmlns=""http://elite.com/schemas/query"">
  <OQL_CONTEXT Class = ""NextGen.Framework.Managers.ObjectMgr.ExContextProvider"">
    <NODEMAP ID=""Node#1"" QueryID=""Entity"" Class=""NextGen.Application.Query.Entity"" Assembly=""NextGen.Archetype.Entity"" />
    <NODEMAP ID = ""Node#2"" QueryID=""EntityType1"">
      <NODE NodeID = ""Node#1"" />
    </NODEMAP>
  </OQL_CONTEXT>
  <SELECT_LIST>
    <SINGLE_SELECT Union=""Distinct"">
      <NODE NodeID = ""Node#1"" />
      <VALUES>
        <VALUE>
          <LEAF QueryID=""EntityID"">
            <NODE NodeID = ""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""EntIndex"">
            <NODE NodeID = ""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""DisplayName"">
            <NODE NodeID = ""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""EntityType"">
            <NODE NodeID = ""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID = ""Node#2"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Comment"">
            <NODE NodeID = ""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""TaxID"">
            <NODE NodeID = ""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""SyncID"">
            <NODE NodeID = ""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Is3EOwned"">
            <NODE NodeID = ""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""EntitySanction"">
            <NODE NodeID = ""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""AltNum"">
            <NODE NodeID = ""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""LoadSource"">
            <NODE NodeID = ""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""LoadGroup"">
            <NODE NodeID = ""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""LoadNumber"">
            <NODE NodeID = ""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsChangeAll"">
            <NODE NodeID = ""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsMerged"">
            <NODE NodeID = ""Node#1"" />
          </LEAF>
        </VALUE>
      </VALUES>
      <WHERE>
         <X_AND_Y>
            <X>
                <X_IS_EQUAL_TO_Y>
					<X>
						<LEAF QueryID=""DisplayName"">
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
						<LEAF QueryID = ""LoadSource"">
                            <NODE NodeID=""Node#1"" />
						</LEAF>
					</X>
					<Y>
						<UNICODE_STRING Value = ""AdditionalRefSource"" />
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

        public static string GetEntityCPAXML = @"
        <QUERY><SELECT ID=""SelectStatement"" Class=""NextGen.Framework.OQL.Symbols.SelectStatement"" xmlns=""http://elite.com/schemas/query"">
  <OQL_CONTEXT Class = ""NextGen.Framework.Managers.ObjectMgr.ExContextProvider"">
    <NODEMAP ID=""Node#1"" QueryID=""Entity"" Class=""NextGen.Application.Query.Entity"" Assembly=""NextGen.Archetype.Entity"" />
    <NODEMAP ID = ""Node#2"" QueryID=""EntityType1"">
      <NODE NodeID = ""Node#1"" />
    </NODEMAP>
  </OQL_CONTEXT>
  <SELECT_LIST>
    <SINGLE_SELECT Union=""Distinct"">
      <NODE NodeID = ""Node#1"" />
      <VALUES>
        <VALUE>
          <LEAF QueryID=""EntityID"">
            <NODE NodeID = ""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""EntIndex"">
            <NODE NodeID = ""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""DisplayName"">
            <NODE NodeID = ""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""EntityType"">
            <NODE NodeID = ""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID = ""Node#2"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Comment"">
            <NODE NodeID = ""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""TaxID"">
            <NODE NodeID = ""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""SyncID"">
            <NODE NodeID = ""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Is3EOwned"">
            <NODE NodeID = ""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""EntitySanction"">
            <NODE NodeID = ""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""AltNum"">
            <NODE NodeID = ""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""LoadSource"">
            <NODE NodeID = ""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""LoadGroup"">
            <NODE NodeID = ""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""LoadNumber"">
            <NODE NodeID = ""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsChangeAll"">
            <NODE NodeID = ""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsMerged"">
            <NODE NodeID = ""Node#1"" />
          </LEAF>
        </VALUE>
      </VALUES>
      <WHERE>
         <X_AND_Y>
            <X>
                <X_IS_EQUAL_TO_Y>
					<X>
						<LEAF QueryID=""DisplayName"">
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
						<LEAF QueryID = ""EntityType"">
                            <NODE NodeID=""Node#1"" />
						</LEAF>
					</X>
					<Y>
						<UNICODE_STRING Value = ""DEFAULT"" />
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
