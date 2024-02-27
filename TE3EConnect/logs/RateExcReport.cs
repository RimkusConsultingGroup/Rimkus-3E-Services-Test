using System;
using System.IO;

namespace TE3EConnect.logs
{
    public class RateExcReport
    {
        public string _logFilePath;

        public RateExcReport(string filePath = "", bool rejected = false)
        {
            string ftype = rejected
                           ? string.Format(@"C:\ProgramData\te_3e\Logs\rateexc\rejected_rateexcreport.{0}.csv", DateTime.Now.ToString("MMddy.HHmmss"))
                           : string.Format(@"C:\ProgramData\te_3e\Logs\rateexc\rateexcreport.{0}.csv", DateTime.Now.ToString("MMddy.HHmmss"));

            _logFilePath = !string.IsNullOrEmpty(filePath)
                           ? filePath
                           : ftype;

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

        public static void GenerateXMLRateExc(string gj, string xml)
        {
            string dir = @"C:\ProgramData\te_3e\Logs\Xml\rateexc";

            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            string xmlFile = Path.Combine(dir, string.Format("{0}_{1}.xml", gj, DateTime.Now.ToString("MMddyyyyTHHmmss")));

            if (!File.Exists(xmlFile))
                File.WriteAllText(xmlFile, xml);
        }

        public void MoveCsvToUploadFolder(string csv)
        {
            if (File.Exists(csv))
            {
                string dir = @"C:\ProgramData\te_3e\Logs\Uploaded\rateexc";

                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);

                File.Move(csv, Path.Combine(dir, string.Format("{0}_{1}", DateTime.Now.ToString("MMddyyyyTHHmmss"), Path.GetFileName(csv))));
            }
        }
    }
}