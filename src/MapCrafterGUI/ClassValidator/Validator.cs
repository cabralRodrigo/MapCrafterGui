using MapCrafterGUI.Extensions;
using MapCrafterGUI.LanguageHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MapCrafterGUI.ClassValidator
{
    public static class Validator
    {
        private class ValidationTuple<T>
        {
            public readonly ValidationDelegateAttribute ValidationAttribute;
            public readonly Func<T, bool> ValidationDelegate;

            public ValidationTuple(ValidationDelegateAttribute attr, Func<T, bool> validationDelegate)
            {
                this.ValidationAttribute = attr;
                this.ValidationDelegate = validationDelegate;
            }
        }

        public static IEnumerable<ValidationError> Validate<T>(T objectToValidate)
        {
            var d = Validator.GetAllValidationTuple<T>().ToList();
            return null;
        }

        private static IEnumerable<ValidationTuple<T>> GetAllValidationTuple<T>()
        {
            var attributes = typeof(T).GetFields<Func<T, bool>>(BindingFlags.Static | BindingFlags.Public, true).ToList();

            foreach (var attr in attributes)
            {
                Func<T, bool> validationDelegate = attr.GetValue(null) as Func<T, bool>;
                ValidationDelegateAttribute validationAttribute = attr.GetCustomAttribute<ValidationDelegateAttribute>(true);

                if (validationDelegate == null)
                    throw new ValidationException("");

                if (validationAttribute != null)
                    yield return new ValidationTuple<T>(validationAttribute, validationDelegate);
            }
        }

        private static string GetErrorMessage(string className, ValidatableAttribute classAttribute, ValidationDelegateAttribute delegateAttribute)
        {
            string errorMessage = string.Empty;

            bool useLocalizedErroMessage = delegateAttribute.UseLocalizedErrorMessage == null ? classAttribute.UseLocalizedErrorMessages : delegateAttribute.UseLocalizedErrorMessage.Value;

            if (useLocalizedErroMessage)
                errorMessage = Language.GetLocalizedStringRaw(string.Format("Validator.{0}.{1}", className, delegateAttribute.ErrorMessage));
            else
                errorMessage = delegateAttribute.ErrorMessage;

            return errorMessage;
        }
    }
}