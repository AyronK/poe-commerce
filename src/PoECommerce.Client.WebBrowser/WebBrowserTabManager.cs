using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using PoECommerce.Client.Shared.Display;
using PoECommerce.Client.Shared.Routing;

namespace PoECommerce.Client.WebBrowser
{
    public class WebBrowserTabManager : IWindowManager
    {
        private readonly IJSRuntime _jsRuntime;
        private readonly INavigationManager _navigationManager;
        private readonly List<WebBrowserWindow> _windows;

        public WebBrowserTabManager(IJSRuntime jsRuntime, INavigationManager navigationManager, List<WebBrowserWindow> windows)
        {
            _jsRuntime = jsRuntime;
            _navigationManager = navigationManager;
            _windows = windows;
        }
        
        public Task ResizeAndPlaceOnCursor(int windowId, int width, int height) => Task.CompletedTask;

        public IReadOnlyList<IWindow> Windows => new ReadOnlyCollection<IWindow>(_windows.Cast<IWindow>().ToList());

        public void AddWindow(WebBrowserWindow window)
        {
            if (_windows.Any(w => w.Id == window.Id))
            {
                throw new ArgumentException($"Window with id {window.Id} already exists.", nameof(window));
            }

            _windows.Add(window);
        }
        
        public async Task Show(int windowId)
        {
            WebBrowserWindow window = GetWindow(windowId);

            await LoadUrl(window.Id, window.LoadPath);

            window.IsLoaded = true;
            window.IsOpen = true;
            window.IsMaximized = true;
        }

        public async Task LoadUrl(int windowId, string url)
        {
            await _jsRuntime.InvokeAsync<object>("open", new[] { _navigationManager.ToAbsoluteUri(url).AbsoluteUri, "_blank" });
        }

        public Task Hide(int windowId) => Task.CompletedTask;

        public Task Close(int windowId) => Task.CompletedTask;

        public Task Minimize(int windowId) => Task.CompletedTask;

        public Task Maximize(int windowId) => Show(windowId);

        public Task ResizeAndPosition(int windowId, int x, int y, int width, int height) => Task.CompletedTask;

        private WebBrowserWindow GetWindow(int windowId)
        {
            if (!(_windows.Find(w => w.Id == windowId) is WebBrowserWindow window))
            {
                throw new ArgumentOutOfRangeException(nameof(windowId), $"There is no window with id {windowId}.");
            }

            return window;
        }
    }
}