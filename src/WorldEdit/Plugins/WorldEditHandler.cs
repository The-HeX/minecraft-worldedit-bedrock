using MinecraftPluginServer;
using MinecraftPluginServer.Protocol.Response;

namespace WorldEdit
{
    public class WorldEditHandler : IGameEventHander
    {
        private readonly CommandControl _cmdHandler;

        public WorldEditHandler(CommandControl cmdHandler)
        {
            _cmdHandler = cmdHandler;
        }

        public bool CanHandle(GameEvent eventname)
        {
            return eventname == GameEvent.PlayerMessage;
        }

        public Result Handle(Response message)
        {
            if (message.body.properties.MessageType.Equals("chat"))
            {
                var args = message.body.properties.Message.Split(' ');
                if (args.Length > 1 && (args[0].Equals("pos")))
                {
                    _cmdHandler.HandleCommand(args);
                }
            }
            return new Result();
        }
    }
}