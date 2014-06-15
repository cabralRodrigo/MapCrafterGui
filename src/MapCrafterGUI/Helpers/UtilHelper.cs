using MapCrafterGUI.MapCrafterConfiguration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace MapCrafterGUI.Helpers
{
    public static class UtilHelper
    {
        public static Color GetColorFromHtmlColor(string htmlColor)
        {
            return ColorTranslator.FromHtml(htmlColor);
        }

        public static string GetHexCodeFromColor(Color color)
        {
            return string.Format("#{0}{1}{2}", color.R.ToString("X2"), color.G.ToString("X2"), color.B.ToString("X2"));
        }

        public static Dictionary<int, string> ConvertEnumToDictionary<T>() where T : IComparable, IFormattable, IConvertible
        {
            Array arrayEnum = Enum.GetValues(typeof(T));
            Dictionary<int, string> dicEnum = new Dictionary<int, string>();

            for (int i = 0; i < arrayEnum.GetLength(0); i++)
                dicEnum.Add(i, arrayEnum.GetValue(i).ToString());

            return dicEnum;
        }

        public static bool LoadConfigurationFromFile(string path, out RenderConfiguration configuration)
        {
            RenderConfiguration config = null;
            bool successOnLoad = false;

            try
            {
                if (IOHelper.GetFileExtension(path) == "." + Info.PROJECT_FILE_EXTENSION)
                {
                    string textFile = IOHelper.ReadFile(path);
                    config = JsonConvert.DeserializeObject<RenderConfiguration>(textFile);
                    successOnLoad = true;
                }
            }
            catch { }

            configuration = config;
            return successOnLoad;
        }
    }
}
