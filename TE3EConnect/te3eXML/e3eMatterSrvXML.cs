using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TE3EConnect.te3eXML
{
    public static class e3eMatterSrvXML
    {
        public static string EditMatterXML = @"
    <Matter xmlns=""http://elite.com/schemas/transaction/process/write/Matter"">
    <Initialize xmlns=""http://elite.com/schemas/transaction/object/write/Matter"">
        <Edit>
            <Matter KeyValue=""@KeyValue"">
                 <Children>
                    @EditPGDetHdr_CCC
                </Children>
            </Matter>
        </Edit>
    </Initialize>
</Matter>
";

        public static string AddMatterSrvXml = @"
    <Matter xmlns=""http://elite.com/schemas/transaction/process/write/Matter"">
    <Initialize xmlns=""http://elite.com/schemas/transaction/object/write/Matter"">
        <Add>
            <Matter>
                <Attributes>
                    <Number></Number>
                    <AltNumber></AltNumber>
                    <DisplayName>@DisplayName</DisplayName>
                    <Description>@Description</Description>
                    <Client>@Client</Client>
                    <MattInfo></MattInfo>
                    <RelMattIndex />
                    <MattStatus>@MattStatus</MattStatus>
                    <MattStatusDate>@MattStatusDate</MattStatusDate>
                    <MattType>@MattType</MattType>
                    <OpenDate>@OpenDate</OpenDate>
                    <ConflictStatus />
                    <Narrative></Narrative>
                    <BillingInstruc></BillingInstruc>
                    <Language>@Language</Language>
                    <ContactInfo></ContactInfo>
                    <ReferralInfo></ReferralInfo>
                    <MattCloseType />
                    <CloseDate></CloseDate>
                    <IsMaster>@IsMaster</IsMaster>
                    <NonBillType />
                    <IsProBono>0</IsProBono>
                    <ProBonoEntity />
                    <ProBonoInfo></ProBonoInfo>
                    <IsAdmin>0</IsAdmin>
                    <AdminAccount></AdminAccount>
                    <AdminInfo></AdminInfo>
                    <ElecBillingType />
                    <ElecNumber></ElecNumber>
                    <ElecInfo></ElecInfo>
                    <IsNonBillable>0</IsNonBillable>
                    <BillAsMatter />
                    <BillSite />
                    <StatementSite />
                    <IsValidate>0</IsValidate>
                    <!--<OpenTkpr>@OpenTkpr</OpenTkpr>-->
                    <CloseTkpr />
                    <Comments></Comments>
                    <IsDefault>0</IsDefault>
                    <BillingFrequency>@BillingFrequency</BillingFrequency>
                    <IsNoProforma>0</IsNoProforma>
                    <IsNoBill>0</IsNoBill>
                    <Markup />
                    <WithholdingTax />
                    <TimeTaxCode />
                    <CostTaxCode />
                    <ChrgTaxCode />
                    <DueDays></DueDays>
                    <Currency>@Currency</Currency>
                    <CurrencyDateList>@CurrencyDateList</CurrencyDateList>
                    <ElecCostTypeMap />
                    <TimeIncrement>@TimeIncrement</TimeIncrement>
                    <IsAutoNumbering>@IsAutoNumbering</IsAutoNumbering>
                    <IsEngageLetterReq>0</IsEngageLetterReq>
                    <EngageLetterSubDate></EngageLetterSubDate>
                    <EngageLetterRecDate></EngageLetterRecDate>
                    <EngageLetterComment></EngageLetterComment>
                    <IsWaiverLetterReq>0</IsWaiverLetterReq>
                    <WaiverLetterSubDate></WaiverLetterSubDate>
                    <WaiverLetterRecDate></WaiverLetterRecDate>
                    <WaiverLetterComment></WaiverLetterComment>
                    <IsConflictsConfidential>0</IsConflictsConfidential>
                    <BillDCSTemplate />
                    <ProfDCSTemplate />
                    <StmtDCSTemplate />
                    <IsAutoNumAfterSave>1</IsAutoNumAfterSave>
                    <ApproveTkpr />
                    <MattAttribute>@MattAttribute</MattAttribute>
                    <MattCategory>@MattCategory</MattCategory>
                    <EntryDate></EntryDate>
                    <VATRegistration></VATRegistration>
                    <MattMinType />
                    <GLProject />
                    <IsForeign>0</IsForeign>
                    <VolumeDiscountGroup />
                    <MattInterest />
                    <IsEBill>0</IsEBill>
                    <ElecTitleMap />
                    <ElecDCSTemplate />
                    <PaymentTermsInfo>@PaymentTermsInfo</PaymentTermsInfo>
                    <IsFeeEstimate>0</IsFeeEstimate>
                    <FeeEstimateAmount></FeeEstimateAmount>
                    <EstimatedCompletionDate></EstimatedCompletionDate>
                    <ApproveDate></ApproveDate>
                    <InvoiceOverride />
                    <ProformaEmail></ProformaEmail>
                    <BillEmail></BillEmail>
                    <IsNumberEnabled>0</IsNumberEnabled>
                    <GLRespTkpr />
                    <IsICBAcctRec>0</IsICBAcctRec>
                    <IsICBPayable>0</IsICBPayable>
                    <ICBUnitDueTo />
                    <ICBUnitDueFrom />
                    <HasTimekeeperChanged>0</HasTimekeeperChanged>
                    <IsAllowTrustOverdraw>0</IsAllowTrustOverdraw>
                    <BillingOffice />
                    <BankAcctAp />
                    <TaxReportID1></TaxReportID1>
                    <TaxReportID2></TaxReportID2>
                    <ToTaxArea />
                    <IsLeadVolumeDiscountMatter>0</IsLeadVolumeDiscountMatter>
                    <IsBillStatementIncludeDoubtful>0</IsBillStatementIncludeDoubtful>
                    <LoadGroup></LoadGroup>
                    <LoadNumber></LoadNumber>
                    <LoadSource></LoadSource>
                    <EbillValidationList />
                    <WPType />
                    <BillTkprDispName></BillTkprDispName>
                    <GLActivity />
                    <CreditNoteDCSTemplate />
                    <ElecTaxCodeMap />
                    <BillGroupDCSTemplate />
                    <CreditNoteGroupDCSTemplate />
                    <Day_CCC>@Day_CCC</Day_CCC>
                    <EngSignedDate_CCC>@EngSignedDate_CCC</EngSignedDate_CCC>
                    <EngStatus_CCC>@EngStatus_CCC</EngStatus_CCC>
                    <EngType_CCC>@EngType_CCC</EngType_CCC>
                    <IsEvergreen_CCC>@IsEvergreen_CCC</IsEvergreen_CCC>
                    <Month_CCC>@Month_CCC</Month_CCC>
                    <OpportunityID_CCC></OpportunityID_CCC>
                    <BD1></BD1>
                    <rTK></rTK>
                </Attributes>
                <Children>
                    @AddMattDate
                    @AddMatterRateExc
                    @AddPGDetHdr_CCC
                    @AddAssociateTkprs_CCC
                    @AddSalesForceInfo_CCC
                </Children>
            </Matter>
        </Add>
    </Initialize>
</Matter>

            ";

        public static string AddMattDate = @"
        <MattDate>
                        <Add>
                            <MattDate>
                                <Attributes>
                                    <EffStart>@EffStart</EffStart>
                                    <PracticeGroup>@PracticeGroup</PracticeGroup>
                                    <Department>@Department</Department>
                                    <Section>@Section</Section>
                                    <Arrangement>@Arrangement</Arrangement>
                                    <TkprTeam />
                                    <ReservesGroup />
                                    <PTAGroup>@PTAGroup</PTAGroup>
                                    <Office>@Office</Office>
                                    <MattSplitType />
                                    <BillTkpr>@BillTkpr</BillTkpr>
                                    <RspTkpr>@RspTkpr</RspTkpr>
                                    <SpvTkpr>@SpvTkpr</SpvTkpr>
                                    <PTAGroupCost />
                                    <PTAGroupChrg />
                                    <IsFireValidation>0</IsFireValidation>
                                    <PTAGroup2>@PTAGroup2</PTAGroup2>
                                    <PTAGroupChrg2 />
                                    <PTAGroupCost2 />
                                    <NxStartDate></NxStartDate>
                                    <CRATkpr_CCC />
                                </Attributes>
                                <Children>
                                    @AddMattOrgTkpr
                                    @AddMattPrlfTkpr
                                </Children>
                            </MattDate>
                        </Add>
                    </MattDate>
";

        public static string AddMattOrgTkpr = @"
        <MattOrgTkpr>
                                        <Add>
                                            <MattOrgTkpr>
                                                <Attributes>
                                                    <Timekeeper>@Timekeeper</Timekeeper>
                                                    <Percentage>@Percentage</Percentage>
                                                    <IsPrimary>@IsPrimary</IsPrimary>
                                                </Attributes>
                                            </MattOrgTkpr>
                                        </Add>
                                    </MattOrgTkpr>
";

        public static string AddMattPrlfTkpr = @"
        <MattPrlfTkpr>
                                        <Add>
                                            <MattPrlfTkpr>
                                                <Attributes>
                                                    <Timekeeper>@Timekeeper</Timekeeper>
                                                    <Percentage>@Percentage</Percentage>
                                                    <IsPrimary>@IsPrimary</IsPrimary>
                                                </Attributes>
                                            </MattPrlfTkpr>
                                        </Add>
                                    </MattPrlfTkpr>
";

        public static string AddMattSite = @"
        <MattSite>
                        <Add>
                            <MattSite>
                                <Attributes>
                                    <Site />
                                    <MattSiteType />
                                    <StartDate>0001-01-02T00:00:00</StartDate>
                                    <FinishDate>0001-01-02T00:00:00</FinishDate>
                                </Attributes>
                            </MattSite>
                        </Add>
                    </MattSite>
                    
";


        public static string AddMattBillingContact = @"
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
";

        public static string AddMattRate = @"
        <MattRate>
                        <Add>
                            <MattRate>
                                <Attributes>
                                    <Rate>@Rate</Rate>
                                    <MaxHours></MaxHours>
                                    <MaxBillAmt></MaxBillAmt>
                                    <Currency />
                                    <CurrDate></CurrDate>
                                    <IsActive>1</IsActive>
                                    <RefRate />
                                    <RateGroup />
                                    <MaxFees></MaxFees>
                                    <MaxHCo></MaxHCo>
                                    <MaxSCo></MaxSCo>
                                    <MaxInt></MaxInt>
                                    <MaxBOA></MaxBOA>
                                    <MaxTax></MaxTax>
                                    <MaxOth></MaxOth>
                                    <IsEnforceMaximums>0</IsEnforceMaximums>
                                </Attributes>
                            </MattRate>
                        </Add>
                    </MattRate>
        
";


        public static string AddRateExc = @"
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
                                    @AddRateExcDet
                                    @AddRateExcClientList
                                    @AddRateExcMatterList
                                </Children>
                            </RateExc>
                        </Add>
                    </RateExc>
";

        public static string AddRateExcDet = @"
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
                                                    <BillingTitle_CCC />
                                                </Attributes>
                                            </RateExcDet>
                                        </Add>
                                    </RateExcDet>
";


        public static string AddRateExcClientList = @"
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
";



        public static string AddRateExcMatterList = @"
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
";


        public static string AddMattTaxonomy = @"
     <MattTaxonomy>
                        <Add>
                            <MattTaxonomy>
                                <Attributes>
                                    <WestTaxomony />
                                </Attributes>
                            </MattTaxonomy>
                        </Add>
                    </MattTaxonomy>
";

        public static string AddMatterRateExc = @"
<MatterRateExc>
                        <Add>
                            <MatterRateExc>
                                <Attributes>
                                    <RateExc>@RateExc</RateExc>
                                    <StartDate>@StartDate</StartDate>
                                    <EndDate></EndDate>
                                </Attributes>
                            </MatterRateExc>
                        </Add>
                    </MatterRateExc>
";

        public static string AddMattTemplateOption = @"
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
";

        public static string AddBillingGroupMatter1 = @"

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
";

        public static string AddMattProfAdjust = @"
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
                                </Attributes>
                            </MattProfAdjust>
                        </Add>
                    </MattProfAdjust>
";


        public static string AddMaskOverrideValues = @"
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
";


        public static string AddMattBudget = @"
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
                                </Attributes>
                            </MattBudget>
                        </Add>
                    </MattBudget>
";

        public static string AddMattFlatFee = @"
        <MattFlatFee>
                        <Add>
                            <MattFlatFee>
                                <Attributes>
                                    <TimeType />
                                    <Currency />
                                    <StartDate>0001-01-02T00:00:00</StartDate>
                                    <EndDate>0001-01-02T00:00:00</EndDate>
                                    <FlatFeeAmount>1</FlatFeeAmount>
                                    <Client />
                                </Attributes>
                            </MattFlatFee>
                        </Add>
                    </MattFlatFee>
";

        public static string AddMattPhaseException = @"
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
";


        public static string AddMattIndustryGroup = @"
         <MattIndustryGroup>
                        <Add>
                            <MattIndustryGroup>
                                <Attributes>
                                    <IndustryGroup />
                                </Attributes>
                            </MattIndustryGroup>
                        </Add>
                    </MattIndustryGroup>
                    

";

        public static string AddMattPracticeTeam = @"
        <MattPracticeTeam>
                        <Add>
                            <MattPracticeTeam>
                                <Attributes>
                                    <PracticeTeam />
                                </Attributes>
                            </MattPracticeTeam>
                        </Add>
                    </MattPracticeTeam>
";

        public static string AddMattCostTypeSummarize = @"
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
";

        public static string AddCmCase = @"
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
                                    @AddCMCaseStatusHist
                                    @AddCmCaseTeam
                                    @AddCmCaseDtl
                                </Children>
                            </CmCase>
                        </Add>
                    </CmCase>
";

        public static string AddCMCaseStatusHist = @"
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
";

        public static string AddCmCaseTeam = @"
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
                                                    @AddCmCaseTeamStatus
                                                </Children>
                                            </CmCaseTeam>
                                        </Add>
                                    </CmCaseTeam>
";

        public static string AddCmCaseTeamStatus = @"
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
";


        public static string AddCmCaseDtl = @"
                                    <CmCaseDtl>
                                        @AddCmLitigation
                                        @AddCmBankruptcy
                                        @AddCmInsurance
                                        @AddCmRealEstate
                                        @AddCmTrademark
                                        @AddCmSecurities
                                        @AddCmPatent
                                        @AddCmHealthLaw
                                        @AddCmLaborEmploy
                                        @AddCmMedMal
                                        @AddCmProductsLiability
                                        @AddCmTax 
                                        @AddCmCriminalLaw 
                                        @AddCmDivorce 
                                        @AddCmChildSupport 
                                        @AddCmChildCustody
                                    </CmCaseDtl>
";

        public static string AddCmLitigation = @"
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

";


        public static string AddCmBankruptcy = @"
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
";

        public static string AddCmInsurance = @"
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
                                                   @AddCmClaimNos 
                                                   @AddCmLossDates 
                                                   @AddCmInsExperts
                                                </Children>
                                            </CmInsurance>
                                        </Add>
";

        public static string AddCmClaimNos = @"
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
";

        public static string AddCmLossDates = @"
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
";

        public static string AddCmInsExperts = @"
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
";


        public static string AddCmRealEstate = @"
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
                                       
";


        public static string AddCmTrademark = @"
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
";

        public static string AddCmSecurities = @"
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
";

        public static string AddCmPatent = @"
        <Add>
            <CmPatent>
                <Attributes>
                    <InventionTitle>NewValue</InventionTitle>
                    <PatentDate>0001-01-02T00:00:00</PatentDate>
                    <FilingDate>0001-01-02T00:00:00</FilingDate>
                </Attributes>
                <Children>
                    @AddCmPatentAppNum
                    @AddCmPatentCountry
                </Children>
            </CmPatent>
        </Add>
";

        public static string AddCmPatentCountry = @"
        <CmPatentCountry>
            <Add>
                <CmPatentCountry>
                    <Attributes>
                        <Country />
                    </Attributes>
                </CmPatentCountry>
            </Add>
        </CmPatentCountry>
";

        public static string AddCmPatentAppNum = @"
        <CmPatentAppNum>
            <Add>
                <CmPatentAppNum>
                    <Attributes>
                        <ApplicationNumber>NewValue</ApplicationNumber>
                    </Attributes>
                </CmPatentAppNum>
            </Add>
        </CmPatentAppNum>
";

        public static string AddCmHealthLaw = @"
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
";

        public static string AddCmLaborEmploy = @"
        <Add>
            <CmLaborEmploy>
                <Attributes>
                    <IsDiscrimination>1</IsDiscrimination>
                    <IsHarrassment>1</IsHarrassment>
                    <IsBreachOfContract>1</IsBreachOfContract>
                </Attributes>
            </CmLaborEmploy>
        </Add>

";

        public static string AddCmMedMal = @"
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
";


        public static string AddCmProductsLiability = @"
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
";


        public static string AddCmTax = @"
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
";


        public static string AddCmCriminalLaw = @"
            <Add>
                <CmCriminalLaw>
                    <Attributes>
                        <Statute>NewValue</Statute>
                        <DateTime>NewValue</DateTime>
                        <Location>NewValue</Location>
                    </Attributes>
                </CmCriminalLaw>
            </Add>
";


        public static string AddCmDivorce = @"
            <Add>
                <CmDivorce>
                    <Attributes>
                        <Assets>NewValue</Assets>
                        <PrenupDtls>NewValue</PrenupDtls>
                    </Attributes>
                </CmDivorce>
            </Add>
";


        public static string AddCmChildSupport = @"
            <Add>
                <CmChildSupport>
                    <Attributes>
                        <PlaceOfEmploy>NewValue</PlaceOfEmploy>
                        <TaxReturnsPayStubs>NewValue</TaxReturnsPayStubs>
                    </Attributes>
                </CmChildSupport>
            </Add>
";

        public static string AddCmChildCustody = @"
             <Add>
                <CmChildCustody>
                    <Attributes>
                        <ChildMentPhysIssues>NewValue</ChildMentPhysIssues>
                        <ParentMentPhysIssues>NewValue</ParentMentPhysIssues>
                    </Attributes>
                </CmChildCustody>
            </Add>
";

        public static string AddMattPayor = @"
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
                                </Attributes>
                                <Children>
                                    @AddMattPayorDetail
                                    @AddMattPayorLayer
                                </Children>
                            </MattPayor>
                        </Add>
                    </MattPayor>
";


        public static string AddMattPayorDetail = @"
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
                        </Attributes>
                    </MattPayorDetail>
                </Add>
            </MattPayorDetail>
";

        public static string AddMattPayorLayer = @"
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
                            @AddMattPayorLayerDet
                        </Children>
                    </MattPayorLayer>
                </Add>
            </MattPayorLayer>
";
        public static string AddMattPayorLayerDet = @"
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
";

        public static string AddMattTrust = @"
        <MattTrust>
                        <Add>
                            <MattTrust>
                                <Attributes>
                                    <BankAcctTrust />
                                </Attributes>
                            </MattTrust>
                        </Add>
                    </MattTrust>
";

        public static string AddMattTaxArticle = @"
        <MattTaxArticle>
            <Add>
                <MattTaxArticle>
                    <Attributes>
                        <TaxArticle />
                    </Attributes>
                </MattTaxArticle>
            </Add>
        </MattTaxArticle>
";

        public static string AddMattNote = @"
        <MattNote>
            <Add>
                <MattNote>
                    <Attributes>
                        <MattNoteType />
                        <DateEntered>0001-01-02T00:00:00</DateEntered>
                        <EntryUser />
                        <Note>NewValue</Note>
                    </Attributes>
                </MattNote>
            </Add>
        </MattNote>
";

        public static string AddPGDetHdr_CCC = @"
            <PGDetHdr_CCC>
                <Add>
                    <PGDetHdr_CCC>
                        <Attributes>
                            <AdjWIP></AdjWIP>
                            <BlendedHourlyRate></BlendedHourlyRate>
                            <CreditEstHigh>@CreditEstHigh</CreditEstHigh>
                            <CreditEstLow>@CreditEstLow</CreditEstLow>
                            <EffStart>@EffStart</EffStart>
                            <FeeCapPct>@FeeCapPct</FeeCapPct>
                            <IsAuditDefenseIncluded>0</IsAuditDefenseIncluded>
                            <NxEndDate></NxEndDate>
                            <OrigWIP>@OrigWIP</OrigWIP>
                            <RemainingWIP></RemainingWIP>
                            <Total></Total>
                            <FeeCapFixed>@FeeCapFixed</FeeCapFixed>
                            <BA_Notes_CCC>@BA_Notes_CCC</BA_Notes_CCC>
                            <NxStartDate></NxStartDate>
                        </Attributes>
                        <Children>
                            @PGDetChild_CCC
                        </Children>
                    </PGDetHdr_CCC>
                </Add>
            </PGDetHdr_CCC>
";

        public static string EditPGDetHdr_CCC = @"
            <PGDetHdr_CCC>
                <Edit>
                    <PGDetHdr_CCC KeyValue=""@KeyValue"">
                        <Children>
                            @edPGDetChild_CCC
                        </Children>
                    </PGDetHdr_CCC>
                </Edit>
            </PGDetHdr_CCC>
";

        public static string edPGDetChild_CCC = @"
            <PGDetChild_CCC>
                @EditPGDetChild_CCC
            </PGDetChild_CCC>
";
        public static string PGDetChild_CCC = @"
            <PGDetChild_CCC>
                @AddPGDetChild_CCC
            </PGDetChild_CCC>
";

        public static string EditPGDetChild_CCC = @"
                <Edit>
                    <PGDetChild_CCC KeyValue=""@KeyValue"">
                        <Attributes>
                            <Adjustments>@Adjustments</Adjustments>
                            <Comments>@Comments</Comments>
                        </Attributes>
                    </PGDetChild_CCC>
                </Edit>
";

        public static string AddPGDetChild_CCC = @"
             <Add>
                    <PGDetChild_CCC>
                        <Attributes>
                            <Adjustments>@Adjustments</Adjustments>
                            <Building></Building>
                            <Comments>@Comments</Comments>
                            <EngineerReview></EngineerReview>
                            <FinalCredit></FinalCredit>
                            <Interest></Interest>
                            <IsFederal>@IsFederal</IsFederal>
                            <IsGeneralWork>0</IsGeneralWork>
                            <OrigCredit>@OrigCredit</OrigCredit>
                            <Quarter></Quarter>
                            <RevenuePct></RevenuePct>
                            <State>@State</State>
                            <SustentionAmt></SustentionAmt>
                            <SustentionPct></SustentionPct>
                            <Total></Total>
                            <TriggerType />
                            <ValueAssessment></ValueAssessment>
                            <Year>@Year</Year>
                            <MSID></MSID>
                            <bldgID></bldgID>
                            <Status></Status>
                            <NewWIPFT>0</NewWIPFT>
                            <ControlGroup></ControlGroup>
                        </Attributes>
                    </PGDetChild_CCC>
                </Add>
";


        public static string AddAssociateTkprs_CCC = @"
                    <AssociatedTkprs_CCC>
                        <Add>
                            <AssociatedTkprs_CCC>
                                <Attributes>
                                    <Alliance>@Alliance</Alliance>
                                    <AlliancePct>@AlliancePct</AlliancePct>
                                    <BDTkpr1>@BDTkpr1</BDTkpr1>
                                    <BDTkpr2>@BDTkpr2</BDTkpr2>
                                    <BDTkpr3>@BDTkpr3</BDTkpr3>
                                    <BDTkprPct1>@BDTkprPct1</BDTkprPct1>
                                    <BDTkprPct2>@BDTkprPct2</BDTkprPct2>
                                    <BDTkprPct3>@BDTkprPct3</BDTkprPct3>
                                    <Comments>@Comments</Comments>
                                    <EffStart>@EffStart</EffStart>
                                    <FUSOETkpr>@FUSOETkpr</FUSOETkpr>
                                    <FUSOETkprPct>@FUSOETkprPct</FUSOETkprPct>
                                    <KickOffAMPM></KickOffAMPM>
                                    <KickOffDate></KickOffDate>
                                    <KickOffNotes></KickOffNotes>
                                    <KickOffStatus></KickOffStatus>
                                    <KickOffTime></KickOffTime>
                                    <KickOffTimeZone></KickOffTimeZone>
                                    <NxEndDate></NxEndDate>
                                    <SOETkpr1>@SOETkpr1</SOETkpr1>
                                    <SOETkpr2>@SOETkpr2</SOETkpr2>
                                    <SOETkpr3>@SOETkpr3</SOETkpr3>
                                    <SOETkprPct1>@SOETkprPct1</SOETkprPct1>
                                    <SOETkprPct2>@SOETkprPct2</SOETkprPct2>
                                    <SOETkprPct3>@SOETkprPct3</SOETkprPct3>
                                    <RefSource1>@RefSource1</RefSource1>
                                    <RefSource2>@RefSource2</RefSource2>
                                    <RefSourcePct1>@RefSourcePct1</RefSourcePct1>
                                    <RefSourcePct2>@RefSourcePct2</RefSourcePct2>
                                    <NxStartDate></NxStartDate>
                                </Attributes>
                                <Children>
                                    @CPADetails_CCC
                                </Children>
                            </AssociatedTkprs_CCC>
                        </Add>
                    </AssociatedTkprs_CCC>
";

        public static string AddContactRoles_CCC = @"
                 <ContactRoles_CCC>
                        <Add>
                            <ContactRoles_CCC>
                                <Attributes>
                                    <AccountName>NewValue</AccountName>
                                    <Email>NewValue</Email>
                                    <Phone>NewValue</Phone>
                                    <Role>NewValue</Role>
                                    <Title>NewValue</Title>
                                </Attributes>
                            </ContactRoles_CCC>
                        </Add>
                    </ContactRoles_CCC>
";

        public static string CPADetails_CCC = @"
                    <CPADetails_CCC>
                        @AddCPADetails_CCC
                    </CPADetails_CCC>
";
        public static string AddCPADetails_CCC = @"

        <Add>
                            <CPADetails_CCC>
                                <Attributes>
                                    <CPAAlliance></CPAAlliance>
                                    <CPAFirm>@CPAFirm</CPAFirm>
                                    <CPAParent></CPAParent>
                                    <CPAPct>@CPAPct</CPAPct>
                                    <CPAType>@CPAType</CPAType>
                                    <IsActive>1</IsActive>
                                    <CPACity></CPACity>
                                    <CPAState></CPAState>
                                    <CPAEmail></CPAEmail>
                                    <CPAPhone></CPAPhone>
                                    <CPAEntity>@CPAEntity</CPAEntity>
                                </Attributes>
                            </CPADetails_CCC>
                        </Add>

";

        public static string AddSalesForceInfo_CCC = @"
                    <SalesForceInfo_CCC>
                        <Add>
                            <SalesForceInfo_CCC>
                                <Attributes>
                                    <AdditionalRefSource>@AdditionalRefSource</AdditionalRefSource>
                                    <AdditionalSOE />
                                    <CPAWantsFinalNumbersDate></CPAWantsFinalNumbersDate>
                                    <EffStart>@EffStart</EffStart>
                                    <FedSOLEntity></FedSOLEntity>
                                    <FedSOLShareHolder></FedSOLShareHolder>
                                    <IsCPARequiresFinalReport>0</IsCPARequiresFinalReport>
                                    <IsUnderExistingAudit>0</IsUnderExistingAudit>
                                    <NxEndDate></NxEndDate>
                                    <RefType></RefType>
                                    <RelDirector />
                                    <SpecialInstructions></SpecialInstructions>
                                    <StateSOLEntity></StateSOLEntity>
                                    <StateSOLShareHolder></StateSOLShareHolder>
                                    <StatusUpdateRcpt></StatusUpdateRcpt>
                                    <StudyInfoEntityType>@StudyInfoEntityType</StudyInfoEntityType>
                                    <StudyInfoFedStudyYears>@StudyInfoFedStudyYears</StudyInfoFedStudyYears>
                                    <StudyInfoFiscalYearEnd>@StudyInfoFiscalYearEnd</StudyInfoFiscalYearEnd>
                                    <StudyInfoStates>@StudyInfoStates</StudyInfoStates>
                                    <StudyInfoStateStudyYears>@StudyInfoStateStudyYears</StudyInfoStateStudyYears>
                                    <YrsUnderExistingAudit></YrsUnderExistingAudit>
                                    <ASL>0</ASL>
                                    <MSReferralID></MSReferralID>
                                    <ReferringMatter></ReferringMatter>
                                    <BDAssistID></BDAssistID>
                                    <BDAssistOtherID></BDAssistOtherID>
                                    <ReferralInfo></ReferralInfo>
                                    <NxStartDate></NxStartDate>
                                </Attributes>
                                <Children>
                                </Children>
                            </SalesForceInfo_CCC>
                        </Add>
                    </SalesForceInfo_CCC>

";
        public static string AddReferralSource_CCC = @"<ReferralSource_CCC>
                                                            <Add>
                                                                <ReferralSource_CCC>
                                                                    <Attributes>
                                                                        <Account>NewValue</Account>
                                                                        <Campaign>NewValue</Campaign>
                                                                        <Name>NewValue</Name>
                                                                        <Source>NewValue</Source>
                                                                        <SubSource>NewValue</SubSource>
                                                                        <RefPMID>1</RefPMID>
                                                                        <RefCRID>1</RefCRID>
                                                                        <RefSubmittedByID>1</RefSubmittedByID>
                                                                        <RefSubmittedByTitle>NewValue</RefSubmittedByTitle>
                                                                        <RefTeamID>1</RefTeamID>
                                                                        <RefSubTeamID>1</RefSubTeamID>
                                                                    </Attributes>
                                                                </ReferralSource_CCC>
                                                            </Add>
                                                        </ReferralSource_CCC>
                                                        ";



    }
}
