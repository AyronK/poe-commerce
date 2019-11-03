using ElectronNET.API;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NLog;
using NLog.Web;

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
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime appLifetime)
        {
            appLifetime.ApplicationStarted.Register(async () =>
            {
                _logger.Debug("PoE Commerce started.");

                if (HybridSupport.IsElectronActive)
                {
                    _logger.Debug("Electron mode is active.");
                    _logger.Debug("Opening main window...");

                    await Electron.WindowManager.CreateWindowAsync();
                    _logger.Debug("Main window opened.");
                }
            });

            appLifetime.ApplicationStopped.Register(() =>
            {
                if (HybridSupport.IsElectronActive)
                {
                    Electron.App.Exit();
                    _logger.Debug("PoE Commerce called electron an exit request.");
                }

                _logger.Debug("PoE Commerce exited with exit code 0.");
            });

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
        }
    }
}