using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TE3EConnect.te3eObjects.Automation;
using TE3EEntityFramework.Data.KenticoCMS.RCGKENTCMS;
using TE3EEntityFramework.Extension;

namespace TE3EConnect.te3eMappers.Automation
{
    internal class EntityOrgSrvMapper
    {
        public static string ConvertEntityOrgSrvToXml(List<EntityOrgSrv> entityOrgSrvs, e3eMode e3EMode)
        {
            string csXml = "";
            string strTemplate = "EntityOrgSrv.xml";

            using (var objStreamReader = File.OpenText(Path.Combine(Path.GetDirectoryName(Assembly.GetCallingAssembly().Location), $"te3eXML/Automation/{strTemplate}")))
            {
                csXml = objStreamReader.ReadToEnd();
                csXml = csXml.Replace("@AddEntityOrgSrv", e3EMode == e3eMode.Add ? ConvertAddOrgEntity(entityOrgSrvs) : ConvertEditOrgEntity(entityOrgSrvs));
            }

            return csXml;
        }

        #region add org entity conversion
        private static string ConvertAddOrgEntity(List<EntityOrgSrv> entityOrgSrvs)
        {
            StringBuilder sb = new StringBuilder();

            entityOrgSrvs.ForEach(x =>
            {
                string csXml = AddOrgEntityXml;
                csXml = csXml.Replace("@EntityType", x.entityOrg.EntityType)
                             .Replace("@OrgName", x.entityOrg.OrgName.TrimToLength(128));
                //.Replace("@AddOrgSite", ConvertAddOrgSite(x.orgSites));

                sb.AppendLine(csXml);
            });

            return sb.ToString();
        }

        private static string ConvertAddOrgSite(List<OrgSite> orgSites)
        {
            StringBuilder sb = new StringBuilder();

            orgSites.ForEach(x =>
            {
                string csXml = AddOrgSiteXml;
                csXml = csXml.Replace("@Description", x.Description)
                             .Replace("@SiteType", x.SiteType)
                             .Replace("@IsDefault", string.IsNullOrEmpty(x.IsDefault) ? "0" : x.IsDefault)
                             .Replace("@Street", x.Street.TrimToLength(255))
                             .Replace("@City", x.City.TrimToLength(64))
                             .Replace("@ZipCode", x.ZipCode.TrimToLength(20))
                             .Replace("@State", x.State.TrimToLength(16))
                             .Replace("@County", x.County.TrimToLength(20))
                             .Replace("@Country", x.Country.TrimToLength(20))
                             .Replace("@Longitude", x.Longitude)
                             .Replace("@Latitude", x.Latitude)
                             .Replace("@AddOrgSiteEmail", !string.IsNullOrEmpty(x.EmailAddress.EmailAddr) ? ConvertAddOrgSiteEmail(x.EmailAddress) : "");

                if (!string.IsNullOrEmpty(x.Country) && (x.Country.ToUpper().Equals("CA") || x.Country.ToUpper().Equals("US")))
                {
                    csXml = csXml.Replace("@State", x.State).Replace("@Additional1", string.Empty);
                }
                else
                {
                    csXml = csXml.Replace("@State", string.Empty).Replace("@Additional1", x.State);
                }


                sb.AppendLine(csXml);
            });

            return sb.ToString();
        }

