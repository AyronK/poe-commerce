namespace PoECommerce.Core.Model.Search
{
    public class SearchResult
    {
        public string QueryId { get; set; }

        public uint Total { get; set; }

        public string[] ItemIds { get; set; }
    }
}