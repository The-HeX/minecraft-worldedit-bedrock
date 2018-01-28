using System.Windows.Forms;

namespace MinecraftPluginServer.Protocol.Response
{
    public class Body
    {
        public string eventName { get; set; }
        public object measurements { get; set; }
        public global::MinecraftPluginServer.Protocol.Response.Properties properties { get; set; }
        public position position { get; set; } 
    }

    public class position
    {
        public int x { get; set; }
        public int y { get; set; }
        public int z { get; set; }
    }

}