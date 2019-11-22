using System.Collections.Generic;
using System.Text.Json.Serialization;
using PoECommerce.TradeService.Json.Serialization;
using PoECommerce.TradeService.Models.Enums;

namespace PoECommerce.TradeService.Models.Trade.Items
{
    /// <summary>
    ///     A set of additional metadata of an item. Can contain emulated values for maximum quality
    ///     if the item is not upgraded yet.
    /// </summary>
    public class ExtendedMetadata
    {
        /// <summary>
        ///     Modifiers' metadata such as tier, values range and name.
        /// </summary>
        [JsonPropertyName("mods")]
        [JsonConverter(typeof(EnumKeyDictionaryJsonConverter<ModifierType, Modifier[]>))]
        public IDictionary<ModifierType, Modifier[]> Modifiers { get; set; }

        [JsonPropertyName("hashes")]
        [JsonConverter(typeof(HashesDictionaryJsonConverter))]
        public IDictionary<ModifierType, Hash[]> Hashes { get; set; }

        /// <summary>
        ///     Damage per Second
        /// </summary>
        [JsonPropertyName("dps")]
        public float? DpS { get; set; }

        /// <summary>
        ///     If true <see cref="DpS" /> is a value if the item was upgraded to max weapon quality (but it is not).
        /// </summary>
        [JsonPropertyName("dps_aug")]
        public bool? IsDpSAugmented { get; set; }

        /// <summary>
        ///     Physical Damage per Second
        /// </summary>
        [JsonPropertyName("pdps")]
        public float? PDpS { get; set; }

        /// <summary>
        ///     If true <see cref="PDpS" /> is a value if the item was upgraded to max weapon quality (but it is not).
        /// </summary>
        [JsonPropertyName("pdps_aug")]
        public bool? IsPDpSAugmented { get; set; }

        /// <summary>
        ///     Elemental Damage per Second (not affected by quality).
        /// </summary>
        [JsonPropertyName("edps")]
        public float? EDpS { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }

        /// <summary>
        ///     The amount of Armour on a piece of armour.  The actual value if <see cref="IsArmourAugmented" /> is false or a
        ///     calculation for the state when the item is upgraded to max armour quality if true.
        /// </summary>
        [JsonPropertyName("ar")]
        public int? Armour { get; set; } //armour

        /// <summary>
        ///     If true <see cref="Armour" /> is a value if the item was upgraded to max armour quality (but it is not).
        /// </summary>
        [JsonPropertyName("ar_aug")]
        public bool? IsArmourAugmented { get; set; } //is at max quality for armour

        /// <summary>
        ///     The amount of Evasion on a piece of armour.  The actual value if <see cref="IsEvasionAugmented" /> is false or a
        ///     calculation for the state when the item is upgraded to max armour quality if true.
        /// </summary>
        [JsonPropertyName("ev")]
        public int? Evasion { get; set; }

        /// <summary>
        ///     If true <see cref="Evasion" /> is a value if the item was upgraded to max armour quality (but it is not).
        /// </summary>
        [JsonPropertyName("ev_aug")]
        public bool? IsEvasionAugmented { get; set; }

        /// <summary>
        ///     The amount of Energy Shield on a piece of armour. The actual value if <see cref="IsEnergyShieldAugmented" /> is
        ///     false or a calculation for the state when the item is upgraded to max armour quality if true.
        /// </summary>
        [JsonPropertyName("es")]
        public int? EnergyShield { get; set; }

        /// <summary>
        ///     If true <see cref="EnergyShield" /> is a value if the item was upgraded to max armour quality (but it is not).
        /// </summary>
        [JsonPropertyName("es_aug")]
        public bool? IsEnergyShieldAugmented { get; set; }
    }
}