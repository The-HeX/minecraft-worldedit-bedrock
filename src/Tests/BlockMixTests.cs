using ShapeGenerator.Generators;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeGenerator;
using Xunit;

namespace Tests
{
    public class BlockMixTests
    {
        [Fact]
        public void test_block_mix()
        {
            var random= new Random();


            var blocks = new List<Tuple<string, int>>();
            blocks.Add(new Tuple<string, int>("stonebrick 0", 78));
            blocks.Add(new Tuple<string, int>("stone", 5));
            blocks.Add(new Tuple<string, int>("stonebrick 2", 15));
            blocks.Add(new Tuple<string, int>("stonebrick 1", 2));

            var total = blocks.Sum(a => a.Item2);
            var normalized = blocks.Select(a => new { Item = a.Item1, Percentage = a.Item2 / total, Frequency = a.Item2 }).OrderByDescending(a => a.Frequency).ToList();

            for (int i = 0; i < 1000; i++)
            {
                
                var number = random.Next(0, total);
                foreach (var item in normalized)
                {
                    number -= item.Frequency;
                    if (number <= 0)
                    {
                        Console.WriteLine($"{i} {number} {item.Item}");
                        break;
                    }
                }
                Trace.WriteLine("nothing");
            }
        }

        [Fact]
        public void merlon_test()
        {

            var gen = new MerlonGenerator();
            var results=gen.Run(new Options()
            {
                Block = "wool",
                CenterX = 0,
                CenterY = 4,
                CenterZ = 0,
                Fill = false,
                Height = 1,
                Merlon = true,
                Width = 40,
                Length = 1
            });

            foreach (var a in results)
            {
                Trace.WriteLine($"{a.X} {a.Y} {a.Z}");
            }


        }
    }
}
