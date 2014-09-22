using MapCrafterGUI.ClassValidator;
using MapCrafterGUI.Enums;
using System;
using System.Collections.Generic;

namespace MapCrafterGUI.MapCrafterConfiguration
{
    [Validatable(true)]
    public class WorldConfiguration
    {
        public WorldConfiguration(string name, string worldPath)
        {
            this.WorldPath = worldPath;
            this.Name = name;
            this.Dimension = Dimension.Overworld;
            this.Maps = new List<MapConfiguration>();
        }

        public Dimension Dimension { get; set; }
        public string WorldPath { get; set; }
        public List<MapConfiguration> Maps { get; set; }
        public string Name { get; set; }

        [ValidationDelegate("WorldPath", "InvalidWorldPath", true, 0)]
        public static Func<WorldConfiguration, bool> WorldPathValidator = Validators.WorldConfigurationValidators.PathValidator;

        [ValidationDelegate("WorldPath", "LevelFileInvalid", false, 1)]
        public static Func<WorldConfiguration, bool> WorldPathFilesValidator = Validators.WorldConfigurationValidators.WorldFilesValidator;

        [ValidationDelegate("Name", "InvalidWorldName", true)]
        public static Func<WorldConfiguration, bool> NameValidator = Validators.WorldConfigurationValidators.NameValidator;

    }
}
