using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PoECommerce.TradeService.PathOfExile
{
    internal abstract class PathOfExileHttpServiceBase
    {
        protected static readonly JsonSerializerOptions JsonOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            PropertyNameCaseInsensitive = false,
            IgnoreNullValues = true,
            Converters =
            {
                new JsonStringEnumConverter()
            }
        };

        protected PathOfExileHttpServiceBase(IHttpClientFactory httpClient)
        {
            HttpClient = httpClient.CreateClient(PathOfExileConfiguration.HttpClientName);

            if (HttpClient?.BaseAddress != PathOfExileConfiguration.BaseAddress)
            {
                throw new ArgumentException($"Failed to initialize {nameof(System.Net.Http.HttpClient)} with base address '{PathOfExileConfiguration.BaseAddress}'", nameof(httpClient));
            }
        }

        protected HttpClient HttpClient { get; }
    }
}