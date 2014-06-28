using System;
using System.Diagnostics;
using System.IO;

namespace MapCrafterGUI.Helpers
{
    public static class TraceHelper
    {
        private enum MessageLevel
        {
            Info,
            Warning,
            Error
        }

        public static void Warning(string warning)
        {
            LogMessage(warning, MessageLevel.Warning);
        }

        public static void Info(string info)
        {
            LogMessage(info, MessageLevel.Info);
        }

        public static void Error(string error, Exception ex)
        {
            LogMessage(string.Format("{0}{1}{2}", ex.Message, Environment.NewLine, error), MessageLevel.Error);
        }

        private static void LogMessage(string message, MessageLevel level)
        {
            Console.WriteLine(message);
            Trace.WriteLine(message);

            if (level != MessageLevel.Info)
            {
                AppendToLogFile(message, level);
                if (Debugger.IsAttached && level == MessageLevel.Error)
                    Debugger.Break();
            }
        }

        private static void AppendToLogFile(string message, MessageLevel level)
        {
            string messageToLog = string.Format("Level: {0}{1}Log: {2}", level.ToString(), Environment.NewLine, message);
            Logger.Log(messageToLog);
        }
    }
}
