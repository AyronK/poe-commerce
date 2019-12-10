using Microsoft.AspNetCore.Components;
using PoECommerce.Core.Model.Trade;

namespace PoECommerce.Client.Components.Trade.Items
{
    public class SocketsContainerBase : ComponentBase
    {
        [Parameter]
        public Socket[] Sockets { get; set; }

        [Parameter]
        public int ItemHeight { get; set; }

        [Parameter]
        public int ItemWidth { get; set; }
    }
}
