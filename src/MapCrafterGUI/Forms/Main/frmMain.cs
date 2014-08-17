using MapCrafterGUI.Dialogs;
using MapCrafterGUI.Forms.Main;
using MapCrafterGUI.Helpers;
using MapCrafterGUI.LanguageHandler;
using MapCrafterGUI.MapCrafterConfiguration;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Windows.Forms;

namespace MapCrafterGUI.Forms
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

            this.RefreshForm();

            string dialogsFilterDescription = Language.GetLocalizedStringRaw("frmMain.dialogSaveOpen.Filter");
            this.dialogSaveProject.DefaultExt = Info.PROJECT_FILE_EXTENSION;
            this.dialogSaveProject.Filter = string.Format("{0}|*.{1}", dialogsFilterDescription, Info.PROJECT_FILE_EXTENSION);

            this.dialogOpenProject.DefaultExt = Info.PROJECT_FILE_EXTENSION;
            this.dialogOpenProject.Filter = string.Format("{0}|*.{1}", dialogsFilterDescription, Info.PROJECT_FILE_EXTENSION);

            this.lblRenderConfigurationOutputPath.SetLocalizedField(LanguageControlField.Text);
            this.lblRenderConfigurationFileName.SetLocalizedField(LanguageControlField.Text);
            this.lblRenderConfigurationColor.SetLocalizedField(LanguageControlField.Text);
            this.groupRenderConfig.SetLocalizedField(LanguageControlField.Text);
            this.btnRenderCondigurationOutput.SetLocalizedField(LanguageControlField.Text);
            this.btnAddWorld.SetLocalizedField(LanguageControlField.Text);
            this.SetLocalizedField(LanguageControlField.Text, new { Version = Info.Version });

            this.menuItemLoadConfig.Text = Language.GetLocalizedStringRaw("frmMain.menuItemLoadConfig.Text");
            this.menuItemSaveConfig.Text = Language.GetLocalizedStringRaw("frmMain.menuItemSaveConfig.Text");
            this.menuItemNewConfig.Text = Language.GetLocalizedStringRaw("frmMain.menuItemNewConfig.Text");
            this.menuItemFile.Text = Language.GetLocalizedStringRaw("frmMain.menuItemFile.Text");
            this.dialogOpenProject.Title = Language.GetLocalizedStringRaw("frmMain.dialogOpenProject.Title");
            this.dialogSaveProject.Title = Language.GetLocalizedStringRaw("frmMain.dialogSaveProject.Title");
            this.dialogRenderConfigurationOutput.Description = Language.GetLocalizedStringRaw("frmMain.dialogRenderConfigurationOutput.Description");
        }

        private RenderConfiguration config { get { return RenderConfiguration.instance; } }

        private void btnAddWorld_Click(object sender, EventArgs e)
        {
            using (frmAddWorld addWorldDialog = new frmAddWorld(config))
                if (addWorldDialog.ShowDialog() == DialogResult.OK)
                    RefreshForm();
        }

        private void btnDebug_Click(object sender, EventArgs e)
        {
            var ser = JsonConvert.SerializeObject(this.config);
            this.RefreshForm();
            config.GenerateConfigurationFile();
        }

        private void btnRenderCondigurationOutput_Click(object sender, EventArgs e)
        {
            dialogRenderConfigurationOutput.SelectedPath = Environment.CurrentDirectory;
            if (dialogRenderConfigurationOutput.ShowDialog() == DialogResult.OK)
            {
                this.config.OutputFolder = dialogRenderConfigurationOutput.SelectedPath;
                this.RefreshForm();
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
        }

        private void menuItemLoadConfig_Click(object sender, EventArgs e)
        {
            dialogOpenProject.InitialDirectory = Environment.CurrentDirectory;
            if (dialogOpenProject.ShowDialog() == DialogResult.OK)
            {
                string errorOnOpening = Language.GetLocalizedGenericFieldForControl(this, LanguageGenericField.Error, "ErrorOnOpeningFile", new { LineBreak = Environment.NewLine });
                string errorOnOpeningCaption = Language.GetLocalizedGenericFieldForControl(this, LanguageGenericField.Error, "ErrorOnOpeningFileCaption");

                if (RenderConfiguration.LoadFromFile(dialogOpenProject.FileName))
                {

                    this.RefreshForm();
                    if (RenderConfiguration.instance.Worlds.Where(w => !w.IsWorldValid()).Count() > 0)
                    {
                        string worldsInvalid = Language.GetLocalizedGenericFieldForControl(this, LanguageGenericField.Info, "WorldInfoInvalid", new { LineBreak = Environment.NewLine });
                        string worldsInvalidCaption = Language.GetLocalizedGenericFieldForControl(this, LanguageGenericField.Info, "WorldInfoInvalidCaption");

                        MessageBox.Show(worldsInvalid, worldsInvalidCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show(errorOnOpening, errorOnOpeningCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menuItemNewConfig_Click(object sender, EventArgs e)
        {
            RenderConfiguration.SetConfiguration(new RenderConfiguration(Info.RENDER_CONFIGURATION_FILE_NAME, Info.RENDER_CONFIGURATION_OUTPUT_FOLDER));
            this.RefreshForm();
        }

        private void menuItemSaveConfig_Click(object sender, EventArgs e)
        {
            dialogSaveProject.InitialDirectory = Environment.CurrentDirectory;
            if (dialogSaveProject.ShowDialog() == DialogResult.OK)
                IOHelper.CreateTextFile(dialogSaveProject.FileName, JsonConvert.SerializeObject(this.config), true);

        }

        private void pnBackgroundColor_Click(object sender, EventArgs e)
        {
            dialogBackgroundColor.Color = config.BackgroudColor;
            if (dialogBackgroundColor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.config.BackgroudColor = dialogBackgroundColor.Color;
                this.RefreshForm();
            }
        }

        private void RefreshForm()
        {
            this.txtRenderConfigurationFileName.Text = config.FileName;
            this.txtRenderConfigurationOutputPath.Text = config.OutputFolder;

            this.pnBackgroundColor.BackColor = config.BackgroudColor;
            tabsWorlds.Controls.Clear();

            foreach (WorldConfiguration world in config.Worlds)
                tabsWorlds.Controls.Add(new TabPageWorld(world));
        }
    }
}