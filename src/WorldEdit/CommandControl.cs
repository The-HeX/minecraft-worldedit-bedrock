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
        private readonly IMinecraftCommandService _minecraftCommandService;

        public CommandControl(IMinecraftCommandService minecraftCommandService,ICommandFormater commandFormater)
        {
            _minecraftCommandService = minecraftCommandService;
            _commandFormater = commandFormater;
        }

        private readonly SavedPositionService SavedPositions = new SavedPositionService();
        private readonly ICommandFormater _commandFormater;

        public void HandleCommand(string[] args)
        {
            
            var position = _minecraftCommandService.GetLocation();
            var commandArgs = CommandArgs(args);
            if (args[0].StartsWith("schematic"))
            {
                HandelSchematicCommand(commandArgs);
            }
            else if (args[0].StartsWith("create"))
            {
                HandleCreateCommand(commandArgs, _minecraftCommandService, position, SavedPositions.Positions);
            }
            else if (args[0].StartsWith("pos"))
            {
                HandlePositionCommand(commandArgs, position, _minecraftCommandService);
            }
            //measure
        }
        private void HandleCreateCommand(string[] commandArgs, IMinecraftCommandService minecraft, Position position, List<SavedPosition> storaedPositions)
        {
            var lines = new CreateCommandHandler().Handle(commandArgs, minecraft, position, storaedPositions);
            var sw = new Stopwatch();
            sw.Start();
            foreach (var line in lines)
            {
                var command = _commandFormater.Fill(line.Start.X,line.Start.Y,line.Start.Z,line.End.X,line.End.Y,line.End.Z,line.Block,"0");
                minecraft.Command(command);
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
            new SchematicProcessor(_minecraftCommandService).SchematicCommandProcessor(commandArgs);
        }

        private void HandlePositionCommand(string[] commandArgs, Position position, IMinecraftCommandService minecraft)
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

    public interface ICommandFormater
    {
        string Fill(int startX, int startY, int startz, int endX, int endY, int endZ, string block="stone", string data = "0");
        string Title(string title,string subtitle);
    }

    public class CodeConnectCommandFormater:ICommandFormater
    {
        public string Fill(int startX,int startY,int startZ,int endX,int endY,int endZ,string block,string data)
        {
            return
                $"fill?from={startX} {startY} {startZ}&to={endX} {endY} {endZ}&tileName={block}&tileData={data}";
        }

        public string Title( string title,string subtitle)
        {
            var command = "executeasother?origin=@p&position=~%20~%20~&command=title%20@s%20";
            if (!string.IsNullOrEmpty(title))
            {
                command = command + "title " + title;
            }
            if (!string.IsNullOrEmpty(subtitle))
            {
                command = command + "subtitle " + subtitle;
            }
            return command;
        }
    }
}