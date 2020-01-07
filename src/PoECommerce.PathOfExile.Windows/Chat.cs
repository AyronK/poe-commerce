using System;
using GregsStack.InputSimulatorStandard;
using GregsStack.InputSimulatorStandard.Native;

namespace PoECommerce.PathOfExile.Windows
{
    internal class Chat : IChat
    {
        private const int MillisecondsTimeoutBeforeInput = 100;
        private readonly IInputSimulator _inputSimulator;

        public Chat(IInputSimulator inputSimulator)
        {
            _inputSimulator = inputSimulator;
        }

        public void Write(string command)
        {
            Write(command, true);
        }

        private void Write(string command, bool submit)
        {
            OpenChat();
            Delay();
            ClearChatInput();
            Delay();
            _inputSimulator.Keyboard.TextEntry(command);

            if (submit)
            {
                CloseChat();
                Delay();
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

            Write("@ " + characterName, false);
        }

        public void WritePrivateMessage(string characterName, string text)
        {
            if (string.IsNullOrWhiteSpace(characterName))
            {
                throw new ArgumentNullException(nameof(characterName), "To start a conversation with a player provide it's character name.");
            }

            Write("@ " + characterName, true);
        }

        private void CloseChat()
        {
            _inputSimulator.Keyboard.KeyPress(VirtualKeyCode.RETURN);
        }

        private void OpenChat()
        {
            _inputSimulator.Keyboard.KeyPress(VirtualKeyCode.RETURN);
        }

        private void ClearChatInput()
        {
            _inputSimulator.Keyboard.ModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_A);
            Delay();

            _inputSimulator.Keyboard.KeyPress(VirtualKeyCode.DELETE);
        }

        private void Delay()
        {
            _inputSimulator.Keyboard.Sleep(MillisecondsTimeoutBeforeInput);
        }
    }
}