using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TE3EConnect.extension;
using TE3EConnect.te3eObjects.Automation;
using TE3EEntityFramework.Extension;

namespace TE3EConnect.te3eMappers.Automation
{
    internal class MatterSrvMapper
    {
        #region Add Section
        public static string ConvertAddMatterSrvToXml(te3eObjects.Automation.MatterSrv matterSrv, bool useTemplateProcess)
        {
            string csXml = "";
            string strTemplate = useTemplateProcess ? "AddMatterSrvTemplate.xml" : "AddMatterSrv.xml";

            using (var objStreamReader = File.OpenText(Path.Combine(Path.GetDirectoryName(Assembly.GetCallingAssembly().Location), $"te3eXML/Automation/{strTemplate}")))
            {
                csXml = objStreamReader.ReadToEnd();

                //Loss Location
                if (matterSrv.mattSites.Count() == 0)
                {
                    if (!useTemplateProcess)
                    {
                        csXml = csXml.Replace("<MattSite>", "");
                        csXml = csXml.Replace("@AddMattSite", "");
                        csXml = csXml.Replace("</MattSite>", "");
                    }
                }
                else
                {
                    csXml = csXml.Replace("@AddMattSite", ConvertAddMattSite(matterSrv.mattSites));
                }

                //MattPayor Det
                if (matterSrv.mattPayorDetails.Count() == 0)
                {
                    csXml = csXml.Replace("<MattPayorDetail>", "");
                    csXml = csXml.Replace("@AddMattPayorDetail", "");
                    csXml = csXml.Replace("</MattPayorDetail>", "");
                }
                else
                {
                    csXml = csXml.Replace("@AddMattPayorDetail", ConvertAddMattPayorDetail(matterSrv.mattPayorDetails));
                }

                //Related Parties
                if (matterSrv.relatedParties_CCCs.Count() == 0)
                {
                    csXml = csXml.Replace("<RelatedParties_CCC>", "");
                    csXml = csXml.Replace("@AddRelatedParties_CCC", "");
                    csXml = csXml.Replace("</RelatedParties_CCC>", "");
                }
                else
                {
                    csXml = csXml.Replace("@AddRelatedParties_CCC", ConvertAddRelatedParties_CCC(matterSrv.relatedParties_CCCs));
                }

                if (matterSrv.mattDates.Any(x => x.PracticeGroup.Equals("002") || x.PracticeGroup.Equals("001")))
                {
                    csXml = csXml.Replace("@CommercialInspectionContact_CCC", ConvertAddCommercialInspectionContact_CCC(matterSrv.mattPayorDetails));
                }
                else
                {
                    csXml = csXml.Replace("<CommercialInspectionContact_CCC>", "");
                    csXml = csXml.Replace("@CommercialInspectionContact_CCC", "");
                    csXml = csXml.Replace("</CommercialInspectionContact_CCC>", "");
                }


                csXml = csXml.Replace("@DisplayName", matterSrv.DisplayName.TrimToLength(255))
                            .Replace("@LoadSource", matterSrv.LoadSource.TrimToLength(64))
                            .Replace("@ClientIndex", matterSrv.Client)
                            .Replace("@MStatus", matterSrv.MStatus)
                            .Replace("@MattStatusDate", matterSrv.MattStatusDate)
                            .Replace("@OpenDate", matterSrv.OpenDate)
                            .Replace("@OpenTkpr", matterSrv.OpenTkpr)
                            .Replace("@Narrative", matterSrv.Narrative)
                            .Replace("@DateOfOccurence_CCC", matterSrv.DateOfOccurence_CCC)
                            .Replace("@TimeTaxCode", matterSrv.TimeTaxCode)
                            .Replace("@IsProspective_CCC", Convert.ToByte(matterSrv.IsProspective_CCC ?? "1").ToString())
                            .Replace("@RetainerAmount_CCC", matterSrv.RetainerAmount_CCC)
                            .Replace("@ScopeOfWork_CCC", matterSrv.ScopeOfWork_CCC)
                            .Replace("@IsFixedPrice_CCC", Convert.ToByte(matterSrv.IsFixedPrice_CCC ?? "0").ToString())
                            .Replace("@DNENotes_CCC", matterSrv.DNENotes_CCC.TrimToLength(500))
                            .Replace("@IsWeb_CCC", Convert.ToByte(matterSrv.IsWeb_CCC ?? "0").ToString())
                            .Replace("@EntryDate", matterSrv.EntryDate)
                            .Replace("@IsEBill", Convert.ToByte(matterSrv.IsEBill ?? "0").ToString())
                            .Replace("@ElecBillingType", matterSrv.ElecBillingType)
                            .Replace("@ElecNumber", matterSrv.ElecNumber)
                            .Replace("@IsConfLetterCAT_CCC", Convert.ToByte(matterSrv.IsConfLetterCAT_CCC ?? "0").ToString())
                            .Replace("@IsConfLetterEngSvcs_CCC", Convert.ToByte(matterSrv.IsConfLetterEngSvcs_CCC ?? "0").ToString())
                            .Replace("@IsConfLetterLegal_CCC", Convert.ToByte(matterSrv.IsConfLetterLegal_CCC ?? "0").ToString())
                            .Replace("@IsConfLetterNatAgmt_CCC", Convert.ToByte(matterSrv.IsConfLetterNatAgmt_CCC ?? "0").ToString())
                            .Replace("@IsConfLetterRtnr_CCC", Convert.ToByte(matterSrv.IsConfLetterRtnr_CCC ?? "0").ToString())
                            .Replace("@IsConfLetterSign_CCC", Convert.ToByte(matterSrv.IsConfLetterSign_CCC ?? "0").ToString())
                            .Replace("@IsConfLetterStd_CCC", Convert.ToByte(matterSrv.IsConfLetterStd_CCC).ToString())
                            .Replace("@ReportOfFindings_CCC", matterSrv.ReportOfFindings_CCC)
                            .Replace("@ReportingOffice_CCC", matterSrv.ReportingOffice_CCC)

                            //MattDate
                            .Replace("@AddMattDate", ConvertAddMattDate(matterSrv.mattDates))

                            //MattBudget
                            .Replace("@AddMattBudget", !string.IsNullOrEmpty(matterSrv.MatterBudget.BudAmount) ? ConvertAddMattBudget(matterSrv.MatterBudget.BudAmount) : "")

                            //MattFlatFee
                            .Replace("@AddMattFlatFee", !string.IsNullOrEmpty(matterSrv.MatterFlatFee.FlatFeeAmount) ? ConvertAddMattFlatFee(matterSrv.MatterFlatFee) : "")

                            //MattPayor
                            .Replace("@StartDate", matterSrv.mattPayor.StartDate)
                            .Replace("@CauseNum_CCC", matterSrv.mattPayor.CauseNum_CCC.TrimToLength(64))
                            .Replace("@Court_CCC", matterSrv.mattPayor.Court_CCC.TrimToLength(512))
                            .Replace("@Representing_CCC", matterSrv.mattPayor.Representing_CCC)
                            .Replace("@Style_CCC", matterSrv.mattPayor.Style_CCC.TrimToLength(1000))

                            //Matter Special Instruction
                            .Replace("@MSClient", matterSrv.matterSpecialInstructions_CCC.MSClient)
                            .Replace("@MSStartDate", matterSrv.matterSpecialInstructions_CCC.MSStartDate)
                            .Replace("@MSEffDate", matterSrv.matterSpecialInstructions_CCC.MSEffDate)
                            .Replace("@MSEndDate", matterSrv.matterSpecialInstructions_CCC.MSEndDate)

                            //temporary suppressed until issue with mapping is addressed
                            //.Replace("@ClientInstruction", matterSrv.matterSpecialInstructions_CCC.ClientInstr)

                            .Replace("@ReportsTo", matterSrv.matterSpecialInstructions_CCC.ReportsTo)
                            .Replace("@AdditionalInstr", matterSrv.matterSpecialInstructions_CCC.AdditionalInstr)

                            .Replace("@AddMatterSpecialInvoiceTo_CCC", matterSrv.matterSpecialInvoiceTo_CCC.Count() > 0
                                                                       ? ConvertAddMatterSpecialInvoiceTo_CCC(matterSrv.matterSpecialInvoiceTo_CCC)
                                                                       : "")
                            //Technical Review
                            .Replace("@EngineerOfRecord", matterSrv.techRevEngRec_CCC.EngineerOfRecord)
                            .Replace("@Marketer", matterSrv.techRevEngRec_CCC.Marketer)
                            .Replace("@TechincalReviewer", matterSrv.techRevEngRec_CCC.TechincalReviewer)

                            //CoConsultants
                            .Replace("@AddCoConsultants_CCC", matterSrv.coConsultants_CCCs.Count() > 0 ? ConvertAddCoConsultants(matterSrv.coConsultants_CCCs) : "")

                            //matter rate
                            .Replace("@MattRate", matterSrv.MatterRate.MattRate)

                            //matter rate group exc
                            .Replace("@MatterRateExc", matterSrv.MatterRateExc.MattRateExc)

                            //Industry Group
                            .Replace("@IndustryGroup", matterSrv.mattIndustryGroup.IndustryGroup);
            }

            return csXml;
        }

