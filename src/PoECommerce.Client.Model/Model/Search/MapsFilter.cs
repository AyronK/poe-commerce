namespace PoECommerce.Core.Model.Search
{
    public class MapsFilter
    {
        public FilterMagnitude Tier { get; set; } = new FilterMagnitude();
        public FilterMagnitude IncreasedItemQuantity { get; set; } = new FilterMagnitude();
        public FilterMagnitude PackSize { get; set; } = new FilterMagnitude();
        public FilterMagnitude IncreasedItemRarity { get; set; } = new FilterMagnitude();
        public bool? Shaped { get; set; }
        public bool? Blighted { get; set; }
        public bool? Elder { get; set; }
        public string Series { get; set; }
    }
}