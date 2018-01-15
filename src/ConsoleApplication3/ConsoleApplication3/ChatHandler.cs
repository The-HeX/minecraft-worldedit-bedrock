using System;
using MinecraftPluginServer.Protocol.Response;

namespace MinecraftPluginServer
{
    public class ChatHandler : IGameEventHander
    {
        public bool CanHandle(GameEvent eventname)
        {
            return eventname == GameEvent.PlayerMessage;
        }

        public Result Handle(Response message)
        {
            Console.WriteLine($"chat: {message.body.properties.UserId} {message.body.properties.Message} ");
            return new Result();
        }
    }
}