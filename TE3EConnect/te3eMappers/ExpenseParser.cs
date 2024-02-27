using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TE3EConnect.extension;
using TE3EConnect.logs;

namespace TE3EConnect.te3eMappers
{
    public class ExpenseParser
    {
        public Logger logger = new Logger("voucher");

        public RejectedVoucher rejectedvchr = new RejectedVoucher();

        public List<e3eVoucher> e3EVouchers;

        private Dictionary<string, string> glAcctMaskAliasCache;

        private Dictionary<string, List<string>> VchrGroups;

        public ExpenseParser(string[] lines, TE3ETranSvc transSvc)
        {
            VchrGroups = new Dictionary<string, List<string>>();
            e3EVouchers = new List<e3eVoucher>();
            glAcctMaskAliasCache = new Dictionary<string, string>();

            foreach (string line in lines)
            {
                string[] splitLine = line.Split(',');
                if (!VchrGroups.ContainsKey(splitLine[0]))
                    VchrGroups.Add(splitLine[0], new List<string> { line });
                else VchrGroups.Where(x => x.Key == splitLine[0]).First().Value.Add(line);
            }

            foreach (KeyValuePair<string, List<string>> vchrGrp in VchrGroups)
            {
                string firstLine = null;
                e3eVoucher e3EVoucher = new e3eVoucher();
                e3EVoucher.costCards = new List<CostCard>();
                e3EVoucher.vchrDirectGLs = new List<VchrDirectGL>();

                try
                {
                    firstLine = vchrGrp.Value.First();

                    e3EVoucher.voucher = ParseVchr(transSvc, firstLine, vchrGrp);
                    List<CostCard> ccards = new List<CostCard>();
                    List<VchrDirectGL> directGL = new List<VchrDirectGL>();

                    string timeKeeperId = "";
                    string mattIndex = "";
                    int lineNo = 1;
                    vchrGrp.Value.ForEach(x =>
                    {
                        string[] sLine = e3eExtension.LineParser(x);
                        if (sLine[11] == "Y")
                        {
                            try
                            {
                                if (string.IsNullOrEmpty(timeKeeperId))
                                {
                                    try
                                    {
                                        var timekeeper = transSvc.GetTimeKeeperByName(string.Format("{0}, {1}", sLine[3], sLine[2]));

                                        if (timekeeper == null)
                                            throw new Exception(string.Format("{0} - Unable to parse voucher - Timekeeper {1} not found", string.Format("{0} {1}", DateTime.Now.ToString("MMddy"), sLine[3]), sLine[0]));

                                        timeKeeperId = timekeeper.TkprIndex;
                                    }
                                    catch (Exception ex)
                                    {
                                        rejectedvchr.Log(string.Format("{0},{1}", x, ex.Message));
                                        throw ex;
                                    }
                                }

                                try
                                {
                                    //look up matter index - need to test
                                    //use sLine[12]
                                    var projectNum = sLine[12].Replace("/", ".");
                                    var matter = transSvc.GetMatterInfoByNum(Convert.ToInt64(projectNum));

                                    if (matter == null)
                                        throw new Exception(string.Format("{0} - Unable to parse voucher - Matter {1} not found", string.Format("{0} {1}", DateTime.Now.ToString("MMddy"), sLine[3]), projectNum));

                                    mattIndex = matter.MattIndex;
                                }
                                catch (Exception ex)
                                {
                                    rejectedvchr.Log(string.Format("{0},{1}", x, ex.Message));
                                    throw ex;
                                }

                                CostCard ccard = new CostCard();
                                ccard.WorkDate = Convert.ToDateTime(sLine[5]).ToString("yyyy-MM-ddT00:00:00");
                                //ccard.PostDate = vchrCC.TranDate;
                                ccard.CurrDate = e3EVoucher.voucher.TranDate;
                                ccard.Currency = e3EVoucher.voucher.Currency;
                                ccard.Narrative = sLine[18]; //description
                                ccard.WorkAmt = sLine[9]; //amount
                                ccard.WorkRate = ccard.WorkAmt;
                                ccard.WorkQty = "1";
                                ccard.RefAmt = ccard.WorkAmt;
                                ccard.RefRate = ccard.WorkAmt;
                                ccard.OrigAmt = ccard.WorkAmt;
                                ccard.Timekeeper = timeKeeperId;
                                ccard.Language = "1033";  //English
                                ccard.Office = e3EVoucher.voucher.Office;
                                ccard.Matter = mattIndex;

                                //lookup cost type - todo: need to test
                                string[] acctCode = sLine[6].Split('-').Where(a => !string.IsNullOrEmpty(a)).Select(a => a).ToArray();
                                ccard.CostType = e3eExtension.GetCode(e3eArchetype.CostType, string.Format("{0} - {1}", acctCode[1].Trim(), acctCode[2].Trim())).Code;
                                //e3eLookup.GetCostType(sLine[6]);

                                ccards.Add(ccard);

                                e3EVoucher.costCards.Add(ccard);
                            }
                            catch (Exception e)
                            {
                                logger.Error(e);
                            }
                        }
                        else
                        {
                            try
                            {
                                VchrDirectGL dGL = new VchrDirectGL();
                                dGL.CurrDate = e3EVoucher.voucher.TranDate;
                                dGL.Amount = sLine[9];
                                dGL.Office = e3EVoucher.voucher.Office;
                                dGL.Description = new VchrDirectGLDescription[] { new VchrDirectGLDescription { Value = sLine[18] } }; //description
                                dGL.APTranDetailList = "PR"; //detail type
                                dGL.Currency = e3EVoucher.voucher.Currency;
                                dGL.LineNum = lineNo.ToString();
                                dGL.GLAcct = BuildGLAcctIndex(transSvc, sLine); //expense gl account - need to test

                                directGL.Add(dGL);

                                e3EVoucher.vchrDirectGLs.Add(dGL);
                            }
                            catch (Exception e)
                            {
                                logger.Error(e);
                            }

                            lineNo++;
                        }
                    });

                    double totalAmt = 0.0;

                    if (ccards.Count > 0)
                    {
                        e3EVoucher.voucher.Amount = ccards.Sum(x => Convert.ToDouble(x.WorkAmt)).ToString();
                        totalAmt = totalAmt + ccards.Sum(x => Convert.ToDouble(x.WorkAmt));
                        //VoucherWithCostCards.Add(e3EVoucher.voucher, ccards);
                    }

                    if (directGL.Count > 0)
                    {
                        e3EVoucher.voucher.Amount = directGL.Sum(x => Convert.ToDouble(x.Amount)).ToString();
                        totalAmt = totalAmt + directGL.Sum(x => Convert.ToDouble(x.Amount));
                        //VoucherWithDirectGL.Add(vchrDGL, directGL);
                    }

                    if (ccards.Count > 0 || directGL.Count > 0)
                    {
                        e3EVoucher.voucher.Amount = totalAmt.ToString();
                        e3EVouchers.Add(e3EVoucher);
                    }
                }
                catch (Exception ex)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine(firstLine.ToString());
                    sb.AppendLine(ex.Message);
                    logger.Error(new Exception(sb.ToString()));
                }
            }
        }

