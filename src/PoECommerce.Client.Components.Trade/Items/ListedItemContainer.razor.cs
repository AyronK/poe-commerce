﻿using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
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
        
        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        [Parameter]
        public ListedItem ListedItem { get; set; }
        
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

        private static bool IsPathOfExileFocused()
        {
            Process poeWindow = Process.GetProcesses().FirstOrDefault(p => p.ProcessName.Contains("PathOfExile") && p.MainWindowTitle.StartsWith("Path of Exile"));

            return poeWindow != null && SetForegroundWindow(poeWindow.MainWindowHandle);
        }

        protected void InvokeInstantWhisper()
        {
#if DEBUG // if PoE is turned off
            SentWhisper = true;
#endif
            if (IsPathOfExileFocused())
            {
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
            }
            else
            {
                Logger.Debug("Cannot send whisper because Path of Exile process is not attached.");
            }
        }
    }
}