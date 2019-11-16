using System;
using System.Threading.Tasks;
using ElectronNET.API.Entities;
using PoECommerce.Client.Electron.Abstraction;
using PoECommerce.Client.Shared.Display;

namespace PoECommerce.Client.Electron
{
    public class ElectronWindow : IWindow
    {
        public ElectronWindow(int windowId, BrowserWindowOptions windowOptions, string loadPath = null)
        {
            Id = windowId;
            WindowOptions = windowOptions;
            LoadPath = loadPath;
        }

        public int Id { get; }
        public bool IsLoaded { get; internal set; }
        public bool IsOpen { get; internal set; }
        public bool IsMaximized { get; internal set; }
        public string LoadPath { get; }
        public BrowserWindowOptions WindowOptions { get; }
        public IBrowserWindow BrowserWindow { get; private set; }
        
        internal async Task InitializeWindow(Func<Task<IBrowserWindow>> asyncInitializer)
        {
            BrowserWindow = await asyncInitializer();
        }
    }
}