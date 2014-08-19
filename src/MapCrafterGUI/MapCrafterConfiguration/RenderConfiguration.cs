using MapCrafterGUI.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace MapCrafterGUI.MapCrafterConfiguration
{
    public class RenderConfiguration
    {
        private static RenderConfiguration _instance;

        public RenderConfiguration(string fileName, string outputFolder)
        {
            this.FileName = fileName;
            this.OutputFolder = outputFolder;
            this.Worlds = new List<WorldConfiguration>();
            this.BackgroudColor = UtilHelper.GetColorFromHtmlColor("#DDDDDD");
        }

        public static RenderConfiguration instance
        {
            get
            {
                if (_instance == null)
                    //TODO: Change the default localization
                    _instance = new RenderConfiguration("render.config", "output");
                return _instance;
            }
        }
        public Color BackgroudColor { get; set; }
        public string FileName { get; set; }
        public string OutputFolder { get; set; }
        public List<WorldConfiguration> Worlds { get; set; }

        public static bool LoadFromFile(string path)
        {
            RenderConfiguration newConfig;
            bool success = IOHelper.LoadObjectFromJsonFile(path, out newConfig);
            if (success)
                SetConfiguration(newConfig);

            return success;
        }
        public static void SetConfiguration(RenderConfiguration config)
        {
            _instance = config;
        }
    }
}