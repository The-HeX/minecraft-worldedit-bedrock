using WorldEdit.Output;

namespace WorldEdit
{
    public class DrainHandler : ChatHandler
    {
        private readonly IMinecraftCommandService _commandService;

        public DrainHandler(IMinecraftCommandService commandService)
        {
            _commandService = commandService;
            _command = "drain";
        }

        protected override void HandleMessage(string[] args)
        {
            _commandService.Command("fill ~-15 ~-15 ~-15 ~15 ~15 ~15 air 0 replace water");
        }
    }
}