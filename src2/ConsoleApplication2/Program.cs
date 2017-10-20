using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ShapeGenerator;
using ShapeGenerator.Generators;

namespace SchematicExporter
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            int toX = 0;
            int toY = 0;
            int toZ = 0;
            var FileName = args[0];
            string fillCommandOutputFile=Path.GetFileNameWithoutExtension(FileName)+".fill";
            string csvOutputFile= Path.GetFileNameWithoutExtension(FileName) + ".template";

            if (args.Length > 1)
            {
                fillCommandOutputFile = args[1];
            }
            
            if (args.Length == 5)
            {
                toX = Convert.ToInt32(args[2]);
                toY = Convert.ToInt32(args[3]);
                toZ = Convert.ToInt32(args[4]);
            }

            Console.WriteLine($"{FileName}  ${fillCommandOutputFile} {toX} {toY} {toZ}");
            var lines = ConvertFileToCommands( FileName);            
            WriteLinesToCommandFile(toX, toY, toZ, fillCommandOutputFile,lines);
            WriteLinesToTemplateFile(0, 0, 0, csvOutputFile, lines);
        }

        private static void WriteLinesToTemplateFile(int toX, int toY, int toZ, string csvOutputFile, List<Line> lines)
        {
            var file = File.CreateText(csvOutputFile);
            file.WriteLine($"tp {toX} {toY} {toZ}");
            lines.OrderBy(a => a.Start.Y).ThenBy(a => a.Start.X).ThenBy(a => a.Start.Z).ToList().ForEach(a => { file.WriteLine(a.Csv(toX, toY, toZ)); });
            file.Close();
        }

        private static List<Line> ConvertFileToCommands(string FileName)
        {
            var schematic = Schematic.LoadFromFile(FileName);

            var points = schematic.GetPoints();

            return LineFactory.CreateFromPoints(points);
        }


        private static void WriteLinesToCommandFile(int toX, int toY, int toZ, string outputFilename, List<Line> lines)
        {
            var file = File.CreateText(outputFilename);
            file.WriteLine($"tp {toX} {toY} {toZ}");
            lines
                .OrderBy(a=>a.Start.Y).ThenBy(a=>a.Start.X).ThenBy(a=>a.Start.Z)
                .Where(a => a.Block != 0)
                .ToList().ForEach(a => { file.WriteLine(a.Command(toX, toY, toZ)); });
            file.Close();
        }
    }
}