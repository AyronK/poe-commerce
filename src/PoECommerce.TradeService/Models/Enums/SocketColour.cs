using System.Text.Json.Serialization;

namespace PoECommerce.TradeService.Models.Enums
{
    /// <summary>
    ///     Socket type.
    /// </summary>
    public enum SocketColour
    {
        [JsonEnumName("B")]
        Blue,

        [JsonEnumName("R")]
        Red,

        [JsonEnumName("G")]
        Green,

        [JsonEnumName("W")]
        White,

        [JsonEnumName("A")]
        Abyss,

        [JsonEnumName("DV")]
        Delve,
    }
}