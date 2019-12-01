namespace PoECommerce.Core.Model.Search
{
    public class TradeFilter
    {
        public string AccountName { get; set; }
        public Indexed? Indexed { get; set; }
        public SaleType? SaleType { get; set; }
        public Price Price { get; set; } = new Price();
    }
}