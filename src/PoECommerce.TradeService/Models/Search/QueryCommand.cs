using System.Collections.Generic;
using System.Text.Json.Serialization;
using PoECommerce.TradeService.Models.Search.Enums;

namespace PoECommerce.TradeService.Models.Search
{
    public class QueryCommand
    {
        public QueryCommand()
        {

        }

        public QueryCommand(Query query)
        {
            Query = query;
        }

        [JsonPropertyName("query")]
        public Query Query { get; set; }

        [JsonPropertyName("sort")]
        [JsonConverter(typeof(EnumValueDictionaryJsonConverter<string, SortType>))]
        public IDictionary<string, SortType> Sort { get; set; }

    }
}