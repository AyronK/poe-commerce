using System.Text.Json.Serialization;

namespace PoECommerce.TradeService.Models.Search.Filters.Wrappers
{
    public class StringOption
    {
        [JsonPropertyName("option")]
        public string Value { get; set; }
    }
}