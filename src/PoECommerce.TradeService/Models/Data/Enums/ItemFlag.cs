using System.Text.Json.Serialization;

namespace PoECommerce.TradeService.Models.Data.Enums
{
    public enum ItemFlag
    {
        [JsonEnumName("prophecy")]
        Prophecy,

        [JsonEnumName("unique")]
        Unique
    }
}