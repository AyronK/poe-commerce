using System.Text.Json.Serialization;

namespace PoECommerce.TradeService.Models.Enums
{
    /// <summary>
    ///     Modifier type.
    /// </summary>
    public enum ModifierType
    {
        [JsonEnumName("implicit")]
        Implicit,
        [JsonEnumName("explicit")]
        Explicit,
        [JsonEnumName("crafted")]
        Crafted,
        [JsonEnumName("enchant")]
        Enchant,
        [JsonEnumName("delve")]
        Delve,
        [JsonEnumName("pseudo")]
        Pseudo,
    }
}