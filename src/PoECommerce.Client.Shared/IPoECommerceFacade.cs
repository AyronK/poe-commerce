using System;
using System.Collections.Generic;
using PoECommerce.Core.Model.Search;

namespace PoECommerce.Client.Shared
{
    public interface ITradeState
    {
        IReadOnlyDictionary<string, TradeSession> Sessions { get; }

        bool IsCompact { get; set; }
        bool IsVisible { get; set; }

        event EventHandler<bool> OnIsCompactChanged;
        event EventHandler<bool> OnIsVisibleChanged;
        TradeSession SearchItems(Query query);
        TradeSession CurrentTradeSession { get; }
    }
}