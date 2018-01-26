using System;
using System.Diagnostics;

namespace WorldEdit
{
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
            {
                Process.Start("taskkill.exe", "/PID " + pid);
            }

            _process?.CloseMainWindow();
        }
    }
}