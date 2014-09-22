using MapCrafterGUI.ClassValidator;
using MapCrafterGUI.Enums;
using MapCrafterGUI.Extensions;
using MapCrafterGUI.Helpers;
using MapCrafterGUI.LanguageHandler;
using MapCrafterGUI.MapCrafterConfiguration;
using System;
using System.Linq;
using System.Windows.Forms;

namespace MapCrafterGUI.Dialogs
{
    public partial class frmAddWorld : Form
    {
        private readonly RenderConfiguration config;
        private bool isWorldPathValid = false;
        private bool isWorldNameValid = false;

        public frmAddWorld(RenderConfiguration config)
        {
            InitializeComponent();
            this.config = config;
            this.cbDimension.DataSource = EnumHelper.ConvertEnumToDictionary<Dimension>(true).Select(s => s.Value).ToArray();

            this.SetLocalizedField(LanguageControlField.Text);
            this.lblDimension.SetLocalizedField(LanguageControlField.Text);
            this.lblInputFolder.SetLocalizedField(LanguageControlField.Text);
            this.lblWorldName.SetLocalizedField(LanguageControlField.Text);
            this.btnAdd.SetLocalizedField(LanguageControlField.Text);
            this.btnCancel.SetLocalizedField(LanguageControlField.Text);
            this.btnInputFolder.SetLocalizedField(LanguageControlField.Text);
            
            //Builds and sets the folder dialog description from the lanaguage file
            string folderDialogField = Language.BuildFieldName(typeof(frmAddWorld), () => new { this.folderDialog }, "Description");
            this.folderDialog.Description = Language.GetLocalizedStringRaw(folderDialogField);
        }

        private WorldConfiguration CreateWorldFromForm()
        {
            Dimension dimension;
            if (Enum.TryParse<Dimension>(cbDimension.SelectedIndex.ToString(), out dimension))
                return new WorldConfiguration(this.txtWorldName.Text, this.txtInputFolder.Text) { Dimension = dimension };
            else
                return null;
        }

        #region Events

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.txtInputFolder_TextChanged(this, EventArgs.Empty);
            this.txtWorldName_TextChanged(this, EventArgs.Empty);

            if (this.isWorldPathValid && this.isWorldNameValid)
            {
                this.config.Worlds.Add(this.CreateWorldFromForm());

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnInputFolder_Click(object sender, EventArgs e)
        {
            if (folderDialog.OpenDialogFromPath(txtInputFolder.Text) == DialogResult.OK)
                this.txtInputFolder.Text = folderDialog.SelectedPath;
        }

        private void txtWorldName_TextChanged(object sender, EventArgs e)
        {
            var errors = Validator.Validate(this.CreateWorldFromForm(), i => i.Name);
            if (errors.Count >= 1)
                validationControl.DefineError(this.txtWorldName, errors[0].Error);
            else
                validationControl.ClearError(this.txtWorldName);

            this.isWorldNameValid = errors.Count == 0;
        }

        private void txtInputFolder_TextChanged(object sender, EventArgs e)
        {
            var errors = Validator.Validate(this.CreateWorldFromForm(), i => i.WorldPath);
            if (errors.Count >= 1)
                validationControl.DefineError(this.txtInputFolder, errors[0].Error);
            else
                validationControl.ClearError(this.txtInputFolder);

            this.isWorldPathValid = errors.Count == 0;
        }

        #endregion

    }
}
