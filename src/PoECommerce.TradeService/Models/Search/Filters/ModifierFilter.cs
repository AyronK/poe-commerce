using System.Text.Json.Serialization;

namespace PoECommerce.PathOfExile.Models.Search.Filters
{
    public class ModifierFilter
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("value")]
        public FilterMagnitude Magnitude { get; set; }

        [JsonPropertyName("disabled")]
        public bool? Disabled { get; set; }
    }
}