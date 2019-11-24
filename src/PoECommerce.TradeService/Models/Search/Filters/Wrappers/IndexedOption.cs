using System.Text.Json.Serialization;
using PoECommerce.TradeService.Models.Search.Enums;

namespace PoECommerce.TradeService.Models.Search.Filters.Wrappers
{
    public class IndexedOption
    {
        [JsonPropertyName("option")]
        [JsonConverter(typeof(NullableEnumJsonConverter<Indexed>))]
        public Indexed? Value { get; set; }
    }
}