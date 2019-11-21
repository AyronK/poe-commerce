using System.Collections.Generic;
using System.Text.Json.Serialization;
using FluentAssertions;
using NUnit.Framework;

namespace System.Text.Json.Tests.Serialization
{
    [TestFixture]
    public class EnumKeyDictionaryJsonConverterTest
    {
        [SetUp]
        public void SetUp()
        {
            _converter = new EnumKeyDictionaryJsonConverter<StringComparison, string>();
            _jsonSerializerOptions = new JsonSerializerOptions { Converters = { _converter }, AllowTrailingCommas = true, DictionaryKeyPolicy = JsonNamingPolicy.CamelCase };
        }

        private EnumKeyDictionaryJsonConverter<StringComparison, string> _converter;
        private JsonSerializerOptions _jsonSerializerOptions;

        [Test]
        public void When_Deserialize()
        {
            // Given
            string json = "{\"ordinal\":\"test\"}";

            // When
            IDictionary<StringComparison, string> result = JsonSerializer.Deserialize<IDictionary<StringComparison, string>>(json, _jsonSerializerOptions);

            // Then
            result.Should().ContainKey(StringComparison.Ordinal);
            result[StringComparison.Ordinal].Should().Be("test");
        }

        [Test]
        public void When_Deserialize_And_InvalidEnumMember()
        {
            // Given
            string json = "{\"notExisting\":\"test\"}";

            // When
            Func<IDictionary<StringComparison, string>> when = () => JsonSerializer.Deserialize<IDictionary<StringComparison, string>>(json, _jsonSerializerOptions);

            // Then
            when.Should().Throw<JsonException>().And.Message.Should().Be("Key 'notExisting' cannot be converted to enum of type 'System.StringComparison'.");
        }

        [Test]
        public void When_Deserialize_And_InvalidJson()
        {
            // Given
            string json = "[]";

            // When
            Func<IDictionary<StringComparison, string>> when = () => JsonSerializer.Deserialize<IDictionary<StringComparison, string>>(json, _jsonSerializerOptions);

            // Then
            when.Should().Throw<JsonException>().And.Message.Should().Be("Cannot convert to dictionary - json should be an object, but starts with 'StartArray'.");
        }

        [Test]
        public void When_Serialize()
        {
            // Given
            IDictionary<StringComparison, string> dictionary = new Dictionary<StringComparison, string> { { StringComparison.Ordinal, "test" } };

            // When
            string result = JsonSerializer.Serialize(dictionary, _jsonSerializerOptions);

            // Then
            result.Should().Be("{\"ordinal\":\"test\"}");
        }

        [Test]
        public void When_Serialize_WithoutNamingPolicy()
        {
            // Given
            IDictionary<StringComparison, string> dictionary = new Dictionary<StringComparison, string> { { StringComparison.Ordinal, "test" } };

            // When
            string result = JsonSerializer.Serialize(dictionary, new JsonSerializerOptions { Converters = { _converter } });

            // Then
            result.Should().Be("{\"Ordinal\":\"test\"}");
        }
    }
}