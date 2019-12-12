using System;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using PoECommerce.PathOfExile.PathOfExile;
using PoECommerce.PathOfExile.PathOfExile.Data;
using PoECommerce.PathOfExile.PathOfExile.Trade;

namespace PoECommerce.PathOfExile.Extensions
{
    public static class PathOfExileRegistrationExtensions
    {
        /// <summary>
        ///     Registers official Path of Exile API services for low level data operations.
        /// </summary>
        public static void AddPathOfExileApiServices(this IServiceCollection services, Action<RegistrationConfiguration> configure)
        {
            RegistrationConfiguration configuration = new RegistrationConfiguration();
            configure?.Invoke(configuration);

            services.AddHttpClient(PathOfExileConfiguration.HttpClientName, c =>
            {
                c.BaseAddress =  PathOfExileConfiguration.BaseAddress;
            });

            AddPathOfExileTradeService(services, configuration);
            AddPathOfExileDataService(services, configuration);
        }

        private static void AddPathOfExileDataService(IServiceCollection services, RegistrationConfiguration configuration)
        {
            // register implementation
            services.AddTransient(provider =>
            {
                IHttpClientFactory httpClientFactory = provider.GetRequiredService<IHttpClientFactory>();
                return new PathOfExileDataService(httpClientFactory);
            });

            // register interface with configurable scope and implementation decorator
            services.RegisterService(configuration.DataServiceSettings.Scope, provider =>
            {
                return configuration.DataServiceSettings.Factory
                           ?.Invoke(provider.GetService<PathOfExileDataService>)
                       ?? provider.GetService<PathOfExileDataService>();
            });
        }

        private static void AddPathOfExileTradeService(IServiceCollection services, RegistrationConfiguration configuration)
        {
            // register implementation
            services.AddTransient(provider =>
            {
                IHttpClientFactory httpClientFactory = provider.GetRequiredService<IHttpClientFactory>();
                return new PathOfExileTradeService(httpClientFactory);
            });

            // register interface with configurable scope and implementation decorator
            services.RegisterService(configuration.TradeServiceSettings.Scope, provider =>
            {
                return configuration.TradeServiceSettings.Factory
                           ?.Invoke(provider.GetService<PathOfExileTradeService>)
                       ?? provider.GetService<PathOfExileTradeService>();
            });
        }

        private static void RegisterService<TService>(this IServiceCollection services, RegistrationType registrationType, Func<IServiceProvider, TService> factory) where TService : class
        {
            switch (registrationType)
            {
                case RegistrationType.Transient:
                    services.AddTransient<TService, TService>(factory);
                    break;
                case RegistrationType.Scoped:
                    services.AddScoped<TService, TService>(factory);
                    break;
                case RegistrationType.Singleton:
                    services.AddSingleton<TService, TService>(factory);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}