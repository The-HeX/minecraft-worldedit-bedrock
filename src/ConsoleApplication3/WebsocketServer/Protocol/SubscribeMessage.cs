using MinecraftPluginServer.Protocol.Request;

namespace MinecraftPluginServer.Protocol
{
    public class SubscribeMessage : RequestMessage
    {
        public SubscribeMessage(string eventName)
        {
            body = new mcBodysubscribe(eventName);
            header.messagePurpose = "subscribe";
        }

        public mcBodysubscribe body { get; set; }
    }
}