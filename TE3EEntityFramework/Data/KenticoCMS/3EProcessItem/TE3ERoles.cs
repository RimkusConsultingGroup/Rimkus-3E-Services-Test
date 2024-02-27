using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TE3EEntityFramework.Data.KenticoCMS._3EProcessItem
{
    public class TE3ERoles
    {
        public string Role { get; set; }
        public string Description { get; set; }
    }

    public enum TE3ERoleType
    {
        AdditionalParties,
        MatterPayorDetail
    }
}
