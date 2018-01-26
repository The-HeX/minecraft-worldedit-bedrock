using MinecraftPluginServer;
using MinecraftPluginServer.Protocol.Response;
using WorldEdit.Output;

namespace WorldEdit
{
    public class ChatHandler : IGameEventHander
    {
        private readonly CommandControl _cmdHandler;
        protected string ChatCommand;
        public  IMinecraftCommandService _commandService { get;  set; }

        public bool CanHandle(GameEvent eventname)
        {
            return eventname == GameEvent.PlayerMessage;
        }

        public Result Handle(Response message)
        {
            if (message.body.properties.MessageType.Equals("chat"))
            {
                var args = message.body.properties.Message.Split(' ');
                if (args.Length == 1 && args[0].Equals(ChatCommand))
                {
                    HandleMessage(args);
                }
            }
            return new Result();
        }

        public void Command(string commannd)
        {
            _commandService.Command(commannd);
        }

        protected virtual void HandleMessage(string[] args)
        {
        }
    }
}