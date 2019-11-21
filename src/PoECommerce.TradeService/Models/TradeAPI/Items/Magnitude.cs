using System.Text.Json.Serialization;

namespace PoECommerce.TradeService.Models.TradeAPI.Items
{
    /// <summary>
    ///     Values range of the property value.
    /// </summary>
    public class Magnitude
    {
        /// <summary>
        ///     Unique hash of the modifier.
        /// </summary>
        [JsonPropertyName("hash")]
        public string Hash { get; set; }

        /// <summary>
        ///     Minimum in the modifier's values range.
        /// </summary>
        [JsonPropertyName("min")]
        public int Min { get; set; }

        /// <summary>
        ///     Maximum in the modifier's values range.
        /// </summary>
        [JsonPropertyName("max")]
        public int Max { get; set; }
    }
}