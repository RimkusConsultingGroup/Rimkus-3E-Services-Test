using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TE3EEntityFramework.Data.TrackerSafe
{
    public class TSOffices
    {
        public int Id { get; set; }
        public string Guid { get; set; }
        public string CreateDateTime { get; set; }
        public string UpdatedDateTime { get; set; }
        public bool IsDeleted { get; set; }
        public int UserCount { get; set; }
        public int GeneralTaskFromUserId { get; set; }
        public string GeneralTaskFromUser { get; set; }
        public int GeneralTaskFromUserGroupId { get; set; }
        public string GeneralTaskFromUserGroup { get; set; }
        public bool IsDefaultTaskFrom { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
        public int PhotoId { get; set; }
        public string PhotoOffice { get; set; }
        public bool Active { get; set; }
        public int OrganizationId { get; set; }
        public string Organization { get; set; }
        public string ReservedLicenses { get; set; }
        public int LanguageTemplateId { get; set; }
        public string LanguageTemplate { get; set; }
    }
}
