using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TE3EConnect.te3eXML.CliShortEntry
{
    public static partial class e3eCliShortEntryXML
    {
        public static string EditClientSrvXml = @"
 <Edit>
            <Client KeyValue=""{ClientKey}"">
                <Attributes>
                    <Entity />
                    <Number>NewValue</Number>
                    <AltNumber>NewValue</AltNumber>
                    <DisplayName>NewValue</DisplayName>
                    <SortString>NewValue</SortString>
                    <RelatedClient />
                    <CliType />
                    <CliStatusType />
                    <CliStatusDate>0001-01-02T00:00:00</CliStatusDate>
                    <CreditLimit>1</CreditLimit>
                    <Currency />
                    <CurrencyDate>0001-01-02T00:00:00</CurrencyDate>
                    <OpenDate>0001-01-02T00:00:00</OpenDate>
                    <InvoiceSite />
                    <StatementSite />
                    <ContactInfo>NewValue</ContactInfo>
                    <Industry />
                    <Narrative>NewValue</Narrative>
                    <Language />
                    <IsPayor>1</IsPayor>
                    <PayorIndex>1</PayorIndex>
                    <BillingInstruc>NewValue</BillingInstruc>
                    <Description>NewValue</Description>
                    <OpenTkpr />
                    <CloseTkpr />
                    <CloseDate>0001-01-02T00:00:00</CloseDate>
                    <IsAutoNumbering>1</IsAutoNumbering>
                    <BillDCSTemplate />
                    <StmtDCSTemplate />
                    <Country />
                    <CliAttribute />
                    <CliCategory />
                    <EntryDate>0001-01-02T00:00:00</EntryDate>
                    <VATRegistration>NewValue</VATRegistration>
                    <IsEngageLetterReq>1</IsEngageLetterReq>
                    <EngageLetterSubDate>0001-01-02T00:00:00</EngageLetterSubDate>
                    <EngageLetterRecDate>0001-01-02T00:00:00</EngageLetterRecDate>
                    <EngageLetterComment>NewValue</EngageLetterComment>
                    <IsWaiverLetterReq>1</IsWaiverLetterReq>
                    <WaiverLetterSubDate>0001-01-02T00:00:00</WaiverLetterSubDate>
                    <WaiverLetterRecDate>0001-01-02T00:00:00</WaiverLetterRecDate>
                    <WaiverLetterComment>NewValue</WaiverLetterComment>
                    <IsConflictsConfidential>1</IsConflictsConfidential>
                    <ApproveTkpr />
                    <ConflictStatus />
                    <ProfDCSTemplate />
                    <IsIdentified>1</IsIdentified>
                    <IdentificationDate>0001-01-02T00:00:00</IdentificationDate>
                    <VolumeDiscountGroup />
                    <IsEBill>1</IsEBill>
                    <DueDays>1</DueDays>
                    <ApproveDate>0001-01-02T00:00:00</ApproveDate>
                    <IsOrigClosedStatus>1</IsOrigClosedStatus>
                    <IsNumberEnabled>1</IsNumberEnabled>
                    <IsCreateTaxInvOnRcpt>1</IsCreateTaxInvOnRcpt>
                    <IsICB>1</IsICB>
                    <ICBUnit />
                    <StmtSitePrimPhone>NewValue</StmtSitePrimPhone>
                    <InvSitePrimPhone>NewValue</InvSitePrimPhone>
                    <PayorTaxArea />
                    <PayorTaxNum>NewValue</PayorTaxNum>
                    <IsNewEntity>1</IsNewEntity>
                    <NewEntityIndex>1</NewEntityIndex>
                    <LoadGroup>NewValue</LoadGroup>
                    <LoadNumber>NewValue</LoadNumber>
                    <LoadSource>NewValue</LoadSource>
                    <RSSFeed>NewValue</RSSFeed>
                    <TickerSymbol>NewValue</TickerSymbol>
                    <URL>NewValue</URL>
                    <CreditNoteDCSTemplate />
                    <BillGroupDCSTemplate />
                    <CreditNoteGroupDCSTemplate />
                    <IsNoTC_CCC>1</IsNoTC_CCC>
                </Attributes>
                <Children>
                    <CliDate>
                        <Edit>
                            <CliDate KeyValue=""{CliDateKey}"">
                                <Attributes>
                                    <EffStart>0001-01-02T00:00:00</EffStart>
                                    <Office />
                                    <TkprTeam />
                                    <Arrangement />
                                    <RspTkpr />
                                    <BillTkpr />
                                    <SpvTkpr />
                                    <NxStartDate>0001-01-02T00:00:00</NxStartDate>
                                </Attributes>
                                <Children>
                                    <CliOrgTkpr>
                                        <Edit>
                                            <CliOrgTkpr KeyValue=""{CliOrgTkprKey}"">
                                                <Attributes>
                                                    <Timekeeper />
                                                    <Percentage>1</Percentage>
                                                    <IsPrimary>1</IsPrimary>
                                                </Attributes>
                                            </CliOrgTkpr>
                                        </Edit>
                                    </CliOrgTkpr>
                                    <CliPlfrTkpr>
                                        <Edit>
                                            <CliPlfrTkpr KeyValue=""{CliPlfrTkprKey}"">
                                                <Attributes>
                                                    <Timekeeper />
                                                    <Percentage>1</Percentage>
                                                    <IsPrimary>1</IsPrimary>
                                                </Attributes>
                                            </CliPlfrTkpr>
                                        </Edit>
                                    </CliPlfrTkpr>
                                </Children>
                            </CliDate>
                        </Edit>
                    </CliDate>
                    <RateExc>
                        <Edit>
                            <RateExc KeyValue=""{RateExcKey}"">
                                <Attributes>
                                    <Description>NewValue</Description>
                                    <Matter />
                                    <StartDate>0001-01-02T00:00:00</StartDate>
                                    <FinishDate>0001-01-02T00:00:00</FinishDate>
                                    <RateExcList />
                                    <IsMaximum>1</IsMaximum>
                                    <IsValidate>1</IsValidate>
                                    <IsMatchCurr>1</IsMatchCurr>
                                    <OverrideDate>0001-01-02T00:00:00</OverrideDate>
                                    <IsSkipClientExc>1</IsSkipClientExc>
                                    <CostType />
                                    <MultiDimensionOrdinal>1</MultiDimensionOrdinal>
                                    <IsStdRateExc>1</IsStdRateExc>
                                </Attributes>
                                <Children>
                                    <RateExcDet>
                                        <Edit>
                                            <RateExcDet KeyValue=""{RateExcDetKey}"">
                                                <Attributes>
                                                    <RateOverride>1</RateOverride>
                                                    <Rate />
                                                    <MaxRate>1</MaxRate>
                                                    <Currency />
                                                    <CurrencyDate>0001-01-02T00:00:00</CurrencyDate>
                                                    <Timekeeper />
                                                    <Title />
                                                    <Office />
                                                    <Section />
                                                    <RateClass />
                                                    <Description>NewValue</Description>
                                                    <Department />
                                                    <CostType />
                                                    <Startdate>0001-01-02T00:00:00</Startdate>
                                                    <FinishDate>0001-01-02T00:00:00</FinishDate>
                                                    <OverridePercent>1</OverridePercent>
                                                    <RoundingMethod />
                                                    <RateYearRangeMin>1</RateYearRangeMin>
                                                    <RateYearRangeMax>1</RateYearRangeMax>
                                                    <MatterRateMax>1</MatterRateMax>
                                                    <MultiDimensionOrdinal>1</MultiDimensionOrdinal>
                                                    <MatterRateMin>1</MatterRateMin>
                                                    <DeviationAmount>1</DeviationAmount>
                                                </Attributes>
                                            </RateExcDet>
                                        </Edit>
                                    </RateExcDet>
                                    <RateExcClientList>
                                        <Edit>
                                            <RateExcClientList KeyValue=""{RateExcClientListKey}"">
                                                <Attributes>
                                                    <Client />
                                                    <StartDate>0001-01-02T00:00:00</StartDate>
                                                    <EndDate>0001-01-02T00:00:00</EndDate>
                                                </Attributes>
                                            </RateExcClientList>
                                        </Edit>
                                    </RateExcClientList>
                                    <RateExcMatterList>
                                        <Edit>
                                            <RateExcMatterList KeyValue=""{RateExcMatterListKey}"">
                                                <Attributes>
                                                    <Matter />
                                                    <StartDate>0001-01-02T00:00:00</StartDate>
                                                    <EndDate>0001-01-02T00:00:00</EndDate>
                                                </Attributes>
                                            </RateExcMatterList>
                                        </Edit>
                                    </RateExcMatterList>
                                </Children>
                            </RateExc>
                        </Edit>
                    </RateExc>
                    <CliBillingContact>
                        <Edit>
                            <CliBillingContact KeyValue=""{CliBillingContactKey}"">
                                <Attributes>
                                    <StartDate>0001-01-02T00:00:00</StartDate>
                                    <FinishDate>0001-01-02T00:00:00</FinishDate>
                                    <EntityPerson />
                                    <BillingContactType />
                                    <EntityPosition>NewValue</EntityPosition>
                                </Attributes>
                            </CliBillingContact>
                        </Edit>
                    </CliBillingContact>
                    <ClientRateExc>
                        <Edit>
                            <ClientRateExc KeyValue=""{ClientRateExcKey}"">
                                <Attributes>
                                    <RateExc />
                                    <StartDate>0001-01-02T00:00:00</StartDate>
                                    <EndDate>0001-01-02T00:00:00</EndDate>
                                </Attributes>
                            </ClientRateExc>
                        </Edit>
                    </ClientRateExc>
                    <CliTemplateOption>
                        <Edit>
                            <CliTemplateOption KeyValue=""{CliTemplateOptionKey}"">
                                <Attributes>
                                    <BillTemplateOptionValue />
                                    <BillTemplateOption />
                                </Attributes>
                            </CliTemplateOption>
                        </Edit>
                    </CliTemplateOption>
                    <CliProfAdjust>
                        <Edit>
                            <CliProfAdjust KeyValue=""{CliProfAdjustKey}"">
                                <Attributes>
                                    <Percentage>1</Percentage>
                                    <Amount>1</Amount>
                                    <Currency />
                                    <StartDate>0001-01-02T00:00:00</StartDate>
                                    <EndDate>0001-01-02T00:00:00</EndDate>
                                    <Description>NewValue</Description>
                                    <Timekeeper />
                                    <ProfAdjustMethodList />
                                    <ProfAdjustType />
                                    <IsIncludeOtherAdjustments>1</IsIncludeOtherAdjustments>
                                    <BillAmount>1</BillAmount>
                                    <ProfEnd>0001-01-02T00:00:00</ProfEnd>
                                    <ProfStart>0001-01-02T00:00:00</ProfStart>
                                    <ChrgCardFilter>NewValue</ChrgCardFilter>
                                    <CostCardFilter>NewValue</CostCardFilter>
                                    <TimeCardFilter>NewValue</TimeCardFilter>
                                    <IsAdjustWithFilters>1</IsAdjustWithFilters>
                                </Attributes>
                            </CliProfAdjust>
                        </Edit>
                    </CliProfAdjust>
                    <MaskOverrideValues>
                        <Edit>
                            <MaskOverrideValues KeyValue=""{MaskOverrideValuesKey}"">
                                <Attributes>
                                    <CostType />
                                    <ChrgType />
                                    <TimeType />
                                    <Matter />
                                    <Timekeeper />
                                    <GLNatural />
                                    <GLUnit />
                                    <GLOffice />
                                    <GLTimekeeper />
                                    <GLDepartment />
                                    <GLSection />
                                    <GLArrangement />
                                    <GLTitle />
                                    <GLPracticeGroup />
                                    <GLWorkType />
                                    <MaskOverrideType />
                                    <ChrgTypePredicate>NewValue</ChrgTypePredicate>
                                    <ClientPredicate>NewValue</ClientPredicate>
                                    <CostTypePredicate>NewValue</CostTypePredicate>
                                    <MatterPredicate>NewValue</MatterPredicate>
                                    <TimekeeperPredicate>NewValue</TimekeeperPredicate>
                                    <TimeTypePredicate>NewValue</TimeTypePredicate>
                                    <UsingChrgType>1</UsingChrgType>
                                    <UsingClient>1</UsingClient>
                                    <UsingCostType>1</UsingCostType>
                                    <UsingMatter>1</UsingMatter>
                                    <UsingTimekeeper>1</UsingTimekeeper>
                                    <UsingTimeType>1</UsingTimeType>
                                    <GLActivity />
                                </Attributes>
                            </MaskOverrideValues>
                        </Edit>
                    </MaskOverrideValues>
                    <MattFlatFee>
                        <Edit>
                            <MattFlatFee KeyValue=""{MattFlatFeeKey}"">
                                <Attributes>
                                    <Matter />
                                    <TimeType />
                                    <Currency />
                                    <StartDate>0001-01-02T00:00:00</StartDate>
                                    <EndDate>0001-01-02T00:00:00</EndDate>
                                    <FlatFeeAmount>1</FlatFeeAmount>
                                </Attributes>
                            </MattFlatFee>
                        </Edit>
                    </MattFlatFee>
                    <CliEBillValList>
                        <Edit>
                            <CliEBillValList KeyValue=""{CliEBillValListKey}"">
                                <Attributes>
                                    <EBillValList />
                                </Attributes>
                            </CliEBillValList>
                        </Edit>
                    </CliEBillValList>
                    <ClientPTAGroup_CCC>
                        <Edit>
                            <ClientPTAGroup_CCC KeyValue=""{ClientPTAGroup_CCCKey}"">
                                <Attributes>
                                    <PTAGroup />
                                </Attributes>
                            </ClientPTAGroup_CCC>
                        </Edit>
                    </ClientPTAGroup_CCC>
                    <ClientSpecialInstructions_CCC>
                        <Edit>
                            <ClientSpecialInstructions_CCC KeyValue=""{ClientSpecialInstructions_CCCKey}"">
                                <Attributes>
                                    <ClientInstructions_CCC />
                                    <EndDate>0001-01-02T00:00:00</EndDate>
                                    <StartDate>0001-01-02T00:00:00</StartDate>
                                </Attributes>
                            </ClientSpecialInstructions_CCC>
                        </Edit>
                    </ClientSpecialInstructions_CCC>
                </Children>
            </Client>
        </Edit>
";
    }
}
