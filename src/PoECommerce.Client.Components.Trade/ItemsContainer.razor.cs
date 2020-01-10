using System;
using System.Threading;
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
                await foreach (ListedItem _ in TradeSession.Begin())
                {
                    await InvokeAsync(StateHasChanged);
                }
            }
            else
            {
                CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
                cancellationTokenSource.CancelAfter(5000);

                await Task.Run(async () =>
                {
                    while (TradeSession.State != TradeSession.TradeSessionState.Closed)
                    {
                        await Task.Delay(100, cancellationTokenSource.Token);
                        await InvokeAsync(StateHasChanged);
                    }
                }, cancellationTokenSource.Token);
            }
        }
    }
}