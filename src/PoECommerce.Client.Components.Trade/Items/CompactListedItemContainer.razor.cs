using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using NLog;
using PoECommerce.Core.Model.Trade;
using PoECommerce.PathOfExile;

namespace PoECommerce.Client.Components.Trade.Items
{
    public class CompactListedItemContainerBase : ComponentBase
    {
        private bool _sentWhisper;

        [Parameter]
        public ListedItem ListedItem { get; set; }

        [Parameter]
        public EventCallback<MouseEventArgs> OnClick { get; set; }

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

        protected override void OnInitialized()
        {
            base.OnInitialized();

            OnClick = new EventCallbackFactory().Create<MouseEventArgs>(this, InvokeInstantWhisper);
        }

        protected void InvokeInstantWhisper()
        {
#if DEBUG // if PoE is turned off
            SentWhisper = true;
#endif
            if (PathOfExileFacade.IsLaunched())
            {
                PathOfExileFacade.Chat.Write(ListedItem.Listing.Whisper);
            }
            else
            {
                Logger.Debug("Cannot send whisper because Path of Exile process is not attached.");
            }
        }
    }
}