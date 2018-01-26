using System.Threading;
using WorldEdit.Schematic;

namespace WorldEdit.Output
{
    public interface IMinecraftCommandService
    {
        void Command(string command);
        void Status(string message);
        Position GetLocation();
        void Wait();
        CancellationTokenSource Run();

        ICommandFormater GetFormater();

        void ShutDown();
        void Subscribe(string toString);
    }
}