using Microsoft.AspNetCore.Components;
using PoECommerce.Client.Shared;
using PoECommerce.Core.Model.Search;

namespace PoECommerce.Client.Components.Trade
{
    public class TradeContainerBase : ComponentBase
    {
        [Inject]
        public IPoECommerceFacade PoECommerceFacade { get; set; }

        public TradeSession TradeSession { get; set; }

        [Parameter]
        public string CurrentSessionId { get; set; }

        public void UpdateView(TradeSession trade)
        {
            TradeSession = trade;
        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();

            if (CurrentSessionId != null && PoECommerceFacade.Sessions.TryGetValue(CurrentSessionId, out TradeSession session))
            {
                TradeSession = session;
                StateHasChanged();
            }
        }
    }
}