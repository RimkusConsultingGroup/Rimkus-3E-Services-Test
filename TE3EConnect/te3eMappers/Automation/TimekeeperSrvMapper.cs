using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TE3EConnect.te3eObjects.Automation;

namespace TE3EConnect.te3eMappers.Automation
{
    internal class TimekeeperSrvMapper
    {
        public static string ConvertTimekeeperSrvToXml(TimekeeperSrv timekeeperSrv, e3eMode e3EMode, bool forceEditDisplayAndBillName = false)
        {
            string csXml = "";
            string strTemplate = "TimekeeperSrv.xml";
            
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetCallingAssembly().Location), "te3eXML", "Automation",strTemplate);
            using (var objStreamReader = File.OpenText(path))
            {
                csXml = objStreamReader.ReadToEnd();
                csXml = csXml.Replace("@AddTimekeeper", e3EMode == e3eMode.Add ? ConvertAddTimekeeper(timekeeperSrv) : ConvertEditTimekeeper(timekeeperSrv, forceEditDisplayAndBillName));

            }

            return csXml;
        }
        
        #region add timekeeper conversion
        private static string ConvertAddTimekeeper(TimekeeperSrv timekeeperSrv)
        {
            StringBuilder sb = new StringBuilder();

            string csXml = AddTimekeeperXml;
            csXml = csXml.Replace("@Number", timekeeperSrv.timekeeper.Number)
                         .Replace("@BillInitial", timekeeperSrv.timekeeper.BillInitial)
                         .Replace("@DisplayName", timekeeperSrv.timekeeper.DisplayName)
                         .Replace("@BillName", timekeeperSrv.timekeeper.BillName)
                         .Replace("@TkprStatusCode", timekeeperSrv.timekeeper.TkprStatusCode)
                         .Replace("@SortName", timekeeperSrv.timekeeper.SortName)
                         .Replace("@EntityID", timekeeperSrv.timekeeper.EntityID.ToString())
                         .Replace("@PayrollNumber", timekeeperSrv.timekeeper.PayrollNumber)
                         .Replace("@HRNumber", timekeeperSrv.timekeeper.HRNumber)
                         .Replace("@HRTitle", timekeeperSrv.timekeeper.HRTitle)
                         .Replace("@PhysicalLocation", timekeeperSrv.timekeeper.PhysicalLocation)
                         .Replace("@Narrative", timekeeperSrv.timekeeper.Narrative)
                         .Replace("@TkprType", timekeeperSrv.timekeeper.TkprType)

                         //TkprDate
                         .Replace("@EffStart", timekeeperSrv.tkprDate.EffStart)
                         .Replace("@Office", timekeeperSrv.tkprDate.Office)
                         .Replace("@Department", timekeeperSrv.tkprDate.Department)
                         .Replace("@Section", timekeeperSrv.tkprDate.Section)
                         .Replace("@HireDate", timekeeperSrv.tkprDate.HireDate)
                         .Replace("@TermDate", timekeeperSrv.tkprDate.TermDate)
                         .Replace("@Title", timekeeperSrv.tkprDate.Title)
                         .Replace("@RateClass", timekeeperSrv.tkprDate.RateClass)
                         .Replace("@WorkCalendar", timekeeperSrv.tkprDate.WorkCalendar)
                         .Replace("@WorkType", timekeeperSrv.tkprDate.WorkType)
                         .Replace("@NxStartDate", timekeeperSrv.tkprDate.NxStartDate)
                         .Replace("@SupTkpr", timekeeperSrv.tkprDate.SupTkpr)
                         .Replace("@NxUnit", timekeeperSrv.tkprDate.NxUnit)

                         //TkprRate
                         .Replace("@RateType", timekeeperSrv.tkprRate.RateType)
                         .Replace("@Currency", timekeeperSrv.tkprRate.Currency)
                         .Replace("@DefaultRate", timekeeperSrv.tkprRate.DefaultRate)
                         .Replace("@EffStart", timekeeperSrv.tkprRate.EffStart)
                         .Replace("@NxStartDate", timekeeperSrv.tkprRate.NxStartDate)

                         //TkprAccreditation
                         .Replace("@TkprAccreditation", timekeeperSrv.tkprAccreditations.Count() > 0 ? ConvertAddTkprAccreditation(timekeeperSrv.tkprAccreditations) : "");

            sb.AppendLine(csXml);

            return sb.ToString();
        }

        private static string ConvertAddEditTkprDate(TkprDate tkprDate)
        {
            StringBuilder sb = new StringBuilder();
            
            if (tkprDate.SvcOps == TE3EEntityFramework.Data.KenticoCMS.RCGKENTCMS.SvcOps.Add)
            {
                string csXml = AddTkprDateXml;
                csXml = csXml.Replace("@EffStart", tkprDate.EffStart)
                         .Replace("@Office", tkprDate.Office)
                         .Replace("@Department", tkprDate.Department)
                         .Replace("@Section", tkprDate.Section)
                         .Replace("@HireDate", tkprDate.HireDate)
                         .Replace("@TermDate", tkprDate.TermDate)
                         .Replace("@Title", tkprDate.Title)
                         .Replace("@RateClass", tkprDate.RateClass)
                         .Replace("@WorkCalendar", tkprDate.WorkCalendar)
                         .Replace("@WorkType", tkprDate.WorkType)
                         .Replace("@NxStartDate", tkprDate.NxStartDate)
                         .Replace("@SupTkpr", tkprDate.SupTkpr)
                         .Replace("@NxUnit", tkprDate.NxUnit);

                sb.AppendLine(csXml);
            }
            else if (tkprDate.SvcOps == TE3EEntityFramework.Data.KenticoCMS.RCGKENTCMS.SvcOps.Edit)
            {
                string csXml = EditTkprDateXml;
                csXml = csXml.Replace("@TkprDateIdx", tkprDate.TkprDateID)
                         .Replace("@Office", tkprDate.Office)
                         .Replace("@HireDate", tkprDate.HireDate)
                         .Replace("@TermDate", tkprDate.TermDate)
                         .Replace("@Title", tkprDate.Title)
                         .Replace("@RateClass", tkprDate.RateClass)
                         .Replace("@WorkCalendar", tkprDate.WorkCalendar);

                sb.AppendLine(csXml);
            }

            return sb.ToString();
        }

        private static string ConvertAddTkprAccreditation(List<TkprAccreditation> tkprAccreditations)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<TkprAccreditation>");

            tkprAccreditations.ForEach(x =>
            {
                string csXml = AddTkprAccreditationXml;
                csXml = csXml.Replace("@Location", x.Location)
                             .Replace("@AccrType", x.AccrType) //blank
                             .Replace("@AccrDate", x.AccrDate) //expiration date
                             .Replace("@CertificateNumber", x.CertificateNumber)
                             .Replace("@Country", x.Country)
                             .Replace("@LicenseType_CCC", x.LicenseType_CCC)
                             .Replace("@State", x.State)
                             .Replace("@IsActive_CCC", x.IsActive_CCC);

                sb.AppendLine(csXml);
            });

            sb.AppendLine("</TkprAccreditation>");

            if (tkprAccreditations.Count() == 0)
                sb = new StringBuilder();

            return sb.ToString();
        }

        private static string ConvertAddEditTkprAccreditation(List<TkprAccreditation> tkprAccreditations)
        {
            StringBuilder sb = new StringBuilder();

            if(tkprAccreditations.Count() > 0)
            {
                sb.AppendLine("<TkprAccreditation>");

                tkprAccreditations.ForEach(x =>
                {
                    if (x.SvcOps == TE3EEntityFramework.Data.KenticoCMS.RCGKENTCMS.SvcOps.Add)
                    {
                        string csXml = AddTkprAccreditationXml;
                        csXml = csXml.Replace("@AccrDate", x.AccrDate) //expiration date
                                     .Replace("@CertificateNumber", x.CertificateNumber)
                                     .Replace("@Country", x.Country)
                                     .Replace("@LicenseType_CCC", x.LicenseType_CCC)
                                     .Replace("@State", x.State)
                                     .Replace("@IsActive_CCC", x.IsActive_CCC);

                        sb.AppendLine(csXml);
                    }
                    else if (x.SvcOps == TE3EEntityFramework.Data.KenticoCMS.RCGKENTCMS.SvcOps.Edit)
                    {
                        string csXml = EditTkprAccreditationXml;
                        csXml = csXml.Replace("@TkprAccreditationIdx", x.TkprAccreditationIdx)
                                     .Replace("@AccrDate", x.AccrDate) //expiration date
                                     .Replace("@CertificateNumber", x.CertificateNumber)
                                     .Replace("@Country", x.Country)
                                     .Replace("@LicenseType_CCC", x.LicenseType_CCC)
                                     .Replace("@State", x.State);

                        sb.AppendLine(csXml);
                    }

                });

                sb.AppendLine("</TkprAccreditation>");
            }

            return sb.ToString();
        }
        #endregion add timekeeper conversion

        #region add timkeeper xml

        private static string AddTimekeeperXml = @"

        <Add>
            <Timekeeper>
                <Attributes>
                    <Number>@Number</Number>
                    <AltNumber>@BillInitial</AltNumber>
                    <DisplayName>@DisplayName</DisplayName>
                    <BillName>@BillName</BillName>
                    <BillInitial>@BillInitial</BillInitial>
					<TkprStatus>@TkprStatusCode</TkprStatus>
                    <SortName>@SortName</SortName>
                    <GLTimekeeper />
					<Entity>@EntityID</Entity>
                    <PayrollNumber>@PayrollNumber</PayrollNumber>
                    <HRNumber>@HRNumber</HRNumber>
                    <HRTitle>@HRTitle</HRTitle>
                    <PhysicalLocation>@PhysicalLocation</PhysicalLocation>
                    <Narrative>@Narrative</Narrative>
                    <Language />
                    <JDDate></JDDate>
                    <CompDate></CompDate>
                    <IsAutoNumbering>0</IsAutoNumbering>
					<TkprType>@TkprType</TkprType> <!--Discipline-->
                    <TkprAttribute />
                    <TkprCategory />
                    <ProfDCSTemplate />
                    <BillDCSTemplate />
                    <StmtDCSTemplate />
                    <IsNumberEnabled>0</IsNumberEnabled>
                    <RateYear></RateYear>
                    <CreditNoteDCSTemplate />
                    <BillGroupDCSTemplate />
                    <CreditNoteGroupDCSTemplate />
                    <WF_User />
                </Attributes>
                <Children>
                    <TkprDate>
                        <Add>
                            <TkprDate>
                                <Attributes>
                                    <EffStart>@EffStart</EffStart>
									<Office>@Office</Office>
									<Department>@Department</Department>
									<Section>@Section</Section>
                                    <HireDate>@HireDate</HireDate>
                                    <TermDate>@TermDate</TermDate>
									<Title>@Title</Title>
									<RateClass>@RateClass</RateClass>
									<WorkCalendar>@WorkCalendar</WorkCalendar>
                                    <SupTkpr>@SupTkpr</SupTkpr>
                                    <NxUnit>@NxUnit</NxUnit>
									<WorkType>@WorkType</WorkType>
                                    <IsFireValidation>1</IsFireValidation>
                                    <BillingCoordinator />
                                    <NxStartDate>@NxStartDate</NxStartDate>
                                </Attributes>
                            </TkprDate>
                        </Add>
                    </TkprDate>
                    <!--<TkprSchool>
                        <Add>
                            <TkprSchool>
                                <Attributes>
                                    <School>NewValue</School>
                                    <IsGraduated>1</IsGraduated>
                                    <GradDate>0001-01-02T00:00:00</GradDate>
                                    <Degree>NewValue</Degree>
                                    <Specialty>NewValue</Specialty>
                                </Attributes>
                            </TkprSchool>
                        </Add>
                    </TkprSchool>-->
                    @TkprAccreditation
                    <!--<TkprPracticeGroup>
                        <Add>
                            <TkprPracticeGroup>
                                <Attributes>
                                    <PracticeGroup />
                                    <Percentage>1</Percentage>
                                </Attributes>
                            </TkprPracticeGroup>
                        </Add>
                    </TkprPracticeGroup>
                    <TimekeepTeams>
                        <Add>
                            <TimekeepTeams>
                                <Attributes>
                                    <TkprTeam />
                                    <Percentage>1</Percentage>
                                </Attributes>
                            </TimekeepTeams>
                        </Add>
                    </TimekeepTeams>
                    <TkprGLNatural>
                        <Add>
                            <TkprGLNatural>
                                <Attributes>
                                    <GLNatural1 />
                                    <GLNatural2 />
                                    <GLNatural3 />
                                </Attributes>
                            </TkprGLNatural>
                        </Add>
                    </TkprGLNatural>
                    <TkprDateFTE>
                        <Add>
                            <TkprDateFTE>
                                <Attributes>
                                    <EffStart>0001-01-02T00:00:00</EffStart>
                                    <FTEStatus />
                                    <FTEPercent>1</FTEPercent>
                                    <ActualHeadCountFactor>1</ActualHeadCountFactor>
                                    <ProdHeadCountFactor>1</ProdHeadCountFactor>
                                    <NxStartDate>0001-01-02T00:00:00</NxStartDate>
                                </Attributes>
                            </TkprDateFTE>
                        </Add>
                    </TkprDateFTE>
                    <TkprDateHR>
                        <Add>
                            <TkprDateHR>
                                <Attributes>
                                    <EffStart>0001-01-02T00:00:00</EffStart>
                                    <Currency />
                                    <Salary>1</Salary>
                                    <Benefits>1</Benefits>
                                    <DirectCost>1</DirectCost>
                                    <InDirectCost>1</InDirectCost>
                                    <OverheadAlloc>1</OverheadAlloc>
                                    <NxStartDate>0001-01-02T00:00:00</NxStartDate>
                                </Attributes>
                            </TkprDateHR>
                        </Add>
                    </TkprDateHR>-->
                    <TkprRate>
                        <Add>
                            <TkprRate>
                                <Attributes>
									<RateType>@RateType</RateType>
                                </Attributes>
                                <Children>
                                    <TkprRateDate>
                                        <Add>
                                            <TkprRateDate>
                                                <Attributes>
													<Currency>@Currency</Currency>
                                                    <DefaultRate>@DefaultRate</DefaultRate> <!--1-->
                                                    <EffStart>@EffStart</EffStart>
                                                    <CurrencyLookBackDate></CurrencyLookBackDate>
                                                    <NxStartDate>@NxStartDate</NxStartDate>
                                                </Attributes>
                                                <!--<Children>
                                                    <TkprRateDateDet_1>
                                                        <Add>
                                                            <TkprRateDateDet_1>
                                                                <Attributes>
                                                                    <Currency />
                                                                    <Office />
                                                                    <Rate>1</Rate>
                                                                    <CurrDate>0001-01-02T00:00:00</CurrDate>
                                                                </Attributes>
                                                            </TkprRateDateDet_1>
                                                        </Add>
                                                    </TkprRateDateDet_1>
                                                </Children>-->
                                            </TkprRateDate>
                                        </Add>
                                    </TkprRateDate>
                                </Children>
                            </TkprRate>
                        </Add>
                    </TkprRate>
                    <!--<MaskOverrideValues>
                        <Add>
                            <MaskOverrideValues>
                                <Attributes>
                                    <CostType />
                                    <ChrgType />
                                    <TimeType />
                                    <Client />
                                    <Matter />
                                    <GLNatural />
                                    <GLUnit />
                                    <GLOffice />
                                    <GLTimekeeper />
                                    <GLDepartment />
                                    <GLSection />
                                    <GLArrangement />
                                    <GLTitle />
                                    <GLPracticeGroup />
                                    <GLWorkType />
                                    <MaskOverrideType />
                                    <ChrgTypePredicate>NewValue</ChrgTypePredicate>
                                    <ClientPredicate>NewValue</ClientPredicate>
                                    <CostTypePredicate>NewValue</CostTypePredicate>
                                    <MatterPredicate>NewValue</MatterPredicate>
                                    <TimekeeperPredicate>NewValue</TimekeeperPredicate>
                                    <TimeTypePredicate>NewValue</TimeTypePredicate>
                                    <UsingChrgType>1</UsingChrgType>
                                    <UsingClient>1</UsingClient>
                                    <UsingCostType>1</UsingCostType>
                                    <UsingMatter>1</UsingMatter>
                                    <UsingTimekeeper>1</UsingTimekeeper>
                                    <UsingTimeType>1</UsingTimeType>
                                    <GLActivity />
                                </Attributes>
                            </MaskOverrideValues>
                        </Add>
                    </MaskOverrideValues>-->
                    <!--<TkprObjective>
                        <Add>
                            <TkprObjective>
                                <Attributes>
                                    <IsDefault>1</IsDefault>
                                    <MxObjective />
                                </Attributes>
                            </TkprObjective>
                        </Add>
                    </TkprObjective>-->
                </Children>
            </Timekeeper>
        </Add>
