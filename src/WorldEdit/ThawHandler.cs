using WorldEdit.Output;

namespace WorldEdit
{
    public class ThawHandler : ChatHandler
    {
        private readonly IMinecraftCommandService _commandService;

        public ThawHandler(IMinecraftCommandService commandService)
        {
            _commandService = commandService;
            _command = "thaw";
        }

        protected override void HandleMessage(string[] args)
        {
            _commandService.Command("fill ~-15 ~-15 ~-15 ~15 ~15 ~15 water 0 replace ice");
        }
    }
}