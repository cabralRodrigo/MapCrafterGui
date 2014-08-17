using System;
using System.IO;

namespace MapCrafterGUI.Helpers
{
    public class Logger
    {
        public static string LogFileFolder
        {
            get
            {
                return Path.Combine(IOHelper.FolderOfApplication, "log");
            }
        }
       
        public static string LogFileName
        {
            get
            {
                return Path.Combine(Logger.LogFileFolder, DateTime.Now.ToString("yyyy.MM.dd") + ".log");
            }
        }

        public static void Log(string textToLog)
        {
            if (!string.IsNullOrEmpty(textToLog))
            {
                Logger.CreateLogFolder();
                File.AppendAllText(Logger.LogFileName, string.Format("{0}{1}{2}{1}{1}", DateTime.Now.ToString("HH:mm:ss.fff"), Environment.NewLine, textToLog));
            }
        }

        private static void CreateLogFolder()
        {
            if (!Directory.Exists(Logger.LogFileFolder))
                Directory.CreateDirectory(Logger.LogFileFolder);
        }
    }
}
