namespace MapCrafterGUI.ClassValidator
{
    public class ValidationError
    {
        public string Error { get; private set; }
        public string PropertyName { get; private set; }

        public ValidationError(string errorDescription, string propertyName)
        {
            this.Error = errorDescription;
            this.PropertyName = propertyName;
        }
    }
}
