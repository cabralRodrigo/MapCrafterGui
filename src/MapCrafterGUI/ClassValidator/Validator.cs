using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MapCrafterGUI.ClassValidator
{
    public static class Validator
    {
        public static IEnumerable<ValidationError> Validate<T>(T objectToValidate)
        {
            var validationErros = new List<ValidationError>();

            var validationAttributes = Validator.GetValidationDelegates(objectToValidate);

            var properties = typeof(T).GetProperties();

            foreach (PropertyInfo property in properties)
            {
                var validationTuple = validationAttributes.Where(tupleAttr => tupleAttr.Item1.Properties.Contains(property.Name)).ToList();

                if (validationTuple.Count == 0)
                    continue;

                else if (validationTuple.Count > 1)
                    throw new ValidationException("Error on validation, is not allowed multiples validators in the same property");

                else
                {
                    Func<T, bool> validationDelegate = validationTuple[0].Item2.GetValue(objectToValidate) as Func<T, bool>;

                    if (validationDelegate == null)
                        throw new ValidationException(string.Format("Error on validation, validator delegate is null for the property '{0}'", property.Name));
                    else
                        if (!validationDelegate(objectToValidate))
                            yield return new ValidationError(validationTuple[0].Item1.ErrorMessage, property.Name);

                }
            }
        }

        private static IEnumerable<Tuple<ValidationDelegateAttribute, FieldInfo>> GetValidationDelegates<T>(T objectToValidate)
        {
            var fields = typeof(T).GetFields();
            var validationAttributes = new List<Tuple<ValidationDelegateAttribute, FieldInfo>>();

            foreach (FieldInfo field in fields)
            {
                var rr = field.GetCustomAttribute<ValidationDelegateAttribute>();
                if (rr != null)
                    validationAttributes.Add(new Tuple<ValidationDelegateAttribute, FieldInfo>(rr, field));
            }

            return validationAttributes;
        }
    }
}