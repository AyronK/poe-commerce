using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using PoECommerce.Client.Shared;
using PoECommerce.Core.Model.Search;
using PoECommerce.Core.Model.Trade;

namespace PoECommerce.Client.Components.Trade
{
    public class TradeContainerBase : ComponentBase
    {
        public TradeSession TradeSession { get; set; }

        public void UpdateView(TradeSession trade)
        {
            TradeSession = trade;
        }
    }
}