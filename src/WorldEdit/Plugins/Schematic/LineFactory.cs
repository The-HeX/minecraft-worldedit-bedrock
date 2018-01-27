using System;
using System.Collections.Generic;
using System.Linq;

namespace WorldEdit.Schematic
{
    public class LineFactory
    {
        public static List<Line> CreateFromPoints(List<Point> points)
        {
            var lines = points.Count <= 50000 ? WorkingMethod(points) : Parallel(points);
            return lines;
        }

        private static List<Line> Parallel(List<Point> points)
        {
            var lines = new List<Line>();
            lines.AddRange(
                points.AsParallel()
                    .Select(
                        point =>
                            new Line
                            {
                                Start = point.Clone(),
                                End = point.Clone(),
                                Block = point.BlockId,
                                BlockName = point.BlockName,
                                Data = point.Data
                            }));
            lines = lines.AsParallel().GroupBy(a => new {a.Start.X, a.Start.Z}).Select(b =>
            {
                var items = b.OrderBy(a => a.Start.Y).ToList();
                var output = new List<Line>();
                output.Add(items[0]);
                for (var i = 0; i < items.Count; i++)
                {
                    var last = output.Last();
                    if (last.CanCombine(items[i]))
                    {
                        output.Add(last.Combine(items[i]));
                        output.Remove(last);
                    }
                    else
                    {
                        output.Add(items[i]);
                    }
                }
                return output;
            }).SelectMany(a => a.ToList()).ToList();


            lines = lines.AsParallel().GroupBy(a => new {a.Start.Y, a.Start.Z}).Select(b =>
            {
                var items = b.OrderBy(a => a.Start.X).ToList();
                var output = new List<Line>();
                output.Add(items[0]);
                for (var i = 0; i < items.Count; i++)
                {
                    var last = output.Last();
                    if (last.CanCombine(items[i]))
                    {
                        output.Add(last.Combine(items[i]));
                        output.Remove(last);
                    }
                    else
                    {
                        output.Add(items[i]);
                    }
                }
                return output;
            }).SelectMany(a => a.ToList()).ToList();

            lines = lines.AsParallel().GroupBy(a => new {a.Start.Y, a.Start.X}).Select(b =>
            {
                var items = b.OrderBy(a => a.Start.Z).ToList();
                var output = new List<Line>();
                output.Add(items[0]);
                for (var i = 0; i < items.Count; i++)
                {
                    var last = output.Last();
                    if (last.CanCombine(items[i]))
                    {
                        output.Add(last.Combine(items[i]));
                        output.Remove(last);
                    }
                    else
                    {
                        output.Add(items[i]);
                    }
                }
                return output;
            }).SelectMany(a => a.ToList()).ToList();


            lines = SplitLinesIntoMaxSizes(lines);
            return lines;
        }

        private static List<Line> WorkingMethod(List<Point> points)
        {
            var lines = new List<Line>();
            lines.AddRange(
                points.AsParallel()
                    .Select(
                        point =>
                            new Line
                            {
                                Start = point.Clone(),
                                End = point.Clone(),
                                Block = point.BlockId,
                                BlockName = point.BlockName,
                                Data = point.Data
                            }));
            lines = lines.AsParallel().OrderBy(a => a.Start.X).ThenBy(a => a.Start.Z).ThenBy(a => a.Start.Y).ToList();
            lines = SquashLines(lines);
            lines = lines.AsParallel().OrderBy(a => a.Start.Y).ThenBy(a => a.Start.X).ThenBy(a => a.Start.Z).ToList();
            lines = SquashLines(lines);

            lines = lines.AsParallel().OrderBy(a => a.Start.Z).ThenBy(a => a.Start.Y).ThenBy(a => a.Start.X).ToList();
            lines = SquashLines(lines);

            lines = lines.AsParallel().OrderBy(a => a.Start.Z).ThenBy(a => a.Start.X).ThenBy(a => a.Start.Y).ToList();
            lines = SquashLines(lines);

            lines = lines.AsParallel().OrderBy(a => a.Start.Y).ThenBy(a => a.Start.Z).ThenBy(a => a.Start.X).ToList();
            lines = SquashLines(lines);

            lines = lines.AsParallel().OrderBy(a => a.Start.X).ThenBy(a => a.Start.Y).ThenBy(a => a.Start.Z).ToList();
            lines = SquashLines(lines);

            lines = SplitLinesIntoMaxSizes(lines);
            return lines;
        }

        public static List<Line> SplitLinesIntoMaxSizes(List<Line> lines)
        {
            var output = new List<Line>();

            foreach (var line in lines)
            {
                if (line.IsSmallerThen(50))
                {
                    output.Add(line);
                }
                else //need to split the line into  smaller segments.
                {
                    output.AddRange(line.SplitToAMaxSize(32));
                }
            }
            return output;
        }

        public static List<Line> SquashLines(List<Line> lines)
        {
            for (var i = 0; i < lines.Count - 1; i++)
            {
                for (var j = i + 1; j < lines.Count; j++)
                {
                    if (lines[i].CanCombine(lines[j]))
                    {
                        lines[i] = lines[i].Combine(lines[j]);
                        lines.Remove(lines[j]);
                        i--;
                        break;
                    }
                }
            }
            return lines;
        }

        private static double Distance(int centerX, int centerZ, int centerY, int x, int z, int y)
        {
            return Math.Round(Math.Sqrt(Math.Pow(centerX - x, 2) + Math.Pow(centerZ - z, 2) + Math.Pow(centerY - y, 2)),
                0);
        }
    }
}