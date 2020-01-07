using System;
using System.Collections.Generic;
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

                Display display = ElectronNET.API.Electron.Screen.GetPrimaryDisplayAsync().Result;
                int width = display.Bounds.Width;
                int height = display.Bounds.Height;

                int overlayWidth = 60;
                int overlayHeight = 50;

                int padding = 10;

                manager.AddWindow(new ElectronWindow(0, new BrowserWindowOptions
                {
                    Transparent = true,
                    Show = false,
                    Frame = false,
                    AlwaysOnTop = true,
                    Movable = false,
                    Resizable = false,
                    Closable = true,
                    Width = overlayWidth,
                    X = width - overlayWidth - padding,
                    Height = overlayHeight,
                    Y = height - overlayHeight - padding,
                    SkipTaskbar = true,
                }));

                manager.AddWindow(new ElectronWindow(1, new BrowserWindowOptions
                {
                    Transparent = true,
                    Show = false,
                    Frame = false,
                    AlwaysOnTop = true,
                    HasShadow = false,
                    Resizable = false,
                    Movable = true,
                    Closable = true,
                    Minimizable = true,
                    Width = 800,
                    Height = 800,
                    X = width - 800,
                    Y = (height / 2) - 400,
                    SkipTaskbar = true,
                }, "/Trade"));

                manager.AddWindow(new ElectronWindow(2, new BrowserWindowOptions
                {
                    Transparent = true,
                    Show = false,
                    Frame = false,
                    AlwaysOnTop = true,
                    HasShadow = false,
                    Resizable = false,
                    Minimizable = true,
                    Movable = true,
                    Closable = true,
                    Width = 400,
                    Height = 200,
                    X = width - 400,
                    Y = (height / 2) - 200,
                    SkipTaskbar = true,
                }, "/CompactTrade"));

#if !DEBUG
                ElectronNET.API.Electron.Menu.SetApplicationMenu(new MenuItem[0]);
#endif
            }
            else
            {
                WebBrowserTabManager manager = serviceProvider.GetService<WebBrowserTabManager>();
                manager.AddWindow(new WebBrowserWindow(0, "/"));
                manager.AddWindow(new WebBrowserWindow(1, "/Trade"));
                manager.AddWindow(new WebBrowserWindow(2, "/CompactTrade"));
            }

            return applicationBuilder;
        }
    }
}