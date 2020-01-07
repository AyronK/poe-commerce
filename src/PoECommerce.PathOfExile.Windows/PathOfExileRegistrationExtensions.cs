using Microsoft.Extensions.DependencyInjection;

namespace PoECommerce.PathOfExile.Windows
{
    public static class PathOfExileRegistrationExtensions
    {
        public static void AddPathOfExileWindowsSupport(this IServiceCollection services)
        {
            services.AddScoped<IChat, Chat>();
            services.AddScoped<IPathOfExileFacade, PathOfExileFacade>();
        }
    }
}