using System;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;

namespace PoECommerce.TradeService.Extensions
{
    public static class TradeServiceRegistrationExtensions
    {
        public static void AddPathOfExileTradeService(this IServiceCollection services, Func<string> leagueNameFactory)
        {
            services.AddHttpClient(OfficialPoETradeService.HttpClientName, c =>
            {
                c.BaseAddress = new Uri("https://www.pathofexile.com");
            });

            services.AddScoped<ITradeService>(provider =>
            {
                IHttpClientFactory httpClientFactory = provider.GetRequiredService<IHttpClientFactory>();
                return new OfficialPoETradeService(httpClientFactory, leagueNameFactory());
            });
        }
    }
}