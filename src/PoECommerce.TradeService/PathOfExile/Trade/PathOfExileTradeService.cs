using System;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using PoECommerce.PathOfExile.Extensions.Internal;
using PoECommerce.PathOfExile.Models;
using PoECommerce.PathOfExile.Models.Search;
using PoECommerce.PathOfExile.Models.Trade;

namespace PoECommerce.PathOfExile.PathOfExile.Trade
{
    internal class PathOfExileTradeService : PathOfExileHttpServiceBase, IPathOfExileTradeService
    {
        private const string FetchEndpoint = "/api/trade/fetch/";
        private const string SearchEndpoint = "/api/trade/search/";

        internal PathOfExileTradeService(IHttpClientFactory httpClient) : base(httpClient)
        {

        }

        public async Task<QueryResult> Search(Query query, string league)
        {
            string queryJson = JsonSerializer.Serialize(new QueryCommand(query), JsonOptions);
            StringContent body = new StringContent(queryJson, Encoding.UTF8, MediaTypeNames.Application.Json);

            HttpResponseMessage response = await HttpClient.PostAsync(SearchEndpoint + league, body);
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