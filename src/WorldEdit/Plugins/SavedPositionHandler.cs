using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using WorldEdit.Input;

namespace WorldEdit
{
    public class SavedPositionHandler : ChatHandler
    {
        private readonly SavedPositionService SavedPositions = new SavedPositionService();

        public SavedPositionHandler()
        {
            ChatCommand = "pos";
        }

        public override void HandleMessage(string[] args)
        {
            HandlePositionCommand(RemoveFirstArg(args));
        }

        private static string[] RemoveFirstArg(string[] args)
        {
            return args.ToList().Skip(1).ToArray();
        }

        private void HandlePositionCommand(string[] commandArgs)
        {
            var name = commandArgs.Length > 1 ? commandArgs[1] : "";
            switch (commandArgs[0])
            {
                case "add":
                    var position = CommandService.GetLocation();
                    SavedPositions.Positions.Add(new SavedPosition {Position = position, Name = name});
                    CommandService.Status($"saved postition {name} at {position}");
                    break;
                case "list":
                    if (SavedPositions.Positions.Any())
                        CommandService.Status("Positions: " +
                                              SavedPositions.Positions.Select(b => $"\n{b.Name} at {b.Position}")
                                                  .Aggregate((a, b) => a += b));
                    else
                        CommandService.Status("No saved positions.");

                    break;
                case "remove":
                    var posToDelete = SavedPositions.Positions.SingleOrDefault(a => a.Name.Equals(name));
                    if (posToDelete != null)
                    {
                        SavedPositions.Positions.Remove(posToDelete);
                        CommandService.Status($"removed position {posToDelete.Name}");
                    }
                    break;
                case "save":
                    var json = JsonConvert.SerializeObject(SavedPositions.Positions);
                    File.WriteAllText("SavedPositions.json", json);
                    break;
                case "load":
                    if (File.Exists("savedpositions.json"))
                    {
                        var jsonstring = File.ReadAllText("savedpositions.json");
                        SavedPositions.Positions.AddRange(
                            JsonConvert.DeserializeObject<List<SavedPosition>>(jsonstring));
                    }
                    break;
            }
        }
    }
}