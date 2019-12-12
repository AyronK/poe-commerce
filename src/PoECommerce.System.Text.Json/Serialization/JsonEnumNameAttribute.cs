namespace System.Text.Json.Serialization
{
    public class JsonEnumNameAttribute : JsonAttribute
    {
        /// <summary>
        ///     Creates a map between json text and enum value. If more then one name is specified, all will be checked on read,
        ///     but only first will be used to write.
        /// </summary>
        /// <param name="names">Custom names which will be mapped to enum's value. First one passed will always be used for writing.</param>
        public JsonEnumNameAttribute(params string[] names)
        {
            Names = names;
        }

        public string[] Names { get; }
    }
}