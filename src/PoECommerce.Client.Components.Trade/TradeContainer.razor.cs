using Microsoft.AspNetCore.Components;
using PoECommerce.Core.Model.Search;

namespace PoECommerce.Client.Components.Trade
{
    public class TradeContainerBase : ComponentBase
    {
        private SearchResult _searchResult;

        public SearchResult SearchResult
        {
            get => _searchResult;
            set
            {
                _searchResult = value;
                StateHasChanged();
            }
        }
    }
}