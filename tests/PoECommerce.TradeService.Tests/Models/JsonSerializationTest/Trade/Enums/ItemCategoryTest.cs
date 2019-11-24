using System.Text.Json;
using System.Text.Json.Serialization;
using FluentAssertions;
using NUnit.Framework;
using PoECommerce.PathOfExile.Models.Enums;

namespace PoECommerce.PathOfExile.Tests.Models.JsonSerializationTest.Trade.Enums
{
    [TestFixture]
    public class ItemCategoryTest
    {
        [TestCase(ItemCategory.Armour, "Armour")]
        [TestCase(ItemCategory.Accessory, "Accessories")]
        [TestCase(ItemCategory.BlightedMap, "blighted_maps")]
        [TestCase(ItemCategory.CapturedBeast, "Captured Beasts")]
        [TestCase(ItemCategory.Currency, "currency")]
        [TestCase(ItemCategory.DivinationCard, "cards")]
        [TestCase(ItemCategory.ElderMap, "elder_maps")]
        [TestCase(ItemCategory.Essence, "essences")]
        [TestCase(ItemCategory.Flask, "Flasks")]
        [TestCase(ItemCategory.Fossil, "fossils")]
        [TestCase(ItemCategory.Fragment, "fragments")]
        [TestCase(ItemCategory.Gem, "Gems")]
        [TestCase(ItemCategory.Incubator, "incubators")]
        [TestCase(ItemCategory.Jewel, "Jewels")]
        [TestCase(ItemCategory.Leaguestone, "leaguestones")]
        [TestCase(ItemCategory.Prophecy, "Prophecies")]
        [TestCase(ItemCategory.Oil, "oils")]
        [TestCase(ItemCategory.Scarab, "scarabs")]
        [TestCase(ItemCategory.Resonator, "resonators")]
        [TestCase(ItemCategory.Vial, "vials")]
        [TestCase(ItemCategory.Net, "nets")]
        [TestCase(ItemCategory.Misc, "misc")]
        [TestCase(ItemCategory.ShapedMap, "shaped_maps")]
        [TestCase(ItemCategory.Weapon, "Weapons")]
        [TestCase(ItemCategory.NormalMap, "maps")]
        public void When_SerializeToJson(ItemCategory value, string expectedResult)
        {
            // When
            string result = JsonSerializer.Serialize(value, new JsonSerializerOptions { Converters = { new EnumJsonConverter<ItemCategory>() } });

            // Then
            result.Should().Be($"\"{expectedResult}\"");
        }

        [TestCase("Accessories", ItemCategory.Accessory)]
        [TestCase("Armour", ItemCategory.Armour)]
        [TestCase("cards", ItemCategory.DivinationCard)]
        [TestCase("Cards", ItemCategory.DivinationCard)]
        [TestCase("currency", ItemCategory.Currency)]
        [TestCase("Currency", ItemCategory.Currency)]
        [TestCase("Flasks", ItemCategory.Flask)]
        [TestCase("Gems", ItemCategory.Gem)]
        [TestCase("Jewels", ItemCategory.Jewel)]
        [TestCase("maps", ItemCategory.NormalMap)]
        [TestCase("Maps", ItemCategory.NormalMap)]
        [TestCase("shaped_maps", ItemCategory.ShapedMap)]
        [TestCase("elder_maps", ItemCategory.ElderMap)]
        [TestCase("blighted_maps", ItemCategory.BlightedMap)]
        [TestCase("Weapons", ItemCategory.Weapon)]
        [TestCase("leaguestones", ItemCategory.Leaguestone)]
        [TestCase("Leaguestones", ItemCategory.Leaguestone)]
        [TestCase("Prophecies", ItemCategory.Prophecy)]
        [TestCase("Captured Beasts", ItemCategory.CapturedBeast)]
        [TestCase("fragments", ItemCategory.Fragment)]
        [TestCase("oils", ItemCategory.Oil)]
        [TestCase("incubators", ItemCategory.Incubator)]
        [TestCase("scarabs", ItemCategory.Scarab)]
        [TestCase("resonators", ItemCategory.Resonator)]
        [TestCase("fossils", ItemCategory.Fossil)]
        [TestCase("vials", ItemCategory.Vial)]
        [TestCase("nets", ItemCategory.Net)]
        [TestCase("essences", ItemCategory.Essence)]
        [TestCase("misc", ItemCategory.Misc)]
        public void When_DeserializeFromJson(string value, ItemCategory expectedResult)
        {
            // When
            ItemCategory result = JsonSerializer.Deserialize<ItemCategory>($"\"{value}\"", new JsonSerializerOptions { Converters = { new EnumJsonConverter<ItemCategory>() } });

            // Then
            result.Should().Be(expectedResult);
        }
    }
}