namespace System.Text.Json.Serialization
{
    public class EnumKeyDictionaryJsonConverter<TKey, TValue> : DictionaryJsonConverterBase<TKey, TValue> where TKey : struct, Enum
    {
        private static readonly EnumJsonConverter<TKey> Converter = new EnumJsonConverter<TKey>(true);

        protected override TKey ReadKey(ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            return Converter.Read(ref reader, typeof(TKey), options);
        }

        protected override void WriteKey(Utf8JsonWriter writer, JsonSerializerOptions options, TKey key)
        {
            Converter.Write(writer, key, options);
        }
    }
}