        private string BuildGLAcctIndex(TE3ETranSvc transSvc, string[] line)
        {
            StringBuilder sb = new StringBuilder();

            //ExpenseType expense = e3eLookup.GetExpenseType(line[6]);
            //string expenseType = expense == null ? "" : expense.glCode.ToString();

            string[] acctCode = line[6].Split('-').Where(x => !string.IsNullOrEmpty(x)).Select(x => x).ToArray();
            string expenseType = acctCode[0].Trim();

            sb.Append(expenseType);
            sb.Append("-");
            sb.Append("10");
            sb.Append("-");
            string[] fn = line[0].Split(' ');
            string name = string.Format("{0}, {1}", fn[1], fn[0]);
            //Employee emp = Concur3eLookup.GetEmployee(name);

            //int deptCode = emp == null ? 0 : emp.deptCode;
            int deptCode = Convert.ToInt32(line[16]);
            sb.Append(deptCode == 0 ? "000" : deptCode.ToString());
            sb.Append("-");

            string practiceGrp = "000";
            if (deptCode == 101)
                practiceGrp = "110";
            else if (deptCode == 102)
                practiceGrp = "130";
            else if (deptCode == 103)
                practiceGrp = "170";
            else if (deptCode == 104)
                practiceGrp = "160";
            else if (deptCode == 121)
                practiceGrp = "150";

            sb.Append(practiceGrp);
            sb.Append("-");
            //State state = Concur3eLookup.GetStateCode(line[17]);
            sb.Append(string.Format("{0}-00000-00000", line[17]));

            string acctIndex = "";
            if (glAcctMaskAliasCache.ContainsKey(sb.ToString()))
                acctIndex = glAcctMaskAliasCache[sb.ToString()];
            else
            {
                GLAcct gLAcct = transSvc.GetGLAcctByMaskedAlias(sb.ToString());
                acctIndex = gLAcct == null ? sb.ToString() : transSvc.GetGLAcctByMaskedAlias(sb.ToString()).AcctIndex;
                glAcctMaskAliasCache.Add(sb.ToString(), acctIndex);
            }

            logger.Info(string.Format("{0} - GLAcctMaskAlias: {1}", name, sb.ToString()));
            return acctIndex;
        }

