using Microsoft.AspNetCore.Components;
using PoECommerce.Core.Model.Trade;

namespace PoECommerce.Client.Components.Trade.Items
{
    public class ListedItemContainerBase : ComponentBase
    {
        [Parameter]
        public ListedItem ListedItem { get; set; }

        protected string GetOnlineStatus()
        {
            if (!string.IsNullOrEmpty(ListedItem.Listing.Account.Online.Status))
            {
                return ListedItem.Listing.Account.Online.Status;
            }

            if (ListedItem.Listing.Account.Online.IsOnline)
            {
                return "Online";
            }

            return "Offline";
        }

        protected string GetPricedTypeName()
        {
            switch (ListedItem.Listing.Price?.Type.ToLower())
            {
                case "~b/o":
                    return "Asking price";
                case "~fixed":
                case "~price":
                    return "Exact price";
                case null:
                    return null;
            }

            return null;
        }
    }
}