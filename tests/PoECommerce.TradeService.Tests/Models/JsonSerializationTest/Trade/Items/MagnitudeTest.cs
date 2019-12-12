using System.Text.Json;
using FluentAssertions;
using NUnit.Framework;
using PoECommerce.PathOfExile.Models.Trade.Items;
using PoECommerce.PathOfExile.Tests.Utility;

namespace PoECommerce.PathOfExile.Tests.Models.JsonSerializationTest.Trade.Items
{
    [TestFixture]
    public class MagnitudeTest
    {
        public static ModelFromJsonTestCase<Magnitude>[] TestCases =
        {
            new ModelFromJsonTestCase<Magnitude>
            {
                Json = "{\"hash\":null,\"min\":90,\"max\":100}",
                ExpectedResult =
                    new Magnitude
                    {
                        Hash = null,
                        Min = 90,
                        Max = 100
                    },
                Description = "Without hash"
            },
            new ModelFromJsonTestCase<Magnitude>
            {
                Json = "{\"hash\":\"explicit.stat_3299347043\",\"min\":50,\"max\":50}",
                ExpectedResult =
                    new Magnitude
                    {
                        Hash = "explicit.stat_3299347043",
                        Min = 50,
                        Max = 50
                    },
                Description = "With hash"
            },
            new ModelFromJsonTestCase<Magnitude>
            {
                Json = "{\"hash\":\"explicit.stat_3299347043\",\"min\":0.2,\"max\":0.4}",
                ExpectedResult =
                    new Magnitude
                    {
                        Hash = "explicit.stat_3299347043",
                        Min = 0.2,
                        Max = 0.4
                    },
                Description = "Double values"
            }
        };

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public void When_DeserializeFromJson(ModelFromJsonTestCase<Magnitude> testCase)
        {
            TestContext.Write(testCase.Description);

            // When
            Magnitude result = JsonSerializer.Deserialize<Magnitude>(testCase.Json);

            // Then
            result.Should().BeEquivalentTo(testCase.ExpectedResult);
        }
    }
}