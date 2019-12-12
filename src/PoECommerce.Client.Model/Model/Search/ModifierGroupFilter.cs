using System.Collections.Generic;

namespace PoECommerce.Core.Model.Search
{
    public class ModifierGroupFilter
    {
        public FilterOperand Operand { get; set; } = FilterOperand.And;

        public List<SingleModifierFilter> Filters { get; set; } = new List<SingleModifierFilter>();
    }
}