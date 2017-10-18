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
            string outputFilename=Path.GetFileNameWithoutExtension(FileName)+".fill";
            if (args.Length > 1)
            {
                outputFilename = args[1];
            }
            
            if (args.Length == 5)
            {
                toX = Convert.ToInt32(args[2]);
                toY = Convert.ToInt32(args[3]);
                toZ = Convert.ToInt32(args[4]);
            }

            Console.WriteLine($"{FileName}  ${outputFilename} {toX} {toY} {toZ}");
            var lines = ConvertFileToCommands( FileName);            
            WriteLinesToCommandFile(toX, toY, toZ, outputFilename,
                lines);
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