using MinecraftPluginServer.Protocol.Response;
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
            var position = minecraftService.GetLocation();
            for (var i = 0; i <= RadiusHandler.Radius; i++)
            {
                CreateHandler.CreateGeometry(minecraftService,"create","circle",$"{i}","1","air",$"{position.X}",$"{position.Y+i}",$"{position.Z}");
                //minecraftService.Command($"fill ~-{i} ~{i} ~-{i} ~{i} ~{i} ~{i} air");
            }
        }
    }
}