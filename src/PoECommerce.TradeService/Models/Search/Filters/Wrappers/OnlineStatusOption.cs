using System.Text.Json.Serialization;
using PoECommerce.TradeService.Models.Search.Enums;

namespace PoECommerce.TradeService.Models.Search.Filters.Wrappers
{
    public class OnlineStatusOption
    {
        [JsonPropertyName("option")]
        [JsonConverter(typeof(NullableEnumJsonConverter<OnlineStatus>))]
        public OnlineStatus? Value { get; set; }
    }
}