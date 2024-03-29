﻿using System.Collections.Generic;
using System.Text.Json.Serialization;
using PoECommerce.PathOfExile.Models.Data.Enums;

namespace PoECommerce.PathOfExile.Models.Data
{
    public class Item
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("flags")]
        [JsonConverter(typeof(EnumKeyDictionaryJsonConverter<ItemFlag, bool>))]
        public IDictionary<ItemFlag, bool> Flags { get; set; }

        /// <summary>
        ///     E.g. map origins (atlasofworlds, theawakening).
        /// </summary>
        [JsonPropertyName("disc")]
        public string Discriminator { get; set; }
    }
}