using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using AutoHotkey.Interop;
using WorldEdit.Schematic;

namespace WorldEdit.Input
{
    public static class AutoHotKey
    {
        private static readonly AHKDelegate ahkDelegate = AHKCallback;
        public static Action<string> Callback = s => Console.WriteLine(s);

        private static void AHKCallback(string s)
        {
            Callback(s);
        }

        public static AutoHotkeyEngine Run(string script)
            //toto make disposable wrapper to deal with saving state, saved positions..ect.
        {
            var ptr = Marshal.GetFunctionPointerForDelegate(ahkDelegate);
            var ahk = new AutoHotkeyEngine();
            ahk.Load(script);
            ahk.SetVar("ptr", ptr.ToString());
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
        public List<SavedPosition> Positions { get; private set; } = new List<SavedPosition>();
    }
}