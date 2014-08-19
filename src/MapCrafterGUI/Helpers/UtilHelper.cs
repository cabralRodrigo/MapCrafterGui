using System.Drawing;
using System.Linq;
using System.Reflection;

namespace MapCrafterGUI.Helpers
{
    public static class UtilHelper
    {
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
        /// Get the hexadecimal code from a color
        /// </summary>
        /// <param name="color">The color to get the hexdecimal code</param>
        /// <returns>The hexadicimal code from the color received</returns>
        public static string GetHexCodeFromColor(Color color)
        {
            return string.Format("#{0}{1}{2}", color.R.ToString("X2"), color.G.ToString("X2"), color.B.ToString("X2"));
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