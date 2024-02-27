using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TE3EEntityFramework.Data.TeamsDMS;
using TE3EEntityFramework.Data.TrackerSafe;
using TE3EEntityFramework.Datasource;
using TE3EEntityFramework.Setting;

namespace TE3EEntityFramework.Client
{
    public class TeamsDmsWebClient
    {
        private TeamsDMSLogin teamsDMSLogin;
        private TeamsDMSAppSetting tDmsappSetting;

        public TeamsDmsWebClient(TeamsDMSAppSetting appSettings)
        {
            teamsDMSLogin = new TeamsDMSLogin(appSettings);
            tDmsappSetting = appSettings;
        }

        public DmsWebResponse Push3eMatterToTeamsDMS(TeamsMatter teamsMatter)
        {
            DmsWebResponse dmsWebResponse = new DmsWebResponse();
            HttpWebRequest request = null;
            string requestJson = "";

            if(teamsMatter.isTeamRehydrated) //rehydrate team
            {
                request = CreatePostHttpWebRequest(TeamsDMSUrlVerbs.GetAzureFuncUrl(AzureFuncURL.TEAMACTION, tDmsappSetting));
                TeamAction teamAction = new TeamAction
                {
                    mattNum = teamsMatter.mattNum,
                    mattName = teamsMatter.mattName,
                    rspTkpr = teamsMatter.rspkpr,
                    actionDirective = "RehydrateTeam",
                    reason = "Rehydrate Team",
                    processId = "3E",
                    extendedProperties = new ExtendedProperties 
                    { 
                        ownerUsers = string.Join(",", teamsMatter.ownerUsers),
                        memberUsers = string.Join(",", teamsMatter.memberUsers)
                    }
                };

                requestJson = JsonConvert.SerializeObject(teamAction);
            }
            else if(teamsMatter.isTeamRehydrated && teamsMatter.isTeamsChanged)
            {
                StringBuilder sb1 = new StringBuilder();
                StringBuilder sb2 = new StringBuilder();

                //rehydrate team
                if (teamsMatter.isTeamRehydrated)
                {
                    request = CreatePostHttpWebRequest(TeamsDMSUrlVerbs.GetAzureFuncUrl(AzureFuncURL.TEAMACTION, tDmsappSetting));
                    TeamAction teamAction = new TeamAction
                    {
                        mattNum = teamsMatter.mattNum,
                        mattName = teamsMatter.mattName,
                        rspTkpr = teamsMatter.rspkpr,
                        actionDirective = "RehydrateTeam",
                        reason = "Rehydrate Team",
                        processId = "3E",
                        extendedProperties = new ExtendedProperties
                        {
                            ownerUsers = string.Join(",", teamsMatter.ownerUsers),
                            memberUsers = string.Join(",", teamsMatter.memberUsers)
                        }
                    };

                    requestJson = JsonConvert.SerializeObject(teamAction);

                    byte[] bytes1 = System.Text.Encoding.UTF8.GetBytes(requestJson);
                    request.ContentLength = bytes1.Length;

                    Stream dataStream1 = request.GetRequestStream();
                    dataStream1.Write(bytes1, 0, bytes1.Length);
                    dataStream1.Close();

                    HttpWebResponse response1 = (HttpWebResponse)request.GetResponse();
                    string result1 = "";

                    using (dataStream1 = response1.GetResponseStream())
                    {
                        StreamReader streamreader = new StreamReader(dataStream1);
                        result1 = streamreader.ReadToEnd();
                    }

                    dmsWebResponse.webResponse = response1;
                    response1.Close();

                    sb1 = new StringBuilder();
                    sb1.AppendLine($"Result: {result1}");
                    sb1.AppendLine($"RequestJson: {requestJson}");
                    dmsWebResponse.rawResponse = sb1.ToString();

                    return dmsWebResponse;
                }

                //case assignment
                if (teamsMatter.isTeamsChanged)
                {
                    request = CreatePostHttpWebRequest(TeamsDMSUrlVerbs.GetAzureFuncUrl(AzureFuncURL.CASEASSIGNMENT, tDmsappSetting));
                    CaseAssignment caseAssignment = new CaseAssignment
                    {
                        mattNum = teamsMatter.mattNum,
                        mattName = teamsMatter.mattName,
                        rspTkpr = teamsMatter.rspkpr,
                        narrative = teamsMatter.narrative,
                        scopeOfWork = teamsMatter.scopeOfWork,
                        ownerUsers = teamsMatter.ownerUsers,
                        memberUsers = teamsMatter.memberUsers
                    };

                    requestJson = JsonConvert.SerializeObject(caseAssignment);

                    byte[] bytes2 = System.Text.Encoding.UTF8.GetBytes(requestJson);
                    request.ContentLength = bytes2.Length;

                    Stream dataStream2 = request.GetRequestStream();
                    dataStream2.Write(bytes2, 0, bytes2.Length);
                    dataStream2.Close();

                    HttpWebResponse response2 = (HttpWebResponse)request.GetResponse();
                    string result2 = "";

                    using (dataStream2 = response2.GetResponseStream())
                    {
                        StreamReader streamreader = new StreamReader(dataStream2);
                        result2 = streamreader.ReadToEnd();
                    }

                    dmsWebResponse.webResponse = response2;
                    response2.Close();

                    sb2 = new StringBuilder();
                    sb2.AppendLine($"Result: {result2}");
                    sb2.AppendLine($"RequestJson: {requestJson}");
                }

                StringBuilder newSb = new StringBuilder();
                newSb.AppendLine(sb1.ToString());
                newSb.AppendLine(sb2.ToString());
                dmsWebResponse.rawResponse = newSb.ToString();

                return dmsWebResponse;

            }
            else if (teamsMatter.caseStatus == CaseStatus.Open ||
                    teamsMatter.caseStatus == CaseStatus.NoBilling ||
                    teamsMatter.caseStatus == CaseStatus.OpenforEvidenceBilling ||
                    teamsMatter.caseStatus == CaseStatus.OpenforTime ||
                    teamsMatter.caseStatus == CaseStatus.Pending ||
                    teamsMatter.caseStatus == CaseStatus.Hold ||
                    teamsMatter.caseStatus == CaseStatus.AwaitingRetainer) //case opened 
            {
                if (teamsMatter.isTeamsChanged) //case assignment
                {
                    request = CreatePostHttpWebRequest(TeamsDMSUrlVerbs.GetAzureFuncUrl(AzureFuncURL.CASEASSIGNMENT, tDmsappSetting));
                    CaseAssignment caseAssignment = new CaseAssignment
                    {
                        mattNum = teamsMatter.mattNum,
                        mattName = teamsMatter.mattName,
                        rspTkpr = teamsMatter.rspkpr,
                        narrative = teamsMatter.narrative,
                        scopeOfWork = teamsMatter.scopeOfWork,
                        ownerUsers = teamsMatter.ownerUsers,
                        memberUsers = teamsMatter.memberUsers
                    };

                    requestJson = JsonConvert.SerializeObject(caseAssignment);
                }
                else
                {
                    request = CreatePostHttpWebRequest(TeamsDMSUrlVerbs.GetAzureFuncUrl(AzureFuncURL.CASEOPENED, tDmsappSetting));
                    CaseOpened caseOpened = new CaseOpened
                    {
                        assignmentId = teamsMatter.assignmentId,
                        mattNum = teamsMatter.mattNum,
                        mattName = teamsMatter.mattName,
                        mattDate = teamsMatter.mattDate,
                        openTkpr = teamsMatter.openTkpr,
                        reportingOffice = teamsMatter.reportingOffice,
                        section = teamsMatter.section,
                        department = teamsMatter.department,
                        narrative = teamsMatter.narrative,
                        scopeOfWork = teamsMatter.scopeOfWork,
                        mattDesc = teamsMatter.mattDesc,
                        ownerUsers = teamsMatter.ownerUsers,
                        memberUsers = teamsMatter.memberUsers,
                        evidenceId = teamsMatter.evidenceId,
                        processId = teamsMatter.processId
                    };

                    requestJson = JsonConvert.SerializeObject(caseOpened);
                }
                
            }
            else if (teamsMatter.caseStatus == CaseStatus.Closed ||
                    teamsMatter.caseStatus == CaseStatus.Complete ||
                    teamsMatter.caseStatus == CaseStatus.ClientRefused ||
                    teamsMatter.caseStatus == CaseStatus.Declined) //case closed
            {
                request = CreatePostHttpWebRequest(TeamsDMSUrlVerbs.GetAzureFuncUrl(AzureFuncURL.CASECLOSED, tDmsappSetting));
                CaseClosed caseClosed = new CaseClosed
                {
                    mattNum = teamsMatter.mattNum,
                    mattName = teamsMatter.mattName,
                    closeTkpr = teamsMatter.closeTkpr,
                    reason = !string.IsNullOrEmpty(teamsMatter.reason) ? teamsMatter.reason : $"Case is closed",
                    closeDate = teamsMatter.closeDate
                };

                requestJson = JsonConvert.SerializeObject(caseClosed);
            }

            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(requestJson);
            request.ContentLength = bytes.Length;

            Stream dataStream = request.GetRequestStream();
            dataStream.Write(bytes, 0, bytes.Length);
            dataStream.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string result = "";

            using (dataStream = response.GetResponseStream())
            {
                StreamReader streamreader = new StreamReader(dataStream);
                result = streamreader.ReadToEnd();
            }

            dmsWebResponse.webResponse = response;
            response.Close();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Result: {result}");
            sb.AppendLine($"RequestJson: {requestJson}");
            dmsWebResponse.rawResponse = sb.ToString();

            return dmsWebResponse;
        }

