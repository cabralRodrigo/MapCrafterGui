using MapCrafterGUI.Enums;
using System.Collections.Generic;
using System.Text;

namespace MapCrafterGUI.MapCrafterConfiguration
{
    //TODO: add validation of folder of the world. Looking for at least the file level.dat
    public class WorldConfiguration
    {
        public WorldConfiguration(string name, string worldFolder)
        {
            this.InputFolder = worldFolder;
            this.Name = name;
            this.Dimension = Dimension.Overworld;
            this.Maps = new List<MapConfiguration>();
        }

        public string InputFolder { get; set; }
        public string Name { get; set; }
        public Dimension Dimension { get; set; }
        public List<MapConfiguration> Maps { get; set; }
        //TODO: public Point3D DefaultView  { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("[world:{0}]", this.Name));
            sb.AppendLine("input_dir = " + this.InputFolder);
            sb.AppendLine("dimension = " + this.Dimension.ToString().ToLower());
            sb.AppendLine("");
             
            foreach (MapConfiguration map in this.Maps)
                sb.AppendLine(map.ToString(this));
              
            return sb.ToString();
        }
    }
}
