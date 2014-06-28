using System;
using System.IO;

namespace MapCrafterGUI.Helpers
{
    public class Logger
    {
        public static string FolderOfLogFile
        {
            get
            {
                return Path.Combine(IOHelper.FolderOfApplication, "log");
            }
        }
        public static string FullNameOfLogFile
        {
            get
            {
                return Path.Combine(Logger.FolderOfLogFile, DateTime.Now.ToString("yyyy.MM.dd") + ".log");
            }
        }

        private static void CreateLogFolder()
        {
            if (!Directory.Exists(Logger.FolderOfLogFile))
                Directory.CreateDirectory(Logger.FolderOfLogFile);
        }

        public static void Log(string textToLog)
        {
            if (!string.IsNullOrEmpty(textToLog))
            {
                Logger.CreateLogFolder();
                File.AppendAllText(Logger.FullNameOfLogFile, string.Format("{0}{1}{2}{1}{1}", DateTime.Now.ToString("HH:mm:ss.fff"), Environment.NewLine, textToLog));
            }
        }
    }
}
