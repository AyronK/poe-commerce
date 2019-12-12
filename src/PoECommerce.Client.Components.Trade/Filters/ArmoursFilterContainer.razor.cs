using System;
using Microsoft.AspNetCore.Components;
using PoECommerce.Core.Model.Search;

namespace PoECommerce.Client.Components.Trade.Filters
{
    public class ArmoursFilterContainerBase : ComponentBase
    {
        [Parameter]
        public ArmoursFilter Filter { get; set; }

        public FilterMagnitude Armour
        {
            get => Filter.Armour;
            set
            {
                Filter.Armour = value;
                OnChange?.Invoke(Filter);
            }
        }

        public FilterMagnitude EnergyShield
        {
            get => Filter.EnergyShield;
            set
            {
                Filter.EnergyShield = value;
                OnChange?.Invoke(Filter);
            }
        }

        public FilterMagnitude Evasion
        {
            get => Filter.Evasion;
            set
            {
                Filter.Evasion = value;
                OnChange?.Invoke(Filter);
            }
        }

        public FilterMagnitude Block
        {
            get => Filter.Block;
            set
            {
                Filter.Block = value;
                OnChange?.Invoke(Filter);
            }
        }

        [Parameter]
        public Action<ArmoursFilter> OnChange { get; set; }
    }
}