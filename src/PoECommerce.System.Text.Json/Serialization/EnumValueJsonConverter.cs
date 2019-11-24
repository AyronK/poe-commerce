using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace System.Text.Json.Serialization
{
    public class EnumJsonConverter<T> : JsonConverter<T> where T : struct, Enum, IConvertible
    {
        private readonly bool _isObjectProperty;
        private static readonly Dictionary<T, string> EnumValueJsonNames;
        private static readonly Dictionary<string, T> JsonNamesEnumValues;

        static EnumJsonConverter()
        {
            EnumValueJsonNames = new Dictionary<T, string>();
            JsonNamesEnumValues = new Dictionary<string, T>();

            foreach (T value in Enum.GetValues(typeof(T)))
            {
                string valueName = value.ToString();
                string[] valueNames = GetEnumMemberAttributeValue(valueName) ?? new[] { value.ToString("D") };

                EnumValueJsonNames.Add(value, valueNames.First());

                foreach (string name in valueNames)
                {
                    JsonNamesEnumValues.Add(name, value);
                }
            }

            static string[] GetEnumMemberAttributeValue(string valueName)
            {
                return typeof(T).GetMember(valueName)
                    .FirstOrDefault(m => m.DeclaringType == typeof(T))
                    ?.GetCustomAttributes(typeof(JsonEnumNameAttribute), false)
                    .OfType<JsonEnumNameAttribute>()
                    .FirstOrDefault()
                    ?.Names;
            }
        }

        public EnumJsonConverter(bool isObjectProperty)
        {
            _isObjectProperty = isObjectProperty;
        }

        public EnumJsonConverter()
        {
            _isObjectProperty = false;
        }

        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string value = reader.TokenType switch
            {
                JsonTokenType.String => reader.GetString(),
                JsonTokenType.PropertyName => reader.GetString(),
                JsonTokenType.Number when reader.TryGetInt32(out int intValue) => intValue.ToString(CultureInfo.InvariantCulture),
                _ => throw new NotSupportedException($"Enum value can only be either {JsonTokenType.String} or {JsonTokenType.Number}, but was {reader.TokenType}"),
            };

            return JsonNamesEnumValues.TryGetValue(value, out T enumValue)
                ? enumValue
                : Enum.TryParse(value, true, out enumValue)
                    ? enumValue
                    : throw new JsonException($"Value '{value}' cannot be converted to enum of type '{typeof(T)}'.");
        }

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            if (EnumValueJsonNames.TryGetValue(value, out string enumJsonName))
            {
                if (int.TryParse(enumJsonName, out int number))
                {
                    if (!_isObjectProperty)
                    {
                        writer.WriteNumberValue(number);
                    }
                    else
                    {
                        enumJsonName = value.ToString();
                        enumJsonName = options.DictionaryKeyPolicy?.ConvertName(enumJsonName) ?? options.PropertyNamingPolicy?.ConvertName(enumJsonName) ?? enumJsonName;
                        writer.WritePropertyName(enumJsonName);
                    }
                }
                else
                {
                    if (_isObjectProperty)
                    {
                        enumJsonName = options.DictionaryKeyPolicy?.ConvertName(enumJsonName) ?? options.PropertyNamingPolicy?.ConvertName(enumJsonName) ?? enumJsonName;
                        writer.WritePropertyName(enumJsonName);
                    }
                    else
                    {
                        writer.WriteStringValue(enumJsonName);
                    }
                }
            }
            else
            {
                if (_isObjectProperty)
                {
                    writer.WritePropertyName(value.ToString());
                }
                else
                {
                    writer.WriteNumberValue(value.ToInt32(CultureInfo.InvariantCulture));
                }
            }
        }
    }
}