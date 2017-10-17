using System;
using System.Collections.Generic;

namespace ShapeGenerator.Generators
{
    public class LineGenerator : IGenerator
    {
        private const double ToleranceToFindPoint = 0.010;

        public List<Point> Run(Options options)
        {
            var opt = (ILineOptions)options;
            var points = new List<Point>();

            var lowerX = Math.Min(opt.Start.X, opt.End.X);
            var lowerY = Math.Min(opt.Start.Y, opt.End.Y);
            var lowerZ = Math.Min(opt.Start.Z, opt.End.Z);

            var upperX = Math.Max(opt.Start.X, opt.End.X);
            var upperY = Math.Max(opt.Start.Y, opt.End.Y);
            var upperZ = Math.Max(opt.Start.Z, opt.End.Z);

            var x1 = opt.Start.X;
            var y1 = opt.Start.Y;
            var z1 = opt.Start.Z;
            var x2 = opt.End.X;
            var y2 = opt.End.Y;
            var z2 = opt.End.Z;

            for (var x = lowerX; x <= upperX; x++)
            for (var y = lowerY; y <= upperY; y++)
            for (var z = lowerZ; z <= upperZ; z++)
                if (PointLiesOnLine(x1, y1, z1, x2, y2, z2, x, y, z))
                    points.Add(new Point { X = x, Y = y, Z = z });
            return points;
        }

        public List<Line> TransformToLines(List<Point> points,Options options)
        {
            return SphereGenerator.LinesFromPoints(points, options);
        }

        private static bool PointLiesOnLine(int x1, int y1, int z1, int x2, int y2, int z2, int x, int y, int z)
        {
            var AB = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1) + (z2 - z1) * (z2 - z1));
            var AP = Math.Sqrt((x - x1) * (x - x1) + (y - y1) * (y - y1) + (z - z1) * (z - z1));
            var PB = Math.Sqrt((x2 - x) * (x2 - x) + (y2 - y) * (y2 - y) + (z2 - z) * (z2 - z));
            var difference = AB - (AP + PB);
            if (Math.Abs(difference) < ToleranceToFindPoint)
                return true;
            return false;
        }

        List<Line> IGenerator.Run(Options options)
        {
            return TransformToLines(Run(options), options);
        }
    }
}