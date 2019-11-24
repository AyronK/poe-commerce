using System.Text.Json.Serialization;

namespace PoECommerce.PathOfExile.Models.Search.Filters
{
    public class FilterMagnitude
    {
        [JsonPropertyName("min")]
        public int? Min { get; set; }

        [JsonPropertyName("max")]
        public int? Max { get; set; }
    }
}