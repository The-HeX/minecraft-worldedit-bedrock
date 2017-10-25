using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using AutoHotkey.Interop;
using WorldEdit.Commands;
using WorldEdit.Output;
using WorldEdit.Schematic;
using Position = WorldEdit.Schematic.Position;

namespace WorldEdit.Input
{
    public static class AutoHotKey
    {
        private static readonly AHKDelegate ahkDelegate = AHKCallback;

        private static readonly SavedPositionService SavedPositions = new SavedPositionService();

        private static void AHKCallback(string s)
        {
            var minecraft = new MinecraftCommandService();
            var position = minecraft.GetLocation();
            Console.WriteLine(s);
            var args = s.Split(' ');
            var commandArgs = CommandArgs(args);
            if (s.StartsWith("schematic"))
            {                
                HandelSchematicCommand(commandArgs);
            }
            else if(s.StartsWith("create"))
            {
                HandleCreateCommand(commandArgs,minecraft, position,SavedPositions.Positions);
            }
            else if (s.StartsWith("pos"))
            {
                HandlePositionCommand(commandArgs, position, minecraft);
            }
            //measure
        }

        private static void HandleCreateCommand(string[] commandArgs, MinecraftCommandService minecraft, Position position,List<SavedPosition> storaedPositions )
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

        private static void HandelSchematicCommand(string[] commandArgs)
        {
            SchematicProcessor.SchematicCommandProcessor(commandArgs);
        }

        private static void HandlePositionCommand(string[] commandArgs, Position position, MinecraftCommandService minecraft)
        {
            var name = commandArgs.Length > 1 ? commandArgs[1] : "";
            switch (commandArgs[0])
            {
                case "add":

                    SavedPositions.Positions.Add(new SavedPosition() {Position = position, Name = name});
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
            }
        }

        private static string[] CommandArgs(string[] args)
        {
            return args.ToList().Skip(1).ToArray();
        }

        public static AutoHotkeyEngine Run()//toto make disposable wrapper to deal with saving state, saved positions..ect.
        {
            var ptr = Marshal.GetFunctionPointerForDelegate(ahkDelegate);
            var ahk = new AutoHotkeyEngine();
            ahk.Load("input.ahk");            
            ahk.SetVar("ptr",ptr.ToString());
            return ahk;
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void AHKDelegate([MarshalAs(UnmanagedType.LPWStr)] string s);
    }

    public class SavedPosition
    {
       public Position Position { get; set; }
       public string Name { get; set; }
    }

    public class SavedPositionService
    {
        public List<SavedPosition> Positions { get; private set; }=new List<SavedPosition>();

    }

}