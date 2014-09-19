using MapCrafterGUI.MapCrafterConfiguration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapCrafterGUI.ClassValidator
{
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
                                if (!File.Exists(Path.Combine(world.WorldPath, folder)))
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
                    return world => !string.IsNullOrEmpty(world.Name);
                }
            }
        }
    }
}
