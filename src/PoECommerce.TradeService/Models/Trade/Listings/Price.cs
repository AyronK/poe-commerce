using System.Text.Json.Serialization;

namespace PoECommerce.TradeService.Models.Trade.Listings
{
    public class Price
    {
        /// <summary>
        ///     Type of the listed price (~price, ~b/o, ~fixed etc.).
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        ///     The amount of requested currency.
        /// </summary>
        [JsonPropertyName("amount")]
        public double? Amount { get; set; }

        /// <summary>
        ///     Name of the requested currency (e.g. "chrom", "fus", "exe" etc.).
        /// </summary>
        [JsonPropertyName("currency")]
        public string Currency { get; set; }
    }
}