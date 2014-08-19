using MapCrafterGUI.Helpers;
using MapCrafterGUI.MapCrafterGUIConfiguration;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace MapCrafterGUI.Extensions
{
    public static class Extensions
    {
        /// <summary>
        /// Format the string and append a copy of the formated string followed by the default line terminator
        /// </summary>
        /// <param name="source">The instance of the StringBuilder to apped</param>
        /// <param name="format">A composite format string</param>
        /// <param name="args">An array of objects to format</param>
        public static void AppendLineFormat(this StringBuilder source, string format, params object[] args)
        {
            source.AppendLine(string.Format(format, args));
        }

        /// <summary>
        /// Open the FolderBrowserDialog and attempt to open the dialog on the specified path
        /// </summary>
        /// <param name="source">The instance of the dialog</param>
        /// <param name="destinationPath">The path to attempt to set on the dialog</param>
        /// <returns>The result from the dialog</returns>
        public static DialogResult OpenDialogFromPath(this FolderBrowserDialog source, string destinationFolder)
        {
            return Extensions.OpenDialogFromPathLogic(source, (dialog, path) => dialog.SelectedPath = path, dialog => dialog.SelectedPath, destinationFolder);
        }

        /// <summary>
        /// Open the FileDialog and attempt to open the dialog on the specified path
        /// </summary>
        /// <param name="source">The instance of the dialog</param>
        /// <param name="destinationPath">The path to attempt to set on the dialog</param>
        /// <returns>The result from the dialog</returns>
        public static DialogResult OpenDialogFromPath(this FileDialog source, string destinationPath)
        {
            return Extensions.OpenDialogFromPathLogic(source, (dialog, path) => dialog.InitialDirectory = path, dialog => dialog.FileName, destinationPath);
        }

        /// <summary>
        /// Handle the opening of a common dialog
        /// </summary>
        /// <typeparam name="T">The type of the dialog</typeparam>
        /// <param name="dialog">The instance of the dialog</param>
        /// <param name="setDialogPath">Delegate which will set the path on the dialog</param>
        /// <param name="getDialogPath">Delegate which will get the path on the dialog</param>
        /// <param name="destinationPath">Destination folder to attempt set on the dialog</param>
        /// <returns>DialogResult of opening the dialog</returns>
        private static DialogResult OpenDialogFromPathLogic<T>(T dialog, Action<T, string> setDialogPath, Func<T, string> getDialogPath, string destinationPath) where T : CommonDialog
        {
            //First try to set the destination folder parameter on the dialog
            if (Directory.Exists(destinationPath))
                setDialogPath(dialog, destinationPath);

            //Then try to set the last selected path on the config file
            else if (Directory.Exists(Configuration.instance.LastSelectedPath))
                setDialogPath(dialog, Configuration.instance.LastSelectedPath);

            //if everything else fails, set the current directory of the applicatin
            else
                setDialogPath(dialog, Environment.CurrentDirectory);

            //Show the dialog and get the result from its
            DialogResult result = dialog.ShowDialog();

            //Update the last selecte path in the config file
            if (result == DialogResult.OK || result == DialogResult.Yes)
            {
                string newDirectory = IOHelper.GetFolderNameFromPath(getDialogPath(dialog));
                if (!string.IsNullOrEmpty(newDirectory))
                    Configuration.instance.LastSelectedPath = newDirectory;
            }

            return result;
        }
    }
}