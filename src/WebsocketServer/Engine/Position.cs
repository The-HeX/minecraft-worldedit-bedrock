namespace WorldEdit.Schematic
{
    public class Position
    {
        public Position()
        {
        }

        public Position(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public override string ToString()
        {
            return $"x:{X} y:{Y} z:{Z}";
        }

        public Position Muliply(int scale)
        {
            return new Position(X*scale, Y*scale, Z*scale);
        }
    }
}