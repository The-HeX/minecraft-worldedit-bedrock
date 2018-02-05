using ShapeGenerator.Generators;

namespace ShapeGenerator
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public Point Clone()
        {
            return new Point {X = X, Y = Y, Z = Z};
        }
        public double Distance(Point from)
        {
            return SphereGenerator.Distance(X, Z, Y, from.X, from.Z, from.Y);
        }

    }
}