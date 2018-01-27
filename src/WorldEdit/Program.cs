using System;
using MinecraftPluginServer;
using WorldEdit.Output;

namespace WorldEdit
{
    internal class Program
    {
        private static void Main()
        {
            var pluginServer = new PluginServer();
            pluginServer.Plugin(new DrainHandler());
            pluginServer.Plugin(new ThawHandler());
            pluginServer.Plugin(new CreateHandler());
            pluginServer.Plugin(new SchematicHandler());

            pluginServer.Plugin(new RadiusHandler());
            pluginServer.Plugin(new LandSculptHandler());
            //pluginServer.Plugin(new RadiusHandler());

            Console.CancelKeyPress += delegate(object sender, ConsoleCancelEventArgs e)
            {
                e.Cancel = true;
                pluginServer.Stop();
            };

            pluginServer.Start();
        }
    }

    internal class LandSculptHandler : IHotkeyHandler
    {
        public bool CanHandle(string[] args)
        {
            return args.Length > 0 && args[0].Equals("^l");
        }

        public void Handle(string[] args, IMinecraftCommandService minecraftService)
        {
            for (int i = 0; i <= RadiusHandler.Radius; i++)
            {
                minecraftService.Command($"fill ~-{i} ~{i} ~-{i} ~{i} ~{i} ~{i} air");
            }
        }
    }
}