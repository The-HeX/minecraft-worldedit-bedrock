using System;
using System.Collections.Generic;
using System.Linq;

namespace ShapeGenerator.Generators
{
    public class SphereGenerator : IGenerator
    {
        public List<Point> Run(Options options)
        {
            var points = new List<Point>();

            var radius = options.Radius;
            var centerX = options.CenterX;
            var centerZ = options.CenterZ;
            var centerY = options.CenterY;

            var lowerX = centerX - radius - 1;
            var lowerZ = centerZ - radius - 1;
            var lowerY = centerY - radius - 1;
            var upperX = centerX + radius + 1;
            var upperZ = centerZ + radius + 1;
            var upperY = centerY + radius + 1;

            for (var y = lowerY; y < upperY; y++)
            for (var x = lowerX; x < upperX; x++)
            for (var z = lowerZ; z < upperZ; z++)
            {
                var distance = Distance(centerX, centerZ, centerY, x, z, y);

                if (distance == radius)
                    points.Add(new Point { X = x, Z = z, Y = y });
                //if (fill)
                //{
                //    if (distance < radius)
                //    {
                //        points.Add(new Point { X = x, Z = z, Y = y });
                //    }
                //}
            }
            return points;
        }

        public List<Line> TransformToLines(List<Point> points,Options options)
        {
            return LinesFromPoints(points, options);
        }

        public static List<Line> LinesFromPoints(List<Point> points, Options options)
        {
            var lines = new List<Line>();
            foreach (var point in points.ToList())
            {
                var item1 = new Line { Start = point, End = point ,Block = options.Block};
                lines.Add(item1);
            }

            return lines;
        }


        private static double Distance(int centerX, int centerZ, int centerY, int x, int z, int y)
        {
            return Math.Round(Math.Sqrt(Math.Pow(centerX - x, 2) + Math.Pow(centerZ - z, 2) + Math.Pow(centerY - y, 2)),
                0);
        }

    }
}