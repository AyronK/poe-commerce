using System.Text.Json.Serialization;

namespace PoECommerce.PathOfExile.Models.Search.Enums
{
    public enum Indexed
    {
        [JsonEnumName("1day")]
        OneDay,

        [JsonEnumName("3days")]
        ThreeDays,

        [JsonEnumName("1week")]
        OneWeek,

        [JsonEnumName("2weeks")]
        TwoWeek,

        [JsonEnumName("1month")]
        OneMonth,

        [JsonEnumName("2months")]
        TwoMonths,
    }
}