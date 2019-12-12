using System.Text.Json.Serialization;
using PoECommerce.PathOfExile.Models.Search.Enums;

namespace PoECommerce.PathOfExile.Models.Search.Filters.Wrappers
{
    public class ItemRarityOption
    {
        [JsonPropertyName("option")]
        [JsonConverter(typeof(NullableEnumJsonConverter<ItemRarity>))]
        public ItemRarity? Value { get; set; }
    }
}