using GregsStack.InputSimulatorStandard;
using GregsStack.InputSimulatorStandard.Native;
using PoECommerce.PathOfExile.GameClient.Abstractions;

namespace PoECommerce.PathOfExile.Windows
{
    internal class PathOfExileInput : IPathOfExileInput
    {
        private const int MillisecondsTimeoutBeforeInput = 100;

        private readonly IInputSimulator _inputSimulator;

        public PathOfExileInput(IInputSimulator inputSimulator)
        {
            _inputSimulator = inputSimulator;
        }

        public void OpenChat()
        {
            _inputSimulator.Keyboard.KeyPress(VirtualKeyCode.RETURN);
            Delay();
        }

        public void SendChatInput()
        {
            _inputSimulator.Keyboard.KeyPress(VirtualKeyCode.RETURN);
            Delay();
        }

        public void WriteChatInput(string text)
        {
            _inputSimulator.Keyboard.TextEntry(text);
            Delay();
        }

        public void ClearChatInput()
        {
            _inputSimulator.Keyboard.ModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_A);

            Delay();

            _inputSimulator.Keyboard.KeyPress(VirtualKeyCode.DELETE);

            Delay();
        }

        public void CopyItemToClipboard()
        {
            _inputSimulator.Keyboard.ModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_C);

            Delay();
        }

        private void Delay()
        {
            _inputSimulator.Keyboard.Sleep(MillisecondsTimeoutBeforeInput);
        }
    }
}