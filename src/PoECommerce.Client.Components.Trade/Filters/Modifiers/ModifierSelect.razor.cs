using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using PoECommerce.Core;
using PoECommerce.Core.Model.Data;

namespace PoECommerce.Client.Components.Trade.Filters.Modifiers
{
    public class ModifierSelectBase : ComponentBase
    {
        [Parameter]
        public string Value { get; set; }

        [Parameter]
        public string PlaceHolder { get; set; }

        [Inject]
        public IStaticDataService DataService { get; set; }

        [Parameter]
        public EventCallback<string> ValueChanged { get; set; }

        public void OnSearchTextChange(ChangeEventArgs changeEventArgs)
        {
            string value = changeEventArgs.Value.ToString();
            IEnumerable<string> x = value.Split(' ').Where(s => !string.IsNullOrWhiteSpace(s));

            SearchTooltipValues = Modifiers.Where(v => x.All(a => v.Text.IndexOf(a, StringComparison.InvariantCultureIgnoreCase) >= 0))
                .OrderBy(v => v.Type == ModifierType.Pseudo ? 0 : 1)
                .ThenBy(v => v.Type)
                .ThenBy(v => v.Text.StartsWith(value, StringComparison.InvariantCultureIgnoreCase))
                .ThenBy(v => v.Text)
                .Take(50);
        }

        protected IEnumerable<Modifier> Modifiers { get; set; } = new Modifier[0];

        public IEnumerable<Modifier> SearchTooltipValues { get; set; } = new Modifier[0];

        protected override async Task OnInitializedAsync()
        {
            base.OnInitialized();

            Modifiers = (await DataService.GetModifiers()).SelectMany(m => m.Value).ToArray();
            SearchTooltipValues = Modifiers.Where(m => m.Type == ModifierType.Pseudo).ToArray();
        }
    }
}