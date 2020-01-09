using System.Collections.Generic;
using System.Threading.Tasks;
using PoECommerce.Core.Model.Search;
using PoECommerce.PathOfExile.GameClient.Abstractions;

namespace PoECommerce.Client.Shared
{
    public interface IPoECommerceFacade
    {
        IPathOfExileFacade PathOfExile { get; }

        IReadOnlyDictionary<string, TradeSession> Sessions { get; }

        TradeSession SearchItems(Query query);

        Task OpenCompactResults(string tradeSessionId = null);

        Task OpenAdvancedResults(string tradeSessionId = null);
    }
}