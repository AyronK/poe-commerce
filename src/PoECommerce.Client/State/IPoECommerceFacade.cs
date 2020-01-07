using PoECommerce.Client.Shared;
using PoECommerce.PathOfExile;

namespace PoECommerce.Client.State
{
    public interface IPoECommerceFacade
    {
        IPathOfExileFacade PathOfExile { get; }
    }
}