using System.Text.Json.Serialization;

namespace PoECommerce.TradeService.Models.Enums
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