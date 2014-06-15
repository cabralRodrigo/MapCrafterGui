using MapCrafterGUI.Helpers;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace MapCrafterGUI.MapCrafterConfiguration
{
    public class RenderConfiguration
    {
        private static RenderConfiguration _instance;
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

        public static void SetConfiguration(RenderConfiguration config)
        {
            _instance = config;
        }

        public RenderConfiguration(string fileName, string outputFolder)
        {
            this.FileName = fileName;
            this.OutputFolder = outputFolder;
            this.Worlds = new List<WorldConfiguration>();
            this.BackgroudColor = UtilHelper.GetColorFromHtmlColor("#DDDDDD");
        }

        public string FileName { get; set; }
        public string OutputFolder { get; set; }
        public Color BackgroudColor { get; set; }
        public List<WorldConfiguration> Worlds { get; set; }

        //TODO : public List<MarkerConfiguration> Markers { get; set; }

        public string GenerateConfigurationFile()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("output_dir = " + this.OutputFolder);
            sb.AppendLine("background_color = " + UtilHelper.GetHexCodeFromColor(this.BackgroudColor));
            sb.AppendLine("");

            foreach (WorldConfiguration world in this.Worlds)
                sb.AppendLine(world.ToString());

            return sb.ToString();
        }
  
    }
}
