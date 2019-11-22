using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using PoECommerce.TradeService.Extensions.Internal;
using PoECommerce.TradeService.Models;
using PoECommerce.TradeService.Models.Data;
using PoECommerce.TradeService.Models.Enums;

namespace PoECommerce.TradeService.PathOfExile.Data
{
    internal class PathOfExileDataService : PathOfExileHttpServiceBase, IPoEDataService
    {
        private const string ItemsEndpoint = "/api/trade/data/items";
        private const string LeaguesEndpoint = "/api/trade/data/leagues";
        private const string StaticEndpoint = "/api/trade/data/static";
        private const string StatsEndpoint = "/api/trade/data/stats";

        internal PathOfExileDataService(IHttpClientFactory httpClient) : base(httpClient)
        {
        }

        public async Task<League[]> GetLeagues()
        {
            HttpResponseMessage response = await HttpClient.GetAsync(LeaguesEndpoint);
            response.EnsureSuccessStatusCode();

            ResponseResult<League[]> responseResult = await response.DeserializeResponseBody<ResponseResult<League[]>>(JsonOptions);

            return responseResult.Result;
        }

        public async Task<IReadOnlyDictionary<ItemCategory, Item[]>> GetItems()
        {
            HttpResponseMessage response = await HttpClient.GetAsync(ItemsEndpoint);
            response.EnsureSuccessStatusCode();

            ResponseResult<ItemsDataResult[]> responseResult = await response.DeserializeResponseBody<ResponseResult<ItemsDataResult[]>>(JsonOptions);
            Dictionary<ItemCategory, Item[]> result = responseResult.Result.ToDictionary(r => r.Category, r => r.Items);

            return result;
        }

        public async Task<IReadOnlyDictionary<ModifierType, Modifier[]>> GetModifiers()
        {
            HttpResponseMessage response = await HttpClient.GetAsync(StatsEndpoint);
            response.EnsureSuccessStatusCode();

            ResponseResult<ModifiersDataResult[]> responseResult = await response.DeserializeResponseBody<ResponseResult<ModifiersDataResult[]>>(JsonOptions);
            Dictionary<ModifierType, Modifier[]> result = responseResult.Result.ToDictionary(r => r.ModifierType, r => r.Modifiers);

            return result;
        }

        public async Task<IReadOnlyDictionary<ItemCategory, StaticData[]>> GetStaticData()
        {
            HttpResponseMessage response = await HttpClient.GetAsync(StaticEndpoint);
            response.EnsureSuccessStatusCode();

            StaticDataResponseResult responseResult = await response.DeserializeResponseBody<StaticDataResponseResult>(JsonOptions);

            foreach (KeyValuePair<ItemCategory, StaticData[]> keyValuePair in responseResult.Result)
            {
                foreach (StaticData staticData in keyValuePair.Value)
                {
                    staticData.Image = new Uri(PathOfExileConfiguration.BaseAddress + staticData.Image.TrimStart('/')).AbsoluteUri;
                }
            }

            return new ReadOnlyDictionary<ItemCategory, StaticData[]>(responseResult.Result);
        }
    }
}