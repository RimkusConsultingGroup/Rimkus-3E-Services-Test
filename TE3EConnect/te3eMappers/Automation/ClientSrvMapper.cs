using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TE3EConnect.extension;
using TE3EConnect.te3eObjects.Automation;

namespace TE3EConnect.te3eMappers.Automation
{
    internal class ClientSrvMapper
    {
        public static string ConvertClientSrvToXml(List<ClientSrv> clientSrvs, e3eMode e3EMode)
        {
            string csXml = "";
            string strTemplate = "ClientSrv.xml";

            using (var objStreamReader = File.OpenText(Path.Combine(Path.GetDirectoryName(Assembly.GetCallingAssembly().Location), $"te3eXML/Automation/{strTemplate}")))
            {
                csXml = objStreamReader.ReadToEnd();
                csXml = csXml.Replace("@AddClientShortEntry", e3EMode == e3eMode.Add ? ConvertAddClientShortEntry(clientSrvs) : ConvertEditClientShortEntry(clientSrvs));
            }

            return csXml;
        }

        #region add client short entry conversion
        private static string ConvertAddClientShortEntry(List<ClientSrv> clientSrvs)
        {
            StringBuilder sb = new StringBuilder();

            clientSrvs.ForEach(x =>
            {
                string csXml = AddClientShortEntryXml;
                csXml = csXml.Replace("@Entity", x.Entity)
                            .Replace("@CliType", x.CliType)
                            .Replace("@CliStatusType", x.CliStatusType)
                            .Replace("@CliStatusDate", x.CliStatusDate)
                            .Replace("@OpenDate", x.OpenDate)
                            .Replace("@InvoiceSite", x.InvoiceSite)
                            .Replace("@DisplayName", x.DisplayName)
                            .Replace("@OpenTkpr", x.OpenTkpr)
                            .Replace("@EffStart", x.cliDate.EffStart)
                            .Replace("@Office", x.cliDate.Office)
                            .Replace("@RspTkpr", x.cliDate.RspTkpr)
                            .Replace("@BillTkpr", x.cliDate.BillTkpr)
                            .Replace("@SpvTkpr", x.cliDate.SpvTkpr)
                            .Replace("@NxStartDate", x.cliDate.NxStartDate);

                sb.AppendLine(csXml);
            });

            return sb.ToString();
        }
        #endregion add client short entry conversion

        #region add client short entry xml
        private static string AddClientShortEntryXml = @"
        <Add>
          <Client>
            <Attributes>
              <Entity>@Entity</Entity>
              <CliType>@CliType</CliType>
              <CliStatusType>@CliStatusType</CliStatusType>
              <CliStatusDate>@CliStatusDate</CliStatusDate>
              <Currency>USD</Currency>
              <OpenDate>@OpenDate</OpenDate>
              <InvoiceSite>@InvoiceSite</InvoiceSite>
              <!-- must be a site related to the client entity -->
              <Language>1033</Language>
              <LoadSource>Kentico</LoadSource>
              <DisplayName>@DisplayName</DisplayName>
              <OpenTkpr>@OpenTkpr</OpenTkpr>
              <!-- Administrative Division (46)-->
            </Attributes>
            <Children>
              <CliDate>
                <Add>
                  <CliDate>
                    <Attributes>
                      <EffStart>@EffStart</EffStart>
                      <Office>@Office</Office>
                      <!-- Houston (001)-->
                      <RspTkpr>@RspTkpr</RspTkpr>
                      <!-- Administrative Division (46)-->
                      <BillTkpr>@BillTkpr</BillTkpr>
                      <!-- Administrative Division (46)-->
                      <SpvTkpr>@SpvTkpr</SpvTkpr>
                      <!-- Administrative Division (46)-->
                      <NxStartDate>@NxStartDate</NxStartDate>
                    </Attributes>
                  </CliDate>
                </Add>
              </CliDate>
              <ClientSpecialInstructions_CCC>
                <Add>
                  <ClientSpecialInstructions_CCC>
                    <Attributes>
                      <ClientInstructions_CCC>000</ClientInstructions_CCC>
                    </Attributes>
                  </ClientSpecialInstructions_CCC>
                </Add>
              </ClientSpecialInstructions_CCC>
            </Children>
          </Client>
        </Add>
    ";
        #endregion add client short entry xnl

        #region edit client short entry conversion
        private static string ConvertEditClientShortEntry(List<ClientSrv> clientSrvs)
        {
            StringBuilder sb = new StringBuilder();

            clientSrvs.ForEach(x =>
            {
                string csXml = EditClientShortEntryXml;
                csXml = csXml//.Replace("@Entity", x.Entity)
                             //.Replace("@CliType", x.CliType)
                             //.Replace("@InvoiceSite", x.InvoiceSite)
                             .Replace("@DisplayName", x.DisplayName)
                             //.Replace("@Office", x.cliDate.Office)
                             .Replace("@ClientKey", x.ClientIndex);
                //.Replace("@CliDateKey", x.ClientIndex);

                sb.AppendLine(csXml);
            });

            return sb.ToString();
        }
        #endregion edit client short entry conversion

        #region edit client short entry xml
        private static string EditClientShortEntryXml = @"
        <Edit>
          <Client KeyValue=""@ClientKey"">
            <Attributes>
              <DisplayName>@DisplayName</DisplayName>
            </Attributes>
            <Children>
              <!--<CliDate>
                <Edit>
                  <CliDate KeyValue=""@CliDateKey"">
                    <Attributes>
                      <Office>@Office</Office>
                    </Attributes>
                  </CliDate>
                </Edit>
              </CliDate> -->
            </Children>
          </Client>
        </Edit>
    ";
        #endregion edit client short entry xml
    }
}
