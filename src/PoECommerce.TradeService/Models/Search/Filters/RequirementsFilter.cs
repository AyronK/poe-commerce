using System.Text.Json.Serialization;

namespace PoECommerce.TradeService.Models.Search.Filters
{
    public class RequirementsFilter
    {
        [JsonPropertyName("lvl")]
        public FilterMagnitude Level { get; set; }

        [JsonPropertyName("dex")]
        public FilterMagnitude Dexterity { get; set; }

        [JsonPropertyName("str")]
        public FilterMagnitude Strength { get; set; }

        [JsonPropertyName("int")]
        public FilterMagnitude Intelligence { get; set; }
    }
}