namespace PoECommerce.Core.Model.Trade
{
    /// <summary>
    ///     Metadata of the property of the item.
    /// </summary>
    public class Property
    {
        /// <summary>
        ///     Unique name of the property.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Property values with information about their display patterns.
        /// </summary>
        public PropertyValue[] Values { get; set; }

        /// <summary>
        ///     How the property should be displayed.
        /// </summary>
        public PropertyDisplayMode DisplayMode { get; set; }

        /// <summary>
        ///     The order in which the lines should be displayed.
        /// </summary>
        public int? Order { get; set; }

        /// <summary>
        ///     Progress values e.g. for incubated items.
        /// </summary>
        public float? Progress { get; set; }
    }
}