using System;
using Microsoft.AspNetCore.Components;
using PoECommerce.Core.Model.Search;

namespace PoECommerce.Client.Components.Trade.Filters
{
    public class WeaponsFilterContainerBase : ComponentBase
    {
        [Parameter]
        public WeaponsFilter Filter { get; set; }

        public FilterMagnitude Damage
        {
            get => Filter.Damage;
            set
            {
                Filter.Damage = value;
                OnChange?.Invoke(Filter);
            }
        }

        public FilterMagnitude CriticalChance
        {
            get => Filter.CriticalChance;
            set
            {
                Filter.CriticalChance = value;
                OnChange?.Invoke(Filter);
            }
        }

        public FilterMagnitude PhysicalDps
        {
            get => Filter.PhysicalDps;
            set
            {
                Filter.PhysicalDps = value;
                OnChange?.Invoke(Filter);
            }
        }

        public FilterMagnitude AttacksPerSecond
        {
            get => Filter.AttacksPerSecond;
            set
            {
                Filter.AttacksPerSecond = value;
                OnChange?.Invoke(Filter);
            }
        }

        public FilterMagnitude Dps
        {
            get => Filter.Dps;
            set
            {
                Filter.Dps = value;
                OnChange?.Invoke(Filter);
            }
        }


        public FilterMagnitude ElementalDps
        {
            get => Filter.ElementalDps;
            set
            {
                Filter.ElementalDps = value;
                OnChange?.Invoke(Filter);
            }
        }

        [Parameter]
        public Action<WeaponsFilter> OnChange { get; set; }
    }
}