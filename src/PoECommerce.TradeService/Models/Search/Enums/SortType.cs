using System.Text.Json.Serialization;

namespace PoECommerce.TradeService.Models.Search.Enums
{
    public enum SortType
    {
        [JsonEnumName("asc")]
        Ascending,

        [JsonEnumName("desc")]
        Descending
    }
}