        private static string ConvertAddMatterSpecialInvoiceTo_CCC(List<MatterSpecialInvoiceTo_CCC> matterSpecialInvoiceTo_CCCs)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<MatterSpecialInvoiceTo_CCC>");

            matterSpecialInvoiceTo_CCCs.ForEach(x =>
            {
                string csXml = AddMatterSpecialInvoiceTo_CCCXml;
                csXml = csXml.Replace("@InvoiceTo", x.InvoiceTo);
                sb.AppendLine(csXml);
            });

            sb.AppendLine("</MatterSpecialInvoiceTo_CCC>");

            return sb.ToString(); ;
        }

        private static string ConvertAddMattBudget(string budAmount)
        {
            if (string.IsNullOrEmpty(budAmount))
                return "";

            string csXml = @"<MattBudget>
							<Add>
							  <MattBudget>
								<Attributes>
								  <IsActive>1</IsActive>
								  <StartDate>@MBStartDate</StartDate>
								  <EndDate>@MBEndDate</EndDate>
								  <IsFee>0</IsFee>
								  <IsCost>1</IsCost>
								  <Currency>USD</Currency>
								  <BudAmount>@BudAmount</BudAmount>
								  <IsBaseBudget_CCC>1</IsBaseBudget_CCC>
								</Attributes>
							  </MattBudget>
							</Add>
						  </MattBudget>";

            csXml = csXml.Replace("@MBStartDate", DateTime.Now.ToString("yyyy-MM-ddT00:00:00"));
            csXml = csXml.Replace("@MBEndDate", DateTime.MaxValue.ToString("yyyy-MM-ddT00:00:00"));
            csXml = csXml.Replace("@BudAmount", budAmount);

            return csXml;
        }

        private static string ConvertAddMattFlatFee(MatterFlatFee matterFlatFee)
        {
            if (string.IsNullOrEmpty(matterFlatFee.FlatFeeAmount))
                return "";

            string csXml = @" <MattFlatFee>
								<Add>
								  <MattFlatFee>
									<Attributes>
									  <TimeType>FFEE</TimeType>
									  <Currency>USD</Currency>
									  <StartDate>@MFStartDate</StartDate>
									  <EndDate>@MFEndDate</EndDate>
									  <FlatFeeAmount>@FlatFeeAmount</FlatFeeAmount>
									  <Client />
									</Attributes>
								  </MattFlatFee>
								</Add>
							</MattFlatFee>";

            csXml = csXml.Replace("@MFStartDate", DateTime.Now.ToString("yyyy-MM-ddT00:00:00"));
            csXml = csXml.Replace("@MFEndDate", DateTime.MaxValue.ToString("yyyy-MM-ddT00:00:00"));
            csXml = csXml.Replace("@TimeType", matterFlatFee.TimeType);
            csXml = csXml.Replace("@FlatFeeAmount", matterFlatFee.FlatFeeAmount);

            return csXml;
        }

        private static string ConvertAddCoConsultants(List<CoConsultants_CCC> coConsultants)
        {
            if (coConsultants.Count() == 0)
                return "";

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<CoConsultants_CCC>");

            coConsultants.ForEach(x =>
            {
                string csXml = AddCoConsultants_CCCXml;
                csXml = csXml.Replace("@CoConsultant", x.CoConsultantIndex);

                sb.AppendLine(csXml);
            });

            sb.AppendLine("</CoConsultants_CCC>");

            return sb.ToString();
        }

        private static string ConvertAddCommercialInspectionContact_CCC(List<MattPayorDetail> mattPayorDetails)
        {
            if (mattPayorDetails.Count() == 0)
                return "";

            StringBuilder sb = new StringBuilder();

            mattPayorDetails.ForEach(x =>
            {
                string csXml = AddCommercialInspectionContact_CCC;
                csXml = csXml
                            .Replace("@CIEmail", x.Email_CCC)
                            .Replace("@CIContact", x.Contact_CCC.TrimToLength(64));

                sb.AppendLine(csXml);
            });

            return sb.ToString();
        }

        private static string ConvertAddMattPayorDetail(List<MattPayorDetail> mattPayorDetails)
        {
            if (mattPayorDetails.Count() == 0)
                return "";

            StringBuilder sb = new StringBuilder();

            mattPayorDetails.ForEach(x =>
            {
                string csXml = AddMattPayorDetailXml;
                csXml = csXml.Replace("@PctFee", x.PctFee)
                            .Replace("@CftRole_CCC", x.CftRole_CCC)
                            .Replace("@CftRelationship_CCC", x.CftRelationship_CCC)
                            .Replace("@Payor", x.PayorIndex)
                            .Replace("@Email_CCC", x.Email_CCC)
                            .Replace("@Contact_CCC", x.Contact_CCC.TrimToLength(64))
                            .Replace("@PhoneNum_CCC", x.PhoneNum_CCC.TrimToLength(64))
                            .Replace("@RefNumber", x.RefNumber.TrimToLength(64))
                            .Replace("@ClaimNum_CCC", x.ClaimNum_CCC.TrimToLength(64))
                            .Replace("@CorpType_CCC", x.CorpType_CCC)
                            .Replace("@GovernmentType_CCC", x.GovernmentType_CCC)
                            .Replace("@Title_CCC", x.Title_CCC.TrimToLength(64))
                            .Replace("@AddtlContactInfo_CCC", x.AddtlContactInfo_CCC)
                            .Replace("@PONumber_CCC", x.PONumber_CCC.TrimToLength(64))
                            .Replace("@Policy_CCC", x.Policy_CCC.TrimToLength(64))
                            .Replace("@UMR_CCC", x.UMR_CCC)
                            .Replace("@File_CCC", x.File_CCC)
                            .Replace("@Tracking_CCC", x.Tracking_CCC)
                            .Replace("@PSite", x.PSite)
                            .Replace("@IsDefault", x.IsDefault)
                            .Replace("@StmtSite", x.StmtSite);

                sb.AppendLine(csXml);
            });

            return sb.ToString();
        }

        private static string ConvertAddRelatedParties_CCC(List<RelatedParties_CCC> relatedParties_CCCs)
        {
            if (relatedParties_CCCs.Count() == 0)
                return "";

            StringBuilder sb = new StringBuilder();

            relatedParties_CCCs.ForEach(x =>
            {
                string csXml = AddRelatedParties_CCCXml;
                csXml = csXml.Replace("@RelatedPartiesCftRole", x.RelatedPartiesCftRole)
                            .Replace("@RelatedPartiesEntity", x.RelatedPartiesEntity)
                            .Replace("@WorkPhone", x.WorkPhone);

                sb.AppendLine(csXml);
            });

            return sb.ToString();
        }

