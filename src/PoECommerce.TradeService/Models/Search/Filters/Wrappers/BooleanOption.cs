using System.Text.Json.Serialization;

namespace PoECommerce.TradeService.Models.Search.Filters.Wrappers
{
    public class BooleanOption
    {
        [JsonPropertyName("option")]
        public bool? Value { get; set; }
    }
}