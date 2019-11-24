using System.Text.Json.Serialization;

namespace PoECommerce.PathOfExile.Models.Trade.Enums
{
    /// <summary>
    ///     Type of item listing method.
    /// </summary>
    public enum ListingMethod
    {
        /// <summary>
        ///     Premium stash tab API/
        /// </summary>
        [JsonEnumName("psapi")]
        PremiumStashTab,

        /// <summary>
        ///     Forum thread.
        /// </summary>
        [JsonEnumName("forum")]
        Forum
    }
}