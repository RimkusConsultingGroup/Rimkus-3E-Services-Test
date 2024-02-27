using System;
using System.Collections.Generic;

namespace TE3EEntityFramework.Data.TrackerSafe
{
    public class SequentialCaseIdNested
    {
        public int section { get; set; }
        public object nested { get; set; }
    }

    public class FormData
    {
        public string id { get; set; }
        public bool active { get; set; }
        public int entityId { get; set; }
        public int formId { get; set; }
        public string formName { get; set; }
        public object dateFields { get; set; }
        public string data { get; set; }
        public int organizationId { get; set; }
        public int officeId { get; set; }
        public int visibilityId { get; set; }
    }

    public class Item2
    {
        public string sequentialCaseId { get; set; }
        public SequentialCaseIdNested sequentialCaseIdNested { get; set; }
        public string barcode { get; set; }
        public string description { get; set; }
        public DateTime recoveryDate { get; set; }
        public object recoveryLocation { get; set; }
        public bool active { get; set; }
        public int locationId { get; set; }
        public string location { get; set; }
        public object fullLocation { get; set; }
        public object lastLocationId { get; set; }
        public object lastLocation { get; set; }
        public int statusId { get; set; }
        public string status { get; set; }
        public int categoryId { get; set; }
        public string category { get; set; }
        public int custodyReasonId { get; set; }
        public string custodyReason { get; set; }
        public int recoveredById { get; set; }
        public string recoveredBy { get; set; }
        public int submittedById { get; set; }
        public string submittedBy { get; set; }
        public object custodianId { get; set; }
        public object custodian { get; set; }
        public int currentOfficeId { get; set; }
        public string currentOfficeName { get; set; }
        public int primaryCaseId { get; set; }
        public string primaryCaseNumber { get; set; }
        public int primaryCaseOfficerId { get; set; }
        public string primaryCaseOfficer { get; set; }
        public int primaryCaseOffenseTypeId { get; set; }
        public string primaryCaseOffenseType { get; set; }
        public bool isPrimaryCaseRestricted { get; set; }
        public object make { get; set; }
        public object model { get; set; }
        public object serialNumber { get; set; }
        public int creatingOrgId { get; set; }
        public DateTime dateCreated { get; set; }
        public object loaningOrgId { get; set; }
        public object incomingOrgId { get; set; }
        public int sequentialOrgId { get; set; }
        public List<int> cases { get; set; }
        public List<object> caseModels { get; set; }
        public object media { get; set; }
        public int mediaAmount { get; set; }
        public int rootMediaFolderId { get; set; }
        public List<FormData> formData { get; set; }
        public int formDataAmount { get; set; }
        public List<object> notes { get; set; }
        public int notesAmount { get; set; }
        public List<object> tags { get; set; }
        public int tagsAmount { get; set; }
        public List<object> barcodes { get; set; }
        public int barcodesAmount { get; set; }
        public int id { get; set; }
        public int sqlId { get; set; }
        public object people { get; set; }
        public object peopleIds { get; set; }
        public object peopleNames { get; set; }
        public object peopleGuids { get; set; }
        public object parentItemId { get; set; }
        public object parentItemDescription { get; set; }
        public object parentSequentialOrgId { get; set; }
        public List<object> childItems { get; set; }
        public int childItemsAmount { get; set; }
        public object tasks { get; set; }
        public int tasksAmount { get; set; }
        public int historiesAmount { get; set; }
        public bool isForbidden { get; set; }
    }

    public class Entity
    {
        public string sequentialCaseId { get; set; }
        public SequentialCaseIdNested sequentialCaseIdNested { get; set; }
        public string barcode { get; set; }
        public string description { get; set; }
        public DateTime recoveryDate { get; set; }
        public object recoveryLocation { get; set; }
        public bool active { get; set; }
        public int locationId { get; set; }
        public string location { get; set; }
        public object fullLocation { get; set; }
        public object lastLocationId { get; set; }
        public object lastLocation { get; set; }
        public int statusId { get; set; }
        public string status { get; set; }
        public int categoryId { get; set; }
        public string category { get; set; }
        public int custodyReasonId { get; set; }
        public string custodyReason { get; set; }
        public int recoveredById { get; set; }
        public string recoveredBy { get; set; }
        public int submittedById { get; set; }
        public string submittedBy { get; set; }
        public object custodianId { get; set; }
        public object custodian { get; set; }
        public int currentOfficeId { get; set; }
        public string currentOfficeName { get; set; }
        public int primaryCaseId { get; set; }
        public string primaryCaseNumber { get; set; }
        public int primaryCaseOfficerId { get; set; }
        public string primaryCaseOfficer { get; set; }
        public int primaryCaseOffenseTypeId { get; set; }
        public string primaryCaseOffenseType { get; set; }
        public bool isPrimaryCaseRestricted { get; set; }
        public object make { get; set; }
        public object model { get; set; }
        public object serialNumber { get; set; }
        public int creatingOrgId { get; set; }
        public DateTime dateCreated { get; set; }
        public object loaningOrgId { get; set; }
        public object incomingOrgId { get; set; }
        public int sequentialOrgId { get; set; }
        public List<int> cases { get; set; }
        public List<object> caseModels { get; set; }
        public object media { get; set; }
        public int mediaAmount { get; set; }
        public int rootMediaFolderId { get; set; }
        public List<FormData> formData { get; set; }
        public int formDataAmount { get; set; }
        public List<object> notes { get; set; }
        public int notesAmount { get; set; }
        public List<object> tags { get; set; }
        public int tagsAmount { get; set; }
        public List<object> barcodes { get; set; }
        public int barcodesAmount { get; set; }
        public int id { get; set; }
        public int sqlId { get; set; }
        public object people { get; set; }
        public object peopleIds { get; set; }
        public object peopleNames { get; set; }
        public object peopleGuids { get; set; }
        public object parentItemId { get; set; }
        public object parentItemDescription { get; set; }
        public object parentSequentialOrgId { get; set; }
        public List<object> childItems { get; set; }
        public int childItemsAmount { get; set; }
        public object tasks { get; set; }
        public int tasksAmount { get; set; }
        public int historiesAmount { get; set; }
        public bool isForbidden { get; set; }
    }

    public class Item
    {
        public string historyId { get; set; }
        public DateTime timeStamp { get; set; }
        public int historyUserId { get; set; }
        public string historyUserName { get; set; }
        public int historyType { get; set; }
        public int seqOrgItemHistoryId { get; set; }
        public Item2 item { get; set; }
        public Entity entity { get; set; }
    }

    public class ItemHistory
    {
        public string historyType { get; set; }
        public List<Item> item { get; set; }
    }
}