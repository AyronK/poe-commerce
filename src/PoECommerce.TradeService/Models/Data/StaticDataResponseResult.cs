using System.Collections.Generic;
using System.Text.Json.Serialization;
using PoECommerce.PathOfExile.Models.Enums;

namespace PoECommerce.PathOfExile.Models.Data
{
    public class StaticDataResponseResult : ResponseResult<IDictionary<ItemCategory, StaticData[]>>
    {
        [JsonConverter(typeof(EnumKeyDictionaryJsonConverter<ItemCategory, StaticData[]>))]
        [JsonPropertyName("result")]
        public override IDictionary<ItemCategory, StaticData[]> Result { get; set; }
    }
}