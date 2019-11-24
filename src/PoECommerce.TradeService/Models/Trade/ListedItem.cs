using System.Text.Json.Serialization;
using PoECommerce.PathOfExile.Models.Trade.Items;
using PoECommerce.PathOfExile.Models.Trade.Listings;

namespace PoECommerce.PathOfExile.Models.Trade
{
    public class ListedItem
    {
        /// <summary>
        ///     Result ID (might be different than <see cref="Item" />.Id.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        ///     Information about the seller (name, online status, language etc.) and its offer (price, currency, notes etc.).
        /// </summary>
        [JsonPropertyName("listing")]
        public Listing Listing { get; set; }

        /// <summary>
        ///     Information about the listed item.
        /// </summary>
        [JsonPropertyName("item")]
        public Item Item { get; set; }
    }
}