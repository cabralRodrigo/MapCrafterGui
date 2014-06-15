namespace MapCrafterGUI.Helpers
{
    public class Point3D
    {
        public Point3D(long x, long y, long z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public long X { get; set; }
        public long Y { get; set; }
        public long Z { get; set; }
    }
}