using System.IO;
using System.Reflection;

namespace MapCrafterGUI.Helpers
{
    public static class IOHelper
    {
        public static string FolderOfApplication
        {
            get
            {
                return Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName;
            }
        }

        public static bool CreateTextFile(string path, string text, bool replaceFileIfExists)
        {
            bool errorOnCreate = false;

            try
            {
                if (File.Exists(path) && !replaceFileIfExists)
                    return false;

                if (File.Exists(path))
                    File.Delete(path);

                File.AppendAllText(path, text);
            }
            catch
            {
                errorOnCreate = true;
            }

            return errorOnCreate;
        }

        public static string GetFileExtension(string path)
        {
            return new FileInfo(path).Extension;
        }

        public static string ReadFile(string path)
        {
            return File.ReadAllText(path);
        }
    }
}
