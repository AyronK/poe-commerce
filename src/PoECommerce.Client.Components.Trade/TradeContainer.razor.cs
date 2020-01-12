using System;
using Microsoft.AspNetCore.Components;
using PoECommerce.Client.Shared;

namespace PoECommerce.Client.Components.Trade
{
    public class TradeContainerBase : ComponentBase, IDisposable
    {
        [Parameter]
        public bool IsCompact { get; set; }

        [Inject]
        public ITradeState TradeState { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            TradeState.OnNewSession += StateChangeEvent;
        }

        private async void StateChangeEvent(object sender, TradeSession session)
        {
            await InvokeAsync(StateHasChanged);
        }

        public void Dispose()
        {
            TradeState.OnNewSession -= StateChangeEvent;
        }
    }
}