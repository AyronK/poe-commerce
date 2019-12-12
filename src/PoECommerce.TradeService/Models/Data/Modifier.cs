using System.Text.Json.Serialization;
using PoECommerce.PathOfExile.Models.Enums;

namespace PoECommerce.PathOfExile.Models.Data
{
    public class Modifier
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("type")]
        [JsonConverter(typeof(EnumJsonConverter<ModifierType>))]
        public ModifierType Type { get; set; }
    }
}