        private static string ConvertAddMattSite(List<te3eObjects.Automation.MattSite> mattSites)
        {
            if (mattSites.Count() == 0)
                return "";

            StringBuilder sb = new StringBuilder();

            mattSites.ForEach(x =>
            {
                string csXml = AddMattSiteXml;
                csXml = csXml.Replace("@MSite", x.MSite)
                            .Replace("@MattSiteType", x.MattSiteType);

                sb.AppendLine(csXml);
            });

            return sb.ToString();
        }

        private static string ConvertAddMattDate(List<te3eObjects.Automation.MattDate> mattDates)
        {
            if (mattDates.Count() == 0)
                return "";

            StringBuilder sb = new StringBuilder();

            mattDates.ForEach(x =>
            {
                string csXml = AddMattDateXml;
                csXml = csXml.Replace("@EffStart", x.EffStart)
                            .Replace("@NxStartDate", x.NxStartDate)
                            .Replace("@PracticeGroup", x.PracticeGroup)
                            .Replace("@Department", x.Department)
                            .Replace("@Section", x.Section)
                            .Replace("@Arrangement", x.Arrangement)
                            .Replace("@PTAGroup", x.PTAGroup)
                            .Replace("@BillTkpr", x.BillTkpr)
                            .Replace("@RspTkpr", x.RspTkpr)
                            .Replace("@SpvTkpr", x.SpvTkpr)
                            .Replace("@Office", x.Office)
                            .Replace("@SubSection_CCC", x.SubSection_CCC);

                sb.AppendLine(csXml);
            });

            return sb.ToString();
        }


        private static string AddMattDateXml = @"
        <Add>
			<MattDate>
				<Attributes>
					<EffStart>@EffStart</EffStart>
					<!-- <PracticeGroup>Undefined</PracticeGroup> -->
					<PracticeGroup>@PracticeGroup</PracticeGroup>
					<!-- <Department>000</Department> -->
					<Department>@Department</Department>
					<!-- <Section>000</Section> -->
					<Section>@Section</Section>
					<SubSection_CCC>@SubSection_CCC</SubSection_CCC>
					<!-- <Arrangement>100</Arrangement> -->
					<Arrangement>@Arrangement</Arrangement>
					<!-- <PTAGroup>Default</PTAGroup> -->
					<PTAGroup>@PTAGroup</PTAGroup>
					<NxStartDate>@NxStartDate</NxStartDate>
					<BillTkpr>@BillTkpr</BillTkpr>
					<RspTkpr>@RspTkpr</RspTkpr>
					<SpvTkpr>@SpvTkpr</SpvTkpr>
					<Office>@Office</Office>
				</Attributes>
			</MattDate>
		</Add>
";

        private static string AddMattSiteXml = @"
        <Add>
			<MattSite>
				<Attributes>
					<Site>@MSite</Site>
					<MattSiteType>@MattSiteType</MattSiteType>
				</Attributes>
			</MattSite>
		</Add>
";

        private static string AddCommercialInspectionContact_CCC = @"
        <Add>
			<CommercialInspectionContact_CCC>
				<Attributes>
					<Contact>@CIContact</Contact>
					<Email>@CIEmail</Email>
					<CompanyName>@CIContact</CompanyName>
					<IsSameAsOrdering>1</IsSameAsOrdering>
				</Attributes>
			</CommercialInspectionContact_CCC>
		</Add>
";

        private static string AddMattPayorDetailXml = @"
        <Add>
			<MattPayorDetail>
				<Attributes>
					<IsDefault>@IsDefault</IsDefault>
					<!-- only one payor can have default specification -->
					<PctFee>@PctFee</PctFee>
					<!-- total of all payors must be 1 for percent fields -->
					<PctHCo>@PctFee</PctHCo>
					<PctSCo>@PctFee</PctSCo>
					<PctTax>@PctFee</PctTax>
					<PctInt>@PctFee</PctInt>
					<PctBOA>@PctFee</PctBOA>
					<PctOth>@PctFee</PctOth>
					<CftRole_CCC>@CftRole_CCC</CftRole_CCC>
					<CftRelationship_CCC>@CftRelationship_CCC</CftRelationship_CCC>
					<Payor>@Payor</Payor>
					<Email_CCC>@Email_CCC</Email_CCC>
					<Contact_CCC>@Contact_CCC</Contact_CCC>
					<PhoneNum_CCC>@PhoneNum_CCC</PhoneNum_CCC>
					<RefNumber>@RefNumber</RefNumber>
					<ClaimNum_CCC>@ClaimNum_CCC</ClaimNum_CCC>
					<CorpType_CCC>@CorpType_CCC</CorpType_CCC>
					<GovernmentType_CCC>@GovernmentType_CCC</GovernmentType_CCC>
					<Title_CCC>@Title_CCC</Title_CCC>
					<AddtlContactInfo_CCC>@AddtlContactInfo_CCC</AddtlContactInfo_CCC>
					<PONumber_CCC>@PONumber_CCC</PONumber_CCC>
					<!--<Policy_CCC>@Policy_CCC</Policy_CCC>
					<UMR_CCC>@UMR_CCC</UMR_CCC>
					<File_CCC>@File_CCC</File_CCC>
					<Tracking_CCC>@Tracking_CCC</Tracking_CCC> -->
					<Site>@PSite</Site>
					<!-- Site must be related to payor (client) entity -->
					<StmtSite>@StmtSite</StmtSite>
				</Attributes>
			</MattPayorDetail>
		</Add>
";

        private static string AddRelatedParties_CCCXml = @"
        <Add>
			<RelatedParties_CCC>
				<Attributes>
					<CftRole>@RelatedPartiesCftRole</CftRole>
					<Entity>@RelatedPartiesEntity</Entity>
                    <WorkPhone>@WorkPhone</WorkPhone>
				</Attributes>
			</RelatedParties_CCC>
		</Add>
";

        private static string AddCoConsultants_CCCXml = @"
			<Add>
                <CoConsultants_CCC>
                    <Attributes>
                        <CoConsultant>@CoConsultant</CoConsultant>
                    </Attributes>
                </CoConsultants_CCC>
            </Add>
			";

        private static string AddMatterSpecialInvoiceTo_CCCXml = @"
		<Add>
				<MatterSpecialInvoiceTo_CCC>
					<Attributes>
						<InvoiceTo>@InvoiceTo</InvoiceTo>
					</Attributes>
				</MatterSpecialInvoiceTo_CCC>
			</Add>
";
        #endregion Add Section

        #region Edit Section

