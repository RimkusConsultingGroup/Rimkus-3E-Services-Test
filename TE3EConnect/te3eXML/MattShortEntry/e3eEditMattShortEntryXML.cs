﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TE3EConnect.te3eXML.MattShortEntry
{
    public static partial class e3eMattShortEntryXML
    {
        public static string EditMatterSrvXml = @"
<Edit>
            <Matter KeyValue=""{@MatterKey}"">
                <Attributes>
                    <Number>NewValue</Number>
                    <AltNumber>NewValue</AltNumber>
                    <DisplayName>NewValue</DisplayName>
                    <Description>NewValue</Description>
                    <Client />
                    <MattInfo>NewValue</MattInfo>
                    <RelMattIndex />
                    <MattStatus />
                    <MattStatusDate>0001-01-02T00:00:00</MattStatusDate>
                    <MattType />
                    <OpenDate>0001-01-02T00:00:00</OpenDate>
                    <ConflictStatus />
                    <Narrative>NewValue</Narrative>
                    <BillingInstruc>NewValue</BillingInstruc>
                    <Language />
                    <ContactInfo>NewValue</ContactInfo>
                    <ReferralInfo>NewValue</ReferralInfo>
                    <MattCloseType />
                    <CloseDate>0001-01-02T00:00:00</CloseDate>
                    <IsMaster>1</IsMaster>
                    <NonBillType />
                    <IsProBono>1</IsProBono>
                    <ProBonoEntity />
                    <ProBonoInfo>NewValue</ProBonoInfo>
                    <IsAdmin>1</IsAdmin>
                    <AdminAccount>NewValue</AdminAccount>
                    <AdminInfo>NewValue</AdminInfo>
                    <ElecBillingType />
                    <ElecNumber>NewValue</ElecNumber>
                    <ElecInfo>NewValue</ElecInfo>
                    <IsNonBillable>1</IsNonBillable>
                    <BillAsMatter />
                    <BillSite />
                    <StatementSite />
                    <IsValidate>1</IsValidate>
                    <OpenTkpr />
                    <CloseTkpr />
                    <Comments>NewValue</Comments>
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
                    <EngageLetterSubDate>0001-01-02T00:00:00</EngageLetterSubDate>
                    <EngageLetterRecDate>0001-01-02T00:00:00</EngageLetterRecDate>
                    <EngageLetterComment>NewValue</EngageLetterComment>
                    <IsWaiverLetterReq>1</IsWaiverLetterReq>
                    <WaiverLetterSubDate>0001-01-02T00:00:00</WaiverLetterSubDate>
                    <WaiverLetterRecDate>0001-01-02T00:00:00</WaiverLetterRecDate>
                    <WaiverLetterComment>NewValue</WaiverLetterComment>
                    <IsConflictsConfidential>1</IsConflictsConfidential>
                    <BillDCSTemplate />
                    <ProfDCSTemplate />
                    <StmtDCSTemplate />
                    <IsAutoNumAfterSave>1</IsAutoNumAfterSave>
                    <ApproveTkpr />
                    <MattAttribute />
                    <MattCategory />
                    <EntryDate>0001-01-02T00:00:00</EntryDate>
                    <VATRegistration>NewValue</VATRegistration>
                    <MattMinType />
                    <GLProject />
                    <IsForeign>1</IsForeign>
                    <VolumeDiscountGroup />
                    <MattInterest />
                    <IsEBill>1</IsEBill>
                    <ElecTitleMap />
                    <ElecDCSTemplate />
                    <PaymentTermsInfo>NewValue</PaymentTermsInfo>
                    <IsFeeEstimate>1</IsFeeEstimate>
                    <FeeEstimateAmount>1</FeeEstimateAmount>
                    <EstimatedCompletionDate>0001-01-02T00:00:00</EstimatedCompletionDate>
                    <ApproveDate>0001-01-02T00:00:00</ApproveDate>
                    <InvoiceOverride />
                    <ProformaEmail>NewValue</ProformaEmail>
                    <BillEmail>NewValue</BillEmail>
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
                    <TaxReportID1>NewValue</TaxReportID1>
                    <TaxReportID2>NewValue</TaxReportID2>
                    <ToTaxArea />
                    <IsLeadVolumeDiscountMatter>1</IsLeadVolumeDiscountMatter>
                    <IsBillStatementIncludeDoubtful>1</IsBillStatementIncludeDoubtful>
                    <LoadGroup>NewValue</LoadGroup>
                    <LoadNumber>NewValue</LoadNumber>
                    <LoadSource>NewValue</LoadSource>
                    <WPType />
                    <BillTkprDispName>NewValue</BillTkprDispName>
                    <GLActivity />
                    <CreditNoteDCSTemplate />
                    <ElecTaxCodeMap />
                    <BillGroupDCSTemplate />
                    <CreditNoteGroupDCSTemplate />
                    <DateOfOccurence_CCC>0001-01-02T00:00:00</DateOfOccurence_CCC>
                    <DateOfOccurenceTxt_CCC>NewValue</DateOfOccurenceTxt_CCC>
                    <IsProspective_CCC>1</IsProspective_CCC>
                    <WarningMsg_CCC>NewValue</WarningMsg_CCC>
                    <isConflictsRoleApproved_CCC>1</isConflictsRoleApproved_CCC>
                    <Originator_CCC />
                    <ReassignUser_CCC>NewValue</ReassignUser_CCC>
                    <Par_Warning_CCC>NewValue</Par_Warning_CCC>
                    <DateReceived_CCC>0001-01-02T00:00:00</DateReceived_CCC>
                    <IsWeb_CCC>1</IsWeb_CCC>
                    <RetainerAmount_CCC>1</RetainerAmount_CCC>
                    <ScopeOfWork_CCC>NewValue</ScopeOfWork_CCC>
                    <ValidationMsg_CCC>NewValue</ValidationMsg_CCC>
                    <ReportingOffice_CCC />
                    <DNENotes_CCC>NewValue</DNENotes_CCC>
                    <IsFixedPrice_CCC>1</IsFixedPrice_CCC>
                    <IsConfLetterCAT_CCC>1</IsConfLetterCAT_CCC>
                    <IsConfLetterEngSvcs_CCC>1</IsConfLetterEngSvcs_CCC>
                    <IsConfLetterLegal_CCC>1</IsConfLetterLegal_CCC>
                    <IsConfLetterNatAgmt_CCC>1</IsConfLetterNatAgmt_CCC>
                    <IsConfLetterRtnr_CCC>1</IsConfLetterRtnr_CCC>
                    <IsConfLetterSign_CCC>1</IsConfLetterSign_CCC>
                    <IsConfLetterStd_CCC>1</IsConfLetterStd_CCC>
                    <ReportOfFindings_CCC />
                </Attributes>
                <Children>
                    <MattDate>
                        <Edit>
                            <MattDate KeyValue=""{@MattDateKey}"">
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
                                        <Edit>
                                            <MattOrgTkpr KeyValue=""{@MattOrgTkprKey}"">
                                                <Attributes>
                                                    <Timekeeper />
                                                    <Percentage>1</Percentage>
                                                    <IsPrimary>1</IsPrimary>
                                                </Attributes>
                                            </MattOrgTkpr>
                                        </Edit>
                                    </MattOrgTkpr>
                                    <MattPrlfTkpr>
                                        <Edit>
                                            <MattPrlfTkpr KeyValue=""{@MattPrlfTkprKey}"">
                                                <Attributes>
                                                    <Timekeeper />
                                                    <Percentage>1</Percentage>
                                                    <IsPrimary>1</IsPrimary>
                                                </Attributes>
                                            </MattPrlfTkpr>
                                        </Edit>
                                    </MattPrlfTkpr>
                                </Children>
                            </MattDate>
                        </Edit>
                    </MattDate>
                    <MattSite>
                        <Edit>
                            <MattSite KeyValue=""{@MattSiteKey}"">
                                <Attributes>
                                    <Site />
                                    <MattSiteType />
                                    <StartDate>0001-01-02T00:00:00</StartDate>
                                    <FinishDate>0001-01-02T00:00:00</FinishDate>
                                    <OrigFormattedAddress>NewValue</OrigFormattedAddress>
                                </Attributes>
                            </MattSite>
                        </Edit>
                    </MattSite>
                    <MattBillingContact>
                        <Edit>
                            <MattBillingContact KeyValue=""{@MattBillingContactKey}"">
                                <Attributes>
                                    <StartDate>0001-01-02T00:00:00</StartDate>
                                    <FinishDate>0001-01-02T00:00:00</FinishDate>
                                    <BillingContactType />
                                    <EntityPerson />
                                    <EntityPosition>NewValue</EntityPosition>
                                </Attributes>
                            </MattBillingContact>
                        </Edit>
                    </MattBillingContact>
                    <MattRate>
                        <Edit>
                            <MattRate KeyValue=""{@MattRateKey}"">
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
                        </Edit>
                    </MattRate>
                    <RateExc>
                        <Edit>
                            <RateExc KeyValue=""{@RateExcKey}"">
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
                                        <Edit>
                                            <RateExcDet KeyValue=""{@RateExcDetKey}"">
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
                                            <RateExcClientList KeyValue=""{@RateExcClientListKey}"">
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
                                            <RateExcMatterList KeyValue=""{@RateExcMatterListKey}"">
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
                    <MattTaxonomy>
                        <Edit>
                            <MattTaxonomy KeyValue=""{@MattTaxonomyKey}"">
                                <Attributes>
                                    <WestTaxomony />
                                </Attributes>
                            </MattTaxonomy>
                        </Edit>
                    </MattTaxonomy>
                    <MatterRateExc>
                        <Edit>
                            <MatterRateExc KeyValue=""{@MatterRateExcKey}"">
                                <Attributes>
                                    <RateExc />
                                    <StartDate>0001-01-02T00:00:00</StartDate>
                                    <EndDate>0001-01-02T00:00:00</EndDate>
                                </Attributes>
                            </MatterRateExc>
                        </Edit>
                    </MatterRateExc>
                    <MattTemplateOption>
                        <Edit>
                            <MattTemplateOption KeyValue=""{@MattTemplateOptionKey}"">
                                <Attributes>
                                    <BillTemplateOption />
                                    <BillTemplateOptionValue />
                                </Attributes>
                            </MattTemplateOption>
                        </Edit>
                    </MattTemplateOption>
                    <BillingGroupMatter1>
                        <Edit>
                            <BillingGroupMatter1 KeyValue=""{@BillingGroupMatter1Key}"">
                                <Attributes>
                                    <BillingGroup />
                                    <IsLead>1</IsLead>
                                    <IsBillingMatter>1</IsBillingMatter>
                                </Attributes>
                            </BillingGroupMatter1>
                        </Edit>
                    </BillingGroupMatter1>
                    <MattProfAdjust>
                        <Edit>
                            <MattProfAdjust KeyValue=""{@MattProfAdjustKey}"">
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
                        </Edit>
                    </MattProfAdjust>
                    <MaskOverrideValues>
                        <Edit>
                            <MaskOverrideValues KeyValue=""{@MaskOverrideValuesKey}"">
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
                        </Edit>
                    </MaskOverrideValues>
                    <MattBudget>
                        <Edit>
                            <MattBudget KeyValue=""{@MattBudgetKey}"">
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
                        </Edit>
                    </MattBudget>
                    <MattFlatFee>
                        <Edit>
                            <MattFlatFee KeyValue=""{@MattFlatFeeKey}"">
                                <Attributes>
                                    <TimeType />
                                    <Currency />
                                    <StartDate>0001-01-02T00:00:00</StartDate>
                                    <EndDate>0001-01-02T00:00:00</EndDate>
                                    <FlatFeeAmount>1</FlatFeeAmount>
                                    <Client />
                                </Attributes>
                            </MattFlatFee>
                        </Edit>
                    </MattFlatFee>
                    <MattPhaseException>
                        <Edit>
                            <MattPhaseException KeyValue=""{@MattPhaseExceptionKey}"">
                                <Attributes>
                                    <Phase />
                                    <MilestoneDate>0001-01-02T00:00:00</MilestoneDate>
                                    <IsTimeEntry>1</IsTimeEntry>
                                    <IsCostEntry>1</IsCostEntry>
                                    <IsChargeEntry>1</IsChargeEntry>
                                    <PTAGroup />
                                </Attributes>
                            </MattPhaseException>
                        </Edit>
                    </MattPhaseException>
                    <MattIndustryGroup>
                        <Edit>
                            <MattIndustryGroup KeyValue=""{@MattIndustryGroupKey}"">
                                <Attributes>
                                    <IndustryGroup />
                                </Attributes>
                            </MattIndustryGroup>
                        </Edit>
                    </MattIndustryGroup>
                    <MattPracticeTeam>
                        <Edit>
                            <MattPracticeTeam KeyValue=""{@MattPracticeTeamKey}"">
                                <Attributes>
                                    <PracticeTeam />
                                </Attributes>
                            </MattPracticeTeam>
                        </Edit>
                    </MattPracticeTeam>
                    <MattCostTypeSummarize>
                        <Edit>
                            <MattCostTypeSummarize KeyValue=""{@MattCostTypeSummarizeKey}"">
                                <Attributes>
                                    <CostType />
                                    <SummarizeTo />
                                    <IsDoNotSummarize>1</IsDoNotSummarize>
                                </Attributes>
                            </MattCostTypeSummarize>
                        </Edit>
                    </MattCostTypeSummarize>
                    <CmCase>
                        <Edit>
                            <CmCase KeyValue=""{@CmCaseKey}"">
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
                                        <Edit>
                                            <CMCaseStatusHist KeyValue=""{@CMCaseStatusHistKey}"">
                                                <Attributes>
                                                    <CmCaseStatusList />
                                                    <StatusStartDate>0001-01-02T00:00:00</StatusStartDate>
                                                    <Comment>NewValue</Comment>
                                                    <NxStartDate>0001-01-02T00:00:00</NxStartDate>
                                                </Attributes>
                                            </CMCaseStatusHist>
                                        </Edit>
                                    </CMCaseStatusHist>
                                    <CmCaseTeam>
                                        <Edit>
                                            <CmCaseTeam KeyValue=""{@CmCaseTeamKey}"">
                                                <Attributes>
                                                    <Timekeeper />
                                                    <CmCaseTkprRoleList />
                                                    <IsCustom>1</IsCustom>
                                                    <Status>NewValue</Status>
                                                    <IsStatusDirty>1</IsStatusDirty>
                                                </Attributes>
                                                <Children>
                                                    <CmCaseTeamStatus>
                                                        <Edit>
                                                            <CmCaseTeamStatus KeyValue=""{@CmCaseTeamStatusKey}"">
                                                                <Attributes>
                                                                    <StatusStartDate>0001-01-02T00:00:00</StatusStartDate>
                                                                    <NxEndDate>0001-01-02T00:00:00</NxEndDate>
                                                                    <CmTkprCaseStatus />
                                                                    <CmSubEventStatus />
                                                                    <NxStartDate>0001-01-02T00:00:00</NxStartDate>
                                                                </Attributes>
                                                            </CmCaseTeamStatus>
                                                        </Edit>
                                                    </CmCaseTeamStatus>
                                                </Children>
                                            </CmCaseTeam>
                                        </Edit>
                                    </CmCaseTeam>
                                    <CmCaseDtl>
                                        <Edit>
                                            <CmLitigation KeyValue=""{@CmLitigationKey}"">
                                                <Attributes>
                                                    <AmtContested>1</AmtContested>
                                                    <SettlementAmt>1</SettlementAmt>
                                                    <DueDiligence>NewValue</DueDiligence>
                                                    <Currency />
                                                    <ConvDate>0001-01-02T00:00:00</ConvDate>
                                                </Attributes>
                                            </CmLitigation>
                                        </Edit>
                                        <Edit>
                                            <CmBankruptcy KeyValue=""{@CmBankruptcyKey}"">
                                                <Attributes>
                                                    <CmBkChList />
                                                    <SettlementAmt>1</SettlementAmt>
                                                    <Currency />
                                                    <ConvDate>0001-01-02T00:00:00</ConvDate>
                                                    <AssetDescription>NewValue</AssetDescription>
                                                </Attributes>
                                            </CmBankruptcy>
                                        </Edit>
                                        <Edit>
                                            <CmInsurance KeyValue=""{@CmInsuranceKey}"">
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
                                                        <Edit>
                                                            <CmClaimNos KeyValue=""{@CmClaimNosKey}"">
                                                                <Attributes>
                                                                    <ClaimNumber>NewValue</ClaimNumber>
                                                                    <Description>NewValue</Description>
                                                                </Attributes>
                                                            </CmClaimNos>
                                                        </Edit>
                                                    </CmClaimNos>
                                                    <CmLossDates>
                                                        <Edit>
                                                            <CmLossDates KeyValue=""{@CmLossDatesKey}"">
                                                                <Attributes>
                                                                    <LossDate>0001-01-02T00:00:00</LossDate>
                                                                    <Description>NewValue</Description>
                                                                </Attributes>
                                                            </CmLossDates>
                                                        </Edit>
                                                    </CmLossDates>
                                                    <CmInsExperts>
                                                        <Edit>
                                                            <CmInsExperts KeyValue=""{@CmInsExpertsKey}"">
                                                                <Attributes>
                                                                    <Entity />
                                                                    <Description>NewValue</Description>
                                                                </Attributes>
                                                            </CmInsExperts>
                                                        </Edit>
                                                    </CmInsExperts>
                                                </Children>
                                            </CmInsurance>
                                        </Edit>
                                        <Edit>
                                            <CmRealEstate KeyValue=""{@CmRealEstateKey}"">
                                                <Attributes>
                                                    <PropertyAddress />
                                                    <ParcelID>NewValue</ParcelID>
                                                    <ZoningRestr>NewValue</ZoningRestr>
                                                    <EnvConcerns>NewValue</EnvConcerns>
                                                </Attributes>
                                            </CmRealEstate>
                                        </Edit>
                                        <Edit>
                                            <CmTrademark KeyValue=""{@CmTrademarkKey}"">
                                                <Attributes>
                                                    <Mark>NewValue</Mark>
                                                    <DesignType>NewValue</DesignType>
                                                    <IsActive>1</IsActive>
                                                    <SerialNumber>NewValue</SerialNumber>
                                                    <RegNumber>NewValue</RegNumber>
                                                </Attributes>
                                            </CmTrademark>
                                        </Edit>
                                        <Edit>
                                            <CmSecurities KeyValue=""{@CmSecuritiesKey}"">
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
                                        </Edit>
                                        <Edit>
                                            <CmPatent KeyValue=""{@CmPatentKey}"">
                                                <Attributes>
                                                    <InventionTitle>NewValue</InventionTitle>
                                                    <PatentDate>0001-01-02T00:00:00</PatentDate>
                                                    <FilingDate>0001-01-02T00:00:00</FilingDate>
                                                </Attributes>
                                                <Children>
                                                    <CmPatentAppNum>
                                                        <Edit>
                                                            <CmPatentAppNum KeyValue=""{@CmPatentAppNumKey}"">
                                                                <Attributes>
                                                                    <ApplicationNumber>NewValue</ApplicationNumber>
                                                                </Attributes>
                                                            </CmPatentAppNum>
                                                        </Edit>
                                                    </CmPatentAppNum>
                                                    <CmPatentCountry>
                                                        <Edit>
                                                            <CmPatentCountry KeyValue=""{@CmPatentCountryKey}"">
                                                                <Attributes>
                                                                    <Country />
                                                                </Attributes>
                                                            </CmPatentCountry>
                                                        </Edit>
                                                    </CmPatentCountry>
                                                </Children>
                                            </CmPatent>
                                        </Edit>
                                        <Edit>
                                            <CmHealthLaw KeyValue=""{@CmHealthLawKey}"">
                                                <Attributes>
                                                    <Medicare>NewValue</Medicare>
                                                    <Medicaid>NewValue</Medicaid>
                                                    <Pharmaceuticals>NewValue</Pharmaceuticals>
                                                    <LongTermCare>NewValue</LongTermCare>
                                                </Attributes>
                                            </CmHealthLaw>
                                        </Edit>
                                        <Edit>
                                            <CmLaborEmploy KeyValue=""{@CmLaborEmployKey}"">
                                                <Attributes>
                                                    <IsDiscrimination>1</IsDiscrimination>
                                                    <IsHarrassment>1</IsHarrassment>
                                                    <IsBreachOfContract>1</IsBreachOfContract>
                                                </Attributes>
                                            </CmLaborEmploy>
                                        </Edit>
                                        <Edit>
                                            <CmMedMal KeyValue=""{@CmMedMalKey}"">
                                                <Attributes>
                                                    <DamagesCap>1</DamagesCap>
                                                    <StatuteLimit>NewValue</StatuteLimit>
                                                    <DamagesClaimed>1</DamagesClaimed>
                                                    <CmStrictLiabNegList />
                                                    <Currency />
                                                    <ConvDate>0001-01-02T00:00:00</ConvDate>
                                                </Attributes>
                                            </CmMedMal>
                                        </Edit>
                                        <Edit>
                                            <CmProductsLiability KeyValue=""{@CmProductsLiabilityKey}"">
                                                <Attributes>
                                                    <ProdNameCat>NewValue</ProdNameCat>
                                                    <DamagesClaimed>1</DamagesClaimed>
                                                    <CmStrictLiabNegList />
                                                    <Currency />
                                                    <ConvDate>0001-01-02T00:00:00</ConvDate>
                                                </Attributes>
                                            </CmProductsLiability>
                                        </Edit>
                                        <Edit>
                                            <CmTax KeyValue=""{@CmTaxKey}"">
                                                <Attributes>
                                                    <StateLocalIssue>NewValue</StateLocalIssue>
                                                    <FedIssue>NewValue</FedIssue>
                                                    <PersonalIssue>NewValue</PersonalIssue>
                                                    <BusIssues>NewValue</BusIssues>
                                                </Attributes>
                                            </CmTax>
                                        </Edit>
                                        <Edit>
                                            <CmCriminalLaw KeyValue=""{@CmCriminalLawKey}"">
                                                <Attributes>
                                                    <Statute>NewValue</Statute>
                                                    <DateTime>NewValue</DateTime>
                                                    <Location>NewValue</Location>
                                                </Attributes>
                                            </CmCriminalLaw>
                                        </Edit>
                                        <Edit>
                                            <CmDivorce KeyValue=""{@CmDivorceKey}"">
                                                <Attributes>
                                                    <Assets>NewValue</Assets>
                                                    <PrenupDtls>NewValue</PrenupDtls>
                                                </Attributes>
                                            </CmDivorce>
                                        </Edit>
                                        <Edit>
                                            <CmChildSupport KeyValue=""{@CmChildSupportKey}"">
                                                <Attributes>
                                                    <PlaceOfEmploy>NewValue</PlaceOfEmploy>
                                                    <TaxReturnsPayStubs>NewValue</TaxReturnsPayStubs>
                                                </Attributes>
                                            </CmChildSupport>
                                        </Edit>
                                        <Edit>
                                            <CmChildCustody KeyValue=""{@CmChildCustodyKey}"">
                                                <Attributes>
                                                    <ChildMentPhysIssues>NewValue</ChildMentPhysIssues>
                                                    <ParentMentPhysIssues>NewValue</ParentMentPhysIssues>
                                                </Attributes>
                                            </CmChildCustody>
                                        </Edit>
                                    </CmCaseDtl>
                                </Children>
                            </CmCase>
                        </Edit>
                    </CmCase>
                    <MattPayor>
                        <Edit>
                            <MattPayor KeyValue=""{@MattPayorKey}"">
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
                                        <Edit>
                                            <MattPayorDetail KeyValue=""{@MattPayorDetailKey}"">
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
                                        </Edit>
                                    </MattPayorDetail>
                                    <MattPayorLayer>
                                        <Edit>
                                            <MattPayorLayer KeyValue=""{@MattPayorLayerKey}"">
                                                <Attributes>
                                                    <IsDefault>1</IsDefault>
                                                    <Layer>NewValue</Layer>
                                                    <LayerAmount>1</LayerAmount>
                                                    <LayerPercent>1</LayerPercent>
                                                </Attributes>
                                                <Children>
                                                    <MattPayorLayerDet>
                                                        <Edit>
                                                            <MattPayorLayerDet KeyValue=""{@MattPayorLayerDetKey}"">
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
                                                        </Edit>
                                                    </MattPayorLayerDet>
                                                </Children>
                                            </MattPayorLayer>
                                        </Edit>
                                    </MattPayorLayer>
                                </Children>
                            </MattPayor>
                        </Edit>
                    </MattPayor>
                    <MattTrust>
                        <Edit>
                            <MattTrust KeyValue=""{@MattTrustKey}"">
                                <Attributes>
                                    <BankAcctTrust />
                                </Attributes>
                            </MattTrust>
                        </Edit>
                    </MattTrust>
                    <MattTaxArticle>
                        <Edit>
                            <MattTaxArticle KeyValue=""{@MattTaxArticleKey}"">
                                <Attributes>
                                    <TaxArticle />
                                </Attributes>
                            </MattTaxArticle>
                        </Edit>
                    </MattTaxArticle>
                    <MattNote>
                        <Edit>
                            <MattNote KeyValue=""{@MattNoteKey}"">
                                <Attributes>
                                    <MattNoteType />
                                    <DateEntered>0001-01-02T00:00:00</DateEntered>
                                    <EntryUser />
                                    <Note>NewValue</Note>
                                    <NoteTimestamp_CCC>0001-01-02T00:00:00</NoteTimestamp_CCC>
                                </Attributes>
                            </MattNote>
                        </Edit>
                    </MattNote>
                    <MattEBillValList>
                        <Edit>
                            <MattEBillValList KeyValue=""{@MattEBillValListKey}"">
                                <Attributes>
                                    <EBillValList />
                                </Attributes>
                            </MattEBillValList>
                        </Edit>
                    </MattEBillValList>
                    <RelatedParties_CCC>
                        <Edit>
                            <RelatedParties_CCC KeyValue=""{@RelatedParties_CCCKey}"">
                                <Attributes>
                                    <CftRole />
                                    <HomePhone>NewValue</HomePhone>
                                    <MobilePhone>NewValue</MobilePhone>
                                    <WorkPhone>NewValue</WorkPhone>
                                    <Entity />
                                </Attributes>
                            </RelatedParties_CCC>
                        </Edit>
                    </RelatedParties_CCC>
                    <MatterSpecialInstructions_CCC>
                        <Edit>
                            <MatterSpecialInstructions_CCC KeyValue=""{@MatterSpecialInstructions_CCCKey}"">
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
                                        <Edit>
                                            <MatterSpecialInvoiceTo_CCC KeyValue=""{@MatterSpecialInvoiceTo_CCCKey}"">
                                                <Attributes>
                                                    <InvoiceTo>NewValue</InvoiceTo>
                                                </Attributes>
                                            </MatterSpecialInvoiceTo_CCC>
                                        </Edit>
                                    </MatterSpecialInvoiceTo_CCC>
                                </Children>
                            </MatterSpecialInstructions_CCC>
                        </Edit>
                    </MatterSpecialInstructions_CCC>
                    <TechRevEngRec_CCC>
                        <Edit>
                            <TechRevEngRec_CCC KeyValue=""{@TechRevEngRec_CCCKey}"">
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
                                        <Edit>
                                            <CoConsultants_CCC KeyValue=""{@CoConsultants_CCCKey}"">
                                                <Attributes>
                                                    <CoConsultant />
                                                </Attributes>
                                            </CoConsultants_CCC>
                                        </Edit>
                                    </CoConsultants_CCC>
                                </Children>
                            </TechRevEngRec_CCC>
                        </Edit>
                    </TechRevEngRec_CCC>
                    <LibertyMutual_CCC>
                        <Edit>
                            <LibertyMutual_CCC KeyValue=""{@LibertyMutual_CCCKey}"">
                                <Attributes>
                                    <ClaimsType_CCC />
                                    <ExpertType_CCC />
                                    <InsuranceType_CCC />
                                    <SystemType_CCC />
                                </Attributes>
                            </LibertyMutual_CCC>
                        </Edit>
                    </LibertyMutual_CCC>
                    <MattIndustryGroupCode_CCC>
                        <Edit>
                            <MattIndustryGroupCode_CCC KeyValue=""{@MattIndustryGroupCode_CCCKey}"">
                                <Attributes>
                                    <IndustryGroup />
                                </Attributes>
                            </MattIndustryGroupCode_CCC>
                        </Edit>
                    </MattIndustryGroupCode_CCC>
                    <IndustryGroupMatter_CCC>
                        <Edit>
                            <IndustryGroupMatter_CCC KeyValue=""{@IndustryGroupMatter_CCCKey}"">
                                <Attributes>
                                    <IndustryGroup />
                                </Attributes>
                            </IndustryGroupMatter_CCC>
                        </Edit>
                    </IndustryGroupMatter_CCC>
                </Children>
            </Matter>
        </Edit>
";
    }
}
