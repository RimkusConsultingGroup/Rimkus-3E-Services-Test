using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using TE3EEntityFramework.Data.TrackerSafe;
using TE3EEntityFramework.Datasource;
using TE3EEntityFramework.Setting;

namespace TE3EEntityFramework.Client
{
    public class TrackerSafeWebClient
    {
        //private string sTSBaseUrl = "https://trackersafeapi.rimkus.com";

        private TSLogin tSLogin;
        private TrackerSafeAppSetting _appSettings;

        public TrackerSafeWebClient(TrackerSafeAppSetting appSettings)
        {
            _appSettings = appSettings;
            tSLogin = new TSLogin(appSettings);
        }

        public void TriggerEmailDecisionLetter()
        {

        }

        public void updateCaseMedia(ClientTS3EInfo client)
        {

        }

        public string GetSpecificCaseJson(string matterNo)
        {
            var request = CreateGetHttpWebRequest(TSUrlVerbs.GetApiUrl(TSAPIURL.GETSPECIFICCASE).Replace("@caseNo", matterNo));
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();

            string result = string.Empty;

            using (StreamReader streamreader = new StreamReader(stream))
            {
                result = streamreader.ReadToEnd();
            }

            return result;
        }

        public TSCase GetSpecificCase(string matterNo)
        {
            var request = CreateGetHttpWebRequest(TSUrlVerbs.GetApiUrl(TSAPIURL.GETSPECIFICCASE).Replace("@caseNo", matterNo));
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();

            TSCase tSCase = null;

            using (StreamReader streamreader = new StreamReader(stream))
            {
                string result = streamreader.ReadToEnd();
                tSCase = JsonConvert.DeserializeObject<TSCase>(result);
            }

            return tSCase;
        }

        public void GetAllItemOfSpecificCase(string caseId)
        {
            var request = CreateGetHttpWebRequest(TSUrlVerbs.GetApiUrl(TSAPIURL.GETALLITEMSOFSPECIFICCASE).Replace("@caseId", caseId));
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();

            List<TSItem> tSItems = new List<TSItem>();

            using (StreamReader streamreader = new StreamReader(stream))
            {
                string result = streamreader.ReadToEnd();
                tSItems = JsonConvert.DeserializeObject<List<TSItem>>(result);
            }

            //return tSCase;
        }

        public ItemHistory GetItemsHistory()
        {
            var request = CreateGetHttpWebRequest(TSUrlVerbs.GetApiUrl(TSAPIURL.GETITEMHISTORY).Replace("@itemId", "1"));
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();

            ItemHistory itemHistory = null;

            using (StreamReader streamreader = new StreamReader(stream))
            {
                string result = streamreader.ReadToEnd();
                itemHistory = JsonConvert.DeserializeObject<ItemHistory>(result);
            }

            return itemHistory;
        }

        public List<TSOffices> GetOffices()
        {
            var request = CreateGetHttpWebRequest(TSUrlVerbs.GetApiUrl(TSAPIURL.GETOFFICES));
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();

            List<TSOffices> tSOffices = new List<TSOffices>();

            using (StreamReader streamreader = new StreamReader(stream))
            {
                string result = streamreader.ReadToEnd();
                tSOffices = JsonConvert.DeserializeObject<List<TSOffices>>(result, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                });
            }

            return tSOffices;
        }

        public User GetListOfUsers()
        {
            var request = CreateGetHttpWebRequest(TSUrlVerbs.GetApiUrl(TSAPIURL.GETLISTOFUSERS));
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();

            User user = null;

            using (StreamReader streamreader = new StreamReader(stream))
            {
                string result = streamreader.ReadToEnd();
                user = JsonConvert.DeserializeObject<User>(result);
            }

            return user;
        }

        public User GetUserByEmail(string email)
        {
            var request = CreateGetHttpWebRequest(TSUrlVerbs.GetApiUrl(TSAPIURL.GETUSERBYEMAIL).Replace("@email", email));
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();

            User user = null;

            using (StreamReader streamreader = new StreamReader(stream))
            {
                string result = streamreader.ReadToEnd();
                user = JsonConvert.DeserializeObject<User>(result);
            }

            return user;
        }