        public static string ConvertEditMatterSrvToXml(te3eObjects.Automation.MatterSrv matterSrv)
        {
            string csXml = "";
            string strTemplate = "EditMatterSrv.xml";

            using (var objStreamReader = File.OpenText(Path.Combine(Path.GetDirectoryName(Assembly.GetCallingAssembly().Location), $"te3eXML/Automation/{strTemplate}")))
            {
                csXml = objStreamReader.ReadToEnd();
                csXml = csXml.Replace("@MatterIndex", matterSrv.MatterIndex)
                            .Replace("@DisplayName", matterSrv.DisplayName.TrimToLength(255))
                            .Replace("@LoadSource", matterSrv.LoadSource)
                            .Replace("@Client", matterSrv.Client)
                            .Replace("@MStatus", matterSrv.MStatus)
                            .Replace("@MattStatusDate", matterSrv.MattStatusDate)
                            .Replace("@OpenDate", matterSrv.OpenDate)
                            .Replace("@OpenTkpr", matterSrv.OpenTkpr)
                            .Replace("@Narrative", matterSrv.Narrative)
                            .Replace("@DateOfOccurence_CCC", matterSrv.DateOfOccurence_CCC)
                            .Replace("@TimeTaxCode", matterSrv.TimeTaxCode)
                            .Replace("@IsProspective_CCC", matterSrv.IsProspective_CCC)
                            .Replace("@RetainerAmount_CCC", matterSrv.RetainerAmount_CCC)
                            .Replace("@ScopeOfWork_CCC", matterSrv.ScopeOfWork_CCC)
                            .Replace("@IsFixedPrice_CCC", matterSrv.IsFixedPrice_CCC)
                            .Replace("@DNENotes_CCC", matterSrv.DNENotes_CCC.TrimToLength(500))
                            .Replace("@IsWeb_CCC", matterSrv.IsWeb_CCC)
                            .Replace("@EntryDate", matterSrv.EntryDate)
                            .Replace("@IsEBill", matterSrv.IsEBill)
                            .Replace("@ElecBillingType", matterSrv.ElecBillingType)
                            .Replace("@ElecNumber", matterSrv.ElecNumber)
                            .Replace("@IsConfLetterCAT_CCC", matterSrv.IsConfLetterCAT_CCC)
                            .Replace("@IsConfLetterEngSvcs_CCC", matterSrv.IsConfLetterEngSvcs_CCC)
                            .Replace("@IsConfLetterLegal_CCC", matterSrv.IsConfLetterLegal_CCC)
                            .Replace("@IsConfLetterNatAgmt_CCC", matterSrv.IsConfLetterNatAgmt_CCC)
                            .Replace("@IsConfLetterRtnr_CCC", matterSrv.IsConfLetterRtnr_CCC)
                            .Replace("@IsConfLetterSign_CCC", matterSrv.IsConfLetterSign_CCC)
                            .Replace("@IsConfLetterStd_CCC", matterSrv.IsConfLetterStd_CCC)
                            .Replace("@ReportOfFindings_CCC", matterSrv.ReportOfFindings_CCC)
                            .Replace("@ReportingOffice_CCC", matterSrv.ReportingOffice_CCC)

                            //MattDate
                            .Replace("@EditMattDate", matterSrv.mattDates.Count() > 0 ? ConvertEditMattDate(matterSrv.mattDates) : "")

                            //Loss Location
                            .Replace("@EditMattSite", matterSrv.mattSites.Count() > 0 ? ConvertEditMattSite(matterSrv.mattSites) : "")

                            //MattBudget
                            .Replace("@EditMattBudget", !string.IsNullOrEmpty(matterSrv.MatterBudget.MattBudgetIndex) ? ConvertEditMattBudget(matterSrv.MatterBudget) : ConvertAddMattBudget(matterSrv.MatterBudget.BudAmount))

                            //MattFlatFee
                            .Replace("@EditMattFlatFee", !string.IsNullOrEmpty(matterSrv.MatterFlatFee.MattFlatFeeIndex) ? ConvertEditMattFlatFee(matterSrv.MatterFlatFee) : ConvertAddMattFlatFee(matterSrv.MatterFlatFee))

                            //MattPayor
                            .Replace("@EditMattPayor", ConvertEditMattPayor(matterSrv.mattPayor, matterSrv.mattPayorDetails))

                            //Related Parties
                            .Replace("@EditRelatedParties_CCC", matterSrv.relatedParties_CCCs.Count() > 0 ? ConvertEditRelatedParties_CCC(matterSrv.relatedParties_CCCs) : "")

                            //Matter Special Instruction
                            .Replace("@EditMatterSpecialInstructions_CCC", ConvertEditMattSpecialInstructions(matterSrv.matterSpecialInstructions_CCC, matterSrv.matterSpecialInvoiceTo_CCC))

                            //Technical Review
                            .Replace("@EditTechRevEngRec_CCC", ConvertEditTechRevEngRec_CCC(matterSrv.techRevEngRec_CCC, matterSrv.coConsultants_CCCs))

                            //CoConsultants
                            //.Replace("@EditCoConsultants_CCC", matterSrv.coConsultants_CCCs.Count() > 0 ? ConvertEditCoConsultants(matterSrv.coConsultants_CCCs) : "")

                            //matter rate
                            .Replace("@EditMattRate", ConvertEditMattRate(matterSrv.MatterRate))

                            //matter rate group exc
                            .Replace("@EditMatterRateExc", ConvertEditMattRateExc(matterSrv.MatterRateExc))

                            //Industry Group
                            .Replace("@EditIndustryGroupMatter_CCC", ConvertEditIndustryGroupMatter_CCC(matterSrv.mattIndustryGroup));
            }

            return csXml;
        }

        private static string ConvertEditIndustryGroupMatter_CCC(MattIndustryGroup mattIndustryGroup)
        {
            string csXml;

            if (!string.IsNullOrEmpty(mattIndustryGroup.IndustryGroupIndex))
            {
                csXml = @"<IndustryGroupMatter_CCC>
								<Edit>
									  <IndustryGroupMatter_CCC KeyValue=""@IndustryGroupMatter_CCCKey"">
										  <Attributes>
											  <IndustryGroup>@IndustryGroup</IndustryGroup>
										  </Attributes>
									  </IndustryGroupMatter_CCC>
								  </Edit>
						  </IndustryGroupMatter_CCC>";

                csXml = csXml.Replace("@IndustryGroupMatter_CCCKey", mattIndustryGroup.IndustryGroupIndex)
                             .Replace("@IndustryGroup", mattIndustryGroup.IndustryGroup);
            }
            else
            {
                csXml = @"<IndustryGroupMatter_CCC>
								<Add>
									  <IndustryGroupMatter_CCC>
										  <Attributes>
											  <IndustryGroup>@IndustryGroup</IndustryGroup>
										  </Attributes>
									  </IndustryGroupMatter_CCC>
								  </Add>
						  </IndustryGroupMatter_CCC>";

                csXml = csXml.Replace("@IndustryGroup", mattIndustryGroup.IndustryGroup);
            }

            return csXml;
        }

        private static string ConvertEditTechRevEngRec_CCC(TechRevEngRec_CCC techRevEngRec_CCC, List<CoConsultants_CCC> coConsultants_CCCs)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<TechRevEngRec_CCC>");

            int entryCount = 0;
            if (!string.IsNullOrEmpty(techRevEngRec_CCC.TechRevEngRecIndex))
            {
                string csXml = @"<Edit>
								  <TechRevEngRec_CCC KeyValue=""@TechRevEngRec_CCCKey"">
									<Attributes>
									  <EngineerOfRecord>@EngineerOfRecord</EngineerOfRecord>
									  <Marketer>@Marketer</Marketer>
									  <TechincalReviewer>@TechincalReviewer</TechincalReviewer>
									</Attributes>
									<Children>
									  @EditCoConsultants_CCC
									</Children>
								  </TechRevEngRec_CCC>
								</Edit>";

                csXml = csXml.Replace("@TechRevEngRec_CCCKey", techRevEngRec_CCC.TechRevEngRecIndex)
                             .Replace("@EngineerOfRecord", techRevEngRec_CCC.EngineerOfRecord)
                             .Replace("@Marketer", techRevEngRec_CCC.Marketer)
                             .Replace("@TechincalReviewer", techRevEngRec_CCC.TechincalReviewer)
                             .Replace("@EditCoConsultants_CCC", coConsultants_CCCs.Count() > 0 ? ConvertEditCoConsultants(coConsultants_CCCs) : "");

                sb.AppendLine(csXml);
                entryCount++;
            }
            else
            {
                string csXml = "";

                if (!string.IsNullOrEmpty(techRevEngRec_CCC.TechincalReviewer) ||
                    !string.IsNullOrEmpty(techRevEngRec_CCC.Marketer) ||
                    !string.IsNullOrEmpty(techRevEngRec_CCC.EngineerOfRecord))
                {
                    csXml = @"<Add>
								  <TechRevEngRec_CCC>
									<Attributes>
									  <EngineerOfRecord>@EngineerOfRecord</EngineerOfRecord>
									  <Marketer>@Marketer</Marketer>
									  <TechincalReviewer>@TechincalReviewer</TechincalReviewer>
									</Attributes>
									<Children>
									  @EditCoConsultants_CCC
									</Children>
								  </TechRevEngRec_CCC>
								</Add>";

                    csXml = csXml.Replace("@EngineerOfRecord", techRevEngRec_CCC.EngineerOfRecord)
                                 .Replace("@Marketer", techRevEngRec_CCC.Marketer)
                                 .Replace("@TechincalReviewer", techRevEngRec_CCC.TechincalReviewer)
                                 .Replace("@EditCoConsultants_CCC", coConsultants_CCCs.Count() > 0 ? ConvertEditCoConsultants(coConsultants_CCCs) : "");

                    entryCount++;
                }

                sb.AppendLine(csXml);
            }

