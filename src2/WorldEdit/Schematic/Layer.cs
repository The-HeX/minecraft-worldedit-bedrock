using System.Collections.Generic;

namespace WorldEdit.Schematic
{
    public class Layer
    {
        public int Y { get; set; }
        public List<BlockCount> Blocks { get; set; }
    }
}