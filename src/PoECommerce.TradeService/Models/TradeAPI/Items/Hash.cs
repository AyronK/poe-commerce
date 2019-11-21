namespace PoECommerce.TradeService.Models.TradeAPI.Items
{
    // This model is not serialized directly from json but using custom converter,
    // thus it does not need json related attributes.
    public class Hash
    {
        public string Id { get; set; }

        public int Value { get; set; }
    }
}