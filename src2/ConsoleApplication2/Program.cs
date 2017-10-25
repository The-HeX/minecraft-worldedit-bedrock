using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using WorldEdit.Input;
using WorldEdit.Output;

namespace WorldEdit
{
    internal class Program
    {
        private static string wsUrl;
        private static string restURL;

        //http://localhost:8080/fill?from=3%205%203&to=30 3f0 30&tileName=stone&tileData=0
        private static void Main()
        {
            using (var codeConnectionProcess = Prerequisites())
            {
                var cmdHandler = new CommandControl();
                ;
                using (var commandService = MinecraftCommandService.Run())
                {
                    commandService.Start();
                    //check if connected, if not send connection command through AHK
                    var ahk = AutoHotKey.Run();
                    AutoHotKey.Callback = (s) =>
                    {
                        Console.WriteLine(s);
                        var args = s.Split(' ');
                        cmdHandler.HandleCommand(args);
                    };
                    commandService.Wait();
                }
                codeConnectionProcess?.Close();
            }

        }

        private static Process Prerequisites()
        {
            var processes = Process.GetProcesses();
            if (!processes.Any(a => a.ProcessName.Contains("minecraft")))
            {
                Console.WriteLine("ERROR: Minecraft is not running");
            }
            if (!processes.Any(a => a.ProcessName.Contains("Code Connection")))
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
                    return process;
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
}