        public User GetUserByLastName(string lname)
        {
            var request = CreateGetHttpWebRequest(TSUrlVerbs.GetApiUrl(TSAPIURL.GETUSERBYLASTNAME).Replace("@lname", lname));
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();

            User user = null;

            using (StreamReader streamreader = new StreamReader(stream))
            {
                string result = streamreader.ReadToEnd();
                user = JsonConvert.DeserializeObject<User>(result);
            }

            return user;
        }
        public UserValue GetUserById(int userId)
        {
            var request = CreateGetHttpWebRequest(TSUrlVerbs.GetApiUrl(TSAPIURL.GETUSERBYID).Replace("@userId", userId.ToString()));
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();

            UserValue user = null;

            using (StreamReader streamreader = new StreamReader(stream))
            {
                string result = streamreader.ReadToEnd();
                user = JsonConvert.DeserializeObject<UserValue>(result);
            }

            return user;
        }

        public CaseOfficeUser GetCaseOfficerId(string email)
        {
            var request = CreateGetHttpWebRequest(TSUrlVerbs.GetApiUrl(TSAPIURL.GETCASEOFFICERID).Replace("@email", email));
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();

            CaseOfficeUser user = null;

            using (StreamReader streamreader = new StreamReader(stream))
            {
                string result = streamreader.ReadToEnd();
                user = JsonConvert.DeserializeObject<CaseOfficeUser>(result);
            }

            return user;
        }

        public void GetCasesByDate(DateTime fromDt, DateTime toDt)
        {

        }

        public void UpdateDecisionLetterLinkAndOfficeIdInCase(string matterNo, string officeId = "")
        {
            string tsCaseJson = GetSpecificCaseJson(matterNo);
            TSCase tSCase = JsonConvert.DeserializeObject<TSCase>(tsCaseJson);

            var request = CreatePutHttpWebRequest(TSUrlVerbs.GetApiUrl(TSAPIURL.EDITCASE).Replace("@caseNo", tSCase.id), string.IsNullOrEmpty(officeId) ? tSCase.officeId.ToString() : officeId);
            //string requestJson = JsonConvert.SerializeObject(tSCase);

            if (tsCaseJson.Contains("10.102.3.207"))
            {
                tsCaseJson = tsCaseJson.Replace("10.102.3.207", "rcgapp01");

                byte[] bytes;
                bytes = System.Text.Encoding.UTF8.GetBytes(tsCaseJson);
                request.ContentLength = bytes.Length;

                Stream dataStream = request.GetRequestStream();
                dataStream.Write(bytes, 0, bytes.Length);
                dataStream.Close();

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                using (dataStream = response.GetResponseStream())
                {
                    StreamReader streamreader = new StreamReader(dataStream);
                    string result = streamreader.ReadToEnd();
                }

                response.Close();
            }
        }

        public string AddCase(TSCase tSCase, int officeId)
        {
            var request = CreatePostHttpWebRequest(TSUrlVerbs.GetApiUrl(TSAPIURL.ADDCASE), officeId);
            string requestJson = JsonConvert.SerializeObject(tSCase);
            byte[] bytes;
            bytes = System.Text.Encoding.UTF8.GetBytes(requestJson);
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

            response.Close();

            return result;
        }

