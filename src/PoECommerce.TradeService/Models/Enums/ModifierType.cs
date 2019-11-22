using System.Text.Json.Serialization;

namespace PoECommerce.TradeService.Models.Enums
{
    /// <summary>
    ///     Modifier type.
    /// </summary>
    public enum ModifierType
    {
        [JsonEnumName("implicit", "Implicit")]
        Implicit,

        [JsonEnumName("explicit", "Explicit")]
        Explicit,

        [JsonEnumName("crafted", "Crafted")]
        Crafted,

        [JsonEnumName("fractured", "Fractured")]
        Fractured,

        [JsonEnumName("veiled", "Veiled")]
        Veiled,

        [JsonEnumName("monster", "Monster")]
        Monster,

        [JsonEnumName("enchant", "Enchant")]
        Enchant,

        [JsonEnumName("delve", "Delve")]
        Delve,

        [JsonEnumName("pseudo", "Pseudo")]
        Pseudo
    }
}