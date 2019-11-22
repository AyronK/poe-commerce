using System.Text.Json;
using FluentAssertions;
using NUnit.Framework;
using PoECommerce.TradeService.Models.Data;
using PoECommerce.TradeService.Tests.Utility;

namespace PoECommerce.TradeService.Tests.Models.JsonSerializationTest.Data
{
    [TestFixture]
    public class StaticDataTest
    {
        public static ModelFromJsonTestCase<StaticData>[] TestCases =
        {
            new ModelFromJsonTestCase<StaticData>
            {
                Json = "{}",
                ExpectedResult =
                    new StaticData
                    {
                        Id = null,
                        Text = null,
                        Image = null
                    },
                Description = "All nulls"
            },
            new ModelFromJsonTestCase<StaticData>
            {
                Json = "{\"id\":\"idTest\",\"text\":\"textTest\",\"image\":\"/img/1\"}",
                ExpectedResult =
                    new StaticData
                    {
                        Id = "idTest",
                        Text = "textTest",
                        Image = "/img/1"
                    },
                Description = "With values"
            }
        };

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public void When_DeserializeFromJson(ModelFromJsonTestCase<StaticData> testCase)
        {
            TestContext.Write(testCase.Description);

            // When
            StaticData result = JsonSerializer.Deserialize<StaticData>(testCase.Json);

            // Then
            result.Should().BeEquivalentTo(testCase.ExpectedResult);
        }
    }
}