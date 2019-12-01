using System;
using Microsoft.AspNetCore.Components;
using PoECommerce.Core.Model.Search;

namespace PoECommerce.Client.Components.Trade.Filters.Common
{
    public class FilterMagnitudeContainerBase : ComponentBase
    {
        [Parameter]
        public FilterMagnitude FilterMagnitude { get; set; }

        protected string MinValue
        {
            get => Min?.ToString();
            set => Min = int.TryParse(value, out int intValue) ? intValue : (int?) null;
        }

        protected string MaxValue
        {
            get => Max?.ToString();
            set => Max = int.TryParse(value, out int intValue) ? intValue : (int?) null;
        }

        public int? Min
        {
            get => FilterMagnitude.Min;
            set
            {
                FilterMagnitude.Min = value;
                OnChange?.Invoke(FilterMagnitude);
            }
        }

        public int? Max
        {
            get => FilterMagnitude.Max;
            set
            {
                FilterMagnitude.Max = value;
                OnChange?.Invoke(FilterMagnitude);
            }
        }

        [Parameter]
        public Action<FilterMagnitude> OnChange { get; set; }
    }
}