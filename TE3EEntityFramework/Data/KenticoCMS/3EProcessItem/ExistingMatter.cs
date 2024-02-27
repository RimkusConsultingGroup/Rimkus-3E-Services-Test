using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TE3EEntityFramework.Data.KenticoCMS._3EProcessItem
{
    public class ExistingMatter
    {
        public int MattIndex { get; set; }
        public string MattNumber { get; set; }
        public string MattName { get; set; }
        public string LastProcItemID { get; set; }
        public string OrigProcItemID { get; set; }
    }
}
