using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TE3EConnect.te3eXML;
using TE3EConnect.te3eXML.NewBizIntake;

namespace TE3EConnect.te3eMappers.NewBizIntake
{
    public class CftNewBizIntakeMapper
    {
        public static string ConvertNewBizIntakeToXml(e3eCftNewBizIntake e3ECftNewBizIntake, e3eMode e3EMode = e3eMode.Add)
        {
            string cftNewBizIntakeXml = "";

            if (e3EMode == e3eMode.Add)
            {
                var addCftWFNewBizIntakeXml = ConvertAddCftWFNewBizIntakeXml(e3ECftNewBizIntake);
                cftNewBizIntakeXml = e3eCftWFNewBizIntakeXML.CftWFNewBizIntakeXml
                                                            .Replace("@AddCftWFNewBizIntakeXml", addCftWFNewBizIntakeXml)
                                                            .Replace("@EditCftWFNewBizIntakeXml", "");
            }
            else
            {
                cftNewBizIntakeXml = e3eCftWFNewBizIntakeXML.CftWFNewBizIntakeXml
                                                            .Replace("@AddCftWFNewBizIntakeXml", "")
                                                            .Replace("@EditCftWFNewBizIntakeXml", e3eCftWFNewBizIntakeXML.EditCftWFNewBizIntakeXml);

            }
            
            return cftNewBizIntakeXml;
        }

        private static string ConvertAddCftWFNewBizIntakeXml(e3eCftNewBizIntake e3ECftNewBizIntake)
        {
            string addCftWFNewBizIntakeXml = e3eCftWFNewBizIntakeXML.AddCftWFNewBizIntakeXml;
            string addCftNewBizRequest = ConvertAddCftNewBizRequest(e3ECftNewBizIntake);
            addCftWFNewBizIntakeXml = addCftWFNewBizIntakeXml.Replace("@AddCftNewBizRequest", addCftNewBizRequest);

            return addCftWFNewBizIntakeXml;
        }

