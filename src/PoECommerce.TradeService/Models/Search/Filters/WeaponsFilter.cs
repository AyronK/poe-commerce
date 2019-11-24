using System.Text.Json.Serialization;

namespace PoECommerce.PathOfExile.Models.Search.Filters
{
    public class WeaponsFilter
    {
        [JsonPropertyName("damage")]
        public FilterMagnitude Damage { get; set; }

        [JsonPropertyName("crit")]
        public FilterMagnitude CriticalChance { get; set; }

        [JsonPropertyName("pdps")]
        public FilterMagnitude PhysicalDps { get; set; }

        [JsonPropertyName("aps")]
        public FilterMagnitude AttacksPerSecond { get; set; }

        [JsonPropertyName("dps")]
        public FilterMagnitude Dps { get; set; }

        [JsonPropertyName("edps")]
        public FilterMagnitude ElementalDps { get; set; }
    }
}