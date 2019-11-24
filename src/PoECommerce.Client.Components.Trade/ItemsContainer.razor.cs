using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using PoECommerce.Core;
using PoECommerce.Core.Model.Search;

namespace PoECommerce.Client.Components.Trade
{
    public class ItemsContainerBase : ComponentBase
    {
        [Parameter]
        public SearchResult SearchResult { get; set; }

        public List<ListedItem> ListedItems { get; set; } = new List<ListedItem>();

        [Inject]
        public ITradeService TradeService { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            if (SearchResult?.ItemIds?.Any() == true)
            {
                string[] ids = SearchResult.ItemIds.Take(5).ToArray();
                ListedItem[] items = await TradeService.Fetch(SearchResult.QueryId, ids);
                ListedItems.AddRange(items);
                StateHasChanged();
            }
            else
            {
                ListedItems.Clear();
            }
        }
    }
}