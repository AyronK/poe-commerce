using System;
using Microsoft.AspNetCore.Components;
using PoECommerce.Core.Model.Search;

namespace PoECommerce.Client.Components.Trade.Filters
{
    public class RequirementsFilterContainerBase : ComponentBase
    {
        [Parameter]
        public RequirementsFilter Filter { get; set; }

        public FilterMagnitude Level
        {
            get => Filter.Level;
            set
            {
                Filter.Level = value;
                OnChange?.Invoke(Filter);
            }
        }

        public FilterMagnitude Dexterity
        {
            get => Filter.Dexterity;
            set
            {
                Filter.Dexterity = value;
                OnChange?.Invoke(Filter);
            }
        }

        public FilterMagnitude Strength
        {
            get => Filter.Strength;
            set
            {
                Filter.Strength = value;
                OnChange?.Invoke(Filter);
            }
        }

        public FilterMagnitude Intelligence
        {
            get => Filter.Intelligence;
            set
            {
                Filter.Intelligence = value;
                OnChange?.Invoke(Filter);
            }
        }

        [Parameter]
        public Action<RequirementsFilter> OnChange { get; set; }
    }
}