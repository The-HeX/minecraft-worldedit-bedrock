namespace ShapeGenerator.Generators
{
    public interface ISquareOptions
    {
        int CenterX { get; set; }
        int CenterZ { get; set; }
        int CenterY { get; set; }
        int Height { get; set; }
        int Width { get; set; }
        bool Fill { get; set; }
        int Length { get; set; }
        string Block { get; set; }
        int Thickness { get; set; }
        bool Merlon { get; set; } 
    }
}