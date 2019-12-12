using System.Text.Json;
using FluentAssertions;
using NUnit.Framework;
using PoECommerce.PathOfExile.Models.Data;
using PoECommerce.PathOfExile.Tests.Utility;

namespace PoECommerce.PathOfExile.Tests.Models.JsonSerializationTest.Data
{
    [TestFixture]
    public class LeagueTest
    {
        public static ModelFromJsonTestCase<League>[] TestCases =
        {
            new ModelFromJsonTestCase<League>
            {
                Json = "{}",
                ExpectedResult =
                    new League
                    {
                        Id = null,
                        Text = null
                    },
                Description = "All nulls"
            },
            new ModelFromJsonTestCase<League>
            {
                Json = "{\"id\":\"_blight\",\"text\":\"Blight\"}",
                ExpectedResult =
                    new League
                    {
                        Id = "_blight",
                        Text = "Blight"
                    },
                Description = "With values"
            }
        };

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public void When_DeserializeFromJson(ModelFromJsonTestCase<League> testCase)
        {
            TestContext.Write(testCase.Description);

            // When
            League result = JsonSerializer.Deserialize<League>(testCase.Json);

            // Then
            result.Should().BeEquivalentTo(testCase.ExpectedResult);
        }
    }
}