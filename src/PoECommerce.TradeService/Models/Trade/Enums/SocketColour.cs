using System.Text.Json.Serialization;

namespace PoECommerce.PathOfExile.Models.Trade.Enums
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