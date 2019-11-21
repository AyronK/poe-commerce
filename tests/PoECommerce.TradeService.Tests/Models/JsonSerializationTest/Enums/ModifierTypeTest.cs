using System.Text.Json;
using System.Text.Json.Serialization;
using FluentAssertions;
using NUnit.Framework;
using PoECommerce.TradeService.Models.Enums;

namespace PoECommerce.TradeService.Tests.Models.Enums
{
    [TestFixture]
    public class ModifierTypeTest
    {
        [TestCase(ModifierType.Crafted, "crafted")]
        [TestCase(ModifierType.Delve, "delve")]
        [TestCase(ModifierType.Enchant, "enchant")]
        [TestCase(ModifierType.Explicit, "explicit")]
        [TestCase(ModifierType.Implicit, "implicit")]
        [TestCase(ModifierType.Pseudo, "pseudo")]
        public void When_SerializeToJson(ModifierType value, string expectedResult)
        {
            // When
            string result = JsonSerializer.Serialize(value, new JsonSerializerOptions {Converters = {new EnumJsonConverter<ModifierType>()}});

            // Then
            result.Should().Be($"\"{expectedResult}\"");
        }

        [TestCase("crafted", ModifierType.Crafted)]
        [TestCase("enchant", ModifierType.Enchant)]
        [TestCase("explicit", ModifierType.Explicit)]
        [TestCase("implicit", ModifierType.Implicit)]
        [TestCase("pseudo", ModifierType.Pseudo)]
        [TestCase("delve", ModifierType.Delve)]
        public void When_DeserializeFromJson(string value, ModifierType expectedResult)
        {
            // When
            ModifierType result = JsonSerializer.Deserialize<ModifierType>($"\"{value}\"", new JsonSerializerOptions {Converters = {new EnumJsonConverter<ModifierType>()}});

            // Then
            result.Should().Be(expectedResult);
        }
    }
}