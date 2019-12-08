using System;
using Microsoft.AspNetCore.Components;
using PoECommerce.Core.Model.Search;

namespace PoECommerce.Client.Components.Trade.Filters
{
    public class SocketsFilterContainerBase : ComponentBase
    {
        [Parameter]
        public SocketsFilter SocketsFilter { get; set; }

        protected string GreenMinValue
        {
            get => GreenMin?.ToString();
            set => GreenMin = int.TryParse(value, out int intValue) ? intValue : (int?)null;
        }

        protected string RedMinValue
        {
            get => RedMin?.ToString();
            set => RedMin = int.TryParse(value, out int intValue) ? intValue : (int?)null;
        }

        protected string BlueMinValue
        {
            get => BlueMin?.ToString();
            set => BlueMin = int.TryParse(value, out int intValue) ? intValue : (int?)null;
        }

        protected string WhiteMinValue
        {
            get => WhiteMin?.ToString();
            set => WhiteMin = int.TryParse(value, out int intValue) ? intValue : (int?)null;
        }

        protected string AnyMinValue
        {
            get => AnyMin?.ToString();
            set => AnyMin = int.TryParse(value, out int intValue) ? intValue : (int?)null;
        }

        protected string AnyMaxValue
        {
            get => AnyMax?.ToString();
            set => AnyMax = int.TryParse(value, out int intValue) ? intValue : (int?)null;
        }

        public int? GreenMin
        {
            get => SocketsFilter.GreenMin;
            set
            {
                SocketsFilter.GreenMin = value;
                OnChange?.Invoke(SocketsFilter);
            }
        }

        public int? RedMin
        {
            get => SocketsFilter.RedMin;
            set
            {
                SocketsFilter.RedMin = value;
                OnChange?.Invoke(SocketsFilter);
            }
        }

        public int? BlueMin
        {
            get => SocketsFilter.BlueMin;
            set
            {
                SocketsFilter.BlueMin = value;
                OnChange?.Invoke(SocketsFilter);
            }
        }

        public int? WhiteMin
        {
            get => SocketsFilter.WhiteMin;
            set
            {
                SocketsFilter.WhiteMin = value;
                OnChange?.Invoke(SocketsFilter);
            }
        }

        public int? AnyMin
        {
            get => SocketsFilter.AnyMin;
            set
            {
                SocketsFilter.AnyMin = value;
                OnChange?.Invoke(SocketsFilter);
            }
        }

        public int? AnyMax
        {
            get => SocketsFilter.AnyMax;
            set
            {
                SocketsFilter.AnyMax = value;
                OnChange?.Invoke(SocketsFilter);
            }
        }

        [Parameter]
        public Action<SocketsFilter> OnChange { get; set; }
    }
}