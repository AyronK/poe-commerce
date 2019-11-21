using System;
using System.Text.Json;
using FluentAssertions;
using NUnit.Framework;
using PoECommerce.TradeService.Models.Enums;
using PoECommerce.TradeService.Models.TradeAPI.Listings;

namespace PoECommerce.TradeService.Tests.Models.JsonSerializationTest.TradeAPI.Listings
{
    [TestFixture]
    public class ListingTest
    {
        public static ModelFromJsonTestCase<Listing>[] TestCases =
        {
            new ModelFromJsonTestCase<Listing>
            {
                Json = "{\"method\":\"forum\",\"indexed\":\"2019-09-20T22:15:10Z\",\"stash\":null,\"whisper\":null,\"account\":null,\"price\":null}",
                ExpectedResult =
                    new Listing
                    {
                        Price = null,
                        Account = null,
                        Indexed = new DateTime(2019, 9, 20, 22, 15, 10),
                        Method = ListingMethod.Forum,
                        Stash = null,
                        Whisper = null
                    },
                Description = "All nulls except method and indexed"
            },
            new ModelFromJsonTestCase<Listing>
            {
                Json = "{\"method\":\"psapi\",\"indexed\":\"2018-11-05T12:45:15Z\",\"stash\":null,\"whisper\":null,\"account\":null,\"price\":null}",
                ExpectedResult =
                    new Listing
                    {
                        Price = null,
                        Account = null,
                        Indexed = new DateTime(2018, 11, 5, 12, 45, 15),
                        Method = ListingMethod.PremiumStashTab,
                        Stash = null,
                        Whisper = null
                    },
                Description = "All nulls except method and indexed, different values"
            },
            new ModelFromJsonTestCase<Listing>
            {
                Json = "{\"method\":\"forum\",\"indexed\":\"2019-09-20T22:15:10Z\",\"stash\":null,\"whisper\":\"@chkoun_akalni Hi, I would like to buy your level 1 9% Static Strike listed for 1 alch in Blight (stash tab \\\"3\\\"; position: left 9, top 5)\",\"account\":null,\"price\":null}",
                ExpectedResult =
                    new Listing
                    {
                        Price = null,
                        Account = null,
                        Indexed = new DateTime(2019, 9, 20, 22, 15, 10),
                        Method = ListingMethod.Forum,
                        Stash = null,
                        Whisper = "@chkoun_akalni Hi, I would like to buy your level 1 9% Static Strike listed for 1 alch in Blight (stash tab \"3\"; position: left 9, top 5)"
                    },
                Description = "And with wishper"
            },
            new ModelFromJsonTestCase<Listing>
            {
                Json = "{\"method\":\"forum\",\"indexed\":\"2019-09-20T22:15:10Z\",\"stash\":{\"name\":\"Test\",\"x\":1,\"y\":2},\"whisper\":null,\"account\":null,\"price\":null}",
                ExpectedResult =
                    new Listing
                    {
                        Price = null,
                        Account = null,
                        Indexed = new DateTime(2019, 9, 20, 22, 15, 10),
                        Method = ListingMethod.Forum,
                        Stash = new Stash {Name = "Test", X = 1, Y = 2},
                        Whisper = null
                    },
                Description = "And with stash"
            },
            new ModelFromJsonTestCase<Listing>
            {
                Json = "{\"method\":\"forum\",\"indexed\":\"2019-09-20T22:15:10Z\",\"stash\":null,\"whisper\":null,\"account\":{\"name\":\"player1\",\"lastCharacterName\":\"character1\",\"online\":null,\"language\":\"en_US\"},\"price\":null}",
                ExpectedResult =
                    new Listing
                    {
                        Price = null,
                        Account = new Account{Name = "player1", LastCharacterName = "character1", Online = null, Language = "en_US"},
                        Indexed = new DateTime(2019, 9, 20, 22, 15, 10),
                        Method = ListingMethod.Forum,
                        Stash = null,
                        Whisper = null
                    },
                Description = "And with stash"
            },
            new ModelFromJsonTestCase<Listing>
            {
                Json = "{\"method\":\"forum\",\"indexed\":\"2019-09-20T22:15:10Z\",\"stash\":null,\"whisper\":null,\"account\":null,\"price\":{\"type\":\"~fixed\",\"amount\":10,\"currency\":\"chrom\"}}",
                ExpectedResult =
                    new Listing
                    {
                        Price = new Price{Type = "~fixed", Amount = 10, Currency = "chrom"},
                        Account = null,
                        Indexed = new DateTime(2019, 9, 20, 22, 15, 10),
                        Method = ListingMethod.Forum,
                        Stash = null,
                        Whisper = null
                    },
                Description = "And with stash"
            },
        };

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public void When_DeserializeFromJson(ModelFromJsonTestCase<Listing> testCase)
        {
            TestContext.Write(testCase.Description);

            // When
            Listing result = JsonSerializer.Deserialize<Listing>(testCase.Json);

            // Then
            result.Should().BeEquivalentTo(testCase.ExpectedResult);
        }
    }
}