        private static string ConvertAddCftNewBizRequest(e3eCftNewBizIntake e3ECftNewBizIntake)
        {
            string addCftNewBizRequest = e3eCftWFNewBizIntakeXML.AddCftNewBizRequest;
            addCftNewBizRequest = addCftNewBizRequest.Replace("@ClientId", e3ECftNewBizIntake.cftNewBizRequest.Client)
                                                     .Replace("@MatterId", e3ECftNewBizIntake.cftNewBizRequest.Matter)
                                                     .Replace("@RequestDateTime", e3ECftNewBizIntake.cftNewBizRequest.RequestDateTime)
                                                     .Replace("@CftSearchReason", e3ECftNewBizIntake.cftNewBizRequest.CftSearchReason)
                                                     .Replace("@Description", e3ECftNewBizIntake.cftNewBizRequest.Description)
                                                     .Replace("@CurrentSearchID", e3ECftNewBizIntake.cftNewBizRequest.CurrentSearchID)
                                                     .Replace("@IsCreatedMatter", e3ECftNewBizIntake.cftNewBizRequest.IsCreatedMatter)
                                                     .Replace("@IsCreatedClient", e3ECftNewBizIntake.cftNewBizRequest.IsCreatedClient)
                                                     .Replace("@StartTime", e3ECftNewBizIntake.cftNewBizRequest.StartTime)
                                                     .Replace("@CftNBRStatus", e3ECftNewBizIntake.cftNewBizRequest.CftNBRStatus)
                                                     .Replace("@CurrentWorkflowStep", e3ECftNewBizIntake.cftNewBizRequest.CurrentWorkflowStep)
                                                     .Replace("@OrgProc", e3ECftNewBizIntake.cftNewBizRequest.OrgProc)
                                                     .Replace("@ClientSearchNameId", e3ECftNewBizIntake.cftNewBizRequest.ClientSearchNameId)
                                                     .Replace("@Submitter", e3ECftNewBizIntake.cftNewBizRequest.Submitter)
                                                     .Replace("@FinalizeResult", e3ECftNewBizIntake.cftNewBizRequest.FinalizeResult)
                                                     .Replace("@DateRouted", e3ECftNewBizIntake.cftNewBizRequest.DateRouted)
                                                     .Replace("@DateDecided", e3ECftNewBizIntake.cftNewBizRequest.DateDecided)
                                                     .Replace("@DeclineReason", e3ECftNewBizIntake.cftNewBizRequest.DeclineReason)
                                                     .Replace("@DeclineComment", e3ECftNewBizIntake.cftNewBizRequest.DeclineComment)
                                                     .Replace("@DecidedBy", e3ECftNewBizIntake.cftNewBizRequest.DecidedBy)
                                                     .Replace("@LoadNumber", e3ECftNewBizIntake.cftNewBizRequest.LoadNumber)
                                                     .Replace("@LoadSource", e3ECftNewBizIntake.cftNewBizRequest.LoadSource)
                                                     .Replace("@LoadGroup", e3ECftNewBizIntake.cftNewBizRequest.LoadGroup)
                                                     .Replace("@LoadBatchID", e3ECftNewBizIntake.cftNewBizRequest.LoadBatchID)
                                                     .Replace("@LoadFlag", e3ECftNewBizIntake.cftNewBizRequest.LoadFlag)
                                                     .Replace("@CftSearchClient", e3ECftNewBizIntake.cftNewBizRequest.CftSearchClient)
                                                     .Replace("@CftResultView", e3ECftNewBizIntake.cftNewBizRequest.CftResultView)
                                                     .Replace("@FromCMCase", e3ECftNewBizIntake.cftNewBizRequest.FromCMCase)
                                                     .Replace("@CmCase", e3ECftNewBizIntake.cftNewBizRequest.CmCase)
                                                     .Replace("@AdminComments", e3ECftNewBizIntake.cftNewBizRequest.AdminComments)
                                                     .Replace("@IsNBIntake", e3ECftNewBizIntake.cftNewBizRequest.IsNBIntake)
                                                     .Replace("@EntityId", e3ECftNewBizIntake.cftNewBizRequest.Entity)
                                                     .Replace("@CreatedEntityIndex", e3ECftNewBizIntake.cftNewBizRequest.CreatedEntityIndex)
                                                     .Replace("@ClientMatterCreationRouteTo", e3ECftNewBizIntake.cftNewBizRequest.ClientMatterCreationRouteTo)
                                                     .Replace("@IsCurrentClientMatterCreationStep", e3ECftNewBizIntake.cftNewBizRequest.IsCurrentClientMatterCreationStep)
                                                     .Replace("@EstimatedNumResults", e3ECftNewBizIntake.cftNewBizRequest.EstimatedNumResults)
                                                     .Replace("@IsLargeResultSetAllowed", e3ECftNewBizIntake.cftNewBizRequest.IsLargeResultSetAllowed)
                                                     .Replace("@LastEditedBy", e3ECftNewBizIntake.cftNewBizRequest.LastEditedBy)
                                                     .Replace("@IsNoSearchNecessary", e3ECftNewBizIntake.cftNewBizRequest.IsNoSearchNecessary)
                                                     .Replace("@ClientMatterCreationStep", e3ECftNewBizIntake.cftNewBizRequest.ClientMatterCreationStep)
                                                     .Replace("@IsProspective_CCC", e3ECftNewBizIntake.cftNewBizRequest.IsProspective_CCC);

            //AddCftNewBizSearchName 
            addCftNewBizRequest = addCftNewBizRequest.Replace("@AddCftNewBizSearchName", e3eCftWFNewBizIntakeXML.AddCftNewBizSearchName);
            string addCftNewBizSearchName = ConvertAddCftNewBizSearchNameItem(e3ECftNewBizIntake);
            addCftNewBizRequest = addCftNewBizRequest.Replace("@AddCftNewBizSearchNameItem", addCftNewBizSearchName);

            //AddCftSearch - todo
            string addCftSearch = ConvertAddCftSearch(e3ECftNewBizIntake);
            addCftNewBizRequest = addCftNewBizRequest.Replace("@AddCftSearch", addCftSearch);

            //AddCftNewBizAddress_CCC - todo
            string addCftNewBizDateRange_CCC = ConvertAddCftNewBizDateRange_CCC(e3ECftNewBizIntake);
            addCftNewBizRequest = addCftNewBizRequest.Replace("@AddCftNewBizDateRange_CCC", addCftNewBizDateRange_CCC);

            //AddCftNewBizDateRange_CCC - todo
            string addCftNewBizAddress_CCC = ConvertAddCftNewBizAddress_CCC(e3ECftNewBizIntake);
            addCftNewBizRequest = addCftNewBizRequest.Replace("@AddCftNewBizAddress_CCC", addCftNewBizAddress_CCC);

            return addCftNewBizRequest;
        }

