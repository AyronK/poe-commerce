using System.Text.Json.Serialization;

namespace PoECommerce.TradeService.Models.Trade.Listings
{
    public class Account
    {
        /// <summary>
        ///     Name of the account.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        ///     Name of the last character the player used on this account.
        /// </summary>
        [JsonPropertyName("lastCharacterName")]
        public string LastCharacterName { get; set; }

        /// <summary>
        ///     Information about the online status. Null if the player is offline.
        /// </summary>
        [JsonPropertyName("online")]
        public Online Online { get; set; }

        /// <summary>
        ///     The language the player is using as a default (e.g. "en_US").
        /// </summary>
        [JsonPropertyName("language")]
        public string Language { get; set; }
    }
}