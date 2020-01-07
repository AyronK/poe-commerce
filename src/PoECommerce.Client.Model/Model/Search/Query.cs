using System.Collections.Generic;
using PoECommerce.Core.Model.Enums;

namespace PoECommerce.Core.Model.Search
{
    public class Query
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public OnlineStatus? OnlineStatus { get; set; }
        public string League { get; set; }
        public TypeFilter TypeFilter { get; set; }
        public WeaponsFilter WeaponFilter { get; set; }
        public TradeFilter TradeFilter { get; set; }
        public ModifiersFilter ModifiersFilter { get; set; }
        public ArmoursFilter ArmourFilter { get; set; }
        public SocketsGroupFilter SocketFilter { get; set; }
        public RequirementsFilter RequirementsFilter { get; set; }
        public MapsFilter MapsFilter { get; set; }
        public MiscellaneousFilter MiscellaneousFilter { get; set; }
        public IDictionary<string, SortType> Sort { get; set; }
    }
}