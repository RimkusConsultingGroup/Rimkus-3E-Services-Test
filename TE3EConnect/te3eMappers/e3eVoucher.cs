using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TE3EConnect.te3eMappers
{
    public class e3eVoucher
    {
        public Voucher voucher { get; set; }

        public List<VchrDirectGL> vchrDirectGLs { get; set; }

        public List<CostCard> costCards { get; set; }

        public Vchr1099 vchr1099 { get; set; }
    }
}
