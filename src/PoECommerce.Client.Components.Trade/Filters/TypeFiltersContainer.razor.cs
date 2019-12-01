using System;
using Microsoft.AspNetCore.Components;
using PoECommerce.Core.Model.Search;

namespace PoECommerce.Client.Components.Trade.Filters
{
    public class TypeFilterContainerBase : ComponentBase
    {
        [Parameter]
        public TypeFilter Filter { get; set; }

        public string Category
        {
            get => Filter.Category;
            set
            {
                Filter.Category = value;
                OnChange?.Invoke(Filter);
            }
        }

        public string ItemRarity
        {
            get => Filter.ItemRarity.ToString();
            set
            {
                Filter.ItemRarity = Enum.TryParse(value, out ItemRarity rarity) ? rarity : (ItemRarity?) null;
                OnChange?.Invoke(Filter);
            }
        }

        [Parameter]
        public Action<TypeFilter> OnChange { get; set; }
    }
}