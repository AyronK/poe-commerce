using System;

namespace PoECommerce.Core.Model.Search
{
    public class Item
    {
        /// <summary>
        ///     True if the item has not changed since it was linked.
        /// </summary>
        public bool IsVerified { get; set; }

        /// <summary>
        ///     Width of the item in inventory tiles.
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        ///     Height of the item in inventory tiles.
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        ///     Item level.
        /// </summary>
        public int ItemLevel { get; set; }

        /// <summary>
        ///     URL to an image of the item.
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        ///     League identifier.
        /// </summary>
        public string League { get; set; }

        /// <summary>
        ///     True if the item can have elder mods.
        /// </summary>
        public bool IsElder { get; set; }

        /// <summary>
        ///     True if the item can have shaper mods.
        /// </summary>
        public bool IsShaper { get; set; }

        /// <summary>
        ///     True if the item can have fractured mods.
        /// </summary>
        public bool IsFractured { get; set; }

        /// <summary>
        ///     True if the item is a support gem.
        /// </summary>
        public bool IsSupportGem { get; set; }

        /// <summary>
        ///     True if the item is identified.
        /// </summary>
        public bool IsIdentified { get; set; }

        /// <summary>
        ///     True if the item is corrupted.
        /// </summary>
        public bool IsCorrupted { get; set; }

        /// <summary>
        ///     Name of the item.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Name of the item's base item (with prefix and suffix if they exist).
        /// </summary>
        public string TypeName { get; set; }

        public ItemType ItemType { get; set; }

        public string DisplayName => string.Join(Environment.NewLine, Name, TypeName);

        public string Description { get; set; }

        public Property[] Properties { get; set; }

        public Property[] Requirements { get; set; }

        public Property[] AdditionalProperties { get; set; }
        public string ProphecyText { get; set; }
        public string Note { get; set; }

        /// <summary>
        ///     Mods for flasks.
        /// </summary>
        public string[] UtilityMods { get; set; }

        /// <summary>
        ///     Implicit mods.
        /// </summary>
        public string[] ImplicitMods { get; set; }

        /// <summary>
        ///     Explicit mods.
        /// </summary>
        public string[] ExplicitMods { get; set; }

        /// <summary>
        ///     Master crafted mods.
        /// </summary>
        public string[] CraftedMods { get; set; }

        /// <summary>
        ///     Enchantments.
        /// </summary>
        public string[] EnchantMods { get; set; }

        /// <summary>
        ///     Fractured mods.
        /// </summary>
        public string[] FracturedMods { get; set; }

        /// <summary>
        ///     Array of lines of the flavour text of e.g. unique items.
        /// </summary>
        public string[] FlavourText { get; set; }

        /// <summary>
        ///     Pseudo modifiers related to trade side such as '+#% total Elemental Resistance'.
        /// </summary>
        public string[] PseudoMods { get; set; }
    }
}