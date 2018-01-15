namespace MinecraftPluginServer.Protocol.Response
{
    public class Body
    {
        public string eventName { get; set; }
        public object measurements { get; set; }
        public global::MinecraftPluginServer.Protocol.Response.Properties properties { get; set; }
    }
}