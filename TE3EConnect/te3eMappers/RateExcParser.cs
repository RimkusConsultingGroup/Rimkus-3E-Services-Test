using TE3EConnect.extension;
using TE3EConnect.logs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TE3EConnect.te3eMappers
{
    public class RateExcParser
    {
        public Logger logger = new Logger("ratexc");

        public RejectedRateExc rejectedRateExc;

        public List<e3eRateExc> e3ERateExcs;

        private TE3ETranSvc e3EService;

        private Dictionary<string, List<string>> RateExcGroups;

        public RateExcParser(string[] lines, TE3ETranSvc transSvc)
        {
            e3EService = transSvc;
            RateExcGroups = new Dictionary<string, List<string>>();
            rejectedRateExc = new RejectedRateExc();

            foreach (string line in lines)
            {
                string[] splitLine = line.Split(',');
                if (!RateExcGroups.ContainsKey(splitLine[0]))
                    RateExcGroups.Add(splitLine[0], new List<string> { line });
                else RateExcGroups.Where(x => x.Key == splitLine[0]).First().Value.Add(line);
            }

            e3ERateExcs = new List<e3eRateExc>();

            foreach (KeyValuePair<string, List<string>> rateGrp in RateExcGroups)
            {
                e3eRateExc e3ERate = new e3eRateExc();

                try
                {
                    string[] firstLine = e3eExtension.LineParser(rateGrp.Value.First());

                    RateExc existingRateExc = e3EService.GetRateExc(firstLine[0]);
                    e3ERate.isNew = existingRateExc == null;

                    if (!e3ERate.isNew)
                        e3ERate.keyValue = existingRateExc.RateExcID;

                    e3ERate.rateExc = RateExcConvert(firstLine);
                    e3ERate.rateExcDets = new List<RateExcDet>();

                    foreach (string rDet in rateGrp.Value)
                    {
                        try
                        {
                            string[] splitrDet = e3eExtension.LineParser(rDet);
                            RateExcDet rDetail = RateExcDetConvert(splitrDet);
                            e3ERate.rateExcDets.Add(rDetail);
                        }
                        catch (Exception ex)
                        {
                            logger.Error(ex);
                        }
                    }

                    e3ERateExcs.Add(e3ERate);
                }
                catch (Exception e)
                {
                    logger.Error(e);
                }
            }
        }

        private RateExc RateExcConvert(string[] rate)
        {
            RateExc rateExc = new RateExc();
            rateExc.Description = new RateExcDescription[] { new RateExcDescription { Value = rate[0] } };
            rateExc.StartDate = Convert.ToDateTime(rate[4]).ToString("yyyy-MM-ddT00:00:00");
            rateExc.RateExcList = "TIMEKEEPER";

            return rateExc;
        }

        private RateExcDet RateExcDetConvert(string[] rateDet)
        {
            RateExcDet rateExcDet = new RateExcDet();
            rateExcDet.RateOverride = rateDet[3];

            try { rateExcDet.Timekeeper = e3EService.GetTimeKeeperByNum(rateDet[1]).TkprIndex; }
            catch { rateExcDet.Timekeeper = ""; }

            rateExcDet.Startdate = Convert.ToDateTime(rateDet[4]).ToString("yyyy-MM-ddT00:00:00");
            rateExcDet.Description = new RateExcDetDescription[] { new RateExcDetDescription { Value = rateDet[0] } };

            //try { rateExcDet.BillingTitle_CCC = e3EService.GetBillingTitle_CCC(rateDet[2]).Code; }
            //catch { rateExcDet.BillingTitle_CCC = rateDet[2]; }

            return rateExcDet;
        }
    }
}