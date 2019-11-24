using PoECommerce.TradeService.Models.Trade.Enums;

namespace PoECommerce.TradeService.Models.Trade.Items
{
    // This model is not serialized directly from json but using custom converter,
    // thus it does not need json related attributes.
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