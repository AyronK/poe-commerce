namespace PoECommerce.Core.Model.Search
{
    public class SocketsGroupFilter
    {
        public SocketsFilter SocketsFilter { get; set; } = new SocketsFilter();
        public SocketsFilter LinksFilter { get; set; } = new SocketsFilter();
    }
}