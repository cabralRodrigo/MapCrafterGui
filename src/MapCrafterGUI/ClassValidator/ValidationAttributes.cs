using System;

namespace MapCrafterGUI.ClassValidator
{
    /// <summary>
    /// Attribute used to mark a field that is an validation delegate
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class ValidationDelegateAttribute : Attribute
    {
        /// <summary>
        /// The property that this attribute will validate
        /// </summary>
        public string PropertyName { get; set; }

        /// <summary>
        /// The error message in case the validation fails
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Boolean indicating if error message will be localized for the current language loaded
        /// </summary>
        public bool? UseLocalizedErrorMessage { get; set; }

        /// <summary>
        /// The order for the validation inside all others validation delegates in the class
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// Boolean indicating if the validation of the class stops if this validation fails
        /// </summary>
        public bool StopValidationOnError { get; set; }

        /// <summary>
        /// Marks the field as an validation delegate
        /// </summary>
        /// <param name="property">The property that this attribute will validade</param>
        /// <param name="errorMessage">The error message in case the validation fails</param>
        /// <param name="stopValidationOnError">Boolean indicating if error message will be localized for the current language loaded</param>
        public ValidationDelegateAttribute(string property, string errorMessage, bool stopValidationOnError) : this(property, errorMessage, stopValidationOnError, null, -1) { }

        /// <summary>
        /// Marks the field as an validation delegate
        /// </summary>
        /// <param name="property">The property that this attribute will validade</param>
        /// <param name="errorMessage">The error message in case the validation fails</param>
        /// <param name="stopValidationOnError">Boolean indicating if error message will be localized for the current language loaded</param>
        /// <param name="order">The order for the validation inside all others validation delegates in the class</param>
        public ValidationDelegateAttribute(string property, string errorMessage, bool stopValidationOnError, int order) : this(property, errorMessage, stopValidationOnError, null, order) { }

        /// <summary>
        /// Marks the field as an validation delegate
        /// </summary>
        /// <param name="property">The property that this attribute will validade</param>
        /// <param name="errorMessage">The error message in case the validation fails</param>
        /// <param name="stopValidationOnError">Boolean indicating if error message will be localized for the current language loaded</param>
        /// <param name="useLocalizedErrorMessage">Boolean indicating if error message will be localized for the current language loaded</param>
        public ValidationDelegateAttribute(string property, string errorMessage, bool stopValidationOnError, bool? useLocalizedErrorMessage) : this(property, errorMessage, stopValidationOnError, useLocalizedErrorMessage, -1) { }

        /// <summary>
        /// Marks the field as an validation delegate
        /// </summary>
        /// <param name="property">The property that this attribute will validade</param>
        /// <param name="errorMessage">The error message in case the validation fails</param>
        /// <param name="stopValidationOnError">Boolean indicating if error message will be localized for the current language loaded</param>
        /// <param name="useLocalizedErrorMessage">Boolean indicating if error message will be localized for the current language loaded</param>
        /// <param name="order">The order for the validation inside all others validation delegates in the class</param>
        public ValidationDelegateAttribute(string property, string errorMessage, bool stopValidationOnError, bool? useLocalizedErrorMessage, int order)
        {
            this.ErrorMessage = errorMessage;
            this.PropertyName = property;
            this.UseLocalizedErrorMessage = useLocalizedErrorMessage;
            this.Order = order;
            this.StopValidationOnError = stopValidationOnError;
        }
    }

    /// <summary>
    /// Attribute used to mark a class is enabled to validation
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class ValidatableAttribute : Attribute
    {
        /// <summary>
        /// Boolean indicating if all validation delegates on the class use localized error messages
        /// </summary>
        public bool UseLocalizedErrorMessages { get; set; }

        /// <summary>
        /// Enables the class to validation
        /// </summary>
        /// <param name="useLocalizedErrorMessages">Boolean indicating if all validation delegates on the class use localized error messages, this will overhide</param>
        public ValidatableAttribute(bool useLocalizedErrorMessages)
        {
            this.UseLocalizedErrorMessages = useLocalizedErrorMessages;
        }
    }
}