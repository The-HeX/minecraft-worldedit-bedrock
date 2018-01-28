using WorldEdit.Output;

namespace WorldEdit
{
    internal class GetDataHandler : IHotkeyHandler
    {
        public bool CanHandle(string[] args)
        {
            return args.Length > 0 && args[0].Equals("^m");
        }

        public void Handle(string[] args, IMinecraftCommandService minecraftService)
        {
            minecraftService.Command("getchunks overworld");
            minecraftService.Command("getchunkdata overworld ~ ~ ~");
        }
    }
}