";

        #endregion add timekeeper xml

        #region add tkpr accreditation xml
        private static string AddTkprAccreditationXml = @"
        <Add>
            <TkprAccreditation>
                <Attributes>
                    
                    <AccrDate>@AccrDate</AccrDate>
                    <CertificateNumber>@CertificateNumber</CertificateNumber>
					<Country>@Country</Country>
					<LicenseType_CCC>@LicenseType_CCC</LicenseType_CCC>
					<State>@State</State>
                    <IsActive_CCC>@IsActive_CCC</IsActive_CCC>
                </Attributes>
            </TkprAccreditation>
        </Add>
";
        #endregion add tkpr accreditation xml

        #region edit timekeeper conversion
        private static string ConvertEditTimekeeper(TimekeeperSrv timekeeperSrv, bool forceEditDisplayAndBillName = false)
        {
            StringBuilder sb = new StringBuilder();

            string csXml = !forceEditDisplayAndBillName ? EditTimekeeperXml : EditTimekeeperWithDisplayBillNameXml;
            csXml = csXml.Replace("@TkprIndex", timekeeperSrv.timekeeper.TkprIndex.ToString())
                         .Replace("@TkprType", timekeeperSrv.timekeeper.TkprType)
                         .Replace("@TkprStatusCode", timekeeperSrv.timekeeper.TkprStatusCode)
                         .Replace("@DisplayName", timekeeperSrv.timekeeper.DisplayName)
                         .Replace("@BillName", timekeeperSrv.timekeeper.BillName);

                         
            if(!forceEditDisplayAndBillName)
            {
                //TkprDate
                csXml = csXml.Replace("@TkprDate", timekeeperSrv.tkprDate != null ? ConvertAddEditTkprDate(timekeeperSrv.tkprDate) : "")

                //TkprAccreditation
                .Replace("@TkprAccreditation", timekeeperSrv.tkprAccreditations.Count() > 0 ? ConvertAddEditTkprAccreditation(timekeeperSrv.tkprAccreditations) : "");

            }

            sb.AppendLine(csXml);

            return sb.ToString();
        }

        private static string ConvertEditTkprAccreditation(List<TkprAccreditation> tkprAccreditations)
        {
            StringBuilder sb = new StringBuilder();

            tkprAccreditations.ForEach(x =>
            {
                string csXml = EditTkprAccreditationXml;
                csXml = csXml.Replace("@TkprAccreditationIdx", x.TkprAccreditationIdx)
                             .Replace("@Location", x.Location)
                             .Replace("@AccrType", x.AccrType) //blank
                             .Replace("@AccrDate", x.AccrDate) //expiration date
                             .Replace("@CertificateNumber", x.CertificateNumber)
                             .Replace("@Country", x.Country)
                             .Replace("@LicenseType_CCC", x.LicenseType_CCC)
                             .Replace("@State", x.State)
                             .Replace("@IsActive_CCC", x.IsActive_CCC);

                sb.AppendLine(csXml);
            });

            return sb.ToString();
        }

        #endregion edit timekeeper conversion

        #region edit timekeeper xml
        private static string EditTimekeeperXml = @"

        <Edit>
          <Timekeeper KeyValue=""@TkprIndex"">
           <Attributes>
              <TkprType>@TkprType</TkprType> <!--Discipline-->
              <TkprStatus>@TkprStatusCode</TkprStatus>
              <!--<DisplayName>@DisplayName</DisplayName>
               <BillName>@BillName</BillName>-->
            </Attributes>
            <Children>
              <!--@TkprDate
              @TkprAccreditation-->
            </Children>
          </Timekeeper>
        </Edit>
