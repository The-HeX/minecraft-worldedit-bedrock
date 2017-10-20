using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using ShapeGenerator;
using ShapeGenerator.Generators;

namespace SchematicExporter
{
    internal class Program
    {
        //http://localhost:8080/fill?from=3%205%203&to=30 3f0 30&tileName=stone&tileData=0
        private static void Main(string[] args)
        {

            var target = new Position(0,0,0);

            var command = args[0];
            var FileName = args[1];
            var outputFilename = Path.GetFileNameWithoutExtension(FileName) + ".fill";
            if (args.Length > 2)
            {
                outputFilename = args[2];
            }
            var schematic = Schematic.LoadFromFile(FileName);
            var points = schematic.GetPoints();

            switch (command)
            {
                case "analyze":
                        var results = ModelAnalyzer.Analyze(points);
                        var firstGroundLayer = results.Layers.First(a => a.Blocks.Any(b => b.Block.Equals("air") && b.PercentOfLayer >= 0.5)).Y;
                        Console.WriteLine($"Model Size: X:{results.Width} Y:{results.Height} Z:{results.Length} Ground Level:{firstGroundLayer} Total Blocks:{results.Width * results.Height * results.Length}");
                    break;
                case "cmdFile":
                        if (args.Length == 6)
                        {
                            target.X = Convert.ToInt32(args[3]);
                            target.Y = Convert.ToInt32(args[4]);
                            target.Z = Convert.ToInt32(args[5]);
                        }
                        var lines = ConvertFileToCommands( points);            
                        WriteLinesToCommandFile(target, outputFilename,lines);
                    break;

                case "exportcsv":
                    break;

                case "import":
                    SendCommandsToCodeConnection(target, points, Rotate.None);
                    break;
                default:                
                    break;
            }
            Console.WriteLine($"{FileName}  ${outputFilename} {target.X} {target.Y} {target.Z}");
        }

        private static void SendCommandsToCodeConnection(Position target, List<Point> points,Rotate rotation,Position clip=null)
        {
            throw new NotImplementedException();
        }

        private static List<Line> ConvertFileToCommands(List<Point> points)
        {                         
            return LineFactory.CreateFromPoints(points);
        }

        private static void WriteLinesToCommandFile(Position target, string outputFilename, List<Line> lines)
        {
            var file = File.CreateText(outputFilename);
            file.WriteLine($"tp {target.X} {target.Y} {target.Z}");
            lines
                .OrderBy(a=>a.Start.Y).ThenBy(a=>a.Start.X).ThenBy(a=>a.Start.Z)
                .Where(a => a.Block != 0)
                .ToList().ForEach(a => { file.WriteLine(a.Command(target)); });
            file.Close();
        }
    }

    public enum Rotate:int
    {
        None =0,
        Ninty=90,
        OneEighty=180,
        TwoSeventy=270    
    }
}