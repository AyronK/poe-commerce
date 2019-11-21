using System.Text.Json.Serialization;
using PoECommerce.TradeService.Models.Enums;

namespace PoECommerce.TradeService.Models.TradeAPI.Items
{
    public class Item
    {
        /// <summary>
        ///     True if the item has not changed since it was linked.
        /// </summary>
        [JsonPropertyName("verified")]
        public bool IsVerified { get; set; }

        /// <summary>
        ///     Width of the item in inventory tiles.
        /// </summary>
        [JsonPropertyName("w")]
        public int Width { get; set; }

        /// <summary>
        ///     Height of the item in inventory tiles.
        /// </summary>
        [JsonPropertyName("h")]
        public int Height { get; set; }

        /// <summary>
        ///     Item level.
        /// </summary>
        [JsonPropertyName("ilvl")]
        public int ItemLevel { get; set; }

        /// <summary>
        ///     URL to an image of the item.
        /// </summary>
        [JsonPropertyName("icon")]
        public string Icon { get; set; }

        /// <summary>
        ///     League identifier.
        /// </summary>
        [JsonPropertyName("league")]
        public string League { get; set; }

        /// <summary>
        ///     True if the item can have elder mods.
        /// </summary>
        [JsonPropertyName("elder")]
        public bool IsElder { get; set; }

        /// <summary>
        ///     True if the item can have shaper mods.
        /// </summary>
        [JsonPropertyName("shaper")]
        public bool IsShaper { get; set; }

        /// <summary>
        ///     True if the item can have fractured mods.
        /// </summary>
        [JsonPropertyName("fractured")]
        public bool IsFractured { get; set; }

        /// <summary>
        ///     True if the item is a support gem.
        /// </summary>
        [JsonPropertyName("support")]
        public bool IsSupportGem { get; set; }

        /// <summary>
        ///     Metadata of the sockets of the item.
        /// </summary>
        [JsonPropertyName("sockets")]
        public Socket[] Sockets { get; set; }

        /// <summary>
        ///     Name of the item.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        ///     Name of the item's base item (with prefix and suffix if they exist).
        /// </summary>
        [JsonPropertyName("typeLine")]
        public string TypeName { get; set; }

        /// <summary>
        ///     True if the item is identified.
        /// </summary>
        [JsonPropertyName("identified")]
        public bool IsIdentified { get; set; }

        /// <summary>
        ///     True if the item is corrupted.
        /// </summary>
        [JsonPropertyName("corrupted")]
        public bool IsCorrupted { get; set; }

        /// <summary>
        ///     Player's note on the item.
        /// </summary>
        [JsonPropertyName("note")]
        public string Note { get; set; }

        /// <summary>
        ///     Properties of the item.
        /// </summary>
        [JsonPropertyName("properties")]
        public Property[] Properties { get; set; }

        /// <summary>
        ///     Additional properties of the item.
        /// </summary>
        [JsonPropertyName("additionalProperties")]
        public Property[] AdditionalProperties { get; set; }

        /// <summary>
        ///     Requirements of the item.
        /// </summary>
        [JsonPropertyName("requirements")]
        public Property[] Requirements { get; set; }

        /// <summary>
        ///     Mods for flasks.
        /// </summary>
        [JsonPropertyName("utilityMods")]
        public string[] UtilityMods { get; set; }

        /// <summary>
        ///     Implicit mods.
        /// </summary>
        [JsonPropertyName("implicitMods")]
        public string[] ImplicitMods { get; set; }
        /// <summary>
        ///     Explicit mods.
        /// </summary>
        [JsonPropertyName("explicitMods")]
        public string[] ExplicitMods { get; set; }

        /// <summary>
        ///     Master crafted mods.
        /// </summary>
        [JsonPropertyName("craftedMods")]
        public string[] CraftedMods { get; set; }

        /// <summary>
        ///     Enchantments.
        /// </summary>
        [JsonPropertyName("enchantMods")]
        public string[] EnchantMods { get; set; }

        /// <summary>
        ///     Fractured mods.
        /// </summary>
        [JsonPropertyName("fracturedMods")]
        public string[] FracturedMods { get; set; }

        /// <summary>
        ///     Array of lines of the flavour text of e.g. unique items.
        /// </summary>
        [JsonPropertyName("flavourText")]
        public string[] FlavourText { get; set; }

        /// <summary>
        ///     Frame type of the item depending on rarity or item type (e.g. gem).
        /// </summary>
        [JsonPropertyName("frameType")]
        public FrameType FrameType { get; set; }

        /// <summary>
        ///     True if the item is a relic item.
        /// </summary>
        [JsonPropertyName("isRelic")]
        public bool IsRelic { get; set; }

        /// <summary>
        ///     Extended metadata for item's statistics and properties such as range or max quality calculation.
        /// </summary>
        [JsonPropertyName("extended")]
        public ExtendedMetadata Extended { get; set; }

        /// <summary>
        ///     Description.
        /// </summary>
        [JsonPropertyName("descrText")]
        public string DescriptionText { get; set; }

        /// <summary>
        ///     Secondary description.
        /// </summary>
        [JsonPropertyName("secDescrText")]
        public string SecondaryDescriptionText { get; set; }

        /// <summary>
        ///     If the item is stackable, current stack size.
        /// </summary>
        [JsonPropertyName("stackSize")]
        public int? StackSize { get; set; }

        /// <summary>
        ///     If the item is stackable, max stack size.
        /// </summary>
        [JsonPropertyName("maxStackSize")]
        public int? MaxStackSize { get; set; }

        /// <summary>
        ///     Text of the prophecy.
        /// </summary>
        [JsonPropertyName("prophecyText")]
        public string ProphecyText { get; set; }

        /// <summary>
        ///     Filename of an art related to the item (e.g. divination card artwork).
        /// </summary>
        [JsonPropertyName("artFilename")]
        public string ArtFilename { get; set; }

        /// <summary>
        ///     True if the item is a delve resonator.
        /// </summary>
        [JsonPropertyName("delve")]
        public bool IsDelve { get; set; }

        /// <summary>
        ///     Metadata of the incubated item.
        /// </summary>
        [JsonPropertyName("incubatedItem")]
        public IncubatedItem IncubatedItem { get; set; }

        /// <summary>
        ///     Pseudo modifiers related to trade side such as '+#% total Elemental Resistance'.
        /// </summary>
        [JsonPropertyName("pseudoMods")]
        public string[] PseudoMods { get; set; }
    }
}