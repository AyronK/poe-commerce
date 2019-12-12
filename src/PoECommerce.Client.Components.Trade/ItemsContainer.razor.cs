using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using PoECommerce.Core;
using PoECommerce.Core.Model.Search;
using PoECommerce.Core.Model.Trade;

namespace PoECommerce.Client.Components.Trade
{
    public class ItemsContainerBase : ComponentBase
    {
        private string _lastQueryId;

        [Parameter]
        public SearchResult SearchResult { get; set; }

        public List<ListedItem> ListedItems { get; set; } = new List<ListedItem>();

        [Inject]
        public ITradeService TradeService { get; set; }

        protected IntPtr? PoEWindow { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            
            Process poeProcess = Process.GetProcesses().FirstOrDefault(p => p.ProcessName.StartsWith("PathOfExile"));
            PoEWindow = poeProcess?.MainWindowHandle;
        }

        protected override async Task OnParametersSetAsync()
        {
            if (SearchResult?.QueryId == _lastQueryId) // prevent multiple reload on same query
            {
                return;
            }

            if (SearchResult?.ItemIds?.Any() == true)
            {
                string[] itemIds = SearchResult?.ItemIds;

                _lastQueryId = SearchResult.QueryId;
                ListedItems = new List<ListedItem>();

                for (int i = 0; i < itemIds.Length; i += 10)
                {
                    string[] ids = itemIds.Skip(i).Take(10).ToArray();
                    ListedItems.AddRange(await TradeService.Fetch(_lastQueryId, ids));
                    StateHasChanged();
                    await Task.Delay(1000);
                }
            }
            else
            {
                ListedItems.Clear();
                _lastQueryId = null;

                StateHasChanged();
            }
        }
    }
}