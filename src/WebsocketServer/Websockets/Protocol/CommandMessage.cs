using MinecraftPluginServer.Protocol.Request;

namespace MinecraftPluginServer.Protocol
{
    public class CommandMessage : RequestMessage
    {
        public CommandMessage(string command)
        {
            body.commandLine = command;
        }

        public CommandMessage()
        {
        }


        public mcBodyCommand body { get; set; } = new mcBodyCommand();

    }
}