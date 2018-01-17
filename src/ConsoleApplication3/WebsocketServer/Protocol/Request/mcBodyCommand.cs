using System;

namespace MinecraftPluginServer.Protocol.Request
{
    public class mcBodyCommand : mcBody
    {
        public mcBodyCommand()
        {
        }
        public int version { get; set; } = 1;
        public mcBodyCommand(string commandLine)
        {
            this.commandLine = commandLine;
        }

        public Origin origin { get; set; } = new Origin() {type = "player"};
        public string commandLine { get; set; } = "";

    }

    public class Origin
    {
        public string type { get; set; }
    }
}