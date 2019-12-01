using System.Collections.Generic;

namespace PoECommerce.Core.Model.Search
{
    public class ModifiersFilter
    {
        public List<ModifierGroupFilter> GroupFilters { get; set; } = new List<ModifierGroupFilter>();
    }
}