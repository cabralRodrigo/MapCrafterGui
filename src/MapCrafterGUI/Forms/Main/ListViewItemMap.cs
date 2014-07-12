using MapCrafterGUI.LanguageHandler;
using MapCrafterGUI.MapCrafterConfiguration;
using System.Windows.Forms;

namespace MapCrafterGUI.Forms.Main
{
    /// <summary>
    /// ListViewItem created specifically for an instance of the class MapConfiguration
    /// </summary>
    public class ListViewItemMap : ListViewItem
    {
        /// <summary>
        /// Reference to the instance of MapConfiguration
        /// </summary>
        public readonly MapConfiguration Map;

        /// <summary>
        /// Create an instance of the ListViewItem from an instance of MapConfiguration
        /// </summary>
        /// <param name="map">MapConfiguration instance</param>
        public ListViewItemMap(MapConfiguration map)
        {
            //Initialize the class
            this.Map = map;
            this.InitListViewItemMap();
        }

        /// <summary>
        /// Set all text on the UI, including localization
        /// </summary>
        private void InitListViewItemMap()
        {
            //Set the text on the first column on the list view
            this.Text = this.Map.Name;

            //Set the text on the second column on the list view
            ListViewSubItem subRenderMode = new ListViewSubItem();
            subRenderMode.Text = Language.GetLocalizedDescriptionForEnum(this.Map.RenderMode);
            this.SubItems.Add(subRenderMode);
        }
    }
}