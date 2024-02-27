using TE3EConnect.extension;
using TE3EConnect.logs;
using System;
using System.Collections.Generic;
using System.Linq;
using static TE3EConnect.TE3ETranSvc;

namespace TE3EConnect.te3eMappers
{
    public class GJParser
    {
        public Logger logger = new Logger("gj");

        public RejectedGJ rejectedJE = new RejectedGJ();

        public e3eGJ e3eEGJ;

        private TE3ETranSvc e3EService;

        private Dictionary<string, string> GJTypes
        {
            get
            {
                return new Dictionary<string, string> { };
            }
        }

        private Dictionary<string, string> GJCategories
        {
            get
            {
                return new Dictionary<string, string>
                {
                    { "Depreciation", "DEPREC" },
                    { "Payroll", "PYRLL" },
                    { "Manual Journal", "MANUAL" }
                };
            }
        }

        public GJParser(string[] lines, TE3ETranSvc transSvc)
        {
            e3EService = transSvc;
            e3eEGJ = new e3eGJ();
            string[] firstLine = e3eExtension.LineParser(lines[0]);
            e3eEGJ.gJ = GJConvert(firstLine);
            e3eEGJ.gJDetails = new List<GJDetail>();

            string[] gjDetails = lines.Skip(6).ToArray();

            int lineNum = 1;
            foreach (string gjDet in gjDetails)
            {
                try
                {
                    string[] splitgjDet = e3eExtension.LineParser(gjDet);
                    GJDetail gJDetail = GJDetailConvert(splitgjDet, lineNum);
                    e3eEGJ.gJDetails.Add(gJDetail);
                    lineNum++;
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                }
            }
        }

        private GJ GJConvert(string[] gjournal)
        {
            GJ gJ = new GJ();
            gJ.GJTranNum = gjournal[0];
            gJ.TranDate = Convert.ToDateTime(gjournal[1]).ToString("yyyy-MM-ddT00:00:00");
            gJ.PostDate = Convert.ToDateTime(gjournal[2]).ToString("yyyy-MM-ddT00:00:00");
            gJ.IsAutoReversed = gjournal[3] == "Y" ? "1" : "0";
            gJ.ReverseTo = string.IsNullOrEmpty(gjournal[4].Trim()) ? "" : Convert.ToDateTime(gjournal[4]).ToString("yyyy-MM-ddT00:00:00");
            gJ.GLType = GJTypes[gjournal[7]];
            gJ.Category = GJCategories[gjournal[8]];
            gJ.Description = gjournal[5];
            gJ.Currency = gjournal[6];
            gJ.CurrDate = string.IsNullOrEmpty(gjournal[9]) ? "" : Convert.ToDateTime(gjournal[9]).ToString("yyyy-MM-ddT00:00:00");
            gJ.NxUnit = gjournal[10];
            gJ.IsCalcForEx = gjournal[11] == "Y" ? "1" : "0";
            gJ.IsAllowIntercompanyGJ = gjournal[12] == "Y" ? "1" : "0";

            return gJ;
        }

        private GJDetail GJDetailConvert(string[] gjournalDet, int lineNo)
        {
            GJDetail gJDetail = new GJDetail();
            gJDetail.LineNum = lineNo.ToString();

            gJDetail.GLAcct = "";
            try { gJDetail.GLAcct = e3EService.GetGLAcctByMaskedAlias(gjournalDet[1]).AcctIndex; }
            catch (Exception ex) { logger.Error(new Exception(string.Format("{0} - {1}", gjournalDet[1], ex.Message))); }

            gJDetail.OrigDR = string.IsNullOrEmpty(gjournalDet[2]) ? "0" : gjournalDet[2].Replace("$", "");
            gJDetail.OrigCR = string.IsNullOrEmpty(gjournalDet[3]) ? "0" : gjournalDet[3].Replace("$", "");
            gJDetail.Description = gjournalDet[4];
            gJDetail.CurrDate = DateTime.Now.ToString("yyyy-MM-ddT00:00:00");
            gJDetail.IsDebit = string.IsNullOrEmpty(gjournalDet[2]) ? "0" : "1";

            return gJDetail;
        }
    }
}