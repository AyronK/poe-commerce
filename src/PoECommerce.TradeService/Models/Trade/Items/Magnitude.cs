using System.Text.Json.Serialization;

namespace PoECommerce.PathOfExile.Models.Trade.Items
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
        public double Min { get; set; }

        /// <summary>
        ///     Maximum in the modifier's values range.
        /// </summary>
        [JsonPropertyName("max")]
        public double Max { get; set; }
    }
}