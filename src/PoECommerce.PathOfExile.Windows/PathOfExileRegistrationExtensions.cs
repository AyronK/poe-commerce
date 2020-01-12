using Microsoft.Extensions.DependencyInjection;
using PoECommerce.PathOfExile.GameClient.Abstractions;

namespace PoECommerce.PathOfExile.Windows
{
    public static class PathOfExileRegistrationExtensions
    {
        /// <summary>
        ///     Registers required services to enable attaching Path of Exile game window and sending input to the client.
        /// </summary>
        /// <param name="services"></param>
        public static void AddPathOfExileWindowsSupport(this IServiceCollection services)
        {
            services.AddTransient<IPathOfExileInput, PathOfExileInput>();
            services.AddTransient<IPathOfExileProcessHook, PathOfExileProcessHook>();
        }
    }
}