using System.Text.Json.Serialization;

namespace PoECommerce.TradeService.Models.TradeAPI.Listings
{
    public class Online
    {
        /// <summary>
        ///     The league the player is currently logged in.
        /// </summary>
        [JsonPropertyName("league")]
        public string League { get; set; }

        /// <summary>
        ///     Status of the player e.g. "afk".
        /// </summary>
        [JsonPropertyName("status")]
        public string Status { get; set; }
    }
}