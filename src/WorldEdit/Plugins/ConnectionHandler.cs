using MinecraftPluginServer;
using MinecraftPluginServer.Protocol;
using WorldEdit.Output;

namespace WorldEdit
{
    class ConnectionHandler : IConnectionEventHander
    {
        private readonly IMinecraftCommandService _minecraftService;

        public ConnectionHandler(IMinecraftCommandService minecraftService)
        {
            _minecraftService = minecraftService;
        }

        public void OnConnection()
        {
            _minecraftService.Command(_minecraftService.GetFormater().Title("WorldEdit Started", ""));
            _minecraftService.Subscribe((new SubscribeMessage("PlayerMessage")).ToString());
        }
    }
}