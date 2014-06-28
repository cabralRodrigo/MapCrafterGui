using MapCrafterGUI.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapCrafterGUI.LanguageHandler
{
    public class LanguageFile
    {
        public static void LoadLanguageFile(CultureInfo culture)
        {
            LanguageFile newLang;
            if (UtilHelper.LoadFileTypeFromFile(GetLocationOfLanguageFile(culture), out newLang))
                instance = newLang;
            else
                instance = new LanguageFile();
        }

        public static LanguageFile instance;

        private static string GetLocationOfLanguageFile(CultureInfo culture)
        {
            return Path.Combine(IOHelper.FolderOfApplication, "lang", string.Format("{0}.{1}", culture.Name, Info.LANGUAGE_FILE_EXTENSION));
        }

        public Dictionary<string, string> Fields;

        public LanguageFile()
        {
            this.Fields = new Dictionary<string, string>();
        }

        public string GetFieldValue(string fieldName, string defaultValue)
        {
            string fieldValue = defaultValue;
            try
            {
                fieldValue = this.Fields[fieldName];
            }
            catch (KeyNotFoundException)
            {
                TraceHelper.Warning("Could not find in the language file, the value for the field " + fieldName);               
            }
            catch (Exception ex)
            {
                TraceHelper.Error("Error loading the localized string that belongs to the field " + fieldName, ex);
            }
            return fieldValue;
        }

        public string GetFieldValue(string fieldName)
        {
            return this.GetFieldValue(fieldName, string.Empty);
        }
    }
}
