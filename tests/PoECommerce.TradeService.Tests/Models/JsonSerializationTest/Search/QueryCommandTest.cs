using System.Text.Json;
using FluentAssertions;
using NUnit.Framework;
using PoECommerce.PathOfExile.Models.Search;
using PoECommerce.PathOfExile.Tests.Utility;

namespace PoECommerce.PathOfExile.Tests.Models.JsonSerializationTest.Search
{
    [TestFixture]
    public class QueryCommandTest
    {
        public static ModelToJsonTestCase<QueryCommand>[] TestCases =
        {
            new ModelToJsonTestCase<QueryCommand>
            {
                Subject = new QueryCommand
                {
                    Query = null
                },
                ExpectedJson = "{}"
            },
            new ModelToJsonTestCase<QueryCommand>
            {
                Subject = new QueryCommand
                {
                    Query = new Query
                    {
                        Name = "Super",
                        Type = "Valuable item"
                    }
                },
                ExpectedJson = "{\"query\":{\"name\":\"Super\",\"type\":\"Valuable item\"}}"
            }
        };

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public void When_SerializeToJson(ModelToJsonTestCase<QueryCommand> testCase)
        {
            TestContext.Write(testCase.Description);

            // When
            string result = JsonSerializer.Serialize(testCase.Subject, new JsonSerializerOptions {IgnoreNullValues = true});

            // Then
            result.Should().Be(testCase.ExpectedJson);
        }
    }
}