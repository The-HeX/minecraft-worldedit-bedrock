using System.Collections.Generic;

namespace SchematicExporter
{
    public class ModelOverview
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public int Length { get; set; }
        public List<Layer> Layers { get; set; }
    }
}