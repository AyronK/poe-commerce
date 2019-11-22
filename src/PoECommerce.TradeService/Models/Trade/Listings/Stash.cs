using System.Text.Json.Serialization;

namespace PoECommerce.TradeService.Models.Trade.Listings
{
    /// <summary>
    ///     Information about the position of the item in the player's stash.
    /// </summary>
    public class Stash
    {
        /// <summary>
        ///     Name of the stash tab.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        ///     X (horizontal) position in the stash tab's grid.
        /// </summary>
        [JsonPropertyName("x")]
        public int X { get; set; }

        /// <summary>
        ///     Y (vertical) position in the stash tab's grid.
        /// </summary>
        [JsonPropertyName("y")]
        public int Y { get; set; }
    }
}