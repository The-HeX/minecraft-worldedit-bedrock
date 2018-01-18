using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using MinecraftPluginServer;
using WorldEdit.Output;
using WorldEdit.Schematic;

namespace WorldEdit
{
    public class MinecraftWebsocketCommandService : IMinecraftCommandService
    {
        private readonly PluginServer _server;

        public MinecraftWebsocketCommandService(PluginServer server)
        {
            _server = server;
        }


        public void Subscribe(string message)
        {
            _server.Subscribe(message);
        }
        public void Command(string command)
        {
            Commands.Enqueue(command);
        }

        public void Status(string message)
        {
            Statuses.Enqueue("tell @s " + message);
        }

        public Position GetLocation()
        {
            var result = _server.Send("testforblock ~ ~ ~ air");
            
            return new Position(result.body.position.x, result.body.position.y, result.body.position.z);
        }

        public void Wait()
        {
            while (!(Commands.IsEmpty && Statuses.IsEmpty))
            {
                Thread.Sleep(1000);
            }
            return;
        }

        private static bool pause=false;
        private const int SLEEP_WHEN_EMPTY = 5000;
        private const int SLEEP_WHEN_LOOPING = 100;
        private ConcurrentQueue<string> Commands { get; } = new ConcurrentQueue<string>();
        private ConcurrentQueue<string> Statuses { get; } = new ConcurrentQueue<string>();
        public int MessageCount { get; private set; }
        public static bool StopWhenEmpty { get; set; } = false;

        public CancellationTokenSource Run()
        {
            var tokenSource = new CancellationTokenSource()
                ;
            Task.Run(() =>
            {
                string message;
                while (true)
                {
                    if (!pause)
                    {
                        while (!Statuses.IsEmpty)
                        {
                            if (Statuses.TryDequeue(out message))
                            {
                                _server.Send(message,"",false);
                                MessageCount++;
                            }
                        }
                        if (!Commands.IsEmpty)
                        {
                            if (Commands.TryDequeue(out message))
                            {
                                _server.Send(message,"",false);
                                MessageCount++;
                            }
                        }
                        if (Statuses.IsEmpty && Commands.IsEmpty)
                        {
                            if (StopWhenEmpty)
                            {
                                tokenSource.Cancel();
                            }
                            Thread.Sleep(SLEEP_WHEN_EMPTY);
                        }
                        else
                        {
                            Thread.Sleep(SLEEP_WHEN_LOOPING);
                        }
                    }
                    else
                    {
                        Thread.Sleep(SLEEP_WHEN_EMPTY);
                    }
                }
            }, tokenSource.Token);

            return tokenSource;
        }

        public ICommandFormater GetFormater()
        {
            return new WebsocketCommandFormater();
        }

        public void ShutDown()
        {
            StopWhenEmpty = true;
        }

        public Action<string> MessageReceived = (a) => { };
    }
}