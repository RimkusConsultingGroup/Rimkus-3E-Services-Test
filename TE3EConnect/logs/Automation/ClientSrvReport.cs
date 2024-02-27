﻿using System;
using System.IO;
using TE3EEntityFramework.Extension;

namespace TE3EConnect.logs
{
    public class ClientSrvReport
    {
        public string _logFilePath;

        public ClientSrvReport(string filePath = "")
        {
            _logFilePath = !string.IsNullOrEmpty(filePath)
                           ? filePath
                           : string.Format(@"C:\ProgramData\te_3e\Logs\automation\clientsrv\clientsrvreport.{0}.csv", DateTime.Now.ToString("MMddy.HHmmss"));

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

        public static string GenerateXMLClientSrvReport(string id, string xml)
        {
            string dir = @"C:\ProgramData\te_3e\Logs\automation\clientsrv\xml";

            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            string xmlFile = Path.Combine(dir, string.Format("clientsrv_{0}_{1}_payload.xml", id, DateTime.Now.ToString("MMddyyyyTHHmmss")).MakeSafeForFileName());

            if (!File.Exists(xmlFile))
                File.WriteAllText(xmlFile, xml);

            return xmlFile;
        }

        public static string GenerateResultXMLClientSrvReport(string id, string xml)
        {
            string dir = @"C:\ProgramData\te_3e\Logs\automation\clientsrv\xml\results";

            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            string xmlFile = Path.Combine(dir, string.Format("clientsrv_{0}_{1}_result.xml", id, DateTime.Now.ToString("MMddyyyyTHHmmss")).MakeSafeForFileName());

            if (!File.Exists(xmlFile))
                File.WriteAllText(xmlFile, xml);

            return xmlFile;
        }
    }
}