";

        private static string EditTimekeeperWithDisplayBillNameXml = @"

        <Edit>
          <Timekeeper KeyValue=""@TkprIndex"">
           <Attributes>
              <DisplayName>@DisplayName</DisplayName>
              <BillName>@BillName</BillName>
            </Attributes>
          </Timekeeper>
        </Edit>
";
        #endregion edit timekeeper xml

        #region edit tkpr accreditation xml
        private static string AddTkprDateXml = @"
                     <TkprDate>
                        <Add>
                            <TkprDate>
                                <Attributes>
                                    <EffStart>@EffStart</EffStart>
									<Office>@Office</Office>
									<Department>@Department</Department>
									<Section>@Section</Section>
                                    <HireDate>@HireDate</HireDate>
                                    <TermDate>@TermDate</TermDate>
									<Title>@Title</Title>
									<RateClass>@RateClass</RateClass>
									<WorkCalendar>@WorkCalendar</WorkCalendar>
                                    <SupTkpr>@SupTkpr</SupTkpr>
                                    <NxUnit>@NxUnit</NxUnit>
									<WorkType>@WorkType</WorkType>
                                    <IsFireValidation>1</IsFireValidation>
                                    <BillingCoordinator />
                                    <NxStartDate>@NxStartDate</NxStartDate>
                                </Attributes>
                            </TkprDate>
                        </Add>
                    </TkprDate>
";

        private static string EditTkprDateXml = @"
                    <TkprDate>
                        <Edit>
                            <TkprDate KeyValue=""@TkprDateIdx"">
                                <Attributes>
                                    <Office>@Office</Office>
                                    <HireDate>@HireDate</HireDate>
                                    <TermDate>@TermDate</TermDate>
									<Title>@Title</Title>
									<WorkCalendar>@WorkCalendar</WorkCalendar>
                                    <!--<RateClass>@RateClass</RateClass>-->
                                </Attributes>
                            </TkprDate>
                        </Edit>
                    </TkprDate>";

        private static string EditTkprAccreditationXml = @"
            <Edit>
                <TkprAccreditation KeyValue=""@TkprAccreditationIdx"">
                <Attributes>
                    <AccrDate>@AccrDate</AccrDate>
                    <CertificateNumber>@CertificateNumber</CertificateNumber>
					<Country>@Country</Country>
					<LicenseType_CCC>@LicenseType_CCC</LicenseType_CCC>
					<State>@State</State>
                </Attributes>
                </TkprAccreditation>
            </Edit>
";
        #endregion edit tkpr accreditation xml
    }
}
