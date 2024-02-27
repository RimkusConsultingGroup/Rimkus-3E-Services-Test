using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TE3EConnect;
using TE3EEntityFramework.Client.RCGKENTCMS;
using TE3EEntityFramework.Setting;

namespace Rimkus3EServicesHealthCheck.Transaction
{
    public class TE3ETransactionClient
    {
        private UKGTE3EAppSetting uKGTE3EAppSetting;
        private CMSSQLClientV2 te3EDbClient;
        //private KenticoWebClient kenticoWebClient;
        private TE3ETranSvc tE3ETranSvc;
        private readonly log4net.ILog logger;
        private List<string> xmlFiles;
        private StringBuilder accumatedLogMsg;
        private string Office_Emails_To_Test;
        private string Client_Relation_Email;

        public TE3ETransactionClient(UKGTE3EAppSetting appSetting)
        {
            #region configuration application log

            log4net.Config.XmlConfigurator.Configure();
            logger = log4net.LogManager.GetLogger(typeof(TE3ETransactionClient));

            #endregion configuration application log

            #region configure automation client

            //get app config
            uKGTE3EAppSetting = appSetting;

            #endregion configure automation client

            #region configure 3e Transaction service client

            TE3ELoginInfo tE3ELoginInfo = new TE3ELoginInfo
            {
                E3EServerEnv = (e3eServerEnv)Enum.Parse(typeof(e3eServerEnv), (uKGTE3EAppSetting.Te3eServer.ToString()), true),
                IsProdUpgradedVersion = uKGTE3EAppSetting.IsProdUpgradedVersion
            };

            tE3ETranSvc = new TE3ETranSvc(tE3ELoginInfo);
            #endregion configure 3e Transaction service client
        }

        public ProcessResults ExecuteProcess(string csXml)
        {
            #region process matter_srv
            ProcessResults processResults = new ProcessResults();
            processResults.xmlFiles = new List<string>();

            ProcessRawResultXml matter = new ProcessRawResultXml();
            matter.xmlFiles = new List<string>();

            int returnInfo = 0;

            string xmlString = csXml;// MatterSrvMapper.ConvertAddMatterSrvToXml(matterSrv, true);

            string result = tE3ETranSvc.TransvcExecuteProcess(xmlString, returnInfo);
            //string payloadXml = MatterSrvReport.GenerateXMLMatterSrvReport(matterSrv.DisplayName, xmlString);
            //matter.xmlFiles.Add(payloadXml);

            //string resultXml = MatterSrvReport.GenerateResultXMLMatterSrvReport(matterSrv.DisplayName, result);
            //matter.xmlFiles.Add(resultXml);
            matter.result = result;

            //return processRawResultXml;

            //var matter = tE3ETranSvc.AddMatterSrvTemplateProcess(matterSrv);
            processResults = tE3ETranSvc.CheckResult(matter.result);
            processResults.xmlFiles = new List<string>();
            processResults.xmlFiles.AddRange(matter.xmlFiles);

            #endregion process matter_srv

            return processResults;
        }

        public void DeleteMatterSvrRCProcess(string matterIndex)
        {
            int returnInfo = 0;

            string xmlString = @"<Matter_Srv_RC xmlns=""http://elite.com/schemas/transaction/process/write/Matter_Srv_RC"">
                                    <Initialize xmlns=""http://elite.com/schemas/transaction/object/write/Matter"">
                                        <Delete>
                                            <Matter KeyValue=""matterIndex"" />
                                        </Delete>
                                    </Initialize>
                                </Matter_Srv_RC>
                                ";

            xmlString = xmlString.Replace("matterIndex", matterIndex);

            string result = tE3ETranSvc.TransvcExecuteProcess(xmlString, returnInfo);
            ProcessResults processResults = tE3ETranSvc.CheckResult(result);
        }
    }
}
