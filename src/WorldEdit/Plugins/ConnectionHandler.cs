using System;
using System.Collections.Generic;
using System.Threading;
using MinecraftPluginServer;
using MinecraftPluginServer.Protocol;
using WorldEdit.Output;

namespace WorldEdit
{
    internal class ConnectionHandler : IConnectionEventHander
    {
        private readonly IMinecraftCommandService _minecraftService;
        private readonly string _serverName;
        private readonly List<GameEvent> _eventSubscriptions;

        public ConnectionHandler(IMinecraftCommandService minecraftService, string serverName, List<GameEvent> eventSubscriptions)
        {
            _minecraftService = minecraftService;
            _serverName = serverName;
            _eventSubscriptions = eventSubscriptions;
        }

        public void OnConnection()
        {
            _minecraftService.Command(_minecraftService.GetFormater().Title(_serverName+" Started", ""));
            foreach (var subscription in _eventSubscriptions)
            {
                Console.WriteLine($"subscibing to {subscription}");
                _minecraftService.Subscribe((new SubscribeMessage(subscription.ToString())).ToString());
                Thread.Sleep(100);
            }            
        }
    }
}