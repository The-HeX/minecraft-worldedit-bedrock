using System.Collections.Generic;
using MinecraftPluginServer.Protocol.Response;

namespace MinecraftPluginServer
{
    public interface IGameEventHander
    {
        List<GameEvent> CanHandle();
        Result Handle(Response message);    
    }
}