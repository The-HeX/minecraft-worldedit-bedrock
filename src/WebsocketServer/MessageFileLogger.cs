using System;
using System.IO;
using MinecraftPluginServer.Protocol.Response;
using Newtonsoft.Json;

namespace MinecraftPluginServer
{
    public class MessageFileLogger : IGameEventHander,IGameRawEventHander {
        public bool CanHandle(GameEvent eventname)
        {
            return true;

        }

        public Result Handle(string rawMessage)
        {
            var message = JsonConvert.DeserializeObject<Response>(rawMessage);
            var filename = message.header.messagePurpose + message.body.eventName + "-" + Guid.NewGuid() + ".txt";
            WriteToFile(rawMessage, filename);
            return new Result();

        }

        public Result Handle(Response message)
        {
            
            
            var filename = message.header.messagePurpose + message.body.eventName+"-" +Guid.NewGuid() + ".txt";
            WriteToFile(message.ToString(), filename);
            return new Result();
        }

        private static void WriteToFile(string message, string filename)
        {
            using (var file = File.CreateText(filename))
            {
                file.Write(message);
                file.Flush();
            }
        }
    }
}