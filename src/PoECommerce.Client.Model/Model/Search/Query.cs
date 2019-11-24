namespace PoECommerce.Core.Model.Search
{
    public class Query
    {
        public string Text { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public OnlineStatus? OnlineStatus { get; set; }
        public string League { get; set; }
    }
}