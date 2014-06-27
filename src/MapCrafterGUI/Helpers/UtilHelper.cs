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
        public static Color GetColorFromHtmlColor(string htmlColor)
        {
            return ColorTranslator.FromHtml(htmlColor);
        }

        public static string GetHexCodeFromColor(Color color)
        {
            return string.Format("#{0}{1}{2}", color.R.ToString("X2"), color.G.ToString("X2"), color.B.ToString("X2"));
        }

        public static Dictionary<int, string> ConvertEnumToDictionary<T>(bool useLocalizedEnumDescription) where T : IComparable, IFormattable, IConvertible
        {
            Array arrayEnum = Enum.GetValues(typeof(T));
            Dictionary<int, string> dicEnum = new Dictionary<int, string>();

            for (int i = 0; i < arrayEnum.GetLength(0); i++)
            {
                string enumDescription;
                if (useLocalizedEnumDescription)
                    enumDescription = Language.GetLocalizedDescriptionForEnum((Enum)Enum.Parse(typeof(T), i.ToString()));
                else
                    enumDescription = arrayEnum.GetValue(i).ToString();
                dicEnum.Add(i, enumDescription);
            }

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

        public static string GetEnumDescription(Enum en)
        {
            string enumDescription = string.Empty;
            DescriptionAttribute descAttribute = GetAttributesOfEnum<DescriptionAttribute>(en);
            if (descAttribute != null)
                enumDescription = descAttribute.Description;

            return enumDescription;
        }

        public static string GetEnumValue(Enum en)
        {
            string enumValue = string.Empty;
            DefaultValueAttribute valueAttribute = GetAttributesOfEnum<DefaultValueAttribute>(en);
            if (valueAttribute != null)
                enumValue = (valueAttribute.Value ?? string.Empty).ToString();

            return enumValue;
        }

        private static T GetAttributesOfEnum<T>(Enum en) where T : Attribute
        {
            return en.GetType().GetField(en.ToString()).GetCustomAttribute<T>();
        }
    }
}