        private static string ConvertAddCftNewBizSearchNameItem(e3eCftNewBizIntake e3ECftNewBizIntake)
        {
            StringBuilder sb = new StringBuilder();
            //for loop
            e3ECftNewBizIntake.cftNewBizSearchNames.ForEach(x =>
            {
                string addCftNewBizSearchNameItem = e3eCftWFNewBizIntakeXML.AddCftNewBizSearchNameItem;
                addCftNewBizSearchNameItem = addCftNewBizSearchNameItem.Replace("@CftPartyType", x.CftPartyType)
                                                         .Replace("@CftRelationshipCode", x.CftRelationshipCode)
                                                         .Replace("@SearchString", x.SearchString)
                                                         .Replace("@EntityDisplayName", x.EntityDisplayName)
                                                         .Replace("@UserModifiedSearchString", x.UserModifiedSearchString)
                                                         .Replace("@FirstName", x.FirstName)
                                                         .Replace("@MiddleName", x.MiddleName)
                                                         .Replace("@LastName", x.LastName)
                                                         .Replace("@CompanyName", x.CompanyName)
                                                         .Replace("@DebugInfo", x.DebugInfo)
                                                         .Replace("@EntityId", x.Entity)
                                                         .Replace("@CftRole", x.CftRole)
                                                         .Replace("@IsCreatedEntity", x.IsCreatedEntity)
                                                         .Replace("@AddedRelatedParty", x.AddedRelatedParty)
                                                         .Replace("@NumDuplicates", x.NumDuplicates)
                                                         .Replace("@RiskFlag", x.RiskFlag)
                                                         .Replace("@DebugData", x.DebugData)
                                                         .Replace("@Resolved", x.Resolved)
                                                         .Replace("@CurEntityIndex", x.CurEntityIndex)
                                                         .Replace("@LinkType", x.LinkType)
                                                         .Replace("@Notes", x.Notes)
                                                         .Replace("@IsPhoneticSearch", x.IsPhoneticSearch)
                                                         .Replace("@SortOrder", x.SortOrder)
                                                         .Replace("@IsClientAsSearchName", x.IsClientAsSearchName)
                                                         .Replace("@IsNotSearch", x.IsNotSearch)
                                                         .Replace("@IsNotCreateLink", x.IsNotCreateLink)
                                                         .Replace("@SearchTerm", x.SearchTerm)
                                                         .Replace("@CftEntityType", x.CftEntityType)
                                                         .Replace("@CftRelatedParty", x.CftRelatedParty)
                                                         .Replace("@FullTextSearchResultCount", x.FullTextSearchResultCount);

                sb.AppendLine(addCftNewBizSearchNameItem);
            });
            

            //string addCftNewBizSearchName = e3eCftWFNewBizIntakeXML.AddCftNewBizSearchName;
            //addCftNewBizSearchName = addCftNewBizSearchName.Replace("@AddCftNewBizSearchNameItem", sb.ToString());

            return sb.ToString();
        }

