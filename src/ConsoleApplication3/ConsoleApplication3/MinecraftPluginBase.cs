using System;
using System.Collections.Generic;
using System.Net.Mail;
using MinecraftPluginServer.Protocol;
using MinecraftPluginServer.Protocol.Request;
using MinecraftPluginServer.Protocol.Response;
using Newtonsoft.Json;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace MinecraftPluginServer
{
    public class MinecraftPluginBase : WebSocketBehavior
    {
        protected List<IGameEventHander> Handlers = new List<IGameEventHander>();
        protected List<IGameRawEventHander> RawHandlers = new List<IGameRawEventHander>();

        public MinecraftPluginBase()
        {
            EmitOnPing = true;
            Handlers.Add(new ChatHandler());
            
            RawHandlers.Add(new MessageFileLogger());
        }

        protected override void OnOpen()
        {
            base.OnOpen();
            OnConnected(this);
            Console.WriteLine("opened.");
            var message = new CommandMessage("geteduclientinfo");
            Send(message.ToString());
        }

        public void Send(RequestMessage message)
        {
            Send(message.ToString());
        }
        public static Action<MinecraftPluginBase> OnConnected = (a) => { };

        protected override void OnError(ErrorEventArgs e)
        {
            Console.WriteLine(e.Message + " " + e.Exception);
            base.OnError(e);
        }

        protected override void OnMessage(MessageEventArgs e)
        {
            var obj = JsonConvert.DeserializeObject<Response>(e.Data);

            HandleRawMessages(e.Data, 0);
            switch (obj.header.messagePurpose.ToMessagePurpose())
            {
                case MessagePurpose.Event:
                    HandelEvents(obj,e.Data);
                    Console.WriteLine("Event: " + e.Data);
                    break;
                case MessagePurpose.CommandResponse:
                    Console.WriteLine("Command Response: " + e.Data);
                    break;
                default:
                    Console.WriteLine("Unhandled Message: " + e.Data);
                    break;
            }
        }

        private void HandelEvents(Response eventMessage,string rawMessage)
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
    }

    public interface IGameRawEventHander
    {
        bool CanHandle(GameEvent eventname);
        Result Handle(string rawMessage);
    }
}