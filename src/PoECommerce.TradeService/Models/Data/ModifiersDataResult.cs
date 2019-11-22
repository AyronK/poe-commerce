using System.Text.Json.Serialization;
using PoECommerce.TradeService.Models.Enums;

namespace PoECommerce.TradeService.Models.Data
{
    public class ModifiersDataResult
    {
        [JsonPropertyName("label")]
        [JsonConverter(typeof(EnumJsonConverter<ModifierType>))]
        public ModifierType ModifierType { get; set; }

        [JsonPropertyName("entries")]
        public Modifier[] Modifiers { get; set; }
    }
}