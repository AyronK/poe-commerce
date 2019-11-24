using System.Text.Json.Serialization;

namespace PoECommerce.TradeService.Models.Search.Enums
{
    public enum ItemRarity
    {
        [JsonEnumName("nonunique")]
        NonUnique,

        [JsonEnumName("normal")]
        Normal,

        [JsonEnumName("magic")]
        Magic,

        [JsonEnumName("rare")]
        Rare,

        [JsonEnumName("unique")]
        Unique,

        [JsonEnumName("uniquefoil")]
        Relic,
    }
}