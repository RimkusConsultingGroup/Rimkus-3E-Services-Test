using System;
using System.IO;
using TE3EEntityFramework.Extension;

namespace TE3EConnect.logs
{
    public class EntityPersonSrvReport
    {
        public string _logFilePath;

        public EntityPersonSrvReport(string filePath = "")
        {
            _logFilePath = !string.IsNullOrEmpty(filePath)
                           ? filePath
                           : string.Format(@"C:\ProgramData\te_3e\Logs\automation\entitypersonsrv\entitypersonsrvreport.{0}.csv", DateTime.Now.ToString("MMddy.HHmmss"));

            FileInfo fileInfo = new FileInfo(_logFilePath);

            if (!Directory.Exists(fileInfo.DirectoryName))
                Directory.CreateDirectory(fileInfo.DirectoryName);
        }

        public void Log(string message)
        {
            using (StreamWriter sw = new StreamWriter(_logFilePath, true))
            {
                sw.WriteLine(message);
            }
        }

        public static string GenerateXMLEntityPersonSrvReport(string id, string xml)
        
        {
            string dir = @"C:\ProgramData\te_3e\Logs\automation\entitypersonsrv\xml";

            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            string xmlFile = Path.Combine(dir, string.Format("entitypersonsrv_{0}_{1}_payload.xml", id, DateTime.Now.ToString("MMddyyyyTHHmmss")).MakeSafeForFileName());

            if (!File.Exists(xmlFile))
                File.WriteAllText(xmlFile, xml);

            return xmlFile;
        }

        public static string GenerateResultXMLEntityPersonSrvReport(string id, string xml)
        {
            string dir = @"C:\ProgramData\te_3e\Logs\automation\entitypersonsrv\xml\results";

            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            string xmlFile = Path.Combine(dir, string.Format("entitypersonsrv_{0}_{1}_result.xml", id, DateTime.Now.ToString("MMddyyyyTHHmmss")).MakeSafeForFileName());

            if (!File.Exists(xmlFile))
                File.WriteAllText(xmlFile, xml);

            return xmlFile;
        }
    }
}