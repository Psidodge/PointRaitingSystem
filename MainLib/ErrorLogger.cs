using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace MainLib
{
    public class ErrorLogger
    {
        private string logFolderPath,
                       currentLogFilePath;

        //TOREF: logFileDesc - не используется
        //private FileStream logFileDesc;
        private bool inDebugMode = false;

        public ErrorLogger()
        {
            logFolderPath = Directory.GetCurrentDirectory();
            CreateLogFolder();
            CreateLogFile();
        }

        public void Debug(string debugMsg)
        {
            StreamWriter sw = File.AppendText(currentLogFilePath);
            if (inDebugMode)
            {
                sw.WriteLine(string.Format("DEBUG - {0}", debugMsg));
            }
            sw.Close();
        }
        public void Error(object sender, string errorMsg)
        {
            StreamWriter sw = File.AppendText(currentLogFilePath);
            sw.WriteLine(string.Format("ERROR at {0} - {1}", sender.ToString(), errorMsg));
            sw.Close();
        }
        public void ErrorStackTrace(string stackTrace)
        {
            StreamWriter sw = File.AppendText(currentLogFilePath);
            sw.WriteLine(stackTrace);
            sw.Close();
        }

        //TODO: дописать метод деструктора
        public void Close()
        {
        }


        private void CreateLogFolder()
        {
            if (!Directory.Exists(Path.Combine(logFolderPath, "Logs")))
            {
                Directory.CreateDirectory(Path.Combine(logFolderPath, "Logs"));
            }
            logFolderPath = Path.Combine(logFolderPath, "Log");
        }
        private void CreateLogFile()
        {
            string prefixLog = DateTime.Today.Date.ToString().Split(' ')[0].Replace('.', '_');
            currentLogFilePath = Path.Combine(logFolderPath, string.Format("{0} {1}",prefixLog, "log.txt"));

            if (!File.Exists(currentLogFilePath))
                File.Create(currentLogFilePath).Close();
        }

        public string GetLogFolderPath { get => logFolderPath; }
        public string GetLogFilePath { get => currentLogFilePath; }
        public bool DebugMode { get => inDebugMode; set => inDebugMode = value; }
    }
}
