using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using ShapeGenerator;
using ShapeGenerator.Generators;
using WorldEdit.Input;
using WorldEdit.Output;
using WorldEdit.Schematic;
using Line = ShapeGenerator.Line;

namespace WorldEdit.Commands
{
    public class CreateCommandHandler
    {
        public List<Line> Handle(string[] commandArgs, MinecraftCommandService minecraft, Position position,
            List<SavedPosition> savedPositions)
        {
            var command = commandArgs[0];
            var lines = new List<Line>();
            switch (command.ToLower())
            {
                case "circle":
                    lines = CreateCircle(commandArgs, position, savedPositions, lines);
                    break;
                case "ring":
                    lines = CreateRing(commandArgs, position, savedPositions, lines);
                    break;
                case "walls":
                    lines = CreateWalls(commandArgs, position, savedPositions, lines);
                    break;
                case "outline":
                    lines = CreateOutline(commandArgs, position, savedPositions, lines);
                    break;
                case "box":
                    lines = CreateBox(commandArgs, position, savedPositions, lines);
                    break;
                case "floor":
                    lines = CreateFloor(commandArgs, position, savedPositions, lines);
                    break;
                case "sphere":
                    lines = CreateSphere(commandArgs, position, savedPositions, lines);
                    break;
            }
            return lines;
        }

        private static List<Line> CreateFloor(string[] commandArgs, Position position, List<SavedPosition> savedPositions, List<Line> lines)
            {
                IGenerator generator;
                ISquareOptions walls = new Options();
                walls.Fill = true;
                switch (commandArgs.Length)
                {
                    // width height block [postition]
                    case 4:
                        walls.Width = commandArgs[1].ToInt();
                        walls.Length = commandArgs[2].ToInt();
                        walls.Height = 1;
                        walls.Block = commandArgs[3];
                        walls.CenterX = position.X;
                        walls.CenterY = position.Y;
                        walls.CenterZ = position.Z;
                        break;
                    case 5:

                        walls.Width = commandArgs[1].ToInt();
                        walls.Length = commandArgs[2].ToInt();
                        walls.Height = 1;
                        walls.Block = commandArgs[3];
                        var center = savedPositions.Single(a => a.Name.Equals(commandArgs[4])).Position;
                        walls.CenterX = center.X;
                        walls.CenterY = center.Y;
                        walls.CenterZ = center.Z;
                        break;
                    case 7:

                        walls.Width = commandArgs[1].ToInt();
                        walls.Length = commandArgs[2].ToInt();
                        walls.Height = 1;
                        walls.Block = commandArgs[3];
                        walls.CenterX = commandArgs[4].ToInt();
                        walls.CenterY = commandArgs[5].ToInt();
                        walls.CenterZ = commandArgs[6].ToInt();
                        break;
                }
                generator = new BoxGenerator();
                lines = generator.Run((Options)walls);
                return lines;
            }
        
    private static List<Line> CreateBox(string[] commandArgs, Position position, List<SavedPosition> savedPositions, List<Line> lines)
        {
            IGenerator generator;
            ISquareOptions walls = new Options();
            walls.Fill = true;
            switch (commandArgs.Length)
            {
                // width height block [postition]
                case 5:
                    walls.Width = commandArgs[1].ToInt();
                    walls.Length = commandArgs[2].ToInt();
                    walls.Height = commandArgs[3].ToInt();
                    walls.Block = commandArgs[4];
                    walls.CenterX = position.X;
                    walls.CenterY = position.Y;
                    walls.CenterZ = position.Z;
                    break;
                case 6:

                    walls.Width = commandArgs[1].ToInt();
                    walls.Length = commandArgs[2].ToInt();
                    walls.Height = commandArgs[3].ToInt();
                    walls.Block = commandArgs[4];
                    var center = savedPositions.Single(a => a.Name.Equals(commandArgs[5])).Position;
                    walls.CenterX = center.X;
                    walls.CenterY = center.Y;
                    walls.CenterZ = center.Z;
                    break;
                case 8:

                    walls.Width = commandArgs[1].ToInt();
                    walls.Length = commandArgs[2].ToInt();
                    walls.Height = commandArgs[3].ToInt();
                    walls.Block = commandArgs[4];
                    walls.CenterX = commandArgs[5].ToInt();
                    walls.CenterY = commandArgs[6].ToInt();
                    walls.CenterZ = commandArgs[7].ToInt();
                    break;
            }
            generator = new BoxGenerator();
            lines = generator.Run((Options) walls);
            return lines;
        }

