using System.Text.Json;
using FluentAssertions;
using NUnit.Framework;
using PoECommerce.PathOfExile.Models.Search;
using PoECommerce.PathOfExile.Tests.Utility;

namespace PoECommerce.PathOfExile.Tests.Models.JsonSerializationTest.Search
{
    [TestFixture]
    public partial class QueryTest
    {
        public static ModelToJsonTestCase<Query>[] TestCases =
        {
            new ModelToJsonTestCase<Query>
            {
                Subject =
                    new Query
                    {
                        Name = "Super"
                    },
                ExpectedJson = "{\"name\":\"Super\"}"
            },
            new ModelToJsonTestCase<Query>
            {
                Subject =
                    new Query
                    {
                        Type = "Valuable item"
                    },
                ExpectedJson = "{\"type\":\"Valuable item\"}"
            },
            new ModelToJsonTestCase<Query>
            {
                Subject =
                    new Query
                    {
                        Name = "Super",
                        Type = "Valuable item"
                    },
                ExpectedJson = "{\"name\":\"Super\",\"type\":\"Valuable item\"}"
            }
        };

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public void When_SerializeToJson(ModelToJsonTestCase<Query> testCase)
        {
            TestContext.Write(testCase.Description);

            // When
            string result = JsonSerializer.Serialize(testCase.Subject, new JsonSerializerOptions { IgnoreNullValues = true });

            // Then
            result.Should().Be(testCase.ExpectedJson);
        }
    }
}