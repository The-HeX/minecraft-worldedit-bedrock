using System.Collections.Generic;
using System.Linq;

namespace WorldEdit.Schematic
{
    public class ModelAnalyzer
    {
        public static ModelOverview Analyze(List<Point> points)
        {
            var results = new ModelOverview();
            var minY = points.Min(a => a.Y);
            var maxY = points.Max(a => a.Y);
            results.Height = maxY - minY;
            var minX = points.Min(a => a.X);
            var maxX = points.Max(a => a.X);
            results.Width = maxX - minX;
            var minZ = points.Min(a => a.Z);
            var maxZ = points.Max(a => a.Z);
            results.Length = maxZ - minZ;
            results.Minimum = new Position(minX, minY, minZ);
            results.Maximum = new Position(maxX, maxY, maxZ);
            results.TotalBlocks = maxX*maxY*maxZ;
            results.TotalPlaceableBlocks = points.Count(a => !a.BlockId.Equals(0));
            results.Layers = points.GroupBy(a => a.Y).Select(a => new Layer
            {
                Y = a.Key,
                Blocks = a.GroupBy(b => new {b.BlockName})
                    .Select(b =>
                        new BlockCount
                        {
                            Block = b.Key.BlockName,
                            Count = b.Count(),
                            PercentOfLayer = 1.0*b.Count()/a.Count()
                        }).ToList()
            }).ToList();


            return results;
        }
    }
}