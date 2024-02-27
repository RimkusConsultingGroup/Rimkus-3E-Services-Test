using TE3EConnect.te3eOjects;
using TE3EConnect.extension;
using TE3EConnect.logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TE3EConnect.te3eMappers.MatterSE
{
    public class MattShortEntryParser
    {
        public Logger logger = new Logger("matter");

        public RejectedNBI rejectedNBI = new RejectedNBI();
        
        public e3eMode e3EMode;

        private TE3ETranSvc e3EService;

        private Dictionary<string, List<string>> matterGroups;

        public List<e3eMatterSrv> e3EMatterSrvs;

        public MattShortEntryParser(Matter matter, TE3ETranSvc transSvc, e3eMode e3Mode)
        {
            e3EMode = e3Mode;
            e3EService = transSvc;
            matterGroups = new Dictionary<string, List<string>>();
            e3EMatterSrvs = new List<e3eMatterSrv>();

            if (e3EMode == e3eMode.Add)
                ParseAddMatterRec(matter);
            //else ParseEditMatterRec(lines);
        }

        private void ParseAddMatterRec(Matter matt)
        {
            try
            {
                e3eMatterSrv e3EMatter = new e3eMatterSrv();
                //firstLine = mattGrp.Value.First();

                ////parse matter
                //e3EMatter.matterSrv = ParseAddMatter(firstLine);

                ////parse effective dated info
                //e3EMatter.mattDate = ParseEffectiveDateInfo(firstLine);

                ////parse matter originating timekpr
                //e3EMatter.mattOrgTkpr = ParseMattOrgTkpr(firstLine);

                ////parse matter proliferating timekpr
                //e3EMatter.mattPrlfTkpr = ParseMattPrlfTkpr(firstLine);

                ////parse billing arrangement
                //e3EMatter.pGDetHdr_CCC = ParsePGDetHdr_CCC(firstLine);

                ////parse associated timekpr
                //e3EMatter.associatedTkprs_CCC = ParseAssociatedTkprs_CCC(firstLine);

                ////parse salesforce info
                //e3EMatter.salesForceInfo_CCC = ParseSalesForceInfo_CCC(firstLine);

                ////parse matter rate
                //e3EMatter.mattRate = ParseMattRate(firstLine);

                ////parse rate exception group
                //e3EMatter.mattRateExc = ParseRateExGrp(firstLine);

                //List<PGDetChild_CCC> pGDets = new List<PGDetChild_CCC>();
                //List<CPADetails_CCC> cPADetails = new List<CPADetails_CCC>();

                //mattGrp.Value.ForEach(x =>
                //{
                //    //parse billing arrangement details
                //    pGDets.Add(ParsePGDetChild_CCC(x));

                //    //parse cpa details
                //    var cpadet = ParseCPADetails_CCC(x);

                //    if (!string.IsNullOrEmpty(cpadet.CPAEntity) &&
                //       !string.IsNullOrEmpty(cpadet.CPAType) &&
                //       !string.IsNullOrEmpty(cpadet.CPAPct))
                //        cPADetails.Add(cpadet);
                //});

                //e3EMatter.pGDetChild_CCCs = pGDets;
                //e3EMatter.cPADetails_CCCs = cPADetails;

                e3EMatterSrvs.Add(e3EMatter);
            }
            catch (Exception ex)
            {
                StringBuilder sb = new StringBuilder();
                //sb.AppendLine(firstLine.ToString());
                sb.AppendLine(ex.Message);
                logger.Error(new Exception(sb.ToString()));
            }

            //foreach (string line in lines)
            //{
            //    var parsedLine = e3eExtension.LineParser(line);
            //    if (!matterGroups.ContainsKey(parsedLine[14])) //group by opportunity id
            //        matterGroups.Add(parsedLine[14], new List<string> { line });
            //    else matterGroups.Where(x => x.Key == parsedLine[14]).First().Value.Add(line);
            //}

            //foreach (KeyValuePair<string, List<string>> mattGrp in matterGroups)
            //{
            //    string firstLine = "";
            //    e3eMatterSrv e3EMatter = new e3eMatterSrv();

            //    try
            //    {
            //        firstLine = mattGrp.Value.First();

            //        //parse matter
            //        e3EMatter.matterSrv = ParseAddMatter(firstLine);

            //        //parse effective dated info
            //        e3EMatter.mattDate = ParseEffectiveDateInfo(firstLine);

            //        //parse matter originating timekpr
            //        e3EMatter.mattOrgTkpr = ParseMattOrgTkpr(firstLine);

            //        //parse matter proliferating timekpr
            //        e3EMatter.mattPrlfTkpr = ParseMattPrlfTkpr(firstLine);

            //        //parse billing arrangement
            //        e3EMatter.pGDetHdr_CCC = ParsePGDetHdr_CCC(firstLine);

            //        //parse associated timekpr
            //        e3EMatter.associatedTkprs_CCC = ParseAssociatedTkprs_CCC(firstLine);

            //        //parse salesforce info
            //        e3EMatter.salesForceInfo_CCC = ParseSalesForceInfo_CCC(firstLine);

            //        //parse matter rate
            //        e3EMatter.mattRate = ParseMattRate(firstLine);

            //        //parse rate exception group
            //        e3EMatter.mattRateExc = ParseRateExGrp(firstLine);

            //        List<PGDetChild_CCC> pGDets = new List<PGDetChild_CCC>();
            //        List<CPADetails_CCC> cPADetails = new List<CPADetails_CCC>();

            //        mattGrp.Value.ForEach(x =>
            //        {
            //            //parse billing arrangement details
            //            pGDets.Add(ParsePGDetChild_CCC(x));

            //            //parse cpa details
            //            var cpadet = ParseCPADetails_CCC(x);

            //            if (!string.IsNullOrEmpty(cpadet.CPAEntity) &&
            //               !string.IsNullOrEmpty(cpadet.CPAType) &&
            //               !string.IsNullOrEmpty(cpadet.CPAPct))
            //                cPADetails.Add(cpadet);
            //        });

            //        e3EMatter.pGDetChild_CCCs = pGDets;
            //        e3EMatter.cPADetails_CCCs = cPADetails;

            //        e3EMatterSrvs.Add(e3EMatter);
            //    }
            //    catch (Exception ex)
            //    {
            //        StringBuilder sb = new StringBuilder();
            //        sb.AppendLine(firstLine.ToString());
            //        sb.AppendLine(ex.Message);
            //        logger.Error(new Exception(sb.ToString()));
            //    }
            //}
        }

        private void ParseEditMatterRec(string[] lines)
        {
            foreach (string line in lines)
            {
                var parsedLine = e3eExtension.LineParser(line);
                if (!matterGroups.ContainsKey(parsedLine[0])) //group by matter number
                    matterGroups.Add(parsedLine[0], new List<string> { line });
                else matterGroups.Where(x => x.Key == parsedLine[0]).First().Value.Add(line);
            }

            foreach (KeyValuePair<string, List<string>> mattGrp in matterGroups)
            {
                string firstLine = "";
                e3eMatterSrv e3EMatter = new e3eMatterSrv();

                try
                {
                    firstLine = mattGrp.Value.First();
                    var parsedLine = e3eExtension.LineParser(firstLine);

                    //parse matter
                    e3EMatter.matterSrv = new MatterSrv();
                    e3EMatter.matterSrv.Number = parsedLine[0]; //matter number
                    e3EMatter.matterSrv.MattIndex = parsedLine[1]; //matter index

                    //get pgdethdr
                    e3EMatter.pGDetHdr_CCC = new PGDetHdr_CCC();
                    //te3eOjects.Edit.Matter.Matter matterPGDetHdr = e3EService.GetPGDetHdrByMattNum(parsedLine[0]);
                    //e3EMatter.pGDetHdr_CCC.KeyValue = matterPGDetHdr.PGDetHdr_CCCID;

                    //List<te3eOjects.Edit.PGDetChild_CCC> pGDetChild_CCCKeys = e3EService.GetPGDetChild_CCCs(matterPGDetHdr.PGDetHdr_CCCID);
                    List<PGDetChild_CCC> pGDets = new List<PGDetChild_CCC>();
                    
                    mattGrp.Value.ForEach(x =>
                    {
                        try
                        {
                            //parse billing arrangement details
                            PGDetChild_CCC pGDetChild_CCC = new PGDetChild_CCC();
                            var line = e3eExtension.LineParser(x);

                            string stateCode = e3eExtension.GetCode(e3eArchetype.State, line[4]).Code;

                            int isFederal = line[3].ToLower() == "true" ? 1 : 0;
                            //var selectedPGDetChild = pGDetChild_CCCKeys.Where(p => p.Year == line[2] && p.IsFederal == isFederal.ToString() && p.State == stateCode).Select(f => f);

                            //if (selectedPGDetChild == null)
                            //    throw new Exception(string.Format("PGDetChild_CCC not found for [Year: {0}, IsFederal: {1}, State: {2}]", line[2], line[3], line[4]));

                            //pGDetChild_CCC.KeyValue = selectedPGDetChild.First().PGDetChild_CCCID; //keyvalue
                            pGDetChild_CCC.Adjustments = line[5]; //adjustment
                            pGDetChild_CCC.Comments = line[6].Replace("&", "&amp;"); //comments
                            pGDets.Add(pGDetChild_CCC);
                        }
                        catch(Exception ex)
                        {
                            StringBuilder sb = new StringBuilder();
                            sb.AppendLine(firstLine.ToString());
                            sb.AppendLine(ex.Message);
                            logger.Error(new Exception(sb.ToString()));
                        }

                    });

                    e3EMatter.pGDetChild_CCCs = pGDets;
                    e3EMatterSrvs.Add(e3EMatter);
                }
                catch(Exception ex)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine(firstLine.ToString());
                    sb.AppendLine(ex.Message);
                    logger.Error(new Exception(sb.ToString()));
                }
            }
        }
        
        private MatterSrv ParseAddMatter(string line)
        {
            MatterSrv matterSrv = new MatterSrv();
            var parsedLine = e3eExtension.LineParser(line);

            matterSrv.MattStatus = e3eExtension.GetCode(e3eArchetype.MattStatus, parsedLine[0].Trim()).Code; //mattstatus
            //matterSrv.RelMattIndex = parsedLine[2];  //related matter - int (needs to lookup mattindex)
            matterSrv.DisplayName = parsedLine[1].Replace("&", "&amp;"); //matter name
            var client = e3EService.GetClientByNum(parsedLine[2]); // client
            matterSrv.Client = client.ClientIndex; //client
            matterSrv.OpenTkpr = client.OpenTkpr; //open timekpr
            matterSrv.OpenDate = Convert.ToDateTime(parsedLine[3]).ToString("yyyy-MM-ddT00:00:00"); //open date
            matterSrv.MattType = e3eExtension.GetCode(e3eArchetype.MattType, parsedLine[4].Trim()).Code; //matter type
            matterSrv.MattAttribute = e3eExtension.GetCode(e3eArchetype.MattAttribute, parsedLine[5].Trim()).Code; //matter attribute
            matterSrv.MattCategory = e3eExtension.GetCode(e3eArchetype.MattCategory, parsedLine[6].Trim()).Code; //matter category
            matterSrv.IsEvergreen_CCC = parsedLine[7].ToLower() == "true" ? "1" : "0"; //evergreen
            matterSrv.Month_CCC = e3eExtension.GetCode(e3eArchetype.Month_CCC, parsedLine[8].Trim()).Code; //month
            matterSrv.Day_CCC = parsedLine[9]; //day
            matterSrv.EngType_CCC = e3eExtension.GetCode(e3eArchetype.EngType, parsedLine[10].Trim()).Code; //engagement type
            matterSrv.Description = parsedLine[11].Replace("&", "&amp;"); //description
            matterSrv.EngStatus_CCC = e3eExtension.GetCode(e3eArchetype.EngStatus, parsedLine[12].Trim()).Code; //engagement status
            matterSrv.EngSignedDate_CCC = parsedLine[13]; //engagement signed date
            matterSrv.OpportunityID_CCC = parsedLine[14]; //opportunity id
            matterSrv.BillingFrequency = e3eExtension.GetCode(e3eArchetype.BillingFrequency, parsedLine[15].Trim()).Code; //billing frequency
            matterSrv.Currency = "USD";
            matterSrv.CurrencyDateList = parsedLine[16]; //matter currency method
            matterSrv.TimeIncrement = "QUARTERHOUR"; //Quarter of an Hour Unit
            matterSrv.PaymentTermsInfo = parsedLine[17]; //payment terms info
            matterSrv.Language = "1033"; //english
            matterSrv.IsAutoNumbering = "1";
            matterSrv.MattStatusDate = DateTime.Now.ToString("yyyy-MM-ddT00:00:00"); //current date
            matterSrv.IsMaster = "0";

            return matterSrv;
        }

        private MattDate ParseEffectiveDateInfo(string line)
        {
            MattDate mattDate = new MattDate();
            var parsedLine = e3eExtension.LineParser(line);

            mattDate.EffStart = Convert.ToDateTime(parsedLine[18]).ToString("yyyy-MM-ddT00:00:00"); //start date
            mattDate.BillTkpr = e3EService.GetTimeKeeperByNum(parsedLine[19]).TkprIndex; //billing timekpr
            mattDate.RspTkpr = mattDate.BillTkpr; //same as billing timekpr
            mattDate.SpvTkpr = mattDate.BillTkpr; //same as billing timekpr
            mattDate.Office = e3eExtension.GetCode(e3eArchetype.Office, parsedLine[20].Trim()).Code; //office
            mattDate.PTAGroup = e3eExtension.GetCode( e3eArchetype.PTAGroup, parsedLine[21].Trim()).Code; //pta group fees 1
            mattDate.Department = e3eExtension.GetCode(e3eArchetype.Department, parsedLine[22].Trim()).Code; //department
            mattDate.Section = e3eExtension.GetCode(e3eArchetype.Section, parsedLine[23].Trim()).Code; //section
            mattDate.PracticeGroup = e3eExtension.GetCode(e3eArchetype.PraticeGroup, parsedLine[24].Trim()).Code; //practice group
            mattDate.PTAGroup2 = e3eExtension.GetCode(e3eArchetype.PTAGroup, parsedLine[25].Trim()).Code; //pta group fees 2
            mattDate.Arrangement = e3eExtension.GetCode(e3eArchetype.Arrangement, parsedLine[26].Trim()).Code; //arrangement
            
            return mattDate;
        }

        public MattOrgTkpr ParseMattOrgTkpr(string line)
        {
            MattOrgTkpr mattOrgTkpr = new MattOrgTkpr();
            var parsedLine = e3eExtension.LineParser(line);

            mattOrgTkpr.Timekeeper = e3EService.GetTimeKeeperByNum(parsedLine[27]).TkprIndex; // originating timekpr
            mattOrgTkpr.Percentage = "100"; //percent
            mattOrgTkpr.IsPrimary = "1"; //isprimary

            return mattOrgTkpr;
        }

        public MattPrlfTkpr ParseMattPrlfTkpr(string line)
        {
            MattPrlfTkpr mattPrlfTkpr = new MattPrlfTkpr();
            var parsedLine = e3eExtension.LineParser(line);

            mattPrlfTkpr.Timekeeper = e3EService.GetTimeKeeperByNum(parsedLine[28]).TkprIndex; // proliferating timekpr
            mattPrlfTkpr.Percentage = "100"; //percent
            mattPrlfTkpr.IsPrimary = "1"; //isprimary

            return mattPrlfTkpr;
        }

        public PGDetHdr_CCC ParsePGDetHdr_CCC(string line)
        {
            PGDetHdr_CCC pGDetHdr_CCC = new PGDetHdr_CCC();
            var parsedLine = e3eExtension.LineParser(line);

            pGDetHdr_CCC.EffStart = DateTime.Now.ToString("yyyy-MM-ddT00:00:00"); //current date
            pGDetHdr_CCC.FeeCapPct = parsedLine[29]; //fee cap %
            pGDetHdr_CCC.FeeCapFixed = parsedLine[30]; //fee cap - fixed
            pGDetHdr_CCC.OrigWIP = parsedLine[31]; //original wip
            pGDetHdr_CCC.CreditEstHigh = parsedLine[32]; //credit estimate high
            pGDetHdr_CCC.CreditEstLow = parsedLine[33]; //credit estimate low
            pGDetHdr_CCC.BA_Notes_CCC = parsedLine[34]; //notes
            
            return pGDetHdr_CCC;
        }

        public PGDetChild_CCC ParsePGDetChild_CCC(string line)
        {
            //needs multiple entries for fed and state
            PGDetChild_CCC pGDetChild_CCC = new PGDetChild_CCC();
            var parsedLine = e3eExtension.LineParser(line);

            pGDetChild_CCC.Year = parsedLine[35]; //year
            pGDetChild_CCC.IsFederal = parsedLine[36].ToLower() == "true" ? "1" : "0";
            pGDetChild_CCC.State = e3eExtension.GetCode(e3eArchetype.State, parsedLine[37].Trim()).Code; //state
            pGDetChild_CCC.OrigCredit = parsedLine[38]; //orig cred/ded
            pGDetChild_CCC.Adjustments = parsedLine[39]; //adjustments
            pGDetChild_CCC.Total = parsedLine[38]; //total
            pGDetChild_CCC.Comments = parsedLine[40].Replace("&", "&amp;"); //comments
            
            return pGDetChild_CCC;
        }
        

        public AssociatedTkprs_CCC ParseAssociatedTkprs_CCC(string line)
        {
            AssociatedTkprs_CCC associatedTkprs_CCC = new AssociatedTkprs_CCC();
            var parsedLine = e3eExtension.LineParser(line);

            associatedTkprs_CCC.EffStart = DateTime.Now.ToString("yyyy-MM-ddT00:00:00"); //current date
            associatedTkprs_CCC.BDTkpr1 = e3EService.GetTimeKeeperByNum(parsedLine[41]).TkprIndex; //bd timekpr1
            associatedTkprs_CCC.BDTkprPct1 = parsedLine[42]; //bd timekpr1 %
            associatedTkprs_CCC.BDTkpr2 = e3EService.GetTimeKeeperByNum(parsedLine[43]).TkprIndex; //bd timekpr2
            associatedTkprs_CCC.BDTkprPct2 = parsedLine[44]; //bd timekpr2 %
            associatedTkprs_CCC.BDTkpr3 = e3EService.GetTimeKeeperByNum(parsedLine[45]).TkprIndex; //bd timekpr3
            associatedTkprs_CCC.BDTkprPct3 = parsedLine[46]; //bd timekpr3 %

            associatedTkprs_CCC.SOETkpr1 = e3EService.GetTimeKeeperByNum(parsedLine[47]).TkprIndex; //source of engagement timekpr1
            associatedTkprs_CCC.SOETkprPct1 = parsedLine[48]; //source of engagement timekpr1 %
            associatedTkprs_CCC.SOETkpr2 = e3EService.GetTimeKeeperByNum(parsedLine[49]).TkprIndex; //source of engagement timekpr2
            associatedTkprs_CCC.SOETkprPct2 = parsedLine[50]; //source of engagement timekpr2 %
            associatedTkprs_CCC.SOETkpr3 = e3EService.GetTimeKeeperByNum(parsedLine[51]).TkprIndex; //source of engagement timekpr3
            associatedTkprs_CCC.SOETkprPct3 = parsedLine[52]; //source of engagement timekpr3 %

            associatedTkprs_CCC.FUSOETkpr = e3EService.GetTimeKeeperByNum(parsedLine[53]).TkprIndex; //follow-up soe timekpr
            associatedTkprs_CCC.FUSOETkprPct = parsedLine[54]; //follow-up soe timekpr %
            associatedTkprs_CCC.Alliance = e3EService.GetEntityByDisplayName(parsedLine[55]).EntIndex; //alliance
            associatedTkprs_CCC.AlliancePct = parsedLine[56]; //alliance %
            associatedTkprs_CCC.RefSource1 = parsedLine[57]; //referral source1
            associatedTkprs_CCC.RefSourcePct1 = parsedLine[58]; //referral source1 %
            associatedTkprs_CCC.RefSource2 = parsedLine[59]; //referral source2
            associatedTkprs_CCC.RefSourcePct2 = parsedLine[60]; //referral source2 %
            associatedTkprs_CCC.Comments = parsedLine[61].Replace("&", "&amp;"); //comments

            //associatedTkprs_CCC.KickOffAMPM = parsedLine[65]; //kick-off am/pm
            //associatedTkprs_CCC.KickOffDate = string.IsNullOrEmpty(parsedLine[66]) ? "" : Convert.ToDateTime(parsedLine[66]).ToString("yyyy-MM-ddT00:00:00"); //kick-off date
            //associatedTkprs_CCC.KickOffStatus = parsedLine[67]; //kick-off status
            //associatedTkprs_CCC.KickOffTime = parsedLine[68]; //kick-off time
            //associatedTkprs_CCC.KickOffTimeZone = parsedLine[69]; //kick-off time zone
            //associatedTkprs_CCC.KickOffNotes = parsedLine[70]; //kick-off notes

            return associatedTkprs_CCC;
        }

        public CPADetails_CCC ParseCPADetails_CCC(string line)
        {
            //need multiple entries
            CPADetails_CCC cPADetails_CCC = new CPADetails_CCC();
            var parsedLine = e3eExtension.LineParser(line);

            if(!string.IsNullOrEmpty(parsedLine[62]))
            {
                var entity = e3EService.GetCPAEntity(parsedLine[62]);
                cPADetails_CCC.CPAEntity = entity.EntIndex; //entity person - need lookup indx in 3E
                cPADetails_CCC.CPAType = e3eExtension.GetCode(e3eArchetype.CPAType_CCC, parsedLine[63].Trim()).Code; //cpa type
                cPADetails_CCC.CPAPct = parsedLine[64]; //cpa %
                cPADetails_CCC.CPAFirm = parsedLine[72].Replace("&", "&amp;"); //cpa firm
            }

            return cPADetails_CCC;
        }
        
        public ContactRoles_CCC ParseContactRoles_CCC(string line)
        {
            ContactRoles_CCC contactRoles_CCC = new ContactRoles_CCC();
            var parsedLine = e3eExtension.LineParser(line);

            return contactRoles_CCC;
        }

        public SalesForceInfo_CCC ParseSalesForceInfo_CCC(string line)
        {
            SalesForceInfo_CCC salesForceInfo_CCC = new SalesForceInfo_CCC();
            var parsedLine = e3eExtension.LineParser(line);

            salesForceInfo_CCC.EffStart = DateTime.Now.ToString("yyyy-MM-ddT00:00:00"); //current date

            try
            {
                salesForceInfo_CCC.AdditionalRefSource = e3EService.GetEntityAdditionalRefSource(parsedLine[65]).EntIndex; //additional AG referral source
            }
            catch { salesForceInfo_CCC.AdditionalRefSource = ""; }
            
            salesForceInfo_CCC.StudyInfoEntityType = parsedLine[66]; //study info entity type
            salesForceInfo_CCC.StudyInfoFedStudyYears = parsedLine[67]; //federal study
            salesForceInfo_CCC.StudyInfoFiscalYearEnd = parsedLine[68]; //fiscal year end
            salesForceInfo_CCC.StudyInfoStates = parsedLine[69]; //states
            salesForceInfo_CCC.StudyInfoStateStudyYears = parsedLine[70]; //state study year

            return salesForceInfo_CCC;
        }

        public MattRate ParseMattRate(string line)
        {
            MattRate mattRate = new MattRate();
            var parsedLine = e3eExtension.LineParser(line);

            mattRate.Rate = "STANDARD"; // parsedLine[71]; //rate
            mattRate.IsActive = "1";

            return mattRate;
        }

        public MatterRateExc ParseRateExGrp(string line)
        {
            MatterRateExc mattRateExc = new MatterRateExc();
            var parsedLine = e3eExtension.LineParser(line);

            mattRateExc.RateExc = e3EService.GetRateExc(parsedLine[73]).RateExcID; //rate exception group;
            mattRateExc.StartDate = DateTime.Now.ToString("yyyy-MM-ddT00:00:00"); //current date

            return mattRateExc;
        }
    }
}