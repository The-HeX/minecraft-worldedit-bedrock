using System.Linq;
using WorldEdit.Schematic;

namespace WorldEdit
{
    public class SchematicHandler : ChatHandler
    {
        public SchematicHandler()
        {
            ChatCommand = "schematic";
        }

        public override void HandleMessage(string[] args)
        {
            new SchematicProcessor(CommandService).SchematicCommandProcessor(args.ToList().Skip(1).ToArray());
        }
    }
}