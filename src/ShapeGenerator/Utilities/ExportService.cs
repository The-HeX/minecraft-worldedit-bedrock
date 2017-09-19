using System.Collections.Generic;
using System.IO;
using CsvHelper;

namespace ShapeGenerator.Utilities
{
    public class ExportService
    {
        public static void WritePointsFile(List<Point> points, string filename)
        {
            using (var writer = File.CreateText(filename))
            {
                var csv = new CsvWriter(writer);
                csv.WriteHeader<Point>();
                foreach (var l in points)
                    csv.WriteRecord(l);
            }
        }

        public static void WriteLinesFile(List<Line> lines, string filename)
        {
            using (var writer = File.CreateText(filename))
            {
                var csv = new CsvWriter(writer);
                csv.WriteHeader<Line>();
                foreach (var l in lines)
                    csv.WriteRecord(l);
            }
        }

    }
}