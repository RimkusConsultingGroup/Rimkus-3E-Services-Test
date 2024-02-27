using System;
using System.Collections.Generic;
using System.Linq;
using TE3EConnect.te3eObjects.Automation;
using TE3EEntityFramework.Client.RCGKENTCMS;
using TE3EEntityFramework.Data.KenticoCMS.RCGKENTCMS;
using TE3EEntityFramework.Data.Te3e.CMS.CMS.Definition;
using TE3EEntityFramework.Data.Te3e.CMS.CustomException;
using TE3EEntityFramework.Data.Te3e.CMS.Definition;
using TE3EEntityFramework.Data.Te3e.Entity;
using TE3EEntityFramework.Datasource;
using TE3EEntityFramework.Datasource.RCGKENTCMS.DataModel;
using TE3EEntityFramework.Extension;

namespace TE3EConnect
{
    public class CMSWebClient
    {
        //private TE3ELoginInfo _tE3ELoginInfo;
        private CMSSQLClientV2 _te3ECmsClient;
        private int _sqlCommandTimeout;
        private EnvEnum envEnum;

        public CMSWebClient(int sqlCommandTimeout, EnvEnum _env = EnvEnum.DEV)
        {
            //_tE3ELoginInfo = tE3ELoginInfo;
            _sqlCommandTimeout = sqlCommandTimeout;
            envEnum = _env;
            _te3ECmsClient = new CMSSQLClientV2();
        }

        public List<CMSGetLookupCodes_Result> GetLookupCodes(int id)
        {
            var results = _te3ECmsClient.GetLookupCodes(id, _sqlCommandTimeout, envEnum);

            return results.ToList();
        }

        public List<CMSGetLookupTypes_Result> GetLookupTypes()
        {
            var results = _te3ECmsClient.GetLookupTypes(_sqlCommandTimeout, envEnum);

            return results.ToList();
        }

        public List<CMSGetClientsByType_Result> GetClientsByType(int id)
        {
            var results = _te3ECmsClient.GetClientsByType(id, _sqlCommandTimeout, envEnum);

            return results.ToList();
        }

        public List<CMSSearchClients_Result> GetClients(string name)
        {
            var results = _te3ECmsClient.GetClients(name, _sqlCommandTimeout, envEnum);

            return results.ToList();
        }

        public List<CMSSearchTimekeepers_Result> GetTimekeepers(string name)
        {
            var results = _te3ECmsClient.GetTimekeepers(name, _sqlCommandTimeout, envEnum);

            return results.ToList();
        }

        public List<CMSSearchEntity_Result> GetEntities(string name)
        {
            var results = _te3ECmsClient.GetEntities(name, _sqlCommandTimeout, envEnum);

            return results.ToList();
        }

        public List<CMSSearchRelMatters_Result> GetRelMatters(string name)
        {
            var results = _te3ECmsClient.GetRelMatters(name, _sqlCommandTimeout, envEnum);

            return results.ToList();
        }

        public AssignmentList GetClientMatters(int clientNo, int offset = 0, int limit = 50)
        {
            AssignmentList assignmentList = new AssignmentList();
            var matters = _te3ECmsClient.GetClientMatters(clientNo, _sqlCommandTimeout, envEnum);

            if (matters.Count() == 0)
                throw new CustomerNotFoundException($"Customer ID Not Found. No customer with ID = {clientNo.ToString("D7")}");

            //create paging
            assignmentList.TotalResultCount = matters.Count();
            assignmentList.FilteredResultCount = matters.Count();
            var pagedMatters = matters.OrderByDescending(c => c.StatusDate).Skip(offset).Take(limit);

            //need to translate to kentico json format
            assignmentList.Assignments = pagedMatters.Select(x =>
                new AssignmentListDetail
                {
                    //customer view
                    E3EId = Convert.ToInt32(x.MattIndex),
                    MatterNumber = x.MattNumber,
                    MatterTitle = x.MattName,
                    OrderingClientNumber = x.ClientNumber,
                    OrderingClientContactEmail = x.ContactEmail,
                    OrderingClientCompany = x.ClientName,
                    ClaimNumber = x.ClaimNo ?? "",
                    DateOfOccurrence = Convert.ToDateTime(x.OccurrenceDate?.ToUniversalTime()).ToString("yyyy-MM-ddT00:00:00"),
                    LocationOfOccurrence = x.OccurrenceLocation ?? "",
                    MatterStatus = x.CurrentStatus,
                    LatestNote = x.LatestNotes ?? "",
                    StatusDate = Convert.ToDateTime(x.StatusDate?.ToUniversalTime()).ToString("yyyy-MM-ddT00:00:00"),

                    //internal view
                    SubmissionID = "",
                    MatterType = x.MatterSection,
                    RequestDate = Convert.ToDateTime(x.TimeStamp?.ToUniversalTime()).ToString("yyyy-MM-ddT00:00:00"),
                    OrderingClientCity = x.OrderClientCompanyAddressCity ?? "",
                    OrderingClientState = x.OrderClientCompanyAddressState ?? "",
                    OrderingClientZip = x.OrderClientCompanyAddressZip ?? "",
                    OccurrenceCity = x.OccurrenceCity ?? "",
                    OccurrenceState = x.OccurrenceState ?? "",
                    OccurrenceZip = x.OccurrenceZipCode ?? ""
                }).ToList();

            return assignmentList;
        }

        public AssignmentList GetClientMattersByEmail(string email, int offset = 0, int limit = 50)
        {
            AssignmentList assignmentList = new AssignmentList();
            var matters = _te3ECmsClient.GetClientMattersByEmail(email, _sqlCommandTimeout, envEnum);

            //if (matters.Count() == 0)
            //    throw new CustomerNotFoundException($"Customer Not Found - {email}.");

            //create paging
            assignmentList.TotalResultCount = matters.Count();
            assignmentList.FilteredResultCount = matters.Count();
            var pagedMatters = matters.OrderByDescending(c => c.StatusDate).Skip(offset).Take(limit);

            //need to translate to kentico json format
            assignmentList.Assignments = pagedMatters.Select(x =>
                new AssignmentListDetail
                {
                    //customer view
                    E3EId = Convert.ToInt32(x.MattIndex),
                    MatterNumber = x.MattNumber,
                    MatterTitle = x.MattName,
                    OrderingClientNumber = x.ClientNumber,
                    OrderingClientContactEmail = x.ContactEmail,
                    OrderingClientCompany = x.ClientName,
                    ClaimNumber = x.ClaimNo ?? "",
                    DateOfOccurrence = Convert.ToDateTime(x.OccurrenceDate?.ToUniversalTime()).ToString("yyyy-MM-ddT00:00:00"),
                    LocationOfOccurrence = x.OccurrenceLocation ?? "",
                    MatterStatus = x.CurrentStatus,
                    LatestNote = x.LatestNotes ?? "",
                    StatusDate = Convert.ToDateTime(x.StatusDate?.ToUniversalTime()).ToString("yyyy-MM-ddT00:00:00"),

                    //internal view
                    SubmissionID = "",
                    MatterType = x.MatterSection,
                    RequestDate = Convert.ToDateTime(x.TimeStamp?.ToUniversalTime()).ToString("yyyy-MM-ddT00:00:00"),
                    OrderingClientCity = x.OrderClientCompanyAddressCity ?? "",
                    OrderingClientState = x.OrderClientCompanyAddressState ?? "",
                    OrderingClientZip = x.OrderClientCompanyAddressZip ?? "",
                    OccurrenceCity = x.OccurrenceCity ?? "",
                    OccurrenceState = x.OccurrenceState ?? "",
                    OccurrenceZip = x.OccurrenceZipCode ?? ""
                }).ToList();

            return assignmentList;
        }
        public AssignmentList GetAllClientMattersV3(string status, string search, string email, string clientNumber, string searchcolumn, string from, string to, int offset = 0, int limit = 50)
        {
            AssignmentList assignmentList = new AssignmentList();

            if (!string.IsNullOrEmpty(search))
            {
                search = search.ToLower().Trim();
                try
                {
                    search = Convert.ToDateTime(search).ToString("yyyy-MM-ddT00:00:00");
                }
                catch { }
            }

            var matters = _te3ECmsClient.GetAllClientMatters_V3(status, search, searchcolumn, from, to, email, clientNumber, offset, limit, out int totalCountOut, out int filteredCountOut, _sqlCommandTimeout, envEnum);

            assignmentList.TotalResultCount = totalCountOut;
            assignmentList.FilteredResultCount = filteredCountOut;
            var pagedMatters = matters.OrderByDescending(c => c.StatusDate);

            //need to translate to kentico json format
            assignmentList.Assignments = pagedMatters.Select(x =>
                new AssignmentListDetail
                {
                    //customer view
                    E3EId = Convert.ToInt32(x.MattIndex),
                    MatterNumber = x.MattNumber,
                    MatterTitle = x.MattName,
                    OrderingClientNumber = x.ClientNumber,
                    OrderingClientContactEmail = x.ContactEmail,
                    OrderingClientCompany = x.ClientName,
                    ClaimNumber = x.ClaimNo ?? "",
                    DateOfOccurrence = Convert.ToDateTime(x.OccurrenceDate?.ToUniversalTime()).ToString("yyyy-MM-ddT00:00:00"),
                    LocationOfOccurrence = x.OccurrenceLocation ?? "",
                    MatterStatus = x.CurrentStatus,
                    LatestNote = x.LatestNotes ?? "",
                    StatusDate = Convert.ToDateTime(x.StatusDate?.ToUniversalTime()).ToString("yyyy-MM-ddT00:00:00"),

                    //internal view
                    SubmissionID = "",
                    MatterType = x.MatterSection,
                    RequestDate = Convert.ToDateTime(x.TimeStamp?.ToUniversalTime()).ToString("yyyy-MM-ddT00:00:00"),
                    OrderingClientCity = x.OrderClientCompanyAddressCity ?? "",
                    OrderingClientState = x.OrderClientCompanyAddressState ?? "",
                    OrderingClientZip = x.OrderClientCompanyAddressZip ?? "",
                    OccurrenceCity = x.OccurrenceCity ?? "",
                    OccurrenceState = x.OccurrenceState ?? "",
                    OccurrenceZip = x.OccurrenceZipCode ?? "",
                    OpenTimeKeeper = x.OpenTkprName,
                    ResponsibleTimeKeeper = x.RespTkprName,
                    KenticoId = x.KenticoID
                }).ToList();

            return assignmentList;
        }

