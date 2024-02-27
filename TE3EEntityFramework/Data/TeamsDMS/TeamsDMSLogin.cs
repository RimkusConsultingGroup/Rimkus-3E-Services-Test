using System.Collections.Specialized;
using System.Configuration;
using TE3EEntityFramework.Setting;

namespace TE3EEntityFramework.Data.TrackerSafe
{
    public class TeamsDMSLogin
    {
        public TeamsDMSLogin(TeamsDMSAppSetting appSettings)
        {
            IsDebug = appSettings.IsDebug;
            SqlCommandTimeout = appSettings.SqlCommandTimeout;
            AzureFuncBaseUrl = appSettings.AzureDMSSetting.AzureFuncBaseUrl;
        }

        private string token = @"
        eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9hZG1pbiI6IkZhbHNlIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvc2lkIjoiMTY2IiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvZW1haWxhZGRyZXNzIjoidHJhY2tlcmFwaUByaW1rdXMuY29tIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvb3JnYW5pemF0aW9uSWQiOiIzIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvb2ZmaWNlSWQiOiI1IiwicmVxdWlyZU1mYSI6IkZhbHNlIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvbmFtZWlkZW50aWZpZXIiOiIxNjYiLCJuYmYiOjE1ODA4NDYxMTUsImV4cCI6MjA1MzgzNjAwMCwiaXNzIjoiaHR0cHM6Ly90cmFja2Vyc2FmZS5yaW1rdXMuY29tIiwiYXVkIjoiODgyYWI0ZjVjNjYwNDMwMTgyOTQ2ZThjYTEwOGI4YTUifQ.Jxt-3fwPEirASPvf9FGCoYsK8t9AWw_A797asIHGP5s
        ";

        public string Token
        {
            get { return token; }
        }

        public bool IsDebug;

        public int SqlCommandTimeout;

        public string AzureFuncBaseUrl;

    }
}