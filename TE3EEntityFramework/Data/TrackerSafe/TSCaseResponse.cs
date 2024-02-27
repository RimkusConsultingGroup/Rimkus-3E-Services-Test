using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TE3EEntityFramework.Data.TrackerSafe
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class TSFormDataResponse
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

    public class TSCaseResponse
    {
        public int id { get; set; }
        public string caseNumber { get; set; }
        public List<int> caseOfficerIds { get; set; }
        public List<string> caseOfficers { get; set; }
        public int offenseTypeId { get; set; }
        public string offenseType { get; set; }
        public string offenseDescription { get; set; }
        public object offenseLocation { get; set; }
        public DateTime? offenseDate { get; set; }
        public DateTime? followUpDate { get; set; }
        public bool active { get; set; }
        public int officeId { get; set; }
        public string officeName { get; set; }
        public int creatorId { get; set; }
        public string creator { get; set; }
        public DateTime? createdDate { get; set; }
        public int organizationId { get; set; }
        public string organizationName { get; set; }
        public List<object> items { get; set; }
        public string nextItemId { get; set; }
        public object media { get; set; }
        public int mediaAmount { get; set; }
        public int rootMediaFolderId { get; set; }
        public List<TSFormDataResponse> formData { get; set; }
        public int formDataAmount { get; set; }
        public List<int> notes { get; set; }
        public int notesAmount { get; set; }
        public int itemsNotesAmount { get; set; }
        public List<object> tags { get; set; }
        public int tagsAmount { get; set; }
        public int peopleAmount { get; set; }
        public int tasksAmount { get; set; }
        public int historiesAmount { get; set; }
        public DateTime? closedDate { get; set; }
        public DateTime? reviewDate { get; set; }
        public string reviewDateNotes { get; set; }
        public bool isRestricted { get; set; }
        public int permissionAmount { get; set; }
        public string permissions { get; set; }
        public bool isForbidden { get; set; }
    }

    #region TSCaseSearchModel

    public class TSStaticField
    {
        public string name { get; set; }
        public int typeId { get; set; }
        public string fieldName { get; set; }
        public int searchCriteriasType { get; set; }
        public int searchCriteria { get; set; }
        public DateTime toDate { get; set; }
        public DateTime model { get; set; }
    }

    public class TSDynamicField
    {
        public int formId { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string fieldType { get; set; }
        public int searchCriteria { get; set; }
        public string model { get; set; }
        public bool searchJustForm { get; set; }
    }

    public class TSCaseSearchModel
    {
        public List<TSStaticField> StaticFields { get; set; }
        public List<int> officeIds { get; set; }
        public string orderBy { get; set; }
        public bool orderByAsc { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public bool IsSearchingInSublocations { get; set; }
        public List<TSDynamicField> DynamicFields { get; set; }
    }

    #endregion

    #region TSCaseSearchResponse
    public class TSFormDataParsed
    {
        public string value { get; set; }
        public string searchName { get; set; }
        public int? customFormId { get; set; }
        public string customFormName { get; set; }
        public string fieldName { get; set; }
        public string fieldType { get; set; }
        public string name { get; set; }
        public string text { get; set; }
    }

    public class TSSearchCaseData
    {
        public List<TSFormDataParsed> formDataParsed { get; set; }
        public int id { get; set; }
        public string caseNumber { get; set; }
        public int? caseOfficerId { get; set; }
        public string caseOfficer { get; set; }
        public int? offenseTypeId { get; set; }
        public string offenseType { get; set; }
        public string offenseDescription { get; set; }
        public object offenseLocation { get; set; }
        public string offenseDate { get; set; }
        public DateTime? followUpDate { get; set; }
        public bool active { get; set; }
        public int? officeId { get; set; }
        public string officeName { get; set; }
        public int? creatorId { get; set; }
        public string creator { get; set; }
        public DateTime? createdDate { get; set; }
        public int? organizationId { get; set; }
        public string organizationName { get; set; }
        public List<object> items { get; set; }
        public string nextItemId { get; set; }
        public object media { get; set; }
        public int? mediaAmount { get; set; }
        public int? rootMediaFolderId { get; set; }
        public object formData { get; set; }
        public int? formDataAmount { get; set; }
        public object notes { get; set; }
        public int? notesAmount { get; set; }
        public int? itemsNotesAmount { get; set; }
        public object tags { get; set; }
        public int? tagsAmount { get; set; }
        public int? peopleAmount { get; set; }
        public int? tasksAmount { get; set; }
        public int? historiesAmount { get; set; }
        public DateTime? closedDate { get; set; }
        public DateTime? reviewDate { get; set; }
        public string reviewDateNotes { get; set; }
        public bool isRestricted { get; set; }
        public int? permissionAmount { get; set; }
        public object permissions { get; set; }
        public bool isForbidden { get; set; }
    }

    public class TSCaseSearchResponse
    {
        public int count { get; set; }
        public List<TSSearchCaseData> data { get; set; }
    } 
    #endregion
}
