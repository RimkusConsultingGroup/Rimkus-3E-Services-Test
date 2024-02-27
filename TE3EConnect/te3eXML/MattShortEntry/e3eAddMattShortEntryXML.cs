﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TE3EConnect.te3eXML.MattShortEntry
{
    public static partial class e3eMattShortEntryXML
    {
        public static string AddMatterSrvXml = @"
        <Add>
            <Matter>
                <Attributes>
                    <Number></Number>
                    <AltNumber></AltNumber>
                    <DisplayName>@DisplayName</DisplayName>
                    <Description>@Description</Description>
                    <Client>@Client</Client>
                    <MattInfo>@MattInfo</MattInfo>
                    <RelMattIndex>@RelMattIndex</RelMattIndex>
                    <MattStatus>@MattStatus</MattStatus>
                    <MattStatusDate>@MattStatusDate</MattStatusDate>
                    <MattType>@MattType</MattType>
                    <OpenDate>@OpenDate</OpenDate>
                    <ConflictStatus>@ConflictStatus</ConflictStatus>
                    <Narrative>@Narrative</Narrative>
                    <BillingInstruc>@BillingInstruc</BillingInstruc>
                    <Language>@Language</Language>
                    <ContactInfo>@ContactInfo</ContactInfo>
                    <ReferralInfo>@ReferralInfo</ReferralInfo>
                    <MattCloseType>@MattCloseType</MattCloseType>
                    <CloseDate>@CloseDate</CloseDate>
                    <IsMaster>@IsMaster</IsMaster>
                    <NonBillType>@NonBillType</NonBillType>
                    <IsProBono>1</IsProBono>
                    <ProBonoEntity />
                    <ProBonoInfo></ProBonoInfo>
                    <IsAdmin>1</IsAdmin>
                    <AdminAccount>@AdminAccount</AdminAccount>
                    <AdminInfo>@AdminInfo</AdminInfo>
                    <ElecBillingType />
                    <ElecNumber></ElecNumber>
                    <ElecInfo></ElecInfo>
                    <IsNonBillable>1</IsNonBillable>
                    <BillAsMatter />
                    <BillSite />
                    <StatementSite />
                    <IsValidate>1</IsValidate>
                    <OpenTkpr />
                    <CloseTkpr />
                    <Comments>@Comments</Comments>
                    <IsDefault>1</IsDefault>
                    <BillingFrequency />
                    <IsNoProforma>1</IsNoProforma>
                    <IsNoBill>1</IsNoBill>
                    <Markup />
                    <WithholdingTax />
                    <TimeTaxCode />
                    <CostTaxCode />
                    <ChrgTaxCode />
                    <DueDays>1</DueDays>
                    <Currency />
                    <CurrencyDateList />
                    <ElecCostTypeMap />
                    <TimeIncrement />
                    <IsAutoNumbering>1</IsAutoNumbering>
                    <IsEngageLetterReq>1</IsEngageLetterReq>
                    <EngageLetterSubDate>@EngageLetterSubDate</EngageLetterSubDate>
                    <EngageLetterRecDate>@EngageLetterRecDate</EngageLetterRecDate>
                    <EngageLetterComment>@EngageLetterComment</EngageLetterComment>
                    <IsWaiverLetterReq>1</IsWaiverLetterReq>
                    <WaiverLetterSubDate>@WaiverLetterSubDate</WaiverLetterSubDate>
                    <WaiverLetterRecDate>@WaiverLetterRecDate</WaiverLetterRecDate>
                    <WaiverLetterComment>@WaiverLetterComment</WaiverLetterComment>
                    <IsConflictsConfidential>1</IsConflictsConfidential>
                    <BillDCSTemplate />
                    <ProfDCSTemplate />
                    <StmtDCSTemplate />
                    <IsAutoNumAfterSave>1</IsAutoNumAfterSave>
                    <ApproveTkpr />
                    <MattAttribute />
                    <MattCategory />
                    <EntryDate>@EntryDate</EntryDate>
                    <VATRegistration>@VATRegistration</VATRegistration>
                    <MattMinType />
                    <GLProject />
                    <IsForeign>1</IsForeign>
                    <VolumeDiscountGroup />
                    <MattInterest />
                    <IsEBill>1</IsEBill>
                    <ElecTitleMap />
                    <ElecDCSTemplate />
                    <PaymentTermsInfo>@PaymentTermsInfo</PaymentTermsInfo>
                    <IsFeeEstimate>1</IsFeeEstimate>
                    <FeeEstimateAmount>1</FeeEstimateAmount>
                    <EstimatedCompletionDate>@EstimatedCompletionDate</EstimatedCompletionDate>
                    <ApproveDate>@ApproveDate</ApproveDate>
                    <InvoiceOverride />
                    <ProformaEmail>@ProformaEmail</ProformaEmail>
                    <BillEmail>@BillEmail</BillEmail>
                    <IsNumberEnabled>1</IsNumberEnabled>
                    <GLRespTkpr />
                    <IsICBAcctRec>1</IsICBAcctRec>
                    <IsICBPayable>1</IsICBPayable>
                    <ICBUnitDueTo />
                    <ICBUnitDueFrom />
                    <HasTimekeeperChanged>1</HasTimekeeperChanged>
                    <IsAllowTrustOverdraw>1</IsAllowTrustOverdraw>
                    <BillingOffice />
                    <BankAcctAp />
                    <TaxReportID1>@TaxReportID1</TaxReportID1>
                    <TaxReportID2>@TaxReportID2</TaxReportID2>
                    <ToTaxArea />
                    <IsLeadVolumeDiscountMatter>1</IsLeadVolumeDiscountMatter>
                    <IsBillStatementIncludeDoubtful>1</IsBillStatementIncludeDoubtful>
                    <LoadGroup>@LoadGroup</LoadGroup>
                    <LoadNumber>@LoadNumber</LoadNumber>
                    <LoadSource>@LoadSource</LoadSource>
                    <WPType />
                    <BillTkprDispName>@BillTkprDispName</BillTkprDispName>
                    <GLActivity />
                    <CreditNoteDCSTemplate />
                    <ElecTaxCodeMap />
                    <BillGroupDCSTemplate />
                    <CreditNoteGroupDCSTemplate />
                    <DateOfOccurence_CCC>@DateOfOccurence_CCC</DateOfOccurence_CCC>
                    <DateOfOccurenceTxt_CCC>@DateOfOccurenceTxt_CCC</DateOfOccurenceTxt_CCC>
                    <IsProspective_CCC>1</IsProspective_CCC>
                    <WarningMsg_CCC>@WarningMsg_CCC</WarningMsg_CCC>
                    <isConflictsRoleApproved_CCC>1</isConflictsRoleApproved_CCC>
                    <Originator_CCC>@Originator_CCC</Originator_CCC>
                    <ReassignUser_CCC>@ReassignUser_CCC</ReassignUser_CCC>
                    <Par_Warning_CCC>@Par_Warning_CCC</Par_Warning_CCC>
                    <DateReceived_CCC>@DateReceived_CCC</DateReceived_CCC>
                    <IsWeb_CCC>1</IsWeb_CCC>
                    <RetainerAmount_CCC>@RetainerAmount_CCC</RetainerAmount_CCC>
                    <ScopeOfWork_CCC>@ScopeOfWork_CCC</ScopeOfWork_CCC>
                    <ValidationMsg_CCC>@ValidationMsg_CCC</ValidationMsg_CCC>
                    <ReportingOffice_CCC>@ReportingOffice_CCC</ReportingOffice_CCC>
                    <DNENotes_CCC>@DNENotes_CCC</DNENotes_CCC>
                    <IsFixedPrice_CCC>1</IsFixedPrice_CCC>
                    <IsConfLetterCAT_CCC>1</IsConfLetterCAT_CCC>
                    <IsConfLetterEngSvcs_CCC>1</IsConfLetterEngSvcs_CCC>
                    <IsConfLetterLegal_CCC>1</IsConfLetterLegal_CCC>
                    <IsConfLetterNatAgmt_CCC>1</IsConfLetterNatAgmt_CCC>
                    <IsConfLetterRtnr_CCC>1</IsConfLetterRtnr_CCC>
                    <IsConfLetterSign_CCC>1</IsConfLetterSign_CCC>
                    <IsConfLetterStd_CCC>1</IsConfLetterStd_CCC>
                    <ReportOfFindings_CCC>@ReportOfFindings_CCC</ReportOfFindings_CCC>
                </Attributes>
                <Children>
                    <MattDate>
                        <Add>
                            <MattDate>
                                <Attributes>
                                    <EffStart>0001-01-02T00:00:00</EffStart>
                                    <PracticeGroup />
                                    <Department />
                                    <Section />
                                    <Arrangement />
                                    <TkprTeam />
                                    <ReservesGroup />
                                    <PTAGroup />
                                    <Office />
                                    <MattSplitType />
                                    <BillTkpr />
                                    <RspTkpr />
                                    <SpvTkpr />
                                    <PTAGroupCost />
                                    <PTAGroupChrg />
                                    <IsFireValidation>1</IsFireValidation>
                                    <PTAGroup2 />
                                    <PTAGroupChrg2 />
                                    <PTAGroupCost2 />
                                    <NxStartDate>0001-01-02T00:00:00</NxStartDate>
                                </Attributes>
                                <Children>
                                    <MattOrgTkpr>
                                        <Add>
                                            <MattOrgTkpr>
                                                <Attributes>
                                                    <Timekeeper />
                                                    <Percentage>1</Percentage>
                                                    <IsPrimary>1</IsPrimary>
                                                </Attributes>
                                            </MattOrgTkpr>
                                        </Add>
                                    </MattOrgTkpr>
                                    <MattPrlfTkpr>
                                        <Add>
                                            <MattPrlfTkpr>
                                                <Attributes>
                                                    <Timekeeper />
                                                    <Percentage>1</Percentage>
                                                    <IsPrimary>1</IsPrimary>
                                                </Attributes>
                                            </MattPrlfTkpr>
                                        </Add>
                                    </MattPrlfTkpr>
                                </Children>
                            </MattDate>
                        </Add>
                    </MattDate>
                    <MattSite>
                        <Add>
                            <MattSite>
                                <Attributes>
                                    <Site />
                                    <MattSiteType />
                                    <StartDate>0001-01-02T00:00:00</StartDate>
                                    <FinishDate>0001-01-02T00:00:00</FinishDate>
                                    <OrigFormattedAddress>NewValue</OrigFormattedAddress>
                                </Attributes>
                            </MattSite>
                        </Add>
                    </MattSite>
                    <MattBillingContact>
                        <Add>
                            <MattBillingContact>
                                <Attributes>
                                    <StartDate>0001-01-02T00:00:00</StartDate>
                                    <FinishDate>0001-01-02T00:00:00</FinishDate>
                                    <BillingContactType />
                                    <EntityPerson />
                                    <EntityPosition>NewValue</EntityPosition>
                                </Attributes>
                            </MattBillingContact>
                        </Add>
                    </MattBillingContact>
                    <MattRate>
                        <Add>
                            <MattRate>
                                <Attributes>
                                    <Rate />
                                    <MaxHours>1</MaxHours>
                                    <MaxBillAmt>1</MaxBillAmt>
                                    <Currency />
                                    <CurrDate>0001-01-02T00:00:00</CurrDate>
                                    <IsActive>1</IsActive>
                                    <RefRate />
                                    <RateGroup />
                                    <MaxFees>1</MaxFees>
                                    <MaxHCo>1</MaxHCo>
                                    <MaxSCo>1</MaxSCo>
                                    <MaxInt>1</MaxInt>
                                    <MaxBOA>1</MaxBOA>
                                    <MaxTax>1</MaxTax>
                                    <MaxOth>1</MaxOth>
                                    <IsEnforceMaximums>1</IsEnforceMaximums>
                                </Attributes>
                            </MattRate>
                        </Add>
                    </MattRate>
                    <RateExc>
                        <Add>
                            <RateExc>
                                <Attributes>
                                    <Description>NewValue</Description>
                                    <Client />
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
                                        <Add>
                                            <RateExcDet>
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
                                        </Add>
                                    </RateExcDet>
                                    <RateExcClientList>
                                        <Add>
                                            <RateExcClientList>
                                                <Attributes>
                                                    <Client />
                                                    <StartDate>0001-01-02T00:00:00</StartDate>
                                                    <EndDate>0001-01-02T00:00:00</EndDate>
                                                </Attributes>
                                            </RateExcClientList>
                                        </Add>
                                    </RateExcClientList>
                                    <RateExcMatterList>
                                        <Add>
                                            <RateExcMatterList>
                                                <Attributes>
                                                    <Matter />
                                                    <StartDate>0001-01-02T00:00:00</StartDate>
                                                    <EndDate>0001-01-02T00:00:00</EndDate>
                                                </Attributes>
                                            </RateExcMatterList>
                                        </Add>
                                    </RateExcMatterList>
                                </Children>
                            </RateExc>
                        </Add>
                    </RateExc>
                    <MattTaxonomy>
                        <Add>
                            <MattTaxonomy>
                                <Attributes>
                                    <WestTaxomony />
                                </Attributes>
                            </MattTaxonomy>
                        </Add>
                    </MattTaxonomy>
                    <MatterRateExc>
                        <Add>
                            <MatterRateExc>
                                <Attributes>
                                    <RateExc />
                                    <StartDate>0001-01-02T00:00:00</StartDate>
                                    <EndDate>0001-01-02T00:00:00</EndDate>
                                </Attributes>
                            </MatterRateExc>
                        </Add>
                    </MatterRateExc>
                    <MattTemplateOption>
                        <Add>
                            <MattTemplateOption>
                                <Attributes>
                                    <BillTemplateOption />
                                    <BillTemplateOptionValue />
                                </Attributes>
                            </MattTemplateOption>
                        </Add>
                    </MattTemplateOption>
                    <BillingGroupMatter1>
                        <Add>
                            <BillingGroupMatter1>
                                <Attributes>
                                    <BillingGroup />
                                    <IsLead>1</IsLead>
                                    <IsBillingMatter>1</IsBillingMatter>
                                </Attributes>
                            </BillingGroupMatter1>
                        </Add>
                    </BillingGroupMatter1>
                    <MattProfAdjust>
                        <Add>
                            <MattProfAdjust>
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
                            </MattProfAdjust>
                        </Add>
                    </MattProfAdjust>
                    <MaskOverrideValues>
                        <Add>
                            <MaskOverrideValues>
                                <Attributes>
                                    <CostType />
                                    <ChrgType />
                                    <TimeType />
                                    <Client />
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
                        </Add>
                    </MaskOverrideValues>
                    <MattBudget>
                        <Add>
                            <MattBudget>
                                <Attributes>
                                    <SortString>NewValue</SortString>
                                    <IsActive>1</IsActive>
                                    <StartDate>0001-01-02T00:00:00</StartDate>
                                    <EndDate>0001-01-02T00:00:00</EndDate>
                                    <IsFee>1</IsFee>
                                    <IsCost>1</IsCost>
                                    <BudHours>1</BudHours>
                                    <Currency />
                                    <BudAmount>1</BudAmount>
                                    <Timekeeper />
                                    <CostType />
                                    <PTAGroup />
                                    <Phase />
                                    <Task />
                                    <Activity />
                                    <BillAmount>1</BillAmount>
                                    <BillHours>1</BillHours>
                                    <CollAmount>1</CollAmount>
                                    <CollHours>1</CollHours>
                                    <NBAmount>1</NBAmount>
                                    <NBHours>1</NBHours>
                                    <WOffAmount>1</WOffAmount>
                                    <WOffHours>1</WOffHours>
                                    <Activity2 />
                                    <Phase2 />
                                    <PTAGroup2 />
                                    <Task2 />
                                    <Narrative_CCC>NewValue</Narrative_CCC>
                                    <IsBaseBudget_CCC>1</IsBaseBudget_CCC>
                                </Attributes>
                            </MattBudget>
                        </Add>
                    </MattBudget>
                    <MattFlatFee>
                        <Add>
                            <MattFlatFee>
                                <Attributes>
                                    <TimeType>FFEE</TimeType>
                                    <Currency>USD</Currency>
                                    <StartDate>0001-01-02T00:00:00</StartDate>
                                    <EndDate>0001-01-02T00:00:00</EndDate>
                                    <FlatFeeAmount>1</FlatFeeAmount>
                                    <Client />
                                </Attributes>
                            </MattFlatFee>
                        </Add>
                    </MattFlatFee>
                    <MattPhaseException>
                        <Add>
                            <MattPhaseException>
                                <Attributes>
                                    <Phase />
                                    <MilestoneDate>0001-01-02T00:00:00</MilestoneDate>
                                    <IsTimeEntry>1</IsTimeEntry>
                                    <IsCostEntry>1</IsCostEntry>
                                    <IsChargeEntry>1</IsChargeEntry>
                                    <PTAGroup />
                                </Attributes>
                            </MattPhaseException>
                        </Add>
                    </MattPhaseException>
                    <MattIndustryGroup>
                        <Add>
                            <MattIndustryGroup>
                                <Attributes>
                                    <IndustryGroup />
                                </Attributes>
                            </MattIndustryGroup>
                        </Add>
                    </MattIndustryGroup>
                    <MattPracticeTeam>
                        <Add>
                            <MattPracticeTeam>
                                <Attributes>
                                    <PracticeTeam />
                                </Attributes>
                            </MattPracticeTeam>
                        </Add>
                    </MattPracticeTeam>
                    <MattCostTypeSummarize>
                        <Add>
                            <MattCostTypeSummarize>
                                <Attributes>
                                    <CostType />
                                    <SummarizeTo />
                                    <IsDoNotSummarize>1</IsDoNotSummarize>
                                </Attributes>
                            </MattCostTypeSummarize>
                        </Add>
                    </MattCostTypeSummarize>
                    <CmCase>
                        <Add>
                            <CmCase>
                                <Attributes>
                                    <CmCaseNumber>NewValue</CmCaseNumber>
                                    <Description>NewValue</Description>
                                    <DocketID>NewValue</DocketID>
                                    <Language />
                                    <CmTimeZone />
                                    <CmRuleset />
                                    <CmJurisdiction />
                                    <CmCaseCategory />
                                    <Alert>NewValue</Alert>
                                    <RMSubmatter />
                                    <IsViewcase>1</IsViewcase>
                                    <TkprsAffectClosedEvents>1</TkprsAffectClosedEvents>
                                    <TkprsAffectPastEvents>1</TkprsAffectPastEvents>
                                </Attributes>
                                <Children>
                                    <CMCaseStatusHist>
                                        <Add>
                                            <CMCaseStatusHist>
                                                <Attributes>
                                                    <CmCaseStatusList />
                                                    <StatusStartDate>0001-01-02T00:00:00</StatusStartDate>
                                                    <Comment>NewValue</Comment>
                                                    <NxStartDate>0001-01-02T00:00:00</NxStartDate>
                                                </Attributes>
                                            </CMCaseStatusHist>
                                        </Add>
                                    </CMCaseStatusHist>
                                    <CmCaseTeam>
                                        <Add>
                                            <CmCaseTeam>
                                                <Attributes>
                                                    <Timekeeper />
                                                    <CmCaseTkprRoleList />
                                                    <IsCustom>1</IsCustom>
                                                    <Status>NewValue</Status>
                                                    <IsStatusDirty>1</IsStatusDirty>
                                                </Attributes>
                                                <Children>
                                                    <CmCaseTeamStatus>
                                                        <Add>
                                                            <CmCaseTeamStatus>
                                                                <Attributes>
                                                                    <StatusStartDate>0001-01-02T00:00:00</StatusStartDate>
                                                                    <NxEndDate>0001-01-02T00:00:00</NxEndDate>
                                                                    <CmTkprCaseStatus />
                                                                    <CmSubEventStatus />
                                                                    <NxStartDate>0001-01-02T00:00:00</NxStartDate>
                                                                </Attributes>
                                                            </CmCaseTeamStatus>
                                                        </Add>
                                                    </CmCaseTeamStatus>
                                                </Children>
                                            </CmCaseTeam>
                                        </Add>
                                    </CmCaseTeam>
                                    <CmCaseDtl>
                                        <Add>
                                            <CmLitigation>
                                                <Attributes>
                                                    <AmtContested>1</AmtContested>
                                                    <SettlementAmt>1</SettlementAmt>
                                                    <DueDiligence>NewValue</DueDiligence>
                                                    <Currency />
                                                    <ConvDate>0001-01-02T00:00:00</ConvDate>
                                                </Attributes>
                                            </CmLitigation>
                                        </Add>
                                        <Add>
                                            <CmBankruptcy>
                                                <Attributes>
                                                    <CmBkChList />
                                                    <SettlementAmt>1</SettlementAmt>
                                                    <Currency />
                                                    <ConvDate>0001-01-02T00:00:00</ConvDate>
                                                    <AssetDescription>NewValue</AssetDescription>
                                                </Attributes>
                                            </CmBankruptcy>
                                        </Add>
                                        <Add>
                                            <CmInsurance>
                                                <Attributes>
                                                    <LossAmt>1</LossAmt>
                                                    <IsSubrogationAllowed>1</IsSubrogationAllowed>
                                                    <CmSettleRelList />
                                                    <PolicyNumber>NewValue</PolicyNumber>
                                                    <AccidentLocation>NewValue</AccidentLocation>
                                                    <AdjusterName>NewValue</AdjusterName>
                                                    <Currency />
                                                    <ConvDate>0001-01-02T00:00:00</ConvDate>
                                                    <InsuredEntity />
                                                    <AdjusterEntity />
                                                    <JudgeEntity />
                                                    <SettledAmt>1</SettledAmt>
                                                    <AuthorizedAmt>1</AuthorizedAmt>
                                                    <FinalAmt>1</FinalAmt>
                                                    <IsJuryTrialRequired>1</IsJuryTrialRequired>
                                                    <CmDisposition />
                                                    <ClosingNotes>NewValue</ClosingNotes>
                                                </Attributes>
                                                <Children>
                                                    <CmClaimNos>
                                                        <Add>
                                                            <CmClaimNos>
                                                                <Attributes>
                                                                    <ClaimNumber>NewValue</ClaimNumber>
                                                                    <Description>NewValue</Description>
                                                                </Attributes>
                                                            </CmClaimNos>
                                                        </Add>
                                                    </CmClaimNos>
                                                    <CmLossDates>
                                                        <Add>
                                                            <CmLossDates>
                                                                <Attributes>
                                                                    <LossDate>0001-01-02T00:00:00</LossDate>
                                                                    <Description>NewValue</Description>
                                                                </Attributes>
                                                            </CmLossDates>
                                                        </Add>
                                                    </CmLossDates>
                                                    <CmInsExperts>
                                                        <Add>
                                                            <CmInsExperts>
                                                                <Attributes>
                                                                    <Entity />
                                                                    <Description>NewValue</Description>
                                                                </Attributes>
                                                            </CmInsExperts>
                                                        </Add>
                                                    </CmInsExperts>
                                                </Children>
                                            </CmInsurance>
                                        </Add>
                                        <Add>
                                            <CmRealEstate>
                                                <Attributes>
                                                    <PropertyAddress />
                                                    <ParcelID>NewValue</ParcelID>
                                                    <ZoningRestr>NewValue</ZoningRestr>
                                                    <EnvConcerns>NewValue</EnvConcerns>
                                                </Attributes>
                                            </CmRealEstate>
                                        </Add>
                                        <Add>
                                            <CmTrademark>
                                                <Attributes>
                                                    <Mark>NewValue</Mark>
                                                    <DesignType>NewValue</DesignType>
                                                    <IsActive>1</IsActive>
                                                    <SerialNumber>NewValue</SerialNumber>
                                                    <RegNumber>NewValue</RegNumber>
                                                </Attributes>
                                            </CmTrademark>
                                        </Add>
                                        <Add>
                                            <CmSecurities>
                                                <Attributes>
                                                    <FormNumber>NewValue</FormNumber>
                                                    <Class>NewValue</Class>
                                                    <RegDate>0001-01-02T00:00:00</RegDate>
                                                    <NumberShares>1</NumberShares>
                                                    <PerShareValue>1</PerShareValue>
                                                    <Currency />
                                                    <ConvDate>0001-01-02T00:00:00</ConvDate>
                                                </Attributes>
                                            </CmSecurities>
                                        </Add>
                                        <Add>
                                            <CmPatent>
                                                <Attributes>
                                                    <InventionTitle>NewValue</InventionTitle>
                                                    <PatentDate>0001-01-02T00:00:00</PatentDate>
                                                    <FilingDate>0001-01-02T00:00:00</FilingDate>
                                                </Attributes>
                                                <Children>
                                                    <CmPatentAppNum>
                                                        <Add>
                                                            <CmPatentAppNum>
                                                                <Attributes>
                                                                    <ApplicationNumber>NewValue</ApplicationNumber>
                                                                </Attributes>
                                                            </CmPatentAppNum>
                                                        </Add>
                                                    </CmPatentAppNum>
                                                    <CmPatentCountry>
                                                        <Add>
                                                            <CmPatentCountry>
                                                                <Attributes>
                                                                    <Country />
                                                                </Attributes>
                                                            </CmPatentCountry>
                                                        </Add>
                                                    </CmPatentCountry>
                                                </Children>
                                            </CmPatent>
                                        </Add>
                                        <Add>
                                            <CmHealthLaw>
                                                <Attributes>
                                                    <Medicare>NewValue</Medicare>
                                                    <Medicaid>NewValue</Medicaid>
                                                    <Pharmaceuticals>NewValue</Pharmaceuticals>
                                                    <LongTermCare>NewValue</LongTermCare>
                                                </Attributes>
                                            </CmHealthLaw>
                                        </Add>
                                        <Add>
                                            <CmLaborEmploy>
                                                <Attributes>
                                                    <IsDiscrimination>1</IsDiscrimination>
                                                    <IsHarrassment>1</IsHarrassment>
                                                    <IsBreachOfContract>1</IsBreachOfContract>
                                                </Attributes>
                                            </CmLaborEmploy>
                                        </Add>
                                        <Add>
                                            <CmMedMal>
                                                <Attributes>
                                                    <DamagesCap>1</DamagesCap>
                                                    <StatuteLimit>NewValue</StatuteLimit>
                                                    <DamagesClaimed>1</DamagesClaimed>
                                                    <CmStrictLiabNegList />
                                                    <Currency />
                                                    <ConvDate>0001-01-02T00:00:00</ConvDate>
                                                </Attributes>
                                            </CmMedMal>
                                        </Add>
                                        <Add>
                                            <CmProductsLiability>
                                                <Attributes>
                                                    <ProdNameCat>NewValue</ProdNameCat>
                                                    <DamagesClaimed>1</DamagesClaimed>
                                                    <CmStrictLiabNegList />
                                                    <Currency />
                                                    <ConvDate>0001-01-02T00:00:00</ConvDate>
                                                </Attributes>
                                            </CmProductsLiability>
                                        </Add>
                                        <Add>
                                            <CmTax>
                                                <Attributes>
                                                    <StateLocalIssue>NewValue</StateLocalIssue>
                                                    <FedIssue>NewValue</FedIssue>
                                                    <PersonalIssue>NewValue</PersonalIssue>
                                                    <BusIssues>NewValue</BusIssues>
                                                </Attributes>
                                            </CmTax>
                                        </Add>
                                        <Add>
                                            <CmCriminalLaw>
                                                <Attributes>
                                                    <Statute>NewValue</Statute>
                                                    <DateTime>NewValue</DateTime>
                                                    <Location>NewValue</Location>
                                                </Attributes>
                                            </CmCriminalLaw>
                                        </Add>
                                        <Add>
                                            <CmDivorce>
                                                <Attributes>
                                                    <Assets>NewValue</Assets>
                                                    <PrenupDtls>NewValue</PrenupDtls>
                                                </Attributes>
                                            </CmDivorce>
                                        </Add>
                                        <Add>
                                            <CmChildSupport>
                                                <Attributes>
                                                    <PlaceOfEmploy>NewValue</PlaceOfEmploy>
                                                    <TaxReturnsPayStubs>NewValue</TaxReturnsPayStubs>
                                                </Attributes>
                                            </CmChildSupport>
                                        </Add>
                                        <Add>
                                            <CmChildCustody>
                                                <Attributes>
                                                    <ChildMentPhysIssues>NewValue</ChildMentPhysIssues>
                                                    <ParentMentPhysIssues>NewValue</ParentMentPhysIssues>
                                                </Attributes>
                                            </CmChildCustody>
                                        </Add>
                                    </CmCaseDtl>
                                </Children>
                            </CmCase>
                        </Add>
                    </CmCase>
                    <MattPayor>
                        <Add>
                            <MattPayor>
                                <Attributes>
                                    <Description>NewValue</Description>
                                    <Currency />
                                    <IsLayer>1</IsLayer>
                                    <IsLayerAmount>1</IsLayerAmount>
                                    <IsTaxbyMultipayor>1</IsTaxbyMultipayor>
                                    <IsMultipayorByRate>1</IsMultipayorByRate>
                                    <EffDate>0001-01-02T00:00:00</EffDate>
                                    <EndDate>0001-01-02T00:00:00</EndDate>
                                    <StartDate>0001-01-02T00:00:00</StartDate>
                                    <CauseNum_CCC>NewValue</CauseNum_CCC>
                                    <Court_CCC>NewValue</Court_CCC>
                                    <Representing_CCC />
                                    <Style_CCC>NewValue</Style_CCC>
                                </Attributes>
                                <Children>
                                    <MattPayorDetail>
                                        <Add>
                                            <MattPayorDetail>
                                                <Attributes>
                                                    <Payor />
                                                    <Site />
                                                    <IsDefault>1</IsDefault>
                                                    <PctFee>1</PctFee>
                                                    <PctHCo>1</PctHCo>
                                                    <PctSCo>1</PctSCo>
                                                    <PctTax>1</PctTax>
                                                    <PctInt>1</PctInt>
                                                    <PctBOA>1</PctBOA>
                                                    <PctOth>1</PctOth>
                                                    <StmtSite />
                                                    <ForAttentionOf>NewValue</ForAttentionOf>
                                                    <RefNumber>NewValue</RefNumber>
                                                    <FeeRate />
                                                    <CftRole_CCC />
                                                    <EntityContact_CCC />
                                                    <CftRelationship_CCC />
                                                    <ClaimNum_CCC>NewValue</ClaimNum_CCC>
                                                    <Contact_CCC>NewValue</Contact_CCC>
                                                    <CorpType_CCC />
                                                    <Email_CCC>NewValue</Email_CCC>
                                                    <PhoneNum_CCC>NewValue</PhoneNum_CCC>
                                                    <Title_CCC>NewValue</Title_CCC>
                                                    <Fax_CCC>NewValue</Fax_CCC>
                                                    <MobileNum_CCC>NewValue</MobileNum_CCC>
                                                    <IsDeposition_CCC>1</IsDeposition_CCC>
                                                    <AddtlContactInfo_CCC>NewValue</AddtlContactInfo_CCC>
                                                    <DepoRetainer_CCC>1</DepoRetainer_CCC>
                                                </Attributes>
                                            </MattPayorDetail>
                                        </Add>
                                    </MattPayorDetail>
                                    <MattPayorLayer>
                                        <Add>
                                            <MattPayorLayer>
                                                <Attributes>
                                                    <IsDefault>1</IsDefault>
                                                    <Layer>NewValue</Layer>
                                                    <LayerAmount>1</LayerAmount>
                                                    <LayerPercent>1</LayerPercent>
                                                </Attributes>
                                                <Children>
                                                    <MattPayorLayerDet>
                                                        <Add>
                                                            <MattPayorLayerDet>
                                                                <Attributes>
                                                                    <ForAttentionOf>NewValue</ForAttentionOf>
                                                                    <IsDefault>1</IsDefault>
                                                                    <Payor />
                                                                    <PctBOA>1</PctBOA>
                                                                    <PctFee>1</PctFee>
                                                                    <PctHCo>1</PctHCo>
                                                                    <PctInt>1</PctInt>
                                                                    <PctOth>1</PctOth>
                                                                    <PctSCo>1</PctSCo>
                                                                    <PctTax>1</PctTax>
                                                                    <RefNumber>NewValue</RefNumber>
                                                                    <Site />
                                                                    <StmtSite />
                                                                    <FeeRate />
                                                                </Attributes>
                                                            </MattPayorLayerDet>
                                                        </Add>
                                                    </MattPayorLayerDet>
                                                </Children>
                                            </MattPayorLayer>
                                        </Add>
                                    </MattPayorLayer>
                                </Children>
                            </MattPayor>
                        </Add>
                    </MattPayor>
                    <MattTrust>
                        <Add>
                            <MattTrust>
                                <Attributes>
                                    <BankAcctTrust />
                                </Attributes>
                            </MattTrust>
                        </Add>
                    </MattTrust>
                    <MattTaxArticle>
                        <Add>
                            <MattTaxArticle>
                                <Attributes>
                                    <TaxArticle />
                                </Attributes>
                            </MattTaxArticle>
                        </Add>
                    </MattTaxArticle>
                    <MattNote>
                        <Add>
                            <MattNote>
                                <Attributes>
                                    <MattNoteType />
                                    <DateEntered>0001-01-02T00:00:00</DateEntered>
                                    <EntryUser />
                                    <Note>NewValue</Note>
                                    <NoteTimestamp_CCC>0001-01-02T00:00:00</NoteTimestamp_CCC>
                                </Attributes>
                            </MattNote>
                        </Add>
                    </MattNote>
                    <MattEBillValList>
                        <Add>
                            <MattEBillValList>
                                <Attributes>
                                    <EBillValList />
                                </Attributes>
                            </MattEBillValList>
                        </Add>
                    </MattEBillValList>
                    <RelatedParties_CCC>
                        <Add>
                            <RelatedParties_CCC>
                                <Attributes>
                                    <CftRole />
                                    <HomePhone>NewValue</HomePhone>
                                    <MobilePhone>NewValue</MobilePhone>
                                    <WorkPhone>NewValue</WorkPhone>
                                    <Entity />
                                </Attributes>
                            </RelatedParties_CCC>
                        </Add>
                    </RelatedParties_CCC>
                    <MatterSpecialInstructions_CCC>
                        <Add>
                            <MatterSpecialInstructions_CCC>
                                <Attributes>
                                    <Client />
                                    <ClientInstr />
                                    <EndDate>0001-01-02T00:00:00</EndDate>
                                    <StartDate>0001-01-02T00:00:00</StartDate>
                                    <AdditionalInstr>NewValue</AdditionalInstr>
                                    <EffDate>0001-01-02T00:00:00</EffDate>
                                    <ReportsTo>NewValue</ReportsTo>
                                    <ReportType />
                                    <ClaimsType_CCC />
                                    <ExpertType_CCC />
                                    <InsuranceType_CCC />
                                    <SystemType_CCC />
                                    <ReferralMethod />
                                </Attributes>
                                <Children>
                                    <MatterSpecialInvoiceTo_CCC>
                                        <Add>
                                            <MatterSpecialInvoiceTo_CCC>
                                                <Attributes>
                                                    <InvoiceTo>NewValue</InvoiceTo>
                                                </Attributes>
                                            </MatterSpecialInvoiceTo_CCC>
                                        </Add>
                                    </MatterSpecialInvoiceTo_CCC>
                                </Children>
                            </MatterSpecialInstructions_CCC>
                        </Add>
                    </MatterSpecialInstructions_CCC>
                    <TechRevEngRec_CCC>
                        <Add>
                            <TechRevEngRec_CCC>
                                <Attributes>
                                    <EngineerOfRecord />
                                    <Marketer />
                                    <TechincalReviewer />
                                    <State>NewValue</State>
                                    <Country>NewValue</Country>
                                    <MattOpendate_CCC>0001-01-02T00:00:00</MattOpendate_CCC>
                                </Attributes>
                                <Children>
                                    <CoConsultants_CCC>
                                        <Add>
                                            <CoConsultants_CCC>
                                                <Attributes>
                                                    <CoConsultant />
                                                </Attributes>
                                            </CoConsultants_CCC>
                                        </Add>
                                    </CoConsultants_CCC>
                                </Children>
                            </TechRevEngRec_CCC>
                        </Add>
                    </TechRevEngRec_CCC>
                    <LibertyMutual_CCC>
                        <Add>
                            <LibertyMutual_CCC>
                                <Attributes>
                                    <ClaimsType_CCC />
                                    <ExpertType_CCC />
                                    <InsuranceType_CCC />
                                    <SystemType_CCC />
                                </Attributes>
                            </LibertyMutual_CCC>
                        </Add>
                    </LibertyMutual_CCC>
                    <MattIndustryGroupCode_CCC>
                        <Add>
                            <MattIndustryGroupCode_CCC>
                                <Attributes>
                                    <IndustryGroup />
                                </Attributes>
                            </MattIndustryGroupCode_CCC>
                        </Add>
                    </MattIndustryGroupCode_CCC>
                    <IndustryGroupMatter_CCC>
                        <Add>
                            <IndustryGroupMatter_CCC>
                                <Attributes>
                                    <IndustryGroup />
                                </Attributes>
                            </IndustryGroupMatter_CCC>
                        </Add>
                    </IndustryGroupMatter_CCC>
                </Children>
            </Matter>
        </Add>
";

    }
}