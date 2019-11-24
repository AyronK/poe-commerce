using System.Text.Json;
using FluentAssertions;
using NUnit.Framework;
using PoECommerce.TradeService.Models.Trade.Items;
using PoECommerce.TradeService.Tests.Utility;

namespace PoECommerce.TradeService.Tests.Models.JsonSerializationTest.Trade.Items
{
    [TestFixture]
    public class IncubatedItemTest
    {
        public static ModelFromJsonTestCase<IncubatedItem>[] TestCases =
        {
            new ModelFromJsonTestCase<IncubatedItem>
            {
                Json = "{\"name\":\"test\",\"total\":100,\"progress\":90,\"level\":83}",
                ExpectedResult =
                    new IncubatedItem
                    {
                        Name = "test",
                        Total = 100,
                        Progress = 90,
                        Level = 83
                    }
            },
            new ModelFromJsonTestCase<IncubatedItem>
            {
                Json = "{\"name\":\"test2\",\"total\":50,\"progress\":20,\"level\":25}",
                ExpectedResult =
                    new IncubatedItem
                    {
                        Name = "test2",
                        Total = 50,
                        Progress = 20,
                        Level = 25
                    }
            }
        };

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public void When_DeserializeFromJson(ModelFromJsonTestCase<IncubatedItem> testCase)
        {
            TestContext.Write(testCase.Description);

            // When
            IncubatedItem result = JsonSerializer.Deserialize<IncubatedItem>(testCase.Json);

            // Then
            result.Should().BeEquivalentTo(testCase.ExpectedResult);
        }
    }
}