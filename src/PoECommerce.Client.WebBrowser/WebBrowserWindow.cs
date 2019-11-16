using PoECommerce.Client.Shared.Display;

namespace PoECommerce.Client.WebBrowser
{
    public class WebBrowserWindow : IWindow
    {
        public WebBrowserWindow(int windowId, string loadPath = null)
        {
            Id = windowId;
            LoadPath = loadPath;
        }

        public int Id { get; }
        public string LoadPath { get; }
        public bool IsLoaded { get; internal set; }
        public bool IsOpen { get; internal set; }
        public bool IsMaximized { get; internal set; }
    }
}