using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TE3EEntityFramework.Client.RCGKENTCMS;

namespace TE3EEntityFramework.Data.KenticoCMS._3EProcessItem
{
    public class ExistingMatterClient
    {
        public ExistingMatterClient()
        {
            MatterKenticoRelation = new List<MatterKenticoRel>();
        }
        public string KenticoID { get; set; }
        public int ClientIndex { get; set; }
        public string ClientNumber { get; set; }
        public string ClientName { get; set; }
        public int? MattIndex { get; set; }
        public string MattNumber { get; set; }
        public string MattName { get; set; }

        public List<MatterKenticoRel> MatterKenticoRelation { get; set; }
    }

    public class MatterKenticoRel
    {
        public KenticoSubEntityRelEnum SubEntityType { get; set; }
        public string SubKenticoID { get; set; }
        public string SubEntityKey { get; set; }
    }

}

