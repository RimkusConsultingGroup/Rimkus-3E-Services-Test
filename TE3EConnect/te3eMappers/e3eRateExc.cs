using System.Collections.Generic;

namespace TE3EConnect.te3eMappers
{
    public class e3eRateExc
    {
        public bool isNew { get; set; }

        public string keyValue { get; set; }

        public RateExc rateExc { get; set; }

        public List<RateExcDet> rateExcDets { get; set; }

    }
}