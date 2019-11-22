namespace PoECommerce.TradeService.Tests.Utility
{
    public class ModelToJsonTestCase<T>
    {
        public T Subject { get; set; }
        public string ExpectedJson { get; set; }
        public string Description { get; set; }
    }
}