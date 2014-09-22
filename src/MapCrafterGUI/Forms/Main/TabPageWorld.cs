using MapCrafterGUI.Dialogs;
using MapCrafterGUI.Extensions;
using MapCrafterGUI.LanguageHandler;
using MapCrafterGUI.MapCrafterConfiguration;
using System;
using System.Windows.Forms;

namespace MapCrafterGUI.Forms.Main
{
    /// <summary>
    /// TagPage created specifically for an instance of the class WorldConfiguration
    /// </summary>
    public partial class TabPageWorld : TabPage
    {
        /// <summary>
        /// Reference to the instance of WorldConfiguration
        /// </summary>
        private readonly WorldConfiguration World;

        /// <summary>
        /// Create an instance of the TabPage from an instance of WorldConfiguration
        /// </summary>
        /// <param name="world">WorldConfiguration instance</param>
        public TabPageWorld(WorldConfiguration world)
        {
            //Init of UI
            InitializeComponent();

            //Initialize the instance
            this.World = world;
            this.InitTagPageWorld();
            this.AttachEvents();
        }

        /// <summary>
        /// Attach methods on the events of the TagPage
        /// </summary>
        private void AttachEvents()
        {
            this.btnAddMap.Click += btnAddMap_Click;
        }

        /// <summary>
        /// Set all text on the UI, including localization
        /// </summary>
        private void InitTagPageWorld()
        {
            //Set the informations about the world
            this.lblTextWorldInput.Text = this.World.WorldPath;
            this.lblTextWorldName.Text = this.World.Name;
            this.Text = string.Format("{0} ({1})", this.World.Name, Language.GetLocalizedDescriptionForEnum(this.World.Dimension));
            this.lblTextDimension.Text = Language.GetLocalizedDescriptionForEnum(this.World.Dimension);

            //Loads the current language on the controls
            this.lblWorldInput.SetLocalizedField(LanguageControlField.Text);
            this.lblWorldName.SetLocalizedField(LanguageControlField.Text);
            this.lblDimension.SetLocalizedField(LanguageControlField.Text);
            this.btnAddMap.SetLocalizedField(LanguageControlField.Text);
            this.headerName.Text = Language.GetLocalizedStringRaw(this.BuildFieldName(() => new { this.headerName }, "Text"));
            this.headerRenderMode.Text = Language.GetLocalizedStringRaw(this.BuildFieldName(() => new { this.headerRenderMode }, "Text"));

            //Refresh the map list on the list view
            this.RefreshMapsList();
        }

        /// <summary>
        /// Refresh the map list on lst view
        /// </summary>
        private void RefreshMapsList()
        {
            //First clear all items on list view then loop through all the maps on the selected world
            this.lstMaps.Items.Clear();
            foreach (MapConfiguration map in this.World.Maps)
                this.lstMaps.Items.Add(new ListViewItemMap(map));
        }

        /// <summary>
        /// Click event of the button "Add map"
        /// </summary>
        /// <param name="sender">Object who raised the event</param>
        /// <param name="e">Event arguments</param>
        private void btnAddMap_Click(object sender, EventArgs e)
        {
            //Open the add map dialog and add the result on the map list of the selected world
            using (frmAddMap addMapDialog = new frmAddMap(this.World))
                if (addMapDialog.ShowDialog() == DialogResult.OK)
                    this.RefreshMapsList();
        }
    }
}
