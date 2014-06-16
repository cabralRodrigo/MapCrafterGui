using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MapCrafterGUI.Helpers;
using MapCrafterGUI.Dialogs;
using MapCrafterGUI.Forms.Main;
using MapCrafterGUI.MapCrafterConfiguration;
using Newtonsoft.Json;

namespace MapCrafterGUI.Forms
{
    public partial class frmMain : Form
    {
        private RenderConfiguration config { get { return RenderConfiguration.instance; } }
        public frmMain()
        {
            InitializeComponent();
            this.RefreshForm();

            dialogSaveProject.DefaultExt = Info.PROJECT_FILE_EXTENSION;
            dialogSaveProject.Filter = string.Format("MapCrafterGui Project|*.{0}", Info.PROJECT_FILE_EXTENSION);

            dialogOpenProject.DefaultExt = Info.PROJECT_FILE_EXTENSION;
            dialogOpenProject.Filter = string.Format("MapCrafterGui Project|*.{0}", Info.PROJECT_FILE_EXTENSION);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void btnAddWorld_Click(object sender, EventArgs e)
        {
            using (AddWorld addWorldDialog = new AddWorld(config))
                if (addWorldDialog.ShowDialog() == DialogResult.OK)
                    RefreshForm();
        }

        private void RefreshForm()
        {
            this.lblRenderConfigurarionName.Text = config.FileName;
            this.lblRenderConfigurationOutput.Text = config.OutputFolder;
            this.pnBackgroundColor.BackColor = config.BackgroudColor;
            tabsWorlds.Controls.Clear();

            foreach (WorldConfiguration world in config.Worlds)
                tabsWorlds.Controls.Add(new TabPageWorld(world));
        }


        private void button1_Click(object sender, EventArgs e)
        {
            var ser = JsonConvert.SerializeObject(this.config);
            this.RefreshForm();
            config.GenerateConfigurationFile();
        }

        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            var item = ((ListView)sender).FocusedItem;

            var item2 = item as ListViewItemMap;

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

        private void btnRenderCondigurationOutput_Click(object sender, EventArgs e)
        {
            dialogRenderConfigurationOutput.SelectedPath = Environment.CurrentDirectory;
            if (dialogRenderConfigurationOutput.ShowDialog() == DialogResult.OK)
            {
                this.config.OutputFolder = dialogRenderConfigurationOutput.SelectedPath;
                this.RefreshForm();
            }
        }

        private void saveConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dialogSaveProject.InitialDirectory  = Environment.CurrentDirectory;
            if (dialogSaveProject.ShowDialog() == DialogResult.OK)
                IOHelper.CreateTextFile(dialogSaveProject.FileName, JsonConvert.SerializeObject(this.config), true);

        }

        private void loadConToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dialogOpenProject.InitialDirectory = Environment.CurrentDirectory;
            if (dialogOpenProject.ShowDialog() == DialogResult.OK)
            {
                if (RenderConfiguration.LoadFromFile(dialogOpenProject.FileName))
                    this.RefreshForm();
                else
                    MessageBox.Show("Error on open the project. Please create the project again or try another file.", "Error on open the project", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void newProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RenderConfiguration.SetConfiguration(new RenderConfiguration(Info.RENDER_CONFIGURATION_FILE_NAME, Info.RENDER_CONFIGURATION_OUTPUT_FOLDER));
            this.RefreshForm();
        }
    }
}
