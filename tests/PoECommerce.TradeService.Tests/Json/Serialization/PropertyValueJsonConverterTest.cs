using System;
using System.Text.Json;
using FluentAssertions;
using NUnit.Framework;
using PoECommerce.PathOfExile.Json.Serialization;
using PoECommerce.PathOfExile.Models.Trade.Enums;
using PoECommerce.PathOfExile.Models.Trade.Items;

namespace PoECommerce.PathOfExile.Tests.Json.Serialization
{
    [TestFixture]
    public class PropertyValueJsonConverterTest
    {
        private PropertyValueJsonConverter _converter;
        private JsonSerializerOptions _jsonSerializerOptions;

        [SetUp]
        public void SetUp()
        {
            _converter = new PropertyValueJsonConverter();
            _jsonSerializerOptions = new JsonSerializerOptions { Converters = { _converter }, AllowTrailingCommas = true };
        }

        [TestCase("25%", TextFormat.Augmented)]
        [TestCase("55", TextFormat.Simple)]
        [TestCase("10-20", TextFormat.ColdDamage)]
        [TestCase("22-45", TextFormat.FireDamage)]
        [TestCase("25-30", TextFormat.ChaosDamage)]
        public void When_DeserializeSinglePropertyValue(string value, TextFormat format)
        {
            // Given
            string json = $"[\"{value}\",{(int)format}]";

            // When
            PropertyValue result = JsonSerializer.Deserialize<PropertyValue>(json, _jsonSerializerOptions);

            // Then
            result.Format.Should().Be(format);
            result.Value.Should().Be(value);
        }

        [TestCase("25%", TextFormat.Augmented)]
        [TestCase("55", TextFormat.Simple)]
        [TestCase("10-20", TextFormat.ColdDamage)]
        [TestCase("22-45", TextFormat.FireDamage)]
        [TestCase("25-30", TextFormat.ChaosDamage)]
        public void When_SerializeSinglePropertyValue(string value, TextFormat format)
        {
            // Given
            PropertyValue propertyValue = new PropertyValue { Value = value, Format = format };

            // When
            string result = JsonSerializer.Serialize(propertyValue, _jsonSerializerOptions);

            // Then
            result.Should().Be($"[\"{value}\",{(int)format}]");
        }

        [Test]
        public void When_SerializeMSinglePropertyValue_And_DeserializeBack()
        {
            // Given
            PropertyValue propertyValue = new PropertyValue { Value = "value", Format = TextFormat.ColdDamage };

            // When
            string json = JsonSerializer.Serialize(propertyValue, _jsonSerializerOptions);
            PropertyValue result = JsonSerializer.Deserialize<PropertyValue>(json, _jsonSerializerOptions);

            // Then
            result.Value.Should().Be(propertyValue.Value);
            result.Format.Should().Be(propertyValue.Format);
        }

        [TestCase("25%", TextFormat.Augmented, "55", TextFormat.Simple)]
        [TestCase("10-20", TextFormat.ColdDamage, "22-45", TextFormat.FireDamage)]
        [TestCase("-10%", TextFormat.Simple, "100", TextFormat.ColdDamage)]
        public void When_DeserializeMultiplePropertyValues(string firstValue, TextFormat firstFormat, string secondValue, TextFormat secondFormat)
        {
            // Given
            string json = $"[[\"{firstValue}\",{(int)firstFormat}],[\"{secondValue}\",{(int)secondFormat}]]";

            // When
            PropertyValue[] result = JsonSerializer.Deserialize<PropertyValue[]>(json, _jsonSerializerOptions);

            // Then
            result.Should().HaveCount(2);

            result[0].Format.Should().Be(firstFormat);
            result[0].Value.Should().Be(firstValue);

            result[1].Format.Should().Be(secondFormat);
            result[1].Value.Should().Be(secondValue);
        }

        [TestCase("25%", TextFormat.Augmented, "55", TextFormat.Simple)]
        [TestCase("10-20", TextFormat.ColdDamage, "22-45", TextFormat.FireDamage)]
        [TestCase("-10%", TextFormat.Simple, "100", TextFormat.ColdDamage)]
        public void When_SerializeMultiplePropertyValues(string firstValue, TextFormat firstFormat, string secondValue, TextFormat secondFormat)
        {
            // Given
            PropertyValue[] propertyValues =
            {
                new PropertyValue { Value = firstValue, Format = firstFormat },
                new PropertyValue { Value = secondValue, Format = secondFormat }
            };

            // When
            string result = JsonSerializer.Serialize(propertyValues, _jsonSerializerOptions);

            // Then
            result.Should().Be($"[[\"{firstValue}\",{(int)firstFormat}],[\"{secondValue}\",{(int)secondFormat}]]");
        }

        [Test]
        public void When_SerializeMultiplePropertyValues_And_DeserializeBack()
        {
            // Given
            PropertyValue[] propertyValues =
            {
                new PropertyValue { Value = "value1", Format = TextFormat.ColdDamage },
                new PropertyValue { Value = "value2", Format = TextFormat.ChaosDamage }
            };

            // When
            string json = JsonSerializer.Serialize(propertyValues, _jsonSerializerOptions);
            PropertyValue[] result = JsonSerializer.Deserialize<PropertyValue[]>(json, _jsonSerializerOptions);

            // Then
            result.Should().HaveCount(2);

            result[0].Value.Should().Be(propertyValues[0].Value);
            result[0].Format.Should().Be(propertyValues[0].Format);

            result[1].Value.Should().Be(propertyValues[1].Value);
            result[1].Format.Should().Be(propertyValues[1].Format);
        }

        [TestCase("{\"value\":\"25%\",\"format\":1}", "Cannot convert to PropertyValue - json should be a two element array, but starts with 'StartObject'.", Description = "Two element array is expected.")]
        [TestCase("[0, 10]", "Cannot convert to PropertyValue - the first value in the array should be 'String', but is 'Number'.", Description = "First element should be a string.")]
        [TestCase("[null, 10]", "Cannot convert to PropertyValue - the first value in the array should be 'String', but is 'Null'.", Description = "First element should be a string.")]
        [TestCase("[\"25%\", \"10\"]", "Cannot convert to PropertyValue - the second value in the array should be 'Number', but is 'String'.", Description = "Second element should be a number.")]
        [TestCase("[\"25%\", null]", "Cannot convert to PropertyValue - the second value in the array should be 'Number', but is 'Null'.", Description = "Second element should be a number.")]
        [TestCase("[\"25%\", 10, 10]", "Cannot convert to PropertyValue - json should be a two element array, but there is 'Number' after the second element.", Description = "There should be only two elements.")]
        [TestCase("[\"25%\", 10, null]", "Cannot convert to PropertyValue - json should be a two element array, but there is 'Null' after the second element.", Description = "There should be only two elements.")]
        public void When_InvalidJson(string json, string expectedMessage)
        {
            // When
            Func<PropertyValue> when = () => JsonSerializer.Deserialize<PropertyValue>(json, _jsonSerializerOptions);

            // Then
            when.Should().Throw<JsonException>().And.Message.Should().Be(expectedMessage);
        }
    }
}