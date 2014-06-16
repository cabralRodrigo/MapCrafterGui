using MapCrafterGUI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapCrafterGUI.MapCrafterConfiguration
{
    public class MapConfiguration
    {
        public static MapRotation DefaultRotation = MapRotation.TopLeft;

        public Guid MapID { get; set; }
        public string Name { get; set; }
        public RenderMode RenderMode { get; set; }
        private List<MapRotation> Rotations { get; set; }

        public MapConfiguration(string name, WorldConfiguration world)
        {
            this.MapID = Guid.NewGuid();
            this.Name = name;
            this.RenderMode = RenderMode.Normal;
            this.Rotations = new List<MapRotation>();
            this.AddRotation(MapConfiguration.DefaultRotation);
        }

        public void AddRotation(MapRotation rotation)
        {
            if (!this.Rotations.Contains(rotation))
                this.Rotations.Add(rotation);
        }

        public void RemoveRotation(MapRotation rotation)
        {
            if (this.Rotations.Contains(rotation))
                this.Rotations.Remove(rotation);
        }

        public MapRotation[] GetRotations()
        {
            return this.Rotations.Distinct().ToArray();
        }


        public string ToString(WorldConfiguration world)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("[map:{0}]", this.MapID.ToString()));
            sb.AppendLine("name = " + this.Name);
            sb.AppendLine("world = " + world.Name);
            sb.AppendLine("rendermode = " + this.RenderMode.ToString().ToLower());
            sb.AppendLine("rotations =" + this.GetRotationsToString());

            return sb.ToString();
        }

        private string GetRotationsToString()
        {
            StringBuilder sb = new StringBuilder();

            if (this.GetRotations().Length == 0)
                sb.Append(" " + MapConfiguration.DefaultRotation.ToString());
            else
                foreach (var rotation in this.GetRotations())
                    sb.Append(" " + rotation.ToString().ToLower().Replace('_', '-'));

            return sb.ToString();
        }

    }
}
