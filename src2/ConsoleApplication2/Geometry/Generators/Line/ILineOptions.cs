namespace ShapeGenerator
{
    public interface ILineOptions
    {
        int X1 { get; set; }
        int X2 { get; set; }
        int Y1 { get; set; }
        int Y2 { get; set; }
        int Z1 { get; set; }
        int Z2 { get; set; }

        Point Start { get; }
        Point End { get; }
    }
}