namespace PoECommerce.PathOfExile.GameClient.Abstractions
{
    public interface IPathOfExileInput
    {
        /// <summary>
        ///     Opens the chat console
        /// </summary>
        void OpenChat();

        /// <summary>
        ///     Sends the current console input
        /// </summary>
        void SendChatInput();

        /// <summary>
        ///     Inputs given text to the chat console
        /// </summary>
        /// <param name="text">Text to input to the chat console</param>
        void WriteChatInput(string text);

        /// <summary>
        ///     Removes all text from the chat console
        /// </summary>
        void ClearChatInput();

        /// <summary>
        ///     Copies an item on the cursor to the clipboard
        /// </summary>
        void CopyItemToClipboard();
    }
}