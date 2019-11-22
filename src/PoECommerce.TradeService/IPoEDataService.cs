using System.Collections.Generic;
using System.Threading.Tasks;
using PoECommerce.TradeService.Models.Data;
using PoECommerce.TradeService.Models.Enums;

namespace PoECommerce.TradeService
{
    public interface IPoEDataService
    {
        /// <summary>
        ///     Fetches all currently running leagues.
        /// </summary>
        Task<League[]> GetLeagues();

        /// <summary>
        ///     Fetches metadata of item base types such uniques.
        /// </summary>
        Task<IReadOnlyDictionary<ItemCategory, Item[]>> GetItems();

        /// <summary>
        ///     Fetches metadata of item modifiers.
        /// </summary>
        Task<IReadOnlyDictionary<ModifierType, Modifier[]>> GetModifiers();

        /// <summary>
        ///     Fetches static data such as images url of item base types such as currency.
        /// </summary>
        Task<IReadOnlyDictionary<ItemCategory, StaticData[]>> GetStaticData();
    }
}