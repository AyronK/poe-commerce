using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using PoECommerce.Core;
using PoECommerce.Core.Model.Search;

namespace PoECommerce.Client.Components.Trade
{
    public class FiltersContainerBase : ComponentBase
    {
        private string _league;
        private string _searchText;
        private string _status;
        private bool _test;

        public bool Test
        {
            get => _test;
            set
            {
                _test = value;
                StateHasChanged();
            }
        }

        [Inject]
        public ITradeService TradeService { get; set; }

        [Parameter]
        public EventCallback<SearchResult> OnSearch { get; set; }

        public Query Query { get; set; } = new Query();

        public string[] SearchAutocompleteValues { get; set; } =
        {
            "Voideye Unset Ring",
            "Voidheart Iron Ring",
            "Null and Void Legion Gloves",
            "Voidbringer Conjurer Gloves",
            "Voidwalker Murder Boots",
            "The Void",
            "Voidforge Infernal Sword",
            "Empower",
            "Static Strike",
        };

        public IEnumerable<string> SearchTooltipValues { get; set; } = new List<string>();

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
                Query.OnlineStatus = Enum.TryParse(_status, out OnlineStatus status) ? status : (OnlineStatus?)null;
            }
        }

        public void Clear()
        {
            Query = new Query();
            SearchText = null;
            League = "Blight";
            Status = OnlineStatus.Online.ToString();
            StateHasChanged();
        }

        public async Task Search()
        {
            SearchResult searchResult = await TradeService.Search(Query);
            OnSearch.InvokeAsync(searchResult).Wait();
        }

        public void OnSearchTextChange(ChangeEventArgs changeEventArgs)
        {
            string value = changeEventArgs.Value.ToString();
            SearchTooltipValues = SearchAutocompleteValues.Where(v => v.IndexOf(value, StringComparison.InvariantCultureIgnoreCase) >= 0)
                .OrderByDescending(v => v.StartsWith(value, StringComparison.InvariantCultureIgnoreCase))
                .ThenBy(v => v)
                .Take(5);
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            Clear();
        }
    }
}