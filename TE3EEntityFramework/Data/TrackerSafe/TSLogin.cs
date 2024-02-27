using System.Collections.Specialized;
using System.Configuration;
using TE3EEntityFramework.Setting;

namespace TE3EEntityFramework.Data.TrackerSafe
{
    public class TSLogin
    {
        private TrackerSafeAppSetting _appSettings;

        public TSLogin(TrackerSafeAppSetting appSettings)
        {
            _appSettings = appSettings;
            OrganizationId = appSettings.OrganizationId;
            OfficeId = appSettings.OfficeId;
        }

        private string devToken = @"
        eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9hZG1pbiI6IkZhbHNlIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvc2lkIjoiMTY2IiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvZW1haWxhZGRyZXNzIjoidHJhY2tlcmFwaUByaW1rdXMuY29tIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvb3JnYW5pemF0aW9uSWQiOiIzIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvb2ZmaWNlSWQiOiI1IiwicmVxdWlyZU1mYSI6IkZhbHNlIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvbmFtZWlkZW50aWZpZXIiOiIxNjYiLCJuYmYiOjE2MTY2MDMyMDUsImV4cCI6MjA4OTYwMjAwMCwiaXNzIjoiaHR0cHM6Ly90cmFja2Vyc2FmZS5yaW1rdXNkZXYuY29tIiwiYXVkIjoiNDFjOTE4MmM0NjgxNDYxMGI2NjBjOTYyODhmMmQ2NmUifQ.Ies7o4MhHlzamF6KGlNw3oOXwLLHAzv9oJ3taud6o5I";
        private string prodToken = @"
        eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9hZG1pbiI6IkZhbHNlIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvc2lkIjoiMTY2IiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvZW1haWxhZGRyZXNzIjoidHJhY2tlcmFwaUByaW1rdXMuY29tIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvb3JnYW5pemF0aW9uSWQiOiIzIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvb2ZmaWNlSWQiOiI1IiwicmVxdWlyZU1mYSI6IkZhbHNlIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvbmFtZWlkZW50aWZpZXIiOiIxNjYiLCJuYmYiOjE1ODA4NDYxMTUsImV4cCI6MjA1MzgzNjAwMCwiaXNzIjoiaHR0cHM6Ly90cmFja2Vyc2FmZS5yaW1rdXMuY29tIiwiYXVkIjoiODgyYWI0ZjVjNjYwNDMwMTgyOTQ2ZThjYTEwOGI4YTUifQ.Jxt-3fwPEirASPvf9FGCoYsK8t9AWw_A797asIHGP5s";

        public string Token
        {
            get { return _appSettings.IsDebug ? devToken : prodToken; }
        }

        public string OrganizationId;

        public string OfficeId;

    }
}