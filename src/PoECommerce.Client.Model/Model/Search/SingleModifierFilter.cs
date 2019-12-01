namespace PoECommerce.Core.Model.Search
{
    public class SingleModifierFilter
    {
        public string Id { get; set; }

        public FilterMagnitude Magnitude { get; set; } = new FilterMagnitude();

        public bool Disabled { get; set; } = false;
    }
}