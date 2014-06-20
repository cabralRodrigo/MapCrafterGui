using MapCrafterGUI.Helpers;
using System.ComponentModel;
namespace MapCrafterGUI.Enums
{
    public enum MapRotation
    {
        [DefaultValue("top-left")]
        [Description("Top-Left")]
        TopLeft,

        [DefaultValue("top-right")]
        [Description("Top-Right")]
        TopRight,

        [DefaultValue("bottom-right")]
        [Description("Bottom-Right")]
        BottomRight,

        [DefaultValue("bottom-left")]
        [Description("Bottom-Left")]
        BottomLeft
    }
}
