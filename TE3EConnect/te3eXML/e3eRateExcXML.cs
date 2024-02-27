namespace TE3EConnect.te3eXML
{
    public class e3eRateExcXML
    {
        public static string GetRateExcXML = @"
        <QUERY><SELECT ID=""SelectStatement"" Class=""NextGen.Framework.OQL.Symbols.SelectStatement"" xmlns=""http://elite.com/schemas/query"">
                  <OQL_CONTEXT Class = ""NextGen.Framework.Managers.ObjectMgr.ExContextProvider"">
                    <NODEMAP ID=""Node#1"" QueryID=""RateExc"" Class=""NextGen.Application.Query.RateExc"" Assembly=""NextGen.Archetype.RateExc""/>
                    <NODEMAP ID = ""Node#2"" QueryID=""Client1"">
                      <NODE NodeID = ""Node#1""/>
                    </NODEMAP>
                    <NODEMAP ID=""Node#3"" QueryID=""Matter1"">
                      <NODE NodeID = ""Node#1""/>
                    </NODEMAP>
                    <NODEMAP ID=""Node#4"" QueryID=""RateExcList1"">
                      <NODE NodeID = ""Node#1""/>
                    </NODEMAP>
                    <NODEMAP ID=""Node#5"" QueryID=""CostTypeRel"">
                      <NODE NodeID = ""Node#1""/>
                    </NODEMAP>
                  </OQL_CONTEXT>
                  <SELECT_LIST>
                    <SINGLE_SELECT Union=""Distinct"">
                      <NODE NodeID = ""Node#1""/>
                      <VALUES>
                        <VALUE>
                          <LEAF QueryID=""RateExcID"">
                            <NODE NodeID = ""Node#1""/>
                          </LEAF>
                        </VALUE>
                        <VALUE>
                          <LEAF QueryID=""Description"">
                            <NODE NodeID = ""Node#1""/>
                          </LEAF>
                        </VALUE>
                        <VALUE>
                          <LEAF QueryID=""Client"">
                            <NODE NodeID = ""Node#1""/>
                          </LEAF>
                        </VALUE>
                        <VALUE>
                          <LEAF QueryID=""Number"">
                            <NODE NodeID = ""Node#2""/>
                          </LEAF>
                        </VALUE>
                        <VALUE>
                          <LEAF QueryID=""Matter"">
                            <NODE NodeID = ""Node#1""/>
                          </LEAF>
                        </VALUE>
                        <VALUE>
                          <LEAF QueryID=""Number"">
                            <NODE NodeID = ""Node#3""/>
                          </LEAF>
                        </VALUE>
                        <VALUE>
                          <LEAF QueryID=""StartDate"">
                            <NODE NodeID = ""Node#1""/>
                          </LEAF>
                        </VALUE>
                        <VALUE>
                          <LEAF QueryID=""FinishDate"">
                            <NODE NodeID = ""Node#1""/>
                          </LEAF>
                        </VALUE>
                        <VALUE>
                          <LEAF QueryID=""Currency"">
                            <NODE NodeID = ""Node#1""/>
                          </LEAF>
                        </VALUE>
                        <VALUE>
                          <LEAF QueryID=""RateExcList"">
                            <NODE NodeID = ""Node#1""/>
                          </LEAF>
                        </VALUE>
                        <VALUE>
                          <LEAF QueryID=""Description"">
                            <NODE NodeID = ""Node#4""/>
                          </LEAF>
                        </VALUE>
                        <VALUE>
                          <LEAF QueryID=""IsMaximum"">
                            <NODE NodeID = ""Node#1""/>
                          </LEAF>
                        </VALUE>
                        <VALUE>
                          <LEAF QueryID=""IsMatchCurr"">
                            <NODE NodeID = ""Node#1""/>
                          </LEAF>
                        </VALUE>
                        <VALUE>
                          <LEAF QueryID=""OverrideDate"">
                            <NODE NodeID = ""Node#1""/>
                          </LEAF>
                        </VALUE>
                        <VALUE>
                          <LEAF QueryID=""IsSkipClientExc"">
                            <NODE NodeID = ""Node#1""/>
                          </LEAF>
                        </VALUE>
                        <VALUE>
                          <LEAF QueryID=""CostType"">
                            <NODE NodeID = ""Node#1""/>
                          </LEAF>
                        </VALUE>
                        <VALUE>
                          <LEAF QueryID=""Description"">
                            <NODE NodeID = ""Node#5""/>
                          </LEAF>
                        </VALUE>
                        <VALUE>
                          <LEAF QueryID=""MultiDimensionOrdinal"">
                            <NODE NodeID = ""Node#1""/>
                          </LEAF>
                        </VALUE>
                        <VALUE>
                          <LEAF QueryID=""IsStdRateExc"">
                            <NODE NodeID = ""Node#1""/>
                          </LEAF>
                        </VALUE>
                      </VALUES>
                      <WHERE>
                        <X_IS_EQUAL_TO_Y>
                          <X>
                            <LEAF QueryID=""Description"">
			                  <NODE NodeID = ""Node#1""/>
                            </LEAF>
                          </X>
                          <Y>
                            <UNICODE_STRING Value=""{0}""/>
		                  </Y>
		                </X_IS_EQUAL_TO_Y>
                      </WHERE>
                    </SINGLE_SELECT>
                  </SELECT_LIST>
                </SELECT>
                </QUERY>
";

        public static string GetBillingTitle_CCCXML = @"
        <QUERY><SELECT ID=""SelectStatement"" Class=""NextGen.Framework.OQL.Symbols.SelectStatement"" xmlns=""http://elite.com/schemas/query"">
  <OQL_CONTEXT Class=""NextGen.Framework.Managers.ObjectMgr.ExContextProvider"">
    <NODEMAP ID=""Node#1"" QueryID=""BillingTitle_CCC"" Class=""NextGen.Application.Query.BillingTitle_CCC"" Assembly=""NextGen.Archetype.BillingTitle_CCC"" />
  </OQL_CONTEXT>
  <SELECT_LIST>
    <SINGLE_SELECT Union=""Distinct"">
      <NODE NodeID=""Node#1"" />
      <VALUES>
        <VALUE>
          <LEAF QueryID=""StartDate"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""EndDate"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsActive"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""SortString"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Is_Default"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""InternalComment"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""BillingTitle_CCCID"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Code"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
      </VALUES>
      <WHERE>
        <X_IS_EQUAL_TO_Y>
            <X>
            <LEAF QueryID=""Description"">
			    <NODE NodeID = ""Node#1""/>
            </LEAF>
            </X>
            <Y>
            <UNICODE_STRING Value=""{0}""/>
		    </Y>
		</X_IS_EQUAL_TO_Y>
      </WHERE>
    </SINGLE_SELECT>
  </SELECT_LIST>
</SELECT>
</QUERY>

";

        public static string RateExcXML = @"
        <RateExc xmlns=""http://elite.com/schemas/transaction/process/write/RateExc"">
            <Initialize xmlns = ""http://elite.com/schemas/transaction/object/write/RateExc"">
                {0}
            </Initialize>
        </RateExc>
";

        public static string EditRateExcXML = @"
        <Edit>
            <RateExc KeyValue=""@KeyValue"">
                <Children>
                    <RateExcDet>
                        {0}
                    </RateExcDet>
                </Children>
            </RateExc>
        </Edit>

";

        public static string AddRateExcXML = @"
        <Add>
            <RateExc>
                <Attributes>
                    <Description>@Description</Description>
                    <Client />
                    <Matter />
                    <StartDate>@StartDate</StartDate>
                    <FinishDate></FinishDate>
                    <RateExcList>@RateExcList</RateExcList>
                    <IsMaximum>0</IsMaximum>
                    <IsValidate>0</IsValidate>
                    <IsMatchCurr>0</IsMatchCurr>
                    <OverrideDate></OverrideDate>
                    <IsSkipClientExc>0</IsSkipClientExc>
                    <CostType />
                    <MultiDimensionOrdinal>2</MultiDimensionOrdinal>
                    <IsStdRateExc>0</IsStdRateExc>
                </Attributes>
                <Children>
                    <RateExcDet>
                        {0}
                    </RateExcDet>
                </Children>
            </RateExc>
        </Add>
";

        public static string AddRateExcDetXML = @"
        <Add>
            <RateExcDet>
                <Attributes>
                    <RateOverride>@RateOverride</RateOverride>
                    <Rate />
                    <MaxRate>2</MaxRate>
                    <Currency>USD</Currency>
                    <CurrencyDate>@StartDate</CurrencyDate>
                    <Timekeeper>@Timekeeper</Timekeeper>
                    <Title />
                    <Office />
                    <Section />
                    <RateClass />
                    <Description>@Description</Description>
                    <Department />
                    <CostType />
                    <Startdate>@StartDate</Startdate>
                    <FinishDate></FinishDate>
                    <OverridePercent></OverridePercent>
                    <RoundingMethod />
                    <RateYearRangeMin></RateYearRangeMin>
                    <RateYearRangeMax></RateYearRangeMax>
                    <MatterRateMax></MatterRateMax>
                    <MultiDimensionOrdinal>2</MultiDimensionOrdinal>
                    <MatterRateMin></MatterRateMin>
                    <BillingTitle_CCC>@BillingTitle_CCC</BillingTitle_CCC>
                </Attributes>
            </RateExcDet>
        </Add>

";
    }
}