        public AssignmentDetail GetMatterDetails(int mattIndex, int clientNo = 0)
        {
            var matter = _te3ECmsClient.GetMatterDetails(mattIndex, _sqlCommandTimeout, envEnum);

            //if (matter.ClientNumber != clientNo.ToString("D7"))
            //    throw new CustomerNotMatchException($"Customer ID Not Match. No customer with ID = {clientNo.ToString("D7")}");

            //need to translate to kentico json format
            AssignmentDetail assignmentDetail = new AssignmentDetail
            {
                //customer view
                E3EId = Convert.ToInt32(matter.MattIndex),
                MatterNumber = matter.MattNumber,
                MatterTitle = matter.MattName,
                MatterStatus = matter.CurrentStatus,
                OrderingClientNumber = matter.ClientNumber,
                OrderingClientContactEmail = matter.OrderClientContactEmail,
                OrderingClientCompany = matter.ClientName,
                ClaimNumber = matter.ClaimNo ?? "",
                DateOfOccurrence = Convert.ToDateTime(matter.OccurrenceDate?.ToUniversalTime()).ToString("yyyy-MM-ddT00:00:00"),
                LocationOfOccurrence = matter.OccurrenceLocation ?? "",
                ProjectManager = matter.PMName ?? "",
                OfficePhone = matter.OfficePhone ?? "",
                CellPhone = matter.CellPhone ?? "",
                Email = matter.PMEmail ?? "",
                Budget = matter.BudgetAmount?.ToString() ?? "",
                KenticoId = matter.KenticoID
            };

            return assignmentDetail;
        }

