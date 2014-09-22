namespace MapCrafterGUI.ClassValidator
{
    /// <summary>
    /// Represents a validation error
    /// </summary>
    public class ValidationError
    {
        /// <summary>
        /// Error message
        /// </summary>
        public string Error { get; private set; }

        /// <summary>
        /// The property that is invalid
        /// </summary>
        public string PropertyName { get; private set; }

        public ValidationError(string errorDescription, string propertyName)
        {
            this.Error = errorDescription;
            this.PropertyName = propertyName;
        }
    }
}
