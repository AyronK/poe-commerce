using System;

namespace PoECommerce.Microsoft.Extensions.DependencyInjection
{
    public class ServiceSettings<T>
    {
        public Func<Func<T>, T> Factory { get; set; } = null;
        public RegistrationType Scope { get; set; } = RegistrationType.Scoped;
    }
}