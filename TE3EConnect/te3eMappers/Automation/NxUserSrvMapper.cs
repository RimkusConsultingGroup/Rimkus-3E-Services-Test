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
    internal class NxUserSrvMapper
    {
        public static string ConvertNxUserSrvToXml(NxUser nxUser, e3eMode e3EMode)
        {
            string csXml = "";
            string strTemplate = "NxUser_CCC_Srv.xml";
            
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetCallingAssembly().Location), "te3eXML", "Automation",strTemplate);
            using (var objStreamReader = File.OpenText(path))
            {
                csXml = objStreamReader.ReadToEnd();
                csXml = csXml.Replace("@AddNxUser", e3EMode == e3eMode.Add ? ConvertAddNxUser(nxUser) : ConvertEditNxUser(nxUser));

            }

            return csXml;
        }
        
        #region add NxUser conversion
        private static string ConvertAddNxUser(NxUser nxUser)
        {
            StringBuilder sb = new StringBuilder();
            var entity = !string.IsNullOrEmpty(nxUser.Entity.ToString()) && nxUser.Entity.ToString() != "0" ? nxUser.Entity.ToString() : "";
            var roleSec = nxUser.NxUserSecRoles.Count() > 0 ? ConvertAddNxUserSecRole(nxUser.NxUserSecRoles) : "";
            var timeKeeper = (!string.IsNullOrEmpty(nxUser.TimekeeperIndex.ToString()) && nxUser.TimekeeperIndex.ToString() != "0") ? ConvertAddTimekeeper(nxUser.TimekeeperIndex.ToString()) : "";
            
            string csXml = AddNxUserXml;
            csXml = csXml.Replace("@BaseUserName", nxUser.BaseUserName)
                         .Replace("@IsActive", nxUser.IsActive)
                         .Replace("@TimeZone", nxUser.TimeZone)
                         .Replace("@Language", nxUser.Language)
                         .Replace("@Dashboard", nxUser.Dashboard)
                         .Replace("@EmailAddr", nxUser.EmailAddr)
                         .Replace("@NetworkAlias", nxUser.NetworkAlias)
                         .Replace("@OptionsRole", nxUser.OptionsRole)
                         .Replace("@DefaultUnit", nxUser.DefaultUnit)
                         .Replace("@Entity", entity)
                         .Replace("@Office", nxUser.Office)
                         .Replace("@Department_CCC", nxUser.Department_CCC) 
                         .Replace("@Supervisor_CCC", nxUser.Supervisor_CCC)
                         .Replace("@CanSwitchOperatingUnit", nxUser.CanSwitchOperatingUnit)
                         .Replace("@DataRole", nxUser.DataRole)
                         .Replace("@IsAllowTimeEntry", nxUser.IsAllowTimeEntry)
                         .Replace("@CanProxy", nxUser.CanProxy)
                         .Replace("@CanEditDashboard", nxUser.CanEditDashboard)
                         .Replace("@WinTimeZone", nxUser.WinTimeZone)
                         .Replace("@CanEditGlobalModel", nxUser.CanEditGlobalModel)
                         .Replace("@CanEditCompanyHeader", nxUser.CanEditCompanyHeader)
                         .Replace("@AddSecurityRole", roleSec)
                         .Replace("@AddTimekeeper", timeKeeper);

            sb.AppendLine(csXml);

            return sb.ToString();
        }

        private static string ConvertAddTimekeeper(string timekeeperIndex)
        {
            StringBuilder sb = new StringBuilder();
            string csXml = AddTimekeeperXml;
            csXml = csXml.Replace("@Timekeeper", timekeeperIndex);

            sb.AppendLine(csXml);

            return sb.ToString();
        }

        private static string ConvertAddNxUserSecRole(List<string> nxUserSecRoles)
        {
            StringBuilder sb = new StringBuilder();
            string csXml = AddSecurityRoleXml;

            StringBuilder nxSecRoleSb = new StringBuilder();
            nxUserSecRoles.ForEach(x =>
            {
                string nxSecRoleAttrXml = AddSecurityRoleAttributeXml;
                nxSecRoleAttrXml = nxSecRoleAttrXml.Replace("@RoleID", x);

                nxSecRoleSb.AppendLine(nxSecRoleAttrXml);
            });

            csXml = csXml.Replace("@AddSecurityRoleAttributes", nxSecRoleSb.ToString());

            sb.AppendLine(csXml);

            return sb.ToString();
        }
        #endregion add NxUser conversion

        #region add NxUser xml

        private static string AddNxUserXml = @"

        <Add>
            <NxUser>
                <Attributes>
                    <BaseUserName>@BaseUserName</BaseUserName>
                    <IsActive>@IsActive</IsActive>
                    <TimeZone>@TimeZone</TimeZone>
                    <Language>@Language</Language>
                    <Dashboard>@Dashboard</Dashboard>
                    <EmailAddr>@EmailAddr</EmailAddr>
                    <NetworkAlias>@NetworkAlias</NetworkAlias>
                    <OptionsRole>@OptionsRole</OptionsRole>
                    <DefaultUnit>@DefaultUnit</DefaultUnit>
                    <Department_CCC>@Department_CCC</Department_CCC>
                    <Supervisor_CCC>@Supervisor_CCC</Supervisor_CCC>
                    <Entity>@Entity</Entity>
                    <Office>@Office</Office>
                    <IsDeveloper>0</IsDeveloper>
                    <CanSwitchOperatingUnit>@CanSwitchOperatingUnit</CanSwitchOperatingUnit>
                    <DataRole>@DataRole</DataRole>
                    <IsAllowTimeEntry>@IsAllowTimeEntry</IsAllowTimeEntry>
                    <CanProxy>@CanProxy</CanProxy>
                    <CanEditDashboard>@CanEditDashboard</CanEditDashboard>
                    <WinTimeZone>@WinTimeZone</WinTimeZone>
                    <CanEditGlobalModel>@CanEditGlobalModel</CanEditGlobalModel>
                    <CanEditCompanyHeader>@CanEditCompanyHeader</CanEditCompanyHeader>
                </Attributes>
                <Children>
                    @AddSecurityRole
                    @AddTimekeeper
                </Children>
            </NxUser>
        </Add>
