using System.Text.Json;
using FluentAssertions;
using NUnit.Framework;
using PoECommerce.TradeService.Models.TradeAPI.Listings;

namespace PoECommerce.TradeService.Tests.Models.JsonSerializationTest.TradeAPI.Listings
{
    [TestFixture]
    public class PriceTest
    {
        public static ModelFromJsonTestCase<Price>[] TestCases =
        {
            new ModelFromJsonTestCase<Price>
            {
                Json = "{\"type\":null,\"amount\":null,\"currency\":null}",
                ExpectedResult =
                    new Price
                    {
                        Type = null,
                        Amount = null,
                        Currency = null
                    },
                Description = "All is empty"
            },
            new ModelFromJsonTestCase<Price>
            {
                Json = "{\"type\":\"~b/o\",\"amount\":null,\"currency\":\"exa\"}",
                ExpectedResult =
                    new Price
                    {
                        Type = "~b/o",
                        Amount = null,
                        Currency = "exa"
                    },
                Description = "Price is null"
            },
            new ModelFromJsonTestCase<Price>
            {
                Json = "{\"type\":\"~fixed\",\"amount\":10,\"currency\":\"chrom\"}",
                ExpectedResult =
                    new Price
                    {
                        Type = "~fixed",
                        Amount = 10,
                        Currency = "chrom"
                    },
                Description = "Price is specified"
            }
        };

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public void When_DeserializeFromJson(ModelFromJsonTestCase<Price> testCase)
        {
            TestContext.Write(testCase.Description);

            // When
            Price result = JsonSerializer.Deserialize<Price>(testCase.Json);

            // Then
            result.Should().BeEquivalentTo(testCase.ExpectedResult);
        }
    }
}