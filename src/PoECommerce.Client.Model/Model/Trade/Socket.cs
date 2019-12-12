namespace PoECommerce.Core.Model.Trade
{
    /// <summary>
    ///     Metadata of the socket of the item.
    /// </summary>
    public class Socket
    {
        /// <summary>
        ///     Every socket that has the same group is linked.
        /// </summary>
        public int Group { get; set; }

        /// <summary>
        ///     Colour of the socket.
        /// </summary>
        public SocketType Type { get; set; }
    }
}