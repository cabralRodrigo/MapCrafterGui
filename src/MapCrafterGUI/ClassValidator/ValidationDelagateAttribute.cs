using System;

namespace MapCrafterGUI.ClassValidator
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class ValidationDelegateAttribute : Attribute
    {
        public string[] Properties { get; set; }
        public string ErrorMessage { get; set; }

        public ValidationDelegateAttribute(string errorMessage, params string[] properties)
        {
            this.ErrorMessage = errorMessage;
            this.Properties = properties;
        }
    }
}
