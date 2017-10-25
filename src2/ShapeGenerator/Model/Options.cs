using CommandLine;
using ShapeGenerator.Generators;

namespace ShapeGenerator
{
    public class Options : ISphereOptions, ICircleOptions, ILineOptions,ISquareOptions
    {
        [Option('s', "shape", Required = true, HelpText = "Input files to be processed.")]
        public Shape Shape { get; set; }

        [Option("y", Required = false, HelpText = "Input files to be processed.")]
        public int Y { get; set; }

        [Option('h', "height", HelpText = "Input files to be processed.")]
        public int Height { get; set; }

        [Option('f', "fill", HelpText = "Input files to be processed.")]
        public bool Fill { get; set; }

        public int Length { get; set; }

        [Option("x1", HelpText = "Input files to be processed.")]
        public int X1 { get; set; }

        [Option("x2", HelpText = "Input files to be processed.")]
        public int X2 { get; set; }

        [Option("y1", HelpText = "Input files to be processed.")]
        public int Y1 { get; set; }

        [Option("y2", HelpText = "Input files to be processed.")]
        public int Y2 { get; set; }

        [Option("z1", HelpText = "Input files to be processed.")]
        public int Z1 { get; set; }

        [Option("z2", HelpText = "Input files to be processed.")]
        public int Z2 { get; set; }

        public Point Start => new Point {X = X1, Y = Y1, Z = Z1};


        public Point End => new Point {X = X2, Y = Y2, Z = Z2};

        [Option('r', "radius", HelpText = "Input files to be processed.")]
        public int Radius { get; set; }

        [Option( "cx", HelpText = "Input files to be processed.")]

        public int CenterX { get; set; }

        [Option( "cz", HelpText = "Input files to be processed.")]

        public int CenterZ { get; set; }

        [Option( "cY", HelpText = "Input files to be processed.")]
        public int CenterY { get; set; }

        [Option("block", HelpText = "Input files to be processed.")]
        public string Block { get; set; } = "stone";

        [Option("width", HelpText = "Input files to be processed.")]
        public int Width { get; set; }
    }
}