using System.Text;

namespace MapCrafterGUI.Extensions
{
    public static class Extensions
    {
        public static void AppendLineFormat(this StringBuilder source, string format, params object[] args)
        {
            source.AppendLine(string.Format(format, args));
        }
    }
}
