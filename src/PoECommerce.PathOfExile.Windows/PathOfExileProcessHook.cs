using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using PoECommerce.PathOfExile.GameClient.Abstractions;

namespace PoECommerce.PathOfExile.Windows
{
    internal class PathOfExileProcessHook : IPathOfExileProcessHook
    {
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        private Process _currentHook;

        public bool IsLaunched()
        {
            if (!IsHookActive())
            {
                _currentHook = Process.GetProcesses().FirstOrDefault(p => p.ProcessName.Contains("PathOfExile") && p.MainWindowTitle.StartsWith("Path of Exile"));
            }

            return IsHookActive();
        }
        public bool FocusGameWindow()
        {
            if (!IsLaunched())
            {
                return false;
            }

            return SetForegroundWindow(_currentHook.MainWindowHandle);
        }

        private bool IsHookActive()
        {
            return _currentHook != null && !_currentHook.HasExited && _currentHook.Responding;
        }

    }
}