using System.Text.Json;
using System.Text.Json.Serialization;
using FluentAssertions;
using NUnit.Framework;
using PoECommerce.TradeService.Models.Search.Enums;

namespace PoECommerce.TradeService.Tests.Models.JsonSerializationTest.Search.Filters.Enums
{
    [TestFixture]
    public class ItemRarityTest
    {
        [TestCase(ItemRarity.Normal, "normal")]
        [TestCase(ItemRarity.Magic, "magic")]
        [TestCase(ItemRarity.Rare, "rare")]
        [TestCase(ItemRarity.NonUnique, "nonunique")]
        [TestCase(ItemRarity.Relic, "uniquefoil")]
        [TestCase(ItemRarity.Unique, "unique")]
        public void When_SerializeToJson(ItemRarity value, string expectedResult)
        {
            // When
            string result = JsonSerializer.Serialize(value, new JsonSerializerOptions {Converters = {new EnumJsonConverter<ItemRarity>()}});

            // Then
            result.Should().Be($"\"{expectedResult}\"");
        }

        [TestCase("normal", ItemRarity.Normal)]
        [TestCase("magic", ItemRarity.Magic)]
        [TestCase("rare", ItemRarity.Rare)]
        [TestCase("nonunique", ItemRarity.NonUnique)]
        [TestCase("uniquefoil", ItemRarity.Relic)]
        [TestCase("unique", ItemRarity.Unique)]
        public void When_DeserializeFromJson(string value, ItemRarity expectedResult)
        {
            // When
            ItemRarity result = JsonSerializer.Deserialize<ItemRarity>($"\"{value}\"", new JsonSerializerOptions {Converters = {new EnumJsonConverter<ItemRarity>()}});

            // Then
            result.Should().Be(expectedResult);
        }
    }
}