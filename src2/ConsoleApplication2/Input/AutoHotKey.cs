using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using AutoHotkey.Interop;
using WorldEdit.Commands;
using WorldEdit.Output;
using WorldEdit.Schematic;
using Position = WorldEdit.Schematic.Position;

namespace WorldEdit.Input
{
    public static class AutoHotKey
    {
        private static readonly AHKDelegate ahkDelegate = AHKCallback;


        private static void AHKCallback(string s)
        {
            Callback(s);
        }

        public static Action<string> Callback = (s) => Console.WriteLine(s);


        public static AutoHotkeyEngine Run()//toto make disposable wrapper to deal with saving state, saved positions..ect.
        {
            var ptr = Marshal.GetFunctionPointerForDelegate(ahkDelegate);
            var ahk = new AutoHotkeyEngine();
            ahk.Load("input.ahk");            
            ahk.SetVar("ptr",ptr.ToString());
            return ahk;
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void AHKDelegate([MarshalAs(UnmanagedType.LPWStr)] string s);
    }

    public class SavedPosition
    {
       public Position Position { get; set; }
       public string Name { get; set; }
    }

    public class SavedPositionService
    {
        public List<SavedPosition> Positions { get; private set; }=new List<SavedPosition>();

    }

}