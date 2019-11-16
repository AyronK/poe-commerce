using System.Collections.Generic;
using ElectronNET.API;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using PoECommerce.Client.Electron;
using PoECommerce.Client.Shared.Display;
using PoECommerce.Client.Shared.Routing;
using PoECommerce.Client.WebBrowser;

namespace PoECommerce.Client.StartupExtensions.Electron
{
    public static class DependencyInjectionExtensions
    {
        public static void AddElectronHybrid(this IServiceCollection services)
        {
            services.AddScoped<INavigationManager>(provider => new NavigationManagerAdapter(provider.GetRequiredService<NavigationManager>()));

            if (HybridSupport.IsElectronActive)
            {
                services.AddSingleton<List<ElectronWindow>>();
                services.AddScoped<ElectronWindowManager>();
                services.AddScoped<IWindowManager>(provider => provider.GetRequiredService<ElectronWindowManager>());
            }
            else
            {
                services.AddSingleton<List<WebBrowserWindow>>();
                services.AddScoped<WebBrowserTabManager>();
                services.AddScoped<IWindowManager>(provider => provider.GetRequiredService<WebBrowserTabManager>());
            }
        }
    }
}