using System;

namespace ShapeGenerator.Generators
{
    public class GeneratorFactory
    {
        public IGenerator Create(Shape shape)
        {
            switch (shape)
            {
                case Shape.Circle:
                    return new CircleGenerator();
                case Shape.Line:
                    return new LineGenerator();
                case Shape.Sphere:
                    return new SphereGenerator();
            }
            throw new NotImplementedException($"Cannot process a {shape.ToString()} yet" );
        }
    }
}