using System;
using Microsoft.AspNetCore.Components.Routing;

namespace PoECommerce.Client.Shared.Routing
{
    public interface INavigationManager
    {
        event EventHandler<LocationChangedEventArgs> LocationChanged;
        string BaseUri { get; }
        string Uri { get; }
        void NavigateTo(string uri, bool forceLoad = false);
        Uri ToAbsoluteUri(string relativeUri);
        string ToBaseRelativePath(string uri);
    }
}