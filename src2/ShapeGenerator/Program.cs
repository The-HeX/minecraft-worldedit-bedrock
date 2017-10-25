using System;
using System.Collections.Generic;
using System.Threading;
using CommandLine;
using ShapeGenerator.Generators;
using ShapeGenerator.Utilities;

namespace ShapeGenerator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //try
            //{
                var _factory = new GeneratorFactory();
//                var time = DateTime.Now.ToString("hhmmssffff");
                var options = new Options();
                Parser.Default.ParseArgumentsStrict(args, options);

                var points = new List<Point>();
                var lines = new List<Line>();

                var generator = _factory.Create(options.Shape);
                lines = generator.Run(options);
                //lines = generator.TransformToLines(points, options);


                //if (lines.Count > 0)
                //    ExportService.WriteLinesFile(lines, $@"..\..\..\..\lines-{options.Shape}-{time}.csv");
                //if (points.Count > 0)
                //    ExportService.WritePointsFile(points, $@"points-{options.Shape}-{time}.csv");


                Console.WriteLine($"there were {lines.Count} lines");
                Console.WriteLine($"there were {points.Count} points");
            //}catch(Exception e)
            //{
            //    Console.WriteLine(e);
            //      Console.ReadKey();
            //}
        }
    }
}