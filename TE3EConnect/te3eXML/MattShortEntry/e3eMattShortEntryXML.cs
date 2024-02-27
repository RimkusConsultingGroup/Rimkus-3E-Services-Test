using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TE3EConnect.te3eXML.MattShortEntry
{
    public static partial class e3eMattShortEntryXML
    {
        public static string MatterSrvXml = @"
<Matter_Srv xmlns=""http://elite.com/schemas/transaction/process/write/Matter_Srv"">
    <Initialize xmlns=""http://elite.com/schemas/transaction/object/write/Matter"">
        @AddMatterSrvXml
        @EditMatterSrvXml
    </Initialize>
</Matter_Srv>
";
    }
}
