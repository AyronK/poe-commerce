using PoECommerce.PathOfExile.GameClient.Abstractions;

namespace PoECommerce.PathOfExile.GameClient
{
    internal class PathOfExileFacade : IPathOfExileFacade
    {
        public IChat Chat { get; }

        public PathOfExileFacade(IChat chat)
        {
            Chat = chat;
        }
    }
}