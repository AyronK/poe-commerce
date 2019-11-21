using System.Text.Json.Serialization;

namespace PoECommerce.TradeService.Models.TradeAPI.Items
{
    public class IncubatedItem
    {
        /// <summary>
        ///     Incubated item name.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        ///     Incubated item level.
        /// </summary>
        [JsonPropertyName("level")]
        public int Level { get; set; }

        /// <summary>
        ///     Current progress in incubating.
        /// </summary>
        [JsonPropertyName("progress")]
        public int Progress { get; set; }

        /// <summary>
        ///     Total value at which incubated item pops out.
        /// </summary>
        [JsonPropertyName("total")]
        public int Total { get; set; }
    }
}