using System;
using System.Diagnostics;

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

        //TODO
        private static void AppendToLogFile(string message, MessageLevel level)
        {

        }
    }
}
