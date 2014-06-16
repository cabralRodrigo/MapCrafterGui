using System;
using System.Diagnostics;

namespace MapCrafterGUI.Helpers
{
    public static class TraceHelper
    {
        public static void ThrowMessage(string message)
        {
            #if DEBUG
                Console.WriteLine(message);
                Trace.WriteLine(message);
                Debug.WriteLine(message);

                if (Debugger.IsAttached)
                    Debugger.Break();
            #endif
        }

        public static void ThrowMessage(string message, Exception exception)
        {
            ThrowMessage(string.Format("Ex.:{0}{1}{2}", exception.Message, Environment.NewLine, message));
        }
    }
}
