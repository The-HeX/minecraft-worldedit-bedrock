using System;
using System.IO;
using System.Linq;
using MinecraftPluginServer;

namespace WorldEdit
{
    internal class Program
    {
        private static void Main()
        {
            var pluginServer = new PluginServer();


            //game event handlers
            pluginServer.Plugin(new SavedPositionHandler());
            pluginServer.Plugin(new DrainHandler());
            pluginServer.Plugin(new ThawHandler());
            var createHandler = new CreateHandler();
            pluginServer.Plugin(createHandler);
            pluginServer.Plugin(new ScriptHandler(createHandler));
            pluginServer.Plugin(new SchematicHandler());
            pluginServer.Plugin(new ChatLogHandler());
            //local hotkey handlers.
            pluginServer.Plugin(new RadiusHandler());
            pluginServer.Plugin(new LandSculptHandler());
            

            Console.CancelKeyPress += delegate(object sender, ConsoleCancelEventArgs e)
            {
                e.Cancel = true;
                pluginServer.Stop();
            };

            pluginServer.Start("WorldEdit", 12112);
        }
    }

    public class ChatLogHandler : ChatHandler
    {
        public ChatLogHandler()
        {
            ChatCommand = "create";
        }

        public override void HandleMessage(string[] args)
        {
            using (var file = File.AppendText(".\\create.log"))
            {
                file.WriteLine(args.Aggregate((a,b)=>a+=b +" "));
            }
        }
    }

    public class ScriptHandler : ChatHandler
    {
        private readonly CreateHandler _handler;

        public ScriptHandler(CreateHandler handler)
        {
            _handler = handler;
            ChatCommand = "script";
        }

        public override void HandleMessage(string[] args)
        {
            var lines = File.ReadAllLines($".\\{args[1]}.log");

            foreach (var command in lines)
            {
                _handler.HandleMessage(command.Split(' ').Where(a => !string.IsNullOrWhiteSpace(a)).ToArray());
            }
            
        }
    }

}