            sb.AppendLine("</TechRevEngRec_CCC>");

            if (entryCount == 0)
                sb = new StringBuilder();

            return sb.ToString();
        }

        //private static string ConvertAddTechRevEngRec_CCC(TechRevEngRec_CCC techRevEngRec_CCC, List<CoConsultants_CCC> coConsultants_CCCs)
        //{
        //	if (string.IsNullOrEmpty(techRevEngRec_CCC.TechincalReviewer) &&
        //		string.IsNullOrEmpty(techRevEngRec_CCC.EngineerOfRecord) &&
        //		string.IsNullOrEmpty(techRevEngRec_CCC.Marketer) &&
        //		coConsultants_CCCs.Count() == 0)
        //		return "";

        //	string csXml = @"<TechRevEngRec_CCC>
        //						<Add>
        //						  <TechRevEngRec_CCC>
        //							<Attributes>
        //							  <EngineerOfRecord>@EngineerOfRecord</EngineerOfRecord>
        //							  <Marketer>@Marketer</Marketer>
        //							  <TechincalReviewer>@TechincalReviewer</TechincalReviewer>
        //							</Attributes>
        //							<Children>
        //							  @EditCoConsultants_CCC
        //							</Children>
        //						  </TechRevEngRec_CCC>
        //						</Add>
        //					</TechRevEngRec_CCC>";

        //	csXml = csXml.Replace("@TechRevEngRec_CCCKey", techRevEngRec_CCC.TechRevEngRecIndex)
        //				 .Replace("@EngineerOfRecord", techRevEngRec_CCC.EngineerOfRecord)
        //				 .Replace("@Marketer", techRevEngRec_CCC.Marketer)
        //				 .Replace("@TechincalReviewer", techRevEngRec_CCC.TechincalReviewer)
        //				 .Replace("@EditCoConsultants_CCC", coConsultants_CCCs.Count() > 0 ? ConvertEditCoConsultants(coConsultants_CCCs) : ConvertAddCoConsultants(coConsultants_CCCs));

        //	return csXml;
        //}

        private static string ConvertEditMattSpecialInstructions(MatterSpecialInstructions_CCC matterSpecialInstructions_CCC, List<MatterSpecialInvoiceTo_CCC> matterSpecialInvoiceTo_CCC)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<MatterSpecialInstructions_CCC>");

            if (!string.IsNullOrEmpty(matterSpecialInstructions_CCC.MSClientIndex))
            {
                string csXml = EditMatterSpecialInstructions_CCCXml;
                csXml = csXml.Replace("@MatterSpecialInstructions_CCCKey", matterSpecialInstructions_CCC.MSClientIndex)
                             .Replace("@ClientInstruction", matterSpecialInstructions_CCC.ClientInstr)
                             .Replace("@AdditionalInstr", matterSpecialInstructions_CCC.AdditionalInstr)
                             .Replace("@ReportsTo", matterSpecialInstructions_CCC.ReportsTo)
                             .Replace("@EditMatterSpecialInvoiceTo_CCCXml", ConvertEditMatterSpecialInvoiceTo(matterSpecialInvoiceTo_CCC));

                sb.AppendLine(csXml);
            }
            else
            {
                string csXml = AddMatterSpecialInstructions_CCCXml;
                csXml = csXml.Replace("@MSClient", matterSpecialInstructions_CCC.MSClient)
                             .Replace("@ClientInstruction", matterSpecialInstructions_CCC.ClientInstr)
                             .Replace("@AdditionalInstr", matterSpecialInstructions_CCC.AdditionalInstr)
                             .Replace("@ReportsTo", matterSpecialInstructions_CCC.ReportsTo)
                             .Replace("@EditMatterSpecialInvoiceTo_CCCXml", matterSpecialInvoiceTo_CCC.Count() > 0 ? ConvertEditMatterSpecialInvoiceTo(matterSpecialInvoiceTo_CCC) : "");

                sb.AppendLine(csXml);
            }

            sb.AppendLine("</MatterSpecialInstructions_CCC>");

            return sb.ToString();
        }

        private static string ConvertEditMatterSpecialInvoiceTo(List<MatterSpecialInvoiceTo_CCC> matterSpecialInvoiceTo_CCC)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<MatterSpecialInvoiceTo_CCC>");

            int entryCount = 0;
            matterSpecialInvoiceTo_CCC.ForEach(x =>
            {
                if (!string.IsNullOrEmpty(x.MatterSpecialInvoiceToIndex))
                {
                    string csXml = EditMatterSpecialInvoiceTo_CCCXml;
                    csXml = csXml.Replace("@MatterSpecialInvoiceTo_CCCKey", x.MatterSpecialInvoiceToIndex)
                                 .Replace("@InvoiceTo", x.InvoiceTo);

                    sb.AppendLine(csXml);
                    entryCount++;
                }
                else
                {
                    string csXml = AddMatterSpecialInvoiceTo_CCCXml;
                    csXml = csXml.Replace("@InvoiceTo", x.InvoiceTo);

                    sb.AppendLine(csXml);
                    entryCount++;
                }
            });


            sb.AppendLine("</MatterSpecialInvoiceTo_CCC>");

            if (entryCount == 0)
                sb = new StringBuilder();

            return sb.ToString();
        }

        private static string ConvertEditMattBudget(MatterBudget mattBudget)
        {
            string csXml = @"<MattBudget>
							<Edit>
							  <MattBudget KeyValue=""@MattBudgetKey"">
								<Attributes>
								  <!-- <StartDate>@MBStartDate</StartDate> -->
								  <!-- <EndDate>@MBEndDate</EndDate> -->
								  <BudAmount>@BudAmount</BudAmount>
								</Attributes>
							  </MattBudget>
							</Edit>
						  </MattBudget>";

            csXml = csXml.Replace("@MattBudgetKey", mattBudget.MattBudgetIndex);
            //csXml = csXml.Replace("@MBStartDate", DateTime.Now.ToString("yyyy-MM-ddT00:00:00"));
            //csXml = csXml.Replace("@MBEndDate", DateTime.MaxValue.ToString("yyyy-MM-ddT00:00:00"));
            csXml = csXml.Replace("@BudAmount", mattBudget.BudAmount);

            return csXml;
        }

        private static string ConvertEditMattFlatFee(MatterFlatFee matterFlatFee)
        {
            string csXml = @" <MattFlatFee>
								<Edit>
								  <MattFlatFee KeyValue=""@MattFlatFeeKey"">
									<Attributes>
									  <!-- <TimeType>@TimeType</TimeType> -->
									  <!-- <Currency>USD</Currency> -->
									  <!-- <StartDate>@MFStartDate</StartDate> -->
									  <!-- <EndDate>@MFEndDate</EndDate> -->
									  <FlatFeeAmount>@FlatFeeAmount</FlatFeeAmount>
									</Attributes>
								  </MattFlatFee>
								</Edit>
							</MattFlatFee>";

            csXml = csXml.Replace("@MattFlatFeeKey", matterFlatFee.MattFlatFeeIndex);
            csXml = csXml.Replace("@TimeType", matterFlatFee.TimeType);
            //csXml = csXml.Replace("@MFStartDate", DateTime.Now.ToString("yyyy-MM-ddT00:00:00"));
            //csXml = csXml.Replace("@MFEndDate", DateTime.MaxValue.ToString("yyyy-MM-ddT00:00:00"));
            csXml = csXml.Replace("@FlatFeeAmount", matterFlatFee.FlatFeeAmount);

            return csXml;
        }

        private static string ConvertEditCoConsultants(List<CoConsultants_CCC> coConsultants)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<CoConsultants_CCC>");

            int entryCount = 0;
            coConsultants.ForEach(x =>
            {
                if (!string.IsNullOrEmpty(x.CoConsultantIndex))
                {
                    if (x.SvcOp == TE3EEntityFramework.Data.KenticoCMS.RCGKENTCMS.SvcOps.Delete)
                    {
                        string csXml = DeleteCoConsultants_CCCXml;
                        csXml = csXml.Replace("@CoConsultants_CCCKey", x.CoConsultantIndex);

                        sb.AppendLine(csXml);
                        entryCount++;
                    }
                    //string csXml = EditCoConsultants_CCCXml;
                    //csXml = csXml.Replace("@CoConsultants_CCCKey", x.CoConsultantIndex)
                    //			 .Replace("@CoConsultant", x.CoConsultant);

                }
                else
                {
                    string csXml = AddCoConsultants_CCCXml;
                    csXml = csXml.Replace("@CoConsultant", x.CoConsultant);

                    sb.AppendLine(csXml);
                    entryCount++;
                }
            });

            sb.AppendLine("</CoConsultants_CCC>");

            if (entryCount == 0)
                sb = new StringBuilder();

            return sb.ToString();
        }


        private static string ConvertEditMattPayor(MattPayor mattPayor, List<MattPayorDetail> mattPayorDetails)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<MattPayor>");

            if (!string.IsNullOrEmpty(mattPayor.MattPayorIndex))
            {
                string csXml = EditMattPayorXml;
                csXml = csXml.Replace("@MattPayorKey", mattPayor.MattPayorIndex)
                             .Replace("@StartDate", mattPayor.StartDate)
                             .Replace("@CauseNum_CCC", mattPayor.CauseNum_CCC)
                             .Replace("@Court_CCC", mattPayor.Court_CCC.TrimToLength(512))
                             .Replace("@Representing_CCC", mattPayor.Representing_CCC)
                             .Replace("@Style_CCC", mattPayor.Style_CCC.TrimToLength(1000))
                             .Replace("@EditMattPayorDetail", mattPayorDetails.Count() > 0 ? ConvertEditMattPayorDetail(mattPayorDetails) : "");

                sb.AppendLine(csXml);
            }
            else
            {
                string csXml = AddMattPayorXml;
                csXml = csXml.Replace("@StartDate", mattPayor.StartDate)
                             .Replace("@CauseNum_CCC", mattPayor.CauseNum_CCC)
                             .Replace("@Court_CCC", mattPayor.Court_CCC.TrimToLength(512))
                             .Replace("@Representing_CCC", mattPayor.Representing_CCC)
                             .Replace("@Style_CCC", mattPayor.Style_CCC.TrimToLength(1000))
                             .Replace("@EditMattPayorDetail", mattPayorDetails.Count() > 0 ? ConvertEditMattPayorDetail(mattPayorDetails) : "");

                sb.AppendLine(csXml);
            }

            sb.AppendLine("</MattPayor>");

            return sb.ToString();
        }

        private static string ConvertEditMattPayorDetail(List<MattPayorDetail> mattPayorDetails)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<MattPayorDetail>");

            int entryCount = 0;
            mattPayorDetails.ForEach(x =>
            {
                if (!string.IsNullOrEmpty(x.MattPayorDetailIndex))
                {
                    #region delete mode
                    if (x.SvcOp == TE3EEntityFramework.Data.KenticoCMS.RCGKENTCMS.SvcOps.Delete)
                    {
                        string csXml = DeleteMattPayorDetailXml;
                        csXml = csXml.Replace("@MattPayorDetailKey", x.MattPayorDetailIndex);
                        sb.AppendLine(csXml);
                        entryCount++;
                    }
                    #endregion delete mode
                    #region edit mode
                    else if (x.SvcOp == TE3EEntityFramework.Data.KenticoCMS.RCGKENTCMS.SvcOps.Edit)
                    {
                        string csXml = EditMattPayorDetailXml;
                        csXml = csXml.Replace("@MattPayorDetailKey", x.MattPayorDetailIndex)
                                    .Replace("@PctFee", x.PctFee)
                                    .Replace("@CftRole_CCC", x.CftRole_CCC)
                                    .Replace("@CftRelationship_CCC", x.CftRelationship_CCC)
                                    .Replace("@Payor", x.PayorIndex)
                                    .Replace("@Email_CCC", x.Email_CCC)
                                    .Replace("@Contact_CCC", x.Contact_CCC.TrimToLength(64))
                                    .Replace("@PhoneNum_CCC", x.PhoneNum_CCC)
                                    .Replace("@RefNumber", x.RefNumber.TrimToLength(64))
                                    .Replace("@ClaimNum_CCC", x.ClaimNum_CCC.TrimToLength(64))
                                    .Replace("@CorpType_CCC", x.CorpType_CCC)
                                    .Replace("@Title_CCC", x.Title_CCC)
                                    .Replace("@AddtlContactInfo_CCC", x.AddtlContactInfo_CCC)
                                    .Replace("@PONumber_CCC", x.PONumber_CCC.TrimToLength(64))
                                    .Replace("@Policy_CCC", x.Policy_CCC.TrimToLength(64))
                                    .Replace("@UMR_CCC", x.UMR_CCC.TrimToLength(64))
                                    .Replace("@File_CCC", x.File_CCC)
                                    .Replace("@Tracking_CCC", x.Tracking_CCC)
                                    .Replace("@PSite", x.PSite)
                                    .Replace("@IsDefault", x.IsDefault)
                                    .Replace("@StmtSite", x.StmtSite);

                        sb.AppendLine(csXml);
                        entryCount++;
                    }
                    #endregion edit mode

                }
            });

            sb.AppendLine("</MattPayorDetail>");

            if (entryCount == 0)
                sb = new StringBuilder();

            return sb.ToString();
        }

        private static string ConvertEditRelatedParties_CCC(List<RelatedParties_CCC> relatedParties_CCCs)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<RelatedParties_CCC>");

            int entryCount = 0;
            relatedParties_CCCs.ForEach(x =>
            {

                if (!string.IsNullOrEmpty(x.RelatedPartiesIndex))
                {
                    #region delete mode
                    if (x.SvcOp == TE3EEntityFramework.Data.KenticoCMS.RCGKENTCMS.SvcOps.Delete)
                    {
                        string csXml = DeleteModeRelatedParties_CCCXml;
                        csXml = csXml.Replace("@RelatedParties_CCCKey", x.RelatedPartiesIndex);
                        sb.AppendLine(csXml);
                    }
                    entryCount++;
                    #endregion delete mode

                    //#region edit mode
                    //string csXml = EditModeRelatedParties_CCCXml;
                    //csXml = csXml.Replace("@RelatedParties_CCCKey", x.RelatedPartiesIndex)
                    //             .Replace("@RelatedPartiesCftRole", x.RelatedPartiesCftRole)
                    //             .Replace("@RelatedPartiesEntity", x.RelatedPartiesEntity)
                    //             .Replace("@WorkPhone", x.WorkPhone);

                    //sb.AppendLine(csXml);
                    //entryCount++;
                    //#endregion edit mode
                }
                else
                {
                    #region add mode
                    string csXml = AddModeRelatedParties_CCCXml;
                    csXml = csXml.Replace("@RelatedPartiesCftRole", x.RelatedPartiesCftRole)
                                 .Replace("@RelatedPartiesEntity", x.RelatedPartiesEntity)
                                 .Replace("@WorkPhone", x.WorkPhone);

                    sb.AppendLine(csXml);
                    entryCount++;
                    #endregion add mode
                }
            });

            sb.AppendLine("</RelatedParties_CCC>");

            if (entryCount == 0)
                sb = new StringBuilder();

            return sb.ToString();
        }

        private static string ConvertEditMattSite(List<te3eObjects.Automation.MattSite> mattSites)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<MattSite>");

            int entryCount = 0;
            mattSites.ForEach(x =>
            {
                if (!string.IsNullOrEmpty(x.MattSiteIndex))
                {
                    if (x.SvcOp == TE3EEntityFramework.Data.KenticoCMS.RCGKENTCMS.SvcOps.Delete)
                    {
                        string csXml = DeleteMattSiteXml;
                        csXml = csXml.Replace("@MattSiteKey", x.MattSiteIndex);

                        sb.AppendLine(csXml);
                    }
                }
                else
                {
                    string csXml = AddMattSiteXml2;
                    csXml = csXml.Replace("@MSite", x.MSite)
                                 .Replace("@MattSiteType", x.MattSiteType);

                    sb.AppendLine(csXml);
                }

                entryCount++;
            });

            sb.AppendLine("</MattSite>");

            if (entryCount == 0)
                sb = new StringBuilder();

            return sb.ToString();
        }

        private static string ConvertEditMattDate(List<te3eObjects.Automation.MattDate> mattDates)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<MattDate>");

            mattDates.ForEach(x =>
            {
                if (!string.IsNullOrEmpty(x.MattDateIndex))
                {
                    string csXml = EditMattDateXml;
                    csXml = csXml.Replace("@MattDateKey", x.MattDateIndex)
                                .Replace("@EffStart", x.EffStart)
                                .Replace("@NxStartDate", x.NxStartDate)
                                .Replace("@PracticeGroup", x.PracticeGroup)
                                .Replace("@Department", x.Department)
                                .Replace("@Section", x.Section)
                                .Replace("@Arrangement", x.Arrangement)
                                .Replace("@PTAGroup", x.PTAGroup)
                                .Replace("@BillTkpr", x.BillTkpr)
                                .Replace("@RspTkpr", x.RspTkpr)
                                .Replace("@SpvTkpr", x.SpvTkpr)
                                .Replace("@Office", x.Office)
                                .Replace("@SubSection_CCC", x.SubSection_CCC);

                    sb.AppendLine(csXml);
                }
                else
                {
                    string csXml = AddMattDateXml;
                    csXml = csXml.Replace("@EffStart", x.EffStart)
                                .Replace("@NxStartDate", x.NxStartDate)
                                .Replace("@PracticeGroup", x.PracticeGroup)
                                .Replace("@Department", x.Department)
                                .Replace("@Section", x.Section)
                                .Replace("@Arrangement", x.Arrangement)
                                .Replace("@PTAGroup", x.PTAGroup)
                                .Replace("@BillTkpr", x.BillTkpr)
                                .Replace("@RspTkpr", x.RspTkpr)
                                .Replace("@SpvTkpr", x.SpvTkpr)
                                .Replace("@Office", x.Office)
                                .Replace("@SubSection_CCC", x.SubSection_CCC);
                }
            });

            sb.AppendLine("</MattDate>");

            return sb.ToString();
        }

        private static string ConvertEditMattRate(TE3EConnect.te3eObjects.Automation.MatterRate matterRate)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<MattRate>");

            if (!string.IsNullOrEmpty(matterRate.MattRateIndex))
            {
                string csXml = EditMattRateXml;
                csXml = csXml.Replace("@MattRateKey", matterRate.MattRateIndex)
                             .Replace("@MattRate", matterRate.MattRate);

                sb.AppendLine(csXml);
            }
            else
            {
                matterRate.IsActive = "1";
                string csXml = AddMattRateXml;
                csXml = csXml.Replace("@MattRate", matterRate.MattRate)
                             .Replace("@IsActive", matterRate.IsActive);

                sb.AppendLine(csXml);
            }

            sb.AppendLine("</MattRate>");

            return sb.ToString();
        }

        private static string ConvertEditMattRateExc(TE3EConnect.te3eObjects.Automation.MatterRateExc matterRateExc)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<MatterRateExc>");

            if (!string.IsNullOrEmpty(matterRateExc.MattRateExcIndex))
            {
                string csXml = EditMattRateExcXml;
                csXml = csXml.Replace("@MatterRateExcKey", matterRateExc.MattRateExcIndex)
                             .Replace("@MatterRateExc", matterRateExc.MattRateExc);

                sb.AppendLine(csXml);
            }
            else
            {
                string csXml = AddMattRateExcXml;
                csXml = csXml.Replace("@MattRateExc", matterRateExc.MattRateExc);

                sb.AppendLine(csXml);
            }

            sb.AppendLine("</MatterRateExc>");

            return sb.ToString();
        }

        private static string EditMattDateXml = @"
	
        <Edit>
			<MattDate KeyValue=""@MattDateKey"">
				<Attributes>
					<EffStart>@EffStart</EffStart>
					<!-- <PracticeGroup>Undefined</PracticeGroup> -->
					<PracticeGroup>@PracticeGroup</PracticeGroup>
					<!-- <Department>000</Department> -->
					<Department>@Department</Department>
					<!-- <Section>000</Section> -->
					<Section>@Section</Section>
					<SubSection_CCC>@SubSection_CCC</SubSection_CCC>
					<!-- <Arrangement>100</Arrangement> -->
					<Arrangement>@Arrangement</Arrangement>
					<!-- <PTAGroup>Default</PTAGroup> -->
					<PTAGroup>@PTAGroup</PTAGroup>
					<NxStartDate>@NxStartDate</NxStartDate>
					<BillTkpr>@BillTkpr</BillTkpr>
					<RspTkpr>@RspTkpr</RspTkpr>
					<SpvTkpr>@SpvTkpr</SpvTkpr>
					<Office>@Office</Office>
				</Attributes>
			</MattDate>
		</Edit>
	
