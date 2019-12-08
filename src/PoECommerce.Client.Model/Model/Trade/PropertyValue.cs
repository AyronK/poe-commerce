namespace PoECommerce.Core.Model.Trade
{
    public class PropertyValue
    {
        /// <summary>
        ///     Property value e.g. number or percentage.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        ///     Text formatting type.
        /// </summary>
        public TextFormat Format { get; set; }
    }
}