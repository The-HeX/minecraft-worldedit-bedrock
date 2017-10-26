using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using WorldEdit.Commands;
using WorldEdit.Input;
using WorldEdit.Output;
using WorldEdit.Schematic;

namespace WorldEdit
{
    public class CommandControl
    {
        private readonly SavedPositionService SavedPositions = new SavedPositionService();

        public void HandleCommand(string[] args)
        {
            var minecraft = new MinecraftCommandService();
            var position = minecraft.GetLocation();
            var commandArgs = CommandArgs(args);
            if (args[0].StartsWith("schematic"))
            {
                HandelSchematicCommand(commandArgs);
            }
            else if (args[0].StartsWith("create"))
            {
                HandleCreateCommand(commandArgs, minecraft, position, SavedPositions.Positions);
            }
            else if (args[0].StartsWith("pos"))
            {
                HandlePositionCommand(commandArgs, position, minecraft);
            }
            //measure
        }
        private void HandleCreateCommand(string[] commandArgs, MinecraftCommandService minecraft, Position position, List<SavedPosition> storaedPositions)
        {
            var lines = new CreateCommandHandler().Handle(commandArgs, minecraft, position, storaedPositions);
            var sw = new Stopwatch();
            sw.Start();
            foreach (var line in lines)
            {
                minecraft.Command($"fill?from={line.Start.X} {line.Start.Y} {line.Start.Z}&to={line.End.X} {line.End.Y} {line.End.Z}&tileName={line.Block}&tileData=0");
            }
            sw.Stop();
            minecraft.Status($"time to queue commands {sw.Elapsed.TotalSeconds}");
            Console.WriteLine($"time to queue commands {sw.Elapsed.TotalSeconds}");
            sw.Reset();
            sw.Start();
            minecraft.Wait();
            sw.Stop();
            minecraft.Status($"time to complete import {sw.Elapsed.TotalSeconds}");
            Console.WriteLine($"time to complete import {sw.Elapsed.TotalSeconds}");

        }

        private void HandelSchematicCommand(string[] commandArgs)
        {
            SchematicProcessor.SchematicCommandProcessor(commandArgs);
        }

        private void HandlePositionCommand(string[] commandArgs, Position position, MinecraftCommandService minecraft)
        {
            var name = commandArgs.Length > 1 ? commandArgs[1] : "";
            switch (commandArgs[0])
            {
                case "add":

                    SavedPositions.Positions.Add(new SavedPosition() { Position = position, Name = name });
                    minecraft.Status($"saved postition {name} at {position}");
                    break;
                case "list":
                    if (SavedPositions.Positions.Any())
                    {
                        minecraft.Status("Positions: " +
                                         SavedPositions.Positions.Select(b => $"\n{b.Name} at {b.Position}")
                                             .Aggregate((a, b) => a += b));
                    }
                    else
                    {
                        minecraft.Status("No saved positions.");
                    }

                    break;
                case "remove":
                    var posToDelete = SavedPositions.Positions.SingleOrDefault(a => a.Name.Equals(name));
                    if (posToDelete != null)
                    {
                        SavedPositions.Positions.Remove(posToDelete);
                        minecraft.Status($"removed position {posToDelete.Name}");
                    }
                    break;
                case "save":
                    //SavedPositions.Positions
                    //JsonConvert
                    break;
                case "load":
                    break;
            }
        }

        private static string[] CommandArgs(string[] args)
        {
            return args.ToList().Skip(1).ToArray();
        }
    }
}