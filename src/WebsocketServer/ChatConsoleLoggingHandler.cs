using System;
using System.Collections.Generic;
using MinecraftPluginServer.Protocol.Response;

namespace MinecraftPluginServer
{
    public class ChatConsoleLoggingHandler : IGameEventHander
    {
        public List<GameEvent> CanHandle()
        {
            return new List<GameEvent> {GameEvent.PlayerMessage};
        }

        public Result Handle(Response message)
        {
            Console.WriteLine($"chat: {message.body.properties.UserId} {message.body.properties.MessageType} {message.body.properties.Message} ");
            return new Result();
        }
    }
}