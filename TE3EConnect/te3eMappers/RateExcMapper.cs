using System.Collections.Generic;
using System.Text;
using TE3EConnect.te3eXML;

namespace TE3EConnect.te3eMappers
{
    internal class RateExcMapper
    {
        public static string ConvertRateExcToXml(e3eRateExc e3ERateExc)
        {
            string rateExcXml = e3ERateExc.isNew
                                ? e3eRateExcXML.AddRateExcXML
                                            .Replace("@Description", e3ERateExc.rateExc.Description[0].Value.ToString())
                                            .Replace("@StartDate", e3ERateExc.rateExc.StartDate)
                                            .Replace("@RateExcList", e3ERateExc.rateExc.RateExcList)
                                : e3eRateExcXML.EditRateExcXML
                                            .Replace("@KeyValue", e3ERateExc.keyValue);
            return rateExcXml;
        }

        public static string ConvertRateExcDetailToXml(List<RateExcDet> rateExcDets)
        {
            StringBuilder sb = new StringBuilder();

            foreach (RateExcDet rateExcDet in rateExcDets)
            {
                string rateExDetailXml = e3eRateExcXML.AddRateExcDetXML
                                          .Replace("@RateOverride", rateExcDet.RateOverride)
                                          .Replace("@StartDate", rateExcDet.Startdate)
                                          .Replace("@Timekeeper", rateExcDet.Timekeeper)
                                          .Replace("@Description", rateExcDet.Description[0].Value);
                                          //.Replace("@BillingTitle_CCC", rateExcDet.BillingTitle_CCC);

                sb.AppendLine(rateExDetailXml);
            }

            return sb.ToString();
        }
    }
}