        private static string ConvertAddCftSearch(e3eCftNewBizIntake e3ECftNewBizIntake)
        {
            //replace attr - todo
            string addCftSearch = e3eCftWFNewBizIntakeXML.AddCftSearch;
            addCftSearch = addCftSearch.Replace("@Description", e3ECftNewBizIntake.cftSearch.Description)
                                        .Replace("@NumResults1", e3ECftNewBizIntake.cftSearch.NumResults)
                                        .Replace("@DateRun", e3ECftNewBizIntake.cftSearch.DateRun)
                                        .Replace("@Comments", e3ECftNewBizIntake.cftSearch.Comments)
                                        .Replace("@IsErrored", e3ECftNewBizIntake.cftSearch.IsErrored)
                                        .Replace("@OrigNumResults", e3ECftNewBizIntake.cftSearch.OrigNumResults)
                                        .Replace("@NumResultsLiteral1", e3ECftNewBizIntake.cftSearch.NumResultsLiteral)
                                        .Replace("@RanBy", e3ECftNewBizIntake.cftSearch.RanBy)
                                        .Replace("@SimpleSearchTerms", e3ECftNewBizIntake.cftSearch.SimpleSearchTerms)
                                        .Replace("@CurrentWorkflowStep", e3ECftNewBizIntake.cftSearch.CurrentWorkflowStep)
                                        .Replace("@ContinueWorkflow", e3ECftNewBizIntake.cftSearch.ContinueWorkflow)
                                        .Replace("@WorkflowEndReason", e3ECftNewBizIntake.cftSearch.WorkflowEndReason)
                                        .Replace("@ElapsedDataTime", e3ECftNewBizIntake.cftSearch.ElapsedDataTime)
                                        .Replace("@ElapsedSearchTime", e3ECftNewBizIntake.cftSearch.ElapsedSearchTime)
                                        .Replace("@FinalDecision", e3ECftNewBizIntake.cftSearch.FinalDecision)
                                        .Replace("@IsRouted", e3ECftNewBizIntake.cftSearch.IsRouted)
                                        .Replace("@DCSReportID", e3ECftNewBizIntake.cftSearch.DCSReportID)
                                        .Replace("@DecisionBy", e3ECftNewBizIntake.cftSearch.DecisionBy)
                                        .Replace("@DateRouted", e3ECftNewBizIntake.cftSearch.DateRouted)
                                        .Replace("@DateDecided", e3ECftNewBizIntake.cftSearch.DateDecided)
                                        .Replace("@IsSelectedResults", e3ECftNewBizIntake.cftSearch.IsSelectedResults)
                                        .Replace("@isFiltersPopulated", e3ECftNewBizIntake.cftSearch.isFiltersPopulated)
                                        .Replace("@ParentId", e3ECftNewBizIntake.cftSearch.ParentId)
                                        .Replace("@CftAuthority", e3ECftNewBizIntake.cftSearch.CftAuthority)
                                        .Replace("@IsAccessToRoutedResults", e3ECftNewBizIntake.cftSearch.IsAccessToRoutedResults)
                                        .Replace("@CftSearchTypeList", e3ECftNewBizIntake.cftSearch.CftSearchTypeList)
                                        .Replace("@IsPhoneticSearch", e3ECftNewBizIntake.cftSearch.IsPhoneticSearch)
                                        .Replace("@NxBaseUser", e3ECftNewBizIntake.cftSearch.NxBaseUser)
                                        .Replace("@CftSearchAuthorityList", e3ECftNewBizIntake.cftSearch.CftSearchAuthorityList)
                                        .Replace("@CftSearchResultsViewList", e3ECftNewBizIntake.cftSearch.CftSearchResultsViewList)
                                        .Replace("@StepDate", e3ECftNewBizIntake.cftSearch.StepDate)
                                        .Replace("@EstimatedNumResults", e3ECftNewBizIntake.cftSearch.EstimatedNumResults)
                                        .Replace("@IsProspectiveUnfiltered", e3ECftNewBizIntake.cftSearch.IsProspectiveUnfiltered)
                                        .Replace("@CopyDescription", e3ECftNewBizIntake.cftSearch.CopyDescription)
                                        .Replace("@CopySavedDate", e3ECftNewBizIntake.cftSearch.CopySavedDate)
                                        .Replace("@CopySavedBy", e3ECftNewBizIntake.cftSearch.CopySavedBy)
                                        .Replace("@IsReadOnlyAccess", e3ECftNewBizIntake.cftSearch.IsReadOnlyAccess)
                                        .Replace("@LblDecisionReview2", e3ECftNewBizIntake.cftSearch.LblDecisionReview2)
                                        .Replace("@CurrentOwner", e3ECftNewBizIntake.cftSearch.CurrentOwner)
                                        .Replace("@DisplayCurrentOwner", e3ECftNewBizIntake.cftSearch.DisplayCurrentOwner)
                                        .Replace("@IsAllowReRouteAll", e3ECftNewBizIntake.cftSearch.IsAllowReRouteAll)
                                        .Replace("@IsRouteAllReleaseReciepient", e3ECftNewBizIntake.cftSearch.IsRouteAllReleaseReciepient)
                                        .Replace("@IsSearchReexecuted", e3ECftNewBizIntake.cftSearch.IsSearchReexecuted)
                                        .Replace("@IsUnboundDataPopulated", e3ECftNewBizIntake.cftSearch.IsUnboundDataPopulated)
                                        .Replace("@IsSearchForViewOnly", e3ECftNewBizIntake.cftSearch.IsSearchForViewOnly)
                                        .Replace("@IsRouteSelected", e3ECftNewBizIntake.cftSearch.IsRouteSelected)
                                        .Replace("@MaxProcessedPageNumber", e3ECftNewBizIntake.cftSearch.MaxProcessedPageNumber)
                                        .Replace("@IsViewAllPages", e3ECftNewBizIntake.cftSearch.IsViewAllPages)
                                        .Replace("@RoutingBGStatus", e3ECftNewBizIntake.cftSearch.RoutingBGStatus)
                                        .Replace("@IsRoutingBG", e3ECftNewBizIntake.cftSearch.IsRoutingBG)
                                        .Replace("@IsProcessAllPages", e3ECftNewBizIntake.cftSearch.IsProcessAllPages)
                                        .Replace("@UseHighlighting", e3ECftNewBizIntake.cftSearch.UseHighlighting)
                                        .Replace("@UseEquivalency", e3ECftNewBizIntake.cftSearch.UseEquivalency);
            

            //AddCftSearchTerm 
            string addCftSearchTerm = e3eCftWFNewBizIntakeXML.AddCftSearchTerm;
            string addCftSearchTermItem = ConvertAddCftSearchTermItem(e3ECftNewBizIntake);
            addCftSearchTerm = addCftSearchTerm.Replace("@AddCftSearchTermItem", addCftSearchTermItem);

            addCftSearch = addCftSearch.Replace("@AddCftSearchTerm", addCftSearchTerm);

            return addCftSearch;
        }

