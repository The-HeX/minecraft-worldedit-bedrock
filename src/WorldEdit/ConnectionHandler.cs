using MinecraftPluginServer;
using MinecraftPluginServer.Protocol;

namespace WorldEdit
{
    class ConnectionHandler : IConnectionEventHander
    {
        private readonly MinecraftWebsocketCommandService _minecraftService;

        public ConnectionHandler(MinecraftWebsocketCommandService minecraftService)
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