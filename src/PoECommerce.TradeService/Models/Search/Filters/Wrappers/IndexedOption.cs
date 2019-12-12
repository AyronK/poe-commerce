using System.Text.Json.Serialization;
using PoECommerce.PathOfExile.Models.Search.Enums;

namespace PoECommerce.PathOfExile.Models.Search.Filters.Wrappers
{
    public class IndexedOption
    {
        [JsonPropertyName("option")]
        [JsonConverter(typeof(NullableEnumJsonConverter<Indexed>))]
        public Indexed? Value { get; set; }
    }
}