        #region TrackerSafe DecisionLetter Update Case
        public void UpdateDecisionLetterResponse(TrackerSafeDecisionLetter decisionLetter, string matterNo)
        {
            string tsCaseJson = GetSpecificCaseJson(matterNo);
            var tSCase = JsonConvert.DeserializeObject<TSCaseResponse>(tsCaseJson);
            #region Decision Letter Form Fields Mapping
            if (_appSettings.IsDebug)
            {
                var decisionLetterForm = new DLFormDataDevOutput
                {
                    field5871 = decisionLetter.ReceivedAt,
                    field5873 = decisionLetter.SentAt,
                    field5877 = decisionLetter.RecipientAddress,
                    field5879 = decisionLetter.RecipientCity,
                    field5881 = decisionLetter.RecipientState,
                    field5883 = decisionLetter.RecipientZipCode,
                    field5885 = (decisionLetter.IsInsured ?? false ? 1 : 2).ToString(), // 1 = Yes . 2 = No
                    field5887 = decisionLetter.InsuranceAmount ?? 0,
                    field5889 = decisionLetter.RecipientPhone,
                    field5891 = decisionLetter.RecipientName,
                    field5893 = decisionLetter.RecipientCompany,
                    field5895 = decisionLetter.AuthorizedRepresentative,
                    field8213 = decisionLetter.DecisionOption?.ToString(),
                    field8053 = decisionLetter.RecipientCarrierName
                };

                var DLJson = tSCase.formData.FirstOrDefault(x => x.formId == 15);
                if (DLJson == null)
                {
                    var form = new TSFormDataResponse
                    {
                        active = true,
                        data = JsonConvert.SerializeObject(decisionLetterForm).ToString(),
                        entityId = tSCase.id,
                        formName = "Decision Letter Information",
                        officeId = tSCase.officeId,
                        organizationId = tSCase.organizationId,
                        visibilityId = 0,
                        formId = 15,
                    };
                    tSCase.formData.Add(form);
                }
                else
                {
                    DLJson.data = JsonConvert.SerializeObject(decisionLetterForm).ToString();
                }
            }
            else
            {
                var decisionLetterForm = new DLFormDataProdOutput
                {
                    field2043 = decisionLetter.ReceivedAt,
                    field2041 = decisionLetter.SentAt,
                    field2051 = decisionLetter.RecipientAddress,
                    field2053 = decisionLetter.RecipientCity,
                    field2055 = decisionLetter.RecipientState,
                    field2057 = decisionLetter.RecipientZipCode,
                    field2063 = (decisionLetter.IsInsured ?? false ? 2 : 1).ToString(), // 1 = No . 2 = Yes
                    field2065 = decisionLetter.InsuranceAmount ?? 0,
                    field2059 = decisionLetter.RecipientPhone,
                    field2047 = decisionLetter.RecipientName,
                    field2049 = decisionLetter.RecipientCompany,
                    field2067 = decisionLetter.AuthorizedRepresentative,
                    field2045 = decisionLetter.DecisionOption?.ToString(),
                    field2061 = decisionLetter.RecipientCarrierName
                };

                var DLJson = tSCase.formData.FirstOrDefault(x => x.formId == 16);
                if (DLJson == null)
                {
                    var form = new TSFormDataResponse
                    {
                        active = true,
                        data = JsonConvert.SerializeObject(decisionLetterForm).ToString(),
                        entityId = tSCase.id,
                        formName = "Decision Letter Information",
                        officeId = tSCase.officeId,
                        organizationId = tSCase.organizationId,
                        visibilityId = 0,
                        formId = 16,
                    };
                    tSCase.formData.Add(form);
                }
                else
                {
                    DLJson.data = JsonConvert.SerializeObject(decisionLetterForm).ToString();
                }
            }
            #endregion

            tsCaseJson = JsonConvert.SerializeObject(tSCase);
            var request = CreatePutHttpWebRequest(TSUrlVerbs.GetApiUrl(TSAPIURL.EDITCASE).Replace("@caseNo", tSCase.id.ToString()), tSCase.officeId.ToString());

            byte[] bytes = Encoding.UTF8.GetBytes(tsCaseJson);
            request.ContentLength = bytes.Length;

            Stream dataStream = request.GetRequestStream();
            dataStream.Write(bytes, 0, bytes.Length);
            dataStream.Close();
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using (dataStream = response.GetResponseStream())
                {
                    StreamReader streamreader = new StreamReader(dataStream);
                    string result = streamreader.ReadToEnd();
                }
                response.Close();
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        #endregion 
        #region TrackerSafe DecisionLetter Search Method
        /// <summary>
        /// TrackerSafe DecisionLetter Search Method For Matters within Date Range and billing as enabled
        /// </summary>
        /// <param name="from">Starting Date</param>
        /// <param name="to">Ending Date</param>
        /// <param name="officeId"></param>
        /// <returns></returns>
        public List<TSSearchCaseData> SearchMattersForDecesionLetter(int pageSize = 50, int officeId = 0)
        {
            var tsCaseSearchResponseList = new List<TSSearchCaseData>();
            int resultCount = 0, pageNumber = 1;
            do
            {
                var request = CreatePostHttpWebRequest(TSUrlVerbs.GetApiUrl(TSAPIURL.CASESEARCH), officeId);
                var officeIds = GetOffices().Select(x => x.Id).ToList();

                var searchModel = new TSCaseSearchModel()
                {
                    DynamicFields = new List<TSDynamicField>
                {
                    new TSDynamicField(){
                        formId = 10,
                        fieldType = "dropdown",
                        model = "2",
                        name = "field9459",
                        searchCriteria = 0,
                        searchJustForm = false,
                        type = "selectlist"
                    },
                    new TSDynamicField(){
                        formId = 10,
                        fieldType = "dropdown",
                        model = "1",
                        name = "field7142", //Bill Rate Type
                        searchCriteria = 0,
                        searchJustForm = false,
                        type = "selectlist"
                    }
                },
                    StaticFields = new List<TSStaticField>
                {
                    new TSStaticField()
                    {
                        name = "GENERAL.CREATED_DATE",
                        typeId = 2,
                        fieldName = "CreatedDate",
                        searchCriteriasType = 2,
                        searchCriteria = 6, //  Before
                        model = DateTime.UtcNow.AddDays(1).Date
                    }
                },
                    IsSearchingInSublocations = false,
                    officeIds = officeIds,
                    orderBy = "CreatedDate",
                    orderByAsc = false,
                    PageNumber = pageNumber,
                    PageSize = pageSize
                };
                var tsCaseJson = JsonConvert.SerializeObject(searchModel);
                byte[] bytes = Encoding.UTF8.GetBytes(tsCaseJson);
                request.ContentLength = bytes.Length;
                Stream dataStream = request.GetRequestStream();
                dataStream.Write(bytes, 0, bytes.Length);
                dataStream.Close();
                try
                {
                    string resultString;
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    using (dataStream = response.GetResponseStream())
                    {
                        StreamReader streamreader = new StreamReader(dataStream);
                        resultString = streamreader.ReadToEnd();
                    }
                    response.Close();
                    var result = JsonConvert.DeserializeObject<TSCaseSearchResponse>(resultString);
                    tsCaseSearchResponseList.AddRange(result.data);
                    resultCount = _appSettings.IsDebug || !_appSettings.IsSendingEmailsToClients ? pageSize : result.count;
                    pageNumber++;
                }
                catch (Exception)
                {
                }
            } while (tsCaseSearchResponseList.Count < resultCount);

            return tsCaseSearchResponseList;
        }

        #endregion

        private HttpWebRequest CreatePostHttpWebRequest(string urlVerb, int officeId)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(string.Format("{0}{1}", _appSettings.TrackerApiBaseUrl, urlVerb));

            request.Method = WebRequestMethods.Http.Post;
            request.AllowAutoRedirect = true;
            request.Accept = "application/json";
            request.ContentType = "application/json";
            request.Headers.Add("Authorization", CreateBearerAuthHeader(tSLogin.Token.Trim()));
            request.Headers.Add("OrganizationID", tSLogin.OrganizationId);
            request.Headers.Add("OfficeID", officeId!=0 ? officeId.ToString() : tSLogin.OfficeId);
            request.Headers.Add("StaticToken", "true");

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                                                    | SecurityProtocolType.Tls11
                                                    | SecurityProtocolType.Tls12
                                                    | SecurityProtocolType.Ssl3;

            return request;
        }

