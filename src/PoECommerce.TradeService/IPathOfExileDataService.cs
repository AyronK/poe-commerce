using System.Collections.Generic;
using System.Threading.Tasks;
using PoECommerce.PathOfExile.Models.Data;
using PoECommerce.PathOfExile.Models.Enums;

namespace PoECommerce.PathOfExile
{
    public interface IPathOfExileDataService
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