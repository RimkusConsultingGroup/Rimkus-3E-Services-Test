using Microsoft.AspNetCore.JsonPatch.Operations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using TE3EEntityFramework.Client.RCGKENTCMS;
using TE3EEntityFramework.Data.KenticoCMS;
using TE3EEntityFramework.Data.KenticoCMS.RCGKENTCMS;
using TE3EEntityFramework.Data.Te3e.CMS.CMS.Definition;
using TE3EEntityFramework.Data.Te3e.CMS.Definition;
using TE3EEntityFramework.Datasource;
using TE3EEntityFramework.Datasource.RCGKENTCMS.DataModel;

namespace TE3EEntityFramework.Extension
{
    public static class TE3EEntityExt
    {
        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute),
                false);

            if (attributes != null &&
                attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }


        public static bool IsLatLonValid(decimal? Lat, decimal? Lon)
        {
            return (Lat != null && Lon != null && Lat > -90 && Lat < 90 && Lon > -180 && Lon < 180);
        }

        public static void SendEmailNotification(string fromAddr, string toAddr, string cc, string subject, string body, Attachment attachment = null, bool IsBodyHTML = true)
        {
            var smtpClient = new SmtpClient();
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.EnableSsl = false;
            smtpClient.Host = "mail.rimkus.com";
            smtpClient.Port = 25;

            var mailMessage = new MailMessage
            {
                From = new MailAddress(fromAddr),
                Subject = subject,
                Body = body,
                IsBodyHtml = IsBodyHTML,
            };

            List<string> emailTos = toAddr.Split(';').Where(x => !string.IsNullOrEmpty(x)).ToList();
            emailTos.ForEach(x => mailMessage.To.Add(x.Trim()));

            if (!string.IsNullOrEmpty(cc?.Trim()))
            {
                List<string> emaiCC = cc.Split(';').Where(x => !string.IsNullOrEmpty(x)).ToList();
                emaiCC.ForEach(x => mailMessage.CC.Add(x.Trim()));
            }
            if (attachment != null)
            {
                mailMessage.Attachments.Add(attachment);
            }
            smtpClient.Send(mailMessage);
        }

        public static object GetValueForEnum(this List<Patch> patches, ePath pathEnum)
        {
            var pathStr = pathEnum.ToString();
            var patch = patches.FirstOrDefault(x => x.path.Equals(pathStr, StringComparison.OrdinalIgnoreCase));
            if (patch != null && patch.value != null && !string.IsNullOrEmpty(patch?.value?.ToString()))
            {
                return patch.value;
            }
            return null;
        }

        //[Obsolete]
        //public static CMSJob ToCMSJob(this Assignment assignment, CMSSQLClient cmsSQLClient, int sqlCommandTimeout, bool isDebug = false)
        //{
        //    var job = new CMSJob()
        //    {
        //        assignment = new CMSAssignment(),
        //        additionalParties = new List<CMSAdditionalParty>(),
        //        coConsultants = new List<CMSCoConsultant>(),
        //        incidentLocations = new List<CMSIncidentLocation>(),
        //        orderingClient = new CMSOrderingClient(),
        //        payorDetails = new List<CMSPayorDetail>()
        //    };

        //    #region map data fields to assignment

        //    //map data fields to assignment

        //    job.assignment.KenticoID = assignment.KenticoID ?? "";

        //    #region not expecting this on new record, but when it creates record in 3e we need to send back for them to update in json patch

        //    job.assignment.E3EID = assignment.E3EID;
        //    job.assignment.MattStatus = assignment.MatterStatusID;
        //    job.assignment.MattStatusDesc = assignment.MatterStatus;

        //    #endregion not expecting this on new record, but when it creates record in 3e we need to send back for them to update in json patch

        //    #region Ordering Client Contact Section

        //    job.orderingClient.ContactSalutation = assignment.OrderingClientContactSalutation;
        //    job.orderingClient.ContactFirstName = assignment.OrderingClientContactFirstName;
        //    job.orderingClient.ContactLastName = assignment.OrderingClientContactLastName;
        //    job.orderingClient.ContactEmail = assignment.OrderingClientContactEmail ?? "";
        //    job.orderingClient.ContactPhoneNo = assignment.OrderingClientContactPhoneNo ?? "";

        //    #region not expecting this on new record, but when it creates record in 3e we need to send back for them to update in json patch

        //    job.orderingClient.ClientIndex = assignment.OrderingClientID.ToInt();
        //    job.orderingClient.ClientNumber = assignment.OrderingClientNumber;

        //    #endregion not expecting this on new record, but when it creates record in 3e we need to send back for them to update in json patch

        //    #endregion Ordering Client Contact Section

        //    #region Ordering Client Company Section

        //    //# Section: Client Company
        //    job.orderingClient.CompanyName = assignment.OrderingClientCompanyName;
        //    job.orderingClient.CompanyAddress1 = assignment.OrderingClientCompanyAddress1;
        //    job.orderingClient.CompanyAddress2 = assignment.OrderingClientCompanyAddress2;
        //    job.orderingClient.CompanyAddressCity = assignment.OrderingClientCompanyAddressCity;
        //    job.orderingClient.CompanyAddressState = assignment.OrderingClientCompanyAddressState;
        //    job.orderingClient.CompanyAddressZip = assignment.OrderingClientCompanyAddressZip;

        //    //todo: need to convert ConvertCliTypeByCode
        //    job.orderingClient.CompanyType = assignment.OrderingClientCompanyType;
        //    job.orderingClient.CompanyTypeDesc = assignment.OrderingClientCompanyTypeDesc;

        //    job.orderingClient.CompanyAddressCountry = assignment.OrderingClientCompanyAddressCountry;
        //    job.orderingClient.CompanyLatAddress = assignment.OrderingClientCompanyAddressLat.ToDecimal(); ;
        //    job.orderingClient.CompanyLonAddress = assignment.OrderingClientCompanyAddressLon.ToDecimal(); ;

        //    #region add ordering client to payor detail

        //    CMSPayorDetail orderingPayorDet = new CMSPayorDetail()
        //    {
        //        Relationship = CftRelationship_CCC.Ordering.ToString("D2"), //02
        //        RelationshipDesc = TE3EEntityExt.GetEnumDescription(CftRelationship_CCC.Ordering),
        //        RoleDesc = assignment.OrderingClientCompanyType,
        //        Role = ConvertCMSPayorRole(assignment.OrderingClientCompanyType), //get role code from RoleDesc in this case assignment.AdjusterType
        //        PercentFee = Convert.ToDecimal("0"),

        //        PayorName = assignment.OrderingClientCompanyName,
        //        FirstName = assignment.OrderingClientContactFirstName,
        //        LastName = assignment.OrderingClientContactLastName,
        //        Email = assignment.OrderingClientContactEmail ?? "",
        //        PhoneNumber = assignment.OrderingClientContactPhoneNo ?? "",
        //        Street = assignment.OrderingClientCompanyAddress1 ?? "",
        //        City = assignment.OrderingClientCompanyAddressCity ?? "",
        //        State = assignment.OrderingClientCompanyAddressState ?? "",
        //        ZipCode = assignment.OrderingClientCompanyAddressZip ?? "",
        //        Country = assignment.OrderingClientCompanyAddressCountry
        //    };

        //    assignment.ReferenceNumbers.ForEach(x =>
        //    {
        //        var refType = cmsSQLClient.GetRefType(x.ReferenceIndex.ToInt() ?? 0, sqlCommandTimeout, isDebug);
        //        switch (refType)
        //        {
        //            case "Claim":
        //                orderingPayorDet.ClaimNumber = x.Number;
        //                break;

        //            case "Policy":
        //                orderingPayorDet.Policy_CCC = x.Number;
        //                break;

        //            case "File":
        //                orderingPayorDet.File_CCC = x.Number;
        //                break;

        //            case "Reference":
        //                orderingPayorDet.ReferenceNumber = x.Number;
        //                break;

        //            case "UMR":
        //                orderingPayorDet.UMR_CCC = x.Number;
        //                break;

        //            case "Tracking":
        //                orderingPayorDet.Tracking_CCC = x.Number;
        //                break;

        //            case "PONumber":
        //                orderingPayorDet.PONumber_CCC = x.Number;
        //                break;
        //        }
        //    });

        //    job.payorDetails.Add(orderingPayorDet);

        //    #endregion add ordering client to payor detail

        //    #endregion Ordering Client Company Section

        //    #region Incident Information Section

        //    job.assignment.DateOccurence = assignment.DateOccurence.ToDateTime();
        //    job.assignment.Narrative_UnformattedText = assignment.DescOccurence;
        //    job.assignment.ScopeOfWork = assignment.NeedAnswered;
        //    job.assignment.SpecialInstructions = assignment.SpecialInstructions;

        //    //# Section: Incident Information
        //    if (assignment.IncidentYN ?? false)
        //    {
        //        assignment.IncidentLocations.ForEach(x =>
        //        {
        //            CMSIncidentLocation incidentLocation = new CMSIncidentLocation();
        //            incidentLocation.KenticoID = x.KenticoID;

        //            #region not expecting this on new record, but when it creates record in 3e we need to send back for them to update in json patch

        //            incidentLocation.SiteIndex = x.SiteIndex.ToInt();

        //            #endregion not expecting this on new record, but when it creates record in 3e we need to send back for them to update in json patch

        //            //dont need these
        //            incidentLocation.MattSiteID = x.MattSiteID;
        //            incidentLocation.AddrIndex = x.AddressID.ToInt();

        //            incidentLocation.StreetOccurrence = x.StreetOccurence;
        //            incidentLocation.CityOccurrence = x.CityOccurence;
        //            incidentLocation.StateOccurrence = x.StateOccurence;
        //            incidentLocation.ZipCodeOccurrence = x.ZipCodeOccurence;
        //            incidentLocation.CountyOccurrence = x.CountyOccurence;
        //            incidentLocation.CountryOccurrence = x.CountryOccurence;
        //            incidentLocation.LatOccurrence = x.LatOccurence.ToDecimal();
        //            incidentLocation.LonOccurrence = x.LonOccurence.ToDecimal();

        //            job.incidentLocations.Add(incidentLocation);
        //        });
        //    }

        //    #endregion Incident Information Section

        //    #region Combined Fields - in use

        //    #region Adjuster Information

        //    // Not adding adjuster to payorDetails as it is should be already included in incoming payors list
        //    // yes, need to add adjuster
        //    job.payorDetails.Add(new CMSPayorDetail()
        //    {
        //        //Relationship = ??? need to map relationship ()
        //        //assignment.AuthYN = outsideAdj.RoleDesc.Equals("I am the Adjuster", StringComparison.OrdinalIgnoreCase);
        //        // if assignment.AuthYN then RelationshipDesc = Paying, Relationship = 03
        //        //public enum CftRelationship_CCC
        //        //{
        //        //    [Description("Both")]
        //        //    Both = 1,
        //        //    [Description("Ordering")]
        //        //    Ordering = 2,
        //        //    [Description("Paying")]
        //        //    Paying = 3,
        //        //    [Description("SamSideInvolved")]
        //        //    SamSideInvolved = 4,
        //        //    [Description("Against")]
        //        //    Against = 5
        //        //}

        //        RoleDesc = assignment.AdjusterType,
        //        //Role = get role code from RoleDesc in this case assignment.AdjusterType
        //        //public enum CftRoleCodes
        //        //{
        //        //    [Description("Corporation")]
        //        //    Corporation = 100,
        //        //    [Description("Claimant")]
        //        //    Claimant = 200,
        //        //    [Description("Insured")]
        //        //    Insured = 300,
        //        //    [Description("Plaintiff")]
        //        //    Plaintiff = 400,
        //        //    [Description("Defendant")]
        //        //    Defendant = 500,
        //        //    [Description("Insurance Company")]
        //        //    InsuranceCompany = 600,
        //        //    [Description("Adjustment Firm")]
        //        //    AdjustmentFirm = 700,
        //        //    [Description("Law Firm Plaintiff")]
        //        //    LawFirmPlaintiff = 800,
        //        //    [Description("Law Firm Defendant")]
        //        //    LawFirmDefendant = 900,
        //        //    //Government = 950,
        //        //    [Description("Government/Municipality")]
        //        //    GovernmentMunicipality = 1000,
        //        //    [Description("Individual")]
        //        //    Individual = 1100,
        //        //    [Description("Third Party Administrator (TPA)")]
        //        //    ThirdPartyAdministratorTPA = 1200,
        //        //    [Description("Independent Adjuster (IA)")]
        //        //    IndependentAdjusterIA = 1300,
        //        //    //Attorney = 1400,
        //        //    //GovernmentEntity = 1500,
        //        //    [Description("None of the above")]
        //        //    Noneoftheabove = 1600
        //        //}

        //        PayorName = assignment.OutsideCompName,
        //        FirstName = assignment.OutsideFirstName,
        //        LastName = assignment.OutsideLastName,
        //        Email = assignment.OutsideAdjEmail,
        //        PhoneNumber = assignment.OutsideAdjPhone,
        //        Street = assignment.OutsideAddr1,
        //        City = assignment.OutsideCity,
        //        State = assignment.OutsideState,
        //        ZipCode = assignment.OutsideZip,
        //        Country = assignment.OutsideCountry
        //    });

        //    #endregion Adjuster Information

        //    #region Legal Information [Only show if OrderClientCompanyType = Attorney]

        //    if (assignment.OrderingClientCompanyType == TE3EEntityExt.GetEnumDescription(CftRoleCodes.LawFirmPlaintiff)//"Law Firm Plaintiff"
        //      || assignment.OrderingClientCompanyType == TE3EEntityExt.GetEnumDescription(CftRoleCodes.LawFirmDefendant))//"Law Firm Defendant")
        //    {
        //        job.orderingClient.AdditionalInstr = $"{assignment.ParaFirstName} {assignment.ParaLastName}";
        //        job.orderingClient.RepresentingDesc = assignment.RepType;

        //        //TODO:
        //        job.orderingClient.CompanyType = assignment.LegalClientType;
        //        job.orderingClient.Style = assignment.Style;
        //        job.orderingClient.Court = assignment.Court;
        //        job.orderingClient.CauseNumber = assignment.CauseNumber;

        //        //#region Legal Information [Only show if LegalClientType = Individual;]

        //        ////if (!string.IsNullOrEmpty(assignment.InsFirstName))
        //        ////{
        //        ////    var indvlInsPartyInvolved = new CMSAdditionalParty()
        //        ////    {
        //        ////        PartyName = $"{assignment.InsFirstName} {assignment.InsLastName}",
        //        ////        HomePhone = assignment.InsPOCNo,

        //        ////    }
        //        ////}

        //        //var individualInsParty = additionalParties.Where(x => x.ArchetypeCode == TE3EEntityExt.GetEnumDescription(TE3EConnect.te3eObjects.Automation.ArchetypeCode.EntityPerson)
        //        //                                                && x.Role == ((int)AdditionalPartiesRoles.Insured).ToString())
        //        //                                       .Select(x => x).ToList();

        //        //if (individualInsParty.Count() > 0)
        //        //{
        //        //    CMSGetFullMatterAdditionalPartiesDetails_Result indvlInsPartyInvolved = individualInsParty.First();
        //        //    //fullNameParts = ParseFullname(indvlInsPartyInvolved.PartyName);

        //        //    assignment.InsFirstName = indvlInsPartyInvolved.FirstName;
        //        //    assignment.InsLastName = indvlInsPartyInvolved.LastName;
        //        //    assignment.InsPOCNo = indvlInsPartyInvolved.HomePhone;
        //        //}

        //        //#endregion Legal Information [Only show if LegalClientType = Individual;]

        //        //#region Legal Information [Only show if LegalClientType != Individual;] - company or government entity
        //        //var compOrGovInsParty = additionalParties.Where(x => x.ArchetypeCode == TE3EEntityExt.GetEnumDescription(TE3EConnect.te3eObjects.Automation.ArchetypeCode.EntityOrg)
        //        //                                                && x.Role == ((int)AdditionalPartiesRoles.Insured).ToString())
        //        //                                       .Select(x => x).ToList();
        //        //if (compOrGovInsParty.Count() > 0)
        //        //{
        //        //    CMSGetFullMatterAdditionalPartiesDetails_Result compOrGovInsPartyInvolved = compOrGovInsParty.First();

        //        //    assignment.InsClientName = compOrGovInsPartyInvolved.PartyName;
        //        //    assignment.InsLegalPOCNo = compOrGovInsPartyInvolved.HomePhone;
        //        //    assignment.InsLegalPOC = $"{orderingClient.OrderingClientContactFirstName} {orderingClient.OrderingClientContactLastName}";
        //        //    assignment.InsNo = orderingClient.OrderingClientContactPhoneNo;
        //        //}
        //        //#endregion Legal Information [Only show if LegalClientType != Individual;] - company or government entity
        //    }

        //    #endregion Legal Information [Only show if OrderClientCompanyType = Attorney]

        //    #region Opposing Party Law Firm

        //    if (assignment.OpposingYN ?? false)
        //    {
        //        job.payorDetails.Add(new CMSPayorDetail()
        //        {
        //            PayorName = assignment.OppName,
        //            FirstName = assignment.OpenTimekeeper,
        //            LastName = assignment.OppAttyLastName,
        //            Street = assignment.OppStreetAddr1,
        //            City = assignment.OppCity,
        //            State = assignment.OppState,
        //            ZipCode = assignment.OppZip,
        //            Country = assignment.OppCountry
        //        });
        //        if (assignment.OpposingParties != null && assignment.OpposingParties.Any())
        //        {
        //            assignment.OpposingParties.ForEach(x =>
        //            {
        //                //if (x.AttorneysClientType.Equals("Plaintiff"))
        //                //{
        //                //    job.additionalParties.Add(new CMSAdditionalParty()
        //                //    {
        //                //        EntIndex = x.EntityIndex,
        //                //        PartyName = x.OpposingAttorneysClientName,
        //                //        RoleDesc = x.AttorneysClientType,
        //                //        KenticoID = x.KenticoID
        //                //    });
        //                //}
        //                //if (x.AttorneysClientType.Equals("Defendant"))
        //                //{
        //                if (x.AttorneysClientType.Equals("Plaintiff"))
        //                {
        //                    job.additionalParties.Add(new CMSAdditionalParty()
        //                    {
        //                        EntIndex = x.EntityIndex, //no entity index for new record
        //                        PartyName = x.OpposingAttorneysClientName,
        //                        RoleDesc = "Plaintiff",
        //                        Role = "", //get the code from roledesc
        //                        KenticoID = x.KenticoID
        //                    });
        //                }
        //                else if (x.AttorneysClientType.Equals("Defendant"))
        //                {
        //                    job.additionalParties.Add(new CMSAdditionalParty()
        //                    {
        //                        EntIndex = x.EntityIndex, //no entity index for new record
        //                        PartyName = x.OpposingAttorneysClientName,
        //                        RoleDesc = "Defendant",
        //                        Role = "", //get the code from roledesc
        //                        KenticoID = x.KenticoID
        //                    });
        //                }
        //                //}
        //            }

        //            );
        //        }
        //    }

        //    #endregion Opposing Party Law Firm

        //    #region Parties (Additional Parties)

        //    assignment.Parties.ForEach(x =>
        //    {
        //        CMSAdditionalParty party = new CMSAdditionalParty()
        //        {
        //            KenticoID = x.KenticoID,
        //            MatterNumber = assignment.MatterNumber,
        //            Email = x.Email,
        //            EntIndex = x.EntityIndex, //no entity index for new record
        //            EntityTypeDesc = x.EntityType, //always set this to Additional Parties type
        //            HomePhone = x.Phone,
        //            WorkPhone = x.Phone,
        //            MobilePhone = x.Phone,
        //            PartyName = string.IsNullOrEmpty($"{x.FirstName}{x.LastName}".Trim()) ? x.CompanyName : $"{x.FirstName} {x.LastName}".Trim(),
        //            PartyType = x.PartyType,
        //            RoleDesc = x.PartyType,
        //            Role = "", //get the code from roledesc
        //        };
        //        job.additionalParties.Add(party);
        //    });

        //    #endregion Parties (Additional Parties)

        //    #region CoConsultants

        //    //check if there's coconsultant
        //    if (assignment.CoConsultantsYN ?? false)
        //    {
        //        assignment.CoConsultants.ForEach(x =>
        //        {
        //            CMSCoConsultant coConsultant = new CMSCoConsultant();
        //            //coConsultant.CoConsultantID = x.CoConsultantIndex.ToString(); // CMSWebClient CoConsultantIndex is int but here it is Guid TODO
        //            coConsultant.KenticoID = x.KenticoID;
        //            //coConsultant.co
        //            coConsultant.CoConsultantName = x.CoConsultantName ?? "";
        //            coConsultant.CoConsultantNumber = x.CoConsultantNumber.ToString() ?? "";

        //            job.coConsultants.Add(coConsultant);
        //        });
        //    }

        //    #endregion CoConsultants

        //    #region Multipayor Information

        //    if (assignment.Payors != null)
        //    {
        //        job.assignment.SpecialInstructions = assignment.MultipayorInvoicing;
        //        assignment.Payors.ForEach(x =>
        //        {
        //            CMSPayorDetail payor = new CMSPayorDetail()
        //            {
        //                PayorIndex = x.PayorIndex.ToInt(),
        //                City = x.PayCity,
        //                Country = x.PayCountry,
        //                E3EID = assignment.E3EID,
        //                Email = x.PayEmail,
        //                FirstName = x.PayFirstName,
        //                LastName = x.PayLastName,
        //                LatAddress = x.PayLat.ToDecimal(),
        //                LonAddress = x.PayLon.ToDecimal(),
        //                MatterNumber = assignment.MatterNumber,
        //                PayorName = x.PayName,
        //                PercentFee = x.InvoicePercentage.ToDecimal(),
        //                PhoneNumber = x.PayPhone,
        //                ReferenceNumber = x.ReferenceNumber,
        //                RoleDesc = x.PayRole,
        //                State = x.PayState,
        //                Street = x.PayAddr1,
        //                TimeStamp = DateTime.Now,
        //                ZipCode = x.PayZip
        //            };
        //            job.payorDetails.Add(payor);
        //        });
        //    }
        //    else
        //    {
        //        //ordering client is also payor client with 100% percent
        //        orderingPayorDet.RelationshipDesc = "Both";
        //        orderingPayorDet.Relationship = "01";
        //        orderingPayorDet.PercentFee = 100;
        //    }

        //    #endregion Multipayor Information

        //    #region add ordering client with reference number

        //    //CMSPayorDetail orderingPayorDet = new CMSPayorDetail()
        //    //{
        //    //    PayorIndex = assignment.OrderingClientID.ToInt(),
        //    //    City = assignment.OrderingClientCompanyAddressCity,
        //    //    Country = assignment.OrderingClientCompanyAddressCountry,
        //    //    Email = assignment.OrderingClientContactEmail,
        //    //    FirstName = assignment.OrderingClientContactFirstName,
        //    //    LastName = assignment.OrderingClientContactLastName,
        //    //    LatAddress = assignment.OrderingClientCompanyAddressLat.ToDecimal();,
        //    //    LonAddress = assignment.OrderingClientCompanyAddressLon.ToDecimal();,
        //    //    MatterNumber = assignment.MatterNumber,
        //    //    PayorName = assignment.OrderingClientCompanyName,
        //    //    //PercentFee = x.InvoicePercentage.ToDecimal();,
        //    //    PhoneNumber = assignment.OrderingClientContactPhoneNo,
        //    //    RoleDesc = assignment.OrderingClientCompanyType,
        //    //    State = assignment.OrderingClientCompanyAddressState,
        //    //    Street = $"{assignment.OrderingClientCompanyAddress1} {assignment.OrderingClientCompanyAddress2}",
        //    //    TimeStamp = DateTime.Now,
        //    //    ZipCode = assignment.OrderingClientCompanyAddressZip
        //    //};
        //    //assignment.ReferenceNumbers.ForEach(x =>
        //    //{
        //    //    var refType = cmsSQLClient.GetRefType(x.ReferenceIndex.CheckIfNull<int>(), sqlCommandTimeout, isDebug);
        //    //    switch (refType)
        //    //    {
        //    //        case "Claim":
        //    //            orderingPayorDet.ClaimNumber = x.Number;
        //    //            break;
        //    //        case "Policy":
        //    //            orderingPayorDet.Policy_CCC = x.Number;
        //    //            break;
        //    //        case "File":
        //    //            orderingPayorDet.File_CCC = x.Number;
        //    //            break;
        //    //        case "Reference":
        //    //            orderingPayorDet.ReferenceNumber = x.Number;
        //    //            break;
        //    //        case "UMR":
        //    //            orderingPayorDet.UMR_CCC = x.Number;
        //    //            break;
        //    //        case "Tracking":
        //    //            orderingPayorDet.Tracking_CCC = x.Number;
        //    //            break;
        //    //        case "PONumber":
        //    //            orderingPayorDet.PONumber_CCC = x.Number;
        //    //            break;
        //    //    }
        //    //});
        //    //job.payorDetails.Add(orderingPayorDet);

        //    #endregion add ordering client with reference number

        //    #endregion Combined Fields - in use

        //    //# Section: Invoice Instructions
        //    job.assignment.InvoiceTo = assignment.SpecialInvoice;

        //    #region Internal Use Only Section

        //    //# Section: Internal Use Only=
        //    job.assignment.MatterName = assignment.MatterName;
        //    job.assignment.MatterNumber = assignment.MatterNumber;
        //    job.assignment.RelatedMatter = assignment.RelatedMatter.ToInt();
        //    job.assignment.Currency = assignment.Currency;
        //    job.assignment.OpenTimekeeperName = assignment.OpenTimekeeper;
        //    job.assignment.RetainerAmount = assignment.RetainerAmount.ToDecimal();
        //    job.assignment.FixedPrice = Convert.ToByte(assignment.FixedPrice ?? false);
        //    job.assignment.DNENotes = assignment.DneNotes;
        //    job.assignment.WebOriginated = Convert.ToByte(assignment.WebOriginated ?? false);
        //    job.assignment.FeesTaxCode = assignment.FeesTaxCode;
        //    job.assignment.EntryDate = assignment.EntryDate.ToDateTime();
        //    job.assignment.EBilling = Convert.ToByte(assignment.EBilling ?? false);
        //    job.assignment.ElecBillingType = assignment.EBillingType;
        //    job.assignment.ElectronicNumber = assignment.ElectronicNumber;
        //    job.assignment.IsConfLetterCAT = Convert.ToByte(assignment.ConfirmationLetterType?.Equals("CAT") ?? false);
        //    job.assignment.IsConfLetterEngSvcs = Convert.ToByte(assignment.ConfirmationLetterType?.Equals("Engineering Services") ?? false);
        //    job.assignment.IsConfLetterLegal = Convert.ToByte(assignment.ConfirmationLetterType?.Equals("Legal") ?? false);
        //    job.assignment.IsConfLetterNatAgmt = Convert.ToByte(assignment.ConfirmationLetterType?.Equals("National Agreement") ?? false);
        //    job.assignment.IsConfLetterRtnr = Convert.ToByte(assignment.ConfirmationLetterType?.Equals("Retainer") ?? false);
        //    job.assignment.IsConfLetterSign = Convert.ToByte(assignment.ConfirmationLetterType?.Equals("Signature") ?? false);
        //    job.assignment.IsConfLetterStd = Convert.ToByte(assignment.ConfirmationLetterType?.Equals("Standard") ?? false);
        //    job.assignment.ROFTemplateDesc = assignment.RofTemplate;
        //    job.assignment.StartDate1 = assignment.StartDate1.ToDateTime();
        //    job.assignment.BillingTimekeeperName = assignment.BillingTimekeeper;
        //    job.assignment.ResponsibleTimekeeperName = assignment.ResponsibleTimekeeper;
        //    job.assignment.SupervisingTimekeeperName = assignment.SupervisingTimekeeper;
        //    job.assignment.OfficeName = assignment.Office;
        //    job.assignment.SectionDesc = assignment.Section;
        //    job.assignment.ArrangementDesc = assignment.Arrangement;
        //    job.assignment.DepartmentDesc = assignment.Department;
        //    job.assignment.PracticeGroupDesc = assignment.PracticeGroup;
        //    job.assignment.PTAGroup = assignment.Pta1;
        //    job.assignment.IndustryGroupDesc = assignment.IndustryGroup;
        //    job.assignment.TechnicalReviewerNumber = assignment.TechnicalReviewerNumber.ToInt();
        //    job.assignment.TechincalReviewerName = assignment.TechnicalReviewerName;
        //    job.assignment.EngineerOfRecordNo = assignment.EngineerOfRecordNumber.ToInt();
        //    job.assignment.EngineerOfRecordName = assignment.EngineerOfRecordName;
        //    job.assignment.BDManagerNo = assignment.BdManagerNumber.ToInt();
        //    job.assignment.BDManagerName = assignment.BdManagerName;
        //    job.assignment.StartDate2 = assignment.StartDate2.ToDateTime();
        //    job.assignment.SpecialClientInstruction = assignment.SpecialClientInstruction;
        //    job.assignment.RateDesc = assignment.Rate;
        //    job.assignment.RateExceptGroup = assignment.RateExceptGroup;
        //    job.assignment.TimeType = assignment.TimeType;
        //    job.assignment.FlatFeeAmount = assignment.FlatFeeAmount.ToDecimal();
        //    job.assignment.Budget = assignment.Budget.ToDecimal();

        //    #endregion Internal Use Only Section

        //    #endregion map data fields to assignment

        //    job.assignment.KenticoID = assignment.KenticoID;
        //    job.assignment.E3EID = assignment.E3EID;
        //    job.assignment.MatterNumber = assignment.MatterNumber;
        //    job.assignment.TimeStamp = DateTime.Now;
        //    job.assignment.MatterIndex = assignment.E3EID;

        //    job.orderingClient.KenticoID = assignment.KenticoID;
        //    job.orderingClient.E3EID = assignment.E3EID;
        //    job.orderingClient.MatterNumber = assignment.MatterNumber;
        //    job.orderingClient.TimeStamp = DateTime.Now;
        //    job.orderingClient.MatterIndex = assignment.E3EID;

        //    job.additionalParties.ForEach(x =>
        //    {
        //        x.MatterNumber = assignment.MatterNumber;
        //        x.E3EID = assignment.E3EID;
        //        x.MatterIndex = assignment.E3EID;
        //        x.TimeStamp = DateTime.Now;
        //    });
        //    job.coConsultants.ForEach(x =>
        //    {
        //        x.MatterNumber = assignment.MatterNumber;
        //        x.E3EID = assignment.E3EID;
        //        x.MatterIndex = assignment.E3EID;
        //        x.TimeStamp = DateTime.Now;
        //    });
        //    job.incidentLocations.ForEach(x =>
        //    {
        //        x.MatterNumber = assignment.MatterNumber;
        //        x.E3EID = assignment.E3EID;
        //        x.MatterIndex = assignment.E3EID;
        //        x.TimeStamp = DateTime.Now;
        //    });
        //    job.payorDetails.ForEach(x =>
        //    {
        //        x.MatterNumber = assignment.MatterNumber;
        //        x.E3EID = assignment.E3EID;
        //        x.MatterIndex = assignment.E3EID;
        //        x.TimeStamp = DateTime.Now;
        //    });

        //    return job;
        //}

        //public static Assignment CMSJobToAssignment(this CMSJob cmsJob, CMSSQLClient cmsSQLClient, int sqlCommandTimeout, bool isDebug = false)
        //{
        //    Assignment assignment = new Assignment();

        //    #region fetching full matter details
        //    //get matter detail
        //    var matter = cmsSQLClient.GetFullMatterDetails(mattIndex, sqlCommandTimeout, isDebug);

        //    //if (matter.ClientNumber != clientNo.ToString("D7"))
        //    //    throw new CustomerNotMatchException($"Customer ID Not Match. No customer with ID = {clientNo.ToString("D7")}");

        //    //get ordering client
        //    var orderingClient = cmsSQLClient.GetFullMatterOrderingClientDetails(mattIndex, sqlCommandTimeout, isDebug);

        //    //get incident location
        //    var incidentLocations = cmsSQLClient.GetFullMatterIncidentLocationDetails(mattIndex, sqlCommandTimeout, isDebug);

        //    //get coconsultants
        //    var coConsultants = cmsSQLClient.GetFullMatterCoConsultantDetails(mattIndex, sqlCommandTimeout, isDebug);

        //    //get matter payor details
        //    var matterPayorDet = cmsSQLClient.GetFullMatterPayorDetails(mattIndex, sqlCommandTimeout, isDebug);

        //    //get additional parties
        //    var additionalParties = cmsSQLClient.GetFullMatterAdditionalPartiesDetails(mattIndex, sqlCommandTimeout, isDebug);

        //    #endregion fetching full matter details

        //    #region map data fields to assignment
        //    //map data fields to assignment
        //    assignment.E3EID = matter.E3EID;
        //    assignment.KenticoID = matter.KenticoID ?? "";
        //    assignment.MatterStatus = matter.CurrentStatus;
        //    assignment.MatterStatusID = matter.CurrentStatusCode;

        //    #region Ordering Client Contact Section
        //    //# Section: Client Contact
        //    //FullNameParts fullNameParts = ParseFullname(orderingClient.OrderClientContactName);

        //    assignment.OrderingClientContactSalutation = orderingClient.OrderingClientSalutation;
        //    assignment.OrderingClientContactFirstName = orderingClient.OrderingClientContactFirstName;
        //    assignment.OrderingClientContactLastName = orderingClient.OrderingClientContactLastName;
        //    assignment.OrderingClientContactEmail = orderingClient.OrderingClientContactEmail ?? "";
        //    assignment.OrderingClientContactPhoneNo = orderingClient.OrderingClientContactPhoneNo ?? "";
        //    assignment.OrderingClientID = orderingClient.OrderingClientIndex?.ToString();
        //    assignment.OrderingClientNumber = orderingClient.OrderingClientNumber;
        //    #endregion Ordering Client Contact Section

        //    #region Ordering Client Company Section
        //    //# Section: Client Company
        //    var cmsCliType = CMSMapper.ConvertToCMSCliType(cmsSQLClient, orderingClient.OrderingClientCompanyType, sqlCommandTimeout, isDebug);

        //    assignment.OrderingClientCompanyName = orderingClient.OrderingClientCompanyName;
        //    assignment.OrderingClientCompanyAddress1 = orderingClient.OrderingClientCompanyAddress1 ?? "";
        //    assignment.OrderingClientCompanyAddress2 = orderingClient.OrderingClientCompanyAddress2 ?? "";
        //    assignment.OrderingClientCompanyAddressCity = orderingClient.OrderingClientCompanyAddressCity ?? "";
        //    assignment.OrderingClientCompanyAddressState = orderingClient.OrderingClientCompanyAddressState ?? "";
        //    assignment.OrderingClientCompanyAddressZip = orderingClient.OrderingClientCompanyAddressZip ?? "";
        //    assignment.OrderingClientCompanyType = cmsCliType != null ? cmsCliType.Description : orderingClient.OrderingClientCompanyType;
        //    assignment.OrderingClientCompanyAddressCountry = orderingClient.OrderingClientCompanyAddressCountry;
        //    assignment.OrderingClientCompanyAddressLat = orderingClient.OrderingClientCompanyLatAddress?.ToString() ?? "";
        //    assignment.OrderingClientCompanyAddressLon = orderingClient.OrderingClientCompanyLonAddress?.ToString() ?? "";
        //    #endregion Ordering Client Company Section

        //    #region Incident Information Section
        //    //# Section: Incident Information
        //    assignment.IncidentYN = Convert.ToDateTime(matter.DateOfOccurence?.ToUniversalTime()) != DateTime.MinValue;
        //    assignment.DateOccurence = Convert.ToDateTime(matter.DateOfOccurence?.ToUniversalTime()).ToString("yyyy-MM-ddT00:00:00");
        //    assignment.DateUnknown = Convert.ToDateTime(matter.DateOfOccurence?.ToUniversalTime()) == DateTime.MinValue;
        //    assignment.DescOccurence = matter.Narrative_UnformattedText ?? "";
        //    assignment.NeedAnswered = matter.ScopeOfWork ?? "";
        //    assignment.SpecialInstructions = matter.SpecialInstructions;

        //    assignment.IncidentLocations = new List<IncidentLocation>();
        //    incidentLocations.ForEach(x =>
        //    {
        //        IncidentLocation incidentLocation = new IncidentLocation();
        //        incidentLocation.SiteIndex = x.SiteID.ToString();
        //        incidentLocation.KenticoID = x.KenticoID;
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
        //    var adjuster = matterPayorDet.Where(x => (x.RelationshipDesc == TE3EEntityExt.GetEnumDescription(CftRelationship_CCC.Ordering)
        //                                           || x.RelationshipDesc == TE3EEntityExt.GetEnumDescription(CftRelationship_CCC.Both))
        //                                           && x.RoleDesc == TE3EEntityExt.GetEnumDescription(CftRoleCodes.AdjustmentFirm))
        //                                 .Select(x => x).ToList();

        //    if (adjuster.Count() > 0)
        //    {
        //        var outsideAdj = adjuster.First();

        //        assignment.AdjusterType = CMSMapper.ConvertToCMSAdjusterType(outsideAdj.RoleDesc, Convert.ToBoolean(outsideAdj.PaymentAuthority)); //I am the adjuster, Outside adjuster, I did not hire an adjuster
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

        //    if (orderingClient.OrderingClientCompanyType == TE3EEntityExt.GetEnumDescription(CftRoleCodes.LawFirmPlaintiff)
        //      || orderingClient.OrderingClientCompanyType == TE3EEntityExt.GetEnumDescription(CftRoleCodes.LawFirmDefendant))
        //    {
        //        //var addInstr = orderingClient.OrderClientAdditionalInstr.Split(',').Where(x => !string.IsNullOrEmpty(x)).Select(x => x.Trim()).ToList();

        //        assignment.ParaFirstName = orderingClient.OrderingClientAdditionalInstr ?? ""; //orderingClient.OrderClientAdditionalInstr
        //        assignment.ParaLastName = "";
        //        assignment.RepType = orderingClient.RepresentingDesc ?? "";

        //        //todo:
        //        //Individual, Company, Government Entity (equivalent to entityperson = individual, entityorg = company and gov entity
        //        assignment.Style = orderingClient.Style ?? "";
        //        assignment.Court = orderingClient.Court ?? "";
        //        assignment.CauseNumber = orderingClient.CauseNumber ?? "";
        //        assignment.SuitYN = !string.IsNullOrEmpty(assignment.CauseNumber);

        //        #region Legal Information [Only show if LegalClientType = Individual;]
        //        var individualInsParty = additionalParties.Where(x => x.ArchetypeCode == TE3EEntityExt.GetEnumDescription(TE3EEntityFramework.Data.KenticoCMS.RCGKENTCMS.ArchetypeCode.EntityPerson)
        //                                                        && x.Role == ((int)AdditionalPartiesRoles.Insured).ToString())
        //                                               .Select(x => x).ToList();

        //        if (individualInsParty.Count() > 0)
        //        {
        //            CMSGetFullMatterAdditionalPartiesDetails_Result indvlInsPartyInvolved = individualInsParty.First();

        //            assignment.LegalClientType = TE3EEntityExt.GetEnumDescription(CMSLegalOrAttyType.Individual);
        //            assignment.InsFirstName = indvlInsPartyInvolved.FirstName;
        //            assignment.InsLastName = indvlInsPartyInvolved.LastName;
        //            assignment.InsPOCNo = indvlInsPartyInvolved.HomePhone ?? "";
        //        }

        //        #endregion Legal Information [Only show if LegalClientType = Individual;]

        //        #region Legal Information [Only show if LegalClientType != Individual;] - company or government entity
        //        var compOrGovInsParty = additionalParties.Where(x => x.ArchetypeCode == TE3EEntityExt.GetEnumDescription(TE3EEntityFramework.Data.KenticoCMS.RCGKENTCMS.ArchetypeCode.EntityOrg)
        //                                                        && x.Role == ((int)AdditionalPartiesRoles.Insured).ToString())
        //                                               .Select(x => x).ToList();
        //        if (compOrGovInsParty.Count() > 0)
        //        {
        //            CMSGetFullMatterAdditionalPartiesDetails_Result compOrGovInsPartyInvolved = compOrGovInsParty.First();

        //            assignment.LegalClientType = TE3EEntityExt.GetEnumDescription(CMSLegalOrAttyType.Company);
        //            assignment.InsClientName = compOrGovInsPartyInvolved.PartyName ?? "";
        //            assignment.InsLegalPOCNo = compOrGovInsPartyInvolved.HomePhone ?? "";
        //            assignment.InsLegalPOC = $"{orderingClient.OrderingClientContactFirstName} {orderingClient.OrderingClientContactLastName}";
        //            assignment.InsNo = orderingClient.OrderingClientContactPhoneNo ?? "";
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
        //                OpposingParty opposingParty = new OpposingParty();
        //                opposingParty.EntityIndex = x.EntityIndex?.ToString() ?? "";
        //                opposingParty.AttorneysClientType = x.ArchetypeCode == TE3EEntityExt.GetEnumDescription(ArchetypeCode.EntityPerson)
        //                                                    ? TE3EEntityExt.GetEnumDescription(CMSLegalOrAttyType.Individual)
        //                                                    : TE3EEntityExt.GetEnumDescription(CMSLegalOrAttyType.Company);

        //                opposingParty.OpposingAttorneysClientName = x.PartyName;
        //                assignment.OpposingParties.Add(opposingParty);
        //            });
        //        }
        //        else if (defendantOpposingParty)
        //        {
        //            var opposingParties = additionalParties.Where(x => x.RoleDesc == "Defendant").Select(x => x).ToList();

        //            opposingParties.ForEach(x =>
        //            {
        //                OpposingParty opposingParty = new OpposingParty();
        //                opposingParty.EntityIndex = x.EntityIndex?.ToString() ?? "";
        //                opposingParty.AttorneysClientType = x.ArchetypeCode == TE3EEntityExt.GetEnumDescription(ArchetypeCode.EntityPerson)
        //                                                    ? TE3EEntityExt.GetEnumDescription(CMSLegalOrAttyType.Individual)
        //                                                    : TE3EEntityExt.GetEnumDescription(CMSLegalOrAttyType.Company);

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
        //        if (!assignment.OpposingParties.Any(o => o.EntityIndex == x.EntityIndex.ToString()))
        //        {
        //            Party party = new Party();
        //            party.EntityIndex = x.EntityIndex?.ToString() ?? "";
        //            party.EntityType = Convert3EAddtnlEntityToCMSEntityType(x.ArchetypeCode);
        //            party.PartyType = Convert3EAddtnlRoleToCMSPartyType(x.RoleDesc);

        //            if (x.ArchetypeCode == TE3EEntityExt.GetEnumDescription(ArchetypeCode.EntityPerson))
        //            {
        //                party.FirstName = x.FirstName;
        //                party.LastName = x.LastName;
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
        //        payor.PayRole = x.RoleDesc;
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

        //    assignment.LibertyInsuranceType = matter.InsuranceType ?? "";
        //    assignment.LibertyClaimType = matter.ClaimType ?? "";

        //    #region Populating Reference Numbers

        //    matterPayorDet.ForEach(x =>
        //    {
        //        //only populate for ordering client
        //        if (x.ClientIndex == orderingClient.OrderingClientIndex)
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

        //            if (!string.IsNullOrEmpty(x.PONumber))
        //            {
        //                ReferenceNumber referenceNumber = new ReferenceNumber();
        //                referenceNumber.ReferenceIndex = cmsSQLClient.GetRefNumberID(TE3EEntityExt.GetEnumDescription(ReferenceNumberType.PO), sqlCommandTimeout, isDebug).ToString();
        //                referenceNumber.Number = x.PONumber;
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
        //    assignment.MatterName = matter.MattName;
        //    assignment.MatterNumber = matter.MattNumber;
        //    assignment.RelatedMatter = matter.RelatedMatter?.ToString() ?? "";
        //    assignment.Currency = matter.Currency;
        //    assignment.OpenTimekeeper = matter.OpenTimekeeperName;
        //    assignment.RetainerAmount = matter.RetainerAmount?.ToString() ?? "";
        //    assignment.FixedPrice = matter.FixedPrice == 1;
        //    assignment.DneNotes = matter.DNENotes ?? "";
        //    assignment.WebOriginated = matter.WebOriginated == 1;
        //    assignment.FeesTaxCode = matter.FeesTaxCode ?? "";
        //    assignment.EntryDate = Convert.ToDateTime(matter.EntryDate?.ToUniversalTime()).ToString("yyyy-MM-ddT00:00:00");
        //    assignment.EBilling = matter.EBilling == 1;
        //    assignment.EBillingType = matter.ElecBillingType ?? "";
        //    assignment.ElectronicNumber = matter.ElectronicNumber ?? "";
        //    assignment.ConfirmationLetterType = GetConfirmationLetterType(matter);
        //    assignment.RofTemplate = matter.ROFTemplateDesc?.ToString() ?? "";
        //    assignment.StartDate1 = Convert.ToDateTime(matter.StartDate1?.ToUniversalTime()).ToString("yyyy-MM-ddT00:00:00");
        //    assignment.BillingTimekeeper = matter.BillingTimekeeperName;
        //    assignment.ResponsibleTimekeeper = matter.ResponsibleTimekeeperName;
        //    assignment.SupervisingTimekeeper = matter.SupervisorTimekeeperName;
        //    assignment.Office = matter.OfficeName;
        //    assignment.Section = matter.SectionDesc;
        //    assignment.Arrangement = matter.ArrangementDesc;
        //    assignment.Department = matter.DepartmentDesc;
        //    assignment.PracticeGroup = matter.PracticeGroupDesc;
        //    assignment.Pta1 = matter.PTAGroup ?? "";
        //    assignment.IndustryGroup = matter.IndustryGroupDesc ?? "";
        //    assignment.TechnicalReviewerNumber = matter.TechnicalReviewerNumber?.ToString() ?? "";
        //    assignment.TechnicalReviewerName = matter.TechnicalReviewerName ?? "";
        //    assignment.EngineerOfRecordNumber = matter.EngineerOfRecordNo?.ToString() ?? "";
        //    assignment.EngineerOfRecordName = matter.EngineerOfRecordName ?? "";
        //    assignment.BdManagerNumber = matter.BDManagerNo?.ToString() ?? "";
        //    assignment.BdManagerName = matter.BDManagerName ?? "";
        //    assignment.StartDate2 = Convert.ToDateTime(matter.StartDate2?.ToUniversalTime()).ToString("yyyy-MM-ddT00:00:00");
        //    assignment.SpecialClientInstruction = matter.SpecialClientInstruction;
        //    assignment.Rate = matter.RateDesc;
        //    assignment.RateExceptGroup = matter.RateExceptionGroup;
        //    assignment.TimeType = matter.TimeType ?? "";
        //    assignment.FlatFeeAmount = matter.FlatFeeAmount?.ToString() ?? "";
        //    assignment.Budget = matter.BudgetAmount?.ToString() ?? "";

        //    #endregion Internal Use Only Section

        //    #endregion map data fields to assignment

        //    return assignment;
        //}

        public static List<Operation> AssignmentPatchGeneration(Assignment oldAssignment, Assignment newAssignment)
        {
            var patchOperations = new List<Operation>();

            var assignmentOps = JsonPatchHelper.CompareAndGenerate(oldAssignment, newAssignment);
            assignmentOps.RemoveChilds($"/{nameof(Assignment.IncidentLocations)}");
            assignmentOps.RemoveChilds($"/{nameof(Assignment.Payors)}");
            assignmentOps.RemoveChilds($"/{nameof(Assignment.Parties)}");
            assignmentOps.RemoveChilds($"/{nameof(Assignment.CoConsultants)}");
            assignmentOps.RemoveChilds($"/{nameof(Assignment.ReferenceNumbers)}");
            assignmentOps.RemoveChilds($"/{nameof(Assignment.OpposingParties)}");

            patchOperations.AddRange(assignmentOps);

            try
            {
                patchOperations.AddRange(JsonPatchHelper.CompareListAndGenerate(oldAssignment.IncidentLocations, newAssignment.IncidentLocations, nameof(Assignment.IncidentLocations), nameof(IncidentLocation.KenticoID)));

                patchOperations.AddRange(JsonPatchHelper.CompareListAndGenerate(oldAssignment.Payors, newAssignment.Payors, nameof(Assignment.Payors), nameof(Payor.KenticoID)));

                patchOperations.AddRange(JsonPatchHelper.CompareListAndGenerate(oldAssignment.Parties, newAssignment.Parties, nameof(Assignment.Parties), nameof(Party.KenticoID)));

                patchOperations.AddRange(JsonPatchHelper.CompareListAndGenerate(oldAssignment.CoConsultants, newAssignment.CoConsultants, nameof(Assignment.CoConsultants), nameof(CoConsultant.KenticoID)));

                patchOperations.AddRange(JsonPatchHelper.CompareListAndGenerate(oldAssignment.ReferenceNumbers, newAssignment.ReferenceNumbers, nameof(Assignment.ReferenceNumbers), nameof(ReferenceNumber.KenticoID)));

                patchOperations.AddRange(JsonPatchHelper.CompareListAndGenerate(oldAssignment.OpposingParties, newAssignment.OpposingParties, nameof(Assignment.OpposingParties), nameof(OpposingParty.KenticoID)));
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return patchOperations;
        }

        public static void ApplyPatchToAssignment(PatchAssignmentDocument patchAssignment, Assignment eAssignment)
        {
            try
            {
                var allPatchAssignment = patchAssignment.patch.Select(x => new Operation()
                {
                    path = x.path,
                    op = x.op,
                    value = x.value
                }).ToList();

                #region Case for Update OperationType.Replace
                {

                    var incLocPatches = allPatchAssignment.FindAndGroupChildUpdateOps($"/{nameof(Assignment.IncidentLocations)}");
                    allPatchAssignment.RemoveChilds($"/{nameof(Assignment.IncidentLocations)}", OperationType.Replace);

                    var payorsPatches = allPatchAssignment.FindAndGroupChildUpdateOps($"/{nameof(Assignment.Payors)}");
                    allPatchAssignment.RemoveChilds($"/{nameof(Assignment.Payors)}", OperationType.Replace);

                    var partiesPatches = allPatchAssignment.FindAndGroupChildUpdateOps($"/{nameof(Assignment.Parties)}");
                    allPatchAssignment.RemoveChilds($"/{nameof(Assignment.Parties)}", OperationType.Replace);

                    var coconsultPatches = allPatchAssignment.FindAndGroupChildUpdateOps($"/{nameof(Assignment.CoConsultants)}");
                    allPatchAssignment.RemoveChilds($"/{nameof(Assignment.CoConsultants)}", OperationType.Replace);

                    var refNumsPatches = allPatchAssignment.FindAndGroupChildUpdateOps($"/{nameof(Assignment.ReferenceNumbers)}");
                    allPatchAssignment.RemoveChilds($"/{nameof(Assignment.ReferenceNumbers)}", OperationType.Replace);

                    var opPartiesPatches = allPatchAssignment.FindAndGroupChildUpdateOps($"/{nameof(Assignment.OpposingParties)}");
                    allPatchAssignment.RemoveChilds($"/{nameof(Assignment.OpposingParties)}", OperationType.Replace);

                    if (allPatchAssignment.Any())
                    {
                        allPatchAssignment.Where(x => x.OperationType == OperationType.Replace).ToList().ApplyPatch(eAssignment);
                    }

                    if (incLocPatches.Any())
                    {
                        foreach (var item in incLocPatches)
                        {
                            IncidentLocation tobePatched = null;
                            if (int.TryParse(item.Key, out int id))
                            {
                                tobePatched = eAssignment.IncidentLocations.FirstOrDefault(x => x.SiteIndex.Equals(item.Key));
                            }
                            else
                            {
                                tobePatched = eAssignment.IncidentLocations.FirstOrDefault(x => x.KenticoID.Equals(item.Key));
                            }
                            item.Value.ApplyPatch(tobePatched);
                        }
                    }

                    if (payorsPatches.Any())
                    {
                        foreach (var item in payorsPatches)
                        {
                            Payor tobePatched = null;
                            if (int.TryParse(item.Key, out int id))
                            {
                                tobePatched = eAssignment.Payors.FirstOrDefault(x => x.PayorIndex.Equals(item.Key));
                            }
                            else
                            {
                                tobePatched = eAssignment.Payors.FirstOrDefault(x => x.KenticoID.Equals(item.Key));
                            }
                            item.Value.ApplyPatch(tobePatched);
                        }
                    }

                    if (partiesPatches.Any())
                    {
                        foreach (var item in partiesPatches)
                        {
                            Party tobePatched = null;
                            if (int.TryParse(item.Key, out int id))
                            {
                                tobePatched = eAssignment.Parties.FirstOrDefault(x => x.EntityIndex.Equals(item.Key));
                            }
                            else
                            {
                                tobePatched = eAssignment.Parties.FirstOrDefault(x => x.KenticoID.Equals(item.Key));
                            }
                            item.Value.ApplyPatch(tobePatched);
                        }
                    }

                    if (coconsultPatches.Any())
                    {
                        foreach (var item in coconsultPatches)
                        {
                            CoConsultant tobePatched = null;
                            if (int.TryParse(item.Key, out int id))
                            {
                                tobePatched = eAssignment.CoConsultants.FirstOrDefault(x => x.CoConsultantIndex.Equals(item.Key));
                            }
                            else
                            {
                                tobePatched = eAssignment.CoConsultants.FirstOrDefault(x => x.KenticoID.Equals(item.Key));
                            }
                            item.Value.ApplyPatch(tobePatched);
                        }
                    }

                    if (refNumsPatches.Any())
                    {
                        foreach (var item in refNumsPatches)
                        {
                            ReferenceNumber tobePatched = null;
                            if (int.TryParse(item.Key, out int id))
                            {
                                tobePatched = eAssignment.ReferenceNumbers.FirstOrDefault(x => x.ReferenceIndex.Equals(item.Key));
                            }
                            else
                            {
                                tobePatched = eAssignment.ReferenceNumbers.FirstOrDefault(x => x.KenticoID.Equals(item.Key));
                            }
                            item.Value.ApplyPatch(tobePatched);
                        }
                    }

                    if (opPartiesPatches.Any())
                    {
                        foreach (var item in opPartiesPatches)
                        {
                            OpposingParty tobePatched = null;
                            if (int.TryParse(item.Key, out int id))
                            {
                                tobePatched = eAssignment.OpposingParties.FirstOrDefault(x => x.EntityIndex.Equals(item.Key));
                            }
                            else
                            {
                                tobePatched = eAssignment.OpposingParties.FirstOrDefault(x => x.KenticoID.Equals(item.Key));
                            }
                            item.Value.ApplyPatch(tobePatched);
                        }
                    }
                }
                #endregion Case for Update OperationType.Replace

                #region Case for Delete OperationType.Remove
                {

                    allPatchAssignment.FindChilds($"/{nameof(Assignment.IncidentLocations)}", OperationType.Remove)
                        .ForEach(y =>
                        {
                            var key = y.path.Split('/')[2];
                            IncidentLocation tobePatched = null;
                            if (int.TryParse(key, out int id))
                            {
                                tobePatched = eAssignment.IncidentLocations.FirstOrDefault(x => x.MattSiteID.Equals(key));
                            }
                            else
                            {
                                tobePatched = eAssignment.IncidentLocations.FirstOrDefault(x => x.KenticoID.Equals(key));
                            }
                            eAssignment.IncidentLocations.Remove(tobePatched);
                        });

                    allPatchAssignment.FindChilds($"/{nameof(Assignment.Payors)}", OperationType.Remove)
                        .ForEach(y =>
                        {
                            var key = y.path.Split('/')[2];
                            Payor tobePatched = null;
                            if (int.TryParse(key, out int id))
                            {
                                tobePatched = eAssignment.Payors.FirstOrDefault(x => x.PayorIndex.Equals(key));
                            }
                            else
                            {
                                tobePatched = eAssignment.Payors.FirstOrDefault(x => x.KenticoID.Equals(key));
                            }
                            eAssignment.Payors.Remove(tobePatched);
                        });

                    allPatchAssignment.FindChilds($"/{nameof(Assignment.Parties)}", OperationType.Remove)
                        .ForEach(y =>
                        {
                            var key = y.path.Split('/')[2];
                            Party tobePatched = null;
                            if (int.TryParse(key, out int id))
                            {
                                tobePatched = eAssignment.Parties.FirstOrDefault(x => x.EntityIndex.Equals(key));
                            }
                            else
                            {
                                tobePatched = eAssignment.Parties.FirstOrDefault(x => x.KenticoID.Equals(key));
                            }
                            eAssignment.Parties.Remove(tobePatched);
                        });

                    allPatchAssignment.FindChilds($"/{nameof(Assignment.CoConsultants)}", OperationType.Remove)
                        .ForEach(y =>
                        {
                            var key = y.path.Split('/')[2];
                            CoConsultant tobePatched = null;
                            if (int.TryParse(key, out int id))
                            {
                                tobePatched = eAssignment.CoConsultants.FirstOrDefault(x => x.CoConsultantIndex.Equals(key));
                            }
                            else
                            {
                                tobePatched = eAssignment.CoConsultants.FirstOrDefault(x => x.KenticoID.Equals(key));
                            }
                            eAssignment.CoConsultants.Remove(tobePatched);
                        });

                    allPatchAssignment.FindChilds($"/{nameof(Assignment.ReferenceNumbers)}", OperationType.Remove)
                        .ForEach(y =>
                        {
                            var key = y.path.Split('/')[2];
                            ReferenceNumber tobePatched = null;
                            if (int.TryParse(key, out int id))
                            {
                                tobePatched = eAssignment.ReferenceNumbers.FirstOrDefault(x => x.ReferenceIndex.Equals(key));
                            }
                            else
                            {
                                tobePatched = eAssignment.ReferenceNumbers.FirstOrDefault(x => x.KenticoID.Equals(key));
                            }
                            eAssignment.ReferenceNumbers.Remove(tobePatched);
                        });

                    allPatchAssignment.FindChilds($"/{nameof(Assignment.OpposingParties)}", OperationType.Remove)
                        .ForEach(y =>
                        {
                            var key = y.path.Split('/')[2];
                            OpposingParty tobePatched = null;
                            if (int.TryParse(key, out int id))
                            {
                                tobePatched = eAssignment.OpposingParties.FirstOrDefault(x => x.EntityIndex.Equals(key));
                            }
                            else
                            {
                                tobePatched = eAssignment.OpposingParties.FirstOrDefault(x => x.KenticoID.Equals(key));
                            }
                            eAssignment.OpposingParties.Remove(tobePatched);
                        });
                }

                #endregion

                #region Case for Delete OperationType.Add
                {

                    allPatchAssignment.FindChilds($"/{nameof(Assignment.IncidentLocations)}", OperationType.Add)
                        .ForEach(y =>
                        {
                            eAssignment.IncidentLocations.Add(JsonConvertSerializeAndDeserializeObj<IncidentLocation>(y.value));
                        });

                    allPatchAssignment.FindChilds($"/{nameof(Assignment.Payors)}", OperationType.Add)
                        .ForEach(y =>
                        {
                            eAssignment.Payors.Add(JsonConvertSerializeAndDeserializeObj<Payor>(y.value));
                        });

                    allPatchAssignment.FindChilds($"/{nameof(Assignment.Parties)}", OperationType.Add)
                        .ForEach(y =>
                        {
                            eAssignment.Parties.Add(JsonConvertSerializeAndDeserializeObj<Party>(y.value));
                        });

                    allPatchAssignment.FindChilds($"/{nameof(Assignment.CoConsultants)}", OperationType.Add)
                        .ForEach(y =>
                        {
                            eAssignment.CoConsultants.Add(JsonConvertSerializeAndDeserializeObj<CoConsultant>(y.value));
                        });

                    allPatchAssignment.FindChilds($"/{nameof(Assignment.ReferenceNumbers)}", OperationType.Add)
                        .ForEach(y =>
                        {
                            eAssignment.ReferenceNumbers.Add(JsonConvertSerializeAndDeserializeObj<ReferenceNumber>(y.value));
                        });

                    allPatchAssignment.FindChilds($"/{nameof(Assignment.OpposingParties)}", OperationType.Add)
                        .ForEach(y =>
                        {
                            eAssignment.OpposingParties.Add(JsonConvertSerializeAndDeserializeObj<OpposingParty>(y.value));
                        });
                }

                #endregion
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to parse Incoming JSON patch update.");
            }
        }

        public static T JsonConvertSerializeAndDeserializeObj<T>(object obj)
        {
            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(obj));
        }


        public static void ApplyPatchOperationsToCmsJob(CMSJob oldCMSJob, CMSJob newCMSJob)
        {
            var newCMSJOBCopy = JsonConvert.DeserializeObject<CMSJob>(JsonConvert.SerializeObject(newCMSJob));

            var patchOperations = new List<Operation>();

            patchOperations.AddRange(JsonPatchHelper.CompareAndGenerate(oldCMSJob, newCMSJOBCopy));
            patchOperations.RemoveChilds($"/{nameof(CMSJob.incidentLocations)}");
            patchOperations.RemoveChilds($"/{nameof(CMSJob.payorDetails)}");
            patchOperations.RemoveChilds($"/{nameof(CMSJob.additionalParties)}");
            patchOperations.RemoveChilds($"/{nameof(CMSJob.coConsultants)}");

            try
            {
                patchOperations.AddRange(JsonPatchHelper.CompareListAndGenerate(oldCMSJob.incidentLocations, newCMSJOBCopy.incidentLocations, nameof(CMSJob.incidentLocations), nameof(CMSIncidentLocation.SubItemKenticoID)));
                patchOperations.AddRange(JsonPatchHelper.CompareListAndGenerate(oldCMSJob.payorDetails, newCMSJOBCopy.payorDetails, nameof(CMSJob.payorDetails), nameof(CMSPayorDetail.SubItemKenticoID)));
                patchOperations.AddRange(JsonPatchHelper.CompareListAndGenerate(oldCMSJob.additionalParties, newCMSJOBCopy.additionalParties, nameof(CMSJob.additionalParties), nameof(CMSAdditionalParty.SubItemKenticoID)));
                patchOperations.AddRange(JsonPatchHelper.CompareListAndGenerate(oldCMSJob.coConsultants, newCMSJOBCopy.coConsultants, nameof(CMSJob.coConsultants), nameof(CMSCoConsultant.SubItemKenticoID)));

                patchOperations.RemoveChilds($"/{nameof(CMSJob.assignment.TimeStamp)}");

            }
            catch (Exception ex)
            {
                throw ex;
            }

            newCMSJob.incidentLocations.ForEach(x => x.SvcOp = TE3EEntityExt.GetEnumDescription(SvcOps.Ignore));
            newCMSJob.payorDetails.ForEach(x => x.SvcOp = TE3EEntityExt.GetEnumDescription(SvcOps.Ignore));
            newCMSJob.additionalParties.ForEach(x => x.SvcOp = TE3EEntityExt.GetEnumDescription(SvcOps.Ignore));
            newCMSJob.coConsultants.ForEach(x => x.SvcOp = TE3EEntityExt.GetEnumDescription(SvcOps.Ignore));

            // Edit
            patchOperations.FindAndGroupChildUpdateOps($"/{nameof(CMSJob.incidentLocations)}").ToList().ForEach(x =>
            {
                newCMSJob.incidentLocations.FirstOrDefault(y => y.SubItemKenticoID == (string.IsNullOrWhiteSpace(x.Key) ? null : x.Key)).SvcOp = TE3EEntityExt.GetEnumDescription(SvcOps.Edit);
            });
            patchOperations.FindAndGroupChildUpdateOps($"/{nameof(CMSJob.payorDetails)}").ToList().ForEach(x =>
            {
                newCMSJob.payorDetails.FirstOrDefault(y => y.SubItemKenticoID == (string.IsNullOrWhiteSpace(x.Key) ? null : x.Key)).SvcOp = TE3EEntityExt.GetEnumDescription(SvcOps.Edit);
            });
            patchOperations.FindAndGroupChildUpdateOps($"/{nameof(CMSJob.additionalParties)}").ToList().ForEach(x =>
            {
                newCMSJob.additionalParties.FirstOrDefault(y => y.SubItemKenticoID == (string.IsNullOrWhiteSpace(x.Key) ? null : x.Key)).SvcOp = TE3EEntityExt.GetEnumDescription(SvcOps.Edit);
            });
            patchOperations.FindAndGroupChildUpdateOps($"/{nameof(CMSJob.coConsultants)}").ToList().ForEach(x =>
            {
                newCMSJob.coConsultants.FirstOrDefault(y => y.SubItemKenticoID == (string.IsNullOrWhiteSpace(x.Key) ? null : x.Key)).SvcOp = TE3EEntityExt.GetEnumDescription(SvcOps.Edit);
            });

            // Add
            if (patchOperations.FindChilds($"/{nameof(CMSJob.incidentLocations)}", OperationType.Add).Any())
            {
                var existingSubKenticoIds = oldCMSJob.incidentLocations.Select(x => x.SubItemKenticoID).ToList();
                newCMSJob.incidentLocations.Where(x => !existingSubKenticoIds.Contains(x.SubItemKenticoID)).ToList().ForEach(x => x.SvcOp = TE3EEntityExt.GetEnumDescription(SvcOps.Add));
            }
            if (patchOperations.FindChilds($"/{nameof(CMSJob.payorDetails)}", OperationType.Add).Any())
            {
                var existingSubKenticoIds = oldCMSJob.payorDetails.Select(x => x.SubItemKenticoID).ToList();
                newCMSJob.payorDetails.Where(x => !existingSubKenticoIds.Contains(x.SubItemKenticoID)).ToList().ForEach(x => x.SvcOp = TE3EEntityExt.GetEnumDescription(SvcOps.Add));
            }
            if (patchOperations.FindChilds($"/{nameof(CMSJob.additionalParties)}", OperationType.Add).Any())
            {
                var existingSubKenticoIds = oldCMSJob.additionalParties.Select(x => x.SubItemKenticoID).ToList();
                newCMSJob.additionalParties.Where(x => !existingSubKenticoIds.Contains(x.SubItemKenticoID)).ToList().ForEach(x => x.SvcOp = TE3EEntityExt.GetEnumDescription(SvcOps.Add));
            }
            if (patchOperations.FindChilds($"/{nameof(CMSJob.coConsultants)}", OperationType.Add).Any())
            {
                var existingSubKenticoIds = oldCMSJob.coConsultants.Select(x => x.SubItemKenticoID).ToList();
                newCMSJob.coConsultants.Where(x => !existingSubKenticoIds.Contains(x.SubItemKenticoID)).ToList().ForEach(x => x.SvcOp = TE3EEntityExt.GetEnumDescription(SvcOps.Add));
            }

            // TODO: Delete

            var tempJson = JsonConvert.SerializeObject(patchOperations, Formatting.Indented);



        }


        public static List<Operation> CustomerPatchGeneration(CustomerProfile oldCustomer, CustomerProfile newCustomer)
        {
            var patchOperations = new List<Operation>();
            patchOperations.AddRange(JsonPatchHelper.CompareAndGenerate(oldCustomer, newCustomer));
            return patchOperations;
        }

        public static void ApplyPatchToCustomer(PatchCustomerDocument patchCustomer, CustomerProfile oldCustomer)
        {
            try
            {
                patchCustomer.patch.Select(x => new Operation()
                {
                    path = x.path,
                    op = x.op,
                    value = x.value
                }).ToList().ApplyPatch(oldCustomer);

            }
            catch (Exception ex)
            {
                throw new Exception("Failed to parse Incoming JSON patch update.");
            }
        }


        private static string GetConfirmationLetterType(CMSAssignment matter)
        {
            string confType = "Standard";

            if (matter.IsConfLetterStd == 1)
                confType = "Standard";
            else if (matter.IsConfLetterLegal == 1)
                confType = "Legal";
            else if (matter.IsConfLetterNatAgmt == 1)
                confType = "National Agreement";
            else if (matter.IsConfLetterCAT == 1)
                confType = "CAT";
            else if (matter.IsConfLetterEngSvcs == 1)
                confType = "Engineering Services";
            else if (matter.IsConfLetterRtnr == 1)
                confType = "Retainer";
            else if (matter.IsConfLetterSign == 1)
                confType = "Signature";
            return confType;
        }

        //[Obsolete]
        //public static In3eAssignment ConvertToInAssignment(this PatchAssignmentDocument iPatchAssignment)
        //{
        //    In3eAssignment iAssignment = new In3eAssignment
        //    {
        //        assignment = new InAssignmentsCM(),
        //        orderingClient = new InOrderingClientsCM(),
        //        additionalParties = new List<InAdditionalPartiesCM>(),
        //        coConsultants = new List<InCoConsultantsCM>(),
        //        incidentLocations = new List<InIncidentLocationsCM>(),
        //        payorDetails = new List<InPayorDetailsCM>()
        //    };

        //    // Clean extra data from patch path
        //    var patchesList = iPatchAssignment.patch.Select(x => new Patch()
        //    {
        //        op = x.op,
        //        path = x.path.Split('/')[1],
        //        value = x.value
        //    }).ToList();

        //    //todo: need to map tE3EAssignment
        //    iAssignment.assignment.KenticoID = iPatchAssignment.kenticoId;
        //    iAssignment.assignment.E3EID = iPatchAssignment.e3EId;
        //    iAssignment.assignment.MatterIndex = iPatchAssignment.e3EId;

        //    iAssignment.assignment.MattStatusDesc = patchesList.GetValueForEnum(ePath.matterStatus)?.ToString();
        //    iAssignment.assignment.MattStatus = patchesList.GetValueForEnum(ePath.matterStatusId)?.ToString();
        //    iAssignment.assignment.MatterName = patchesList.GetValueForEnum(ePath.matterTitle)?.ToString();
        //    iAssignment.assignment.MatterNumber = patchesList.GetValueForEnum(ePath.matterNumber)?.ToString();

        //    #region Ordering Client Contact Section

        //    iAssignment.orderingClient.E3EID = iAssignment.assignment.E3EID;
        //    iAssignment.orderingClient.KenticoID = iAssignment.assignment.KenticoID;
        //    iAssignment.orderingClient.MatterIndex = iPatchAssignment.e3EId;
        //    iAssignment.orderingClient.MatterNumber = iAssignment.assignment.MatterNumber;

        //    iAssignment.orderingClient.OrderClientContactSalutation = patchesList.GetValueForEnum(ePath.orderingClientContactSalutation)?.ToString();
        //    iAssignment.orderingClient.OrderClientContactFirstName = patchesList.GetValueForEnum(ePath.orderingClientContactFirstName)?.ToString();
        //    iAssignment.orderingClient.OrderClientContactLastName = patchesList.GetValueForEnum(ePath.orderingClientContactLastName)?.ToString();
        //    iAssignment.orderingClient.OrderClientContactEmail = patchesList.GetValueForEnum(ePath.orderingClientContactEmail)?.ToString();
        //    iAssignment.orderingClient.OrderClientContactPhoneNo = patchesList.GetValueForEnum(ePath.orderingClientContactPhoneNo)?.ToString();

        //    if (!string.IsNullOrEmpty(patchesList.GetValueForEnum(ePath.orderingClientID)?.ToString()))
        //    {
        //        iAssignment.assignment.ClientIndex = Convert.ToInt32(patchesList.GetValueForEnum(ePath.orderingClientID));
        //        iAssignment.orderingClient.OrderClientIndex = iAssignment.assignment.ClientIndex;
        //    }

        //    iAssignment.assignment.ClientNumber = patchesList.GetValueForEnum(ePath.orderingClientNumber)?.ToString();
        //    iAssignment.orderingClient.OrderClientNumber = iAssignment.assignment.ClientNumber;

        //    #endregion Ordering Client Contact Section

        //    #region Ordering Client Company Section

        //    iAssignment.assignment.ClientName = patchesList.GetValueForEnum(ePath.orderingClientCompanyName)?.ToString();
        //    iAssignment.orderingClient.OrderClientCompanyName = iAssignment.assignment.ClientName;

        //    iAssignment.orderingClient.OrderClientCompanyAddress1 = patchesList.GetValueForEnum(ePath.orderingClientCompanyAddress1)?.ToString();
        //    iAssignment.orderingClient.OrderClientCompanyAddress2 = patchesList.GetValueForEnum(ePath.orderingClientCompanyAddress2)?.ToString();
        //    iAssignment.orderingClient.OrderClientCompanyAddressCity = patchesList.GetValueForEnum(ePath.orderingClientCompanyAddressCity)?.ToString();
        //    iAssignment.orderingClient.OrderClientCompanyAddressState = patchesList.GetValueForEnum(ePath.orderingClientCompanyAddressState)?.ToString();
        //    iAssignment.orderingClient.OrderClientCompanyAddressZip = patchesList.GetValueForEnum(ePath.orderingClientCompanyAddressZip)?.ToString();
        //    // Country, Lat, Lon is missing in Json
        //    iAssignment.orderingClient.OrderClientCompanyType = patchesList.GetValueForEnum(ePath.orderingClientCompanyType)?.ToString();

        //    #endregion Ordering Client Company Section

        //    #region Incident Information Section

        //    //iAssignment.assignment.IncidentYN = Convert.ToBoolean(patchesList.GetValueForEnum(ePath.incidentYN));
        //    iAssignment.assignment.DateOfOccurenceTxt = patchesList.GetValueForEnum(ePath.dateOccurence)?.ToString();

        //    if (!string.IsNullOrEmpty(patchesList.GetValueForEnum(ePath.dateOccurence)?.ToString()))
        //        iAssignment.assignment.DateOccurence = Convert.ToDateTime(iAssignment.assignment.DateOfOccurenceTxt);

        //    //iAssignment.assignment.DateUnknown = Convert.ToBoolean(patchesList.GetValueForEnum(ePath.dateUnknown));
        //    iAssignment.assignment.Narrative_UnformattedText = patchesList.GetValueForEnum(ePath.descOccurence)?.ToString();
        //    iAssignment.assignment.ScopeOfWork = patchesList.GetValueForEnum(ePath.needAnswered)?.ToString();
        //    iAssignment.assignment.SpecialInstructions = patchesList.GetValueForEnum(ePath.specialInstructions)?.ToString();
        //    IncidentLocation[] incidentLocations = JsonConvert.DeserializeObject<IncidentLocation[]>(patchesList.GetValueForEnum(ePath.incidentLocations)?.ToString());
        //    List<InIncidentLocationsCM> inIncidentLocationCMs = new List<InIncidentLocationsCM>();

        //    foreach (var inc in incidentLocations)
        //    {
        //        var timeStamp = DateTime.Now;
        //        var inIncidentLocationCM = new InIncidentLocationsCM();
        //        inIncidentLocationCM.KenticoID = iAssignment.assignment.KenticoID;
        //        inIncidentLocationCM.E3EID = iAssignment.assignment.E3EID;
        //        inIncidentLocationCM.MatterIndex = iPatchAssignment.e3EId;
        //        inIncidentLocationCM.MatterNumber = iAssignment.assignment.MatterNumber;
        //        inIncidentLocationCM.MattSiteID = Guid.Parse(inc.MattSiteID);
        //        inIncidentLocationCM.AddressID = Guid.Parse(inc.AddressID);
        //        inIncidentLocationCM.SiteID = Guid.Parse(inc.SiteIndex);
        //        inIncidentLocationCM.StreetOccurrence = inc.StreetOccurence;
        //        inIncidentLocationCM.CityOccurrence = inc.CityOccurence;
        //        inIncidentLocationCM.StateOccurrence = inc.StateOccurence;
        //        inIncidentLocationCM.ZipCodeOccurrence = inc.ZipCodeOccurence;
        //        inIncidentLocationCM.CountyOccurrence = inc.CountyOccurence;
        //        inIncidentLocationCM.CountryOccurrence = inc.CountryOccurence;
        //        if (!string.IsNullOrEmpty(inc.LatOccurence))
        //            inIncidentLocationCM.LatOccurrence = Convert.ToDecimal(inc.LatOccurence);
        //        if (!string.IsNullOrEmpty(inc.LonOccurence))
        //            inIncidentLocationCM.LonOccurrence = Convert.ToDecimal(inc.LonOccurence);
        //        inIncidentLocationCM.TimeStamp = timeStamp;
        //        inIncidentLocationCMs.Add(inIncidentLocationCM);
        //    }
        //    iAssignment.incidentLocations = inIncidentLocationCMs;

        //    #endregion Incident Information Section

        //    #region Adjuster Information

        //    //if (!string.IsNullOrEmpty(patchesList.GetValueForEnum(ePath.adjusterType)?.ToString()))
        //    //{
        //    //    var inPayorDetailsCM = new InPayorDetailsCM();
        //    //    inPayorDetailsCM.Role = patchesList.GetValueForEnum(ePath.adjusterType)?.ToString();
        //    //    inPayorDetailsCM.E3EID = iAssignment.assignment.E3EID;
        //    //    inPayorDetailsCM.MatterNumber = iAssignment.assignment.MatterNumber;
        //    //    inPayorDetailsCM.MatterIndex = iPatchAssignment.te3eAssignmentId;
        //    //    inPayorDetailsCM.PayorName = patchesList.GetValueForEnum(ePath.outsideCompName)?.ToString();
        //    //    inPayorDetailsCM.FirstName = patchesList.GetValueForEnum(ePath.outsideFirstName)?.ToString();
        //    //    inPayorDetailsCM.LastName = patchesList.GetValueForEnum(ePath.outsideLastName)?.ToString();
        //    //    inPayorDetailsCM.Email = patchesList.GetValueForEnum(ePath.outsideAdjEmail)?.ToString();
        //    //    inPayorDetailsCM.PhoneNumber = patchesList.GetValueForEnum(ePath.outsideAdjPhone)?.ToString();
        //    //    inPayorDetailsCM.Street = patchesList.GetValueForEnum(ePath.outsideAddr1)?.ToString();
        //    //    inPayorDetailsCM.City = patchesList.GetValueForEnum(ePath.outsideCity)?.ToString();
        //    //    inPayorDetailsCM.State = patchesList.GetValueForEnum(ePath.outsideState)?.ToString();
        //    //    inPayorDetailsCM.ZipCode = patchesList.GetValueForEnum(ePath.outsideZip)?.ToString();
        //    //    inPayorDetailsCM.Country = patchesList.GetValueForEnum(ePath.outsideCountry)?.ToString();
        //    //    iAssignment.payorDetails.Add(inPayorDetailsCM);
        //    //}

        //    #endregion Adjuster Information

        //    #region Legal Information [Only show if OrderClientCompanyType = Attorney]

        //    if (iAssignment.orderingClient.OrderClientCompanyType == "Law Firm Plaintiff"
        //      || iAssignment.orderingClient.OrderClientCompanyType == "Law Firm Defendant")
        //    {
        //        iAssignment.orderingClient.OrderClientAdditionalInstr = patchesList.GetValueForEnum(ePath.outsideCountry)?.ToString();
        //        iAssignment.orderingClient.RepresentingDesc = patchesList.GetValueForEnum(ePath.repType)?.ToString();
        //        iAssignment.orderingClient.OrderClientCompanyType = patchesList.GetValueForEnum(ePath.legalClientType)?.ToString();
        //        iAssignment.orderingClient.Style = patchesList.GetValueForEnum(ePath.style)?.ToString();
        //        iAssignment.orderingClient.Court = patchesList.GetValueForEnum(ePath.court)?.ToString();
        //        iAssignment.orderingClient.CauseNumber = patchesList.GetValueForEnum(ePath.causeNumber)?.ToString();

        //        iAssignment.orderingClient.OrderClientContactFirstName = patchesList.GetValueForEnum(ePath.insPOC)?.ToString();
        //        iAssignment.orderingClient.OrderClientContactPhoneNo = patchesList.GetValueForEnum(ePath.insNo)?.ToString();

        //        #region Conditional  LegalClientType

        //        //if (!string.IsNullOrEmpty(iAssignment.orderingClient.OrderClientCompanyType)
        //        //    && iAssignment.orderingClient.OrderClientCompanyType.Equals("Individual"))
        //        //{
        //        //    #region Legal Information [Only show if LegalClientType = Individual;]
        //        //    InAdditionalPartiesCM inAdditionalPartiesCM = new InAdditionalPartiesCM
        //        //    {
        //        //        E3EID = iAssignment.assignment.E3EID,
        //        //        Role = 300.ToString(),//AdditionalPartiesRoles.Insured,
        //        //        PartyName = patchesList.GetValueForEnum(ePath.insFirstName)?.ToString(),
        //        //        HomePhone = patchesList.GetValueForEnum(ePath.insPOCNo)?.ToString(),
        //        //    };
        //        //    iAssignment.additionalParties.Add(inAdditionalPartiesCM);
        //        //    #endregion Legal Information [Only show if LegalClientType = Individual;]
        //        //}
        //        //else
        //        //{
        //        //    #region Legal Information [Only show if LegalClientType != Individual;] - company or government entity
        //        //    InAdditionalPartiesCM inAdditionalPartiesCM = new InAdditionalPartiesCM
        //        //    {
        //        //        E3EID = iAssignment.assignment.E3EID,
        //        //        Role = 300.ToString(),//AdditionalPartiesRoles.Insured,
        //        //        PartyName = patchesList.GetValueForEnum(ePath.insFirstName)?.ToString(),
        //        //        HomePhone = patchesList.GetValueForEnum(ePath.insPOCNo)?.ToString()
        //        //    };
        //        //    iAssignment.orderingClient.OrderClientContactFirstName = patchesList.GetValueForEnum(ePath.insPOC)?.ToString();
        //        //    iAssignment.orderingClient.OrderClientContactPhoneNo = patchesList.GetValueForEnum(ePath.insNo)?.ToString();
        //        //    iAssignment.additionalParties.Add(inAdditionalPartiesCM);
        //        //    #endregion Legal Information [Only show if LegalClientType != Individual;] - company or government entity
        //        //}

        //        #endregion Conditional  LegalClientType
        //    }

        //    #endregion Legal Information [Only show if OrderClientCompanyType = Attorney]

        //    #region Opposing Party Law Firm

        //    //if (Convert.ToBoolean(patchesList.GetValueForEnum(ePath.opposingYN)))
        //    //{
        //    //    InPayorDetailsCM inPayorDetailsCM = new InPayorDetailsCM()
        //    //    {
        //    //        E3EID = iAssignment.assignment.E3EID,
        //    //        MatterNumber = iAssignment.assignment.MatterNumber,
        //    //        MatterIndex = iPatchAssignment.te3eAssignmentId,
        //    //        PayorName = patchesList.GetValueForEnum(ePath.oppName)?.ToString(),
        //    //        FirstName = patchesList.GetValueForEnum(ePath.oppAttyFirstName)?.ToString(),
        //    //        LastName = patchesList.GetValueForEnum(ePath.oppAttyLastName)?.ToString(),
        //    //        Street = patchesList.GetValueForEnum(ePath.oppStreetAddr1)?.ToString(),
        //    //        City = patchesList.GetValueForEnum(ePath.oppCity)?.ToString(),
        //    //        State = patchesList.GetValueForEnum(ePath.oppState)?.ToString(),
        //    //        ZipCode = patchesList.GetValueForEnum(ePath.oppZip)?.ToString(),
        //    //        Country = patchesList.GetValueForEnum(ePath.oppCountry)?.ToString()
        //    //    };
        //    //    iAssignment.payorDetails.Add(inPayorDetailsCM);
        //    //}

        //    #endregion Opposing Party Law Firm

        //    #region Parties (Additional Parties)

        //    Party[] parties = JsonConvert.DeserializeObject<Party[]>(patchesList.GetValueForEnum(ePath.parties)?.ToString());
        //    if (parties != null)
        //    {
        //        foreach (var party in parties)
        //        {
        //            var additionalParty = new InAdditionalPartiesCM()
        //            {
        //                E3EID = iAssignment.assignment.E3EID,
        //                MatterNumber = iAssignment.assignment.MatterNumber,
        //                MatterIndex = iPatchAssignment.e3EId,
        //                KenticoID = party.KenticoID,
        //                EntityTypeDesc = party.EntityType,
        //                EntIndex = party.EntityIndex,
        //                RoleDesc = party.PartyType,
        //                //RelatedPartiesID = Guid.Parse(party.Party3EID),
        //                PartyName = party.CompanyName,
        //                HomePhone = party.Phone,
        //                FirstName = party.FirstName,
        //                LastName = party.LastName,
        //            };
        //            iAssignment.additionalParties.Add(additionalParty);
        //        }
        //    }

        //    #endregion Parties (Additional Parties)

        //    #region CoConsultants

        //    if (Convert.ToBoolean(patchesList.GetValueForEnum(ePath.coConsultantsYN)))
        //    {
        //        CoConsultant[] coConsultants = JsonConvert.DeserializeObject<CoConsultant[]>(patchesList.GetValueForEnum(ePath.coConsultants)?.ToString() ?? "");

        //        foreach (var item in coConsultants)
        //        {
        //            var coConsultant = new InCoConsultantsCM()
        //            {
        //                //KenticoID = item.KenticoID,
        //                E3EID = iAssignment.assignment.E3EID,
        //                MatterIndex = iPatchAssignment.e3EId,
        //                CoConsultantName = item.CoConsultantName,
        //                CoConsultantNumber = item.CoConsultantNumber,
        //                MatterNumber = iAssignment.assignment.MatterNumber
        //            };
        //            iAssignment.coConsultants.Add(coConsultant);
        //        }
        //    }

        //    #endregion CoConsultants

        //    #region Multipayor Information

        //    //if (Convert.ToBoolean(patchesList.GetValueForEnum(ePath.multipayorYN)))
        //    //{
        //    if (!string.IsNullOrEmpty(patchesList.GetValueForEnum(ePath.multipayorInvoicing)?.ToString()))
        //    {
        //        //iAssignment.assignment.SpecialInstructions = patchesList.GetValueForEnum(ePath.parties)?.ToString().Split(':')[0].Trim();
        //        iAssignment.assignment.InvoiceTo = patchesList.GetValueForEnum(ePath.parties)?.ToString().Split(':')[1].Trim();
        //    }
        //    Payor[] payors = JsonConvert.DeserializeObject<Payor[]>(patchesList.GetValueForEnum(ePath.payors)?.ToString() ?? "");
        //    if (payors != null)
        //    {
        //        foreach (var item in payors)
        //        {
        //            var payor = new InPayorDetailsCM()
        //            {
        //                //KenticoID = item.KenticoID,
        //                E3EID = iAssignment.assignment.E3EID,
        //                MatterIndex = iPatchAssignment.e3EId,
        //                MatterNumber = iAssignment.assignment.MatterNumber,
        //                Street = item.PayAddr1,
        //                City = item.PayCity,
        //                State = item.PayState,
        //                ZipCode = item.PayZip,
        //                FirstName = item.PayFirstName,
        //                LastName = item.PayLastName,
        //                //ClientNumber =
        //                PayorName = item.PayName,
        //                Email = item.PayEmail,
        //                PhoneNumber = item.PayPhone,
        //                ReferenceNumber = item.ReferenceNumber,
        //            };
        //            if (!string.IsNullOrEmpty(item.InvoicePercentage))
        //                payor.PercentFee = Convert.ToDecimal(item.InvoicePercentage);
        //            iAssignment.payorDetails.Add(payor);
        //        }
        //    }
        //    //}

        //    #endregion Multipayor Information

        //    #region Reference Numbers

        //    //if (iAssignment.orderingClient.OrderClientCompanyType.Equals("Insurance Company"))
        //    //{
        //    //    #region Liberty Mutual soft-requirement
        //    //    //if (iAssignment.orderingClient.OrderClientCompanyName.ToLower().Contains("Liberty Mutual".ToLower()))
        //    //    //{
        //    //    //    iAssignment.assignment.InsuranceType = patchesList.GetValueForEnum(ePath.libertyInsuranceType)?.ToString();
        //    //    //    iAssignment.assignment.ClaimType = patchesList.GetValueForEnum(ePath.libertyClaimType)?.ToString();
        //    //    //}
        //    //    #endregion Liberty Mutual soft-requirement

        //    ReferenceNumber[] referenceNumbers = JsonConvert.DeserializeObject<ReferenceNumber[]>(patchesList.GetValueForEnum(ePath.referenceNumbers)?.ToString() ?? "");
        //    if (referenceNumbers != null)
        //    {
        //        foreach (var item in referenceNumbers)
        //        {
        //            var referenceNumber = new InPayorDetailsCM()
        //            {
        //                E3EID = iAssignment.assignment.E3EID,
        //                //KenticoID = item.KenticoID,
        //                MatterIndex = iPatchAssignment.e3EId
        //            };
        //            if (Enum.TryParse(item.Type, out ReferenceNumberType reference))
        //            {
        //                switch (reference)
        //                {
        //                    case ReferenceNumberType.Claim:
        //                        referenceNumber.ClaimNumber = item.Number;
        //                        break;

        //                    case ReferenceNumberType.Reference:
        //                        referenceNumber.ReferenceNumber = item.Number;
        //                        break;

        //                    case ReferenceNumberType.PO:
        //                        referenceNumber.PhoneNumber = item.Number; // PONumber not available in InPayorDetailsCM table
        //                        break;

        //                    default:
        //                        break;
        //                }
        //            }
        //            iAssignment.payorDetails.Add(referenceNumber);
        //        }
        //    }
        //    //}

        //    #endregion Reference Numbers

        //    #region Invoice Instructions

        //    iAssignment.assignment.InvoiceTo = patchesList.GetValueForEnum(ePath.specialInvoice)?.ToString();

        //    if (!string.IsNullOrEmpty(patchesList.GetValueForEnum(ePath.relatedMatter)?.ToString()))
        //        iAssignment.assignment.RelatedMatter = Convert.ToInt32(patchesList.GetValueForEnum(ePath.relatedMatter));

        //    iAssignment.assignment.Currency = patchesList.GetValueForEnum(ePath.currency)?.ToString();
        //    iAssignment.assignment.OpenTimekeeperName = patchesList.GetValueForEnum(ePath.openTimekeeper)?.ToString();

        //    if (!string.IsNullOrEmpty(patchesList.GetValueForEnum(ePath.retainerAmount)?.ToString()))
        //        iAssignment.assignment.RetainerAmount = Convert.ToDecimal(patchesList.GetValueForEnum(ePath.retainerAmount)?.ToString());

        //    if (!string.IsNullOrEmpty(patchesList.GetValueForEnum(ePath.fixedPrice)?.ToString()))
        //        iAssignment.assignment.FixedPrice = Convert.ToByte(patchesList.GetValueForEnum(ePath.fixedPrice));

        //    iAssignment.assignment.DNENotes = patchesList.GetValueForEnum(ePath.dneNotes)?.ToString();

        //    if (!string.IsNullOrEmpty(patchesList.GetValueForEnum(ePath.webOriginated)?.ToString()))
        //        iAssignment.assignment.WebOriginated = Convert.ToByte(patchesList.GetValueForEnum(ePath.webOriginated));

        //    iAssignment.assignment.FeesTaxCode = patchesList.GetValueForEnum(ePath.feesTaxCode)?.ToString();
        //    iAssignment.assignment.EntryDate = Convert.ToDateTime(patchesList.GetValueForEnum(ePath.entryDate));

        //    if (!string.IsNullOrEmpty(patchesList.GetValueForEnum(ePath.eBilling)?.ToString()))
        //        iAssignment.assignment.EBilling = Convert.ToByte(patchesList.GetValueForEnum(ePath.eBilling));

        //    iAssignment.assignment.ElecBillingType = patchesList.GetValueForEnum(ePath.eBillingType)?.ToString();
        //    iAssignment.assignment.ElectronicNumber = patchesList.GetValueForEnum(ePath.electronicNumber)?.ToString();

        //    switch (patchesList.GetValueForEnum(ePath.confirmationLetterType)?.ToString())
        //    {
        //        case "Standard":
        //            iAssignment.assignment.IsConfLetterStd = 1;
        //            break;

        //        case "Legal":
        //            iAssignment.assignment.IsConfLetterLegal = 1;
        //            break;

        //        case "National Agreement":
        //            iAssignment.assignment.IsConfLetterNatAgmt = 1;
        //            break;

        //        case "CAT":
        //            iAssignment.assignment.IsConfLetterCAT = 1;
        //            break;

        //        case "Engineering Services":
        //            iAssignment.assignment.IsConfLetterEngSvcs = 1;
        //            break;

        //        case "Retainer":
        //            iAssignment.assignment.IsConfLetterRtnr = 1;
        //            break;

        //        case "Signature":
        //            iAssignment.assignment.IsConfLetterSign = 1;
        //            break;

        //        default:
        //            break;
        //    }

        //    iAssignment.assignment.ROFTemplateDesc = patchesList.GetValueForEnum(ePath.rofTemplate)?.ToString();

        //    if (!string.IsNullOrEmpty(patchesList.GetValueForEnum(ePath.startDate1)?.ToString()))
        //        iAssignment.assignment.StartDate1 = Convert.ToDateTime(patchesList.GetValueForEnum(ePath.startDate1));
        //    iAssignment.assignment.BillingTimekeeperName = patchesList.GetValueForEnum(ePath.billingTimekeeper)?.ToString();
        //    iAssignment.assignment.ResponsibleTimekeeperName = patchesList.GetValueForEnum(ePath.responsibleTimekeeper)?.ToString();
        //    iAssignment.assignment.SupervisingTimekeeperName = patchesList.GetValueForEnum(ePath.supervisingTimekeeper)?.ToString();
        //    iAssignment.assignment.OfficeName = patchesList.GetValueForEnum(ePath.office)?.ToString();
        //    if (!string.IsNullOrEmpty(iAssignment.assignment.OfficeName) && iAssignment.assignment.OfficeName.Split('-').Length == 2)
        //    {
        //        iAssignment.assignment.Office = iAssignment.assignment.OfficeName.Split('-')[1].Trim();
        //    }
        //    iAssignment.assignment.SectionDesc = patchesList.GetValueForEnum(ePath.section)?.ToString();
        //    iAssignment.assignment.ArrangementDesc = patchesList.GetValueForEnum(ePath.arrangement)?.ToString();
        //    iAssignment.assignment.DepartmentDesc = patchesList.GetValueForEnum(ePath.department)?.ToString();
        //    iAssignment.assignment.PracticeGroupDesc = patchesList.GetValueForEnum(ePath.practiceGroup)?.ToString();
        //    iAssignment.assignment.PTAGroup = patchesList.GetValueForEnum(ePath.pta1)?.ToString();
        //    iAssignment.assignment.IndustryGroupDesc = patchesList.GetValueForEnum(ePath.industryGroup)?.ToString();
        //    iAssignment.assignment.TechincalReviewerName = patchesList.GetValueForEnum(ePath.technicalReviewerName)?.ToString();

        //    if (!string.IsNullOrEmpty(patchesList.GetValueForEnum(ePath.technicalReviewerNumber)?.ToString()))
        //        iAssignment.assignment.TechnicalReviewerNumber = Convert.ToInt32(patchesList.GetValueForEnum(ePath.technicalReviewerNumber)); // Change int to string

        //    if (!string.IsNullOrEmpty(patchesList.GetValueForEnum(ePath.engineerOfRecordNo)?.ToString()))
        //        iAssignment.assignment.EngineerOfRecordNo = Convert.ToInt32(patchesList.GetValueForEnum(ePath.engineerOfRecordNo));

        //    iAssignment.assignment.EngineerOfRecordName = patchesList.GetValueForEnum(ePath.engineerOfRecordName)?.ToString();

        //    if (!string.IsNullOrEmpty(patchesList.GetValueForEnum(ePath.bdManagerNo)?.ToString()))
        //        iAssignment.assignment.BDManagerNo = Convert.ToInt32(patchesList.GetValueForEnum(ePath.bdManagerNo));

        //    if (!string.IsNullOrEmpty(patchesList.GetValueForEnum(ePath.startDate2)?.ToString()))
        //        iAssignment.assignment.StartDate2 = Convert.ToDateTime(patchesList.GetValueForEnum(ePath.startDate2)?.ToString());

        //    iAssignment.assignment.SpecialClientInstruction = patchesList.GetValueForEnum(ePath.specialClientInstruction)?.ToString();
        //    iAssignment.assignment.RateDesc = patchesList.GetValueForEnum(ePath.rate)?.ToString();
        //    iAssignment.assignment.RateExceptGroup = patchesList.GetValueForEnum(ePath.rateExceptGroup)?.ToString();
        //    iAssignment.assignment.TimeType = patchesList.GetValueForEnum(ePath.timeType)?.ToString();

        //    if (!string.IsNullOrEmpty(patchesList.GetValueForEnum(ePath.flatFeeAmount)?.ToString()))
        //        iAssignment.assignment.FlatFeeAmount = Convert.ToDecimal(patchesList.GetValueForEnum(ePath.flatFeeAmount));

        //    if (!string.IsNullOrEmpty(patchesList.GetValueForEnum(ePath.budget)?.ToString()))
        //        iAssignment.assignment.Budget = Convert.ToDecimal(patchesList.GetValueForEnum(ePath.budget));

        //    #endregion Invoice Instructions

        //    #region Time Stamps

        //    iAssignment.assignment.TimeStamp = DateTime.Now;
        //    iAssignment.orderingClient.TimeStamp = DateTime.Now;
        //    iAssignment.incidentLocations.ForEach(x => x.TimeStamp = DateTime.Now);
        //    iAssignment.additionalParties.ForEach(x => x.TimeStamp = DateTime.Now);
        //    iAssignment.payorDetails.ForEach(x => x.TimeStamp = DateTime.Now);
        //    iAssignment.coConsultants.ForEach(x => x.TimeStamp = DateTime.Now);

        //    #endregion Time Stamps

        //    var json = JsonConvert.SerializeObject(iAssignment, Formatting.Indented);
        //    return iAssignment;
        //}

        //[Obsolete]
        //public static InCustomerProfileCM ConvertToInCustomer(this PatchInCustomerDocument iPatchCustomer)
        //{
        //    InCustomerProfileCM iCustomer = new InCustomerProfileCM();
        //    iCustomer.KenticoID = iPatchCustomer.kenticoId;
        //    iCustomer.CompanyType = iPatchCustomer.companyType;

        //    foreach (var patch in iPatchCustomer.patch)
        //    {
        //        var splittedPath = patch.path.Split('/').Where(x => !string.IsNullOrEmpty(x));
        //        var path = "";

        //        if (splittedPath.Count() > 0)
        //            path = splittedPath.First();

        //        ePath epath;
        //        Enum.TryParse(path, true, out epath);
        //        switch (epath)
        //        {
        //            case ePath.email:
        //                {
        //                    iCustomer.Email = patch.value.ToString();
        //                    break;
        //                }
        //            case ePath.salutation:
        //                {
        //                    iCustomer.Salutation = patch.value.ToString();
        //                    break;
        //                }
        //            case ePath.firstName:
        //                {
        //                    iCustomer.FirstName = patch.value.ToString();
        //                    break;
        //                }
        //            case ePath.lastName:
        //                {
        //                    iCustomer.LastName = patch.value.ToString();
        //                    break;
        //                }
        //            case ePath.phone:
        //                {
        //                    iCustomer.Phone = patch.value.ToString();
        //                    break;
        //                }
        //            case ePath.companyName:
        //                {
        //                    iCustomer.CompanyName = patch.value.ToString();
        //                    break;
        //                }
        //            case ePath.companyAddress1:
        //                {
        //                    iCustomer.CompanyAddress1 = patch.value.ToString();
        //                    break;
        //                }
        //            case ePath.companyAddress2:
        //                {
        //                    iCustomer.CompanyAddress2 = patch.value.ToString();
        //                    break;
        //                }
        //            case ePath.companyAddressCity:
        //                {
        //                    iCustomer.CompanyAddressCity = patch.value.ToString();
        //                    break;
        //                }
        //            case ePath.companyAddressState:
        //                {
        //                    iCustomer.CompanyAddressState = patch.value.ToString();
        //                    break;
        //                }
        //            case ePath.companyAddressZip:
        //                {
        //                    iCustomer.CompanyAddressZip = patch.value.ToString();
        //                    break;
        //                }
        //            case ePath.clientNumber:
        //                {
        //                    iCustomer.ClientNumber = patch.value.ToString();
        //                    break;
        //                }
        //            case ePath.entityID:
        //                {
        //                    iCustomer.EntityID = int.Parse(patch.value.ToString());
        //                    break;
        //                }
        //            default:
        //                break;
        //        }
        //    }

        //    iCustomer.TimeStamp = DateTime.UtcNow;

        //    return iCustomer;
        //}

        //public static string ConvertCMSCliType(string clientType)
        //{
        //    var t = GetClientsByType(27)
        //    string cliType = "";
        //    if (clientType == TE3EEntityExt.GetEnumDescription(CftRoleCodes.Corporation))
        //        cftRole = CftRoleCodes.Corporation.ToString();
        //}

        public static string ConvertCMSPayorRole(string payorRole)
        {
            //public enum CftRoleCodes
            //{
            //    [Description("Corporation")]
            //    Corporation = 100,
            //    [Description("Claimant")]
            //    Claimant = 200,
            //    [Description("Insured")]
            //    Insured = 300,
            //    [Description("Plaintiff")]
            //    Plaintiff = 400,
            //    [Description("Defendant")]
            //    Defendant = 500,
            //    [Description("Insurance Company")]
            //    InsuranceCompany = 600,
            //    [Description("Adjustment Firm")]
            //    AdjustmentFirm = 700,
            //    [Description("Law Firm Plaintiff")]
            //    LawFirmPlaintiff = 800,
            //    [Description("Law Firm Defendant")]
            //    LawFirmDefendant = 900,
            //    //Government = 950,
            //    [Description("Government/Municipality")]
            //    GovernmentMunicipality = 1000,
            //    [Description("Individual")]
            //    Individual = 1100,
            //    [Description("Third Party Administrator (TPA)")]
            //    ThirdPartyAdministratorTPA = 1200,
            //    [Description("Independent Adjuster (IA)")]
            //    IndependentAdjusterIA = 1300,
            //    //Attorney = 1400,
            //    //GovernmentEntity = 1500,
            //    [Description("None of the above")]
            //    Noneoftheabove = 1600
            //}
            string cftRole = "";
            if (payorRole == TE3EEntityExt.GetEnumDescription(CftRoleCodes.Corporation))
                cftRole = CftRoleCodes.Corporation.ToString();
            else if (payorRole == TE3EEntityExt.GetEnumDescription(CftRoleCodes.Claimant))
                cftRole = CftRoleCodes.Claimant.ToString();
            else if (payorRole == TE3EEntityExt.GetEnumDescription(CftRoleCodes.Insured))
                cftRole = CftRoleCodes.Insured.ToString();
            else if (payorRole == TE3EEntityExt.GetEnumDescription(CftRoleCodes.Plaintiff))
                cftRole = CftRoleCodes.Plaintiff.ToString();
            else if (payorRole == TE3EEntityExt.GetEnumDescription(CftRoleCodes.Defendant))
                cftRole = CftRoleCodes.Defendant.ToString();
            else if (payorRole == TE3EEntityExt.GetEnumDescription(CftRoleCodes.InsuranceCompany))
                cftRole = CftRoleCodes.InsuranceCompany.ToString();
            else if (payorRole == TE3EEntityExt.GetEnumDescription(CftRoleCodes.AdjustmentFirm))
                cftRole = CftRoleCodes.AdjustmentFirm.ToString();
            else if (payorRole == TE3EEntityExt.GetEnumDescription(CftRoleCodes.LawFirmPlaintiff))
                cftRole = CftRoleCodes.LawFirmPlaintiff.ToString();
            else if (payorRole == TE3EEntityExt.GetEnumDescription(CftRoleCodes.Corporation))
                cftRole = CftRoleCodes.Corporation.ToString();
            else if (payorRole == TE3EEntityExt.GetEnumDescription(CftRoleCodes.Corporation))
                cftRole = CftRoleCodes.Corporation.ToString();
            else if (payorRole == TE3EEntityExt.GetEnumDescription(CftRoleCodes.Corporation))
                cftRole = CftRoleCodes.Corporation.ToString();
            else if (payorRole == TE3EEntityExt.GetEnumDescription(CftRoleCodes.Corporation))
                cftRole = CftRoleCodes.Corporation.ToString();
            else if (payorRole == TE3EEntityExt.GetEnumDescription(CftRoleCodes.Corporation))
                cftRole = CftRoleCodes.Corporation.ToString();
            else if (payorRole == TE3EEntityExt.GetEnumDescription(CftRoleCodes.Corporation))
                cftRole = CftRoleCodes.Corporation.ToString();

            return cftRole;
        }
    }

    public enum ePath
    {
        e3eAssignmentId,
        matterStatus,
        matterStatusId,
        orderingClientContactSalutation,
        orderingClientContactFirstName,
        orderingClientContactLastName,
        orderingClientContactEmail,
        orderingClientContactPhoneNo,
        orderingClientCompanyName,
        orderingClientCompanyAddress1,
        orderingClientCompanyAddress2,
        orderingClientCompanyAddressCity,
        orderingClientCompanyAddressState,
        orderingClientCompanyAddressZip,
        orderingClientCompanyType,
        incidentYN,
        dateOccurence,
        dateUnknown,
        incidentLocations,
        descOccurence,
        needAnswered,
        specialInstructions,
        adjusterType,
        authYN,
        outsideCompName,
        outsideFirstName,
        outsideLastName,
        outsideAdjEmail,
        outsideAdjPhone,
        adjusterInvoicing,
        outsideAddr1,
        outsideAddr2,
        outsideCity,
        outsideState,
        outsideZip,
        paraFirstName,
        paraLastName,
        repType,
        legalClientType,
        insFirstName,
        insLastName,
        insPOCNo,
        insPOC,
        insNo,
        opposingYN,
        oppName,
        oppAttyFirstName,
        oppAttyLastName,
        oppStreetAddr1,
        oppStreetAddr2,
        oppCity,
        oppState,
        oppZip,
        opposingParties,
        suitYN,
        causeNumber,
        court,
        style,
        referenceNumbers,
        parties,
        multipayorYN,
        multipayorInvoicing,
        payors,
        specialInvoice,
        matterTitle,
        relatedMatter,
        currency,
        openTimekeeper,
        retainerAmount,
        fixedPrice,
        dneNotes,
        webOriginated,
        feesTaxCode,
        entryDate,
        eBilling,
        eBillingType,
        electronicNumber,
        confirmationLetterType,
        rofTemplate,
        startDate1,
        billingTimekeeper,
        responsibleTimekeeper,
        supervisingTimekeeper,
        office,
        section,
        arrangement,
        department,
        practiceGroup,
        pta1,
        industryGroup,
        technicalReviewerNumber,
        technicalReviewerName,
        engineerOfRecordNo,
        engineerOfRecordName,
        bdManagerNo,
        bdManagerName,
        coConsultantsYN,
        coConsultants,
        startDate2,
        specialClientInstruction,
        rate,
        rateExceptGroup,
        timeType,
        flatFeeAmount,
        budget,

        // InCustomerProfileCM  ePath
        kenticoId,

        email,
        salutation,
        firstName,
        lastName,
        phone,
        companyName,
        companyAddress1,
        companyAddress2,
        companyAddressCity,
        companyAddressState,
        companyAddressZip,
        clientNumber,
        entityID,

        outsideCountry,
        oppCountry,
        matterNumber,
        orderingClientID,
        orderingClientNumber
    }

    public enum eOp
    {
        Add,
        Replace
    }
}