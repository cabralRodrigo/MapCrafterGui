using MapCrafterGUI.Enums;
using MapCrafterGUI.Helpers;
using MapCrafterGUI.LanguageHandler;
using MapCrafterGUI.MapCrafterConfiguration;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MapCrafterGUI.Dialogs
{
    public partial class frmAddWorld : Form
    {
        private readonly RenderConfiguration config;

        public frmAddWorld(RenderConfiguration config)
        {
            InitializeComponent();
            this.config = config;
            this.cbDimension.DataSource = UtilHelper.ConvertEnumToDictionary<Dimension>(true).Select(s => s.Value).ToArray();

            this.SetLocalizedField(LanguageControlField.Text);
            this.lblDimension.SetLocalizedField(LanguageControlField.Text);
            this.lblInputFolder.SetLocalizedField(LanguageControlField.Text);
            this.lblWorldName.SetLocalizedField(LanguageControlField.Text);
            this.btnAdd.SetLocalizedField(LanguageControlField.Text);
            this.btnCancel.SetLocalizedField(LanguageControlField.Text);
            this.btnInputFolder.SetLocalizedField(LanguageControlField.Text);
            this.folderDialog.Description = Language.GetLocalizedStringRaw("frmAddWorld.folderDialog.Description");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtInputValidate() & txtWorldNameValidate())
            {
                Dimension dimension;
                if (Enum.TryParse<Dimension>(cbDimension.SelectedIndex.ToString(), out dimension))
                    this.config.Worlds.Add(new WorldConfiguration(this.txtWorldName.Text, this.txtInputFolder.Text) { Dimension = dimension });

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnInputFolder_Click(object sender, EventArgs e)
        {
            folderDialog.SelectedPath = string.IsNullOrEmpty(txtInputFolder.Text.Trim()) ? Environment.CurrentDirectory : txtInputFolder.Text.Trim();
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                this.txtInputFolder.Text = folderDialog.SelectedPath;
                this.txtInputValidate();
            }
        }

        private void txtInputFolder_Validating(object sender, CancelEventArgs e)
        {
            txtInputValidate();
        }
        private void txtWorldName_Validating(object sender, CancelEventArgs e)
        {
            txtWorldNameValidate();
        }

        private bool txtInputValidate()
        {
            string errorMessage = string.Empty;
            bool error = false;

            if (!WorldConfiguration.Validate_FolderWorld(this.txtInputFolder.Text))
            {
                error = true;
                errorMessage = WorldConfiguration.Validate_Error_FolderWorld;
            }
            else if (!WorldConfiguration.Validate_LevelFile(this.txtInputFolder.Text))
            {
                error = true;
                errorMessage = WorldConfiguration.Validate_Error_LevelFile;
            }

            if (error)
            {
                this.txtInputFolder.BackColor = Color.LightPink;
                this.validationControl.SetError(this.txtInputFolder, errorMessage);
            }
            else
            {
                this.txtInputFolder.BackColor = Color.White;
                this.validationControl.SetError(this.txtInputFolder, string.Empty);
            }

            return !error;
        }
        private bool txtWorldNameValidate()
        {
            bool error = WorldConfiguration.Validate_WorldName(txtWorldName.Text);
            string errorMessage = WorldConfiguration.Validate_Error_WorldName;

            if (error)
            {
                this.txtWorldName.BackColor = Color.LightPink;
                this.validationControl.SetError(this.txtWorldName, errorMessage);
            }
            else
            {
                this.txtWorldName.BackColor = Color.White;
                this.validationControl.SetError(this.txtWorldName, string.Empty);
            }

            return error;
        }
    }
}
