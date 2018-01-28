using System.Collections.Generic;
using MinecraftPluginServer;
using MinecraftPluginServer.Protocol.Response;
using WorldEdit.Output;

namespace WorldEdit
{
    public class WorldEditHandler : IGameEventHander, ISendCommand
    {
        private  CommandControl _cmdHandler;

        public List<GameEvent> CanHandle()
        {
            return new List<GameEvent>() { GameEvent.PlayerMessage };
        }

        public Result Handle(Response message)
        {
            if (message.body.properties.MessageType.Equals("chat"))
            {
                var args = message.body.properties.Message.Split(' ');
                if (args.Length > 1 && (args[0].Equals("pos")))
                {
                    if (_cmdHandler == null)
                    {
                        _cmdHandler=new CommandControl(CommandService,CommandService.GetFormater());
                    }
                    _cmdHandler.HandleCommand(args);
                }
            }
            return new Result();
        }

        public IMinecraftCommandService CommandService { get; set; }
    }
}