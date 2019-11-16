namespace PoECommerce.Client.Shared.Display
{
    public interface IWindow
    {
        int Id { get; }
        bool IsLoaded { get; }
        bool IsOpen { get; }
        bool IsMaximized { get; }
    }
}