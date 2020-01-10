using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using PoECommerce.Core;
using PoECommerce.PathOfExile.Models.Data;
using PoECommerce.PathOfExile.Models.Enums;
using PoECommerce.PathOfExile.Web.Abstractions;
using PoECommerce.TradeService.PathOfExile.Mappers;
using CoreModels = PoECommerce.Core.Model.Data;

namespace PoECommerce.TradeService.PathOfExile
{
    internal class PathOfExileStaticDataService : IStaticDataService
    {
        private readonly IPathOfExileDataService _dataService;
        private readonly IMapperFacade _mapper;

        public PathOfExileStaticDataService(IMapperFacade mapper, IPathOfExileDataService dataService)
        {
            _mapper = mapper;
            _dataService = dataService;
        }

        public async Task<CoreModels.League[]> GetLeagues()
        {
            League[] result = await _dataService.GetLeagues();

            return result.Select(_mapper.Map).ToArray();
        }

        public async Task<IReadOnlyDictionary<CoreModels.ModifierType, CoreModels.Modifier[]>> GetModifiers()
        {
            IReadOnlyDictionary<ModifierType, Modifier[]> result = await _dataService.GetModifiers();

            return new ReadOnlyDictionary<CoreModels.ModifierType, CoreModels.Modifier[]>(result.ToDictionary(kv => _mapper.Map(kv.Key), kv => kv.Value.Select(_mapper.Map).ToArray()));
        }

        public async Task<IReadOnlyDictionary<CoreModels.ItemCategory, CoreModels.Item[]>> GetItems()
        {
            IReadOnlyDictionary<ItemCategory, Item[]> result = await _dataService.GetItems();

            return new ReadOnlyDictionary<CoreModels.ItemCategory, CoreModels.Item[]>(result.ToDictionary(kv => _mapper.Map(kv.Key), kv => kv.Value.Select(v => _mapper.Map(new KeyValuePair<ItemCategory, Item>(kv.Key, v))).ToArray()));
        }
    }
}