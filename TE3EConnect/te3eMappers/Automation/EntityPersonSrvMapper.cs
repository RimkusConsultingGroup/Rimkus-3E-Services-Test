﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TE3EConnect.te3eObjects.Automation;
using TE3EEntityFramework.Extension;

namespace TE3EConnect.te3eMappers.Automation
{
    internal class EntityPersonSrvMapper
    {
        public static string ConvertEntityPersonSrvToXml(List<EntityPersonSrv> entityPersonSrvs, e3eMode e3EMode)
        {
            string csXml = "";
            string strTemplate = "EntityPersonSrv.xml";
            
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetCallingAssembly().Location), "te3eXML", "Automation",strTemplate);
            using (var objStreamReader = File.OpenText(path))
            {
                csXml = objStreamReader.ReadToEnd();
                csXml = csXml.Replace("@AddPersonEntity", e3EMode == e3eMode.Add ? ConvertAddPersonEntity(entityPersonSrvs) : ConvertEditPersonEntity(entityPersonSrvs));

            }

            return csXml;
        }

        #region add person entity conversion
        private static string ConvertAddPersonEntity(List<EntityPersonSrv> entityPersonSrvs)
        {
            StringBuilder sb = new StringBuilder();

            entityPersonSrvs.ForEach(x =>
            {
                string csXml = AddPersonEntityXml;
                csXml = csXml.Replace("@EntityType", x.entityPerson.EntityType)
                             .Replace("@FirstName", x.entityPerson.FirstName)
                             .Replace("@MiddleName", !string.IsNullOrEmpty(x.entityPerson.MiddleName) ? x.entityPerson.MiddleName : "")
                             .Replace("@LastName", x.entityPerson.LastName)
                             .Replace("@Prefix", x.entityPerson.Prefix)
                             .Replace("@Suffix", x.entityPerson.Suffix);
                             //.Replace("@AddPersonSite", ConvertAddPersonSite(x.personSites));

                sb.AppendLine(csXml);
            });

            return sb.ToString();
        }

        private static string ConvertAddPersonSite(List<PersonSite> personSites)
        {
            StringBuilder sb = new StringBuilder();

            personSites.ForEach(x =>
            {
                string csXml = AddPersonSiteXml;
                csXml = csXml.Replace("@Description", x.Description)
                            .Replace("@SiteType", x.SiteType)
                            .Replace("@IsDefault", x.IsDefault)
                            .Replace("@Street", x.Street.TrimToLength(255))
                            .Replace("@City", x.City.TrimToLength(64))
                            .Replace("@ZipCode", x.ZipCode.TrimToLength(20))
                            .Replace("@State", x.State.TrimToLength(16))
                            .Replace("@County", x.County.TrimToLength(20))
                            .Replace("@Country", x.Country.TrimToLength(20))
                            .Replace("@Longitude", x.Longitude)
                            .Replace("@Latitude", x.Latitude)
                            .Replace("@AddPersonSiteEmail", !string.IsNullOrEmpty(x.EmailAddress?.EmailAddr) ? ConvertAddPersonSiteEmail(x.EmailAddress) : "");

                sb.AppendLine(csXml);
            });

            return sb.ToString();
        }

        private static string ConvertAddPersonSiteEmail(PersonEmail personEmail)
        {
            string csXml = AddPersonSiteEmailXml;
            csXml = csXml.Replace("@EmailAddr", personEmail.EmailAddr.TrimToLength(100))
                         .Replace("@EmailDescription", personEmail.EmailAddr)
                         .Replace("@SortString", personEmail.EmailAddr);

            return csXml;
        }
        #endregion add person entity conversion

        #region add person entity xml
        private static string AddPersonEntityXml = @"
        <Add>
            <EntityPerson>
                <Attributes>
                    <EntityType>@EntityType</EntityType>
                  <!-- General - No Site Required (200) -->
                    <LoadSource>UKG</LoadSource>
                    <IsMerged>0</IsMerged>
                    <FirstName>@FirstName</FirstName>
                    <MiddleName>@MiddleName</MiddleName>
                    <LastName>@LastName</LastName>
                    <NameFormat>150</NameFormat>
                    <Prefix>@Prefix</Prefix>
                    <Suffix>@Suffix</Suffix>
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
                                      @AddPersonSite
                                    </Site>
                                </Children>
                -->
                            </Relate>
                        </Add>
                    </Relate>
                </Children>
            </EntityPerson>
        </Add>
";

        private static string AddPersonSiteXml = @"
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
                    <County>@County</County>
                    <Country>@Country</Country>
                    <Language>1033</Language>
                    <Longitude>@Longitude</Longitude>
                    <Latitude>@Latitude</Latitude>
                </Attributes>
                <Children>
                    @AddPersonSiteEmail
                </Children>
            </Site>
        </Add>
";

        private static string AddPersonSiteEmailXml = @"
        <Site_EMail>
            <Add>
                <Site_EMail>
                    <Attributes>
                        <EmailAddr>@EmailAddr</EmailAddr>
                        <Description>@EmailDescription</Description>
                        <SortString>@SortString</SortString>
                        <EmailType>100</EmailType>
                        <IsDefault>1</IsDefault>
                    </Attributes>
                </Site_EMail>
            </Add>
        </Site_EMail>

