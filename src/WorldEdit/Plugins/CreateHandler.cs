using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using WorldEdit.Commands;
using WorldEdit.Input;
using WorldEdit.Output;

namespace WorldEdit
{
    public class CreateHandler : ChatHandler
    {
        public CreateHandler()
        {
            ChatCommand = "create";
        }

        public override void HandleMessage(string[] args)
        {
            CreateGeometry(CommandService,args);
        }

        public static void CreateGeometry(IMinecraftCommandService commandService, params string[] args)
        {
            var position = commandService.GetLocation();
            var lines = new CreateCommandHandler(commandService).Handle(args.ToList().Skip(1).ToArray(), position,
                new List<SavedPosition>());
            if (lines.Any())
            {
                var _commandFormater = commandService.GetFormater();
                var sw = new Stopwatch();
                sw.Start();
                var lastLine = lines.First();
                foreach (var line in lines)
                {
                    if (lastLine.Start.Distance2D(line.Start) > 100)
                    {                        
                        commandService.Command($"tp @s {line.Start.X} ~ {line.Start.Z}");
                    }
                    var command = _commandFormater.Fill(line.Start.X, line.Start.Y, line.Start.Z, line.End.X,line.End.Y,line.End.Z, line.Block, line.Block.Contains(" ")?"":"0");
                    commandService.Command(command);
                    lastLine = line;
                }
                sw.Stop();
                commandService.Status($"time to queue commands {sw.Elapsed.TotalSeconds}");
                //Console.WriteLine($"time to queue commands {sw.Elapsed.TotalSeconds}");
                sw.Reset();
                sw.Start();
                commandService.Wait();
                sw.Stop();
                commandService.Status($"time to complete import {sw.Elapsed.TotalSeconds}");
                //Console.WriteLine($"time to complete import {sw.Elapsed.TotalSeconds}");
            }
        }
    }
}