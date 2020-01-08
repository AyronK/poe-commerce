using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using PoECommerce.Client.Shared;
using PoECommerce.Core.Model.Trade;

namespace PoECommerce.Client.Components.Trade
{
    public class ItemsContainerBase : ComponentBase
    {
        [Parameter]
        public bool IsCompact { get; set; }

        [Parameter]
        public bool ShowSummary { get; set; }

        [Parameter]
        public TradeSession TradeSession { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            await base.OnParametersSetAsync();

            if (TradeSession != null && TradeSession.State == TradeSession.TradeSessionState.New)
            {
                await foreach (ListedItem _ in TradeSession.Begin())
                {
                    StateHasChanged();
                }
            }
        }
    }
}