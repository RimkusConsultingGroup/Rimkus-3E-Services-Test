using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TE3EConnect.te3eXML.NewBizIntake
{
    public static partial class e3eCftWFNewBizIntakeXML
    {
        public static string AddCftWFNewBizIntakeXml = @"
        @AddCftNewBizRequest
";

        public static string AddCftNewBizRequest = @"
        <Add>
            <CftNewBizRequest>
                <Attributes>
                    <Client>@ClientId</Client>
                    <Matter>@MatterId</Matter>
                    <RequestDateTime>@RequestDateTime</RequestDateTime>
                    <CftSearchReason>@CftSearchReason</CftSearchReason>
                    <Description>@Description</Description>
                    <CurrentSearchID>@CurrentSearchID</CurrentSearchID>
                    <IsCreatedMatter>@IsCreatedMatter</IsCreatedMatter>
                    <IsCreatedClient>@IsCreatedClient</IsCreatedClient>
                    <StartTime>@StartTime</StartTime>
                    <CftNBRStatus>@CftNBRStatus</CftNBRStatus>
                    <CurrentWorkflowStep>@CurrentWorkflowStep</CurrentWorkflowStep>
                    <OrgProc>@OrgProc</OrgProc>
                    <ClientSearchNameId>@ClientSearchNameId</ClientSearchNameId>
                    <Submitter>@Submitter</Submitter>
                    <FinalizeResult>@FinalizeResult</FinalizeResult>
                    <DateRouted>@DateRouted</DateRouted>
                    <DateDecided>@DateDecided</DateDecided>
                    <DeclineReason>@DeclineReason</DeclineReason>
                    <DeclineComment>@DeclineComment</DeclineComment>
                    <DecidedBy>@DecidedBy</DecidedBy>
                    <LoadNumber>@LoadNumber</LoadNumber>
                    <LoadSource>@LoadSource</LoadSource>
                    <LoadGroup>@LoadGroup</LoadGroup>
                    <LoadBatchID>@LoadBatchID</LoadBatchID>
                    <LoadFlag>@LoadFlag</LoadFlag>
                    <CftSearchClient>@CftSearchClient</CftSearchClient>
                    <CftResultView>@CftResultView</CftResultView>
                    <FromCMCase>@FromCMCase</FromCMCase>
                    <CmCase>@CmCase</CmCase>
                    <AdminComments>@AdminComments</AdminComments>
                    <IsNBIntake>@IsNBIntake</IsNBIntake>
                    <Entity>@EntityId</Entity>
                    <CreatedEntityIndex>@CreatedEntityIndex</CreatedEntityIndex>
                    <ClientMatterCreationRouteTo>@ClientMatterCreationRouteTo</ClientMatterCreationRouteTo>
                    <IsCurrentClientMatterCreationStep>@IsCurrentClientMatterCreationStep</IsCurrentClientMatterCreationStep>
                    <EstimatedNumResults>@EstimatedNumResults</EstimatedNumResults>
                    <IsLargeResultSetAllowed>@IsLargeResultSetAllowed</IsLargeResultSetAllowed>
                    <LastEditedBy>@LastEditedBy</LastEditedBy>
                    <IsNoSearchNecessary>@IsNoSearchNecessary</IsNoSearchNecessary>
                    <ClientMatterCreationStep>@ClientMatterCreationStep</ClientMatterCreationStep>
                    <IsProspective_CCC>@IsProspective_CCC</IsProspective_CCC>
                </Attributes>
                <Children>
                    @AddCftNewBizSearchName
                    @AddCftSearch
                    @AddCftNewBizDateRange_CCC
                    @AddCftNewBizAddress_CCC
                </Children>
            </CftNewBizRequest>
        </Add>
";

        public static string AddCftNewBizSearchName = @"
        <CftNewBizSearchName>
            @AddCftNewBizSearchNameItem     
        </CftNewBizSearchName>

";

        public static string AddCftNewBizSearchNameItem = @"
        <Add>
            <CftNewBizSearchName>
                <Attributes>
                    <CftPartyType>@CftPartyType</CftPartyType>
                    <CftRelationshipCode>@CftRelationshipCode</CftRelationshipCode>
                    <SearchString>@SearchString</SearchString>
                    <EntityDisplayName>@EntityDisplayName</EntityDisplayName>
                    <UserModifiedSearchString>@UserModifiedSearchString</UserModifiedSearchString>
                    <FirstName>@FirstName</FirstName>
                    <MiddleName>@MiddleName</MiddleName>
                    <LastName>@LastName</LastName>
                    <CompanyName>@CompanyName</CompanyName>
                    <DebugInfo>@DebugInfo</DebugInfo>
                    <Entity>@EntityId</Entity>
                    <CftRole>@CftRole</CftRole>
                    <IsCreatedEntity>@IsCreatedEntity</IsCreatedEntity>
                    <AddedRelatedParty>@AddedRelatedParty</AddedRelatedParty>
                    <NumDuplicates>@NumDuplicates</NumDuplicates>
                    <RiskFlag>@RiskFlag</RiskFlag>
                    <DebugData>@DebugData</DebugData>
                    <Resolved>@Resolved</Resolved>
                    <CurEntityIndex>@CurEntityIndex</CurEntityIndex>
                    <LinkType>@LinkType</LinkType>
                    <Notes>@Notes</Notes>
                    <IsPhoneticSearch>@IsPhoneticSearch</IsPhoneticSearch>
                    <SortOrder>@SortOrder</SortOrder>
                    <IsClientAsSearchName>@IsClientAsSearchName</IsClientAsSearchName>
                    <IsNotSearch>@IsNotSearch</IsNotSearch>
                    <IsNotCreateLink>@IsNotCreateLink</IsNotCreateLink>
                    <SearchTerm>@SearchTerm</SearchTerm>
                    <CftEntityType>@CftEntityType</CftEntityType>
                    <CftRelatedParty>@CftRelatedParty</CftRelatedParty>
                    <FullTextSearchResultCount>@FullTextSearchResultCount</FullTextSearchResultCount>
                </Attributes>
            </CftNewBizSearchName>
        </Add>
";

        public static string AddCftSearch = @"
        <CftSearch>
            <Add>
                <CftSearch>
                    <Attributes>
                        <Description>@Description</Description>
                        <NumResults>@NumResults1</NumResults>
                        <DateRun>@DateRun</DateRun>
                        <Comments>@Comments</Comments>
                        <IsErrored>@IsErrored</IsErrored>
                        <OrigNumResults>@OrigNumResults</OrigNumResults>
                        <NumResultsLiteral>@NumResultsLiteral1</NumResultsLiteral>
                        <RanBy>@RanBy</RanBy>
                        <SimpleSearchTerms>@SimpleSearchTerms</SimpleSearchTerms>
                        <CurrentWorkflowStep>@CurrentWorkflowStep</CurrentWorkflowStep>
                        <ContinueWorkflow>@ContinueWorkflow</ContinueWorkflow>
                        <WorkflowEndReason>@WorkflowEndReason</WorkflowEndReason>
                        <ElapsedDataTime>@ElapsedDataTime</ElapsedDataTime>
                        <ElapsedSearchTime>@ElapsedSearchTime</ElapsedSearchTime>
                        <FinalDecision>@FinalDecision</FinalDecision>
                        <IsRouted>@IsRouted</IsRouted>
                        <DCSReportID>@DCSReportID</DCSReportID>
                        <DecisionBy>@DecisionBy</DecisionBy>
                        <DateRouted>@DateRouted</DateRouted>
                        <DateDecided>@DateDecided</DateDecided>
                        <IsSelectedResults>@IsSelectedResults</IsSelectedResults>
                        <isFiltersPopulated>@isFiltersPopulated</isFiltersPopulated>
                        <ParentId>@ParentId</ParentId>
                        <CftAuthority>@CftAuthority</CftAuthority>
                        <IsAccessToRoutedResults>@IsAccessToRoutedResults</IsAccessToRoutedResults>
                        <CftSearchTypeList>@CftSearchTypeList</CftSearchTypeList>
                        <IsPhoneticSearch>@IsPhoneticSearch</IsPhoneticSearch>
                        <NxBaseUser>@NxBaseUser</NxBaseUser>
                        <CftSearchAuthorityList>@CftSearchAuthorityList</CftSearchAuthorityList>
                        <CftSearchResultsViewList>@CftSearchResultsViewList</CftSearchResultsViewList>
                        <StepDate>@StepDate</StepDate>
                        <EstimatedNumResults>@EstimatedNumResults</EstimatedNumResults>
                        <IsProspectiveUnfiltered>@IsProspectiveUnfiltered</IsProspectiveUnfiltered>
                        <CopyDescription>@CopyDescription</CopyDescription>
                        <CopySavedDate>@CopySavedDate</CopySavedDate>
                        <CopySavedBy>@CopySavedBy</CopySavedBy>
                        <IsReadOnlyAccess>@IsReadOnlyAccess</IsReadOnlyAccess>
                        <LblDecisionReview2>@LblDecisionReview2</LblDecisionReview2>
                        <CurrentOwner>@CurrentOwner</CurrentOwner>
                        <DisplayCurrentOwner>@DisplayCurrentOwner</DisplayCurrentOwner>
                        <IsAllowReRouteAll>@IsAllowReRouteAll</IsAllowReRouteAll>
                        <IsRouteAllReleaseReciepient>@IsRouteAllReleaseReciepient</IsRouteAllReleaseReciepient>
                        <IsSearchReexecuted>@IsSearchReexecuted</IsSearchReexecuted>
                        <IsUnboundDataPopulated>@IsUnboundDataPopulated</IsUnboundDataPopulated>
                        <IsSearchForViewOnly>@IsSearchForViewOnly</IsSearchForViewOnly>
                        <IsRouteSelected>@IsRouteSelected</IsRouteSelected>
                        <MaxProcessedPageNumber>@MaxProcessedPageNumber</MaxProcessedPageNumber>
                        <IsViewAllPages>@IsViewAllPages</IsViewAllPages>
                        <RoutingBGStatus>@RoutingBGStatus</RoutingBGStatus>
                        <IsRoutingBG>@IsRoutingBG</IsRoutingBG>
                        <IsProcessAllPages>@IsProcessAllPages</IsProcessAllPages>
                        <UseHighlighting>@UseHighlighting</UseHighlighting>
                        <UseEquivalency>@UseEquivalency</UseEquivalency>
                    </Attributes>
                    <Children>
                        @AddCftSearchTerm
                    </Children>
                </CftSearch>
            </Add>
        </CftSearch>
";

        public static string AddCftSearchTerm = @"
        <CftSearchTerm>
            @AddCftSearchTermItem
        </CftSearchTerm>
";

        public static string AddCftSearchTermItem = @"
        <Add>
            <CftSearchTerm>
                <Attributes>
                    <SearchTerm>@SearchTerm1</SearchTerm>
                    <NumResults>@NumResults2</NumResults>
                    <Name>@Name</Name>
                    <IsErrored>@IsErrored</IsErrored>
                    <CftRelationshipCode>@CftRelationshipCode</CftRelationshipCode>
                    <SortOrder>@SortOrder</SortOrder>
                    <OrigNumResults>@OrigNumResults</OrigNumResults>
                    <NumResultsLiteral>@NumResultsLiteral2</NumResultsLiteral>
                    <CftRole>@CftRole</CftRole>
                    <RiskImage>@RiskImage</RiskImage>
                    <FullTextSearchRequestID>@FullTextSearchRequestID</FullTextSearchRequestID>
                    <ElapsedTotalTime>@ElapsedTotalTime</ElapsedTotalTime>
                    <ElapsedResultTime>@ElapsedResultTime</ElapsedResultTime>
                    <DateRun>@DateRun</DateRun>
                    <IsPhoneticSearch>@IsPhoneticSearch</IsPhoneticSearch>
                    <CftNewBizSearchName>@CftNewBizSearchName</CftNewBizSearchName>
                    <IsNotSearch>@IsNotSearch</IsNotSearch>
                    <IsNotCreateLink>@IsNotCreateLink</IsNotCreateLink>
                    <OrigSearchTerm>@OrigSearchTerm</OrigSearchTerm>
                    <SearchTerms>@SearchTerms</SearchTerms>
                    <EstimatedResultCount>@EstimatedResultCount</EstimatedResultCount>
                </Attributes>
            </CftSearchTerm>
        </Add>

";

        public static string AddCftNewBizDateRange_CCC = @"
        <CftNewBizDateRange_CCC>
            <Add>
                <CftNewBizDateRange_CCC>
                    <Attributes>
                        <DateOfOccurenceEnd>@DateOfOccurenceEnd</DateOfOccurenceEnd>
                        <DateOfOccurenceStart>@DateOfOccurenceStart</DateOfOccurenceStart>
                    </Attributes>
                </CftNewBizDateRange_CCC>
            </Add>
        </CftNewBizDateRange_CCC>
";

        public static string AddCftNewBizAddress_CCC = @"
         <CftNewBizAddress_CCC>
            <Add>
                <CftNewBizAddress_CCC>
                    <Attributes>
                        <City>@City</City>
                        <County>@County</County>
                        <Location>@Location</Location>
                        <ZipCode>@ZipCode</ZipCode>
                        <Country>@Country</Country>
                        <State>@State</State>
                        <ZipCodeLookup />
                    </Attributes>
                </CftNewBizAddress_CCC>
            </Add>
        </CftNewBizAddress_CCC>
";
    }
}
