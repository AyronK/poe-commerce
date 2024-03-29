﻿using System.Text.Json.Serialization;

namespace PoECommerce.PathOfExile.Models.Search.Filters.Wrappers
{
    public class FilterWrapper<T>
    {
        [JsonPropertyName("disabled")]
        public bool? Disabled { get; set; }

        [JsonPropertyName("filters")]
        public T Filter { get; set; }
    }
}