        private static string ConvertEditOrAddOrgSite(List<OrgSite> orgSites)
        {
            StringBuilder sb = new StringBuilder();

            orgSites.ForEach(x =>
            {
                if (x.SvcOp == SvcOps.Add)
                {
                    string csXml = AddOrgSiteXml;
                    csXml = csXml.Replace("@Description", x.Description)
                                 .Replace("@SiteType", x.SiteType)
                                 .Replace("@IsDefault", string.IsNullOrEmpty(x.IsDefault) ? "0" : x.IsDefault)
                                 .Replace("@Street", x.Street.TrimToLength(255))
                                 .Replace("@City", x.City.TrimToLength(64))
                                 .Replace("@ZipCode", x.ZipCode.TrimToLength(20))
                                 .Replace("@State", x.State.TrimToLength(16))
                                 .Replace("@County", x.County.TrimToLength(20))
                                 .Replace("@Country", x.Country.TrimToLength(20))
                                 .Replace("@Longitude", x.Longitude)
                                 .Replace("@Latitude", x.Latitude)
                                 .Replace("@AddOrgSiteEmail", !string.IsNullOrEmpty(x.EmailAddress.EmailAddr) ? ConvertAddOrgSiteEmail(x.EmailAddress) : "");

                    if (!string.IsNullOrEmpty(x.Country) && (x.Country.ToUpper().Equals("CA") || x.Country.ToUpper().Equals("US")))
                    {
                        csXml = csXml.Replace("@State", x.State).Replace("@Additional1", string.Empty);
                    }
                    else
                    {
                        csXml = csXml.Replace("@State", string.Empty).Replace("@Additional1", x.State);
                    }
                    sb.AppendLine(csXml);
                }
                else if (x.SvcOp == SvcOps.Edit)
                {
                    string csXml = EditSiteXml;
                    csXml = csXml.Replace("@SiteKey", x.SiteID.ToString())
                                .Replace("@Description", x.Description)
                                .Replace("@Street", x.Street.TrimToLength(255))
                                .Replace("@City", x.City.TrimToLength(64))
                                .Replace("@ZipCode", x.ZipCode.TrimToLength(20))
                                .Replace("@State", x.State.TrimToLength(16))
                                .Replace("@County", x.County.TrimToLength(20))
                                .Replace("@Country", x.Country.TrimToLength(20))
                                .Replace("@Longitude", x.Longitude)
                                .Replace("@Latitude", x.Latitude)
                                .Replace("@AddOrgSiteEmail", !string.IsNullOrEmpty(x.EmailAddress.EmailAddr) ? ConvertAddOrgSiteEmail(x.EmailAddress) : "");

                    if (!string.IsNullOrEmpty(x.Country) && (x.Country.ToUpper().Equals("CA") || x.Country.ToUpper().Equals("US")))
                    {
                        csXml = csXml.Replace("@State", x.State).Replace("@Additional1", string.Empty);
                    }
                    else
                    {
                        csXml = csXml.Replace("@State", string.Empty).Replace("@Additional1", x.State);
                    }
                    sb.AppendLine(csXml);
                }
            });

            return sb.ToString();
        }

        private static string ConvertAddOrgSiteEmail(OrgEmail orgEmail)
        {
            string csXml = AddOrgSiteEmailXml;
            csXml = csXml.Replace("@EmailAddr", orgEmail.EmailAddr)
                         .Replace("@EmailDescription", orgEmail.EmailAddr)
                         .Replace("@SortString", orgEmail.EmailAddr)
                         .Replace("@IsDefault", orgEmail.IsDefault);

            return csXml;
        }
        #endregion add org entity conversion

        #region add org entity xml
        private static string AddOrgEntityXml = @"
        <Add>
            <EntityOrg>
                <Attributes>
                    <EntityType>@EntityType</EntityType>
					<LoadSource>Kentico</LoadSource>
                    <IsMerged>0</IsMerged>
                    <OrgName>@OrgName</OrgName>
                </Attributes>
                <Children>
                    <Relate>
                        <Add>
                            <Relate>
                                <Attributes>
                                    <RelType>SELF</RelType>
                                    <Description>SELF</Description>
									 <IsDefault>1</IsDefault>
                                </Attributes>
                <!--
                                <Children>
                                    <Site>
                                      @AddOrgSite
                                    </Site>
                                </Children>
                -->
                            </Relate>
                        </Add>
                    </Relate>
                </Children>
            </EntityOrg>
        </Add>
";

        private static string AddOrgSiteXml = @"
        <Add>
            <Site>
                <Attributes>
                    <Description>@Description</Description>
                    <SiteType>@SiteType</SiteType>
                    <IsDefault>@IsDefault</IsDefault>
					<Street>@Street</Street>
                    <City>@City</City>
                    <ZipCode>@ZipCode</ZipCode>
                    <State>@State</State>
                    <Additional1>@Additional1</Additional1>
                    <County>@County</County>
                    <Country>@Country</Country>
                    <Language>1033</Language>
                    <Longitude>@Longitude</Longitude>
                    <Latitude>@Latitude</Latitude>
                </Attributes>
                <Children>
                    @AddOrgSiteEmail
                </Children>
            </Site>
        </Add>
";

