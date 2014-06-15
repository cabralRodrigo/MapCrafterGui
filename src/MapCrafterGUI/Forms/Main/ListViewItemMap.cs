using MapCrafterGUI.MapCrafterConfiguration;
using System.Windows.Forms;

namespace MapCrafterGUI.Forms.Main
{
    public class ListViewItemMap : ListViewItem
    {
        public readonly MapConfiguration Map;

        public ListViewItemMap(MapConfiguration map)
        {
            this.Map = map;
            this.InitListViewItemMap();
        }

        private void InitListViewItemMap()
        {
            this.Text = this.Map.Name;

            ListViewSubItem subMapName = new ListViewSubItem();
            ListViewSubItem subRenderMode = new ListViewSubItem();

            subMapName.Text = this.Map.Name;
            subRenderMode.Text = this.Map.RenderMode.ToString();

           // this.SubItems.Add(subMapName);
            this.SubItems.Add(subRenderMode);
        }
    }
}