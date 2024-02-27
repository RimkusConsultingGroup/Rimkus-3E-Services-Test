using TE3EConnect.extension;
using TE3EConnect.logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TE3EConnect.te3eMappers
{
    public class CreditCardParser
    {
        public Logger logger = new Logger("creditcardvoucher");

        public RejectedVoucher rejectedvchr = new RejectedVoucher();

        public List<e3eVoucher> e3EVouchers;

        private Dictionary<string, string> glAcctMaskAliasCache;

        private Dictionary<string, List<string>> VchrGroups;

        public CreditCardParser(string[] lines, TE3ETranSvc transSvc)
        {
            VchrGroups = new Dictionary<string, List<string>>();
            e3EVouchers = new List<e3eVoucher>();
            glAcctMaskAliasCache = new Dictionary<string, string>();
            string[] invNumLine = lines.Take(1).FirstOrDefault().Split(',').ElementAt(13).Split('-');

            lines = lines.Skip(4).ToArray();
            foreach (string line in lines)
            {
                string[] splitLine = e3eExtension.LineParser(line);

                if (!string.IsNullOrEmpty(splitLine[17]))
                {
                    if (!VchrGroups.ContainsKey(splitLine[17]))
                        VchrGroups.Add(splitLine[17], new List<string> { line });
                    else VchrGroups.Where(x => x.Key == splitLine[17]).First().Value.Add(line);
                }
            }

            VchrGroups = VchrGroups.OrderBy(x => x.Key).ToDictionary(v => v.Key, v => v.Value);

            foreach (KeyValuePair<string, List<string>> vchrGrp in VchrGroups)
            {
                string firstLine = null;
                e3eVoucher e3EVoucher = new e3eVoucher();
                e3EVoucher.costCards = new List<CostCard>();
                e3EVoucher.vchrDirectGLs = new List<VchrDirectGL>();

                string invNum = string.Format("{0} - {1} - {2}", invNumLine[0].Trim(), invNumLine[1].Trim(), vchrGrp.Key);

                try
                {
                    firstLine = vchrGrp.Value.First();
                    e3EVoucher.voucher = ParseVchr(transSvc, firstLine, invNum);
                    List<CostCard> ccards = new List<CostCard>();
                    List<VchrDirectGL> directGL = new List<VchrDirectGL>();


                    string timeKeeperId = "";
                    string mattIndex = "";
                    int lineNo = 1;
                    int index = 1;
                    vchrGrp.Value.ForEach(x =>
                    {
                        string[] sLine = e3eExtension.LineParser(x);
                        if (sLine[8].ToLower() == "b") //check for billable or nonbillable
                        {
                            try
                            {
                                Timekeeper timekeeper = null;

                                try
                                {
                                    timekeeper = transSvc.GetTimeKeeperByName(sLine[5].Trim()); //timekpr

                                    if (timekeeper == null)
                                    {
                                        timeKeeperId = "0";
                                        throw new Exception(string.Format("{0} - Unable to parse voucher - Timekeeper {1} not found", string.Format("{0} {1}", DateTime.Now.ToString("MMddy"), sLine[3]), sLine[5]));
                                    }

                                    timeKeeperId = timekeeper.TkprIndex;
                                }
                                catch (Exception ex)
                                {
                                    rejectedvchr.Log(string.Format("{0},{1}", x, ex.Message));
                                    logger.Error(ex);
                                }

                                try
                                {
                                    //look up matter index - need to test
                                    var projectNum = sLine[4].Trim().Replace("/", ".");
                                    var matter = transSvc.GetMatterInfoByNum(Convert.ToInt64(projectNum));

                                    if (matter == null)
                                    {
                                        mattIndex = "0";
                                        throw new Exception(string.Format("{0} - Unable to parse voucher - Matter {1} not found", string.Format("{0} {1}", DateTime.Now.ToString("MMddy"), sLine[3]), projectNum));

                                    }

                                    mattIndex = matter.MattIndex;
                                }
                                catch (Exception ex)
                                {
                                    rejectedvchr.Log(string.Format("{0},{1}", x, ex.Message));
                                    logger.Error(ex);
                                }

                                var tkprName = timekeeper == null ? sLine[5].Trim() : timekeeper.BillName;
                                logger.Info($"{index}: TimeKeeper Name: {tkprName}, timekeeper id: {timeKeeperId}");

                                string[] acctCode = sLine[7].Split('-').Where(a => !string.IsNullOrEmpty(a)).Select(a => a).ToArray();
                                CostCard ccard = new CostCard();
                                ccard.WorkDate = Convert.ToDateTime(sLine[1].Trim()).ToString("yyyy-MM-ddT00:00:00");
                                //ccard.PostDate = vchrCC.TranDate;
                                ccard.CurrDate = e3EVoucher.voucher.TranDate;
                                ccard.Currency = e3EVoucher.voucher.Currency;
                                ccard.Narrative = sLine[2].Trim(); //description
                                ccard.WorkAmt = sLine[14].Replace("(", "-").Replace(")", "").Trim(); //amount
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
                                //CostType costType = Concur3eLookup.GetCostType(sLine[6]);

                                ccard.CostType = e3eExtension.GetCode(e3eArchetype.CostType, string.Format("{0} - {1}", acctCode[1].Trim(), acctCode[2].Trim())).Code;
                                ccards.Add(ccard);

                                e3EVoucher.costCards.Add(ccard);
                            }
                            catch (Exception e)
                            {
                                logger.Error(e);
                            }
                        }
                        else if (sLine[8].ToLower() == "n")
                        {
                            try
                            {
                                VchrDirectGL dGL = new VchrDirectGL();
                                dGL.CurrDate = e3EVoucher.voucher.TranDate;
                                dGL.Amount = sLine[14].Replace("(","-").Replace(")","").Trim(); //total
                                dGL.Office = e3EVoucher.voucher.Office;
                                dGL.Description = new VchrDirectGLDescription[] { new VchrDirectGLDescription { Value = sLine[2].Trim() } }; //description
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

                        index++;
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
                    if (!string.IsNullOrEmpty(firstLine))
                        sb.AppendLine(firstLine.ToString());

                    sb.AppendLine(ex.Message);
                    logger.Error(new Exception(sb.ToString()));
                }
            }

        }

        private string BuildGLAcctIndex(TE3ETranSvc transSvc, string[] line)
        {
            StringBuilder sb = new StringBuilder();

            //ExpenseType expense = Concur3eLookup.GetExpenseType(line[6]);
            string[] acctCode = line[7].Split('-').Where(x => !string.IsNullOrEmpty(x)).Select(x => x).ToArray();
            string expenseType = acctCode[0].Trim();

            sb.Append(expenseType);
            sb.Append("-");
            sb.Append("10");
            sb.Append("-");
            //string[] fn = line[0].Split(' ');
            //string name = string.Format("{0}, {1}", fn[1], fn[0]);
            //Employee emp = Concur3eLookup.GetEmployee(name);

            //int deptCode = emp == null ? 0 : emp.deptCode;
            int deptCode = Convert.ToInt32(line[9].Split('-')[0].Trim()); //deptclass
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
            string[] stateCode = line[6].Split('-').Where(a => !string.IsNullOrEmpty(a)).Select(a => a).ToArray();
            sb.Append(string.Format("{0}-00000-00000", stateCode[0].Trim()));

            string acctIndex = "";
            if (glAcctMaskAliasCache.ContainsKey(sb.ToString()))
                acctIndex = glAcctMaskAliasCache[sb.ToString()];
            else
            {
                GLAcct gLAcct = transSvc.GetGLAcctByMaskedAlias(sb.ToString());
                acctIndex = gLAcct == null ? sb.ToString() : transSvc.GetGLAcctByMaskedAlias(sb.ToString()).AcctIndex;
                glAcctMaskAliasCache.Add(sb.ToString(), acctIndex);
            }

            logger.Info(string.Format("GLAcctMaskAlias: {0}", sb.ToString()));
            return acctIndex;
        }

        private Voucher ParseVchr(TE3ETranSvc transSvc, string line, string invNum)
        {
            Voucher vchr = new Voucher();
            var firstLine = e3eExtension.LineParser(line);

            vchr.TranDate = DateTime.Now.ToString("yyyy-MM-ddT00:00:00"); //tran date
            vchr.InvDate = DateTime.Now.ToString("yyyy-MM-ddT00:00:00");
            vchr.InvNum = new VoucherInvNum[] { new VoucherInvNum { Value = invNum } };

            //get payee id
            Payee payee = null;
            string ccPayeeName = (transSvc._e3EServer == e3eServerEnv.DEV || transSvc._e3EServer == e3eServerEnv.UAT) ? "Compass Bank Credit Card" : "BBVA USA - Credit Card";

            try
            {
                payee = transSvc.GetPayeeByName(ccPayeeName);

                if (payee == null)
                    throw new Exception(string.Format("{0} - Unable to parse voucher - Payee {1} not found", string.Format("{0} {1}", DateTime.Now.ToString("MMddy"), "Compass Bank Credit Card"), "Compass Bank Credit Card"));
            }
            catch (Exception ex)
            {
                rejectedvchr.Log(string.Format("{0},{1}", line[2], ex.Message));
                throw ex;
            }

            vchr.Payee = payee.PayeeIndex;
            vchr.PayeeSite = payee.CkSite;

            //vchr.Payee = "1384"; //BBVA USA CC
            //vchr.PayeeSite = "01384";

            vchr.CurrDate = DateTime.Now.ToString("yyyy-MM-ddT00:00:00");
            //vchr.Amount = vchrGrp.Value.Sum(x => Convert.ToDouble(x.Split(',')[9])).ToString();
            vchr.DueDate = DateTime.Now.ToString("yyyy-MM-ddT00:00:00");
            vchr.PayDate = DateTime.Now.ToString("yyyy-MM-ddT00:00:00");
            vchr.PostDate = DateTime.Now.ToString("yyyy-MM-ddT00:00:00");
            vchr.TaxDate = DateTime.Now.ToString("yyyy-MM-ddT00:00:00");

            //vchr.ApprovedAmt = vchr.Amount;

            vchr.Currency = "USD";
            vchr.Terms = "UPONREC";
            vchr.APTranType = "INV";
            vchr.Office = "01100"; //Houston
            //vchr.APGLAcct = "21101";
            vchr.APGLAcct = transSvc.GetGLAcctByMaskedAlias("21101-10-000-000-00000-00000-00000").AcctIndex;

            return vchr;
        }
    }
}
