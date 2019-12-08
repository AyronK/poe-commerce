using System;
using Microsoft.AspNetCore.Components;
using PoECommerce.Core.Model.Search;

namespace PoECommerce.Client.Components.Trade.Filters
{
    public class SocketsGroupFilterContainerBase : ComponentBase
    {
        [Parameter]
        public SocketsGroupFilter Filter { get; set; }

        public SocketsFilter SocketsFilter
        {
            get => Filter.SocketsFilter;
            set
            {
                Filter.SocketsFilter = value;
                OnChange?.Invoke(Filter);
            }
        }

        public SocketsFilter LinksFilter
        {
            get => Filter.LinksFilter;
            set
            {
                Filter.LinksFilter = value;
                OnChange?.Invoke(Filter);
            }
        }

        [Parameter]
        public Action<SocketsGroupFilter> OnChange { get; set; }
    }
}