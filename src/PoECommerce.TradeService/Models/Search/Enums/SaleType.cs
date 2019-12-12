using System.Text.Json.Serialization;

namespace PoECommerce.PathOfExile.Models.Search.Enums
{
    public enum SaleType
    {
        [JsonEnumName("priced")]
        Priced,

        [JsonEnumName("unpriced")]
        NotPriced
    }
}