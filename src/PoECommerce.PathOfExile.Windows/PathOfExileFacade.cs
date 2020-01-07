using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;

namespace PoECommerce.PathOfExile.Windows
{
    internal class PathOfExileFacade : IPathOfExileFacade
    {
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        private readonly IChat _chat;

        public PathOfExileFacade(IChat chat)
        {
            _chat = chat;
        }

        public IChat Chat => IsLaunched() ? _chat : throw new NullReferenceException("Chat cannot be accessed because Path of Exile client is not launched.");

        public bool IsLaunched()
        {
            Process poeWindow = Process.GetProcesses().FirstOrDefault(p => p.ProcessName.Contains("PathOfExile") && p.MainWindowTitle.StartsWith("Path of Exile"));
            return poeWindow != null && SetForegroundWindow(poeWindow.MainWindowHandle);
        }
    }
}