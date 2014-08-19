using MapCrafterGUI.LanguageHandler;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;

namespace MapCrafterGUI.Helpers
{
    public static class UtilHelper
    {
        public static bool CompareObjects<T>(T obj1, T obj2)
        {
            bool equals = false;

            if (obj1 == null && obj2 == null)
                equals = true;

            if ((obj1 == null && obj2 != null) || (obj1 != null && obj2 != null))
                equals = obj2.Equals(obj1);

            if (obj2 == null && obj1 != null)
                equals = obj1.Equals(obj2);

            return equals;
        }
    
        public static Color GetColorFromHtmlColor(string htmlColor)
        {
            return ColorTranslator.FromHtml(htmlColor);
        }

        public static string GetHexCodeFromColor(Color color)
        {
            return string.Format("#{0}{1}{2}", color.R.ToString("X2"), color.G.ToString("X2"), color.B.ToString("X2"));
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
                TraceHelper.Error("Error while loading an object from a file. Path:" + path, ex);
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