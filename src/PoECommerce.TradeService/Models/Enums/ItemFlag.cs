using System.Text.Json.Serialization;

namespace PoECommerce.TradeService.Models.Enums
{
    public enum ItemFlag
    {
        [JsonEnumName("prophecy")]
        Prophecy,

        [JsonEnumName("unique")]
        Unique
    }
}