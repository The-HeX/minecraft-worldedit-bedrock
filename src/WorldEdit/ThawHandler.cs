﻿namespace WorldEdit
{
    public class ThawHandler : ChatHandler
    {
        public ThawHandler()
        {
            ChatCommand = "thaw";
        }

        protected override void HandleMessage(string[] args)
        {
            Command("fill ~-15 ~-15 ~-15 ~15 ~15 ~15 water 0 replace ice");
        }
    }
}