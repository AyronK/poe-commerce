﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ElectronNET.API;
using ElectronNET.API.Entities;

namespace PoECommerce.Client.Electron.Abstraction
{
    public interface IBrowserWindow
    {
        int Id { get; }
        IReadOnlyCollection<MenuItem> MenuItems { get; }
        IReadOnlyCollection<ThumbarButton> ThumbarButtons { get; }
        WebContents WebContents { get; }
        event Action OnReadyToShow;
        event Action<string> OnPageTitleUpdated;
        event Action OnClose;
        event Action OnClosed;
        event Action OnSessionEnd;
        event Action OnUnresponsive;
        event Action OnResponsive;
        event Action OnBlur;
        event Action OnFocus;
        event Action OnShow;
        event Action OnHide;
        event Action OnMaximize;
        event Action OnUnmaximize;
        event Action OnMinimize;
        event Action OnRestore;
        event Action OnResize;
        event Action OnMove;
        event Action OnMoved;
        event Action OnEnterFullScreen;
        event Action OnLeaveFullScreen;
        event Action OnEnterHtmlFullScreen;
        event Action OnLeaveHtmlFullScreen;
        event Action<string> OnAppCommand;
        event Action OnScrollTouchBegin;
        event Action OnScrollTouchEnd;
        event Action OnScrollTouchEdge;
        event Action<string> OnSwipe;
        event Action OnSheetBegin;
        event Action OnSheetEnd;
        event Action OnNewWindowForTab;
        void Destroy();
        void Close();
        void Focus();
        void Blur();
        Task<bool> IsFocusedAsync();
        Task<bool> IsDestroyedAsync();
        void Show();
        void ShowInactive();
        void Hide();
        Task<bool> IsVisibleAsync();
        Task<bool> IsModalAsync();
        void Maximize();
        void Unmaximize();
        Task<bool> IsMaximizedAsync();
        void Minimize();
        void Restore();
        Task<bool> IsMinimizedAsync();
        void SetFullScreen(bool flag);
        Task<bool> IsFullScreenAsync();
        void SetAspectRatio(int aspectRatio, Size extraSize);
        void PreviewFile(string path);
        void PreviewFile(string path, string displayname);
        void CloseFilePreview();
        void SetBounds(Rectangle bounds);
        void SetBounds(Rectangle bounds, bool animate);
        Task<Rectangle> GetBoundsAsync();
        void SetContentBounds(Rectangle bounds);
        void SetContentBounds(Rectangle bounds, bool animate);
        Task<Rectangle> GetContentBoundsAsync();
        void SetSize(int width, int height);
        void SetSize(int width, int height, bool animate);
        Task<int[]> GetSizeAsync();
        void SetContentSize(int width, int height);
        void SetContentSize(int width, int height, bool animate);
        Task<int[]> GetContentSizeAsync();
        void SetMinimumSize(int width, int height);
        Task<int[]> GetMinimumSizeAsync();
        void SetMaximumSize(int width, int height);
        Task<int[]> GetMaximumSizeAsync();
        void SetResizable(bool resizable);
        Task<bool> IsResizableAsync();
        void SetMovable(bool movable);
        Task<bool> IsMovableAsync();
        void SetMinimizable(bool minimizable);
        Task<bool> IsMinimizableAsync();
        void SetMaximizable(bool maximizable);
        Task<bool> IsMaximizableAsync();
        void SetFullScreenable(bool fullscreenable);
        Task<bool> IsFullScreenableAsync();
        void SetClosable(bool closable);
        Task<bool> IsClosableAsync();
        void SetAlwaysOnTop(bool flag);
        void SetAlwaysOnTop(bool flag, OnTopLevel level);
        void SetAlwaysOnTop(bool flag, OnTopLevel level, int relativeLevel);
        Task<bool> IsAlwaysOnTopAsync();
        void Center();
        void SetPosition(int x, int y);
        void SetPosition(int x, int y, bool animate);
        Task<int[]> GetPositionAsync();
        void SetTitle(string title);
        Task<string> GetTitleAsync();
        void SetSheetOffset(float offsetY);
        void SetSheetOffset(float offsetY, float offsetX);
        void FlashFrame(bool flag);
        void SetSkipTaskbar(bool skip);
        void SetKiosk(bool flag);
        Task<bool> IsKioskAsync();
        void SetRepresentedFilename(string filename);
        Task<string> GetRepresentedFilenameAsync();
        void SetDocumentEdited(bool edited);
        Task<bool> IsDocumentEditedAsync();
        void FocusOnWebView();
        void BlurWebView();
        void LoadURL(string url);
        void LoadURL(string url, LoadURLOptions options);
        void Reload();
        void SetMenu(MenuItem[] menuItems);
        void RemoveMenu();
        void SetProgressBar(double progress);
        void SetProgressBar(double progress, ProgressBarOptions progressBarOptions);
        void SetHasShadow(bool hasShadow);
        Task<bool> HasShadowAsync();
        Task<bool> SetThumbarButtonsAsync(ThumbarButton[] thumbarButtons);
        void SetThumbnailClip(Rectangle rectangle);
        void SetThumbnailToolTip(string tooltip);
        void SetAppDetails(AppDetailsOptions options);
        void ShowDefinitionForSelection();
        void SetAutoHideMenuBar(bool hide);
        Task<bool> IsMenuBarAutoHideAsync();
        void SetMenuBarVisibility(bool visible);
        Task<bool> IsMenuBarVisibleAsync();
        void SetVisibleOnAllWorkspaces(bool visible);
        Task<bool> IsVisibleOnAllWorkspacesAsync();
        void SetIgnoreMouseEvents(bool ignore);
        void SetContentProtection(bool enable);
        void SetFocusable(bool focusable);
        void SetParentWindow(BrowserWindow parent);
        Task<BrowserWindow> GetParentWindowAsync();
        Task<List<BrowserWindow>> GetChildWindowsAsync();
        void SetAutoHideCursor(bool autoHide);
        void SetVibrancy(Vibrancy type);
    }
}