        private static List<Line> CreateOutline(string[] commandArgs, Position position, List<SavedPosition> savedPositions, List<Line> lines)
        {
            IGenerator generator;
            ISquareOptions walls = new Options();
            walls.Fill = false;
            switch (commandArgs.Length)
            {
                // width height block [postition]
                case 5:
                    walls.Width = commandArgs[1].ToInt();
                    walls.Length = commandArgs[2].ToInt();
                    walls.Height = commandArgs[3].ToInt();
                    walls.Block = commandArgs[4];
                    walls.CenterX = position.X;
                    walls.CenterY = position.Y;
                    walls.CenterZ = position.Z;
                    break;
                case 6:

                    walls.Width = commandArgs[1].ToInt();
                    walls.Length = commandArgs[2].ToInt();
                    walls.Height = commandArgs[3].ToInt();
                    walls.Block = commandArgs[4];
                    var center = savedPositions.Single(a => a.Name.Equals(commandArgs[5])).Position;
                    walls.CenterX = center.X;
                    walls.CenterY = center.Y;
                    walls.CenterZ = center.Z;
                    break;
                case 8:

                    walls.Width = commandArgs[1].ToInt();
                    walls.Length = commandArgs[2].ToInt();
                    walls.Height = commandArgs[3].ToInt();
                    walls.Block = commandArgs[4];
                    walls.CenterX = commandArgs[5].ToInt();
                    walls.CenterY = commandArgs[6].ToInt();
                    walls.CenterZ = commandArgs[7].ToInt();
                    break;
            }
            generator = new BoxGenerator();
            lines = generator.Run((Options) walls);
            return lines;
        }

        private static List<Line> CreateWalls(string[] commandArgs, Position position, List<SavedPosition> savedPositions, List<Line> lines)
        {
            IGenerator generator;
            ISquareOptions walls = new Options();
            walls.Fill = false;
            switch (commandArgs.Length)
            {
                // width height block [postition]
                case 5:
                    walls.Width = commandArgs[1].ToInt();
                    walls.Length = commandArgs[2].ToInt();
                    walls.Height = commandArgs[3].ToInt();
                    walls.Block = commandArgs[4];
                    walls.CenterX = position.X;
                    walls.CenterY = position.Y;
                    walls.CenterZ = position.Z;
                    break;
                case 6:

                    walls.Width = commandArgs[1].ToInt();
                    walls.Length = commandArgs[2].ToInt();
                    walls.Height = commandArgs[3].ToInt();
                    walls.Block = commandArgs[4];
                    var center = savedPositions.Single(a => a.Name.Equals(commandArgs[5])).Position;
                    walls.CenterX = center.X;
                    walls.CenterY = center.Y;
                    walls.CenterZ = center.Z;
                    break;
                case 8:

                    walls.Width = commandArgs[1].ToInt();
                    walls.Length = commandArgs[2].ToInt();
                    walls.Height = commandArgs[3].ToInt();
                    walls.Block = commandArgs[4];
                    walls.CenterX = commandArgs[5].ToInt();
                    walls.CenterY = commandArgs[6].ToInt();
                    walls.CenterZ = commandArgs[7].ToInt();
                    break;
            }
            generator = new SquareGenerator();
            lines = generator.Run((Options) walls);
            return lines;
        }

