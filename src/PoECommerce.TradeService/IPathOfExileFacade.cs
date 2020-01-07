namespace PoECommerce.PathOfExile
{
    public interface IPathOfExileFacade
    {
        bool IsLaunched();

        IChat Chat { get; }
    }
}