namespace MinecraftPluginServer.Protocol.Request
{
    public class mcBodysubscribe : mcBody
    {
        public mcBodysubscribe()
        {
        }

        public mcBodysubscribe(string eventName)
        {
            this.eventName = eventName;
        }


        public string eventName { get; set; } = "";

    }
}