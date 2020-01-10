using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using ElectronNET.API.Entities;
using PoECommerce.Client.Electron.Abstraction;
using PoECommerce.Client.Electron.Decorators;
using PoECommerce.Client.Shared.Display;
using PoECommerce.Client.Shared.Routing;

namespace PoECommerce.Client.Electron
{
    public class ElectronWindowManager : IWindowManager
    {
        private readonly IElectronApi _electronApi;
        private readonly INavigationManager _navigationManager;
        private readonly List<ElectronWindow> _windows;

        public ElectronWindowManager(INavigationManager navigationManager, List<ElectronWindow> windows)
        {
            _electronApi = new ElectronApi();
            _navigationManager = navigationManager;
            _windows = windows;
        }

        internal ElectronWindowManager(IElectronApi electronApi, INavigationManager navigationManager, List<ElectronWindow> windows)
        {
            _electronApi = electronApi;
            _navigationManager = navigationManager;
            _windows = windows;
        }

        public async Task ResizeAndPlaceOnCursor(int windowId, int width, int height)
        {
            IBrowserWindow window = await GetBrowserWindow(GetWindow(windowId));
            Point point = await ElectronNET.API.Electron.Screen.GetCursorScreenPointAsync();
            window.SetBounds(new Rectangle { X = point.X, Y = point.Y, Height = height, Width = width });
            window.Show();
        }

        public async Task ResizeAndPosition(int windowId, int x, int y, int width, int height)
        {
            IBrowserWindow window = await GetBrowserWindow(GetWindow(windowId));
            window.SetBounds(new Rectangle { X = x, Y = y, Height = height, Width = width }, true);
            window.Show();
        }

        public IReadOnlyList<IWindow> Windows => new ReadOnlyCollection<IWindow>(_windows.Cast<IWindow>().ToList());

        public async Task LoadUrl(int windowId, string url, bool openWhenReady)
        {
            IBrowserWindow window = await GetBrowserWindow(GetWindow(windowId));
            window.LoadURL(_navigationManager.ToAbsoluteUri(url).AbsoluteUri);
            window.WebContents.OnDidFinishLoad += ShowWhenReady;

            void ShowWhenReady()
            {
                window.Show();
                window.WebContents.OnDidFinishLoad -= ShowWhenReady;
            }
        }

        public async Task Show(int windowId)
        {
            IBrowserWindow window = await GetBrowserWindow(GetWindow(windowId));
            window.Show();
        }


        public async Task Hide(int windowId)
        {
            IBrowserWindow window = await GetBrowserWindow(GetWindow(windowId));
            window.Hide();
        }

        public async Task Close(int windowId)
        {
            IBrowserWindow window = await GetBrowserWindow(GetWindow(windowId));
            window.Close();
        }

        public async Task Minimize(int windowId)
        {
            IBrowserWindow window = await GetBrowserWindow(GetWindow(windowId));
            window.Minimize();
        }

        public async Task Maximize(int windowId)
        {
            IBrowserWindow window = await GetBrowserWindow(GetWindow(windowId));
            window.Maximize();
        }
        public void AddWindow(ElectronWindow window)
        {
            if (_windows.Any(w => w.Id == window.Id))
            {
                throw new ArgumentException($"Window with id {window.Id} already exists.", nameof(window));
            }

            _windows.Add(window);
        }

        private async Task<IBrowserWindow> GetBrowserWindow(ElectronWindow window)
        {
            if (window.BrowserWindow != null)
            {
                return window.BrowserWindow;
            }

            await InitializeBrowserWindow(window);

            return window.BrowserWindow;
        }

        private async Task InitializeBrowserWindow(ElectronWindow window)
        {
            if (string.IsNullOrEmpty(window.LoadPath))
            {
                await window.InitializeWindow(async () => await _electronApi.CreateWindowAsync(window.WindowOptions));
            }
            else
            {
                try
                {
                    await window.InitializeWindow(async () => await _electronApi.CreateWindowAsync(window.WindowOptions, _navigationManager.ToAbsoluteUri(window.LoadPath).AbsoluteUri));
                }
                catch (InvalidOperationException navigationManagerException)
                {
                    throw new ElectronException($"Electron cannot load window while there is no request context. {typeof(INavigationManager)} is not initialized yet.", navigationManagerException);
                }
            }

            window.BrowserWindow.OnReadyToShow += () => window.IsLoaded = true;
            window.BrowserWindow.OnShow += () => window.IsOpen = true;
            window.BrowserWindow.OnClose += () => window.IsOpen = false;
            window.BrowserWindow.OnMinimize += () => window.IsMaximized = false;
            window.BrowserWindow.OnMaximize += () => window.IsMaximized = true;
        }

        private ElectronWindow GetWindow(int windowId)
        {
            if (!(_windows.Find(w => w.Id == windowId) is ElectronWindow window))
            {
                throw new ArgumentOutOfRangeException(nameof(windowId), $"There is no window with id {windowId}.");
            }

            return window;
        }
    }
}