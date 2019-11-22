using System.Text.Json;
using System.Text.Json.Serialization;
using FluentAssertions;
using NUnit.Framework;
using PoECommerce.TradeService.Models.Enums;

namespace PoECommerce.TradeService.Tests.Models.JsonSerializationTest.Enums
{
    [TestFixture]
    public class ItemFlagTest
    {
        [TestCase(ItemFlag.Prophecy, "prophecy")]
        [TestCase(ItemFlag.Unique, "unique")]
        public void When_SerializeToJson(ItemFlag value, string expectedResult)
        {
            // When
            string result = JsonSerializer.Serialize(value, new JsonSerializerOptions { Converters = { new EnumJsonConverter<ItemFlag>() } });

            // Then
            result.Should().Be($"\"{expectedResult}\"");
        }

        [TestCase("prophecy", ItemFlag.Prophecy)]
        [TestCase("unique", ItemFlag.Unique)]
        public void When_DeserializeFromJson(string value, ItemFlag expectedResult)
        {
            // When
            ItemFlag result = JsonSerializer.Deserialize<ItemFlag>($"\"{value}\"", new JsonSerializerOptions { Converters = { new EnumJsonConverter<ItemFlag>() } });

            // Then
            result.Should().Be(expectedResult);
        }
    }
}