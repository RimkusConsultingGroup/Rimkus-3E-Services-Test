using System;
using System.Collections.Generic;

namespace TE3EEntityFramework.Data.LibertyMutual
{

    #region Common Events Props

    public class ClaimEvent
    {
        public string ClaimEventType { get; set; }
        public string EventNotificationType { get; set; }
    }

    public class User
    {
        public string LoginName { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserRole { get; set; }
        public Company Company { get; set; }
    }
    public class Company
    {
        public string HeadOfficeCompanyID { get; set; }
        public string CompanyID { get; set; }
        public string ExternalSystemCompanyCode { get; set; }
        public string CompanyName { get; set; }
    }
    #endregion

    #region Parent Notification Model

    // ClaimNotification myDeserializedClass = JsonConvert.DeserializeObject<ClaimNotification>(myJsonResponse); 


    public class ClaimNotification
    {
        public string Number { get; set; }
        public string UniqueID { get; set; }
        public string ExternalReference { get; set; }
        public string PolicyNumber { get; set; }
        public string FileNumber { get; set; }
        public string Status { get; set; }
        public Company OriginatorCompany { get; set; }
        public List<CLAIMASSIGNMENTEVENT> Events { get; set; }
        public User User { get; set; }
    }



    #endregion

    #region All Events

    // CLAIMASSIGNMENTEVENT myDeserializedClass = JsonConvert.DeserializeObject<CLAIMASSIGNMENTEVENT>(myJsonResponse); 
    public class CLAIMASSIGNMENTEVENT : ClaimEvent
    {
        public int AssignmentID { get; set; }
        public int ParentAssignmentID { get; set; }
        public string Name { get; set; }
        public string AssignmentTypeCode { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }
        public Company AssignedBy { get; set; }
        public Company Assignee { get; set; }
        public User InternalAssignee { get; set; }
    }

    // CLAIMCALENDAREVENT myDeserializedClass = JsonConvert.DeserializeObject<CLAIMCALENDAREVENT>(myJsonResponse); 
    public class CLAIMCALENDAREVENT : ClaimEvent
    {
        public int CalendarEventID { get; set; }
        public string CategoryName { get; set; }
        public string Subject { get; set; }
    }

    // CLAIMDIAGRAMEVENT myDeserializedClass = JsonConvert.DeserializeObject<CLAIMDIAGRAMEVENT>(myJsonResponse); 
    public class CLAIMDIAGRAMEVENT : ClaimEvent
    {
        public int DiagramID { get; set; }
        public Company AuthorCompany { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }

    // CLAIMESTIMATEEVENT myDeserializedClass = JsonConvert.DeserializeObject<CLAIMESTIMATEEVENT>(myJsonResponse); 
    public class CLAIMESTIMATEEVENT : ClaimEvent
    {
        public int EstimateID { get; set; }
        public int ParentEstimateID { get; set; }
        public string Name { get; set; }
        public string ParentEstimateName { get; set; }
        public Company AuthorCompany { get; set; }
        public string Status { get; set; }
    }

    // CLAIMEXTERNALDOCUMENTEVENT myDeserializedClass = JsonConvert.DeserializeObject<CLAIMEXTERNALDOCUMENTEVENT>(myJsonResponse); 
    public class CLAIMEXTERNALDOCUMENTEVENT : ClaimEvent
    {
        public int ExternalDocumentID { get; set; }
        public Company CreatorCompany { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
    }

    // CLAIMFORMEVENT myDeserializedClass = JsonConvert.DeserializeObject<CLAIMFORMEVENT>(myJsonResponse); 
    public class CLAIMFORMEVENT : ClaimEvent
    {
        public int FormID { get; set; }
        public Company AuthorCompany { get; set; }
        public string Name { get; set; }
        public string OriginalName { get; set; }
    }

    // CLAIMHANDWRITTENNOTEEVENT myDeserializedClass = JsonConvert.DeserializeObject<CLAIMHANDWRITTENNOTEEVENT>(myJsonResponse); 
    public class CLAIMHANDWRITTENNOTEEVENT : ClaimEvent
    {
        public int HandwrittenNoteID { get; set; }
        public Company AuthorCompany { get; set; }
        public string Name { get; set; }
    }

    // CLAIMMANUALJOURNALENTRYEVENT myDeserializedClass = JsonConvert.DeserializeObject<CLAIMMANUALJOURNALENTRYEVENT>(myJsonResponse); 
    public class CLAIMMANUALJOURNALENTRYEVENT : ClaimEvent
    {
        public DateTime CreationDate { get; set; }
        public string Entry { get; set; }
        public User AuthorUser { get; set; }
    }

    // CLAIMNUMBERCHANGEDEVENT myDeserializedClass = JsonConvert.DeserializeObject<CLAIMNUMBERCHANGEDEVENT>(myJsonResponse); 
    public class CLAIMNUMBERCHANGEDEVENT : ClaimEvent
    {
        public string PreviousNumber { get; set; }
    }

    // CLAIMPAYMENTEVENT myDeserializedClass = JsonConvert.DeserializeObject<CLAIMPAYMENTEVENT>(myJsonResponse); 
    public class CLAIMPAYMENTEVENT : ClaimEvent
    {
        public int PaymentID { get; set; }
        public Company AuthorCompany { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
    }

    // CLAIMPHOTOPAGEEVENT myDeserializedClass = JsonConvert.DeserializeObject<CLAIMPHOTOPAGEEVENT>(myJsonResponse); 
    public class CLAIMPHOTOPAGEEVENT : ClaimEvent
    {
        public int PhotoPageID { get; set; }
        public Company AuthorCompany { get; set; }
        public string Name { get; set; }
    }

    // CLAIMTASKEVENT myDeserializedClass = JsonConvert.DeserializeObject<CLAIMTASKEVENT>(myJsonResponse); 
    public class CLAIMTASKEVENT : ClaimEvent
    {
        public int TaskID { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
    }

    // CLAIMUSEREVENT myDeserializedClass = JsonConvert.DeserializeObject<CLAIMUSEREVENT>(myJsonResponse); 
    public class CLAIMUSEREVENT : ClaimEvent
    {
        public User User { get; set; }
    }

    #endregion
}
