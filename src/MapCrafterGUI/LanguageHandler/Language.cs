using MapCrafterGUI.Helpers;
using System.Windows.Forms;

namespace MapCrafterGUI.LanguageHandler
{
    public class Language
    {
        public static string GetLocalizatedGenericFieldForControl(Control control, LanguageGenericField genericField, string fieldDetails)
        {
            string fieldNameOnLanguageFile = GetGenericFieldNameOnLanguegFileForControl(control, genericField, fieldDetails);
            return GetLocalizatedStringRaw(fieldNameOnLanguageFile);
        }
        public static string GetLocalizatedGenericFieldForControl(Control control, LanguageGenericField genericField, string fieldDetails, object metadata)
        {
            string value = GetLocalizatedGenericFieldForControl(control, genericField, fieldDetails);
            return UtilHelper.StringReplaceWithMetadata(value, metadata);
        }
        public static string GetLocalizatedGenericFieldForControl(Control control, LanguageGenericField genericField, string fieldDetails, string defaultValue)
        {
            string fieldNameOnLanguageFile = GetLocalizatedGenericFieldForControl(control, genericField, fieldDetails, defaultValue);
            return GetLocalizatedStringRaw(fieldNameOnLanguageFile, defaultValue);
        }
        public static string GetLocalizatedGenericFieldForControl(Control control, LanguageGenericField genericField, string fieldDetails, string defaultValue, object metadata)
        {
            string value = GetLocalizatedGenericFieldForControl(control, genericField, fieldDetails);
            return UtilHelper.StringReplaceWithMetadata(value, metadata);
        }

        public static string GetLocalizatedFieldForControl(Control control, LanguageControlField controlField)
        {
            string fieldNameOnLanguageFile = GetFieldNameOnLanguageFileForControl(control, controlField);

            return GetLocalizatedStringRaw(fieldNameOnLanguageFile);
        }
        public static string GetLocalizatedFieldForControl(Control control, LanguageControlField controlField, object metadata)
        {
            string value = GetLocalizatedFieldForControl(control, controlField);
            return UtilHelper.StringReplaceWithMetadata(value, metadata);
        }
        public static string GetLocalizatedFieldForControl(Control control, LanguageControlField controlField, string defaultValue)
        {
            string fieldNameOnLanguageFile = GetFieldNameOnLanguageFileForControl(control, controlField);

            return GetLocalizatedStringRaw(fieldNameOnLanguageFile, defaultValue);
        }
        public static string GetLocalizatedFieldForControl(Control control, LanguageControlField controlField, string defaultValue, object metadata)
        {
            string value = GetLocalizatedFieldForControl(control, controlField, defaultValue);
            return UtilHelper.StringReplaceWithMetadata(value, metadata);
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

        private static string GetLocalizatedStringRaw(string fieldName)
        {
            return LanguageFile.instance.GetFieldValue(fieldName);
        }
        private static string GetLocalizatedStringRaw(string fieldName, string defaultValue)
        {
            string value = GetLocalizatedStringRaw(fieldName);
            return string.IsNullOrEmpty(value) ? defaultValue : value;
        }
    }
}