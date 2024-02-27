using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TE3EEntityFramework.Data.Te3e.CMS.CMS.Definition;
using TE3EEntityFramework.Data.Te3e.CMS.Definition;

namespace TE3EEntityFramework.Data.KenticoCMS
{

    public class NewAssignmentDocument
    {
        [JsonProperty(PropertyName = "objectType", NullValueHandling = NullValueHandling.Ignore)]
        public string objectType { get; set; }

        [JsonProperty(PropertyName = "kenticoId", NullValueHandling = NullValueHandling.Ignore)]
        public string kenticoId { get; set; }

        [JsonProperty(PropertyName = "e3EId", NullValueHandling = NullValueHandling.Ignore)]
        public int? e3EId { get; set; }

        [JsonProperty(PropertyName = "item")]
        public Assignment item { get; set; }
    }
    public class PatchAssignmentDocument
    {
        [JsonProperty(PropertyName = "objectType", NullValueHandling = NullValueHandling.Ignore)]
        public string objectType { get; set; }

        [JsonProperty(PropertyName = "e3EId", NullValueHandling = NullValueHandling.Ignore)]
        public int e3EId { get; set; }

        [JsonProperty(PropertyName = "kenticoId", NullValueHandling = NullValueHandling.Ignore)]
        public string kenticoId { get; set; }

        [JsonProperty(PropertyName = "patch")]
        public Patch[] patch { get; set; }
    }


    public class NewCustomerDocument
    {
        [JsonProperty(PropertyName = "objectType", NullValueHandling = NullValueHandling.Ignore)]
        public string objectType { get; set; }

        [JsonProperty(PropertyName = "kenticoId", NullValueHandling = NullValueHandling.Ignore)]
        public string kenticoId { get; set; }

        [JsonProperty(PropertyName = "item")]
        public CustomerProfile item { get; set; }
    }

    public class PatchCustomerDocument
    {
        [JsonProperty(PropertyName = "objectType", NullValueHandling = NullValueHandling.Ignore)]
        public string objectType { get; set; }

        [JsonProperty(PropertyName = "kenticoId", NullValueHandling = NullValueHandling.Ignore)]
        public string kenticoId { get; set; }

        [JsonProperty(PropertyName = "patch")]
        public Patch[] patch { get; set; }
    }





    //public class PatchInCustomerDocument
    //{
    //    [JsonProperty(PropertyName = "objectType", NullValueHandling = NullValueHandling.Ignore)]
    //    public string objectType { get; set; }

    //    [JsonProperty(PropertyName = "kenticoId", NullValueHandling = NullValueHandling.Ignore)]
    //    public string kenticoId { get; set; }

    //    [JsonProperty(PropertyName = "companyType", NullValueHandling = NullValueHandling.Ignore)]
    //    public string companyType { get; set; }

    //    [JsonProperty(PropertyName = "patch")]
    //    public Patch[] patch { get; set; }
    //}

    public class Patch
    {
        public string op { get; set; }
        public string path { get; set; }
        public object value { get; set; }
    }
}
