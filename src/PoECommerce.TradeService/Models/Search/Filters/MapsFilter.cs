using System.Text.Json.Serialization;
using PoECommerce.TradeService.Models.Search.Filters.Wrappers;

namespace PoECommerce.TradeService.Models.Search.Filters
{
    public class MapsFilter
    {
        [JsonPropertyName("map_tier")]
        public FilterMagnitude Tier { get; set; }

        [JsonPropertyName("map_iiq")]
        public FilterMagnitude IncreasedItemQuantity { get; set; }

        [JsonPropertyName("map_packsize")]
        public FilterMagnitude PackSize { get; set; }

        [JsonPropertyName("map_iir")]
        public FilterMagnitude IncreasedItemRarity { get; set; }

        [JsonPropertyName("map_shaped")]
        public BooleanOption Shaped { get; set; }

        [JsonPropertyName("map_blighted")]
        public BooleanOption Blighted { get; set; }

        [JsonPropertyName("map_elder")]
        public BooleanOption Elder { get; set; }

        [JsonPropertyName("map_series")]
        public StringOption Series { get; set; }
    }
}