using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using PoECommerce.Core.Model.Search;

namespace PoECommerce.Client.Components.Trade.Filters.Modifiers
{
    public class ModifiersFiltersContainerBase : ComponentBase
    {
        [Parameter]
        public ModifiersFilter Filter { get; set; }

        [Parameter]
        public Action<ModifiersFilter> OnChange { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            Filter.GroupFilters.Add(new ModifierGroupFilter
            {
                Filters = new List<SingleModifierFilter>(),
                Operand = FilterOperand.And
            });
        }

        protected void RemoveFilter(ModifierGroupFilter groupFilter, SingleModifierFilter filter)
        {
            groupFilter.Filters.Remove(filter);
            OnChange?.Invoke(Filter);
        }

        protected void AddFilter(ModifierGroupFilter groupFilter, string filter)
        {
            if (filter == null)
            {
                return;
            }

            groupFilter.Filters.Add(new SingleModifierFilter
            {
                Id = filter
            });

            OnChange?.Invoke(Filter);
        }
    }
}