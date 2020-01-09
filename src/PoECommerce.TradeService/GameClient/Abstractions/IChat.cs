using System;

namespace PoECommerce.PathOfExile.GameClient.Abstractions
{
    public interface IChat
    {
        /// <summary>
        ///     Determines whether chat window is ready to accept input
        /// </summary>
        /// <returns></returns>
        bool CanWrite();

        /// <summary>
        ///     Writes and sends passed text to chat window
        /// </summary>
        /// <param name="command"></param>
        /// <exception cref="InvalidOperationException">Chat console is unreachable e.g. due to the game process being not attached</exception>
        void Write(string command);

        /// <summary>
        ///     Sends '/dnd {command}' message to chat window
        /// </summary>
        /// <param name="message">Message written on auto-reply</param>
        /// <exception cref="InvalidOperationException">Chat console is unreachable e.g. due to the game process being not attached</exception>
        void DoNotDisturb(string message);

        /// <summary>
        ///     Sends '/afk {command}' message to chat window
        /// </summary>
        /// <param name="message">Message written on auto-reply</param>
        /// <exception cref="InvalidOperationException">Chat console is unreachable e.g. due to the game process being not attached</exception>
        void AwayFromKeyboard(string message);

        /// <summary>
        ///      Kick the player from the party. Sends '/kick {player}' message to chat window
        /// </summary>
        /// <param name="characterName">Character name</param>
        /// <exception cref="InvalidOperationException">Chat console is unreachable e.g. due to the game process being not attached</exception>
        /// <exception cref="ArgumentNullException"><see cref="characterName"/> is null/empty/whitespace</exception>
        void KickFromParty(string characterName);

        /// <summary>
        ///     Invites the player to the party. Sends '/invite {characterName}' message to chat window
        /// </summary>
        /// <param name="characterName">Character name</param>
        /// <exception cref="InvalidOperationException">Chat console is unreachable e.g. due to the game process being not attached</exception>
        /// <exception cref="ArgumentNullException"><see cref="characterName"/> is null/empty/whitespace</exception>
        void InviteToParty(string characterName);

        /// <summary>
        ///     Adds the player to ignore list. Sends '/ignore {characterName}' message to chat window
        /// </summary>
        /// <param name="characterName">Character name</param>
        /// <exception cref="InvalidOperationException">Chat console is unreachable e.g. due to the game process being not attached</exception>
        /// <exception cref="ArgumentNullException"><see cref="characterName"/> is null/empty/whitespace</exception>
        void Ignore(string characterName);

        /// <summary>
        ///     Opens a private message window without sending any text. '@{characterName} ` will show up in the chat window
        /// </summary>
        /// <param name="characterName">Message written on auto-reply</param>
        /// <exception cref="InvalidOperationException">Chat console is unreachable e.g. due to the game process being not attached</exception>
        /// <exception cref="ArgumentNullException"><see cref="characterName"/> is null/empty/whitespace</exception>
        void OpenPrivateMessage(string characterName);

        /// <summary>
        ///     Sends a given text to the player. Sends '@{characterName} {text}` message to chat window
        /// </summary>
        /// <param name="characterName">Message written on auto-reply</param>
        /// <param name="text"></param>
        /// <exception cref="InvalidOperationException">Chat console is unreachable e.g. due to the game process being not attached</exception>
        /// <exception cref="ArgumentNullException"><see cref="characterName"/> is null/empty/whitespace</exception>
        void WritePrivateMessage(string characterName, string text);
    }
}