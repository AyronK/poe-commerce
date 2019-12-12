using System.Text.Json.Serialization;
using PoECommerce.PathOfExile.Models.Search.Enums;

namespace PoECommerce.PathOfExile.Models.Search.Filters.Wrappers
{
    public class SaleTypeOption
    {
        [JsonPropertyName("option")]
        [JsonConverter(typeof(NullableEnumJsonConverter<SaleType>))]
        public SaleType? Value { get; set; }
    }
}