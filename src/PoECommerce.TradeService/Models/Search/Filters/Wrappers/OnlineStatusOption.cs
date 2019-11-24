using System.Text.Json.Serialization;
using PoECommerce.PathOfExile.Models.Search.Enums;

namespace PoECommerce.PathOfExile.Models.Search.Filters.Wrappers
{
    public class OnlineStatusOption
    {
        [JsonPropertyName("option")]
        [JsonConverter(typeof(NullableEnumJsonConverter<OnlineStatus>))]
        public OnlineStatus? Value { get; set; }
    }
}