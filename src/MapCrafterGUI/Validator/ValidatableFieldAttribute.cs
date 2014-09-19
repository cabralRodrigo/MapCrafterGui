using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapCrafterGUI.Validator
{
    public class ValidatableFieldAttribute: Attribute
    {
        public readonly string errorMessage;
        public readonly Type type;
        public readonly string func;
        public ValidatableFieldAttribute(Type type, string validatorName, string message)
        {
            this.errorMessage = message;
            this.type = type;
            this.func = validatorName;
        }
    }
}