";

        private static string EditMattSiteXml = @"
	
        <Edit>
			<MattSite KeyValue=""@MattSiteKey"">
				<Attributes>
					<Site>@MSite</Site>
					<MattSiteType>@MattSiteType</MattSiteType>
				</Attributes>
			</MattSite>
		</Edit>
	
";

        private static string DeleteMattSiteXml = @"
	
        <Delete>
			<MattSite KeyValue=""@MattSiteKey""></MattSite>
		</Delete>
	
";

        private static string AddMattSiteXml2 = @"
	
        <Add>
			<MattSite>
				<Attributes>
					<Site>@MSite</Site>
					<MattSiteType>@MattSiteType</MattSiteType>
				</Attributes>
			</MattSite>
		</Add>
	
";

        private static string EditMattPayorXml = @"
        
			<!-- Payor should be related to the matter client -->
            <Edit>
				<MattPayor KeyValue=""@MattPayorKey"">
					<Attributes>
						<StartDate>@StartDate</StartDate>
						 <CauseNum_CCC>@CauseNum_CCC</CauseNum_CCC>
						 <Court_CCC>@Court_CCC</Court_CCC>
						 <Representing_CCC>@Representing_CCC</Representing_CCC>
						 <Style_CCC>@Style_CCC</Style_CCC>
					</Attributes>
					<Children>
						<!-- <MattPayorDetail> -->
							@EditMattPayorDetail
						<!-- </MattPayorDetail> -->
					</Children>
				</MattPayor>
			</Edit>
