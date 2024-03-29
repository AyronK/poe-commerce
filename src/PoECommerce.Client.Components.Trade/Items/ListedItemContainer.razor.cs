﻿using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GregsStack.InputSimulatorStandard;
using GregsStack.InputSimulatorStandard.Native;
using Microsoft.AspNetCore.Components;
using NLog;
using PoECommerce.Core.Model.Trade;

namespace PoECommerce.Client.Components.Trade.Items
{
    public class ListedItemContainerBase : ComponentBase
    {
        private bool _sentWhisper;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern void SwitchToThisWindow(IntPtr hWnd, bool fAltTab);

        [Parameter]
        public ListedItem ListedItem { get; set; }

        [Parameter]
        public IntPtr? PoEWindow { get; set; }

        [Inject]
        public ILogger Logger { get; set; }

        [Inject]
        public IInputSimulator InputSimulator { get; set; }

        public bool SentWhisper
        {
            get => _sentWhisper;
            set
            {
                _sentWhisper = value;
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
#if DEBUG // if PoE is turned off
            SentWhisper = true;
#endif
            if (PoEWindow.HasValue)
            {
                SwitchToThisWindow(PoEWindow.Value, true);

                InputSimulator.Keyboard.Sleep(100);
                InputSimulator.Keyboard.KeyPress(VirtualKeyCode.RETURN);
                InputSimulator.Keyboard.Sleep(100);
                InputSimulator.Keyboard.ModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_A);
                InputSimulator.Keyboard.Sleep(100);
                InputSimulator.Keyboard.KeyPress(VirtualKeyCode.DELETE);
                InputSimulator.Keyboard.Sleep(100);
                InputSimulator.Keyboard.TextEntry(ListedItem.Listing.Whisper);
                InputSimulator.Keyboard.Sleep(100);
                InputSimulator.Keyboard.KeyPress(VirtualKeyCode.RETURN);

                SentWhisper = true;
            }
            else
            {
                Logger.Debug("Cannot send whisper because Path of Exile process is not attached.");
            }
        }
    }
}