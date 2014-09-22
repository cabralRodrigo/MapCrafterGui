using MapCrafterGUI.Extensions;
using MapCrafterGUI.Helpers;
using MapCrafterGUI.LanguageHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace MapCrafterGUI.ClassValidator
{
    //TODO: Create tests for the validation system
    public static class Validator
    {
        /// <summary>
        /// Class used for internal purpose
        /// </summary>
        /// <typeparam name="T">The type of the class which is being validated</typeparam>
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

        /// <summary>
        /// Validates an instance of any class decorated with <seealso cref="MapCrafterGUI.ClassValidator.ValidationDelegateAttribute"/> attribute
        /// </summary>
        /// <typeparam name="T">The type of the class which will be validated</typeparam>
        /// <param name="objectToValidate">The object which will be validated</param>
        /// <returns>List with all errors in the validation, the list will be empty if no error was found</returns>
        public static List<ValidationError> Validate<T>(T objectToValidate)
        {
            return Validator.Validate(objectToValidate, string.Empty);
        }

        /// <summary>
        /// Validates an instance of any class decorated with <seealso cref="MapCrafterGUI.ClassValidator.ValidationDelegateAttribute"/> attribute
        /// </summary>
        /// <typeparam name="T">The type of the class which will be validated</typeparam>
        /// <param name="objectToValidate">The object which will be validated</param>
        /// <param name="propertyName">The property name which will be validated</param>
        /// <returns>List with all errors in the validation, the list will be empty if no error was found</returns>
        public static List<ValidationError> Validate<T>(T objectToValidate, string propertyName)
        {
            //Gets the validatable attribute of the class
            ValidatableAttribute validatableAttr = typeof(T).GetCustomAttribute<ValidatableAttribute>(true);
            if (validatableAttr == null)
                throw new ValidationException("The class has to be decorated with the validatable attribute");

            //Gets all validation delegates and all validation attribute in the class
            var tuples = Validator.GetAllValidationTuples<T>(propertyName)
                            .OrderBy(tuple => tuple.ValidationAttribute.Order)
                            .ThenBy(tuple => tuple.ValidationAttribute.PropertyName)
                            .ToList();

            //If the list is empty has no need to proceed
            if (tuples.Count == 0)
                return new List<ValidationError>();

            //Gets all possibles errors in the object
            List<ValidationError> errorList = new List<ValidationError>();
            foreach (ValidationTuple<T> tuple in tuples)
                //If the result of the delegate is false, means that validation fails
                if (!tuple.ValidationDelegate(objectToValidate))
                {
                    //Gets the error message based on the settings on the attributes in the class and in the field
                    string errorMessage = Validator.GetErrorMessage(typeof(T).Name, validatableAttr, tuple.ValidationAttribute);

                    //Adds the error on the return list
                    errorList.Add(new ValidationError(errorMessage, tuple.ValidationAttribute.PropertyName));

                    if (tuple.ValidationAttribute.StopValidationOnError)
                        break;
                }

            return errorList;
        }

        /// <summary>
        /// Validates an instance of any class decorated with <seealso cref="MapCrafterGUI.ClassValidator.ValidationDelegateAttribute"/> attribute
        /// </summary>
        /// <typeparam name="T">The type of the class which will be validated</typeparam>
        /// <param name="objectToValidate">The object which will be validated</param>
        /// <param name="property">The property which will be validated</param>
        /// <returns>List with all errors in the validation, the list will be empty if no error was found</returns>
        public static List<ValidationError> Validate<T>(T objectToValidate, PropertyInfo property)
        {
            return Validator.Validate(objectToValidate, property.Name);
        }

        /// <summary>
        /// Validates an instance of any class decorated with <seealso cref="MapCrafterGUI.ClassValidator.ValidationDelegateAttribute"/> attribute
        /// </summary>
        /// <typeparam name="T">The type of the class which will be validated</typeparam>
        /// <param name="objectToValidate">The object which will be validated</param>
        /// <param name="expressionToGetProperty">The lambda expression to define which property will be validated</param>
        /// <returns>List with all errors in the validation, the list will be empty if no error was found</returns>
        public static List<ValidationError> Validate<T>(T objectToValidte, Expression<Func<T, object>> expressionToGetProperty)
        {
            return Validator.Validate(objectToValidte, UtilHelper.GetPropertyName(expressionToGetProperty));
        }

        /// <summary>
        /// Gets all validation attributes and all validation delegates of a class
        /// </summary>
        /// <typeparam name="T">The type of the class to be validated</typeparam>
        /// <param name="propertyName">Specifies the property for getting the validation attributes and the validation delegates. If null, will get all</param>
        /// <returns>IEnumerable with all the validation attributes and all validation delegates found in the class</returns>
        private static IEnumerable<ValidationTuple<T>> GetAllValidationTuples<T>(string propertyName)
        {
            //Gets all fields which are possible to be a validation delegate
            var fields = typeof(T).GetFields<Func<T, bool>>(BindingFlags.Static | BindingFlags.Public, true).ToList();

            foreach (var attr in fields)
            {
                Func<T, bool> validationDelegate = attr.GetValue(null) as Func<T, bool>;
                ValidationDelegateAttribute validationAttribute = attr.GetCustomAttribute<ValidationDelegateAttribute>(true);

                //The field is not a validation delegate
                if (validationAttribute == null)
                    continue;

                if (validationDelegate == null)
                    throw new ValidationException(string.Format("The validation delegate \"{0}\" cannot be null", attr.Name));

                if (!Validator.PropertyExistsInClass<T>(validationAttribute.PropertyName))
                    throw new ValidationException(string.Format("Cannot found the property \"{0}\" in the class", validationAttribute.PropertyName));

                if (string.IsNullOrEmpty(propertyName) || propertyName == validationAttribute.PropertyName)
                    yield return new ValidationTuple<T>(validationAttribute, validationDelegate);
            }
        }

        /// <summary>
        /// Verifies if the property exists in the class
        /// </summary>
        /// <typeparam name="T">The type of the class to the property be searched</typeparam>
        /// <param name="propertyName">The property name</param>
        /// <returns>Boolean indicating whether the property exists or not</returns>
        private static bool PropertyExistsInClass<T>(string propertyName)
        {
            return typeof(T).GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.GetProperty) != null;
        }

        /// <summary>
        /// Gets an error message of the validatable attribute and the validation delegate received as parameters
        /// </summary>
        /// <param name="className">The class name</param>
        /// <param name="classAttribute">The validatable attribute</param>
        /// <param name="delegateAttribute">The validation delegate attribute</param>
        /// <returns>The error message which was generated</returns>
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