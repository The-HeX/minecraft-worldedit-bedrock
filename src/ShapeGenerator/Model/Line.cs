using System;

namespace ShapeGenerator
{
    public class Line
    {
        public Point Start { get; set; }
        public Point End { get; set; }

        public string Block { get; set; }

        public bool CanCombine(Line line)
        {
            if (line.Block.Equals(Block))
            {
                //combine the Z
                if (line.Start.X == Start.X && line.Start.Y == Start.Y)
                {
                    if (line.End.X == End.X && line.End.Y == End.Y)
                    {
                        if (End.Z + 1 == line.Start.Z || End.Z == line.Start.Z)
                        {
                            return true;
                        }
                    }
                }
                //combine the x
                if (line.Start.Z == Start.Z && line.Start.Y == Start.Y)
                {
                    if (line.End.Z == End.Z && line.End.Y == End.Y)
                    {
                        if (End.X + 1 == line.Start.X || End.X == line.Start.X)
                        {
                            return true;
                        }
                    }
                }
                //combine the Y
                if (line.Start.Z == Start.Z && line.Start.X == Start.X)
                {
                    if (line.End.Z == End.Z && line.End.X == End.X)
                    {
                        if (End.Y + 1 == line.Start.Y || End.Y == line.Start.Y)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public  Line Combine(Line line)
        {
            if (CanCombine(line))
            {
                return new Line() {
                    Start= Start.Clone(),
                    End=line.End.Clone(),
                    Block=Block
                };
            }
            throw new InvalidOperationException("lines cannot be combined");
        }
    }
}