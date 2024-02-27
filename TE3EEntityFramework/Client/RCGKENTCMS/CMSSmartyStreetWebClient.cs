using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartyStreets;

namespace TE3EEntityFramework.Client.RCGKENTCMS
{
    public class CMSSmartyStreetWebClient
    {
        private SmartyStreets.USZipCodeApi.Client zipClient;
        private SmartyStreets.USReverseGeoApi.Client reverseGeoClient;

        public CMSSmartyStreetWebClient(string authId, string authToken)
        {
            zipClient = new ClientBuilder(authId, authToken).BuildUsZipCodeApiClient();
            reverseGeoClient = new ClientBuilder(authId, authToken).WithLicense(new List<string>() { "us-reverse-geocoding-cloud" }).BuildUsReverseGeoApiClient();
        }

        public string GetCountyName(string city, string state, string zipCode)
        {
            string countyName = "";

            var lookup = new SmartyStreets.USZipCodeApi.Lookup
            {
                City = city,
                State = state,
                ZipCode = zipCode
            };

            try
            {
                zipClient.Send(lookup);
            }
            catch (SmartyException ex)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(ex.Message);
                sb.AppendLine(ex.StackTrace);

                throw new SmartyException(sb.ToString());
            }
            catch (IOException ex)
            {
                throw new SmartyException(ex.StackTrace);
            }

            var result = lookup.Result.ZipCodes;

            if (result != null && result.Count() > 0)
                countyName = result.First().CountyName;

            return countyName;
        }

        public string GetZipCode(string latitude, string longitude)
        {
            string zipCode = "";
            double lat = !string.IsNullOrEmpty(latitude) ? Convert.ToDouble(Convert.ToDouble(latitude).ToString("#.######")) : Convert.ToDouble("0.0");
            double lon = !string.IsNullOrEmpty(longitude) ? Convert.ToDouble(Convert.ToDouble(longitude).ToString("#.######")) : Convert.ToDouble("0.0");

            var lookup = new SmartyStreets.USReverseGeoApi.Lookup(lat, lon);

            try
            {
                reverseGeoClient.Send(lookup);
            }
            catch (SmartyException ex)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(ex.Message);
                sb.AppendLine(ex.StackTrace);

                throw new SmartyException(sb.ToString());
            }
            catch (IOException ex)
            {
                throw new SmartyException(ex.StackTrace);
            }

            var result = lookup.SmartyResponse.Results;

            if (result.Count() > 0)
            {
                zipCode = result.OrderBy(x => x.Distance).First().Address.ZipCode;
            }

            return zipCode;
        }
    }
}