        private HttpWebRequest CreatePostHttpWebRequest(string urlVerb)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(string.Format("{0}{1}", teamsDMSLogin.AzureFuncBaseUrl, urlVerb));

            request.Method = WebRequestMethods.Http.Post;
            request.AllowAutoRedirect = true;
            request.Accept = "application/json";
            request.ContentType = "application/json";
            //request.Headers.Add("Authorization", CreateBearerAuthHeader(tSLogin.Token));
            //request.Headers.Add("OrganizationID", tSLogin.OrganizationId);
            //request.Headers.Add("OfficeID", !string.IsNullOrEmpty(officeId) ? officeId.ToString() : tSLogin.OfficeId);
            //request.Headers.Add("StaticToken", "True");

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                                                    | SecurityProtocolType.Tls11
                                                    | SecurityProtocolType.Tls12
                                                    | SecurityProtocolType.Ssl3;

            return request;
        }

        private HttpWebRequest CreatePutHttpWebRequest(string urlVerb)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(string.Format("{0}{1}", teamsDMSLogin.AzureFuncBaseUrl, urlVerb));

            request.Method = WebRequestMethods.Http.Put;
            request.AllowAutoRedirect = true;
            request.Accept = "application/json";
            request.ContentType = "application/json";
            //request.Headers.Add("Authorization", CreateBearerAuthHeader(tSLogin.Token));
            //request.Headers.Add("OrganizationID", tSLogin.OrganizationId);
            //request.Headers.Add("OfficeID", !string.IsNullOrEmpty(officeId) ? officeId.ToString() : tSLogin.OfficeId);
            //request.Headers.Add("StaticToken", "True");

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                                                    | SecurityProtocolType.Tls11
                                                    | SecurityProtocolType.Tls12
                                                    | SecurityProtocolType.Ssl3;

            return request;
        }

        private HttpWebRequest CreateGetHttpWebRequest(string urlVerb)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(string.Format("{0}{1}", teamsDMSLogin.AzureFuncBaseUrl, urlVerb));

            request.Method = WebRequestMethods.Http.Get;
            request.AllowAutoRedirect = true;
            request.Accept = "application/json";
            request.ContentType = "application/x-www-form-urlencoded";
            //request.Headers.Add("Authorization", CreateBearerAuthHeader(tSLogin.Token));
            //request.Headers.Add("OrganizationID", tSLogin.OrganizationId);
            //request.Headers.Add("OfficeID", tSLogin.OfficeId);
            //request.Headers.Add("StaticToken", "True");

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                                                    | SecurityProtocolType.Tls11
                                                    | SecurityProtocolType.Tls12
                                                    | SecurityProtocolType.Ssl3;

            return request;
        }

        private string CreateBearerAuthHeader(string token)
        {
            return "Bearer " + token;
        }
    }

    public class DmsWebResponse
    {
        public HttpWebResponse webResponse { get; set; }

        public string rawResponse { get; set; }
    }
}
