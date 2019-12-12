using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using PoECommerce.PathOfExile.Models.Trade.Enums;
using PoECommerce.PathOfExile.Models.Trade.Items;

namespace PoECommerce.PathOfExile.Json.Serialization
{
    public sealed class PropertyValueJsonConverter : JsonConverter<PropertyValue>
    {
        public override PropertyValue Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            PropertyValue propertyValue = new PropertyValue();

            if (reader.TokenType != JsonTokenType.StartArray)
            {
                throw new JsonException($"Cannot convert to {nameof(PropertyValue)} - json should be a two element array, but starts with '{reader.TokenType}'.");
            }

            if (!reader.Read() || reader.TokenType != JsonTokenType.String)
            {
                throw new JsonException($"Cannot convert to {nameof(PropertyValue)} - the first value in the array should be '{JsonTokenType.String}', but is '{reader.TokenType}'.");
            }

            propertyValue.Value = reader.GetString();

            if (!reader.Read() || reader.TokenType != JsonTokenType.Number)
            {
                throw new JsonException($"Cannot convert to {nameof(PropertyValue)} - the second value in the array should be '{JsonTokenType.Number}', but is '{reader.TokenType}'.");
            }

            propertyValue.Format = (TextFormat)reader.GetInt32();

            if (!reader.Read() || reader.TokenType != JsonTokenType.EndArray)
            {
                throw new JsonException($"Cannot convert to {nameof(PropertyValue)} - json should be a two element array, but there is '{reader.TokenType}' after the second element.");
            }

            return propertyValue;
        }

        public override void Write(Utf8JsonWriter writer, PropertyValue value, JsonSerializerOptions options)
        {
            writer.WriteStartArray();
            writer.WriteStringValue(value.Value);
            writer.WriteNumberValue((int)value.Format);
            writer.WriteEndArray();
        }
    }
}