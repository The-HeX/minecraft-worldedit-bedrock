namespace MinecraftPluginServer.Protocol.Response
{
    public class Header
    {
        public string messagePurpose { get; set; }
        public string requestId { get; set; }
        public int version { get; set; }
    }
}