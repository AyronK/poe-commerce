using System;
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
        private string _status;

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

        public string Status
        {
            get => _status;
            set
            {
                _status = value;
                Query.OnlineStatus = Enum.TryParse(_status, out OnlineStatus status) ? status : (OnlineStatus?) null;
            }
        }

        public void Clear()
        {
            Query = new Query();
            SearchText = null;
            League = "Blight";
            Status = OnlineStatus.Any.ToString();
            StateHasChanged();
        }

        public async Task Search()
        {
            SearchResult searchResult = await TradeService.Search(Query);
            OnSearch.InvokeAsync(searchResult).Wait();
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            Clear();
        }
    }
}
