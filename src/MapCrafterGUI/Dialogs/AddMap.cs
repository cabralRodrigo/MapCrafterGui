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
    public partial class frmAddMap : Form
    {
        private readonly WorldConfiguration world;

        public frmAddMap(WorldConfiguration world)
        {
            InitializeComponent();
            this.world = world;
            this.lblTextWorldName.Text = this.world.Name;
            this.cbRenderMode.DataSource = EnumHelper.ConvertEnumToDictionary<RenderMode>(true).Select(s => s.Value).ToList();

            this.PopulateRotations();

            this.SetLocalizedField(LanguageControlField.Text);
            this.lblWorldName.SetLocalizedField(LanguageControlField.Text);
            this.lblMapName.SetLocalizedField(LanguageControlField.Text);
            this.lblRotations.SetLocalizedField(LanguageControlField.Text);
            this.lblRenderMode.SetLocalizedField(LanguageControlField.Text);
            this.btnAdd.SetLocalizedField(LanguageControlField.Text);
            this.btnCancel.SetLocalizedField(LanguageControlField.Text);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //TODO: do a validation here
            MapConfiguration map = new MapConfiguration(txtMapName.Text);

            RenderMode renderMode;
            if (Enum.TryParse<RenderMode>(this.cbRenderMode.SelectedIndex.ToString(), out renderMode))
                map.RenderMode = renderMode;

            foreach (var enumIndex in this.clbRotations.CheckedIndices)
                map.AddRotation((MapRotation)enumIndex);

            this.world.Maps.Add(map);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
       
        private void PopulateRotations()
        {
            foreach (var rotation in EnumHelper.ConvertEnumToDictionary<MapRotation>(false))
            {
                Enum enumRotation = (Enum)Enum.Parse(typeof(MapRotation), rotation.Value);
                string enumDescription = Language.GetLocalizedDescriptionForEnum(enumRotation);
                this.clbRotations.Items.Add(enumDescription, enumRotation.ToString() == MapConfiguration.DefaultRotation.ToString());
            }
        }
    }
}