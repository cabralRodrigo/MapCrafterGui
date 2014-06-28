using MapCrafterGUI.Dialogs;
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

namespace MapCrafterGUI.Forms.Main
{
    public partial class TabPageWorld : TabPage
    {
        private readonly WorldConfiguration World;

        public TabPageWorld(WorldConfiguration world)
        {
            InitializeComponent();

            this.World = world;

            this.InitTagPageWorld();
            this.AttachEvents();
        }

        private void AttachEvents()
        {
            this.lstMaps.ItemActivate += lstMaps_ItemActivate;
            this.btnAddMap.Click += btnAddMap_Click;
        }

        private void InitTagPageWorld()
        {
            this.lblTextWorldInput.Text = this.World.InputFolder;
            this.lblTextWorldName.Text = this.World.Name;
            this.Text = string.Format("{0} ({1})", this.World.Name, this.World.Dimension.ToString());
            this.lblTextDimension.Text = this.World.Dimension.ToString();

            this.RefreshMapsList();
        }

        private void RefreshMapsList()
        {
            this.lstMaps.Items.Clear();
            foreach (MapConfiguration map in this.World.Maps)
                this.lstMaps.Items.Add(new ListViewItemMap(map));
        }

        private void lstMaps_ItemActivate(object sender, EventArgs e)
        {

        }
        private void btnAddMap_Click(object sender, EventArgs e)
        {
            using (frmAddMap addMapDialog = new frmAddMap(this.World))
                if (addMapDialog.ShowDialog() == DialogResult.OK)
                    this.RefreshMapsList();
        }
    }
}
