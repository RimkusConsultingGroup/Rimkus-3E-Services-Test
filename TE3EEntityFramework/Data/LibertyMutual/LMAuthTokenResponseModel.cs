﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TE3EEntityFramework.Data.LibertyMutual
{
    // AuthTokenViewModel myDeserializedClass = JsonConvert.DeserializeObject<AuthTokenViewModel>(myJsonResponse); 
    public class LMAuthTokenResponseModel
    {
        public string access_token { get; set; }
        public int expires_in { get; set; }
        public string token_type { get; set; }
    }
}
