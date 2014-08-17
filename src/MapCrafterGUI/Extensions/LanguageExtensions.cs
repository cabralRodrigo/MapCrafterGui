using MapCrafterGUI.LanguageHandler;
using System.Reflection;
using System.Windows.Forms;

namespace MapCrafterGUI.Extensions
{
    public static class LanguageExtensions
    {
        public static void SetLocalizedField(this Control control, LanguageControlField field)
        {
            SetLocalizedField(control, field, string.Empty, null);
        }
        public static void SetLocalizedField(this Control control, LanguageControlField field, object metadata)
        {
            SetLocalizedField(control, field, string.Empty, metadata);
        }
        public static void SetLocalizedField(this Control control, LanguageControlField field, string defaultValue)
        {
            SetLocalizedField(control, field, defaultValue, null);
        }
        public static void SetLocalizedField(this Control control, LanguageControlField field, string defaultValue, object metadata)
        {
            if (control == null)
                return;

            PropertyInfo prop = control.GetType().GetProperty(field.ToString());
            string newPropValue = Language.GetLocalizedFieldForControl(control, field, defaultValue, metadata);
            prop.SetValue(control, newPropValue);
        }
    }
}