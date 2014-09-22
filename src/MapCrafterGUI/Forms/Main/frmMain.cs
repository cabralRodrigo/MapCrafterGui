using MapCrafterGUI.Dialogs;
using MapCrafterGUI.Extensions;
using MapCrafterGUI.Forms.Main;
using MapCrafterGUI.Helpers;
using MapCrafterGUI.LanguageHandler;
using MapCrafterGUI.MapCrafterConfiguration;
using MapCrafterGUI.MapCrafterGUIConfiguration;
using Newtonsoft.Json;
using System;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace MapCrafterGUI.Forms
{
    public partial class frmMain : Form
    {
        private RenderConfiguration config { get { return RenderConfiguration.instance; } }

        public frmMain()
        {
            InitializeComponent();

            this.RefreshForm();
            this.LoadCurrentLanguage();
        }

        private void LoadCurrentLanguage()
        {
            this.lblRenderConfigurationOutputPath.SetLocalizedField(LanguageControlField.Text);
            this.lblRenderConfigurationFileName.SetLocalizedField(LanguageControlField.Text);
            this.lblRenderConfigurationColor.SetLocalizedField(LanguageControlField.Text);
            this.groupRenderConfig.SetLocalizedField(LanguageControlField.Text);
            this.btnRenderCondigurationOutput.SetLocalizedField(LanguageControlField.Text);
            this.btnAddWorld.SetLocalizedField(LanguageControlField.Text);
            this.SetLocalizedField(LanguageControlField.Text, new { Version = Info.Version });

            this.menuItemLoadConfig.Text = this.GetLocalizedStringForControl(() => new { this.menuItemLoadConfig }, "Text");
            this.menuItemSaveConfig.Text = this.GetLocalizedStringForControl(() => new { this.menuItemSaveConfig }, "Text");
            this.menuItemNewConfig.Text = this.GetLocalizedStringForControl(() => new { this.menuItemNewConfig }, "Text");
            this.menuItemFile.Text = this.GetLocalizedStringForControl(() => new { this.menuItemFile }, "Text");
            this.dialogOpenProject.Title = this.GetLocalizedStringForControl(() => new { this.dialogOpenProject }, "Title");
            this.dialogSaveProject.Title = this.GetLocalizedStringForControl(() => new { this.dialogSaveProject }, "Title");
            this.dialogRenderConfigurationOutput.Description = this.GetLocalizedStringForControl(() => new { this.dialogRenderConfigurationOutput }, "Description");

            string dialogSaveProjectDescription = this.GetLocalizedStringForControl(() => new { this.dialogSaveProject }, "Filter");
            this.dialogSaveProject.DefaultExt = Info.PROJECT_FILE_EXTENSION;
            this.dialogSaveProject.Filter = string.Format("{0}|*.{1}", dialogSaveProjectDescription, Info.PROJECT_FILE_EXTENSION);

            string dialogOpenProjectDescription = this.GetLocalizedStringForControl(() => new { this.dialogOpenProject }, "Filter");
            this.dialogOpenProject.DefaultExt = Info.PROJECT_FILE_EXTENSION;
            this.dialogOpenProject.Filter = string.Format("{0}|*.{1}", dialogOpenProjectDescription, Info.PROJECT_FILE_EXTENSION);

            this.txtRenderConfigurationOutputPath.Text = Configuration.instance.LastSelectedPath;
        }

        private string GetLocalizedStringForControl(Expression<Func<dynamic>> expression, string lastFieldName)
        {
            string fieldName = this.BuildFieldName(expression, lastFieldName);
            return Language.GetLocalizedStringRaw(fieldName);
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

        #region Events

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
            Clipboard.SetText(MapCrafterConfigurationGenerator.GenerateConfigurationFile(config));
            MessageBox.Show("Config copied!!!");
        }

        private void btnRenderCondigurationOutput_Click(object sender, EventArgs e)
        {
            if (dialogRenderConfigurationOutput.OpenDialogFromPath(this.txtRenderConfigurationOutputPath.Text) == DialogResult.OK)
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
            if (dialogOpenProject.OpenDialogFromPath(Configuration.instance.LastSelectedPath) == DialogResult.OK)
            {
                string errorOnOpening = Language.GetLocalizedGenericFieldForControl(this, LanguageGenericField.Error, "ErrorOnOpeningFile", new { LineBreak = Environment.NewLine });
                string errorOnOpeningCaption = Language.GetLocalizedGenericFieldForControl(this, LanguageGenericField.Error, "ErrorOnOpeningFileCaption");

                if (RenderConfiguration.LoadFromFile(dialogOpenProject.FileName))
                {
                    this.RefreshForm();

                    //TODO: remake the valid of the loaded world in the main form
                    /*
                    if (RenderConfiguration.instance.Worlds.Where(w => !w.IsWorldValid()).Count() > 0)
                    {
                        string worldsInvalid = Language.GetLocalizedGenericFieldForControl(this, LanguageGenericField.Info, "WorldInfoInvalid", new { LineBreak = Environment.NewLine });
                        string worldsInvalidCaption = Language.GetLocalizedGenericFieldForControl(this, LanguageGenericField.Info, "WorldInfoInvalidCaption");

                        MessageBox.Show(worldsInvalid, worldsInvalidCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    */
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
            if (dialogSaveProject.OpenDialogFromPath(Configuration.instance.LastSelectedPath) == DialogResult.OK)
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

        #endregion
    }
}