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
    public class FetchResultTest
    {
        public static ModelFromJsonTestCase<FetchResult>[] TestCases =
        {
            new ModelFromJsonTestCase<FetchResult>
            {
                Json = "{\"result\":null}",
                ExpectedResult =
                    new FetchResult
                    {
                        Result = null
                    },
                Description = "Null result"
            },
            new ModelFromJsonTestCase<FetchResult>
            {
                Json = "{\"result\":[{\"id\":\"23l4kjsasdJD\",\"listing\":null,\"item\":null}]}",
                ExpectedResult =
                    new FetchResult
                    {
                        Result = new[]
                        {
                            new FetchResultItem
                            {
                                Id = "23l4kjsasdJD",
                                Listing = null,
                                Item = null
                            }
                        }
                    },
                Description = "With single result item"
            },
            new ModelFromJsonTestCase<FetchResult>
            {
                Json = "{\"result\":[" +
                       "{\"id\":\"23l4kjsasdJD\",\"listing\":null,\"item\":null}," +
                       "{\"id\":null,\"listing\":{\"method\":\"forum\",\"indexed\":\"2019-09-20T22:15:10Z\",\"stash\":null,\"whisper\":null,\"account\":null,\"price\":null},\"item\":null}" +
                       "]}",
                ExpectedResult =
                    new FetchResult
                    {
                        Result = new[]
                        {
                            new FetchResultItem
                            {
                                Id = "23l4kjsasdJD",
                                Listing = null,
                                Item = null
                            },
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
                            }
                        }
                    },
                Description = "With multiple result items"
            }
        };

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public void When_DeserializeFromJson(ModelFromJsonTestCase<FetchResult> testCase)
        {
            TestContext.Write(testCase.Description);

            // When
            FetchResult result = JsonSerializer.Deserialize<FetchResult>(testCase.Json);

            // Then
            result.Should().BeEquivalentTo(testCase.ExpectedResult);
        }
    }
}