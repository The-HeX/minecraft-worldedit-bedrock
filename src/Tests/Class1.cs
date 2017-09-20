using ShapeGenerator;
using ShapeGenerator.Generators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    
    public class LineTests
    {

        [Fact]
        public void Can_squash_lines()
        {
            var line1 = new Line() { Start = new Point { X = 0, Y = 0, Z = 0 }, End = new Point { X = 10, Y = 11, Z = 0 } };
            var line2 = new Line() { Start = new Point { X = 0, Y = 0, Z = 1 }, End = new Point { X = 10, Y = 11, Z = 1 } };
            var lines = new List<Line>(){ line1,line2};
            var results = SphereGenerator.SquashLines(lines);

            Assert.True(results.Count == 1);

        }


        [Fact]
        public void Can_combine_z_axis_lines()
        {
            var line1 = new Line() {Start=new Point {X=0,Y=0,Z=0 },End=new Point {X=10,Y=11,Z=0 } };
            var line2 = new Line() { Start = new Point { X = 0, Y = 0, Z = 1 }, End = new Point { X = 10, Y = 11, Z = 1 } };

            Assert.True(line1.CanCombine(line2));

        }

        [Fact]
        public void combine_z_axis_lines()
        {
            var line1 = new Line() { Start = new Point { X = 0, Y = 0, Z = 0 }, End = new Point { X = 10, Y = 11, Z = 0 } };
            var line2 = new Line() { Start = new Point { X = 0, Y = 0, Z = 1 }, End = new Point { X = 10, Y = 11, Z = 1 } };

            var result = line1.Combine(line2);

            Assert.True(result.Start.Z == line1.Start.Z);
            Assert.True(result.End.Z == line2.End.Z);

        }

        [Fact]
        public void Cannot_combine_z_axis_lines()
        {
            var line1 = new Line() { Start = new Point { X = 0, Y = 0, Z = 0 }, End = new Point { X = 10, Y = 11, Z = 0 } };
            var line2 = new Line() { Start = new Point { X = 0, Y = 0, Z = 2 }, End = new Point { X = 10, Y = 11, Z = 2 } };

            Assert.False(line1.CanCombine(line2));

        }
    }
}