        public Assignment GetFullMatterDetails(int mattIndex, int clientNo = 0)
        {
            Assignment assignment = CMSMapper.ConvertToCMSAssignment(mattIndex, _te3ECmsClient, _sqlCommandTimeout, envEnum);

            #region need to remove once tested
            //#region fetching full matter details
            ////get matter detail
            //var matter = _te3ECmsClient.GetFullMatterDetails(mattIndex, _sqlCommandTimeout, _isDebug);

            ////if (matter.ClientNumber != clientNo.ToString("D7"))
            ////    throw new CustomerNotMatchException($"Customer ID Not Match. No customer with ID = {clientNo.ToString("D7")}");

            ////get ordering client
            //var orderingClient = _te3ECmsClient.GetFullMatterOrderingClientDetails(mattIndex, _sqlCommandTimeout, _isDebug);

            ////get incident location
            //var incidentLocations = _te3ECmsClient.GetFullMatterIncidentLocationDetails(mattIndex, _sqlCommandTimeout, _isDebug);

            ////get coconsultants
            //var coConsultants = _te3ECmsClient.GetFullMatterCoConsultantDetails(mattIndex, _sqlCommandTimeout, _isDebug);

            ////get matter payor details
            //var matterPayorDet = _te3ECmsClient.GetFullMatterPayorDetails(mattIndex, _sqlCommandTimeout, _isDebug);

            ////get additional parties
            //var additionalParties = _te3ECmsClient.GetFullMatterAdditionalPartiesDetails(mattIndex, _sqlCommandTimeout, _isDebug);

            //#endregion fetching full matter details

            //#region map data fields to assignment
            ////map data fields to assignment
            //assignment.E3EID = matter.E3EID;
            //assignment.KenticoID = matter.KenticoID ?? "";
            //assignment.MatterStatus = matter.CurrentStatus;
            //assignment.MatterStatusID = matter.CurrentStatusCode;

            //#region Ordering Client Contact Section
            ////# Section: Client Contact
            ////FullNameParts fullNameParts = ParseFullname(orderingClient.OrderClientContactName);

            //assignment.OrderingClientContactSalutation = orderingClient.OrderingClientSalutation;
            //assignment.OrderingClientContactFirstName = orderingClient.OrderingClientContactFirstName;
            //assignment.OrderingClientContactLastName = orderingClient.OrderingClientContactLastName;
            //assignment.OrderingClientContactEmail = orderingClient.OrderingClientContactEmail ?? "";
            //assignment.OrderingClientContactPhoneNo = orderingClient.OrderingClientContactPhoneNo ?? "";
            //assignment.OrderingClientID = orderingClient.OrderingClientIndex?.ToString();
            //assignment.OrderingClientNumber = orderingClient.OrderingClientNumber;
            //#endregion Ordering Client Contact Section

            //#region Ordering Client Company Section
            ////# Section: Client Company
            //var cmsCliType = CMSMapper.ConvertToCMSCliType(_te3ECmsClient, orderingClient.OrderingClientCompanyType, _sqlCommandTimeout, _isDebug);

            //assignment.OrderingClientCompanyName = orderingClient.OrderingClientCompanyName;
            //assignment.OrderingClientCompanyAddress1 = orderingClient.OrderingClientCompanyAddress1 ?? "";
            //assignment.OrderingClientCompanyAddress2 = orderingClient.OrderingClientCompanyAddress2 ?? "";
            //assignment.OrderingClientCompanyAddressCity = orderingClient.OrderingClientCompanyAddressCity ?? "";
            //assignment.OrderingClientCompanyAddressState = orderingClient.OrderingClientCompanyAddressState ?? "";
            //assignment.OrderingClientCompanyAddressZip = orderingClient.OrderingClientCompanyAddressZip ?? "";
            //assignment.OrderingClientCompanyType = cmsCliType != null ? cmsCliType.Description : orderingClient.OrderingClientCompanyType;
            //assignment.OrderingClientCompanyAddressCountry = orderingClient.OrderingClientCompanyAddressCountry;
            //assignment.OrderingClientCompanyAddressLat = orderingClient.OrderingClientCompanyLatAddress?.ToString() ?? "";
            //assignment.OrderingClientCompanyAddressLon = orderingClient.OrderingClientCompanyLonAddress?.ToString() ?? "";
            //#endregion Ordering Client Company Section

            //#region Incident Information Section
            ////# Section: Incident Information
            //assignment.IncidentYN = Convert.ToDateTime(matter.DateOfOccurence?.ToUniversalTime()) != DateTime.MinValue;
            //assignment.DateOccurence = Convert.ToDateTime(matter.DateOfOccurence?.ToUniversalTime()).ToString("yyyy-MM-ddT00:00:00");
            //assignment.DateUnknown = Convert.ToDateTime(matter.DateOfOccurence?.ToUniversalTime()) == DateTime.MinValue;
            //assignment.DescOccurence = matter.Narrative_UnformattedText ?? "";
            //assignment.NeedAnswered = matter.ScopeOfWork ?? "";
            //assignment.SpecialInstructions = matter.SpecialInstructions;

            //assignment.IncidentLocations = new List<IncidentLocation>();
            //incidentLocations.ForEach(x =>
            //{
            //    IncidentLocation incidentLocation = new IncidentLocation();
            //    incidentLocation.SiteIndex = x.SiteID.ToString();
            //    incidentLocation.KenticoID = x.KenticoID;
            //    //incidentLocation.MattSiteID = x.MattSiteID.ToString();
            //    //incidentLocation.AddressID = x.AddressID.ToString();
            //    incidentLocation.StreetOccurence = x.StreetOccurrence ?? "";
            //    incidentLocation.CityOccurence = x.CityOccurrence ?? "";
            //    incidentLocation.StateOccurence = x.StateOccurrence ?? "";
            //    incidentLocation.ZipCodeOccurence = x.ZipCodeOccurrence ?? "";
            //    incidentLocation.CountyOccurence = x.CountyOccurrence ?? "";
            //    incidentLocation.CountryOccurence = x.CountryOccurrence ?? "";
            //    incidentLocation.LatOccurence = x.LatOccurrence?.ToString() ?? "";
            //    incidentLocation.LonOccurence = x.LonOccurrence?.ToString() ?? "";

            //    assignment.IncidentLocations.Add(incidentLocation);
            //});

            //#endregion Incident Information Section

            //#region info from client (obsolete) - not in use
            ////#region Insurance Section

            ////if (orderingClient.OrderClientCompanyType == ((int)CftRoleCodes.InsuranceCompany).ToString())
            ////{
            ////    var insOrderingClient = matterPayorDet.Where(x => x.ClientName == orderingClient.OrderClientCompanyName 
            ////                                                || x.PayorName == orderingClient.OrderClientCompanyName
            ////                                             ).Select(x => x).ToList();

            ////    #region Liberty Mutual soft-requirement 

            ////    if (orderingClient.OrderClientCompanyName.ToLower().Contains("Liberty Mutual".ToLower()))
            ////    {
            ////        assignment.LibertyInsuranceType = matter.InsuranceType;
            ////        assignment.LibertyClaimType = matter.ClaimType;
            ////    }

            ////    #endregion Liberty Mutual soft-requirement 

            ////    #region Reference Numbers
            ////    insOrderingClient.ForEach(x =>
            ////    {
            ////        assignment.ReferenceNumbers = new List<ReferenceNumber>();
            ////        if (!string.IsNullOrEmpty(x.ClaimNumber))
            ////        {
            ////            ReferenceNumber referenceNumber = new ReferenceNumber();
            ////            referenceNumber.E3EID = x.E3EID;
            ////            referenceNumber.KenticoID = x.KenticoID;
            ////            referenceNumber.Number = x.ClaimNumber;
            ////            referenceNumber.Type = TE3EEntityExt.GetEnumDescription(ReferenceNumberType.Claim);
            ////            assignment.ReferenceNumbers.Add(referenceNumber);
            ////        }

            ////        if (!string.IsNullOrEmpty(x.ReferenceNumber))
            ////        {
            ////            ReferenceNumber referenceNumber = new ReferenceNumber();
            ////            referenceNumber.E3EID = x.E3EID;
            ////            referenceNumber.KenticoID = x.KenticoID;
            ////            referenceNumber.Number = x.ReferenceNumber;
            ////            referenceNumber.Type = TE3EEntityExt.GetEnumDescription(ReferenceNumberType.Policy);
            ////            assignment.ReferenceNumbers.Add(referenceNumber);
            ////        }

            ////        if (!string.IsNullOrEmpty(x.PONumber))
            ////        {
            ////            ReferenceNumber referenceNumber = new ReferenceNumber();
            ////            referenceNumber.E3EID = x.E3EID;
            ////            referenceNumber.KenticoID = x.KenticoID;
            ////            referenceNumber.Number = x.PONumber;
            ////            referenceNumber.Type = TE3EEntityExt.GetEnumDescription(ReferenceNumberType.PO);
            ////            assignment.ReferenceNumbers.Add(referenceNumber);
            ////        }
            ////    });
            ////    #endregion Reference Numbers

            ////    #region Parties Involved

            ////    //individual
            ////    //var individualParty = matterPayorDet.Where(x => x.Role == ((int)CftRoleCodes.Individual).ToString()
            ////    //                                            && (x.Relationship != ((int)CftRelationship_CCC.Ordering).ToString()
            ////    //                                             && x.Relationship != ((int)CftRelationship_CCC.Both).ToString())
            ////    //                                          ).Select(x => x).ToList();

            ////    var individualParty = additionalParties.Where(x => x.ArchetypeCode == TE3EEntityExt.GetEnumDescription(TE3EConnect.te3eObjects.Automation.ArchetypeCode.EntityPerson)
            ////                                                    && x.Role == ((int)AdditionalPartiesRoles.Insured).ToString())
            ////                                           .Select(x => x).ToList();
            ////    //company or government entity
            ////    //var compOrGovParty = matterPayorDet.Where(x => (x.Role == ((int)CftRoleCodes.Corporation).ToString()
            ////    //                                        || x.Role == ((int)CftRoleCodes.GovernmentMunicipality).ToString())
            ////    //                                      && (x.Relationship != ((int)CftRelationship_CCC.Ordering).ToString()
            ////    //                                       && x.Relationship != ((int)CftRelationship_CCC.Both).ToString())
            ////    //                                    ).Select(x => x).ToList();

            ////    var compOrGovParty = additionalParties.Where(x => x.ArchetypeCode == TE3EEntityExt.GetEnumDescription(TE3EConnect.te3eObjects.Automation.ArchetypeCode.EntityOrg)
            ////                                                    && x.Role == ((int)AdditionalPartiesRoles.Insured).ToString())
            ////                                           .Select(x => x).ToList();
            ////    if (individualParty.Count() > 0)
            ////    {
            ////        var indvlPartyInvolved = individualParty.First();
            ////        var fullName = indvlPartyInvolved.PartyName.Split(' ');

            ////        assignment.InsFirstName = (fullName.Count() > 0) ? fullName.ElementAt(0) : ""; 
            ////        assignment.InsLastName = (fullName.Count() > 1) ? fullName.ElementAt(1) : "";
            ////        assignment.InsPOCNo = indvlPartyInvolved.HomePhone ?? "";
            ////    }
            ////    else if (compOrGovParty.Count() > 0)
            ////    {
            ////        var compOrGovPartyInvolved = compOrGovParty.First();

            ////        assignment.InsFirstName = compOrGovPartyInvolved.PartyName ?? "";
            ////        assignment.InsPOCNo = compOrGovPartyInvolved.HomePhone ?? "";
            ////        assignment.InsPOC = $"{orderingClient.OrderClientContactFirstName} {orderingClient.OrderClientContactLastName}";
            ////        assignment.InsNo = orderingClient.OrderClientContactPhoneNo ?? "";

            ////    }

            ////    /*
            ////     * Type of Insured	InsType	List - Individual, Company or Government Entity

            ////        If Insured is a Individual go to 38		
            ////        Insured First Name	Ins_First Name	
            ////        Insured Last Name	Ins_Last_Name	
            ////        Insured Phone Number (if contact required)	Ins_No.	3E Phone Format
            ////        End (Line 38-40) and Go to Line 48		

            ////        If Insured is a Company or Government Entity Go to Line 43		
            ////        Name of Insured	Ins_First_Name	
            ////        Name of Person to Contact (if contact required)	Ins_POC	
            ////        Point of Contact Phone Number (if contact required)	Ins_POC_No.	3E Phone Format
            ////        End (Line 43-45) and Go to Line 48		

            ////        Is there a claimant	ClaimantYN	Yes/No

            ////        If there is a Claimant go to Line 50, If No go to Line 65		
            ////        Type of Claimant	ClaimantTypeYN	List
            ////        If Claimant is a Individual Go to Line 52		
            ////        Cliamant First Name	Claimant_First_Name	
            ////        Claimant Last Name	Claimant_Last_Name	
            ////        Claimant Point of Contact Nme (if different than claimant and contact required)	ClaimantPOC	
            ////        Claimant Point of Contact Phone # (if contact required)	ClaimantPOC_No	
            ////        End (Line 52-55), Go to Line 62		

            ////        If Claimant is a Company or Government Entity Go to Line 58		
            ////        Name of Claimant	Claimant_First_Name	
            ////        Name of Person to Contact (if contact required)	ClaimantPOC	
            ////        Point of Contact Phone Number (if contact required)	ClaimantPOC_No	
            ////        End (line 58-60), Go to Line 62		
            ////        Additional Claimants?	 	Yes/No
            ////        If Response to Line 62 is "Yes", repeat go back to Line 50. If No go to Line 64		


            ////        If you hired an Independent/Outside Adjuster do you want us to correspond with them or you?		Me/Outside Adjuster/I did not hire an Independent Adjuster
            ////        If Line 64 is Independant Adjuster  Go to Line 66. If Me or I did not hire an Independent Adjuster go to Line 80		
            ////        Company Name	Outside_Comp_Name	
            ////        Adjuster First Name	Outside_First_Name	
            ////        Adjuster Last Name	Outside_Last_Name	

            ////        Address #1	Outside_Addr_#1	
            ////        Address #2	Outside_Addr_#2	
            ////        City	Outside_City	
            ////        State	Outside_State	3E State Format
            ////        Zip	Outside_Zip	3E Zip Format
            ////        Adjuster Email	Outside_Adj_Email	
            ////        Adjuster Phone #	Outside_Adj_Phone #	3E Phone Format
            ////        Do you want invoice sent to you or sent care of Independent Adjuster	 	List
            ////        End Line 66-77, Go To Line 80	 	

            ////        Is this is a multipayer file	MultiYN	
            ////        If Yes Go to Line 82.  If No go to Line 84		
            ////        How would you like us to handle invoicing of a multipayer file (i.e. send invoice to me, allocate %of invoice to each company in accordance to scehudlee, etc).  You can attach the schedule of Insurance here if you like.  	MultiHandle	
            ////        End (Line 82) Go to Line 84		
            ////        Any Other Special Invoice Handling Instructions you would like us to follow	SpecialInvoice	 
            ////        Go To Line 244		

            ////     */
            ////    #endregion Parties Involved
            ////}

            ////#endregion Insurance Section

            ////#region IA or TPA Section

            ////if (orderingClient.OrderClientCompanyType == ((int)CftRoleCodes.IndependentAdjusterIA).ToString()
            //// || orderingClient.OrderClientCompanyType == ((int)CftRoleCodes.ThirdPartyAdministratorTPA).ToString())
            ////{


            ////    var iATPAOrderClient = matterPayorDet.Where(x => (x.Role == ((int)CftRoleCodes.IndependentAdjusterIA).ToString()
            ////                                                   || x.Role == ((int)CftRoleCodes.ThirdPartyAdministratorTPA).ToString())
            ////                                                  && (x.Relationship == ((int)CftRelationship_CCC.Ordering).ToString()
            ////                                                   || x.Relationship == ((int)CftRelationship_CCC.Both).ToString())
            ////                                               ).Select(x => x).ToList();

            ////    //File # - Adj_File_No

            ////    #region Parties Involved
            ////    //Type of Insured - InsType
            ////    //If Insured is a Individual Go to Line 91
            ////    //Insured First Name Ins_First_Name
            ////    //Insured Last Name Ins_Last_Name
            ////    //Insured Phone Number(if contact required)	Ins_No.
            ////    //End(Line 91 - 93) and Go To Line 101

            ////    //If Insured is a Company or Government Entity Go to Line 96
            ////    //Name of Insured Ins_First_Name
            ////    //Name of Person to Contact if different than Insured(If contact required)   Ins_POC
            ////    //Insured or Point of Contact Phone Number(if contact required)	Ins_POC_No.
            ////    //End(Line 96 - 98) and Go To Line 101


            ////    //Is there a claimant?	ClaimantYN
            ////    //If there is a Claimant Go to Line 103, If No Go to Line 117.
            ////    //Type of Claimant ClaimCorpYN
            ////    //If Claimant is a Individual Go to Line 105
            ////    //Cliamant First Name Claimant_First_Name
            ////    //Claimant Last Name Claimant_Last_Name
            ////    //Claimant Point of Contact(if different than claimant and contact required)	ClaimantPOC
            ////    //Claimant Point of Contact or Claimant Phone # (if contact required)	ClaimantPOC_No
            ////    //End(line 105 - 108) Go to Line 115

            ////    //If Claimant is a Company or Government Entity Go to Line 111
            ////    //Name of Claimant Claimant_First_Name
            ////    //Name of Person to Contact ClaimantPOC
            ////    //Point of Contact Phone Number ClaimantPOC_No
            ////    //End(Line111 - 113), Go to Line 115
            ////    //Additional Claimants?	 
            ////    //If Response to Line 115 is "Yes", Go to Line 103.If not Go to Line 117

            ////    #region  Multipayor
            ////    /*
            ////     * If this is a multipayer file	MultiYN
            ////        If Yes Go to Line 119.  If no Go to Line 121	
            ////        How would you like us to handle invoicing of a multipayer file (i.e. send invoice to me, allocate %of invoice to each company in accordance to scehudlee, etc).  You can attach the schedule of Insurance here if you like.  	MultiHandle
            ////        End (Line 119) Go to Line 136	
            ////        Do you have payment authority to pay our invoice?	AuthYN
            ////        If No Go to Line 124, if yes Go to Line 136	

            ////        Claim # or Paying Organization Reference # (required)	Pay_#
            ////        Name of Organization paying invoice (required)	Pay_Name
            ////        Payor First Name (if applicable)	Pay_First_Name
            ////        Payor Last Name (if applicable)	Pay_Last_Name
            ////        Payor Phone Number	Pay_No
            ////        Payor Email	Pay_Email
            ////        Payor Address #1	Pay_Addr_1#
            ////        Payor Address #2	Pay_Addr_#2
            ////        Payor City	Pay_City
            ////        Payor State	Pay_State
            ////        Payor Zip	Pay_Zip
            ////        Would you like us to send the Invoice care of to you or directly to the client and copy you	CareOf
            ////        End (line 124-134) , Go to Line 136	
            ////        Any Other Special Invoice Handling Instructions you would like us to follow	SpecialInvoice

            ////     */
            ////    #endregion Multipayor

            ////    #endregion Parties Involved
            ////}

            ////#endregion IA or TPA Section

            ////#region Company or Government Section
            ////if (orderingClient.OrderClientCompanyType == ((int)CftRoleCodes.Corporation).ToString()
            //// || orderingClient.OrderClientCompanyType == ((int)CftRoleCodes.GovernmentMunicipality).ToString())
            ////{
            ////    var compGovernmentClient = matterPayorDet.Where(x => (x.Role == ((int)CftRoleCodes.Corporation).ToString()
            ////                                                 || x.Role == ((int)CftRoleCodes.GovernmentMunicipality).ToString())
            ////                                                && (x.Relationship == ((int)CftRelationship_CCC.Ordering).ToString()
            ////                                                 || x.Relationship == ((int)CftRelationship_CCC.Both).ToString())
            ////                                                   ).Select(x => x).ToList();

            ////    /*
            //// * Your File # or Other Reference # (If applicable)	File_No
            //// * 
            ////    Are you handling a claim	ClaimYN
            ////    If handling a claim go to Line 143, If No go to Line 177	

            //// */

            ////    //Parties Involved
            ////    /*
            ////     * Name of Insured	Ins_First_Name
            ////        End (Line 143) and Go To Line 146	

            ////        Is there a claimant?	ClaimantYN
            ////        If there is a Claimant Go to Line 148, If no go to Line 162. 	
            ////        Type of Claimant	ClaimType

            ////        If Claimant is a Individual Go to Line 150	
            ////        Claimant First Name	Claimant_First_Name
            ////        Claimant Last Name	Claimant_Last_Name
            ////        Claimant Point of Contact Name (if different than claimant and contact required)	ClaimantPOC
            ////        Claimant or Point of Contact Phone # (if contact required)	ClaimantPOC_No
            ////        End (line 150-153), Go to Line 160	

            ////        If Claimant is a Company or Government Entity Go to Line 156	
            ////        Name of Claimant	Claimant_First_Name
            ////        Name of Person to Contact	ClaimantPOC
            ////        Point of Contact Phone Number	ClaimantPOC#
            ////        End (line 156-158), Go to Line 160	

            ////        Additional Claimants?	 
            ////        If Response to Line 160 is "Yes", Go to Line 148 . If not go to Line 162	
            ////        Do you want us corresponding with a Outside Adjuster that you have hired in handling this assignment

            ////        If Line 162 is Yes, Go to Line 164, If No go to Line 177	
            ////        Company Name	Outside_Comp_Name
            ////        Adjuster First Name	Outside_First_Name
            ////        Adjuster Last Name	Outside_Last_Name

            ////        Address #1	Outside_Addr_#1
            ////        Address #2	Outside_Addr_#2
            ////        City	Outside_City
            ////        State	Outside_State
            ////        Zip	Outside_Zip
            ////        Adjuster Email	Outside_Adj_Email
            ////        Adjuster Phone #	Outside_Adj_Phone #
            ////        Do you want invoice sent to you or sent care of the Outside Adjuster	CareOf
            ////        End Line 164-175, Go To Line 177	
            ////        Any Other Special Invoice Handling Instructions you would like us to follow	SpecialInvoice


            ////     */
            ////}

            ////#endregion Company or Government Section

            ////#region Law Firm Section
            ////if (orderingClient.OrderClientCompanyType == ((int)CftRoleCodes.LawFirmDefendant).ToString()
            //// || orderingClient.OrderClientCompanyType == ((int)CftRoleCodes.LawFirmPlaintiff).ToString())
            ////{

            ////    var lawFirm = matterPayorDet.Where(x => (x.Role == ((int)CftRoleCodes.LawFirmDefendant).ToString()
            ////                                          || x.Role == ((int)CftRoleCodes.LawFirmPlaintiff).ToString())
            ////                                         && (x.Relationship == ((int)CftRelationship_CCC.Ordering).ToString()
            ////                                          || x.Relationship == ((int)CftRelationship_CCC.Both).ToString())
            ////                                      ).Select(x => x).ToList();

            ////    /*
            ////     * If Attorney in Line 1 Go to Line 183	

            ////        Your File # or Other Tracking Number (if applicable)	Atty_File_No
            ////        Paralegal or Legal Assistant First Name	Para_First_Name
            ////        Paralegal or Legal Assistant Last Name	Para_Last_Name
            ////        Are you representing defendant, plaintiff, subrogation or to early to know/NA	Rep_Type

            ////        Is your client a 	
            ////        If client Attorney represents is a Individual Go to Line 189, If No Go to Line 193	

            ////        Client First Name	Ins_First_Name
            ////        Client Last Name	Ins_Last_Name
            ////        Client Phone Number (if contact required)	Ins_POC_No.
            ////        End (Line 189-191)  Go To Line 198	

            ////        If client Attorney represents is a Company or Government Entity Go to Line 194, If No Go to Line 198	
            ////        Name of Client	Ins_First_Name
            ////        Name of Person to Contact (if contact required)	Ins_POC
            ////        Point of Contact Phone Number (if contact required)	Ins_No.
            ////        End (Line 194-196).  Go To Line 198	

            ////        Is there an opposing law firm	OpposingYN
            ////        If there is an Opposing Law Firm Go To Line 200, If No Go to Line 216	

            ////        Opposing Party Law Firm Name	Opp_Name
            ////        Opposing Law Firm Attorney First Name	Opp_Atty_First_Name
            ////        Opposing Law Firm Attorney Last Name	Opp_Atty_Last_Name
            ////        Opposing Law Firm Address #1	Opp_Street_Addr_#1
            ////        Opposing Law Firm Address #2	Opp_Street_Addr_#2
            ////        Opposing Law Firm City	Opp_City
            ////        Opposing Law Firm State	Opp_State
            ////        Opposing Law Firm Zip	Opp_Zip

            ////        Is Opposing Attorney's client an Individual, company or government entity	Opp_Client_Type

            ////        If Opposing Attorney represents is a Individual Go to Line 210	
            ////        Opposing Attorney's Client First Name	Claimant_First_Name
            ////        Opposing Attorney's Client Last Name	Claimant_Last_Name
            ////        End (Line 210-211).  Go To Line 216	

            ////        If Opposing Attorney represents a Company or Government Entity Go to Line 214	
            ////        Name Opposing Attorney's Client	Claimant_First_Name
            ////        End (Line 214).  Go To Line 216	

            ////        Are there more Opposing Parties	 
            ////        If there are more Opposing Parties Go to Line 200, If No Go to Line 218	
            ////        Has Suit been Filed	SuitYN

            ////        If Suit has been filed Go to Line 219, If No go to Line 224	
            ////        Cause #	Cause#
            ////        Court	Court
            ////        Style	Style
            ////        End (Line 220 - 222), Go to Line 224	

            ////        Do you or your law firm have payment authority to pay our invoice?	AuthYN
            ////        If Yes go to Line 238.  If no go to Line 226	

            ////        Claim # or Paying Organization Reference # 	Pay_#
            ////        Name of Organization paying invoice (required)	Pay_Name
            ////        Payor First Name (if applicable)	Pay_First_Name
            ////        Payor Last Name (if applicable)	Pay_Last_Name
            ////        Payor Phone Number	Pay_No
            ////        Payor Address #1	Pay_Addr_#1
            ////        Payor Address #2	Pay_Addr_#2
            ////        Payor City	Pay_City
            ////        Payor State	Pay_State
            ////        Payor Zip	Pay_Zip

            ////        Would You Like us to send the Invoive Care of to you or directly to the payor and copy you	CareOf
            ////        End (Line 226-236), Go to Line 238	
            ////        Any Special Invoice Handling Instructions you would like us to follow	SpecialInvoice

            ////     */
            ////}

            ////#endregion Law Firm Section
            //#endregion info from client (obsolete) - not in use

            //#region Combined Fields - in use

            //#region Adjuster Information

            ////AdjusterType = Outside Adjuster
            //var adjuster = matterPayorDet.Where(x => x.RelationshipDesc == TE3EEntityExt.GetEnumDescription(CftRelationship_CCC.Ordering) 
            //                                      && x.RoleDesc == TE3EEntityExt.GetEnumDescription(CftRoleCodes.AdjustmentFirm))
            //                             .Select(x => x).ToList();

            //if (adjuster.Count() > 0)
            //{
            //    var outsideAdj = adjuster.First();

            //    assignment.AdjusterType = CMSMapper.ConvertToCMSAdjusterType(outsideAdj.RoleDesc, Convert.ToBoolean(outsideAdj.PaymentAuthority)); //I am the adjuster, Outside adjuster, I did not hire an adjuster
            //    assignment.AuthYN = Convert.ToBoolean(outsideAdj.PaymentAuthority); //outsideAdj.RoleDesc.Equals("I am the Adjuster", StringComparison.OrdinalIgnoreCase);
            //    assignment.OutsideCompName = outsideAdj.PayorName;
            //    assignment.OutsideFirstName = outsideAdj.FirstName;
            //    assignment.OutsideLastName = outsideAdj.LastName;
            //    assignment.OutsideAdjEmail = outsideAdj.Email ?? "";
            //    assignment.OutsideAdjPhone = outsideAdj.PhoneNumber ?? "";
            //    assignment.AdjusterInvoicing = matter.SpecialInstructions ?? ""; //matterspecialinstructions_CCC

            //    assignment.OutsideAddr1 = outsideAdj.Street ?? "";
            //    assignment.OutsideAddr2 = "";
            //    assignment.OutsideCity = outsideAdj.City ?? "";
            //    assignment.OutsideState = outsideAdj.State ?? "";
            //    assignment.OutsideZip = outsideAdj.ZipCode ?? "";
            //    assignment.OutsideCountry = outsideAdj.Country ?? "";

            //    assignment.SpecialInstructions = matter.SpecialInstructions ?? "";
            //}

            //#endregion Adjuster Information

            //#region Legal Information [Only show if OrderClientCompanyType = Attorney]

            //if (orderingClient.OrderingClientCompanyType == TE3EEntityExt.GetEnumDescription(CftRoleCodes.LawFirmPlaintiff)
            //  || orderingClient.OrderingClientCompanyType == TE3EEntityExt.GetEnumDescription(CftRoleCodes.LawFirmDefendant))
            //{
            //    //var addInstr = orderingClient.OrderClientAdditionalInstr.Split(',').Where(x => !string.IsNullOrEmpty(x)).Select(x => x.Trim()).ToList();

            //    assignment.ParaFirstName = orderingClient.OrderingClientAdditionalInstr ?? ""; //orderingClient.OrderClientAdditionalInstr
            //    assignment.ParaLastName = "";
            //    assignment.RepType = orderingClient.RepresentingDesc ?? "";

            //    //todo: 
            //    //Individual, Company, Government Entity (equivalent to entityperson = individual, entityorg = company and gov entity
            //    assignment.Style = orderingClient.Style ?? "";
            //    assignment.Court = orderingClient.Court ?? "";
            //    assignment.CauseNumber = orderingClient.CauseNumber ?? "";
            //    assignment.SuitYN = !string.IsNullOrEmpty(assignment.CauseNumber);


            //    #region Legal Information [Only show if LegalClientType = Individual;]
            //    var individualInsParty = additionalParties.Where(x => x.ArchetypeCode == TE3EEntityExt.GetEnumDescription(TE3EEntityFramework.Data.KenticoCMS.RCGKENTCMS.ArchetypeCode.EntityPerson)
            //                                                    && x.Role == ((int)AdditionalPartiesRoles.Insured).ToString())
            //                                           .Select(x => x).ToList();

            //    if (individualInsParty.Count() > 0)
            //    {
            //        CMSGetFullMatterAdditionalPartiesDetails_Result indvlInsPartyInvolved = individualInsParty.First();

            //        assignment.LegalClientType = TE3EEntityExt.GetEnumDescription(CMSLegalOrAttyType.Individual);
            //        assignment.InsFirstName = indvlInsPartyInvolved.FirstName;
            //        assignment.InsLastName = indvlInsPartyInvolved.LastName;
            //        assignment.InsPOCNo = indvlInsPartyInvolved.HomePhone ?? "";
            //    }

            //    #endregion Legal Information [Only show if LegalClientType = Individual;]

            //    #region Legal Information [Only show if LegalClientType != Individual;] - company or government entity
            //    var compOrGovInsParty = additionalParties.Where(x => x.ArchetypeCode == TE3EEntityExt.GetEnumDescription(TE3EEntityFramework.Data.KenticoCMS.RCGKENTCMS.ArchetypeCode.EntityOrg)
            //                                                    && x.Role == ((int)AdditionalPartiesRoles.Insured).ToString())
            //                                           .Select(x => x).ToList();
            //    if (compOrGovInsParty.Count() > 0)
            //    {
            //        CMSGetFullMatterAdditionalPartiesDetails_Result compOrGovInsPartyInvolved = compOrGovInsParty.First();

            //        assignment.LegalClientType = TE3EEntityExt.GetEnumDescription(CMSLegalOrAttyType.Company);
            //        assignment.InsClientName = compOrGovInsPartyInvolved.PartyName ?? "";
            //        assignment.InsLegalPOCNo = compOrGovInsPartyInvolved.HomePhone ?? "";
            //        assignment.InsLegalPOC = $"{orderingClient.OrderingClientContactFirstName} {orderingClient.OrderingClientContactLastName}";
            //        assignment.InsNo = orderingClient.OrderingClientContactPhoneNo ?? "";
            //    }
            //    #endregion Legal Information [Only show if LegalClientType != Individual;] - company or government entity
            //}
            //#endregion Legal Information [Only show if OrderClientCompanyType = Attorney]

            //#region Opposing Party Law Firm
            //var opposingPartyLawFirm = matterPayorDet.Where(x => Convert.ToInt32(x.Relationship) == (int)CftRelationship_CCC.Against).Select(x => x).ToList();
            //if (opposingPartyLawFirm.Count() > 0)
            //{
            //    var oppParty = opposingPartyLawFirm.First();

            //    assignment.OpposingYN = true;
            //    assignment.OppName = oppParty.PayorName;
            //    assignment.OppAttyFirstName = oppParty.FirstName;
            //    assignment.OppAttyLastName = oppParty.LastName;
            //    assignment.OppStreetAddr1 = oppParty.Street ?? "";
            //    assignment.OppStreetAddr2 = "";
            //    assignment.OppCity = oppParty.City ?? "";
            //    assignment.OppState = oppParty.State ?? "";
            //    assignment.OppZip = oppParty.ZipCode ?? "";
            //    assignment.OppCountry = oppParty.Country ?? "";

            //    assignment.OpposingParties = new List<OpposingParty>();
            //    var plantiffOpposingParty = oppParty.RoleDesc.Contains("Plaintiff");
            //    var defendantOpposingParty = oppParty.RoleDesc.Contains("Defendant");

            //    if(plantiffOpposingParty)
            //    {
            //        var opposingParties = additionalParties.Where(x => x.RoleDesc == "Plaintiff").Select(x => x).ToList();

            //        opposingParties.ForEach(x =>
            //        {
            //            OpposingParty opposingParty = new OpposingParty();
            //            opposingParty.EntityIndex = x.EntityIndex?.ToString() ?? "";
            //            opposingParty.AttorneysClientType = x.RoleDesc;
            //            opposingParty.OpposingAttorneysClientName = x.PartyName;
            //            assignment.OpposingParties.Add(opposingParty);
            //        });
            //    }
            //    else if(defendantOpposingParty)
            //    {
            //        var opposingParties = additionalParties.Where(x => x.RoleDesc == "Defendant").Select(x => x).ToList();

            //        opposingParties.ForEach(x =>
            //        {
            //            OpposingParty opposingParty = new OpposingParty();
            //            opposingParty.EntityIndex = x.EntityIndex?.ToString() ?? "";
            //            opposingParty.AttorneysClientType = x.RoleDesc;
            //            opposingParty.OpposingAttorneysClientName = x.PartyName;
            //            assignment.OpposingParties.Add(opposingParty);
            //        });
            //    }

            //}
            //#endregion Opposing Party Law Firm

            //#region Parties (Additional Parties)
            //assignment.Parties = new List<Party>();

            //additionalParties.ForEach(x =>
            //{
            //    if(!assignment.OpposingParties.Any(o => o.EntityIndex == x.EntityIndex.ToString()))
            //    {
            //        Party party = new Party();
            //        party.EntityIndex = x.EntityIndex?.ToString() ?? "";
            //        party.EntityType = x.EntityTypeDesc ?? "";
            //        party.PartyType = x.RoleDesc;

            //        if (x.ArchetypeCode == TE3EEntityExt.GetEnumDescription(TE3EEntityFramework.Data.KenticoCMS.RCGKENTCMS.ArchetypeCode.EntityPerson))
            //        {
            //            party.FirstName = x.FirstName;
            //            party.LastName = x.LastName;
            //        }
            //        else
            //        {
            //            party.CompanyName = x.PartyName;
            //            party.ContactName = "";
            //        }

            //        if(!string.IsNullOrEmpty(x.HomePhone))
            //            party.Phone = x.HomePhone;
            //        else if (!string.IsNullOrEmpty(x.WorkPhone))
            //            party.Phone = x.WorkPhone;
            //        else if (!string.IsNullOrEmpty(x.MobilePhone))
            //            party.Phone = x.MobilePhone;

            //        assignment.Parties.Add(party);
            //    }
            //});

            //#endregion Parties (Additional Parties)

            //#region CoConsultants
            ////check if there's coconsultant
            //assignment.CoConsultantsYN = coConsultants.Count() > 0;
            //assignment.CoConsultants = new List<CoConsultant>();
            //coConsultants.ForEach(x =>
            //{
            //    CoConsultant coConsultant = new CoConsultant();
            //    coConsultant.CoConsultantIndex = x.CoConsultantIndex.ToString();
            //    coConsultant.CoConsultantName = x.CoConsultantName ?? "";
            //    coConsultant.CoConsultantNumber = x.CoConsultantNumber.ToString() ?? "";

            //    assignment.CoConsultants.Add(coConsultant);
            //});

            //#endregion CoConsultants

            //#region Multipayor Information

            //var multiPayors = matterPayorDet.Where(x => Convert.ToDouble(x.PercentFee?.ToString() ?? "0") < 100.0)
            //                           .Select(x => x).ToList();

            //assignment.MultipayorYN = multiPayors.Count() > 1;
            //assignment.MultipayorInvoicing = assignment.MultipayorYN ?? false ? (matter.SpecialInstructions ?? "") : "";

            //assignment.Payors = new List<Payor>();
            //matterPayorDet.OrderByDescending(x => x.PercentFee).ToList().ForEach(x =>
            //{
            //    Payor payor = new Payor();
            //    payor.PayorIndex = x.PayorIndex.ToString();
            //    payor.PayRole = x.RoleDesc;
            //    payor.PayAddr1 = x.Street ?? "";
            //    payor.PayCity = x.City ?? "";
            //    payor.PayState = x.State ?? "";
            //    payor.PayZip = x.ZipCode ?? "";
            //    payor.PayFirstName = x.FirstName ?? "";
            //    payor.PayLastName = x.LastName ?? "";
            //    payor.PayName = x.PayorName ?? "";
            //    payor.PayEmail = x.Email ?? "";
            //    payor.PayPhone = x.PhoneNumber ?? "";
            //    payor.PayCountry = x.Country ?? "";
            //    payor.PayLat = x.LatAddress?.ToString() ?? "";
            //    payor.PayLon = x.LonAddress?.ToString() ?? "";
            //    payor.ReferenceNumber = x.ReferenceNumber ?? "";
            //    payor.CareOf = $"{matter.SpecialInstructions ?? ""}";
            //    payor.InvoicePercentage = x.PercentFee?.ToString();
            //    assignment.Payors.Add(payor);
            //});

            //#endregion  Multipayor Information

            //#region Reference Numbers 

            //assignment.LibertyInsuranceType = matter.InsuranceType ?? "";
            //assignment.LibertyClaimType = matter.ClaimType ?? "";

            //#region Populating Reference Numbers

            //matterPayorDet.ForEach(x =>
            //{
            //    //only populate for ordering client
            //    if (x.ClientIndex == orderingClient.OrderingClientIndex)
            //    {
            //        assignment.ReferenceNumbers = new List<ReferenceNumber>();

            //        if (!string.IsNullOrEmpty(x.ClaimNumber))
            //        {
            //            ReferenceNumber referenceNumber = new ReferenceNumber();
            //            referenceNumber.ReferenceIndex = _te3ECmsClient.GetRefNumberID(TE3EEntityExt.GetEnumDescription(ReferenceNumberType.Claim), _sqlCommandTimeout, _isDebug).ToString();
            //            referenceNumber.Number = x.ClaimNumber;
            //            referenceNumber.IncludeForBilling = false; //no fields in 3e - need to create new field on payor detail
            //            referenceNumber.Type = TE3EEntityExt.GetEnumDescription(ReferenceNumberType.Claim);
            //            assignment.ReferenceNumbers.Add(referenceNumber);
            //        }

            //        if (!string.IsNullOrEmpty(x.ReferenceNumber))
            //        {
            //            ReferenceNumber referenceNumber = new ReferenceNumber();
            //            referenceNumber.ReferenceIndex = _te3ECmsClient.GetRefNumberID(TE3EEntityExt.GetEnumDescription(ReferenceNumberType.Reference), _sqlCommandTimeout, _isDebug).ToString();
            //            referenceNumber.Number = x.ReferenceNumber;
            //            referenceNumber.IncludeForBilling = false; //no fields in 3e - need to create new field on payor detail
            //            referenceNumber.Type = TE3EEntityExt.GetEnumDescription(ReferenceNumberType.Reference);
            //            assignment.ReferenceNumbers.Add(referenceNumber);
            //        }

            //        if (!string.IsNullOrEmpty(x.Policy_CCC))
            //        {
            //            ReferenceNumber referenceNumber = new ReferenceNumber();
            //            referenceNumber.ReferenceIndex = _te3ECmsClient.GetRefNumberID(TE3EEntityExt.GetEnumDescription(ReferenceNumberType.Policy), _sqlCommandTimeout, _isDebug).ToString();
            //            referenceNumber.Number = x.Policy_CCC;
            //            referenceNumber.IncludeForBilling = false; //no fields in 3e - need to create new field on payor detail
            //            referenceNumber.Type = TE3EEntityExt.GetEnumDescription(ReferenceNumberType.Policy);
            //            assignment.ReferenceNumbers.Add(referenceNumber);
            //        }

            //        if (!string.IsNullOrEmpty(x.File_CCC))
            //        {
            //            ReferenceNumber referenceNumber = new ReferenceNumber();
            //            referenceNumber.ReferenceIndex = _te3ECmsClient.GetRefNumberID(TE3EEntityExt.GetEnumDescription(ReferenceNumberType.File), _sqlCommandTimeout, _isDebug).ToString();
            //            referenceNumber.Number = x.File_CCC;
            //            referenceNumber.IncludeForBilling = false; //no fields in 3e - need to create new field on payor detail
            //            referenceNumber.Type = TE3EEntityExt.GetEnumDescription(ReferenceNumberType.File);
            //            assignment.ReferenceNumbers.Add(referenceNumber);
            //        }

            //        if (!string.IsNullOrEmpty(x.UMR_CCC))
            //        {
            //            ReferenceNumber referenceNumber = new ReferenceNumber();
            //            referenceNumber.ReferenceIndex = _te3ECmsClient.GetRefNumberID(TE3EEntityExt.GetEnumDescription(ReferenceNumberType.UMR), _sqlCommandTimeout, _isDebug).ToString();
            //            referenceNumber.Number = x.UMR_CCC;
            //            referenceNumber.IncludeForBilling = false; //no fields in 3e - need to create new field on payor detail
            //            referenceNumber.Type = TE3EEntityExt.GetEnumDescription(ReferenceNumberType.UMR);
            //            assignment.ReferenceNumbers.Add(referenceNumber);
            //        }

            //        if (!string.IsNullOrEmpty(x.Tracking_CCC))
            //        {
            //            ReferenceNumber referenceNumber = new ReferenceNumber();
            //            referenceNumber.ReferenceIndex = _te3ECmsClient.GetRefNumberID(TE3EEntityExt.GetEnumDescription(ReferenceNumberType.Tracking), _sqlCommandTimeout, _isDebug).ToString();
            //            referenceNumber.Number = x.Tracking_CCC;
            //            referenceNumber.IncludeForBilling = false; //no fields in 3e - need to create new field on payor detail
            //            referenceNumber.Type = TE3EEntityExt.GetEnumDescription(ReferenceNumberType.Tracking);
            //            assignment.ReferenceNumbers.Add(referenceNumber);
            //        }

            //        if (!string.IsNullOrEmpty(x.PONumber))
            //        {
            //            ReferenceNumber referenceNumber = new ReferenceNumber();
            //            referenceNumber.ReferenceIndex = _te3ECmsClient.GetRefNumberID(TE3EEntityExt.GetEnumDescription(ReferenceNumberType.PO), _sqlCommandTimeout, _isDebug).ToString();
            //            referenceNumber.Number = x.PONumber;
            //            referenceNumber.Type = TE3EEntityExt.GetEnumDescription(ReferenceNumberType.PO);
            //            referenceNumber.IncludeForBilling = false; //no fields in 3e - need to create new field on payor detail
            //            assignment.ReferenceNumbers.Add(referenceNumber);
            //        }
            //    }
            //});

            //#endregion Populating Reference Numbers

            //#endregion Reference Numbers

            //#endregion Combined Fields - in use

            ////# Section: Invoice Instructions
            //assignment.SpecialInvoice = matter.InvoiceTo ?? "";

            //#region Internal Use Only Section
            ////# Section: Internal Use Only=
            //assignment.MatterName = matter.MattName;
            //assignment.MatterNumber = matter.MattNumber;
            //assignment.RelatedMatter = matter.RelatedMatter?.ToString() ?? "";
            //assignment.Currency = matter.Currency;
            //assignment.OpenTimekeeper = matter.OpenTimekeeperName;
            //assignment.RetainerAmount = matter.RetainerAmount?.ToString() ?? "";
            //assignment.FixedPrice = matter.FixedPrice == 1;
            //assignment.DneNotes = matter.DNENotes ?? "";
            //assignment.WebOriginated = matter.WebOriginated == 1;
            //assignment.FeesTaxCode = matter.FeesTaxCode ?? "";
            //assignment.EntryDate = Convert.ToDateTime(matter.EntryDate?.ToUniversalTime()).ToString("yyyy-MM-ddT00:00:00");
            //assignment.EBilling = matter.EBilling == 1;
            //assignment.EBillingType = matter.ElecBillingType ?? "";
            //assignment.ElectronicNumber = matter.ElectronicNumber ?? "";
            //assignment.ConfirmationLetterType = GetConfirmationLetterType(matter);
            //assignment.RofTemplate = matter.ROFTemplateDesc?.ToString() ?? "";
            //assignment.StartDate1 = Convert.ToDateTime(matter.StartDate1?.ToUniversalTime()).ToString("yyyy-MM-ddT00:00:00");
            //assignment.BillingTimekeeper = matter.BillingTimekeeperName;
            //assignment.ResponsibleTimekeeper = matter.ResponsibleTimekeeperName;
            //assignment.SupervisingTimekeeper = matter.SupervisorTimekeeperName;
            //assignment.Office = matter.OfficeName;
            //assignment.Section = matter.SectionDesc;
            //assignment.Arrangement = matter.ArrangementDesc;
            //assignment.Department = matter.DepartmentDesc;
            //assignment.PracticeGroup = matter.PracticeGroupDesc;
            //assignment.Pta1 = matter.PTAGroup ?? "";
            //assignment.IndustryGroup = matter.IndustryGroupDesc ?? "";
            //assignment.TechnicalReviewerNumber = matter.TechnicalReviewerNumber?.ToString() ?? "";
            //assignment.TechnicalReviewerName = matter.TechnicalReviewerName ?? "";
            //assignment.EngineerOfRecordNumber = matter.EngineerOfRecordNo?.ToString() ?? "";
            //assignment.EngineerOfRecordName = matter.EngineerOfRecordName ?? "";
            //assignment.BdManagerNumber = matter.BDManagerNo?.ToString() ?? "";
            //assignment.BdManagerName = matter.BDManagerName ?? "";
            //assignment.StartDate2 = Convert.ToDateTime(matter.StartDate2?.ToUniversalTime()).ToString("yyyy-MM-ddT00:00:00");
            //assignment.SpecialClientInstruction = matter.SpecialClientInstruction;
            //assignment.Rate = matter.RateDesc;
            //assignment.RateExceptGroup = matter.RateExceptionGroup;
            //assignment.TimeType = matter.TimeType ?? "";
            //assignment.FlatFeeAmount = matter.FlatFeeAmount?.ToString() ?? "";
            //assignment.Budget = matter.BudgetAmount?.ToString() ?? "";

            //#endregion Internal Use Only Section

            //#endregion map data fields to assignment
            #endregion need to remove once tested

            return assignment;
        }

