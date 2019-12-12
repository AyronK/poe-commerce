namespace PoECommerce.Core.Model.Search
{
    public class ArmoursFilter
    {
        public FilterMagnitude Armour { get; set; } = new FilterMagnitude();
        public FilterMagnitude EnergyShield { get; set; } = new FilterMagnitude();
        public FilterMagnitude Evasion { get; set; } = new FilterMagnitude();
        public FilterMagnitude Block { get; set; } = new FilterMagnitude();
    }
}