";
        #endregion add person entity xml

        #region edit person entity conversion
        private static string ConvertEditPersonEntity(List<EntityPersonSrv> entityPersonSrvs)
        {
            StringBuilder sb = new StringBuilder();

            entityPersonSrvs.ForEach(x =>
            {
                if(!string.IsNullOrEmpty(x.entityPerson.FirstName) || !string.IsNullOrEmpty(x.entityPerson.LastName))
                {
                    string csXml = EditPersonEntityXml;
                    csXml = csXml.Replace("@EntityPersonKey", x.entityPerson.EntityID.ToString())
                                 .Replace("@FirstName", x.entityPerson.FirstName)
                                 .Replace("@LastName", x.entityPerson.LastName)
                                 .Replace("@MiddleName", x.entityPerson.MiddleName);

                    //x.personSites.ForEach(p =>
                    //{

                    //    if (!string.IsNullOrEmpty(p.SiteID))
                    //    {
                    //        csXml = csXml.Replace("@EditRelatedPersonEntityXml", EditRelatedPersonEntityXml)
                    //                     .Replace("@RelateKey", p.RelateID.ToString())
                    //                     .Replace("@SiteKey", p.SiteID.ToString())
                    //                     .Replace("@Description", p.Description)
                    //                     .Replace("@Street", p.Street.TrimToLength(255))
                    //                     .Replace("@City", p.City.TrimToLength(64))
                    //                     .Replace("@ZipCode", p.ZipCode.TrimToLength(20))
                    //                     .Replace("@State", p.State.TrimToLength(16))
                    //                     .Replace("@County", p.County.TrimToLength(20))
                    //                     .Replace("@Country", p.Country.TrimToLength(20))
                    //                     .Replace("@Longitude", p.Longitude)
                    //                     .Replace("@Latitude", p.Latitude);
                    //    }
                    //    else
                    //    {
                    //        csXml = csXml.Replace("@EditRelatedPersonEntityXml", "");
                    //    }

                    //    if (!string.IsNullOrEmpty(p.SiteEmailID))
                    //    {
                    //        csXml = csXml.Replace("@EditEmailSitePersonEntityXml", EditEmailSitePersonEntityXml)
                    //                     .Replace("@SiteEmailKey", p.SiteEmailID.ToString())
                    //                     .Replace("@EmailAddr", p.EmailAddress.EmailAddr ?? "")
                    //                     .Replace("@EmailDescription", p.EmailAddress.EmailAddr ?? "")
                    //                     .Replace("@SortString", p.EmailAddress.EmailAddr ?? "");
                    //    }
                    //    else
                    //    {
                    //        csXml = csXml.Replace("@EditEmailSitePersonEntityXml", "");
                    //    }
                    //});

                    //if(x.personSites.Count() == 0)
                    //{
                    //    csXml = csXml.Replace("@EditRelatedPersonEntityXml", "");
                    //}

                    sb.AppendLine(csXml);
                }
            });

            return sb.ToString();
        }

        #endregion edit person entity conversion

        #region edit person entity xml
        private static string EditPersonEntityXml = @"

        <Edit>
            <EntityPerson KeyValue=""@EntityPersonKey"">
                <Attributes>
                    <FirstName>@FirstName</FirstName>
                    <MiddleName>@MiddleName</MiddleName>
                    <LastName>@LastName</LastName>
                </Attributes>
                <!--
                <Children>
                    @EditRelatedPersonEntityXml
                </Children>
                -->
            </EntityPerson>
        </Edit>
";
        private static string EditRelatedPersonEntityXml = @"
            <Relate>
                <Edit>
                    <Relate KeyValue=""@RelateKey"">
                        <Children>
                            <Site>
                                <Edit>
                                    <Site KeyValue=""@SiteKey"">
                                        <Attributes>
                                            <Description>@Description</Description>
					                        <Street>@Street</Street>
                                            <City>@City</City>
                                            <ZipCode>@ZipCode</ZipCode>
                                            <State>@State</State>
                                            <County>@County</County>
                                            <Country>@Country</Country>
                                            <Longitude>@Longitude</Longitude>
                                            <Latitude>@Latitude</Latitude>
                                        </Attributes>
                                        <Children>
                                            @EditEmailSitePersonEntityXml
                                        </Children>
                                    </Site>
                                </Edit>
                            </Site>
                        </Children>
                    </Relate>
                </Edit>
            </Relate>
";

        private static string EditEmailSitePersonEntityXml = @"
            <Site_EMail>
                <Edit>
                    <Site_EMail KeyValue=""@SiteEmailKey"">
                        <Attributes>
                            <EmailAddr>@EmailAddr</EmailAddr>
                            <Description>@EmailDescription</Description>
                            <SortString>@SortString</SortString>
                        </Attributes>
                    </Site_EMail>
                </Edit>
            </Site_EMail>
";
        #endregion edit person entity xml
    }
}
