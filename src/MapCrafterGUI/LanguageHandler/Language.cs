using MapCrafterGUI.Helpers;
using System;
using System.Windows.Forms;

namespace MapCrafterGUI.LanguageHandler
{
    public static class Language
    {
        public static string GetLocalizedDescriptionForEnum(Enum en)
        {
            string nameOnFile = GetFieldNameOnLanguageFileForEnum(en);
            string defaultValue = EnumHelper.GetEnumDescription(en);

            return GetLocalizedStringRaw(nameOnFile, defaultValue);
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

        public static string GetLocalizedStringRaw(string fieldName)
        {
            return GetLocalizedStringRaw(fieldName, string.Empty, null);
        }
        public static string GetLocalizedStringRaw(string fieldName, object metadata)
        {
            return GetLocalizedStringRaw(fieldName, string.Empty, metadata);
        }
        public static string GetLocalizedStringRaw(string fieldName, string defaultValue)
        {
            return GetLocalizedStringRaw(fieldName, defaultValue, null);
        }
        public static string GetLocalizedStringRaw(string fieldName, string defaultValue, object metadata)
        {
            string localizedString = LanguageFile.instance.GetFieldValue(fieldName, defaultValue);
            return UtilHelper.StringReplaceWithMetadata(localizedString, metadata);
        }

        private static string GetFieldNameOnLanguageFileForControl(Control control, LanguageControlField field)
        {
            if (control == null)
                return string.Empty;

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
        private static string GetFieldNameOnLanguageFileForEnum(Enum en)
        {
            string enumClass = en.GetType().Name;
            string enumItem = en.ToString();

            return string.Format("{0}.{1}", enumClass, enumItem);
        }
        private static string GetGenericFieldNameOnLanguegFileForControl(Control control, LanguageGenericField genericField, string fieldDetails)
        {
            if (control == null)
                return string.Empty;

            string controlName = (control.GetType().GetProperty("Name").GetValue(control) ?? string.Empty).ToString();

            if (string.IsNullOrEmpty(controlName))
                return string.Empty;

            return string.Format("{0}.{1}.{2}", controlName, genericField.ToString(), fieldDetails);
        }
    }
}