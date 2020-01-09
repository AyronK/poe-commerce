namespace PoECommerce.PathOfExile.GameClient.Abstractions
{
    public interface IChatConsole
    {
        /// <summary>
        ///     Opens the chat console
        /// </summary>
        void Open();

        /// <summary>
        ///     Sends the current console input
        /// </summary>
        void Send();

        /// <summary>
        ///     Inputs given text to the chat console
        /// </summary>
        /// <param name="text"></param>
        void WriteText(string text);

        /// <summary>
        ///     Removes all text from the chat console
        /// </summary>
        void ClearText();
    }
}