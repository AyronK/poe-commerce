using System.Text.Json.Serialization;
using FluentAssertions;
using NUnit.Framework;

namespace System.Text.Json.Tests.Serialization
{
    [TestFixture]
    public class EnumValueJsonConverterTest
    {
        private enum TestEnum
        {
            [JsonEnumName("customText")]
            MemberWithCustomText = 0,
            NormalMember = 1,
        }

        private EnumJsonConverter<TestEnum> _converter;
        private JsonSerializerOptions _jsonSerializerOptions;

        [SetUp]
        public void SetUp()
        {
            _converter = new EnumJsonConverter<TestEnum>();
            _jsonSerializerOptions = new JsonSerializerOptions { Converters = { _converter }, AllowTrailingCommas = true };
        }

        [Test]
        public void When_SerializeEnumMember_WithoutCustomText()
        {
            // Given
            TestEnum enumMember = TestEnum.NormalMember;

            // When
            string result = JsonSerializer.Serialize(enumMember, _jsonSerializerOptions);

            // Then
            result.Should().Be(TestEnum.NormalMember.ToString("D"));
        }

        [Test]
        public void When_SerializeEnumMember_WithCustomText()
        {
            // Given
            TestEnum enumMember = TestEnum.MemberWithCustomText;

            // When
            string result = JsonSerializer.Serialize(enumMember, _jsonSerializerOptions);

            // Then
            result.Should().Be("\"customText\"");
        }

        [Test]
        public void When_DeserializeEnumMember_WithoutCustomText()
        {
            // Given
            string json = "1";

            // When
            TestEnum result = JsonSerializer.Deserialize<TestEnum>(json, _jsonSerializerOptions);

            // Then
            result.Should().Be(TestEnum.NormalMember);
        }

        [Test]
        public void When_DeserializeEnumMember_WithCustomText()
        {
            // Given
            string json = "\"customText\"";

            // When
            TestEnum result = JsonSerializer.Deserialize<TestEnum>(json, _jsonSerializerOptions);

            // Then
            result.Should().Be(TestEnum.MemberWithCustomText);
        }

        [Test]
        public void When_DeserializeEnumMember_WithCustomText_ButFromNumber()
        {
            // Given
            string json = "0";

            // When
            TestEnum result = JsonSerializer.Deserialize<TestEnum>(json, _jsonSerializerOptions);

            // Then
            result.Should().Be(TestEnum.MemberWithCustomText);
        }
    }
}