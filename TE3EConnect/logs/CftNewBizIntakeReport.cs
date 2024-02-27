using System;
using System.IO;

namespace TE3EConnect.logs
{
    public class CftNewBizIntakeReport
    {
        public string _logFilePath;

        public CftNewBizIntakeReport(string filePath = "")
        {
            _logFilePath = !string.IsNullOrEmpty(filePath)
                           ? filePath
                           : string.Format(@"C:\ProgramData\te_3e\CftNewBizIntake\CftNewBizIntakeReport.{0}.csv", DateTime.Now.ToString("MMddy.HHmmss"));

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

        public static void GenerateXMLCftNewBizIntake(string name, string xml)
        {
            string dir = @"C:\ProgramData\te_3e\Logs\Xml\CftNewBizIntake\payloads";

            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            string xmlFile = Path.Combine(dir, string.Format("{0}_{1}.xml", name, DateTime.Now.ToString("MMddyyyyTHHmmss")));

            if (!File.Exists(xmlFile))
                File.WriteAllText(xmlFile, xml);
        }

        public static void GenerateResultXMLCftNewBizIntake(string name, string xml)
        {
            string dir = @"C:\ProgramData\te_3e\Logs\Xml\CftNewBizIntake\results";

            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            string xmlFile = Path.Combine(dir, string.Format("{0}_{1}.xml", name, DateTime.Now.ToString("MMddyyyyTHHmmss")));

            if (!File.Exists(xmlFile))
                File.WriteAllText(xmlFile, xml);
        }
    }
}