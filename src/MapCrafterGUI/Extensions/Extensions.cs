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
        public static void AppendLineFormat(this StringBuilder source, string format, params object[] args)
        {
            source.AppendLine(string.Format(format, args));
        }

        public static DialogResult OpenDialogFromPath(this FolderBrowserDialog source, string destinationFolder)
        {
            if (Directory.Exists(destinationFolder))
                source.SelectedPath = destinationFolder;
            else if (Directory.Exists(Configuration.instance.LastSelectedPath))
                source.SelectedPath = Configuration.instance.LastSelectedPath;
            else
                source.SelectedPath = Environment.CurrentDirectory;

            DialogResult result = source.ShowDialog();

            if (result == DialogResult.OK || result == DialogResult.Yes)
                Configuration.instance.LastSelectedPath = source.SelectedPath;

            return result;
        }
        public static DialogResult OpenDialogFromPath(this FileDialog source, string destinationFolder)
        {
            if (Directory.Exists(destinationFolder))
                source.InitialDirectory = destinationFolder;
            else if (Directory.Exists(Configuration.instance.LastSelectedPath))
                source.InitialDirectory = Configuration.instance.LastSelectedPath;
            else
                source.InitialDirectory = Environment.CurrentDirectory;

            DialogResult result = source.ShowDialog();

            if (result == DialogResult.OK || result == DialogResult.Yes)
            {
                string directory = IOHelper.GetFolderNameFromFile(source.FileName);
                if (!string.IsNullOrEmpty(directory))
                    Configuration.instance.LastSelectedPath = directory;
            }

            return result;
        }
    }
}
