using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using ShapeGenerator;
using ShapeGenerator.Generators;
using System.Diagnostics;

namespace SchematicExporter
{
    internal class Program
    {
        //http://localhost:8080/fill?from=3%205%203&to=30 3f0 30&tileName=stone&tileData=0
        private static void Main(string[] args)
        {

            var target = new Position(0,0,0);
            var shift=new Position(0,0,0);
            var rotation = Rotate.None;

            var command = args[0];
            var FileName = args[1];
            var outputFilename = Path.GetFileNameWithoutExtension(FileName) + ".fill";
            if (args.Length > 2)
            {
                outputFilename = args[2];
            }
            if (args.Length == 6)
            {
                target.X = Convert.ToInt32(args[3]);
                target.Y = Convert.ToInt32(args[4]);
                target.Z = Convert.ToInt32(args[5]);
            }
            var schematic = Schematic.LoadFromFile(FileName);
            var points = schematic.GetPoints();

            switch (command)
            {
                case "analyze":
                        var results = ModelAnalyzer.Analyze(points);
                        var firstGroundLayer = results.Layers.First(a => a.Blocks.Any(b => b.Block.Equals("air") && b.PercentOfLayer >= 0.5)).Y;
                        Console.WriteLine($"{Path.GetFileName(FileName)} Model Size: X:{results.Width} Y:{results.Height} Z:{results.Length} Ground Level:{firstGroundLayer} Total Blocks:{results.Width * results.Height * results.Length}");
                    break;
                case "cmdFile":
                        var lines = ConvertFileToCommands( points);            
                        WriteLinesToCommandFile(target, outputFilename,lines);
                    break;

                case "exportcsv":
                    var exportLines = ConvertFileToCommands(points);
                    WriteLinesToTemplateFile(target, outputFilename, exportLines);
                    break;
                case "import":
                    if (args.Length >= 5)
                    {
                        target.X = Convert.ToInt32(args[2]);
                        target.Y = Convert.ToInt32(args[3]);
                        target.Z = Convert.ToInt32(args[4]);
                    }
                    if (args.Length >= 6)
                    {
                        rotation = (Rotate) Convert.ToInt32(args?[5]);
                    }
                    if (args.Length >= 9)
                    {
                        shift.X = Convert.ToInt32(args[6]);
                        shift.Y = Convert.ToInt32(args[7]);
                        shift.Z = Convert.ToInt32(args[8]);
                    }

                    Console.WriteLine($"importing {FileName} to {target}");
                    SendCommandsToCodeConnection(target, points, rotation,shift);
                    break;
                default:
                    break;
            }
            Console.WriteLine($"{FileName}  ${outputFilename} {target.X} {target.Y} {target.Z}");
        }

        private static void WriteLinesToTemplateFile(Position target, string csvOutputFile, List<Line> lines)
        {
            var file = File.CreateText(csvOutputFile);
            file.WriteLine($"tp {target.X} {target.Y} {target.Z}");
            lines.OrderBy(a => a.Start.Y).ThenBy(a => a.Start.X).ThenBy(a => a.Start.Z).ToList().ForEach(a => { file.WriteLine(a.Csv(target.X, target.Y, target.Z)); });
            file.Close();
        }

        private static void SendCommandsToCodeConnection(Position target, List<Point> points,Rotate rotation,Position clip=null)
        {
            var httpclient = new System.Net.Http.HttpClient();
            var sw = new Stopwatch();
            httpclient.GetStringAsync($"http://localhost:8080/executeasother?origin=@p&position=~%20~%20~&command=say%20"+ "preparing schematic").Wait();
            if (clip != null)
            {
                points=points.Where(a => a.X >= clip.X && a.Y >= clip.Y && a.Z >= clip.Z).Select(a=>a.Shift(clip.Muliply(-1))).ToList();
            }
            if (rotation != Rotate.None)
            {
                sw.Start();
                Console.WriteLine($"rotating points...");
                var rotatedPoints=points.AsParallel().Select(a => a.Rotate(rotation)).ToList();
                Console.WriteLine($"time to rotate {sw.Elapsed}");
                sw.Reset();                
                var measures = ModelAnalyzer.Analyze(rotatedPoints);
                sw.Start();
                Console.WriteLine($"shifting points...");
                points = rotatedPoints.AsParallel().Select(a => a.Shift(measures.Minimum.Muliply(-1))).ToList();
                Console.WriteLine($"time to shift {sw.Elapsed}");
                sw.Reset();
            }
            sw.Start();
            Console.WriteLine($"combining points...");
            var exportLines = ConvertFileToCommands(points.Where(a=>a.BlockId!=0).ToList());
            Console.WriteLine($"time to combine {sw.Elapsed}");
            sw.Reset();
            sw.Start();
            var shift = exportLines.AsParallel().Select(a => a.Shift(target)).ToList();
            Console.WriteLine($"time to shift {sw.Elapsed}");
            sw.Reset();
            sw.Start();
            var importLines=shift.AsParallel().OrderBy(a => a.Start.Y).ThenBy(a=>a.Start.X).ThenBy(a=>a.Start.Z).ToList();
            Console.WriteLine($"time to sort {sw.Elapsed}");

            sw.Reset();
            httpclient.GetStringAsync($"http://localhost:8080/executeasother?origin=@p&position=~%20~%20~&command=say%20" + "starting schematic import").Wait();
            sw.Start();            
            foreach (var line in importLines)
            {
                var result = httpclient.GetStringAsync($"http://localhost:8080/fill?from={line.Start.X} {line.Start.Y} {line.Start.Z}&to={line.End.X} {line.End.Y} {line.End.Z}&tileName={line.BlockName}&tileData={line.Data}").Result;
                Console.WriteLine(result);
            }
            sw.Stop();
            Console.WriteLine($"time to import {sw.Elapsed.TotalSeconds}");
            httpclient.GetStringAsync($"http://localhost:8080/executeasother?origin=@p&position=~%20~%20~&command=say%20" + $"schematic import completed in {sw.Elapsed.TotalSeconds} seconds").Wait();

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