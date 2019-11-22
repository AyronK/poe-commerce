using System.Text.Json;
using System.Text.Json.Serialization;
using FluentAssertions;
using NUnit.Framework;
using PoECommerce.TradeService.Models.Enums;

namespace PoECommerce.TradeService.Tests.Models.JsonSerializationTest.Enums
{
    [TestFixture]
    public class SocketColourTest
    {
        [TestCase(SocketColour.Blue, "B")]
        [TestCase(SocketColour.Red, "R")]
        [TestCase(SocketColour.Green, "G")]
        [TestCase(SocketColour.Abyss, "A")]
        [TestCase(SocketColour.White, "W")]
        public void When_SerializeToJson(SocketColour value, string expectedResult)
        {
            // When
            string result = JsonSerializer.Serialize(value, new JsonSerializerOptions {Converters = {new EnumJsonConverter<SocketColour>()}});

            // Then
            result.Should().Be($"\"{expectedResult}\"");
        }

        [TestCase("B", SocketColour.Blue)]
        [TestCase("R", SocketColour.Red)]
        [TestCase("G", SocketColour.Green)]
        [TestCase("A", SocketColour.Abyss)]
        [TestCase("W", SocketColour.White)]
        public void When_DeserializeFromJson(string value, SocketColour expectedResult)
        {
            // When
            SocketColour result = JsonSerializer.Deserialize<SocketColour>($"\"{value}\"", new JsonSerializerOptions {Converters = {new EnumJsonConverter<SocketColour>()}});

            // Then
            result.Should().Be(expectedResult);
        }
    }
}