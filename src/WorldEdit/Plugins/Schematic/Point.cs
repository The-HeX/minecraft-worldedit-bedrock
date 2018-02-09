using System;
using System.Linq;
using ShapeGenerator.Generators;

namespace WorldEdit.Schematic
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public int BlockId { get; internal set; }
        public string BlockName { get; internal set; }
        public int Data { get; internal set; }
        public int SortOrder { get; set; }

        public Point Clone()
        {
            return new Point
            {
                X = X,
                Y = Y,
                Z = Z,
                BlockId = BlockId,
                BlockName = BlockName,
                Data = Data,
                SortOrder = SortOrder
            };
        }

        internal Point Shift(Position position)
        {
            X = X + position.X;
            Y = Y + position.Y;
            Z = Z + position.Z;
            return this;
        }

        public Point Rotate(Rotate rotation)
        {
            var rotatedPoint = Clone();
            var radians = ConvertToRadians((double) rotation);
            rotatedPoint.Z = (int) Math.Round(Z*Math.Cos(radians) - X*Math.Sin(radians), 0);
            rotatedPoint.X = (int) Math.Round(Z*Math.Sin(radians) + X*Math.Cos(radians), 0);

            var block = BlockNameLoopup.Lookup().Where(a => a.Name == BlockName).FirstOrDefault();
            if (block != null && block.HasDirection)
            {
                var rotationOrder = (new[] {2, 0, 3, 1}).ToList(); //(new[] { 0, 2, 1, 3 }).ToList();
                var current = rotatedPoint.Data & 3;
                var extra = rotatedPoint.Data & 252;
                var currentIndex = rotationOrder.FindIndex(a => a == current);
                var rotationsteps = ((int) rotation)/90;
                var newrotation = (currentIndex + rotationsteps)%4;
                var newData = rotationOrder[newrotation];
                rotatedPoint.Data = newData | extra;
            }

            return rotatedPoint;
        }

        public double ConvertToRadians(double angle)
        {
            return (Math.PI/180)*angle;
        }

    }
}