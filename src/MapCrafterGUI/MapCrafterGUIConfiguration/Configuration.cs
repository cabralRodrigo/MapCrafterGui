using MapCrafterGUI.Helpers;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace MapCrafterGUI.MapCrafterGUIConfiguration
{
    public class Configuration : SynchronizableClass<Configuration>
    {
        #region Static Members

        private static Configuration _instance;
        public static Configuration instance { get { return _instance; } }

        public Configuration() : base(Configuration.ConfigurationFilePath) { }

        private static string ConfigurationFilePath
        {
            get
            {
                return Path.Combine(IOHelper.ApplicationPath, Info.APPLICATION_CONFIGURATION_FILE);
            }
        }

        public static Configuration GetDefaultConfig()
        {
            Configuration config = new Configuration();
            config.DisableSynchronization();
            config.LastSelectedPath = string.Empty;
            config.EnableSynchonization();

            return config;
        }

        #endregion

        #region Synchronizable
        protected override Configuration GetDefault()
        {
            return Configuration.GetDefaultConfig();
        }

        private string lastSelectedPath;
        public string LastSelectedPath
        {
            get { return lastSelectedPath; }
            set { base.SynchronizePropertySet<string>(ref lastSelectedPath, value); }
        }
        #endregion


        public static void LoadSavedConfig()
        {
            Configuration config = null;
            bool success = UtilHelper.LoadFileTypeFromFile<Configuration>(Configuration.ConfigurationFilePath, out config);

            if (!success || config == null)
                config = Configuration.GetDefaultConfig();

            Configuration._instance = config;            
        }
    }
}