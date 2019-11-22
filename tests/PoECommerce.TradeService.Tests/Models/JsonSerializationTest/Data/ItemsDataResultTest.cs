using System.Text.Json;
using FluentAssertions;
using NUnit.Framework;
using PoECommerce.TradeService.Models.Data;
using PoECommerce.TradeService.Models.Enums;
using PoECommerce.TradeService.Tests.Utility;

namespace PoECommerce.TradeService.Tests.Models.JsonSerializationTest.Data
{
    [TestFixture]
    internal class ItemsDataResultTest
    {
        public static ModelFromJsonTestCase<ItemsDataResult>[] TestCases =
        {
            new ModelFromJsonTestCase<ItemsDataResult>
            {
                Json = "{\"entries\":[],\"label\":\"blighted_maps\"}",
                ExpectedResult =
                    new ItemsDataResult
                    {
                        Items = new Item[0],
                        Category = ItemCategory.BlightedMap
                    },
                Description = "Empty items"
            },
            new ModelFromJsonTestCase<ItemsDataResult>
            {
                Json = "{\"entries\":[{\"name\":\"testName\",\"type\":\"testType\",\"text\":\"testText\",\"disc\":\"testDisc\",\"flags\":null}],\"label\":\"blighted_maps\"}",
                ExpectedResult =
                    new ItemsDataResult
                    {
                        Items = new[]
                        {
                            new Item
                            {
                                Name = "testName",
                                Type = "testType",
                                Text = "testText",
                                Disclaimer = "testDisc",
                                Flags = null
                            }
                        },
                        Category = ItemCategory.BlightedMap
                    },
                Description = "Empty items"
            }
        };

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public void When_DeserializeFromJson(ModelFromJsonTestCase<ItemsDataResult> testCase)
        {
            TestContext.Write(testCase.Description);

            // When
            ItemsDataResult result = JsonSerializer.Deserialize<ItemsDataResult>(testCase.Json);

            // Then
            result.Should().BeEquivalentTo(testCase.ExpectedResult);
        }
    }
}