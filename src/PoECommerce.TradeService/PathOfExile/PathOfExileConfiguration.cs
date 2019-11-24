using System;

namespace PoECommerce.PathOfExile.PathOfExile
{
    internal static class PathOfExileConfiguration
    {
        public const string HttpClientName = "pathofexile/trade";
        public static readonly Uri BaseAddress = new Uri("https://www.pathofexile.com");
    }
}