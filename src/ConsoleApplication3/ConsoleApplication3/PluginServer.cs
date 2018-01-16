using System;
using System.Collections.Generic;
using System.Threading;
using MinecraftPluginServer.Protocol;
using MinecraftPluginServer.Protocol.Response;
using Newtonsoft.Json;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace MinecraftPluginServer
{
    public class PluginServer : IDisposable
    {
        private readonly WebSocketServer wssv;

        public PluginServer()
        {
            Handlers.Add(new ChatConsoleLoggingHandler());
            RawHandlers.Add(new MessageFileLogger());

            MinecraftPluginBase.OnConnected = OnConnection;
            MinecraftPluginBase.MessageReceived = OnMessage;
            MinecraftPluginBase.ErrorReceived = OnError;
        }

        public PluginServer(IGameEventHander[] handlers)
        {
            Handlers.AddRange(handlers);
        }

        private void OnError(ErrorEventArgs obj)
        {
            
        }

        private void OnMessage(MessageEventArgs e)
        {
            Console.WriteLine($"OnMessage {e.IsPing}");
            try
            {
                var obj = JsonConvert.DeserializeObject<Response>(e.Data);

                HandleRawMessages(e.Data, 0);
                switch (obj.header.messagePurpose.ToMessagePurpose())
                {
                    case MessagePurpose.Event:
                        HandelEvents(obj, e.Data);
                        Console.WriteLine("Event: " + e.Data);
                        break;
                    case MessagePurpose.CommandResponse:
                        Console.WriteLine("Command Response: " + e.Data);
                        _lastId = obj.header.requestId;
                        break;
                    default:
                        Console.WriteLine("Unhandled Message: " + e.Data);
                        break;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(e.Data + " " + exception);
                throw;
            }

        }

        private void HandelEvents(Response eventMessage, string rawMessage)
        {
            var eventname = eventMessage.body.eventName.ToEvent();

            foreach (var hander in Handlers)
            {
                if (hander.CanHandle(eventname))
                {
                    hander.Handle(eventMessage);
                }
            }

        }

        private void HandleRawMessages(string rawMessage, GameEvent eventname)
        {
            foreach (var hander in RawHandlers)
            {
                if (hander.CanHandle(eventname))
                {
                    hander.Handle(rawMessage);
                }
            }
        }

        protected List<IGameEventHander> Handlers = new List<IGameEventHander>();
        protected List<IGameRawEventHander> RawHandlers = new List<IGameRawEventHander>();
        private string _lastId;


        public PluginServer(string url)
        {
            wssv = new WebSocketServer(url);
            wssv.AddWebSocketService<MinecraftPluginBase>("/");
            wssv.Log.Level = LogLevel.Debug;
            wssv.Log.Output = (d, a) => Console.WriteLine(a);
            wssv.KeepClean = false;
        }

        public void Dispose()
        {
            if (wssv != null && wssv.IsListening)
                wssv.Stop();
        }

        protected void OnConnection(MinecraftPluginBase source)
        {
            //source.s
        }

        public void Send(string command, string origin = "")
        {
            var m = new CommandMessage(command);
            if (!string.IsNullOrEmpty(origin))
                m.body.origin.type = origin;
            wssv.WebSocketServices.Broadcast(m.ToString());
            var id = m.header.requestId;

            do
            {
                Thread.Sleep(500);
            } while (!id.Equals(_lastId));
            

            //wait for request id to be returned.
        }

        public void Start()
        {
            wssv.Start();
        }

        public void Stop()
        {
            wssv.Stop();
        }

        public void Subscribe(string toString)
        {
            wssv.WebSocketServices.Broadcast(toString);
        }
    }
}