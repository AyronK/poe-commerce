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
        public ITradeState TradeState { get; set; }

        protected void OpenInAdvancedWindow()
        {
            TradeState.IsCompact = false;
        }

        protected void OpenInCompactWindow()
        {
            TradeState.IsCompact = true;
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
                await Task.Run(async () =>
                 {
                     await foreach (ListedItem _ in TradeSession.Begin())
                     {
                         await InvokeAsync(StateHasChanged);
                     }
                 });
            }
        }
    }
}