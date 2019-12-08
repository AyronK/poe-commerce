using System;
using System.Diagnostics;
using System.Linq;
using GregsStack.InputSimulatorStandard;
using GregsStack.InputSimulatorStandard.Native;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
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

            Process poeProcess = Process.GetProcesses().FirstOrDefault(p => p.ProcessName.StartsWith("PathOfExile"));

            if (poeProcess != null)
            {
                SwitchToThisWindow(poeProcess.MainWindowHandle, true);

                InputSimulator simulator = new InputSimulator();

                simulator.Keyboard.KeyPress(VirtualKeyCode.RETURN);
                simulator.Keyboard.Sleep(100);
                simulator.Keyboard.ModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_A);
                simulator.Keyboard.Sleep(100);
                simulator.Keyboard.KeyPress(VirtualKeyCode.DELETE);
                simulator.Keyboard.Sleep(100);
                simulator.Keyboard.TextEntry(ListedItem.Listing.Whisper);
                simulator.Keyboard.Sleep(100);
                simulator.Keyboard.KeyPress(VirtualKeyCode.RETURN);

                SentWhisper = true;
            }
        }
    }
}