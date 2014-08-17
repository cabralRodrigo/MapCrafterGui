using System.Windows.Forms;

namespace MapCrafterGUI.Helpers
{
    public static class Info
    {
        public const string APPLICATION_CONFIGURATION_FILE = "settings.config";
        public const string LANGUAGE_FILE_EXTENSION = "lang";
        public const string PROJECT_FILE_EXTENSION = "mcp";
        public const string RENDER_CONFIGURATION_FILE_NAME = "render.config";
        public const string RENDER_CONFIGURATION_OUTPUT_FOLDER = "output";
        public const string VERSION_PREFIX = "a";

        public static string Version
        {
            get
            {
                string versionNumber = Application.ProductVersion.Remove(Application.ProductVersion.LastIndexOf('.'));
                return Info.VERSION_PREFIX + versionNumber.Remove(versionNumber.LastIndexOf('.'));
            }
        }
    }
}
