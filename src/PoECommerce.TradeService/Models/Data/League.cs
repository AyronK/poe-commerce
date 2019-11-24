using System.Text.Json.Serialization;

namespace PoECommerce.PathOfExile.Models.Data
{
    public class League
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }
    }
}