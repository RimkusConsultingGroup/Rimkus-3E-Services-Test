using System;
using System.Diagnostics;
using System.IO;

namespace TE3EConnect.logs
{
    public class Logger
    {
        public string _logFilePath;

        public Logger(string process, string filePath="")
        {
            _logFilePath = !string.IsNullOrEmpty(filePath)
                           ? filePath
                           : string.Format(@"C:\ProgramData\te_3e\Logs\{0}.{1}.log", process, DateTime.Now.ToString("MMddy"));
        }

        public void Error(Exception ex)
        {
            Log("_______________________________________________");
            Log(ex.Message);
            Log(string.Format("| ERROR | {0}", ex.Message));
            //
            //Log(ex.StackTrace);
        }

        public void Info(string msg)
        {
            Log("_______________________________________________");
            Log(string.Format("| INFO | {0}", msg));
            //
            //Log(ex.StackTrace);
        }

        public void Log(string message)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(_logFilePath, true))
                {
                    sw.WriteLine(DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss") + " " + message);
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }

}