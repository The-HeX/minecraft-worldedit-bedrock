using System;
using System.Collections.Generic;

namespace ShapeGenerator.Generators
{
    public class SquareGenerator : IGenerator
    {
        private const double ToleranceToFindPoint = 0.010;

        public List<Point> Run(Options options)
        {
            var opt = (ISquareOptions)options;
            var points = new List<Point>();

            var lowerX = opt.CenterX - opt.Width / 2;
            var lowerY = opt.CenterY; ;
            var lowerZ = opt.CenterZ - opt.Width / 2;

            var upperX = opt.CenterX + opt.Width / 2;
            var upperY = lowerY+ opt.Height; ;
            var upperZ = opt.CenterZ + opt.Width / 2;

            for (var x = lowerX; x <= upperX; x++)
            {
                for (var y = lowerY; y <= upperY; y++)
                {
                    for (var z = lowerZ; z <= upperZ; z++)
                    {
                        if (x == lowerX || x == upperX || z == lowerZ || z == upperZ || opt.Fill)
                        {
                            points.Add(new Point { X = x, Y = y, Z = z });
                        }

                    }
                }
            }
                
                    
                        
            return points;
        }

        public List<Line> TransformToLines(List<Point> points, Options options)
        {
            return SphereGenerator.LinesFromPoints(points, options);
        }


    }
}