using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using WorldEdit.Commands;
using WorldEdit.Input;

namespace WorldEdit
{
    public class CreateHandler : ChatHandler
    {
        public CreateHandler()
        {
            ChatCommand = "create";
        }

        protected override void HandleMessage(string[] args)
        {
            var position = CommandService.GetLocation();
            var lines = new CreateCommandHandler(CommandService).Handle(args.ToList().Skip(1).ToArray(), position,
                new List<SavedPosition>());
            if (lines.Any())
            {
                var _commandFormater = CommandService.GetFormater();
                var sw = new Stopwatch();
                sw.Start();
                foreach (var line in lines)
                {
                    var command = _commandFormater.Fill(line.Start.X, line.Start.Y, line.Start.Z, line.End.X,
                        line.End.Y,
                        line.End.Z, line.Block, "0");
                    CommandService.Command(command);
                }
                sw.Stop();
                CommandService.Status($"time to queue commands {sw.Elapsed.TotalSeconds}");
                //Console.WriteLine($"time to queue commands {sw.Elapsed.TotalSeconds}");
                sw.Reset();
                sw.Start();
                CommandService.Wait();
                sw.Stop();
                CommandService.Status($"time to complete import {sw.Elapsed.TotalSeconds}");
                //Console.WriteLine($"time to complete import {sw.Elapsed.TotalSeconds}");
            }
        }
    }
}