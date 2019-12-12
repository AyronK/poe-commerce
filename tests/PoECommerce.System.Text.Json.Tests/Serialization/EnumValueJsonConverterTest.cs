using System.Text.Json.Serialization;
using FluentAssertions;
using NUnit.Framework;

namespace System.Text.Json.Tests.Serialization
{
    [TestFixture]
    public class EnumValueJsonConverterTest
    {
        private EnumJsonConverter<TestEnum> _converter;
        private JsonSerializerOptions _jsonSerializerOptions;

        private enum TestEnum
        {
            [JsonEnumName("customText")]
            MemberWithCustomText = 0,

            NormalMember = 1,

            [JsonEnumName("customText1", "customText2")]
            MemberWithTwoCustomTexts = 2
        }

        protected void With_Converter(bool isDictionaryKey)
        {
            _converter = new EnumJsonConverter<TestEnum>(isDictionaryKey);
            _jsonSerializerOptions = new JsonSerializerOptions { Converters = { _converter }, AllowTrailingCommas = true };
        }

        [TestCase("\"customText1\"")]
        [TestCase("\"customText2\"")]
        [TestCase("2")]
        public void When_DeserializeEnumMember_WithTwoCustomTexts(string json)
        {
            // Given
            With_Converter(false);

            // When
            TestEnum result = JsonSerializer.Deserialize<TestEnum>(json, _jsonSerializerOptions);

            // Then
            result.Should().Be(TestEnum.MemberWithTwoCustomTexts);
        }

        [Test]
        public void When_DeserializeEnumMember_WithCustomText()
        {
            // Given
            With_Converter(false);
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
            With_Converter(false);
            string json = "0";

            // When
            TestEnum result = JsonSerializer.Deserialize<TestEnum>(json, _jsonSerializerOptions);

            // Then
            result.Should().Be(TestEnum.MemberWithCustomText);
        }

        [Test]
        public void When_DeserializeEnumMember_WithoutCustomText()
        {
            // Given
            With_Converter(false);
            string json = "1";

            // When
            TestEnum result = JsonSerializer.Deserialize<TestEnum>(json, _jsonSerializerOptions);

            // Then
            result.Should().Be(TestEnum.NormalMember);
        }

        [Test]
        public void When_SerializeEnumMember_WithCustomText()
        {
            // Given
            With_Converter(false);
            TestEnum enumMember = TestEnum.MemberWithCustomText;

            // When
            string result = JsonSerializer.Serialize(enumMember, _jsonSerializerOptions);

            // Then
            result.Should().Be("\"customText\"");
        }

        [Test]
        public void When_SerializeEnumMember_WithoutCustomText()
        {
            // Given
            With_Converter(false);
            TestEnum enumMember = TestEnum.NormalMember;

            // When
            string result = JsonSerializer.Serialize(enumMember, _jsonSerializerOptions);

            // Then
            result.Should().Be(TestEnum.NormalMember.ToString("D"));
        }

        [Test]
        public void When_SerializeEnumMember_WithTwoCustomTexts()
        {
            // Given
            With_Converter(false);
            TestEnum enumMember = TestEnum.MemberWithTwoCustomTexts;

            // When
            string result = JsonSerializer.Serialize(enumMember, _jsonSerializerOptions);

            // Then
            result.Should().Be("\"customText1\"");
        }
    }
}