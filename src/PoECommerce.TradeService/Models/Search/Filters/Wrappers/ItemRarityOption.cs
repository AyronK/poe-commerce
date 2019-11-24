using System.Text.Json.Serialization;
using PoECommerce.TradeService.Models.Search.Enums;

namespace PoECommerce.TradeService.Models.Search.Filters.Wrappers
{
    public class ItemRarityOption
    {
        [JsonPropertyName("option")]
        [JsonConverter(typeof(NullableEnumJsonConverter<ItemRarity>))]
        public ItemRarity? Value { get; set; }
    }
}