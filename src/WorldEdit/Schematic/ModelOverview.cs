using System.Collections.Generic;

namespace WorldEdit.Schematic
{
    public class ModelOverview
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public int Length { get; set; }
        public List<Layer> Layers { get; set; }
        public Position Minimum { get; set; }
        public Position Maximum { get; set; }
        public int TotalBlocks { get; set; }
    }
}