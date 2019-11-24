using System.Text.Json.Serialization;
using PoECommerce.TradeService.Models.Search.Filters.Wrappers;

namespace PoECommerce.TradeService.Models.Search.Filters
{
    public class TypeFilter
    {
        [JsonPropertyName("category")]
        public StringOption Category { get; set; }

        [JsonPropertyName("rarity")]
        public ItemRarityOption Rarity { get; set; }
    }
}