using MapCrafterGUI.Enums;
using MapCrafterGUI.Helpers;
using MapCrafterGUI.MapCrafterConfiguration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapCrafterGUI.Dialogs
{
    public partial class AddWorld : Form
    {
        private readonly RenderConfiguration config;

        public AddWorld(RenderConfiguration config)
        {
            InitializeComponent();
            this.config = config;
            this.cbDimension.DataSource = UtilHelper.ConvertEnumToDictionary<Dimension>(true).Select(s => s.Value).ToArray();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //TODO: do a validation here

            Dimension dimension;
            if (Enum.TryParse<Dimension>(cbDimension.SelectedIndex.ToString(), out dimension))
                this.config.Worlds.Add(new WorldConfiguration(this.txtWorldName.Text, this.txtInputFolder.Text) { Dimension = dimension });

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnInputFolder_Click(object sender, EventArgs e)
        {
            folderDialog.SelectedPath = string.IsNullOrEmpty(txtInputFolder.Text.Trim()) ? Environment.CurrentDirectory : txtInputFolder.Text.Trim();
            if (folderDialog.ShowDialog() == DialogResult.OK)
                this.txtInputFolder.Text = folderDialog.SelectedPath;
        }
    }
}
