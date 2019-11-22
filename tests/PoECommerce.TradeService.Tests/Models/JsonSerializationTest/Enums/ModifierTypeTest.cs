using System.Text.Json;
using System.Text.Json.Serialization;
using FluentAssertions;
using NUnit.Framework;
using PoECommerce.TradeService.Models.Enums;

namespace PoECommerce.TradeService.Tests.Models.JsonSerializationTest.Enums
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
        [TestCase(ModifierType.Fractured, "fractured")]
        [TestCase(ModifierType.Veiled, "veiled")]
        [TestCase(ModifierType.Monster, "monster")]
        public void When_SerializeToJson(ModifierType value, string expectedResult)
        {
            // When
            string result = JsonSerializer.Serialize(value, new JsonSerializerOptions {Converters = {new EnumJsonConverter<ModifierType>()}});

            // Then
            result.Should().Be($"\"{expectedResult}\"");
        }

        [TestCase("crafted", ModifierType.Crafted)]
        [TestCase("Crafted", ModifierType.Crafted)]
        [TestCase("enchant", ModifierType.Enchant)]
        [TestCase("Enchant", ModifierType.Enchant)]
        [TestCase("explicit", ModifierType.Explicit)]
        [TestCase("Explicit", ModifierType.Explicit)]
        [TestCase("implicit", ModifierType.Implicit)]
        [TestCase("Implicit", ModifierType.Implicit)]
        [TestCase("pseudo", ModifierType.Pseudo)]
        [TestCase("Pseudo", ModifierType.Pseudo)]
        [TestCase("delve", ModifierType.Delve)]
        [TestCase("Delve", ModifierType.Delve)]
        [TestCase("fractured", ModifierType.Fractured)]
        [TestCase("Fractured", ModifierType.Fractured)]
        [TestCase("veiled", ModifierType.Veiled)]
        [TestCase("Veiled", ModifierType.Veiled)]
        [TestCase("monster", ModifierType.Monster)]
        [TestCase("Monster", ModifierType.Monster)]
        public void When_DeserializeFromJson(string value, ModifierType expectedResult)
        {
            // When
            ModifierType result = JsonSerializer.Deserialize<ModifierType>($"\"{value}\"", new JsonSerializerOptions {Converters = {new EnumJsonConverter<ModifierType>()}});

            // Then
            result.Should().Be(expectedResult);
        }
    }
}