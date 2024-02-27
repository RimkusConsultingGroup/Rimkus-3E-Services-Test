using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TE3EEntityFramework.Data.LibertyMutual
{
    // ErrorResponseModel errorResponseModel = JsonConvert.DeserializeObject<ErrorResponseModel>(myJsonResponse); 
    public class ErrorResponseModel
    {
        public string Level { get; set; }
        public string Category { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
    }
}
