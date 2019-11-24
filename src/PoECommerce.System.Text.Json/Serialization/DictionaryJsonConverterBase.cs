using System.Collections.Generic;
using System.Globalization;

namespace System.Text.Json.Serialization
{
    public abstract class DictionaryJsonConverterBase<TKey, TValue> : JsonConverter<IDictionary<TKey, TValue>>
    {
        public override IDictionary<TKey, TValue> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException($"Cannot convert to dictionary - json should be an object, but starts with '{reader.TokenType}'.");
            }

            Dictionary<TKey, TValue> resultDictionary = new Dictionary<TKey, TValue>();

            while (reader.Read() && reader.TokenType != JsonTokenType.EndObject)
            {
                TKey key = ReadKey(ref reader, options);

                reader.Read();

                TValue value = ReadValue(ref reader, options);

                resultDictionary.Add(key, value);
            }

            return resultDictionary;
        }

        protected virtual TKey ReadKey(ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            return Read<TKey>(ref reader, options);
        }

        protected virtual TValue ReadValue(ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            return Read<TValue>(ref reader, options);
        }

        private static T Read<T>(ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            switch (reader.TokenType)
            {
                case JsonTokenType.PropertyName:
                case JsonTokenType.String:
                    return JsonSerializer.Deserialize<T>("\"" + reader.GetString() + "\"", options);
                case JsonTokenType.Number:
                    return JsonSerializer.Deserialize<T>(reader.GetDecimal().ToString(CultureInfo.InvariantCulture));
                case JsonTokenType.True:
                case JsonTokenType.False:
                    return JsonSerializer.Deserialize<T>(reader.GetBoolean().ToString().ToLowerInvariant());
                case JsonTokenType.StartObject:
                case JsonTokenType.StartArray:
                    return JsonSerializer.Deserialize<T>(ref reader, options);
                case JsonTokenType.Null:
                case JsonTokenType.None:
                    return default;
                default:
                    throw new NotSupportedException();
            }
        }

        public override void Write(Utf8JsonWriter writer, IDictionary<TKey, TValue> value, JsonSerializerOptions options)
        {
            foreach ((TKey elementKey, TValue elementValue) in value)
            {
                writer.WriteStartObject();
                WriteKey(writer, options, elementKey);
                WriteValue(writer, options, elementValue);
                writer.WriteEndObject();
            }
        }

        protected virtual void WriteKey(Utf8JsonWriter writer, JsonSerializerOptions options, TKey key)
        {
            writer.WritePropertyName(key.ToString());
        }

        protected virtual void WriteValue(Utf8JsonWriter writer, JsonSerializerOptions options, TValue value)
        {
            writer.WriteStringValue(JsonEncodedText.Encode(value.ToString(), options.Encoder));
        }
    }
}