        private Voucher ParseVchr(TE3ETranSvc transSvc, string line, KeyValuePair<string, List<string>> vchrGrp)
        {
            Voucher vchr = new Voucher();
            var firstLine = e3eExtension.LineParser(line);

            vchr.TranDate = DateTime.Now.ToString("yyyy-MM-ddT00:00:00"); //tran date
            vchr.InvDate = DateTime.Now.ToString("yyyy-MM-ddT00:00:00");
            vchr.InvNum = new VoucherInvNum[] { new VoucherInvNum { Value = string.Format("{0} {1}", DateTime.Now.ToString("MMddy"), firstLine[3]) } };

            //get payee id
            Payee payee = null;

            try
            {
                payee = transSvc.GetPayeeByName(firstLine[0]);

                if (payee == null)
                    throw new Exception(string.Format("{0} - Unable to parse voucher - Payee {1} not found", string.Format("{0} {1}", DateTime.Now.ToString("MMddy"), firstLine[3]), firstLine[0]));
            }
            catch (Exception ex)
            {
                vchrGrp.Value.ForEach(x => rejectedvchr.Log(string.Format("{0},{1}", x, ex.Message)));
                throw ex;
            }

            vchr.Payee = payee.PayeeIndex;
            vchr.PayeeSite = payee.CkSite;

            vchr.CurrDate = DateTime.Now.ToString("yyyy-MM-ddT00:00:00");
            //vchr.Amount = vchrGrp.Value.Sum(x => Convert.ToDouble(x.Split(',')[9])).ToString();
            vchr.DueDate = DateTime.Now.ToString("yyyy-MM-ddT00:00:00");
            vchr.PayDate = DateTime.Now.ToString("yyyy-MM-ddT00:00:00");
            vchr.PostDate = DateTime.Now.ToString("yyyy-MM-ddT00:00:00");
            vchr.TaxDate = DateTime.Now.ToString("yyyy-MM-ddT00:00:00");

            //vchr.ApprovedAmt = vchr.Amount;

            vchr.Currency = payee.Currency;
            vchr.Terms = "UPONREC";
            vchr.APTranType = "INV";
            vchr.Office = "01100"; //Houston
            //vchr.APGLAcct = "21101";
            vchr.APGLAcct = transSvc.GetGLAcctByMaskedAlias("21101-10-000-000-00000-00000-00000").AcctIndex;

            return vchr;
        }
    }
}