using MapCrafterGUI.Helpers;
using System.Reflection;
using System.Windows.Forms;

namespace MapCrafterGUI.LanguageHandler
{
    //TODO: Write tests for this class
    public static class Language
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
            PropertyInfo prop = control.GetType().GetProperty(field.ToString());
            string newPropValue = UtilHelper.StringReplaceWithMetadata(GetLocalizedFieldForControl(control, field, defaultValue), metadata);
            prop.SetValue(control, newPropValue);
        }

        public static string GetLocalizedGenericFieldForControl(Control control, LanguageGenericField genericField, string fieldDetails)
        {
            return GetLocalizedGenericFieldForControl(control, genericField, fieldDetails, string.Empty, null);
        }
        public static string GetLocalizedGenericFieldForControl(Control control, LanguageGenericField genericField, string fieldDetails, object metadata)
        {
            return GetLocalizedGenericFieldForControl(control, genericField, fieldDetails, string.Empty, metadata);
        }
        public static string GetLocalizedGenericFieldForControl(Control control, LanguageGenericField genericField, string fieldDetails, string defaultValue)
        {
            return GetLocalizedGenericFieldForControl(control, genericField, fieldDetails, defaultValue, null);
        }
        public static string GetLocalizedGenericFieldForControl(Control control, LanguageGenericField genericField, string fieldDetails, string defaultValue, object metadata)
        {
            string fieldNameOnLanguageFile = GetGenericFieldNameOnLanguegFileForControl(control, genericField, fieldDetails);
            string fieldValue = GetLocalizedStringRaw(fieldNameOnLanguageFile, defaultValue);

            return UtilHelper.StringReplaceWithMetadata(fieldValue, metadata);
        }

        public static string GetLocalizedFieldForControl(Control control, LanguageControlField controlField)
        {
            return GetLocalizedFieldForControl(control, controlField, string.Empty, null);
        }
        public static string GetLocalizedFieldForControl(Control control, LanguageControlField controlField, object metadata)
        {
            return GetLocalizedFieldForControl(control, controlField, string.Empty, metadata);
        }
        public static string GetLocalizedFieldForControl(Control control, LanguageControlField controlField, string defaultValue)
        {
            return GetLocalizedFieldForControl(control, controlField, defaultValue, null);
        }
        public static string GetLocalizedFieldForControl(Control control, LanguageControlField controlField, string defaultValue, object metadata)
        {
            string fieldNameOnLanguageFile = GetFieldNameOnLanguageFileForControl(control, controlField);
            string fieldValue = GetLocalizedStringRaw(fieldNameOnLanguageFile, defaultValue);

            return UtilHelper.StringReplaceWithMetadata(fieldValue, metadata);
        }

        private static string GetGenericFieldNameOnLanguegFileForControl(Control control, LanguageGenericField genericField, string fieldDetails)
        {
            string controlName = (control.GetType().GetProperty("Name").GetValue(control) ?? string.Empty).ToString();

            if (string.IsNullOrEmpty(controlName))
                return string.Empty;

            return string.Format("{0}.{1}.{2}", controlName, genericField.ToString(), fieldDetails);
        }
        private static string GetFieldNameOnLanguageFileForControl(Control control, LanguageControlField field)
        {
            string controlNameParent = string.Empty, controlName = string.Empty;

            if (control.Parent != null)
                controlNameParent = (control.Parent.GetType().GetProperty("Name").GetValue(control.Parent) ?? string.Empty).ToString();

            controlName = (control.GetType().GetProperty("Name").GetValue(control) ?? string.Empty).ToString();

            if (string.IsNullOrEmpty(controlName))
                return string.Empty;

            if (control.Parent == null)
                return string.Format("{0}.{1}", controlName, field.ToString());
            else
                return string.Format("{0}.{1}.{2}", controlNameParent, controlName, field.ToString());
        }

        private static string GetLocalizedStringRaw(string fieldName)
        {
            return LanguageFile.instance.GetFieldValue(fieldName);
        }
        private static string GetLocalizedStringRaw(string fieldName, string defaultValue)
        {
            string localizedString = GetLocalizedStringRaw(fieldName);
            return string.IsNullOrEmpty(localizedString) ? defaultValue : localizedString;
        }
    }
}