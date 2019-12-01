using System.Text.Json.Serialization;

namespace PoECommerce.PathOfExile.Models.Trade.Enums
{
    /// <summary>
    ///     Attribute type.
    /// </summary>
    public enum Attribute
    {
        [JsonEnumName("S")]
        Strength,

        [JsonEnumName("I")]
        Intelligence,

        [JsonEnumName("D")]
        Dexterity,

        [JsonEnumName("DV")]
        Delve,

        [JsonEnumName("A")]
        Abyss,

        [JsonEnumName("G")]
        UnknownRelatedToWhiteSocket,
    }
}