";

        private static string AddMattPayorXml = @"
        
			<!-- Payor should be related to the matter client -->
            <Add>
				<MattPayor>
					<Attributes>
						<StartDate>@StartDate</StartDate>
						 <CauseNum_CCC>@CauseNum_CCC</CauseNum_CCC>
						 <Court_CCC>@Court_CCC</Court_CCC>
						 <Representing_CCC>@Representing_CCC</Representing_CCC>
						 <Style_CCC>@Style_CCC</Style_CCC>
					</Attributes>
					<Children>
						<!-- <MattPayorDetail> -->
							@EditMattPayorDetail
						<!-- </MattPayorDetail> -->
					</Children>
				</MattPayor>
			</Add>
";

        private static string EditMattPayorDetailXml = @"
        <Edit>
			<MattPayorDetail KeyValue=""@MattPayorDetailKey"">
				<Attributes>
					<IsDefault>@IsDefault</IsDefault>
					<!-- only one payor can have default specification -->
					<PctFee>@PctFee</PctFee>
					<!-- total of all payors must be 1 for percent fields -->
					<PctHCo>@PctFee</PctHCo>
					<PctSCo>@PctFee</PctSCo>
					<PctTax>@PctFee</PctTax>
					<PctInt>@PctFee</PctInt>
					<PctBOA>@PctFee</PctBOA>
					<PctOth>@PctFee</PctOth>
					<CftRole_CCC>@CftRole_CCC</CftRole_CCC>
					<CftRelationship_CCC>@CftRelationship_CCC</CftRelationship_CCC>
					<Payor>@Payor</Payor>
					<Email_CCC>@Email_CCC</Email_CCC>
					<Contact_CCC>@Contact_CCC</Contact_CCC>
					<PhoneNum_CCC>@PhoneNum_CCC</PhoneNum_CCC>
					<RefNumber>@RefNumber</RefNumber>
					<ClaimNum_CCC>@ClaimNum_CCC</ClaimNum_CCC>
					<CorpType_CCC>@CorpType_CCC</CorpType_CCC>
					<Title_CCC>@Title_CCC</Title_CCC>
					<AddtlContactInfo_CCC>@AddtlContactInfo_CCC</AddtlContactInfo_CCC>
					<PONumber_CCC>@PONumber_CCC</PONumber_CCC>
					<!--<Policy_CCC>@Policy_CCC</Policy_CCC>
					<UMR_CCC>@UMR_CCC</UMR_CCC>
					<File_CCC>@File_CCC</File_CCC>
					<Tracking_CCC>@Tracking_CCC</Tracking_CCC> -->
					<Site>@PSite</Site>
					<!-- Site must be related to payor (client) entity -->
					<StmtSite>@StmtSite</StmtSite>
				</Attributes>
			</MattPayorDetail>
		</Edit>
