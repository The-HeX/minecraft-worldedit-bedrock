using System;
using System.Collections.Generic;

namespace ShapeGenerator.Generators
{
    public class SquareGenerator : IGenerator
    {

        public List<Point> Run(Options options)
        {
            var opt = (ISquareOptions)options;
            var points = new List<Point>();

            var lowerX = opt.CenterX - opt.Width / 2;
            var lowerY = opt.CenterY; ;
            var lowerZ = opt.CenterZ - opt.Length / 2;
            var upperX = opt.CenterX + opt.Width / 2;
            var upperY = lowerY+ opt.Height-1; ;
            var upperZ = opt.CenterZ + opt.Length / 2;
           
            for (var x = lowerX; x <= upperX; x++)
            {
                for (var y = lowerY; y <= upperY; y++)
                {
                    for (var z = lowerZ; z <= upperZ; z++)
                    {
                        if (TestForCoordinate(x, lowerX, upperX, z, lowerZ, upperZ, opt,y,lowerY,upperY))
                        {
                            points.Add(new Point { X = x, Y = y, Z = z });
                        }

                    }
                }
            }                        
            return points;
        }

        protected virtual  bool TestForCoordinate(int x, int lowerX, int upperX, int z, int lowerZ, int upperZ, ISquareOptions opt, int y, int lowerY, int upperY)
        {
            return x == lowerX || x == upperX || z == lowerZ || z == upperZ || opt.Fill;
        }


        public List<Line> TransformToLines(List<Point> points, Options options)
        {
            return SphereGenerator.LinesFromPoints(points, options);
        }

        List<Line> IGenerator.Run(Options options)
        {
            if (!options.Fill)
            {
                return TransformToLines(Run(options), options);
            }
            return GenerateFillSquare(options);
        }

        private static List<Line> GenerateFillSquare(Options opt)
        {

            var lowerX = opt.CenterX - opt.Width / 2;
            var lowerY = opt.CenterY; ;
            var lowerZ = opt.CenterZ - opt.Width / 2;

            var upperX = opt.CenterX + opt.Width / 2;
            var upperY = lowerY + opt.Height-1; ;
            var upperZ = opt.CenterZ + opt.Width / 2;
            return SphereGenerator.SplitLinesIntoMaxSizes( new List<Line>() { new Line { Block = opt.Block,Start=new Point {X=lowerX,Y=lowerY,Z=lowerZ },End=new Point {X=upperX,Y=upperY,Z=upperZ } } });
        }
    }
}