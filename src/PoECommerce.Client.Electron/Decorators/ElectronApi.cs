using System.Threading.Tasks;
using ElectronNET.API.Entities;
using PoECommerce.Client.Electron.Abstraction;

namespace PoECommerce.Client.Electron.Decorators
{
    internal class ElectronApi : IElectronApi
    {
        public async Task<IBrowserWindow> CreateWindowAsync(BrowserWindowOptions options, string loadUrl = "http://localhost")
        {
            return new ElectronBrowserWindow(await ElectronNET.API.Electron.WindowManager.CreateWindowAsync(options, loadUrl));
        }
    }
}