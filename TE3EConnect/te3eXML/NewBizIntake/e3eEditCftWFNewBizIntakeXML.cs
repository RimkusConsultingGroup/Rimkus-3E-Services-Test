using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TE3EConnect.te3eXML.NewBizIntake
{
    public static partial class e3eCftWFNewBizIntakeXML
    {
        public static string EditCftWFNewBizIntakeXml = @"

         <Edit>
            <CftNewBizRequest KeyValue=""{CftNewBizRequestKey}"">
                <Attributes>
                    <Client>63527</Client>
                    <Matter>417522</Matter>
                    <RequestDateTime>2019-04-16T08:00:09</RequestDateTime>
                    <CftSearchReason>NewMatterExistingClient</CftSearchReason>
                    <Description>S&amp;S Lines &amp; Drains/Simpson Water Supply Line Evaluation</Description>
                    <CurrentSearchID>NewValue</CurrentSearchID>
                    <IsCreatedMatter>0</IsCreatedMatter>
                    <IsCreatedClient>1</IsCreatedClient>
                    <StartTime>1900-01-02T00:00:00</StartTime>
                    <CftNBRStatus>Approved</CftNBRStatus>
                    <CurrentWorkflowStep />
                    <OrgProc>NewBizRequest</OrgProc>
                    <ClientSearchNameId>NewValue</ClientSearchNameId>
                    <Submitter>f6face3b-fbef-479b-9870-f3349a238066</Submitter>
                    <FinalizeResult>Approved</FinalizeResult>
                    <DateRouted>1900-01-02T00:00:00</DateRouted>
                    <DateDecided>1900-01-02T00:00:00</DateDecided>
                    <DeclineReason />
                    <DeclineComment>NewValue</DeclineComment>
                    <DecidedBy />
                    <LoadNumber>NewValue</LoadNumber>
                    <LoadSource>NewValue</LoadSource>
                    <LoadGroup>NewValue</LoadGroup>
                    <LoadBatchID>NewValue</LoadBatchID>
                    <LoadFlag>1</LoadFlag>
                    <CftSearchClient>0</CftSearchClient>
                    <CftResultView />
                    <FromCMCase>1</FromCMCase>
                    <CmCase />
                    <AdminComments>NewValue</AdminComments>
                    <IsNBIntake>0</IsNBIntake>
                    <Entity />
                    <CreatedEntityIndex>1</CreatedEntityIndex>
                    <ClientMatterCreationRouteTo />
                    <IsCurrentClientMatterCreationStep>1</IsCurrentClientMatterCreationStep>
                    <EstimatedNumResults>2</EstimatedNumResults>
                    <IsLargeResultSetAllowed>1</IsLargeResultSetAllowed>
                    <LastEditedBy>ef2df787-3d90-443a-9a8d-8c847ae32746</LastEditedBy>
                    <IsNoSearchNecessary>1</IsNoSearchNecessary>
                    <ClientMatterCreationStep>NewValue</ClientMatterCreationStep>
                    <IsProspective_CCC>0</IsProspective_CCC>
                </Attributes>
                <Children>
                    <CftNewBizSearchName>
                        <Add>
                            <CftNewBizSearchName>
                                <Attributes>
                                    <CftPartyType>EntityOrg</CftPartyType>
                                    <CftRelationshipCode />
                                    <SearchString>NewValue</SearchString>
                                    <EntityDisplayName>S&amp;S Lines &amp; Drains</EntityDisplayName>
                                    <UserModifiedSearchString>1</UserModifiedSearchString>
                                    <FirstName>NewValue</FirstName>
                                    <MiddleName>NewValue</MiddleName>
                                    <LastName>NewValue</LastName>
                                    <CompanyName>S&amp;S Lines &amp; Drains</CompanyName>
                                    <DebugInfo>NewValue</DebugInfo>
                                    <Entity />
                                    <CftRole />
                                    <IsCreatedEntity>1</IsCreatedEntity>
                                    <AddedRelatedParty>1</AddedRelatedParty>
                                    <NumDuplicates>2</NumDuplicates>
                                    <RiskFlag />
                                    <DebugData>NewValue</DebugData>
                                    <Resolved>1</Resolved>
                                    <CurEntityIndex>1</CurEntityIndex>
                                    <LinkType />
                                    <Notes>NewValue</Notes>
                                    <IsPhoneticSearch>1</IsPhoneticSearch>
                                    <SortOrder>4</SortOrder>
                                    <IsClientAsSearchName>1</IsClientAsSearchName>
                                    <IsNotSearch>1</IsNotSearch>
                                    <IsNotCreateLink>0</IsNotCreateLink>
                                    <SearchTerm>(S&amp;S &amp; Drains) OR (2019-04-10) OR (Hollis &amp; Heights &amp; Newnan)</SearchTerm>
                                    <CftEntityType />
                                    <CftRelatedParty />
                                    <FullTextSearchResultCount>2</FullTextSearchResultCount>
                                </Attributes>
                            </CftNewBizSearchName>
                        </Add>
                        <Edit>
                            <CftNewBizSearchName KeyValue=""{CftNewBizSearchNameKey}"">
                                <Attributes>
                                    <CftPartyType>EntityOrg</CftPartyType>
                                    <CftRelationshipCode />
                                    <SearchString>NewValue</SearchString>
                                    <EntityDisplayName>S&amp;S Lines &amp; Drains</EntityDisplayName>
                                    <UserModifiedSearchString>1</UserModifiedSearchString>
                                    <FirstName>NewValue</FirstName>
                                    <MiddleName>NewValue</MiddleName>
                                    <LastName>NewValue</LastName>
                                    <CompanyName>S&amp;S Lines &amp; Drains</CompanyName>
                                    <DebugInfo>NewValue</DebugInfo>
                                    <Entity />
                                    <CftRole />
                                    <IsCreatedEntity>1</IsCreatedEntity>
                                    <AddedRelatedParty>1</AddedRelatedParty>
                                    <NumDuplicates>2</NumDuplicates>
                                    <RiskFlag />
                                    <DebugData>NewValue</DebugData>
                                    <Resolved>1</Resolved>
                                    <CurEntityIndex>1</CurEntityIndex>
                                    <LinkType />
                                    <Notes>NewValue</Notes>
                                    <IsPhoneticSearch>1</IsPhoneticSearch>
                                    <SortOrder>4</SortOrder>
                                    <IsClientAsSearchName>1</IsClientAsSearchName>
                                    <IsNotSearch>1</IsNotSearch>
                                    <IsNotCreateLink>0</IsNotCreateLink>
                                    <SearchTerm>(S&amp;S &amp; Drains) OR (2019-04-10) OR (Hollis &amp; Heights &amp; Newnan)</SearchTerm>
                                    <CftEntityType />
                                    <CftRelatedParty />
                                    <FullTextSearchResultCount>2</FullTextSearchResultCount>
                                </Attributes>
                            </CftNewBizSearchName>
                        </Edit>
                        <Add>
                            <CftNewBizSearchName>
                                <Attributes>
                                    <CftPartyType>EntityPerson</CftPartyType>
                                    <CftRelationshipCode />
                                    <SearchString>NewValue</SearchString>
                                    <EntityDisplayName>Brenda Simpson</EntityDisplayName>
                                    <UserModifiedSearchString>1</UserModifiedSearchString>
                                    <FirstName>Brenda</FirstName>
                                    <MiddleName>NewValue</MiddleName>
                                    <LastName>Simpson</LastName>
                                    <CompanyName>NewValue</CompanyName>
                                    <DebugInfo>NewValue</DebugInfo>
                                    <Entity />
                                    <CftRole />
                                    <IsCreatedEntity>1</IsCreatedEntity>
                                    <AddedRelatedParty>1</AddedRelatedParty>
                                    <NumDuplicates>2</NumDuplicates>
                                    <RiskFlag />
                                    <DebugData>NewValue</DebugData>
                                    <Resolved>1</Resolved>
                                    <CurEntityIndex>1</CurEntityIndex>
                                    <LinkType />
                                    <Notes>NewValue</Notes>
                                    <IsPhoneticSearch>1</IsPhoneticSearch>
                                    <SortOrder>5</SortOrder>
                                    <IsClientAsSearchName>1</IsClientAsSearchName>
                                    <IsNotSearch>1</IsNotSearch>
                                    <IsNotCreateLink>0</IsNotCreateLink>
                                    <SearchTerm>(Brenda &amp; Simpson)</SearchTerm>
                                    <CftEntityType />
                                    <CftRelatedParty />
                                    <FullTextSearchResultCount>3</FullTextSearchResultCount>
                                </Attributes>
                            </CftNewBizSearchName>
                        </Add>
                        <Edit>
                            <CftNewBizSearchName KeyValue=""CftNewBizSearchNameKey"">
                                <Attributes>
                                    <CftPartyType>EntityPerson</CftPartyType>
                                    <CftRelationshipCode />
                                    <SearchString>NewValue</SearchString>
                                    <EntityDisplayName>Brenda Simpson</EntityDisplayName>
                                    <UserModifiedSearchString>1</UserModifiedSearchString>
                                    <FirstName>Brenda</FirstName>
                                    <MiddleName>NewValue</MiddleName>
                                    <LastName>Simpson</LastName>
                                    <CompanyName>NewValue</CompanyName>
                                    <DebugInfo>NewValue</DebugInfo>
                                    <Entity />
                                    <CftRole />
                                    <IsCreatedEntity>1</IsCreatedEntity>
                                    <AddedRelatedParty>1</AddedRelatedParty>
                                    <NumDuplicates>2</NumDuplicates>
                                    <RiskFlag />
                                    <DebugData>NewValue</DebugData>
                                    <Resolved>1</Resolved>
                                    <CurEntityIndex>1</CurEntityIndex>
                                    <LinkType />
                                    <Notes>NewValue</Notes>
                                    <IsPhoneticSearch>1</IsPhoneticSearch>
                                    <SortOrder>5</SortOrder>
                                    <IsClientAsSearchName>1</IsClientAsSearchName>
                                    <IsNotSearch>1</IsNotSearch>
                                    <IsNotCreateLink>0</IsNotCreateLink>
                                    <SearchTerm>(Brenda &amp; Simpson)</SearchTerm>
                                    <CftEntityType />
                                    <CftRelatedParty />
                                    <FullTextSearchResultCount>3</FullTextSearchResultCount>
                                </Attributes>
                            </CftNewBizSearchName>
                        </Edit>
                    </CftNewBizSearchName>
                    <CftSearch>
                        <Add>
                            <CftSearch>
                                <Attributes>
                                    <Description>S&amp;S Lines &amp; Drains/Simpson Water Supply Line Evaluation</Description>
                                    <NumResults>4</NumResults>
                                    <DateRun>2019-04-20T15:59:32</DateRun>
                                    <Comments>NewValue</Comments>
                                    <IsErrored>1</IsErrored>
                                    <OrigNumResults>4</OrigNumResults>
                                    <NumResultsLiteral>3 of 3</NumResultsLiteral>
                                    <RanBy>7356c8e1-de08-40ba-a0f1-5a8bc02707af</RanBy>
                                    <SimpleSearchTerms>NewValue</SimpleSearchTerms>
                                    <CurrentWorkflowStep>Finalized</CurrentWorkflowStep>
                                    <ContinueWorkflow>1</ContinueWorkflow>
                                    <WorkflowEndReason>1</WorkflowEndReason>
                                    <ElapsedDataTime>2</ElapsedDataTime>
                                    <ElapsedSearchTime>532</ElapsedSearchTime>
                                    <FinalDecision>Approved</FinalDecision>
                                    <IsRouted>0</IsRouted>
                                    <DCSReportID>NewValue</DCSReportID>
                                    <DecisionBy>7356c8e1-de08-40ba-a0f1-5a8bc02707af</DecisionBy>
                                    <DateRouted>2019-04-20T00:00:00</DateRouted>
                                    <DateDecided>2019-04-20T00:00:00</DateDecided>
                                    <IsSelectedResults>1</IsSelectedResults>
                                    <isFiltersPopulated>1</isFiltersPopulated>
                                    <ParentId>NewValue</ParentId>
                                    <CftAuthority />
                                    <IsAccessToRoutedResults>1</IsAccessToRoutedResults>
                                    <CftSearchTypeList>Conflicts Search</CftSearchTypeList>
                                    <IsPhoneticSearch>1</IsPhoneticSearch>
                                    <NxBaseUser>653df626-eb1d-46ee-b8de-5f677e6432e4</NxBaseUser>
                                    <CftSearchAuthorityList>Decision Maker</CftSearchAuthorityList>
                                    <CftSearchResultsViewList>Detail</CftSearchResultsViewList>
                                    <StepDate>2019-04-20T16:00:05</StepDate>
                                    <EstimatedNumResults>1</EstimatedNumResults>
                                    <IsProspectiveUnfiltered>1</IsProspectiveUnfiltered>
                                    <CopyDescription>NewValue</CopyDescription>
                                    <CopySavedDate>1900-01-02T00:00:00</CopySavedDate>
                                    <CopySavedBy />
                                    <IsReadOnlyAccess>1</IsReadOnlyAccess>
                                    <LblDecisionReview2>NewValue</LblDecisionReview2>
                                    <CurrentOwner>b7e5705f-bb7a-4727-8c70-4bce9b4a5e4b</CurrentOwner>
                                    <DisplayCurrentOwner>b7e5705f-bb7a-4727-8c70-4bce9b4a5e4b</DisplayCurrentOwner>
                                    <IsAllowReRouteAll>0</IsAllowReRouteAll>
                                    <IsRouteAllReleaseReciepient>1</IsRouteAllReleaseReciepient>
                                    <IsSearchReexecuted>1</IsSearchReexecuted>
                                    <IsUnboundDataPopulated>1</IsUnboundDataPopulated>
                                    <IsSearchForViewOnly>1</IsSearchForViewOnly>
                                    <IsRouteSelected>1</IsRouteSelected>
                                    <MaxProcessedPageNumber>2</MaxProcessedPageNumber>
                                    <IsViewAllPages>1</IsViewAllPages>
                                    <RoutingBGStatus>NewValue</RoutingBGStatus>
                                    <IsRoutingBG>1</IsRoutingBG>
                                    <IsProcessAllPages>1</IsProcessAllPages>
                                    <UseHighlighting>0</UseHighlighting>
                                    <UseEquivalency>0</UseEquivalency>
                                </Attributes>
                                <Children>
                                    <CftSearchTerm>
                                        <Add>
                                            <CftSearchTerm>
                                                <Attributes>
                                                    <SearchTerm>NewValue</SearchTerm>
                                                    <NumResults>2</NumResults>
                                                    <Name>S&amp;S Lines &amp; Drains</Name>
                                                    <IsErrored>1</IsErrored>
                                                    <CftRelationshipCode />
                                                    <SortOrder>2</SortOrder>
                                                    <OrigNumResults>2</OrigNumResults>
                                                    <NumResultsLiteral>1 of 1</NumResultsLiteral>
                                                    <CftRole />
                                                    <RiskImage />
                                                    <FullTextSearchRequestID>db8de0e1-0be4-4451-a3ec-b5c6ad7bb859</FullTextSearchRequestID>
                                                    <ElapsedTotalTime>298</ElapsedTotalTime>
                                                    <ElapsedResultTime>17</ElapsedResultTime>
                                                    <DateRun>2019-04-20T15:59:32</DateRun>
                                                    <IsPhoneticSearch>1</IsPhoneticSearch>
                                                    <CftNewBizSearchName>87bc4f6b-5a69-48e9-af9e-a1bd4eb77712</CftNewBizSearchName>
                                                    <IsNotSearch>1</IsNotSearch>
                                                    <IsNotCreateLink>0</IsNotCreateLink>
                                                    <OrigSearchTerm>NewValue</OrigSearchTerm>
                                                    <SearchTerms>(S&amp;S &amp; Drains) OR (2019-04-10) OR (Hollis &amp; Heights &amp; Newnan)</SearchTerms>
                                                    <EstimatedResultCount>2</EstimatedResultCount>
                                                </Attributes>
                                            </CftSearchTerm>
                                        </Add>
                                        <Add>
                                            <CftSearchTerm>
                                                <Attributes>
                                                    <SearchTerm>NewValue</SearchTerm>
                                                    <NumResults>3</NumResults>
                                                    <Name>Brenda Simpson</Name>
                                                    <IsErrored>1</IsErrored>
                                                    <CftRelationshipCode />
                                                    <SortOrder>1</SortOrder>
                                                    <OrigNumResults>3</OrigNumResults>
                                                    <NumResultsLiteral>2 of 2</NumResultsLiteral>
                                                    <CftRole />
                                                    <RiskImage />
                                                    <FullTextSearchRequestID>6023bee9-e130-48f9-994c-9ee4ae62ee7b</FullTextSearchRequestID>
                                                    <ElapsedTotalTime>392</ElapsedTotalTime>
                                                    <ElapsedResultTime>79</ElapsedResultTime>
                                                    <DateRun>2019-04-20T15:59:32</DateRun>
                                                    <IsPhoneticSearch>1</IsPhoneticSearch>
                                                    <CftNewBizSearchName>460cf8b8-f377-4543-89c1-be075418e7d9</CftNewBizSearchName>
                                                    <IsNotSearch>1</IsNotSearch>
                                                    <IsNotCreateLink>0</IsNotCreateLink>
                                                    <OrigSearchTerm>NewValue</OrigSearchTerm>
                                                    <SearchTerms>(Brenda &amp; Simpson)</SearchTerms>
                                                    <EstimatedResultCount>2</EstimatedResultCount>
                                                </Attributes>
                                            </CftSearchTerm>
                                        </Add>
                                    </CftSearchTerm>
                                    <CftSearchResult>
                                        <Add>
                                            <CftSearchResultRPOrg>
                                                <Attributes>
                                                    <SearchTermGroupingLabel>000002 - S&amp;S Lines &amp; Drains - Searched without Role</SearchTermGroupingLabel>
                                                    <Name>NewValue</Name>
                                                    <Text>[H]S[/H]&amp;[H]S[/H] Lines &amp; [H]Drains[/H]</Text>
                                                    <ProviderCode>FrameworkDataProvider</ProviderCode>
                                                    <FullTextDocumentID>5038f6e2-db84-4734-be2a-7d746fb135c2</FullTextDocumentID>
                                                    <HitCount>1</HitCount>
                                                    <TextLanguage>1</TextLanguage>
                                                    <DataItemID>ed3a4ff3-b1ae-4bac-b882-382c82537ba7</DataItemID>
                                                    <ArchCode>CftRelatedParty</ArchCode>
                                                    <AttrCode>DisplayName</AttrCode>
                                                    <IsExcluded>1</IsExcluded>
                                                    <PartialText>[H]S[/H]&amp;[H]S[/H] Lines &amp; [H]Drains[/H]</PartialText>
                                                    <WhereFoundSortOrder>4</WhereFoundSortOrder>
                                                    <StatusSortString>NewValue</StatusSortString>
                                                    <WhereFoundArchCode>CftRelatedParty</WhereFoundArchCode>
                                                    <WhereFoundAttrCode>DisplayName</WhereFoundAttrCode>
                                                    <WhereFoundArchCaption>RelatedParty</WhereFoundArchCaption>
                                                    <WhereFoundAttrCaption>Entity Name</WhereFoundAttrCaption>
                                                    <WhereFound>RelatedParty.Entity Name</WhereFound>
                                                    <WhereFoundItemID>8685055e-0070-47c1-a756-0ff8a2315445</WhereFoundItemID>
                                                    <CftSearchTerm>9a809490-abbe-4e9e-b7c9-8d9793f988a7</CftSearchTerm>
                                                    <RiskImage>3</RiskImage>
                                                    <SearchTermSortOrder>2</SearchTermSortOrder>
                                                    <DebugInfo>NewValue</DebugInfo>
                                                    <DetailItemID>8685055e-0070-47c1-a756-0ff8a2315445</DetailItemID>
                                                    <DetailArchCode>CftRelatedParty</DetailArchCode>
                                                    <OpenMatters>1</OpenMatters>
                                                    <ClosedMatters>1</ClosedMatters>
                                                    <OpCLMatters>NewValue</OpCLMatters>
                                                    <WhereFoundFrameworkItemID>8685055e-0070-47c1-a756-0ff8a2315445</WhereFoundFrameworkItemID>
                                                    <RiskflagText>NewValue</RiskflagText>
                                                    <IsSelected>1</IsSelected>
                                                    <Assessment>NewValue</Assessment>
                                                    <Routed>NewValue</Routed>
                                                    <IsFiltered>1</IsFiltered>
                                                    <CorporateTreeImage />
                                                    <SearchNo>2</SearchNo>
                                                    <ClientName>NewValue</ClientName>
                                                    <MatterName>NewValue</MatterName>
                                                    <Role>Insured</Role>
                                                    <Relationship>NewValue</Relationship>
                                                    <ConflictsContact>NewValue</ConflictsContact>
                                                    <CftEntityOrMatterIndex>1</CftEntityOrMatterIndex>
                                                    <EthicalWallImage />
                                                    <CftClientIndex>63528</CftClientIndex>
                                                    <EntitySanctionLoad />
                                                    <IsMattercentricHit>1</IsMattercentricHit>
                                                    <DisplayNumber>NewValue</DisplayNumber>
                                                    <IsRouteSelected>1</IsRouteSelected>
                                                    <EntityIndex>578937</EntityIndex>
                                                    <MatterIndex>417523</MatterIndex>
                                                    <DisplayText>NewValue</DisplayText>
                                                    <DisplayPartialText>NewValue</DisplayPartialText>
                                                    <DisplayClientName>NewValue</DisplayClientName>
                                                    <DisplayMatterName>NewValue</DisplayMatterName>
                                                    <DisplayNum>NewValue</DisplayNum>
                                                    <IsFilterAppliedToDetail>1</IsFilterAppliedToDetail>
                                                    <TimekeeperContact />
                                                    <NxUserContact />
                                                    <DisplayOpenMattersCount>2</DisplayOpenMattersCount>
                                                    <DisplayClosedMattersCount>2</DisplayClosedMattersCount>
                                                    <DisplayEthicalWallImage />
                                                    <DisplayCorporateTreeImage />
                                                    <DisplayConflictsContact>NewValue</DisplayConflictsContact>
                                                    <IsResultSelected>1</IsResultSelected>
                                                    <CftRoleCode />
                                                    <ThresholdIndicator> </ThresholdIndicator>
                                                    <IsSearchHasFilter>1</IsSearchHasFilter>
                                                    <IsForceRetrieveDetails>1</IsForceRetrieveDetails>
                                                    <ResultsDifferenceImage />
                                                    <CftSearchCompareStatus />
                                                    <IsResultModified>0</IsResultModified>
                                                    <SourceCollection>3E</SourceCollection>
                                                    <IsExternalHit>1</IsExternalHit>
                                                    <FTXSourceType>3EDatabase</FTXSourceType>
                                                    <PageNumber>0</PageNumber>
                                                    <IsViewDifference>1</IsViewDifference>
                                                    <CftFullTextResults>e99ca9ad-e471-4116-aaa4-60ead13fd7f3</CftFullTextResults>
                                                    <LocationOfOccurenceTxt_CCC>NewValue</LocationOfOccurenceTxt_CCC>
                                                    <DateOfOccurenceTxt_CCC>NewValue</DateOfOccurenceTxt_CCC>
                                                    <RelatedPartyID>8685055e-0070-47c1-a756-0ff8a2315445</RelatedPartyID>
                                                    <EntIndex>2</EntIndex>
                                                    <MattIndex>2</MattIndex>
                                                    <Notes>NewValue</Notes>
                                                    <EntityID>NewValue</EntityID>
                                                    <MatterID>NewValue</MatterID>
                                                    <LinkType>NewValue</LinkType>
                                                    <LinkStatus>NewValue</LinkStatus>
                                                    <ClientNumber>NewValue</ClientNumber>
                                                    <MatterNumber>NewValue</MatterNumber>
                                                    <RPClientName>NewValue</RPClientName>
                                                    <RPMatterName>NewValue</RPMatterName>
                                                    <ClientStatus>NewValue</ClientStatus>
                                                    <MatterStatus>NewValue</MatterStatus>
                                                    <CftRelatedParty />
                                                    <IsProspectiveRPItem>1</IsProspectiveRPItem>
                                                    <ClientOpenDate>1900-01-02T00:00:00</ClientOpenDate>
                                                    <ClientCloseDate>1900-01-02T00:00:00</ClientCloseDate>
                                                    <IsCreatedParty>1</IsCreatedParty>
                                                </Attributes>
                                            </CftSearchResultRPOrg>
                                        </Add>
                                        <Add>
                                            <CftSearchResultRPPerson>
                                                <Attributes>
                                                    <SearchTermGroupingLabel>000001 - Brenda Simpson - Searched without Role</SearchTermGroupingLabel>
                                                    <Name>NewValue</Name>
                                                    <Text>[H]Brenda[/H] [H]Simpson[/H]</Text>
                                                    <ProviderCode>FrameworkDataProvider</ProviderCode>
                                                    <FullTextDocumentID>a8d65561-d6a2-4ee5-a088-e3e33070e1e7</FullTextDocumentID>
                                                    <HitCount>1</HitCount>
                                                    <TextLanguage>1</TextLanguage>
                                                    <DataItemID>0e0d9a27-6aa1-4304-a635-f8945030f6e5</DataItemID>
                                                    <ArchCode>CftRelatedParty</ArchCode>
                                                    <AttrCode>DisplayName</AttrCode>
                                                    <IsExcluded>1</IsExcluded>
                                                    <PartialText>[H]Brenda[/H] [H]Simpson[/H]</PartialText>
                                                    <WhereFoundSortOrder>4</WhereFoundSortOrder>
                                                    <StatusSortString>NewValue</StatusSortString>
                                                    <WhereFoundArchCode>CftRelatedParty</WhereFoundArchCode>
                                                    <WhereFoundAttrCode>DisplayName</WhereFoundAttrCode>
                                                    <WhereFoundArchCaption>RelatedParty</WhereFoundArchCaption>
                                                    <WhereFoundAttrCaption>Entity Name</WhereFoundAttrCaption>
                                                    <WhereFound>RelatedParty.Entity Name</WhereFound>
                                                    <WhereFoundItemID>dbfbf6e4-b7e4-42c7-9f9e-73b33f21c836</WhereFoundItemID>
                                                    <CftSearchTerm>2b715017-1e67-4837-b185-c7d5c40cc4b0</CftSearchTerm>
                                                    <RiskImage>3</RiskImage>
                                                    <SearchTermSortOrder>1</SearchTermSortOrder>
                                                    <DebugInfo>NewValue</DebugInfo>
                                                    <DetailItemID>dbfbf6e4-b7e4-42c7-9f9e-73b33f21c836</DetailItemID>
                                                    <DetailArchCode>CftRelatedParty</DetailArchCode>
                                                    <OpenMatters>1</OpenMatters>
                                                    <ClosedMatters>2</ClosedMatters>
                                                    <OpCLMatters>NewValue</OpCLMatters>
                                                    <WhereFoundFrameworkItemID>dbfbf6e4-b7e4-42c7-9f9e-73b33f21c836</WhereFoundFrameworkItemID>
                                                    <RiskflagText>NewValue</RiskflagText>
                                                    <IsSelected>1</IsSelected>
                                                    <Assessment>NewValue</Assessment>
                                                    <Routed>NewValue</Routed>
                                                    <IsFiltered>1</IsFiltered>
                                                    <CorporateTreeImage />
                                                    <SearchNo>2</SearchNo>
                                                    <ClientName>NewValue</ClientName>
                                                    <MatterName>NewValue</MatterName>
                                                    <Role>Insured</Role>
                                                    <Relationship>NewValue</Relationship>
                                                    <ConflictsContact>NewValue</ConflictsContact>
                                                    <CftEntityOrMatterIndex>1</CftEntityOrMatterIndex>
                                                    <EthicalWallImage />
                                                    <CftClientIndex>53314</CftClientIndex>
                                                    <EntitySanctionLoad />
                                                    <IsMattercentricHit>1</IsMattercentricHit>
                                                    <DisplayNumber>NewValue</DisplayNumber>
                                                    <IsRouteSelected>1</IsRouteSelected>
                                                    <EntityIndex>498891</EntityIndex>
                                                    <MatterIndex>270744</MatterIndex>
                                                    <DisplayText>NewValue</DisplayText>
                                                    <DisplayPartialText>NewValue</DisplayPartialText>
                                                    <DisplayClientName>NewValue</DisplayClientName>
                                                    <DisplayMatterName>NewValue</DisplayMatterName>
                                                    <DisplayNum>NewValue</DisplayNum>
                                                    <IsFilterAppliedToDetail>1</IsFilterAppliedToDetail>
                                                    <TimekeeperContact />
                                                    <NxUserContact />
                                                    <DisplayOpenMattersCount>2</DisplayOpenMattersCount>
                                                    <DisplayClosedMattersCount>2</DisplayClosedMattersCount>
                                                    <DisplayEthicalWallImage />
                                                    <DisplayCorporateTreeImage />
                                                    <DisplayConflictsContact>NewValue</DisplayConflictsContact>
                                                    <IsResultSelected>1</IsResultSelected>
                                                    <CftRoleCode />
                                                    <ThresholdIndicator> </ThresholdIndicator>
                                                    <IsSearchHasFilter>1</IsSearchHasFilter>
                                                    <IsForceRetrieveDetails>1</IsForceRetrieveDetails>
                                                    <ResultsDifferenceImage />
                                                    <CftSearchCompareStatus />
                                                    <IsResultModified>0</IsResultModified>
                                                    <SourceCollection>3E</SourceCollection>
                                                    <IsExternalHit>1</IsExternalHit>
                                                    <FTXSourceType>3EDatabase</FTXSourceType>
                                                    <PageNumber>0</PageNumber>
                                                    <IsViewDifference>1</IsViewDifference>
                                                    <CftFullTextResults>10e66554-9c43-40a4-8e9a-690ce6dd83bd</CftFullTextResults>
                                                    <LocationOfOccurenceTxt_CCC>NewValue</LocationOfOccurenceTxt_CCC>
                                                    <DateOfOccurenceTxt_CCC>NewValue</DateOfOccurenceTxt_CCC>
                                                    <RelatedPartyID>dbfbf6e4-b7e4-42c7-9f9e-73b33f21c836</RelatedPartyID>
                                                    <EntIndex>2</EntIndex>
                                                    <MattIndex>2</MattIndex>
                                                    <Notes>NewValue</Notes>
                                                    <EntityID>NewValue</EntityID>
                                                    <MatterID>NewValue</MatterID>
                                                    <LinkType>NewValue</LinkType>
                                                    <LinkStatus>NewValue</LinkStatus>
                                                    <ClientNumber>NewValue</ClientNumber>
                                                    <MatterNumber>NewValue</MatterNumber>
                                                    <RPClientName>NewValue</RPClientName>
                                                    <RPMatterName>NewValue</RPMatterName>
                                                    <ClientStatus>NewValue</ClientStatus>
                                                    <MatterStatus>NewValue</MatterStatus>
                                                    <CftRelatedParty />
                                                    <IsProspectiveRPItem>1</IsProspectiveRPItem>
                                                    <ClientOpenDate>1900-01-02T00:00:00</ClientOpenDate>
                                                    <ClientCloseDate>1900-01-02T00:00:00</ClientCloseDate>
                                                    <IsCreatedParty>1</IsCreatedParty>
                                                </Attributes>
                                            </CftSearchResultRPPerson>
                                        </Add>
                                        <Add>
                                            <CftSearchResultRPPerson>
                                                <Attributes>
                                                    <SearchTermGroupingLabel>000001 - Brenda Simpson - Searched without Role</SearchTermGroupingLabel>
                                                    <Name>NewValue</Name>
                                                    <Text>[H]Brenda[/H] [H]Simpson[/H]</Text>
                                                    <ProviderCode>FrameworkDataProvider</ProviderCode>
                                                    <FullTextDocumentID>aa3d9f57-8eb5-4f0c-af9a-a089ae900e87</FullTextDocumentID>
                                                    <HitCount>1</HitCount>
                                                    <TextLanguage>1</TextLanguage>
                                                    <DataItemID>70ae5c0c-8d0d-4c0e-9526-9235b5be29b5</DataItemID>
                                                    <ArchCode>CftRelatedParty</ArchCode>
                                                    <AttrCode>DisplayName</AttrCode>
                                                    <IsExcluded>1</IsExcluded>
                                                    <PartialText>[H]Brenda[/H] [H]Simpson[/H]</PartialText>
                                                    <WhereFoundSortOrder>4</WhereFoundSortOrder>
                                                    <StatusSortString>NewValue</StatusSortString>
                                                    <WhereFoundArchCode>CftRelatedParty</WhereFoundArchCode>
                                                    <WhereFoundAttrCode>DisplayName</WhereFoundAttrCode>
                                                    <WhereFoundArchCaption>RelatedParty</WhereFoundArchCaption>
                                                    <WhereFoundAttrCaption>Entity Name</WhereFoundAttrCaption>
                                                    <WhereFound>RelatedParty.Entity Name</WhereFound>
                                                    <WhereFoundItemID>144414ae-745d-4f8f-b0c7-e1696b348f74</WhereFoundItemID>
                                                    <CftSearchTerm>2b715017-1e67-4837-b185-c7d5c40cc4b0</CftSearchTerm>
                                                    <RiskImage>3</RiskImage>
                                                    <SearchTermSortOrder>1</SearchTermSortOrder>
                                                    <DebugInfo>NewValue</DebugInfo>
                                                    <DetailItemID>144414ae-745d-4f8f-b0c7-e1696b348f74</DetailItemID>
                                                    <DetailArchCode>CftRelatedParty</DetailArchCode>
                                                    <OpenMatters>1</OpenMatters>
                                                    <ClosedMatters>1</ClosedMatters>
                                                    <OpCLMatters>NewValue</OpCLMatters>
                                                    <WhereFoundFrameworkItemID>144414ae-745d-4f8f-b0c7-e1696b348f74</WhereFoundFrameworkItemID>
                                                    <RiskflagText>NewValue</RiskflagText>
                                                    <IsSelected>1</IsSelected>
                                                    <Assessment>NewValue</Assessment>
                                                    <Routed>NewValue</Routed>
                                                    <IsFiltered>1</IsFiltered>
                                                    <CorporateTreeImage />
                                                    <SearchNo>2</SearchNo>
                                                    <ClientName>NewValue</ClientName>
                                                    <MatterName>NewValue</MatterName>
                                                    <Role>Claimant</Role>
                                                    <Relationship>NewValue</Relationship>
                                                    <ConflictsContact>NewValue</ConflictsContact>
                                                    <CftEntityOrMatterIndex>1</CftEntityOrMatterIndex>
                                                    <EthicalWallImage />
                                                    <CftClientIndex>63528</CftClientIndex>
                                                    <EntitySanctionLoad />
                                                    <IsMattercentricHit>1</IsMattercentricHit>
                                                    <DisplayNumber>NewValue</DisplayNumber>
                                                    <IsRouteSelected>1</IsRouteSelected>
                                                    <EntityIndex>578938</EntityIndex>
                                                    <MatterIndex>417523</MatterIndex>
                                                    <DisplayText>NewValue</DisplayText>
                                                    <DisplayPartialText>NewValue</DisplayPartialText>
                                                    <DisplayClientName>NewValue</DisplayClientName>
                                                    <DisplayMatterName>NewValue</DisplayMatterName>
                                                    <DisplayNum>NewValue</DisplayNum>
                                                    <IsFilterAppliedToDetail>1</IsFilterAppliedToDetail>
                                                    <TimekeeperContact />
                                                    <NxUserContact />
                                                    <DisplayOpenMattersCount>2</DisplayOpenMattersCount>
                                                    <DisplayClosedMattersCount>2</DisplayClosedMattersCount>
                                                    <DisplayEthicalWallImage />
                                                    <DisplayCorporateTreeImage />
                                                    <DisplayConflictsContact>NewValue</DisplayConflictsContact>
                                                    <IsResultSelected>1</IsResultSelected>
                                                    <CftRoleCode />
                                                    <ThresholdIndicator> </ThresholdIndicator>
                                                    <IsSearchHasFilter>1</IsSearchHasFilter>
                                                    <IsForceRetrieveDetails>1</IsForceRetrieveDetails>
                                                    <ResultsDifferenceImage />
                                                    <CftSearchCompareStatus />
                                                    <IsResultModified>0</IsResultModified>
                                                    <SourceCollection>3E</SourceCollection>
                                                    <IsExternalHit>1</IsExternalHit>
                                                    <FTXSourceType>3EDatabase</FTXSourceType>
                                                    <PageNumber>0</PageNumber>
                                                    <IsViewDifference>1</IsViewDifference>
                                                    <CftFullTextResults>dfa96ca6-074d-4522-8459-33b09df583a1</CftFullTextResults>
                                                    <LocationOfOccurenceTxt_CCC>NewValue</LocationOfOccurenceTxt_CCC>
                                                    <DateOfOccurenceTxt_CCC>NewValue</DateOfOccurenceTxt_CCC>
                                                    <RelatedPartyID>144414ae-745d-4f8f-b0c7-e1696b348f74</RelatedPartyID>
                                                    <EntIndex>2</EntIndex>
                                                    <MattIndex>2</MattIndex>
                                                    <Notes>NewValue</Notes>
                                                    <EntityID>NewValue</EntityID>
                                                    <MatterID>NewValue</MatterID>
                                                    <LinkType>NewValue</LinkType>
                                                    <LinkStatus>NewValue</LinkStatus>
                                                    <ClientNumber>NewValue</ClientNumber>
                                                    <MatterNumber>NewValue</MatterNumber>
                                                    <RPClientName>NewValue</RPClientName>
                                                    <RPMatterName>NewValue</RPMatterName>
                                                    <ClientStatus>NewValue</ClientStatus>
                                                    <MatterStatus>NewValue</MatterStatus>
                                                    <CftRelatedParty />
                                                    <IsProspectiveRPItem>1</IsProspectiveRPItem>
                                                    <ClientOpenDate>1900-01-02T00:00:00</ClientOpenDate>
                                                    <ClientCloseDate>1900-01-02T00:00:00</ClientCloseDate>
                                                    <IsCreatedParty>1</IsCreatedParty>
                                                </Attributes>
                                            </CftSearchResultRPPerson>
                                        </Add>
                                    </CftSearchResult>
                                    <CftComments>
                                        <Add>
                                            <CftComments>
                                                <Attributes>
                                                    <CftSearchAssessment>fca12c19-10dc-4baf-8351-bf141feab750</CftSearchAssessment>
                                                    <CftReviewer>ef2df787-3d90-443a-9a8d-8c847ae32746</CftReviewer>
                                                    <CftNewBizRequest>06122784-ebba-4e85-82b8-ac55142e59f3</CftNewBizRequest>
                                                    <CftDateTime>2019-04-17T14:21:21</CftDateTime>
                                                    <CftComments>Please remove the 'and' from the Insured.</CftComments>
                                                </Attributes>
                                            </CftComments>
                                        </Add>
                                    </CftComments>
                                    <CftWorkflowHistory>
                                        <Add>
                                            <CftWorkflowHistory>
                                                <Attributes>
                                                    <CftNBRStatus>Pending</CftNBRStatus>
                                                    <CftWorkflowStep>SearchEntry</CftWorkflowStep>
                                                    <NxBaseUser>f22b6972-e56c-41ea-a99a-e3b3f2d3ce8c</NxBaseUser>
                                                    <StartDate>2019-04-18T06:49:17</StartDate>
                                                    <EndDate>1900-01-02T00:00:00</EndDate>
                                                    <CftSearchAuthorityList />
                                                </Attributes>
                                            </CftWorkflowHistory>
                                        </Add>
                                        <Add>
                                            <CftWorkflowHistory>
                                                <Attributes>
                                                    <CftNBRStatus>Pending</CftNBRStatus>
                                                    <CftWorkflowStep>SearchEntry</CftWorkflowStep>
                                                    <NxBaseUser>f22b6972-e56c-41ea-a99a-e3b3f2d3ce8c</NxBaseUser>
                                                    <StartDate>2019-04-18T06:49:15</StartDate>
                                                    <EndDate>2019-04-18T06:49:17</EndDate>
                                                    <CftSearchAuthorityList />
                                                </Attributes>
                                            </CftWorkflowHistory>
                                        </Add>
                                        <Add>
                                            <CftWorkflowHistory>
                                                <Attributes>
                                                    <CftNBRStatus>Pending</CftNBRStatus>
                                                    <CftWorkflowStep>SearchEntry</CftWorkflowStep>
                                                    <NxBaseUser>f22b6972-e56c-41ea-a99a-e3b3f2d3ce8c</NxBaseUser>
                                                    <StartDate>2019-04-20T15:59:01</StartDate>
                                                    <EndDate>1900-01-02T00:00:00</EndDate>
                                                    <CftSearchAuthorityList />
                                                </Attributes>
                                            </CftWorkflowHistory>
                                        </Add>
                                        <Add>
                                            <CftWorkflowHistory>
                                                <Attributes>
                                                    <CftNBRStatus>Pending</CftNBRStatus>
                                                    <CftWorkflowStep>SearchEntry</CftWorkflowStep>
                                                    <NxBaseUser>f22b6972-e56c-41ea-a99a-e3b3f2d3ce8c</NxBaseUser>
                                                    <StartDate>2019-04-16T08:20:18</StartDate>
                                                    <EndDate>1900-01-02T00:00:00</EndDate>
                                                    <CftSearchAuthorityList />
                                                </Attributes>
                                            </CftWorkflowHistory>
                                        </Add>
                                        <Add>
                                            <CftWorkflowHistory>
                                                <Attributes>
                                                    <CftNBRStatus>Pending</CftNBRStatus>
                                                    <CftWorkflowStep>SearchEntry</CftWorkflowStep>
                                                    <NxBaseUser>ef2df787-3d90-443a-9a8d-8c847ae32746</NxBaseUser>
                                                    <StartDate>2019-04-16T08:20:18</StartDate>
                                                    <EndDate>2019-04-17T14:22:32</EndDate>
                                                    <CftSearchAuthorityList />
                                                </Attributes>
                                            </CftWorkflowHistory>
                                        </Add>
                                        <Add>
                                            <CftWorkflowHistory>
                                                <Attributes>
                                                    <CftNBRStatus>Pending</CftNBRStatus>
                                                    <CftWorkflowStep>SearchEntry</CftWorkflowStep>
                                                    <NxBaseUser>f22b6972-e56c-41ea-a99a-e3b3f2d3ce8c</NxBaseUser>
                                                    <StartDate>2019-04-16T08:20:16</StartDate>
                                                    <EndDate>2019-04-16T08:20:18</EndDate>
                                                    <CftSearchAuthorityList />
                                                </Attributes>
                                            </CftWorkflowHistory>
                                        </Add>
                                        <Add>
                                            <CftWorkflowHistory>
                                                <Attributes>
                                                    <CftNBRStatus>Pending</CftNBRStatus>
                                                    <CftWorkflowStep>NBIEntry</CftWorkflowStep>
                                                    <NxBaseUser>f6face3b-fbef-479b-9870-f3349a238066</NxBaseUser>
                                                    <StartDate>2019-04-16T08:00:09</StartDate>
                                                    <EndDate>1900-01-02T00:00:00</EndDate>
                                                    <CftSearchAuthorityList />
                                                </Attributes>
                                            </CftWorkflowHistory>
                                        </Add>
                                        <Add>
                                            <CftWorkflowHistory>
                                                <Attributes>
                                                    <CftNBRStatus>Pending</CftNBRStatus>
                                                    <CftWorkflowStep>SearchResults</CftWorkflowStep>
                                                    <NxBaseUser>7356c8e1-de08-40ba-a0f1-5a8bc02707af</NxBaseUser>
                                                    <StartDate>2019-04-20T15:59:31</StartDate>
                                                    <EndDate>2019-04-20T15:59:58</EndDate>
                                                    <CftSearchAuthorityList />
                                                </Attributes>
                                            </CftWorkflowHistory>
                                        </Add>
                                        <Add>
                                            <CftWorkflowHistory>
                                                <Attributes>
                                                    <CftNBRStatus>PendingApproved</CftNBRStatus>
                                                    <CftWorkflowStep>ResultsReviewForDecision</CftWorkflowStep>
                                                    <NxBaseUser>653df626-eb1d-46ee-b8de-5f677e6432e4</NxBaseUser>
                                                    <StartDate>2019-04-20T16:00:04</StartDate>
                                                    <EndDate>2019-04-20T16:00:05</EndDate>
                                                    <CftSearchAuthorityList>Decision Maker</CftSearchAuthorityList>
                                                </Attributes>
                                            </CftWorkflowHistory>
                                        </Add>
                                        <Add>
                                            <CftWorkflowHistory>
                                                <Attributes>
                                                    <CftNBRStatus>Pending</CftNBRStatus>
                                                    <CftWorkflowStep>SearchEntry</CftWorkflowStep>
                                                    <NxBaseUser>7356c8e1-de08-40ba-a0f1-5a8bc02707af</NxBaseUser>
                                                    <StartDate>2019-04-18T06:49:17</StartDate>
                                                    <EndDate>2019-04-20T15:58:35</EndDate>
                                                    <CftSearchAuthorityList />
                                                </Attributes>
                                            </CftWorkflowHistory>
                                        </Add>
                                        <Add>
                                            <CftWorkflowHistory>
                                                <Attributes>
                                                    <CftNBRStatus>Pending</CftNBRStatus>
                                                    <CftWorkflowStep>SearchEntry</CftWorkflowStep>
                                                    <NxBaseUser>7356c8e1-de08-40ba-a0f1-5a8bc02707af</NxBaseUser>
                                                    <StartDate>2019-04-20T15:59:01</StartDate>
                                                    <EndDate>2019-04-20T15:59:31</EndDate>
                                                    <CftSearchAuthorityList />
                                                </Attributes>
                                            </CftWorkflowHistory>
                                        </Add>
                                        <Add>
                                            <CftWorkflowHistory>
                                                <Attributes>
                                                    <CftNBRStatus>Pending</CftNBRStatus>
                                                    <CftWorkflowStep>ResultsReviewForDecision</CftWorkflowStep>
                                                    <NxBaseUser>7356c8e1-de08-40ba-a0f1-5a8bc02707af</NxBaseUser>
                                                    <StartDate>2019-04-20T15:59:58</StartDate>
                                                    <EndDate>2019-04-20T16:00:04</EndDate>
                                                    <CftSearchAuthorityList>Decision Maker</CftSearchAuthorityList>
                                                </Attributes>
                                            </CftWorkflowHistory>
                                        </Add>
                                        <Add>
                                            <CftWorkflowHistory>
                                                <Attributes>
                                                    <CftNBRStatus>Approved</CftNBRStatus>
                                                    <CftWorkflowStep>Finalized</CftWorkflowStep>
                                                    <NxBaseUser>7356c8e1-de08-40ba-a0f1-5a8bc02707af</NxBaseUser>
                                                    <StartDate>2019-04-20T16:00:05</StartDate>
                                                    <EndDate>2019-04-20T16:00:06</EndDate>
                                                    <CftSearchAuthorityList />
                                                </Attributes>
                                            </CftWorkflowHistory>
                                        </Add>
                                        <Add>
                                            <CftWorkflowHistory>
                                                <Attributes>
                                                    <CftNBRStatus>Pending</CftNBRStatus>
                                                    <CftWorkflowStep>NBIEntry</CftWorkflowStep>
                                                    <NxBaseUser>f6face3b-fbef-479b-9870-f3349a238066</NxBaseUser>
                                                    <StartDate>2019-04-17T14:22:32</StartDate>
                                                    <EndDate>1900-01-02T00:00:00</EndDate>
                                                    <CftSearchAuthorityList />
                                                </Attributes>
                                            </CftWorkflowHistory>
                                        </Add>
                                        <Add>
                                            <CftWorkflowHistory>
                                                <Attributes>
                                                    <CftNBRStatus>Pending</CftNBRStatus>
                                                    <CftWorkflowStep>SearchResults</CftWorkflowStep>
                                                    <NxBaseUser>7356c8e1-de08-40ba-a0f1-5a8bc02707af</NxBaseUser>
                                                    <StartDate>2019-04-20T15:58:35</StartDate>
                                                    <EndDate>2019-04-20T15:59:01</EndDate>
                                                    <CftSearchAuthorityList />
                                                </Attributes>
                                            </CftWorkflowHistory>
                                        </Add>
                                    </CftWorkflowHistory>
                                    <CftSearchFields>
                                        <Add>
                                            <CftSearchFields>
                                                <Attributes>
                                                    <ArchCode>EntityPerson</ArchCode>
                                                    <AttrCode>GoesBy</AttrCode>
                                                    <IsPhoneticSearch>0</IsPhoneticSearch>
                                                    <CollectionName>3E</CollectionName>
                                                </Attributes>
                                            </CftSearchFields>
                                        </Add>
                                        <Add>
                                            <CftSearchFields>
                                                <Attributes>
                                                    <ArchCode>EntityPerson</ArchCode>
                                                    <AttrCode>DisplayName</AttrCode>
                                                    <IsPhoneticSearch>0</IsPhoneticSearch>
                                                    <CollectionName>3E</CollectionName>
                                                </Attributes>
                                            </CftSearchFields>
                                        </Add>
                                        <Add>
                                            <CftSearchFields>
                                                <Attributes>
                                                    <ArchCode>EntityOrg</ArchCode>
                                                    <AttrCode>DisplayName</AttrCode>
                                                    <IsPhoneticSearch>0</IsPhoneticSearch>
                                                    <CollectionName>3E</CollectionName>
                                                </Attributes>
                                            </CftSearchFields>
                                        </Add>
                                        <Add>
                                            <CftSearchFields>
                                                <Attributes>
                                                    <ArchCode>Client</ArchCode>
                                                    <AttrCode>Number</AttrCode>
                                                    <IsPhoneticSearch>1</IsPhoneticSearch>
                                                    <CollectionName>3E</CollectionName>
                                                </Attributes>
                                            </CftSearchFields>
                                        </Add>
                                        <Add>
                                            <CftSearchFields>
                                                <Attributes>
                                                    <ArchCode>CftRelatedParty</ArchCode>
                                                    <AttrCode>Notes</AttrCode>
                                                    <IsPhoneticSearch>1</IsPhoneticSearch>
                                                    <CollectionName>3E</CollectionName>
                                                </Attributes>
                                            </CftSearchFields>
                                        </Add>
                                        <Add>
                                            <CftSearchFields>
                                                <Attributes>
                                                    <ArchCode>Client</ArchCode>
                                                    <AttrCode>Narrative</AttrCode>
                                                    <IsPhoneticSearch>1</IsPhoneticSearch>
                                                    <CollectionName>3E</CollectionName>
                                                </Attributes>
                                            </CftSearchFields>
                                        </Add>
                                        <Add>
                                            <CftSearchFields>
                                                <Attributes>
                                                    <ArchCode>Client</ArchCode>
                                                    <AttrCode>DisplayName</AttrCode>
                                                    <IsPhoneticSearch>0</IsPhoneticSearch>
                                                    <CollectionName>3E</CollectionName>
                                                </Attributes>
                                            </CftSearchFields>
                                        </Add>
                                        <Add>
                                            <CftSearchFields>
                                                <Attributes>
                                                    <ArchCode>Matter</ArchCode>
                                                    <AttrCode>Description</AttrCode>
                                                    <IsPhoneticSearch>0</IsPhoneticSearch>
                                                    <CollectionName>3E</CollectionName>
                                                </Attributes>
                                            </CftSearchFields>
                                        </Add>
                                        <Add>
                                            <CftSearchFields>
                                                <Attributes>
                                                    <ArchCode>EntityAltName</ArchCode>
                                                    <AttrCode>AltName</AttrCode>
                                                    <IsPhoneticSearch>0</IsPhoneticSearch>
                                                    <CollectionName>3E</CollectionName>
                                                </Attributes>
                                            </CftSearchFields>
                                        </Add>
                                    </CftSearchFields>
                                    <CftSearchAddress_CCC>
                                        <Add>
                                            <CftSearchAddress_CCC>
                                                <Attributes>
                                                    <City>Newnan</City>
                                                    <Country>US</Country>
                                                    <Location>63 Hollis Heights</Location>
                                                    <State>GA</State>
                                                    <Zipcode>30263</Zipcode>
                                                    <ZipCodeLookup />
                                                    <County>NewValue</County>
                                                </Attributes>
                                            </CftSearchAddress_CCC>
                                        </Add>
                                    </CftSearchAddress_CCC>
                                </Children>
                            </CftSearch>
                        </Add>
                        <Edit>
                            <CftSearch KeyValue=""CftSearchKey"">
                                <Attributes>
                                    <Description>S&amp;S Lines &amp; Drains/Simpson Water Supply Line Evaluation</Description>
                                    <NumResults>4</NumResults>
                                    <DateRun>2019-04-20T15:59:32</DateRun>
                                    <Comments>NewValue</Comments>
                                    <IsErrored>1</IsErrored>
                                    <OrigNumResults>4</OrigNumResults>
                                    <NumResultsLiteral>3 of 3</NumResultsLiteral>
                                    <RanBy>7356c8e1-de08-40ba-a0f1-5a8bc02707af</RanBy>
                                    <SimpleSearchTerms>NewValue</SimpleSearchTerms>
                                    <CurrentWorkflowStep>Finalized</CurrentWorkflowStep>
                                    <ContinueWorkflow>1</ContinueWorkflow>
                                    <WorkflowEndReason>1</WorkflowEndReason>
                                    <ElapsedDataTime>2</ElapsedDataTime>
                                    <ElapsedSearchTime>532</ElapsedSearchTime>
                                    <FinalDecision>Approved</FinalDecision>
                                    <IsRouted>0</IsRouted>
                                    <DCSReportID>NewValue</DCSReportID>
                                    <DecisionBy>7356c8e1-de08-40ba-a0f1-5a8bc02707af</DecisionBy>
                                    <DateRouted>2019-04-20T00:00:00</DateRouted>
                                    <DateDecided>2019-04-20T00:00:00</DateDecided>
                                    <IsSelectedResults>1</IsSelectedResults>
                                    <isFiltersPopulated>1</isFiltersPopulated>
                                    <ParentId>NewValue</ParentId>
                                    <CftAuthority />
                                    <IsAccessToRoutedResults>1</IsAccessToRoutedResults>
                                    <CftSearchTypeList>Conflicts Search</CftSearchTypeList>
                                    <IsPhoneticSearch>1</IsPhoneticSearch>
                                    <NxBaseUser>653df626-eb1d-46ee-b8de-5f677e6432e4</NxBaseUser>
                                    <CftSearchAuthorityList>Decision Maker</CftSearchAuthorityList>
                                    <CftSearchResultsViewList>Detail</CftSearchResultsViewList>
                                    <StepDate>2019-04-20T16:00:05</StepDate>
                                    <EstimatedNumResults>1</EstimatedNumResults>
                                    <IsProspectiveUnfiltered>1</IsProspectiveUnfiltered>
                                    <CopyDescription>NewValue</CopyDescription>
                                    <CopySavedDate>1900-01-02T00:00:00</CopySavedDate>
                                    <CopySavedBy />
                                    <IsReadOnlyAccess>1</IsReadOnlyAccess>
                                    <LblDecisionReview2>NewValue</LblDecisionReview2>
                                    <CurrentOwner>b7e5705f-bb7a-4727-8c70-4bce9b4a5e4b</CurrentOwner>
                                    <DisplayCurrentOwner>b7e5705f-bb7a-4727-8c70-4bce9b4a5e4b</DisplayCurrentOwner>
                                    <IsAllowReRouteAll>0</IsAllowReRouteAll>
                                    <IsRouteAllReleaseReciepient>1</IsRouteAllReleaseReciepient>
                                    <IsSearchReexecuted>1</IsSearchReexecuted>
                                    <IsUnboundDataPopulated>1</IsUnboundDataPopulated>
                                    <IsSearchForViewOnly>1</IsSearchForViewOnly>
                                    <IsRouteSelected>1</IsRouteSelected>
                                    <MaxProcessedPageNumber>2</MaxProcessedPageNumber>
                                    <IsViewAllPages>1</IsViewAllPages>
                                    <RoutingBGStatus>NewValue</RoutingBGStatus>
                                    <IsRoutingBG>1</IsRoutingBG>
                                    <IsProcessAllPages>1</IsProcessAllPages>
                                    <UseHighlighting>0</UseHighlighting>
                                    <UseEquivalency>0</UseEquivalency>
                                </Attributes>
                                <Children>
                                    <CftSearchTerm>
                                        <Add>
                                            <CftSearchTerm>
                                                <Attributes>
                                                    <SearchTerm>NewValue</SearchTerm>
                                                    <NumResults>2</NumResults>
                                                    <Name>S&amp;S Lines &amp; Drains</Name>
                                                    <IsErrored>1</IsErrored>
                                                    <CftRelationshipCode />
                                                    <SortOrder>2</SortOrder>
                                                    <OrigNumResults>2</OrigNumResults>
                                                    <NumResultsLiteral>1 of 1</NumResultsLiteral>
                                                    <CftRole />
                                                    <RiskImage />
                                                    <FullTextSearchRequestID>db8de0e1-0be4-4451-a3ec-b5c6ad7bb859</FullTextSearchRequestID>
                                                    <ElapsedTotalTime>298</ElapsedTotalTime>
                                                    <ElapsedResultTime>17</ElapsedResultTime>
                                                    <DateRun>2019-04-20T15:59:32</DateRun>
                                                    <IsPhoneticSearch>1</IsPhoneticSearch>
                                                    <CftNewBizSearchName>87bc4f6b-5a69-48e9-af9e-a1bd4eb77712</CftNewBizSearchName>
                                                    <IsNotSearch>1</IsNotSearch>
                                                    <IsNotCreateLink>0</IsNotCreateLink>
                                                    <OrigSearchTerm>NewValue</OrigSearchTerm>
                                                    <SearchTerms>(S&amp;S &amp; Drains) OR (2019-04-10) OR (Hollis &amp; Heights &amp; Newnan)</SearchTerms>
                                                    <EstimatedResultCount>2</EstimatedResultCount>
                                                </Attributes>
                                            </CftSearchTerm>
                                        </Add>
                                        <Edit>
                                            <CftSearchTerm KeyValue=""CftSearchTermKey"">
                                                <Attributes>
                                                    <SearchTerm>NewValue</SearchTerm>
                                                    <NumResults>2</NumResults>
                                                    <Name>S&amp;S Lines &amp; Drains</Name>
                                                    <IsErrored>1</IsErrored>
                                                    <CftRelationshipCode />
                                                    <SortOrder>2</SortOrder>
                                                    <OrigNumResults>2</OrigNumResults>
                                                    <NumResultsLiteral>1 of 1</NumResultsLiteral>
                                                    <CftRole />
                                                    <RiskImage />
                                                    <FullTextSearchRequestID>db8de0e1-0be4-4451-a3ec-b5c6ad7bb859</FullTextSearchRequestID>
                                                    <ElapsedTotalTime>298</ElapsedTotalTime>
                                                    <ElapsedResultTime>17</ElapsedResultTime>
                                                    <DateRun>2019-04-20T15:59:32</DateRun>
                                                    <IsPhoneticSearch>1</IsPhoneticSearch>
                                                    <CftNewBizSearchName>87bc4f6b-5a69-48e9-af9e-a1bd4eb77712</CftNewBizSearchName>
                                                    <IsNotSearch>1</IsNotSearch>
                                                    <IsNotCreateLink>0</IsNotCreateLink>
                                                    <OrigSearchTerm>NewValue</OrigSearchTerm>
                                                    <SearchTerms>(S&amp;S &amp; Drains) OR (2019-04-10) OR (Hollis &amp; Heights &amp; Newnan)</SearchTerms>
                                                    <EstimatedResultCount>2</EstimatedResultCount>
                                                </Attributes>
                                            </CftSearchTerm>
                                        </Edit>
                                        <Add>
                                            <CftSearchTerm>
                                                <Attributes>
                                                    <SearchTerm>NewValue</SearchTerm>
                                                    <NumResults>3</NumResults>
                                                    <Name>Brenda Simpson</Name>
                                                    <IsErrored>1</IsErrored>
                                                    <CftRelationshipCode />
                                                    <SortOrder>1</SortOrder>
                                                    <OrigNumResults>3</OrigNumResults>
                                                    <NumResultsLiteral>2 of 2</NumResultsLiteral>
                                                    <CftRole />
                                                    <RiskImage />
                                                    <FullTextSearchRequestID>6023bee9-e130-48f9-994c-9ee4ae62ee7b</FullTextSearchRequestID>
                                                    <ElapsedTotalTime>392</ElapsedTotalTime>
                                                    <ElapsedResultTime>79</ElapsedResultTime>
                                                    <DateRun>2019-04-20T15:59:32</DateRun>
                                                    <IsPhoneticSearch>1</IsPhoneticSearch>
                                                    <CftNewBizSearchName>460cf8b8-f377-4543-89c1-be075418e7d9</CftNewBizSearchName>
                                                    <IsNotSearch>1</IsNotSearch>
                                                    <IsNotCreateLink>0</IsNotCreateLink>
                                                    <OrigSearchTerm>NewValue</OrigSearchTerm>
                                                    <SearchTerms>(Brenda &amp; Simpson)</SearchTerms>
                                                    <EstimatedResultCount>2</EstimatedResultCount>
                                                </Attributes>
                                            </CftSearchTerm>
                                        </Add>
                                        <Edit>
                                            <CftSearchTerm KeyValue=""CftSearchTermKey"">
                                                <Attributes>
                                                    <SearchTerm>NewValue</SearchTerm>
                                                    <NumResults>3</NumResults>
                                                    <Name>Brenda Simpson</Name>
                                                    <IsErrored>1</IsErrored>
                                                    <CftRelationshipCode />
                                                    <SortOrder>1</SortOrder>
                                                    <OrigNumResults>3</OrigNumResults>
                                                    <NumResultsLiteral>2 of 2</NumResultsLiteral>
                                                    <CftRole />
                                                    <RiskImage />
                                                    <FullTextSearchRequestID>6023bee9-e130-48f9-994c-9ee4ae62ee7b</FullTextSearchRequestID>
                                                    <ElapsedTotalTime>392</ElapsedTotalTime>
                                                    <ElapsedResultTime>79</ElapsedResultTime>
                                                    <DateRun>2019-04-20T15:59:32</DateRun>
                                                    <IsPhoneticSearch>1</IsPhoneticSearch>
                                                    <CftNewBizSearchName>460cf8b8-f377-4543-89c1-be075418e7d9</CftNewBizSearchName>
                                                    <IsNotSearch>1</IsNotSearch>
                                                    <IsNotCreateLink>0</IsNotCreateLink>
                                                    <OrigSearchTerm>NewValue</OrigSearchTerm>
                                                    <SearchTerms>(Brenda &amp; Simpson)</SearchTerms>
                                                    <EstimatedResultCount>2</EstimatedResultCount>
                                                </Attributes>
                                            </CftSearchTerm>
                                        </Edit>
                                    </CftSearchTerm>
                                    <CftSearchResult>
                                        <Add>
                                            <CftSearchResultRPOrg>
                                                <Attributes>
                                                    <SearchTermGroupingLabel>000002 - S&amp;S Lines &amp; Drains - Searched without Role</SearchTermGroupingLabel>
                                                    <Name>NewValue</Name>
                                                    <Text>[H]S[/H]&amp;[H]S[/H] Lines &amp; [H]Drains[/H]</Text>
                                                    <ProviderCode>FrameworkDataProvider</ProviderCode>
                                                    <FullTextDocumentID>5038f6e2-db84-4734-be2a-7d746fb135c2</FullTextDocumentID>
                                                    <HitCount>1</HitCount>
                                                    <TextLanguage>1</TextLanguage>
                                                    <DataItemID>ed3a4ff3-b1ae-4bac-b882-382c82537ba7</DataItemID>
                                                    <ArchCode>CftRelatedParty</ArchCode>
                                                    <AttrCode>DisplayName</AttrCode>
                                                    <IsExcluded>1</IsExcluded>
                                                    <PartialText>[H]S[/H]&amp;[H]S[/H] Lines &amp; [H]Drains[/H]</PartialText>
                                                    <WhereFoundSortOrder>4</WhereFoundSortOrder>
                                                    <StatusSortString>NewValue</StatusSortString>
                                                    <WhereFoundArchCode>CftRelatedParty</WhereFoundArchCode>
                                                    <WhereFoundAttrCode>DisplayName</WhereFoundAttrCode>
                                                    <WhereFoundArchCaption>RelatedParty</WhereFoundArchCaption>
                                                    <WhereFoundAttrCaption>Entity Name</WhereFoundAttrCaption>
                                                    <WhereFound>RelatedParty.Entity Name</WhereFound>
                                                    <WhereFoundItemID>8685055e-0070-47c1-a756-0ff8a2315445</WhereFoundItemID>
                                                    <CftSearchTerm>9a809490-abbe-4e9e-b7c9-8d9793f988a7</CftSearchTerm>
                                                    <RiskImage>3</RiskImage>
                                                    <SearchTermSortOrder>2</SearchTermSortOrder>
                                                    <DebugInfo>NewValue</DebugInfo>
                                                    <DetailItemID>8685055e-0070-47c1-a756-0ff8a2315445</DetailItemID>
                                                    <DetailArchCode>CftRelatedParty</DetailArchCode>
                                                    <OpenMatters>1</OpenMatters>
                                                    <ClosedMatters>1</ClosedMatters>
                                                    <OpCLMatters>NewValue</OpCLMatters>
                                                    <WhereFoundFrameworkItemID>8685055e-0070-47c1-a756-0ff8a2315445</WhereFoundFrameworkItemID>
                                                    <RiskflagText>NewValue</RiskflagText>
                                                    <IsSelected>1</IsSelected>
                                                    <Assessment>NewValue</Assessment>
                                                    <Routed>NewValue</Routed>
                                                    <IsFiltered>1</IsFiltered>
                                                    <CorporateTreeImage />
                                                    <SearchNo>2</SearchNo>
                                                    <ClientName>NewValue</ClientName>
                                                    <MatterName>NewValue</MatterName>
                                                    <Role>Insured</Role>
                                                    <Relationship>NewValue</Relationship>
                                                    <ConflictsContact>NewValue</ConflictsContact>
                                                    <CftEntityOrMatterIndex>1</CftEntityOrMatterIndex>
                                                    <EthicalWallImage />
                                                    <CftClientIndex>63528</CftClientIndex>
                                                    <EntitySanctionLoad />
                                                    <IsMattercentricHit>1</IsMattercentricHit>
                                                    <DisplayNumber>NewValue</DisplayNumber>
                                                    <IsRouteSelected>1</IsRouteSelected>
                                                    <EntityIndex>578937</EntityIndex>
                                                    <MatterIndex>417523</MatterIndex>
                                                    <DisplayText>NewValue</DisplayText>
                                                    <DisplayPartialText>NewValue</DisplayPartialText>
                                                    <DisplayClientName>NewValue</DisplayClientName>
                                                    <DisplayMatterName>NewValue</DisplayMatterName>
                                                    <DisplayNum>NewValue</DisplayNum>
                                                    <IsFilterAppliedToDetail>1</IsFilterAppliedToDetail>
                                                    <TimekeeperContact />
                                                    <NxUserContact />
                                                    <DisplayOpenMattersCount>2</DisplayOpenMattersCount>
                                                    <DisplayClosedMattersCount>2</DisplayClosedMattersCount>
                                                    <DisplayEthicalWallImage />
                                                    <DisplayCorporateTreeImage />
                                                    <DisplayConflictsContact>NewValue</DisplayConflictsContact>
                                                    <IsResultSelected>1</IsResultSelected>
                                                    <CftRoleCode />
                                                    <ThresholdIndicator> </ThresholdIndicator>
                                                    <IsSearchHasFilter>1</IsSearchHasFilter>
                                                    <IsForceRetrieveDetails>1</IsForceRetrieveDetails>
                                                    <ResultsDifferenceImage />
                                                    <CftSearchCompareStatus />
                                                    <IsResultModified>0</IsResultModified>
                                                    <SourceCollection>3E</SourceCollection>
                                                    <IsExternalHit>1</IsExternalHit>
                                                    <FTXSourceType>3EDatabase</FTXSourceType>
                                                    <PageNumber>0</PageNumber>
                                                    <IsViewDifference>1</IsViewDifference>
                                                    <CftFullTextResults>e99ca9ad-e471-4116-aaa4-60ead13fd7f3</CftFullTextResults>
                                                    <LocationOfOccurenceTxt_CCC>NewValue</LocationOfOccurenceTxt_CCC>
                                                    <DateOfOccurenceTxt_CCC>NewValue</DateOfOccurenceTxt_CCC>
                                                    <RelatedPartyID>8685055e-0070-47c1-a756-0ff8a2315445</RelatedPartyID>
                                                    <EntIndex>2</EntIndex>
                                                    <MattIndex>2</MattIndex>
                                                    <Notes>NewValue</Notes>
                                                    <EntityID>NewValue</EntityID>
                                                    <MatterID>NewValue</MatterID>
                                                    <LinkType>NewValue</LinkType>
                                                    <LinkStatus>NewValue</LinkStatus>
                                                    <ClientNumber>NewValue</ClientNumber>
                                                    <MatterNumber>NewValue</MatterNumber>
                                                    <RPClientName>NewValue</RPClientName>
                                                    <RPMatterName>NewValue</RPMatterName>
                                                    <ClientStatus>NewValue</ClientStatus>
                                                    <MatterStatus>NewValue</MatterStatus>
                                                    <CftRelatedParty />
                                                    <IsProspectiveRPItem>1</IsProspectiveRPItem>
                                                    <ClientOpenDate>1900-01-02T00:00:00</ClientOpenDate>
                                                    <ClientCloseDate>1900-01-02T00:00:00</ClientCloseDate>
                                                    <IsCreatedParty>1</IsCreatedParty>
                                                </Attributes>
                                            </CftSearchResultRPOrg>
                                        </Add>
                                        <Edit>
                                            <CftSearchResultRPOrg KeyValue=""CftSearchResultRPOrgKey"">
                                                <Attributes>
                                                    <SearchTermGroupingLabel>000002 - S&amp;S Lines &amp; Drains - Searched without Role</SearchTermGroupingLabel>
                                                    <Name>NewValue</Name>
                                                    <Text>[H]S[/H]&amp;[H]S[/H] Lines &amp; [H]Drains[/H]</Text>
                                                    <ProviderCode>FrameworkDataProvider</ProviderCode>
                                                    <FullTextDocumentID>5038f6e2-db84-4734-be2a-7d746fb135c2</FullTextDocumentID>
                                                    <HitCount>1</HitCount>
                                                    <TextLanguage>1</TextLanguage>
                                                    <DataItemID>ed3a4ff3-b1ae-4bac-b882-382c82537ba7</DataItemID>
                                                    <ArchCode>CftRelatedParty</ArchCode>
                                                    <AttrCode>DisplayName</AttrCode>
                                                    <IsExcluded>1</IsExcluded>
                                                    <PartialText>[H]S[/H]&amp;[H]S[/H] Lines &amp; [H]Drains[/H]</PartialText>
                                                    <WhereFoundSortOrder>4</WhereFoundSortOrder>
                                                    <StatusSortString>NewValue</StatusSortString>
                                                    <WhereFoundArchCode>CftRelatedParty</WhereFoundArchCode>
                                                    <WhereFoundAttrCode>DisplayName</WhereFoundAttrCode>
                                                    <WhereFoundArchCaption>RelatedParty</WhereFoundArchCaption>
                                                    <WhereFoundAttrCaption>Entity Name</WhereFoundAttrCaption>
                                                    <WhereFound>RelatedParty.Entity Name</WhereFound>
                                                    <WhereFoundItemID>8685055e-0070-47c1-a756-0ff8a2315445</WhereFoundItemID>
                                                    <CftSearchTerm>9a809490-abbe-4e9e-b7c9-8d9793f988a7</CftSearchTerm>
                                                    <RiskImage>3</RiskImage>
                                                    <SearchTermSortOrder>2</SearchTermSortOrder>
                                                    <DebugInfo>NewValue</DebugInfo>
                                                    <DetailItemID>8685055e-0070-47c1-a756-0ff8a2315445</DetailItemID>
                                                    <DetailArchCode>CftRelatedParty</DetailArchCode>
                                                    <OpenMatters>1</OpenMatters>
                                                    <ClosedMatters>1</ClosedMatters>
                                                    <OpCLMatters>NewValue</OpCLMatters>
                                                    <WhereFoundFrameworkItemID>8685055e-0070-47c1-a756-0ff8a2315445</WhereFoundFrameworkItemID>
                                                    <RiskflagText>NewValue</RiskflagText>
                                                    <IsSelected>1</IsSelected>
                                                    <Assessment>NewValue</Assessment>
                                                    <Routed>NewValue</Routed>
                                                    <IsFiltered>1</IsFiltered>
                                                    <CorporateTreeImage />
                                                    <SearchNo>2</SearchNo>
                                                    <ClientName>NewValue</ClientName>
                                                    <MatterName>NewValue</MatterName>
                                                    <Role>Insured</Role>
                                                    <Relationship>NewValue</Relationship>
                                                    <ConflictsContact>NewValue</ConflictsContact>
                                                    <CftEntityOrMatterIndex>1</CftEntityOrMatterIndex>
                                                    <EthicalWallImage />
                                                    <CftClientIndex>63528</CftClientIndex>
                                                    <EntitySanctionLoad />
                                                    <IsMattercentricHit>1</IsMattercentricHit>
                                                    <DisplayNumber>NewValue</DisplayNumber>
                                                    <IsRouteSelected>1</IsRouteSelected>
                                                    <EntityIndex>578937</EntityIndex>
                                                    <MatterIndex>417523</MatterIndex>
                                                    <DisplayText>NewValue</DisplayText>
                                                    <DisplayPartialText>NewValue</DisplayPartialText>
                                                    <DisplayClientName>NewValue</DisplayClientName>
                                                    <DisplayMatterName>NewValue</DisplayMatterName>
                                                    <DisplayNum>NewValue</DisplayNum>
                                                    <IsFilterAppliedToDetail>1</IsFilterAppliedToDetail>
                                                    <TimekeeperContact />
                                                    <NxUserContact />
                                                    <DisplayOpenMattersCount>2</DisplayOpenMattersCount>
                                                    <DisplayClosedMattersCount>2</DisplayClosedMattersCount>
                                                    <DisplayEthicalWallImage />
                                                    <DisplayCorporateTreeImage />
                                                    <DisplayConflictsContact>NewValue</DisplayConflictsContact>
                                                    <IsResultSelected>1</IsResultSelected>
                                                    <CftRoleCode />
                                                    <ThresholdIndicator> </ThresholdIndicator>
                                                    <IsSearchHasFilter>1</IsSearchHasFilter>
                                                    <IsForceRetrieveDetails>1</IsForceRetrieveDetails>
                                                    <ResultsDifferenceImage />
                                                    <CftSearchCompareStatus />
                                                    <IsResultModified>0</IsResultModified>
                                                    <SourceCollection>3E</SourceCollection>
                                                    <IsExternalHit>1</IsExternalHit>
                                                    <FTXSourceType>3EDatabase</FTXSourceType>
                                                    <PageNumber>0</PageNumber>
                                                    <IsViewDifference>1</IsViewDifference>
                                                    <CftFullTextResults>e99ca9ad-e471-4116-aaa4-60ead13fd7f3</CftFullTextResults>
                                                    <LocationOfOccurenceTxt_CCC>NewValue</LocationOfOccurenceTxt_CCC>
                                                    <DateOfOccurenceTxt_CCC>NewValue</DateOfOccurenceTxt_CCC>
                                                    <RelatedPartyID>8685055e-0070-47c1-a756-0ff8a2315445</RelatedPartyID>
                                                    <EntIndex>2</EntIndex>
                                                    <MattIndex>2</MattIndex>
                                                    <Notes>NewValue</Notes>
                                                    <EntityID>NewValue</EntityID>
                                                    <MatterID>NewValue</MatterID>
                                                    <LinkType>NewValue</LinkType>
                                                    <LinkStatus>NewValue</LinkStatus>
                                                    <ClientNumber>NewValue</ClientNumber>
                                                    <MatterNumber>NewValue</MatterNumber>
                                                    <RPClientName>NewValue</RPClientName>
                                                    <RPMatterName>NewValue</RPMatterName>
                                                    <ClientStatus>NewValue</ClientStatus>
                                                    <MatterStatus>NewValue</MatterStatus>
                                                    <CftRelatedParty />
                                                    <IsProspectiveRPItem>1</IsProspectiveRPItem>
                                                    <ClientOpenDate>1900-01-02T00:00:00</ClientOpenDate>
                                                    <ClientCloseDate>1900-01-02T00:00:00</ClientCloseDate>
                                                    <IsCreatedParty>1</IsCreatedParty>
                                                </Attributes>
                                            </CftSearchResultRPOrg>
                                        </Edit>
                                        <Add>
                                            <CftSearchResultRPPerson>
                                                <Attributes>
                                                    <SearchTermGroupingLabel>000001 - Brenda Simpson - Searched without Role</SearchTermGroupingLabel>
                                                    <Name>NewValue</Name>
                                                    <Text>[H]Brenda[/H] [H]Simpson[/H]</Text>
                                                    <ProviderCode>FrameworkDataProvider</ProviderCode>
                                                    <FullTextDocumentID>a8d65561-d6a2-4ee5-a088-e3e33070e1e7</FullTextDocumentID>
                                                    <HitCount>1</HitCount>
                                                    <TextLanguage>1</TextLanguage>
                                                    <DataItemID>0e0d9a27-6aa1-4304-a635-f8945030f6e5</DataItemID>
                                                    <ArchCode>CftRelatedParty</ArchCode>
                                                    <AttrCode>DisplayName</AttrCode>
                                                    <IsExcluded>1</IsExcluded>
                                                    <PartialText>[H]Brenda[/H] [H]Simpson[/H]</PartialText>
                                                    <WhereFoundSortOrder>4</WhereFoundSortOrder>
                                                    <StatusSortString>NewValue</StatusSortString>
                                                    <WhereFoundArchCode>CftRelatedParty</WhereFoundArchCode>
                                                    <WhereFoundAttrCode>DisplayName</WhereFoundAttrCode>
                                                    <WhereFoundArchCaption>RelatedParty</WhereFoundArchCaption>
                                                    <WhereFoundAttrCaption>Entity Name</WhereFoundAttrCaption>
                                                    <WhereFound>RelatedParty.Entity Name</WhereFound>
                                                    <WhereFoundItemID>dbfbf6e4-b7e4-42c7-9f9e-73b33f21c836</WhereFoundItemID>
                                                    <CftSearchTerm>2b715017-1e67-4837-b185-c7d5c40cc4b0</CftSearchTerm>
                                                    <RiskImage>3</RiskImage>
                                                    <SearchTermSortOrder>1</SearchTermSortOrder>
                                                    <DebugInfo>NewValue</DebugInfo>
                                                    <DetailItemID>dbfbf6e4-b7e4-42c7-9f9e-73b33f21c836</DetailItemID>
                                                    <DetailArchCode>CftRelatedParty</DetailArchCode>
                                                    <OpenMatters>1</OpenMatters>
                                                    <ClosedMatters>2</ClosedMatters>
                                                    <OpCLMatters>NewValue</OpCLMatters>
                                                    <WhereFoundFrameworkItemID>dbfbf6e4-b7e4-42c7-9f9e-73b33f21c836</WhereFoundFrameworkItemID>
                                                    <RiskflagText>NewValue</RiskflagText>
                                                    <IsSelected>1</IsSelected>
                                                    <Assessment>NewValue</Assessment>
                                                    <Routed>NewValue</Routed>
                                                    <IsFiltered>1</IsFiltered>
                                                    <CorporateTreeImage />
                                                    <SearchNo>2</SearchNo>
                                                    <ClientName>NewValue</ClientName>
                                                    <MatterName>NewValue</MatterName>
                                                    <Role>Insured</Role>
                                                    <Relationship>NewValue</Relationship>
                                                    <ConflictsContact>NewValue</ConflictsContact>
                                                    <CftEntityOrMatterIndex>1</CftEntityOrMatterIndex>
                                                    <EthicalWallImage />
                                                    <CftClientIndex>53314</CftClientIndex>
                                                    <EntitySanctionLoad />
                                                    <IsMattercentricHit>1</IsMattercentricHit>
                                                    <DisplayNumber>NewValue</DisplayNumber>
                                                    <IsRouteSelected>1</IsRouteSelected>
                                                    <EntityIndex>498891</EntityIndex>
                                                    <MatterIndex>270744</MatterIndex>
                                                    <DisplayText>NewValue</DisplayText>
                                                    <DisplayPartialText>NewValue</DisplayPartialText>
                                                    <DisplayClientName>NewValue</DisplayClientName>
                                                    <DisplayMatterName>NewValue</DisplayMatterName>
                                                    <DisplayNum>NewValue</DisplayNum>
                                                    <IsFilterAppliedToDetail>1</IsFilterAppliedToDetail>
                                                    <TimekeeperContact />
                                                    <NxUserContact />
                                                    <DisplayOpenMattersCount>2</DisplayOpenMattersCount>
                                                    <DisplayClosedMattersCount>2</DisplayClosedMattersCount>
                                                    <DisplayEthicalWallImage />
                                                    <DisplayCorporateTreeImage />
                                                    <DisplayConflictsContact>NewValue</DisplayConflictsContact>
                                                    <IsResultSelected>1</IsResultSelected>
                                                    <CftRoleCode />
                                                    <ThresholdIndicator> </ThresholdIndicator>
                                                    <IsSearchHasFilter>1</IsSearchHasFilter>
                                                    <IsForceRetrieveDetails>1</IsForceRetrieveDetails>
                                                    <ResultsDifferenceImage />
                                                    <CftSearchCompareStatus />
                                                    <IsResultModified>0</IsResultModified>
                                                    <SourceCollection>3E</SourceCollection>
                                                    <IsExternalHit>1</IsExternalHit>
                                                    <FTXSourceType>3EDatabase</FTXSourceType>
                                                    <PageNumber>0</PageNumber>
                                                    <IsViewDifference>1</IsViewDifference>
                                                    <CftFullTextResults>10e66554-9c43-40a4-8e9a-690ce6dd83bd</CftFullTextResults>
                                                    <LocationOfOccurenceTxt_CCC>NewValue</LocationOfOccurenceTxt_CCC>
                                                    <DateOfOccurenceTxt_CCC>NewValue</DateOfOccurenceTxt_CCC>
                                                    <RelatedPartyID>dbfbf6e4-b7e4-42c7-9f9e-73b33f21c836</RelatedPartyID>
                                                    <EntIndex>2</EntIndex>
                                                    <MattIndex>2</MattIndex>
                                                    <Notes>NewValue</Notes>
                                                    <EntityID>NewValue</EntityID>
                                                    <MatterID>NewValue</MatterID>
                                                    <LinkType>NewValue</LinkType>
                                                    <LinkStatus>NewValue</LinkStatus>
                                                    <ClientNumber>NewValue</ClientNumber>
                                                    <MatterNumber>NewValue</MatterNumber>
                                                    <RPClientName>NewValue</RPClientName>
                                                    <RPMatterName>NewValue</RPMatterName>
                                                    <ClientStatus>NewValue</ClientStatus>
                                                    <MatterStatus>NewValue</MatterStatus>
                                                    <CftRelatedParty />
                                                    <IsProspectiveRPItem>1</IsProspectiveRPItem>
                                                    <ClientOpenDate>1900-01-02T00:00:00</ClientOpenDate>
                                                    <ClientCloseDate>1900-01-02T00:00:00</ClientCloseDate>
                                                    <IsCreatedParty>1</IsCreatedParty>
                                                </Attributes>
                                            </CftSearchResultRPPerson>
                                        </Add>
                                        <Edit>
                                            <CftSearchResultRPPerson KeyValue=""CftSearchResultRPPersonKey"">
                                                <Attributes>
                                                    <SearchTermGroupingLabel>000001 - Brenda Simpson - Searched without Role</SearchTermGroupingLabel>
                                                    <Name>NewValue</Name>
                                                    <Text>[H]Brenda[/H] [H]Simpson[/H]</Text>
                                                    <ProviderCode>FrameworkDataProvider</ProviderCode>
                                                    <FullTextDocumentID>a8d65561-d6a2-4ee5-a088-e3e33070e1e7</FullTextDocumentID>
                                                    <HitCount>1</HitCount>
                                                    <TextLanguage>1</TextLanguage>
                                                    <DataItemID>0e0d9a27-6aa1-4304-a635-f8945030f6e5</DataItemID>
                                                    <ArchCode>CftRelatedParty</ArchCode>
                                                    <AttrCode>DisplayName</AttrCode>
                                                    <IsExcluded>1</IsExcluded>
                                                    <PartialText>[H]Brenda[/H] [H]Simpson[/H]</PartialText>
                                                    <WhereFoundSortOrder>4</WhereFoundSortOrder>
                                                    <StatusSortString>NewValue</StatusSortString>
                                                    <WhereFoundArchCode>CftRelatedParty</WhereFoundArchCode>
                                                    <WhereFoundAttrCode>DisplayName</WhereFoundAttrCode>
                                                    <WhereFoundArchCaption>RelatedParty</WhereFoundArchCaption>
                                                    <WhereFoundAttrCaption>Entity Name</WhereFoundAttrCaption>
                                                    <WhereFound>RelatedParty.Entity Name</WhereFound>
                                                    <WhereFoundItemID>dbfbf6e4-b7e4-42c7-9f9e-73b33f21c836</WhereFoundItemID>
                                                    <CftSearchTerm>2b715017-1e67-4837-b185-c7d5c40cc4b0</CftSearchTerm>
                                                    <RiskImage>3</RiskImage>
                                                    <SearchTermSortOrder>1</SearchTermSortOrder>
                                                    <DebugInfo>NewValue</DebugInfo>
                                                    <DetailItemID>dbfbf6e4-b7e4-42c7-9f9e-73b33f21c836</DetailItemID>
                                                    <DetailArchCode>CftRelatedParty</DetailArchCode>
                                                    <OpenMatters>1</OpenMatters>
                                                    <ClosedMatters>2</ClosedMatters>
                                                    <OpCLMatters>NewValue</OpCLMatters>
                                                    <WhereFoundFrameworkItemID>dbfbf6e4-b7e4-42c7-9f9e-73b33f21c836</WhereFoundFrameworkItemID>
                                                    <RiskflagText>NewValue</RiskflagText>
                                                    <IsSelected>1</IsSelected>
                                                    <Assessment>NewValue</Assessment>
                                                    <Routed>NewValue</Routed>
                                                    <IsFiltered>1</IsFiltered>
                                                    <CorporateTreeImage />
                                                    <SearchNo>2</SearchNo>
                                                    <ClientName>NewValue</ClientName>
                                                    <MatterName>NewValue</MatterName>
                                                    <Role>Insured</Role>
                                                    <Relationship>NewValue</Relationship>
                                                    <ConflictsContact>NewValue</ConflictsContact>
                                                    <CftEntityOrMatterIndex>1</CftEntityOrMatterIndex>
                                                    <EthicalWallImage />
                                                    <CftClientIndex>53314</CftClientIndex>
                                                    <EntitySanctionLoad />
                                                    <IsMattercentricHit>1</IsMattercentricHit>
                                                    <DisplayNumber>NewValue</DisplayNumber>
                                                    <IsRouteSelected>1</IsRouteSelected>
                                                    <EntityIndex>498891</EntityIndex>
                                                    <MatterIndex>270744</MatterIndex>
                                                    <DisplayText>NewValue</DisplayText>
                                                    <DisplayPartialText>NewValue</DisplayPartialText>
                                                    <DisplayClientName>NewValue</DisplayClientName>
                                                    <DisplayMatterName>NewValue</DisplayMatterName>
                                                    <DisplayNum>NewValue</DisplayNum>
                                                    <IsFilterAppliedToDetail>1</IsFilterAppliedToDetail>
                                                    <TimekeeperContact />
                                                    <NxUserContact />
                                                    <DisplayOpenMattersCount>2</DisplayOpenMattersCount>
                                                    <DisplayClosedMattersCount>2</DisplayClosedMattersCount>
                                                    <DisplayEthicalWallImage />
                                                    <DisplayCorporateTreeImage />
                                                    <DisplayConflictsContact>NewValue</DisplayConflictsContact>
                                                    <IsResultSelected>1</IsResultSelected>
                                                    <CftRoleCode />
                                                    <ThresholdIndicator> </ThresholdIndicator>
                                                    <IsSearchHasFilter>1</IsSearchHasFilter>
                                                    <IsForceRetrieveDetails>1</IsForceRetrieveDetails>
                                                    <ResultsDifferenceImage />
                                                    <CftSearchCompareStatus />
                                                    <IsResultModified>0</IsResultModified>
                                                    <SourceCollection>3E</SourceCollection>
                                                    <IsExternalHit>1</IsExternalHit>
                                                    <FTXSourceType>3EDatabase</FTXSourceType>
                                                    <PageNumber>0</PageNumber>
                                                    <IsViewDifference>1</IsViewDifference>
                                                    <CftFullTextResults>10e66554-9c43-40a4-8e9a-690ce6dd83bd</CftFullTextResults>
                                                    <LocationOfOccurenceTxt_CCC>NewValue</LocationOfOccurenceTxt_CCC>
                                                    <DateOfOccurenceTxt_CCC>NewValue</DateOfOccurenceTxt_CCC>
                                                    <RelatedPartyID>dbfbf6e4-b7e4-42c7-9f9e-73b33f21c836</RelatedPartyID>
                                                    <EntIndex>2</EntIndex>
                                                    <MattIndex>2</MattIndex>
                                                    <Notes>NewValue</Notes>
                                                    <EntityID>NewValue</EntityID>
                                                    <MatterID>NewValue</MatterID>
                                                    <LinkType>NewValue</LinkType>
                                                    <LinkStatus>NewValue</LinkStatus>
                                                    <ClientNumber>NewValue</ClientNumber>
                                                    <MatterNumber>NewValue</MatterNumber>
                                                    <RPClientName>NewValue</RPClientName>
                                                    <RPMatterName>NewValue</RPMatterName>
                                                    <ClientStatus>NewValue</ClientStatus>
                                                    <MatterStatus>NewValue</MatterStatus>
                                                    <CftRelatedParty />
                                                    <IsProspectiveRPItem>1</IsProspectiveRPItem>
                                                    <ClientOpenDate>1900-01-02T00:00:00</ClientOpenDate>
                                                    <ClientCloseDate>1900-01-02T00:00:00</ClientCloseDate>
                                                    <IsCreatedParty>1</IsCreatedParty>
                                                </Attributes>
                                            </CftSearchResultRPPerson>
                                        </Edit>
                                        <Add>
                                            <CftSearchResultRPPerson>
                                                <Attributes>
                                                    <SearchTermGroupingLabel>000001 - Brenda Simpson - Searched without Role</SearchTermGroupingLabel>
                                                    <Name>NewValue</Name>
                                                    <Text>[H]Brenda[/H] [H]Simpson[/H]</Text>
                                                    <ProviderCode>FrameworkDataProvider</ProviderCode>
                                                    <FullTextDocumentID>aa3d9f57-8eb5-4f0c-af9a-a089ae900e87</FullTextDocumentID>
                                                    <HitCount>1</HitCount>
                                                    <TextLanguage>1</TextLanguage>
                                                    <DataItemID>70ae5c0c-8d0d-4c0e-9526-9235b5be29b5</DataItemID>
                                                    <ArchCode>CftRelatedParty</ArchCode>
                                                    <AttrCode>DisplayName</AttrCode>
                                                    <IsExcluded>1</IsExcluded>
                                                    <PartialText>[H]Brenda[/H] [H]Simpson[/H]</PartialText>
                                                    <WhereFoundSortOrder>4</WhereFoundSortOrder>
                                                    <StatusSortString>NewValue</StatusSortString>
                                                    <WhereFoundArchCode>CftRelatedParty</WhereFoundArchCode>
                                                    <WhereFoundAttrCode>DisplayName</WhereFoundAttrCode>
                                                    <WhereFoundArchCaption>RelatedParty</WhereFoundArchCaption>
                                                    <WhereFoundAttrCaption>Entity Name</WhereFoundAttrCaption>
                                                    <WhereFound>RelatedParty.Entity Name</WhereFound>
                                                    <WhereFoundItemID>144414ae-745d-4f8f-b0c7-e1696b348f74</WhereFoundItemID>
                                                    <CftSearchTerm>2b715017-1e67-4837-b185-c7d5c40cc4b0</CftSearchTerm>
                                                    <RiskImage>3</RiskImage>
                                                    <SearchTermSortOrder>1</SearchTermSortOrder>
                                                    <DebugInfo>NewValue</DebugInfo>
                                                    <DetailItemID>144414ae-745d-4f8f-b0c7-e1696b348f74</DetailItemID>
                                                    <DetailArchCode>CftRelatedParty</DetailArchCode>
                                                    <OpenMatters>1</OpenMatters>
                                                    <ClosedMatters>1</ClosedMatters>
                                                    <OpCLMatters>NewValue</OpCLMatters>
                                                    <WhereFoundFrameworkItemID>144414ae-745d-4f8f-b0c7-e1696b348f74</WhereFoundFrameworkItemID>
                                                    <RiskflagText>NewValue</RiskflagText>
                                                    <IsSelected>1</IsSelected>
                                                    <Assessment>NewValue</Assessment>
                                                    <Routed>NewValue</Routed>
                                                    <IsFiltered>1</IsFiltered>
                                                    <CorporateTreeImage />
                                                    <SearchNo>2</SearchNo>
                                                    <ClientName>NewValue</ClientName>
                                                    <MatterName>NewValue</MatterName>
                                                    <Role>Claimant</Role>
                                                    <Relationship>NewValue</Relationship>
                                                    <ConflictsContact>NewValue</ConflictsContact>
                                                    <CftEntityOrMatterIndex>1</CftEntityOrMatterIndex>
                                                    <EthicalWallImage />
                                                    <CftClientIndex>63528</CftClientIndex>
                                                    <EntitySanctionLoad />
                                                    <IsMattercentricHit>1</IsMattercentricHit>
                                                    <DisplayNumber>NewValue</DisplayNumber>
                                                    <IsRouteSelected>1</IsRouteSelected>
                                                    <EntityIndex>578938</EntityIndex>
                                                    <MatterIndex>417523</MatterIndex>
                                                    <DisplayText>NewValue</DisplayText>
                                                    <DisplayPartialText>NewValue</DisplayPartialText>
                                                    <DisplayClientName>NewValue</DisplayClientName>
                                                    <DisplayMatterName>NewValue</DisplayMatterName>
                                                    <DisplayNum>NewValue</DisplayNum>
                                                    <IsFilterAppliedToDetail>1</IsFilterAppliedToDetail>
                                                    <TimekeeperContact />
                                                    <NxUserContact />
                                                    <DisplayOpenMattersCount>2</DisplayOpenMattersCount>
                                                    <DisplayClosedMattersCount>2</DisplayClosedMattersCount>
                                                    <DisplayEthicalWallImage />
                                                    <DisplayCorporateTreeImage />
                                                    <DisplayConflictsContact>NewValue</DisplayConflictsContact>
                                                    <IsResultSelected>1</IsResultSelected>
                                                    <CftRoleCode />
                                                    <ThresholdIndicator> </ThresholdIndicator>
                                                    <IsSearchHasFilter>1</IsSearchHasFilter>
                                                    <IsForceRetrieveDetails>1</IsForceRetrieveDetails>
                                                    <ResultsDifferenceImage />
                                                    <CftSearchCompareStatus />
                                                    <IsResultModified>0</IsResultModified>
                                                    <SourceCollection>3E</SourceCollection>
                                                    <IsExternalHit>1</IsExternalHit>
                                                    <FTXSourceType>3EDatabase</FTXSourceType>
                                                    <PageNumber>0</PageNumber>
                                                    <IsViewDifference>1</IsViewDifference>
                                                    <CftFullTextResults>dfa96ca6-074d-4522-8459-33b09df583a1</CftFullTextResults>
                                                    <LocationOfOccurenceTxt_CCC>NewValue</LocationOfOccurenceTxt_CCC>
                                                    <DateOfOccurenceTxt_CCC>NewValue</DateOfOccurenceTxt_CCC>
                                                    <RelatedPartyID>144414ae-745d-4f8f-b0c7-e1696b348f74</RelatedPartyID>
                                                    <EntIndex>2</EntIndex>
                                                    <MattIndex>2</MattIndex>
                                                    <Notes>NewValue</Notes>
                                                    <EntityID>NewValue</EntityID>
                                                    <MatterID>NewValue</MatterID>
                                                    <LinkType>NewValue</LinkType>
                                                    <LinkStatus>NewValue</LinkStatus>
                                                    <ClientNumber>NewValue</ClientNumber>
                                                    <MatterNumber>NewValue</MatterNumber>
                                                    <RPClientName>NewValue</RPClientName>
                                                    <RPMatterName>NewValue</RPMatterName>
                                                    <ClientStatus>NewValue</ClientStatus>
                                                    <MatterStatus>NewValue</MatterStatus>
                                                    <CftRelatedParty />
                                                    <IsProspectiveRPItem>1</IsProspectiveRPItem>
                                                    <ClientOpenDate>1900-01-02T00:00:00</ClientOpenDate>
                                                    <ClientCloseDate>1900-01-02T00:00:00</ClientCloseDate>
                                                    <IsCreatedParty>1</IsCreatedParty>
                                                </Attributes>
                                            </CftSearchResultRPPerson>
                                        </Add>
                                        <Edit>
                                            <CftSearchResultRPPerson KeyValue=""CftSearchResultRPPersonKey"">
                                                <Attributes>
                                                    <SearchTermGroupingLabel>000001 - Brenda Simpson - Searched without Role</SearchTermGroupingLabel>
                                                    <Name>NewValue</Name>
                                                    <Text>[H]Brenda[/H] [H]Simpson[/H]</Text>
                                                    <ProviderCode>FrameworkDataProvider</ProviderCode>
                                                    <FullTextDocumentID>aa3d9f57-8eb5-4f0c-af9a-a089ae900e87</FullTextDocumentID>
                                                    <HitCount>1</HitCount>
                                                    <TextLanguage>1</TextLanguage>
                                                    <DataItemID>70ae5c0c-8d0d-4c0e-9526-9235b5be29b5</DataItemID>
                                                    <ArchCode>CftRelatedParty</ArchCode>
                                                    <AttrCode>DisplayName</AttrCode>
                                                    <IsExcluded>1</IsExcluded>
                                                    <PartialText>[H]Brenda[/H] [H]Simpson[/H]</PartialText>
                                                    <WhereFoundSortOrder>4</WhereFoundSortOrder>
                                                    <StatusSortString>NewValue</StatusSortString>
                                                    <WhereFoundArchCode>CftRelatedParty</WhereFoundArchCode>
                                                    <WhereFoundAttrCode>DisplayName</WhereFoundAttrCode>
                                                    <WhereFoundArchCaption>RelatedParty</WhereFoundArchCaption>
                                                    <WhereFoundAttrCaption>Entity Name</WhereFoundAttrCaption>
                                                    <WhereFound>RelatedParty.Entity Name</WhereFound>
                                                    <WhereFoundItemID>144414ae-745d-4f8f-b0c7-e1696b348f74</WhereFoundItemID>
                                                    <CftSearchTerm>2b715017-1e67-4837-b185-c7d5c40cc4b0</CftSearchTerm>
                                                    <RiskImage>3</RiskImage>
                                                    <SearchTermSortOrder>1</SearchTermSortOrder>
                                                    <DebugInfo>NewValue</DebugInfo>
                                                    <DetailItemID>144414ae-745d-4f8f-b0c7-e1696b348f74</DetailItemID>
                                                    <DetailArchCode>CftRelatedParty</DetailArchCode>
                                                    <OpenMatters>1</OpenMatters>
                                                    <ClosedMatters>1</ClosedMatters>
                                                    <OpCLMatters>NewValue</OpCLMatters>
                                                    <WhereFoundFrameworkItemID>144414ae-745d-4f8f-b0c7-e1696b348f74</WhereFoundFrameworkItemID>
                                                    <RiskflagText>NewValue</RiskflagText>
                                                    <IsSelected>1</IsSelected>
                                                    <Assessment>NewValue</Assessment>
                                                    <Routed>NewValue</Routed>
                                                    <IsFiltered>1</IsFiltered>
                                                    <CorporateTreeImage />
                                                    <SearchNo>2</SearchNo>
                                                    <ClientName>NewValue</ClientName>
                                                    <MatterName>NewValue</MatterName>
                                                    <Role>Claimant</Role>
                                                    <Relationship>NewValue</Relationship>
                                                    <ConflictsContact>NewValue</ConflictsContact>
                                                    <CftEntityOrMatterIndex>1</CftEntityOrMatterIndex>
                                                    <EthicalWallImage />
                                                    <CftClientIndex>63528</CftClientIndex>
                                                    <EntitySanctionLoad />
                                                    <IsMattercentricHit>1</IsMattercentricHit>
                                                    <DisplayNumber>NewValue</DisplayNumber>
                                                    <IsRouteSelected>1</IsRouteSelected>
                                                    <EntityIndex>578938</EntityIndex>
                                                    <MatterIndex>417523</MatterIndex>
                                                    <DisplayText>NewValue</DisplayText>
                                                    <DisplayPartialText>NewValue</DisplayPartialText>
                                                    <DisplayClientName>NewValue</DisplayClientName>
                                                    <DisplayMatterName>NewValue</DisplayMatterName>
                                                    <DisplayNum>NewValue</DisplayNum>
                                                    <IsFilterAppliedToDetail>1</IsFilterAppliedToDetail>
                                                    <TimekeeperContact />
                                                    <NxUserContact />
                                                    <DisplayOpenMattersCount>2</DisplayOpenMattersCount>
                                                    <DisplayClosedMattersCount>2</DisplayClosedMattersCount>
                                                    <DisplayEthicalWallImage />
                                                    <DisplayCorporateTreeImage />
                                                    <DisplayConflictsContact>NewValue</DisplayConflictsContact>
                                                    <IsResultSelected>1</IsResultSelected>
                                                    <CftRoleCode />
                                                    <ThresholdIndicator> </ThresholdIndicator>
                                                    <IsSearchHasFilter>1</IsSearchHasFilter>
                                                    <IsForceRetrieveDetails>1</IsForceRetrieveDetails>
                                                    <ResultsDifferenceImage />
                                                    <CftSearchCompareStatus />
                                                    <IsResultModified>0</IsResultModified>
                                                    <SourceCollection>3E</SourceCollection>
                                                    <IsExternalHit>1</IsExternalHit>
                                                    <FTXSourceType>3EDatabase</FTXSourceType>
                                                    <PageNumber>0</PageNumber>
                                                    <IsViewDifference>1</IsViewDifference>
                                                    <CftFullTextResults>dfa96ca6-074d-4522-8459-33b09df583a1</CftFullTextResults>
                                                    <LocationOfOccurenceTxt_CCC>NewValue</LocationOfOccurenceTxt_CCC>
                                                    <DateOfOccurenceTxt_CCC>NewValue</DateOfOccurenceTxt_CCC>
                                                    <RelatedPartyID>144414ae-745d-4f8f-b0c7-e1696b348f74</RelatedPartyID>
                                                    <EntIndex>2</EntIndex>
                                                    <MattIndex>2</MattIndex>
                                                    <Notes>NewValue</Notes>
                                                    <EntityID>NewValue</EntityID>
                                                    <MatterID>NewValue</MatterID>
                                                    <LinkType>NewValue</LinkType>
                                                    <LinkStatus>NewValue</LinkStatus>
                                                    <ClientNumber>NewValue</ClientNumber>
                                                    <MatterNumber>NewValue</MatterNumber>
                                                    <RPClientName>NewValue</RPClientName>
                                                    <RPMatterName>NewValue</RPMatterName>
                                                    <ClientStatus>NewValue</ClientStatus>
                                                    <MatterStatus>NewValue</MatterStatus>
                                                    <CftRelatedParty />
                                                    <IsProspectiveRPItem>1</IsProspectiveRPItem>
                                                    <ClientOpenDate>1900-01-02T00:00:00</ClientOpenDate>
                                                    <ClientCloseDate>1900-01-02T00:00:00</ClientCloseDate>
                                                    <IsCreatedParty>1</IsCreatedParty>
                                                </Attributes>
                                            </CftSearchResultRPPerson>
                                        </Edit>
                                    </CftSearchResult>
                                    <CftComments>
                                        <Add>
                                            <CftComments>
                                                <Attributes>
                                                    <CftSearchAssessment>fca12c19-10dc-4baf-8351-bf141feab750</CftSearchAssessment>
                                                    <CftReviewer>ef2df787-3d90-443a-9a8d-8c847ae32746</CftReviewer>
                                                    <CftNewBizRequest>06122784-ebba-4e85-82b8-ac55142e59f3</CftNewBizRequest>
                                                    <CftDateTime>2019-04-17T14:21:21</CftDateTime>
                                                    <CftComments>Please remove the 'and' from the Insured.</CftComments>
                                                </Attributes>
                                            </CftComments>
                                        </Add>
                                        <Edit>
                                            <CftComments KeyValue=""CftCommentsKey"">
                                                <Attributes>
                                                    <CftSearchAssessment>fca12c19-10dc-4baf-8351-bf141feab750</CftSearchAssessment>
                                                    <CftReviewer>ef2df787-3d90-443a-9a8d-8c847ae32746</CftReviewer>
                                                    <CftNewBizRequest>06122784-ebba-4e85-82b8-ac55142e59f3</CftNewBizRequest>
                                                    <CftDateTime>2019-04-17T14:21:21</CftDateTime>
                                                    <CftComments>Please remove the 'and' from the Insured.</CftComments>
                                                </Attributes>
                                            </CftComments>
                                        </Edit>
                                    </CftComments>
                                    <CftWorkflowHistory>
                                        <Add>
                                            <CftWorkflowHistory>
                                                <Attributes>
                                                    <CftNBRStatus>Pending</CftNBRStatus>
                                                    <CftWorkflowStep>SearchEntry</CftWorkflowStep>
                                                    <NxBaseUser>f22b6972-e56c-41ea-a99a-e3b3f2d3ce8c</NxBaseUser>
                                                    <StartDate>2019-04-18T06:49:17</StartDate>
                                                    <EndDate>1900-01-02T00:00:00</EndDate>
                                                    <CftSearchAuthorityList />
                                                </Attributes>
                                            </CftWorkflowHistory>
                                        </Add>
                                        <Edit>
                                            <CftWorkflowHistory KeyValue=""CftWorkflowHistoryKey"">
                                                <Attributes>
                                                    <CftNBRStatus>Pending</CftNBRStatus>
                                                    <CftWorkflowStep>SearchEntry</CftWorkflowStep>
                                                    <NxBaseUser>f22b6972-e56c-41ea-a99a-e3b3f2d3ce8c</NxBaseUser>
                                                    <StartDate>2019-04-18T06:49:17</StartDate>
                                                    <EndDate>1900-01-02T00:00:00</EndDate>
                                                    <CftSearchAuthorityList />
                                                </Attributes>
                                            </CftWorkflowHistory>
                                        </Edit>
                                        <Add>
                                            <CftWorkflowHistory>
                                                <Attributes>
                                                    <CftNBRStatus>Pending</CftNBRStatus>
                                                    <CftWorkflowStep>SearchEntry</CftWorkflowStep>
                                                    <NxBaseUser>f22b6972-e56c-41ea-a99a-e3b3f2d3ce8c</NxBaseUser>
                                                    <StartDate>2019-04-18T06:49:15</StartDate>
                                                    <EndDate>2019-04-18T06:49:17</EndDate>
                                                    <CftSearchAuthorityList />
                                                </Attributes>
                                            </CftWorkflowHistory>
                                        </Add>
                                        <Edit>
                                            <CftWorkflowHistory KeyValue=""CftWorkflowHistoryKey"">
                                                <Attributes>
                                                    <CftNBRStatus>Pending</CftNBRStatus>
                                                    <CftWorkflowStep>SearchEntry</CftWorkflowStep>
                                                    <NxBaseUser>f22b6972-e56c-41ea-a99a-e3b3f2d3ce8c</NxBaseUser>
                                                    <StartDate>2019-04-18T06:49:15</StartDate>
                                                    <EndDate>2019-04-18T06:49:17</EndDate>
                                                    <CftSearchAuthorityList />
                                                </Attributes>
                                            </CftWorkflowHistory>
                                        </Edit>
                                        <Add>
                                            <CftWorkflowHistory>
                                                <Attributes>
                                                    <CftNBRStatus>Pending</CftNBRStatus>
                                                    <CftWorkflowStep>SearchEntry</CftWorkflowStep>
                                                    <NxBaseUser>f22b6972-e56c-41ea-a99a-e3b3f2d3ce8c</NxBaseUser>
                                                    <StartDate>2019-04-20T15:59:01</StartDate>
                                                    <EndDate>1900-01-02T00:00:00</EndDate>
                                                    <CftSearchAuthorityList />
                                                </Attributes>
                                            </CftWorkflowHistory>
                                        </Add>
                                        <Edit>
                                            <CftWorkflowHistory KeyValue=""CftWorkflowHistoryKey"">
                                                <Attributes>
                                                    <CftNBRStatus>Pending</CftNBRStatus>
                                                    <CftWorkflowStep>SearchEntry</CftWorkflowStep>
                                                    <NxBaseUser>f22b6972-e56c-41ea-a99a-e3b3f2d3ce8c</NxBaseUser>
                                                    <StartDate>2019-04-20T15:59:01</StartDate>
                                                    <EndDate>1900-01-02T00:00:00</EndDate>
                                                    <CftSearchAuthorityList />
                                                </Attributes>
                                            </CftWorkflowHistory>
                                        </Edit>
                                        <Add>
                                            <CftWorkflowHistory>
                                                <Attributes>
                                                    <CftNBRStatus>Pending</CftNBRStatus>
                                                    <CftWorkflowStep>SearchEntry</CftWorkflowStep>
                                                    <NxBaseUser>f22b6972-e56c-41ea-a99a-e3b3f2d3ce8c</NxBaseUser>
                                                    <StartDate>2019-04-16T08:20:18</StartDate>
                                                    <EndDate>1900-01-02T00:00:00</EndDate>
                                                    <CftSearchAuthorityList />
                                                </Attributes>
                                            </CftWorkflowHistory>
                                        </Add>
                                        <Edit>
                                            <CftWorkflowHistory KeyValue=""CftWorkflowHistoryKey"">
                                                <Attributes>
                                                    <CftNBRStatus>Pending</CftNBRStatus>
                                                    <CftWorkflowStep>SearchEntry</CftWorkflowStep>
                                                    <NxBaseUser>f22b6972-e56c-41ea-a99a-e3b3f2d3ce8c</NxBaseUser>
                                                    <StartDate>2019-04-16T08:20:18</StartDate>
                                                    <EndDate>1900-01-02T00:00:00</EndDate>
                                                    <CftSearchAuthorityList />
                                                </Attributes>
                                            </CftWorkflowHistory>
                                        </Edit>
                                        <Add>
                                            <CftWorkflowHistory>
                                                <Attributes>
                                                    <CftNBRStatus>Pending</CftNBRStatus>
                                                    <CftWorkflowStep>SearchEntry</CftWorkflowStep>
                                                    <NxBaseUser>ef2df787-3d90-443a-9a8d-8c847ae32746</NxBaseUser>
                                                    <StartDate>2019-04-16T08:20:18</StartDate>
                                                    <EndDate>2019-04-17T14:22:32</EndDate>
                                                    <CftSearchAuthorityList />
                                                </Attributes>
                                            </CftWorkflowHistory>
                                        </Add>
                                        <Edit>
                                            <CftWorkflowHistory KeyValue=""CftWorkflowHistoryKey"">
                                                <Attributes>
                                                    <CftNBRStatus>Pending</CftNBRStatus>
                                                    <CftWorkflowStep>SearchEntry</CftWorkflowStep>
                                                    <NxBaseUser>ef2df787-3d90-443a-9a8d-8c847ae32746</NxBaseUser>
                                                    <StartDate>2019-04-16T08:20:18</StartDate>
                                                    <EndDate>2019-04-17T14:22:32</EndDate>
                                                    <CftSearchAuthorityList />
                                                </Attributes>
                                            </CftWorkflowHistory>
                                        </Edit>
                                        <Add>
                                            <CftWorkflowHistory>
                                                <Attributes>
                                                    <CftNBRStatus>Pending</CftNBRStatus>
                                                    <CftWorkflowStep>SearchEntry</CftWorkflowStep>
                                                    <NxBaseUser>f22b6972-e56c-41ea-a99a-e3b3f2d3ce8c</NxBaseUser>
                                                    <StartDate>2019-04-16T08:20:16</StartDate>
                                                    <EndDate>2019-04-16T08:20:18</EndDate>
                                                    <CftSearchAuthorityList />
                                                </Attributes>
                                            </CftWorkflowHistory>
                                        </Add>
                                        <Edit>
                                            <CftWorkflowHistory KeyValue=""CftWorkflowHistoryKey"">
                                                <Attributes>
                                                    <CftNBRStatus>Pending</CftNBRStatus>
                                                    <CftWorkflowStep>SearchEntry</CftWorkflowStep>
                                                    <NxBaseUser>f22b6972-e56c-41ea-a99a-e3b3f2d3ce8c</NxBaseUser>
                                                    <StartDate>2019-04-16T08:20:16</StartDate>
                                                    <EndDate>2019-04-16T08:20:18</EndDate>
                                                    <CftSearchAuthorityList />
                                                </Attributes>
                                            </CftWorkflowHistory>
                                        </Edit>
                                        <Add>
                                            <CftWorkflowHistory>
                                                <Attributes>
                                                    <CftNBRStatus>Pending</CftNBRStatus>
                                                    <CftWorkflowStep>NBIEntry</CftWorkflowStep>
                                                    <NxBaseUser>f6face3b-fbef-479b-9870-f3349a238066</NxBaseUser>
                                                    <StartDate>2019-04-16T08:00:09</StartDate>
                                                    <EndDate>1900-01-02T00:00:00</EndDate>
                                                    <CftSearchAuthorityList />
                                                </Attributes>
                                            </CftWorkflowHistory>
                                        </Add>
                                        <Edit>
                                            <CftWorkflowHistory KeyValue=""CftWorkflowHistoryKey"">
                                                <Attributes>
                                                    <CftNBRStatus>Pending</CftNBRStatus>
                                                    <CftWorkflowStep>NBIEntry</CftWorkflowStep>
                                                    <NxBaseUser>f6face3b-fbef-479b-9870-f3349a238066</NxBaseUser>
                                                    <StartDate>2019-04-16T08:00:09</StartDate>
                                                    <EndDate>1900-01-02T00:00:00</EndDate>
                                                    <CftSearchAuthorityList />
                                                </Attributes>
                                            </CftWorkflowHistory>
                                        </Edit>
                                        <Add>
                                            <CftWorkflowHistory>
                                                <Attributes>
                                                    <CftNBRStatus>Pending</CftNBRStatus>
                                                    <CftWorkflowStep>SearchResults</CftWorkflowStep>
                                                    <NxBaseUser>7356c8e1-de08-40ba-a0f1-5a8bc02707af</NxBaseUser>
                                                    <StartDate>2019-04-20T15:59:31</StartDate>
                                                    <EndDate>2019-04-20T15:59:58</EndDate>
                                                    <CftSearchAuthorityList />
                                                </Attributes>
                                            </CftWorkflowHistory>
                                        </Add>
                                        <Edit>
                                            <CftWorkflowHistory KeyValue=""CftWorkflowHistoryKey"">
                                                <Attributes>
                                                    <CftNBRStatus>Pending</CftNBRStatus>
                                                    <CftWorkflowStep>SearchResults</CftWorkflowStep>
                                                    <NxBaseUser>7356c8e1-de08-40ba-a0f1-5a8bc02707af</NxBaseUser>
                                                    <StartDate>2019-04-20T15:59:31</StartDate>
                                                    <EndDate>2019-04-20T15:59:58</EndDate>
                                                    <CftSearchAuthorityList />
                                                </Attributes>
                                            </CftWorkflowHistory>
                                        </Edit>
                                        <Add>
                                            <CftWorkflowHistory>
                                                <Attributes>
                                                    <CftNBRStatus>PendingApproved</CftNBRStatus>
                                                    <CftWorkflowStep>ResultsReviewForDecision</CftWorkflowStep>
                                                    <NxBaseUser>653df626-eb1d-46ee-b8de-5f677e6432e4</NxBaseUser>
                                                    <StartDate>2019-04-20T16:00:04</StartDate>
                                                    <EndDate>2019-04-20T16:00:05</EndDate>
                                                    <CftSearchAuthorityList>Decision Maker</CftSearchAuthorityList>
                                                </Attributes>
                                            </CftWorkflowHistory>
                                        </Add>
                                        <Edit>
                                            <CftWorkflowHistory KeyValue=""CftWorkflowHistoryKey"">
                                                <Attributes>
                                                    <CftNBRStatus>PendingApproved</CftNBRStatus>
                                                    <CftWorkflowStep>ResultsReviewForDecision</CftWorkflowStep>
                                                    <NxBaseUser>653df626-eb1d-46ee-b8de-5f677e6432e4</NxBaseUser>
                                                    <StartDate>2019-04-20T16:00:04</StartDate>
                                                    <EndDate>2019-04-20T16:00:05</EndDate>
                                                    <CftSearchAuthorityList>Decision Maker</CftSearchAuthorityList>
                                                </Attributes>
                                            </CftWorkflowHistory>
                                        </Edit>
                                        <Add>
                                            <CftWorkflowHistory>
                                                <Attributes>
                                                    <CftNBRStatus>Pending</CftNBRStatus>
                                                    <CftWorkflowStep>SearchEntry</CftWorkflowStep>
                                                    <NxBaseUser>7356c8e1-de08-40ba-a0f1-5a8bc02707af</NxBaseUser>
                                                    <StartDate>2019-04-18T06:49:17</StartDate>
                                                    <EndDate>2019-04-20T15:58:35</EndDate>
                                                    <CftSearchAuthorityList />
                                                </Attributes>
                                            </CftWorkflowHistory>
                                        </Add>
                                        <Edit>
                                            <CftWorkflowHistory KeyValue=""CftWorkflowHistoryKey"">
                                                <Attributes>
                                                    <CftNBRStatus>Pending</CftNBRStatus>
                                                    <CftWorkflowStep>SearchEntry</CftWorkflowStep>
                                                    <NxBaseUser>7356c8e1-de08-40ba-a0f1-5a8bc02707af</NxBaseUser>
                                                    <StartDate>2019-04-18T06:49:17</StartDate>
                                                    <EndDate>2019-04-20T15:58:35</EndDate>
                                                    <CftSearchAuthorityList />
                                                </Attributes>
                                            </CftWorkflowHistory>
                                        </Edit>
                                        <Add>
                                            <CftWorkflowHistory>
                                                <Attributes>
                                                    <CftNBRStatus>Pending</CftNBRStatus>
                                                    <CftWorkflowStep>SearchEntry</CftWorkflowStep>
                                                    <NxBaseUser>7356c8e1-de08-40ba-a0f1-5a8bc02707af</NxBaseUser>
                                                    <StartDate>2019-04-20T15:59:01</StartDate>
                                                    <EndDate>2019-04-20T15:59:31</EndDate>
                                                    <CftSearchAuthorityList />
                                                </Attributes>
                                            </CftWorkflowHistory>
                                        </Add>
                                        <Edit>
                                            <CftWorkflowHistory KeyValue=""CftWorkflowHistoryKey"">
                                                <Attributes>
                                                    <CftNBRStatus>Pending</CftNBRStatus>
                                                    <CftWorkflowStep>SearchEntry</CftWorkflowStep>
                                                    <NxBaseUser>7356c8e1-de08-40ba-a0f1-5a8bc02707af</NxBaseUser>
                                                    <StartDate>2019-04-20T15:59:01</StartDate>
                                                    <EndDate>2019-04-20T15:59:31</EndDate>
                                                    <CftSearchAuthorityList />
                                                </Attributes>
                                            </CftWorkflowHistory>
                                        </Edit>
                                        <Add>
                                            <CftWorkflowHistory>
                                                <Attributes>
                                                    <CftNBRStatus>Pending</CftNBRStatus>
                                                    <CftWorkflowStep>ResultsReviewForDecision</CftWorkflowStep>
                                                    <NxBaseUser>7356c8e1-de08-40ba-a0f1-5a8bc02707af</NxBaseUser>
                                                    <StartDate>2019-04-20T15:59:58</StartDate>
                                                    <EndDate>2019-04-20T16:00:04</EndDate>
                                                    <CftSearchAuthorityList>Decision Maker</CftSearchAuthorityList>
                                                </Attributes>
                                            </CftWorkflowHistory>
                                        </Add>
                                        <Edit>
                                            <CftWorkflowHistory KeyValue=""CftWorkflowHistoryKey"">
                                                <Attributes>
                                                    <CftNBRStatus>Pending</CftNBRStatus>
                                                    <CftWorkflowStep>ResultsReviewForDecision</CftWorkflowStep>
                                                    <NxBaseUser>7356c8e1-de08-40ba-a0f1-5a8bc02707af</NxBaseUser>
                                                    <StartDate>2019-04-20T15:59:58</StartDate>
                                                    <EndDate>2019-04-20T16:00:04</EndDate>
                                                    <CftSearchAuthorityList>Decision Maker</CftSearchAuthorityList>
                                                </Attributes>
                                            </CftWorkflowHistory>
                                        </Edit>
                                        <Add>
                                            <CftWorkflowHistory>
                                                <Attributes>
                                                    <CftNBRStatus>Approved</CftNBRStatus>
                                                    <CftWorkflowStep>Finalized</CftWorkflowStep>
                                                    <NxBaseUser>7356c8e1-de08-40ba-a0f1-5a8bc02707af</NxBaseUser>
                                                    <StartDate>2019-04-20T16:00:05</StartDate>
                                                    <EndDate>2019-04-20T16:00:06</EndDate>
                                                    <CftSearchAuthorityList />
                                                </Attributes>
                                            </CftWorkflowHistory>
                                        </Add>
                                        <Edit>
                                            <CftWorkflowHistory KeyValue=""CftWorkflowHistoryKey"">
                                                <Attributes>
                                                    <CftNBRStatus>Approved</CftNBRStatus>
                                                    <CftWorkflowStep>Finalized</CftWorkflowStep>
                                                    <NxBaseUser>7356c8e1-de08-40ba-a0f1-5a8bc02707af</NxBaseUser>
                                                    <StartDate>2019-04-20T16:00:05</StartDate>
                                                    <EndDate>2019-04-20T16:00:06</EndDate>
                                                    <CftSearchAuthorityList />
                                                </Attributes>
                                            </CftWorkflowHistory>
                                        </Edit>
                                        <Add>
                                            <CftWorkflowHistory>
                                                <Attributes>
                                                    <CftNBRStatus>Pending</CftNBRStatus>
                                                    <CftWorkflowStep>NBIEntry</CftWorkflowStep>
                                                    <NxBaseUser>f6face3b-fbef-479b-9870-f3349a238066</NxBaseUser>
                                                    <StartDate>2019-04-17T14:22:32</StartDate>
                                                    <EndDate>1900-01-02T00:00:00</EndDate>
                                                    <CftSearchAuthorityList />
                                                </Attributes>
                                            </CftWorkflowHistory>
                                        </Add>
                                        <Edit>
                                            <CftWorkflowHistory KeyValue=""CftWorkflowHistoryKey"">
                                                <Attributes>
                                                    <CftNBRStatus>Pending</CftNBRStatus>
                                                    <CftWorkflowStep>NBIEntry</CftWorkflowStep>
                                                    <NxBaseUser>f6face3b-fbef-479b-9870-f3349a238066</NxBaseUser>
                                                    <StartDate>2019-04-17T14:22:32</StartDate>
                                                    <EndDate>1900-01-02T00:00:00</EndDate>
                                                    <CftSearchAuthorityList />
                                                </Attributes>
                                            </CftWorkflowHistory>
                                        </Edit>
                                        <Add>
                                            <CftWorkflowHistory>
                                                <Attributes>
                                                    <CftNBRStatus>Pending</CftNBRStatus>
                                                    <CftWorkflowStep>SearchResults</CftWorkflowStep>
                                                    <NxBaseUser>7356c8e1-de08-40ba-a0f1-5a8bc02707af</NxBaseUser>
                                                    <StartDate>2019-04-20T15:58:35</StartDate>
                                                    <EndDate>2019-04-20T15:59:01</EndDate>
                                                    <CftSearchAuthorityList />
                                                </Attributes>
                                            </CftWorkflowHistory>
                                        </Add>
                                        <Edit>
                                            <CftWorkflowHistory KeyValue=""CftWorkflowHistoryKey"">
                                                <Attributes>
                                                    <CftNBRStatus>Pending</CftNBRStatus>
                                                    <CftWorkflowStep>SearchResults</CftWorkflowStep>
                                                    <NxBaseUser>7356c8e1-de08-40ba-a0f1-5a8bc02707af</NxBaseUser>
                                                    <StartDate>2019-04-20T15:58:35</StartDate>
                                                    <EndDate>2019-04-20T15:59:01</EndDate>
                                                    <CftSearchAuthorityList />
                                                </Attributes>
                                            </CftWorkflowHistory>
                                        </Edit>
                                    </CftWorkflowHistory>
                                    <CftSearchFields>
                                        <Add>
                                            <CftSearchFields>
                                                <Attributes>
                                                    <ArchCode>EntityPerson</ArchCode>
                                                    <AttrCode>GoesBy</AttrCode>
                                                    <IsPhoneticSearch>0</IsPhoneticSearch>
                                                    <CollectionName>3E</CollectionName>
                                                </Attributes>
                                            </CftSearchFields>
                                        </Add>
                                        <Edit>
                                            <CftSearchFields KeyValue=""CftSearchFieldsKey"">
                                                <Attributes>
                                                    <ArchCode>EntityPerson</ArchCode>
                                                    <AttrCode>GoesBy</AttrCode>
                                                    <IsPhoneticSearch>0</IsPhoneticSearch>
                                                    <CollectionName>3E</CollectionName>
                                                </Attributes>
                                            </CftSearchFields>
                                        </Edit>
                                        <Add>
                                            <CftSearchFields>
                                                <Attributes>
                                                    <ArchCode>EntityPerson</ArchCode>
                                                    <AttrCode>DisplayName</AttrCode>
                                                    <IsPhoneticSearch>0</IsPhoneticSearch>
                                                    <CollectionName>3E</CollectionName>
                                                </Attributes>
                                            </CftSearchFields>
                                        </Add>
                                        <Edit>
                                            <CftSearchFields KeyValue=""CftSearchFieldsKey"">
                                                <Attributes>
                                                    <ArchCode>EntityPerson</ArchCode>
                                                    <AttrCode>DisplayName</AttrCode>
                                                    <IsPhoneticSearch>0</IsPhoneticSearch>
                                                    <CollectionName>3E</CollectionName>
                                                </Attributes>
                                            </CftSearchFields>
                                        </Edit>
                                        <Add>
                                            <CftSearchFields>
                                                <Attributes>
                                                    <ArchCode>EntityOrg</ArchCode>
                                                    <AttrCode>DisplayName</AttrCode>
                                                    <IsPhoneticSearch>0</IsPhoneticSearch>
                                                    <CollectionName>3E</CollectionName>
                                                </Attributes>
                                            </CftSearchFields>
                                        </Add>
                                        <Edit>
                                            <CftSearchFields KeyValue=""CftSearchFieldsKey"">
                                                <Attributes>
                                                    <ArchCode>EntityOrg</ArchCode>
                                                    <AttrCode>DisplayName</AttrCode>
                                                    <IsPhoneticSearch>0</IsPhoneticSearch>
                                                    <CollectionName>3E</CollectionName>
                                                </Attributes>
                                            </CftSearchFields>
                                        </Edit>
                                        <Add>
                                            <CftSearchFields>
                                                <Attributes>
                                                    <ArchCode>Client</ArchCode>
                                                    <AttrCode>Number</AttrCode>
                                                    <IsPhoneticSearch>1</IsPhoneticSearch>
                                                    <CollectionName>3E</CollectionName>
                                                </Attributes>
                                            </CftSearchFields>
                                        </Add>
                                        <Edit>
                                            <CftSearchFields KeyValue=""CftSearchFieldsKey"">
                                                <Attributes>
                                                    <ArchCode>Client</ArchCode>
                                                    <AttrCode>Number</AttrCode>
                                                    <IsPhoneticSearch>1</IsPhoneticSearch>
                                                    <CollectionName>3E</CollectionName>
                                                </Attributes>
                                            </CftSearchFields>
                                        </Edit>
                                        <Add>
                                            <CftSearchFields>
                                                <Attributes>
                                                    <ArchCode>CftRelatedParty</ArchCode>
                                                    <AttrCode>Notes</AttrCode>
                                                    <IsPhoneticSearch>1</IsPhoneticSearch>
                                                    <CollectionName>3E</CollectionName>
                                                </Attributes>
                                            </CftSearchFields>
                                        </Add>
                                        <Edit>
                                            <CftSearchFields KeyValue=""CftSearchFieldsKey"">
                                                <Attributes>
                                                    <ArchCode>CftRelatedParty</ArchCode>
                                                    <AttrCode>Notes</AttrCode>
                                                    <IsPhoneticSearch>1</IsPhoneticSearch>
                                                    <CollectionName>3E</CollectionName>
                                                </Attributes>
                                            </CftSearchFields>
                                        </Edit>
                                        <Add>
                                            <CftSearchFields>
                                                <Attributes>
                                                    <ArchCode>Client</ArchCode>
                                                    <AttrCode>Narrative</AttrCode>
                                                    <IsPhoneticSearch>1</IsPhoneticSearch>
                                                    <CollectionName>3E</CollectionName>
                                                </Attributes>
                                            </CftSearchFields>
                                        </Add>
                                        <Edit>
                                            <CftSearchFields KeyValue=""CftSearchFieldsKey"">
                                                <Attributes>
                                                    <ArchCode>Client</ArchCode>
                                                    <AttrCode>Narrative</AttrCode>
                                                    <IsPhoneticSearch>1</IsPhoneticSearch>
                                                    <CollectionName>3E</CollectionName>
                                                </Attributes>
                                            </CftSearchFields>
                                        </Edit>
                                        <Add>
                                            <CftSearchFields>
                                                <Attributes>
                                                    <ArchCode>Client</ArchCode>
                                                    <AttrCode>DisplayName</AttrCode>
                                                    <IsPhoneticSearch>0</IsPhoneticSearch>
                                                    <CollectionName>3E</CollectionName>
                                                </Attributes>
                                            </CftSearchFields>
                                        </Add>
                                        <Edit>
                                            <CftSearchFields KeyValue=""CftSearchFieldsKey"">
                                                <Attributes>
                                                    <ArchCode>Client</ArchCode>
                                                    <AttrCode>DisplayName</AttrCode>
                                                    <IsPhoneticSearch>0</IsPhoneticSearch>
                                                    <CollectionName>3E</CollectionName>
                                                </Attributes>
                                            </CftSearchFields>
                                        </Edit>
                                        <Add>
                                            <CftSearchFields>
                                                <Attributes>
                                                    <ArchCode>Matter</ArchCode>
                                                    <AttrCode>Description</AttrCode>
                                                    <IsPhoneticSearch>0</IsPhoneticSearch>
                                                    <CollectionName>3E</CollectionName>
                                                </Attributes>
                                            </CftSearchFields>
                                        </Add>
                                        <Edit>
                                            <CftSearchFields KeyValue=""CftSearchFieldsKey"">
                                                <Attributes>
                                                    <ArchCode>Matter</ArchCode>
                                                    <AttrCode>Description</AttrCode>
                                                    <IsPhoneticSearch>0</IsPhoneticSearch>
                                                    <CollectionName>3E</CollectionName>
                                                </Attributes>
                                            </CftSearchFields>
                                        </Edit>
                                        <Add>
                                            <CftSearchFields>
                                                <Attributes>
                                                    <ArchCode>EntityAltName</ArchCode>
                                                    <AttrCode>AltName</AttrCode>
                                                    <IsPhoneticSearch>0</IsPhoneticSearch>
                                                    <CollectionName>3E</CollectionName>
                                                </Attributes>
                                            </CftSearchFields>
                                        </Add>
                                        <Edit>
                                            <CftSearchFields KeyValue=""CftSearchFieldsKey"">
                                                <Attributes>
                                                    <ArchCode>EntityAltName</ArchCode>
                                                    <AttrCode>AltName</AttrCode>
                                                    <IsPhoneticSearch>0</IsPhoneticSearch>
                                                    <CollectionName>3E</CollectionName>
                                                </Attributes>
                                            </CftSearchFields>
                                        </Edit>
                                    </CftSearchFields>
                                    <CftSearchAddress_CCC>
                                        <Add>
                                            <CftSearchAddress_CCC>
                                                <Attributes>
                                                    <City>Newnan</City>
                                                    <Country>US</Country>
                                                    <Location>63 Hollis Heights</Location>
                                                    <State>GA</State>
                                                    <Zipcode>30263</Zipcode>
                                                    <ZipCodeLookup />
                                                    <County>NewValue</County>
                                                </Attributes>
                                            </CftSearchAddress_CCC>
                                        </Add>
                                        <Edit>
                                            <CftSearchAddress_CCC KeyValue=""CftSearchAddress_CCCKey"">
                                                <Attributes>
                                                    <City>Newnan</City>
                                                    <Country>US</Country>
                                                    <Location>63 Hollis Heights</Location>
                                                    <State>GA</State>
                                                    <Zipcode>30263</Zipcode>
                                                    <ZipCodeLookup />
                                                    <County>NewValue</County>
                                                </Attributes>
                                            </CftSearchAddress_CCC>
                                        </Edit>
                                    </CftSearchAddress_CCC>
                                </Children>
                            </CftSearch>
                        </Edit>
                    </CftSearch>
                    <CftNBIComments>
                        <Add>
                            <CftNBIComments>
                                <Attributes>
                                    <CftSearchAssessment>fca12c19-10dc-4baf-8351-bf141feab750</CftSearchAssessment>
                                    <CftReviewer>ef2df787-3d90-443a-9a8d-8c847ae32746</CftReviewer>
                                    <CftDateTime>2019-04-17T14:21:21</CftDateTime>
                                    <CftComments>Please remove the 'and' from the Insured.</CftComments>
                                    <CftSearch>e8ca65e6-ad13-4499-b1fa-f59dd11a9782</CftSearch>
                                </Attributes>
                            </CftNBIComments>
                        </Add>
                        <Edit>
                            <CftNBIComments KeyValue=""CftNBICommentsKey"">
                                <Attributes>
                                    <CftSearchAssessment>fca12c19-10dc-4baf-8351-bf141feab750</CftSearchAssessment>
                                    <CftReviewer>ef2df787-3d90-443a-9a8d-8c847ae32746</CftReviewer>
                                    <CftDateTime>2019-04-17T14:21:21</CftDateTime>
                                    <CftComments>Please remove the 'and' from the Insured.</CftComments>
                                    <CftSearch>e8ca65e6-ad13-4499-b1fa-f59dd11a9782</CftSearch>
                                </Attributes>
                            </CftNBIComments>
                        </Edit>
                    </CftNBIComments>
                    <CftNewBizDateRange_CCC>
                        <Add>
                            <CftNewBizDateRange_CCC>
                                <Attributes>
                                    <DateOfOccurenceEnd>2019-04-11T00:00:00</DateOfOccurenceEnd>
                                    <DateOfOccurenceStart>2019-04-11T00:00:00</DateOfOccurenceStart>
                                </Attributes>
                            </CftNewBizDateRange_CCC>
                        </Add>
                        <Edit>
                            <CftNewBizDateRange_CCC KeyValue=""CftNewBizDateRange_CCCKey"">
                                <Attributes>
                                    <DateOfOccurenceEnd>2019-04-11T00:00:00</DateOfOccurenceEnd>
                                    <DateOfOccurenceStart>2019-04-11T00:00:00</DateOfOccurenceStart>
                                </Attributes>
                            </CftNewBizDateRange_CCC>
                        </Edit>
                    </CftNewBizDateRange_CCC>
                    <CftNewBizAddress_CCC>
                        <Add>
                            <CftNewBizAddress_CCC>
                                <Attributes>
                                    <City>Newnan</City>
                                    <County>Coweta</County>
                                    <Location>63 Hollis Heights</Location>
                                    <ZipCode>30263</ZipCode>
                                    <Country>US</Country>
                                    <State>GA</State>
                                    <ZipCodeLookup />
                                </Attributes>
                            </CftNewBizAddress_CCC>
                        </Add>
                        <Edit>
                            <CftNewBizAddress_CCC KeyValue=""CftNewBizAddress_CCCKey"">
                                <Attributes>
                                    <City>Newnan</City>
                                    <County>Coweta</County>
                                    <Location>63 Hollis Heights</Location>
                                    <ZipCode>30263</ZipCode>
                                    <Country>US</Country>
                                    <State>GA</State>
                                    <ZipCodeLookup />
                                </Attributes>
                            </CftNewBizAddress_CCC>
                        </Edit>
                    </CftNewBizAddress_CCC>
                </Children>
            </CftNewBizRequest>
        </Edit>
";

    }
}
