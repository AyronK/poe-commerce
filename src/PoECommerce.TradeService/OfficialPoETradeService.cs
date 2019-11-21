using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using PoECommerce.TradeService.Extensions.Internal;
using PoECommerce.TradeService.Models.TradeAPI;

namespace PoECommerce.TradeService
{
    public class OfficialPoETradeService : ITradeService
    {
        private static readonly JsonSerializerOptions JsonOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            PropertyNameCaseInsensitive = false,
            IgnoreNullValues = true,
            Converters =
            {
                new JsonStringEnumConverter()
            }
        };

        private readonly HttpClient _httpClient;
        private readonly string _searchEndpoint;
        private readonly string _fetchEndpoint;

        internal const string HttpClientName = "pathofexile/trade";

        public string League { get; }

        public OfficialPoETradeService(IHttpClientFactory httpClient, string league)
        {
            League = league;
            _httpClient = httpClient.CreateClient(HttpClientName);

            _searchEndpoint = "/api/trade/search/" + league;
            _fetchEndpoint = "/api/trade/fetch/";
        }

        public async Task<QueryResult> Search(Query query)
        {
            string queryJson = JsonSerializer.Serialize(new QueryCommand(query), JsonOptions);
            StringContent body = new StringContent(queryJson, Encoding.UTF8, MediaTypeNames.Application.Json);

            HttpResponseMessage response = await _httpClient.PostAsync(_searchEndpoint, body);
            response.EnsureSuccessStatusCode();

            return await response.DeserializeResponseBody<QueryResult>(JsonOptions);
        }

        public async Task<FetchResult> Fetch(string queryId, string[] itemsIds)
        {
            string joinedIds = string.Join(',', itemsIds);

            QueryString queryString = new QueryString().Add("query", queryId);
            string url = _fetchEndpoint + joinedIds + queryString;

            HttpResponseMessage response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            return await response.DeserializeResponseBody<FetchResult>(JsonOptions);
        }
    }
}