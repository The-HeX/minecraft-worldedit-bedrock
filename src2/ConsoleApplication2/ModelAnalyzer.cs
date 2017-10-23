using System.Collections.Generic;
using System.Linq;
using ShapeGenerator;

namespace SchematicExporter
{
    public class ModelAnalyzer
    {
        public static ModelOverview Analyze(List<Point> points)
        {
            var results = new ModelOverview();
            results.Height = points.Max(a => a.Y) - points.Min(a => a.Y);
            results.Width  = points.Max(a => a.X) - points.Min(a => a.X);
            results.Length = points.Max(a => a.Z) - points.Min(a => a.Z);

            results.Layers= points.GroupBy(a => a.Y).Select(a => new Layer
            {
                Y = a.Key,
                Blocks = a.GroupBy(b => new {b.BlockName})
                    .Select(b =>
                        new BlockCount{Block = b.Key.BlockName, Count = b.Count(), PercentOfLayer = 1.0 *b.Count() / a.Count()}).ToList()                 
            }).ToList();
            


            return results;
        }
    }
}