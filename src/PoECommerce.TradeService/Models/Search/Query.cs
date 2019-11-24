using System.Text.Json.Serialization;
using PoECommerce.TradeService.Models.Search.Filters;
using PoECommerce.TradeService.Models.Search.Filters.Wrappers;

namespace PoECommerce.TradeService.Models.Search
{
    public class Query
    {
        [JsonPropertyName("status")]
        public OnlineStatusOption Status { get; set; }

        /// <summary>
        ///     Item's name.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        ///     Item's base type's name.
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("stats")]
        public ModifierGroupFilter[] ModifiersFilters { get; set; }

        [JsonPropertyName("filters")]
        public Filter Filter { get; set; }
    }
}