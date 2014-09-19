using MapCrafterGUI.ClassValidator;
using MapCrafterGUI.Forms;
using MapCrafterGUI.LanguageHandler;
using MapCrafterGUI.MapCrafterConfiguration;
using MapCrafterGUI.MapCrafterGUIConfiguration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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

        /// <summary>
        /// Init common stuff for the application
        /// </summary>
        static void InitProgram()
        {
            //Init of the localization system
            LanguageFile.LoadLanguageFile(CultureInfo.CurrentUICulture, new CultureInfo("en-US"));

            //Init of the configuration system
            Configuration.LoadSavedConfig();

            WorldConfiguration w = new WorldConfiguration("", "");

            var errors = Validator.Validate(w).ToList();


        }
    }
}
