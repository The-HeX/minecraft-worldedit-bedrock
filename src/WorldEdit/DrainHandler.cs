using WorldEdit.Output;

namespace WorldEdit
{
    public class DrainHandler : ChatHandler
    {
        
        public DrainHandler()
        {
            ChatCommand = "drain";
        }

        protected override void HandleMessage(string[] args)
        {
            Command("fill ~-15 ~-15 ~-15 ~15 ~15 ~15 air 0 replace water");
        }
    }
}