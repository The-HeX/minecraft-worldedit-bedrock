using CommandLine;
using CommandLine.Text;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShapeGenerator
{
    public enum Shape{
      Circle, //working
      Cylinder, // circle with -F (fill)
      Sphere,
      Triangle,
      Piramid,
      Square,
      Rectangle,
      Line
    }

    class Program
    {
        static void Main(string[] args)
        {
            var time = DateTime.Now.ToString("hhmmssffff");
            var options = new Options();
            var isValid = CommandLine.Parser.Default.ParseArgumentsStrict(args, options);
            if (!isValid)
            {
                Console.WriteLine("invalid arguments");
                Console.Read();
                return;
            }

            var points = new List<Point>();


            if (options.Shape== Shape.Circle)
            {
                points = GenerateCircle(options);
                List<Line> lines = SimpleLinesFromPoints(points, options);
                WriteLinesFile(lines, @"..\..\..\..\circle-" + time + ".csv");
                WritePointsFile(points, @"points.csv");

                Console.WriteLine($"there were {lines.Count} lines");
                Console.WriteLine($"there were {points.Count} points");
            }
            if(options.Shape== Shape.Sphere)
            {
                points = GenerateSphere(options);
                List<Line> lines = LinesFromPoints(points, options);
                WriteLinesFile(lines, @"..\..\..\..\sphere-" + time + ".csv");

            }
            if(options.Shape== Shape.Line)
            {
                var opt = (ILineOptions)options;


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
                    for(var y = lowerY; y <= upperY; y++)
                        for(var z = lowerZ; z <= upperZ; z++)
                        {
                            if( PointLiesOnLine(x1, y1, z1, x2, y2, z2, x, y, z))
                            {
                                points.Add(new Point {X=x,Y=y,Z=z});
                            }
                        }
                List<Line> lines = LinesFromPoints(points, options);
                WriteLinesFile(lines, @"..\..\..\..\line-" + time + ".csv");
            }

            //   Console.ReadKey();
            Thread.Sleep(1000);
        }

        private static bool PointLiesOnLine(int x1, int y1, int z1, int x2, int y2, int z2, int x, int y, int z)
        {
            var AB = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1) + (z2 - z1) * (z2 - z1));
            var AP = Math.Sqrt((x - x1) * (x - x1) + (y - y1) * (y - y1) + (z - z1) * (z - z1));
            var PB = Math.Sqrt((x2 - x) * (x2 - x) + (y2 - y) * (y2 - y) + (z2 - z) * (z2 - z));
            double difference = (AB - (AP + PB));
            if (Math.Abs(difference) < 0.010)
                return true;
            return false;
        }

        private static List<Line> LinesFromPoints(List<Point> points, Options options)
        {
            var lines = new List<Line>();
            foreach (var point in points.ToList())
            {
                Line item1 = new Line { Start = point, End = point };
                lines.Add(item1);
            }

            return lines;
        }

        private static List<Point> GenerateSphere(ISphereOptions options)
        {
            List<Point> points = new List<Point>();

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
            {
                for (var x = lowerX; x < upperX; x++)
                {
                    for (var z = lowerZ; z < upperZ; z++)
                    {
                        var distance = Distance(centerX, centerZ,centerY, x, z, y);

                        if (distance == radius)
                        {
                            points.Add(new Point { X = x, Z = z, Y = y });
                        }
                        //if (fill)
                        //{
                        //    if (distance < radius)
                        //    {
                        //        points.Add(new Point { X = x, Z = z, Y = y });
                        //    }
                        //}
                    }
                }
            }
            return points;
        }

        private static double Distance(int centerX, int centerZ, int centerY, int x, int z, int y)
        {
            return Math.Round(Math.Sqrt(Math.Pow(centerX - x, 2) + Math.Pow(centerZ - z, 2) + Math.Pow(centerY - y, 2) )  , 0);
        }

        private static void WritePointsFile(List<Point> points,string filename)
        {
            using (var writer = File.CreateText(filename))
            {
                var csv = new CsvWriter(writer);
                csv.WriteHeader<Point>();
                foreach (var l in points)
                {
                    csv.WriteRecord<Point>(l);
                }
            }
        }

        private static void WriteLinesFile(List<Line> lines,string filename)
        {
            using (var writer = File.CreateText(filename))
            {
                var csv = new CsvWriter(writer);
                csv.WriteHeader<Line>();
                foreach (var l in lines)
                {
                    csv.WriteRecord<Line>(l);
                }
            }
        }

        private static List<Line> SimpleLinesFromPoints(List<Point> points,Options options)
        {
            var lines = new List<Line>();
            points = points.OrderBy(a => a.X).ThenBy(a => a.Z).ToList();
            Line item = new Line { Start = points[0], End = points[0] };
            item.Start.Y = options.Y;
            item.End.Y = options.Y + options.Height;
            lines.Add(item);
            foreach (var point in points.Skip(1).ToList())
            {
                var lastLine = lines.Last();
                if (point.X == lastLine.Start.X)
                {
                    if (point.Z == lastLine.End.Z + 1)
                    {
                        lastLine.End = point;
                        lastLine.End.Y = options.Y + options.Height;
                        continue;
                    }
                }
                Line item1 = new Line { Start = point, End = point };
                item1.Start.Y = options.Y;
                item1.End.Y = options.Y + options.Height;
                lines.Add(item1);
            }

            return lines;
        }

        private static List<Point> GenerateCircle(Options options)
        {
            List<Point> points = new List<Point>();

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
            {
                for (var z = lowerZ; z < upperZ; z++)
                {
                    var distance = Distance(centerX, centerZ, x, z);

                    if (distance == radius)
                    {
                        points.Add(new Point { X = x, Z = z ,Y=y});
                    }
                    if (fill)
                    {
                        if (distance < radius)
                        {
                            points.Add(new Point { X = x, Z = z ,Y=y});
                        }
                    }
                }
            }
            return points;
        }

        private static double Distance(int centerX, int centerZ, int x, int z)
        {
            return Math.Round(Math.Sqrt(Math.Pow(centerX - x, 2) + Math.Pow(centerZ - z, 2)), 0);
        }
    }

    public interface ISphereOptions
    {
        int Radius { get; set; }


        int CenterX { get; set; }

        

        int CenterZ { get; set; }

        int CenterY { get; set; }

    }

    public class Line
    {
        public Point Start { get; set; }
        public Point End { get; set; }
    }


    public class Options : ISphereOptions, ICircleOptions, ILineOptions
    {

        [Option('s', "shape", Required = true,HelpText = "Input files to be processed.")]
        public Shape Shape { get; set; }

        [Option('r', "radius", HelpText = "Input files to be processed.")]
        public int Radius { get; set; }

        [Option('x', "cx",  HelpText = "Input files to be processed.")]

        public int CenterX { get; set; }

        [Option('z', "cz", HelpText = "Input files to be processed.")]

        public int CenterZ { get; set; }
        
        [Option('y', Required = false, HelpText = "Input files to be processed.")]
        public int Y { get; set; }
        [Option('h', "height",  HelpText = "Input files to be processed.")]
        public int Height { get; set; }

        [Option('f', "fill",  HelpText = "Input files to be processed.")]
        public bool Fill { get; set; }

        [Option('y', "CenterY", HelpText = "Input files to be processed.")]
        public int CenterY { get; set; }

        [Option( "x1", HelpText = "Input files to be processed.")]
        public int X1  { get; set; }
        [Option("x2", HelpText = "Input files to be processed.")]
        public int X2  { get; set; }
        [Option("y1", HelpText = "Input files to be processed.")]
        public int Y1  { get; set; }
        [Option("y2", HelpText = "Input files to be processed.")]
        public int Y2  { get; set; }
        [Option("z1", HelpText = "Input files to be processed.")]
        public int Z1  { get; set; }
        [Option("z2", HelpText = "Input files to be processed.")]
        public int Z2 { get; set; }

        public Point Start
        {
            get
            {
                return new Point { X = X1, Y = Y1, Z = Z1 };
            }
        }
            

        public Point End
        {
            get
            {
                return new Point { X = X2, Y = Y2, Z = Z2 };
            }
        }
    }

}
