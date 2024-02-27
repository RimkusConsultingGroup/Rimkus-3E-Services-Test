using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TE3EEntityFramework.Data.TrackerSafe
{
    public class UserValue
    {
        public string Id { get; set; }
        public string Guid { get; set; }
        public string Email { get; set; }
        public string MobilePhone { get; set; }
        public string OtherPhone { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string DisplayedName { get; set; }
        public string OrganizationId { get; set; }
        public string OrganizationName { get; set; }
        public string PhotoId { get; set; }
        public object Note { get; set; }
        public bool Active { get; set; }
        public string PersonId { get; set; }
        public bool IsExternal { get; set; }
        public bool IsOrgAdmin { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool IsGoogleAuthenticatorEnabled { get; set; }
        public bool EmailDisable { get; set; }
        public List<object> Groups { get; set; }
        public List<object> UserGroups { get; set; }
        public bool IsLockedOut { get; set; }
    }

    public class User
    {
        public List<UserValue> value { get; set; }
    }

    public class CaseOfficeUser
    {
        public int UsersCount { get; set; }

        public List<CaseUser> Users { get; set; }
    }

    public class CaseUser
    {
        public int Id { get; set; }

        public string Text { get; set; }
    }
}
