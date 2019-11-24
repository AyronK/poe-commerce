using System.Text.Json.Serialization;

namespace PoECommerce.TradeService.Models.Search.Enums
{
    public enum SaleType
    {
        [JsonEnumName("priced")]
        Priced,

        [JsonEnumName("unpriced")]
        NotPriced
    }
}