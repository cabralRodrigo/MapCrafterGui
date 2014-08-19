using MapCrafterGUI.Enums;
using MapCrafterGUI.Extensions;
using MapCrafterGUI.Helpers;
using System.Linq;
using System.Text;

namespace MapCrafterGUI.MapCrafterConfiguration
{
    public static class MapCrafterConfigurationGenerator
    {
        public static string GenerateConfigurationFile(RenderConfiguration renderConfig)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLineFormat("output_dir = {0}", renderConfig.OutputFolder);
            sb.AppendLineFormat("background_color = {0}", UtilHelper.GetHexCodeFromColor(renderConfig.BackgroudColor));
            sb.AppendLine(string.Empty);

            foreach (WorldConfiguration world in renderConfig.Worlds)
            {
                sb.AppendLineFormat("[world:{0}]", world.Name);
                sb.AppendLineFormat("input_dir = {0}", world.InputFolder);
                sb.AppendLineFormat("dimension = {0}", world.Dimension.ToString().ToLower());
                sb.AppendLine(string.Empty);

                foreach (MapConfiguration map in world.Maps)
                {
                    sb.AppendLineFormat("[map:{0}]", map.MapID);
                    sb.AppendLineFormat("name = {0}", map.Name);
                    sb.AppendLineFormat("world = {0}", world.Name);
                    sb.AppendLineFormat("rendermode = {0}", map.RenderMode.ToString().ToLower());
                    sb.AppendLineFormat("rotation = {0}", MapCrafterConfigurationGenerator.RotationsToString(map.GetRotations()));
                    sb.AppendLine(string.Empty);
                }
            }

            return sb.ToString().Trim();
        }

        private static string RotationsToString(MapRotation[] rotations)
        {
            var rotationsDistinct = rotations.Distinct().ToList();

            if (rotationsDistinct.Count == 0)
                rotationsDistinct.Add(MapConfiguration.DefaultRotation);

            StringBuilder sb = new StringBuilder();
            foreach (MapRotation rotation in rotationsDistinct)
                sb.Append(" " + EnumHelper.GetEnumValue(rotation));

            return sb.ToString();
        }
    }
}
