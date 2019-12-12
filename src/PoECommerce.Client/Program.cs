using System;
using ElectronNET.API;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Web;

namespace PoECommerce.Client
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Logger logger = NLogBuilder.ConfigureNLog("nlog.config").GetLogger(Startup.LoggerName);

            try
            {
                logger.Debug("PoE Commerce is starting..");

                Host.CreateDefaultBuilder(args)
                    .ConfigureLogging(logging =>
                    {
                        logging.ClearProviders();
                        logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
                    })
                    .ConfigureWebHostDefaults(webBuilder =>
                    {
                        webBuilder.UseElectron(args);
                        webBuilder.UseStaticWebAssets();
                        webBuilder.UseStartup<Startup>();
                    })
                    .Build()
                    .Run();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "PoE Commerce start up error");
                if (HybridSupport.IsElectronActive)
                {
                    ElectronNET.API.Electron.App.Exit(1);
                }
            }
            finally
            {
                LogManager.Shutdown();
                if (HybridSupport.IsElectronActive)
                {
                    ElectronNET.API.Electron.App.Exit();
                }
            }
        }
    }
}