using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TE3EEntityFramework.Client.RCGKENTCMS;
using TE3EEntityFramework.Data.KenticoCMS._3EProcessItem;
using TE3EEntityFramework.Data.Te3e.CMS.CMS.Definition;
using TE3EEntityFramework.Data.Te3e.CMS.Definition;
using TE3EEntityFramework.Datasource.RCGKENTCMS.DataModel;
using TE3EEntityFramework.Extension;

namespace TE3EEntityFramework.Data.KenticoCMS.RCGKENTCMS
{
    public static class CMSMapper
    {
        public static CMSJob ConvertToCMSJob(Assignment assignment, CMSSQLClientV2 cmsSQLClient, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        {

            var timeStampNow = DateTime.Now;
            #region Trim Strings
            assignment.TrimAllStrings();
            //cMSJob.assignment.TrimAllStrings();
            //cMSJob.orderingClient.TrimAllStrings();
            //cMSJob.additionalParties.ForEach(x => x.TrimAllStrings());
            //cMSJob.coConsultants.ForEach(x => x.TrimAllStrings());
            //cMSJob.incidentLocations.ForEach(x => x.TrimAllStrings());
            //cMSJob.payorDetails.ForEach(x => x.TrimAllStrings());
            #endregion

            var cMSJob = new CMSJob()
            {
                assignment = new CMSAssignment(),
                additionalParties = new List<CMSAdditionalParty>(),
                coConsultants = new List<CMSCoConsultant>(),
                incidentLocations = new List<CMSIncidentLocation>(),
                orderingClient = new CMSOrderingClient(),
                payorDetails = new List<CMSPayorDetail>()
            };

            #region map data fields to assignment
            //map data fields to assignment

            #region KenticoId
            cMSJob.assignment.KenticoID = assignment.KenticoID ?? "";
            cMSJob.assignment.SubmissionID = assignment.SubmissionId ?? "";
            cMSJob.orderingClient.KenticoID = assignment.KenticoID ?? "";
            cMSJob.assignment.TimeStamp = timeStampNow;
            #endregion KenticoId

            #region not expecting this on new record, but when it creates record in 3e we need to send back for them to update in json patch
            cMSJob.assignment.E3EID = assignment.E3EID;
            cMSJob.assignment.MattStatus = assignment.MatterStatusID;
            cMSJob.assignment.MattStatusDesc = assignment.MatterStatus;

            cMSJob.orderingClient.ClientIndex = assignment.OrderingClientID.ToInt();
            cMSJob.orderingClient.ClientNumber = assignment.OrderingClientID;
            //cMSJob.orderingClient.ClientNumber = assignment.OrderingClientNumber;

            #endregion not expecting this on new record, but when it creates record in 3e we need to send back for them to update in json patch

            #region Ordering Client Contact Section

            //cMSJob.orderingClient.ContactSalutation = assignment.OrderingClientContactSalutation;
            cMSJob.orderingClient.ContactFirstName = assignment.OrderingClientContactFirstName;
            cMSJob.orderingClient.ContactLastName = assignment.OrderingClientContactLastName;
            cMSJob.orderingClient.ContactEmail = assignment.OrderingClientContactEmail ?? "";
            cMSJob.orderingClient.ContactPhoneNo = assignment.OrderingClientContactPhoneNo ?? "";

            #endregion Ordering Client Contact Section

            #region Ordering Client Company Section
            //# Section: Client Company
            #region convert to 3e clitype
            var cliType = cmsSQLClient.ConvertCliTypeByCode(assignment.OrderingClientCompanyType, sqlCommandTimeout, env);
            cMSJob.orderingClient.CompanyType = cliType?.Code;
            cMSJob.orderingClient.CompanyTypeDesc = cliType?.Description;
            #endregion convert to 3e clitype

            cMSJob.orderingClient.CompanyName = assignment.OrderingClientCompanyName;
            cMSJob.orderingClient.CompanyAddress1 = assignment.OrderingClientCompanyAddress1;
            cMSJob.orderingClient.CompanyAddress2 = assignment.OrderingClientCompanyAddress2;
            cMSJob.orderingClient.CompanyAddressCity = assignment.OrderingClientCompanyAddressCity;
            cMSJob.orderingClient.CompanyAddressState = assignment.OrderingClientCompanyAddressState;
            cMSJob.orderingClient.CompanyAddressZip = assignment.OrderingClientCompanyAddressZip;
            cMSJob.orderingClient.CompanyAddressCountry = assignment.OrderingClientCompanyAddressCountry;
            cMSJob.orderingClient.CompanyLatAddress = assignment.OrderingClientCompanyAddressLat.ToDecimal();
            cMSJob.orderingClient.CompanyLonAddress = assignment.OrderingClientCompanyAddressLon.ToDecimal();
            cMSJob.orderingClient.TimeStamp = timeStampNow;

            #region Insurance Information [Only show If OrderClientCompanyName = Liberty Mutual;]

            if (!string.IsNullOrEmpty(assignment.LibertyInsuranceType))
            {
                var libertyInsuranceType = cmsSQLClient.GetMatterCode(T3EMatterLookupType.InsuranceType, assignment.LibertyInsuranceType, sqlCommandTimeout, env);
                cMSJob.assignment.InsuranceType = libertyInsuranceType.IndexOrCode;
                cMSJob.assignment.InsuranceTypeDesc = libertyInsuranceType.Name;
            }

            if (!string.IsNullOrEmpty(assignment.LibertyClaimType))
            {
                var libertyClaimType = cmsSQLClient.GetMatterCode(T3EMatterLookupType.ClaimType, assignment.LibertyClaimType, sqlCommandTimeout, env);
                cMSJob.assignment.ClaimType = libertyClaimType.IndexOrCode;
                cMSJob.assignment.ClaimTypeDesc = libertyClaimType.Name;
            }

            #endregion Insurance Information [Only show If OrderClientCompanyName = Liberty Mutual;]

            #region add ordering client to payor detail

            #region convert to 3e ordering payor detail role
            var orderingPayorDetRole = ConvertCMSCliTypeToPayorDetRole(cmsSQLClient, assignment.OrderingClientCompanyType, assignment.RepType, sqlCommandTimeout, env);
            #endregion convert to 3e ordering payor detail role

            decimal orderingPayorFee = 0;

            assignment.MultipayorYN = (assignment.Payors != null && assignment.Payors.Any());
            if (assignment.MultipayorYN.Value)
            {
                var tempPercentage = assignment.Payors.Sum(x => Convert.ToDecimal(string.IsNullOrEmpty(x.InvoicePercentage) ? "0" : x.InvoicePercentage));
                if (tempPercentage < 100)
                {
                    orderingPayorFee = 100 - tempPercentage;
                }
            }

            CMSPayorDetail orderingPayorDet = new CMSPayorDetail()
            {
                KenticoID = assignment.KenticoID,
                Relationship = ((int)CftRelationship_CCC.Ordering).ToString("D2"), //02
                RelationshipDesc = TE3EEntityExt.GetEnumDescription(CftRelationship_CCC.Ordering),
                RoleDesc = orderingPayorDetRole != null ? orderingPayorDetRole.Description : MatterDefaultAttr.DefaultRoleDesc,
                Role = orderingPayorDetRole != null ? orderingPayorDetRole.Code : MatterDefaultAttr.DefaultRole,
                PercentFee = orderingPayorFee,

                ClientName = assignment.OrderingClientCompanyName,
                PayorName = assignment.OrderingClientCompanyName,
                FirstName = assignment.OrderingClientContactFirstName,
                LastName = assignment.OrderingClientContactLastName,
                Email = assignment.OrderingClientContactEmail ?? "",
                PhoneNumber = assignment.OrderingClientContactPhoneNo ?? "",
                Street = assignment.OrderingClientCompanyAddress1.CombineWith(assignment.OrderingClientCompanyAddress2).IfNullOrEmptyUseThis(MatterDefaultAttr.DefaultUnknowAddress),
                City = assignment.OrderingClientCompanyAddressCity ?? "",
                State = assignment.OrderingClientCompanyAddressState ?? "",
                ZipCode = assignment.OrderingClientCompanyAddressZip ?? "",
                Country = assignment.OrderingClientCompanyAddressCountry,

                PayorIndex = assignment.OrderingClientPayorIndex.ToInt(),
                //PayorSiteIndex = assignment.ord

                SvcOp = TE3EEntityExt.GetEnumDescription(SvcOps.Add),
                TimeStamp = timeStampNow
            };

            assignment.ReferenceNumbers.ForEach(x =>
            {
                //var refType = cmsSQLClient.GetRefType(x.ReferenceIndex.ToInt() ?? 0, sqlCommandTimeout, isDebug);
                switch (x.Type)
                {
                    case "Claim":
                        orderingPayorDet.ClaimNumber = x.Number;
                        break;
                    case "Policy":
                        orderingPayorDet.Policy_CCC = x.Number;
                        break;
                    case "File":
                        orderingPayorDet.File_CCC = x.Number;
                        break;
                    case "Reference":
                        orderingPayorDet.ReferenceNumber = x.Number;
                        break;
                    case "UMR":
                        orderingPayorDet.UMR_CCC = x.Number;
                        break;
                    case "Tracking":
                        orderingPayorDet.Tracking_CCC = x.Number;
                        break;
                    case "PONumber":
                        orderingPayorDet.PONumber_CCC = x.Number;
                        break;
                }
            });

            cMSJob.payorDetails.Add(orderingPayorDet);
            #endregion add ordering client to payor detail

            #endregion Ordering Client Company Section

            #region Incident Information Section
            cMSJob.assignment.DateOccurence = assignment.DateOccurence.ToDateTime();
            //cMSJob.assignment.Narrative_UnformattedText = assignment.DescOccurence;
            cMSJob.assignment.Narrative = assignment.DescOccurence;
            cMSJob.assignment.ScopeOfWork = assignment.NeedAnswered;
            cMSJob.assignment.SpecialInstructions = assignment.SpecialInstructions;
            cMSJob.assignment.IsCheckWritingAuthority = Convert.ToByte(assignment.AuthYN ?? false);

            //# Section: Incident Information
            if (assignment.IncidentYN ?? false)
            {
                assignment.IncidentLocations.ForEach(x =>
                {
                    CMSIncidentLocation incidentLocation = new CMSIncidentLocation();
                    incidentLocation.KenticoID = assignment.KenticoID;
                    incidentLocation.SubItemKenticoID = x.KenticoID;

                    #region not expecting this on new record, but when it creates record in 3e we need to send back for them to update in json patch
                    incidentLocation.SiteIndex = x.SiteIndex.ToInt();
                    #endregion not expecting this on new record, but when it creates record in 3e we need to send back for them to update in json patch

                    //dont need these
                    //incidentLocation.MattSiteID = x.MattSiteID;
                    //incidentLocation.AddrIndex = x.AddressID.ToInt();

                    incidentLocation.StreetOccurrence = x.StreetOccurence.IfNullOrEmptyUseThis(MatterDefaultAttr.DefaultUnknowAddress);
                    incidentLocation.CityOccurrence = x.CityOccurence;
                    incidentLocation.StateOccurrence = x.StateOccurence;
                    incidentLocation.ZipCodeOccurrence = x.ZipOccurrence;
                    incidentLocation.CountyOccurrence = x.CountyOccurence;
                    incidentLocation.CountryOccurrence = x.CountryOccurence;
                    incidentLocation.LatOccurrence = x.LatOccurence.ToDecimal();
                    incidentLocation.LonOccurrence = x.LonOccurence.ToDecimal();

                    incidentLocation.SvcOp = TE3EEntityExt.GetEnumDescription(SvcOps.Add);
                    incidentLocation.TimeStamp = timeStampNow;

                    cMSJob.incidentLocations.Add(incidentLocation);
                });
            }

            #endregion Incident Information Section

            #region Combined Fields - in use

            #region Adjuster Information

            if (assignment.AdjusterType == ((int)CMSAdjType.OutsideAdjuster).ToString())
            {
                #region convert to 3e payor detail role

                var adjPayorDetRole = ConvertTo3EPayorDetRole(cmsSQLClient, TE3EEntityExt.GetEnumDescription(CMSClientType.ThirdPartyAdministrator), "", sqlCommandTimeout, env);
                #endregion convert to 3e payor detail role

                cMSJob.payorDetails.Add(new CMSPayorDetail()
                {
                    KenticoID = assignment.KenticoID,

                    #region setting adjuster as paying payor detail if AuthYN == Y
                    Relationship = Convert.ToBoolean(assignment.AuthYN?.ToString()) ? ((int)CftRelationship_CCC.Paying).ToString("D2") : ((int)CftRelationship_CCC.SameSideInvolved).ToString("D2"), //03 (paying) , 04 (samesideinvolved)
                    RelationshipDesc = Convert.ToBoolean(assignment.AuthYN?.ToString()) ? TE3EEntityExt.GetEnumDescription(CftRelationship_CCC.Paying) : TE3EEntityExt.GetEnumDescription(CftRelationship_CCC.SameSideInvolved),
                    RoleDesc = adjPayorDetRole != null ? adjPayorDetRole.Description : MatterDefaultAttr.DefaultRoleDesc,
                    Role = adjPayorDetRole != null ? adjPayorDetRole.Code : MatterDefaultAttr.DefaultRole,

                    PercentFee = Convert.ToBoolean(assignment.AuthYN?.ToString()) ? Convert.ToDecimal("100") : Convert.ToDecimal("0"),
                    #endregion setting adjuster as paying payor detail if AuthYN == Y

                    ClientName = assignment.OutsideCompName,
                    PayorName = assignment.OutsideCompName,
                    FirstName = assignment.OutsideFirstName,
                    LastName = assignment.OutsideLastName,
                    Email = assignment.OutsideAdjEmail,
                    PhoneNumber = assignment.OutsideAdjPhone,
                    Street = assignment.OutsideAddr1.CombineWith(assignment.OutsideAddr2).IfNullOrEmptyUseThis(MatterDefaultAttr.DefaultUnknowAddress),
                    City = assignment.OutsideCity,
                    State = assignment.OutsideState,
                    ZipCode = assignment.OutsideZip,
                    Country = assignment.OutsideCountry,
                    TimeStamp = timeStampNow,
                    PaymentAuthority = Convert.ToBoolean(assignment.AuthYN?.ToString()),
                    SvcOp = TE3EEntityExt.GetEnumDescription(SvcOps.Add),
                });

                cMSJob.assignment.SpecialInstructions = assignment.AdjusterInvoicing ?? "";
            }

            #endregion Adjuster Information

            #region Legal Information [Only show if OrderClientCompanyType = Attorney]

            if (Convert.ToInt32(assignment.OrderingClientCompanyType) == (int)CMSClientType.Attorney)
            {
                cMSJob.orderingClient.AdditionalInstr = $"{assignment.ParaFirstName} {assignment.ParaLastName}";
                cMSJob.orderingClient.RepresentingDesc = assignment.RepType;

                //cMSJob.orderingClient.CompanyType = assignment.LegalClientType;
                cMSJob.orderingClient.Style = assignment.Style;
                cMSJob.orderingClient.Court = assignment.Court;
                cMSJob.orderingClient.CauseNumber = assignment.CauseNumber;

                #region Legal Information [Only show if LegalClientType = Individual;]

                if (Convert.ToInt32(assignment.LegalClientType) == (int)CMSLegalOrAttyType.Individual)
                {
                    cMSJob.additionalParties.Add(
                        new CMSAdditionalParty
                        {
                            KenticoID = assignment.KenticoID,
                            PartyName = $"{assignment.InsFirstName} {assignment.InsLastName}",
                            PartyType = TE3EEntityExt.GetEnumDescription(AdditionalPartiesRoles.Insured),
                            Role = ((int)AdditionalPartiesRoles.Insured).ToString(),
                            RoleDesc = TE3EEntityExt.GetEnumDescription(AdditionalPartiesRoles.Insured),
                            EntityType = ((int)EntityType.AdditionalParty).ToString(),
                            EntityTypeDesc = TE3EEntityExt.GetEnumDescription(EntityType.AdditionalParty),
                            HomePhone = assignment.InsPOCNo,
                            ArchetypeCode = TE3EEntityExt.GetEnumDescription(ArchetypeCode.EntityPerson),
                            TimeStamp = timeStampNow,
                            SvcOp = TE3EEntityExt.GetEnumDescription(SvcOps.Add),
                        });
                }
                #endregion Legal Information [Only show if LegalClientType = Individual;]

                #region Legal Information [Only show if LegalClientType != Individual;] - company or government entity

                else if (Convert.ToInt32(assignment.LegalClientType) == (int)CMSLegalOrAttyType.Company
                      || Convert.ToInt32(assignment.LegalClientType) == (int)CMSLegalOrAttyType.GovernmentEntity)
                {
                    cMSJob.additionalParties.Add(
                        new CMSAdditionalParty
                        {
                            KenticoID = assignment.KenticoID,
                            PartyName = assignment.InsClientName,
                            PartyType = TE3EEntityExt.GetEnumDescription(AdditionalPartiesRoles.Insured),
                            Role = ((int)AdditionalPartiesRoles.Insured).ToString(),
                            RoleDesc = TE3EEntityExt.GetEnumDescription(AdditionalPartiesRoles.Insured),
                            EntityType = ((int)EntityType.AdditionalParty).ToString(),
                            EntityTypeDesc = TE3EEntityExt.GetEnumDescription(EntityType.AdditionalParty),
                            HomePhone = assignment.InsLegalPOCNo,
                            ArchetypeCode = TE3EEntityExt.GetEnumDescription(ArchetypeCode.EntityOrg),
                            TimeStamp = timeStampNow,
                            SvcOp = TE3EEntityExt.GetEnumDescription(SvcOps.Add),
                        });
                }
                #endregion Legal Information [Only show if LegalClientType != Individual;] - company or government entity
            }
            #endregion Legal Information [Only show if OrderClientCompanyType = Attorney]

            #region Opposing Party Law Firm
            if (assignment.OpposingYN ?? false)
            {
                #region determine whether opposing party law firm plaintiff or defendant
                CMSGetLookupCodes_Result oppPayorDetRole = null;
                if (Convert.ToInt32(assignment.RepType) == (int)CMSRepType.Plaintiff)
                {
                    oppPayorDetRole = new CMSGetLookupCodes_Result();
                    oppPayorDetRole.Code = ((int)CftRoleCodes.LawFirmDefendant).ToString();
                    oppPayorDetRole.Description = TE3EEntityExt.GetEnumDescription(CftRoleCodes.LawFirmDefendant);
                }
                else if (Convert.ToInt32(assignment.RepType) == (int)CMSRepType.Defendant)
                {
                    oppPayorDetRole = new CMSGetLookupCodes_Result();
                    oppPayorDetRole.Code = ((int)CftRoleCodes.LawFirmPlaintiff).ToString();
                    oppPayorDetRole.Description = TE3EEntityExt.GetEnumDescription(CftRoleCodes.LawFirmPlaintiff);
                }
                #endregion determine whether opposing party law firm plaintiff or defendant

                #region add opposing party law firm to payor detail
                cMSJob.payorDetails.Add(new CMSPayorDetail()
                {
                    KenticoID = assignment.KenticoID,
                    Relationship = ((int)CftRelationship_CCC.Against).ToString("D2"),
                    RelationshipDesc = TE3EEntityExt.GetEnumDescription(CftRelationship_CCC.Against),
                    RoleDesc = oppPayorDetRole != null ? oppPayorDetRole.Description : MatterDefaultAttr.DefaultRoleDesc,
                    Role = oppPayorDetRole != null ? oppPayorDetRole.Code : MatterDefaultAttr.DefaultRole,
                    PercentFee = Convert.ToDecimal("0"),

                    ClientName = assignment.OppName,
                    PayorName = assignment.OppName,
                    FirstName = assignment.OppAttyFirstName,
                    LastName = assignment.OppAttyLastName,
                    Street = assignment.OppStreetAddr1.CombineWith(assignment.OppStreetAddr2).IfNullOrEmptyUseThis(MatterDefaultAttr.DefaultUnknowAddress),
                    City = assignment.OppCity,
                    State = assignment.OppState,
                    ZipCode = assignment.OppZip,
                    Country = assignment.OppCountry,
                    TimeStamp = timeStampNow,
                    PaymentAuthority = false,
                    SvcOp = TE3EEntityExt.GetEnumDescription(SvcOps.Add),
                });
                #endregion add opposing party law firm to payor detail

                #region add opposing party

                if (assignment.OpposingParties != null && assignment.OpposingParties.Any())
                {
                    assignment.OpposingParties.ForEach(x =>
                    {
                        var archetypeCode = Convert.ToInt32(x.AttorneysClientType) == ((int)CMSLegalOrAttyType.Individual)
                                                ? TE3EEntityExt.GetEnumDescription(ArchetypeCode.EntityPerson)
                                                : TE3EEntityExt.GetEnumDescription(ArchetypeCode.EntityOrg);

                        if (Convert.ToInt32(assignment.RepType) == (int)CMSRepType.Plaintiff)
                        {
                            cMSJob.additionalParties.Add(new CMSAdditionalParty()
                            {
                                KenticoID = assignment.KenticoID,
                                SubItemKenticoID = x.KenticoID,

                                #region not expecting this on new record, but when it creates record in 3e we need to send back for them to update in json patch
                                EntIndex = x.EntityIndex, //no entity index for new record
                                #endregion #region not expecting this on new record, but when it creates record in 3e we need to send back for them to update in json patch

                                PartyName = x.OpposingAttorneysClientName,
                                PartyType = TE3EEntityExt.GetEnumDescription(AdditionalPartiesRoles.Defendant),
                                Role = ((int)AdditionalPartiesRoles.Defendant).ToString(),
                                RoleDesc = TE3EEntityExt.GetEnumDescription(AdditionalPartiesRoles.Defendant),
                                EntityType = ((int)EntityType.AdditionalParty).ToString(),
                                EntityTypeDesc = TE3EEntityExt.GetEnumDescription(EntityType.AdditionalParty),
                                HomePhone = "",
                                ArchetypeCode = archetypeCode,
                                TimeStamp = timeStampNow,
                                SvcOp = TE3EEntityExt.GetEnumDescription(SvcOps.Add),
                            });
                        }
                        else if (assignment.RepType == TE3EEntityExt.GetEnumDescription(CMSRepType.Defendant))
                        {
                            cMSJob.additionalParties.Add(new CMSAdditionalParty()
                            {
                                KenticoID = assignment.KenticoID,
                                SubItemKenticoID = x.KenticoID,

                                #region not expecting this on new record, but when it creates record in 3e we need to send back for them to update in json patch
                                EntIndex = x.EntityIndex, //no entity index for new record
                                #endregion #region not expecting this on new record, but when it creates record in 3e we need to send back for them to update in json patch

                                PartyName = x.OpposingAttorneysClientName,
                                PartyType = TE3EEntityExt.GetEnumDescription(AdditionalPartiesRoles.Plaintiff),
                                Role = ((int)AdditionalPartiesRoles.Defendant).ToString(),
                                RoleDesc = TE3EEntityExt.GetEnumDescription(AdditionalPartiesRoles.Plaintiff),
                                EntityType = ((int)EntityType.AdditionalParty).ToString(),
                                EntityTypeDesc = TE3EEntityExt.GetEnumDescription(EntityType.AdditionalParty),
                                HomePhone = "",
                                ArchetypeCode = archetypeCode,
                                TimeStamp = timeStampNow,
                                SvcOp = TE3EEntityExt.GetEnumDescription(SvcOps.Add),
                            });
                        }
                    });
                }

                #endregion add opposing party
            }

            #endregion Opposing Party Law Firm

            #region Parties (Additional Parties)

            assignment.Parties.ForEach(x =>
            {
                var addtnlPartyArch = ConvertCMSEntityTypeTo3EArchetype(x.EntityType);
                var addtnlPartyRole = ConvertCMSPartyTypeTo3EAddtnlRole(x.PartyType);

                CMSAdditionalParty party = new CMSAdditionalParty()
                {
                    KenticoID = assignment.KenticoID,
                    SubItemKenticoID = x.KenticoID,
                    Email = x.Email,
                    HomePhone = x.Phone,

                    #region not expecting this on new record, but when it creates record in 3e we need to send back for them to update in json patch
                    EntIndex = x.EntityIndex, //no entity index for new record
                    #endregion #region not expecting this on new record, but when it creates record in 3e we need to send back for them to update in json patch

                    PartyName = addtnlPartyArch == TE3EEntityExt.GetEnumDescription(ArchetypeCode.EntityPerson)
                                ? $"{x.FirstName} {x.LastName}"
                                : x.CompanyName,

                    PartyType = addtnlPartyRole.Description,
                    Role = addtnlPartyRole.Code,
                    RoleDesc = addtnlPartyRole.Description,
                    EntityType = ((int)EntityType.AdditionalParty).ToString(),
                    EntityTypeDesc = TE3EEntityExt.GetEnumDescription(EntityType.AdditionalParty),
                    ArchetypeCode = addtnlPartyArch,
                    TimeStamp = timeStampNow,
                    SvcOp = TE3EEntityExt.GetEnumDescription(SvcOps.Add),
                };

                cMSJob.additionalParties.Add(party);
            });

            #endregion Parties (Additional Parties)

            #region CoConsultants
            //check if there's coconsultant
            if (assignment.CoConsultantsYN ?? false || assignment.CoConsultants.Any())
            {
                assignment.CoConsultants.ForEach(x =>
                {
                    CMSCoConsultant coConsultant = new CMSCoConsultant();
                    coConsultant.KenticoID = assignment.KenticoID;
                    coConsultant.SubItemKenticoID = x.KenticoID;
                    #region not expecting this on new record, but when it creates record in 3e we need to send back for them to update in json patch
                    if (string.IsNullOrEmpty(x.CoConsultantIndex))
                    {
                        var coConsultantTkpr = cmsSQLClient.GetMatterCode(T3EMatterLookupType.Timekeeper, x.CoConsultantNumber, sqlCommandTimeout, env);
                        coConsultant.CoConsultantIndex = coConsultantTkpr.IndexOrCode;
                    }
                    else
                    {
                        coConsultant.CoConsultantIndex = x.CoConsultantIndex;
                    }

                    #endregion not expecting this on new record, but when it creates record in 3e we need to send back for them to update in json patch

                    coConsultant.CoConsultantName = x.CoConsultantName ?? "";
                    coConsultant.CoConsultantNumber = x.CoConsultantNumber ?? "";
                    coConsultant.TimeStamp = timeStampNow;
                    coConsultant.SvcOp = TE3EEntityExt.GetEnumDescription(SvcOps.Add);

                    cMSJob.coConsultants.Add(coConsultant);
                });
            }

            #endregion CoConsultants

            #region Multipayor Information

            if (assignment.MultipayorYN.Value)
            {
                cMSJob.assignment.SpecialInstructions = assignment.MultipayorInvoicing;

                assignment.Payors.ForEach(x =>
                {
                    CMSPayorDetail payor = new CMSPayorDetail()
                    {
                        KenticoID = assignment.KenticoID,
                        SubItemKenticoID = x.KenticoID,
                        #region not expecting this on new record, but when it creates record in 3e we need to send back for them to update in json patch
                        PayorIndex = x.PayorIndex.ToInt(),
                        #endregion not expecting this on new record, but when it creates record in 3e we need to send back for them to update in json patch

                        Relationship = ((int)CftRelationship_CCC.Paying).ToString("D2"),
                        RelationshipDesc = TE3EEntityExt.GetEnumDescription(CftRelationship_CCC.Paying),
                        RoleDesc = orderingPayorDetRole != null ? orderingPayorDetRole.Description : MatterDefaultAttr.DefaultRoleDesc,
                        Role = orderingPayorDetRole != null ? orderingPayorDetRole.Code : MatterDefaultAttr.DefaultRole,
                        PercentFee = x.InvoicePercentage.ToDecimal(),

                        ClientName = x.PayName,
                        PayorName = x.PayName,
                        FirstName = x.PayFirstName,
                        LastName = x.PayLastName,
                        Street = x.PayAddr1.CombineWith(x.PayAddr2).IfNullOrEmptyUseThis(MatterDefaultAttr.DefaultUnknowAddress),
                        City = x.PayCity,
                        State = x.PayState,
                        ZipCode = x.PayZip,
                        Country = x.PayCountry,
                        PhoneNumber = x.PayPhone,
                        ReferenceNumber = x.ReferenceNumber,
                        Email = x.PayEmail,
                        LatAddress = x.PayLat.ToDecimal(),
                        LonAddress = x.PayLon.ToDecimal(),
                        TimeStamp = timeStampNow,
                        PaymentAuthority = true,
                        SvcOp = TE3EEntityExt.GetEnumDescription(SvcOps.Add),
                    };

                    cMSJob.payorDetails.Add(payor);
                });
            }
            else
            {
                var payingPayorDet = cMSJob.payorDetails.Where(p => Convert.ToInt32(p.Relationship) == (int)CftRelationship_CCC.Paying)
                                                          .Select(p => p)
                                                          .ToList();

                if (payingPayorDet.Count() == 0)
                {
                    //ordering client is also payor client with 100% percent 
                    orderingPayorDet.RelationshipDesc = TE3EEntityExt.GetEnumDescription(CftRelationship_CCC.Both);
                    orderingPayorDet.Relationship = ((int)CftRelationship_CCC.Both).ToString("D2");
                    orderingPayorDet.PercentFee = Convert.ToDecimal("100");
                }
            }

            #endregion  Multipayor Information

            #region Additional Parties
            if (!cMSJob.additionalParties.Any(x => !string.IsNullOrWhiteSpace(x.PartyName)))
            {
                CMSAdditionalParty party = new CMSAdditionalParty()
                {
                    KenticoID = assignment.KenticoID,
                    Email = assignment.OrderingClientContactEmail,
                    PartyName = assignment.OrderingClientCompanyName,
                    PartyType = MatterDefaultAttr.DefaultRoleDesc,
                    Role = MatterDefaultAttr.DefaultRole,
                    RoleDesc = MatterDefaultAttr.DefaultRoleDesc,
                    EntityType = TE3EEntityExt.GetEnumDescription(EntityType.AdditionalParty),
                    EntityTypeDesc = TE3EEntityExt.GetEnumDescription(EntityType.AdditionalParty),
                    ArchetypeCode = TE3EEntityExt.GetEnumDescription(ArchetypeCode.EntityOrg),
                    TimeStamp = timeStampNow,
                    SvcOp = TE3EEntityExt.GetEnumDescription(SvcOps.Add),
                };
            }

            #endregion

            #endregion Combined Fields - in use

            #region invoice instruction
            //# Section: Invoice Instructions
            cMSJob.assignment.InvoiceTo = assignment.SpecialInvoice;
            #endregion invoice instruction

            #region Internal Use Only Section

            #region Matter Name Logic
            string yymm = DateTime.UtcNow.ToString("yyMM");
            string claimNo = "";
            if (cMSJob.payorDetails.Count() > 0)
            {
                if (!string.IsNullOrEmpty(cMSJob.payorDetails.First().ClaimNumber))
                    claimNo = cMSJob.payorDetails.First().ClaimNumber;
            }
            cMSJob.assignment.MatterName = string.IsNullOrEmpty(claimNo)
                                    ? $"{cMSJob.orderingClient.CompanyName} - {yymm} - {cMSJob.assignment.SubmissionID}"
                                    : $"{cMSJob.orderingClient.CompanyName} - {yymm} - {cMSJob.assignment.SubmissionID} - {claimNo}";
            //cMSJob.assignment.MatterName = assignment.MatterName;
            #endregion Matter Name Logic

            #region not expecting this on new record, but when it creates record in 3e we need to send back for them to update in json patch

            cMSJob.assignment.MatterNumber = assignment.MatterNumber;
            cMSJob.assignment.RelatedMatter = assignment.RelatedMatter.ToInt();

            #endregion not expecting this on new record, but when it creates record in 3e we need to send back for them to update in json patch

            #region convert currency
            if (!string.IsNullOrEmpty(assignment.Currency))
            {
                var currency = cmsSQLClient.GetMatterCode(T3EMatterLookupType.Currency, assignment.Currency, sqlCommandTimeout, env);
                cMSJob.assignment.Currency = currency.IndexOrCode;
                cMSJob.assignment.CurrencyDesc = currency.Name;

            }
            else cMSJob.assignment.Currency = MatterDefaultAttr.DefaultCurrency;
            #endregion convert to currency

            #region convert to 3e timekeeper index
            if (!string.IsNullOrEmpty(assignment.OpenTimekeeper))
            {
                var openTkpr = cmsSQLClient.GetMatterCode(T3EMatterLookupType.Timekeeper, assignment.OpenTimekeeper, sqlCommandTimeout, env);
                cMSJob.assignment.OpenTimekeeperName = openTkpr.Name;
                cMSJob.assignment.OpenTimekeeper = openTkpr.IndexOrCode.ToInt(); ;
            }
            else cMSJob.assignment.OpenTimekeeper = MatterDefaultAttr.ADMIndex;

            #endregion convert to 3e timekeeper index

            cMSJob.assignment.RetainerAmount = assignment.RetainerAmount.ToDecimal();
            cMSJob.assignment.FixedPrice = Convert.ToByte(assignment.FixedPrice ?? false);
            cMSJob.assignment.DNENotes = assignment.DneNotes;
            cMSJob.assignment.WebOriginated = Convert.ToByte(assignment.WebOriginated ?? false);

            #region convert to FeesTaxCode
            if (!string.IsNullOrEmpty(assignment.FeesTaxCode))
            {
                var feesTaxCode = cmsSQLClient.GetMatterCode(T3EMatterLookupType.TimeTaxCode, assignment.FeesTaxCode, sqlCommandTimeout, env);
                cMSJob.assignment.FeesTaxCode = feesTaxCode.IndexOrCode;
                cMSJob.assignment.FeeTaxCodeDesc = feesTaxCode.Name;
            }
            else cMSJob.assignment.FeesTaxCode = MatterDefaultAttr.DefaultFeesTaxCode;
            #endregion convert to FeesTaxCode

            cMSJob.assignment.EntryDate = assignment.EntryDate.ToDateTime() == DateTime.MinValue ? null : assignment.EntryDate.ToDateTime();
            cMSJob.assignment.EBilling = Convert.ToByte(assignment.EBilling ?? false);

            #region convert to ebillingtype
            if (!string.IsNullOrEmpty(assignment.EBillingType))
            {
                var eBillingType = cmsSQLClient.GetMatterCode(T3EMatterLookupType.ElecBillingType, assignment.EBillingType, sqlCommandTimeout, env);
                cMSJob.assignment.ElecBillingType = eBillingType.IndexOrCode;
                cMSJob.assignment.ElecBillingTypeDesc = eBillingType.Name;
            }
            #endregion convert to ebillingtype

            cMSJob.assignment.ElectronicNumber = assignment.ElectronicNumber;
            //confirmation type
            if (string.IsNullOrEmpty(assignment.ConfirmationLetterType))
            {
                cMSJob.assignment.IsConfLetterStd = Convert.ToByte("1");
            }
            else
            {
                var confTypes = cmsSQLClient.GetLookupCodes(3, sqlCommandTimeout, env);
                confTypes.ForEach(x =>
                {
                    cMSJob.assignment.IsConfLetterCAT = Convert.ToByte(assignment.ConfirmationLetterType?.Equals(x.Code) ?? false);
                    cMSJob.assignment.IsConfLetterEngSvcs = Convert.ToByte(assignment.ConfirmationLetterType?.Equals(x.Code) ?? false);
                    cMSJob.assignment.IsConfLetterLegal = Convert.ToByte(assignment.ConfirmationLetterType?.Equals(x.Code) ?? false);
                    cMSJob.assignment.IsConfLetterNatAgmt = Convert.ToByte(assignment.ConfirmationLetterType?.Equals(x.Code) ?? false);
                    cMSJob.assignment.IsConfLetterRtnr = Convert.ToByte(assignment.ConfirmationLetterType?.Equals(x.Code) ?? false);
                    cMSJob.assignment.IsConfLetterSign = Convert.ToByte(assignment.ConfirmationLetterType?.Equals(x.Code) ?? false);
                    cMSJob.assignment.IsConfLetterStd = Convert.ToByte(assignment.ConfirmationLetterType?.Equals(x.Code) ?? false);

                });
            }

            #region convert to rof template
            if (!string.IsNullOrEmpty(assignment.RofTemplate))
            {
                var rofTemplate = cmsSQLClient.GetMatterCode(T3EMatterLookupType.ReportOfFindings_CCC, assignment.RofTemplate, sqlCommandTimeout, env);
                cMSJob.assignment.ROFTemplate = rofTemplate.IndexOrCode;
                cMSJob.assignment.ROFTemplateDesc = rofTemplate.Name;
            }
            else cMSJob.assignment.ROFTemplate = MatterDefaultAttr.DefaultROFTemplate;

            #endregion convert to rof template

            cMSJob.assignment.StartDate1 = assignment.StartDate1.ToDateTime();

            #region convert to 3e timekeeper index

            if (!string.IsNullOrEmpty(assignment.BillingTimekeeper))
            {
                var billTkpr = cmsSQLClient.GetMatterCode(T3EMatterLookupType.Timekeeper, assignment.BillingTimekeeper, sqlCommandTimeout, env);
                cMSJob.assignment.BillingTimekeeperName = billTkpr.Name;
                cMSJob.assignment.BillingTimekeeper = billTkpr.IndexOrCode.ToInt();
            }
            else cMSJob.assignment.BillingTimekeeper = MatterDefaultAttr.ADMIndex;

            #endregion convert to 3e timekeeper index

            #region convert to 3e timekeeper index

            if (!string.IsNullOrEmpty(assignment.ResponsibleTimekeeper))
            {
                var rpTkpr = cmsSQLClient.GetMatterCode(T3EMatterLookupType.Timekeeper, assignment.ResponsibleTimekeeper, sqlCommandTimeout, env);
                cMSJob.assignment.ResponsibleTimekeeperName = rpTkpr.Name;
                cMSJob.assignment.ResponsibleTimekeeper = rpTkpr.IndexOrCode.ToInt();
            }
            else cMSJob.assignment.ResponsibleTimekeeper = MatterDefaultAttr.ADMIndex;

            #endregion convert to 3e timekeeper index

            #region convert to 3e timekeeper index

            if (!string.IsNullOrEmpty(assignment.SupervisingTimekeeper))
            {
                var spTkpr = cmsSQLClient.GetMatterCode(T3EMatterLookupType.Timekeeper, assignment.SupervisingTimekeeper, sqlCommandTimeout, env);
                cMSJob.assignment.SupervisingTimekeeperName = spTkpr.Name;
                cMSJob.assignment.SupervisingTimekeeper = spTkpr.IndexOrCode.ToInt();
            }

            #endregion convert to 3e timekeeper index

            #region convert to office
            if (!string.IsNullOrEmpty(assignment.Office))
            {
                var office = cmsSQLClient.GetMatterCode(T3EMatterLookupType.Office, assignment.Office, sqlCommandTimeout, env);
                cMSJob.assignment.Office = office.IndexOrCode;
                cMSJob.assignment.OfficeName = office.Name;
            }
            //else cMSJob.assignment.Office = MatterDefaultAttr.DefaultOffice;
            #endregion convert to office

            #region convert to section
            if (!string.IsNullOrEmpty(assignment.Section))
            {
                var section = cmsSQLClient.GetMatterCode(T3EMatterLookupType.Section, assignment.Section, sqlCommandTimeout, env);
                cMSJob.assignment.Section = section.IndexOrCode;
                cMSJob.assignment.SectionDesc = section.Name;
            }
            else cMSJob.assignment.Section = MatterDefaultAttr.DefaultSection;
            #endregion convert to section

            #region convert to arrangement
            if (!string.IsNullOrEmpty(assignment.Arrangement))
            {
                var arrangement = cmsSQLClient.GetMatterCode(T3EMatterLookupType.Arrangement, assignment.Arrangement, sqlCommandTimeout, env);
                cMSJob.assignment.Arrangement = arrangement.IndexOrCode;
                cMSJob.assignment.ArrangementDesc = arrangement.Name;
            }
            else cMSJob.assignment.Arrangement = MatterDefaultAttr.DefaultArrangement;
            #endregion convert to arrangement

            #region convert to department
            if (!string.IsNullOrEmpty(assignment.Department))
            {
                var department = cmsSQLClient.GetMatterCode(T3EMatterLookupType.Department, assignment.Department, sqlCommandTimeout, env);
                cMSJob.assignment.Department = department.IndexOrCode;
                cMSJob.assignment.DepartmentDesc = department.Name;
            }
            else cMSJob.assignment.Department = MatterDefaultAttr.DefaultDepartment;
            #endregion convert to department

            #region convert to practice group
            if (!string.IsNullOrEmpty(assignment.PracticeGroup))
            {
                var practiceGrp = cmsSQLClient.GetMatterCode(T3EMatterLookupType.PracticeGroup, assignment.PracticeGroup, sqlCommandTimeout, env);
                cMSJob.assignment.PracticeGroup = practiceGrp.IndexOrCode;
                cMSJob.assignment.PracticeGroupDesc = practiceGrp.Name;
            }
            else cMSJob.assignment.PracticeGroup = MatterDefaultAttr.DefaultPracticeGroup;
            #endregion convert to practice group

            #region convert to pta
            if (!string.IsNullOrEmpty(assignment.Pta1))
            {
                var pta1 = cmsSQLClient.GetMatterCode(T3EMatterLookupType.PTAGroup, assignment.Pta1, sqlCommandTimeout, env);
                cMSJob.assignment.PTAGroup = pta1.IndexOrCode;
                cMSJob.assignment.PTAGroupDesc = pta1.Name;
            }
            else cMSJob.assignment.PTAGroup = MatterDefaultAttr.DefaultPTAGroup;
            #endregion convert to pta

            #region convert to industry group
            if (!string.IsNullOrEmpty(assignment.IndustryGroup))
            {
                var industryGroup = cmsSQLClient.GetMatterCode(T3EMatterLookupType.IndustryGroup_CCC, assignment.IndustryGroup, sqlCommandTimeout, env);
                cMSJob.assignment.IndustryGroup = industryGroup.IndexOrCode;
                cMSJob.assignment.IndustryGroupDesc = industryGroup.Name;
            }
            else cMSJob.assignment.IndustryGroup = MatterDefaultAttr.DefaultIndustryGroup;
            #endregion convert to industry group

            if (!string.IsNullOrEmpty(assignment.TechnicalReviewerNumber))
            {
                var tkpr = cmsSQLClient.GetMatterCode(T3EMatterLookupType.Timekeeper, assignment.TechnicalReviewerNumber, sqlCommandTimeout, env);
                cMSJob.assignment.TechincalReviewerName = tkpr.Name;
                cMSJob.assignment.TechnicalReviewerNumber = tkpr.IndexOrCode.ToInt();
            }
            //else cMSJob.assignment.TechnicalReviewerNumber = MatterDefaultAttr.ADMIndex;

            if (!string.IsNullOrEmpty(assignment.EngineerOfRecordNumber))
            {
                var tkpr = cmsSQLClient.GetMatterCode(T3EMatterLookupType.Timekeeper, assignment.EngineerOfRecordNumber, sqlCommandTimeout, env);
                cMSJob.assignment.EngineerOfRecordName = tkpr.Name;
                cMSJob.assignment.EngineerOfRecordNo = tkpr.IndexOrCode.ToInt();
            }
            //else cMSJob.assignment.EngineerOfRecordNo = MatterDefaultAttr.ADMIndex;

            if (!string.IsNullOrEmpty(assignment.BdManagerNumber))
            {
                var tkpr = cmsSQLClient.GetMatterCode(T3EMatterLookupType.Timekeeper, assignment.BdManagerNumber, sqlCommandTimeout, env);
                cMSJob.assignment.BDManagerName = tkpr.Name;
                cMSJob.assignment.BDManagerNo = tkpr.IndexOrCode.ToInt();
            }
            //else cMSJob.assignment.BDManagerNo = MatterDefaultAttr.ADMIndex;

            cMSJob.assignment.StartDate2 = assignment.StartDate2.ToDateTime();

            #region convert to special client instruction
            if (!string.IsNullOrEmpty(assignment.SpecialClientInstruction))
            {
                var specialClientInstruction = cmsSQLClient.GetMatterCode(T3EMatterLookupType.SpecialClientInstruction, assignment.SpecialClientInstruction, sqlCommandTimeout, env);
                cMSJob.assignment.SpecialClientInstruction = specialClientInstruction.IndexOrCode;
                cMSJob.assignment.SpecialClientInstructionDesc = specialClientInstruction.Name;
            }
            else cMSJob.assignment.SpecialClientInstruction = MatterDefaultAttr.DefaultSpecialClientInstr;
            #endregion convert to special client instruction

            #region convert to rate
            if (!string.IsNullOrEmpty(assignment.Rate))
            {
                var rate = cmsSQLClient.GetMatterCode(T3EMatterLookupType.Rate, assignment.Rate, sqlCommandTimeout, env);
                cMSJob.assignment.Rate = rate.IndexOrCode;
                cMSJob.assignment.RateDesc = rate.Name;
            }
            else cMSJob.assignment.Rate = MatterDefaultAttr.DefaultMattRate;
            #endregion convert to rate

            #region convert to rate exception group
            if (!string.IsNullOrEmpty(assignment.RateExceptGroup))
            {
                var rateExceptGroup = cmsSQLClient.GetMatterCode(T3EMatterLookupType.RateExceptionGroup, assignment.RateExceptGroup, sqlCommandTimeout, env);
                cMSJob.assignment.RateExceptGroup = rateExceptGroup.IndexOrCode;
                cMSJob.assignment.RateExceptGroupDesc = rateExceptGroup.Name;
            }
            else cMSJob.assignment.RateExceptGroup = MatterDefaultAttr.DefaultMattRateExc;
            #endregion convert to rate exception group

            #region convert to time type
            if (!string.IsNullOrEmpty(assignment.TimeType))
            {
                var timeType = cmsSQLClient.GetMatterCode(T3EMatterLookupType.TimeType, assignment.TimeType, sqlCommandTimeout, env);
                cMSJob.assignment.TimeType = timeType.IndexOrCode;
                cMSJob.assignment.TimeTypeDesc = timeType.Name;
            }
            else cMSJob.assignment.TimeType = MatterDefaultAttr.DefaultTimeType;
            #endregion convert to time type
            if (cMSJob.assignment.FixedPrice.HasValue && cMSJob.assignment.FixedPrice.Value == 1)
            {
                cMSJob.assignment.FlatFeeAmount = assignment.FlatFeeAmount.ToDecimal() ?? 0;
                cMSJob.assignment.Budget = assignment.Budget.ToDecimal() ?? 0;
            }
            else
            {
                cMSJob.assignment.FlatFeeAmount = assignment.FlatFeeAmount.ToDecimal();
                cMSJob.assignment.Budget = assignment.Budget.ToDecimal();
            }

            cMSJob.assignment.ReportTo = assignment.ReportEmail;
            #endregion Internal Use Only Section

            #endregion map data fields to assignment



            return cMSJob;
        }

        /// <summary>
        /// This method is used by RimkusConnectApi - GetFullMatterDetails
        /// </summary>
        /// <param name="mattIndex"></param>
        /// <param name="cmsSQLClient"></param>
        /// <param name="sqlCommandTimeout"></param>
        /// <param name="env"></param>
        /// <returns></returns>
        public static Assignment ConvertToCMSAssignment(int mattIndex, CMSSQLClientV2 cmsSQLClient, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        {
            Assignment assignment = new Assignment();

            #region fetching full matter details
            //get matter detail
            var matter = cmsSQLClient.GetFullMatterDetails(mattIndex, sqlCommandTimeout, env);

            //if (matter.ClientNumber != clientNo.ToString("D7"))
            //    throw new CustomerNotMatchException($"Customer ID Not Match. No customer with ID = {clientNo.ToString("D7")}");

            //get ordering client
            var orderingClient = cmsSQLClient.GetFullMatterOrderingClientDetails(mattIndex, sqlCommandTimeout, env);

            //get incident location
            var incidentLocations = cmsSQLClient.GetFullMatterIncidentLocationDetails(mattIndex, sqlCommandTimeout, env);

            //get coconsultants
            var coConsultants = cmsSQLClient.GetFullMatterCoConsultantDetails(mattIndex, sqlCommandTimeout, env);

            //get matter payor details
            var matterPayorDet = cmsSQLClient.GetFullMatterPayorDetails(mattIndex, sqlCommandTimeout, env);

            //get additional parties
            var additionalParties = cmsSQLClient.GetFullMatterAdditionalPartiesDetails(mattIndex, sqlCommandTimeout, env);

            #endregion fetching full matter details

            #region map data fields to assignment
            //map data fields to assignment
            assignment.E3EID = matter.E3EID;
            assignment.KenticoID = matter.KenticoID ?? "";
            assignment.MatterStatus = matter.CurrentStatus;
            assignment.MatterStatusID = matter.CurrentStatusCode;

            #region Ordering Client Contact Section
            //# Section: Client Contact
            //assignment.OrderingClientContactSalutation = orderingClient.OrderingClientSalutation;
            assignment.OrderingClientContactFirstName = orderingClient.OrderingClientContactFirstName;
            assignment.OrderingClientContactLastName = orderingClient.OrderingClientContactLastName;
            assignment.OrderingClientContactEmail = orderingClient.OrderingClientContactEmail ?? "";
            assignment.OrderingClientContactPhoneNo = orderingClient.OrderingClientContactPhoneNo ?? "";
            assignment.OrderingClientID = orderingClient.OrderingClientIndex?.ToString();
            assignment.OrderingClientNumber = orderingClient.OrderingClientNumber;
            assignment.OrderingClientPayorIndex = matterPayorDet.FirstOrDefault(x => x.ClientIndex.Equals(orderingClient.OrderingClientIndex))?.PayorIndex.ToString();
            #endregion Ordering Client Contact Section

            #region Ordering Client Company Section
            //# Section: Client Company
            var cmsCliType = CMSMapper.ConvertToCMSCliType(cmsSQLClient, orderingClient.OrderingClientCompanyType, sqlCommandTimeout, env);

            assignment.OrderingClientCompanyType = cmsCliType != null ? cmsCliType.Code : "";
            assignment.OrderingClientCompanyTypeDesc = cmsCliType != null ? cmsCliType.Description : orderingClient.OrderingClientCompanyType;

            assignment.OrderingClientCompanyName = orderingClient.OrderingClientCompanyName;
            assignment.OrderingClientCompanyAddress1 = orderingClient.OrderingClientCompanyAddress1 ?? "";
            assignment.OrderingClientCompanyAddress2 = orderingClient.OrderingClientCompanyAddress2 ?? "";
            assignment.OrderingClientCompanyAddressCity = orderingClient.OrderingClientCompanyAddressCity ?? "";
            assignment.OrderingClientCompanyAddressState = orderingClient.OrderingClientCompanyAddressState ?? "";
            assignment.OrderingClientCompanyAddressZip = orderingClient.OrderingClientCompanyAddressZip ?? "";
            assignment.OrderingClientCompanyAddressCountry = orderingClient.OrderingClientCompanyAddressCountry;
            assignment.OrderingClientCompanyAddressLat = orderingClient.OrderingClientCompanyLatAddress?.ToString() ?? "";
            assignment.OrderingClientCompanyAddressLon = orderingClient.OrderingClientCompanyLonAddress?.ToString() ?? "";
            #endregion Ordering Client Company Section

            #region Incident Information Section
            //# Section: Incident Information
            assignment.IncidentYN = Convert.ToDateTime(matter.DateOfOccurence?.ToUniversalTime()) != DateTime.MinValue;
            assignment.DateOccurence = Convert.ToDateTime(matter.DateOfOccurence?.ToUniversalTime()).ToString("yyyy-MM-ddT00:00:00");
            assignment.DateUnknown = Convert.ToDateTime(matter.DateOfOccurence?.ToUniversalTime()) == DateTime.MinValue;
            //assignment.DescOccurence = matter.Narrative_UnformattedText ?? "";
            assignment.DescOccurence = matter.Narrative ?? "";
            assignment.NeedAnswered = matter.ScopeOfWork ?? "";
            assignment.SpecialInstructions = matter.SpecialInstructions;

            assignment.IncidentLocations = new List<IncidentLocation>();
            incidentLocations.ForEach(x =>
            {
                IncidentLocation incidentLocation = new IncidentLocation();
                incidentLocation.SiteIndex = x.SiteID.ToString();
                incidentLocation.KenticoID = x.KenticoID;
                //incidentLocation.MattSiteID = x.MattSiteID.ToString();
                //incidentLocation.AddressID = x.AddressID.ToString();
                incidentLocation.StreetOccurence = x.StreetOccurrence ?? "";
                incidentLocation.CityOccurence = x.CityOccurrence ?? "";
                incidentLocation.StateOccurence = x.StateOccurrence ?? "";
                incidentLocation.ZipOccurrence = x.ZipCodeOccurrence ?? "";
                incidentLocation.CountyOccurence = x.CountyOccurrence ?? "";
                incidentLocation.CountryOccurence = x.CountryOccurrence ?? "";
                incidentLocation.LatOccurence = x.LatOccurrence?.ToString() ?? "";
                incidentLocation.LonOccurence = x.LonOccurrence?.ToString() ?? "";

                assignment.IncidentLocations.Add(incidentLocation);
            });

            #endregion Incident Information Section

            #region Combined Fields - in use

            #region Adjuster Information

            //AdjusterType = Outside Adjuster
            var adjuster = matterPayorDet.Where(x => (Convert.ToInt32(x.Relationship) == (int)CftRelationship_CCC.Ordering
                                                   || Convert.ToInt32(x.Relationship) == (int)CftRelationship_CCC.Both)
                                                   && Convert.ToInt32(x.Role) == (int)CftRoleCodes.AdjustmentFirm)
                                         .Select(x => x).ToList();

            //default adjuster type
            var adjType = CMSMapper.ConvertToCMSAdjusterType(((int)CftRoleCodes.Noneoftheabove).ToString(), false, cmsSQLClient, sqlCommandTimeout, env);
            assignment.AdjusterType = adjType.Code;
            assignment.AdjusterTypeDesc = adjType.Description;

            if (adjuster.Count() > 0)
            {
                var outsideAdj = adjuster.First();

                adjType = CMSMapper.ConvertToCMSAdjusterType(outsideAdj.Role, Convert.ToBoolean(outsideAdj.PaymentAuthority), cmsSQLClient, sqlCommandTimeout, env); //I am the adjuster, Outside adjuster, I did not hire an adjuster
                assignment.AdjusterType = adjType.Code;
                assignment.AdjusterTypeDesc = adjType.Description;

                assignment.AuthYN = Convert.ToBoolean(outsideAdj.PaymentAuthority); //outsideAdj.RoleDesc.Equals("I am the Adjuster", StringComparison.OrdinalIgnoreCase);
                assignment.OutsideCompName = outsideAdj.PayorName;
                assignment.OutsideFirstName = outsideAdj.FirstName;
                assignment.OutsideLastName = outsideAdj.LastName;
                assignment.OutsideAdjEmail = outsideAdj.Email ?? "";
                assignment.OutsideAdjPhone = outsideAdj.PhoneNumber ?? "";
                assignment.AdjusterInvoicing = matter.SpecialInstructions ?? ""; //matterspecialinstructions_CCC

                assignment.OutsideAddr1 = outsideAdj.Street ?? "";
                assignment.OutsideAddr2 = "";
                assignment.OutsideCity = outsideAdj.City ?? "";
                assignment.OutsideState = outsideAdj.State ?? "";
                assignment.OutsideZip = outsideAdj.ZipCode ?? "";
                assignment.OutsideCountry = outsideAdj.Country ?? "";

                assignment.SpecialInstructions = matter.SpecialInstructions ?? "";
            }

            #endregion Adjuster Information

            #region Legal Information [Only show if OrderClientCompanyType = Attorney]

            if (Convert.ToInt32(orderingClient.OrderingClientCompanyType) == (int)CftRoleCodes.LawFirmPlaintiff
             || Convert.ToInt32(orderingClient.OrderingClientCompanyType) == (int)CftRoleCodes.LawFirmDefendant)
            {
                assignment.ParaFirstName = orderingClient.OrderingClientAdditionalInstr ?? ""; //orderingClient.OrderClientAdditionalInstr
                assignment.ParaLastName = "";
                assignment.RepType = orderingClient.Representing ?? "";
                assignment.RepTypeDesc = orderingClient.RepresentingDesc ?? "";

                //Individual, Company, Government Entity (equivalent to entityperson = individual, entityorg = company and gov entity
                assignment.Style = orderingClient.Style ?? "";
                assignment.Court = orderingClient.Court ?? "";
                assignment.CauseNumber = orderingClient.CauseNumber ?? "";
                assignment.SuitYN = !string.IsNullOrEmpty(assignment.CauseNumber);


                #region Legal Information [Only show if LegalClientType = Individual;]
                var individualInsParty = additionalParties.Where(x => x.ArchetypeCode == TE3EEntityExt.GetEnumDescription(ArchetypeCode.EntityPerson)
                                                              && Convert.ToInt32(x.Role) == (int)AdditionalPartiesRoles.Insured)
                                                          .Select(x => x).ToList();

                if (individualInsParty.Count() > 0)
                {
                    CMSGetFullMatterAdditionalPartiesDetails_Result indvlInsPartyInvolved = individualInsParty.First();

                    var legalOrAttyType = Convert3EAddtnlEntityToCMSLegalOrAttyType(TE3EEntityExt.GetEnumDescription(ArchetypeCode.EntityPerson), cmsSQLClient, sqlCommandTimeout, env);
                    assignment.LegalClientType = legalOrAttyType.Code;
                    assignment.LegalClientTypeDesc = legalOrAttyType.Description;

                    assignment.InsFirstName = indvlInsPartyInvolved.FirstName;
                    assignment.InsLastName = indvlInsPartyInvolved.LastName;
                    assignment.InsPOCNo = indvlInsPartyInvolved.HomePhone ?? "";
                }

                #endregion Legal Information [Only show if LegalClientType = Individual;]

                #region Legal Information [Only show if LegalClientType != Individual;] - company or government entity
                var compOrGovInsParty = additionalParties.Where(x => x.ArchetypeCode == TE3EEntityExt.GetEnumDescription(ArchetypeCode.EntityOrg)
                                                             && Convert.ToInt32(x.Role) == (int)AdditionalPartiesRoles.Insured)
                                                       .Select(x => x).ToList();
                if (compOrGovInsParty.Count() > 0)
                {
                    CMSGetFullMatterAdditionalPartiesDetails_Result compOrGovInsPartyInvolved = compOrGovInsParty.First();

                    var legalOrAttyType = Convert3EAddtnlEntityToCMSLegalOrAttyType(TE3EEntityExt.GetEnumDescription(ArchetypeCode.EntityOrg), cmsSQLClient, sqlCommandTimeout, env);
                    assignment.LegalClientType = legalOrAttyType.Code;
                    assignment.LegalClientTypeDesc = legalOrAttyType.Description;

                    assignment.InsClientName = compOrGovInsPartyInvolved.PartyName ?? "";
                    assignment.InsLegalPOCNo = compOrGovInsPartyInvolved.HomePhone ?? "";
                    assignment.InsLegalPOC = $"{orderingClient.OrderingClientContactFirstName} {orderingClient.OrderingClientContactLastName}";
                    assignment.InsNo = orderingClient.OrderingClientContactPhoneNo ?? "";
                }
                #endregion Legal Information [Only show if LegalClientType != Individual;] - company or government entity
            }
            #endregion Legal Information [Only show if OrderClientCompanyType = Attorney]

            #region Opposing Party Law Firm
            var opposingPartyLawFirm = matterPayorDet.Where(x => Convert.ToInt32(x.Relationship) == (int)CftRelationship_CCC.Against).Select(x => x).ToList();
            if (opposingPartyLawFirm.Count() > 0)
            {
                var oppParty = opposingPartyLawFirm.First();

                assignment.OpposingYN = true;
                assignment.OppName = oppParty.PayorName;
                assignment.OppAttyFirstName = oppParty.FirstName;
                assignment.OppAttyLastName = oppParty.LastName;
                assignment.OppStreetAddr1 = oppParty.Street ?? "";
                assignment.OppStreetAddr2 = "";
                assignment.OppCity = oppParty.City ?? "";
                assignment.OppState = oppParty.State ?? "";
                assignment.OppZip = oppParty.ZipCode ?? "";
                assignment.OppCountry = oppParty.Country ?? "";

                assignment.OpposingParties = new List<OpposingParty>();
                var plantiffOpposingParty = oppParty.RoleDesc.Contains("Plaintiff");
                var defendantOpposingParty = oppParty.RoleDesc.Contains("Defendant");

                if (plantiffOpposingParty)
                {
                    var opposingParties = additionalParties.Where(x => x.RoleDesc == "Plaintiff").Select(x => x).ToList();

                    opposingParties.ForEach(x =>
                    {
                        var legalOrAttyType = Convert3EAddtnlEntityToCMSLegalOrAttyType(x.ArchetypeCode, cmsSQLClient, sqlCommandTimeout, env);
                        OpposingParty opposingParty = new OpposingParty();
                        opposingParty.EntityIndex = x.EntityIndex?.ToString() ?? "";
                        opposingParty.AttorneysClientType = legalOrAttyType.Code;
                        opposingParty.AttorneysClientTypeDesc = legalOrAttyType.Description;
                        opposingParty.KenticoID = x.KenticoID;

                        opposingParty.OpposingAttorneysClientName = x.PartyName;
                        assignment.OpposingParties.Add(opposingParty);
                    });
                }
                else if (defendantOpposingParty)
                {
                    var opposingParties = additionalParties.Where(x => x.RoleDesc == "Defendant").Select(x => x).ToList();

                    opposingParties.ForEach(x =>
                    {
                        var legalOrAttyType = Convert3EAddtnlEntityToCMSLegalOrAttyType(x.ArchetypeCode, cmsSQLClient, sqlCommandTimeout, env);
                        OpposingParty opposingParty = new OpposingParty();
                        opposingParty.EntityIndex = x.EntityIndex?.ToString() ?? "";
                        opposingParty.AttorneysClientType = legalOrAttyType.Code;
                        opposingParty.AttorneysClientTypeDesc = legalOrAttyType.Description;
                        opposingParty.KenticoID = x.KenticoID;

                        opposingParty.OpposingAttorneysClientName = x.PartyName;
                        assignment.OpposingParties.Add(opposingParty);
                    });
                }

            }
            #endregion Opposing Party Law Firm

            #region Parties (Additional Parties)
            assignment.Parties = new List<Party>();

            additionalParties.ForEach(x =>
            {
                if (!assignment.OpposingParties.Any(o => o.EntityIndex == x.EntityIndex.ToString()))
                {
                    Party party = new Party();
                    party.EntityIndex = x.EntityIndex?.ToString() ?? "";
                    party.KenticoID = x.KenticoID;
                    var entType = Convert3EAddtnlEntityToCMSEntityType(x.ArchetypeCode, cmsSQLClient, sqlCommandTimeout, env);
                    party.EntityType = entType.Code;
                    party.EntityTypeDesc = entType.Description;

                    var partyType = Convert3EAddtnlRoleToCMSPartyType(x.Role, cmsSQLClient, sqlCommandTimeout, env);
                    party.PartyType = partyType.Code;
                    party.PartyTypeDesc = partyType.Description;

                    if (x.ArchetypeCode == TE3EEntityExt.GetEnumDescription(ArchetypeCode.EntityPerson))
                    {
                        party.FirstName = x.FirstName;
                        party.LastName = x.LastName;
                    }
                    else
                    {
                        party.CompanyName = x.PartyName;
                        party.ContactName = "";
                    }

                    if (!string.IsNullOrEmpty(x.HomePhone))
                        party.Phone = x.HomePhone;
                    else if (!string.IsNullOrEmpty(x.WorkPhone))
                        party.Phone = x.WorkPhone;
                    else if (!string.IsNullOrEmpty(x.MobilePhone))
                        party.Phone = x.MobilePhone;

                    assignment.Parties.Add(party);
                }
            });

            #endregion Parties (Additional Parties)

            #region CoConsultants
            //check if there's coconsultant
            assignment.CoConsultantsYN = coConsultants.Count() > 0;
            assignment.CoConsultants = new List<CoConsultant>();
            coConsultants.ForEach(x =>
            {
                CoConsultant coConsultant = new CoConsultant();
                coConsultant.CoConsultantIndex = x.CoConsultantIndex.ToString();
                coConsultant.CoConsultantName = x.CoConsultantName ?? "";
                coConsultant.CoConsultantNumber = x.CoConsultantNumber ?? "";

                assignment.CoConsultants.Add(coConsultant);
            });

            #endregion CoConsultants

            #region Multipayor Information

            var multiPayors = matterPayorDet.Where(x => Convert.ToDouble(x.PercentFee?.ToString() ?? "0") <= 100.0)
                                       .Select(x => x).ToList();

            assignment.MultipayorYN = multiPayors.Any();
            assignment.MultipayorInvoicing = assignment.MultipayorYN.Value ? (matter.SpecialInstructions ?? "") : "";

            assignment.Payors = new List<Payor>();
            matterPayorDet.Where(x => x.ClientIndex != orderingClient.OrderingClientIndex).OrderByDescending(x => x.PercentFee).ToList().ForEach(x =>
            {
                Payor payor = new Payor();
                payor.PayorIndex = x.PayorIndex.ToString();
                payor.KenticoID = x.KenticoID;
                payor.PayRole = x.Role;
                payor.PayRoleDesc = x.RoleDesc;
                payor.PayRelationship = x.Relationship;
                payor.PayRelationshipDesc = x.RelationshipDesc;
                payor.PayAddr1 = x.Street ?? "";
                payor.PayCity = x.City ?? "";
                payor.PayState = x.State ?? "";
                payor.PayZip = x.ZipCode ?? "";
                payor.PayFirstName = x.FirstName ?? "";
                payor.PayLastName = x.LastName ?? "";
                payor.PayName = x.PayorName ?? "";
                payor.PayEmail = x.Email ?? "";
                payor.PayPhone = x.PhoneNumber ?? "";
                payor.PayCountry = x.Country ?? "";
                payor.PayLat = x.LatAddress?.ToString() ?? "";
                payor.PayLon = x.LonAddress?.ToString() ?? "";
                payor.ReferenceNumber = x.ReferenceNumber ?? "";
                payor.CareOf = $"{matter.SpecialInstructions ?? ""}";
                payor.InvoicePercentage = x.PercentFee?.ToString();
                assignment.Payors.Add(payor);
            });

            #endregion  Multipayor Information

            #region Reference Numbers 

            assignment.LibertyInsuranceType = matter.InsuranceType?.ToString() ?? "";
            assignment.LibertyInsuranceTypeDesc = matter.InsuranceTypeDesc ?? "";
            assignment.LibertyClaimType = matter.ClaimType ?? "";
            assignment.LibertyClaimTypeDesc = matter.ClaimTypeDesc ?? "";

            #region Populating Reference Numbers
            List<CMSKenticoSubEntityRel> KenticoRefrenceNumberRels = null;
            if (!string.IsNullOrEmpty(matter.KenticoID))
            {
                KenticoRefrenceNumberRels = cmsSQLClient.GetKenAssignRefrenceNumberRelByKenticoId(matter.KenticoID, sqlCommandTimeout, env);
            }
            matterPayorDet.ForEach(x =>
            {
                //only populate for ordering client
                if (x.ClientIndex == orderingClient.OrderingClientIndex)
                {
                    assignment.ReferenceNumbers = new List<ReferenceNumber>();

                    if (!string.IsNullOrEmpty(x.ClaimNumber))
                    {
                        ReferenceNumber referenceNumber = new ReferenceNumber();
                        referenceNumber.KenticoID = KenticoRefrenceNumberRels?.FirstOrDefault(y => y.EntityKey == TE3EEntityExt.GetEnumDescription(ReferenceNumberType.Claim))?.SubKenticoId;
                        referenceNumber.ReferenceIndex = cmsSQLClient.GetRefNumberID(TE3EEntityExt.GetEnumDescription(ReferenceNumberType.Claim), sqlCommandTimeout, env).ToString();
                        referenceNumber.Number = x.ClaimNumber;
                        referenceNumber.IncludeForBilling = false; //no fields in 3e - need to create new field on payor detail
                        referenceNumber.Type = TE3EEntityExt.GetEnumDescription(ReferenceNumberType.Claim);
                        assignment.ReferenceNumbers.Add(referenceNumber);
                    }

                    if (!string.IsNullOrEmpty(x.ReferenceNumber))
                    {
                        ReferenceNumber referenceNumber = new ReferenceNumber();
                        referenceNumber.KenticoID = KenticoRefrenceNumberRels?.FirstOrDefault(y => y.EntityKey == TE3EEntityExt.GetEnumDescription(ReferenceNumberType.Reference))?.SubKenticoId;
                        referenceNumber.ReferenceIndex = cmsSQLClient.GetRefNumberID(TE3EEntityExt.GetEnumDescription(ReferenceNumberType.Reference), sqlCommandTimeout, env).ToString();
                        referenceNumber.Number = x.ReferenceNumber;
                        referenceNumber.IncludeForBilling = false; //no fields in 3e - need to create new field on payor detail
                        referenceNumber.Type = TE3EEntityExt.GetEnumDescription(ReferenceNumberType.Reference);
                        assignment.ReferenceNumbers.Add(referenceNumber);
                    }

                    if (!string.IsNullOrEmpty(x.Policy_CCC))
                    {
                        ReferenceNumber referenceNumber = new ReferenceNumber();
                        referenceNumber.KenticoID = KenticoRefrenceNumberRels?.FirstOrDefault(y => y.EntityKey == TE3EEntityExt.GetEnumDescription(ReferenceNumberType.Policy))?.SubKenticoId;
                        referenceNumber.ReferenceIndex = cmsSQLClient.GetRefNumberID(TE3EEntityExt.GetEnumDescription(ReferenceNumberType.Policy), sqlCommandTimeout, env).ToString();
                        referenceNumber.Number = x.Policy_CCC;
                        referenceNumber.IncludeForBilling = false; //no fields in 3e - need to create new field on payor detail
                        referenceNumber.Type = TE3EEntityExt.GetEnumDescription(ReferenceNumberType.Policy);
                        assignment.ReferenceNumbers.Add(referenceNumber);
                    }

                    if (!string.IsNullOrEmpty(x.File_CCC))
                    {
                        ReferenceNumber referenceNumber = new ReferenceNumber();
                        referenceNumber.KenticoID = KenticoRefrenceNumberRels?.FirstOrDefault(y => y.EntityKey == TE3EEntityExt.GetEnumDescription(ReferenceNumberType.File))?.SubKenticoId;
                        referenceNumber.ReferenceIndex = cmsSQLClient.GetRefNumberID(TE3EEntityExt.GetEnumDescription(ReferenceNumberType.File), sqlCommandTimeout, env).ToString();
                        referenceNumber.Number = x.File_CCC;
                        referenceNumber.IncludeForBilling = false; //no fields in 3e - need to create new field on payor detail
                        referenceNumber.Type = TE3EEntityExt.GetEnumDescription(ReferenceNumberType.File);
                        assignment.ReferenceNumbers.Add(referenceNumber);
                    }

                    if (!string.IsNullOrEmpty(x.UMR_CCC))
                    {
                        ReferenceNumber referenceNumber = new ReferenceNumber();
                        referenceNumber.KenticoID = KenticoRefrenceNumberRels?.FirstOrDefault(y => y.EntityKey == TE3EEntityExt.GetEnumDescription(ReferenceNumberType.UMR))?.SubKenticoId;
                        referenceNumber.ReferenceIndex = cmsSQLClient.GetRefNumberID(TE3EEntityExt.GetEnumDescription(ReferenceNumberType.UMR), sqlCommandTimeout, env).ToString();
                        referenceNumber.Number = x.UMR_CCC;
                        referenceNumber.IncludeForBilling = false; //no fields in 3e - need to create new field on payor detail
                        referenceNumber.Type = TE3EEntityExt.GetEnumDescription(ReferenceNumberType.UMR);
                        assignment.ReferenceNumbers.Add(referenceNumber);
                    }

                    if (!string.IsNullOrEmpty(x.Tracking_CCC))
                    {
                        ReferenceNumber referenceNumber = new ReferenceNumber();
                        referenceNumber.KenticoID = KenticoRefrenceNumberRels?.FirstOrDefault(y => y.EntityKey == TE3EEntityExt.GetEnumDescription(ReferenceNumberType.Tracking))?.SubKenticoId;
                        referenceNumber.ReferenceIndex = cmsSQLClient.GetRefNumberID(TE3EEntityExt.GetEnumDescription(ReferenceNumberType.Tracking), sqlCommandTimeout, env).ToString();
                        referenceNumber.Number = x.Tracking_CCC;
                        referenceNumber.IncludeForBilling = false; //no fields in 3e - need to create new field on payor detail
                        referenceNumber.Type = TE3EEntityExt.GetEnumDescription(ReferenceNumberType.Tracking);
                        assignment.ReferenceNumbers.Add(referenceNumber);
                    }

                    if (!string.IsNullOrEmpty(x.PONumber))
                    {
                        ReferenceNumber referenceNumber = new ReferenceNumber();
                        referenceNumber.KenticoID = KenticoRefrenceNumberRels?.FirstOrDefault(y => y.EntityKey == TE3EEntityExt.GetEnumDescription(ReferenceNumberType.PO))?.SubKenticoId;
                        referenceNumber.ReferenceIndex = cmsSQLClient.GetRefNumberID(TE3EEntityExt.GetEnumDescription(ReferenceNumberType.PO), sqlCommandTimeout, env).ToString();
                        referenceNumber.Number = x.PONumber;
                        referenceNumber.Type = TE3EEntityExt.GetEnumDescription(ReferenceNumberType.PO);
                        referenceNumber.IncludeForBilling = false; //no fields in 3e - need to create new field on payor detail
                        assignment.ReferenceNumbers.Add(referenceNumber);
                    }
                }
            });

            #endregion Populating Reference Numbers

            #endregion Reference Numbers

            #endregion Combined Fields - in use

            //# Section: Invoice Instructions
            assignment.SpecialInvoice = matter.InvoiceTo ?? "";

            #region Internal Use Only Section
            //# Section: Internal Use Only=
            assignment.MatterName = matter.MattName;
            assignment.MatterNumber = matter.MattNumber;
            assignment.RelatedMatter = matter.RelatedMatter?.ToString() ?? "";
            assignment.RelatedMatterName = matter.RelatedMatterName ?? "";
            assignment.Currency = matter.Currency;
            assignment.CurrencyDesc = matter.CurrencyDesc;
            assignment.OpenTimekeeper = matter.OpenTimekeeper.ToString() ?? "";
            assignment.OpenTimekeeperName = matter.OpenTimekeeperName;
            assignment.RetainerAmount = matter.RetainerAmount?.ToString() ?? "";
            assignment.FixedPrice = matter.FixedPrice == 1;
            assignment.DneNotes = matter.DNENotes ?? "";
            assignment.WebOriginated = matter.WebOriginated == 1;
            assignment.FeesTaxCode = matter.FeesTaxCode ?? "";
            assignment.FeesTaxCodeDesc = matter.FeesTaxCodeDesc ?? "";
            if (matter.EntryDate.HasValue)
            {
                assignment.EntryDate = Convert.ToDateTime(matter.EntryDate?.ToUniversalTime()).ToString("yyyy-MM-ddT00:00:00");
            }
            else
            {
                assignment.EntryDate = assignment.E3EID.HasValue ? string.Empty : DateTime.UtcNow.Date.ToString("yyyy-MM-ddT00:00:00");
            }
            //assignment.EntryDate = matter.EntryDate.HasValue ? Convert.ToDateTime(matter.EntryDate?.ToUniversalTime()).ToString("yyyy-MM-ddT00:00:00") : string.Empty;
            assignment.EBilling = matter.EBilling == 1;
            assignment.EBillingType = matter.ElecBillingType ?? "";
            assignment.EBillingTypeDesc = matter.ElecBillingTypeDesc ?? "";
            assignment.ElectronicNumber = matter.ElectronicNumber ?? "";

            //confirmation letter
            var confLetter = GetConfirmationLetterType(matter, cmsSQLClient, sqlCommandTimeout, env);
            assignment.ConfirmationLetterType = confLetter.Code;
            assignment.ConfirmationLetterTypeDesc = confLetter.Description;

            assignment.RofTemplate = matter.ROFTemplate ?? "";
            assignment.RofTemplateDesc = matter.ROFTemplateDesc ?? "";
            if (matter.EntryDate.HasValue)
            {
                assignment.StartDate1 = Convert.ToDateTime(matter.StartDate1?.ToUniversalTime()).ToString("yyyy-MM-ddT00:00:00");
            }
            else
            {
                assignment.StartDate1 = assignment.E3EID.HasValue ? null : DateTime.UtcNow.Date.ToString("yyyy-MM-ddT00:00:00");
            }
            //assignment.StartDate1 = matter.StartDate1.HasValue ? Convert.ToDateTime(matter.StartDate1?.ToUniversalTime()).ToString("yyyy-MM-ddT00:00:00") : string.Empty;
            assignment.StartDate2 = matter.StartDate2.HasValue ? Convert.ToDateTime(matter.StartDate2?.ToUniversalTime()).ToString("yyyy-MM-ddT00:00:00") : string.Empty;
            assignment.BillingTimekeeper = matter.BillingTimekeeper?.ToString() ?? "";
            assignment.BillingTimekeeperName = matter.BillingTimekeeperName ?? "";
            assignment.ResponsibleTimekeeper = matter.ResponsibleTimekeeper?.ToString() ?? "";
            assignment.ResponsibleTimekeeperName = matter.ResponsibleTimekeeperName;
            assignment.SupervisingTimekeeper = matter.SupervisorTimekeeper?.ToString() ?? "";
            assignment.SupervisingTimekeeperName = matter.SupervisorTimekeeperName;
            assignment.Office = matter.Office;
            assignment.OfficeDesc = matter.OfficeDesc;
            assignment.Section = matter.Section;
            assignment.SectionDesc = matter.SectionDesc;
            assignment.Arrangement = matter.Arrangement;
            assignment.ArrangementDesc = matter.ArrangementDesc;
            assignment.Department = matter.Department;
            assignment.DepartmentDesc = matter.DepartmentDesc;
            assignment.PracticeGroup = matter.PracticeGroup;
            assignment.PracticeGroupDesc = matter.PracticeGroupDesc;
            assignment.Pta1 = matter.PTAGroup ?? "";
            assignment.Pta1Desc = matter.PTAGroupDesc ?? "";
            assignment.IndustryGroup = matter.IndustryGroup ?? "";
            assignment.IndustryGroupDesc = matter.IndustryGroupDesc ?? "";
            assignment.TechnicalReviewerNumber = matter.TechnicalReviewerNumber?.ToString() ?? "";
            assignment.TechnicalReviewerName = matter.TechnicalReviewerName ?? "";
            assignment.EngineerOfRecordNumber = matter.EngineerOfRecordNo?.ToString() ?? "";
            assignment.EngineerOfRecordName = matter.EngineerOfRecordName ?? "";
            assignment.BdManagerNumber = matter.BDManagerNo?.ToString() ?? "";
            assignment.BdManagerName = matter.BDManagerName ?? "";
            assignment.SpecialClientInstruction = matter.SpecialClientInstruction;
            assignment.SpecialClientInstructionDesc = matter.SpecialClientInstructionDesc;
            assignment.Rate = matter.Rate;
            assignment.RateDesc = matter.RateDesc ?? "";
            assignment.RateExceptGroup = matter.RateExceptionGroup?.ToString() ?? "";
            assignment.RateExceptGroupDesc = matter.RateExceptionGroupDesc ?? "";
            assignment.TimeType = matter.TimeType ?? "";
            assignment.TimeTypeDesc = matter.TimeTypeDesc ?? "";
            assignment.FlatFeeAmount = matter.FlatFeeAmount?.ToString() ?? "";
            assignment.Budget = matter.BudgetAmount?.ToString() ?? "";
            assignment.ReportEmail = matter.ReportsTo;
            #endregion Internal Use Only Section

            #endregion map data fields to assignment

            return assignment;
        }

        //[Obsolete]
        //public static Assignment ConvertToCMSAssignment(CMSJob cmsJob, CMSSQLClient cmsSQLClient, int sqlCommandTimeout, bool isDebug = false)
        //{
        //    Assignment assignment = new Assignment();

        //    #region fetching full matter details
        //    //get matter detail
        //    var matter = cmsJob.assignment;

        //    //if (matter.ClientNumber != clientNo.ToString("D7"))
        //    //    throw new CustomerNotMatchException($"Customer ID Not Match. No customer with ID = {clientNo.ToString("D7")}");

        //    //get ordering client
        //    var orderingClient = cmsJob.orderingClient;
        //    //get incident location
        //    var incidentLocations = cmsJob.incidentLocations;

        //    //get coconsultants
        //    var coConsultants = cmsJob.coConsultants;

        //    //get matter payor details
        //    var matterPayorDet = cmsJob.payorDetails;

        //    //get additional parties
        //    var additionalParties = cmsJob.additionalParties;

        //    #endregion fetching full matter details

        //    #region map data fields to assignment
        //    //map data fields to assignment
        //    assignment.E3EID = matter.E3EID;
        //    assignment.KenticoID = matter.KenticoID ?? "";
        //    assignment.MatterStatus = matter.MattStatusDesc;
        //    assignment.MatterStatusID = matter.MattStatus;

        //    #region Ordering Client Contact Section
        //    //# Section: Client Contact
        //    assignment.OrderingClientContactSalutation = orderingClient.ContactSalutation;
        //    assignment.OrderingClientContactFirstName = orderingClient.ContactFirstName;
        //    assignment.OrderingClientContactLastName = orderingClient.ContactLastName;
        //    assignment.OrderingClientContactEmail = orderingClient.ContactEmail ?? "";
        //    assignment.OrderingClientContactPhoneNo = orderingClient.ContactPhoneNo ?? "";
        //    assignment.OrderingClientID = orderingClient.ClientIndex?.ToString();
        //    assignment.OrderingClientNumber = orderingClient.ClientNumber;
        //    #endregion Ordering Client Contact Section

        //    #region Ordering Client Company Section
        //    //# Section: Client Company
        //    var cmsCliType = CMSMapper.ConvertToCMSCliType(cmsSQLClient, orderingClient.CompanyType, sqlCommandTimeout, env);

        //    assignment.OrderingClientCompanyType = cmsCliType != null ? cmsCliType.Code : "";
        //    assignment.OrderingClientCompanyTypeDesc = cmsCliType != null ? cmsCliType.Description : orderingClient.CompanyType;

        //    assignment.OrderingClientCompanyName = orderingClient.CompanyName;
        //    assignment.OrderingClientCompanyAddress1 = orderingClient.CompanyAddress1 ?? "";
        //    assignment.OrderingClientCompanyAddress2 = orderingClient.CompanyAddress2 ?? "";
        //    assignment.OrderingClientCompanyAddressCity = orderingClient.CompanyAddressCity ?? "";
        //    assignment.OrderingClientCompanyAddressState = orderingClient.CompanyAddressState ?? "";
        //    assignment.OrderingClientCompanyAddressZip = orderingClient.CompanyAddressZip ?? "";
        //    assignment.OrderingClientCompanyAddressCountry = orderingClient.CompanyAddressCountry;
        //    assignment.OrderingClientCompanyAddressLat = orderingClient.CompanyLatAddress?.ToString() ?? "";
        //    assignment.OrderingClientCompanyAddressLon = orderingClient.CompanyLonAddress?.ToString() ?? "";
        //    #endregion Ordering Client Company Section

        //    #region Incident Information Section
        //    //# Section: Incident Information
        //    assignment.IncidentYN = Convert.ToDateTime(matter.DateOccurence?.ToUniversalTime()) != DateTime.MinValue;
        //    assignment.DateOccurence = matter.DateOccurence.HasValue ? Convert.ToDateTime(matter.DateOccurence?.ToUniversalTime()).ToString("yyyy-MM-ddT00:00:00") : string.Empty;
        //    assignment.DateUnknown = Convert.ToDateTime(matter.DateOccurence?.ToUniversalTime()) == DateTime.MinValue;
        //    assignment.DescOccurence = matter.Narrative_UnformattedText ?? "";
        //    assignment.NeedAnswered = matter.ScopeOfWork ?? "";
        //    assignment.SpecialInstructions = matter.SpecialInstructions;

        //    assignment.IncidentLocations = new List<IncidentLocation>();
        //    incidentLocations.ForEach(x =>
        //    {
        //        IncidentLocation incidentLocation = new IncidentLocation();
        //        incidentLocation.SiteIndex = x.SiteIndex.ToString();
        //        incidentLocation.KenticoID = x.SubItemKenticoID;
        //        //incidentLocation.MattSiteID = x.MattSiteID.ToString();
        //        //incidentLocation.AddressID = x.AddressID.ToString();
        //        incidentLocation.StreetOccurence = x.StreetOccurrence ?? "";
        //        incidentLocation.CityOccurence = x.CityOccurrence ?? "";
        //        incidentLocation.StateOccurence = x.StateOccurrence ?? "";
        //        incidentLocation.ZipCodeOccurence = x.ZipCodeOccurrence ?? "";
        //        incidentLocation.CountyOccurence = x.CountyOccurrence ?? "";
        //        incidentLocation.CountryOccurence = x.CountryOccurrence ?? "";
        //        incidentLocation.LatOccurence = x.LatOccurrence?.ToString() ?? "";
        //        incidentLocation.LonOccurence = x.LonOccurrence?.ToString() ?? "";

        //        assignment.IncidentLocations.Add(incidentLocation);
        //    });

        //    #endregion Incident Information Section

        //    #region Combined Fields - in use

        //    #region Adjuster Information

        //    //AdjusterType = Outside Adjuster
        //    var adjuster = matterPayorDet.Where(x => (Convert.ToInt32(x.Relationship) == (int)CftRelationship_CCC.Ordering
        //                                           || Convert.ToInt32(x.Relationship) == (int)CftRelationship_CCC.Both)
        //                                           && Convert.ToInt32(x.Role) == (int)CftRoleCodes.AdjustmentFirm)
        //                                 .Select(x => x).ToList();

        //    //default adjuster type
        //    var adjType = CMSMapper.ConvertToCMSAdjusterType(((int)CftRoleCodes.Noneoftheabove).ToString(), false, cmsSQLClient, sqlCommandTimeout, isDebug);
        //    assignment.AdjusterType = adjType.Code;
        //    assignment.AdjusterTypeDesc = adjType.Description;

        //    if (adjuster.Count() > 0)
        //    {
        //        var outsideAdj = adjuster.First();

        //        adjType = CMSMapper.ConvertToCMSAdjusterType(outsideAdj.Role, Convert.ToBoolean(outsideAdj.PaymentAuthority), cmsSQLClient, sqlCommandTimeout, isDebug); //I am the adjuster, Outside adjuster, I did not hire an adjuster
        //        assignment.AdjusterType = adjType.Code;
        //        assignment.AdjusterTypeDesc = adjType.Description;

        //        assignment.AuthYN = Convert.ToBoolean(outsideAdj.PaymentAuthority); //outsideAdj.RoleDesc.Equals("I am the Adjuster", StringComparison.OrdinalIgnoreCase);
        //        assignment.OutsideCompName = outsideAdj.PayorName;
        //        assignment.OutsideFirstName = outsideAdj.FirstName;
        //        assignment.OutsideLastName = outsideAdj.LastName;
        //        assignment.OutsideAdjEmail = outsideAdj.Email ?? "";
        //        assignment.OutsideAdjPhone = outsideAdj.PhoneNumber ?? "";
        //        assignment.AdjusterInvoicing = matter.SpecialInstructions ?? ""; //matterspecialinstructions_CCC

        //        assignment.OutsideAddr1 = outsideAdj.Street ?? "";
        //        assignment.OutsideAddr2 = "";
        //        assignment.OutsideCity = outsideAdj.City ?? "";
        //        assignment.OutsideState = outsideAdj.State ?? "";
        //        assignment.OutsideZip = outsideAdj.ZipCode ?? "";
        //        assignment.OutsideCountry = outsideAdj.Country ?? "";

        //        assignment.SpecialInstructions = matter.SpecialInstructions ?? "";
        //    }

        //    #endregion Adjuster Information

        //    #region Legal Information [Only show if OrderClientCompanyType = Attorney]

        //    if (Convert.ToInt32(orderingClient.CompanyType) == (int)CftRoleCodes.LawFirmPlaintiff
        //     || Convert.ToInt32(orderingClient.CompanyType) == (int)CftRoleCodes.LawFirmDefendant)
        //    {
        //        assignment.ParaFirstName = orderingClient.AdditionalInstr ?? ""; //orderingClient.OrderClientAdditionalInstr
        //        assignment.ParaLastName = "";
        //        assignment.RepType = orderingClient.Representing ?? "";
        //        assignment.RepTypeDesc = orderingClient.RepresentingDesc ?? "";

        //        //Individual, Company, Government Entity (equivalent to entityperson = individual, entityorg = company and gov entity
        //        assignment.Style = orderingClient.Style ?? "";
        //        assignment.Court = orderingClient.Court ?? "";
        //        assignment.CauseNumber = orderingClient.CauseNumber ?? "";
        //        assignment.SuitYN = !string.IsNullOrEmpty(assignment.CauseNumber);


        //        #region Legal Information [Only show if LegalClientType = Individual;]
        //        var individualInsParty = additionalParties.Where(x => x.ArchetypeCode == TE3EEntityExt.GetEnumDescription(ArchetypeCode.EntityPerson)
        //                                                        && x.Role == ((int)AdditionalPartiesRoles.Insured).ToString())
        //                                               .Select(x => x).ToList();

        //        if (individualInsParty.Count() > 0)
        //        {
        //            var indvlInsPartyInvolved = individualInsParty.First();

        //            var legalOrAttyType = Convert3EAddtnlEntityToCMSLegalOrAttyType(TE3EEntityExt.GetEnumDescription(ArchetypeCode.EntityPerson), cmsSQLClient, sqlCommandTimeout, isDebug);
        //            assignment.LegalClientType = legalOrAttyType.Code;
        //            assignment.LegalClientTypeDesc = legalOrAttyType.Description;

        //            var fullName = indvlInsPartyInvolved.PartyName.ParseFullname();
        //            assignment.InsFirstName = $"{fullName.Salutation} {fullName.Firstname}".Trim();
        //            assignment.InsLastName = fullName.Lastname;
        //            assignment.InsPOCNo = indvlInsPartyInvolved.HomePhone ?? "";
        //        }

        //        #endregion Legal Information [Only show if LegalClientType = Individual;]

        //        #region Legal Information [Only show if LegalClientType != Individual;] - company or government entity
        //        var compOrGovInsParty = additionalParties.Where(x => x.ArchetypeCode == TE3EEntityExt.GetEnumDescription(ArchetypeCode.EntityOrg)
        //                                                        && x.Role == ((int)AdditionalPartiesRoles.Insured).ToString())
        //                                               .Select(x => x).ToList();
        //        if (compOrGovInsParty.Count() > 0)
        //        {
        //            var compOrGovInsPartyInvolved = compOrGovInsParty.First();

        //            var legalOrAttyType = Convert3EAddtnlEntityToCMSLegalOrAttyType(TE3EEntityExt.GetEnumDescription(ArchetypeCode.EntityOrg), cmsSQLClient, sqlCommandTimeout, isDebug);
        //            assignment.LegalClientType = legalOrAttyType.Code;
        //            assignment.LegalClientTypeDesc = legalOrAttyType.Description;

        //            assignment.InsClientName = compOrGovInsPartyInvolved.PartyName ?? "";
        //            assignment.InsLegalPOCNo = compOrGovInsPartyInvolved.HomePhone ?? "";
        //            assignment.InsLegalPOC = $"{orderingClient.ContactFirstName} {orderingClient.ContactLastName}";
        //            assignment.InsNo = orderingClient.ContactPhoneNo ?? "";
        //        }
        //        #endregion Legal Information [Only show if LegalClientType != Individual;] - company or government entity
        //    }
        //    #endregion Legal Information [Only show if OrderClientCompanyType = Attorney]

        //    #region Opposing Party Law Firm
        //    var opposingPartyLawFirm = matterPayorDet.Where(x => Convert.ToInt32(x.Relationship) == (int)CftRelationship_CCC.Against).Select(x => x).ToList();
        //    if (opposingPartyLawFirm.Count() > 0)
        //    {
        //        var oppParty = opposingPartyLawFirm.First();

        //        assignment.OpposingYN = true;
        //        assignment.OppName = oppParty.PayorName;
        //        assignment.OppAttyFirstName = oppParty.FirstName;
        //        assignment.OppAttyLastName = oppParty.LastName;
        //        assignment.OppStreetAddr1 = oppParty.Street ?? "";
        //        assignment.OppStreetAddr2 = "";
        //        assignment.OppCity = oppParty.City ?? "";
        //        assignment.OppState = oppParty.State ?? "";
        //        assignment.OppZip = oppParty.ZipCode ?? "";
        //        assignment.OppCountry = oppParty.Country ?? "";

        //        assignment.OpposingParties = new List<OpposingParty>();
        //        var plantiffOpposingParty = oppParty.RoleDesc.Contains("Plaintiff");
        //        var defendantOpposingParty = oppParty.RoleDesc.Contains("Defendant");

        //        if (plantiffOpposingParty)
        //        {
        //            var opposingParties = additionalParties.Where(x => x.RoleDesc == "Plaintiff").Select(x => x).ToList();

        //            opposingParties.ForEach(x =>
        //            {
        //                var legalOrAttyType = Convert3EAddtnlEntityToCMSLegalOrAttyType(x.ArchetypeCode, cmsSQLClient, sqlCommandTimeout, isDebug);
        //                OpposingParty opposingParty = new OpposingParty();
        //                opposingParty.EntityIndex = x.EntIndex?.ToString() ?? "";
        //                opposingParty.AttorneysClientType = legalOrAttyType.Code;
        //                opposingParty.AttorneysClientTypeDesc = legalOrAttyType.Description;

        //                opposingParty.OpposingAttorneysClientName = x.PartyName;
        //                assignment.OpposingParties.Add(opposingParty);
        //            });
        //        }
        //        else if (defendantOpposingParty)
        //        {
        //            var opposingParties = additionalParties.Where(x => x.RoleDesc == "Defendant").Select(x => x).ToList();

        //            opposingParties.ForEach(x =>
        //            {
        //                var legalOrAttyType = Convert3EAddtnlEntityToCMSLegalOrAttyType(x.ArchetypeCode, cmsSQLClient, sqlCommandTimeout, isDebug);
        //                OpposingParty opposingParty = new OpposingParty();
        //                opposingParty.EntityIndex = x.EntIndex?.ToString() ?? "";
        //                opposingParty.AttorneysClientType = legalOrAttyType.Code;
        //                opposingParty.AttorneysClientTypeDesc = legalOrAttyType.Description;

        //                opposingParty.OpposingAttorneysClientName = x.PartyName;
        //                assignment.OpposingParties.Add(opposingParty);
        //            });
        //        }

        //    }
        //    #endregion Opposing Party Law Firm

        //    #region Parties (Additional Parties)
        //    assignment.Parties = new List<Party>();

        //    additionalParties.ForEach(x =>
        //    {
        //        if (!assignment.OpposingParties.Any(o => o.EntityIndex == x.EntIndex.ToString()))
        //        {
        //            Party party = new Party();
        //            party.EntityIndex = x.EntIndex?.ToString() ?? "";

        //            var entType = Convert3EAddtnlEntityToCMSEntityType(x.ArchetypeCode, cmsSQLClient, sqlCommandTimeout, isDebug);
        //            party.EntityType = entType.Code;
        //            party.EntityTypeDesc = entType.Description;

        //            var partyType = Convert3EAddtnlRoleToCMSPartyType(x.Role, cmsSQLClient, sqlCommandTimeout, isDebug);
        //            party.PartyType = partyType.Code;
        //            party.PartyTypeDesc = partyType.Description;

        //            if (x.ArchetypeCode == TE3EEntityExt.GetEnumDescription(ArchetypeCode.EntityPerson))
        //            {
        //                var fullName = x.PartyName.ParseFullname();
        //                party.FirstName = $"{fullName.Salutation} {fullName.Firstname}".Trim();
        //                party.LastName = fullName.Lastname;
        //            }
        //            else
        //            {
        //                party.CompanyName = x.PartyName;
        //                party.ContactName = "";
        //            }

        //            if (!string.IsNullOrEmpty(x.HomePhone))
        //                party.Phone = x.HomePhone;
        //            else if (!string.IsNullOrEmpty(x.WorkPhone))
        //                party.Phone = x.WorkPhone;
        //            else if (!string.IsNullOrEmpty(x.MobilePhone))
        //                party.Phone = x.MobilePhone;

        //            assignment.Parties.Add(party);
        //        }
        //    });

        //    #endregion Parties (Additional Parties)

        //    #region CoConsultants
        //    //check if there's coconsultant
        //    assignment.CoConsultantsYN = coConsultants.Count() > 0;
        //    assignment.CoConsultants = new List<CoConsultant>();
        //    coConsultants.ForEach(x =>
        //    {
        //        CoConsultant coConsultant = new CoConsultant();
        //        coConsultant.CoConsultantIndex = x.CoConsultantIndex.ToString();
        //        coConsultant.CoConsultantName = x.CoConsultantName ?? "";
        //        coConsultant.CoConsultantNumber = x.CoConsultantNumber.ToString() ?? "";

        //        assignment.CoConsultants.Add(coConsultant);
        //    });

        //    #endregion CoConsultants

        //    #region Multipayor Information

        //    var multiPayors = matterPayorDet.Where(x => Convert.ToDouble(x.PercentFee?.ToString() ?? "0") < 100.0)
        //                               .Select(x => x).ToList();

        //    assignment.MultipayorYN = multiPayors.Count() > 1;
        //    assignment.MultipayorInvoicing = assignment.MultipayorYN ?? false ? (matter.SpecialInstructions ?? "") : "";

        //    assignment.Payors = new List<Payor>();
        //    matterPayorDet.OrderByDescending(x => x.PercentFee).ToList().ForEach(x =>
        //    {
        //        Payor payor = new Payor();
        //        payor.PayorIndex = x.PayorIndex.ToString();
        //        payor.PayRole = x.Role;
        //        payor.PayRoleDesc = x.RoleDesc;
        //        payor.PayRelationship = x.Relationship;
        //        payor.PayRelationshipDesc = x.RelationshipDesc;
        //        payor.PayAddr1 = x.Street ?? "";
        //        payor.PayCity = x.City ?? "";
        //        payor.PayState = x.State ?? "";
        //        payor.PayZip = x.ZipCode ?? "";
        //        payor.PayFirstName = x.FirstName ?? "";
        //        payor.PayLastName = x.LastName ?? "";
        //        payor.PayName = x.PayorName ?? "";
        //        payor.PayEmail = x.Email ?? "";
        //        payor.PayPhone = x.PhoneNumber ?? "";
        //        payor.PayCountry = x.Country ?? "";
        //        payor.PayLat = x.LatAddress?.ToString() ?? "";
        //        payor.PayLon = x.LonAddress?.ToString() ?? "";
        //        payor.ReferenceNumber = x.ReferenceNumber ?? "";
        //        payor.CareOf = $"{matter.SpecialInstructions ?? ""}";
        //        payor.InvoicePercentage = x.PercentFee?.ToString();
        //        assignment.Payors.Add(payor);
        //    });

        //    #endregion  Multipayor Information

        //    #region Reference Numbers 

        //    assignment.LibertyInsuranceType = matter.InsuranceType?.ToString() ?? "";
        //    assignment.LibertyInsuranceTypeDesc = matter.InsuranceTypeDesc ?? "";
        //    assignment.LibertyClaimType = matter.ClaimType ?? "";
        //    assignment.LibertyClaimTypeDesc = matter.ClaimTypeDesc ?? "";

        //    #region Populating Reference Numbers

        //    matterPayorDet.ForEach(x =>
        //    {
        //        //only populate for ordering client
        //        if (x.PayorIndex == orderingClient.ClientIndex)
        //        {
        //            assignment.ReferenceNumbers = new List<ReferenceNumber>();

        //            if (!string.IsNullOrEmpty(x.ClaimNumber))
        //            {
        //                ReferenceNumber referenceNumber = new ReferenceNumber();
        //                referenceNumber.ReferenceIndex = cmsSQLClient.GetRefNumberID(TE3EEntityExt.GetEnumDescription(ReferenceNumberType.Claim), sqlCommandTimeout, isDebug).ToString();
        //                referenceNumber.Number = x.ClaimNumber;
        //                referenceNumber.IncludeForBilling = false; //no fields in 3e - need to create new field on payor detail
        //                referenceNumber.Type = TE3EEntityExt.GetEnumDescription(ReferenceNumberType.Claim);
        //                assignment.ReferenceNumbers.Add(referenceNumber);
        //            }

        //            if (!string.IsNullOrEmpty(x.ReferenceNumber))
        //            {
        //                ReferenceNumber referenceNumber = new ReferenceNumber();
        //                referenceNumber.ReferenceIndex = cmsSQLClient.GetRefNumberID(TE3EEntityExt.GetEnumDescription(ReferenceNumberType.Reference), sqlCommandTimeout, isDebug).ToString();
        //                referenceNumber.Number = x.ReferenceNumber;
        //                referenceNumber.IncludeForBilling = false; //no fields in 3e - need to create new field on payor detail
        //                referenceNumber.Type = TE3EEntityExt.GetEnumDescription(ReferenceNumberType.Reference);
        //                assignment.ReferenceNumbers.Add(referenceNumber);
        //            }

        //            if (!string.IsNullOrEmpty(x.Policy_CCC))
        //            {
        //                ReferenceNumber referenceNumber = new ReferenceNumber();
        //                referenceNumber.ReferenceIndex = cmsSQLClient.GetRefNumberID(TE3EEntityExt.GetEnumDescription(ReferenceNumberType.Policy), sqlCommandTimeout, isDebug).ToString();
        //                referenceNumber.Number = x.Policy_CCC;
        //                referenceNumber.IncludeForBilling = false; //no fields in 3e - need to create new field on payor detail
        //                referenceNumber.Type = TE3EEntityExt.GetEnumDescription(ReferenceNumberType.Policy);
        //                assignment.ReferenceNumbers.Add(referenceNumber);
        //            }

        //            if (!string.IsNullOrEmpty(x.File_CCC))
        //            {
        //                ReferenceNumber referenceNumber = new ReferenceNumber();
        //                referenceNumber.ReferenceIndex = cmsSQLClient.GetRefNumberID(TE3EEntityExt.GetEnumDescription(ReferenceNumberType.File), sqlCommandTimeout, isDebug).ToString();
        //                referenceNumber.Number = x.File_CCC;
        //                referenceNumber.IncludeForBilling = false; //no fields in 3e - need to create new field on payor detail
        //                referenceNumber.Type = TE3EEntityExt.GetEnumDescription(ReferenceNumberType.File);
        //                assignment.ReferenceNumbers.Add(referenceNumber);
        //            }

        //            if (!string.IsNullOrEmpty(x.UMR_CCC))
        //            {
        //                ReferenceNumber referenceNumber = new ReferenceNumber();
        //                referenceNumber.ReferenceIndex = cmsSQLClient.GetRefNumberID(TE3EEntityExt.GetEnumDescription(ReferenceNumberType.UMR), sqlCommandTimeout, isDebug).ToString();
        //                referenceNumber.Number = x.UMR_CCC;
        //                referenceNumber.IncludeForBilling = false; //no fields in 3e - need to create new field on payor detail
        //                referenceNumber.Type = TE3EEntityExt.GetEnumDescription(ReferenceNumberType.UMR);
        //                assignment.ReferenceNumbers.Add(referenceNumber);
        //            }

        //            if (!string.IsNullOrEmpty(x.Tracking_CCC))
        //            {
        //                ReferenceNumber referenceNumber = new ReferenceNumber();
        //                referenceNumber.ReferenceIndex = cmsSQLClient.GetRefNumberID(TE3EEntityExt.GetEnumDescription(ReferenceNumberType.Tracking), sqlCommandTimeout, isDebug).ToString();
        //                referenceNumber.Number = x.Tracking_CCC;
        //                referenceNumber.IncludeForBilling = false; //no fields in 3e - need to create new field on payor detail
        //                referenceNumber.Type = TE3EEntityExt.GetEnumDescription(ReferenceNumberType.Tracking);
        //                assignment.ReferenceNumbers.Add(referenceNumber);
        //            }

        //            if (!string.IsNullOrEmpty(x.PONumber_CCC))
        //            {
        //                ReferenceNumber referenceNumber = new ReferenceNumber();
        //                referenceNumber.ReferenceIndex = cmsSQLClient.GetRefNumberID(TE3EEntityExt.GetEnumDescription(ReferenceNumberType.PO), sqlCommandTimeout, isDebug).ToString();
        //                referenceNumber.Number = x.PONumber_CCC;
        //                referenceNumber.Type = TE3EEntityExt.GetEnumDescription(ReferenceNumberType.PO);
        //                referenceNumber.IncludeForBilling = false; //no fields in 3e - need to create new field on payor detail
        //                assignment.ReferenceNumbers.Add(referenceNumber);
        //            }
        //        }
        //    });

        //    #endregion Populating Reference Numbers

        //    #endregion Reference Numbers

        //    #endregion Combined Fields - in use

        //    //# Section: Invoice Instructions
        //    assignment.SpecialInvoice = matter.InvoiceTo ?? "";

        //    #region Internal Use Only Section
        //    //# Section: Internal Use Only=
        //    assignment.MatterName = matter.MatterName;
        //    assignment.MatterNumber = matter.MatterNumber;
        //    assignment.RelatedMatter = matter.RelatedMatter?.ToString() ?? "";
        //    assignment.RelatedMatterName = matter.RelatedMatter?.ToString() ?? "";
        //    assignment.Currency = matter.Currency;
        //    assignment.CurrencyDesc = matter.CurrencyDesc;
        //    assignment.OpenTimekeeper = matter.OpenTimekeeper.ToString() ?? "";
        //    assignment.OpenTimekeeperName = matter.OpenTimekeeperName;
        //    assignment.RetainerAmount = matter.RetainerAmount?.ToString() ?? "";
        //    assignment.FixedPrice = matter.FixedPrice == 1;
        //    assignment.DneNotes = matter.DNENotes ?? "";
        //    assignment.WebOriginated = matter.WebOriginated == 1;
        //    assignment.FeesTaxCode = matter.FeesTaxCode ?? "";
        //    assignment.FeesTaxCodeDesc = matter.FeeTaxCodeDesc ?? "";
        //    assignment.EntryDate = Convert.ToDateTime(matter.EntryDate?.ToUniversalTime()).ToString("yyyy-MM-ddT00:00:00");
        //    assignment.EBilling = matter.EBilling == 1;
        //    assignment.EBillingType = matter.ElecBillingType ?? "";
        //    assignment.EBillingTypeDesc = matter.ElecBillingTypeDesc ?? "";
        //    assignment.ElectronicNumber = matter.ElectronicNumber ?? "";

        //    //confirmation letter
        //    var confLetter = GetConfirmationLetterType(matter, cmsSQLClient, sqlCommandTimeout, isDebug);
        //    assignment.ConfirmationLetterType = confLetter.Code;
        //    assignment.ConfirmationLetterTypeDesc = confLetter.Description;

        //    assignment.RofTemplate = matter.ROFTemplate ?? "";
        //    assignment.RofTemplateDesc = matter.ROFTemplateDesc ?? "";
        //    assignment.StartDate1 = Convert.ToDateTime(matter.StartDate1?.ToUniversalTime()).ToString("yyyy-MM-ddT00:00:00");
        //    assignment.BillingTimekeeper = matter.BillingTimekeeper?.ToString() ?? "";
        //    assignment.BillingTimekeeperName = matter.BillingTimekeeperName ?? "";
        //    assignment.ResponsibleTimekeeper = matter.ResponsibleTimekeeper?.ToString() ?? "";
        //    assignment.ResponsibleTimekeeperName = matter.ResponsibleTimekeeperName;
        //    assignment.SupervisingTimekeeper = matter.SupervisingTimekeeper?.ToString() ?? "";
        //    assignment.SupervisingTimekeeperName = matter.SupervisingTimekeeperName;
        //    assignment.Office = matter.Office;
        //    assignment.OfficeDesc = matter.OfficeName;
        //    assignment.Section = matter.Section;
        //    assignment.SectionDesc = matter.SectionDesc;
        //    assignment.Arrangement = matter.Arrangement;
        //    assignment.ArrangementDesc = matter.ArrangementDesc;
        //    assignment.Department = matter.Department;
        //    assignment.DepartmentDesc = matter.DepartmentDesc;
        //    assignment.PracticeGroup = matter.PracticeGroup;
        //    assignment.PracticeGroupDesc = matter.PracticeGroupDesc;
        //    assignment.Pta1 = matter.PTAGroup ?? "";
        //    assignment.Pta1Desc = matter.PTAGroupDesc ?? "";
        //    assignment.IndustryGroup = matter.IndustryGroup ?? "";
        //    assignment.IndustryGroupDesc = matter.IndustryGroupDesc ?? "";
        //    assignment.TechnicalReviewerNumber = matter.TechnicalReviewerNumber?.ToString() ?? "";
        //    assignment.TechnicalReviewerName = matter.TechincalReviewerName ?? "";
        //    assignment.EngineerOfRecordNumber = matter.EngineerOfRecordNo?.ToString() ?? "";
        //    assignment.EngineerOfRecordName = matter.EngineerOfRecordName ?? "";
        //    assignment.BdManagerNumber = matter.BDManagerNo?.ToString() ?? "";
        //    assignment.BdManagerName = matter.BDManagerName ?? "";
        //    assignment.StartDate2 = Convert.ToDateTime(matter.StartDate2?.ToUniversalTime()).ToString("yyyy-MM-ddT00:00:00");
        //    assignment.SpecialClientInstruction = matter.SpecialClientInstruction;
        //    assignment.SpecialClientInstructionDesc = matter.SpecialClientInstructionDesc;
        //    assignment.Rate = matter.Rate;
        //    assignment.RateDesc = matter.RateDesc ?? "";
        //    assignment.RateExceptGroup = matter.RateExceptGroup?.ToString() ?? "";
        //    assignment.RateExceptGroupDesc = matter.RateExceptGroupDesc ?? "";
        //    assignment.TimeType = matter.TimeType ?? "";
        //    assignment.TimeTypeDesc = matter.TimeTypeDesc ?? "";
        //    assignment.FlatFeeAmount = matter.FlatFeeAmount?.ToString() ?? "";
        //    assignment.Budget = matter.Budget?.ToString() ?? "";

        //    #endregion Internal Use Only Section

        //    #endregion map data fields to assignment

        //    return assignment;
        //}

        public static CMSGetLookupCodes_Result ConvertToCMSCliType(CMSSQLClientV2 cmsSQLClient, string clientType, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        {
            //CliType
            var cliTypes = cmsSQLClient.GetLookupCodes(27, sqlCommandTimeout, env);
            CMSGetLookupCodes_Result cmsCliType = null;

            if (Convert.ToInt32(clientType) == (int)T3EClientType.Insurance)
            {
                var results = cliTypes.Where(x => Convert.ToInt32(x.Code) == (int)CMSClientType.InsuranceCompany).Select(x => x).ToList();
                cmsCliType = results.Count() > 0 ? results.First() : null;
            }
            else if (Convert.ToInt32(clientType) == (int)T3EClientType.ThirdPartyAdministrator)
            {
                var results = cliTypes.Where(x => Convert.ToInt32(x.Code) == (int)CMSClientType.ThirdPartyAdministrator).Select(x => x).ToList();
                cmsCliType = results.Count() > 0 ? results.First() : null;
            }
            else if (Convert.ToInt32(clientType) == (int)T3EClientType.LawFirm)
            {
                var results = cliTypes.Where(x => Convert.ToInt32(x.Code) == (int)CMSClientType.Attorney).Select(x => x).ToList();
                cmsCliType = results.Count() > 0 ? results.First() : null;
            }
            else if (Convert.ToInt32(clientType) == (int)T3EClientType.Corporation)
            {
                var results = cliTypes.Where(x => Convert.ToInt32(x.Code) == (int)CMSClientType.Corporation).Select(x => x).ToList();
                cmsCliType = results.Count() > 0 ? results.First() : null;
            }
            else if (Convert.ToInt32(clientType) == (int)T3EClientType.Government)
            {
                var results = cliTypes.Where(x => Convert.ToInt32(x.Code) == (int)CMSClientType.GovernmentEntity).Select(x => x).ToList();
                cmsCliType = results.Count() > 0 ? results.First() : null;
            }
            else if (Convert.ToInt32(clientType) == (int)T3EClientType.Other)
            {
                var results = cliTypes.Where(x => Convert.ToInt32(x.Code) == (int)CMSClientType.NoneOfTheAbove).Select(x => x).ToList();
                cmsCliType = results.Count() > 0 ? results.First() : null;
            }

            return cmsCliType;
        }

        public static CMSGetLookupCodes_Result ConvertToCMSAdjusterType(string role, bool paymentAuth, CMSSQLClientV2 cmsSQLClient, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        {
            //cms adjuster type
            var adjusterLookup = cmsSQLClient.GetLookupCodes(32, sqlCommandTimeout, env);

            CMSGetLookupCodes_Result adjType = new CMSGetLookupCodes_Result();

            if (role == ((int)CftRoleCodes.AdjustmentFirm).ToString())
            {
                var entType = adjusterLookup.Where(x => x.Description == TE3EEntityExt.GetEnumDescription(CMSAdjType.OutsideAdjuster)).Select(x => x).ToList();

                if (entType.Count() > 0)
                {
                    adjType.Code = entType.First().Code;
                    adjType.Description = entType.First().Description;
                }
            }
            else
            {
                if (paymentAuth)
                {
                    var entType = adjusterLookup.Where(x => x.Description == TE3EEntityExt.GetEnumDescription(CMSAdjType.IAmAdjuster)).Select(x => x).ToList();

                    if (entType.Count() > 0)
                    {
                        adjType.Code = entType.First().Code;
                        adjType.Description = entType.First().Description;
                    }
                }
                else
                {
                    var entType = adjusterLookup.Where(x => x.Description == TE3EEntityExt.GetEnumDescription(CMSAdjType.IDidNotHireAdjuster)).Select(x => x).ToList();

                    if (entType.Count() > 0)
                    {
                        adjType.Code = entType.First().Code;
                        adjType.Description = entType.First().Description;
                    }
                }
            }

            return adjType;
        }

        public static CMSCustomerProfile ConvertToCMSCustomerProfile(CustomerProfile customer)
        {
            return new CMSCustomerProfile()
            {
                ContactID = customer.e3EId,
                KenticoID = customer.kenticoId,
                Email = customer.email,
                Salutation = customer.salutation,
                FirstName = customer.firstName,
                LastName = customer.lastName,
                Phone = customer.phone,
                CompanyName = customer.companyName,
                CompanyAddress1 = customer.companyAddress1,
                CompanyAddress2 = customer.companyAddress2,
                CompanyAddressCity = customer.companyAddressCity,
                CompanyAddressState = customer.companyAddressState,
                CompanyAddressZip = customer.companyAddressZip,
                CompanyAddressCountry = customer.companyAddressCountry,
                CompanyType = customer.companyType,
                CompanyAddressLat = null,
                CompanyAddressLon = null,
                TimeStamp = DateTime.Now,
                IsProcessed = false,
                NumOfAttempts = 0,
            };
        }
        public static CustomerProfile ConvertToCustomerProfile(CMSCustomerProfile customer)
        {
            return new CustomerProfile()
            {
                e3EId = customer.ContactID,
                kenticoId = customer.KenticoID,
                email = customer.Email,
                salutation = customer.Salutation,
                firstName = customer.FirstName,
                lastName = customer.LastName,
                phone = customer.Phone,
                companyName = customer.CompanyName,
                companyAddress1 = customer.CompanyAddress1,
                companyAddress2 = customer.CompanyAddress2,
                companyAddressCity = customer.CompanyAddressCity,
                companyAddressState = customer.CompanyAddressState,
                companyAddressZip = customer.CompanyAddressZip,
                companyAddressCountry = customer.CompanyAddressCountry,
                companyType = customer.CompanyType,
            };
        }


        #region private methods

        private static CMSGetLookupCodes_Result GetConfirmationLetterType(CMSGetFullMatterDetails_Result matter, CMSSQLClientV2 cmsSQLClient, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        {
            //confirmation type
            var confTypes = cmsSQLClient.GetLookupCodes(3, sqlCommandTimeout, env);
            CMSGetLookupCodes_Result confType = new CMSGetLookupCodes_Result { Code = "STD", Description = "Standard" };

            if (matter.IsConfLetterStd == 1)
            {
                var confLetter = confTypes.Where(x => x.Description == "Standard").Select(x => x).ToList();

                if (confLetter.Count() > 0)
                {
                    confType.Code = confLetter.First().Code;
                    confType.Description = confLetter.First().Description;
                }
            }
            else if (matter.IsConfLetterLegal == 1)
            {
                var confLetter = confTypes.Where(x => x.Description == "Legal").Select(x => x).ToList();

                if (confLetter.Count() > 0)
                {
                    confType.Code = confLetter.First().Code;
                    confType.Description = confLetter.First().Description;
                }
            }
            else if (matter.IsConfLetterNatAgmt == 1)
            {
                var confLetter = confTypes.Where(x => x.Description == "National Agreement").Select(x => x).ToList();

                if (confLetter.Count() > 0)
                {
                    confType.Code = confLetter.First().Code;
                    confType.Description = confLetter.First().Description;
                }
            }
            else if (matter.IsConfLetterCAT == 1)
            {
                var confLetter = confTypes.Where(x => x.Description == "CAT").Select(x => x).ToList();

                if (confLetter.Count() > 0)
                {
                    confType.Code = confLetter.First().Code;
                    confType.Description = confLetter.First().Description;
                }
            }
            else if (matter.IsConfLetterEngSvcs == 1)
            {
                var confLetter = confTypes.Where(x => x.Description == "Engineering Services").Select(x => x).ToList();

                if (confLetter.Count() > 0)
                {
                    confType.Code = confLetter.First().Code;
                    confType.Description = confLetter.First().Description;
                }
            }
            else if (matter.IsConfLetterRtnr == 1)
            {
                var confLetter = confTypes.Where(x => x.Description == "Retainer").Select(x => x).ToList();

                if (confLetter.Count() > 0)
                {
                    confType.Code = confLetter.First().Code;
                    confType.Description = confLetter.First().Description;
                }
            }
            else if (matter.IsConfLetterSign == 1)
            {
                var confLetter = confTypes.Where(x => x.Description == "Signature").Select(x => x).ToList();

                if (confLetter.Count() > 0)
                {
                    confType.Code = confLetter.First().Code;
                    confType.Description = confLetter.First().Description;
                }
            }

            return confType;
        }

        private static CMSGetLookupCodes_Result GetConfirmationLetterType(CMSAssignment matter, CMSSQLClientV2 cmsSQLClient, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        {
            //confirmation type
            var confTypes = cmsSQLClient.GetLookupCodes(3, sqlCommandTimeout, env);
            CMSGetLookupCodes_Result confType = new CMSGetLookupCodes_Result { Code = "STD", Description = "Standard" };

            if (matter.IsConfLetterStd == 1)
            {
                var confLetter = confTypes.Where(x => x.Description == "Standard").Select(x => x).ToList();

                if (confLetter.Count() > 0)
                {
                    confType.Code = confLetter.First().Code;
                    confType.Description = confLetter.First().Description;
                }
            }
            else if (matter.IsConfLetterLegal == 1)
            {
                var confLetter = confTypes.Where(x => x.Description == "Legal").Select(x => x).ToList();

                if (confLetter.Count() > 0)
                {
                    confType.Code = confLetter.First().Code;
                    confType.Description = confLetter.First().Description;
                }
            }
            else if (matter.IsConfLetterNatAgmt == 1)
            {
                var confLetter = confTypes.Where(x => x.Description == "National Agreement").Select(x => x).ToList();

                if (confLetter.Count() > 0)
                {
                    confType.Code = confLetter.First().Code;
                    confType.Description = confLetter.First().Description;
                }
            }
            else if (matter.IsConfLetterCAT == 1)
            {
                var confLetter = confTypes.Where(x => x.Description == "CAT").Select(x => x).ToList();

                if (confLetter.Count() > 0)
                {
                    confType.Code = confLetter.First().Code;
                    confType.Description = confLetter.First().Description;
                }
            }
            else if (matter.IsConfLetterEngSvcs == 1)
            {
                var confLetter = confTypes.Where(x => x.Description == "Engineering Services").Select(x => x).ToList();

                if (confLetter.Count() > 0)
                {
                    confType.Code = confLetter.First().Code;
                    confType.Description = confLetter.First().Description;
                }
            }
            else if (matter.IsConfLetterRtnr == 1)
            {
                var confLetter = confTypes.Where(x => x.Description == "Retainer").Select(x => x).ToList();

                if (confLetter.Count() > 0)
                {
                    confType.Code = confLetter.First().Code;
                    confType.Description = confLetter.First().Description;
                }
            }
            else if (matter.IsConfLetterSign == 1)
            {
                var confLetter = confTypes.Where(x => x.Description == "Signature").Select(x => x).ToList();

                if (confLetter.Count() > 0)
                {
                    confType.Code = confLetter.First().Code;
                    confType.Description = confLetter.First().Description;
                }
            }

            return confType;
        }

        private static CMSGetLookupCodes_Result ConvertCMSPartyTypeTo3EAddtnlRole(string cmsPartyType)
        {
            CMSGetLookupCodes_Result te3eAdditionPartyRole = new CMSGetLookupCodes_Result();

            if (cmsPartyType == ((int)CMSPartyType.Insured).ToString())
            {
                te3eAdditionPartyRole.Description = TE3EEntityExt.GetEnumDescription(AdditionalPartiesRoles.Insured);
                te3eAdditionPartyRole.Code = ((int)AdditionalPartiesRoles.Insured).ToString();
            }
            else if (cmsPartyType == ((int)CMSPartyType.Claimant).ToString())
            {
                te3eAdditionPartyRole.Description = TE3EEntityExt.GetEnumDescription(AdditionalPartiesRoles.Claimant);
                te3eAdditionPartyRole.Code = ((int)AdditionalPartiesRoles.Claimant).ToString();
            }
            else if (cmsPartyType == ((int)CMSPartyType.PointOfContact).ToString())
            {
                te3eAdditionPartyRole.Description = TE3EEntityExt.GetEnumDescription(AdditionalPartiesRoles.Corporation);
                te3eAdditionPartyRole.Code = ((int)AdditionalPartiesRoles.Corporation).ToString();
            }
            else if (cmsPartyType == ((int)CMSPartyType.Corporation).ToString())
            {
                te3eAdditionPartyRole.Description = TE3EEntityExt.GetEnumDescription(AdditionalPartiesRoles.Corporation);
                te3eAdditionPartyRole.Code = ((int)AdditionalPartiesRoles.Corporation).ToString();
            }
            else if (cmsPartyType == ((int)CMSPartyType.Defendant).ToString())
            {
                te3eAdditionPartyRole.Description = TE3EEntityExt.GetEnumDescription(AdditionalPartiesRoles.Defendant);
                te3eAdditionPartyRole.Code = ((int)AdditionalPartiesRoles.Defendant).ToString();
            }
            else if (cmsPartyType == ((int)CMSPartyType.Plantiff).ToString())
            {
                te3eAdditionPartyRole.Description = TE3EEntityExt.GetEnumDescription(AdditionalPartiesRoles.Plaintiff);
                te3eAdditionPartyRole.Code = ((int)AdditionalPartiesRoles.Plaintiff).ToString();
            }
            else
            {
                te3eAdditionPartyRole.Description = MatterDefaultAttr.DefaultRoleDesc;
                te3eAdditionPartyRole.Code = MatterDefaultAttr.DefaultRole;
            }

            return te3eAdditionPartyRole;
        }

        private static CMSGetLookupCodes_Result Convert3EAddtnlRoleToCMSPartyType(string te3eAdditionPartyRole, CMSSQLClientV2 cmsSQLClient, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        {
            //cms party type
            var partyLookup = cmsSQLClient.GetLookupCodes(31, sqlCommandTimeout, env);

            CMSGetLookupCodes_Result cmsPartyType = new CMSGetLookupCodes_Result();

            if (te3eAdditionPartyRole == ((int)AdditionalPartiesRoles.Insured).ToString())
            {
                var partyType = partyLookup.Where(x => x.Description == TE3EEntityExt.GetEnumDescription(CMSPartyType.Insured)).Select(x => x).ToList();

                if (partyType.Count() > 0)
                {
                    cmsPartyType.Code = partyType.First().Code;
                    cmsPartyType.Description = partyType.First().Description;
                }
            }
            else if (te3eAdditionPartyRole == ((int)AdditionalPartiesRoles.Claimant).ToString())
            {
                var partyType = partyLookup.Where(x => x.Description == TE3EEntityExt.GetEnumDescription(CMSPartyType.Claimant)).Select(x => x).ToList();

                if (partyType.Count() > 0)
                {
                    cmsPartyType.Code = partyType.First().Code;
                    cmsPartyType.Description = partyType.First().Description;
                }
            }
            else
            {
                var partyType = partyLookup.Where(x => x.Description == TE3EEntityExt.GetEnumDescription(CMSPartyType.PointOfContact)).Select(x => x).ToList();

                if (partyType.Count() > 0)
                {
                    cmsPartyType.Code = partyType.First().Code;
                    cmsPartyType.Description = partyType.First().Description;
                }
            }

            return cmsPartyType;
        }

        public static CMSGetLookupCodes_Result ConvertCMSCliTypeToPayorDetRole(CMSSQLClientV2 cmsSQLClient, string clientTypeCode, string repType, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        {
            //Matter Payor Roles
            var cftPayorRoles = cmsSQLClient.GetLookupCodes(16, sqlCommandTimeout, env);

            //var cliType = cmsSQLClient.ConvertCliTypeByCode(clientTypeCode, sqlCommandTimeout, isDebug);

            CMSGetLookupCodes_Result cftPayRole = new CMSGetLookupCodes_Result();

            if (clientTypeCode == ((int)CMSClientType.InsuranceCompany).ToString())
            {
                var results = cftPayorRoles.Where(x => x.Code == ((int)CftRoleCodes.InsuranceCompany).ToString()).Select(x => x);
                cftPayRole = results.Count() > 0 ? results.First() : null;
            }
            else if (clientTypeCode == ((int)CMSClientType.ThirdPartyAdministrator).ToString()
                  || clientTypeCode == ((int)CMSClientType.IndependentAdjuster).ToString())
            {
                var results = cftPayorRoles.Where(x => x.Code == ((int)CftRoleCodes.AdjustmentFirm).ToString()).Select(x => x);
                cftPayRole = results.Count() > 0 ? results.First() : null;
            }
            else if (clientTypeCode == ((int)CMSClientType.Attorney).ToString())
            {
                //Representing
                var representing_CCC = cmsSQLClient.GetLookupCodes(22, sqlCommandTimeout, env);
                var representingType = representing_CCC.Where(r => r.Description == repType).Select(r => r).ToList();

                if (representingType.Count() > 0)
                {
                    var repType_CCC = representingType.First();
                    if (repType_CCC.Code == ((int)CMSRepType.Defendant).ToString())
                    {
                        var results = cftPayorRoles.Where(x => x.Code == ((int)CftRoleCodes.LawFirmDefendant).ToString()).Select(x => x);
                        cftPayRole = results.Count() > 0 ? results.First() : null;
                    }
                    else if (repType_CCC.Code == ((int)CMSRepType.Plaintiff).ToString())
                    {
                        var results = cftPayorRoles.Where(x => x.Code == ((int)CftRoleCodes.LawFirmPlaintiff).ToString()).Select(x => x);
                        cftPayRole = results.Count() > 0 ? results.First() : null;
                    }
                }
                else
                {
                    var results = cftPayorRoles.Where(x => x.Code == ((int)CftRoleCodes.LawFirmDefendant).ToString()).Select(x => x);
                    cftPayRole = results.Count() > 0 ? results.First() : null;
                }
            }
            else if (clientTypeCode == ((int)CMSClientType.Corporation).ToString())
            {
                var results = cftPayorRoles.Where(x => x.Code == ((int)CftRoleCodes.Corporation).ToString()).Select(x => x);
                cftPayRole = results.Count() > 0 ? results.First() : null;
            }
            else if (clientTypeCode == ((int)CMSClientType.GovernmentEntity).ToString())
            {
                var results = cftPayorRoles.Where(x => x.Code == ((int)CftRoleCodes.GovernmentMunicipality).ToString()).Select(x => x);
                cftPayRole = results.Count() > 0 ? results.First() : null;
            }

            return cftPayRole;
        }

        private static CMSGetLookupCodes_Result Convert3EAddtnlEntityToCMSLegalOrAttyType(string archetypeCode, CMSSQLClientV2 cmsSQLClient, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        {
            //cms legal or atty type
            var legalOrAttyLookup = cmsSQLClient.GetLookupCodes(28, sqlCommandTimeout, env);

            CMSGetLookupCodes_Result cmsLegalOrAttyType = new CMSGetLookupCodes_Result();

            ArchetypeCode archetype = (ArchetypeCode)Enum.Parse(typeof(ArchetypeCode), archetypeCode);

            if (archetype == ArchetypeCode.EntityPerson)
            {
                var entType = legalOrAttyLookup.Where(x => x.Description == TE3EEntityExt.GetEnumDescription(CMSLegalOrAttyType.Individual)).Select(x => x).ToList();

                if (entType.Count() > 0)
                {
                    cmsLegalOrAttyType.Code = entType.First().Code;
                    cmsLegalOrAttyType.Description = entType.First().Description;
                }
            }
            else
            {
                var entType = legalOrAttyLookup.Where(x => x.Description == TE3EEntityExt.GetEnumDescription(CMSLegalOrAttyType.Company)).Select(x => x).ToList();

                if (entType.Count() > 0)
                {
                    cmsLegalOrAttyType.Code = entType.First().Code;
                    cmsLegalOrAttyType.Description = entType.First().Description;
                }
            }

            return cmsLegalOrAttyType;
        }

        private static CMSGetLookupCodes_Result Convert3EAddtnlEntityToCMSEntityType(string archetypeCode, CMSSQLClientV2 cmsSQLClient, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        {
            //cms entity type
            var entityLookup = cmsSQLClient.GetLookupCodes(30, sqlCommandTimeout, env);

            CMSGetLookupCodes_Result cmsEntityType = new CMSGetLookupCodes_Result();

            ArchetypeCode archetype = (ArchetypeCode)Enum.Parse(typeof(ArchetypeCode), archetypeCode);

            if (archetype == ArchetypeCode.EntityPerson)
            {
                var entType = entityLookup.Where(x => x.Description == TE3EEntityExt.GetEnumDescription(CMSEntityType.Individual)).Select(x => x).ToList();

                if (entType.Count() > 0)
                {
                    cmsEntityType.Code = entType.First().Code;
                    cmsEntityType.Description = entType.First().Description;
                }
            }
            else
            {
                //cmsEntityType = TE3EEntityExt.GetEnumDescription(CMSEntityType.InsuranceCompany)
                //cmsEntityType = TE3EEntityExt.GetEnumDescription(CMSEntityType.ThirdPartyAdministrator)
                //cmsEntityType = TE3EEntityExt.GetEnumDescription(CMSEntityType.IndependentAdjuster)
                //cmsEntityType = TE3EEntityExt.GetEnumDescription(CMSEntityType.Attorney)
                //cmsEntityType = TE3EEntityExt.GetEnumDescription(CMSEntityType.GovernmentEntity)

                var entType = entityLookup.Where(x => x.Description == TE3EEntityExt.GetEnumDescription(CMSEntityType.Corporation)).Select(x => x).ToList();

                if (entType.Count() > 0)
                {
                    cmsEntityType.Code = entType.First().Code;
                    cmsEntityType.Description = entType.First().Description;
                }
            }

            return cmsEntityType;
        }

        private static string ConvertCMSEntityTypeTo3EArchetype(string cmsEntityType)
        {
            string archetypeCode = TE3EEntityExt.GetEnumDescription(ArchetypeCode.EntityOrg);

            if (cmsEntityType == ((int)CMSEntityType.Individual).ToString())
            {
                archetypeCode = TE3EEntityExt.GetEnumDescription(ArchetypeCode.EntityPerson);
            }
            else if (cmsEntityType == ((int)CMSEntityType.InsuranceCompany).ToString()
                || cmsEntityType == ((int)CMSEntityType.ThirdPartyAdministrator).ToString()
                || cmsEntityType == ((int)CMSEntityType.IndependentAdjuster).ToString()
                || cmsEntityType == ((int)CMSEntityType.Attorney).ToString()
                || cmsEntityType == ((int)CMSEntityType.Corporation).ToString()
                || cmsEntityType == ((int)CMSEntityType.GovernmentEntity).ToString())
            {
                archetypeCode = TE3EEntityExt.GetEnumDescription(ArchetypeCode.EntityOrg);
            }

            return archetypeCode;
        }


        private static CMSGetLookupCodes_Result ConvertTo3EPayorDetRole(CMSSQLClientV2 cmsSQLClient, string clientType, string repType, int sqlCommandTimeout, EnvEnum env = EnvEnum.DEV)
        {
            //Matter Payor Roles
            var cftPayorRoles = cmsSQLClient.GetLookupCodes(16, sqlCommandTimeout, env);

            CMSGetLookupCodes_Result cftPayorRole = new CMSGetLookupCodes_Result();

            if (clientType == TE3EEntityExt.GetEnumDescription(CMSClientType.InsuranceCompany))
            {
                var results = cftPayorRoles.Where(x => x.Description == TE3EEntityExt.GetEnumDescription(CftRoleCodes.InsuranceCompany)).Select(x => x);
                cftPayorRole = results.Count() > 0 ? results.First() : null;
            }
            else if (clientType == TE3EEntityExt.GetEnumDescription(CMSClientType.ThirdPartyAdministrator)
                  || clientType == TE3EEntityExt.GetEnumDescription(CMSClientType.IndependentAdjuster))
            {
                var results = cftPayorRoles.Where(x => x.Description == TE3EEntityExt.GetEnumDescription(CftRoleCodes.AdjustmentFirm)).Select(x => x);
                cftPayorRole = results.Count() > 0 ? results.First() : null;
            }
            else if (clientType == TE3EEntityExt.GetEnumDescription(CMSClientType.Attorney))
            {
                //Representing
                var representing_CCC = cmsSQLClient.GetLookupCodes(22, sqlCommandTimeout, env);
                var representingType = representing_CCC.Where(r => r.Description == repType).Select(r => r).ToList();

                if (representingType.Count() > 0)
                {
                    var repType_CCC = representingType.First();
                    if (repType_CCC.Description == TE3EEntityExt.GetEnumDescription(CMSRepType.Defendant))
                    {
                        var results = cftPayorRoles.Where(x => x.Description == TE3EEntityExt.GetEnumDescription(CftRoleCodes.LawFirmDefendant)).Select(x => x);
                        cftPayorRole = results.Count() > 0 ? results.First() : null;
                    }
                    else if (repType_CCC.Description == TE3EEntityExt.GetEnumDescription(CMSRepType.Plaintiff))
                    {
                        var results = cftPayorRoles.Where(x => x.Description == TE3EEntityExt.GetEnumDescription(CftRoleCodes.LawFirmPlaintiff)).Select(x => x);
                        cftPayorRole = results.Count() > 0 ? results.First() : null;
                    }
                }
            }
            else if (clientType == TE3EEntityExt.GetEnumDescription(CMSClientType.Corporation))
            {
                var results = cftPayorRoles.Where(x => x.Description == TE3EEntityExt.GetEnumDescription(CftRoleCodes.Corporation)).Select(x => x);
                cftPayorRole = results.Count() > 0 ? results.First() : null;
            }
            else if (clientType == TE3EEntityExt.GetEnumDescription(CMSClientType.GovernmentEntity))
            {
                var results = cftPayorRoles.Where(x => x.Description == TE3EEntityExt.GetEnumDescription(CftRoleCodes.GovernmentMunicipality)).Select(x => x);
                cftPayorRole = results.Count() > 0 ? results.First() : null;
            }

            return cftPayorRole;
        }

        #endregion private methods
    }
}
