﻿using System.Text.Json.Serialization;

namespace PoECommerce.TradeService.Models.TradeAPI
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

    }
}