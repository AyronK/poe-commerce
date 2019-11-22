using System;
using Microsoft.Extensions.DependencyInjection;

namespace PoECommerce.Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionServiceExtensions
    {
        public static void RegisterDecorator<TService>(this IServiceCollection services, RegistrationType registrationType, ServiceSettings<TService> settings) where TService : class
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