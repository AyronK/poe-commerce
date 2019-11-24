using System;
using System.Text.Json;
using FluentAssertions;
using NUnit.Framework;
using PoECommerce.TradeService.Models;
using PoECommerce.TradeService.Models.Trade;
using PoECommerce.TradeService.Models.Trade.Enums;
using PoECommerce.TradeService.Models.Trade.Listings;
using PoECommerce.TradeService.Tests.Utility;

namespace PoECommerce.TradeService.Tests.Models.JsonSerializationTest
{
    [TestFixture]
    public class FetchResultTest
    {
        public static ModelFromJsonTestCase<ResponseResult<ListedItem[]>>[] TestCases =
        {
            new ModelFromJsonTestCase<ResponseResult<ListedItem[]>>
            {
                Json = "{\"result\":null}",
                ExpectedResult =
                    new ResponseResult<ListedItem[]>
                    {
                        Result = null
                    },
                Description = "Null result"
            },
            new ModelFromJsonTestCase<ResponseResult<ListedItem[]>>
            {
                Json = "{\"result\":[{\"id\":\"23l4kjsasdJD\",\"listing\":null,\"item\":null}]}",
                ExpectedResult =
                    new ResponseResult<ListedItem[]>
                    {
                        Result = new[]
                        {
                            new ListedItem
                            {
                                Id = "23l4kjsasdJD",
                                Listing = null,
                                Item = null
                            }
                        }
                    },
                Description = "With single result item"
            },
            new ModelFromJsonTestCase<ResponseResult<ListedItem[]>>
            {
                Json = "{\"result\":[" +
                       "{\"id\":\"23l4kjsasdJD\",\"listing\":null,\"item\":null}," +
                       "{\"id\":null,\"listing\":{\"method\":\"forum\",\"indexed\":\"2019-09-20T22:15:10Z\",\"stash\":null,\"whisper\":null,\"account\":null,\"price\":null},\"item\":null}" +
                       "]}",
                ExpectedResult =
                    new ResponseResult<ListedItem[]>
                    {
                        Result = new[]
                        {
                            new ListedItem
                            {
                                Id = "23l4kjsasdJD",
                                Listing = null,
                                Item = null
                            },
                            new ListedItem
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
        public void When_DeserializeFromJson(ModelFromJsonTestCase<ResponseResult<ListedItem[]>> testCase)
        {
            TestContext.Write(testCase.Description);

            // When
            ResponseResult<ListedItem[]> result = JsonSerializer.Deserialize<ResponseResult<ListedItem[]>>(testCase.Json);

            // Then
            result.Should().BeEquivalentTo(testCase.ExpectedResult);
        }
    }
}