using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WorldEdit.Input;
using WorldEdit.Output;

namespace WorldEdit
{
    internal class Program
    {
        private static string wsUrl;
        private static string restURL;
        private static bool keepRunning=true;

        //http://localhost:8080/fill?from=3%205%203&to=30 3f0 30&tileName=stone&tileData=0
        private static void Main()
        {
            Console.CancelKeyPress += delegate (object sender, ConsoleCancelEventArgs e) {
                e.Cancel = true;
                Program.keepRunning = false;
            };
            using (var codeConnectionProcess = Prerequisites())
            {
                var cmdHandler = new CommandControl();
                ;
                using (var commandService = MinecraftCommandService.Run())
                {
                    
                    //check if connected, if not send connection command through AHK
                    var ahk = AutoHotKey.Run();
                    AutoHotKey.Callback = (s) =>
                    {
                        Console.WriteLine(s);
                        var args = s.Split(' ');
                        cmdHandler.HandleCommand(args);
                    };
                    Console.WriteLine(@"
Press Ctrl-C to shutdown.");

                    ahk.ExecRaw(@"
WinMinimize Code Connection for Minecraft
WinActivate Minecraft
send {esc}
sleep 500
send /
sleep 200
send connect " + wsUrl+"{enter}");
                    var minecraftAPI = new MinecraftCommandService();
                    minecraftAPI.Command("executeasother?origin=@p&position=~%20~%20~&command=title%20@s%20title%20WorldEdit%20Started");
          
                    while (keepRunning)
                    {
                        Thread.Sleep(500);
                    }
                    minecraftAPI.Command("executeasother?origin=@p&position=~%20~%20~&command=title%20@s%20subtitle WorldEdit Shutting Down");
                    minecraftAPI.Wait();
                    MinecraftCommandService.ShutDown();
                    commandService.Cancel();
                }
            }
        }

        private static IDisposable Prerequisites()
        {
            var processes = Process.GetProcesses();
            if (!processes.Any(a => a.ProcessName.ToLower().Contains("minecraft")))
            {
                Console.WriteLine("ERROR: Minecraft is not running");
            }
            if (!processes.Any(a => a.ProcessName.ToLower().Contains("code connection")))
            {
                //Console.WriteLine("ERROR: Code Connection is not running");
                var codeconnectionExe =
                    @"C:\Program Files (x86)\Minecraft Code Connection\Code Connection for Minecraft.exe";
                if (File.Exists(codeconnectionExe))
                {
                    var output = "";
                    var processStartInfo = new ProcessStartInfo(codeconnectionExe);

                    processStartInfo.RedirectStandardOutput = true;
                    processStartInfo.UseShellExecute = false;
                    processStartInfo.WindowStyle= ProcessWindowStyle.Hidden;
                    var process = Process.Start(processStartInfo);
                    process.OutputDataReceived += (s, e) =>
                    {
                        output = e.Data;
                    
                        if (output.Contains("WS server"))
                        {
                            wsUrl = output.Replace("WS server listening at", "").Trim();
                        }
                        if (output.Contains("REST server"))
                        {
                            restURL = output.Replace("REST server listening at ", "").Trim();
                        }
                    };
                    process.BeginOutputReadLine();
                    while (string.IsNullOrEmpty(wsUrl) || string.IsNullOrEmpty(restURL))
                    {
                        Thread.Sleep(500);
                    }
                    process.CancelOutputRead();
                    Console.WriteLine("Started code connection: enter command in minecraft\n/connect " + wsUrl);
                    return new Disposable( process);
                }
                else
                {
                    Console.WriteLine("Could not start Code Connection.");
                    return null;
                }
            }
            return null;
        }
    }

    public class Disposable : IDisposable
    {
        private readonly Process _process;

        public Disposable(Process process)
        {
            _process = process;
        }

        public void Dispose()
        {
            var pid = _process?.Id;
            if (pid != null)
            { Process.Start("taskkill.exe", "/PID " + pid); }

            _process?.CloseMainWindow();
        }
    }

}