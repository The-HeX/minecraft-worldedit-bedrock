using System.Collections.Generic;

namespace SchematicExporter
{
    public class Layer
    {
        public int Y { get; set; }
        public List<BlockCount> Blocks { get; set; }
    }
}