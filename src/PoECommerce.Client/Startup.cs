using System;
using GregsStack.InputSimulatorStandard;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NLog;
using NLog.Web;
using PoECommerce.Client.Cache.TradeService;
using PoECommerce.Client.Shared;
using PoECommerce.Client.StartupExtensions.Electron;
using PoECommerce.PathOfExile.Extensions;
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
            });
            services.AddPathOfExileCoreServices();
            services.AddPathOfExileWindowsSupport();
            services.AddSingleton<IPoECommerceFacade, PoECommerceFacade>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime appLifetime, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts(); // The default HSTS value is 30 days. See https://aka.ms/aspnetcore-hsts.
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });

            app.UseElectronHybrid(appLifetime, serviceProvider);
        }
    }
}