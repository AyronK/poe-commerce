using System.Text.Json.Serialization;
using PoECommerce.PathOfExile.Models.Search.Filters.Wrappers;

namespace PoECommerce.PathOfExile.Models.Search.Filters
{
    public class MiscellaneousFilter
    {
        [JsonPropertyName("quality")]
        public FilterMagnitude Quality { get; set; }

        [JsonPropertyName("gem_level")]
        public FilterMagnitude GemLevel { get; set; }

        [JsonPropertyName("ilvl")]
        public FilterMagnitude ItemLevel { get; set; }

        /// <summary>
        ///     Gem experience in percents. 
        /// </summary>
        [JsonPropertyName("gem_level_progress")]
        public FilterMagnitude GemLevelProgress { get; set; }

        [JsonPropertyName("shaper_item")]
        public BooleanOption Shaper { get; set; }

        [JsonPropertyName("fractured_item")]
        public BooleanOption Fractured { get; set; }

        [JsonPropertyName("alternate_art")]
        public BooleanOption AlternateArt { get; set; }

        [JsonPropertyName("corrupted")]
        public BooleanOption Corrupted { get; set; }

        [JsonPropertyName("crafted")]
        public BooleanOption Crafted { get; set; }

        [JsonPropertyName("enchanted")]
        public BooleanOption Enchanted { get; set; }

        [JsonPropertyName("elder_item")]
        public BooleanOption Elder { get; set; }

        [JsonPropertyName("synthesised_item")]
        public BooleanOption Synthesised { get; set; }

        [JsonPropertyName("identified")]
        public BooleanOption Identified { get; set; }

        [JsonPropertyName("mirrored")]
        public BooleanOption Mirrored { get; set; }

        [JsonPropertyName("veiled")]
        public BooleanOption Veiled { get; set; }

        [JsonPropertyName("talisman_tier")]
        public FilterMagnitude TalismanTier { get; set; }
    }
}