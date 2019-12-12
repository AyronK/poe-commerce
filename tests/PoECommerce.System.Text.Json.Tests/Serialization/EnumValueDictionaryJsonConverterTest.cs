using System.Collections.Generic;
using System.Text.Json.Serialization;
using FluentAssertions;
using NUnit.Framework;

namespace System.Text.Json.Tests.Serialization
{
    [TestFixture]
    public class EnumValueDictionaryJsonConverterTest
    {
        [SetUp]
        public void SetUp()
        {
            _converter = new EnumValueDictionaryJsonConverter<string, StringComparison>();
            _jsonSerializerOptions = new JsonSerializerOptions {Converters = {_converter}, AllowTrailingCommas = true, DictionaryKeyPolicy = JsonNamingPolicy.CamelCase};
        }

        private EnumValueDictionaryJsonConverter<string, StringComparison> _converter;
        private JsonSerializerOptions _jsonSerializerOptions;

        [Test]
        public void When_Deserialize()
        {
            // Given
            string json = "{\"test\":\"ordinal\"}";

            // When
            IDictionary<string, StringComparison> result = JsonSerializer.Deserialize<IDictionary<string, StringComparison>>(json, _jsonSerializerOptions);

            // Then
            result.Should().ContainKey("test");
            result["test"].Should().Be(StringComparison.Ordinal);
        }

        [Test]
        public void When_Deserialize_And_InvalidEnumMember()
        {
            // Given
            string json = "{\"test\":\"notExisting\"}";

            // When
            Func<IDictionary<string, StringComparison>> when = () => JsonSerializer.Deserialize<IDictionary<string, StringComparison>>(json, _jsonSerializerOptions);

            // Then
            when.Should().Throw<JsonException>().And.Message.Should().Be("Value 'notExisting' cannot be converted to enum of type 'System.StringComparison'.");
        }

        [Test]
        public void When_Deserialize_And_InvalidJson()
        {
            // Given
            string json = "[]";

            // When
            Func<IDictionary<string, StringComparison>> when = () => JsonSerializer.Deserialize<IDictionary<string, StringComparison>>(json, _jsonSerializerOptions);

            // Then
            when.Should().Throw<JsonException>().And.Message.Should().Be("Cannot convert to dictionary - json should be an object, but starts with 'StartArray'.");
        }

        [Test]
        public void When_Serialize()
        {
            // Given
            IDictionary<string, StringComparison> dictionary = new Dictionary<string, StringComparison> {{"test", StringComparison.Ordinal}};

            // When
            string result = JsonSerializer.Serialize(dictionary, _jsonSerializerOptions);

            // Then
            result.Should().Be("{\"test\":4}");
        }
    }
}