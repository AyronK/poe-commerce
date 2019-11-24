using System.Text.Json;
using FluentAssertions;
using NUnit.Framework;
using PoECommerce.TradeService.Models.Trade.Listings;
using PoECommerce.TradeService.Tests.Utility;

namespace PoECommerce.TradeService.Tests.Models.JsonSerializationTest.Trade.Listings
{
    [TestFixture]
    public class StashTest
    {
        public static ModelFromJsonTestCase<Stash>[] TestCases =
        {
            new ModelFromJsonTestCase<Stash>
            {
                Json = "{\"name\":\"Tab1\",\"x\":5,\"y\":10}",
                ExpectedResult =
                    new Stash
                    {
                        Name = "Tab1",
                        X = 5,
                        Y = 10
                    }
            },
            new ModelFromJsonTestCase<Stash>
            {
                Json = "{\"name\":\"$姓☺▬\",\"x\":15,\"y\":5}",
                ExpectedResult =
                    new Stash
                    {
                        Name = "$姓☺▬",
                        X = 15,
                        Y = 5
                    },
                Description = "Unicode name"
            }
        };

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public void When_DeserializeFromJson(ModelFromJsonTestCase<Stash> testCase)
        {
            TestContext.Write(testCase.Description);

            // When
            Stash result = JsonSerializer.Deserialize<Stash>(testCase.Json);

            // Then
            result.Should().BeEquivalentTo(testCase.ExpectedResult);
        }
    }
}