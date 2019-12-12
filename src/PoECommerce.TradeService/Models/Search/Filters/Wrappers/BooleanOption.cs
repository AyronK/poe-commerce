using System.Text.Json.Serialization;

namespace PoECommerce.PathOfExile.Models.Search.Filters.Wrappers
{
    public class BooleanOption
    {
        [JsonPropertyName("option")]
        public bool? Value { get; set; }
    }
}