using System.Collections.Generic;
using System.Threading.Tasks;
using PoECommerce.Core.Model.Data;

namespace PoECommerce.Core
{
    public interface IStaticDataService
    {
        /// <summary>
        ///     Fetches all currently running leagues.
        /// </summary>
        Task<League[]> GetLeagues();

        /// <summary>
        ///     Fetches metadata of item modifiers.
        /// </summary>
        Task<IReadOnlyDictionary<ModifierType, Modifier[]>> GetModifiers();

        /// <summary>
        ///     Fetches metadata of item base types such uniques.
        /// </summary>
        Task<IReadOnlyDictionary<ItemCategory, Item[]>> GetItems();
    }
}