using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TE3EEntityFramework.Data.TrackerSafe
{
    public class TSItem
    {
        public bool Active { get; set; }

        public bool Location { get; set; }

        public bool Description { get; set; }

        public bool SubmittedBy { get; set; }

        public bool DateCreated { get; set; }
    }
}
