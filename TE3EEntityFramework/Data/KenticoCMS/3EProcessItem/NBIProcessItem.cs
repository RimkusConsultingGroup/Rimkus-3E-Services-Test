using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TE3EEntityFramework.Data.KenticoCMS._3EProcessItem
{
    public class NBIProcessItem
    {
        public int ClientIndex { get; set; }
        public string ClientNumber { get; set; }
        public int ClientEntity { get; set; }
        public int? MatterIndex { get; set; }
        public string Description { get; set; }
    }
}
