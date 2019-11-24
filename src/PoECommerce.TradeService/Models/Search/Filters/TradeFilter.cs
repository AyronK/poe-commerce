using System.Text.Json.Serialization;
using PoECommerce.TradeService.Models.Search.Filters.Wrappers;

namespace PoECommerce.TradeService.Models.Search.Filters
{
    public class TradeFilter
    {
        [JsonPropertyName("account")]
        public Account Account { get; set; }

        [JsonPropertyName("indexed")]
        public IndexedOption Indexed { get; set; }

        [JsonPropertyName("sale_type")]
        public SaleTypeOption SaleType { get; set; }

        [JsonPropertyName("price")]
        public Price Price { get; set; }
    }
}