using System;
using System.Net.WebSockets;
using MinecraftPluginServer.Protocol;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace MinecraftPluginServer
{
    public class PluginServer:IDisposable
    {
        public PluginServer()
        {
            MinecraftPluginBase.OnConnected = OnConnection;
        }

        protected void OnConnection(MinecraftPluginBase source)
        {
            source.s
        }
        public void Send(string command,string origin="")
        {
            var m = new CommandMessage(command);
            if (!string.IsNullOrEmpty(origin))
            {
                m.body.origin.type = origin;
            }
            wssv.WebSocketServices.Broadcast(m.ToString());
        }
        public PluginServer(string url)
        {
            wssv = new WebSocketServer(url);
            wssv.AddWebSocketService<MinecraftPluginBase>("/");
            wssv.Log.Level = LogLevel.Trace;
            wssv.Log.Output = (d, a) => Console.WriteLine(a);            
        }

        public void Start()
        {
            wssv.Start();
            
        }
        private WebSocketServer wssv;
        public void Stop()
        {
            wssv.Stop();
        }

        public void Subscribe(string toString)
        {
            wssv.WebSocketServices.Broadcast(toString);
        }

        public void Dispose()
        {
            if (wssv != null && wssv.IsListening)
            {
                wssv.Stop();
            }
        }
    }
}