using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TE3EEntityFramework.Client
{
    public class KenticoWebClient
    {
        string BaseURL { get; set; }
        string APIKey { get; set; }
        string AssignmentProcessUrl = @"processed/{KenticoID}?e3eid={e3eId}&matterNumber={MatterNumber}&matterStatus={MatterStatus}&emails={OfficeEmails}";
        string AssignmentDetailsUrl = @"/assignment/{KenticoID}";
        public KenticoWebClient(string baseUrl, string apiKey)
        {
            BaseURL = baseUrl;
            APIKey = apiKey;
        }

        public async Task<string> MarkAssignmentProcessed(string kenticoId, int e3eId, string matterNumber, string matterStatus, string officeEmails)
        {
            matterStatus = "Pending";
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(BaseURL);
            httpClient.DefaultRequestHeaders.Add("secret-key", APIKey);
            try
            {
                var response = await httpClient.GetAsync(AssignmentProcessUrl
                    .Replace("{KenticoID}", kenticoId)
                    .Replace("{e3eId}", e3eId.ToString())
                    .Replace("{MatterNumber}", matterNumber)
                    .Replace("{MatterStatus}", matterStatus)
                    .Replace("{OfficeEmails}", officeEmails)
                );
                var jsonResponse = await response.Content.ReadAsStringAsync();
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return $"Status Code=({response.StatusCode}), Responce= ({jsonResponse})";
                }
                else
                {
                    return $"Kentico API Failed: Status Code=({response.StatusCode}), Responce= ({jsonResponse})";
                }
            }
            catch (Exception ex)
            {
                return $"Kentico API Exception:{Environment.NewLine}{ex}{Environment.NewLine}Inner Exception:{Environment.NewLine}{ex.InnerException}";
            }
        }
    }
}
