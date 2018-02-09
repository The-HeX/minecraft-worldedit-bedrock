using System;

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
            pluginServer.Plugin(new CreateHandler());
            pluginServer.Plugin(new SchematicHandler());

            //local hotkey handlers.
            pluginServer.Plugin(new RadiusHandler());
            pluginServer.Plugin(new LandSculptHandler());
            

            Console.CancelKeyPress += delegate(object sender, ConsoleCancelEventArgs e)
            {
                e.Cancel = true;
                pluginServer.Stop();
            };

            pluginServer.Start("WorldEdit", "12112");
        }
    }
}