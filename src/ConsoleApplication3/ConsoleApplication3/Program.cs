using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using MinecraftPluginServer.Protocol;

namespace MinecraftPluginServer
{
    class Program
    {
        static PluginServer wssv;
        static void Main(string[] args)
        {
            using (var wssv = StartServer("ws://127.0.0.1:12112")) // will stop on disposal.
            {
                while (true)
                {
                    var consoleKeyInfo = Console.ReadKey(true);

                    switch (consoleKeyInfo.KeyChar)
                    {
                        case 'u':
                            wssv.Subscribe((new SubscribeMessage("AgentCreated")).ToString());
                            wssv.Subscribe((new SubscribeMessage("AgentCommand")).ToString());
                            wssv.Send("agent create");
                            break;
                        case 'i':
                            wssv.Send("agent inspect forward");
                            break;
                        case 'o':
                            wssv.Send("agent inspectdata forward");
                            break;
                        case 'p':
                            wssv.Send("agent turn right");
                            break;
                        case 'a':
                            wssv.Send("fill ~ ~ ~ ~ ~ ~ stone");
                            break;
                        case 'l':
                            wssv.Send("list");
                            break;
                        case 'c':
                            wssv.Subscribe((new SubscribeMessage("PlayerMessage")).ToString());
                            break;
                        //case 'p':
                        //    wssv.Subscribe((new SubscribeMessage("PlayerTravelled")).ToString());
                        //    break;
                    }

                }
            }            
        } 

        private static PluginServer StartServer(string url)
        {
            var server = new PluginServer(url);
            server.Start();

            

            return server;
        }

        
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
    }
}