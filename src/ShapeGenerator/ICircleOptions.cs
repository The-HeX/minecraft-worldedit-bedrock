namespace ShapeGenerator
{
    public interface ICircleOptions
    {
        Shape Shape { get; set; }

        int Radius { get; set; }

        
        int CenterX { get; set; }

        
        int CenterZ { get; set; }
        //        public int CenterY { get; set; }
        int Y { get; set; }
        int Height { get; set; }
        
        bool Fill { get; set; }

    }
}