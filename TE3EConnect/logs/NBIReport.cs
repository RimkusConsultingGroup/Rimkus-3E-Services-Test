﻿using System;
using System.IO;

namespace TE3EConnect.logs
{
    public class NBIReport
    {
        public string _logFilePath;

        public NBIReport(string filePath = "")
        {
            _logFilePath = !string.IsNullOrEmpty(filePath)
                           ? filePath
                           : string.Format(@"C:\ProgramData\te_3e\Logs\nbi\nbireport.{0}.csv", DateTime.Now.ToString("MMddy.HHmmss"));

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

        public static void GenerateXMLMatterSrv(string matterSrv, string xml)
        {
            string dir = @"C:\ProgramData\te_3e\Logs\Xml\nbi";

            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            string xmlFile = Path.Combine(dir, string.Format("NBI.{0}_{1}.xml", matterSrv, DateTime.Now.ToString("MMddyyyyTHHmmss")));

            if (!File.Exists(xmlFile))
                File.WriteAllText(xmlFile, xml);
        }

        public void MoveCsvToUploadFolder(string csv)
        {
            if (File.Exists(csv))
            {
                string dir = @"C:\ProgramData\te_3e\Logs\Uploaded\nbi";

                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);

                File.Move(csv, Path.Combine(dir, string.Format("{0}_{1}", DateTime.Now.ToString("MMddyyyyTHHmmss"), Path.GetFileName(csv))));
            }
        }
    }
}