        private HttpWebRequest CreatePutHttpWebRequest(string urlVerb, string officeId)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(string.Format("{0}{1}", _appSettings.TrackerApiBaseUrl, urlVerb));

            request.Method = WebRequestMethods.Http.Put;
            request.AllowAutoRedirect = true;
            request.Accept = "application/json";
            request.ContentType = "application/json";
            request.Headers.Add("Authorization", CreateBearerAuthHeader(tSLogin.Token.Trim()));
            request.Headers.Add("OrganizationID", tSLogin.OrganizationId);
            request.Headers.Add("OfficeID", !string.IsNullOrEmpty(officeId) ? officeId.ToString() : tSLogin.OfficeId);
            request.Headers.Add("StaticToken", "true");

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                                                    | SecurityProtocolType.Tls11
                                                    | SecurityProtocolType.Tls12
                                                    | SecurityProtocolType.Ssl3;

            return request;
        }

        private HttpWebRequest CreateGetHttpWebRequest(string urlVerb)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(string.Format("{0}{1}", _appSettings.TrackerApiBaseUrl, urlVerb));

            request.Method = WebRequestMethods.Http.Get;
            request.AllowAutoRedirect = true;
            request.Accept = "application/json";
            request.ContentType = "application/x-www-form-urlencoded";
            request.Headers.Add("Authorization", CreateBearerAuthHeader(tSLogin.Token.Trim()));
            request.Headers.Add("OrganizationID", tSLogin.OrganizationId);
            request.Headers.Add("OfficeID", tSLogin.OfficeId);
            request.Headers.Add("StaticToken", "true");

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
}
