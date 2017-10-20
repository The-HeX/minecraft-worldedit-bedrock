using System;

namespace ShapeGenerator
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public int BlockId { get; internal set; }
        public string BlockName { get; internal set; }
        public int Data { get; internal set; }

        public  Point Clone()
        {
            return new Point { X = X, Y = Y, Z = Z, BlockId=BlockId,BlockName=BlockName,Data=Data };
        }
    }

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
    }
}