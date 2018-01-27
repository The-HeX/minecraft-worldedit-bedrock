using WorldEdit.Output;

namespace WorldEdit
{
    internal class LandSculptHandler : IHotkeyHandler
    {
        public bool CanHandle(string[] args)
        {
            return args.Length > 0 && args[0].Equals("^l");
        }

        public void Handle(string[] args, IMinecraftCommandService minecraftService)
        {
            for (int i = 0; i <= RadiusHandler.Radius; i++)
            {
                minecraftService.Command($"fill ~-{i} ~{i} ~-{i} ~{i} ~{i} ~{i} air");
            }
        }
    }
}