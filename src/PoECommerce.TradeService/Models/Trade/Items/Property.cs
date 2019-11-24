using System.Text.Json.Serialization;
using PoECommerce.PathOfExile.Json.Serialization;
using PoECommerce.PathOfExile.Models.Trade.Items.Enums;

namespace PoECommerce.PathOfExile.Models.Trade.Items
{
    /// <summary>
    ///     Metadata of the property of the item.
    /// </summary>
    public class Property
    {
        /// <summary>
        ///     Unique name of the property.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        ///     Property values with information about their display patterns.
        /// </summary>
        [JsonPropertyName("values")]
        [JsonConverter(typeof(ArrayJsonConverter<PropertyValue, PropertyValueJsonConverter>))]
        public PropertyValue[] Values { get; set; }

        /// <summary>
        ///     How the property should be displayed.
        /// </summary>
        [JsonPropertyName("displayMode")]
        public PropertyDisplayMode DisplayMode { get; set; }

        /// <summary>
        ///     The order in which the lines should be displayed.
        /// </summary>
        [JsonPropertyName("type")]
        public int? Order { get; set; }

        /// <summary>
        ///     Progress values e.g. for incubated items.
        /// </summary>
        [JsonPropertyName("progress")]
        public float? Progress { get; set; }
    }
}