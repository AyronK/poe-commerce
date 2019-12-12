using System.Text.Json.Serialization;

namespace PoECommerce.PathOfExile.Models.Search.Filters
{
    public class SocketsFilter
    {
        [JsonPropertyName("g")]
        public int? GreenMin { get; set; }

        [JsonPropertyName("r")]
        public int? RedMin { get; set; }

        [JsonPropertyName("b")]
        public int? BlueMin { get; set; }

        [JsonPropertyName("w")]
        public int? WhiteMin { get; set; }

        [JsonPropertyName("min")]
        public int? AnyMin { get; set; }

        [JsonPropertyName("max")]
        public int? AnyMax { get; set; }
    }
}