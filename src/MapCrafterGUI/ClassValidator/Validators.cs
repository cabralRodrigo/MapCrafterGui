using MapCrafterGUI.MapCrafterConfiguration;
using System;
using System.IO;

namespace MapCrafterGUI.ClassValidator
{
    /// <summary>
    /// The class which will store all the validation delegates
    /// </summary>
    public static class Validators
    {
        public static class WorldConfigurationValidators
        {
            public static Func<WorldConfiguration, bool> PathValidator
            {
                get
                {
                    return world => Directory.Exists(world.WorldPath);
                }
            }

            public static Func<WorldConfiguration, bool> WorldFilesValidator
            {
                get
                {
                    return world =>
                    {
                        string[] filesToSearch = { "level.dat" };
                        string[] foldersToSearch = { "data", "players", "region", "stats", "DIM1", "DIM-1" };
                        bool correctFolder = true;

                        foreach (string file in filesToSearch)
                            if (!File.Exists(Path.Combine(world.WorldPath, file)))
                            {
                                correctFolder = false;
                                break;
                            }

                        if (correctFolder)
                            foreach (string folder in foldersToSearch)
                                if (!Directory.Exists(Path.Combine(world.WorldPath, folder)))
                                {
                                    correctFolder = false;
                                    break;
                                }


                        return correctFolder;
                    };
                }
            }

            public static Func<WorldConfiguration, bool> NameValidator
            {
                get
                {
                    return world => world.Name == null ? false : !string.IsNullOrEmpty(world.Name.Trim());
                }
            }
        }

        public static class RenderConfigurationValidators
        {
            public static Func<RenderConfiguration, bool> OutputFolderValidator
            {
                get
                {
                    return renderConfiguration => File.Exists(renderConfiguration.OutputFolder);
                }
            }
        }

        public static class MapConfigurationValidators
        {
            public static Func<MapConfiguration, bool> MapIDValidator
            {
                get
                {
                    return mapConfiguration => mapConfiguration.MapID != Guid.Empty;
                }
            }

            public static Func<MapConfiguration, bool> NameValidator
            {
                get
                {
                    return mapConfiguration => !string.IsNullOrEmpty(mapConfiguration.Name);
                }
            }
        }
    }
}
