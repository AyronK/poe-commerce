using System;
using PoECommerce.PathOfExile.GameClient.Abstractions;

namespace PoECommerce.PathOfExile.GameClient
{
    internal class Chat : IChat
    {
        private readonly IChatConsole _chatConsole;
        private readonly IPathOfExileProcessHook _processHook;

        public Chat(IChatConsole chatConsole, IPathOfExileProcessHook processHook)
        {
            _chatConsole = chatConsole;
            _processHook = processHook;
        }

        public bool CanWrite()
        {
            return _processHook.IsLaunched();
        }

        public void Write(string command)
        {

            if (!_processHook.IsLaunched())
            {
                throw new InvalidOperationException("Path of Exile game client is not launched or cannot be accessed.");
            }

            if (!_processHook.FocusGameWindow())
            {
                throw new InvalidOperationException("Path of Exile game client is not launched or cannot be focused.");
            }
            
            Write(command, true);
        }

        private void Write(string command, bool submit)
        {
            _chatConsole.Open();
            _chatConsole.ClearText();
            _chatConsole.WriteText(command);

            if (submit)
            {
                _chatConsole.Send();
            }
        }

        public void DoNotDisturb(string message = null)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                Write("/dnd");
            }
            else
            {
                Write("/dnd " + message);
            }
        }

        public void AwayFromKeyboard(string message = null)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                Write("/afk");
            }
            else
            {
                Write("/afk " + message);
            }
        }

        public void KickFromParty(string characterName)
        {
            if (string.IsNullOrWhiteSpace(characterName))
            {
                throw new ArgumentNullException(nameof(characterName), "To kick a player from your party provide it's character name.");
            }

            Write("/kick " + characterName);
        }

        public void InviteToParty(string characterName)
        {
            if (string.IsNullOrWhiteSpace(characterName))
            {
                throw new ArgumentNullException(nameof(characterName), "To invite a player to your party provide it's character name.");
            }

            Write("/invite " + characterName);
        }

        public void Ignore(string characterName)
        {
            if (string.IsNullOrWhiteSpace(characterName))
            {
                throw new ArgumentNullException(nameof(characterName), "To ignore a player provide it's character name.");
            }

            Write("/ignore " + characterName);
        }

        public void OpenPrivateMessage(string characterName)
        {
            if (string.IsNullOrWhiteSpace(characterName))
            {
                throw new ArgumentNullException(nameof(characterName), "To start a conversation with a player provide it's character name.");
            }

            Write("@ " + characterName + " ", false);
        }

        public void WritePrivateMessage(string characterName, string text)
        {
            if (string.IsNullOrWhiteSpace(characterName))
            {
                throw new ArgumentNullException(nameof(characterName), "To start a conversation with a player provide it's character name.");
            }

            Write("@ " + characterName + " " + text, true);
        }
    }
}