";

        private static string AddTimekeeperXml = @"

        <NxUserTimekeeper>
            <Add>
                <NxUserTimekeeper>
                    <Attributes>
                        <Timekeeper>@Timekeeper</Timekeeper>
                        <IsDefault>1</IsDefault>
                    </Attributes>
                </NxUserTimekeeper>
            </Add>
        </NxUserTimekeeper>
";

        private static string AddSecurityRoleXml = @"
    
        <NxUser_RoleChild>
            @AddSecurityRoleAttributes
        </NxUser_RoleChild>

";

        private static string AddSecurityRoleAttributeXml = @"
    
        <Add>
            <NxUser_RoleChild>
                <Attributes>
                    <RoleID>@RoleID</RoleID>
                    <RolePrecedence>0</RolePrecedence>
                </Attributes>
            </NxUser_RoleChild>
        </Add>

";
        #endregion add NxUser xml

        #region edit NxUser conversion
        private static string ConvertEditNxUser(NxUser nxUser)
        {
            StringBuilder sb = new StringBuilder();
            var entity = !string.IsNullOrEmpty(nxUser.Entity) && nxUser.Entity != "0" ? nxUser.Entity.ToString() : "";
            //var roleSec = nxUser.NxUserSecRoles.Count() > 0 ? ConvertAddNxUserSecRole(nxUser.NxUserSecRoles) : "";
            var timeKeeper = (!string.IsNullOrEmpty(nxUser.TimekeeperIndex) && nxUser.TimekeeperIndex != "0") ? ConvertAddTimekeeper(nxUser.TimekeeperIndex.ToString()) : "";

            string csXml = EditNxUserXml;
            csXml = csXml.Replace("@NxUserIndex", nxUser.NxUserIndex)
                         .Replace("@Entity", entity)
                         .Replace("@Dashboard", nxUser.Dashboard)
                         .Replace("@Department_CCC", nxUser.Department_CCC)
                         .Replace("@Supervisor_CCC", nxUser.Supervisor_CCC)
                         .Replace("@Office", nxUser.Office)
                         .Replace("@WinTimeZone", nxUser.WinTimeZone)
                         .Replace("@AddTimekeeper",timeKeeper);

            sb.AppendLine(csXml);

            return sb.ToString();
        }

        #endregion edit NxUser conversion

        #region edit NxUser xml
        private static string EditNxUserXml = @"

        <Edit>
            <NxUser KeyValue=""@NxUserIndex"">
                <Attributes>
                  <!-- <BaseUserName>@BaseUserName</BaseUserName>
                    <IsActive>@IsActive</IsActive>
                    <TimeZone>@TimeZone</TimeZone>
                    <Language>@Language</Language>
                    <EmailAddr>@EmailAddr</EmailAddr>
                    <NetworkAlias>@NetworkAlias</NetworkAlias>
                    <OptionsRole>@OptionsRole</OptionsRole>
                    <DefaultUnit>@DefaultUnit</DefaultUnit> -->
                    <Dashboard>@Dashboard</Dashboard>
                    <Department_CCC>@Department_CCC</Department_CCC>
                    <Supervisor_CCC>@Supervisor_CCC</Supervisor_CCC>
                    <Office>@Office</Office>
                    <WinTimeZone>@WinTimeZone</WinTimeZone>
                    <Entity>@Entity</Entity>
                    <!-- <IsDeveloper>0</IsDeveloper>
                    <CanSwitchOperatingUnit>@CanSwitchOperatingUnit</CanSwitchOperatingUnit>
                    <DataRole>@DataRole</DataRole>
                    <IsAllowTimeEntry>@IsAllowTimeEntry</IsAllowTimeEntry>
                    <CanProxy>@CanProxy</CanProxy>
                    <CanEditDashboard>@CanEditDashboard</CanEditDashboard>
                    <CanEditGlobalModel>@CanEditGlobalModel</CanEditGlobalModel>
                    <CanEditCompanyHeader>@CanEditCompanyHeader</CanEditCompanyHeader> -->
                </Attributes>
                <Children>
                   <!-- @AddSecurityRole -->
                    @AddTimekeeper 
                </Children>
            </NxUser>
        </Edit>
";

        #endregion edit NxUser xml

    }
}
