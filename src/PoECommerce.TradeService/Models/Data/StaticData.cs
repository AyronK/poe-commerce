using System.Text.Json.Serialization;

namespace PoECommerce.TradeService.Models.Data
{
    public class StaticData
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("image")]
        public string Image { get; set; }
    }
}