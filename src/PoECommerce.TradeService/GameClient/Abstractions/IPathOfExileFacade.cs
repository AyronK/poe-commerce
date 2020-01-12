using System.Threading.Tasks;
using PoECommerce.PathOfExile.Models.Trade.Items;

namespace PoECommerce.PathOfExile.GameClient.Abstractions
{
    public interface IPathOfExileFacade
    {
        /// <summary>
        ///     Path of Exile's in-game chat instance hook.
        /// </summary>
        IChat Chat { get; }

        Task<Item> GetItemOnCursor();
    }
}