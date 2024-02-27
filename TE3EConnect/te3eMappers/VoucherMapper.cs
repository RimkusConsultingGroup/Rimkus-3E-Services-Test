using System.Collections.Generic;
using System.Text;
using TE3EConnect.te3eXML;

namespace TE3EConnect.te3eMappers
{
    internal class VoucherMapper
    {
        public static string ConvertVchrToXml(Voucher voucher)
        {
            string vchrXml = e3eVoucherXML.AddVoucherXml
                                          .Replace("@TranDate", voucher.TranDate)
                                          .Replace("@InvDate", voucher.InvDate)
                                          .Replace("@InvNum", voucher.InvNum[0].Value)
                                          .Replace("@PSite", voucher.PayeeSite)
                                          .Replace("@Payee", voucher.Payee)
                                          .Replace("@CurrDate", voucher.CurrDate)
                                          .Replace("@Amount", voucher.Amount)
                                          .Replace("@DueDate", voucher.DueDate)
                                          .Replace("@PayDate", voucher.PayDate)
                                          .Replace("@Office", voucher.Office)
                                          .Replace("@APGLAcct", voucher.APGLAcct)
                                          //.Replace("@PostDate", voucher.PostDate)
                                          //.Replace("@ApprovedAmt", voucher.ApprovedAmt)
                                          .Replace("@Comments", voucher.Comments)
                                          //.Replace("@DetailSumAmount", voucher.Amount)
                                          //.Replace("@PaidAmount", voucher.Amount)
                                          .Replace("@OrigVchrAmt", voucher.Amount)
                                          .Replace("@TaxDate", voucher.TaxDate)
                                          .Replace("@Currency", "USD")
                                          .Replace("@APTranType", voucher.APTranType)
                                          .Replace("@Terms", voucher.Terms);

            return vchrXml;
        }

        public static string ConvertCompleteVchrToXml(Voucher voucher, int glCount, int ccardCount)
        {
            string vchrXml = e3eVoucherXML.AddCompleteVoucherXml
                                          .Replace("@TranDate", voucher.TranDate)
                                          .Replace("@InvDate", voucher.InvDate)
                                          .Replace("@InvNum", voucher.InvNum[0].Value)
                                          .Replace("@PSite", voucher.PayeeSite)
                                          .Replace("@Payee", voucher.Payee)
                                          .Replace("@CurrDate", voucher.CurrDate)
                                          .Replace("@Amount", voucher.Amount)
                                          .Replace("@DueDate", voucher.DueDate)
                                          .Replace("@PayDate", voucher.PayDate)
                                          .Replace("@Office", voucher.Office)
                                          .Replace("@APGLAcct", voucher.APGLAcct)
                                          //.Replace("@PostDate", voucher.PostDate)
                                          //.Replace("@ApprovedAmt", voucher.ApprovedAmt)
                                          .Replace("@Comments", string.IsNullOrEmpty(voucher.Comments) ? "" : voucher.Comments.Replace("&", "-"))
                                          //.Replace("@DetailSumAmount", voucher.Amount)
                                          //.Replace("@PaidAmount", voucher.Amount)
                                          .Replace("@OrigVDGLCount", glCount.ToString())
                                          .Replace("@OrigCostCardCount", ccardCount.ToString())
                                          .Replace("@OrigVchrAmt", voucher.Amount)
                                          .Replace("@TaxDate", voucher.TaxDate)
                                          .Replace("@Currency", "USD")
                                          .Replace("@APTranType", voucher.APTranType)
                                          .Replace("@Terms", voucher.Terms);

            return vchrXml;
        }

        public static string ConvertVchrCostToXml(List<CostCard> costCards)
        {
            string openTagXml = @"<VchrCost>";
            string closeTagXml = @"</VchrCost>";
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(openTagXml);

            foreach (CostCard costCard in costCards)
            {
                string vchrCostXml = e3eVoucherXML.AddVrchCost
                                              .Replace("@WorkDate", costCard.WorkDate)
                                              //.Replace("@PostDate", costCard.PostDate)
                                              .Replace("@CurrDate", costCard.CurrDate)
                                              .Replace("@MatterIndex", costCard.Matter)
                                              .Replace("@Timekeeper", costCard.Timekeeper)
                                              .Replace("@OrigAmt", costCard.WorkAmt)
                                              .Replace("@WorkQty", costCard.WorkQty)
                                              .Replace("@WorkRate", costCard.WorkRate)
                                              .Replace("@WorkAmt", costCard.WorkAmt)
                                              .Replace("@StdRate", costCard.StdRate)
                                              .Replace("@StdAmt", costCard.StdAmt)
                                              .Replace("@Narrative", string.IsNullOrEmpty(costCard.Narrative) ? "" : costCard.Narrative.Replace("&", "-"))
                                              .Replace("@CostType", costCard.CostType)
                                              .Replace("@RefRate", costCard.RefRate)
                                              .Replace("@RefAmt", costCard.RefAmt)
                                              .Replace("@Language", costCard.Language)
                                              .Replace("@Office", costCard.Office)
                                              .Replace("@Currency", "USD");
                sb.AppendLine(vchrCostXml);
            }

            sb.AppendLine(closeTagXml);

            return sb.ToString();
        }

        public static string ConvertVchrDirectGLToXml(List<VchrDirectGL> vchrDirectGLs)
        {
            string openTagXml = @"<VchrDirectGL>";
            string closeTagXml = @"</VchrDirectGL>";
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(openTagXml);

            foreach (VchrDirectGL vchrDirectGL in vchrDirectGLs)
            {
                string vchrDirectGLXml = e3eVoucherXML.AddVcrhDirectGL
                                                      .Replace("@GLAcct", vchrDirectGL.GLAcct)
                                                      .Replace("@CurrDate", vchrDirectGL.CurrDate)
                                                      .Replace("@Amount", vchrDirectGL.Amount)
                                                      .Replace("@Office", vchrDirectGL.Office)
                                                      .Replace("@LineNumber", vchrDirectGL.LineNum)
                                                      //.Replace("@PostDate", vchrDirectGL.PostDate)
                                                      .Replace("@Description", string.IsNullOrEmpty(vchrDirectGL.Description[0].Value) ? "" : vchrDirectGL.Description[0].Value.Replace("&", "-"))
                                                      .Replace("@APTranDetailList", vchrDirectGL.APTranDetailList)
                                                      .Replace("@GLDate", vchrDirectGL.CurrDate)
                                                      .Replace("@ApprovedDate", vchrDirectGL.CurrDate)
                                                      .Replace("@Currency", "USD");
                sb.AppendLine(vchrDirectGLXml);
            }

            sb.AppendLine(closeTagXml);

            return sb.ToString();
        }

        public static string ConvertVchr1099ToXml(Vchr1099 vchr1099)
        {
            string vchr1099Xml = e3eVoucherXML.AddVchr1099
                                              .Replace("@Flag1099", vchr1099.Flag1099)
                                              .Replace("@Amount", vchr1099.Amount);
            return vchr1099Xml;
        }
    }
}