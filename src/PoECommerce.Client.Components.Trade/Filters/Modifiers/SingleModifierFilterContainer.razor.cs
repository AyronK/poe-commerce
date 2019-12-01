using System;
using Microsoft.AspNetCore.Components;
using PoECommerce.Core.Model.Search;

namespace PoECommerce.Client.Components.Trade.Filters.Modifiers
{
    public class SingleModifierFilterContainerBase : ComponentBase
    {
        [Parameter]
        public SingleModifierFilter Filter { get; set; }

        [Parameter]
        public Action<SingleModifierFilter> OnChange { get; set; }

        [Parameter]
        public Action<SingleModifierFilter> OnRemove { get; set; }

        protected FilterMagnitude Magnitude
        {
            get => Filter.Magnitude;
            set
            {
                Filter.Magnitude = value;
                OnChange?.Invoke(Filter);
            }
        }

        protected string Id
        {
            get => Filter.Id;
            set
            {
                Filter.Id = value;
                OnChange?.Invoke(Filter);
            }
        }

        protected bool Enabled
        {
            get => !Filter.Disabled;
            set
            {
                Filter.Disabled = !value;
                OnChange?.Invoke(Filter);
            }
        }
    }
}