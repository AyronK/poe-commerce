namespace System.Text.Json.Serialization
{
    public class EnumValueDictionaryJsonConverter<TKey, TValue> : DictionaryJsonConverterBase<TKey, TValue> where TValue : struct, Enum
    {
        private static readonly EnumJsonConverter<TValue> Converter = new EnumJsonConverter<TValue>();

        protected override TValue ReadValue(ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            return Converter.Read(ref reader, typeof(TValue), options);
        }

        protected override void WriteValue(Utf8JsonWriter writer, JsonSerializerOptions options, TValue value)
        {
            Converter.Write(writer, value, options);
        }
    }
}