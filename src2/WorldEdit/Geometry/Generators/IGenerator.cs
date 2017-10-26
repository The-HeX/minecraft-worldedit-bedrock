using System.Collections.Generic;

namespace ShapeGenerator.Generators
{
    public interface IGenerator
    {
        List<Line> Run(Options options);
        List<Line> TransformToLines(List<Point> points, Options options);
    }
}