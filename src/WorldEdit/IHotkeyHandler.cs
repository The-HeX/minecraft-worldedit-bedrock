using WorldEdit.Output;

namespace WorldEdit
{
    public interface IHotkeyHandler
    {
        bool CanHandle(string[] args);
        void Handle(string[] args, IMinecraftCommandService minecraftService);
    }
}