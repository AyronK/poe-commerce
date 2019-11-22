using System;

namespace PoECommerce.TradeService.Extensions
{
    public class ServiceSettings<T>
    {
        /// <summary>
        ///     Factory method with resolved instance as a parameter. Can be used to decorate registered instance.
        /// </summary>
        public Func<Func<T>, T> Factory { get; set; } = null;

        /// <summary>
        ///     Scope at which decorated instance will be registered. Default <see cref="RegistrationType.Transient" />. If
        ///     <see cref="Factory" /> is not defined it can also modify default scope of registered instance which is
        ///     <see cref="RegistrationType.Transient" /> by default.
        /// </summary>
        public RegistrationType Scope { get; set; } = RegistrationType.Transient;
    }
}