using Microsoft.Extensions.DependencyInjection;

namespace PoECommerce.PathOfExile.Windows
{
    public static class PathOfExileRegistrationExtensions
    {
        public static void AddPathOfExileWindowsSupport(this IServiceCollection services)
        {
            services.AddTransient<IChat, Chat>();
            services.AddTransient<IPathOfExileFacade, PathOfExileFacade>();
        }
    }
}