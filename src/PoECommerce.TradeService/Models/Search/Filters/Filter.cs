using System.Text.Json.Serialization;
using PoECommerce.PathOfExile.Models.Search.Filters.Wrappers;

namespace PoECommerce.PathOfExile.Models.Search.Filters
{
    public class Filter
    {
        [JsonPropertyName("type_filters")]
        public FilterWrapper<TypeFilter> TypeFilter { get; set; }

        [JsonPropertyName("weapon_filters")]
        public FilterWrapper<WeaponsFilter> WeaponFilter { get; set; }

        [JsonPropertyName("armour_filters")]
        public FilterWrapper<ArmoursFilter> ArmourFilter { get; set; }

        [JsonPropertyName("socket_filters")]
        public FilterWrapper<SocketsGroupFilter> SocketFilter { get; set; }

        [JsonPropertyName("req_filters")]
        public FilterWrapper<RequirementsFilter> RequirementsFilter { get; set; }

        [JsonPropertyName("misc_filters")]
        public FilterWrapper<MiscellaneousFilter> MiscellaneousFilter { get; set; }

        [JsonPropertyName("map_filters")]
        public FilterWrapper<MapsFilter> MapsFilter { get; set; }

        [JsonPropertyName("trade_filters")]
        public FilterWrapper<TradeFilter> TradeFilter { get; set; }
    }
}