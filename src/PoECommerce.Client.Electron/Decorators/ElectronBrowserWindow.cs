using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ElectronNET.API;
using ElectronNET.API.Entities;
using PoECommerce.Client.Electron.Abstraction;

namespace PoECommerce.Client.Electron.Decorators
{
    internal class ElectronBrowserWindow : IBrowserWindow
    {
        private readonly BrowserWindow _window;

        public ElectronBrowserWindow(BrowserWindow window)
        {
            _window = window;
        }

        public int Id => _window.Id;

        public IReadOnlyCollection<MenuItem> MenuItems => _window.MenuItems;

        public IReadOnlyCollection<ThumbarButton> ThumbarButtons => _window.ThumbarButtons;

        public WebContents WebContents => _window.WebContents;

        public event Action OnReadyToShow
        {
            add => _window.OnReadyToShow += value;
            remove => _window.OnReadyToShow -= value;
        }

        public event Action<string> OnPageTitleUpdated
        {
            add => _window.OnPageTitleUpdated += value;
            remove => _window.OnPageTitleUpdated -= value;
        }

        public event Action OnClose
        {
            add => _window.OnClose += value;
            remove => _window.OnClose -= value;
        }

        public event Action OnClosed
        {
            add => _window.OnClosed += value;
            remove => _window.OnClosed -= value;
        }

        public event Action OnSessionEnd
        {
            add => _window.OnSessionEnd += value;
            remove => _window.OnSessionEnd -= value;
        }

        public event Action OnUnresponsive
        {
            add => _window.OnUnresponsive += value;
            remove => _window.OnUnresponsive -= value;
        }

        public event Action OnResponsive
        {
            add => _window.OnResponsive += value;
            remove => _window.OnResponsive -= value;
        }

        public event Action OnBlur
        {
            add => _window.OnBlur += value;
            remove => _window.OnBlur -= value;
        }

        public event Action OnFocus
        {
            add => _window.OnFocus += value;
            remove => _window.OnFocus -= value;
        }

        public event Action OnShow
        {
            add => _window.OnShow += value;
            remove => _window.OnShow -= value;
        }

        public event Action OnHide
        {
            add => _window.OnHide += value;
            remove => _window.OnHide -= value;
        }

        public event Action OnMaximize
        {
            add => _window.OnMaximize += value;
            remove => _window.OnMaximize -= value;
        }

        public event Action OnUnmaximize
        {
            add => _window.OnUnmaximize += value;
            remove => _window.OnUnmaximize -= value;
        }

        public event Action OnMinimize
        {
            add => _window.OnMinimize += value;
            remove => _window.OnMinimize -= value;
        }

        public event Action OnRestore
        {
            add => _window.OnRestore += value;
            remove => _window.OnRestore -= value;
        }

        public event Action OnResize
        {
            add => _window.OnResize += value;
            remove => _window.OnResize -= value;
        }

        public event Action OnMove
        {
            add => _window.OnMove += value;
            remove => _window.OnMove -= value;
        }

        public event Action OnMoved
        {
            add => _window.OnMoved += value;
            remove => _window.OnMoved -= value;
        }

        public event Action OnEnterFullScreen
        {
            add => _window.OnEnterFullScreen += value;
            remove => _window.OnEnterFullScreen -= value;
        }

        public event Action OnLeaveFullScreen
        {
            add => _window.OnLeaveFullScreen += value;
            remove => _window.OnLeaveFullScreen -= value;
        }

        public event Action OnEnterHtmlFullScreen
        {
            add => _window.OnEnterHtmlFullScreen += value;
            remove => _window.OnEnterHtmlFullScreen -= value;
        }

        public event Action OnLeaveHtmlFullScreen
        {
            add => _window.OnLeaveHtmlFullScreen += value;
            remove => _window.OnLeaveHtmlFullScreen -= value;
        }

        public event Action<string> OnAppCommand
        {
            add => _window.OnAppCommand += value;
            remove => _window.OnAppCommand -= value;
        }

