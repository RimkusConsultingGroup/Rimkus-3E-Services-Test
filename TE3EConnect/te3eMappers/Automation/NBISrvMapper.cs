using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TE3EConnect.te3eObjects.Automation;

namespace TE3EConnect.te3eMappers.Automation
{
    internal class NBISrvMapper
    {
        public static string ConvertNBISrvToXml(NBISrv nbiSrv)
        {
            string csXml = "";
            string strTemplate = "NBISrv.xml";

            using (var objStreamReader = File.OpenText(Path.Combine(Path.GetDirectoryName(Assembly.GetCallingAssembly().Location), $"te3eXML/Automation/{strTemplate}")))
            {
                csXml = objStreamReader.ReadToEnd();
                csXml = csXml.Replace("@Client", nbiSrv.Client)
                            .Replace("@Matter", nbiSrv.Matter)
                            .Replace("@RequestDateTime", nbiSrv.RequestDateTime)
                            .Replace("@Description", nbiSrv.Description);

                if(nbiSrv.cftNewBizSearchNames.Count() > 0 || nbiSrv.cftNewBizAddress_CCCs.Count() > 0)
                {
                    csXml = csXml.Replace("@ChildrenTagXml", AddChildrenTagXml);

                    csXml = (nbiSrv.cftNewBizSearchNames.Count() > 0)
                            ? csXml.Replace("@AddCftNewBizSearchNameXml", ConvertCftNewBizSearchName(nbiSrv.cftNewBizSearchNames))
                            : "";

                    csXml = (nbiSrv.cftNewBizAddress_CCCs.Count() > 0)
                            ? csXml.Replace("@AddCftNewBizAddress_CCCXml", ConvertCftNewBizAddress_CCC(nbiSrv.cftNewBizAddress_CCCs))
                            : "";
                }
                else csXml = csXml.Replace("@ChildrenTagXml", "");
            }

            return csXml;
        }

        private static string ConvertCftNewBizSearchName(List<te3eObjects.Automation.CftNewBizSearchName> cftNewBizSearchNames)
        {
            StringBuilder sb = new StringBuilder();

            cftNewBizSearchNames.ForEach(x =>
            {
                string csXml = AddCftNewBizSearchNameXml;
                csXml = csXml.Replace("@CftPartyType", x.CftPartyType)
                            .Replace("@CftRelationshipCode", x.CftRelationshipCode)
                            .Replace("@EntityDisplayName", x.EntityDisplayName)
                            .Replace("@FirstName", x.FirstName)
                            .Replace("@MiddleName", x.MiddleName)
                            .Replace("@LastName", x.LastName)
                            .Replace("@Entity", x.Entity)
                            .Replace("@CftRole", x.CftRole)
                            .Replace("@SearchTerm", x.SearchTerm)
                            .Replace("@CftEntityType", x.CftEntityType);

                sb.AppendLine(csXml);
            });

            return sb.ToString();
        }

        private static string ConvertCftNewBizAddress_CCC(List<te3eObjects.Automation.CftNewBizAddress_CCC> cftNewBizAddress_CCCs)
        {
            StringBuilder sb = new StringBuilder();

            cftNewBizAddress_CCCs.ForEach(x =>
            {
                string csXml = AddCftNewBizAddress_CCCXml;
                csXml = csXml.Replace("@City", x.City)
                            .Replace("@Country", x.Country)
                            .Replace("@Location", x.Location)
                            .Replace("@State", x.State);

                sb.AppendLine(csXml);
            });

            return sb.ToString();
        }

        private static string AddChildrenTagXml = @"
        <Children>
          @CftNewBizSearchNameTagXml
          @CftNewBizAddress_CCCTagXml
        </Children>
";
        private static string CftNewBizSearchNameTagXml = @"
        <CftNewBizSearchName>
            @AddCftNewBizSearchNameXml
        </CftNewBizSearchName>
";

        private static string CftNewBizAddress_CCCTagXml = @"
        <CftNewBizAddress_CCC>
            @AddCftNewBizAddress_CCCXml
        </CftNewBizAddress_CCC>
";

        private static string AddCftNewBizSearchNameXml = @"
        < Add>
              <CftNewBizSearchName>
                <Attributes>
                  <CftPartyType>@CftPartyType</CftPartyType>
                  <!-- CftPartyType - EntityPerson, EntityOrg -->
                  <CftRelationshipCode>@CftRelationshipCode</CftRelationshipCode>
                  <!-- CftRelationshipCode - Both (01) -->
                  <EntityDisplayName>@EntityDisplayName</EntityDisplayName>
                  <FirstName>@FirstName</FirstName>
                  <MiddleName>@MiddleName</MiddleName>
                  <LastName>@LastName</LastName>
                  <!-- <CompanyName>NewValue</CompanyName> Required when CftPartyType = EntityOrg-->
                  <Entity>@Entity</Entity>
                  <CftRole>@CftRole</CftRole>
                  <IsCreatedEntity>0</IsCreatedEntity>
                  <AddedRelatedParty>1</AddedRelatedParty>
                  <Resolved>1</Resolved>
                  <CurEntityIndex>@Entity</CurEntityIndex>
                  <LinkType>Matter</LinkType>
                  <!--Notes>comments</Notes-->
                  <IsPhoneticSearch>0</IsPhoneticSearch>
                  <SortOrder>1</SortOrder>
                  <IsClientAsSearchName>1</IsClientAsSearchName>
                  <IsNotSearch>0</IsNotSearch>
                  <IsNotCreateLink>0</IsNotCreateLink>
                  <SearchTerm>@SearchTerm</SearchTerm>
                  <!-- Diane &amp; Kotowski -->
                  <CftEntityType>@CftEntityType</CftEntityType>
                  <!-- CftEntityType - Additional Party (300) -->
                  <!-- CftRelatedParty /-->
                  <FullTextSearchResultCount>1</FullTextSearchResultCount>
                </Attributes>
              </CftNewBizSearchName>
            </Add>
";

		private static string AddCftNewBizAddress_CCCXml = @"
        <Add>
            <CftNewBizAddress_CCC>
            <Attributes>
                <City>@City</City>
                <Country>@Country</Country>
                <Location>@Location</Location>
                <State>@State</State>
            </Attributes>
            </CftNewBizAddress_CCC>
        </Add>
";
	}
}
