﻿using System.Text.Json.Serialization;

namespace PoECommerce.PathOfExile.Models.Search.Enums
{
    public enum FilterOperand
    {
        [JsonEnumName("and")]
        And,

        [JsonEnumName("not")]
        Not,

        [JsonEnumName("if")]
        If,

        [JsonEnumName("count")]
        Count,

        [JsonEnumName("weight")]
        Weight,
    }
}