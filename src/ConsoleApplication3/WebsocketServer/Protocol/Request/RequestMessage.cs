using System;
using Newtonsoft.Json;

namespace MinecraftPluginServer.Protocol.Request
{
    public class RequestMessage
    {
        public mcHeader header { get; set; } = new mcHeader();
        public override string ToString()
        {
            var serializeObject = JsonConvert.SerializeObject(this);
            Console.WriteLine(serializeObject);
            return serializeObject;
        }
    }
}