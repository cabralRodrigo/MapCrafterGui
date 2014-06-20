﻿using MapCrafterGUI.Enums;
using MapCrafterGUI.Helpers;
using MapCrafterGUI.LanguageHandler;
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
    public partial class AddMap : Form
    {
        private readonly WorldConfiguration world;

        public AddMap(WorldConfiguration world)
        {
            InitializeComponent();
            this.world = world;
            this.lblTextWorldName.Text = this.world.Name;
            this.cbRenderMode.DataSource = UtilHelper.ConvertEnumToDictionary<RenderMode>(true).Select(s => s.Value).ToList();

            this.PopulateRotations();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //TODO: do a validation here
            MapConfiguration map = new MapConfiguration(txtMapName.Text, world);

            RenderMode renderMode;
            if (Enum.TryParse<RenderMode>(this.cbRenderMode.SelectedIndex.ToString(), out renderMode))
                map.RenderMode = renderMode;

            foreach (var enumIndex in this.clbRotations.CheckedIndices)
                map.AddRotation((MapRotation)enumIndex);

            this.world.Maps.Add(map);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void PopulateRotations()
        {
            foreach (var rotation in UtilHelper.ConvertEnumToDictionary<MapRotation>(false))
            {
                Enum enumRotation = (Enum)Enum.Parse(typeof(MapRotation), rotation.Value);
                string enumDescription = Language.GetLocalizedDescriptionForEnum(enumRotation);
                this.clbRotations.Items.Add(enumDescription, enumRotation.ToString() == MapConfiguration.DefaultRotation.ToString());
            }
        }
    }
}