using System.IO;
using System.Reflection;

namespace MapCrafterGUI.Helpers
{
    public static class IOHelper
    {
        /// <summary>
        /// The path from the main assembly file of the application
        /// </summary>
        public static string ApplicationPath
        {
            get
            {
                return Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName;
            }
        }

        /// <summary>
        /// Attempt to create a text file on the path specified
        /// </summary>
        /// <param name="path">Path to create the text file</param>
        /// <param name="text">The content of the text file</param>
        /// <param name="replaceFile">Boolean indicating whether the file will be overwritten if it already exists</param>
        /// <returns>Boolean indicating if the file was created successfully</returns>
        public static bool CreateTextFile(string path, string text, bool replaceFile)
        {
            //Boolean indicating if an error occurred
            bool errorOnCreate = false;

            try
            {
                //Return if the file already exists and the parameter is set to don't replace the file
                if (File.Exists(path) && !replaceFile)
                    return false;

                //Delete the file if he exists
                if (File.Exists(path))
                    File.Delete(path);

                //Create the new file
                File.AppendAllText(path, text);
            }
            catch
            {
                errorOnCreate = true;
            }

            return errorOnCreate;
        }

        /// <summary>
        /// Get the folder name from a path.
        /// </summary>
        /// <param name="path">The paht to get the folder name</param>
        /// <returns>The folder name of the path, null if the path is invalid</returns>
        public static string GetFolderNameFromPath(string path)
        {
            //Get the attributes of the path
            FileAttributes fileAttributes = File.GetAttributes(path);

            if ((fileAttributes & FileAttributes.Directory) == FileAttributes.Directory)
            {
                if (Directory.Exists(path))
                    return path;
                else
                    return null;
            }
            else
            {
                if (File.Exists(path))
                    return new FileInfo(path).DirectoryName;
                else
                    return null;
            }
        }

        /// <summary>
        /// Read a file from a path
        /// </summary>
        /// <param name="path">The path to read the file</param>
        /// <returns>The contents of the file, null if the file don't exists</returns>
        public static string ReadFile(string path)
        {
            if (File.Exists(path))
                return File.ReadAllText(path);
            else
                return null;
        }
    }
}
