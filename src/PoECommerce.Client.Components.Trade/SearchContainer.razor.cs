using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using PoECommerce.Core;
using PoECommerce.Core.Model.Search;

namespace PoECommerce.Client.Components.Trade
{
    public class SearchContainerBase : ComponentBase
    {
        private string _league;
        private string _searchText;
        private OnlineStatus _status;

        [Inject]
        public ITradeService TradeService { get; set; }

        [Parameter]
        public EventCallback<SearchResult> OnSearch { get; set; }

        public Query Query { get; set; } = new Query();

        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                Query.Text = value;
            }
        }

        public string League
        {
            get => _league;
            set
            {
                _league = value;
                Query.League = value;
            }
        }

        public OnlineStatus Status
        {
            get => _status;
            set
            {
                _status = value;
                Query.OnlineStatus = value;
            }
        }

        public void Clear()
        {
            Query = new Query();
            SearchText = null;
            League = "Blight";
            Status = OnlineStatus.Any;
            StateHasChanged();
        }

        public async Task Search()
        {
            SearchResult searchResult = await TradeService.Search(Query);
            OnSearch.InvokeAsync(searchResult).Wait();
        }
    }
}
