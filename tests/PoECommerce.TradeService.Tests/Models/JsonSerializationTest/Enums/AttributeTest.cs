using System.Text.Json;
using System.Text.Json.Serialization;
using FluentAssertions;
using NUnit.Framework;
using PoECommerce.TradeService.Models.Enums;

namespace PoECommerce.TradeService.Tests.Models.Enums
{
    [TestFixture]
    public class AttributeTest
    {
        [TestCase(Attribute.Dexterity, "D")]
        [TestCase(Attribute.Strength, "S")]
        [TestCase(Attribute.Intelligence, "I")]
        public void When_SerializeToJson(Attribute value, string expectedResult)
        {
            // When
            string result = JsonSerializer.Serialize(value, new JsonSerializerOptions {Converters = {new EnumJsonConverter<Attribute>()}});

            // Then
            result.Should().Be($"\"{expectedResult}\"");
        }

        [TestCase("D", Attribute.Dexterity)]
        [TestCase("S", Attribute.Strength)]
        [TestCase("I", Attribute.Intelligence)]
        public void When_DeserializeFromJson(string value, Attribute expectedResult)
        {
            // When
            Attribute result = JsonSerializer.Deserialize<Attribute>($"\"{value}\"", new JsonSerializerOptions {Converters = {new EnumJsonConverter<Attribute>()}});

            // Then
            result.Should().Be(expectedResult);
        }
    }
}