using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TE3EConnect.te3eXML;

namespace TE3EConnect.te3eMappers
{
    internal class GJMapper
    {
        public static string ConvertGJToXml(e3eGJ e3EGJ)
        {
            double totalDebit = e3EGJ.gJDetails.Sum(x => Convert.ToDouble(x.OrigDR));
            double totalCredit = e3EGJ.gJDetails.Sum(x => Convert.ToDouble(x.OrigCR));

            string gjXml = e3eGJXML.AddGJXml
                                          .Replace("@TranDate", e3EGJ.gJ.TranDate)
                                          .Replace("@GLType", e3EGJ.gJ.GLType)
                                          .Replace("@PostDate", e3EGJ.gJ.PostDate)
                                          .Replace("@Description", e3EGJ.gJ.Description)
                                          .Replace("@Unit", e3EGJ.gJ.NxUnit)
                                          .Replace("@IsCalcForEx", e3EGJ.gJ.IsCalcForEx)
                                          .Replace("@CurrDate", e3EGJ.gJ.CurrDate)
                                          .Replace("@IsReversed", e3EGJ.gJ.IsAutoReversed)
                                          .Replace("@GJTranNum", e3EGJ.gJ.GJTranNum)
                                          .Replace("@Category", e3EGJ.gJ.Category)
                                          .Replace("@CurrDate", e3EGJ.gJ.CurrDate)
                                          .Replace("@Currency", e3EGJ.gJ.Currency)
                                          .Replace("@TotalTranDebit", totalDebit.ToString())
                                          .Replace("@TotalTranCredit", totalCredit.ToString())
                                          .Replace("@ReverseTo", e3EGJ.gJ.ReverseTo)
                                          .Replace("@IsAllowIntercompanyGJ", e3EGJ.gJ.IsAllowIntercompanyGJ);

            return gjXml;
        }

        public static string ConvertGJDetailToXml(List<GJDetail> gJDetails)
        {
            StringBuilder sb = new StringBuilder();

            foreach (GJDetail gJDetail in gJDetails)
            {
                string gjDetailXml = e3eGJXML.AddGJDetail
                                          .Replace("@LineNum", gJDetail.LineNum)
                                          .Replace("@GLAcct", gJDetail.GLAcct)
                                          .Replace("@OrigDR", gJDetail.OrigDR)
                                          .Replace("@OrigCR", gJDetail.OrigCR)
                                          .Replace("@Description", gJDetail.Description)
                                          .Replace("@CurrDate", gJDetail.CurrDate)
                                          .Replace("@IsDebit", gJDetail.IsDebit);

                sb.AppendLine(gjDetailXml);
            }

            return sb.ToString();
        }
    }
}