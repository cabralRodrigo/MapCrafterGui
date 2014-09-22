using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace MapCrafterGUI.Helpers
{
    public static class UtilHelper
    {
        /// <summary>
        /// Verify if two types are equals
        /// </summary>
        /// <param name="type1">The first type</param>
        /// <param name="type2">The second type</param>
        /// <param name="inherit">Boolean indicating whether checks if the first type is assignable from the second type</param>
        /// <returns>Boolean indicating if the first type is equals from the second</returns>
        public static bool IsClassesEqual(Type type1, Type type2, bool inherit)
        {
            if (inherit)
                return type1.IsAssignableFrom(type2);
            else
                return type1 == type2;
        }

        /// <summary>
        /// Get a color object from the html code of this same color
        /// </summary>
        /// <param name="htmlColor">Html code of the color</param>
        /// <returns>The color of the html color code</returns>
        public static Color GetColorFromHtmlColor(string htmlColor)
        {
            return ColorTranslator.FromHtml(htmlColor);
        }

        /// <summary>
        /// Get the name of property from a lambda expression
        /// </summary>
        /// <typeparam name="T">The type for get the property name</typeparam>
        /// <param name="expression">The lambda expression to define the property on the type</param>
        /// <returns>The property name</returns>
        public static string GetPropertyName<T>(Expression<Func<T, object>> expression)
        {
            MemberExpression memberExpression = (expression.Body is UnaryExpression ? ((UnaryExpression)expression.Body).Operand : expression.Body) as MemberExpression;

            if (memberExpression == null)
                throw new Exception(string.Format("Expression '{0}' don't refers to a property", expression.ToString()));

            PropertyInfo property = memberExpression.Member as PropertyInfo;
            if (property == null)
                throw new Exception(string.Format("Expression '{0}' don't refers to a property", expression.ToString()));

            return property.Name;
        }

        /// <summary>
        /// Get the hexadecimal code from a color
        /// </summary>
        /// <param name="color">The color to get the hexdecimal code</param>
        /// <returns>The hexadicimal code from the color received</returns>
        public static string GetHexCodeFromColor(Color color)
        {
            return string.Format("#{0}{1}{2}", color.R.ToString("X2"), color.G.ToString("X2"), color.B.ToString("X2"));
        }

        /// <summary>
        /// Get all members expression in an expression which has a dynamic type as return
        /// </summary>
        /// <param name="expression">Expression to get all members expression</param>
        /// <returns>IEnumerable with all members expression in the expression received</returns>
        public static IEnumerable<MemberExpression> GetMembersExpressionFromDynamicResultInExpression(Expression<Func<dynamic>> expression)
        {
            if (expression == null)
                throw new ArgumentNullException("expression");

            NewExpression exp = expression.Body as NewExpression;
            return exp.Arguments.Cast<MemberExpression>();
        }

        /// <summary>
        /// Replace metadata inside a string in the format: "{tags_name}"
        /// </summary>
        /// <param name="text">Text which to be made the replace</param>
        /// <param name="metadata">The object which is the metadata to be replaced in the text</param>
        /// <returns>The Text parameter replaced with the metadata object</returns>
        public static string StringReplaceWithMetadata(string text, object metadata)
        {
            string textWithMetadata = text;
            if (metadata != null)
                foreach (PropertyInfo prop in metadata.GetType().GetProperties().Where(w => w.CanRead))
                {
                    string propName = prop.Name;
                    object propValue = prop.GetValue(metadata);
                    if (propValue != null)
                        textWithMetadata = textWithMetadata.Replace(string.Format("{{{0}}}", propName), propValue.ToString());
                }
            return textWithMetadata;
        }
    }
}