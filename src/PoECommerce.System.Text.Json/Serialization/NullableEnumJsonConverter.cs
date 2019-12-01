namespace System.Text.Json.Serialization
{
    public class NullableEnumJsonConverter<T> : JsonConverter<T?> where T : struct, Enum, IConvertible
    {
        private static readonly EnumJsonConverter<T> Converter = new EnumJsonConverter<T>();


        public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Null)
            {
                return null;
            }

            return Converter.Read(ref reader, typeToConvert, options);
        }

        public override void Write(Utf8JsonWriter writer, T? value, JsonSerializerOptions options)
        {
            if (!value.HasValue)
            {
                writer.WriteNullValue();
                return;
            }

            Converter.Write(writer, value.Value, options);
        }
    }
}