using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TE3EEntityFramework.Data.TrackerSafe
{
    class TSUrlVerbs
    {
        public static string GetApiUrl(TSAPIURL tSAPIURL)
        {
            string urlPart = "";

            switch (tSAPIURL)
            {
                case TSAPIURL.ADDCASE:
                    urlPart = "/api/cases";
                    break;
                case TSAPIURL.EDITCASE:
                    urlPart = "/api/cases/@caseNo";
                    break;
                case TSAPIURL.CASESEARCH:
                    urlPart = "/api/cases/search";
                    break;
                case TSAPIURL.CUSTOMSEARCH:
                    urlPart = "/api/items/search";
                    break;
                case TSAPIURL.GETITEMHISTORY:
                    urlPart = "/api/items/seqOrgItemHistoryId/@itemId";
                    break;
                case TSAPIURL.GETCASEOFFICERID:
                    urlPart = "/api/users/typeahead?search=@email";
                    break;
                case TSAPIURL.GETSPECIFICCASE:
                    urlPart = "/api/cases/getByNumber?value=@caseNo";
                    break;
                case TSAPIURL.GETOFFENSETYPEID:
                    urlPart = "/api/offensetypes?belongToOrganization=false";
                    break;
                case TSAPIURL.GETUSERBYEMAIL:
                    urlPart = "/odata/users/?$orderby=Id%20desc&&$filter=contains(Email,%27@email%27)";
                    break;
                case TSAPIURL.GETUSERBYLASTNAME:
                    urlPart = "/odata/users/?$orderby=Id%20desc&&$filter=contains(LastName,%27@lname%27)";
                    break; 
                case TSAPIURL.GETUSERBYID:
                    urlPart = "/api/users/@userId";
                    break;
                case TSAPIURL.GETLISTOFUSERS:
                    urlPart = "/odata/users/?$orderby=Id%20desc";
                    break;
                case TSAPIURL.GETSPECIFICITEM:
                    urlPart = "/api/items/@itemId";
                    break;
                case TSAPIURL.GETALLITEMSOFSPECIFICCASE:
                    urlPart = "/api/cases/@caseId/items";
                    break;
                case TSAPIURL.GETOFFICES:
                    urlPart = "/api/offices";
                    break;
                default:
                    break;
            }

            return urlPart;
        }
    }

    public enum TSAPIURL
    {
        ADDCASE,
        EDITCASE,
        CUSTOMSEARCH,
        GETOFFICES,
        GETITEMHISTORY,
        GETCASEOFFICERID,
        GETOFFENSETYPEID,
        GETUSERBYEMAIL,
        GETUSERBYLASTNAME,
        GETUSERBYID,
        GETLISTOFUSERS,
        GETSPECIFICCASE,
        GETSPECIFICITEM,
        GETALLITEMSOFSPECIFICCASE,
        CASESEARCH
    }
}
