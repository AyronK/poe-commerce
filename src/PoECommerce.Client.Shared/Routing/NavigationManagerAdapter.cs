using System;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace PoECommerce.Client.Shared.Routing
{
    public class NavigationManagerAdapter : INavigationManager
    {
        private readonly NavigationManager _navigationManager;

        public NavigationManagerAdapter(NavigationManager navigationManager)
        {
            _navigationManager = navigationManager;
        }

        public event EventHandler<LocationChangedEventArgs> LocationChanged
        {
            add => _navigationManager.LocationChanged += value;
            remove => _navigationManager.LocationChanged -= value;
        }

        public string BaseUri => _navigationManager.BaseUri;

        public string Uri => _navigationManager.Uri;

        public void NavigateTo(string uri, bool forceLoad = false)
        {
            _navigationManager.NavigateTo(uri, forceLoad);
        }

        public Uri ToAbsoluteUri(string relativeUri)
        {
            return _navigationManager.ToAbsoluteUri(relativeUri);
        }

        public string ToBaseRelativePath(string uri)
        {
            return _navigationManager.ToBaseRelativePath(uri);
        }
    }
}