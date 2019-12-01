using System;
using Microsoft.AspNetCore.Components;
using PoECommerce.Core.Model.Search;

namespace PoECommerce.Client.Components.Trade.Filters
{
    public class TradeFiltersContainerBase : ComponentBase
    {
        [Parameter]
        public TradeFilter Filter { get; set; }

        public string AccountName
        {
            get => Filter.AccountName;
            set
            {
                Filter.AccountName = value;
                OnChange?.Invoke(Filter);
            }
        }

        public string Indexed
        {
            get => Filter.Indexed.ToString();
            set
            {
                Filter.Indexed = Enum.TryParse(value, out Indexed indexed) ? indexed : (Indexed?) null;
                OnChange?.Invoke(Filter);
            }
        }

        public string SaleType
        {
            get => Filter.SaleType.ToString();
            set
            {
                Filter.SaleType = Enum.TryParse(value, out SaleType saleType) ? saleType : (SaleType?)null;
                OnChange?.Invoke(Filter);
            }
        }

        public string PriceCurrency
        {
            get => Filter.Price?.Currency;
            set
            {
                Filter.Price.Currency = value;
                OnChange?.Invoke(Filter);
            }
        }

        public string PriceMin
        {
            get => Filter.Price?.Min?.ToString();
            set
            {
                Filter.Price.Min = int.TryParse(value, out int intValue) ? intValue : (int?)null;
                OnChange?.Invoke(Filter);
            }
        }

        public string PriceMax
        {
            get => Filter.Price?.Max?.ToString();
            set
            {
                Filter.Price.Max = int.TryParse(value, out int intValue) ? intValue : (int?)null;
                OnChange?.Invoke(Filter);
            }
        }

        [Parameter]
        public Action<TradeFilter> OnChange { get; set; }
    }
}