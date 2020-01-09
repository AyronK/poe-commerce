namespace PoECommerce.PathOfExile.GameClient.Abstractions
{
    public interface IPathOfExileProcessHook
    {
        /// <summary>
        ///     Determines whether Path of Exile process is running and is valid to attach.
        /// </summary>
        bool IsLaunched();

        /// <summary>
        ///     Sets Path of Exile process as a foreground window.
        /// </summary>
        bool FocusGameWindow();
    }
}