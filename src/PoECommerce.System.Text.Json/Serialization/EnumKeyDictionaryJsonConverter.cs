using System.Collections.Generic;
using System.Linq;

namespace System.Text.Json.Serialization
{
    public class EnumKeyDictionaryJsonConverter<TKey, TValue> : JsonConverter<IDictionary<TKey, TValue>> where TKey : struct, Enum
    {
        EnumJsonConverter<TKey> _converter = new EnumJsonConverter<TKey>();

        public override IDictionary<TKey, TValue> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException($"Cannot convert to dictionary - json should be an object, but starts with '{reader.TokenType}'.");
            }

            Dictionary<TKey, TValue> resultDictionary = new Dictionary<TKey, TValue>();

            while (reader.Read() && reader.TokenType != JsonTokenType.EndObject)
            {
                TKey enumKey = _converter.Read(ref reader, typeof(TKey), options);

                reader.Read();

                TValue value = ReadValue(ref reader, options);
                
                resultDictionary.Add(enumKey, value);
            }

            return resultDictionary;
        }

        protected virtual TValue ReadValue(ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            return JsonSerializer.Deserialize<TValue>(ref reader, options);
        }

        public override void Write(Utf8JsonWriter writer, IDictionary<TKey, TValue> value, JsonSerializerOptions options)
        {
            Dictionary<string, TValue> dictionary = value.ToDictionary(e => e.Key.ToString(), e => e.Value);

            foreach ((string elementKey, TValue elementValue) in dictionary)
            {
                writer.WriteStartObject();
                writer.WritePropertyName(options?.DictionaryKeyPolicy?.ConvertName(elementKey) ?? elementKey);
                WriteValue(writer, options, elementValue);
                writer.WriteEndObject();
            }
        }

        protected virtual void WriteValue(Utf8JsonWriter writer, JsonSerializerOptions options, TValue value)
        {
            JsonSerializer.Serialize(writer, value, options);
        }
    }
}