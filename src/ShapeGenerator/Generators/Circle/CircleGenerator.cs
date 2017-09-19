using System;
using System.Collections.Generic;
using System.Linq;

namespace ShapeGenerator.Generators
{
    public class CircleGenerator : IGenerator
    {
        public List<Point> Run(Options options)
        {
            var points = new List<Point>();

            var radius = options.Radius;
            var centerX = options.CenterX;
            var centerZ = options.CenterZ;
            var fill = options.Fill;
            var y = options.Y;

            var lowerX = centerX - radius - 1;
            var lowerZ = centerZ - radius - 1;
            var upperX = centerX + radius + 1;
            var upperZ = centerZ + radius + 1;

            for (var x = lowerX; x < upperX; x++)
            for (var z = lowerZ; z < upperZ; z++)
            {
                var distance = Distance(centerX, centerZ, x, z);

                if (distance == radius)
                    points.Add(new Point { X = x, Z = z, Y = y });

                if (fill)
                    if (distance < radius)
                        points.Add(new Point { X = x, Z = z, Y = y });
            }
            return points;
        }

        public List<Line> TransformToLines(List<Point> points,Options options)
        {
            return SimpleLinesFromPoints(points, options);            
        }

        private static List<Line> SimpleLinesFromPoints(List<Point> points, Options opt)
        {
            var options = (ICircleOptions) opt;
            var lines = new List<Line>();
            points = points.OrderBy(a => a.X).ThenBy(a => a.Z).ToList();
            var item = new Line { Start = points[0], End = points[0] };
            item.Start.Y = options.CenterY;
            item.End.Y = options.CenterY + options.Height;
            lines.Add(item);
            foreach (var point in points.Skip(1).ToList())
            {
                var lastLine = lines.Last();
                if (point.X == lastLine.Start.X)
                    if (point.Z == lastLine.End.Z + 1)
                    {
                        lastLine.End = point;
                        lastLine.End.Y = options.CenterY + options.Height;
                        continue;
                    }
                var item1 = new Line { Start = point, End = point };
                item1.Start.Y = options.CenterY;
                item1.End.Y = options.CenterY + options.Height;
                lines.Add(item1);
            }

            return lines;
        }


        private static double Distance(int centerX, int centerZ, int x, int z)
        {
            return Math.Round(Math.Sqrt(Math.Pow(centerX - x, 2) + Math.Pow(centerZ - z, 2)), 0);
        }

    }
}