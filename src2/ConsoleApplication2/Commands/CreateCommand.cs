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
            //create line [positionStart] [positionEnd] [block]
            //create line x1 y1 z1 x2 y2 z2 [block]
            //create walls [positionStart] [positionEnd] [block]
            //create box
            //create outline
            //create sphere

            var block = "air";
            IGenerator generator;
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
            }
            //else if(args[1]="outline"){
            //   if(args.MaxIndex()=4){
            //       BlockInput On
            //       w:=args[2]
            //       h:=args[3]
            //       b:=args[4]
            //       Walls(w, w, h, b,"~","~","~")
            //       Floor(w, w, b,"~","~-1","~")
            //       Floor(w, w, b,"~", "~" . h ,"~")
            //       BlockInput Off
            //       return
            //   }
            //   Display("/create outline width height blockname")
            //}
            //else if(args[1]="floor"){
            //   if(args.MaxIndex()=3){
            //       BlockInput On
            //       w:=args[2]
            //       b:=args[3]
            //       Floor(w, w, b,"~","~-1","~")
            //       BlockInput Off
            //       return
            //   }
            //   Display("/create floor width blockname")
            //}
            //   return
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