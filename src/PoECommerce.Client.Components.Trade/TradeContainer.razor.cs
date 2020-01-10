using System;
using Microsoft.AspNetCore.Components;
using PoECommerce.Client.Shared;

namespace PoECommerce.Client.Components.Trade
{
    public class TradeContainerBase : ComponentBase
    {
        [Parameter]
        public bool IsCompact { get; set; }

        [Inject]
        public ITradeState TradeState { get; set; }
    }
}