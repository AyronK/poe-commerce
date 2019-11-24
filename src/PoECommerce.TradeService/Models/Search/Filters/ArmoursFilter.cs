using System.Text.Json.Serialization;

namespace PoECommerce.TradeService.Models.Search.Filters
{
    public class ArmoursFilter
    {
        [JsonPropertyName("ar")]
        public FilterMagnitude Armour { get; set; }

        [JsonPropertyName("es")]
        public FilterMagnitude EnergyShield { get; set; }

        [JsonPropertyName("ev")]
        public FilterMagnitude Evasion { get; set; }

        [JsonPropertyName("block")]
        public FilterMagnitude Block { get; set; }
    }
}