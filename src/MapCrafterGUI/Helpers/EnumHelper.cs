using MapCrafterGUI.LanguageHandler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace MapCrafterGUI.Helpers
{
    public static class EnumHelper
    {
        /// <summary>
        /// Convert an enum to a dictionary with key being the index of the item within the enum and the value being the enum description
        /// </summary>
        /// <typeparam name="T">The type of the enum</typeparam>
        /// <param name="useLocalizedEnumDescription">Boolean indicating wheter the enum description will be localized in the language system</param>
        /// <returns>Dictionary with the enum description and order</returns>
        public static Dictionary<int, string> ConvertEnumToDictionary<T>(bool useLocalizedEnumDescription) where T : IComparable, IFormattable, IConvertible
        {
            //Throw an exception if the type parameter is not an Enum
            if (!typeof(T).IsEnum)
                throw new ArgumentException("Type parameter 'T' has to be an Enum");

            //Get all values from enum
            Array arrayEnum = Enum.GetValues(typeof(T));

            Dictionary<int, string> dicEnum = new Dictionary<int, string>();
            for (int i = 0; i < arrayEnum.GetLength(0); i++)
            {
                string enumDescription;

                //Get the localized description from the enum if the parameter "useLocalizedEnumDescription" is set to true
                if (useLocalizedEnumDescription)
                    enumDescription = Language.GetLocalizedDescriptionForEnum((Enum)Enum.Parse(typeof(T), i.ToString()));
                else
                    enumDescription = arrayEnum.GetValue(i).ToString();

                dicEnum.Add(i, enumDescription);
            }

            return dicEnum;
        }

        /// <summary>
        /// Get the enum description from the <seealso cref="DescriptionAttribute"/> attribute
        /// </summary>
        /// <param name="en">The enum item for get the description</param>
        /// <returns>The description of the enum item, null if the enum was not decorated with the <seealso cref="DescriptionAttribute"/> attribute</returns>
        public static string GetEnumDescription(Enum en)
        {
            string enumDescription = null;

            DescriptionAttribute descAttribute = GetCustomAttribute<DescriptionAttribute>(en);
            if (descAttribute != null)
                enumDescription = descAttribute.Description;

            return enumDescription;
        }

        /// <summary>
        /// Get the enum value from the the <seealso cref="DefaultValueAttribute"/> attribute
        /// </summary>
        /// <param name="en">The enum item for get the value</param>
        /// <returns>The value of the enum item, null if the enum was not decorated with the <seealso cref="DescriptionAttribute"/> attribute</returns>
        public static string GetEnumValue(Enum en)
        {
            string enumValue = null;

            DefaultValueAttribute valueAttribute = GetCustomAttribute<DefaultValueAttribute>(en);
            if (valueAttribute != null)
                enumValue = (valueAttribute.Value ?? string.Empty).ToString();

            return enumValue;
        }

        /// <summary>
        /// Get custom attributes from an enum 
        /// </summary>
        /// <typeparam name="T">The type of the enum</typeparam>
        /// <param name="en">The enum item</param>
        /// <returns>A custom attribute that matches T, or null if no such attribute is found</returns>
        private static T GetCustomAttribute<T>(Enum en) where T : Attribute
        {
            return en.GetType().GetField(en.ToString()).GetCustomAttribute<T>();
        }
    }
}
