using MapCrafterGUI.ClassValidator;
using MapCrafterGUI.Enums;
using System;
using System.Collections.Generic;
using System.IO;

namespace MapCrafterGUI.MapCrafterConfiguration
{
    [Validatable(true)]
    public class WorldConfiguration
    {
        //public static readonly string Validate_Error_LevelFile = Language.GetLocalizedStringRaw("WorldConfiguration.Error.LevelFileInvalid");

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

        [ValidationDelegate("WorldPath", "InvalidWorldPath", 0)]
        public static Func<WorldConfiguration, bool> WorldPathValidator = Validators.WorldConfigurationValidators.PathValidator;

        [ValidationDelegate("WorldPath", "InvalidWorldPath", 1)]
        public static Func<WorldConfiguration, bool> WorldPathFilesValidator = Validators.WorldConfigurationValidators.WorldFilesValidator;

        [ValidationDelegate("Name", "InvalidWorldName")]
        public static Func<WorldConfiguration, bool> NameValidator = Validators.WorldConfigurationValidators.PathValidator;

    }
}
