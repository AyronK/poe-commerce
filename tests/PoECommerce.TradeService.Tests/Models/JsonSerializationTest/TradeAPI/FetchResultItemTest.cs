using System;
using System.Text.Json;
using FluentAssertions;
using NUnit.Framework;
using PoECommerce.TradeService.Models.Enums;
using PoECommerce.TradeService.Models.TradeAPI;
using PoECommerce.TradeService.Models.TradeAPI.Listings;

namespace PoECommerce.TradeService.Tests.Models.JsonSerializationTest.TradeAPI
{
    [TestFixture]
    public class FetchResultItemTest
    {
        public static ModelFromJsonTestCase<FetchResultItem>[] TestCases =
        {
            new ModelFromJsonTestCase<FetchResultItem>
            {
                Json = "{\"id\":null,\"listing\":null,\"item\":null}",
                ExpectedResult =
                    new FetchResultItem
                    {
                        Id = null,
                        Listing = null,
                        Item = null
                    },
                Description = "Null result"
            },
            new ModelFromJsonTestCase<FetchResultItem>
            {
                Json = "{\"id\":\"23l4kjsasdJD\",\"listing\":null,\"item\":null}",
                ExpectedResult =
                    new FetchResultItem
                    {
                        Id = "23l4kjsasdJD",
                        Listing = null,
                        Item = null
                    },
                Description = "With id"
            },
            new ModelFromJsonTestCase<FetchResultItem>
            {
                Json = "{\"id\":null,\"listing\":{\"method\":\"forum\",\"indexed\":\"2019-09-20T22:15:10Z\",\"stash\":null,\"whisper\":null,\"account\":null,\"price\":null},\"item\":null}",
                ExpectedResult =
                    new FetchResultItem
                    {
                        Id = null,
                        Listing = new Listing
                        {
                            Price = null,
                            Account = null,
                            Indexed = new DateTime(2019, 9, 20, 22, 15, 10),
                            Method = ListingMethod.Forum,
                            Stash = null,
                            Whisper = null
                        },
                        Item = null
                    },
                Description = "With listing"
            }
        };

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public void When_DeserializeFromJson(ModelFromJsonTestCase<FetchResultItem> testCase)
        {
            TestContext.Write(testCase.Description);

            // When
            FetchResultItem result = JsonSerializer.Deserialize<FetchResultItem>(testCase.Json);

            // Then
            result.Should().BeEquivalentTo(testCase.ExpectedResult);
        }
    }
}