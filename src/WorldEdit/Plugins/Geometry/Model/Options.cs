using ShapeGenerator.Generators;

namespace ShapeGenerator
{
    public class Options : ISphereOptions, ICircleOptions, ILineOptions, ISquareOptions
    {
        public int Y { get; set; }
        public Shape Shape { get; set; }
        public int Height { get; set; }
        public bool Fill { get; set; }
        public int X1 { get; set; }
        public int X2 { get; set; }
        public int Y1 { get; set; }
        public int Y2 { get; set; }
        public int Z1 { get; set; }
        public int Z2 { get; set; }
        public Point Start => new Point {X = X1, Y = Y1, Z = Z1};
        public Point End => new Point {X = X2, Y = Y2, Z = Z2};
        public int Radius { get; set; }
        public int CenterX { get; set; }
        public int CenterZ { get; set; }
        public int CenterY { get; set; }
        public string Block { get; set; } = "stone";
        public int Length { get; set; }
        public int Width { get; set; }
    }
}