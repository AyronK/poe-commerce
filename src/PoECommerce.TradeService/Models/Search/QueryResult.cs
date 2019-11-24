using System.Text.Json.Serialization;

namespace PoECommerce.TradeService.Models.Search
{
    public class QueryResult
    {
        /// <summary>
        ///     Query ID. Asking about returned item's detail with this ID provides additional info such as pseud modifiers.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        ///     Total amount of items the query found. It can vary from <see cref="Result" /> length, because API can return only
        ///     limited amount of items at once.
        /// </summary>
        [JsonPropertyName("total")]
        public uint Total { get; set; }

        /// <summary>
        ///     Query result in a form of IDs array. To get details about queried item call other component using its ID.
        /// </summary>
        [JsonPropertyName("result")]
        public string[] Result { get; set; }
    }
}