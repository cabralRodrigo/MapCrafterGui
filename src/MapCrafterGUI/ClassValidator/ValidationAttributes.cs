using System;

namespace MapCrafterGUI.ClassValidator
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class ValidationDelegateAttribute : Attribute
    {
        public string Property { get; set; }
        public string ErrorMessage { get; set; }
        public bool? UseLocalizedErrorMessage { get; set; }
        public int Order { get; set; }

        public ValidationDelegateAttribute(string property, string errorMessage) : this(property, errorMessage, null, 0) { }

        public ValidationDelegateAttribute(string property, string errorMessage, int order) : this(property, errorMessage, null, order) { }

        public ValidationDelegateAttribute(string property, string errorMessage, bool? useLocalizedErrorMessage) : this(property, errorMessage, useLocalizedErrorMessage, 0) { }

        public ValidationDelegateAttribute(string property, string errorMessage, bool? useLocalizedErrorMessage, int order)
        {
            this.ErrorMessage = errorMessage;
            this.Property = property;
            this.UseLocalizedErrorMessage = useLocalizedErrorMessage;
            this.Order = order;
        }
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class ValidatableAttribute : Attribute
    {
        public bool UseLocalizedErrorMessages { get; set; }

        public ValidatableAttribute(bool useLocalizedErrorMessages)
        {
            this.UseLocalizedErrorMessages = useLocalizedErrorMessages;
        }
    }
}