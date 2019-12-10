using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using PoECommerce.Core;
using PoECommerce.Core.Model.Data;
using PoECommerce.Core.Model.Search;

namespace PoECommerce.Client.Components.Trade.Filters
{
    public class MapsFilterContainerBase : ComponentBase
    {
        [Parameter]
        public MapsFilter Filter { get; set; }

        [Inject]
        public IStaticDataService DataService { get; set; }

        protected string[] MapSeries = new string[0];

        public FilterMagnitude Tier
        {
            get => Filter.Tier;
            set
            {
                Filter.Tier = value;
                OnChange?.Invoke(Filter);
            }
        }

        public FilterMagnitude IncreasedItemQuantity
        {
            get => Filter.IncreasedItemQuantity;
            set
            {
                Filter.IncreasedItemQuantity = value;
                OnChange?.Invoke(Filter);
            }
        }

        public FilterMagnitude PackSize
        {
            get => Filter.PackSize;
            set
            {
                Filter.PackSize = value;
                OnChange?.Invoke(Filter);
            }
        }

        public FilterMagnitude IncreasedItemRarity
        {
            get => Filter.IncreasedItemRarity;
            set
            {
                Filter.IncreasedItemRarity = value;
                OnChange?.Invoke(Filter);
            }
        }

        public string ShapedValue
        {
            get => Shaped.ToString();
            set => Shaped = bool.TryParse(value, out bool boolValue) ? boolValue : (bool?)null;
        }

        public bool? Shaped
        {
            get => Filter.Shaped;
            set
            {
                Filter.Shaped = value;
                OnChange?.Invoke(Filter);
            }
        }

        public string BlightedValue
        {
            get => Blighted.ToString();
            set => Blighted = bool.TryParse(value, out bool boolValue) ? boolValue : (bool?)null;
        }

        public bool? Blighted
        {
            get => Filter.Blighted;
            set
            {
                Filter.Blighted = value;
                OnChange?.Invoke(Filter);
            }
        }

        public string ElderValue
        {
            get => Elder.ToString();
            set => Elder = bool.TryParse(value, out bool boolValue) ? boolValue : (bool?)null;
        }

        public bool? Elder
        {
            get => Filter.Elder;
            set
            {
                Filter.Elder = value;
                OnChange?.Invoke(Filter);
            }
        }

        public string Series
        {
            get => Filter.Series;
            set
            {
                Filter.Series = value;
                OnChange?.Invoke(Filter);
            }
        }

        [Parameter]
        public Action<MapsFilter> OnChange { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            IReadOnlyDictionary<ItemCategory, Item[]> items = await DataService.GetItems();
            MapSeries = items[ItemCategory.NormalMap].Select(m => m.Disclaimer).Distinct().Where(m => !string.IsNullOrEmpty(m)).ToArray();
        }
    }
}