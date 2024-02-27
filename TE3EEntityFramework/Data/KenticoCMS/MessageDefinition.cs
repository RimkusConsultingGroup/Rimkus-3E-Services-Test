using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TE3EEntityFramework.Data.KenticoCMS
{
    public class Assignment
    {
        public int e3EId { get; set; }
        public string kenticoId { get; set; }
        public string matterStatus { get; set; }
        public int matterStatusId { get; set; }

        //# Section: Client Contact
        public string orderClientContactSalutation { get; set; }
        public string orderClientContactFirstName { get; set; }
        public string orderClientContactLastName { get; set; }
        public string orderClientContactEmail { get; set; }
        public string orderClientContactPhoneNo { get; set; }

        //# Section: Client Company
        public string orderClientCompanyName { get; set; }
        public string orderClientCompanyAddress1 { get; set; }
        public string orderClientCompanyAddress2 { get; set; }
        public string orderClientCompanyAddressCity { get; set; }
        public string orderClientCompanyAddressState { get; set; }
        public string orderClientCompanyAddressZip { get; set; }
        public string orderClientCompanyType { get; set; }
        //   "enum": [
        //"insurance",
        //"tpa",
        //"ia",
        //"attorney",
        //"corporation",
        //"government",
        //"other"
        //]

        //# Section: Incident Information
        public bool incidentYN { get; set; }
        public string dateOccurence { get; set; }
        public bool dateUnknown { get; set; }
        public IncidentLocations[] incidentLocations { get; set; }
        //"type": "array",
        //     "items": {
        //"$ref": "#/definitions/IncidentLocation"
        //}

        public string descOccurence { get; set; }
        public string needAnswered { get; set; }
        public string specialInstructions { get; set; }

        //# Section: Adjuster Information
        public string adjusterType { get; set; }
        //   "enum": [
        //"self",
        //"outside",
        //"none"
        //]
        public bool authYN { get; set; }
        public string outsideCompName { get; set; }
        public string outsideFirstName { get; set; }
        public string outsideLastName { get; set; }
        public string outsideAdjEmail { get; set; }
        public string outsideAdjPhone { get; set; }
        public string adjusterInvoicing { get; set; }
        //    "enum": [
        //"self",
        //"adjuster"
        //]
        public string outsideAddr1 { get; set; }
        public string outsideAddr2 { get; set; }
        public string outsideCity { get; set; }
        public string outsideState { get; set; }
        public string outsideZip { get; set; }
        public string paraFirstName { get; set; }
        public string paraLastName { get; set; }
        public string repType { get; set; }
        //   "enum": [
        //"defendant",
        //"plaintiff",
        //"subrogation",
        //"na"
        //]
        public string legalClientType { get; set; }
        //    "enum": [
        //"individual",
        //"company",
        //"government"
        //]
        public string insFirstName { get; set; }
        public string insLastName { get; set; }
        public string insPOCNo { get; set; }
        public string insPOC { get; set; }
        public string insNo { get; set; }
        public bool opposingYN { get; set; }
        public string oppName { get; set; }
        public string oppAttyFirstName { get; set; }
        public string oppAttyLastName { get; set; }
        public string oppStreetAddr1 { get; set; }
        public string oppStreetAddr2 { get; set; }
        public string oppCity { get; set; }
        public string oppState { get; set; }
        public string oppZip { get; set; }
        public OpposingParties[] opposingParties { get; set; }
        //    "type": "array",
        //"items": {
        //"$ref": "#/definitions/OpposingParty"
        //}
        public bool suitYN { get; set; }
        public string causeNumber { get; set; }
        public string court { get; set; }
        public string style { get; set; }

        //# Section: Reference Numbers
        public ReferenceNumbers[] referenceNumbers { get; set; }
        //   "type": "array",
        //"items": {
        //"$ref": "#/definitions/ReferenceNumber"
        //}

        //# Section: Parties
        public Parties[] parties { get; set; }
        //    "type": "array",
        //"items": {
        //"$ref": "#/definitions/Party"
        //}

        //# Section: Multipayor Information
        public bool multipayorYN { get; set; }
        public string multipayorInvoicing { get; set; }
        //    "enum": [
        //"invoice",
        //"allocate",
        //"schedule"
        //]

        public Payors[] payors { get; set; }
        //    "type": "array",
        //"items": {
        //"$ref": "#/definitions/Payor"
        //}

        //# Section: Invoice Instructions
        public string specialInvoice { get; set; }

        //# Section: Internal Use Only
        public string matterName { get; set; }
        public string relatedMatter { get; set; }
        public string currency { get; set; }
        public int openTimekeeper { get; set; }
        public double retainerAmount { get; set; }
        public bool fixedPrice { get; set; }
        public string dneNotes { get; set; }
        public bool webOriginated { get; set; }
        public string feesTaxCode { get; set; }
        public string entryDate { get; set; }
        public bool eBilling { get; set; }
        public string eBillingType { get; set; }
        //   "type": "string",
        //"enum": [
        //"Legal-X",
        //"Tymetrix 360"
        //]
        public string electronicNumber { get; set; }
        public string confirmationLetterType { get; set; }
        //    "enum": [
        //"Standard",
        //"Legal",
        //"Natonal Agreement",
        //"CAT",
        //"Engineering Services",
        //"Retainer",
        //"Signature"
        //]

        public string rofTemplate { get; set; }
        public string startDate1 { get; set; }
        public string billingTimekeeper { get; set; }
        public string responsibleTimekeeper { get; set; }
        public string supervisingTimekeeper { get; set; }
        public string office { get; set; }
        //    "enum": [
        //"All Offices",
        //"CAT and Profit Centers"
        //]
        public string section { get; set; }
        public string arrangement { get; set; }
        //enum:
        //- "Flat Fee"
        //- "Hourly"

        public string department { get; set; }
        public string practiceGroup { get; set; }
        //    "enum": [
        //"Commercial - 1st Party",
        //"Commercial - 3rd Party",
        //"Default",
        //"Personal Lines - 1st Party",
        //"Personal Lines - 3rd Party",
        //"Undefined"
        //]
        public string pta1 { get; set; }
        public string industryGroup { get; set; }
        public int technicalReviewerNumber { get; set; }
        public string technicalReviewerName { get; set; }
        public int engineerOfRecordNo { get; set; }
        public string engineerOfRecordName { get; set; }
        public int bdManagerNo { get; set; }
        public string bdManagerName { get; set; }
        public bool coConsultantsYN { get; set; }
        public CoConsultant[] coConsultants { get; set; }
        //    "type": "array",
        //"items": {
        //"$ref": "#/definitions/CoConsultant"
        //}
        public string startDate2 { get; set; }
        public string specialClientInstruction { get; set; }
        public string rate { get; set; }
        //     "enum": [
        //"Investigative",
        //"Investigative-Canada",
        //"Investigative-London",
        //"Legal",
        //"Legal - Canada",
        //"Legal - London"
        //]
        public string rateExceptGroup { get; set; }
        public string timeType { get; set; }
        public double flatFeeAmount { get; set; }
        public double budget { get; set; }

    }

    public class IncidentLocations
    {
        public string kenticoIncidentLocationId { get; set; }
        public string streetOccurence { get; set; }
        public string cityOccurence { get; set; }
        public string countyOccurence { get; set; }
        public string stateOccurence { get; set; }
        public string zipCodeOccurence { get; set; }
        public string countryOccurence { get; set; }
        public string latOccurence { get; set; }
        public string lonOccurence { get; set; }
    }
    public class OpposingParties
    {
        public string kenticoOpposingPartyId { get; set; }
        public string attorneysClientType { get; set; }
        public string opposingAttorneysClientName { get; set; }
    }
    public class ReferenceNumbers
    {
        public string kenticoReferenceNumberId { get; set; }
        public string type { get; set; }
        public string number { get; set; }
        public bool includeForBilling { get; set; }
    }
    public class Parties
    {
        public string kenticoPartyId { get; set; }
        public string entityType { get; set; }
        public string partyType { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string companyName { get; set; }
        public string contactName { get; set; }
        public string phone { get; set; }
    }
    public class Payors
    {
        public string kenticoPayorId { get; set; }
        public string payName { get; set; }
        public string invoicePercentage { get; set; }
        public string referenceNumber { get; set; }
        public string payFirstName { get; set; }
        public string payLastName { get; set; }
        public string payPhone { get; set; }
        public string payEmail { get; set; }
        public string payAddr1 { get; set; }
        public string payAddr2 { get; set; }
        public string payCity { get; set; }
        public string payState { get; set; }
        public string payZip { get; set; }
        public string careOf { get; set; }
    }
    public class CoConsultant
    {
        public string kenticoCoConsultantId { get; set; }
        public string coConsultantNumber { get; set; }
        public string coConsultantName { get; set; }
    }

}
