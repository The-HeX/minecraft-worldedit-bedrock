using System;

namespace MinecraftPluginServer.Protocol.Request
{
    public class mcHeader
    {
        public string requestId { get; set; } = Guid.NewGuid().ToString();
        public string messagePurpose { get; set; } = "commandRequest";
        public int version { get; set; } = 1;
        public string messageType { get; set; } = "commandRequest";
    }
}