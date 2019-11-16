using System.Threading.Tasks;
using ElectronNET.API.Entities;

namespace PoECommerce.Client.Electron.Abstraction
{
    internal interface IElectronApi
    {
        Task<IBrowserWindow> CreateWindowAsync(BrowserWindowOptions options, string loadUrl = "http://localhost");
    }
}