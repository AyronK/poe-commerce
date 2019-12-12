using System.Collections.Generic;
using System.Text.Json.Serialization;
using PoECommerce.PathOfExile.Models.Search.Enums;

namespace PoECommerce.PathOfExile.Models.Search
{
    public class QueryCommand
    {
        public QueryCommand()
        {

        }

        public QueryCommand(Query query, IDictionary<string, SortType> sort)
        {
            Query = query;
            Sort = sort;
        }

        [JsonPropertyName("query")]
        public Query Query { get; set; }

        [JsonPropertyName("sort")]
        [JsonConverter(typeof(EnumValueDictionaryJsonConverter<string, SortType>))]
        public IDictionary<string, SortType> Sort { get; set; }

    }
}