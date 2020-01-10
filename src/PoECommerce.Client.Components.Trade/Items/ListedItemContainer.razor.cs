using System;
using Microsoft.AspNetCore.Components;
using NLog;
using PoECommerce.Core.Model.Trade;
using PoECommerce.PathOfExile.GameClient.Abstractions;

namespace PoECommerce.Client.Components.Trade.Items
{
    public class ListedItemContainerBase : ComponentBase
    {
        private bool _sentWhisper;
        private bool _failedWhisper;

        [Parameter]
        public ListedItem ListedItem { get; set; }

        [Inject]
        public ILogger Logger { get; set; }

        [Inject]
        public IPathOfExileFacade PathOfExileFacade { get; set; }

        public bool SentWhisper
        {
            get => _sentWhisper;
            set
            {
                _sentWhisper = value;
                StateHasChanged();
            }
        }
        public bool FailedWhisper
        {
            get => _failedWhisper;
            set
            {
                _failedWhisper = value;
                StateHasChanged();
            }
        }

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

        protected void InvokeInstantWhisper()
        {
            FailedWhisper = false;

            if (PathOfExileFacade.Chat.CanWrite())
            {
                try
                {
                    PathOfExileFacade.Chat.Write(ListedItem.Listing.Whisper);
                    SentWhisper = true;
                }
                catch (InvalidOperationException ex)
                {
                    Logger.Debug("Cannot send whisper because Path of Exile process is focused.", ex);
                    FailedWhisper = true;
                }
            }
            else
            {
                Logger.Debug("Cannot send whisper because Path of Exile process is not attached.");
                FailedWhisper = true;
            }
        }
    }
}