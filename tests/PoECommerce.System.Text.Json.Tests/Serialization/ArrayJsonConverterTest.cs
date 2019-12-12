using System.Text.Json.Serialization;
using FluentAssertions;
using NUnit.Framework;

namespace System.Text.Json.Tests.Serialization
{
    [TestFixture]
    public class ArrayJsonConverterTest
    {
        [SetUp]
        public void SetUp()
        {
            _converter = new ArrayJsonConverter<int, TestJsonConverter>();
            _jsonSerializerOptions = new JsonSerializerOptions {Converters = {_converter}, AllowTrailingCommas = true};
        }

        [TearDown]
        public void CleanUp()
        {
            TestJsonConverter.ReadCounter = 0;
            TestJsonConverter.WriteCounter = 0;
        }

        private ArrayJsonConverter<int, TestJsonConverter> _converter;
        private JsonSerializerOptions _jsonSerializerOptions;

        [TestCase(1)]
        [TestCase(1, 2, 3, 4, 5)]
        [TestCase(3, 2, 1)]
        public void When_DeserializeArray(params int[] values)
        {
            // Given
            string json = $"[{string.Join(',', values)}]";

            // When
            int[] result = JsonSerializer.Deserialize<int[]>(json, _jsonSerializerOptions);

            // Then
            result.Should().BeEquivalentTo(values);
            TestJsonConverter.ReadCounter.Should().Be(values.Length);
            TestJsonConverter.WriteCounter.Should().Be(0);
        }

        [TestCase(1)]
        [TestCase(1, 2, 3, 4, 5)]
        [TestCase(3, 2, 1)]
        public void When_SerializeArray(params int[] values)
        {
            // When
            string result = JsonSerializer.Serialize(values, _jsonSerializerOptions);

            // Then
            result.Should().Be($"[{string.Join(',', values)}]");
            TestJsonConverter.WriteCounter.Should().Be(values.Length);
            TestJsonConverter.ReadCounter.Should().Be(0);
        }

        [TestCase("{}", "Cannot convert to Int32[] - json should be an array, but it starts with 'StartObject'.")]
        [TestCase("\"test\"", "Cannot convert to Int32[] - json should be an array, but it starts with 'String'.")]
        public void When_InvalidJson(string json, string expectedMessage)
        {
            // When
            Func<int[]> when = () => JsonSerializer.Deserialize<int[]>(json, _jsonSerializerOptions);

            // Then
            when.Should().Throw<JsonException>().And.Message.Should().Be(expectedMessage);
        }

        [Test]
        public void When_DeserializeEmptyArray()
        {
            // Given
            string json = "[]";

            // When
            int[] result = JsonSerializer.Deserialize<int[]>(json, _jsonSerializerOptions);

            // Then
            result.Should().BeEquivalentTo(new int[0]);
            TestJsonConverter.ReadCounter.Should().Be(0);
            TestJsonConverter.WriteCounter.Should().Be(0);
        }

        [Test]
        public void When_SerializeEmptyArray()
        {
            // When
            string result = JsonSerializer.Serialize(new int[0], _jsonSerializerOptions);

            // Then
            result.Should().Be("[]");
            TestJsonConverter.WriteCounter.Should().Be(0);
            TestJsonConverter.ReadCounter.Should().Be(0);
        }

        private class TestJsonConverter : JsonConverter<int>
        {
            public static int ReadCounter { get; set; }
            public static int WriteCounter { get; set; }

            public override int Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                return ++ReadCounter;
            }

            public override void Write(Utf8JsonWriter writer, int value, JsonSerializerOptions options)
            {
                writer.WriteNumberValue(value);
                WriteCounter++;
            }
        }
    }
}