        private static string AddOrgSiteEmailXml = @"
        <Site_EMail>
            <Add>
                <Site_EMail>
                    <Attributes>
                        <EmailAddr>@EmailAddr</EmailAddr>
                        <Description>@EmailDescription</Description>
                        <SortString>@SortString</SortString>
                        <EmailType>150</EmailType>
                        <IsDefault>@IsDefault</IsDefault>
                    </Attributes>
                </Site_EMail>
            </Add>
        </Site_EMail>

";
        #endregion add org entity xml

        #region edit org entity conversion
        private static string ConvertEditOrgEntity(List<EntityOrgSrv> entityOrgSrvs)
        {
            StringBuilder sb = new StringBuilder();

            entityOrgSrvs.ForEach(x =>
            {
                string csXml = EditOrgEntityXml;
                csXml = csXml.Replace("@EntityOrgKey", x.entityOrg.EntityID.ToString())
                             .Replace("@OrgName", x.entityOrg.OrgName.TrimToLength(128));

                //if (x.orgSites.Count() > 0)
                //{
                //    csXml = csXml.Replace("@RelateKey", x.orgSites.First().RelateID.ToString())
                //                 .Replace("@EditOrAddSiteXml", ConvertEditOrAddOrgSite(x.orgSites));
                //}
                //else
                //{
                //    csXml = csXml.Replace(@"<Relate>
                //        <Edit>
                //            <Relate KeyValue=""@RelateKey"">
                //                <Children>
                //                    <Site>
                //                        @EditOrAddSiteXml
                //                    </Site>
                //                </Children>
                //            </Relate>
                //        </Edit>
                //    </Relate>", "");
                //}
                sb.AppendLine(csXml);
            });

            return sb.ToString();
        }

        #endregion edit org entity conversion

        #region edit org entity xml

        private static string EditOrgEntityXml = @"
        <Edit>
            <EntityOrg KeyValue=""@EntityOrgKey"">
                <Attributes>
                    <OrgName>@OrgName</OrgName>
                </Attributes>
                <!--
                <Children>
                    <Relate>
                        <Edit>
                            <Relate KeyValue=""@RelateKey"">
                                <Children>
                                    <Site>
                                        @EditOrAddSiteXml
                                    </Site>
                                </Children>
                            </Relate>
                        </Edit>
                    </Relate>
                </Children>
                -->
            </EntityOrg>
        </Edit>
";

        private static string EditSiteXml = @"
            <Edit>
                <Site KeyValue=""@SiteKey"">
                    <Attributes>
                        <Description>@Description</Description>
					    <Street>@Street</Street>
                        <City>@City</City>
                        <ZipCode>@ZipCode</ZipCode>
                        <State>@State</State>
                        <Additional1>@Additional1</Additional1>
                        <County>@County</County>
                        <Country>@Country</Country>
                        <Longitude>@Longitude</Longitude>
                        <Latitude>@Latitude</Latitude>
                    </Attributes>
                    <Children>
                        @AddOrgSiteEmail
                    </Children>
                </Site>
            </Edit>
";

        //        private static string AddSiteXml = @"
        //            <Add>
        //                <Site>
        //                    <Attributes>
        //                        <Description>@Description</Description>
        //					    <Street>@Street</Street>
        //                        <City>@City</City>
        //                        <ZipCode>@ZipCode</ZipCode>
        //                        <State>@State</State>
        //                        <County>@County</County>
        //                        <Country>@Country</Country>
        //                        <Longitude>@Longitude</Longitude>
        //                        <Latitude>@Latitude</Latitude>
        //                    </Attributes>
        //                    <Children>
        //                        @AddOrgSiteEmail
        //                    </Children>
        //                </Site>
        //            </Add>
        //";
        #endregion edit org entity xml
    }
}
