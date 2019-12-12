using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using PoECommerce.Core;
using PoECommerce.Core.Model.Data;
using PoECommerce.Core.Model.Search;

namespace PoECommerce.Client.Components.Trade.Filters.Modifiers
{
    public class ModifiersFiltersContainerBase : ComponentBase
    {
        [Inject]
        public IStaticDataService DataService { get; set; }

        protected IEnumerable<Modifier> Modifiers { get; set; } = new Modifier[0];
        
        [Parameter]
        public ModifiersFilter Filter { get; set; }

        [Parameter]
        public Action<ModifiersFilter> OnChange { get; set; }

        protected override async Task OnInitializedAsync()
        {
            base.OnInitialized();

            Modifiers = (await DataService.GetModifiers()).SelectMany(m => m.Value).ToArray();
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

            if (Modifiers.All(m => m.Id != filter))
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