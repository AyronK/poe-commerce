using System;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using PoECommerce.TradeService.Extensions.Internal;
using PoECommerce.TradeService.Models;
using PoECommerce.TradeService.Models.Search;
using PoECommerce.TradeService.Models.Trade;

namespace PoECommerce.TradeService.PathOfExile.Trade
{
    internal class PathOfExileTradeService : PathOfExileHttpServiceBase, IPoETradeService
    {
        private const string FetchEndpoint = "/api/trade/fetch/";
        private const string SearchEndpoint = "/api/trade/search/";

        internal PathOfExileTradeService(IHttpClientFactory httpClient, string league) : base(httpClient)
        {
            League = !string.IsNullOrWhiteSpace(league) ? league : throw new ArgumentException($"'{nameof(PathOfExileTradeService)} argument {nameof(league)} is null/empty/whitespace.", nameof(league));
        }

        public string League { get; }

        public async Task<QueryResult> Search(Query query)
        {
            string queryJson = JsonSerializer.Serialize(new QueryCommand(query), JsonOptions);
            StringContent body = new StringContent(queryJson, Encoding.UTF8, MediaTypeNames.Application.Json);

            HttpResponseMessage response = await HttpClient.PostAsync(SearchEndpoint + League, body);
            response.EnsureSuccessStatusCode();

            return await response.DeserializeResponseBody<QueryResult>(JsonOptions);
        }

        public async Task<ListedItem[]> Fetch(string queryId, string[] itemsIds)
        {
            string joinedIds = string.Join(',', itemsIds);

            QueryString queryString = new QueryString().Add("query", queryId);
            string url = FetchEndpoint + joinedIds + queryString;

            HttpResponseMessage response = await HttpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            ResponseResult<ListedItem[]> responseResult = await response.DeserializeResponseBody<ResponseResult<ListedItem[]>>(JsonOptions);
            return responseResult.Result;
        }
    }
}