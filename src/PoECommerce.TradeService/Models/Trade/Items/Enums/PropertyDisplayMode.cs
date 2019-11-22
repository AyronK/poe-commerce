namespace PoECommerce.TradeService.Models.Trade.Items.Enums
{
    /// <summary>
    ///     Describes how the property which consists of PropertyName and PropertyValues[] should be displayed.
    /// </summary>
    public enum PropertyDisplayMode
    {
        /// <summary>
        ///     If the there is any value:
        ///     <code>$"{PropertyName}: {string.Join(',', PropertyValues)}"</code>
        ///     otherwise:
        ///     <code>$"{PropertyName}"</code>
        /// </summary>
        MultipleValues = 0,

        /// <summary>
        ///     <code>$"{PropertyValues[0]} {PropertyName}"</code>
        /// </summary>
        SingleValue = 1,

        /// <summary>
        ///     <para>
        ///         PropertyValues[0] is progress bar value in format `CurrentValue/MaxValue` (e.g. 20/100 which means 20%).
        ///     </para>
        ///     <para>
        ///         Value should be displayed as both progress bar and text CurrentValue/MaxValue.
        ///         PropertyName should not be displayed.
        ///     </para>
        ///     <para>
        ///         Calculated value of CurrentValue/MaxValue should also be found in Progress field of the Property.
        ///     </para>
        /// </summary>
        ProgressBar = 2,

        /// <summary>
        ///     PropertyName is a template. '%\d' is a placeholder for PropertyValues (e.g. %0 requires PropertyValues[0]).
        /// </summary>
        Template = 3
    }
}