using System.Text.Json.Serialization;

namespace PoECommerce.TradeService.Models.Search.Filters
{
    public class SocketsGroupFilter
    {
        [JsonPropertyName("sockets")]
        public SocketsFilter SocketsFilter { get; set; }

        [JsonPropertyName("links")]
        public SocketsFilter LinksFilter { get; set; }
    }
}