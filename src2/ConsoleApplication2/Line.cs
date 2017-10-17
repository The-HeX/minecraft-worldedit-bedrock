using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Lifetime;

namespace ShapeGenerator
{
    public class Line
    {
        public Point Start { get; set; }
        public Point End { get; set; }

        public int Block { get; set; }
        public int Data { get; internal set; }
        public string BlockName { get; internal set; }

        public int Size()
        {
            return Math.Abs((End.X - Start.X) * (End.Y - Start.Y) * (End.Z = Start.Z));
        }
        public bool CanCombine(Line line)
        {
            if (line.Block.Equals(Block)&&line.Data.Equals(Data))
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
                    Block=Block,
                    BlockName=BlockName,
                    Data=Data
                };
            }
            throw new InvalidOperationException("lines cannot be combined");
        }

        public string Command(int toX, int toY, int toZ)
        {
            return $"fill {Start.X+toX} {Start.Y+toY} {Start.Z+toZ} {End.X+toX} {End.Y+toY} {End.Z+toZ} {BlockName} {Data}";
        }

        public bool IsSmallerThen(int size)
        {
            return End.X - Start.X <= size && End.Y - Start.Y <= size && End.Z - Start.Z <= size;
        }

        public IEnumerable<Line> SplitToAMaxSize(int size)
        {
            var output = new List<Line>();
            var splitXAxis = SplitXAxis(size);
            foreach (var line in splitXAxis)
            {
                output.AddRange(line.SplitZAxis(size));
            }
            return output;
        }

        private IEnumerable<Line> SplitXAxis(int size)
        {
            var output = new List<Line>();
            var nextPoint = Start.Clone();
            while ((End.X - nextPoint.X) > size)
            {
                var endPoint = new Point() {Y = End.Y, Z = End.Z, X = nextPoint.X + size};
                output.Add(new Line() {Block = Block, Start = nextPoint.Clone(), End = endPoint, Data=Data,BlockName=BlockName});
                nextPoint = endPoint.Clone();
                nextPoint.Y = Start.Y;
                nextPoint.Z = Start.Z;
                nextPoint.X++;
            }
            output.Add(new Line() {Start = nextPoint, End = End.Clone(), Block = Block});
            return output;
        }
        private IEnumerable<Line> SplitZAxis(int size)
        {
            var output = new List<Line>();
            var nextPoint = Start.Clone();
            while ((End.Z - nextPoint.Z) > size)
            {
                var endPoint = new Point() { Y = End.Y, X = End.X, Z = nextPoint.Z + size };
                output.Add(new Line() { Block = Block, Start = nextPoint.Clone(), End = endPoint, Data = Data, BlockName = BlockName });
                nextPoint = endPoint.Clone();
                nextPoint.Y = Start.Y;
                nextPoint.X = Start.X;
                nextPoint.Z++;
            }
            output.Add(new Line() { Start = nextPoint, End = End.Clone(), Block = Block, Data = Data, BlockName = BlockName });
            return output;
        }
    }
}