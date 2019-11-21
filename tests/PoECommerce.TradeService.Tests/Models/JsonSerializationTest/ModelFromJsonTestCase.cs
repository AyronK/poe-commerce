namespace PoECommerce.TradeService.Tests.Models.JsonSerializationTest
{
    public class ModelFromJsonTestCase<T>
    {
        public string Json { get; set; }
        public T ExpectedResult { get; set; }
        public string Description { get; set; }
    }
}