        public event Action OnScrollTouchBegin
        {
            add => _window.OnScrollTouchBegin += value;
            remove => _window.OnScrollTouchBegin -= value;
        }

        public event Action OnScrollTouchEnd
        {
            add => _window.OnScrollTouchEnd += value;
            remove => _window.OnScrollTouchEnd -= value;
        }

        public event Action OnScrollTouchEdge
        {
            add => _window.OnScrollTouchEdge += value;
            remove => _window.OnScrollTouchEdge -= value;
        }

        public event Action<string> OnSwipe
        {
            add => _window.OnSwipe += value;
            remove => _window.OnSwipe -= value;
        }

        public event Action OnSheetBegin
        {
            add => _window.OnSheetBegin += value;
            remove => _window.OnSheetBegin -= value;
        }

        public event Action OnSheetEnd
        {
            add => _window.OnSheetEnd += value;
            remove => _window.OnSheetEnd -= value;
        }

        public event Action OnNewWindowForTab
        {
            add => _window.OnNewWindowForTab += value;
            remove => _window.OnNewWindowForTab -= value;
        }

        public void Destroy()
        {
            _window.Destroy();
        }

        public void Close()
        {
            _window.Close();
        }

        public void Focus()
        {
            _window.Focus();
        }

        public void Blur()
        {
            _window.Blur();
        }

        public Task<bool> IsFocusedAsync()
        {
            return _window.IsFocusedAsync();
        }

        public Task<bool> IsDestroyedAsync()
        {
            return _window.IsDestroyedAsync();
        }

        public void Show()
        {
            _window.Show();
        }

        public void ShowInactive()
        {
            _window.ShowInactive();
        }

        public void Hide()
        {
            _window.Hide();
        }

        public Task<bool> IsVisibleAsync()
        {
            return _window.IsVisibleAsync();
        }

        public Task<bool> IsModalAsync()
        {
            return _window.IsModalAsync();
        }

        public void Maximize()
        {
            _window.Maximize();
        }

        public void Unmaximize()
        {
            _window.Unmaximize();
        }

        public Task<bool> IsMaximizedAsync()
        {
            return _window.IsMaximizedAsync();
        }

        public void Minimize()
        {
            _window.Minimize();
        }

        public void Restore()
        {
            _window.Restore();
        }

        public Task<bool> IsMinimizedAsync()
        {
            return _window.IsMinimizedAsync();
        }

        public void SetFullScreen(bool flag)
        {
            _window.SetFullScreen(flag);
        }

        public Task<bool> IsFullScreenAsync()
        {
            return _window.IsFullScreenAsync();
        }

        public void SetAspectRatio(int aspectRatio, Size extraSize)
        {
            _window.SetAspectRatio(aspectRatio, extraSize);
        }

        public void PreviewFile(string path)
        {
            _window.PreviewFile(path);
        }

        public void PreviewFile(string path, string displayname)
        {
            _window.PreviewFile(path, displayname);
        }

        public void CloseFilePreview()
        {
            _window.CloseFilePreview();
        }

        public void SetBounds(Rectangle bounds)
        {
            _window.SetBounds(bounds);
        }

        public void SetBounds(Rectangle bounds, bool animate)
        {
            _window.SetBounds(bounds, animate);
        }

        public Task<Rectangle> GetBoundsAsync()
        {
            return _window.GetBoundsAsync();
        }

        public void SetContentBounds(Rectangle bounds)
        {
            _window.SetContentBounds(bounds);
        }

        public void SetContentBounds(Rectangle bounds, bool animate)
        {
            _window.SetContentBounds(bounds, animate);
        }

        public Task<Rectangle> GetContentBoundsAsync()
        {
            return _window.GetContentBoundsAsync();
        }

        public void SetSize(int width, int height)
        {
            _window.SetSize(width, height);
        }

