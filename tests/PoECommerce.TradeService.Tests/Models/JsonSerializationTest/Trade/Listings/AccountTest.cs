using System.Text.Json;
using FluentAssertions;
using NUnit.Framework;
using PoECommerce.PathOfExile.Models.Trade.Listings;
using PoECommerce.PathOfExile.Tests.Utility;

namespace PoECommerce.PathOfExile.Tests.Models.JsonSerializationTest.Trade.Listings
{
    [TestFixture]
    public class AccountTest
    {
        public static ModelFromJsonTestCase<Account>[] TestCases =
        {
            new ModelFromJsonTestCase<Account>
            {
                Json = "{\"name\":null,\"lastCharacterName\":null,\"online\":null,\"language\":null}",
                ExpectedResult =
                    new Account
                    {
                        Name = null,
                        LastCharacterName = null,
                        Online = null,
                        Language = null
                    },
                Description = "All is empty"
            },
            new ModelFromJsonTestCase<Account>
            {
                Json = "{\"name\":\"player1\",\"lastCharacterName\":\"character1\",\"online\":null,\"language\":\"en_US\"}",
                ExpectedResult =
                    new Account
                    {
                        Name = "player1",
                        LastCharacterName = "character1",
                        Online = null,
                        Language = "en_US"
                    },
                Description = "Offline player"
            },
            new ModelFromJsonTestCase<Account>
            {
                Json = "{\"name\":\"玩家二\",\"lastCharacterName\":\"人物三\",\"online\":null,\"language\":\"zh_CN\"}",
                ExpectedResult =
                    new Account
                    {
                        Name = "玩家二",
                        LastCharacterName = "人物三",
                        Online = null,
                        Language = "zh_CN"
                    },
                Description = "Offline chinese player"
            },
            new ModelFromJsonTestCase<Account>
            {
                Json = "{\"name\":\"player1\",\"lastCharacterName\":\"character1\",\"online\":{\"status\":\"afk\",\"league\":\"Delve\"},\"language\":\"en_US\"}",
                ExpectedResult =
                    new Account
                    {
                        Name = "player1",
                        LastCharacterName = "character1",
                        Online = new Online
                        {
                            Status = "afk",
                            League = "Delve"
                        },
                        Language = "en_US"
                    },
                Description = "Online player"
            }
        };

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public void When_DeserializeFromJson(ModelFromJsonTestCase<Account> testCase)
        {
            TestContext.Write(testCase.Description);

            // When
            Account result = JsonSerializer.Deserialize<Account>(testCase.Json);

            // Then
            result.Should().BeEquivalentTo(testCase.ExpectedResult);
        }
    }
}