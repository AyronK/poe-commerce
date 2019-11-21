using System.Collections.Generic;

namespace System.Text.Json.Serialization
{
    public class ArrayJsonConverter<TType, TTypeConverter> : JsonConverter<TType[]> where TTypeConverter : JsonConverter<TType>, new()
    {
        private static readonly TTypeConverter Converter = new TTypeConverter();

        public override TType[] Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartArray)
            {
                throw new JsonException($"Cannot convert to {typeof(TType).Name}[] - json should be an array, but it starts with '{reader.TokenType}'.");
            }

            TType[] elements = ReadElements(ref reader, options);
            
            return elements;
        }

        private static TType[] ReadElements(ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            List<TType> elements = new List<TType>();

            while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
            {
                elements.Add(Converter.Read(ref reader, typeof(TType), options));
            }

            return elements.ToArray();
        }

        public override void Write(Utf8JsonWriter writer, TType[] value, JsonSerializerOptions options)
        {
            writer.WriteStartArray();

            foreach (TType element in value)
            {
                Converter.Write(writer, element, options);
            }

            writer.WriteEndArray();
        }
    }
}