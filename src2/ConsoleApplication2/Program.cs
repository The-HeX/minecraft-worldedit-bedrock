using System.Threading;
using WorldEdit.Input;
using WorldEdit.Output;
using WorldEdit.Schematic;

namespace WorldEdit
{
    internal class Program
    {
        //http://localhost:8080/fill?from=3%205%203&to=30 3f0 30&tileName=stone&tileData=0
        private static void Main(string[] args)
        {
            using (var commandService = MinecraftCommandService.Run())
            {
                commandService.Start();
                var ahk=AutoHotKey.Run();

                //SchematicProcessor.SchematicCommandProcessor(args);
                //Thread.Sleep(30000);
                //MinecraftCommandService.ShutDown();
                commandService.Wait();
            }
                
        }        
    }
}