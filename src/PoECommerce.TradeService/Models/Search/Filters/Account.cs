using System.Text.Json.Serialization;

namespace PoECommerce.TradeService.Models.Search.Filters
{
    public class Account
    {
        [JsonPropertyName("input")]
        public string Name { get; set; }
    }
}