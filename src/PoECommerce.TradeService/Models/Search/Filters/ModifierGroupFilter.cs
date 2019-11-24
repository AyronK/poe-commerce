using System.Text.Json.Serialization;
using PoECommerce.TradeService.Models.Search.Enums;

namespace PoECommerce.TradeService.Models.Search.Filters
{
    public class ModifierGroupFilter
    {
        [JsonPropertyName("type")]
        [JsonConverter(typeof(EnumJsonConverter<FilterOperand>))]
        public FilterOperand Operand { get; set; }

        [JsonPropertyName("filters")]
        public ModifierFilter[] Filters { get; set; }
    }
}