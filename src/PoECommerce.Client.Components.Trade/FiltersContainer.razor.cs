using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using PoECommerce.Core;
using PoECommerce.Core.Model.Data;
using PoECommerce.Core.Model.Search;
using Item = PoECommerce.Core.Model.Data.Item;

namespace PoECommerce.Client.Components.Trade
{
    public class FiltersContainerBase : ComponentBase
    {
        private string _league;
        private string _searchText;
        private string _status;
        private bool _isFiltersSectionOpen = false;

        [Inject]
        public ITradeService TradeService { get; set; }

        [Inject]
        public IStaticDataService DataService { get; set; }

        public League[] Leagues { get; set; } = new League[0];

        [Parameter]
        public EventCallback<SearchResult> OnSearch { get; set; }

        public Query Query { get; set; } = new Query();

        protected IEnumerable<Item> Items { get; set; } = new Item[0];

        public IEnumerable<Item> SearchTooltipValues { get; set; } = new Item[0];

        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;

                if (Items.FirstOrDefault(i => i.GetHashCode().ToString().Equals(value, StringComparison.InvariantCultureIgnoreCase)) is Item matchedItem)
                {
                    Query.Type = matchedItem.Type;
                    Query.Name = matchedItem.Name;
                    Query.Text = null;
                }
                else
                {
                    Query.Type = null;
                    Query.Name = null;
                    Query.Text = value;
                }
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

        public void ToggleFilter()
        {
            IsFiltersSectionOpen = !IsFiltersSectionOpen;
        }

        public void Clear()
        {
            InitModels();
            SearchText = null;
            League = Leagues[0].Id;
            Status = OnlineStatus.Online.ToString();
            StateHasChanged();
        }

        public async Task Search()
        {
            OnSearch.InvokeAsync(null).Wait();
            SearchResult searchResult = await TradeService.Search(Query);
            OnSearch.InvokeAsync(searchResult).Wait();
        }

        public void OnSearchTextChange(ChangeEventArgs changeEventArgs)
        {
            string value = changeEventArgs.Value.ToString();
            SearchTooltipValues = Items.Where(v => v.Name?.IndexOf(value, StringComparison.InvariantCultureIgnoreCase) >= 0 || v.Type?.IndexOf(value, StringComparison.InvariantCultureIgnoreCase) >= 0)
                .OrderBy(v => v.IsUnique)
                .ThenBy(v => v.IsProphecy)
                .ThenBy(v => v.ItemCategory)
                .ThenBy(v => v.Name?.StartsWith(value, StringComparison.InvariantCultureIgnoreCase) ?? v.Type.StartsWith(value, StringComparison.InvariantCultureIgnoreCase))
                .ThenBy(v => v.Name ?? v.Type)
                .ThenBy(v => v.Disclaimer)
                .Take(50);
        }

        public bool IsFiltersSectionOpen
        {
            get => _isFiltersSectionOpen;
            set
            {
                _isFiltersSectionOpen = value;
                StateHasChanged();
            }
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            InitModels();
            Leagues = await DataService.GetLeagues();
            Items = (await DataService.GetItems()).SelectMany(m => m.Value).ToArray();
            Clear();
        }

        private void InitModels()
        {
            Query = new Query
            {
                TypeFilter = new TypeFilter(),
                TradeFilter = new TradeFilter
                {
                    SaleType = SaleType.Priced
                },
                WeaponFilter = new WeaponsFilter(),
                ModifiersFilter = new ModifiersFilter(),
                ArmourFilter = new ArmoursFilter(),
                MapsFilter = new MapsFilter(),
                RequirementsFilter = new RequirementsFilter(),
                SocketFilter = new SocketsGroupFilter(),
                MiscellaneousFilter = new MiscellaneousFilter(),
                Sort = new Dictionary<string, SortType>
                {
                    { "price", SortType.Ascending }
                }
            };

            Query.ModifiersFilter.GroupFilters.Add(new ModifierGroupFilter());
        }
    }
}