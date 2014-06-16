using MapCrafterGUI.MapCrafterConfiguration;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;

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

        public static bool LoadFileTypeFromFile<T>(string path, out T objectLoaded)
        {
            objectLoaded = default(T);
            bool successOnLoad = false;
            try
            {
                string textFile = IOHelper.ReadFile(path);
                objectLoaded = JsonConvert.DeserializeObject<T>(textFile);
                successOnLoad = objectLoaded != null;
            }
            catch (Exception ex)
            {
                TraceHelper.ThrowMessage("Error on load a object from a text file. Path: " + path, ex);
            }

            return successOnLoad;
        }

        public static string StringReplaceWithMetadata(string text, object metadata)
        {
            string textWithMetadata = text;
            if (metadata != null)
                foreach (PropertyInfo prop in metadata.GetType().GetProperties().Where(w => w.CanRead))
                {
                    string propName = prop.Name;
                    object propValue = prop.GetValue(metadata);
                    if (propValue != null)
                        textWithMetadata = textWithMetadata.Replace(string.Format("{{{0}}}", propName), propValue.ToString());
                }
            return textWithMetadata;
        }
    }
}
