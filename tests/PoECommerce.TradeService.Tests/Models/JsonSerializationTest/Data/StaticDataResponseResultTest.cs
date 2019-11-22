using System.Collections.Generic;
using System.Text.Json;
using FluentAssertions;
using NUnit.Framework;
using PoECommerce.TradeService.Models.Data;
using PoECommerce.TradeService.Models.Enums;
using PoECommerce.TradeService.Tests.Utility;

namespace PoECommerce.TradeService.Tests.Models.JsonSerializationTest.Data
{
    [TestFixture]
    public class StaticDataResponseResultTest
    {
        public static ModelFromJsonTestCase<StaticDataResponseResult>[] TestCases =
        {
            new ModelFromJsonTestCase<StaticDataResponseResult>
            {
                Json = "{\"result\":{}}",
                ExpectedResult =
                    new StaticDataResponseResult
                    {
                        Result = new Dictionary<ItemCategory, StaticData[]>()
                    },
                Description = "All nulls"
            },
            new ModelFromJsonTestCase<StaticDataResponseResult>
            {
                Json = "{\"result\":{\"Armour\":[]}}",
                ExpectedResult =
                    new StaticDataResponseResult
                    {
                        Result = new Dictionary<ItemCategory, StaticData[]>
                        {
                            {ItemCategory.Armour, new StaticData[0]}
                        }
                    },
                Description = "With one empty category"
            },
            new ModelFromJsonTestCase<StaticDataResponseResult>
            {
                Json = "{\"result\":{\"Armour\":[{\"id\":\"idTest\",\"text\":\"textTest\",\"image\":\"/img/1\"}]}}",
                ExpectedResult =
                    new StaticDataResponseResult
                    {
                        Result = new Dictionary<ItemCategory, StaticData[]>
                        {
                            {
                                ItemCategory.Armour, new[]
                                {
                                    new StaticData
                                    {
                                        Id = "idTest",
                                        Text = "textTest",
                                        Image = "/img/1"
                                    }
                                }
                            }
                        }
                    },
                Description = "With one empty category"
            }
        };

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public void When_DeserializeFromJson(ModelFromJsonTestCase<StaticDataResponseResult> testCase)
        {
            TestContext.Write(testCase.Description);

            // When
            StaticDataResponseResult result = JsonSerializer.Deserialize<StaticDataResponseResult>(testCase.Json);

            // Then
            result.Should().BeEquivalentTo(testCase.ExpectedResult);
        }
    }
}