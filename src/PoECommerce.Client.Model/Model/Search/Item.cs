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
        ///     Name of the item.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Name of the item's base item (with prefix and suffix if they exist).
        /// </summary>
        public string TypeName { get; set; }
    }
}