namespace PoECommerce.Core.Model.Search
{
    public class RequirementsFilter
    {
        public FilterMagnitude Level { get; set; } = new FilterMagnitude();
        public FilterMagnitude Dexterity { get; set; } = new FilterMagnitude();
        public FilterMagnitude Strength { get; set; } = new FilterMagnitude();
        public FilterMagnitude Intelligence { get; set; } = new FilterMagnitude();
    }
}