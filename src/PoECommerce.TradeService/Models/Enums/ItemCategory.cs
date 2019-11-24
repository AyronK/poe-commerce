using System.Text.Json.Serialization;

namespace PoECommerce.PathOfExile.Models.Enums
{
    public enum ItemCategory
    {
        [JsonEnumName("Accessories")]
        Accessory,

        [JsonEnumName("Armour")]
        Armour,

        [JsonEnumName("cards", "Cards")]
        DivinationCard,

        [JsonEnumName("currency" ,"Currency")]
        Currency,

        [JsonEnumName("Flasks")]
        Flask,

        [JsonEnumName("Gems")]
        Gem,

        [JsonEnumName("Jewels")]
        Jewel,

        [JsonEnumName("maps", "Maps")]
        NormalMap,

        [JsonEnumName("shaped_maps")]
        ShapedMap,

        [JsonEnumName("elder_maps")]
        ElderMap,

        [JsonEnumName("blighted_maps")]
        BlightedMap,

        [JsonEnumName("Weapons")]
        Weapon,

        [JsonEnumName("leaguestones", "Leaguestones")]
        Leaguestone,

        [JsonEnumName("Prophecies")]
        Prophecy,

        [JsonEnumName("Captured Beasts")]
        CapturedBeast,

        [JsonEnumName("fragments")]
        Fragment,

        [JsonEnumName("oils")]
        Oil,

        [JsonEnumName("incubators")]
        Incubator,

        [JsonEnumName("scarabs")]
        Scarab,

        [JsonEnumName("resonators")]
        Resonator,

        [JsonEnumName("fossils")]
        Fossil,

        [JsonEnumName("vials")]
        Vial,

        [JsonEnumName("nets")]
        Net,

        [JsonEnumName("essences")]
        Essence,

        [JsonEnumName("misc")]
        Misc
    }
}