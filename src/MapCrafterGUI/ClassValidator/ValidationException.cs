using System;

namespace MapCrafterGUI.ClassValidator
{
    public class ValidationException : Exception
    {
        public ValidationException(string message) : base(message) { }
    }
}
