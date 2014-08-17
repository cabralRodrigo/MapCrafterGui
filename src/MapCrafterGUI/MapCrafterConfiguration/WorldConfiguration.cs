using MapCrafterGUI.Enums;
using MapCrafterGUI.LanguageHandler;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text;

namespace MapCrafterGUI.MapCrafterConfiguration
{
    public class WorldConfiguration
    {
        public static readonly string Validate_Error_FolderWorld = Language.GetLocalizedStringRaw("WorldConfiguration.Error.WorldFolderInvalid");
        public static readonly string Validate_Error_LevelFile = Language.GetLocalizedStringRaw("WorldConfiguration.Error.LevelFileInvalid");
        public static readonly string Validate_Error_WorldName = Language.GetLocalizedStringRaw("WorldConfiguration.Error.WorldNameInvalid");

        public WorldConfiguration(string name, string worldFolder)
        {
            this.InputFolder = worldFolder;
            this.Name = name;
            this.Dimension = Dimension.Overworld;
            this.Maps = new List<MapConfiguration>();
        }

        public Dimension Dimension { get; set; }
        public string InputFolder { get; set; }
        public List<MapConfiguration> Maps { get; set; }
        public string Name { get; set; }

        public static bool Validate_FolderWorld(string worldFolder)
        {
            return Directory.Exists(worldFolder);
        }
        public static bool Validate_LevelFile(string worldFolder)
        {
            return File.Exists(Path.Combine(worldFolder, "level.dat"));
        }
        public static bool Validate_WorldName(string worldName)
        {
            return !string.IsNullOrEmpty(worldName);
        }
        public bool IsWorldValid()
        {
            return Validate_FolderWorld(this.InputFolder) && Validate_LevelFile(this.InputFolder);
        }
        
        [OnDeserialized]
        internal void OnDeserialized(StreamingContext context)
        {
            if (string.IsNullOrEmpty(this.Name))
                throw new Exception(Language.GetLocalizedStringRaw("WorldConfiguration.Error.WorldNameEmpty"));
        }
    }
}