        public void SetSize(int width, int height, bool animate)
        {
            _window.SetSize(width, height, animate);
        }

        public Task<int[]> GetSizeAsync()
        {
            return _window.GetSizeAsync();
        }

        public void SetContentSize(int width, int height)
        {
            _window.SetContentSize(width, height);
        }

        public void SetContentSize(int width, int height, bool animate)
        {
            _window.SetContentSize(width, height, animate);
        }

        public Task<int[]> GetContentSizeAsync()
        {
            return _window.GetContentSizeAsync();
        }

        public void SetMinimumSize(int width, int height)
        {
            _window.SetMinimumSize(width, height);
        }

        public Task<int[]> GetMinimumSizeAsync()
        {
            return _window.GetMinimumSizeAsync();
        }

        public void SetMaximumSize(int width, int height)
        {
            _window.SetMaximumSize(width, height);
        }

        public Task<int[]> GetMaximumSizeAsync()
        {
            return _window.GetMaximumSizeAsync();
        }

        public void SetResizable(bool resizable)
        {
            _window.SetResizable(resizable);
        }

        public Task<bool> IsResizableAsync()
        {
            return _window.IsResizableAsync();
        }

        public void SetMovable(bool movable)
        {
            _window.SetMovable(movable);
        }

        public Task<bool> IsMovableAsync()
        {
            return _window.IsMovableAsync();
        }

        public void SetMinimizable(bool minimizable)
        {
            _window.SetMinimizable(minimizable);
        }

        public Task<bool> IsMinimizableAsync()
        {
            return _window.IsMinimizableAsync();
        }

        public void SetMaximizable(bool maximizable)
        {
            _window.SetMaximizable(maximizable);
        }

        public Task<bool> IsMaximizableAsync()
        {
            return _window.IsMaximizableAsync();
        }

        public void SetFullScreenable(bool fullscreenable)
        {
            _window.SetFullScreenable(fullscreenable);
        }

        public Task<bool> IsFullScreenableAsync()
        {
            return _window.IsFullScreenableAsync();
        }

        public void SetClosable(bool closable)
        {
            _window.SetClosable(closable);
        }

        public Task<bool> IsClosableAsync()
        {
            return _window.IsClosableAsync();
        }

        public void SetAlwaysOnTop(bool flag)
        {
            _window.SetAlwaysOnTop(flag);
        }

        public void SetAlwaysOnTop(bool flag, OnTopLevel level)
        {
            _window.SetAlwaysOnTop(flag, level);
        }

        public void SetAlwaysOnTop(bool flag, OnTopLevel level, int relativeLevel)
        {
            _window.SetAlwaysOnTop(flag, level, relativeLevel);
        }

        public Task<bool> IsAlwaysOnTopAsync()
        {
            return _window.IsAlwaysOnTopAsync();
        }

        public void Center()
        {
            _window.Center();
        }

        public void SetPosition(int x, int y)
        {
            _window.SetPosition(x, y);
        }

        public void SetPosition(int x, int y, bool animate)
        {
            _window.SetPosition(x, y, animate);
        }

        public Task<int[]> GetPositionAsync()
        {
            return _window.GetPositionAsync();
        }

        public void SetTitle(string title)
        {
            _window.SetTitle(title);
        }

        public Task<string> GetTitleAsync()
        {
            return _window.GetTitleAsync();
        }

        public void SetSheetOffset(float offsetY)
        {
            _window.SetSheetOffset(offsetY);
        }

        public void SetSheetOffset(float offsetY, float offsetX)
        {
            _window.SetSheetOffset(offsetY, offsetX);
        }

        public void FlashFrame(bool flag)
        {
            _window.FlashFrame(flag);
        }

        public void SetSkipTaskbar(bool skip)
        {
            _window.SetSkipTaskbar(skip);
        }

        public void SetKiosk(bool flag)
        {
            _window.SetKiosk(flag);
        }

        public Task<bool> IsKioskAsync()
        {
            return _window.IsKioskAsync();
        }

