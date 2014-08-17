﻿using MapCrafterGUI.Enums;
using MapCrafterGUI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapCrafterGUI.MapCrafterConfiguration
{
    public class MapConfiguration
    {
        public static MapRotation DefaultRotation = MapRotation.TopLeft;

        public MapConfiguration(string name, WorldConfiguration world)
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

        private string GetRotationsToString()
        {
            StringBuilder sb = new StringBuilder();

            if (this.GetRotations().Length == 0)
                sb.Append(" " + UtilHelper.GetEnumValue(MapConfiguration.DefaultRotation));
            else
                foreach (var rotation in this.GetRotations())
                    sb.Append(" " + UtilHelper.GetEnumValue(rotation));

            return sb.ToString();
        }
    }
}