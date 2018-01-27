namespace ShapeGenerator
{
    public interface ISphereOptions
    {
        int Radius { get; set; }
        int CenterX { get; set; }
        int CenterZ { get; set; }
        int CenterY { get; set; }
        string Block { get; set; }
    }
}