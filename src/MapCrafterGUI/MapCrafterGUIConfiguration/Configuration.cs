using MapCrafterGUI.Helpers;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace MapCrafterGUI.MapCrafterGUIConfiguration
{
    public class Configuration
    {
        #region Static Members

        private static Configuration _instance;
        public static Configuration instance { get { return _instance; } }

        public Configuration()
        {
            this.savePropertiesOnChanged = false;
        }

        public static string ConfigurationFilePath
        {
            get
            {
                return Path.Combine(IOHelper.FolderOfApplication, Info.APPLICATION_CONFIGURATION_FILE);
            }
        }
        public static void InitConfiguration()
        {
            Configuration.SetInstance(Configuration.LoadConfigurationFromFile());
        }
        public static Configuration GetDefaultConfiguration()
        {
            Configuration defaultConfig = new Configuration();
            return defaultConfig;
        }

        private static void CreateConfigurationFile()
        {
            if (!File.Exists(ConfigurationFilePath))
            {
                string stringDefaultConfig = JsonConvert.SerializeObject(Configuration.GetDefaultConfiguration());
                IOHelper.CreateTextFile(ConfigurationFilePath, stringDefaultConfig, false);
            }
        }
        private static Configuration LoadConfigurationFromFile()
        {
            Configuration.CreateConfigurationFile();

            Configuration configLoaded;
            bool configLoadedSuccess = UtilHelper.LoadFileTypeFromFile<Configuration>(ConfigurationFilePath, out configLoaded);

            if (configLoaded == null || !configLoadedSuccess)
                configLoaded = Configuration.GetDefaultConfiguration();

            return configLoaded;
        }
        private static void SetInstance(Configuration config)
        {
            config.savePropertiesOnChanged = true;
            _instance = config;
        }

        #endregion

        [JsonIgnore]
        private bool savePropertiesOnChanged;

        public void SaveConfiguration()
        {
            Configuration configSaved = LoadConfigurationFromFile();

            string stringConfigToSave = JsonConvert.SerializeObject(this);
            string stringConfigSaved = JsonConvert.SerializeObject(configSaved);

            try
            {
                File.Delete(ConfigurationFilePath);
                IOHelper.CreateTextFile(ConfigurationFilePath, stringConfigToSave, false);
            }
            catch (Exception ex)
            {
                TraceHelper.Error("Error saving the configuration file in the directory " + ConfigurationFilePath, ex);
                IOHelper.CreateTextFile(ConfigurationFilePath, stringConfigSaved, true);
            }
        }

        private void SetPropertyAndSaveConfigFile<T>(ref T property, T value, [CallerMemberName] string propertyName = null)
        {
            bool isEqual = UtilHelper.CompareObjects(property, value);
            property = value;
            
            if (this.savePropertiesOnChanged && !isEqual)
            {
                TraceHelper.Info(string.Format("Automatically saving the \"{0}\" property, with the value \"{1}\"", propertyName, value));
                this.SaveConfiguration();
            }
            
        }

        [OnDeserializing]
        internal void OnDeserializing(StreamingContext context)
        {
            this.savePropertiesOnChanged = false;
        }

        [OnDeserialized]
        internal void OnDeserialized(StreamingContext context)
        {
            this.savePropertiesOnChanged = true;
        }
    }
}