        private static string ConvertAddCftSearchTermItem(e3eCftNewBizIntake e3ECftNewBizIntake)
        {
            StringBuilder sb = new StringBuilder();

            e3ECftNewBizIntake.cftSearchTerms.ForEach(x =>
            {
                //for loop - todo
                string addCftSearchTermItem = e3eCftWFNewBizIntakeXML.AddCftSearchTermItem;
                //replace attr - todo
                addCftSearchTermItem = addCftSearchTermItem.Replace("@SearchTerm1", x.SearchTerm)
                                                         .Replace("@NumResults2", x.NumResults)
                                                         .Replace("@Name", x.Name)
                                                         .Replace("@IsErrored", x.IsErrored)
                                                         .Replace("@CftRelationshipCode", x.CftRelationshipCode)
                                                         .Replace("@SortOrder", x.SortOrder)
                                                         .Replace("@OrigNumResults", x.OrigNumResults)
                                                         .Replace("@NumResultsLiteral2", x.NumResultsLiteral)
                                                         .Replace("@CftRole", x.CftRole)
                                                         .Replace("@RiskImage", x.RiskImage)
                                                         .Replace("@FullTextSearchRequestID", x.FullTextSearchRequestID)
                                                         .Replace("@ElapsedTotalTime", x.ElapsedTotalTime)
                                                         .Replace("@ElapsedResultTime", x.ElapsedResultTime)
                                                         .Replace("@DateRun", x.DateRun)
                                                         .Replace("@IsPhoneticSearch", x.IsPhoneticSearch)
                                                         .Replace("@CftNewBizSearchName", x.CftNewBizSearchName)
                                                         .Replace("@IsNotSearch", x.IsNotSearch)
                                                         .Replace("@IsNotCreateLink", x.IsNotCreateLink)
                                                         .Replace("@OrigSearchTerm", x.OrigSearchTerm)
                                                         //.Replace("@Notes", x.not)
                                                         //.Replace("@IsClientAsSearchName", x.clie)
                                                         .Replace("@SearchTerms", x.SearchTerms)
                                                         .Replace("@EstimatedResultCount", x.EstimatedResultCount);

                sb.AppendLine(addCftSearchTermItem);
            });
                
            return sb.ToString();
        }

        private static string ConvertAddCftNewBizDateRange_CCC(e3eCftNewBizIntake e3ECftNewBizIntake)
        {
            string addCftNewBizDateRange_CCC = e3eCftWFNewBizIntakeXML.AddCftNewBizDateRange_CCC;
            //replact attr - todo
            addCftNewBizDateRange_CCC = addCftNewBizDateRange_CCC.Replace("@DateOfOccurenceEnd", e3ECftNewBizIntake.cftNewBizDateRange_CCC.DateOfOccurenceEnd)
                                                                 .Replace("@DateOfOccurenceStart", e3ECftNewBizIntake.cftNewBizDateRange_CCC.DateOfOccurenceStart);
            return addCftNewBizDateRange_CCC;
        }

        private static string ConvertAddCftNewBizAddress_CCC(e3eCftNewBizIntake e3ECftNewBizIntake)
        {
            string addCftNewBizAddress_CCC = e3eCftWFNewBizIntakeXML.AddCftNewBizAddress_CCC;
            //replact attr - todo
            addCftNewBizAddress_CCC = addCftNewBizAddress_CCC.Replace("@City", e3ECftNewBizIntake.cftNewBizAddress_CCC.City)
                                                             .Replace("@County", e3ECftNewBizIntake.cftNewBizAddress_CCC.County)
                                                             .Replace("@Location", e3ECftNewBizIntake.cftNewBizAddress_CCC.Location)
                                                             .Replace("@ZipCode", e3ECftNewBizIntake.cftNewBizAddress_CCC.ZipCode)
                                                             .Replace("@Country", e3ECftNewBizIntake.cftNewBizAddress_CCC.Country)
                                                             .Replace("@State", e3ECftNewBizIntake.cftNewBizAddress_CCC.State);

            return addCftNewBizAddress_CCC;
        }
    }
}
