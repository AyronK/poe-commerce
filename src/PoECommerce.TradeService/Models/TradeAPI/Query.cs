using System.Text.Json.Serialization;

namespace PoECommerce.TradeService.Models.TradeAPI
{
    public class Query
    {
        /// <summary>
        ///     Item's name.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        ///     Item's base type's name.
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}