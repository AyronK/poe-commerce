using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PoECommerce.Client.Shared.Display
{
    public interface IWindowManager
    {
        Task LoadUrl(int windowId, string url);
        Task Show(int windowId);
        Task Hide(int windowId);
        Task Close(int windowId);
        Task Minimize(int windowId);
        Task Maximize(int windowId);
        Task ResizeAndPosition(int windowId, int x, int y, int width, int height);
        Task ResizeAndPlaceOnCursor(int windowId, int width, int height);

        IReadOnlyList<IWindow> Windows { get; }
    }
}
