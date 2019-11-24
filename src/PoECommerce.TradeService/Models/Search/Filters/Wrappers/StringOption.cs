using System.Text.Json.Serialization;

namespace PoECommerce.PathOfExile.Models.Search.Filters.Wrappers
{
    public class StringOption
    {
        [JsonPropertyName("option")]
        public string Value { get; set; }
    }
}