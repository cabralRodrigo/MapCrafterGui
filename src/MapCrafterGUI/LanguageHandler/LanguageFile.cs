using MapCrafterGUI.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace MapCrafterGUI.LanguageHandler
{
    /// <summary>
    /// Class that represents a configuration file
    /// </summary>
    public class LanguageFile
    {
        #region Static members

        /// <summary>
        /// Instance of LanguageFile to be used in the application
        /// </summary>
        public static LanguageFile instance;

        /// <summary>
        /// Loads a language file from a CultureInfo object
        /// </summary>
        /// <param name="culture">CultureInfo to load the language file</param>
        /// <param name="defaultCulture">If the load of the language file failed, loads the language file from a default CultureInfo</param>
        public static void LoadLanguageFile(CultureInfo culture, CultureInfo defaultCulture)
        {
            LanguageFile newLang;

            //Loads the language file from the CultureInfo received from parameter, if the load fails, loads the language file from the default CultureInfo
            if (!UtilHelper.LoadFileTypeFromFile(GetLocationOfLanguageFile(culture), out newLang))
                if (!UtilHelper.LoadFileTypeFromFile(GetLocationOfLanguageFile(defaultCulture), out newLang))
                    newLang = new LanguageFile();

            instance = newLang;
        }

        /// <summary>
        /// Builds the path for a language file from a CultureInfo object
        /// </summary>
        /// <param name="culture">CultureInfo to build the path</param>
        /// <returns>Path to the language file</returns>
        private static string GetLocationOfLanguageFile(CultureInfo culture)
        {
            return Path.Combine(IOHelper.FolderOfApplication, "lang", string.Format("{0}.{1}", culture.Name, Info.LANGUAGE_FILE_EXTENSION));
        }

        #endregion

        /// <summary>
        /// Dictionary that stores the fields and the localized strings on the language file
        /// </summary>
        public Dictionary<string, string> Fields;

        /// <summary>
        /// The constructor of the class, initializes the fields-
        /// </summary>
        public LanguageFile()
        {
            this.Fields = new Dictionary<string, string>();
        }

        /// <summary>
        /// Gets a localized string from the language file, with a default value if the string was not found in the language file
        /// </summary>
        /// <param name="fieldName">Field name</param>
        /// <param name="defaultValue">Default value if the value of the field name received does not exist on the language file</param>
        /// <returns>Localized string from the language file</returns>
        public string GetFieldValue(string fieldName, string defaultValue)
        {
            string fieldValue = defaultValue;
            try
            {
                fieldValue = this.Fields[fieldName];
            }
            catch (KeyNotFoundException)
            {
                //If the field name does not exist in the dictionary, logs the warning event
                TraceHelper.Warning("Could not find in the language file, the value for the field " + fieldName);
            }
            catch (Exception ex)
            {
                //If another error occurs, logs the error event
                TraceHelper.Error("Error loading the localized string that belongs to the field " + fieldName, ex);
            }
            return fieldValue;
        }

        /// <summary>
        /// Gets a localized string from the language file
        /// </summary>
        /// <param name="fieldName"Field name></param>
        /// <returns>Localized string from the language file</returns>
        public string GetFieldValue(string fieldName)
        {
            return this.GetFieldValue(fieldName, string.Empty);
        }
    }
}