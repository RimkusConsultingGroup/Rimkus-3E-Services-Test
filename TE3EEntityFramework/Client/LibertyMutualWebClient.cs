using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TE3EEntityFramework.Data.LibertyMutual;
using TE3EEntityFramework.Setting;

namespace TE3EEntityFramework.Client
{
    public class LibertyMutualWebClient
    {
        private LibertyMutualAppSetting _appSettings;
        private readonly string APIVersion = "v03_03/";
        private readonly string GetBearerTokenURL = "authentication/token/";
        private readonly string GetClaimSummaryURL;
        private readonly string GetClaimDetailURL;
        private readonly string GetAssignmentURL;
        private readonly string AddClaimJournalURL;

        public LibertyMutualWebClient(LibertyMutualAppSetting appSettings)
        {
            _appSettings = appSettings;
            GetClaimSummaryURL = APIVersion + "claims/{claimID}";
            GetClaimDetailURL = APIVersion + "claims/{claimID}/details";
            GetAssignmentURL = APIVersion + "claims/{claimID}/assignments/{assignmentID}";
            AddClaimJournalURL = APIVersion + "claims/{claimID}/journal-entries";
        }

        private async Task<string> GetAuthHeaderToken()
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(_appSettings.LibertyMutualAPIUrl);
            httpClient.DefaultRequestHeaders.Add("Authorization", _appSettings.LibertyMutualAPIToken);
            var model = new Dictionary<string, string> {
                {"grant_type","client_credentials" }
            };
            try
            {
                var response = await httpClient.PostAsync(GetBearerTokenURL, new FormUrlEncodedContent(model));
                var jsonResponse = await response.Content.ReadAsStringAsync();
                LMAuthTokenResponseModel tokenVM = JsonConvert.DeserializeObject<LMAuthTokenResponseModel>(jsonResponse);
                return tokenVM.access_token;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<LM_Claims> GetLMCLaim(string ClaimUniqueId)
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(_appSettings.LibertyMutualAPIUrl);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await GetAuthHeaderToken());
            try
            {
                var response = await httpClient.GetAsync(GetClaimSummaryURL.Replace("{claimID}", ClaimUniqueId));
                var jsonResponse = await response.Content.ReadAsStringAsync();
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var model = JsonConvert.DeserializeObject<LM_Claims>(jsonResponse);
                    return model;
                }
                else
                {
                    ErrorResponseModel errorResponseModel = JsonConvert.DeserializeObject<ErrorResponseModel>(jsonResponse);
                    throw new Exception($"{errorResponseModel.Name} : {errorResponseModel.Message}");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<LM_Assignment> GetLMAssignment(string ClaimUniqueId, string AssignmentID)
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri(_appSettings.LibertyMutualAPIUrl)
            };
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await GetAuthHeaderToken());
            try
            {
                var response = await httpClient.GetAsync(GetAssignmentURL.Replace("{claimID}", ClaimUniqueId).Replace("{assignmentID}", AssignmentID));
                var jsonResponse = await response.Content.ReadAsStringAsync();
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var model = JsonConvert.DeserializeObject<LM_Assignment>(jsonResponse);
                    return model;
                }
                else
                {
                    ErrorResponseModel errorResponseModel = JsonConvert.DeserializeObject<ErrorResponseModel>(jsonResponse);
                    throw new Exception($"{errorResponseModel.Name} : {errorResponseModel.Message}");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> AddLMClaimJournal(string ClaimUniqueId)
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri(_appSettings.LibertyMutualAPIUrl)
            };
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await GetAuthHeaderToken());

            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));//ACCEPT header
            httpClient.DefaultRequestHeaders.Add("From-User-ID-Specification", "{ \"UserID\": \"" + _appSettings.LibertyMutualJournalUserId + "\", \"UserIDType\": \"" + _appSettings.LibertyMutualJournalUserIdType + "\" }");

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, AddClaimJournalURL.Replace("{claimID}", ClaimUniqueId));
            request.Content = new StringContent("{\"Entry\":\"Accepted Assignment\",\"NotifyParticipants\":false,\"IntendedForInsured\":false}", Encoding.UTF8, "application/json");//CONTENT-TYPE header



            //httpClient.DefaultRequestHeaders
            //      .Accept
            //      .Add(new MediaTypeWithQualityHeaderValue("application/json"));//ACCEPT header
            ////httpClient.DefaultRequestHeaders.Add("Content-Type", "application/json");
            //httpClient.DefaultRequestHeaders.Add("From-User-ID-Specification", "{ \"UserID\": \"" + _appSettings.LibertyMutualJournalUserId + "\", \"UserIDType\": \"" + _appSettings.LibertyMutualJournalUserIdType + "\" }");
            try
            {
                var response = await httpClient.SendAsync(request);
                var jsonResponse = await response.Content.ReadAsStringAsync();
                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    return true;
                }
                else
                {
                    ErrorResponseModel errorResponseModel = JsonConvert.DeserializeObject<ErrorResponseModel>(jsonResponse);
                    throw new Exception($"{errorResponseModel.Name} : {errorResponseModel.Message}");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
