using MapCrafterGUI.Forms;
using MapCrafterGUI.LanguageHandler;
using MapCrafterGUI.MapCrafterGUIConfiguration;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace MapCrafterGUI
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            InitProgram();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }

        static void InitProgram()
        {
            LanguageFile.LoadLanguageFile(new CultureInfo("pt-BR"));
            Configuration.InitConfiguration();
        }
    }
}
