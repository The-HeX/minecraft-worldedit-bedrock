using System;
using System.Collections.Generic;
using System.Linq;

namespace ShapeGenerator.Generators
{
    public class SphereGenerator : IGenerator
    {
        public List<Line> TransformToLines(List<Point> points, Options options)
        {
            return LinesFromPoints(points, options);
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
                            points.Add(new Point {X = x, Z = z, Y = y});
                        if (options.Fill)
                        {
                            if (distance < radius)
                            {
                                points.Add(new Point {X = x, Z = z, Y = y});
                            }
                        }
                    }
            return points;
        }

        public static List<Line> LinesFromPoints(List<Point> points, Options options)
        {
            var lines = new List<Line>();
            foreach (var point in points.ToList())
            {
                var item1 = new Line {Start = point.Clone(), End = point.Clone(), Block = options.Block};
                lines.Add(item1);
            }
            lines = lines.OrderBy(a => a.Start.X).ThenBy(a => a.Start.Z).ThenBy(a => a.Start.Y).ToList();
            lines = SquashLines(lines);
            lines = lines.OrderBy(a => a.Start.Y).ThenBy(a => a.Start.X).ThenBy(a => a.Start.Z).ToList();
            lines = SquashLines(lines);

            lines = lines.OrderBy(a => a.Start.Z).ThenBy(a => a.Start.Y).ThenBy(a => a.Start.X).ToList();
            lines = SquashLines(lines);

            lines = lines.OrderBy(a => a.Start.Z).ThenBy(a => a.Start.X).ThenBy(a => a.Start.Y).ToList();
            lines = SquashLines(lines);

            lines = lines.OrderBy(a => a.Start.Y).ThenBy(a => a.Start.Z).ThenBy(a => a.Start.X).ToList();
            lines = SquashLines(lines);

            lines = lines.OrderBy(a => a.Start.X).ThenBy(a => a.Start.Y).ThenBy(a => a.Start.Z).ToList();
            lines = SquashLines(lines);

            lines = SplitLinesIntoMaxSizes(lines);
            return lines;
        }

        public static List<Line> SplitLinesIntoMaxSizes(List<Line> lines)
        {
            var output = new List<Line>();

            foreach (var line in lines)
            {
                if (line.IsSmallerThen(50))
                {
                    output.Add(line);
                }
                else //need to split the line into  smaller segments.
                {
                    output.AddRange(line.SplitToAMaxSize(32));
                }
            }
            return output;
        }

        public static List<Line> SquashLines(List<Line> lines)
        {
            for (var i = 0; i < lines.Count - 1; i++)
            {
                for (var j = i + 1; j < lines.Count; j++)
                {
                    if (lines[i].CanCombine(lines[j]))
                    {
                        lines[i] = lines[i].Combine(lines[j]);
                        lines.Remove(lines[j]);
                        i--;
                        break;
                    }
                }
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