using System;
using System.Text.Json;
using FluentAssertions;
using NUnit.Framework;
using PoECommerce.PathOfExile.Models.Trade;
using PoECommerce.PathOfExile.Models.Trade.Enums;
using PoECommerce.PathOfExile.Models.Trade.Listings;
using PoECommerce.PathOfExile.Tests.Utility;

namespace PoECommerce.PathOfExile.Tests.Models.JsonSerializationTest.Trade
{
    [TestFixture]
    public class ListedItemTest
    {
        public static ModelFromJsonTestCase<ListedItem>[] TestCases =
        {
            new ModelFromJsonTestCase<ListedItem>
            {
                Json = "{\"id\":null,\"listing\":null,\"item\":null}",
                ExpectedResult =
                    new ListedItem
                    {
                        Id = null,
                        Listing = null,
                        Item = null
                    },
                Description = "Null result"
            },
            new ModelFromJsonTestCase<ListedItem>
            {
                Json = "{\"id\":\"23l4kjsasdJD\",\"listing\":null,\"item\":null}",
                ExpectedResult =
                    new ListedItem
                    {
                        Id = "23l4kjsasdJD",
                        Listing = null,
                        Item = null
                    },
                Description = "With id"
            },
            new ModelFromJsonTestCase<ListedItem>
            {
                Json = "{\"id\":null,\"listing\":{\"method\":\"forum\",\"indexed\":\"2019-09-20T22:15:10Z\",\"stash\":null,\"whisper\":null,\"account\":null,\"price\":null},\"item\":null}",
                ExpectedResult =
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
                    },
                Description = "With listing"
            }
        };

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public void When_DeserializeFromJson(ModelFromJsonTestCase<ListedItem> testCase)
        {
            TestContext.Write(testCase.Description);

            // When
            ListedItem result = JsonSerializer.Deserialize<ListedItem>(testCase.Json);

            // Then
            result.Should().BeEquivalentTo(testCase.ExpectedResult);
        }
    }
}