        public void SetRepresentedFilename(string filename)
        {
            _window.SetRepresentedFilename(filename);
        }

        public Task<string> GetRepresentedFilenameAsync()
        {
            return _window.GetRepresentedFilenameAsync();
        }

        public void SetDocumentEdited(bool edited)
        {
            _window.SetDocumentEdited(edited);
        }

        public Task<bool> IsDocumentEditedAsync()
        {
            return _window.IsDocumentEditedAsync();
        }

        public void FocusOnWebView()
        {
            _window.FocusOnWebView();
        }

        public void BlurWebView()
        {
            _window.BlurWebView();
        }

        public void LoadURL(string url)
        {
            _window.LoadURL(url);
        }

        public void LoadURL(string url, LoadURLOptions options)
        {
            _window.LoadURL(url, options);
        }

        public void Reload()
        {
            _window.Reload();
        }

        public void SetMenu(MenuItem[] menuItems)
        {
            _window.SetMenu(menuItems);
        }

        public void RemoveMenu()
        {
            _window.RemoveMenu();
        }

        public void SetProgressBar(double progress)
        {
            _window.SetProgressBar(progress);
        }

        public void SetProgressBar(double progress, ProgressBarOptions progressBarOptions)
        {
            _window.SetProgressBar(progress, progressBarOptions);
        }

        public void SetHasShadow(bool hasShadow)
        {
            _window.SetHasShadow(hasShadow);
        }

        public Task<bool> HasShadowAsync()
        {
            return _window.HasShadowAsync();
        }

        public Task<bool> SetThumbarButtonsAsync(ThumbarButton[] thumbarButtons)
        {
            return _window.SetThumbarButtonsAsync(thumbarButtons);
        }

        public void SetThumbnailClip(Rectangle rectangle)
        {
            _window.SetThumbnailClip(rectangle);
        }

        public void SetThumbnailToolTip(string tooltip)
        {
            _window.SetThumbnailToolTip(tooltip);
        }

        public void SetAppDetails(AppDetailsOptions options)
        {
            _window.SetAppDetails(options);
        }

        public void ShowDefinitionForSelection()
        {
            _window.ShowDefinitionForSelection();
        }

        public void SetAutoHideMenuBar(bool hide)
        {
            _window.SetAutoHideMenuBar(hide);
        }

        public Task<bool> IsMenuBarAutoHideAsync()
        {
            return _window.IsMenuBarAutoHideAsync();
        }

        public void SetMenuBarVisibility(bool visible)
        {
            _window.SetMenuBarVisibility(visible);
        }

        public Task<bool> IsMenuBarVisibleAsync()
        {
            return _window.IsMenuBarVisibleAsync();
        }

        public void SetVisibleOnAllWorkspaces(bool visible)
        {
            _window.SetVisibleOnAllWorkspaces(visible);
        }

        public Task<bool> IsVisibleOnAllWorkspacesAsync()
        {
            return _window.IsVisibleOnAllWorkspacesAsync();
        }

        public void SetIgnoreMouseEvents(bool ignore)
        {
            _window.SetIgnoreMouseEvents(ignore);
        }

        public void SetContentProtection(bool enable)
        {
            _window.SetContentProtection(enable);
        }

        public void SetFocusable(bool focusable)
        {
            _window.SetFocusable(focusable);
        }

        public void SetParentWindow(BrowserWindow parent)
        {
            _window.SetParentWindow(parent);
        }

        public Task<BrowserWindow> GetParentWindowAsync()
        {
            return _window.GetParentWindowAsync();
        }

        public Task<List<BrowserWindow>> GetChildWindowsAsync()
        {
            return _window.GetChildWindowsAsync();
        }

        public void SetAutoHideCursor(bool autoHide)
        {
            _window.SetAutoHideCursor(autoHide);
        }

        public void SetVibrancy(Vibrancy type)
        {
            _window.SetVibrancy(type);
        }
    }
}