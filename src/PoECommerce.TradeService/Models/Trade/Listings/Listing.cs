﻿using System;
using System.Text.Json.Serialization;
using PoECommerce.PathOfExile.Models.Trade.Enums;

namespace PoECommerce.PathOfExile.Models.Trade.Listings
{
    public class Listing
    {
        /// <summary>
        ///     Method of item listing.
        /// </summary>
        [JsonPropertyName("method")]
        [JsonConverter(typeof(EnumJsonConverter<ListingMethod>))]
        public ListingMethod Method { get; set; }

        /// <summary>
        ///     Date and time of item being listed.
        /// </summary>
        [JsonPropertyName("indexed")]
        public DateTime Indexed { get; set; }

        /// <summary>
        ///     Information about the position of the item in the seller's stash.
        /// </summary>
        [JsonPropertyName("stash")]
        public Stash Stash { get; set; }

        /// <summary>
        ///     Autogenerated whisper message to buy an item (in the seller's language).
        /// </summary>
        [JsonPropertyName("whisper")]
        public string Whisper { get; set; }

        /// <summary>
        ///     Account information.
        /// </summary>
        [JsonPropertyName("account")]
        public Account Account { get; set; }

        /// <summary>
        ///     Price information.
        /// </summary>
        [JsonPropertyName("price")]
        public Price Price { get; set; }
    }
}