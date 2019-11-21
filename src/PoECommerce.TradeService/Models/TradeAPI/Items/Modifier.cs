using System.Text.Json.Serialization;

namespace PoECommerce.TradeService.Models.TradeAPI.Items
{
    /// <summary>
    ///     Metadata of the item modifier.
    /// </summary>
    public class Modifier
    {
        /// <summary>
        ///     Unique name of the modifier.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        ///     Tier of the modifier.
        /// </summary>
        [JsonPropertyName("tier")]
        public string Tier { get; set; }

        /// <summary>
        ///     Values ranges of the modifier.
        /// </summary>
        [JsonPropertyName("magnitudes")]
        public Magnitude[] Magnitudes { get; set; }
    }
}