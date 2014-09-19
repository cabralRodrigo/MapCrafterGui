using MapCrafterGUI.ClassValidator;
using MapCrafterGUI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MapCrafterGUI.MapCrafterConfiguration
{
    [Validatable(true)]
    public class MapConfiguration
    {
        public static MapRotation DefaultRotation = MapRotation.TopLeft;

        public MapConfiguration(string name)
        {
            this.MapID = Guid.NewGuid();
            this.Name = name;
            this.RenderMode = RenderMode.Normal;
            this.Rotations = new List<MapRotation>();
            this.AddRotation(MapConfiguration.DefaultRotation);
        }

        public Guid MapID { get; set; }
        public string Name { get; set; }
        public RenderMode RenderMode { get; set; }
        private List<MapRotation> Rotations { get; set; }

        public void AddRotation(MapRotation rotation)
        {
            if (!this.Rotations.Contains(rotation))
                this.Rotations.Add(rotation);
        }
        public MapRotation[] GetRotations()
        {
            return this.Rotations.Distinct().ToArray();
        }
        public void RemoveRotation(MapRotation rotation)
        {
            if (this.Rotations.Contains(rotation))
                this.Rotations.Remove(rotation);
        }

        [ValidationDelegate("InvalidMapID", "MapID")]
        public static Func<MapConfiguration, bool> MapIDValidator = m => m.MapID != Guid.Empty;

        [ValidationDelegate("InvalidMapMap", "Name")]
        public static Func<MapConfiguration, bool> NameValidator = m => !string.IsNullOrEmpty(m.Name);
    }
}