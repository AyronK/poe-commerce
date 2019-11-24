using System.Text.Json.Serialization;
using PoECommerce.TradeService.Models.Search.Enums;

namespace PoECommerce.TradeService.Models.Search.Filters.Wrappers
{
    public class SaleTypeOption
    {
        [JsonPropertyName("option")]
        [JsonConverter(typeof(NullableEnumJsonConverter<SaleType>))]
        public SaleType? Value { get; set; }
    }
}