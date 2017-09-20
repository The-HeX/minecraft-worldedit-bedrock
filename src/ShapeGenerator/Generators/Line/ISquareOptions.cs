namespace ShapeGenerator.Generators
{
    internal interface ISquareOptions
    {
        int CenterX { get; set; }


        int CenterZ { get; set; }

        int CenterY { get; set; }

        int Height { get; set; }
        int Width { get; set; }
        bool Fill { get; set; }

    }
}