        private static List<Line> CreateCircle(string[] commandArgs, Position position, List<SavedPosition> savedPositions, List<Line> lines)
        {
            IGenerator generator;
            ICircleOptions circle = new Options();
            circle.Fill = true;
            switch (commandArgs.Length)
            {
                // radius height block [position]
                case 4:
                    circle.Radius = commandArgs[1].ToInt();
                    circle.Height = commandArgs[2].ToInt();
                    circle.Block = commandArgs[3];

                    circle.CenterX = position.X;
                    circle.CenterY = position.Y;
                    circle.CenterZ = position.Z;
                    break;

                // radius height block position
                case 5:
                    circle.Radius = commandArgs[1].ToInt();
                    circle.Height = commandArgs[2].ToInt();
                    circle.Block = commandArgs[3];
                    var center = savedPositions.Single(a => a.Name.Equals(commandArgs[4])).Position;
                    circle.CenterX = center.X;
                    circle.CenterY = center.Y;
                    circle.CenterZ = center.Z;
                    break;
                // radius height block x y z
                case 7:
                    circle.Radius = commandArgs[1].ToInt();
                    circle.Height = commandArgs[2].ToInt();
                    circle.Block = commandArgs[3];
                    circle.CenterX = commandArgs[4].ToInt();
                    circle.CenterY = commandArgs[5].ToInt();
                    circle.CenterZ = commandArgs[6].ToInt();
                    break;
            }
            generator = new CircleGenerator();
            lines = generator.Run((Options) circle);
            return lines;
        }

        private static List<Line> CreateSphere(string[] commandArgs, Position position, List<SavedPosition> savedPositions, List<Line> lines)
        {
            IGenerator generator;
            ISphereOptions sphere = new Options();
            
            switch (commandArgs.Length)
            {
                // radius height block [position]
                case 3:
                    sphere.Radius = commandArgs[1].ToInt();
                    //sphere.Height = commandArgs[2].ToInt();
                    sphere.Block = commandArgs[2];

                    sphere.CenterX = position.X;
                    sphere.CenterY = position.Y;
                    sphere.CenterZ = position.Z;
                    break;

                // radius height block position
                case 4:
                    sphere.Radius = commandArgs[1].ToInt();
                    //sphere.Height = commandArgs[2].ToInt();
                    sphere.Block = commandArgs[2];
                    var center = savedPositions.Single(a => a.Name.Equals(commandArgs[3])).Position;
                    sphere.CenterX = center.X;
                    sphere.CenterY = center.Y;
                    sphere.CenterZ = center.Z;
                    break;
                // radius height block x y z
                case 6:
                    sphere.Radius = commandArgs[1].ToInt();
                    //sphere.Height = commandArgs[2].ToInt();
                    sphere.Block = commandArgs[2];
                    sphere.CenterX = commandArgs[3].ToInt();
                    sphere.CenterY = commandArgs[4].ToInt();
                    sphere.CenterZ = commandArgs[5].ToInt();
                    break;
            }
            generator = new SphereGenerator();
            lines = generator.Run((Options)sphere);
            return lines;
        }


        private static List<Line> CreateRing(string[] commandArgs, Position position, List<SavedPosition> savedPositions, List<Line> lines)
        {
            IGenerator generator;
            ICircleOptions ring = new Options();
            ring.Fill = false;
            switch (commandArgs.Length)
            {
                // radius height block [position]
                case 4:
                    ring.Block = commandArgs[3];
                    ring.Radius = commandArgs[1].ToInt();
                    ring.Height = commandArgs[2].ToInt();
                    ring.CenterX = position.X;
                    ring.CenterY = position.Y;
                    ring.CenterZ = position.Z;
                    break;

                // radius height block position
                case 5:
                    ring.Block = commandArgs[3];
                    var center = savedPositions.Single(a => a.Name.Equals(commandArgs[4])).Position;
                    ring.Radius = commandArgs[1].ToInt();
                    ring.Height = commandArgs[2].ToInt();
                    ring.CenterX = center.X;

                    ring.CenterY = center.Y;
                    ring.CenterZ = center.Z;
                    break;
                // radius height block x y z
                case 7:
                    ring.Block = commandArgs[3];
                    ring.Radius = commandArgs[1].ToInt();
                    ring.Height = commandArgs[2].ToInt();
                    ring.CenterX = commandArgs[4].ToInt();
                    ring.CenterY = commandArgs[5].ToInt();
                    ring.CenterZ = commandArgs[6].ToInt();
                    break;
            }
            generator = new CircleGenerator();
            lines = generator.Run((Options) ring);
            return lines;
        }
    }


    public static class StringExtensions
    {
        public static int ToInt(this string input)
        {
            return int.Parse(input);
        }
    }
}