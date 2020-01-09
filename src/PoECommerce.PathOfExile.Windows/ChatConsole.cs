using GregsStack.InputSimulatorStandard;
using GregsStack.InputSimulatorStandard.Native;
using PoECommerce.PathOfExile.GameClient.Abstractions;

namespace PoECommerce.PathOfExile.Windows
{
    internal class ChatConsole : IChatConsole
    {
        private const int MillisecondsTimeoutBeforeInput = 100;

        private readonly IInputSimulator _inputSimulator;

        public ChatConsole(IInputSimulator inputSimulator)
        {
            _inputSimulator = inputSimulator;
        }

        public void Open()
        {
            _inputSimulator.Keyboard.KeyPress(VirtualKeyCode.RETURN);
            Delay();
        }

        public void Send()
        {
            _inputSimulator.Keyboard.KeyPress(VirtualKeyCode.RETURN);
            Delay();
        }

        public void WriteText(string text)
        {
            _inputSimulator.Keyboard.TextEntry(text);
            Delay();
        }

        public void ClearText()
        {
            _inputSimulator.Keyboard.ModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_A);

            Delay();

            _inputSimulator.Keyboard.KeyPress(VirtualKeyCode.DELETE);

            Delay();
        }

        private void Delay()
        {
            _inputSimulator.Keyboard.Sleep(MillisecondsTimeoutBeforeInput);
        }
    }
}