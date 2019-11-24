using System.Collections.Generic;
using System.Text.Json.Serialization;
using FluentAssertions;
using NUnit.Framework;

namespace System.Text.Json.Tests.Serialization
{
    [TestFixture]
    public class EnumKeyDictionaryJsonConverterTest
    {
        private class TestClass
        {
            public string Text { get; set; }
            public int Value { get; set; }
            public bool IsTrue { get; set; }
        }

        private JsonSerializerOptions _jsonSerializerOptions;

        protected void With_Converter<TKey, TValue>(JsonNamingPolicy policy = null) where TKey : struct, Enum
        {
            EnumKeyDictionaryJsonConverter<TKey, TValue> converter = new EnumKeyDictionaryJsonConverter<TKey, TValue>();
            _jsonSerializerOptions = new JsonSerializerOptions {Converters = {converter}, DictionaryKeyPolicy = policy};
        }

        [TestCase("true", true)]
        [TestCase("false", false)]
        public void When_Deserialize_Boolean(string jsonValue, bool expected)
        {
            // Given
            With_Converter<StringComparison, bool>(JsonNamingPolicy.CamelCase);
            string json = $"{{\"ordinal\":{jsonValue}}}";

            // When
            IDictionary<StringComparison, bool> result = JsonSerializer.Deserialize<IDictionary<StringComparison, bool>>(json, _jsonSerializerOptions);

            // Then
            result.Should().ContainKey(StringComparison.Ordinal);
            result[StringComparison.Ordinal].Should().Be(expected);
        }

        [TestCase("1", 1)]
        [TestCase("2", 2)]
        public void When_Deserialize_Integer(string jsonValue, int expected)
        {
            // Given
            With_Converter<StringComparison, int>(JsonNamingPolicy.CamelCase);
            string json = $"{{\"ordinal\":{jsonValue}}}";

            // When
            IDictionary<StringComparison, int> result = JsonSerializer.Deserialize<IDictionary<StringComparison, int>>(json, _jsonSerializerOptions);

            // Then
            result.Should().ContainKey(StringComparison.Ordinal);
            result[StringComparison.Ordinal].Should().Be(expected);
        }

        [Test]
        public void When_Deserialize_And_InvalidEnumMember()
        {
            // Given
            With_Converter<StringComparison, string>(JsonNamingPolicy.CamelCase);
            string json = "{\"notExisting\":\"test\"}";

            // When
            Func<IDictionary<StringComparison, string>> when = () => JsonSerializer.Deserialize<IDictionary<StringComparison, string>>(json, _jsonSerializerOptions);

            // Then
            when.Should().Throw<JsonException>().And.Message.Should().Be("Value 'notExisting' cannot be converted to enum of type 'System.StringComparison'.");
        }

        [Test]
        public void When_Deserialize_And_InvalidJson()
        {
            // Given
            With_Converter<StringComparison, string>(JsonNamingPolicy.CamelCase);
            string json = "[]";

            // When
            Func<IDictionary<StringComparison, string>> when = () => JsonSerializer.Deserialize<IDictionary<StringComparison, string>>(json, _jsonSerializerOptions);

            // Then
            when.Should().Throw<JsonException>().And.Message.Should().Be("Cannot convert to dictionary - json should be an object, but starts with 'StartArray'.");
        }

        [Test]
        public void When_Deserialize_Array()
        {
            // Given
            With_Converter<StringComparison, int[]>(JsonNamingPolicy.CamelCase);
            string json = "{\"ordinal\":[1,2,3]}";

            // When
            IDictionary<StringComparison, int[]> result = JsonSerializer.Deserialize<IDictionary<StringComparison, int[]>>(json, _jsonSerializerOptions);

            // Then
            result.Should().ContainKey(StringComparison.Ordinal);
            result[StringComparison.Ordinal].Should().BeEquivalentTo(new[] {1, 2, 3});
        }

        [Test]
        public void When_Deserialize_Object()
        {
            // Given
            With_Converter<StringComparison, TestClass>(JsonNamingPolicy.CamelCase);
            string json = "{\"ordinal\":{\"Text\":\"test\",\"Value\":2,\"IsTrue\":true}}";

            // When
            IDictionary<StringComparison, TestClass> result = JsonSerializer.Deserialize<IDictionary<StringComparison, TestClass>>(json, _jsonSerializerOptions);

            // Then
            result.Should().ContainKey(StringComparison.Ordinal);
            result[StringComparison.Ordinal].Should().BeEquivalentTo(new TestClass {Value = 2, Text = "test", IsTrue = true});
        }

        [Test]
        public void When_Deserialize_String()
        {
            // Given
            With_Converter<StringComparison, string>(JsonNamingPolicy.CamelCase);
            string json = "{\"ordinal\":\"test\"}";

            // When
            IDictionary<StringComparison, string> result = JsonSerializer.Deserialize<IDictionary<StringComparison, string>>(json, _jsonSerializerOptions);

            // Then
            result.Should().ContainKey(StringComparison.Ordinal);
            result[StringComparison.Ordinal].Should().Be("test");
        }

        [Test]
        public void When_Serialize()
        {
            // Given
            With_Converter<StringComparison, string>(JsonNamingPolicy.CamelCase);
            IDictionary<StringComparison, string> dictionary = new Dictionary<StringComparison, string> {{StringComparison.Ordinal, "test"}};

            // When
            string result = JsonSerializer.Serialize(dictionary, _jsonSerializerOptions);

            // Then
            result.Should().Be("{\"ordinal\":\"test\"}");
        }

        [Test]
        public void When_Serialize_WithoutNamingPolicy()
        {
            // Given
            With_Converter<StringComparison, string>();
            IDictionary<StringComparison, string> dictionary = new Dictionary<StringComparison, string> {{StringComparison.Ordinal, "test"}};

            // When
            string result = JsonSerializer.Serialize(dictionary, _jsonSerializerOptions);

            // Then
            result.Should().Be("{\"Ordinal\":\"test\"}");
        }
    }
}