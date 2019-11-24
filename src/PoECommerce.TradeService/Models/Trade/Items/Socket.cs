using System.Text.Json.Serialization;
using PoECommerce.TradeService.Models.Trade.Enums;

namespace PoECommerce.TradeService.Models.Trade.Items
{
    /// <summary>
    ///     Metadata of the socket of the item.
    /// </summary>
    public class Socket
    {
        /// <summary>
        ///     Every socket that has the same group is linked.
        /// </summary>
        [JsonPropertyName("group")]
        public int Group { get; set; }

        /// <summary>
        ///     Attribute (Dex, Int, Str). Colour of the socket originates from attribute requirement.
        /// </summary>
        [JsonPropertyName("attr")]
        [JsonConverter(typeof(NullableEnumJsonConverter<Attribute>))]
        public Attribute? Attribute { get; set; }

        /// <summary>
        ///     Colour of the socket.
        /// </summary>
        [JsonPropertyName("sColour")]
        [JsonConverter(typeof(EnumJsonConverter<SocketColour>))]
        public SocketColour Colour { get; set; }
    }
}