        public AssignmentNotes GetMatterNotes(int mattNo, string customerId, string search, string eventFilter, string eventdateFilter, string noteFilter, int offset = 0, int limit = 50)
        {
            AssignmentNotes assignmentNotes = new AssignmentNotes();
            var notes = _te3ECmsClient.GetMatterNotes(mattNo, _sqlCommandTimeout, envEnum);

            assignmentNotes.TotalResultCount = notes.Count;

            //need to translate to kentico json format
            assignmentNotes.Notes = notes.Where(x => !string.IsNullOrEmpty(x.Note)).OrderByDescending(x=>x.TimeStamp).Select(x =>
                new AssignmentNote
                {
                    E3EId = Convert.ToInt32(x.MattIndex),
                    MatterTitle = x.MattName,
                    MatterNumber = x.MattNumber,
                    NoteDescription = x.MattNoteTypeDesc,
                    EntryUser = x.EntryUser ?? "",
                    DateEntered = Convert.ToDateTime(x.DateEntered?.ToUniversalTime()).ToString("yyyy-MM-ddT00:00:00"),
                    Note = x.Note ?? ""
                }).ToList();

            if (!string.IsNullOrEmpty(search))
            {
                string sDtFilter = "";
                try { sDtFilter = Convert.ToDateTime(search).ToString("yyyy-MM-ddT00:00:00"); }
                catch { }

                if (!string.IsNullOrEmpty(sDtFilter))
                {
                    assignmentNotes.Notes = assignmentNotes.Notes.Where(x => x.DateEntered.Contains(search)).Select(x => x).ToList();
                }
                else
                {
                    var lowerCasedSearch = search.ToLower();
                    assignmentNotes.Notes = assignmentNotes.Notes.Where(x => x.NoteDescription.ToLower().Contains(lowerCasedSearch)
                                                                        || x.Note.ToLower().Contains(lowerCasedSearch)
                                                                        || x.EntryUser.ToLower().Contains(lowerCasedSearch)
                                                                        || x.MatterNumber.ToLower().Contains(lowerCasedSearch)
                                                                        || x.MatterTitle.ToLower().Contains(lowerCasedSearch)).Select(x => x).ToList();
                }
            }

            if (!string.IsNullOrEmpty(eventFilter))
            {
                assignmentNotes.Notes = assignmentNotes.Notes.Where(x => x.NoteDescription.ToLower() == eventFilter.ToLower()).Select(x => x).ToList();
            }

            if (!string.IsNullOrEmpty(eventdateFilter))
            {
                string dtFilter = "";
                try { dtFilter = Convert.ToDateTime(eventdateFilter).ToString("yyyy-MM-ddT00:00:00"); }
                catch { }

                if (!string.IsNullOrEmpty(dtFilter))
                {
                    assignmentNotes.Notes = assignmentNotes.Notes.Where(x => x.DateEntered == dtFilter).Select(x => x).ToList();
                }
            }

            if (!string.IsNullOrEmpty(noteFilter))
            {
                assignmentNotes.Notes = assignmentNotes.Notes.Where(x => x.Note.ToLower() == noteFilter.ToLower()).Select(x => x).ToList();
            }

            assignmentNotes.FilteredResultCount = assignmentNotes.Notes.Count;
            assignmentNotes.Notes = assignmentNotes.Notes.Skip(offset).Take(limit).ToList();

            return assignmentNotes;
        }

        //private string GetConfirmationLetterType(CMSGetFullMatterDetails_Result matter)
        //{
        //    string confType = "Standard";

        //    if (matter.IsConfLetterStd == 1)
        //        confType = "Standard";
        //    else if (matter.IsConfLetterLegal == 1)
        //        confType = "Legal";
        //    else if (matter.IsConfLetterNatAgmt == 1)
        //        confType = "National Agreement";
        //    else if (matter.IsConfLetterCAT == 1)
        //        confType = "CAT";
        //    else if (matter.IsConfLetterEngSvcs == 1)
        //        confType = "Engineering Services";
        //    else if (matter.IsConfLetterRtnr == 1)
        //        confType = "Retainer";
        //    else if (matter.IsConfLetterSign == 1)
        //        confType = "Signature";

        //    return confType;
        //}

    }
}