using System;
using System.Collections.Generic;
using System.Text.Json;
using FluentAssertions;
using NUnit.Framework;
using PoECommerce.PathOfExile.Json.Serialization;
using PoECommerce.PathOfExile.Models.Enums;
using PoECommerce.PathOfExile.Models.Trade.Items;

namespace PoECommerce.PathOfExile.Tests.Json.Serialization
{
    [TestFixture]
    public class HashesDictionaryJsonConverterTest
    {
        [SetUp]
        public void SetUp()
        {
            _converter = new HashesDictionaryJsonConverter();
            _jsonSerializerOptions = new JsonSerializerOptions {Converters = {_converter}, AllowTrailingCommas = true, DictionaryKeyPolicy = JsonNamingPolicy.CamelCase};
        }

        private HashesDictionaryJsonConverter _converter;
        private JsonSerializerOptions _jsonSerializerOptions;

        [Test]
        public void When_Deserialize()
        {
            // Given
            string json = "{\"crafted\":[[\"testValue\",[5]]]}";

            // When
            IDictionary<ModifierType, Hash[]> result = JsonSerializer.Deserialize<IDictionary<ModifierType, Hash[]>>(json, _jsonSerializerOptions);

            // Then
            object[] expectedValues = { new Hash { Id = "testValue", Value = 5 } };

            result.Should().ContainKey(ModifierType.Crafted);
            result[ModifierType.Crafted].Should().BeEquivalentTo(expectedValues);
        }

        [Test]
        public void When_Deserialize_And_InvalidEnumMember()
        {
            // Given
            string json = "{\"notExisting\":\"test\"}";

            // When
            Func<IDictionary<ModifierType, Hash[]>> when = () => JsonSerializer.Deserialize<IDictionary<ModifierType, Hash[]>>(json, _jsonSerializerOptions);

            // Then
            when.Should().Throw<JsonException>().And.Message.Should().Be($"Value 'notExisting' cannot be converted to enum of type '{typeof(ModifierType)}'.");
        }

        [Test]
        public void When_Deserialize_And_InvalidJson()
        {
            // Given
            string json = "[]";

            // When
            Func<IDictionary<ModifierType, Hash[]>> when = () => JsonSerializer.Deserialize<IDictionary<ModifierType, Hash[]>>(json, _jsonSerializerOptions);

            // Then
            when.Should().Throw<JsonException>().And.Message.Should().Be("Cannot convert to dictionary - json should be an object, but starts with 'StartArray'.");
        }

        [Test]
        public void When_Serialize()
        {
            // Given
            IDictionary<ModifierType, Hash[]> dictionary = new Dictionary<ModifierType, Hash[]> {{ModifierType.Crafted, new[] {new Hash {Id = "testValue", Value = 5}}}};

            // When
            string result = JsonSerializer.Serialize(dictionary, _jsonSerializerOptions);

            // Then
            result.Should().Be("{\"crafted\":[[\"testValue\",[5]]]}");
        }
    }
}