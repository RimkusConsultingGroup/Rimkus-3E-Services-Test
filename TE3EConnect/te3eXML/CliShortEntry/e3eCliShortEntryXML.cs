using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TE3EConnect.te3eXML.CliShortEntry
{
    public static partial class e3eCliShortEntryXML
    {
        public static string ClientSrvXml = @"
<Client_Srv xmlns=""http://elite.com/schemas/transaction/process/write/Client_Srv"">
    <Initialize xmlns=""http://elite.com/schemas/transaction/object/write/Client"">
        @AddClientSrvXml
        @EditClientSrvXml
    </Initialize>
</Client_Srv>
";

        
    }
}
