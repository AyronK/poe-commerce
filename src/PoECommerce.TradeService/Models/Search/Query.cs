using System.Text.Json.Serialization;
using PoECommerce.PathOfExile.Models.Search.Filters;
using PoECommerce.PathOfExile.Models.Search.Filters.Wrappers;

namespace PoECommerce.PathOfExile.Models.Search
{
    public class Query
    {
        [JsonPropertyName("status")]
        public OnlineStatusOption Status { get; set; }

        /// <summary>
        ///     Item's custom expression. Use if there is no known <see cref="Name"/> and <see cref="Type"/>
        /// </summary>
        [JsonPropertyName("term")]
        public string Text { get; set; }

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

        [JsonPropertyName("stats")]
        public ModifierGroupFilter[] ModifiersFilters { get; set; }

        [JsonPropertyName("filters")]
        public Filter Filter { get; set; }
    }
}