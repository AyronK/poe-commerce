using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GregsStack.InputSimulatorStandard;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Server.Circuits;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NLog;
using NLog.Web;
using PoECommerce.Client.Cache.TradeService;
using PoECommerce.Client.Shared;
using PoECommerce.Client.StartupExtensions.Electron;
using PoECommerce.Core;
using PoECommerce.PathOfExile.Extensions;
using PoECommerce.PathOfExile.Web.Abstractions;
using PoECommerce.PathOfExile.Windows;
using PoECommerce.TradeService.PathOfExile.Extensions;

namespace PoECommerce.Client
{
    public class Startup
    {
        public const string LoggerName = "PoECommerce.Logger";
        private readonly ILogger _logger;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _logger = NLogBuilder.ConfigureNLog("nlog.config").GetLogger(LoggerName);
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddElectronHybrid();
            services.AddSingleton(_logger);
            services.AddSingleton<IInputSimulator, InputSimulator>();

            // PoE related registrations
            services.AddPathOfExileApiServices(cfg =>
            {
                cfg.DataServiceSettings.Scope = RegistrationType.Singleton;
                cfg.DataServiceSettings.Factory = factory => new CachedDataService(factory);
                cfg.LocalStorageDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "The Wraeclast", "PoE Commerce", "data");
            });
            services.AddPathOfExileCoreServices();
            services.AddPathOfExileWindowsSupport();
            services.AddPathOfExileGameClientServices(async () =>
            {
                try
                {
                    return await ElectronNET.API.Electron.Clipboard.ReadTextAsync();
                }
                catch
                {
                    return string.Empty;
                }
            });
            services.AddSingleton<ITradeState, TradeState>(provider => new TradeState(provider.GetService<ITradeService>));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime appLifetime, IServiceProvider serviceProvider)
        {
            app.UseHsts(); // The default HSTS value is 30 days. See https://aka.ms/aspnetcore-hsts.
            
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });

            app.UseElectronHybrid(appLifetime, serviceProvider);
            IPathOfExileDataService dataService = app.ApplicationServices.GetService<IPathOfExileDataService>();

            Task[] loadingTasks = { dataService.GetItems(), dataService.GetLeagues(), dataService.GetModifiers() };
            Task.WaitAll(loadingTasks);
            //cachedDataService.GetStaticData();
        }
    }
}