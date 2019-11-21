using System;
using ElectronNET.API;
using ElectronNET.API.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NLog;
using PoECommerce.Client.Electron;
using PoECommerce.Client.Shared.Display;
using PoECommerce.Client.WebBrowser;

namespace PoECommerce.Client.StartupExtensions.Electron
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseElectronHybrid(this IApplicationBuilder applicationBuilder, IHostApplicationLifetime appLifetime, IServiceProvider serviceProvider)
        {
            ILogger logger = serviceProvider.GetService<ILogger>();

            appLifetime.ApplicationStarted.Register(() =>
            {
                logger.Debug("PoE Commerce started.");
                
                if (HybridSupport.IsElectronActive)
                {
                    logger.Debug("Electron mode is active.");
                    logger.Debug("Opening main window...");
                    applicationBuilder.ApplicationServices.GetService<IWindowManager>().Show(0).Wait();
                    logger.Debug("Main window opened.");
                }
            });

            appLifetime.ApplicationStopped.Register(() =>
            {
                if (HybridSupport.IsElectronActive)
                {
                    ElectronNET.API.Electron.App.Exit();
                    logger.Debug("PoE Commerce called electron an exit request.");
                }

                logger.Debug("PoE Commerce exited with exit code 0.");
            });

            if (HybridSupport.IsElectronActive)
            {
                ElectronWindowManager manager = serviceProvider.GetService<ElectronWindowManager>();

                manager.AddWindow(new ElectronWindow(0, new BrowserWindowOptions
                {
                    Show = false,
                    Frame = true,
                }));

                manager.AddWindow(new ElectronWindow(1, new BrowserWindowOptions
                {
                    Transparent = true,
                    Show = false,
                    Frame = false,
                    AlwaysOnTop = true,
                    HasShadow = false,
                    SkipTaskbar = true,
                    Resizable = false,
                    Movable = false,
                }, "/TestPage1"));

                manager.AddWindow(new ElectronWindow(2, new BrowserWindowOptions
                {
                    Show = false
                }, "/TestPage2"));
            }
            else
            {
                WebBrowserTabManager manager = serviceProvider.GetService<WebBrowserTabManager>();
                manager.AddWindow(new WebBrowserWindow(0));
                manager.AddWindow(new WebBrowserWindow(1, "/TestPage1"));
                manager.AddWindow(new WebBrowserWindow(2, "/TestPage2"));
            }

            return applicationBuilder;
        }
    }
}