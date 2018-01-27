using WorldEdit.Output;

namespace WorldEdit
{
    public class RadiusHandler : IHotkeyHandler
    {
        public static int Radius { get; private set; } = 3;

        public bool CanHandle(string[] args)
        {
            if (args.Length > 0)
            {
                if (args[0].Equals("^-") || args[0].Equals("^="))
                {
                    return true;
                }
            }
            return false;
        }

        public void Handle(string[] args, IMinecraftCommandService minecraftService)
        {
            if (args[0].Equals("^-"))
            {
                Radius--;
                if (Radius == 0)
                {
                    Radius = 1;
                }
            }
            else
            {
                Radius++;
            }
            minecraftService.Status($"Radius changed to {Radius}");
        }
    }
}