using MinecraftPluginServer.Protocol.Response;

namespace MinecraftPluginServer
{
    public interface IGameEventHander
    {
        bool CanHandle(GameEvent eventname);
        Result Handle(Response message);    
    }
}