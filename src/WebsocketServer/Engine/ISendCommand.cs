using WorldEdit.Output;

namespace WorldEdit
{
    public interface ISendCommand
    {
        IMinecraftCommandService CommandService { get; set; }
    }
}