using Newtonsoft.Json;

namespace MinecraftPluginServer.Protocol.Response
{
    public class Response
    {
        public Body body { get; set; }
        public Header header { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}