using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MinecraftPluginServer.Protocol;
using MinecraftPluginServer.Protocol.Response;
using Newtonsoft.Json;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace MinecraftPluginServer
{
    public class SocketServer : IDisposable
    {
        private readonly WebSocketServer wssv;
        private string _lastId;
        private Response _lastResponse;
        protected List<IConnectionEventHander> ConnectionHandlers = new List<IConnectionEventHander>();

        protected List<IGameEventHander> Handlers = new List<IGameEventHander>();
        protected List<IGameRawEventHander> RawHandlers = new List<IGameRawEventHander>();

        public SocketServer()
        {
            Handlers.Add(new ChatConsoleLoggingHandler());
            //RawHandlers.Add(new MessageFileLogger());

            MinecraftPluginBase.OnConnected = OnConnection;
            MinecraftPluginBase.MessageReceived = OnMessage;
            MinecraftPluginBase.ErrorReceived = OnError;
        }

        public SocketServer(int port, IGameEventHander[] handlers) : this(port)
        {
            Handlers.AddRange(handlers);
        }


        public SocketServer(int  port) : this()
        {
            wssv = new WebSocketServer(port);
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

        private void OnError(ErrorEventArgs obj)
        {
        }

        private void OnMessage(MessageEventArgs e)
        {
            Task.Run(() =>
            {
                try
                {
                    var obj = JsonConvert.DeserializeObject<Response>(e.Data);
                    HandleRawMessages(e.Data, 0);
                    switch (obj.header.messagePurpose.ToMessagePurpose())
                    {
                        case MessagePurpose.Event:
                            HandelEvents(obj, e.Data);
                            break;
                        case MessagePurpose.CommandResponse:
                            _lastResponse = obj;
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
                }
            });
        }

        private void HandelEvents(Response eventMessage, string rawMessage)
        {
            var eventname = eventMessage.body.eventName.ToEvent();

            foreach (var hander in Handlers)
                if (hander.CanHandle().Contains(eventname) )
                    hander.Handle(eventMessage);
        }

        private void HandleRawMessages(string rawMessage, GameEvent eventname)
        {
            foreach (var hander in RawHandlers)
                if (hander.CanHandle(eventname))
                    hander.Handle(rawMessage);
        }

        protected void OnConnection(MinecraftPluginBase source)
        {
            Console.WriteLine("opened.");
            var message = new CommandMessage("geteduclientinfo");

            Send(message.ToString(), "", false);

            foreach (var hander in ConnectionHandlers)
                hander.OnConnection();
        }

        public Response Send(string command, string origin = "", bool wait = true)
        {
            var m = new CommandMessage(command);
            if (!string.IsNullOrEmpty(origin))
                m.body.origin.type = origin;
            var id = m.header.requestId;

            Task.Run(() => { wssv.WebSocketServices.Broadcast(m.ToString()); }).Wait();


            var counter = 0;
            while (!id.Equals(_lastId) && counter < 20 && wait)
            {
                counter++;
                Thread.Sleep(500);
                if (id.Equals(_lastId))
                    return _lastResponse;
            }
            ;


            //wait for request id to be returned.
            return null;
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

        public void AddHandler(IGameEventHander handler)
        {
            Handlers.Add(handler);
        }

        public void AddHandler(IConnectionEventHander handler)
        {
            ConnectionHandlers.Add(handler);
        }
    }

    public interface IConnectionEventHander
    {
        void OnConnection();
    }
}