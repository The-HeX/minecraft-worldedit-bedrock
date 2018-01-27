using System;
using System.Collections.Generic;

namespace ShapeGenerator.Generators
{
    public class CircleGenerator : IGenerator
    {
        public List<Line> TransformToLines(List<Point> points, Options options)
        {
            return SphereGenerator.LinesFromPoints(points, options);
        }

        List<Line> IGenerator.Run(Options options)
        {
            return TransformToLines(Run(options), options);
        }

        public List<Point> Run(Options options)
        {
            var points = new List<Point>();

            var radius = options.Radius;
            var centerX = options.CenterX;
            var centerZ = options.CenterZ;
            var fill = options.Fill;
            //var y = options.Y;

            var lowerX = centerX - radius - 1;
            var lowerZ = centerZ - radius - 1;
            var upperX = centerX + radius + 1;
            var upperZ = centerZ + radius + 1;
            var lowerY = options.CenterY;
            var upperY = options.CenterY + options.Height - 1;
            if (upperY < lowerY)
            {
                var swap = upperY;
                upperY = lowerY;
                lowerY = swap;
            }
            for (var x = lowerX; x < upperX; x++)
                for (var z = lowerZ; z < upperZ; z++)
                {
                    for (var y = lowerY; y <= upperY; y++)
                    {
                        var distance = Distance(centerX, centerZ, x, z);

                        if (distance == radius)
                            points.Add(new Point {X = x, Z = z, Y = y});

                        if (fill)
                            if (distance < radius)
                                points.Add(new Point {X = x, Z = z, Y = y});
                    }
                }
            return points;
        }

        private static double Distance(int centerX, int centerZ, int x, int z)
        {
            return Math.Round(Math.Sqrt(Math.Pow(centerX - x, 2) + Math.Pow(centerZ - z, 2)), 0);
        }
    }
}