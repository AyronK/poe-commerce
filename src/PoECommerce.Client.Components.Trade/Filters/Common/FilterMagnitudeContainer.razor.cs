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
            set => Min = double.TryParse(value, out double doubleValue) ? doubleValue : (double?) null;
        }

        protected string MaxValue
        {
            get => Max?.ToString();
            set => Max = double.TryParse(value, out double doubleValue) ? doubleValue : (double?) null;
        }

        public double? Min
        {
            get => FilterMagnitude.Min;
            set
            {
                FilterMagnitude.Min = value;
                OnChange?.Invoke(FilterMagnitude);
            }
        }

        public double? Max
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