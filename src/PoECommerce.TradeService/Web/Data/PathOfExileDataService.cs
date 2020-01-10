using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using PoECommerce.PathOfExile.Models;
using PoECommerce.PathOfExile.Models.Data;
using PoECommerce.PathOfExile.Models.Enums;
using PoECommerce.PathOfExile.Web.Abstractions;

namespace PoECommerce.PathOfExile.Web.Data
{
    internal class PathOfExileDataService : PathOfExileHttpServiceBase, IPathOfExileDataService
    {
        private const string ItemsEndpoint = "/api/trade/data/items";
        private const string LeaguesEndpoint = "/api/trade/data/leagues";
        private const string StaticEndpoint = "/api/trade/data/static";
        private const string StatsEndpoint = "/api/trade/data/stats";

        private readonly string _rootDirectoryPath;

        internal PathOfExileDataService(IHttpClientFactory httpClient, string storageDirectoryPath) : base(httpClient)
        {
            _rootDirectoryPath = storageDirectoryPath ?? throw new ArgumentNullException(nameof(storageDirectoryPath));

            if (!Directory.Exists(_rootDirectoryPath))
            {
                Directory.CreateDirectory(_rootDirectoryPath);
            }
        }

        public async Task<League[]> GetLeagues()
        {
            string json = await LoadJsonFromFileOrWeb("leagues.json", LeaguesEndpoint);
            ResponseResult<League[]> responseResult = JsonSerializer.Deserialize<ResponseResult<League[]>>(json, JsonOptions);

            return responseResult.Result;
        }

        public async Task<IReadOnlyDictionary<ItemCategory, Item[]>> GetItems()
        {
            string json = await LoadJsonFromFileOrWeb("items.json", ItemsEndpoint);
            ResponseResult<ItemsDataResult[]> responseResult = JsonSerializer.Deserialize<ResponseResult<ItemsDataResult[]>>(json, JsonOptions);
            Dictionary<ItemCategory, Item[]> result = responseResult.Result.ToDictionary(r => r.Category, r => r.Items);

            return result;
        }

        public async Task<IReadOnlyDictionary<ModifierType, Modifier[]>> GetModifiers()
        {
            string json = await LoadJsonFromFileOrWeb("modifiers.json", StatsEndpoint);
            ResponseResult<ModifiersDataResult[]> responseResult = JsonSerializer.Deserialize<ResponseResult<ModifiersDataResult[]>>(json, JsonOptions);
            Dictionary<ModifierType, Modifier[]> result = responseResult.Result.ToDictionary(r => r.ModifierType, r => r.Modifiers);

            return result;
        }

        public async Task<IReadOnlyDictionary<ItemCategory, StaticData[]>> GetStaticData()
        {
            string json = await LoadJsonFromFileOrWeb("static.json", StaticEndpoint);
            StaticDataResponseResult responseResult = JsonSerializer.Deserialize<StaticDataResponseResult>(json, JsonOptions);

            foreach (KeyValuePair<ItemCategory, StaticData[]> keyValuePair in responseResult.Result)
            {
                foreach (StaticData staticData in keyValuePair.Value)
                {
                    if (!string.IsNullOrEmpty(staticData.Image))
                    {
                        staticData.Image = new Uri(PathOfExileConfiguration.BaseAddress + staticData.Image.TrimStart('/')).AbsoluteUri;
                    }
                }
            }

            return new ReadOnlyDictionary<ItemCategory, StaticData[]>(responseResult.Result);
        }

        private async Task<string> LoadJsonFromFileOrWeb(string fileName, string endpoint)
        {
            if (!(await GetFromFile(fileName) is string json))
            {
                HttpResponseMessage response = await HttpClient.GetAsync(endpoint);
                response.EnsureSuccessStatusCode();

                json = await response.Content.ReadAsStringAsync();
            }

            await SaveToFile(fileName, json);
            return json;
        }

        private async Task<string> GetFromFile(string fileName)
        {
            string path = Path.Combine(_rootDirectoryPath, fileName);

            try
            {
                if (!File.Exists(path))
                {
                    return null;
                }

                return await File.ReadAllTextAsync(path);
            }
            catch (Exception ex) when (ex is IOException || ex is JsonException)
            {
                return null;
            }
        }

        private async Task SaveToFile(string fileName, string json)
        {
            string path = Path.Combine(_rootDirectoryPath, fileName);

            try
            {
                await File.WriteAllTextAsync(path, json);
            }
            catch (Exception ex) when (ex is IOException || ex is JsonException)
            {
            }
        }
    }
}