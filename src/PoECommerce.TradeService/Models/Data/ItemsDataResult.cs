using System.Text.Json.Serialization;
using PoECommerce.TradeService.Models.Enums;

namespace PoECommerce.TradeService.Models.Data
{
    internal class ItemsDataResult
    {
        [JsonPropertyName("label")]
        [JsonConverter(typeof(EnumJsonConverter<ItemCategory>))]
        public ItemCategory Category { get; set; }

        [JsonPropertyName("entries")]
        public Item[] Items { get; set; }
    }
}