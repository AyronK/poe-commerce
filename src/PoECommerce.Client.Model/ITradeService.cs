﻿using System.Threading.Tasks;
using PoECommerce.Core.Model.Search;
using PoECommerce.Core.Model.Trade;

namespace PoECommerce.Core
{
    public interface ITradeService
    {

        /// <summary>
        ///     Performs a query on the trade service and returns a query result containing IDs of found items. To get item's details
        ///     call <see cref="Fetch" /> with its ID.
        /// </summary>
        /// <param name="query">A set of filters to search items,</param>
        /// <returns>Query result containing IDs of found items. To get item's details call <see cref="Fetch" /> with its ID.</returns>
        Task<SearchResult> Search(Query query);

        /// <summary>
        ///     Fetches items' details by IDs obtained from <see cref="Search" /> call.
        /// </summary>
        /// <param name="queryId">ID of a query that returned the item ID.</param>
        /// <param name="itemsIds">IDs of items to get details for.</param>
        /// <returns>Details of the requested items.</returns>
        Task<ListedItem[]> Fetch(string queryId, string[] itemsIds);
    }
}
