using System.Text.Json;
using FluentAssertions;
using NUnit.Framework;
using PoECommerce.PathOfExile.Models.Data;
using PoECommerce.PathOfExile.Models.Enums;
using PoECommerce.PathOfExile.Tests.Utility;

namespace PoECommerce.PathOfExile.Tests.Models.JsonSerializationTest.Data
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
                                Discriminator = "testDisc",
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