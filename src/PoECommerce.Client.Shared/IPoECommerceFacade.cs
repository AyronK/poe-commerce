using System.Collections.Generic;
using PoECommerce.Core.Model.Search;
using PoECommerce.Core.Model.Trade;
using PoECommerce.PathOfExile;
using PoECommerce.PathOfExile.GameClient.Abstractions;

namespace PoECommerce.Client.Shared
{
    public interface IPoECommerceFacade
    {
        IPathOfExileFacade PathOfExile { get; }

        void ClearSession();

        TradeSession CurrentTradeSession { get; }

        TradeSession SearchItems(Query query);
    }
}