";

        private static string DeleteMattPayorDetailXml = @"
        <Delete>
			<MattPayorDetail KeyValue=""@MattPayorDetailKey""></MattPayorDetail>
		</Delete>
";

        private static string EditModeRelatedParties_CCCXml = @"
        <Edit>
			<RelatedParties_CCC KeyValue=""@RelatedParties_CCCKey"">
				<Attributes>
					<CftRole>@RelatedPartiesCftRole</CftRole>
					<Entity>@RelatedPartiesEntity</Entity>
                    <WorkPhone>@WorkPhone</WorkPhone>
				</Attributes>
			</RelatedParties_CCC>
		</Edit>
";

        private static string DeleteModeRelatedParties_CCCXml = @"
        <Delete>
			<RelatedParties_CCC KeyValue=""@RelatedParties_CCCKey""></RelatedParties_CCC>
		</Delete>
";

        private static string AddModeRelatedParties_CCCXml = @"
        <Add>
			<RelatedParties_CCC>
				<Attributes>
					<CftRole>@RelatedPartiesCftRole</CftRole>
					<Entity>@RelatedPartiesEntity</Entity>
				</Attributes>
			</RelatedParties_CCC>
		</Add>
";

        private static string EditCoConsultants_CCCXml = @"
			<Edit>
                <CoConsultants_CCC KeyValue=""@CoConsultants_CCCKey"">
                    <Attributes>
                        <CoConsultant>@CoConsultant</CoConsultant>
                    </Attributes>
                </CoConsultants_CCC>
            </Edit>
			";

        private static string DeleteCoConsultants_CCCXml = @"
			<Delete>
                <CoConsultants_CCC KeyValue=""@CoConsultants_CCCKey""></CoConsultants_CCC>
            </Delete>
			";

        private static string EditMattRateXml = @"
		
            <Edit>
				<MattRate KeyValue=""@MattRateKey"">
					<Attributes>
						<Rate>@MattRate</Rate> <!--DNU-->
						<!--<IsActive>1</IsActive>-->
					</Attributes>
				</MattRate>
			</Edit>
";

        private static string AddMattRateXml = @"
		
            <Add>
				<MattRate>
					<Attributes>
						<Rate>@MattRate</Rate> <!--DNU-->
						<IsActive>@IsActive</IsActive>
					</Attributes>
				</MattRate>
			</Add>
		
";

        private static string EditMattRateExcXml = @"
		
            <Edit>
				<MatterRateExc KeyValue=""@MatterRateExcKey"">
					<Attributes>
						<RateExc>@MatterRateExc</RateExc> <!-- 561AD9FC-78B8-432B-9816-EE3F864BFD20-->
					</Attributes>
				</MatterRateExc>
			</Edit>
		
";

        private static string AddMattRateExcXml = @"
		
            <Add>
				<MatterRateExc>
					<Attributes>
						<RateExc>@MatterRateExc</RateExc> <!-- 561AD9FC-78B8-432B-9816-EE3F864BFD20-->
					</Attributes>
				</MatterRateExc>
			</Add>
		
";

        private static string EditMatterSpecialInstructions_CCCXml = @"

            <Edit>
				<MatterSpecialInstructions_CCC KeyValue=""@MatterSpecialInstructions_CCCKey"">
					<Attributes>
						<!--<Client>@MSClient</Client>-->
						<ClientInstr>@ClientInstruction</ClientInstr>
						<!--<StartDate>@MSStartDate</StartDate>-->
						<!--<EffDate>@MSEffDate</EffDate>-->
						<ReportsTo>@ReportsTo</ReportsTo>
						<AdditionalInstr>@AdditionalInstr</AdditionalInstr>
					</Attributes>
					<Children>
						@EditMatterSpecialInvoiceTo_CCCXml
					</Children>
				</MatterSpecialInstructions_CCC>
			</Edit>
";
        private static string AddMatterSpecialInstructions_CCCXml = @"
		
            <Add>
				<MatterSpecialInstructions_CCC>
					<Attributes>
						<!--<Client>@MSClient</Client>-->
						<ClientInstr>@ClientInstruction</ClientInstr>
						<!--<StartDate>@MSStartDate</StartDate>-->
						<!--<EffDate>@MSEffDate</EffDate>-->
						<ReportsTo>@ReportsTo</ReportsTo>
						<AdditionalInstr>@AdditionalInstr</AdditionalInstr>
					</Attributes>
					<Children>
						@EditMatterSpecialInvoiceTo_CCCXml
					</Children>
				</MatterSpecialInstructions_CCC>
			</Add>
";

        private static string EditMatterSpecialInvoiceTo_CCCXml = @"
		<Edit>
			<MatterSpecialInvoiceTo_CCC KeyValue=""@MatterSpecialInvoiceTo_CCCKey"">
				<Attributes>
					<InvoiceTo>@InvoiceTo</InvoiceTo>
				</Attributes>
			</MatterSpecialInvoiceTo_CCC>
		</Edit>
";
        #endregion Edit Section


    }
}
