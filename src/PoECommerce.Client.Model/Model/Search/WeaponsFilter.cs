namespace PoECommerce.Core.Model.Search
{
    public class WeaponsFilter
    {
        public FilterMagnitude Damage { get; set; } = new FilterMagnitude();
        public FilterMagnitude CriticalChance { get; set; } = new FilterMagnitude();
        public FilterMagnitude PhysicalDps { get; set; } = new FilterMagnitude();
        public FilterMagnitude AttacksPerSecond { get; set; } = new FilterMagnitude();
        public FilterMagnitude Dps { get; set; } = new FilterMagnitude();
        public FilterMagnitude ElementalDps { get; set; } = new FilterMagnitude();

    }
}