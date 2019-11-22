namespace PoECommerce.TradeService.Extensions
{
    public enum RegistrationType
    {
        /// <summary>
        ///     Once per dependency.
        /// </summary>
        Transient,

        /// <summary>
        ///     Once per scope (e.g. HTTP request).
        /// </summary>
        Scoped,

        /// <summary>
        ///     Once per lifetime.
        /// </summary>
        Singleton
    }
}