using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using PoECommerce.Client.Shared;
using PoECommerce.Core;
using PoECommerce.Core.Model.Data;
using PoECommerce.Core.Model.Search;
using Item = PoECommerce.Core.Model.Data.Item;
using OnlineStatus = PoECommerce.Core.Model.Enums.OnlineStatus;

namespace PoECommerce.Client.Components.Trade
{
    public class FiltersContainerBase : ComponentBase
    {
        private string _league;
        private string _status;
        private bool _isFiltersSectionOpen = false;
        private string _searchText;

        [Inject]
        public IPoECommerceFacade PoECommerceFacade { get; set; }

        [Inject]
        public IStaticDataService DataService { get; set; }

        public League[] Leagues { get; set; } = new League[0];

        [Parameter]
        public EventCallback<TradeSession> OnSearch { get; set; }

        [Parameter]
        public Query Query { get; set; } = new Query();

        protected IEnumerable<Item> Items { get; set; } = new Item[0];

        public IEnumerable<Item> SearchTooltipValues { get; set; } = new Item[0];

        public string SearchText
        {
            get => _searchText;
            set => _searchText = value.Trim();
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
            Query = null;
            SearchText = null;
            InitModels();
            StateHasChanged();
        }

        public void Search()
        {
            if (Items.FirstOrDefault(i => i.ToString().Equals(SearchText, StringComparison.InvariantCultureIgnoreCase)) is Item matchedItem)
            {
                Query.Type = matchedItem.Type;
                Query.Name = matchedItem.Name;
                Query.Text = null;
            }
            else
            {
                Query.Type = null;
                Query.Name = null;
                Query.Text = SearchText;
            }

            OnSearch.InvokeAsync(null).Wait();
            OnSearch.InvokeAsync(PoECommerceFacade.SearchItems(Query)).Wait();
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
            Leagues = await DataService.GetLeagues();
            Items = (await DataService.GetItems()).SelectMany(m => m.Value).ToArray();
        }

        protected override void OnParametersSet()
        {
            InitModels();
            SearchText = Query.Text ?? Query.Name + " " + Query.Type;
        }

        private void InitModels()
        {
            Query ??= new Query
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
                },
            };

            if (!Query.ModifiersFilter.GroupFilters.Any())
            {
                Query.ModifiersFilter.GroupFilters.Add(new ModifierGroupFilter());
            }

            League = Leagues[0].Id;
            Status = OnlineStatus.Online.ToString();
        }
    }
}