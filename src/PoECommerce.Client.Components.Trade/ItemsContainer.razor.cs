using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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

        [Inject]
        public IPoECommerceFacade PoECommerceFacade { get; set; }

        protected async Task OpenInAdvancedWindow()
        {
            await PoECommerceFacade.CloseCompactResults();
            await PoECommerceFacade.OpenAdvancedResults(TradeSession.Id);
        }
        protected async Task OpenInCompactWindow()
        {
            await PoECommerceFacade.CloseAdvancedResults();
            await PoECommerceFacade.OpenCompactResults(TradeSession.Id);
        }

        protected override async Task OnParametersSetAsync()
        {
            await base.OnParametersSetAsync();

            if (TradeSession == null)
            {
                return;
            }

            if (TradeSession.State == TradeSession.TradeSessionState.New)
            {
                await foreach (ListedItem _ in TradeSession.Begin())
                {
                    StateHasChanged();
                }
            }
            else if (TradeSession.State == TradeSession.TradeSessionState.Pending)
            {
                TradeSession.OnSessionClose += SessionClose;
                
                void SessionClose(object sender, EventArgs args)
                {
                    TradeSession.OnSessionClose -= SessionClose;
                    StateHasChanged();
                }
            }
        }
    }
}