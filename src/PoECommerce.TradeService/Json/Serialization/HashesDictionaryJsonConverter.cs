﻿using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using PoECommerce.PathOfExile.Models.Enums;
using PoECommerce.PathOfExile.Models.Trade.Items;

namespace PoECommerce.PathOfExile.Json.Serialization
{
    public sealed class HashesDictionaryJsonConverter : EnumKeyDictionaryJsonConverter<ModifierType, Hash[]>
    {
        protected override Hash[] ReadValue(ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            List<Hash> result = new List<Hash>();

            if (reader.TokenType != JsonTokenType.StartArray)
            {
                throw new JsonException($"Cannot convert to {nameof(Hash)} - json should be [][][string,int[]] (array of arrays of arrays), but starts with '{reader.TokenType}'.");
            }

            while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
            {
                if (reader.TokenType != JsonTokenType.StartArray)
                {
                    throw new JsonException($"Cannot convert to {nameof(Hash)} - json should be [][][string,int[]] (array of arrays of arrays), but first element of internal array starts with '{reader.TokenType}'.");
                }

                while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
                {
                    if (reader.TokenType != JsonTokenType.String)
                    {
                        throw new JsonException($"Cannot convert to {nameof(Hash)} - first element in hash level array should be a string, but it is '{reader.TokenType}'.");
                    }

                    string id = reader.GetString();

                    if (reader.Read() && reader.TokenType != JsonTokenType.StartArray)
                    {
                        throw new JsonException($"Cannot convert to {nameof(Hash)} - second element in hash level array should be an array, but starts with '{reader.TokenType}'.");
                    }
                    List<int> values = new List<int>();

                    while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
                    {
                        int value = reader.GetInt32();
                        values.Add(value);
                    }

                    if (reader.TokenType != JsonTokenType.EndArray)
                    {
                        throw new JsonException($"Cannot convert to {nameof(Hash)} - second element in hash level array should be an array, but after the last element there is '{reader.TokenType}'.");
                    }

                    result.Add(new Hash { Id = id, Values = values.ToArray() });
                }
            }

            return result.ToArray();
        }

        protected override void WriteValue(Utf8JsonWriter writer, JsonSerializerOptions options, Hash[] value)
        {
            writer.WriteStartArray();

            foreach (Hash hash in value)
            {
                writer.WriteStartArray();
                writer.WriteStringValue(hash.Id);
                writer.WriteStartArray();

                foreach (int hashValue in hash.Values)
                {

                    writer.WriteNumberValue(hashValue);
                }

                writer.WriteEndArray();
                writer.WriteEndArray();
            }

            writer.WriteEndArray();
        }
    }
}