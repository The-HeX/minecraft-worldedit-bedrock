using System;
using MinecraftPluginServer.Protocol;
using MinecraftPluginServer.Protocol.Request;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace MinecraftPluginServer
{
    public class MinecraftPluginBase : WebSocketBehavior
    {
        public static Action<MinecraftPluginBase> OnConnected = a => { };

        public static Action<MessageEventArgs> MessageReceived = a => { };
        public static Action<ErrorEventArgs> ErrorReceived = a => { };

        public MinecraftPluginBase()
        {
            EmitOnPing = true;
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

        protected override void OnError(ErrorEventArgs e)
        {
            ErrorReceived(e);
            base.OnError(e);
        }

        protected override void OnMessage(MessageEventArgs e)
        {
            MessageReceived(e);
        }
    }

    public interface IGameRawEventHander
    {
        bool CanHandle(GameEvent eventname);
        Result Handle(string rawMessage);
    }
}